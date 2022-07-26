﻿'при объявлении новых классов их необходимо добавить в:
'addDevice
'main()
'read dev

Public Module DeviseInspection

    Public Structure ResultType
        Dim answer As Object
        Dim time As Date
        Dim err As String
    End Structure

    Public Structure CommandType
        Dim command As String
        Dim contain As String
        Dim readAnswer As Boolean
        Dim device As I7000
    End Structure

    Private _thread As Threading.Thread = New Threading.Thread(AddressOf _main)


    Private inspection As Boolean = True
    'список устройств
    Public devices As ArrayList = New ArrayList


    Private __commands As ArrayList = New ArrayList
    Private Sub _command(ByVal com As CommandType)
        _ex = com.device.ReadWriteCommand(com)
    End Sub
    Public Sub AddCommand(ByVal command As CommandType)
        __commands.Add(command)
    End Sub

    Private __ex As ArrayList = New ArrayList
    ''' <summary>
    ''' запись ошибки в буфер
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Private WriteOnly Property _ex() As String
        Set(ByVal value As String)
            If value.Length > 0 Then __ex.Add(value)
            If __ex.Count > 10 Then __ex.RemoveAt(0)
        End Set
    End Property
    ''' <summary>
    ''' чтение буфера ошибок
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ex() As ArrayList
        Get
            ex = New ArrayList
            For Each e In __ex
                ex.Add(e)
            Next
            __ex.Clear()
        End Get
    End Property

    Public Sub exClear()
        __ex.Clear()
    End Sub

    Private __result As Dictionary(Of Integer, ResultType) = New Dictionary(Of Integer, ResultType)
    ''' <summary>
    ''' запись ответа после опроса модуля
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Private WriteOnly Property _result() As KeyValuePair(Of Integer, ResultType)
        Set(ByVal value As KeyValuePair(Of Integer, ResultType))
            __result(value.Key) = value.Value
        End Set
    End Property
    ''' <summary>
    ''' чтение ответа указанного канала
    ''' </summary>
    ''' <param name="channel"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property result(ByVal channel As Integer) As ResultType
        Get
            If __result.ContainsKey(channel) Then
                result = __result(channel)
                _endInspection = False
            Else
                result.err = "канал " & channel & "не записан"
                result.time = Now
                result.answer = ""
            End If
        End Get
    End Property

    Private _endInspection As Boolean = False
    ''' <summary>
    ''' Был ли выполнен цикл опроса модулей после последнего чтения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property endInspection() As Boolean
        Get
            Return _endInspection
        End Get
    End Property

    ''' <summary>
    ''' Добавление устройства в перечень
    ''' </summary>
    ''' <param name="device">устройство</param>
    ''' <remarks></remarks>
#Region "addDevice"

    Public Sub addDevice(ByRef device As KS8)
        devices.Add(device)
    End Sub
    Public Sub addDevice(ByRef device As I7018)
        devices.Add(device)
    End Sub
    Public Sub addDevice(ByRef device As I7011)
        devices.Add(device)
    End Sub

#End Region

    Public Sub stopInspection()
        inspection = False
    End Sub

    Public Sub startInspection()
        _thread.Priority = Threading.ThreadPriority.Normal
        inspection = True
        _thread.Start()
    End Sub

    Private Sub _main()
        Do
            For Each dev In devices
                Do While __commands.Count > 0
                    _command(__commands(0))
                    __commands.RemoveAt(0)
                Loop
                If TypeOf dev Is KS8 Then
                    ReadKS8(dev)
                ElseIf TypeOf dev Is I7011 Then
                    ReadI7011(dev)
                ElseIf TypeOf dev Is I7018 Then
                    ReadI7018(dev)
                End If
            Next
            _endInspection = True
            If Not inspection Then Exit Do
        Loop
    End Sub

    ''' <summary>
    ''' чтение состояния модуля и запись в буфер
    ''' (запись ошибки чтения в буфер)
    ''' </summary>
    ''' <param name="dev">опрашиваемый модуль</param>
    ''' <remarks></remarks>
#Region "read dev"

    Private Sub ReadKS8(ByRef dev As KS8)
        Dim answer As Dictionary(Of Integer, Boolean)
        Try
            answer = result(dev.address).answer
        Catch ex As Exception
            answer = New Dictionary(Of Integer, Boolean)
            answer.Add(0, False)
            answer.Add(1, False)
            answer.Add(2, False)
            answer.Add(3, False)
            answer.Add(4, False)
            answer.Add(5, False)
            answer.Add(6, False)
            answer.Add(7, False)
        End Try
        Dim stat(7) As Boolean
        Dim dimex As String = dev.RelayStat(stat)
        If dimex.Length = 0 Then
            For i As Integer = 0 To 7
                answer(i) = stat(i)
            Next
        End If
        _result = New KeyValuePair(Of Integer, ResultType)(dev.address, answerToResultType(answer, dimex))
    End Sub

    Private Sub ReadI7011(ByRef dev As I7011)
        Dim answer As Double
        Try
            answer = result(dev.address).answer
        Catch ex As Exception
            answer = 0
        End Try
        Dim dimex = dev.ReadValue(answer)
        _result = New KeyValuePair(Of Integer, ResultType)(dev.address, answerToResultType(answer, dimex))
    End Sub

    Private Sub ReadI7018(ByRef dev As I7018)
        Dim answer = New Dictionary(Of Integer, Double)
        Dim dimex = ""
        Dim stat As Double() = {0, 0, 0, 0, 0, 0, 0, 0}
        dimex &= dev.ReadValue(stat)
        If dimex.Length <> 0 Then
            Try
                answer = result(dev.address).answer
            Catch ex As Exception
                answer.Add(0, 0)
                answer.Add(1, 0)
                answer.Add(2, 0)
                answer.Add(3, 0)
                answer.Add(4, 0)
                answer.Add(5, 0)
                answer.Add(6, 0)
                answer.Add(7, 0)
            End Try
        Else
            For j = 0 To stat.Length - 1
                answer(j) = stat(j)
            Next
        End If
        _result = New KeyValuePair(Of Integer, ResultType)(dev.address, answerToResultType(answer, dimex))
    End Sub

#End Region

    Private Function answerToResultType(ByRef answer As Object, ByVal err As String) As ResultType
        answerToResultType.time = Now
        answerToResultType.answer = answer
        answerToResultType.err = err
    End Function

End Module
