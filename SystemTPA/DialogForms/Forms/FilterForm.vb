Public Class FilterForm

    Private _file As Ini
    Private _users As String() = New String() {}
    Private _names As String() = New String() {}
    Private _name As String = ""
    Private _num As String = ""
    Private _user As String = ""
    Private _time As String = ""
    Private _text As String = ""
    Private __dateStart As DateTime = Now.AddDays(-7)
    Private Property _dateStart() As DateTime
        Get
            Return __dateStart
        End Get
        Set(ByVal value As DateTime)
            If value > __dateStop Then value = __dateStop
            __dateStart = New DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0)
        End Set
    End Property
    Private __dateStop As DateTime = Now
    Private Property _dateStop() As DateTime
        Get
            Return __dateStop
        End Get
        Set(ByVal value As DateTime)
            If value < _dateStart Then value = _dateStop
            If value > Now Then value = Now
            __dateStop = New DateTime(value.Year, value.Month, value.Day, 23, 59, 59, 999)
        End Set
    End Property
    Private Const dateformat As String = "dd.MM.yyyy"
    Public result As Dictionary(Of String, String)

    Public Sub New(ByVal file As Ini, _
                   ByVal users As String(), _
                   ByVal names As String(), _
                   Optional ByVal head As String = "Фильтр", _
                   Optional ByVal name As String = "Name", _
                   Optional ByVal num As String = "Num", _
                   Optional ByVal user As String = "User", _
                   Optional ByVal time As String = "Time", _
                   Optional ByVal text As String = "заголовок")
        InitializeComponent()
        TPA.GAMEMODE_FORM(Me)
        _users = users
        _names = names
        _name = name
        _num = num
        _user = user
        _time = time
        _text = text
        DeviceValueDateStart.Value = _dateStart.ToString(dateformat)
        DeviceValueDateStop.Value = _dateStop.ToString(dateformat)
        LabelHead.Text = head
        _file = file
        DialogForms.WaitFormStop()
    End Sub

    Private Sub PictureBoxCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
    Private Sub PictureBoxOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxOk.Click
        WaitFormStart()
        result = _file.ReadReportsFilter(LabelUser.Text, LabelName.Text, LabelNum.Text, _dateStart, _dateStop, _name, _num, _user, _time, _text)
        DialogResult = Windows.Forms.DialogResult.OK
        WaitFormStop()
        Close()
    End Sub

    Private Sub ButtonDateStartAddDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDateStartAddDay.Click
        _dateStart = _dateStart.AddDays(1)
        DeviceValueDateStart.Value = _dateStart.ToString(dateformat)
    End Sub

    Private Sub ButtonDateStartDimDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDateStartDimDay.Click
        _dateStart = _dateStart.AddDays(-1)
        DeviceValueDateStart.Value = _dateStart.ToString(dateformat)
    End Sub

    Private Sub ButtonDateStartAddMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDateStartAddMonth.Click
        _dateStart = _dateStart.AddMonths(1)
        DeviceValueDateStart.Value = _dateStart.ToString(dateformat)
    End Sub

    Private Sub ButtonDateStartDimMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDateStartDimMonth.Click
        _dateStart = _dateStart.AddMonths(-1)
        DeviceValueDateStart.Value = _dateStart.ToString(dateformat)
    End Sub

    Private Sub ButtonDateStopAddDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDateStopAddDay.Click
        _dateStop = _dateStop.AddDays(1)
        DeviceValueDateStop.Value = _dateStop.ToString(dateformat)
    End Sub

    Private Sub ButtonDateStopDimDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDateStopDimDay.Click
        _dateStop = _dateStop.AddDays(-1)
        DeviceValueDateStop.Value = _dateStop.ToString(dateformat)
    End Sub

    Private Sub ButtonDateStopAddMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDateStopAddMonth.Click
        _dateStop = _dateStop.AddMonths(1)
        DeviceValueDateStop.Value = _dateStop.ToString(dateformat)
    End Sub

    Private Sub ButtonDateStopDimMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDateStopDimMonth.Click
        _dateStop = _dateStop.AddMonths(-1)
        DeviceValueDateStop.Value = _dateStop.ToString(dateformat)
    End Sub

    Private Sub PanelUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelUser.Click, PanelUserW.Click
        Keyboard.Text(LabelUser.Text, "Оператор")
    End Sub

    Private Sub PanelName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelName.Click, PanelNameW.Click
        Keyboard.Text(LabelName.Text, "Аппарат")
    End Sub

    Private Sub ButtonUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUser.Click
        LabelUser.Text = DialogForms.Selection(_users, "Оператор")
    End Sub

    Private Sub ButtonNewName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNewName.Click
        LabelName.Text = DialogForms.Selection(_names, "Аппарат")
    End Sub

    Private Sub PanelNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelNum.Click, PanelNumW.Click
        Keyboard.Text(LabelNum.Text, "Номер аппарата")
    End Sub
End Class