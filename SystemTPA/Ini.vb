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
