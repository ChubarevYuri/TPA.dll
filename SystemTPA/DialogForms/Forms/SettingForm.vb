Imports System.Windows.Forms

Public Class SettingForm

    Private ReadOnly Property ElementsOnPage() As Integer
        Get
            Try
                Dim val As Integer = Math.Min(7, Math.Max(1, Math.Floor(PanelBody.Height / 100)))
                Return Math.Min(7, Math.Max(1, Math.Floor(PanelBody.Height / 100)))
            Catch ex As Exception
                Return 4
            End Try
        End Get
    End Property

    Private _firstNum As Integer = 1
    Private Property firstNum() As Integer
        Get
            Return _firstNum
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then value = 1
            If value > collVal.Count Then value = collVal.Count
            If collVal.Count < 1 Then value = 1
            _firstNum = value
        End Set
    End Property
    Private collVal As ArrayList = New ArrayList
    Private collName As ArrayList = New ArrayList
    Private collType As ArrayList = New ArrayList
    Private startVal As Object
    Private saveChanges As Boolean = True
    ''' <summary>
    ''' измененные значения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property result() As Object
        Get
            If saveChanges Then
                If TypeOf startVal Is Boolean Then
                    Return Convert.ToBoolean(collVal(0))
                ElseIf TypeOf startVal Is Boolean() Then
                    Return collVal.Cast(Of Boolean).ToArray
                ElseIf TypeOf startVal Is Integer Then
                    Return Convert.ToInt32(collVal(0))
                ElseIf TypeOf startVal Is Integer() Then
                    Dim res(collVal.Count - 1) As Integer
                    For i = 0 To collVal.Count - 1
                        res(i) = Convert.ToInt32(collVal(i))
                    Next
                    Return res
                ElseIf TypeOf startVal Is Double Then
                    Return Convert.ToDouble(collVal(0))
                ElseIf TypeOf startVal Is Double() Then
                    Dim res(collVal.Count - 1) As Double
                    For i = 0 To collVal.Count - 1
                        res(i) = Convert.ToDouble(collVal(i))
                    Next
                    Return res
                ElseIf TypeOf startVal Is String Then
                    Return collVal(0).ToString
                ElseIf TypeOf startVal Is String() Then
                    Dim res(collVal.Count - 1) As String
                    For i = 0 To collVal.Count - 1
                        res(i) = collVal(i)
                    Next
                    Return res
                ElseIf TypeOf startVal Is Collection Then
                    Dim col As Collection = New Collection
                    For Each i In collVal
                        col.Add(i)
                    Next
                    Return col
                Else
                    Return collVal
                End If
            Else
                Return startVal
            End If
        End Get
    End Property

#Region "new"

    Private Sub start(ByRef _values As ArrayList, ByRef _names As String(), ByVal _types As ValueType(), ByVal head As String)
        LabelHead.Text = head
        collVal = _values
        For Each i In _names
            collName.Add(i)
            If collName.Count = collVal.Count Then Exit For
        Next
        Do While collName.Count < collVal.Count
            collName.Add("")
        Loop
        For Each i In _types
            collType.Add(i)
            If collType.Count = collVal.Count Then Exit For
        Next
        Do While collType.Count < collVal.Count
            If TypeOf collVal.Item(collType.Count) Is Boolean Then
                collType.Add(ValueType.bool)
            ElseIf TypeOf collVal.Item(collType.Count) Is Integer Then
                collType.Add(ValueType.int)
            ElseIf TypeOf collVal.Item(collType.Count) Is Double Then
                collType.Add(ValueType.real)
            Else
                collType.Add(ValueType.text)
            End If
        Loop
    End Sub

