Public Module DialogForms

    ''' <summary>
    ''' Тип отображаемого окна
    ''' </summary>
    ''' <remarks></remarks>
    Enum MsgType
        message
        warning
        except
    End Enum
    ''' <summary>
    ''' Вызывает окно сообщения
    ''' </summary>
    ''' <param name="text">текст сообщения</param>
    ''' <param name="head">заголовок формы</param>
    ''' <param name="status">тип сообщения (влияет на картинку)</param>
    ''' <param name="buttonCancel">отображать кнопку cancel?</param>
    ''' <returns>OK - true | CANCEL - false</returns>
    ''' <remarks></remarks>
#Region "message"

    Public Function Message(ByRef text As String, _
                            Optional ByRef head As String = "Сообщение", _
                            Optional ByRef status As MsgType = MsgType.message, _
                            Optional ByRef buttonCancel As Boolean = False) As Boolean
        Using f = New MessageForm(text, head, status, buttonCancel)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then Return True
        End Using
        Return False
    End Function

#End Region

    ''' <summary>
    ''' Тип переменной
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ValueType
        text
        uint
        int
        ureal
        real
        bool
    End Enum
    ''' <summary>
    ''' открывает форму со списком значений и возвращает список измененных значений
    ''' </summary>
    ''' <param name="values">значения</param>
    ''' <param name="names">названия значений</param>
    ''' <param name="types">типы значений</param>
    ''' <param name="head">заголовок формы</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
