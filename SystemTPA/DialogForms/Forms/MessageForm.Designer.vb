<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MessageForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет метод Dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Требуется для конструктора Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора Windows Forms
    'Для ее изменения используйте конструктор Windows Forms.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MessageForm))
        Me.LabelBody = New System.Windows.Forms.Label
        Me.PanelHead = New System.Windows.Forms.Panel
        Me.LabelHead = New System.Windows.Forms.Label
        Me.PictureBoxCancel = New System.Windows.Forms.PictureBox
        Me.PictureBoxOk = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PanelHead.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelBody
        '
        Me.LabelBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelBody.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular)
        Me.LabelBody.Location = New System.Drawing.Point(160, 100)
        Me.LabelBody.Name = "LabelBody"
        Me.LabelBody.Size = New System.Drawing.Size(620, 200)
        Me.LabelBody.Text = "Label1"
        '
        'PanelHead
        '
        Me.PanelHead.BackColor = System.Drawing.Color.Black
        Me.PanelHead.Controls.Add(Me.LabelHead)
        Me.PanelHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHead.Location = New System.Drawing.Point(0, 0)
        Me.PanelHead.Name = "PanelHead"
        Me.PanelHead.Size = New System.Drawing.Size(800, 80)
        '
        'LabelHead
        '
        Me.LabelHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelHead.BackColor = System.Drawing.Color.Black
        Me.LabelHead.Font = New System.Drawing.Font("Arial", 26.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHead.ForeColor = System.Drawing.Color.White
        Me.LabelHead.Location = New System.Drawing.Point(20, 20)
        Me.LabelHead.Name = "LabelHead"
        Me.LabelHead.Size = New System.Drawing.Size(760, 40)
        Me.LabelHead.Text = "head"
        Me.LabelHead.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBoxCancel
        '
        Me.PictureBoxCancel.BackColor = System.Drawing.Color.Black
        Me.PictureBoxCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxCancel.Image = CType(resources.GetObject("PictureBoxCancel.Image"), System.Drawing.Image)
        Me.PictureBoxCancel.Location = New System.Drawing.Point(400, 0)
        Me.PictureBoxCancel.Name = "PictureBoxCancel"
        Me.PictureBoxCancel.Size = New System.Drawing.Size(400, 150)
        Me.PictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'PictureBoxOk
        '
        Me.PictureBoxOk.BackColor = System.Drawing.Color.Black
        Me.PictureBoxOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxOk.Image = CType(resources.GetObject("PictureBoxOk.Image"), System.Drawing.Image)
        Me.PictureBoxOk.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxOk.Name = "PictureBoxOk"
        Me.PictureBoxOk.Size = New System.Drawing.Size(400, 150)
        Me.PictureBoxOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(20, 100)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.PictureBoxOk)
        Me.Panel1.Controls.Add(Me.PictureBoxCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 310)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 150)
        '
        'MessageForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(800, 460)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelHead)
        Me.Controls.Add(Me.LabelBody)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MessageForm"
        Me.Text = "Сообщение"
        Me.PanelHead.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelBody As System.Windows.Forms.Label
    Friend WithEvents PanelHead As System.Windows.Forms.Panel
    Friend WithEvents LabelHead As System.Windows.Forms.Label
    Friend WithEvents PictureBoxOk As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCancel As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
