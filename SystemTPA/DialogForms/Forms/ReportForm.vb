Public Class ReportForm

    Private X As Integer = 0
    Private Y As Integer = 0
    Private x2 As Integer = 0
    Private y2 As Integer = 0
    Private _protocol As Report
    Private _picture As Drawing.Bitmap

    Public Sub New(ByRef protocol As Report, Optional ByVal head As String = "Протокол")
        InitializeComponent()
        LabelHead.Text = head
        _protocol = protocol
        _picture = _protocol.Show
        PictureBoxProtocol.Size = _picture.Size
        PictureBoxProtocol.Image = _picture
        DialogForms.WaitFormStop()
    End Sub

    Private Sub PictureBoxCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub PictureBoxOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub PictureBoxSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxSave.Click
        Dim test As Boolean = True
        Do While test
            Dim saveas As String = ""
            Try
                saveas = DialogForms.SaveAs("Протокол", _
                                                          "", _
                                                          "/", _
                                                          New String() {"/Application Data", _
                                                                        "/My Documents", _
                                                                        "/My Recent Documents", _
                                                                        "/Network", _
                                                                        "/Program Files", _
                                                                        "/STORAGECARD", _
                                                                        "/Temp", _
                                                                        "/Windows", _
                                                                        "/ResidentFlash", _
                                                                        "/Recycled"}, _
                                                          True)
                If saveas.Length > 0 Then
                    _protocol.Save("", saveas)
                    DialogResult = Windows.Forms.DialogResult.OK
                    Close()
                End If
                test = False
            Catch ex As Exception
                test = DialogForms.Message("Не удалось сохранить файл, попробуйте ешё раз", "Ошибка", DialogForms.MsgType.except)
            End Try
        Loop
    End Sub

#Region "move picture"

    Private Sub Protocol_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxProtocol.MouseDown, PanelProtocol.MouseDown
        X = MousePosition.X
        Y = MousePosition.Y
    End Sub

    Private Sub PictureBoxProtocol_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxProtocol.MouseMove, PanelProtocol.MouseMove
        Dim dX As Integer = MousePosition.X - X
        Dim dY As Integer = MousePosition.Y - Y
        X = MousePosition.X
        Y = MousePosition.Y
        PictureBoxProtocol.Location = New Drawing.Point(PictureBoxProtocol.Location.X + dX, _
                                                        PictureBoxProtocol.Location.Y + dY)
        If PictureBoxProtocol.Location.X + PictureBoxProtocol.Width < PanelProtocol.Width Then PictureBoxProtocol.Location = New Drawing.Point(PanelProtocol.Width - PictureBoxProtocol.Width, _
                                                                                                                                               PictureBoxProtocol.Location.Y)
        If PictureBoxProtocol.Location.Y + PictureBoxProtocol.Height < PanelProtocol.Height Then PictureBoxProtocol.Location = New Drawing.Point(PictureBoxProtocol.Location.X, _
                                                                                                                                                 PanelProtocol.Height - PictureBoxProtocol.Height)
        If PictureBoxProtocol.Location.X > 0 Then PictureBoxProtocol.Location = New Drawing.Point(0, _
                                                                                                  PictureBoxProtocol.Location.Y)
        If PictureBoxProtocol.Location.Y > 0 Then PictureBoxProtocol.Location = New Drawing.Point(PictureBoxProtocol.Location.X, _
                                                                                                  0)
    End Sub

#End Region
End Class