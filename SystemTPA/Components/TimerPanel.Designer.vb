<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class TimerPanel
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
        Me.LabelBody = New System.Windows.Forms.Label
        Me.LabelTimer = New System.Windows.Forms.Label
        Me.Timer50ms = New System.Windows.Forms.Timer
        Me.PanelTimer = New System.Windows.Forms.Panel
        Me.PanelTimerBack = New System.Windows.Forms.Panel
        Me.PanelTimerBack.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelBody
        '
        Me.LabelBody.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelBody.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabelBody.Location = New System.Drawing.Point(0, 0)
        Me.LabelBody.Name = "LabelBody"
        Me.LabelBody.Size = New System.Drawing.Size(292, 28)
        Me.LabelBody.Text = "До конца операции осталось"
        '
        'LabelTimer
        '
        Me.LabelTimer.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelTimer.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTimer.Location = New System.Drawing.Point(292, 0)
        Me.LabelTimer.Name = "LabelTimer"
        Me.LabelTimer.Size = New System.Drawing.Size(62, 28)
        Me.LabelTimer.Text = "00:00"
        '
        'Timer50ms
        '
        Me.Timer50ms.Enabled = True
        Me.Timer50ms.Interval = 50
        '
        'PanelTimer
        '
        Me.PanelTimer.BackColor = System.Drawing.Color.LimeGreen
        Me.PanelTimer.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelTimer.Location = New System.Drawing.Point(0, 0)
        Me.PanelTimer.Name = "PanelTimer"
        Me.PanelTimer.Size = New System.Drawing.Size(10, 28)
        '
        'PanelTimerBack
        '
        Me.PanelTimerBack.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelTimerBack.Controls.Add(Me.PanelTimer)
        Me.PanelTimerBack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTimerBack.Location = New System.Drawing.Point(354, 0)
        Me.PanelTimerBack.Name = "PanelTimerBack"
        Me.PanelTimerBack.Size = New System.Drawing.Size(182, 28)
        '
        'TimerPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.PanelTimerBack)
        Me.Controls.Add(Me.LabelTimer)
        Me.Controls.Add(Me.LabelBody)
        Me.Name = "TimerPanel"
        Me.Size = New System.Drawing.Size(536, 28)
        Me.PanelTimerBack.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelBody As System.Windows.Forms.Label
    Friend WithEvents LabelTimer As System.Windows.Forms.Label
    Friend WithEvents Timer50ms As System.Windows.Forms.Timer
    Friend WithEvents PanelTimer As System.Windows.Forms.Panel
    Friend WithEvents PanelTimerBack As System.Windows.Forms.Panel

End Class
