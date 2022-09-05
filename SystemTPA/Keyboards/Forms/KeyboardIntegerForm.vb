Imports System.Windows.Forms

Public Class KeyboardIntegerForm
    Private _minus As Double = False
    Private _startText As String = ""
    Private _result As String = ""
    Public Property result() As Integer
        Get
            Try
                Return Convert.ToInt32(_result)
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Sub New(ByRef value As String, _
                   Optional ByRef head As String = "")
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

        _startText = value
        If value = "" Then
            _minus = False
            _result = ""
        ElseIf value(0) = "-"(0) Then
            _minus = True
            _result = value.Substring(1)
        Else
            _minus = False
            _result = value
        End If
        VisibleText()
        LabelHead.Text = head
        DialogForms.WaitFormStop()
    End Sub

    Private Sub VisibleText()
        If _minus Then
            LabelText.Text = "-"
        Else
            LabelText.Text = ""
        End If
        LabelText.Text &= _result
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
        _result = 0
        _minus = False
        VisibleText()
    End Sub

    Private Sub ButtonBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBackspace.Click
        If _result.Length > 0 Then
            _result = _result.Substring(0, _result.Length - 1)
        Else
            _minus = False
        End If
        VisibleText()
    End Sub

    Private Sub ButtonCh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, _
                Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button1.Click, _
                Button0.Click
        If _result = "0" Then
            _result = DirectCast(sender, Button).Text
        ElseIf _result.Length < 10 Then
            _result &= DirectCast(sender, Button).Text
        End If
        VisibleText()
    End Sub

    Private Sub ButtonMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMinus.Click
        _minus = Not _minus
        VisibleText()
    End Sub
End Class