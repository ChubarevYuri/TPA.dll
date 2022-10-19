Public Class WaitForm
    Private num As Integer = 0
    Public Sub New()
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TPA.GAMEMODE_FORM(Me) = True
    End Sub

    Private Sub TimerWait_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerWait.Tick
        If Not DialogForms.wf Then Close()
        Select Case num
            Case 0
                PictureBox1.Image = My.Resources.ResourceWaitForm._00
            Case 1
                PictureBox1.Image = My.Resources.ResourceWaitForm._01
            Case 2
                PictureBox1.Image = My.Resources.ResourceWaitForm._02
            Case 3
                PictureBox1.Image = My.Resources.ResourceWaitForm._03
            Case 4
                PictureBox1.Image = My.Resources.ResourceWaitForm._04
            Case 5
                PictureBox1.Image = My.Resources.ResourceWaitForm._05
            Case 6
                PictureBox1.Image = My.Resources.ResourceWaitForm._06
            Case 7
                PictureBox1.Image = My.Resources.ResourceWaitForm._07
            Case 8
                PictureBox1.Image = My.Resources.ResourceWaitForm._08
            Case 9
                PictureBox1.Image = My.Resources.ResourceWaitForm._09
            Case 10
                PictureBox1.Image = My.Resources.ResourceWaitForm._10
            Case 11
                PictureBox1.Image = My.Resources.ResourceWaitForm._11
            Case 12
                PictureBox1.Image = My.Resources.ResourceWaitForm._12
            Case 13
                PictureBox1.Image = My.Resources.ResourceWaitForm._13
            Case 14
                PictureBox1.Image = My.Resources.ResourceWaitForm._14
            Case 15
                PictureBox1.Image = My.Resources.ResourceWaitForm._15
            Case 16
                PictureBox1.Image = My.Resources.ResourceWaitForm._16
            Case 17
                PictureBox1.Image = My.Resources.ResourceWaitForm._17
            Case 18
                PictureBox1.Image = My.Resources.ResourceWaitForm._18
            Case 19
                PictureBox1.Image = My.Resources.ResourceWaitForm._19
            Case 20
                PictureBox1.Image = My.Resources.ResourceWaitForm._20
            Case 21
                PictureBox1.Image = My.Resources.ResourceWaitForm._21
            Case 22
                PictureBox1.Image = My.Resources.ResourceWaitForm._22
            Case Else
                PictureBox1.Image = My.Resources.ResourceWaitForm._23
                num = -1
        End Select
        num += 1
    End Sub
End Class