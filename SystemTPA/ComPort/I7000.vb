''' <summary>
''' Все команды возвращают True в случае успешного выполнения команды
''' возврат ответа в ссылку
''' </summary>
''' <remarks></remarks>
Public Class I7000
    Inherits ComPort

    Public address As Integer
    Public crc As Boolean

    Public Sub New()
        Close()
        address = 0
        crc = True
        Open()
    End Sub

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
    ''' Исполнение неучтенной команды
    ''' answer - переменная для ответа
    ''' indicator - индикатор команды
    ''' command - текст команды
    ''' useAddress - использовать ли адрес
    ''' useAnswer - читать ли ответ
    ''' contain - блок индикаторов допустимых ответов
    ''' </summary>
    ''' <param name="indicator"></param>
    ''' <param name="command"></param>
    ''' <param name="useAddress"></param>
    ''' <param name="useAnswer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NewCommand(ByVal indicator As Char, _
                               ByVal command As String, _
                               Optional ByVal useAddress As Boolean = True, _
                               Optional ByVal useAnswer As Boolean = True, _
                               Optional ByVal contain As String = "") As DeviseInspection.CommandType
        If useAddress Then
            command = indicator & Dtohc(address, 2) & command
        Else
            command = indicator & command
        End If
        NewCommand.readAnswer = useAnswer
        NewCommand.command = command
        NewCommand.contain = contain
        NewCommand.device = Me
        'SendRec(answer, command, 100, contain, useAnswer, crc)
        'DeleteIndicator(answer)
    End Function

    ''' <summary>
    ''' Опрос имени устройства
    ''' </summary>
    ''' <param name="answer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadName(ByRef answer As String) As DeviseInspection.CommandType
        ReadName = NewCommand("$", "M", True, True, "!")
    End Function

    ''' <summary>
    ''' преобразует в HEX формат с указанным количеством символов
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Dtohc(ByVal val As Integer, ByVal len As Integer) As String
        Dtohc = ""
        Do While len > 0
            len -= 1
            Dtohc = (val Mod 16).ToString("X") & Dtohc
            val /= 16
        Loop
    End Function

    ''' <summary>
    ''' 2^n
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RangTwo(ByVal n As Integer) As Integer
        If n = 0 Then
            Return 1
        Else
            Return 2 * RangTwo(n - 1)
        End If
    End Function

    ''' <summary>
    ''' Удаление первого символа
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Sub DeleteIndicator(ByRef text As String)
        If Len(text) > 0 Then text = text.Substring(1)
    End Sub

    ''' <summary>
    ''' отправка команды на выполнение
    ''' </summary>
    ''' <param name="command"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function ReadWriteCommand(ByVal command As DeviseInspection.CommandType, _
                                     Optional ByRef answer As String = "") As String
        ReadWriteCommand = SendRec(answer, _
                                   command.command, _
                                   port.ReadTimeout + port.WriteTimeout, _
                                   command.contain, _
                                   command.readAnswer, _
                                   crc)
        DeleteIndicator(answer)
    End Function

End Class
