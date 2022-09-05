Imports System.Drawing
Imports System.Windows.Forms

Public Class KeyboardTextForm
    Private language As Integer = 3
    Private _passwordMode As Boolean = False
    Private _result As String = ""
    Private _startText As String = ""
    Private _isShift As Boolean = True
    Private _textLenght As Integer = 0
    Public Property result() As String
        Get
            Return _result
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property length() As Integer
        Get
            Return _textLenght
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property
    Private ReadOnly keyText(,) As String = {{"ESC", "ESC", "ВЫХ", "ВЫХ"}, _
                                             {"↑↑", "↑↑", "↑↑", "↑↑"}, _
                                             {"↑", "↑", "↑", "↑"}, _
                                             {"ENTER", "ENTER", "ВВОД", "ВВОД"}, _
                                             {"РУС", "РУС", "EN", "EN"}, _
                                             {"←", "←", "←", "←"}, _
                                             {"|←", "|←", "|←", "|←"}, _
                                             {" ", " ", " ", " "}, _
                                             {"0", "0", "0", "0"}, _
                                             {"1", "1", "1", "1"}, _
                                             {"2", "2", "2", "2"}, _
                                             {"3", "3", "3", "3"}, _
                                             {"4", "4", "4", "4"}, _
                                             {"5", "5", "5", "5"}, _
                                             {"6", "6", "6", "6"}, _
                                             {"7", "7", "7", "7"}, _
                                             {"8", "8", "8", "8"}, _
                                             {"9", "9", "9", "9"}, _
                                             {"!", "!", "!", "!"}, _
                                             {"@", "@", "'", "'"}, _
                                             {"#", "#", "№", "№"}, _
                                             {"$", "$", ";", ";"}, _
                                             {"%", "%", "%", "%"}, _
                                             {"^", "^", ":", ":"}, _
                                             {"&&", "&&", "?", "?"}, _
                                             {"(", "(", "(", "("}, _
                                             {")", ")", ")", ")"}, _
                                             {"+", "+", "+", "+"}, _
                                             {"*", "*", "*", "*"}, _
                                             {"-", "-", "-", "-"}, _
                                             {"=", "=", "=", "="}, _
                                             {"_", "_", "_", "_"}, _
                                             {"q", "Q", "й", "Й"}, _
                                             {"w", "W", "ц", "Ц"}, _
                                             {"e", "E", "у", "У"}, _
                                             {"r", "R", "к", "К"}, _
                                             {"t", "T", "е", "Е"}, _
                                             {"y", "Y", "н", "Н"}, _
                                             {"u", "U", "г", "Г"}, _
                                             {"i", "I", "ш", "Ш"}, _
                                             {"o", "O", "щ", "Щ"}, _
                                             {"p", "P", "з", "З"}, _
                                             {":", ":", "х", "Х"}, _
                                             {"№", "№", "ъ", "Ъ"}, _
                                             {"\", "\", "\", "\"}, _
                                             {"/", "/", "/", "/"}, _
                                             {"a", "A", "ф", "Ф"}, _
                                             {"s", "S", "ы", "Ы"}, _
                                             {"d", "D", "в", "В"}, _
                                             {"f", "F", "а", "А"}, _
                                             {"g", "G", "п", "П"}, _
                                             {"h", "H", "р", "Р"}, _
                                             {"j", "J", "о", "О"}, _
                                             {"k", "K", "л", "Л"}, _
                                             {"l", "L", "д", "Д"}, _
                                             {";", ";", "ж", "Ж"}, _
                                             {"'", "'", "э", "Э"}, _
                                             {"z", "Z", "я", "Я"}, _
                                             {"x", "X", "ч", "Ч"}, _
                                             {"c", "C", "с", "С"}, _
                                             {"v", "V", "м", "М"}, _
                                             {"b", "B", "и", "И"}, _
                                             {"n", "N", "т", "Т"}, _
                                             {"m", "M", "ь", "Ь"}, _
                                             {",", ",", "б", "Б"}, _
                                             {".", ".", "ю", "Ю"}, _
                                             {"?", "?", ".", "."}, _
                                             {"|", "|", ",", ","}, _
                                             {"`", "~", "ё", "Ё"} _
                                            }
    ''' <summary>
    ''' Клавиатура для ввода текста
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="startRU"></param>
    ''' <param name="head"></param>
    ''' <remarks></remarks>
    Public Sub New(ByRef value As String, _
                   Optional ByRef head As String = "", _
                   Optional ByRef startRU As Boolean = True)
        If Not startRU Then language = 1
        _startText = value
        _result = value
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

        LabelText.Text = value
        LabelHead.Text = head
        keysText()
        If language Mod 2 = 0 Then
            _isShift = False
        Else
            _isShift = True
        End If
        DialogForms.WaitFormStop()
    End Sub

    ''' <summary>
    ''' Клавиатура для ввода пароля
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        _passwordMode = True
        language = 0
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

        LabelHead.Text = "Пароль"
        keysText()
        If language Mod 2 = 0 Then
            _isShift = False
        Else
            _isShift = True
        End If
        DialogForms.WaitFormStop()
    End Sub

    Private Sub VisibleText()
        _textLenght = _result.Length
        If _passwordMode Then
            LabelText.Text = StrDup(_textLenght, "*")
        Else
            LabelText.Text = _result
        End If
    End Sub

    Private Sub keysText()
        ButtonEsc.Text = keyText(0, language)
        ButtonCaps.Text = keyText(1, language)
        ButtonShiftL.Text = keyText(2, language)
        ButtonShiftR.Text = keyText(2, language)
        If _isShift Then
            ButtonShiftL.BackColor = Color.DarkGray
            ButtonShiftR.BackColor = Color.DarkGray
        Else
            ButtonShiftL.BackColor = Color.LightGray
            ButtonShiftR.BackColor = Color.LightGray
        End If
        ButtonEnter.Text = keyText(3, language)
        ButtonLangL.Text = keyText(4, language)
        ButtonLangR.Text = keyText(4, language)
        ButtonBackspace.Text = keyText(5, language)
        ButtonClear.Text = keyText(6, language)
        ButtonSpace.Text = keyText(7, language)
        Button0.Text = keyText(8, language)
        Button1.Text = keyText(9, language)
        Button2.Text = keyText(10, language)
        Button3.Text = keyText(11, language)
        Button4.Text = keyText(12, language)
        Button5.Text = keyText(13, language)
        Button6.Text = keyText(14, language)
        Button7.Text = keyText(15, language)
        Button8.Text = keyText(16, language)
        Button9.Text = keyText(17, language)
        ButtonCh1.Text = keyText(18, language)
        ButtonCh2.Text = keyText(19, language)
        ButtonCh3.Text = keyText(20, language)
        ButtonCh4.Text = keyText(21, language)
        ButtonCh5.Text = keyText(22, language)
        ButtonCh6.Text = keyText(23, language)
        ButtonCh7.Text = keyText(24, language)
        ButtonCh8.Text = keyText(25, language)
        ButtonCh9.Text = keyText(26, language)
        ButtonCh10.Text = keyText(27, language)
        ButtonCh11.Text = keyText(28, language)
        ButtonCh12.Text = keyText(29, language)
        ButtonCh13.Text = keyText(30, language)
        ButtonCh14.Text = keyText(31, language)
        ButtonQ.Text = keyText(32, language)
        ButtonW.Text = keyText(33, language)
        ButtonE.Text = keyText(34, language)
        ButtonR.Text = keyText(35, language)
        ButtonT.Text = keyText(36, language)
        ButtonY.Text = keyText(37, language)
        ButtonU.Text = keyText(38, language)
        ButtonI.Text = keyText(39, language)
        ButtonO.Text = keyText(40, language)
        ButtonP.Text = keyText(41, language)
        ButtonSkS.Text = keyText(42, language)
        ButtonSkE.Text = keyText(43, language)
        ButtonSlashB.Text = keyText(44, language)
        ButtonSlash.Text = keyText(45, language)
        ButtonA.Text = keyText(46, language)
        ButtonS.Text = keyText(47, language)
        ButtonD.Text = keyText(48, language)
        ButtonF.Text = keyText(49, language)
        ButtonG.Text = keyText(50, language)
        ButtonH.Text = keyText(51, language)
        ButtonJ.Text = keyText(52, language)
        ButtonK.Text = keyText(53, language)
        ButtonL.Text = keyText(54, language)
        ButtonDoublepoint.Text = keyText(55, language)
        ButtonKav.Text = keyText(56, language)
        ButtonZ.Text = keyText(57, language)
        ButtonX.Text = keyText(58, language)
        ButtonC.Text = keyText(59, language)
        ButtonV.Text = keyText(60, language)
        ButtonB.Text = keyText(61, language)
        ButtonN.Text = keyText(62, language)
        ButtonM.Text = keyText(63, language)
        ButtonZap.Text = keyText(64, language)
        ButtonPoint.Text = keyText(65, language)
        ButtonQuestion.Text = keyText(66, language)
        ButtonPr.Text = keyText(67, language)
        ButtonTilda.Text = keyText(68, language)
    End Sub

    Private Sub ButtonEsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEsc.Click
        _result = _startText
        VisibleText()
        If _passwordMode Then
        Else
        End If
        Close()
    End Sub

    Private Sub ButtonEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnter.Click
        Close()
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        _result = ""
        VisibleText()
    End Sub

    Private Sub ButtonBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBackspace.Click
        If _result.Length > 0 Then _result = _result.Substring(0, _result.Length - 1)
        VisibleText()
    End Sub

    Private Sub ButtonShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonShiftL.Click, ButtonShiftR.Click
        _isShift = Not _isShift
        Select Case language
            Case 0
                language = 1

            Case 1
                language = 0
            Case 2
                language = 3
            Case 3
                language = 2
        End Select
        keysText()
    End Sub

    Private Sub ButtonLang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLangL.Click, ButtonLangR.Click
        Select Case language
            Case 0
                language = 2
            Case 1
                language = 3
            Case 2
                language = 0
            Case 3
                language = 1
        End Select
        keysText()
    End Sub

    Private Sub ButtonCaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCaps.Click
        Select Case language
            Case 0
                language = 1
                DirectCast(sender, Button).BackColor = Color.DarkGray
            Case 1
                language = 0
                DirectCast(sender, Button).BackColor = Color.LightGray
            Case 2
                language = 3
                DirectCast(sender, Button).BackColor = Color.DarkGray
            Case 3
                language = 2
                DirectCast(sender, Button).BackColor = Color.LightGray
        End Select
        keysText()
    End Sub

    Private Sub ButtonCh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles ButtonCh1.Click, ButtonCh7.Click, ButtonCh6.Click, _
                ButtonCh5.Click, ButtonCh4.Click, ButtonCh3.Click, _
                ButtonCh2.Click, ButtonTilda.Click, ButtonCh9.Click, _
                ButtonCh8.Click, ButtonCh13.Click, ButtonCh12.Click, _
                ButtonCh11.Click, ButtonCh10.Click, Button9.Click, _
                Button8.Click, Button7.Click, Button6.Click, Button5.Click, _
                Button4.Click, Button3.Click, Button2.Click, Button1.Click, _
                Button0.Click, ButtonZap.Click, ButtonZ.Click, ButtonY.Click, _
                ButtonX.Click, ButtonW.Click, ButtonV.Click, ButtonU.Click, ButtonT.Click, _
                ButtonSpace.Click, ButtonSlashB.Click, ButtonSlash.Click, ButtonSkS.Click, _
                ButtonSkE.Click, ButtonS.Click, ButtonR.Click, ButtonQuestion.Click, ButtonQ.Click, _
                ButtonPr.Click, ButtonPoint.Click, ButtonP.Click, ButtonO.Click, ButtonN.Click, _
                ButtonM.Click, ButtonL.Click, ButtonKav.Click, ButtonK.Click, ButtonJ.Click, _
                ButtonI.Click, ButtonH.Click, ButtonG.Click, ButtonF.Click, ButtonE.Click, _
                ButtonDoublepoint.Click, ButtonD.Click, ButtonCh14.Click, ButtonC.Click, _
                ButtonB.Click, ButtonA.Click
        _result &= DirectCast(sender, Button).Text
        VisibleText()
        If _isShift Then ButtonShift_Click(sender, e)
    End Sub
End Class