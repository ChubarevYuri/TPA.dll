Public Module Keyboard

    ''' <summary>
    ''' Ввод пароля (символы не отображаются)
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="useEng"></param>
    ''' <remarks></remarks>
    Public Sub Password(ByRef value As String, Optional ByVal useEng As Boolean = False)
        value = ""
        Using f = New KeyboardTextForm()
            If Not useEng Then
                f.language = 2
                f.ButtonLangL.Visible = False
                f.ButtonLangR.Visible = False
            End If
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then value = f.result
        End Using
    End Sub

    ''' <summary>
    ''' Текстовая клавиатура
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="head"></param>
    ''' <param name="useEng"></param>
    ''' <remarks></remarks>
    Public Sub Text(ByRef value As String, Optional ByVal head As String = "", Optional ByVal useEng As Boolean = False)
        Using f = New KeyboardTextForm(value, head)
            If Not useEng Then
                f.language = 2
                f.ButtonLangL.Visible = False
                f.ButtonLangR.Visible = False
            End If
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then value = f.result
        End Using
    End Sub

#Region "Decimal"

    ''' <summary>
    ''' Клавиатура для ввода значения в диапазоне [-999999999;999999999]
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="head"></param>
    ''' <remarks></remarks>
#Region "Int"
    Public Sub Int(ByRef value As Integer, Optional ByVal head As String = "")
        value = value Mod 1000000000
        Using f = New KeyboardDecimalForm(value.ToString, head, DecimalKeyboardType.Int)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    value = Val(f.result)
                Catch ex As Exception
                    Dim a As Double = Double.MinValue
                End Try
            End If
        End Using
    End Sub

    Public Sub Int(ByRef value As Double, Optional ByVal head As String = "")
        value = Math.Round(value Mod 1000000000, 0)
        Using f = New KeyboardDecimalForm(value.ToString, head, DecimalKeyboardType.Int)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    value = Val(f.result)
                Catch ex As Exception

                End Try
            End If
        End Using
    End Sub
#End Region

    ''' <summary>
    ''' Клавиатура для ввода значения в диапазоне [0;999999999]
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="head"></param>
    ''' <remarks></remarks>
#Region "UInt"
    Public Sub UInt(ByRef value As Integer, Optional ByVal head As String = "")
        value = Math.Abs(value) Mod 1000000000
        Using f = New KeyboardDecimalForm(value.ToString, head, DecimalKeyboardType.UInt)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    value = Val(f.result)
                Catch ex As Exception
                    Dim a As Double = Double.MinValue
                End Try
            End If
        End Using
    End Sub

    Public Sub UInt(ByRef value As Double, Optional ByVal head As String = "")
        value = Math.Round(Math.Abs(value) Mod 1000000000, 0)
        Using f = New KeyboardDecimalForm(value.ToString, head, DecimalKeyboardType.UInt)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    value = Val(f.result)
                Catch ex As Exception

                End Try
            End If
        End Using
    End Sub
#End Region

    ''' <summary>
    ''' Клавиатура для ввода значения в диапазоне [-999999999;999999999]
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="head"></param>
    ''' <remarks></remarks>
    Public Sub Real(ByRef value As Double, Optional ByVal head As String = "")
        value = value Mod 1000000000
        value = Math.Round(value, RoundCount(value))
        Using f = New KeyboardDecimalForm(value.ToString, head, DecimalKeyboardType.Real)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    value = Val(f.result)
                Catch ex As Exception

                End Try
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Клавиатура для ввода значения в диапазоне [0;999999999]
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="head"></param>
    ''' <remarks></remarks>
    Public Sub UReal(ByRef value As Double, Optional ByVal head As String = "")
        value = Math.Abs(value) Mod 1000000000
        value = Math.Round(value, RoundCount(value))
        Using f = New KeyboardDecimalForm(value.ToString, head, DecimalKeyboardType.UReal)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    value = Val(f.result)
                Catch ex As Exception

                End Try
            End If
        End Using
    End Sub

    Private Function RoundCount(ByVal value As Double) As Integer
        value = Math.Abs(value)
        If value < 10 Then Return 7
        If value < 100 Then Return 6
        If value < 1000 Then Return 5
        If value < 10000 Then Return 4
        If value < 100000 Then Return 3
        If value < 1000000 Then Return 2
        If value < 10000000 Then Return 1
        Return 0
    End Function

    ''' <summary>
    ''' Клавиатура для ввода текста (до 15 символов)
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="head"></param>
    ''' <remarks></remarks>
    Public Sub SerialNum(ByRef value As String, Optional ByVal head As String = "")
        If value.Length > 15 Then value = value.Substring(0, 15)
        Using f = New KeyboardDecimalForm(value, head, DecimalKeyboardType.SerialNum)
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then value = f.result
        End Using
    End Sub

    Public Enum DecimalKeyboardType
        Int
        UInt
        Real
        UReal
        SerialNum
    End Enum

#End Region

End Module
