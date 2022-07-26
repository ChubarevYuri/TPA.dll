Imports System.Windows.Forms

Public Class SettingForm

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
                    Return collVal.Cast(Of Int32).ToArray
                ElseIf TypeOf startVal Is Double Then
                    Return Convert.ToDouble(collVal(0))
                ElseIf TypeOf startVal Is Double() Then
                    Return collVal.Cast(Of Double).ToArray
                ElseIf TypeOf startVal Is String Then
                    Return collVal(0).ToString
                ElseIf TypeOf startVal Is String() Then
                    Return collVal.Cast(Of String).ToArray
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

    Private Sub start(ByRef _values As ArrayList, ByRef _names As String(), ByVal _types As DialogForms.ValueType(), ByVal head As String)
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
                collType.Add(DialogForms.ValueType.bool)
            ElseIf TypeOf collVal.Item(collType.Count) Is Integer Then
                collType.Add(DialogForms.ValueType.int)
            ElseIf TypeOf collVal.Item(collType.Count) Is Double Then
                collType.Add(DialogForms.ValueType.real)
            Else
                collType.Add(DialogForms.ValueType.text)
            End If
        Loop
        visibleObj()
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
                   ByVal _types As DialogForms.ValueType(), _
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
        start(col, _names, New DialogForms.ValueType() {}, head)
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
        start(col, New String() {}, New DialogForms.ValueType() {}, head)
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
        start(col, New String() {_names}, New DialogForms.ValueType() {DialogForms.ValueType.text}, head)
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
                   ByVal _types As DialogForms.ValueType(), _
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
        start(col, _names, New DialogForms.ValueType() {}, head)
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
                   ByVal _types As DialogForms.ValueType, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        col.Add(_values)
        start(col, New String() {_names}, New DialogForms.ValueType() {_types}, head)
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
        start(col, New String() {_names}, New DialogForms.ValueType() {DialogForms.ValueType.text}, head)
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
                   ByVal _types As DialogForms.ValueType(), _
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
        start(col, _names, New DialogForms.ValueType() {}, head)
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
                   ByVal _types As DialogForms.ValueType, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        Dim col As New ArrayList
        col.Add(_values)
        start(col, New String() {_names}, New DialogForms.ValueType() {_types}, head)
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
        start(col, New String() {_names}, New DialogForms.ValueType() {DialogForms.ValueType.text}, head)
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
        start(col, _names, New DialogForms.ValueType() {}, head)
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
        start(col, New String() {}, New DialogForms.ValueType() {}, head)
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
        start(col, New String() {_names}, New DialogForms.ValueType() {DialogForms.ValueType.text}, head)
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
        start(col, New String() {}, New DialogForms.ValueType() {DialogForms.ValueType.text}, "")
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
                   ByVal _types As DialogForms.ValueType(), _
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
        start(col, _names, New DialogForms.ValueType() {}, head)
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
        start(col, New String() {}, New DialogForms.ValueType() {}, head)
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
                   ByVal _types As DialogForms.ValueType, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        Dim col As ArrayList = New ArrayList
        For Each i In _values
            col.Add(i)
        Next
        startVal = _values
        start(col, New String() {_names}, New DialogForms.ValueType() {_types}, head)
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
                   ByVal _types As DialogForms.ValueType(), _
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
        start(_values, _names, New DialogForms.ValueType() {}, head)
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
        start(_values, New String() {}, New DialogForms.ValueType() {}, head)
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
                   ByVal _types As DialogForms.ValueType, _
                   Optional ByVal head As String = "Параметры")
        InitializeComponent()
        startVal = _values
        start(_values, New String() {_names}, New DialogForms.ValueType() {_types}, head)
    End Sub

#End Region

