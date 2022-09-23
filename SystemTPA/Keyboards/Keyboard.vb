Public Module Keyboard

    Public Sub Password(ByRef value As String, Optional ByVal useEng As Boolean = False)
        value = ""
        Using f = New KeyboardTextForm()
            If Not useEng Then
                f.language = 3
                f.ButtonLangL.Visible = False
                f.ButtonLangR.Visible = False
            End If
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then value = f.result
        End Using
    End Sub

    Public Sub Text(ByRef value As String, Optional ByRef head As String = "", Optional ByVal useEng As Boolean = False)
        Using f = New KeyboardTextForm(value, head)
            If Not useEng Then
                f.language = 3
                f.ButtonLangL.Visible = False
                f.ButtonLangR.Visible = False
            End If
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then value = f.result
        End Using
    End Sub

    Public Sub Int(ByRef value As String, Optional ByRef head As String = "")
        Using f = New KeyboardIntegerForm(value, head)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then value = f.result
        End Using
    End Sub

    Public Sub UInt(ByRef value As String, Optional ByRef head As String = "")
        Using f = New KeyboardUIntegerForm(value, head)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then value = f.result
        End Using
    End Sub

    Public Sub Real(ByRef value As String, Optional ByRef head As String = "")
        Using f = New KeyboardDoubleForm(value, head)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then value = f.result
        End Using
    End Sub

    Public Sub UReal(ByRef value As String, Optional ByRef head As String = "")
        Using f = New KeyboardUDoubleForm(value, head)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then value = f.result
        End Using
    End Sub

    Public Sub SerialNum(ByRef value As String, Optional ByRef head As String = "")
        Using f = New KeyboardSerialNumForm(value, head)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then value = f.result
        End Using
    End Sub

End Module
