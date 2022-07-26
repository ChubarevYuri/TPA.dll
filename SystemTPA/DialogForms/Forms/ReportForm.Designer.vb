<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportForm))
        Me.PanelHead = New System.Windows.Forms.Panel
        Me.PictureBoxSave = New System.Windows.Forms.PictureBox
        Me.PictureBoxCancel = New System.Windows.Forms.PictureBox
        Me.LabelHead = New System.Windows.Forms.Label
        Me.PanelProtocol = New System.Windows.Forms.Panel
        Me.PictureBoxProtocol = New System.Windows.Forms.PictureBox
        Me.PanelHead.SuspendLayout()
        Me.PanelProtocol.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelHead
        '
        Me.PanelHead.BackColor = System.Drawing.Color.Black
        Me.PanelHead.Controls.Add(Me.PictureBoxSave)
        Me.PanelHead.Controls.Add(Me.PictureBoxCancel)
        Me.PanelHead.Controls.Add(Me.LabelHead)
        Me.PanelHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHead.Location = New System.Drawing.Point(0, 0)
        Me.PanelHead.Name = "PanelHead"
        Me.PanelHead.Size = New System.Drawing.Size(800, 80)
        '
        'PictureBoxSave
        '
        Me.PictureBoxSave.BackColor = System.Drawing.Color.Black
        Me.PictureBoxSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBoxSave.Image = CType(resources.GetObject("PictureBoxSave.Image"), System.Drawing.Image)
        Me.PictureBoxSave.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxSave.Name = "PictureBoxSave"
        Me.PictureBoxSave.Size = New System.Drawing.Size(80, 80)
        Me.PictureBoxSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
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
        Me.LabelHead.Location = New System.Drawing.Point(210, 20)
        Me.LabelHead.Name = "LabelHead"
        Me.LabelHead.Size = New System.Drawing.Size(380, 40)
        Me.LabelHead.Text = "Протокол"
        Me.LabelHead.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PanelProtocol
        '
        Me.PanelProtocol.BackColor = System.Drawing.Color.White
        Me.PanelProtocol.Controls.Add(Me.PictureBoxProtocol)
        Me.PanelProtocol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelProtocol.Location = New System.Drawing.Point(0, 80)
        Me.PanelProtocol.Name = "PanelProtocol"
        Me.PanelProtocol.Size = New System.Drawing.Size(800, 380)
        '
        'PictureBoxProtocol
        '
        Me.PictureBoxProtocol.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxProtocol.Name = "PictureBoxProtocol"
        Me.PictureBoxProtocol.Size = New System.Drawing.Size(800, 380)
        '
        'ReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 460)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelProtocol)
        Me.Controls.Add(Me.PanelHead)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportForm"
        Me.Text = "Протокол"
        Me.PanelHead.ResumeLayout(False)
        Me.PanelProtocol.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelHead As System.Windows.Forms.Panel
    Friend WithEvents PictureBoxCancel As System.Windows.Forms.PictureBox
    Friend WithEvents LabelHead As System.Windows.Forms.Label
    Friend WithEvents PictureBoxSave As System.Windows.Forms.PictureBox
    Friend WithEvents PanelProtocol As System.Windows.Forms.Panel
    Friend WithEvents PictureBoxProtocol As System.Windows.Forms.PictureBox
End Class
