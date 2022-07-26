<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ButtonNew
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
        Me.LabelText = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'LabelText
        '
        Me.LabelText.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelText.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LabelText.Location = New System.Drawing.Point(3, 60)
        Me.LabelText.Name = "LabelText"
        Me.LabelText.Size = New System.Drawing.Size(144, 27)
        Me.LabelText.Text = "Button"
        Me.LabelText.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.LabelText)
        Me.Name = "Button"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelText As System.Windows.Forms.Label

End Class
