Imports System.Windows.Forms

Public Class KeyboardUDoubleForm
    Private _startText As String = ""
    Private _result As String = ""
    Public Property result() As Double
        Get
            Try
                Return Convert.ToDouble(_result)
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(ByVal value As Double)
        End Set
    End Property

    Public Sub New(ByRef value As String, _
                   Optional ByRef head As String = "")
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

        TPA.GAMEMODE_FORM(Me)
        _startText = value
        _result = value
        VisibleText()
        LabelHead.Text = head
        DialogForms.WaitFormStop()
    End Sub

    Private Sub VisibleText()
        LabelText.Text = _result
    End Sub

    Private Sub ButtonEsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEsc.Click
        _result = _startText
        VisibleText()
        Close()
    End Sub

    Private Sub ButtonEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnter.Click
        Close()
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        _result = ""
        VisibleText()
    End Sub

    Private Sub ButtonBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBackspace.Click
        If _result.Length > 0 Then
            _result = _result.Substring(0, _result.Length - 1)
        End If
        VisibleText()
    End Sub

    Private Sub ButtonCh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, _
                Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button1.Click, _
                Button0.Click, ButtonPoint.Click
        If Not (_result.Contains(".") And DirectCast(sender, Button).Text = "." And _result.Length > 0) Then
            If _result = "0" Then
                If DirectCast(sender, Button).Text = "." Then
                    _result = "0."
                Else
                    _result = DirectCast(sender, Button).Text
                End If
            ElseIf _result.Length < 10 Then
                _result &= DirectCast(sender, Button).Text
            End If
            VisibleText()
        End If
    End Sub

    Private Sub KeyboardUDoubleForm_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Panel1.Left = (Me.Width - Panel1.Width) / 2
        Panel1.Top = (Me.Height - Panel1.Height - LabelHead.Top - LabelHead.Height) / 2 + LabelHead.Top + LabelHead.Height
    End Sub
End Class