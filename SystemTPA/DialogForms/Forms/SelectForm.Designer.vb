<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SelectForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectForm))
        Me.PanelHead = New System.Windows.Forms.Panel
        Me.PictureBoxOk = New System.Windows.Forms.PictureBox
        Me.PictureBoxCancel = New System.Windows.Forms.PictureBox
        Me.LabelHead = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBoxUp = New System.Windows.Forms.PictureBox
        Me.PictureBoxDown = New System.Windows.Forms.PictureBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.PanelBody = New System.Windows.Forms.Panel
        Me.PanelControlLeft = New System.Windows.Forms.Panel
        Me.PictureBoxAdd = New System.Windows.Forms.PictureBox
        Me.PanelControlRight = New System.Windows.Forms.Panel
        Me.PictureBoxDel = New System.Windows.Forms.PictureBox
        Me.Panel1t = New System.Windows.Forms.Panel
        Me.Panel1b = New System.Windows.Forms.Panel
        Me.Panel1l = New System.Windows.Forms.Panel
        Me.Panel1r = New System.Windows.Forms.Panel
        Me.Panel2r = New System.Windows.Forms.Panel
        Me.Panel2l = New System.Windows.Forms.Panel
        Me.Panel2b = New System.Windows.Forms.Panel
        Me.Panel2t = New System.Windows.Forms.Panel
        Me.Panel3r = New System.Windows.Forms.Panel
        Me.Panel3l = New System.Windows.Forms.Panel
        Me.Panel3b = New System.Windows.Forms.Panel
        Me.Panel3t = New System.Windows.Forms.Panel
        Me.Panel4r = New System.Windows.Forms.Panel
        Me.Panel4l = New System.Windows.Forms.Panel
        Me.Panel4b = New System.Windows.Forms.Panel
        Me.Panel4t = New System.Windows.Forms.Panel
        Me.PanelHead.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        Me.PanelControlLeft.SuspendLayout()
        Me.PanelControlRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelHead
        '
        Me.PanelHead.BackColor = System.Drawing.Color.Black
        Me.PanelHead.Controls.Add(Me.PictureBoxOk)
        Me.PanelHead.Controls.Add(Me.PictureBoxCancel)
        Me.PanelHead.Controls.Add(Me.LabelHead)
        Me.PanelHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHead.Location = New System.Drawing.Point(0, 0)
        Me.PanelHead.Name = "PanelHead"
        Me.PanelHead.Size = New System.Drawing.Size(800, 80)
        '
        'PictureBoxOk
        '
        Me.PictureBoxOk.BackColor = System.Drawing.Color.Black
        Me.PictureBoxOk.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBoxOk.Image = CType(resources.GetObject("PictureBoxOk.Image"), System.Drawing.Image)
        Me.PictureBoxOk.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxOk.Name = "PictureBoxOk"
        Me.PictureBoxOk.Size = New System.Drawing.Size(80, 80)
        Me.PictureBoxOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'PictureBoxCancel
        '
        Me.PictureBoxCancel.BackColor = System.Drawing.Color.Black
        Me.PictureBoxCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxCancel.Image = CType(resources.GetObject("PictureBoxCancel.Image"), System.Drawing.Image)
        Me.PictureBoxCancel.Location = New System.Drawing.Point(720, 0)
        Me.PictureBoxCancel.Name = "PictureBoxCancel"
        Me.PictureBoxCancel.Size = New System.Drawing.Size(80, 80)
        Me.PictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'LabelHead
        '
        Me.LabelHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelHead.BackColor = System.Drawing.Color.Black
        Me.LabelHead.Font = New System.Drawing.Font("Arial", 26.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHead.ForeColor = System.Drawing.Color.White
        Me.LabelHead.Location = New System.Drawing.Point(170, 20)
        Me.LabelHead.Name = "LabelHead"
        Me.LabelHead.Size = New System.Drawing.Size(460, 40)
        Me.LabelHead.Text = "head"
        Me.LabelHead.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Panel1r)
        Me.Panel1.Controls.Add(Me.Panel1l)
        Me.Panel1.Controls.Add(Me.Panel1b)
        Me.Panel1.Controls.Add(Me.Panel1t)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 95)
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(10, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(530, 52)
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.Controls.Add(Me.Panel2r)
        Me.Panel2.Controls.Add(Me.Panel2l)
        Me.Panel2.Controls.Add(Me.Panel2b)
        Me.Panel2.Controls.Add(Me.Panel2t)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 95)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(550, 95)
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(10, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(530, 52)
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Controls.Add(Me.Panel3r)
        Me.Panel3.Controls.Add(Me.Panel3l)
        Me.Panel3.Controls.Add(Me.Panel3b)
        Me.Panel3.Controls.Add(Me.Panel3t)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 190)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(550, 95)
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(10, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(530, 52)
        Me.Label3.Text = "Label3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBoxUp
        '
        Me.PictureBoxUp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxUp.Image = CType(resources.GetObject("PictureBoxUp.Image"), System.Drawing.Image)
        Me.PictureBoxUp.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxUp.Name = "PictureBoxUp"
        Me.PictureBoxUp.Size = New System.Drawing.Size(125, 280)
        Me.PictureBoxUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'PictureBoxDown
        '
        Me.PictureBoxDown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxDown.Image = CType(resources.GetObject("PictureBoxDown.Image"), System.Drawing.Image)
        Me.PictureBoxDown.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxDown.Name = "PictureBoxDown"
        Me.PictureBoxDown.Size = New System.Drawing.Size(125, 280)
        Me.PictureBoxDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel4.Controls.Add(Me.Panel4r)
        Me.Panel4.Controls.Add(Me.Panel4l)
        Me.Panel4.Controls.Add(Me.Panel4b)
        Me.Panel4.Controls.Add(Me.Panel4t)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 285)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(550, 95)
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(10, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(530, 52)
        Me.Label4.Text = "Label4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelBody.Controls.Add(Me.Panel4)
        Me.PanelBody.Controls.Add(Me.Panel3)
        Me.PanelBody.Controls.Add(Me.Panel2)
        Me.PanelBody.Controls.Add(Me.Panel1)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(125, 80)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(550, 380)
        '
        'PanelControlLeft
        '
        Me.PanelControlLeft.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelControlLeft.Controls.Add(Me.PictureBoxUp)
        Me.PanelControlLeft.Controls.Add(Me.PictureBoxAdd)
        Me.PanelControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlLeft.Location = New System.Drawing.Point(0, 80)
        Me.PanelControlLeft.Name = "PanelControlLeft"
        Me.PanelControlLeft.Size = New System.Drawing.Size(125, 380)
        '
        'PictureBoxAdd
        '
        Me.PictureBoxAdd.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBoxAdd.Image = CType(resources.GetObject("PictureBoxAdd.Image"), System.Drawing.Image)
        Me.PictureBoxAdd.Location = New System.Drawing.Point(0, 280)
        Me.PictureBoxAdd.Name = "PictureBoxAdd"
        Me.PictureBoxAdd.Size = New System.Drawing.Size(125, 100)
        Me.PictureBoxAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'PanelControlRight
        '
        Me.PanelControlRight.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelControlRight.Controls.Add(Me.PictureBoxDown)
        Me.PanelControlRight.Controls.Add(Me.PictureBoxDel)
        Me.PanelControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlRight.Location = New System.Drawing.Point(675, 80)
        Me.PanelControlRight.Name = "PanelControlRight"
        Me.PanelControlRight.Size = New System.Drawing.Size(125, 380)
        '
        'PictureBoxDel
        '
        Me.PictureBoxDel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBoxDel.Image = CType(resources.GetObject("PictureBoxDel.Image"), System.Drawing.Image)
        Me.PictureBoxDel.Location = New System.Drawing.Point(0, 280)
        Me.PictureBoxDel.Name = "PictureBoxDel"
        Me.PictureBoxDel.Size = New System.Drawing.Size(125, 100)
        Me.PictureBoxDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'Panel1t
        '
        Me.Panel1t.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1t.BackColor = System.Drawing.Color.Black
        Me.Panel1t.Location = New System.Drawing.Point(5, 5)
        Me.Panel1t.Name = "Panel1t"
        Me.Panel1t.Size = New System.Drawing.Size(540, 2)
        '
        'Panel1b
        '
        Me.Panel1b.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1b.BackColor = System.Drawing.Color.Black
        Me.Panel1b.Location = New System.Drawing.Point(5, 88)
        Me.Panel1b.Name = "Panel1b"
        Me.Panel1b.Size = New System.Drawing.Size(540, 2)
        '
        'Panel1l
        '
        Me.Panel1l.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1l.BackColor = System.Drawing.Color.Black
        Me.Panel1l.Location = New System.Drawing.Point(5, 7)
        Me.Panel1l.Name = "Panel1l"
        Me.Panel1l.Size = New System.Drawing.Size(2, 81)
        '
        'Panel1r
        '
        Me.Panel1r.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1r.BackColor = System.Drawing.Color.Black
        Me.Panel1r.Location = New System.Drawing.Point(543, 7)
        Me.Panel1r.Name = "Panel1r"
        Me.Panel1r.Size = New System.Drawing.Size(2, 81)
        '
        'Panel2r
        '
        Me.Panel2r.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2r.BackColor = System.Drawing.Color.Black
        Me.Panel2r.Location = New System.Drawing.Point(543, 7)
        Me.Panel2r.Name = "Panel2r"
        Me.Panel2r.Size = New System.Drawing.Size(2, 81)
        '
        'Panel2l
        '
        Me.Panel2l.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2l.BackColor = System.Drawing.Color.Black
        Me.Panel2l.Location = New System.Drawing.Point(5, 7)
        Me.Panel2l.Name = "Panel2l"
        Me.Panel2l.Size = New System.Drawing.Size(2, 81)
        '
        'Panel2b
        '
        Me.Panel2b.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2b.BackColor = System.Drawing.Color.Black
        Me.Panel2b.Location = New System.Drawing.Point(5, 88)
        Me.Panel2b.Name = "Panel2b"
        Me.Panel2b.Size = New System.Drawing.Size(540, 2)
        '
        'Panel2t
        '
        Me.Panel2t.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2t.BackColor = System.Drawing.Color.Black
        Me.Panel2t.Location = New System.Drawing.Point(5, 5)
        Me.Panel2t.Name = "Panel2t"
        Me.Panel2t.Size = New System.Drawing.Size(540, 2)
        '
        'Panel3r
        '
        Me.Panel3r.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3r.BackColor = System.Drawing.Color.Black
        Me.Panel3r.Location = New System.Drawing.Point(543, 7)
        Me.Panel3r.Name = "Panel3r"
        Me.Panel3r.Size = New System.Drawing.Size(2, 81)
        '
        'Panel3l
        '
        Me.Panel3l.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3l.BackColor = System.Drawing.Color.Black
        Me.Panel3l.Location = New System.Drawing.Point(5, 7)
        Me.Panel3l.Name = "Panel3l"
        Me.Panel3l.Size = New System.Drawing.Size(2, 81)
        '
        'Panel3b
        '
        Me.Panel3b.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3b.BackColor = System.Drawing.Color.Black
        Me.Panel3b.Location = New System.Drawing.Point(5, 88)
        Me.Panel3b.Name = "Panel3b"
        Me.Panel3b.Size = New System.Drawing.Size(540, 2)
        '
        'Panel3t
        '
        Me.Panel3t.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3t.BackColor = System.Drawing.Color.Black
        Me.Panel3t.Location = New System.Drawing.Point(5, 5)
        Me.Panel3t.Name = "Panel3t"
        Me.Panel3t.Size = New System.Drawing.Size(540, 2)
        '
        'Panel4r
        '
        Me.Panel4r.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4r.BackColor = System.Drawing.Color.Black
        Me.Panel4r.Location = New System.Drawing.Point(543, 7)
        Me.Panel4r.Name = "Panel4r"
        Me.Panel4r.Size = New System.Drawing.Size(2, 81)
        '
        'Panel4l
        '
        Me.Panel4l.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4l.BackColor = System.Drawing.Color.Black
        Me.Panel4l.Location = New System.Drawing.Point(5, 7)
        Me.Panel4l.Name = "Panel4l"
        Me.Panel4l.Size = New System.Drawing.Size(2, 81)
        '
        'Panel4b
        '
        Me.Panel4b.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4b.BackColor = System.Drawing.Color.Black
        Me.Panel4b.Location = New System.Drawing.Point(5, 88)
        Me.Panel4b.Name = "Panel4b"
        Me.Panel4b.Size = New System.Drawing.Size(540, 2)
        '
        'Panel4t
        '
        Me.Panel4t.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4t.BackColor = System.Drawing.Color.Black
        Me.Panel4t.Location = New System.Drawing.Point(5, 5)
        Me.Panel4t.Name = "Panel4t"
        Me.Panel4t.Size = New System.Drawing.Size(540, 2)
        '
        'SelectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(800, 460)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelControlRight)
        Me.Controls.Add(Me.PanelControlLeft)
        Me.Controls.Add(Me.PanelHead)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectForm"
        Me.Text = "Список"
        Me.PanelHead.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.PanelBody.ResumeLayout(False)
        Me.PanelControlLeft.ResumeLayout(False)
        Me.PanelControlRight.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelHead As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxUp As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxDown As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxCancel As System.Windows.Forms.PictureBox
    Friend WithEvents LabelHead As System.Windows.Forms.Label
    Friend WithEvents PanelBody As System.Windows.Forms.Panel
    Friend WithEvents PanelControlLeft As System.Windows.Forms.Panel
    Friend WithEvents PanelControlRight As System.Windows.Forms.Panel
    Friend WithEvents PictureBoxAdd As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxDel As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxOk As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1b As System.Windows.Forms.Panel
    Friend WithEvents Panel1t As System.Windows.Forms.Panel
    Friend WithEvents Panel1r As System.Windows.Forms.Panel
    Friend WithEvents Panel1l As System.Windows.Forms.Panel
    Friend WithEvents Panel2r As System.Windows.Forms.Panel
    Friend WithEvents Panel2l As System.Windows.Forms.Panel
    Friend WithEvents Panel2b As System.Windows.Forms.Panel
    Friend WithEvents Panel2t As System.Windows.Forms.Panel
    Friend WithEvents Panel3r As System.Windows.Forms.Panel
    Friend WithEvents Panel3l As System.Windows.Forms.Panel
    Friend WithEvents Panel3b As System.Windows.Forms.Panel
    Friend WithEvents Panel3t As System.Windows.Forms.Panel
    Friend WithEvents Panel4r As System.Windows.Forms.Panel
    Friend WithEvents Panel4l As System.Windows.Forms.Panel
    Friend WithEvents Panel4b As System.Windows.Forms.Panel
    Friend WithEvents Panel4t As System.Windows.Forms.Panel
End Class
