Imports System.Drawing
Imports System.Windows.Forms

Public Class KeyboardTextForm
    Friend language As Integer = 2
    Private _passwordMode As Boolean = False
    Private _result As String = ""
    Private _startText As String = ""
    Private _isShift As Boolean = False
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
        If Not startRU Then language = 0
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
    End Sub

    ''' <summary>
    ''' Клавиатура для ввода пароля
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        _passwordMode = True
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

    End Sub

    Private Sub KeyboardTextForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TPA.GAMEMODE_FORM(Me) = True
        DialogForms.WaitFormStop()
        ButtonEnter.Focus()
    End Sub

    Private Sub VisibleText()
        ButtonEnter.Focus()
        _textLenght = _result.Length
        If _passwordMode Then
            LabelText.Text = StrDup(_textLenght, "*")
        Else
            LabelText.Text = _result
        End If
    End Sub

    Private Sub keysText()
        ButtonEnter.Focus()
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

    Private Sub KeyboardTextForm_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Panel1.Left = (Me.Width - Panel1.Width) / 2
        Panel1.Top = (Me.Height - Panel1.Height - LabelHead.Top - LabelHead.Height) / 2 + LabelHead.Top + LabelHead.Height
    End Sub

    Private kbLangChangeEnable As Boolean = True
    Private AltOrCtrl As Boolean = False
    Private CapsEnabled As Boolean = True

    Private Sub KeyboardTextForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyValue = e.KeyValue
        Dim KeyData = e.KeyData
        Dim KeyCode = e.KeyCode
        If (e.KeyValue = Keys.Escape) Then ButtonEsc_Click(Nothing, Nothing)
        If (e.KeyValue = Keys.Back Or e.KeyValue = Keys.Delete) Then ButtonBackspace_Click(Nothing, Nothing)
        If (e.KeyValue = Keys.ShiftKey And Not _isShift) Then ButtonShift_Click(Nothing, Nothing)
        If (e.KeyValue = Keys.Menu Or e.KeyValue = Keys.ControlKey) Then AltOrCtrl = True
        If (AltOrCtrl And _isShift And (ButtonLangL.Visible Or ButtonLangR.Visible) And kbLangChangeEnable) Then
            kbLangChangeEnable = False
            ButtonLang_Click(Nothing, Nothing)
        End If
        If (e.KeyValue = Keys.Capital And CapsEnabled) Then
            CapsEnabled = False
            ButtonCaps_Click(ButtonCaps, Nothing)
        End If

        If (e.KeyValue = Keys.Space) Then _result &= " "
        If (e.KeyValue = Keys.NumPad0) Then _result &= "0"
        If (e.KeyValue = Keys.NumPad1) Then _result &= "1"
        If (e.KeyValue = Keys.NumPad2) Then _result &= "2"
        If (e.KeyValue = Keys.NumPad3) Then _result &= "3"
        If (e.KeyValue = Keys.NumPad4) Then _result &= "4"
        If (e.KeyValue = Keys.NumPad5) Then _result &= "5"
        If (e.KeyValue = Keys.NumPad6) Then _result &= "6"
        If (e.KeyValue = Keys.NumPad7) Then _result &= "7"
        If (e.KeyValue = Keys.NumPad8) Then _result &= "8"
        If (e.KeyValue = Keys.NumPad9) Then _result &= "9"
        If (e.KeyValue = Keys.Add) Then _result &= "+"
        If (e.KeyValue = Keys.Subtract) Then _result &= "-"
        If (e.KeyValue = Keys.Multiply) Then _result &= "*"
        If (e.KeyValue = Keys.Divide) Then _result &= "/"

        If (e.KeyValue = Keys.Q) Then _result &= keyText(32, language)
        If (e.KeyValue = Keys.W) Then _result &= keyText(33, language)
        If (e.KeyValue = Keys.E) Then _result &= keyText(34, language)
        If (e.KeyValue = Keys.R) Then _result &= keyText(35, language)
        If (e.KeyValue = Keys.T) Then _result &= keyText(36, language)
        If (e.KeyValue = Keys.Y) Then _result &= keyText(37, language)
        If (e.KeyValue = Keys.U) Then _result &= keyText(38, language)
        If (e.KeyValue = Keys.I) Then _result &= keyText(39, language)
        If (e.KeyValue = Keys.O) Then _result &= keyText(40, language)
        If (e.KeyValue = Keys.P) Then _result &= keyText(41, language)
        If (e.KeyValue = Keys.A) Then _result &= keyText(46, language)
        If (e.KeyValue = Keys.S) Then _result &= keyText(47, language)
        If (e.KeyValue = Keys.D) Then _result &= keyText(48, language)
        If (e.KeyValue = Keys.F) Then _result &= keyText(49, language)
        If (e.KeyValue = Keys.G) Then _result &= keyText(50, language)
        If (e.KeyValue = Keys.H) Then _result &= keyText(51, language)
        If (e.KeyValue = Keys.J) Then _result &= keyText(52, language)
        If (e.KeyValue = Keys.K) Then _result &= keyText(53, language)
        If (e.KeyValue = Keys.L) Then _result &= keyText(54, language)
        If (e.KeyValue = Keys.Z) Then _result &= keyText(57, language)
        If (e.KeyValue = Keys.X) Then _result &= keyText(58, language)
        If (e.KeyValue = Keys.C) Then _result &= keyText(59, language)
        If (e.KeyValue = Keys.V) Then _result &= keyText(60, language)
        If (e.KeyValue = Keys.B) Then _result &= keyText(61, language)
        If (e.KeyValue = Keys.N) Then _result &= keyText(62, language)
        If (e.KeyValue = Keys.M) Then _result &= keyText(63, language)

        If (e.KeyValue = Keys.D1) Then
            If (Not _isShift) Then
                _result &= "1"
            Else
                _result &= "!"
            End If
        End If
        If (e.KeyValue = Keys.D2) Then
            If (Not _isShift) Then
                _result &= "2"
            Else
                If (language < 2) Then
                    _result &= "@"
                Else
                    _result &= "'"
                End If
            End If
        End If
        If (e.KeyValue = Keys.D3) Then
            If (Not _isShift) Then
                _result &= "3"
            Else
                If (language < 2) Then
                    _result &= "#"
                Else
                    _result &= "№"
                End If
            End If
        End If
        If (e.KeyValue = Keys.D4) Then
            If (Not _isShift) Then
                _result &= "4"
            Else
                If (language < 2) Then
                    _result &= "$"
                Else
                    _result &= ";"
                End If
            End If
        End If
        If (e.KeyValue = Keys.D5) Then
            If (Not _isShift) Then
                _result &= "5"
            Else
                _result &= "%"
            End If
        End If
        If (e.KeyValue = Keys.D6) Then
            If (Not _isShift) Then
                _result &= "6"
            Else
                If (language < 2) Then
                    _result &= "^"
                Else
                    _result &= ":"
                End If
            End If
        End If
        If (e.KeyValue = Keys.D7) Then
            If (Not _isShift) Then
                _result &= "7"
            Else
                If (language < 2) Then
                    _result &= "&"
                Else
                    _result &= "?"
                End If
            End If
        End If
        If (e.KeyValue = Keys.D8) Then
            If (Not _isShift) Then
                _result &= "8"
            Else
                _result &= "*"
            End If
        End If
        If (e.KeyValue = Keys.D9) Then
            If (Not _isShift) Then
                _result &= "9"
            Else
                _result &= "("
            End If
        End If
        If (e.KeyValue = Keys.D0) Then
            If (Not _isShift) Then
                _result &= "0"
            Else
                _result &= ")"
            End If
        End If
        If (e.KeyValue = 189) Then
            If (Not _isShift) Then
                _result &= "-"
            Else
                _result &= "_"
            End If
        End If
        If (e.KeyValue = 187) Then
            If (Not _isShift) Then
                _result &= "="
            Else
                _result &= "+"
            End If
        End If

        If (e.KeyValue = 192) Then
            If (language < 2) Then
                _result &= If(Not _isShift, "`", "~")
            Else
                _result &= keyText(68, language)
            End If
        End If
        If (e.KeyValue = 219) Then
            If (language < 2) Then
                _result &= If(Not _isShift, "[", "{")
            Else
                _result &= keyText(42, language)
            End If
        End If
        If (e.KeyValue = 221) Then
            If (language < 2) Then
                _result &= If(Not _isShift, "]", "}")
            Else
                _result &= keyText(43, language)
            End If
        End If
        If (e.KeyValue = 186) Then
            If (language < 2) Then
                _result &= If(Not _isShift, ";", ":")
            Else
                _result &= keyText(55, language)
            End If
        End If
        If (e.KeyValue = 222) Then
            If (language < 2) Then
                _result &= If(Not _isShift, "'", "'")
            Else
                _result &= keyText(56, language)
            End If
        End If
        If (e.KeyValue = 220) Then
            If (language < 2) Then
                _result &= If(Not _isShift, "\", "|")
            Else
                _result &= If(Not _isShift, "\", "/")
            End If
        End If
        If (e.KeyValue = 188) Then
            If (language < 2) Then
                _result &= If(Not _isShift, ",", "<")
            Else
                _result &= keyText(64, language)
            End If
        End If
        If (e.KeyValue = 190) Then
            If (language < 2) Then
                _result &= If(Not _isShift, ".", ">")
            Else
                _result &= keyText(65, language)
            End If
        End If
        If (e.KeyValue = 191) Then
            If (language < 2) Then
                _result &= If(Not _isShift, "/", "?")
            Else
                _result &= If(Not _isShift, ".", ",")
            End If
        End If

            VisibleText()
    End Sub

    Private Sub KeyboardTextForm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ButtonEnter.Focus()
        If (e.KeyValue = Keys.ShiftKey And _isShift) Then ButtonShift_Click(Nothing, Nothing)
        If (e.KeyValue = Keys.Menu Or e.KeyValue = Keys.ControlKey) Then AltOrCtrl = False
        If ((Not AltOrCtrl Or Not _isShift) And Not kbLangChangeEnable) Then
            kbLangChangeEnable = True
        End If
        If (e.KeyValue = Keys.Capital And Not CapsEnabled) Then CapsEnabled = True
    End Sub

    Private Sub KeyboardTextForm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim a As Char = e.KeyChar
    End Sub
End Class