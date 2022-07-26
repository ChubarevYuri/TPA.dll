Public Class DeviceValue

    Private _Color As Drawing.Color = Drawing.Color.FromArgb(223, 223, 223)
    ''' <summary>
    ''' Цвет формы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Color() As Drawing.Color
        Get
            Return _Color
        End Get
        Set(ByVal value As Drawing.Color)
            _Color = value
            Me.BackColor = _Color
        End Set
    End Property

    Private _Value As String = "Button"
    ''' <summary>
    ''' значение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
            LabelVal.Text = _Value
        End Set
    End Property

    Private _Head As String = "Параметр"
    ''' <summary>
    ''' Подпись над значением
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Head() As String
        Get
            Return _Head
        End Get
        Set(ByVal value As String)
            _Head = value
            LabelHead.Text = _Head
        End Set
    End Property

    Private _Measure As String = "ед.изм."
    ''' <summary>
    ''' подпись под значением
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Measure() As String
        Get
            Return _Measure
        End Get
        Set(ByVal value As String)
            _Measure = value
            LabelBoth.Text = _Measure
        End Set
    End Property

    Private _FontSize As Single = 20
    ''' <summary>
    ''' размер текста
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FontSize() As Single
        Get
            Return _FontSize
        End Get
        Set(ByVal value As Single)
            If value < 8 Then value = 8
            If value > 48 Then value = 48
            _FontSize = value
            LabelVal.Font = New Drawing.Font("Arial", value, Drawing.FontStyle.Bold)
            value *= 3 / 4
            LabelHead.Font = New Drawing.Font("Arial", value, Drawing.FontStyle.Regular)
            LabelHead.Height = value * 2 - 5
            LabelBoth.Font = New Drawing.Font("Arial", value, Drawing.FontStyle.Regular)
            LabelBoth.Height = value * 2 - 5
            LabelBoth.Top = Me.Height - 3 - LabelBoth.Height
            LabelVal.Top = 3 + LabelHead.Height
            LabelVal.Height = Me.Height - 6 - LabelBoth.Height - LabelHead.Height
        End Set
    End Property

    Private _FontColor As Drawing.Color = Drawing.Color.Black
    ''' <summary>
    ''' Цвет текста подписей
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FontColor() As Drawing.Color
        Get
            Return _FontColor
        End Get
        Set(ByVal value As Drawing.Color)
            _FontColor = value
            LabelHead.ForeColor = value
            LabelBoth.ForeColor = value
        End Set
    End Property

    Private _ValueColor As Drawing.Color = Drawing.Color.Black
    ''' <summary>
    ''' Цвет текста значения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ValueColor() As Drawing.Color
        Get
            Return _ValueColor
        End Get
        Set(ByVal value As Drawing.Color)
            _ValueColor = value
            LabelVal.ForeColor = value
        End Set
    End Property

    Public Sub New()

        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

End Class
