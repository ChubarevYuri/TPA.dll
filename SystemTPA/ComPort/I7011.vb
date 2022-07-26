Public Class I7011
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
    Public Function ReadValue(ByRef answer As Double) As String
        Dim command = "#" & Dtohc(address, 2)
        Dim strAnswer As String = ""
        ReadValue = SendRec(strAnswer, command, port.ReadTimeout, ">", CheckSum:=crc)
        DeleteIndicator(strAnswer)
        Try
            answer = Convert.ToDouble(strAnswer)
        Catch ex As Exception
            answer = 0
        End Try
    End Function
End Class