#Region "strings"

    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="_types">список типов переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As String(), _
                   ByRef _names As String(), _
                   ByVal _types As ValueType(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        start(col, _names, _types, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As String(), _
                   ByRef _names As String(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        start(col, _names, New ValueType() {}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As String(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        start(col, New String() {}, New ValueType() {}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As String, _
                   Optional ByRef _names As String = "", _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        col.Add(_values)
        start(col, New String() {_names}, New ValueType() {ValueType.text}, head)
    End Sub

#End Region

#Region "integers"

    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="_types">список типов переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Integer(), _
                   ByRef _names As String(), _
                   ByVal _types As ValueType(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        start(col, _names, _types, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Integer(), _
                   ByRef _names As String(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        start(col, _names, New ValueType() {}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="_types">список типов переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Integer, _
                   ByRef _names As String, _
                   ByVal _types As ValueType, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        col.Add(_values)
        start(col, New String() {_names}, New ValueType() {_types}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Integer, _
                   ByRef _names As String, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        col.Add(_values)
        start(col, New String() {_names}, New ValueType() {ValueType.text}, head)
    End Sub

#End Region

#Region "double"

    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="_types">список типов переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Double(), _
                   ByRef _names As String(), _
                   ByVal _types As ValueType(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        start(col, _names, _types, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Double(), _
                   ByRef _names As String(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        start(col, _names, New ValueType() {}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="_types">список типов переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Double, _
                   ByRef _names As String, _
                   ByVal _types As ValueType, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        col.Add(_values)
        start(col, New String() {_names}, New ValueType() {_types}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Double, _
                   ByRef _names As String, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        col.Add(_values)
        start(col, New String() {_names}, New ValueType() {ValueType.text}, head)
    End Sub

#End Region

#Region "bool"
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Boolean(), _
                   ByRef _names As String(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        start(col, _names, New ValueType() {}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Boolean(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        start(col, New String() {}, New ValueType() {}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Boolean, _
                   ByRef _names As String, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        col.Add(_values)
        start(col, New String() {_names}, New ValueType() {ValueType.text}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Boolean)
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        col.Add(_values)
        start(col, New String() {}, New ValueType() {ValueType.text}, "")
    End Sub

#End Region

#Region "collection"

    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="_types">список типов переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Collection, _
                   ByRef _names As String(), _
                   ByVal _types As ValueType(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        Dim col As ArrayList = New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        startVal = _values
        start(col, _names, _types, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Collection, _
                   ByRef _names As String(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        Dim col As ArrayList = New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        startVal = _values
        start(col, _names, New ValueType() {}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Collection, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        Dim col As ArrayList = New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        startVal = _values
        start(col, New String() {}, New ValueType() {}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="_types">список типов переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As Collection, _
                   ByRef _names As String, _
                   ByVal _types As ValueType, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        Dim col As ArrayList = New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        startVal = _values
        start(col, New String() {_names}, New ValueType() {_types}, head)
    End Sub

#End Region

#Region "array list"

    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="_types">список типов переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As ArrayList, _
                   ByRef _names As String(), _
                   ByVal _types As ValueType(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        start(_values, _names, _types, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As ArrayList, _
                   ByRef _names As String(), _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        start(_values, _names, New ValueType() {}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As ArrayList, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        start(_values, New String() {}, New ValueType() {}, head)
    End Sub
    ''' <summary>
    ''' Сохраняет в result измененные значения
    ''' </summary>
    ''' <param name="_values">список переменных</param>
    ''' <param name="_names">список подписей переменных</param>
    ''' <param name="_types">список типов переменных</param>
    ''' <param name="head">заголовок</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _values As ArrayList, _
                   ByRef _names As String, _
                   ByVal _types As ValueType, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        start(_values, New String() {_names}, New ValueType() {_types}, head)
    End Sub

#End Region

#End Region

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TPA.GAMEMODE_FORM(Me) = True
        visibleObj()
        DialogForms.WaitFormStop()
    End Sub

    Private Sub PictureBoxCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCancel.Click
        saveChanges = False
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub PictureBoxOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxOk.Click
        saveChanges = True
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub visibleObj()
        Panel1.Height = PanelBody.Height / ElementsOnPage
        Panel1bt.Height = (Panel1.Height - Panel1b.Height) / 2
        Panel2.Height = PanelBody.Height / ElementsOnPage
        Panel2bt.Height = (Panel2.Height - Panel2b.Height) / 2
        Panel3.Height = PanelBody.Height / ElementsOnPage
        Panel3bt.Height = (Panel3.Height - Panel3b.Height) / 2
        Panel4.Height = PanelBody.Height / ElementsOnPage
        Panel4bt.Height = (Panel4.Height - Panel4b.Height) / 2
        Panel5.Height = PanelBody.Height / ElementsOnPage
        Panel5bt.Height = (Panel5.Height - Panel5b.Height) / 2
        Panel6.Height = PanelBody.Height / ElementsOnPage
        Panel6bt.Height = (Panel6.Height - Panel6b.Height) / 2
        Panel7.Height = PanelBody.Height / ElementsOnPage
        Panel7bt.Height = (Panel7.Height - Panel7b.Height) / 2
        If firstNum < 2 Then
            PictureBoxUp.Visible = False
        Else
            PictureBoxUp.Visible = True
        End If
        If collVal.Count - firstNum < ElementsOnPage Then
            PictureBoxDown.Visible = False
        Else
            PictureBoxDown.Visible = True
        End If
        Select Case Math.Min(ElementsOnPage - 1, collVal.Count - firstNum)
            Case -1
                Panel1.Visible = False
                Panel2.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
            Case 0
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
            Case 1
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = True
                panel(Label2h, Label2b, PictureBox2, collName(firstNum), collVal(firstNum), collType(firstNum))
                Panel3.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
            Case 2
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = True
                panel(Label2h, Label2b, PictureBox2, collName(firstNum), collVal(firstNum), collType(firstNum))
                Panel3.Visible = True
                panel(Label3h, Label3b, PictureBox3, collName(firstNum + 1), collVal(firstNum + 1), collType(firstNum + 1))
                Panel4.Visible = False
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
            Case 3
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = True
                panel(Label2h, Label2b, PictureBox2, collName(firstNum), collVal(firstNum), collType(firstNum))
                Panel3.Visible = True
                panel(Label3h, Label3b, PictureBox3, collName(firstNum + 1), collVal(firstNum + 1), collType(firstNum + 1))
                Panel4.Visible = True
                panel(Label4h, Label4b, PictureBox4, collName(firstNum + 2), collVal(firstNum + 2), collType(firstNum + 2))
                Panel5.Visible = False
                Panel6.Visible = False
                Panel7.Visible = False
            Case 4
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = True
                panel(Label2h, Label2b, PictureBox2, collName(firstNum), collVal(firstNum), collType(firstNum))
                Panel3.Visible = True
                panel(Label3h, Label3b, PictureBox3, collName(firstNum + 1), collVal(firstNum + 1), collType(firstNum + 1))
                Panel4.Visible = True
                panel(Label4h, Label4b, PictureBox4, collName(firstNum + 2), collVal(firstNum + 2), collType(firstNum + 2))
                Panel5.Visible = True
                panel(Label5h, Label5b, PictureBox5, collName(firstNum + 3), collVal(firstNum + 3), collType(firstNum + 3))
                Panel6.Visible = False
                Panel7.Visible = False
            Case 5
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = True
                panel(Label2h, Label2b, PictureBox2, collName(firstNum), collVal(firstNum), collType(firstNum))
                Panel3.Visible = True
                panel(Label3h, Label3b, PictureBox3, collName(firstNum + 1), collVal(firstNum + 1), collType(firstNum + 1))
                Panel4.Visible = True
                panel(Label4h, Label4b, PictureBox4, collName(firstNum + 2), collVal(firstNum + 2), collType(firstNum + 2))
                Panel5.Visible = True
                panel(Label5h, Label5b, PictureBox5, collName(firstNum + 3), collVal(firstNum + 3), collType(firstNum + 3))
                Panel6.Visible = True
                panel(Label6h, Label6b, PictureBox6, collName(firstNum + 4), collVal(firstNum + 4), collType(firstNum + 4))
                Panel7.Visible = False
            Case Else
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = True
                panel(Label2h, Label2b, PictureBox2, collName(firstNum), collVal(firstNum), collType(firstNum))
                Panel3.Visible = True
                panel(Label3h, Label3b, PictureBox3, collName(firstNum + 1), collVal(firstNum + 1), collType(firstNum + 1))
                Panel4.Visible = True
                panel(Label4h, Label4b, PictureBox4, collName(firstNum + 2), collVal(firstNum + 2), collType(firstNum + 2))
                Panel5.Visible = True
                panel(Label5h, Label5b, PictureBox5, collName(firstNum + 3), collVal(firstNum + 3), collType(firstNum + 3))
                Panel6.Visible = True
                panel(Label6h, Label6b, PictureBox6, collName(firstNum + 4), collVal(firstNum + 4), collType(firstNum + 4))
                Panel7.Visible = True
                panel(Label7h, Label7b, PictureBox7, collName(firstNum + 5), collVal(firstNum + 5), collType(firstNum + 5))
        End Select

    End Sub

    Private Sub panel(ByRef LabelH As System.Object, _
                      ByRef LabelB As System.Object, _
                      ByRef Picture As System.Object, _
                      ByRef head As String, _
                      ByRef text As Object, _
                      ByRef type As ValueType)
        DirectCast(LabelH, Label).Text = head
        If head <> "" Then DirectCast(LabelH, Label).Text &= ":"
        DirectCast(LabelH, Label).Height = If(type = ValueType.text, 26, 75)
        DirectCast(Picture, PictureBox).Visible = type = ValueType.bool
        DirectCast(LabelB, Label).Visible = type <> ValueType.bool
        DirectCast(LabelB, Label).TextAlign = If(type = ValueType.text, Drawing.ContentAlignment.TopLeft, Drawing.ContentAlignment.TopCenter)
        DirectCast(LabelB, Label).Dock = If(type = ValueType.text, DockStyle.Bottom, DockStyle.Right)
        DirectCast(LabelB, Label).Font = New Drawing.Font("Arial", If(type = ValueType.text, 26, 42), Drawing.FontStyle.Bold)
        If type = ValueType.text Then
            DirectCast(LabelB, Label).Height = 45
        Else
            DirectCast(LabelB, Label).Width = 200
        End If

        If type = ValueType.bool Then
            If text Then
                DirectCast(Picture, PictureBox).Image = My.Resources.ResourceBMP.истина
            Else
                DirectCast(Picture, PictureBox).Image = My.Resources.ResourceBMP.ложь
            End If
        Else
            DirectCast(LabelB, Label).Text = text
        End If
    End Sub

    Private Function selectPanel(ByRef value As Object, ByVal type As ValueType, ByVal name As String) As Object
        Select Case type
            Case ValueType.bool
                Try
                    value = Not value
                Catch ex As Exception
                    value = value
                End Try
            Case ValueType.int
                Dim a As Double = Val(value)
                Keyboard.Int(a, name)
                value = a
            Case ValueType.uint
                Dim a As Double = Val(value)
                Keyboard.UInt(a, name)
                value = a
            Case ValueType.real
                Dim a As Double = Val(value)
                Keyboard.Real(a, name)
                value = a
            Case ValueType.ureal
                Dim a As Double = Val(value)
                Keyboard.UReal(a, name)
                value = a
            Case Else
                Keyboard.Text(value, name)
        End Select
        Return value
    End Function

    Private Sub PictureBoxUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxUp.Click
        firstNum -= ElementsOnPage
        visibleObj()
    End Sub

    Private Sub PictureBoxDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxDown.Click
        firstNum += ElementsOnPage
        visibleObj()
    End Sub

    Private Sub Panel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click, Panel1bb.Click, Panel1bt.Click, Panel1b.Click, Label1b.Click, PictureBox1.Click
        selectPanel(collVal(firstNum - 1), collType(firstNum - 1), collName(firstNum - 1))
        visibleObj()
    End Sub

    Private Sub Panel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.Click, Panel2bt.Click, Panel2bb.Click, Panel2b.Click, Label2b.Click, PictureBox2.Click
        selectPanel(collVal(firstNum), collType(firstNum), collName(firstNum))
        visibleObj()
    End Sub

    Private Sub Panel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel3.Click, Panel3bt.Click, Panel3bb.Click, Panel3b.Click, Label3b.Click, PictureBox3.Click
        selectPanel(collVal(firstNum + 1), collType(firstNum + 1), collName(firstNum + 1))
        visibleObj()
    End Sub

    Private Sub Panel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel4.Click, Panel4bt.Click, Panel4bb.Click, Panel4b.Click, Label4b.Click, PictureBox4.Click
        selectPanel(collVal(firstNum + 2), collType(firstNum + 2), collName(firstNum + 2))
        visibleObj()
    End Sub

    Private Sub Panel5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel5.Click, Panel5bt.Click, Panel5bb.Click, Panel5b.Click, Label5b.Click, PictureBox5.Click
        selectPanel(collVal(firstNum + 3), collType(firstNum + 3), collName(firstNum + 3))
        visibleObj()
    End Sub

    Private Sub Panel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel6.Click, Panel6bt.Click, Panel6bb.Click, Panel6b.Click, Label6b.Click, PictureBox6.Click
        selectPanel(collVal(firstNum + 4), collType(firstNum + 4), collName(firstNum + 4))
        visibleObj()
    End Sub

    Private Sub Panel7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel7.Click, Panel7bt.Click, Panel7bb.Click, Panel7b.Click, Label7b.Click, PictureBox7.Click
        selectPanel(collVal(firstNum + 5), collType(firstNum + 5), collName(firstNum + 5))
        visibleObj()
    End Sub
End Class