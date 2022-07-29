Public Class КМФ_1115_омметр
    Inherits I7000

    ''' <summary>
    ''' Резисторы
    ''' </summary>
    ''' <remarks></remarks>
    Public Rобр As Double() = {100.51, 998, 10030, 99767}

    Public Sub New(ByRef _address As Integer, _
                   ByRef name As String, _
                   Optional ByRef baudRate As Integer = 9600, _
                   Optional ByRef parity As Parity = Parity.None, _
                   Optional ByRef dataBits As Integer = 8, _
                   Optional ByRef stopBits As StopBits = StopBits.One, _
                   Optional ByVal _CRC As Boolean = True, _
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
        address = _address
        crc = _CRC
    End Sub

    ''' <summary>
    ''' Измерение сопротивления
    ''' res = minvalue - не получен ответ
    ''' res = Nothing  - обнаружено напряжение
    ''' res = 0        - КЗ
    ''' res = maxvalue - обрыв
    ''' </summary>
    ''' <param name="ms">максимальное время для измерения</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property val(Optional ByVal ms As Integer = 100) As Double
        Get
            Dim answer As String = ""
            If ReadWriteCommand(NewCommand("$", "S1", True, True, ">"), answer).Length = 0 Then
                Dim sost As Integer = 1
                Dim start As DateTime = Now
                Do While (0 < sost And sost < 3 And start.AddMilliseconds(ms) < Now)
                    answer = ""
                    If ReadWriteCommand(NewCommand("$", "F", True, True, ">"), answer).Length = 0 Then
                        Try
                            sost = Convert.ToInt32(answer)
                        Catch ex As Exception
                            sost = 1
                        End Try
                    End If
                Loop
                Select Case sost
                    Case 0
                        If ReadWriteCommand(NewCommand("$", "U", True, True, ">"), answer).Length = 0 Then
                            Dim d As Integer
                            Dim u As Double
                            Try
                                d = Convert.ToInt32(Split(answer, ":")(0)) - 1
                            Catch ex As Exception
                                Return val
                            End Try
                            Try
                                u = Convert.ToDouble(Split(answer, ":")(1))
                            Catch ex As Exception
                                Return val
                            End Try
                            Try
                                Return u * Rобр(d) / (10 - u)
                            Catch ex As Exception
                            End Try
                        End If
                    Case 1
                        Return Integer.MinValue
                    Case 2
                        Return Integer.MinValue
                    Case 3
                        Return Integer.MaxValue
                    Case 4
                        Return Nothing
                    Case 5
                        Return 0
                End Select
            End If
            Return Integer.MinValue
        End Get
    End Property

End Class