#Region "setting"

    Public Function Setting(ByRef values As String(), _
                            ByRef names As String(), _
                            ByVal types As ValueType(), _
                            Optional ByVal head As String = "Параметры") As String()
        Using f = New SettingForm(values, names, types, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As String(), _
                            ByRef names As String(), _
                            Optional ByVal head As String = "Параметры") As String()
        Using f = New SettingForm(values, names, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As String(), _
                   Optional ByVal head As String = "Параметры") As String()
        Using f = New SettingForm(values, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As String, _
                            ByRef names As String, _
                            Optional ByVal head As String = "Параметры") As String
        Using f = New SettingForm(values, names, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Integer(), _
                            ByRef names As String(), _
                            ByVal types As ValueType(), _
                            Optional ByVal head As String = "Параметры") As Integer()
        Using f = New SettingForm(values, names, types, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Integer(), _
                            ByRef names As String(), _
                            Optional ByVal head As String = "Параметры") As Integer()
        Using f = New SettingForm(values, names, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Integer, _
                            ByRef names As String, _
                            ByVal types As ValueType, _
                            Optional ByVal head As String = "Параметры") As Integer
        Using f = New SettingForm(values, names, types, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Integer, _
                            ByRef names As String, _
                            Optional ByVal head As String = "Параметры") As Integer
        Using f = New SettingForm(values, names, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Double(), _
                            ByRef names As String(), _
                            ByVal types As ValueType(), _
                            Optional ByVal head As String = "Параметры") As Double()
        Using f = New SettingForm(values, names, types, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Double(), _
                            ByRef names As String(), _
                            Optional ByVal head As String = "Параметры") As Double()
        Using f = New SettingForm(values, names, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Double, _
                            ByRef names As String, _
                            ByVal types As ValueType, _
                            Optional ByVal head As String = "Параметры") As Double
        Using f = New SettingForm(values, names, types, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Double, _
                            ByRef names As String, _
                            Optional ByVal head As String = "Параметры") As Double
        Using f = New SettingForm(values, names, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Boolean(), _
                            ByRef names As String(), _
                            Optional ByVal head As String = "Параметры") As Boolean()
        Using f = New SettingForm(values, names, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Boolean(), _
                            Optional ByVal head As String = "Параметры") As Boolean()
        Using f = New SettingForm(values, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Boolean, _
                            Optional ByRef names As String = "", _
                            Optional ByVal head As String = "Параметры") As Boolean
        Using f = New SettingForm(values, names, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Collection, _
                            ByRef names As String(), _
                            ByVal types As ValueType(), _
                            Optional ByVal head As String = "Параметры") As Collection
        Using f = New SettingForm(values, names, types, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Collection, _
                            ByRef names As String(), _
                            Optional ByVal head As String = "Параметры") As Collection
        Using f = New SettingForm(values, names, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Collection, _
                            Optional ByVal head As String = "Параметры") As Collection
        Using f = New SettingForm(values, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As Collection, _
                            ByRef names As String, _
                            ByVal types As ValueType, _
                            Optional ByVal head As String = "Параметры") As Collection
        Using f = New SettingForm(values, names, types, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As ArrayList, _
                            ByRef names As String(), _
                            ByVal types As ValueType(), _
                            Optional ByVal head As String = "Параметры") As ArrayList
        Using f = New SettingForm(values, names, types, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As ArrayList, _
                            ByRef names As String(), _
                            Optional ByVal head As String = "Параметры") As ArrayList
        Using f = New SettingForm(values, names, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As ArrayList, _
                            Optional ByVal head As String = "Параметры") As ArrayList
        Using f = New SettingForm(values, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

    Public Function Setting(ByRef values As ArrayList, _
                            ByRef names As String, _
                            ByVal types As ValueType, _
                            Optional ByVal head As String = "Параметры") As ArrayList
        Using f = New SettingForm(values, names, types, head)
            f.ShowDialog()
            Setting = f.result
        End Using
    End Function

#End Region

    ''' <summary>
    ''' вызывает окно отображения протокола
    ''' </summary>
    ''' <param name="protocol">протокол</param>
    ''' <param name="head">заголовок формы</param>
    ''' <returns>OK - true | CANCEL - false</returns>
    ''' <remarks></remarks>
#Region "report"

    Public Function Report(ByRef protocol As Report, _
                             Optional ByVal head As String = "Протокол") As Boolean
        Using f = New ReportForm(protocol, head)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then Return True
        End Using
        Return False
    End Function

#End Region

    ''' <summary>
    ''' открывает форму со списком значений и возвращает выбранное значение
    ''' </summary>
    ''' <param name="collection">список</param>
    ''' <param name="head">заголовок</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
#Region "selection"

    Public Function Selection(ByRef collection As ArrayList, _
                              Optional ByVal head As String = "Выберите из списка") As Object
        Using f = New SelectForm(collection, head)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then Return f.result
        End Using
        Return Nothing
    End Function

    Public Function Selection(ByRef collection As Collection, _
                              Optional ByVal head As String = "Выберите из списка") As Object
        Using f = New SelectForm(collection, head)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then Return f.result
        End Using
        Return Nothing
    End Function

    Public Function Selection(ByRef collection As String(), _
                              Optional ByVal head As String = "Выберите из списка") As String
        Using f = New SelectForm(collection, head)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then Return f.result
        End Using
        Return Nothing
    End Function

    Public Function Selection(ByRef collection As String, _
                              Optional ByVal head As String = "Выберите из списка") As String
        Using f = New SelectForm(collection, head)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then Return f.result
        End Using
        Return Nothing
    End Function

    Public Function Selection(ByRef collection As Integer(), _
                              Optional ByVal head As String = "Выберите из списка") As Integer
        Using f = New SelectForm(collection, head)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then Return f.result
        End Using
        Return Nothing
    End Function

    Public Function Selection(ByRef collection As Integer, _
                              Optional ByVal head As String = "Выберите из списка") As Integer
        Using f = New SelectForm(collection, head)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then Return f.result
        End Using
        Return Nothing
    End Function

    Public Function Selection(ByRef collection As Double(), _
                              Optional ByVal head As String = "Выберите из списка") As Double
        Using f = New SelectForm(collection, head)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then Return f.result
        End Using
        Return Nothing
    End Function

    Public Function Selection(ByRef collection As Double, _
                              Optional ByVal head As String = "Выберите из списка") As Double
        Using f = New SelectForm(collection, head)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then Return f.result
        End Using
        Return Nothing
    End Function

#End Region

    ''' <summary>
    ''' Тип ответа от Correct()
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum resultOfCorrect
        OK
        Cancel
        Add
        Del
        Correct
    End Enum

    ''' <summary>
    ''' формат ответа "Correct()"
    ''' FormResult - ответ формы (соодветствует определенному действию)
    ''' Elem - элемент над которым необходимо произвести манипуляции
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure CorrectAnswer
        Dim FormResult As resultOfCorrect
        Dim Elem As Object
    End Structure

    ''' <summary>
    ''' возвращает элемент которую необходимо изменить
    ''' OK - сохранить изменения
    ''' Cancel - отменить изменения
    ''' Add - добавить элемент
    ''' Del - удалить элемент
    ''' Correct - изменить элемент
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="head"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
#Region "correct"

    Public Function Correct(ByRef collection As ArrayList, _
                              Optional ByVal head As String = "Выберите из списка", _
                              Optional ByVal canAdd As Boolean = True, _
                              Optional ByVal lastPage As Boolean = False) As CorrectAnswer
        Using f = New SelectForm(collection, head, True, lastPage)
            If Not canAdd Then f.PictureBoxAdd.Image = My.Resources.ResourceBMP.addDisabled
            Select Case f.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    Correct.FormResult = resultOfCorrect.OK
                Case Windows.Forms.DialogResult.Yes
                    Correct.FormResult = resultOfCorrect.Correct
                Case Windows.Forms.DialogResult.Retry
                    Correct.FormResult = resultOfCorrect.Add
                Case Windows.Forms.DialogResult.No
                    Correct.FormResult = resultOfCorrect.Del
                Case Else
                    Correct.FormResult = resultOfCorrect.Cancel
            End Select
            Correct.Elem = f.result
            Return Correct
        End Using
        Return Nothing
    End Function

    Public Function Correct(ByRef collection As Collection, _
                              Optional ByVal head As String = "Выберите из списка", _
                              Optional ByVal canAdd As Boolean = True, _
                              Optional ByVal lastPage As Boolean = False) As CorrectAnswer
        Using f = New SelectForm(collection, head, True, lastPage)
            If Not canAdd Then f.PictureBoxAdd.Image = My.Resources.ResourceBMP.addDisabled
            Select Case f.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    Correct.FormResult = resultOfCorrect.OK
                Case Windows.Forms.DialogResult.Yes
                    Correct.FormResult = resultOfCorrect.Correct
                Case Windows.Forms.DialogResult.Retry
                    Correct.FormResult = resultOfCorrect.Add
                Case Windows.Forms.DialogResult.No
                    Correct.FormResult = resultOfCorrect.Del
                Case Else
                    Correct.FormResult = resultOfCorrect.Cancel
            End Select
            Correct.Elem = f.result
            Return Correct
        End Using
        Return Nothing
    End Function

    Public Function Correct(ByRef collection As String(), _
                              Optional ByVal head As String = "Выберите из списка", _
                              Optional ByVal canAdd As Boolean = True, _
                              Optional ByVal lastPage As Boolean = False) As CorrectAnswer
        Using f = New SelectForm(collection, head, True, lastPage)
            If Not canAdd Then f.PictureBoxAdd.Image = My.Resources.ResourceBMP.addDisabled
            Select Case f.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    Correct.FormResult = resultOfCorrect.OK
                Case Windows.Forms.DialogResult.Yes
                    Correct.FormResult = resultOfCorrect.Correct
                Case Windows.Forms.DialogResult.Retry
                    Correct.FormResult = resultOfCorrect.Add
                Case Windows.Forms.DialogResult.No
                    Correct.FormResult = resultOfCorrect.Del
                Case Else
                    Correct.FormResult = resultOfCorrect.Cancel
            End Select
            Correct.Elem = f.result
            Return Correct
        End Using
        Return Nothing
    End Function

    Public Function Correct(ByRef collection As String, _
                              Optional ByVal head As String = "Выберите из списка", _
                              Optional ByVal canAdd As Boolean = True, _
                              Optional ByVal lastPage As Boolean = False) As CorrectAnswer
        Using f = New SelectForm(collection, head, True, lastPage)
            If Not canAdd Then f.PictureBoxAdd.Image = My.Resources.ResourceBMP.addDisabled
            Select Case f.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    Correct.FormResult = resultOfCorrect.OK
                Case Windows.Forms.DialogResult.Yes
                    Correct.FormResult = resultOfCorrect.Correct
                Case Windows.Forms.DialogResult.Retry
                    Correct.FormResult = resultOfCorrect.Add
                Case Windows.Forms.DialogResult.No
                    Correct.FormResult = resultOfCorrect.Del
                Case Else
                    Correct.FormResult = resultOfCorrect.Cancel
            End Select
            Correct.Elem = f.result
            Return Correct
        End Using
        Return Nothing
    End Function

    Public Function Correct(ByRef collection As Integer(), _
                              Optional ByVal head As String = "Выберите из списка", _
                              Optional ByVal canAdd As Boolean = True, _
                              Optional ByVal lastPage As Boolean = False) As CorrectAnswer
        Using f = New SelectForm(collection, head, True, lastPage)
            If Not canAdd Then f.PictureBoxAdd.Image = My.Resources.ResourceBMP.addDisabled
            Select Case f.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    Correct.FormResult = resultOfCorrect.OK
                Case Windows.Forms.DialogResult.Yes
                    Correct.FormResult = resultOfCorrect.Correct
                Case Windows.Forms.DialogResult.Retry
                    Correct.FormResult = resultOfCorrect.Add
                Case Windows.Forms.DialogResult.No
                    Correct.FormResult = resultOfCorrect.Del
                Case Else
                    Correct.FormResult = resultOfCorrect.Cancel
            End Select
            Correct.Elem = f.result
            Return Correct
        End Using
        Return Nothing
    End Function

    Public Function Correct(ByRef collection As Integer, _
                              Optional ByVal head As String = "Выберите из списка", _
                              Optional ByVal canAdd As Boolean = True, _
                              Optional ByVal lastPage As Boolean = False) As CorrectAnswer
        Using f = New SelectForm(collection, head, True, lastPage)
            If Not canAdd Then f.PictureBoxAdd.Image = My.Resources.ResourceBMP.addDisabled
            Select Case f.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    Correct.FormResult = resultOfCorrect.OK
                Case Windows.Forms.DialogResult.Yes
                    Correct.FormResult = resultOfCorrect.Correct
                Case Windows.Forms.DialogResult.Retry
                    Correct.FormResult = resultOfCorrect.Add
                Case Windows.Forms.DialogResult.No
                    Correct.FormResult = resultOfCorrect.Del
                Case Else
                    Correct.FormResult = resultOfCorrect.Cancel
            End Select
            Correct.Elem = f.result
            Return Correct
        End Using
        Return Nothing
    End Function

    Public Function Correct(ByRef collection As Double(), _
                              Optional ByVal head As String = "Выберите из списка", _
                              Optional ByVal canAdd As Boolean = True, _
                              Optional ByVal lastPage As Boolean = False) As CorrectAnswer
        Using f = New SelectForm(collection, head, True, lastPage)
            If Not canAdd Then f.PictureBoxAdd.Image = My.Resources.ResourceBMP.addDisabled
            Select Case f.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    Correct.FormResult = resultOfCorrect.OK
                Case Windows.Forms.DialogResult.Yes
                    Correct.FormResult = resultOfCorrect.Correct
                Case Windows.Forms.DialogResult.Retry
                    Correct.FormResult = resultOfCorrect.Add
                Case Windows.Forms.DialogResult.No
                    Correct.FormResult = resultOfCorrect.Del
                Case Else
                    Correct.FormResult = resultOfCorrect.Cancel
            End Select
            Correct.Elem = f.result
            Return Correct
        End Using
        Return Nothing
    End Function

    Public Function Correct(ByRef collection As Double, _
                              Optional ByVal head As String = "Выберите из списка", _
                              Optional ByVal canAdd As Boolean = True, _
                              Optional ByVal lastPage As Boolean = False) As CorrectAnswer
        Using f = New SelectForm(collection, head, True, lastPage)
            If Not canAdd Then f.PictureBoxAdd.Image = My.Resources.ResourceBMP.addDisabled
            Select Case f.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    Correct.FormResult = resultOfCorrect.OK
                Case Windows.Forms.DialogResult.Yes
                    Correct.FormResult = resultOfCorrect.Correct
                Case Windows.Forms.DialogResult.Retry
                    Correct.FormResult = resultOfCorrect.Add
                Case Windows.Forms.DialogResult.No
                    Correct.FormResult = resultOfCorrect.Del
                Case Else
                    Correct.FormResult = resultOfCorrect.Cancel
            End Select
            Correct.Elem = f.result
            Return Correct
        End Using
        Return Nothing
    End Function

#End Region

#Region "Filter"

    Public Function FilterReport(ByVal file As Ini, _
                                 ByVal users As Collection, _
                                 ByVal names As Collection, _
                                 Optional ByVal head As String = "Фильтр", _
                                 Optional ByVal name As String = "Name", _
                                 Optional ByVal user As String = "User", _
                                 Optional ByVal time As String = "Time", _
                                 Optional ByVal text As String = "заголовок") As Dictionary(Of String, String)
        Dim _users(users.Count - 1) As String
        For i As Integer = 0 To users.Count - 1
            _users(i) = users(i + 1).ToString.ToString()
        Next
        Dim _names(users.Count - 1) As String
        For i As Integer = 0 To names.Count - 1
            _names(i) = names(i + 1).ToString.ToString()
        Next
        Using f = New FilterForm(file, _users, _names, head, name, user, time, text)
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                Return f.result
            Else
                Return New Dictionary(Of String, String)
            End If
        End Using
    End Function

#End Region

#Region "SaveAs"
    Public Function SaveAs(ByVal name As String, _
                            ByVal format As String, _
                            ByVal startPath As String, _
                            ByVal notUsePaths() As String, _
                            ByVal createName As Boolean) As String
        SaveAs = ""
        Dim dir = New IO.DirectoryInfo(startPath)
        Dim p = dir.GetDirectories
        Dim sp As ArrayList = New ArrayList
        For Each f In p
            If Not notUsePaths.Contains(startPath & f.Name) Then sp.Add(f.Name)
        Next
        Using f = New SelectForm(sp, startPath, True)
            f.PictureBoxAdd.Visible = False
            f.PictureBoxDel.Visible = False
            Select Case f.ShowDialog
                Case Windows.Forms.DialogResult.OK
                    If createName Then Keyboard.Text(name, "Название файла")
                    Return startPath & name & format
                Case Windows.Forms.DialogResult.Yes
                    Return SaveAs(name, format, startPath & f.result & "/", notUsePaths, createName)
                Case Windows.Forms.DialogResult.Cancel
                    Return ""
            End Select
        End Using
    End Function
#End Region

#Region "wait"

    Private WaitFormThread As Threading.Thread
    Private Sub WaitFormShow()
        Dim f = New WaitForm
        f.ShowDialog()
    End Sub

    Public Sub WaitFormStart()
        WaitFormThread = New Threading.Thread(New Threading.ThreadStart(AddressOf WaitFormShow))
        WaitFormThread.Start()
    End Sub

    Public Sub WaitFormStop()
        WaitFormThread.Abort()
    End Sub

#End Region

End Module
