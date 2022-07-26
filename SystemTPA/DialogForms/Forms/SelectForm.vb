Imports System.Windows.Forms

Public Class SelectForm
    Private _correctMode As Boolean = False
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
        If lastPage Then
            Dim minus As Integer = coll.Count Mod 4
            If minus = 0 Then minus = 4
            minus -= 1
            firstNum = coll.Count - minus
        End If
        _correctMode = correctMode
        visibleObj()
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
        If lastPage Then
            Dim minus As Integer = coll.Count Mod 4
            If minus = 0 Then minus = 4
            minus -= 1
            firstNum = coll.Count - minus
        End If
        _correctMode = correctMode
        visibleObj()
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
        If lastPage Then
            Dim minus As Integer = coll.Count Mod 4
            If minus = 0 Then minus = 4
            minus -= 1
            firstNum = coll.Count - minus
        End If
        _correctMode = correctMode
        visibleObj()
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
        If lastPage Then
            Dim minus As Integer = coll.Count Mod 4
            If minus = 0 Then minus = 4
            minus -= 1
            firstNum = coll.Count - minus
        End If
        _correctMode = correctMode
        visibleObj()
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
        If lastPage Then
            Dim minus As Integer = coll.Count Mod 4
            If minus = 0 Then minus = 4
            minus -= 1
            firstNum = coll.Count - minus
        End If
        _correctMode = correctMode
        visibleObj()
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
        If lastPage Then
            Dim minus As Integer = coll.Count Mod 4
            If minus = 0 Then minus = 4
            minus -= 1
            firstNum = coll.Count - minus
        End If
        _correctMode = correctMode
        visibleObj()
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
        If lastPage Then
            Dim minus As Integer = coll.Count Mod 4
            If minus = 0 Then minus = 4
            minus -= 1
            firstNum = coll.Count - minus
        End If
        _correctMode = correctMode
        visibleObj()
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
        If lastPage Then
            Dim minus As Integer = coll.Count Mod 4
            If minus = 0 Then minus = 4
            minus -= 1
            firstNum = coll.Count - minus
        End If
        _correctMode = correctMode
        visibleObj()
    End Sub

#End Region

    Private Sub PictureBoxCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub PictureBoxOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxOk.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub visibleObj()
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
        If coll.Count - firstNum < 4 Then
            PictureBoxDown.Visible = False
        Else
            PictureBoxDown.Visible = True
        End If
        Select Case coll.Count - firstNum
            Case -1
                Panel1.Visible = False
                Panel2.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
            Case 0
                Panel1.Visible = True
                Label1.Text = coll(firstNum - 1)
                Panel2.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
            Case 1
                Panel1.Visible = True
                Label1.Text = coll.Item(firstNum - 1)
                Panel2.Visible = True
                Label2.Text = coll.Item(firstNum)
                Panel3.Visible = False
                Panel4.Visible = False
            Case 2
                Panel1.Visible = True
                Label1.Text = coll(firstNum - 1)
                Panel2.Visible = True
                Label2.Text = coll.Item(firstNum)
                Panel3.Visible = True
                Label3.Text = coll.Item(firstNum + 1)
                Panel4.Visible = False
            Case Else
                Panel1.Visible = True
                Label1.Text = coll(firstNum - 1)
                Panel2.Visible = True
                Label2.Text = coll.Item(firstNum)
                Panel3.Visible = True
                Label3.Text = coll.Item(firstNum + 1)
                Panel4.Visible = True
                Label4.Text = coll.Item(firstNum + 2)
        End Select
        If _correctMode Then
            If _result = Nothing Then
                PictureBoxDel.Enabled = False
                PictureBoxDel.Image = My.Resources.ResourceBMP.delDisabled
            Else
                PictureBoxDel.Enabled = True
                PictureBoxDel.Image = My.Resources.ResourceBMP.delEnabled
            End If
            Panel1.BackColor = Drawing.Color.FromArgb(223, 223, 223)
            Panel2.BackColor = Drawing.Color.FromArgb(223, 223, 223)
            Panel3.BackColor = Drawing.Color.FromArgb(223, 223, 223)
            Panel4.BackColor = Drawing.Color.FromArgb(223, 223, 223)
        End If
    End Sub

    Private Sub PictureBoxUpDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxUp.Click, PictureBoxDown.Click
        If DirectCast(sender, PictureBox).Name.EndsWith("Up") Then
            firstNum -= 4
        Else
            firstNum += 4
        End If
        _result = Nothing
        visibleObj()
    End Sub

    Private Sub Panel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click, Panel2.Click, Panel3.Click, Panel4.Click
        _result = coll(_firstNum - 2 + Convert.ToInt32(DirectCast(sender, Panel).Name.Last.ToString))
        If DirectCast(sender, Panel).BackColor = Drawing.Color.Silver Then
            If _correctMode Then
                DialogResult = Windows.Forms.DialogResult.Yes
            Else
                DialogResult = Windows.Forms.DialogResult.OK
            End If
            Close()
        Else
            visibleObj()
            DirectCast(sender, Panel).BackColor = Drawing.Color.Silver
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