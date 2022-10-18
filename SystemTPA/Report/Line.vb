''' <summary>
''' Класс по созданию ворматированной строки для протокола
''' </summary>
''' <remarks></remarks>
Public Class Line

#Region "global enum"

    ''' <summary>
    ''' положение текста в выделенном поле
    ''' по вертикали и по горизонтали
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Align
        Left
        Center
        Right
    End Enum

    ''' <summary>
    ''' стиль подчеркивания
    ''' None - нет
    ''' Underline - подчеркиваие
    ''' Strikethrough - зачеркивание
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum StyleLine
        None
        Underline
        Strikethrough
        UnderlineStrikethrough
        FillUnderline
        FillUnderlineStrikethrough
    End Enum

#End Region

#Region "global val"

    ''' <summary>
    ''' Текст
    ''' </summary>
    ''' <remarks></remarks>
    Public text As String
    Private _interval As Single = 1
    ''' <summary>
    ''' межстрочный интервал
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property interval() As Single
        Get
            Return _interval
        End Get
        Set(ByVal value As Single)
            If value < 1 Then
                _interval = 1
            ElseIf value > 10 Then
                _interval = 10
            Else
                _interval = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' Положение текста в контейнере
    ''' </summary>
    ''' <remarks></remarks>
    Public textAlign As Align = Align.Left
    ''' <summary>
    ''' Тип подчеркивания текста
    ''' </summary>
    ''' <remarks></remarks>
    Public fontLine As StyleLine = StyleLine.None
    Private _fontSize As Single = 14
    ''' <summary>
    ''' Размер текста
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property fontSize() As Single
        Get
            Return _fontSize
        End Get
        Set(ByVal value As Single)
            If value < 0 Then
                _fontSize = 0
            ElseIf value > 48 Then
                _fontSize = 48
            Else
                _fontSize = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' жирный текст
    ''' </summary>
    ''' <remarks></remarks>
    Public fontBold As Boolean = False
    Private _indentTop As Integer = 0
    ''' <summary>
    ''' Отступ сверху в см
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property indentTop() As Integer
        Get
            Return _indentTop
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                _indentTop = 0
            Else
                _indentTop = value
            End If
        End Set
    End Property
    Private _indentLeft As Integer = 0
    ''' <summary>
    ''' Отступ слева в см
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property indentLeft() As Integer
        Get
            Return _indentLeft
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                _indentLeft = 0
            Else
                _indentLeft = value
            End If
        End Set
    End Property
    Private _indentRight As Integer = 0
    ''' <summary>
    ''' отступ справа в см
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property indentRight() As Integer
        Get
            Return _indentRight
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                _indentRight = 0
            Else
                _indentRight = value
            End If
        End Set
    End Property

#End Region

