<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FilterForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FilterForm))
        Me.PictureBoxOk = New System.Windows.Forms.PictureBox
        Me.LabelHead = New System.Windows.Forms.Label
        Me.PictureBoxCancel = New System.Windows.Forms.PictureBox
        Me.PanelHead = New System.Windows.Forms.Panel
        Me.PanelBody = New System.Windows.Forms.Panel
        Me.PanelNumBoth = New System.Windows.Forms.Panel
        Me.PanelNum = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.PanelNumW = New System.Windows.Forms.Panel
        Me.LabelNum = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonDateStopDimMonth = New TPA.ButtonNew
        Me.ButtonDateStopAddMonth = New TPA.ButtonNew
        Me.ButtonDateStopDimDay = New TPA.ButtonNew
        Me.ButtonDateStopAddDay = New TPA.ButtonNew
        Me.ButtonDateStartDimMonth = New TPA.ButtonNew
        Me.ButtonDateStartAddMonth = New TPA.ButtonNew
        Me.ButtonDateStartDimDay = New TPA.ButtonNew
        Me.ButtonDateStartAddDay = New TPA.ButtonNew
        Me.DeviceValueDateStop = New TPA.DeviceValue
        Me.DeviceValueDateStart = New TPA.DeviceValue
        Me.PanelNameBoth = New System.Windows.Forms.Panel
        Me.PanelName = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.PanelNameW = New System.Windows.Forms.Panel
        Me.LabelName = New System.Windows.Forms.Label
        Me.ButtonNewName = New TPA.ButtonNew
        Me.PanelUserBoth = New System.Windows.Forms.Panel
        Me.PanelUser = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.PanelUserW = New System.Windows.Forms.Panel
        Me.LabelUser = New System.Windows.Forms.Label
        Me.ButtonUser = New TPA.ButtonNew
        Me.PanelHead.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        Me.PanelNumBoth.SuspendLayout()
        Me.PanelNum.SuspendLayout()
        Me.PanelNumW.SuspendLayout()
        Me.PanelNameBoth.SuspendLayout()
        Me.PanelName.SuspendLayout()
        Me.PanelNameW.SuspendLayout()
        Me.PanelUserBoth.SuspendLayout()
        Me.PanelUser.SuspendLayout()
        Me.PanelUserW.SuspendLayout()
        Me.SuspendLayout()
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
        'LabelHead
        '
        Me.LabelHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelHead.BackColor = System.Drawing.Color.Black
        Me.LabelHead.Font = New System.Drawing.Font("Arial", 26.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHead.ForeColor = System.Drawing.Color.White
        Me.LabelHead.Location = New System.Drawing.Point(86, 20)
        Me.LabelHead.Name = "LabelHead"
        Me.LabelHead.Size = New System.Drawing.Size(468, 40)
        Me.LabelHead.Text = "head"
        Me.LabelHead.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBoxCancel
        '
        Me.PictureBoxCancel.BackColor = System.Drawing.Color.Black
        Me.PictureBoxCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxCancel.Image = CType(resources.GetObject("PictureBoxCancel.Image"), System.Drawing.Image)
        Me.PictureBoxCancel.Location = New System.Drawing.Point(560, 0)
        Me.PictureBoxCancel.Name = "PictureBoxCancel"
        Me.PictureBoxCancel.Size = New System.Drawing.Size(80, 80)
        Me.PictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
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
        Me.PanelHead.Size = New System.Drawing.Size(640, 80)
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelBody.Controls.Add(Me.PanelNumBoth)
        Me.PanelBody.Controls.Add(Me.Label3)
        Me.PanelBody.Controls.Add(Me.Label4)
        Me.PanelBody.Controls.Add(Me.Label2)
        Me.PanelBody.Controls.Add(Me.Label1)
        Me.PanelBody.Controls.Add(Me.ButtonDateStopDimMonth)
        Me.PanelBody.Controls.Add(Me.ButtonDateStopAddMonth)
        Me.PanelBody.Controls.Add(Me.ButtonDateStopDimDay)
        Me.PanelBody.Controls.Add(Me.ButtonDateStopAddDay)
        Me.PanelBody.Controls.Add(Me.ButtonDateStartDimMonth)
        Me.PanelBody.Controls.Add(Me.ButtonDateStartAddMonth)
        Me.PanelBody.Controls.Add(Me.ButtonDateStartDimDay)
        Me.PanelBody.Controls.Add(Me.ButtonDateStartAddDay)
        Me.PanelBody.Controls.Add(Me.DeviceValueDateStop)
        Me.PanelBody.Controls.Add(Me.DeviceValueDateStart)
        Me.PanelBody.Controls.Add(Me.PanelNameBoth)
        Me.PanelBody.Controls.Add(Me.PanelUserBoth)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 80)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(640, 400)
        '
        'PanelNumBoth
        '
        Me.PanelNumBoth.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelNumBoth.Controls.Add(Me.PanelNum)
        Me.PanelNumBoth.Controls.Add(Me.Panel1)
        Me.PanelNumBoth.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelNumBoth.Location = New System.Drawing.Point(0, 140)
        Me.PanelNumBoth.Name = "PanelNumBoth"
        Me.PanelNumBoth.Size = New System.Drawing.Size(640, 70)
        '
        'PanelNum
        '
        Me.PanelNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelNum.Controls.Add(Me.Label7)
        Me.PanelNum.Controls.Add(Me.PanelNumW)
        Me.PanelNum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelNum.Location = New System.Drawing.Point(0, 0)
        Me.PanelNum.Name = "PanelNum"
        Me.PanelNum.Size = New System.Drawing.Size(490, 70)
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(25, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 25)
        Me.Label7.Text = "Номер"
        '
        'PanelNumW
        '
        Me.PanelNumW.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelNumW.BackColor = System.Drawing.Color.White
        Me.PanelNumW.Controls.Add(Me.LabelNum)
        Me.PanelNumW.Location = New System.Drawing.Point(161, 11)
        Me.PanelNumW.Name = "PanelNumW"
        Me.PanelNumW.Size = New System.Drawing.Size(329, 44)
        '
        'LabelNum
        '
        Me.LabelNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelNum.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LabelNum.Location = New System.Drawing.Point(8, 8)
        Me.LabelNum.Name = "LabelNum"
        Me.LabelNum.Size = New System.Drawing.Size(473, 28)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(490, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(150, 70)
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(540, 305)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 27)
        Me.Label3.Text = "месяц"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(270, 305)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 27)
        Me.Label4.Text = "день"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(270, 305)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 27)
        Me.Label2.Text = "месяц"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 305)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 27)
        Me.Label1.Text = "день"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonDateStopDimMonth
        '
        Me.ButtonDateStopDimMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDateStopDimMonth.FontSize = 36.0!
        Me.ButtonDateStopDimMonth.Location = New System.Drawing.Point(540, 335)
        Me.ButtonDateStopDimMonth.MyText = "▼"
        Me.ButtonDateStopDimMonth.Name = "ButtonDateStopDimMonth"
        Me.ButtonDateStopDimMonth.Size = New System.Drawing.Size(100, 65)
        Me.ButtonDateStopDimMonth.TabIndex = 16
        '
        'ButtonDateStopAddMonth
        '
        Me.ButtonDateStopAddMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDateStopAddMonth.FontSize = 32.0!
        Me.ButtonDateStopAddMonth.Location = New System.Drawing.Point(540, 240)
        Me.ButtonDateStopAddMonth.MyText = "▲"
        Me.ButtonDateStopAddMonth.Name = "ButtonDateStopAddMonth"
        Me.ButtonDateStopAddMonth.Size = New System.Drawing.Size(100, 65)
        Me.ButtonDateStopAddMonth.TabIndex = 15
        '
        'ButtonDateStopDimDay
        '
        Me.ButtonDateStopDimDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDateStopDimDay.FontSize = 36.0!
        Me.ButtonDateStopDimDay.Location = New System.Drawing.Point(270, 335)
        Me.ButtonDateStopDimDay.MyText = "▼"
        Me.ButtonDateStopDimDay.Name = "ButtonDateStopDimDay"
        Me.ButtonDateStopDimDay.Size = New System.Drawing.Size(100, 65)
        Me.ButtonDateStopDimDay.TabIndex = 14
        '
        'ButtonDateStopAddDay
        '
        Me.ButtonDateStopAddDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDateStopAddDay.FontSize = 32.0!
        Me.ButtonDateStopAddDay.Location = New System.Drawing.Point(270, 240)
        Me.ButtonDateStopAddDay.MyText = "▲"
        Me.ButtonDateStopAddDay.Name = "ButtonDateStopAddDay"
        Me.ButtonDateStopAddDay.Size = New System.Drawing.Size(100, 65)
        Me.ButtonDateStopAddDay.TabIndex = 13
        '
        'ButtonDateStartDimMonth
        '
        Me.ButtonDateStartDimMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDateStartDimMonth.FontSize = 36.0!
        Me.ButtonDateStartDimMonth.Location = New System.Drawing.Point(270, 335)
        Me.ButtonDateStartDimMonth.MyText = "▼"
        Me.ButtonDateStartDimMonth.Name = "ButtonDateStartDimMonth"
        Me.ButtonDateStartDimMonth.Size = New System.Drawing.Size(100, 65)
        Me.ButtonDateStartDimMonth.TabIndex = 12
        '
        'ButtonDateStartAddMonth
        '
        Me.ButtonDateStartAddMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDateStartAddMonth.FontSize = 32.0!
        Me.ButtonDateStartAddMonth.Location = New System.Drawing.Point(270, 240)
        Me.ButtonDateStartAddMonth.MyText = "▲"
        Me.ButtonDateStartAddMonth.Name = "ButtonDateStartAddMonth"
        Me.ButtonDateStartAddMonth.Size = New System.Drawing.Size(100, 65)
        Me.ButtonDateStartAddMonth.TabIndex = 11
        '
        'ButtonDateStartDimDay
        '
        Me.ButtonDateStartDimDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDateStartDimDay.FontSize = 36.0!
        Me.ButtonDateStartDimDay.Location = New System.Drawing.Point(0, 335)
        Me.ButtonDateStartDimDay.MyText = "▼"
        Me.ButtonDateStartDimDay.Name = "ButtonDateStartDimDay"
        Me.ButtonDateStartDimDay.Size = New System.Drawing.Size(100, 65)
        Me.ButtonDateStartDimDay.TabIndex = 10
        '
        'ButtonDateStartAddDay
        '
        Me.ButtonDateStartAddDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDateStartAddDay.FontSize = 32.0!
        Me.ButtonDateStartAddDay.Location = New System.Drawing.Point(0, 240)
        Me.ButtonDateStartAddDay.MyText = "▲"
        Me.ButtonDateStartAddDay.Name = "ButtonDateStartAddDay"
        Me.ButtonDateStartAddDay.Size = New System.Drawing.Size(100, 65)
        Me.ButtonDateStartAddDay.TabIndex = 9
        '
        'DeviceValueDateStop
        '
        Me.DeviceValueDateStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeviceValueDateStop.FontSize = 22.0!
        Me.DeviceValueDateStop.Head = "до"
        Me.DeviceValueDateStop.Location = New System.Drawing.Point(370, 267)
        Me.DeviceValueDateStop.Measure = " "
        Me.DeviceValueDateStop.Name = "DeviceValueDateStop"
        Me.DeviceValueDateStop.Size = New System.Drawing.Size(170, 100)
        Me.DeviceValueDateStop.TabIndex = 4
        Me.DeviceValueDateStop.Value = "22.08.2022"
        '
        'DeviceValueDateStart
        '
        Me.DeviceValueDateStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DeviceValueDateStart.FontSize = 22.0!
        Me.DeviceValueDateStart.Head = "от"
        Me.DeviceValueDateStart.Location = New System.Drawing.Point(100, 267)
        Me.DeviceValueDateStart.Measure = " "
        Me.DeviceValueDateStart.Name = "DeviceValueDateStart"
        Me.DeviceValueDateStart.Size = New System.Drawing.Size(170, 100)
        Me.DeviceValueDateStart.TabIndex = 3
        Me.DeviceValueDateStart.Value = "22.08.2022"
        '
        'PanelNameBoth
        '
        Me.PanelNameBoth.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelNameBoth.Controls.Add(Me.PanelName)
        Me.PanelNameBoth.Controls.Add(Me.ButtonNewName)
        Me.PanelNameBoth.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelNameBoth.Location = New System.Drawing.Point(0, 70)
        Me.PanelNameBoth.Name = "PanelNameBoth"
        Me.PanelNameBoth.Size = New System.Drawing.Size(640, 70)
        '
        'PanelName
        '
        Me.PanelName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelName.Controls.Add(Me.Label6)
        Me.PanelName.Controls.Add(Me.PanelNameW)
        Me.PanelName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelName.Location = New System.Drawing.Point(0, 0)
        Me.PanelName.Name = "PanelName"
        Me.PanelName.Size = New System.Drawing.Size(490, 70)
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(25, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 25)
        Me.Label6.Text = "Аппарат"
        '
        'PanelNameW
        '
        Me.PanelNameW.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelNameW.BackColor = System.Drawing.Color.White
        Me.PanelNameW.Controls.Add(Me.LabelName)
        Me.PanelNameW.Location = New System.Drawing.Point(161, 11)
        Me.PanelNameW.Name = "PanelNameW"
        Me.PanelNameW.Size = New System.Drawing.Size(329, 44)
        '
        'LabelName
        '
        Me.LabelName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelName.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LabelName.Location = New System.Drawing.Point(8, 8)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Size = New System.Drawing.Size(473, 28)
        '
        'ButtonNewName
        '
        Me.ButtonNewName.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonNewName.FontSize = 48.0!
        Me.ButtonNewName.Location = New System.Drawing.Point(490, 0)
        Me.ButtonNewName.MyText = "▼"
        Me.ButtonNewName.Name = "ButtonNewName"
        Me.ButtonNewName.Size = New System.Drawing.Size(150, 70)
        Me.ButtonNewName.TabIndex = 6
        '
        'PanelUserBoth
        '
        Me.PanelUserBoth.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelUserBoth.Controls.Add(Me.PanelUser)
        Me.PanelUserBoth.Controls.Add(Me.ButtonUser)
        Me.PanelUserBoth.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelUserBoth.Location = New System.Drawing.Point(0, 0)
        Me.PanelUserBoth.Name = "PanelUserBoth"
        Me.PanelUserBoth.Size = New System.Drawing.Size(640, 70)
        '
        'PanelUser
        '
        Me.PanelUser.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelUser.Controls.Add(Me.Label5)
        Me.PanelUser.Controls.Add(Me.PanelUserW)
        Me.PanelUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelUser.Location = New System.Drawing.Point(0, 0)
        Me.PanelUser.Name = "PanelUser"
        Me.PanelUser.Size = New System.Drawing.Size(490, 70)
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(25, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 25)
        Me.Label5.Text = "Оператор"
        '
        'PanelUserW
        '
        Me.PanelUserW.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelUserW.BackColor = System.Drawing.Color.White
        Me.PanelUserW.Controls.Add(Me.LabelUser)
        Me.PanelUserW.Location = New System.Drawing.Point(161, 11)
        Me.PanelUserW.Name = "PanelUserW"
        Me.PanelUserW.Size = New System.Drawing.Size(329, 44)
        '
        'LabelUser
        '
        Me.LabelUser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelUser.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LabelUser.Location = New System.Drawing.Point(8, 8)
        Me.LabelUser.Name = "LabelUser"
        Me.LabelUser.Size = New System.Drawing.Size(313, 28)
        '
        'ButtonUser
        '
        Me.ButtonUser.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonUser.FontSize = 48.0!
        Me.ButtonUser.Location = New System.Drawing.Point(490, 0)
        Me.ButtonUser.MyText = "▼"
        Me.ButtonUser.Name = "ButtonUser"
        Me.ButtonUser.Size = New System.Drawing.Size(150, 70)
        Me.ButtonUser.TabIndex = 5
        '
        'FilterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelHead)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FilterForm"
        Me.Text = "Выбор"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelHead.ResumeLayout(False)
        Me.PanelBody.ResumeLayout(False)
        Me.PanelNumBoth.ResumeLayout(False)
        Me.PanelNum.ResumeLayout(False)
        Me.PanelNumW.ResumeLayout(False)
        Me.PanelNameBoth.ResumeLayout(False)
        Me.PanelName.ResumeLayout(False)
        Me.PanelNameW.ResumeLayout(False)
        Me.PanelUserBoth.ResumeLayout(False)
        Me.PanelUser.ResumeLayout(False)
        Me.PanelUserW.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBoxOk As System.Windows.Forms.PictureBox
    Friend WithEvents LabelHead As System.Windows.Forms.Label
    Friend WithEvents PictureBoxCancel As System.Windows.Forms.PictureBox
    Friend WithEvents PanelHead As System.Windows.Forms.Panel
    Friend WithEvents PanelBody As System.Windows.Forms.Panel
    Friend WithEvents PanelUserBoth As System.Windows.Forms.Panel
    Friend WithEvents PanelUser As System.Windows.Forms.Panel
    Friend WithEvents PanelUserW As System.Windows.Forms.Panel
    Friend WithEvents LabelUser As System.Windows.Forms.Label
    Friend WithEvents DeviceValueDateStop As TPA.DeviceValue
    Friend WithEvents DeviceValueDateStart As TPA.DeviceValue
    Friend WithEvents PanelNameBoth As System.Windows.Forms.Panel
    Friend WithEvents PanelName As System.Windows.Forms.Panel
    Friend WithEvents PanelNameW As System.Windows.Forms.Panel
    Friend WithEvents LabelName As System.Windows.Forms.Label
    Friend WithEvents ButtonUser As TPA.ButtonNew
    Friend WithEvents ButtonDateStopDimMonth As TPA.ButtonNew
    Friend WithEvents ButtonDateStopAddMonth As TPA.ButtonNew
    Friend WithEvents ButtonDateStopDimDay As TPA.ButtonNew
    Friend WithEvents ButtonDateStopAddDay As TPA.ButtonNew
    Friend WithEvents ButtonDateStartDimMonth As TPA.ButtonNew
    Friend WithEvents ButtonDateStartAddMonth As TPA.ButtonNew
    Friend WithEvents ButtonDateStartDimDay As TPA.ButtonNew
    Friend WithEvents ButtonDateStartAddDay As TPA.ButtonNew
    Friend WithEvents ButtonNewName As TPA.ButtonNew
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PanelNumBoth As System.Windows.Forms.Panel
    Friend WithEvents PanelNum As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PanelNumW As System.Windows.Forms.Panel
    Friend WithEvents LabelNum As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
