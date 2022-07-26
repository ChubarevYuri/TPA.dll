<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class DeviceValue
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
        Me.LabelHead = New System.Windows.Forms.Label
        Me.LabelBoth = New System.Windows.Forms.Label
        Me.LabelVal = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'LabelHead
        '
        Me.LabelHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelHead.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LabelHead.Location = New System.Drawing.Point(3, 0)
        Me.LabelHead.Name = "LabelHead"
        Me.LabelHead.Size = New System.Drawing.Size(119, 23)
        Me.LabelHead.Text = "Text"
        '
        'LabelBoth
        '
        Me.LabelBoth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelBoth.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LabelBoth.Location = New System.Drawing.Point(3, 59)
        Me.LabelBoth.Name = "LabelBoth"
        Me.LabelBoth.Size = New System.Drawing.Size(119, 23)
        Me.LabelBoth.Text = "mes"
        Me.LabelBoth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelVal
        '
        Me.LabelVal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelVal.BackColor = System.Drawing.Color.White
        Me.LabelVal.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.LabelVal.Location = New System.Drawing.Point(3, 23)
        Me.LabelVal.Name = "LabelVal"
        Me.LabelVal.Size = New System.Drawing.Size(119, 35)
        Me.LabelVal.Text = "00,000"
        Me.LabelVal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DeviceValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.LabelVal)
        Me.Controls.Add(Me.LabelBoth)
        Me.Controls.Add(Me.LabelHead)
        Me.Name = "DeviceValue"
        Me.Size = New System.Drawing.Size(125, 95)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelHead As System.Windows.Forms.Label
    Friend WithEvents LabelBoth As System.Windows.Forms.Label
    Friend WithEvents LabelVal As System.Windows.Forms.Label

End Class
