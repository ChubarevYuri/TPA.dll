Public Class ComPort

    Public Enum Parity
        None = 0
        Odd = 1
        Even = 2
        Mark = 3
        Space = 4
    End Enum

    Public Enum StopBits
        None = 0
        One = 1
        Two = 2
        OnePointFive = 3
    End Enum

    Public port As New IO.Ports.SerialPort()

    ''' <summary>
    ''' Создание экземпляра с открытием порта
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Close()
        Open()
    End Sub
    Public Sub New(ByRef name As String, _
                   ByRef baudRate As Integer, _
                   ByRef parity As Parity, _
                   ByRef dataBits As Integer, _
                   ByRef stopBits As StopBits, _
                   Optional ByRef readTimeout As Integer = 100, _
                   Optional ByRef writeTimeout As Integer = 100)
        Close()
        port.PortName = name
        port.BaudRate = baudRate
        port.Parity = parity
        port.DataBits = dataBits
        port.StopBits = stopBits
        port.ReadTimeout = readTimeout
        port.WriteTimeout = writeTimeout
        Open()
    End Sub

    ''' <summary>
    ''' Закрытие порта
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        port.Close()
    End Sub

    ''' <summary>
    ''' процедура чтения записи по последовательному порту
    ''' Rec - принятая строка
    ''' Send - отправляемая строка
    ''' TimeOut - тайм аут на прием
    ''' CheckSum - контрольная сумма
    ''' Count - количество попыток посылок
    ''' SendVBCr - отправлять ли VbCr
    ''' Contain - список допустимых ответов на запрос
    ''' </summary>
    ''' <param name="Rec">ответ</param>
    ''' <param name="Send">сообщение</param>
    ''' <param name="TimeOut">вемя ожидания ответа</param>
    ''' <param name="Contain">символы выполненной команды</param>
    ''' <param name="CheckSum">осуществление контроля целостности путем добавления контрольной суммы</param>
    ''' <returns>Сообщение ошибки</returns>
    ''' <remarks></remarks>
    Friend Overloads Function SendRec(ByRef Rec As String, _
                                      ByVal Send As String, _
                                      ByVal TimeOut As Integer, _
                                      Optional ByVal Contain As String = "", _
                                      Optional ByVal isRead As Boolean = True, _
                                      Optional ByVal CheckSum As Boolean = True, _
                                      Optional ByVal RemoveCS As Boolean = True) As String
        If port IsNot Nothing Then
            If Not port.IsOpen Then Open()
            Dim TimeStart As Integer = Environment.TickCount
            If CheckSum Then Send = AddCRC(Send)
            If port.IsOpen Then
                port.DiscardOutBuffer()
                port.DiscardInBuffer()
                Send &= vbCr
                port.Write(Send)
                Do While port.BytesToWrite > 0
                    Threading.Thread.Sleep(1)
                Loop
                TimeStart = Environment.TickCount
                Rec = ""
                'reception
                If isRead Then
                    Do While (Environment.TickCount - TimeStart) < TimeOut
                        Dim rbuf As String = port.ReadExisting()
                        For Each recchar In rbuf
                            If (recchar = vbCr) OrElse (recchar = vbLf) Then
                                'пришел CRLF проверяем на наличие ответа
                                If Rec.Length > 2 Then
                                    If CheckSum Then
                                        If CheckCRC(Rec, RemoveCS) Then
                                            If Len(Contain) = 0 Then
                                                Return ""
                                            End If
                                            For Each vl As Char In Contain
                                                If Rec.IndexOf(vl) <> -1 Then
                                                    Return ""
                                                Else
                                                    Return "Ответ неверен: " & Send & " -> " & Rec
                                                End If
                                            Next
                                        End If
                                    Else
                                        For Each vl As String In Contain
                                            If Rec.IndexOf(vl) <> -1 Then
                                                Return ""
                                            Else
                                                Return "Ответ неверен: " & Send & " -> " & Rec
                                            End If
                                        Next
                                    End If
                                Else
                                    If CheckSum Then
                                        Return "Ответ неверен: " & Send & " -> " & Rec
                                    Else
                                        Return ""
                                    End If
                                End If
                            Else
                                Rec &= recchar
                            End If
                            Threading.Thread.Sleep(1)
                        Next
                    Loop
                Else
                    Return ""
                End If
            End If
            Return "Ошибка времени выполнения (" & port.PortName & ") - " & _
                   (Environment.TickCount - TimeStart).ToString & "ms send - " & Send & " rec - " & Rec
        Else
            Return "Порт " & port.PortName & " закрыт"
        End If
        Return "Порт " & port.PortName & " закрыт"
    End Function

    ''' <summary>
    ''' Открытие порта
    ''' </summary>
    ''' <returns>сообение ошибки</returns>
    ''' <remarks></remarks>
    Friend Function Open() As String
        Try
            If port.IsOpen Then
                port.Close()
            End If
            port.Open()
            Open = ""
        Catch ex As Exception
            Open = "Открытие порта " & port.PortName & " невозможно (" & ex.Message & ")"
        End Try
    End Function

    ''' <summary>
    ''' Проверка контрольной суммы строки
    ''' </summary>
    ''' <param name="val"></param>
    ''' <param name="RemoveCS"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckCRC(ByRef val As String, Optional ByVal RemoveCS As Boolean = False) As Boolean
        CheckCRC = False
        Try
            If val.Length > 2 Then
                Dim iCRC1 As Integer = 0
                Dim iCRC2 As Integer = Convert.ToInt32(val.Substring(val.Length - 2), 16)
                For i As Integer = 0 To val.Length - 3
                    iCRC1 += Asc(val.Substring(i, 1))
                Next
                If (iCRC1 And 255) = iCRC2 Then
                    CheckCRC = True

                    If RemoveCS Then
                        Dim len As Integer = val.Length
                        val = val.Remove(len - 2, 2)
                    End If
                End If
            End If
        Catch ex As Exception
            CheckCRC = False
        End Try
    End Function

    ''' <summary>
    ''' добавляет контрольную сумму к строке
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AddCRC(ByVal val As String) As String
        Dim cs As Long = 0
        For Each ch As Char In val
            cs += Asc(ch)
        Next
        cs = cs And 255
        Return val & Dtohc(cs)
    End Function

    ''' <summary>
    ''' преобразует в HEX формат с одним лидирующим нулем
    '''  val - не более 255
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Dtohc(ByVal val As Integer) As String
        val = val And 255
        If val < 16 Then Return "0" & val.ToString("X")
        Return val.ToString("X")
    End Function
End Class