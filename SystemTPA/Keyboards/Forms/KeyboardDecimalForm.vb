Imports System.Windows.Forms

Public Class KeyboardDecimalForm
    Private StringFormat As Boolean = False
    Private _minus As Double = False
    Private _startText As String = ""
    Private _result As String = ""

    Private Const lenS As Integer = 15
    Private Const lenD As Integer = 9

    Public ReadOnly Property result() As String
        Get
            Return _result
        End Get
    End Property

    Public Sub New(ByRef value As String, _
                   Optional ByRef head As String = "", _
                   Optional ByVal Type As Keyboard.DecimalKeyboardType = DecimalKeyboardType.Real)
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        StringFormat = If (Type = DecimalKeyboardType.SerialNum,True,false)
        If (Type = DecimalKeyboardType.UInt Or Type = DecimalKeyboardType.UReal) Then
            Button0.Width = Button0.Left - ButtonMinus.Left + Button0.Width
            Button0.Left = ButtonMinus.Left
            ButtonMinus.Visible = False
        End If
        If (Type = DecimalKeyboardType.Int Or Type = DecimalKeyboardType.UInt) Then
            Button0.Width = ButtonPoint.Left - Button0.Left + ButtonPoint.Width
            ButtonPoint.Visible = False
        End If
        value = Replace(value, ",", ".")
        _startText = value
        If value = "" Then
            _minus = False
            _result = ""
        ElseIf value(0) = "-"c And Not StringFormat Then
            _minus = True
            _result = value.Substring(1)
        Else
            _minus = False
            _result = value
        End If
        VisibleText()
        LabelHead.Text = head
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TPA.GAMEMODE_FORM(Me) = True
        DialogForms.WaitFormStop()
        ButtonEnter.Focus()
    End Sub

    Private Sub VisibleText()
        ButtonEnter.Focus()
        If (StringFormat) Then
            If _minus And _result.Length < lenS Then _result &= "-"
            _minus = False
            LabelText.Text = _result
        Else
            If _minus Then
                LabelText.Text = "-"
            Else
                LabelText.Text = ""
            End If
            _result = If(_result.Length > 0, If(_result(0) = "."c, "0" & _result, _result), "0")
            LabelText.Text &= _result
        End If
    End Sub

    Private Sub ButtonEsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEsc.Click
        _result = _startText
        VisibleText()
        Close()
    End Sub

    Private Sub ButtonEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnter.Click
        If _minus Then _result = "-" & _result
        Close()
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        _result = ""
        _minus = False
        VisibleText()
    End Sub

    Private Sub ButtonBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBackspace.Click
        If _result.Length > 0 And _result <> "0" Then
            _result = _result.Substring(0, _result.Length - 1)
        Else
            _minus = False
        End If
        VisibleText()
    End Sub

    Private Sub ButtonCh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, _
                Button5.Click, Button4.Click, Button3.Click, Button2.Click, _
                Button0.Click, Button1.Click
        If _result = "0" Then _result = ""
        If _result.Length < If(StringFormat, lenS, lenD) Then
            _result &= DirectCast(sender, Button).Text
        End If
        VisibleText()
    End Sub

    Private Sub ButtonPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPoint.Click
        If ((Not _result.Contains(".")) Or StringFormat) _
        And If(StringFormat, _result.Length < lenS, _result.Length < lenD - 1) Then
            _result &= "."
        End If
        VisibleText()
    End Sub

    Private Sub ButtonMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMinus.Click
        _minus = Not _minus
        VisibleText()
    End Sub

    Private Sub KeyboardDoubleForm_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Panel1.Left = (Me.Width - Panel1.Width) / 2
        Panel1.Top = (Me.Height - Panel1.Height - LabelHead.Top - LabelHead.Height) / 2 + LabelHead.Top + LabelHead.Height
    End Sub

    Private Sub KeyboardDoubleForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown ', ButtonPoint.KeyDown, ButtonMinus.KeyDown, ButtonEsc.KeyDown, ButtonEnter.KeyDown, ButtonClear.KeyDown, ButtonBackspace.KeyDown, Button9.KeyDown, Button8.KeyDown, Button7.KeyDown, Button6.KeyDown, Button5.KeyDown, Button4.KeyDown, Button3.KeyDown, Button2.KeyDown, Button0.KeyDown, Button1.KeyDown
        If (e.KeyValue = Keys.Escape) Then ButtonEsc_Click(Nothing, Nothing)
        If (e.KeyValue = Keys.Back Or e.KeyValue = Keys.Delete) Then ButtonBackspace_Click(Nothing, Nothing)
    End Sub

    Private Sub KeyboardDecimalForm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If (e.KeyChar = "0"c) Then ButtonCh_Click(Button0, Nothing)
        If (e.KeyChar = "1"c) Then ButtonCh_Click(Button1, Nothing)
        If (e.KeyChar = "2"c) Then ButtonCh_Click(Button2, Nothing)
        If (e.KeyChar = "3"c) Then ButtonCh_Click(Button3, Nothing)
        If (e.KeyChar = "4"c) Then ButtonCh_Click(Button4, Nothing)
        If (e.KeyChar = "5"c) Then ButtonCh_Click(Button5, Nothing)
        If (e.KeyChar = "6"c) Then ButtonCh_Click(Button6, Nothing)
        If (e.KeyChar = "7"c) Then ButtonCh_Click(Button7, Nothing)
        If (e.KeyChar = "8"c) Then ButtonCh_Click(Button8, Nothing)
        If (e.KeyChar = "9"c) Then ButtonCh_Click(Button9, Nothing)
        If (e.KeyChar = "-"c And ButtonMinus.Visible) Then ButtonMinus_Click(Nothing, Nothing)
        If ((e.KeyChar = "."c Or e.KeyChar = ","c) And ButtonPoint.Visible) Then ButtonPoint_Click(Nothing, Nothing)
    End Sub

    Private Sub KeyboardDecimalForm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ButtonEnter.Focus()
    End Sub
End Class