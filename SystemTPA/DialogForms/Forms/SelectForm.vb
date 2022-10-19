Imports System.Windows.Forms

Public Class SelectForm

    Private ReadOnly Property ElementsOnPage() As Integer
        Get
            Try
                Dim val As Integer = Math.Min(7, Math.Max(1, Math.Floor(PanelBody.Height / 90)))
                Return Math.Min(7, Math.Max(1, Math.Floor(PanelBody.Height / 90)))
            Catch ex As Exception
                Return 4
            End Try
        End Get
    End Property

    Private _correctMode As Boolean = False
    Friend saveForm As Boolean = False
    Private _firstNum As Integer = 1
    Private Property firstNum() As Integer
        Get
            Return _firstNum
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then value = 1
            If value > coll.Count Then value = coll.Count
            If coll.Count = 0 Then value = 1
            _firstNum = value
        End Set
    End Property
    Private coll As ArrayList = New ArrayList
    Private _result As Object
    ''' <summary>
    ''' Выбранное значение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property result() As Object
        Get
            Return _result
        End Get
    End Property

#Region "new"

    Private _lastPage As Boolean = False

    ''' <summary>
    ''' Сохраняет в result выбранное значение
    ''' </summary>
    ''' <param name="_coll">список</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _coll As ArrayList, _
                   Optional ByVal head As String = "Выберите из списка", _
                   Optional ByVal correctMode As Boolean = False, _
                   Optional ByVal lastPage As Boolean = False)
        InitializeComponent()
        LabelHead.Text = head
        coll = _coll
        _lastPage = lastPage
        _correctMode = correctMode
    End Sub
    ''' <summary>
    ''' Сохраняет в result выбранное значение
    ''' </summary>
    ''' <param name="_coll">список</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _coll As Collection, _
                   Optional ByVal head As String = "Выберите из списка", _
                   Optional ByVal correctMode As Boolean = False, _
                   Optional ByVal lastPage As Boolean = False)
        InitializeComponent()
        LabelHead.Text = head
        For Each i In _coll
            coll.Add(i)
        Next
        _lastPage = lastPage
        _correctMode = correctMode
    End Sub
    ''' <summary>
    ''' Сохраняет в result выбранное значение
    ''' </summary>
    ''' <param name="_coll">список</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _coll As String(), _
                   Optional ByVal head As String = "Выберите из списка", _
                   Optional ByVal correctMode As Boolean = False, _
                   Optional ByVal lastPage As Boolean = False)
        InitializeComponent()
        LabelHead.Text = head
        For Each i In _coll
            coll.Add(i)
        Next
        _lastPage = lastPage
        _correctMode = correctMode
    End Sub
    ''' <summary>
    ''' Сохраняет в result выбранное значение
    ''' </summary>
    ''' <param name="_coll">список</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _coll As String, _
                   Optional ByVal head As String = "Выберите из списка", _
                   Optional ByVal correctMode As Boolean = False, _
                   Optional ByVal lastPage As Boolean = False)
        InitializeComponent()
        LabelHead.Text = head
        coll.Add(_coll)
        _lastPage = lastPage
        _correctMode = correctMode
    End Sub
    ''' <summary>
    ''' Сохраняет в result выбранное значение
    ''' </summary>
    ''' <param name="_coll">список</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _coll As Integer(), _
                   Optional ByVal head As String = "Выберите из списка", _
                   Optional ByVal correctMode As Boolean = False, _
                   Optional ByVal lastPage As Boolean = False)
        InitializeComponent()
        LabelHead.Text = head
        For Each i In _coll
            coll.Add(i)
        Next
        _lastPage = lastPage
        _correctMode = correctMode
    End Sub
    ''' <summary>
    ''' Сохраняет в result выбранное значение
    ''' </summary>
    ''' <param name="_coll">список</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _coll As Integer, _
                   Optional ByVal head As String = "Выберите из списка", _
                   Optional ByVal correctMode As Boolean = False, _
                   Optional ByVal lastPage As Boolean = False)
        InitializeComponent()
        LabelHead.Text = head
        coll.Add(_coll)
        _lastPage = lastPage
        _correctMode = correctMode
    End Sub
    ''' <summary>
    ''' Сохраняет в result выбранное значение
    ''' </summary>
    ''' <param name="_coll">список</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _coll As Double(), _
                   Optional ByVal head As String = "Выберите из списка", _
                   Optional ByVal correctMode As Boolean = False, _
                   Optional ByVal lastPage As Boolean = False)
        InitializeComponent()
        LabelHead.Text = head
        For Each i In _coll
            coll.Add(i)
        Next
        _lastPage = lastPage
        _correctMode = correctMode
    End Sub
    ''' <summary>
    ''' Сохраняет в result выбранное значение
    ''' </summary>
    ''' <param name="_coll">список</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _coll As Double, _
                   Optional ByVal head As String = "Выберите из списка", _
                   Optional ByVal correctMode As Boolean = False, _
                   Optional ByVal lastPage As Boolean = False)
        InitializeComponent()
        LabelHead.Text = head
        coll.Add(_coll)
        _lastPage = lastPage
        _correctMode = correctMode
    End Sub

