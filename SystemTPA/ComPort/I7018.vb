Public Class I7018
    Inherits I7000

    Public Sub New(ByRef _address As Integer, _
                   ByRef name As String, _
                   ByRef baudRate As Integer, _
                   ByRef parity As Parity, _
                   ByRef dataBits As Integer, _
                   ByRef stopBits As StopBits, _
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
    ''' Чтение значения
    ''' </summary>
    ''' <param name="answer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadValue(ByRef answer As Double()) As String
        Dim command = "#" & Dtohc(address, 2)
        Dim strAnswer As String = ""
        ReadValue = SendRec(strAnswer, command, port.ReadTimeout, ">", CheckSum:=crc)
        DeleteIndicator(strAnswer)
        Try
            Dim result As List(Of Double) = New List(Of Double)
            Dim i As Integer = 0
            If strAnswer.Contains(".") Then
                Do While strAnswer.Length >= 7
                    Try
                        result.Add(Convert.ToDouble(strAnswer.Substring(0, 7)))
                    Catch ex As Exception
                        ReadValue &= " канал " & i & " не преобразован"
                        result.Add(0)
                    Finally
                        Try
                            strAnswer = strAnswer.Substring(7)
                        Catch ex As Exception
                            strAnswer = ""
                        End Try
                    End Try
                    i += 1
                Loop
            Else
                Do While strAnswer.Length >= 4
                    Try
                        result.Add(Convert.ToInt32(strAnswer.Substring(0, 4), 16))
                    Catch ex As Exception
                        ReadValue &= " канал " & i & " не преобразован"
                        result.Add(0)
                    Finally
                        Try
                            strAnswer = strAnswer.Substring(4)
                        Catch ex As Exception
                            strAnswer = ""
                        End Try
                    End Try
                Loop
            End If
            answer = result.ToArray
        Catch ex As Exception
            answer = New Double() {}
        End Try
    End Function
End Class
