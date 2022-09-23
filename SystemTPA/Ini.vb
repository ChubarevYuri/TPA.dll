Public Class Ini
    Private ReadOnly filePath As String = BasePath & "property\"
    Private fileName As String
    Private fileAddress As String
    Private Const objStart As Char = "<"
    Private Const objEnd As Char = ">"
    Private Const charSplit As Char = "="

    Public Sub New()
        fileName = "setting.ini"
        fileAddress = filePath & fileName
    End Sub
    Public Sub New(ByVal name As String)
        fileName = name & ".ini"
        fileAddress = filePath & fileName
    End Sub
    Public Sub New(ByVal path As String, ByVal name As String)
        Dim res = ""
        For Each ch In path
            If Not (ch = "\" And _
                    ch = "|" And _
                    ch = "#" And _
                    ch = "<" And _
                    ch = ">" And _
                    ch = "=" And _
                    ch = ":" And _
                    ch = "?" And _
                    ch = Chr(10) And _
                    ch = Chr(13)) Then res &= ch
            If ch = "/" Then res &= "\"
        Next
        res = res.Trim("\")
        res &= "\"
        filePath = res
        fileName = name & ".ini"
        fileAddress = filePath & fileName
    End Sub

    ''' <summary>
    ''' Фильтр списка протоколов по принципу: (if name>0 then name = Name), (if user>0 then user = User), DateStart ≤ Date ≤ dateStop
    ''' </summary>
    ''' <param name="user">фильтр по пользователю</param>
    ''' <param name="name">фильтр по устройству</param>
    ''' <param name="DateStart">фильтр по дате</param>
    ''' <param name="dateStop">фильтр по дате</param>
    ''' <param name="_name">подпись пользователя</param>
    ''' <param name="_user">подпись устройства</param>
    ''' <param name="_date">подпись </param>
    ''' <param name="_text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadReportsFilter(ByVal user As String, _
                                      ByVal name As String, _
                                      ByVal num As String, _
                                      ByVal DateStart As DateTime, _
                                      ByVal dateStop As DateTime, _
                                      Optional ByVal _name As String = "Name", _
                                      Optional ByVal _num As String = "Num", _
                                      Optional ByVal _user As String = "User", _
                                      Optional ByVal _date As String = "Time", _
                                      Optional ByVal _text As String = "заголовок") As Dictionary(Of String, String)
        ReadReportsFilter = New Dictionary(Of String, String)
        Dim line As KeyValuePair(Of String, String)
        CreateFile()
        Dim f = New System.IO.StreamReader(fileAddress)
        Try
            Do While f.Peek() >= 0
                Dim s = f.ReadLine
                If s.Length > 0 Then
                    If s(0) = objStart Then
                        Dim readText As Boolean = If(_text.Length = 0, True, False)
                        Dim readUser As Boolean = If(user.Length = 0 Or _user.Length = 0, True, False)
                        Dim readName As Boolean = If(name.Length = 0 Or _name.Length = 0, True, False)
                        Dim readNum As Boolean = If(num.Length = 0 Or _num.Length = 0, True, False)
                        Dim readDate As Boolean = If(_date.Length = 0, True, False)
                        Dim filter As Boolean = True
                        Dim key = s.Substring(1)
                        If _text.Length = 0 Then line = New KeyValuePair(Of String, String)(key, key)
                        Do While f.Peek() >= 0 And s <> objEnd And filter
                            s = f.ReadLine
                            Try
                                If Not readText Then
                                    If Split(s, charSplit, 2)(0) = _text Then
                                        line = New KeyValuePair(Of String, String)(key, Split(s, charSplit, 2)(1))
                                        readText = True
                                    End If
                                End If
                                If Not readUser Then
                                    If Split(s, charSplit, 2)(0) = _user Then
                                        If Split(s, charSplit, 2)(1).ToUpper().Contains(user.ToUpper()) Then
                                            filter = filter And True
                                        Else
                                            filter = False
                                        End If
                                        readUser = True
                                    End If
                                End If
                                If Not readName Then
                                    If Split(s, charSplit, 2)(0) = _name Then
                                        If Split(s, charSplit, 2)(1).ToUpper().Contains(name.ToUpper()) Then
                                            filter = filter And True
                                        Else
                                            filter = False
                                        End If
                                        readName = True
                                    End If
                                End If
                                If Not readNum Then
                                    If Split(s, charSplit, 2)(0) = _num Then
                                        If Split(s, charSplit, 2)(1).ToUpper().Contains(num.ToUpper()) Then
                                            filter = filter And True
                                        Else
                                            filter = False
                                        End If
                                        readNum = True
                                    End If
                                End If
                                If Not readDate Then
                                    If Split(s, charSplit, 2)(0) = _date Then
                                        Try
                                            If DateStart <= Convert.ToDateTime(Split(s, charSplit, 2)(1)) And Convert.ToDateTime(Split(s, charSplit, 2)(1)) <= dateStop Then
                                                filter = filter And True
                                            Else
                                                filter = False
                                            End If
                                        Catch ex As Exception
                                            filter = False
                                        End Try
                                        readDate = True
                                    End If
                                End If
                                If (readText Or Not filter) And readUser And readName And readNum And readDate Then
                                    If filter Then ReadReportsFilter.Add(line.Key, line.Value)
                                    Do While f.Peek() >= 0 And s <> objEnd
                                        s = f.ReadLine
                                    Loop
                                End If
                            Catch ex As Exception
                            End Try
                        Loop
                    End If
                End If
            Loop
        Catch ex As Exception
        End Try
        f.Close()
    End Function

    ''' <summary>
    ''' Возврат значения типа (obj, value)
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadByParam(ByVal param As String) As Dictionary(Of String, String)
        ReadByParam = New Dictionary(Of String, String)
        CreateFile()
        Dim f = New System.IO.StreamReader(fileAddress)
        Try
            Do While f.Peek() >= 0
                Dim s = f.ReadLine
                If s.Length > 0 Then
                    If s(0) = objStart Then
                        Dim key = s.Substring(1)
                        Do While f.Peek() >= 0 And s <> objEnd
                            s = f.ReadLine
                            Try
                                If Split(s, charSplit, 2)(0) = param Then
                                    ReadByParam.Add(key, Split(s, charSplit, 2)(1))
                                    Do While f.Peek() >= 0 And s <> objEnd
                                        s = f.ReadLine
                                    Loop
                                End If
                            Catch ex As Exception
                            End Try
                        Loop
                    End If
                End If
            Loop
        Catch ex As Exception
        End Try
        f.Close()
    End Function

    ''' <summary>
    ''' Поиск val в файле формата:
    ''' obj
    ''' param=val
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="param"></param>
    ''' <returns>val</returns>
    ''' <remarks></remarks>
    Public Function Read(ByVal obj As String, _
                         ByVal param As String) _
                         As String
        Read = ""
        CreateFile()
        Dim f = New System.IO.StreamReader(fileAddress)
        Try
            Do While f.Peek() >= 0
                Dim s = f.ReadLine
                If s.Length > 0 Then
                    If s(0) = objStart And s.Substring(1) = obj Then
                        Do While f.Peek() >= 0 And s <> objEnd
                            s = f.ReadLine
                            Try
                                If Split(s, charSplit, 2)(0) = param Then
                                    f.Close()
                                    Return Split(s, charSplit, 2)(1)
                                End If
                            Catch ex As Exception
                            End Try
                        Loop
                    End If
                End If
            Loop
        Catch ex As Exception
        End Try
        f.Close()
    End Function
    ''' <summary>
    ''' Поиск всех объектов
    ''' </summary>
    ''' <returns>obj()</returns>
    ''' <remarks></remarks>
    Public Function Read() As Collection
        Read = New Collection
        CreateFile()
        Dim f = New System.IO.StreamReader(fileAddress)
        Try
            Do While f.Peek() >= 0
                Dim s = f.ReadLine
                If s.Length > 0 Then
                    If s(0) = objStart Then
                        Read.Add(s.TrimStart(objStart))
                    End If
                End If
            Loop
        Catch ex As Exception
        End Try
        f.Close()
    End Function
    ''' <summary>
    ''' считывание параметров объекта
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Read(ByRef obj As String) As Dictionary(Of String, String)
        Read = New Dictionary(Of String, String)
        CreateFile()
        Dim f = New System.IO.StreamReader(fileAddress)
        Try
            Do While f.Peek() >= 0
                Dim s = f.ReadLine
                If s.Length > 0 Then
                    If s(0) = objStart And s.Substring(1) = obj Then
                        Do While f.Peek() >= 0 And s <> objEnd
                            s = f.ReadLine
                            Try
                                Read.Add(Split(s, charSplit, 2)(0), Split(s, charSplit, 2)(1))
                            Catch ex As Exception
                            End Try
                        Loop
                        f.Close()
                        Return Read
                    End If
                End If
            Loop
        Catch ex As Exception
        End Try
        f.Close()
    End Function

    ''' <summary>
    ''' проверка наличия объекта в файле
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObjectInFile(ByRef obj As String) As Boolean
        ObjectInFile = False
        For Each i In Read()
            If i = obj Then ObjectInFile = True
        Next
    End Function

    Private Function ReadFile() As Dictionary(Of String, Dictionary(Of String, String))
        ReadFile = New Dictionary(Of String, Dictionary(Of String, String))
        CreateFile()
        Dim f = New System.IO.StreamReader(fileAddress)
        Dim key As String
        Do While f.Peek() >= 0
            Dim s = f.ReadLine
            If s.Length > 0 Then
                If s(0) = objStart Then
                    key = s.TrimStart(objStart)
                    Dim val = New Dictionary(Of String, String)
                    s = f.ReadLine
                    Do While f.Peek() >= 0 And s <> objEnd
                        Try
                            val.Add(Split(s, charSplit, 2)(0), Split(s, charSplit, 2)(1))
                        Catch ex As Exception
                        End Try
                        s = f.ReadLine
                    Loop
                    ReadFile.Add(key, val)
                End If
            End If
        Loop
        f.Close()
    End Function

    Private Function WriteFile(ByRef val As Dictionary(Of String, Dictionary(Of String, String))) As Integer
        Try
            CreateFile()
            Using f = New System.IO.StreamWriter(fileAddress, False)
                For Each i In val
                    f.WriteLine(ObjToString(i.Key, i.Value))
                Next
            End Using
            Return 0
        Catch ex As Exception
            Return 1
        End Try
    End Function
    Private Function WriteFile(ByRef key As String, ByRef params As Dictionary(Of String, String)) As Integer
        Try
            CreateFile()
            Using f = New System.IO.StreamWriter(fileAddress, True)
                f.WriteLine(ObjToString(key, params))
            End Using
            Return 0
        Catch ex As Exception
            Return 1
        End Try
    End Function

    ''' <summary>
    ''' Удаление объекта
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub Delete(ByVal obj As String)
        If ObjectInFile(obj) Then
            Dim res As Integer = 0
            Do
                res = _Delete(res, obj)
            Loop While res > 0 And res < 5
        End If
    End Sub

    Private Function _Delete(ByVal num As Integer, ByVal obj As String) As String
        Try
            CreateFile()
            Dim fr = New System.IO.StreamReader(fileAddress)
            Dim fw = New System.IO.StreamWriter(BasePath & "~ini")
            Do While fr.Peek() >= 0
                Dim s = fr.ReadLine
                If s.Length > 0 Then
                    If s(0) = objStart And s.Substring(1) = obj Then
                        Do While fr.Peek() >= 0 And s <> objEnd
                            s = fr.ReadLine
                        Loop
                        If s = objEnd Then s = fr.ReadLine
                    End If
                    fw.WriteLine(s)
                End If
            Loop
            fr.Close()
            fw.Close()

            fr = New System.IO.StreamReader(BasePath & "~ini")
            fw = New System.IO.StreamWriter(fileAddress)
            Do While fr.Peek() >= 0
                fw.WriteLine(fr.ReadLine)
            Loop
            fr.Close()
            fw.Close()
            Dim f = New System.IO.FileInfo(BasePath & "~ini")
            f.Delete()
            _Delete = 0
        Catch ex As Exception
            _Delete = num + 1
        End Try
    End Function

    Private Sub CreateFile()
        If Not System.IO.Directory.Exists(filePath) Then
            System.IO.Directory.CreateDirectory(filePath)
        End If
        If Not System.IO.File.Exists(fileAddress) Then
            Using f = New System.IO.StreamWriter(fileAddress)
                f.Write("")
            End Using
        End If
    End Sub


    ''' <summary>
    ''' преобразуем объект в строку
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="params"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ObjToString(ByRef key As String, _
                                 ByRef params As Dictionary(Of String, String)) _
                                 As String
        ObjToString = objStart & key & Chr(13)
        For Each par In params
            ObjToString &= par.Key & charSplit & par.Value & Chr(13)
        Next
        ObjToString &= objEnd
    End Function

    ''' <summary>
    ''' Добавление обекта
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="params"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Write(ByRef obj As String, _
                          ByRef params As Dictionary(Of String, String)) _
                          As Integer
        Try
            CreateFile()
            Delete(obj)
            Using f = New System.IO.StreamWriter(fileAddress, True)
                f.WriteLine(ObjToString(obj, params))
            End Using
            Return 0
        Catch ex As Exception
            Return 3
        End Try
    End Function
    ''' <summary>
    ''' Замена значения
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="param"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Write(ByVal obj As String, _
                          ByVal param As String, _
                          ByVal value As String) _
                          As Integer
        Try
            Dim params As Dictionary(Of String, String) = Read(obj)
            params.Item(param) = value
            Return Write(obj, params)
        Catch ex As Exception
            Return 2
        End Try
    End Function
End Class
