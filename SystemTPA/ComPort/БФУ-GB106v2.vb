Public Class БФУ_GB106v2
    Inherits I7000

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

#Region "Что опрашиваем"

    Public ОПРОСдискреты As Boolean = False
    Public ОПРОСAin1 As Boolean = False
    Public ОПРОСAin2 As Boolean = False
    Public ОПРОСAin3 As Boolean = False
    Public ОПРОСчастота As Boolean = False
    Public ОПРОСугол As Boolean = False

#End Region

#Region "Read"
    Public ReadOnly Property val() As Dictionary(Of String, DeviseInspection.ResultType)
        Get
            val = New Dictionary(Of String, DeviseInspection.ResultType)
            If ОПРОСдискреты Then
                Dim res As KeyValuePair(Of String, KeyValuePair(Of Boolean(), Boolean())) = Дискреты
                Dim answer As DeviseInspection.ResultType = New DeviseInspection.ResultType
                answer.err = res.Key
                answer.answer = res.Value
                val.Add("Дискреты", answer)
            End If
            If ОПРОСAin1 Then
                Dim res As KeyValuePair(Of String, Double) = Ain1
                Dim answer As DeviseInspection.ResultType = New DeviseInspection.ResultType
                answer.err = res.Key
                answer.answer = res.Value
                val.Add("Ain1", answer)
            End If
            If ОПРОСAin2 Then
                Dim res As KeyValuePair(Of String, Double) = Ain2
                Dim answer As DeviseInspection.ResultType = New DeviseInspection.ResultType
                answer.err = res.Key
                answer.answer = res.Value
                val.Add("Ain2", answer)
            End If
            If ОПРОСAin3 Then
                Dim res As KeyValuePair(Of String, Double) = Ain3
                Dim answer As DeviseInspection.ResultType = New DeviseInspection.ResultType
                answer.err = res.Key
                answer.answer = res.Value
                val.Add("Ain3", answer)
            End If
            If ОПРОСчастота Then
                Dim res As KeyValuePair(Of String, Integer) = Частота
                Dim answer As DeviseInspection.ResultType = New DeviseInspection.ResultType
                answer.err = res.Key
                answer.answer = res.Value
                val.Add("Частота", answer)
            End If
            If ОПРОСугол Then
                Dim res As KeyValuePair(Of String, Integer) = Угол
                Dim answer As DeviseInspection.ResultType = New DeviseInspection.ResultType
                answer.err = res.Key
                answer.answer = res.Value
                val.Add("Угол", answer)
            End If
            Return val
        End Get
    End Property

    ''' <summary>
    ''' (ошибка,    (in(1,2,3,4,5,6,7,8), out(1,2,3,4,5,6,7,8)))
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Дискреты() As KeyValuePair(Of String, KeyValuePair(Of Boolean(), Boolean()))
        Get
            Dim statI As Boolean() = New Boolean() {False, False, False, False, False, False, False, False}
            Dim statO As Boolean() = New Boolean() {False, False, False, False, False, False, False, False}
            Dim answer As String = ""
            Dim err = ReadWriteCommand(NewCommand("@", "", True, True, ">"), answer)
            If err.Length = 0 Then
                Dim resI = Convert.ToUInt32(answer.Substring(0, 2), 16)
                Dim resO = Convert.ToUInt32(answer.Substring(2), 16)
                For i As Integer = 0 To statI.Length - 1
                    statI(i) = (resI \ RangTwo(i)) Mod 2
                    statO(i) = (resO \ RangTwo(i)) Mod 2
                Next
            End If
            Dim res As KeyValuePair(Of Boolean(), Boolean()) = New KeyValuePair(Of Boolean(), Boolean())(statI, statO)
            Return New KeyValuePair(Of String, KeyValuePair(Of Boolean(), Boolean()))(err, res)
        End Get
    End Property

    ''' <summary>
    ''' (ошибка,    val)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Ain1() As KeyValuePair(Of String, Double)
        Get
            Return Ain(1)
        End Get
    End Property

    ''' <summary>
    ''' (ошибка,    val)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Ain2() As KeyValuePair(Of String, Double)
        Get
            Return Ain(2)
        End Get
    End Property

    ''' <summary>
    ''' (ошибка,    val)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Ain3() As KeyValuePair(Of String, Double)
        Get
            Return Ain(3)
        End Get
    End Property

    ''' <summary>
    ''' (ошибка,    val)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Ain(ByVal канал As Integer) As KeyValuePair(Of String, Double)
        Get
            Dim answer As String = ""
            Dim res As Double = 0
            Dim err = ReadWriteCommand(NewCommand("#", канал.ToString(), True, True, ">"), answer)
            If err.Length = 0 Then
                res = Convert.ToDouble(answer)
            End If
            Return New KeyValuePair(Of String, Double)(err, res)
        End Get
    End Property

    ''' <summary>
    ''' (ошибка,    val)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Частота() As KeyValuePair(Of String, Integer)
        Get
            Dim answer As String = ""
            Dim res As Integer = 0
            Dim err = ReadWriteCommand(NewCommand("#", "N", True, True, ">"), answer)
            If err.Length = 0 Then
                res = Convert.ToInt32(answer, 16)
            End If
            Return New KeyValuePair(Of String, Integer)(err, res)
        End Get
    End Property

    ''' <summary>
    ''' (ошибка,    val)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Угол() As KeyValuePair(Of String, Integer)
        Get
            Dim answer As String = ""
            Dim res As Integer = 0
            Dim err = ReadWriteCommand(NewCommand("$", "G", True, True, ">"), answer)
            If err.Length = 0 Then
                res = Convert.ToInt32(answer, 16)
            End If
            Return New KeyValuePair(Of String, Integer)(err, res)
        End Get
    End Property
#End Region

    Public Function out7(ByVal stat As Boolean) As DeviseInspection.CommandType
        Return NewCommand("#", "A60" & If(stat, "1", "0"), contain:=">")
    End Function

    Public Function out8(ByVal stat As Boolean) As DeviseInspection.CommandType
        Return NewCommand("#", "A70" & If(stat, "1", "0"), contain:=">")
    End Function

    Public Function Регулятор(ByVal val As Integer) As DeviseInspection.CommandType
        Return NewCommand("$", "P" & val.ToString(), contain:="!>")
    End Function

    Public Function УголОткрытияПлавно(ByVal угол As Integer) As DeviseInspection.CommandType
        Return NewCommand("$", "A" & угол.ToString(), contain:="!")
    End Function

    Public Function УголОткрытияБыстро(ByVal угол As Integer) As DeviseInspection.CommandType
        Return NewCommand("$", "AF" & угол.ToString(), contain:="!")
    End Function

    Public Function УголАльфа(ByVal угол As Integer) As DeviseInspection.CommandType
        Return NewCommand("$", "AI" & угол.ToString(), contain:="!")
    End Function

    Public Function Сброс() As DeviseInspection.CommandType
        Return NewCommand("$", "R", contain:="!")
    End Function

End Class