#End Region

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TPA.GAMEMODE_FORM(Me) = True
        If _lastPage Then
            Dim minus As Integer = coll.Count Mod ElementsOnPage
            If minus = 0 Then minus = ElementsOnPage
            minus -= 1
            firstNum = coll.Count - minus
        End If
        visibleObj()
        DialogForms.WaitFormStop()
    End Sub

    Private Sub PictureBoxCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub PictureBoxOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxOk.Click
        If _correctMode Then
            If _result <> Nothing Then
                DialogResult = Windows.Forms.DialogResult.Yes
                Close()
            ElseIf saveForm Then
                DialogResult = Windows.Forms.DialogResult.OK
                Close()
            End If
        Else
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub visibleObj()
        Button1.Height = PanelBody.Height / ElementsOnPage
        Button2.Height = PanelBody.Height / ElementsOnPage
        Button3.Height = PanelBody.Height / ElementsOnPage
        Button4.Height = PanelBody.Height / ElementsOnPage
        Button5.Height = PanelBody.Height / ElementsOnPage
        Button6.Height = PanelBody.Height / ElementsOnPage
        Button7.Height = PanelBody.Height / ElementsOnPage
        If _correctMode Then
            PictureBoxOk.Visible = True
        Else
            PictureBoxOk.Visible = False
            PictureBoxDel.Visible = False
            PictureBoxAdd.Visible = False
        End If
        If firstNum < 2 Then
            PictureBoxUp.Visible = False
        Else
            PictureBoxUp.Visible = True
        End If
        If coll.Count - firstNum < ElementsOnPage Then
            PictureBoxDown.Visible = False
        Else
            PictureBoxDown.Visible = True
        End If
        Select Case Math.Min(ElementsOnPage - 1, coll.Count - firstNum)
            Case -1
                Button1.Visible = False
                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = False
                Button5.Visible = False
                Button6.Visible = False
                Button7.Visible = False
            Case 0
                Button1.Visible = True
                Button1.Text = coll(firstNum - 1)
                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = False
                Button5.Visible = False
                Button6.Visible = False
                Button7.Visible = False
            Case 1
                Button1.Visible = True
                Button1.Text = coll.Item(firstNum - 1)
                Button2.Visible = True
                Button2.Text = coll.Item(firstNum)
                Button3.Visible = False
                Button4.Visible = False
                Button5.Visible = False
                Button6.Visible = False
                Button7.Visible = False
            Case 2
                Button1.Visible = True
                Button1.Text = coll(firstNum - 1)
                Button2.Visible = True
                Button2.Text = coll.Item(firstNum)
                Button3.Visible = True
                Button3.Text = coll.Item(firstNum + 1)
                Button4.Visible = False
                Button5.Visible = False
                Button6.Visible = False
                Button7.Visible = False
            Case 3
                Button1.Visible = True
                Button1.Text = coll(firstNum - 1)
                Button2.Visible = True
                Button2.Text = coll.Item(firstNum)
                Button3.Visible = True
                Button3.Text = coll.Item(firstNum + 1)
                Button4.Visible = True
                Button4.Text = coll.Item(firstNum + 2)
                Button5.Visible = False
                Button6.Visible = False
                Button7.Visible = False
            Case 4
                Button1.Visible = True
                Button1.Text = coll(firstNum - 1)
                Button2.Visible = True
                Button2.Text = coll.Item(firstNum)
                Button3.Visible = True
                Button3.Text = coll.Item(firstNum + 1)
                Button4.Visible = True
                Button4.Text = coll.Item(firstNum + 2)
                Button5.Visible = True
                Button5.Text = coll.Item(firstNum + 3)
                Button6.Visible = False
                Button7.Visible = False
            Case 5
                Button1.Visible = True
                Button1.Text = coll(firstNum - 1)
                Button2.Visible = True
                Button2.Text = coll.Item(firstNum)
                Button3.Visible = True
                Button3.Text = coll.Item(firstNum + 1)
                Button4.Visible = True
                Button4.Text = coll.Item(firstNum + 2)
                Button5.Visible = True
                Button5.Text = coll.Item(firstNum + 3)
                Button6.Visible = True
                Button6.Text = coll.Item(firstNum + 4)
                Button7.Visible = False
            Case Else
                Button1.Visible = True
                Button1.Text = coll(firstNum - 1)
                Button2.Visible = True
                Button2.Text = coll.Item(firstNum)
                Button3.Visible = True
                Button3.Text = coll.Item(firstNum + 1)
                Button4.Visible = True
                Button4.Text = coll.Item(firstNum + 2)
                Button5.Visible = True
                Button5.Text = coll.Item(firstNum + 3)
                Button6.Visible = True
                Button6.Text = coll.Item(firstNum + 4)
                Button7.Visible = True
                Button7.Text = coll.Item(firstNum + 5)
        End Select
        If _correctMode Then
            If _result = Nothing Then
                PictureBoxDel.Enabled = False
                PictureBoxDel.Image = My.Resources.ResourceBMP.delDisabled
            Else
                PictureBoxDel.Enabled = True
                PictureBoxDel.Image = My.Resources.ResourceBMP.delEnabled
            End If
            Button1.BackColor = Drawing.Color.FromArgb(223, 223, 223)
            Button2.BackColor = Drawing.Color.FromArgb(223, 223, 223)
            Button3.BackColor = Drawing.Color.FromArgb(223, 223, 223)
            Button4.BackColor = Drawing.Color.FromArgb(223, 223, 223)
            Button5.BackColor = Drawing.Color.FromArgb(223, 223, 223)
            Button6.BackColor = Drawing.Color.FromArgb(223, 223, 223)
            Button7.BackColor = Drawing.Color.FromArgb(223, 223, 223)
        End If
    End Sub

    Private Sub PictureBoxUpDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxUp.Click, PictureBoxDown.Click
        If DirectCast(sender, PictureBox).Name.EndsWith("Up") Then
            firstNum -= ElementsOnPage
        Else
            firstNum += ElementsOnPage
        End If
        _result = Nothing
        visibleObj()
    End Sub

    Private Sub Panel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click
        _result = coll(_firstNum - 2 + Convert.ToInt32(DirectCast(sender, Button).Name.Last.ToString))
        If DirectCast(sender, Button).BackColor = Drawing.Color.Silver Then
            If _correctMode Then
                DialogResult = Windows.Forms.DialogResult.Yes
            Else
                DialogResult = Windows.Forms.DialogResult.OK
            End If
            Close()
        Else
            visibleObj()
            DirectCast(sender, Button).BackColor = Drawing.Color.Silver
            If Not _correctMode Then DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub PictureBoxDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxDel.Click
        DialogResult = Windows.Forms.DialogResult.No
        Close()
    End Sub

    Private Sub PictureBoxAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxAdd.Click
        DialogResult = Windows.Forms.DialogResult.Retry
        Close()
    End Sub
End Class