#End Region

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
        If firstNum < 2 Then
            PictureBoxUp.Visible = False
        Else
            PictureBoxUp.Visible = True
        End If
        If collVal.Count - firstNum < 4 Then
            PictureBoxDown.Visible = False
        Else
            PictureBoxDown.Visible = True
        End If
        Select Case collVal.Count - firstNum
            Case -1
                Panel1.Visible = False
                Panel2.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
            Case 0
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = False
                Panel3.Visible = False
                Panel4.Visible = False
            Case 1
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = True
                panel(Label2h, Label2b, PictureBox2, collName(firstNum), collVal(firstNum), collType(firstNum))
                Panel3.Visible = False
                Panel4.Visible = False
            Case 2
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = True
                panel(Label2h, Label2b, PictureBox2, collName(firstNum), collVal(firstNum), collType(firstNum))
                Panel3.Visible = True
                panel(Label3h, Label3b, PictureBox3, collName(firstNum + 1), collVal(firstNum + 1), collType(firstNum + 1))
                Panel4.Visible = False
            Case Else
                Panel1.Visible = True
                panel(Label1h, Label1b, PictureBox1, collName(firstNum - 1), collVal(firstNum - 1), collType(firstNum - 1))
                Panel2.Visible = True
                panel(Label2h, Label2b, PictureBox2, collName(firstNum), collVal(firstNum), collType(firstNum))
                Panel3.Visible = True
                panel(Label3h, Label3b, PictureBox3, collName(firstNum + 1), collVal(firstNum + 1), collType(firstNum + 1))
                Panel4.Visible = True
                panel(Label4h, Label4b, PictureBox4, collName(firstNum + 2), collVal(firstNum + 2), collType(firstNum + 2))
        End Select

    End Sub

    Private Sub panel(ByRef LabelH As System.Object, _
                      ByRef LabelB As System.Object, _
                      ByRef Picture As System.Object, _
                      ByRef head As String, _
                      ByRef text As Object, _
                      ByRef type As DialogForms.ValueType)
        DirectCast(LabelH, Label).Text = head
        If head <> "" Then DirectCast(LabelH, Label).Text &= ":"
        If type = DialogForms.ValueType.bool Then
            DirectCast(LabelB, Label).Visible = False
            DirectCast(Picture, PictureBox).Visible = True
            If text Then
                DirectCast(Picture, PictureBox).Image = My.Resources.ResourceBMP._true
            Else
                DirectCast(Picture, PictureBox).Image = My.Resources.ResourceBMP._false
            End If
        Else
            DirectCast(Picture, PictureBox).Visible = False
            DirectCast(LabelB, Label).Visible = True
            DirectCast(LabelB, Label).Text = text
        End If
    End Sub

    Private Function selectPanel(ByRef value As Object, ByVal type As DialogForms.ValueType, ByVal name As String) As Object
        Select Case type
            Case DialogForms.ValueType.bool
                Try
                    value = Not value
                Catch ex As Exception
                    value = value
                End Try
            Case DialogForms.ValueType.int
                Keyboard.Int(value, name)
            Case DialogForms.ValueType.uint
                Keyboard.UInt(value, name)
            Case DialogForms.ValueType.real
                Keyboard.Real(value, name)
            Case DialogForms.ValueType.ureal
                Keyboard.UReal(value, name)
            Case Else
                Keyboard.Text(value, name)
        End Select
        Return value
    End Function

    Private Sub PictureBoxUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxUp.Click
        firstNum -= 4
        visibleObj()
    End Sub

    Private Sub PictureBoxDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxDown.Click
        firstNum += 4
        visibleObj()
    End Sub

    Private Sub Panel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click
        selectPanel(collVal(firstNum - 1), collType(firstNum - 1), collName(firstNum - 1))
        visibleObj()
    End Sub

    Private Sub Panel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.Click
        selectPanel(collVal(firstNum), collType(firstNum), collName(firstNum))
        visibleObj()
    End Sub

    Private Sub Panel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel3.Click
        selectPanel(collVal(firstNum + 1), collType(firstNum + 1), collName(firstNum + 1))
        visibleObj()
    End Sub

    Private Sub Panel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel4.Click
        selectPanel(collVal(firstNum + 2), collType(firstNum + 2), collName(firstNum + 2))
        visibleObj()
    End Sub
End Class