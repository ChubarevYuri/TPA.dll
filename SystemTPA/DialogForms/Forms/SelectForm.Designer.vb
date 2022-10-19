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
        Me.PictureBoxUp = New System.Windows.Forms.PictureBox
        Me.PictureBoxDown = New System.Windows.Forms.PictureBox
        Me.PanelBody = New System.Windows.Forms.Panel
        Me.PanelControlLeft = New System.Windows.Forms.Panel
        Me.PictureBoxAdd = New System.Windows.Forms.PictureBox
        Me.PanelControlRight = New System.Windows.Forms.Panel
        Me.PictureBoxDel = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.PanelHead.SuspendLayout()
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
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelBody.Controls.Add(Me.Button7)
        Me.PanelBody.Controls.Add(Me.Button6)
        Me.PanelBody.Controls.Add(Me.Button5)
        Me.PanelBody.Controls.Add(Me.Button4)
        Me.PanelBody.Controls.Add(Me.Button3)
        Me.PanelBody.Controls.Add(Me.Button2)
        Me.PanelBody.Controls.Add(Me.Button1)
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
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(550, 60)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(0, 60)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(550, 60)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Button2"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button3.Location = New System.Drawing.Point(0, 120)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(550, 60)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Button3"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button4.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button4.Location = New System.Drawing.Point(0, 180)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(550, 60)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "Button4"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button5.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button5.Location = New System.Drawing.Point(0, 240)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(550, 60)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "Button5"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button6.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button6.Location = New System.Drawing.Point(0, 300)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(550, 60)
        Me.Button6.TabIndex = 12
        Me.Button6.Text = "Button6"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button7.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button7.Location = New System.Drawing.Point(0, 360)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(550, 60)
        Me.Button7.TabIndex = 13
        Me.Button7.Text = "Button7"
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
        Me.PanelBody.ResumeLayout(False)
        Me.PanelControlLeft.ResumeLayout(False)
        Me.PanelControlRight.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelHead As System.Windows.Forms.Panel
    Friend WithEvents PictureBoxUp As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxDown As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCancel As System.Windows.Forms.PictureBox
    Friend WithEvents LabelHead As System.Windows.Forms.Label
    Friend WithEvents PanelBody As System.Windows.Forms.Panel
    Friend WithEvents PanelControlLeft As System.Windows.Forms.Panel
    Friend WithEvents PanelControlRight As System.Windows.Forms.Panel
    Friend WithEvents PictureBoxAdd As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxDel As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxOk As System.Windows.Forms.PictureBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
