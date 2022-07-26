Public Class KS8
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

#Region "reader"

    ''' <summary>
    ''' Опрос состояния указанного канала
    ''' </summary>
    ''' <param name="status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RelayStat(ByRef status As Boolean, ByRef _channel As Integer) As String
        Dim command = "@" & Dtohc(address, 2)
        Dim answer = ""
        RelayStat = SendRec(answer, command, port.ReadTimeout, ">", CheckSum:=crc)
        DeleteIndicator(answer)
        If RelayStat.Length = 0 Then
            Dim res = Convert.ToUInt32(answer, 16)
            status = (res \ RangTwo(_channel)) Mod 2
        End If
    End Function

    ''' <summary>
    ''' Опрос состояния указанного канала
    ''' </summary>
    ''' <param name="status"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RelayStat(ByRef status As Boolean()) As String
        Dim command = "@" & Dtohc(address, 2)
        Dim answer = ""
        RelayStat = SendRec(answer, command, port.ReadTimeout, ">", CheckSum:=crc)
        DeleteIndicator(answer)
        If RelayStat.Length = 0 Then
            Dim res = Convert.ToUInt32(answer, 16)
            For i = 0 To status.Length - 1
                status(i) = (res \ RangTwo(i)) Mod 2
            Next
        End If
    End Function

#End Region

#Region "using"

    ''' <summary>
    ''' Выключить все каналы
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AllOFF() As DeviseInspection.CommandType
        AllOFF = NewCommand("@", "0000", contain:=">")
    End Function

    ''' <summary>
    ''' Включение указанного канала
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RelayON(ByRef _channel As Integer) As DeviseInspection.CommandType
        If _channel < 8 Then
            RelayON = NewCommand("#", "A" & Dtohc(_channel, 1) & "01", contain:=">")
        Else
            RelayON.command = ""
            RelayON.contain = ""
            RelayON.readAnswer = False
            RelayON.device = Me
        End If
    End Function

    ''' <summary>
    ''' Выключение указанного канала
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RelayOFF(ByRef _channel As Integer) As DeviseInspection.CommandType
        If _channel < 8 Then
            RelayOFF = NewCommand("#", "A" & Dtohc(_channel, 1) & "00", contain:=">")
        Else
            RelayOFF.command = ""
            RelayOFF.contain = ""
            RelayOFF.readAnswer = False
            RelayOFF.device = Me
        End If
    End Function

    ''' <summary>
    ''' Изменение состояния указанного канала
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RelayNOT(ByRef _channel As Integer) As DeviseInspection.CommandType
        Dim status As Boolean = False
        If RelayStat(status, _channel).Length = 0 Then
            If status Then
                RelayNOT = RelayOFF(_channel)
            Else
                RelayNOT = RelayON(_channel)
            End If
        Else
            RelayNOT.command = ""
            RelayNOT.contain = ""
            RelayNOT.readAnswer = False
            RelayNOT.device = Me
        End If
    End Function

#End Region

End Class