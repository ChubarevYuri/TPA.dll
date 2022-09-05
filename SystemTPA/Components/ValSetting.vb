Public Class ValSetting
    Private _type As ValueType = ValueType.real
    ''' <summary>
    ''' тип передаваемого значения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Type() As ValueType
        Get
            Return _type
        End Get
        Set(ByVal value As ValueType)
            _type = value
            If value = ValueType.count Or value = ValueType.text Then
                PictureBoxBool.Visible = False
                PanelMin.Visible = True
                PanelMax.Visible = False
                LabelPoint.Visible = False
                LabelEI.Visible = False
                PanelMin.Dock = Windows.Forms.DockStyle.Fill
                TextSizeMin()
            ElseIf value = ValueType.bool Then
                PictureBoxBool.Visible = True
                PanelMin.Visible = False
                PanelMax.Visible = False
                LabelPoint.Visible = False
                LabelEI.Visible = False
                PictureBoxBool.Image = If(_valueB, _
                                          My.Resources.ResourceBMP.истина, _
                                          My.Resources.ResourceBMP.ложь)
            Else
                PictureBoxBool.Visible = False
                PanelMin.Visible = True
                PanelMax.Visible = True
                LabelPoint.Visible = True
                LabelEI.Visible = True
                PanelMin.Dock = Windows.Forms.DockStyle.Left
                PanelMin.Width = Math.Floor((Me.Width - LabelPoint.Width) / 2)
                PanelMax.Width = Math.Floor((Me.Width - LabelPoint.Width) / 2)
                TextSizeMin()
                TextSizeMax()
            End If
        End Set
    End Property
    Private _valueB As Boolean = False
    ''' <summary>
    ''' Возвращает и задает значение для типов count, text, bool, paramValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value() As Object
        Get
            If Type = ValueType.bool Then
                Return _valueB
            ElseIf Type = ValueType.count Then
                Try
                    Return Convert.ToInt32(LabelMin.Text)
                Catch ex As Exception
                    Return 0
                End Try
            ElseIf Type = ValueType.text Then
                Return LabelMin.Text
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As Object)
            If TypeOf value Is Boolean Then
                _valueB = value
                PictureBoxBool.Image = If(_valueB, _
                                          My.Resources.ResourceBMP.истина, _
                                          My.Resources.ResourceBMP.ложь)
            ElseIf TypeOf value Is Integer Then
                LabelMin.Text = value.ToString
            ElseIf TypeOf value Is String Then
                LabelMin.Text = value
            ElseIf TypeOf value Is ParamValue Then

            End If
        End Set
    End Property
    ''' <summary>
    ''' Возвращает и задает минимальное значение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ValueMin() As Double
        Get
            Try
                Return Convert.ToDouble(LabelMin.Text)
            Catch ex As Exception
                Return Double.MinValue
            End Try
        End Get
        Set(ByVal value As Double)
            If value = Double.MinValue Then
                LabelMin.Text = "---"
            Else
                LabelMin.Text = value.ToString
            End If
        End Set
    End Property
    ''' <summary>
    ''' Возвращает и задает максимальное значение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ValueMax() As Double
        Get
            Try
                Return Convert.ToDouble(LabelMax.Text)
            Catch ex As Exception
                Return Double.MaxValue
            End Try
        End Get
        Set(ByVal value As Double)
            If value = Double.MaxValue Then
                LabelMax.Text = "---"
            Else
                LabelMax.Text = value.ToString
            End If
        End Set
    End Property
    Private Sub TextSizeMin()
        Dim _sizeh As Integer = 14
        Dim _sizew As Integer = 14
        If LabelMin.Height < 23 Then
            _sizeh = 11
        ElseIf LabelMin.Height < 24 Then
            _sizeh = 14
        ElseIf LabelMin.Height < 25 Then
            _sizeh = 15
        ElseIf LabelMin.Height < 29 Then
            _sizeh = 16
        ElseIf LabelMin.Height < 30 Then
            _sizeh = 17
        ElseIf LabelMin.Height < 31 Then
            _sizeh = 18
        ElseIf LabelMin.Height < 33 Then
            _sizeh = 19
        ElseIf LabelMin.Height < 35 Then
            _sizeh = 20
        ElseIf LabelMin.Height < 36 Then
            _sizeh = 21
        ElseIf LabelMin.Height < 38 Then
            _sizeh = 23
        ElseIf LabelMin.Height < 40 Then
            _sizeh = 24
        ElseIf LabelMin.Height < 42 Then
            _sizeh = 25
        ElseIf LabelMin.Height < 44 Then
            _sizeh = 26
        ElseIf LabelMin.Height < 46 Then
            _sizeh = 27
        ElseIf LabelMin.Height < 47 Then
            _sizeh = 28
        ElseIf LabelMin.Height < 48 Then
            _sizeh = 29
        ElseIf LabelMin.Height < 49 Then
            _sizeh = 30
        ElseIf LabelMin.Height < 53 Then
            _sizeh = 31
        ElseIf LabelMin.Height < 54 Then
            _sizeh = 32
        ElseIf LabelMin.Height < 55 Then
            _sizeh = 33
        ElseIf LabelMin.Height < 57 Then
            _sizeh = 34
        ElseIf LabelMin.Height < 59 Then
            _sizeh = 35
        ElseIf LabelMin.Height < 60 Then
            _sizeh = 36
        ElseIf LabelMin.Height < 62 Then
            _sizeh = 37
        ElseIf LabelMin.Height < 64 Then
            _sizeh = 38
        ElseIf LabelMin.Height < 65 Then
            _sizeh = 39
        ElseIf LabelMin.Height < 67 Then
            _sizeh = 40
        ElseIf LabelMin.Height < 68 Then
            _sizeh = 41
        ElseIf LabelMin.Height < 70 Then
            _sizeh = 42
        ElseIf LabelMin.Height < 72 Then
            _sizeh = 43
        ElseIf LabelMin.Height < 73 Then
            _sizeh = 44
        ElseIf LabelMin.Height < 74 Then
            _sizeh = 45
        ElseIf LabelMin.Height < 75 Then
            _sizeh = 46
        ElseIf LabelMin.Height < 77 Then
            _sizeh = 47
        Else
            _sizeh = 48
        End If
        If LabelMin.Width < 70 Then
            _sizew = 11
        ElseIf LabelMin.Width < 72 Then
            _sizew = 14
        ElseIf LabelMin.Width < 76 Then
            _sizew = 15
        ElseIf LabelMin.Width < 82 Then
            _sizew = 16
        ElseIf LabelMin.Width < 85 Then
            _sizew = 17
        ElseIf LabelMin.Width < 90 Then
            _sizew = 18
        ElseIf LabelMin.Width < 95 Then
            _sizew = 19
        ElseIf LabelMin.Width < 100 Then
            _sizew = 20
        ElseIf LabelMin.Width < 105 Then
            _sizew = 21
        ElseIf LabelMin.Width < 109 Then
            _sizew = 22
        ElseIf LabelMin.Width < 114 Then
            _sizew = 23
        ElseIf LabelMin.Width < 120 Then
            _sizew = 24
        ElseIf LabelMin.Width < 125 Then
            _sizew = 25
        ElseIf LabelMin.Width < 128 Then
            _sizew = 26
        ElseIf LabelMin.Width < 133 Then
            _sizew = 27
        ElseIf LabelMin.Width < 137 Then
            _sizew = 28
        ElseIf LabelMin.Width < 142 Then
            _sizew = 29
        ElseIf LabelMin.Width < 148 Then
            _sizew = 30
        ElseIf LabelMin.Width < 152 Then
            _sizew = 31
        ElseIf LabelMin.Width < 157 Then
            _sizew = 32
        ElseIf LabelMin.Width < 162 Then
            _sizew = 33
        ElseIf LabelMin.Width < 167 Then
            _sizew = 34
        ElseIf LabelMin.Width < 170 Then
            _sizew = 35
        ElseIf LabelMin.Width < 175 Then
            _sizew = 36
        ElseIf LabelMin.Width < 180 Then
            _sizew = 37
        ElseIf LabelMin.Width < 185 Then
            _sizew = 38
        ElseIf LabelMin.Width < 189 Then
            _sizew = 39
        ElseIf LabelMin.Width < 194 Then
            _sizew = 40
        ElseIf LabelMin.Width < 199 Then
            _sizew = 41
        ElseIf LabelMin.Width < 203 Then
            _sizew = 42
        ElseIf LabelMin.Width < 208 Then
            _sizew = 43
        ElseIf LabelMin.Width < 213 Then
            _sizew = 44
        ElseIf LabelMin.Width < 218 Then
            _sizew = 45
        ElseIf LabelMin.Width < 222 Then
            _sizew = 46
        ElseIf LabelMin.Width < 227 Then
            _sizew = 47
        Else
            _sizew = 48
        End If
        LabelMin.Font = New Drawing.Font("Arial", Math.Min(_sizew, _sizeh), Drawing.FontStyle.Bold)
    End Sub
    Private Sub TextSizeMax()
        Dim _sizeh As Integer = 14
        Dim _sizew As Integer = 14
        If LabelMax.Height < 23 Then
            _sizeh = 11
        ElseIf LabelMax.Height < 24 Then
            _sizeh = 14
        ElseIf LabelMax.Height < 25 Then
            _sizeh = 15
        ElseIf LabelMax.Height < 29 Then
            _sizeh = 16
        ElseIf LabelMax.Height < 30 Then
            _sizeh = 17
        ElseIf LabelMax.Height < 31 Then
            _sizeh = 18
        ElseIf LabelMax.Height < 33 Then
            _sizeh = 19
        ElseIf LabelMax.Height < 35 Then
            _sizeh = 20
        ElseIf LabelMax.Height < 36 Then
            _sizeh = 21
        ElseIf LabelMax.Height < 38 Then
            _sizeh = 23
        ElseIf LabelMax.Height < 40 Then
            _sizeh = 24
        ElseIf LabelMax.Height < 42 Then
            _sizeh = 25
        ElseIf LabelMax.Height < 44 Then
            _sizeh = 26
        ElseIf LabelMax.Height < 46 Then
            _sizeh = 27
        ElseIf LabelMax.Height < 47 Then
            _sizeh = 28
        ElseIf LabelMax.Height < 48 Then
            _sizeh = 29
        ElseIf LabelMax.Height < 49 Then
            _sizeh = 30
        ElseIf LabelMax.Height < 53 Then
            _sizeh = 31
        ElseIf LabelMax.Height < 54 Then
            _sizeh = 32
        ElseIf LabelMax.Height < 55 Then
            _sizeh = 33
        ElseIf LabelMax.Height < 57 Then
            _sizeh = 34
        ElseIf LabelMax.Height < 59 Then
            _sizeh = 35
        ElseIf LabelMax.Height < 60 Then
            _sizeh = 36
        ElseIf LabelMax.Height < 62 Then
            _sizeh = 37
        ElseIf LabelMax.Height < 64 Then
            _sizeh = 38
        ElseIf LabelMax.Height < 65 Then
            _sizeh = 39
        ElseIf LabelMax.Height < 67 Then
            _sizeh = 40
        ElseIf LabelMax.Height < 68 Then
            _sizeh = 41
        ElseIf LabelMax.Height < 70 Then
            _sizeh = 42
        ElseIf LabelMax.Height < 72 Then
            _sizeh = 43
        ElseIf LabelMax.Height < 73 Then
            _sizeh = 44
        ElseIf LabelMax.Height < 74 Then
            _sizeh = 45
        ElseIf LabelMax.Height < 75 Then
            _sizeh = 46
        ElseIf LabelMax.Height < 77 Then
            _sizeh = 47
        Else
            _sizeh = 48
        End If
        If LabelMax.Width < 70 Then
            _sizew = 11
        ElseIf LabelMax.Width < 72 Then
            _sizew = 14
        ElseIf LabelMax.Width < 76 Then
            _sizew = 15
        ElseIf LabelMax.Width < 82 Then
            _sizew = 16
        ElseIf LabelMax.Width < 85 Then
            _sizew = 17
        ElseIf LabelMax.Width < 90 Then
            _sizew = 18
        ElseIf LabelMax.Width < 95 Then
            _sizew = 19
        ElseIf LabelMax.Width < 100 Then
            _sizew = 20
        ElseIf LabelMax.Width < 105 Then
            _sizew = 21
        ElseIf LabelMax.Width < 109 Then
            _sizew = 22
        ElseIf LabelMax.Width < 114 Then
            _sizew = 23
        ElseIf LabelMax.Width < 120 Then
            _sizew = 24
        ElseIf LabelMax.Width < 125 Then
            _sizew = 25
        ElseIf LabelMax.Width < 128 Then
            _sizew = 26
        ElseIf LabelMax.Width < 133 Then
            _sizew = 27
        ElseIf LabelMax.Width < 137 Then
            _sizew = 28
        ElseIf LabelMax.Width < 142 Then
            _sizew = 29
        ElseIf LabelMax.Width < 148 Then
            _sizew = 30
        ElseIf LabelMax.Width < 152 Then
            _sizew = 31
        ElseIf LabelMax.Width < 157 Then
            _sizew = 32
        ElseIf LabelMax.Width < 162 Then
            _sizew = 33
        ElseIf LabelMax.Width < 167 Then
            _sizew = 34
        ElseIf LabelMax.Width < 170 Then
            _sizew = 35
        ElseIf LabelMax.Width < 175 Then
            _sizew = 36
        ElseIf LabelMax.Width < 180 Then
            _sizew = 37
        ElseIf LabelMax.Width < 185 Then
            _sizew = 38
        ElseIf LabelMax.Width < 189 Then
            _sizew = 39
        ElseIf LabelMax.Width < 194 Then
            _sizew = 40
        ElseIf LabelMax.Width < 199 Then
            _sizew = 41
        ElseIf LabelMax.Width < 203 Then
            _sizew = 42
        ElseIf LabelMax.Width < 208 Then
            _sizew = 43
        ElseIf LabelMax.Width < 213 Then
            _sizew = 44
        ElseIf LabelMax.Width < 218 Then
            _sizew = 45
        ElseIf LabelMax.Width < 222 Then
            _sizew = 46
        ElseIf LabelMax.Width < 227 Then
            _sizew = 47
        Else
            _sizew = 48
        End If
        LabelMax.Font = New Drawing.Font("Arial", Math.Min(_sizew, _sizeh), Drawing.FontStyle.Bold)
    End Sub
    ''' <summary>
    ''' Возвращает и задает подпись значения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name_() As String
        Get
            If LabelName.Text > 1 Then
                Return LabelName.Text.Substring(0, LabelName.Text.Length - 1)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            Try
                If value > 0 Then
                    LabelName.Text = value & ":"
                Else
                    LabelName.Text = ""
                End If
            Catch ex As Exception
                LabelName.Text = ""
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Возвращает и задает ед.изм.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EI() As String
        Get
            Return LabelEI.Text
        End Get
        Set(ByVal value As String)
            If value = Nothing Then
                LabelEI.Text = ""
            Else
                LabelEI.Text = value
            End If
        End Set
    End Property

    Private Sub ValSetting_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If _type <> ValueType.count _
        And _type <> ValueType.text _
        And _type <> ValueType.bool Then
            PanelMin.Width = Math.Floor((Me.Width - LabelPoint.Width) / 2)
            PanelMax.Width = Math.Floor((Me.Width - LabelPoint.Width) / 2)
        ElseIf _type = ValueType.bool Then
            PictureBoxBool.Location = New Drawing.Point((Me.Width - PictureBoxBool.Width) / 2, 25)
        End If
    End Sub

    Private Sub PictureBoxBool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxBool.Click
        _valueB = Not _valueB
        PictureBoxBool.Image = If(_valueB, _
                                  My.Resources.ResourceBMP.истина, _
                                  My.Resources.ResourceBMP.ложь)
    End Sub
End Class
