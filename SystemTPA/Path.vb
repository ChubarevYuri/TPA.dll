Public Module Path
    ''' <summary>
    ''' Определение расположения программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property BasePath() As String
        Get
            BasePath = ""
            Dim folders() As String = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase).Split("\")
            For i As Integer = 0 To folders.Length - 2
                BasePath &= folders(i) & "\"
            Next
        End Get
    End Property
End Module
