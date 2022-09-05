<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SettingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingForm))
        Me.PanelHead = New System.Windows.Forms.Panel
        Me.PictureBoxOk = New System.Windows.Forms.PictureBox
        Me.PictureBoxCancel = New System.Windows.Forms.PictureBox
        Me.LabelHead = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Label4b = New System.Windows.Forms.Label
        Me.Label4h = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label2b = New System.Windows.Forms.Label
        Me.Label2h = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1b = New System.Windows.Forms.Label
        Me.Label1h = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label3b = New System.Windows.Forms.Label
        Me.Label3h = New System.Windows.Forms.Label
        Me.PictureBoxDown = New System.Windows.Forms.PictureBox
        Me.PictureBoxUp = New System.Windows.Forms.PictureBox
        Me.PanelBody = New System.Windows.Forms.Panel
        Me.PanelLeft = New System.Windows.Forms.Panel
        Me.PanelRight = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.PanelHead.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        Me.PanelLeft.SuspendLayout()
        Me.PanelRight.SuspendLayout()
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
        Me.LabelHead.BackColor = System.Drawing.Color.Black
        Me.LabelHead.Font = New System.Drawing.Font("Arial", 26.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHead.ForeColor = System.Drawing.Color.White
        Me.LabelHead.Location = New System.Drawing.Point(80, 20)
        Me.LabelHead.Name = "LabelHead"
        Me.LabelHead.Size = New System.Drawing.Size(640, 40)
        Me.LabelHead.Text = "head"
        Me.LabelHead.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel4.Controls.Add(Me.Label4h)
        Me.Panel4.Controls.Add(Me.Label4b)
        Me.Panel4.Controls.Add(Me.PictureBox4)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 285)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(550, 95)
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.White
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox4.Location = New System.Drawing.Point(475, 10)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'Label4b
        '
        Me.Label4b.BackColor = System.Drawing.Color.White
        Me.Label4b.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label4b.Font = New System.Drawing.Font("Arial", 26.0!, System.Drawing.FontStyle.Bold)
        Me.Label4b.Location = New System.Drawing.Point(0, 40)
        Me.Label4b.Name = "Label4b"
        Me.Label4b.Size = New System.Drawing.Size(475, 45)
        Me.Label4b.Text = "Label4"
        '
        'Label4h
        '
        Me.Label4h.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4h.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label4h.Location = New System.Drawing.Point(0, 10)
        Me.Label4h.Name = "Label4h"
        Me.Label4h.Size = New System.Drawing.Size(475, 26)
        Me.Label4h.Text = "Label4"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.Controls.Add(Me.Label2h)
        Me.Panel2.Controls.Add(Me.Label2b)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Controls.Add(Me.Panel10)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 95)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(550, 95)
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Location = New System.Drawing.Point(475, 10)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'Label2b
        '
        Me.Label2b.BackColor = System.Drawing.Color.White
        Me.Label2b.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2b.Font = New System.Drawing.Font("Arial", 26.0!, System.Drawing.FontStyle.Bold)
        Me.Label2b.Location = New System.Drawing.Point(0, 40)
        Me.Label2b.Name = "Label2b"
        Me.Label2b.Size = New System.Drawing.Size(475, 45)
        Me.Label2b.Text = "Label2"
        '
        'Label2h
        '
        Me.Label2h.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2h.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2h.Location = New System.Drawing.Point(0, 10)
        Me.Label2h.Name = "Label2h"
        Me.Label2h.Size = New System.Drawing.Size(475, 26)
        Me.Label2h.Text = "Label2"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Label1h)
        Me.Panel1.Controls.Add(Me.Label1b)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Panel12)
        Me.Panel1.Controls.Add(Me.Panel11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 95)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Location = New System.Drawing.Point(475, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'Label1b
        '
        Me.Label1b.BackColor = System.Drawing.Color.White
        Me.Label1b.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1b.Font = New System.Drawing.Font("Arial", 26.0!, System.Drawing.FontStyle.Bold)
        Me.Label1b.Location = New System.Drawing.Point(0, 40)
        Me.Label1b.Name = "Label1b"
        Me.Label1b.Size = New System.Drawing.Size(475, 45)
        Me.Label1b.Text = "Label1"
        '
        'Label1h
        '
        Me.Label1h.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1h.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label1h.Location = New System.Drawing.Point(0, 10)
        Me.Label1h.Name = "Label1h"
        Me.Label1h.Size = New System.Drawing.Size(475, 26)
        Me.Label1h.Text = "Label1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Controls.Add(Me.Label3h)
        Me.Panel3.Controls.Add(Me.Label3b)
        Me.Panel3.Controls.Add(Me.PictureBox3)
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 190)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(550, 95)
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.White
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Location = New System.Drawing.Point(475, 10)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'Label3b
        '
        Me.Label3b.BackColor = System.Drawing.Color.White
        Me.Label3b.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label3b.Font = New System.Drawing.Font("Arial", 26.0!, System.Drawing.FontStyle.Bold)
        Me.Label3b.Location = New System.Drawing.Point(0, 40)
        Me.Label3b.Name = "Label3b"
        Me.Label3b.Size = New System.Drawing.Size(475, 45)
        Me.Label3b.Text = "Label3"
        '
        'Label3h
        '
        Me.Label3h.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3h.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label3h.Location = New System.Drawing.Point(0, 10)
        Me.Label3h.Name = "Label3h"
        Me.Label3h.Size = New System.Drawing.Size(475, 26)
        Me.Label3h.Text = "Label3"
        '
        'PictureBoxDown
        '
        Me.PictureBoxDown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxDown.Image = CType(resources.GetObject("PictureBoxDown.Image"), System.Drawing.Image)
        Me.PictureBoxDown.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxDown.Name = "PictureBoxDown"
        Me.PictureBoxDown.Size = New System.Drawing.Size(125, 380)
        Me.PictureBoxDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'PictureBoxUp
        '
        Me.PictureBoxUp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxUp.Image = CType(resources.GetObject("PictureBoxUp.Image"), System.Drawing.Image)
        Me.PictureBoxUp.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxUp.Name = "PictureBoxUp"
        Me.PictureBoxUp.Size = New System.Drawing.Size(125, 380)
        Me.PictureBoxUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
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
        'PanelLeft
        '
        Me.PanelLeft.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelLeft.Controls.Add(Me.PictureBoxUp)
        Me.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelLeft.Location = New System.Drawing.Point(0, 80)
        Me.PanelLeft.Name = "PanelLeft"
        Me.PanelLeft.Size = New System.Drawing.Size(125, 380)
        '
        'PanelRight
        '
        Me.PanelRight.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelRight.Controls.Add(Me.PictureBoxDown)
        Me.PanelRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelRight.Location = New System.Drawing.Point(675, 80)
        Me.PanelRight.Name = "PanelRight"
        Me.PanelRight.Size = New System.Drawing.Size(125, 380)
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 85)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(550, 10)
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(550, 10)
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 85)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(550, 10)
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(550, 10)
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(550, 10)
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 85)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(550, 10)
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(550, 10)
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel12.Location = New System.Drawing.Point(0, 85)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(550, 10)
        '
        'SettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(800, 460)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelRight)
        Me.Controls.Add(Me.PanelLeft)
        Me.Controls.Add(Me.PanelHead)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingForm"
        Me.Text = "Список"
        Me.PanelHead.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.PanelBody.ResumeLayout(False)
        Me.PanelLeft.ResumeLayout(False)
        Me.PanelRight.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelHead As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label4h As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2h As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1h As System.Windows.Forms.Label
    Friend WithEvents PictureBoxUp As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxDown As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3h As System.Windows.Forms.Label
    Friend WithEvents Label4b As System.Windows.Forms.Label
    Friend WithEvents Label2b As System.Windows.Forms.Label
    Friend WithEvents Label1b As System.Windows.Forms.Label
    Friend WithEvents Label3b As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxOk As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCancel As System.Windows.Forms.PictureBox
    Friend WithEvents LabelHead As System.Windows.Forms.Label
    Friend WithEvents PanelBody As System.Windows.Forms.Panel
    Friend WithEvents PanelLeft As System.Windows.Forms.Panel
    Friend WithEvents PanelRight As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
End Class
