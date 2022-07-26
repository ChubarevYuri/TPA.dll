Public Class MessageForm


    Public Sub New(ByVal message As String, _
                   Optional ByVal head As String = "Сообщение", _
                   Optional ByVal type As DialogForms.MsgType = DialogForms.MsgType.message, _
                   Optional ByVal cancelVisible As Boolean = False)
        InitializeComponent()
        LabelHead.Text = head
        LabelBody.Text = message
        If Not cancelVisible Then
            PictureBoxCancel.Visible = False
        End If
        Select Case type
            Case DialogForms.MsgType.message
                PictureBox1.Image = My.Resources.ResourceBMP.message
            Case DialogForms.MsgType.warning
                PictureBox1.Image = My.Resources.ResourceBMP.warning
            Case DialogForms.MsgType.except
                PictureBox1.Image = My.Resources.ResourceBMP.except
        End Select
    End Sub

    Private Sub PictureOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxOk.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub PictureCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
End Class