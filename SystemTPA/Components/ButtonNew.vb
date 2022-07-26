Public Class ButtonNew

    Public Property Color() As Drawing.Color
        Get
            Return Me.BackColor
        End Get
        Set(ByVal value As Drawing.Color)
            Me.BackColor = value
        End Set
    End Property

    Public Property FontColor() As Drawing.Color
        Get
            Return LabelText.ForeColor
        End Get
        Set(ByVal value As Drawing.Color)
            LabelText.ForeColor = value
        End Set
    End Property

    Public Property FontSize() As Single
        Get
            Return LabelText.Font.Size
        End Get
        Set(ByVal value As Single)
            If value < 8 Then value = 8
            If value > 48 Then value = 48
            LabelText.Font = New Drawing.Font("Arial", value, Drawing.FontStyle.Bold)
            LabelText.Height = LabelText.Font.Size * 2 - 5
            LabelText.Top = (Me.Height - LabelText.Height) / 2
        End Set
    End Property

    Public Property MyText() As String
        Get
            Return LabelText.Text
        End Get
        Set(ByVal value As String)
            LabelText.Text = value
        End Set
    End Property

    Public Sub New()

        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

End Class