#Region "new()"
    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        text = ""
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String)
        text = _text
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _textAlign As Align)
        text = _text
        textAlign = _textAlign
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <param name="_fontLine">Стиль подчеркивания</param>
    ''' <param name="_fontBold">Жирный текст</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _textAlign As Align, ByVal _fontLine As StyleLine, Optional ByVal _fontBold As Boolean = False)
        text = _text
        textAlign = _textAlign
        fontLine = _fontLine
        fontBold = _fontBold
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <param name="_fontLine">Стиль подчеркивания</param>
    ''' <param name="_fontSize">Размер шрифта</param>
    ''' <param name="_fontBold">Жирный текст</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _textAlign As Align, ByVal _fontLine As StyleLine, ByVal _fontSize As Single, Optional ByVal _fontBold As Boolean = False)
        text = _text
        textAlign = _textAlign
        fontLine = _fontLine
        fontSize = _fontSize
        fontBold = _fontBold
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer)
        text = _text
        indentLeft = _identLeft
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _textAlign As Align)
        text = _text
        indentLeft = _identLeft
        textAlign = _textAlign
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <param name="_fontLine">Стиль подчеркивания</param>
    ''' <param name="_fontBold">Жирный текст</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _textAlign As Align, ByVal _fontLine As StyleLine, Optional ByVal _fontBold As Boolean = False)
        text = _text
        indentLeft = _identLeft
        textAlign = _textAlign
        fontLine = _fontLine
        fontBold = _fontBold
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <param name="_fontLine">Стиль подчеркивания</param>
    ''' <param name="_fontSize">Размер шрифта</param>
    ''' <param name="_fontBold">Жирный текст</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _textAlign As Align, ByVal _fontLine As StyleLine, ByVal _fontSize As Single, Optional ByVal _fontBold As Boolean = False)
        text = _text
        indentLeft = _identLeft
        textAlign = _textAlign
        fontLine = _fontLine
        fontSize = _fontSize
        fontBold = _fontBold
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_identRight">Отступ справа</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _identRight As Integer)
        text = _text
        indentLeft = _identLeft
        indentRight = _identRight
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_identRight">Отступ справа</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _identRight As Integer, ByVal _textAlign As Align)
        text = _text
        indentLeft = _identLeft
        textAlign = _textAlign
        indentRight = _identRight
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_identRight">Отступ справа</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <param name="_fontLine">Стиль подчеркивания</param>
    ''' <param name="_fontBold">Жирный текст</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _identRight As Integer, ByVal _textAlign As Align, ByVal _fontLine As StyleLine, Optional ByVal _fontBold As Boolean = False)
        text = _text
        indentLeft = _identLeft
        textAlign = _textAlign
        fontLine = _fontLine
        fontBold = _fontBold
        indentRight = _identRight
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_identRight">Отступ справа</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <param name="_fontLine">Стиль подчеркивания</param>
    ''' <param name="_fontSize">Размер шрифта</param>
    ''' <param name="_fontBold">Жирный текст</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _identRight As Integer, ByVal _textAlign As Align, ByVal _fontLine As StyleLine, ByVal _fontSize As Single, Optional ByVal _fontBold As Boolean = False)
        text = _text
        indentLeft = _identLeft
        textAlign = _textAlign
        fontLine = _fontLine
        fontSize = _fontSize
        fontBold = _fontBold
        indentRight = _identRight
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_identRight">Отступ справа</param>
    ''' <param name="_identTop">Отступ сверху</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _identRight As Integer, ByVal _identTop As Integer)
        text = _text
        indentLeft = _identLeft
        indentRight = _identRight
        indentTop = _identTop
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_identRight">Отступ справа</param>
    ''' <param name="_identTop">Отступ сверху</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _identRight As Integer, ByVal _identTop As Integer, ByVal _textAlign As Align)
        text = _text
        indentLeft = _identLeft
        textAlign = _textAlign
        indentRight = _identRight
        indentTop = _identTop
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_identRight">Отступ справа</param>
    ''' <param name="_identTop">Отступ сверху</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <param name="_fontLine">Стиль подчеркивания</param>
    ''' <param name="_fontBold">Жирный текст</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _identRight As Integer, ByVal _identTop As Integer, ByVal _textAlign As Align, ByVal _fontLine As StyleLine, Optional ByVal _fontBold As Boolean = False)
        text = _text
        indentLeft = _identLeft
        textAlign = _textAlign
        fontLine = _fontLine
        fontBold = _fontBold
        indentRight = _identRight
        indentTop = _identTop
    End Sub

    ''' <summary>
    ''' Создание строки
    ''' </summary>
    ''' <param name="_text">Текст</param>
    ''' <param name="_identLeft">Отступ слева</param>
    ''' <param name="_identRight">Отступ справа</param>
    ''' <param name="_identTop">Отступ сверху</param>
    ''' <param name="_textAlign">Положение в контейнере</param>
    ''' <param name="_fontLine">Стиль подчеркивания</param>
    ''' <param name="_fontSize">Размер шрифта</param>
    ''' <param name="_fontBold">Жирный текст</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _text As String, ByVal _identLeft As Integer, ByVal _identRight As Integer, ByVal _identTop As Integer, ByVal _textAlign As Align, ByVal _fontLine As StyleLine, ByVal _fontSize As Single, Optional ByVal _fontBold As Boolean = False)
        text = _text
        indentLeft = _identLeft
        textAlign = _textAlign
        fontLine = _fontLine
        fontSize = _fontSize
        fontBold = _fontBold
        indentRight = _identRight
        indentTop = _identTop
    End Sub

#End Region

End Class

