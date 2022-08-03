Public Class TimerPanel

    Public Sub New()

        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    ''' <summary>
    ''' Цвет фона
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return PanelTimerBack.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            LabelBody.BackColor = value
            LabelTimer.BackColor = value
            PanelTimerBack.BackColor = value
        End Set
    End Property

    ''' <summary>
    ''' Цвет текста
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property ForeColor() As System.Drawing.Color
        Get
            Return LabelBody.ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            LabelBody.ForeColor = value
            LabelTimer.ForeColor = value
        End Set
    End Property

    ''' <summary>
    ''' Цвет полосы загрузки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Color() As System.Drawing.Color
        Get
            Return PanelTimer.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            PanelTimer.BackColor = value
        End Set
    End Property

    ''' <summary>
    ''' Текст
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property Text() As String
        Get
            Return LabelBody.Text
        End Get
        Set(ByVal value As String)
            LabelBody.Text = value
        End Set
    End Property

    ''' <summary>
    ''' Ширина текстового поля
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TextWidth() As Integer
        Get
            Return LabelBody.Width
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then
                LabelBody.Width = value
            Else
                LabelBody.Width = 0
            End If
        End Set
    End Property

    Private _Time As Integer = 60
    ''' <summary>
    ''' Время работы таймера в с
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Time() As Integer
        Get
            Return _Time
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then
                _Time = value
            Else
                _Time = 0
            End If
        End Set
    End Property

    ''' <summary>
    ''' Окончен ли отсчет
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property finish() As Boolean
        Get
            finish = (Now - startTime).TotalSeconds > Time
        End Get
    End Property

    Private startTime As DateTime = Now()

    ''' <summary>
    ''' Запуск таймера
    ''' </summary>
    ''' <param name="val">время работы в мс</param>
    ''' <remarks></remarks>
#Region "Start()"

    Public Sub Start(ByVal val As Integer)
        Time = val
        Start()
    End Sub

    Public Sub Start()
        startTime = Now()
        Timer50ms.Enabled = True
    End Sub

#End Region

    Private Sub Timer50ms_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer50ms.Tick
        'If finish Then Timer50ms.Enabled = False
        visibleElements()
    End Sub

    Private Sub visibleElements()
        Dim timer As Integer = (Now - startTime).TotalSeconds
        If finish Then
            LabelTimer.Text = "00:00"
            PanelTimer.Width = PanelTimerBack.Width
        Else
            'Числовое
            LabelTimer.Text = (Math.Floor((Time - timer) / 60)).ToString("00") & ":" & (Math.Floor(Time - timer) Mod 60).ToString("00")
            'полоса
            Dim _width As Integer = PanelTimerBack.Width / Time * timer
            If _width < PanelTimerBack.Width And _width > 5 Then
                PanelTimer.Width = _width
            ElseIf _width < PanelTimerBack.Width Then
                PanelTimer.Width = 5
            Else
                PanelTimer.Width = PanelTimerBack.Width
            End If
        End If
        LabelTimer.Refresh()
        PanelTimer.Refresh()
    End Sub

    Private Sub PanelTimerBack_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelTimerBack.Resize
        visibleElements()
    End Sub
End Class
