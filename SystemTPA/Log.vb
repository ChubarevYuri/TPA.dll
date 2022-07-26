Public Module Log
    Private _fileName As String = DateAndTime.Now.ToString("yyyyMMddHHmmss")
    ''' <summary>
    ''' имя файла
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property fileName() As String
        Get
            Return _fileName
        End Get
        Set(ByVal value As String)
            Dim res As String = ""
            For Each ch In value
                If Not (ch = "\" And _
                        ch = "/" And _
                        ch = "|" And _
                        ch = "#" And _
                        ch = "<" And _
                        ch = ">" And _
                        ch = "=" And _
                        ch = ":" And _
                        ch = "?" And _
                        ch = Chr(10) And _
                        ch = Chr(13)) Then res &= ch
            Next
            If res.EndsWith(".log") Then
                _fileName = res.Substring(0, res.Length - 4)
            Else
                _fileName = res
            End If
            fileAddress = _filePath & _fileName & ".log"
        End Set
    End Property
    Private _filePath As String = BasePath & "log\"
    ''' <summary>
    ''' относительный путь к файлу
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property filePath() As String
        Get
            Return _filePath
        End Get
        Set(ByVal value As String)
            Dim res = ""
            For Each ch In value
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
            _filePath = res
            fileAddress = _filePath & _fileName & ".log"
        End Set
    End Property
    Private fileAddress As String = _filePath & _fileName & ".log"
    Public printRank As Rank = Rank.OK
    Private countname As UInt16 = 0

    Public Enum Rank
        DEBUG
        OK
        MESSAGE
        WARNING
        EXCEPT
    End Enum

    ''' <summary>
    ''' запись строки в файл
    ''' </summary>
    ''' <param name="rank"></param>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub Print(ByVal rank As Rank, _
                     ByVal message As String)
        If Not System.IO.Directory.Exists(filePath) Then
            System.IO.Directory.CreateDirectory(filePath)
        End If
        DeleteOldFiles()
        If rank >= printRank Then
            SizeControl()
            Dim text As String = rank.ToString().PadRight(8) & DateAndTime.Now.ToString("yyyyMMddHHmmss") & " " & message
            Using f As New System.IO.StreamWriter(fileAddress, True)
                Try
                    f.WriteLine(text)
                    f.Close()
                Catch ex As Exception
                End Try
            End Using
        End If
    End Sub
    ''' <summary>
    ''' Удаление файлов старше месяца
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteOldFiles()
        If Not System.IO.Directory.Exists(filePath) Then
            System.IO.Directory.CreateDirectory(filePath)
        End If
        Try
            Dim di = New IO.DirectoryInfo(filePath)
            For Each dra As IO.FileInfo In di.GetFiles()
                If dra.LastWriteTime.Month < (Now.Month - 1) Or _
                  (dra.LastWriteTime.Month < (Now.Month) And dra.LastWriteTime.Day < (Now.Day)) Then
                    dra.Delete()
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Если файл превышает 1МБ, то создаем новый
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SizeControl()
        If Not System.IO.Directory.Exists(filePath) Then
            System.IO.Directory.CreateDirectory(filePath)
        End If
        Try
            If IO.File.Exists(fileAddress) Then
                Dim f = New IO.FileInfo(fileAddress)
                If f.Length > 1024 * 1024 Then
                    countname += 1
                    fileName &= "_" & countname
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

End Module