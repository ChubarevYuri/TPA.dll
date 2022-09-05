<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ValSetting
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
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
        Me.LabelName = New System.Windows.Forms.Label
        Me.LabelEI = New System.Windows.Forms.Label
        Me.PanelMin = New System.Windows.Forms.Panel
        Me.LabelMin = New System.Windows.Forms.Label
        Me.PanelMax = New System.Windows.Forms.Panel
        Me.LabelMax = New System.Windows.Forms.Label
        Me.LabelPoint = New System.Windows.Forms.Label
        Me.PictureBoxBool = New System.Windows.Forms.PictureBox
        Me.PanelMin.SuspendLayout()
        Me.PanelMax.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelName
        '
        Me.LabelName.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelName.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LabelName.Location = New System.Drawing.Point(0, 0)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Size = New System.Drawing.Size(417, 25)
        Me.LabelName.Text = "Какой-то там параметр:"
        '
        'LabelEI
        '
        Me.LabelEI.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelEI.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LabelEI.Location = New System.Drawing.Point(0, 70)
        Me.LabelEI.Name = "LabelEI"
        Me.LabelEI.Size = New System.Drawing.Size(417, 25)
        Me.LabelEI.Text = "мм"
        Me.LabelEI.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PanelMin
        '
        Me.PanelMin.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.PanelMin.Controls.Add(Me.LabelMin)
        Me.PanelMin.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMin.Location = New System.Drawing.Point(0, 25)
        Me.PanelMin.Name = "PanelMin"
        Me.PanelMin.Size = New System.Drawing.Size(200, 45)
        '
        'LabelMin
        '
        Me.LabelMin.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMin.BackColor = System.Drawing.Color.White
        Me.LabelMin.Font = New System.Drawing.Font("Arial", 22.0!, System.Drawing.FontStyle.Bold)
        Me.LabelMin.Location = New System.Drawing.Point(5, 5)
        Me.LabelMin.Name = "LabelMin"
        Me.LabelMin.Size = New System.Drawing.Size(190, 35)
        Me.LabelMin.Text = "2g2.22"
        Me.LabelMin.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PanelMax
        '
        Me.PanelMax.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.PanelMax.Controls.Add(Me.LabelMax)
        Me.PanelMax.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelMax.Location = New System.Drawing.Point(217, 25)
        Me.PanelMax.Name = "PanelMax"
        Me.PanelMax.Size = New System.Drawing.Size(200, 45)
        '
        'LabelMax
        '
        Me.LabelMax.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMax.BackColor = System.Drawing.Color.White
        Me.LabelMax.Font = New System.Drawing.Font("Arial", 22.0!, System.Drawing.FontStyle.Bold)
        Me.LabelMax.Location = New System.Drawing.Point(5, 5)
        Me.LabelMax.Name = "LabelMax"
        Me.LabelMax.Size = New System.Drawing.Size(190, 35)
        Me.LabelMax.Text = "222.22"
        Me.LabelMax.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelPoint
        '
        Me.LabelPoint.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelPoint.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabelPoint.Location = New System.Drawing.Point(200, 50)
        Me.LabelPoint.Name = "LabelPoint"
        Me.LabelPoint.Size = New System.Drawing.Size(17, 20)
        Me.LabelPoint.Text = ".."
        Me.LabelPoint.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBoxBool
        '
        Me.PictureBoxBool.BackColor = System.Drawing.Color.White
        Me.PictureBoxBool.Location = New System.Drawing.Point(176, 25)
        Me.PictureBoxBool.Name = "PictureBoxBool"
        Me.PictureBoxBool.Size = New System.Drawing.Size(64, 54)
        Me.PictureBoxBool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'ValSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.LabelPoint)
        Me.Controls.Add(Me.PanelMax)
        Me.Controls.Add(Me.PanelMin)
        Me.Controls.Add(Me.LabelEI)
        Me.Controls.Add(Me.LabelName)
        Me.Controls.Add(Me.PictureBoxBool)
        Me.Name = "ValSetting"
        Me.Size = New System.Drawing.Size(417, 95)
        Me.PanelMin.ResumeLayout(False)
        Me.PanelMax.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelName As System.Windows.Forms.Label
    Friend WithEvents LabelEI As System.Windows.Forms.Label
    Friend WithEvents PanelMin As System.Windows.Forms.Panel
    Friend WithEvents LabelMin As System.Windows.Forms.Label
    Friend WithEvents PanelMax As System.Windows.Forms.Panel
    Friend WithEvents LabelMax As System.Windows.Forms.Label
    Friend WithEvents LabelPoint As System.Windows.Forms.Label
    Friend WithEvents PictureBoxBool As System.Windows.Forms.PictureBox

End Class
