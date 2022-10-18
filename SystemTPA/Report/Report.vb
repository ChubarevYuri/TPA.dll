''' <summary>
''' Создание отчета в виде серии изображений bmp
''' </summary>
''' <remarks></remarks>
Public Class Report

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Align
        Left
        Center
        Right
    End Enum

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Line
        None
        Underline
        Strikethrough
        UnderlineStrikethrough
        FillUnderline
        FillUnderlineStrikethrough
    End Enum

#Region "font"

    Private _doubleformat As String = "#0.00"
    ''' <summary>
    ''' Точность отображения double
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property doubleFormat() As Integer
        Set(ByVal value As Integer)
            _doubleformat = "#0"
            If value > 0 Then _doubleformat &= "."
            For i = 0 To value - 1
                _doubleformat &= "0"
            Next
        End Set
    End Property
    ''' <summary>
    ''' Отображение числа с заданной точностью
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DoubleToString(ByVal val As Double)
        Return val.ToString(_doubleformat)
    End Function

    Private _font As String = "Segoe UI"

    Private _fontSize As Single = 14
    ''' <summary>
    ''' Размер шрифта [1..48]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property fontSize() As Single
        Get
            Return _fontSize
        End Get
        Set(ByVal value As Single)
            _fontSize = If(value < 1, 1, If(value > 48, 48, value))
        End Set
    End Property

    Private _lineSpacing As Double = 1
    ''' <summary>
    ''' Межстрочный интервал [1..5]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property lineSpacing() As Double
        Get
            Return _lineSpacing
        End Get
        Set(ByVal value As Double)
            _lineSpacing = If(value < 1, 1, If(value > 5, 5, value))
        End Set
    End Property

    Private _indentTop As Double = 0
    ''' <summary>
    ''' Отступ абзаца, см [0..5]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property indentTop() As Double
        Get
            Return _indentTop
        End Get
        Set(ByVal value As Double)
            _indentTop = If(value < 0, 0, If(value > 5, 5, value))
        End Set
    End Property

    Private _indentLeft As Double = 0
    ''' <summary>
    ''' Отступ абзаца слева, см [0..5]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property indentLeft() As Double
        Get
            Return _indentLeft
        End Get
        Set(ByVal value As Double)
            _indentLeft = If(value < 0, 0, If(value > 5, 5, value))
        End Set
    End Property

    Private _indentRight As Double = 0
    ''' <summary>
    ''' Отступ абзаца справа, см [0..5]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property indentRight() As Double
        Get
            Return _indentRight
        End Get
        Set(ByVal value As Double)
            _indentRight = If(value < 0, 0, If(value > 5, 5, value))
        End Set
    End Property

    Private _firstLine As Double = 0
    ''' <summary>
    ''' Отступ красной строки, см [0..10]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property firstLine() As Double
        Get
            Return _firstLine
        End Get
        Set(ByVal value As Double)
            _firstLine = If(value < 0, 0, If(value > 10, 10, value))
        End Set
    End Property

    Private _horisontalAlign As Align = Align.Left
    ''' <summary>
    ''' Выравнивание текста по горизонтали
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property alignHorisontal() As Align
        Get
            Return _horisontalAlign
        End Get
        Set(ByVal value As Align)
            _horisontalAlign = value
        End Set
    End Property

    Private _verticalAlign As Align = Align.Left
    ''' <summary>
    ''' Выравнивание текста по вертикали
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property alignVertical() As Align
        Get
            Return _verticalAlign
        End Get
        Set(ByVal value As Align)
            _verticalAlign = value
        End Set
    End Property

    Private _fontStyle As Drawing.FontStyle = Drawing.FontStyle.Regular
    ''' <summary>
    ''' Стиль текста
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property fontStyle() As Drawing.FontStyle
        Get
            Return _fontStyle
        End Get
        Set(ByVal value As Drawing.FontStyle)
            _fontStyle = If(value = Nothing, Drawing.FontStyle.Regular, value)
        End Set
    End Property

    Private _fontLine As Line = Line.None
    ''' <summary>
    ''' Стиль подчеркивания
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property fontLine() As Line
        Get
            Return _fontLine
        End Get
        Set(ByVal value As Line)
            _fontLine = If(value = Nothing, Line.None, value)
        End Set
    End Property

#End Region

#Region "Text"

    Private _text As List(Of cellstruct) = New List(Of cellstruct)
    ''' <summary>
    ''' Запись текста
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property text() As String
        Set(ByVal value As String)
            table()
            Dim val As cellstruct
            val.fontStyle = fontStyle
            val.line = fontLine
            val.size = fontSize
            If value.Contains(Chr(13)) Then
                val.text = value.Split(Chr(13))(0)
                _text.Add(val)
                PrintText()
                value = value.Remove(0, value.IndexOf(Chr(13)) + 1)
                Try
                    Dim i As Integer = 0
                    Do While Asc(value(i)) = 10
                        value = value.Remove(0, 1)
                    Loop
                    If value.Length > 0 Then
                        text = value
                    End If
                Catch ex As Exception
                End Try
            Else
                val.text = value
                _text.Add(val)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Запись сохраненного текста
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrintText()
        If _text.Count > 0 Then
            Dim _fontStyle_ = fontStyle
            Dim _fontLine_ = fontLine
            Dim _fontSize_ = fontSize
            Dim _w As Integer = workWidth - smToPix(indentLeft) - smToPix(indentRight)
            Dim bmpStrFirst As Drawing.Bitmap = If(smToPix(firstLine) > 0, NewBmp(smToPix(firstLine), size("Gg").Height), Nothing)
            Y += smToPix(indentTop)
            For Each _str As cellstruct In _text
                fontStyle = _str.fontStyle
                fontLine = _str.line
                fontSize = _str.size
                Dim bmpStrs As List(Of Drawing.Bitmap) = bmpText(_str.text, _w, If(bmpStrFirst Is Nothing, 0, bmpStrFirst.Width))
                Dim _firstNew As Drawing.Bitmap = NewBmp(Math.Min(If(bmpStrFirst Is Nothing, _
                                                                     0, _
                                                                     bmpStrFirst.Width) + bmpStrs(0).Width, _
                                                                  _w), _
                                                         Math.Max(If(bmpStrFirst Is Nothing, _
                                                                     0, _
                                                                     bmpStrFirst.Height), _
                                                                  bmpStrs(0).Height))
                Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(_firstNew)
                    If Not (bmpStrFirst Is Nothing) Then _
                        _graph.DrawImage(bmpStrFirst, _
                                         0, _
                                         Math.Max(_firstNew.Height - bmpStrFirst.Height, _
                                                  0))
                    _graph.DrawImage(bmpStrs(0), _
                                     Math.Min(If(bmpStrFirst Is Nothing, _
                                                 0, _
                                                 bmpStrFirst.Width), _
                                              _firstNew.Width - 1), _
                                     Math.Max(_firstNew.Height - bmpStrs(0).Height, _
                                              0))
                End Using
                bmpStrs.RemoveAt(0)
                If bmpStrs.Count > 0 Then
                    strBmpToPage(_firstNew)
                    bmpStrFirst = bmpStrs(bmpStrs.Count - 1)
                    bmpStrs.RemoveAt(bmpStrs.Count - 1)
                    For Each bs As Drawing.Bitmap In bmpStrs
                        strBmpToPage(bs)
                    Next
                Else
                    bmpStrFirst = _firstNew
                End If
            Next
            If Not (bmpStrFirst Is Nothing) Then strBmpToPage(bmpStrFirst)
            _text.Clear()
            fontStyle = _fontStyle_
            fontLine = _fontLine_
            fontSize = _fontSize_
        End If
    End Sub

    Private Sub strBmpToPage(ByVal strBmp As Drawing.Bitmap)
        Dim _w As Integer = workWidth - smToPix(indentLeft) - smToPix(indentRight)
        If strBmp.Height * lineSpacing > workHeight - Y Then CreatePage()
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(selectPage)
            _graph.DrawImage(strBmp, _
                             smToPix(indentLeft) + (If(alignHorisontal = Align.Right, _
                                                       _w - strBmp.Width, _
                                                       If(alignHorisontal = Align.Center, _
                                                          (_w - strBmp.Width) / 2, _
                                                          0))), _
                             Y + strBmp.Height * (lineSpacing - 1))
        End Using
        Y += strBmp.Height * lineSpacing
    End Sub

    ''' <summary>
    ''' Перенос строки
    ''' </summary>
    ''' <remarks></remarks>
    Public Const enter As String = Chr(13) & Chr(10)

    ''' <summary>
    ''' Размер объекта
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function size(ByVal text) As Drawing.SizeF
        Dim _x As Single
        Dim _y As Single
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(New Drawing.Bitmap(1, 1))
            _x = _graph.MeasureString(text, _
                                      New Drawing.Font(_font, _
                                                      fontSize, _
                                                      fontStyle)).Width
            _y = _graph.MeasureString("Gg", _
                                      New Drawing.Font(_font, _
                                                      fontSize, _
                                                      fontStyle)).Height
        End Using
        Return New Drawing.SizeF(_x, _y)
    End Function

    ''' <summary>
    ''' Текст в список строк изображениями
    ''' </summary>
    ''' <param name="inputtext"></param>
    ''' <param name="width">pix</param>
    ''' <param name="fstLineX">pix</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function bmpText(ByVal inputtext As String, ByVal width As Integer, ByVal fstLineX As Integer) As List(Of Drawing.Bitmap)
        bmpText = New List(Of Drawing.Bitmap)
        For Each text As String In inputtext.Split(vbCrLf)
            Dim i As Integer = text.Length
            If size(text.Substring(0, i).Trim(" ")).Width > width - fstLineX Then
                Do
                    i -= 1
                Loop While If(text.Substring(0, i).TrimStart(" ").Contains(" "), _
                              If(text.Substring(i, 1) = " ", _
                                 size(text.Substring(0, i).Trim(" ")).Width > width - fstLineX, _
                                 True), _
                              size(text.Substring(0, i).Trim(" ")).Width > width - fstLineX) _
                              And If(fstLineX > 0, i > 1, i > 1)
            End If
            bmpText.Add(bmpLine(text.Substring(0, i).Trim(" "), width - fstLineX))
            fstLineX = smToPix(firstLine)
            If i < text.Length Then
                For Each _str As Drawing.Bitmap In bmpText(text.Substring(i), width, 0)
                    bmpText.Add(_str)
                Next
            End If
        Next
    End Function

    ''' <summary>
    ''' Текст в изображение
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="width"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function bmpLine(ByVal text As String, ByVal width As Integer) As Drawing.Bitmap
        Dim _size As Drawing.SizeF = size(text)
        bmpLine = NewBmp(Math.Max(_size.Width, 1), _size.Height)
        Dim sy As Double = 0.58
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(bmpLine)
            _graph.DrawString(text, _
                              New Drawing.Font(_font, _
                                              fontSize, _
                                              fontStyle), _
                              New Drawing.SolidBrush(Drawing.Color.Black), _
                              0, _
                              0)
            If fontLine = Line.Underline Then
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                0, size(text).Height - 1, _
                                size(text).Width + 0, _size.Height - 1)
            End If
            If fontLine = Line.Strikethrough Then
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                0, size(text).Height * sy, _
                                size(text).Width + 0, _size.Height * sy)
            End If
            If fontLine = Line.UnderlineStrikethrough Then
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                0, size(text).Height - 1, _
                                size(text).Width + 0, _size.Height - 1)
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                0, size(text).Height * sy, _
                                size(text).Width + 0, _size.Height * sy)
            End If
            If fontLine = Line.FillUnderline Then
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                0, size(text).Height - 1, _
                                bmpLine.Width, _size.Height - 1)
            End If
            If fontLine = Line.FillUnderlineStrikethrough Then
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                0, _size.Height - 1, _
                                bmpLine.Width, _size.Height - 1)
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                0, _size.Height * sy, _
                                bmpLine.Width, _size.Height * sy)
            End If
        End Using
    End Function

    ''' <summary>
    ''' Отображает поле подписи
    ''' </summary>
    ''' <param name="post">Должность</param>
    ''' <value>ФИО</value>
    ''' <remarks></remarks>
    Public WriteOnly Property signature(ByVal post As String) As String
        Set(ByVal value As String)
            PrintText()
            table()
            Dim sign_bmp As Drawing.Bitmap = _signature(post, value)
            Y += smToPix(indentTop)
            If Y + sign_bmp.Height > workHeight Then CreatePage()
            Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(selectPage)
                _graph.DrawImage(sign_bmp, 0, Y)
                Y += sign_bmp.Height
            End Using
        End Set
    End Property
    ''' <summary>
    ''' Отображает поле подписи
    ''' </summary>
    ''' <value>ФИО</value>
    ''' <remarks></remarks>
    Public WriteOnly Property signature() As String
        Set(ByVal value As String)
            signature("") = value
        End Set
    End Property
    ''' <summary>
    ''' Генерация поля подписи по ширине окна
    ''' </summary>
    ''' <param name="post">должность (слева от места для подписи)</param>
    ''' <param name="fio">расшифровка подписи</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function _signature(ByVal post As String, ByVal fio As String) As Drawing.Bitmap
        If fio = Nothing Then fio = ""
        If post = Nothing Then post = ""
        Dim _fontStyle_ = fontStyle
        Dim _fontLine_ = fontLine
        fontStyle = Drawing.FontStyle.Regular
        fontLine = Line.None
        Dim post_bmp_s As List(Of Drawing.Bitmap) = bmpText(If(post.Trim(" ").Length > 0, post.Trim(" ") & ":", ""), workWidth / 2, 0)
        Dim h_post As Integer = 0
        For Each s In post_bmp_s
            h_post += s.Height
        Next
        Dim post_bmp As Drawing.Bitmap = NewBmp(workWidth / 2, h_post)
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(post_bmp)
            Dim _y As Integer = 0
            For Each s In post_bmp_s
                _graph.DrawImage(s, 0, _y)
                _y += s.Height
            Next
        End Using
        Dim fio_bmp_s As List(Of Drawing.Bitmap) = bmpText(fio, workWidth / 3, 0)
        Dim h_fio As Integer = 0
        For Each s In fio_bmp_s
            h_fio += s.Height
        Next
        Dim fio_bmp As Drawing.Bitmap = NewBmp(workWidth / 3, h_fio)
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(fio_bmp)
            Dim _y As Integer = 0
            For Each s In fio_bmp_s
                _graph.DrawImage(s, 0, _y)
                _y += s.Height
            Next
        End Using
        Dim date_bmp As Drawing.Bitmap = bmpText("___ __________ 20___ г.", workWidth, 0)(0)

        _signature = NewBmp(workWidth, Math.Max(Math.Max(fio_bmp.Height, post_bmp.Height), size("").Height) + size("").Height * (lineSpacing - 1) + date_bmp.Height)
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(_signature)
            _graph.DrawImage(post_bmp, 0, _signature.Height - post_bmp.Height - date_bmp.Height)
            _graph.DrawImage(fio_bmp, workWidth - 5 - fio_bmp.Width, _signature.Height - fio_bmp.Height - date_bmp.Height)
            _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), workWidth / 2, _signature.Height - date_bmp.Height - 1, workWidth - 13 - fio_bmp.Width, _signature.Height - date_bmp.Height - 1)
            _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), workWidth - 7 - fio_bmp.Width, _signature.Height - date_bmp.Height - 1, workWidth - 8, _signature.Height - date_bmp.Height - 1)
            _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), workWidth - 10 - fio_bmp.Width, _signature.Height - date_bmp.Height - 1, workWidth - 5 - fio_bmp.Width, _signature.Height - (size("").Height - 2) - date_bmp.Height)
            _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), workWidth - 5, _signature.Height - date_bmp.Height - 1, workWidth - 1, _signature.Height - (size("").Height - 2) - date_bmp.Height)
            _graph.DrawImage(date_bmp, _signature.Width - date_bmp.Width, _signature.Height - date_bmp.Height)
        End Using
        fontStyle = _fontStyle_
        fontLine = _fontLine_
    End Function

    ''' <summary>
    ''' поле записи текста вручную
    ''' </summary>
    ''' <param name="lines">количество строк для записи [1..10]</param>
    ''' <value>текст перед полем</value>
    ''' <remarks></remarks>
    Public WriteOnly Property recordField(ByVal lines As Integer) As String
        Set(ByVal value As String)
            PrintText()
            table()
            Dim lines_bmp As Drawing.Bitmap = recField(value, lines)
            Y += smToPix(indentTop)
            If Y + lines_bmp.Height > workHeight Then CreatePage()
            Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(selectPage)
                _graph.DrawImage(lines_bmp, 0, Y)
                Y += lines_bmp.Height
            End Using
        End Set
    End Property
    ''' <summary>
    ''' поле записи текста вручную (3 строки)
    ''' </summary>
    ''' <value>текст перед полем</value>
    ''' <remarks></remarks>
    Public WriteOnly Property recordField() As String
        Set(ByVal value As String)
            recordField(3) = value
        End Set
    End Property
    ''' <summary>
    ''' поле записи текста вручную с заверением записей
    ''' </summary>
    ''' <param name="lines">количество строк для записи [1..10]</param>
    ''' <value>текст перед полем</value>
    ''' <remarks></remarks>
    Public WriteOnly Property recordFieldAndSign(ByVal lines As Integer) As String
        Set(ByVal value As String)
            PrintText()
            table()
            Dim lines_bmp As Drawing.Bitmap = recField(value, lines)
            Dim sign_bmp As Drawing.Bitmap = _signature("", "")
            Y += smToPix(indentTop)
            If Y + lines_bmp.Height + sign_bmp.Height + smToPix(indentTop) > workHeight Then CreatePage()
            Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(selectPage)
                _graph.DrawImage(lines_bmp, 0, Y)
                Y += lines_bmp.Height + smToPix(indentTop)
                _graph.DrawImage(sign_bmp, 0, Y)
                Y += sign_bmp.Height
            End Using
        End Set
    End Property
    ''' <summary>
    ''' поле записи текста вручную с заверением записей (3 строки)
    ''' </summary>
    ''' <value>текст перед полем</value>
    ''' <remarks></remarks>
    Public WriteOnly Property recordFieldAndSign() As String
        Set(ByVal value As String)
            recordFieldAndSign(3) = value
        End Set
    End Property
    ''' <summary>
    ''' Генерация поля для записи текста
    ''' </summary>
    ''' <param name="text">текст перед полем</param>
    ''' <param name="lines">количество строк для записи</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function recField(ByVal text As String, ByVal lines As Integer) As Drawing.Bitmap
        If lines < 1 Then lines = 1
        If lines > 10 Then lines = 10
        lines -= 1
        If text = Nothing Then text = ""
        Dim f_line As Drawing.Bitmap
        If text.Length > 0 Then
            text &= ":"
            Dim _fontStyle_ = fontStyle
            Dim _fontLine_ = fontLine
            fontStyle = Drawing.FontStyle.Regular
            fontLine = Line.None
            Dim text_bmp As List(Of Drawing.Bitmap) = bmpText(text, workWidth, 0)
            fontStyle = _fontStyle_
            fontLine = _fontLine_
            Dim _h As Integer = 0
            For Each s In text_bmp
                _h += s.Height
            Next
            f_line = NewBmp(workWidth, _h)
            Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(f_line)
                Dim _y As Integer = 0
                For Each s In text_bmp
                    _graph.DrawImage(s, 0, _y)
                    _y += s.Height
                Next
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                text_bmp(text_bmp.Count - 1).Width, _
                                f_line.Height - 1, _
                                f_line.Width - 1, _
                                f_line.Height - 1)
            End Using
        Else
            f_line = NewBmp(workWidth, size("").Height)
            Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(f_line)
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), 0, f_line.Height - 1, f_line.Width - 1, f_line.Height - 1)
            End Using
        End If
        recField = NewBmp(workWidth, f_line.Height + size("").Height * lines)
        Dim _y_ As Integer = 0
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(recField)
            _graph.DrawImage(f_line, 0, _y_)
            _y_ += f_line.Height
            Do Until lines < 0
                _y_ += size("").Height
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), 0, _y_, recField.Width - 1, _y_)
                lines -= 1
            Loop
        End Using
    End Function

#End Region

#Region "page"

    Private pages As New List(Of Drawing.Bitmap)
    Private pageNum As Integer = 0
    Private _printPageNum As Boolean = True
    ''' <summary>
    ''' Печать номера страницы на бланке
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PrintPageNum() As Boolean
        Get
            Return _printPageNum
        End Get
        Set(ByVal value As Boolean)
            Try
                _printPageNum = If(value, True, False)
            Catch ex As Exception
                _printPageNum = False
            End Try
        End Set
    End Property
    Private selectPage As Drawing.Bitmap = NewBmp(1, 1)
    Private Y As Integer = 0
    Private pageWidth As Integer = 759
    Private pageHeight As Integer = 1089
    Private borderLeft As Integer = 76
    Private borderRight As Integer = 19
    Private borderTop As Integer = 19
    Private borderBoth As Integer = 19
    ''' <summary>
    ''' рабочая область (ширина) в пикселях
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property workWidth() As Integer
        Get
            workWidth = pageWidth - borderLeft - borderRight
            If workWidth < 0 Then workWidth = 0
        End Get
    End Property
    ''' <summary>
    ''' рабочая область (высота) в пикселях
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property workHeight() As Integer
        Get
            workHeight = pageHeight - borderTop - borderBoth
            If workWidth < 0 Then workHeight = 0
        End Get
    End Property

    ''' <summary>
    ''' Стандартизированные листы
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum PageFormat
        A3v
        A3h
        A4v
        A4h
        A5v
        A5h
    End Enum

    ''' <summary>
    ''' Размеры стандартизированных листов
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly _PageFormat = New KeyValuePair(Of Integer, Integer)() _
                                  {New KeyValuePair(Of Integer, Integer)(1555, 1089), _
                                   New KeyValuePair(Of Integer, Integer)(1089, 1555), _
                                   New KeyValuePair(Of Integer, Integer)(759, 1089), _
                                   New KeyValuePair(Of Integer, Integer)(1089, 759), _
                                   New KeyValuePair(Of Integer, Integer)(523, 759), _
                                   New KeyValuePair(Of Integer, Integer)(759, 523)}

    ''' <summary>
    ''' Создание новой страницы
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreatePage()
        savePage()
        pageNum += 1
        selectPage = New Drawing.Bitmap(workWidth, _
                                        workHeight, _
                                        Drawing.Imaging.PixelFormat.Format16bppRgb555)
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(selectPage)
            _graph.Clear(Drawing.Color.White)
        End Using
        Y = 0
    End Sub

    ''' <summary>
    ''' Сохранение активного листа
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub savePage()
        If pageNum > 0 And selectPage.Height > 1 Then
            Dim _page = NewBmp(pageWidth, pageHeight)
            Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(_page)
                _graph.DrawImage(selectPage, borderLeft, borderTop)
                If PrintPageNum Then
                    Dim _fontSize_ = fontSize
                    Dim _fontStyle_ = fontStyle
                    Dim _fontLine_ = fontLine
                    fontSize = 11
                    fontStyle = Drawing.FontStyle.Regular
                    fontLine = Line.None
                    Do While fontSize > 0 And size("Gg").Height > borderBoth
                        fontSize -= 1
                    Loop
                    Dim _w As Integer = size(pageNum.ToString()).Width
                    _graph.DrawImage(bmpLine(pageNum.ToString(), _w), _
                                     pageWidth - borderRight - _w, _
                                     pageHeight - borderBoth)
                    fontSize = _fontSize_
                    fontStyle = _fontStyle_
                    fontLine = _fontLine_
                End If
            End Using
            pages.Add(_page)
        End If
        selectPage = NewBmp(1, 1)
    End Sub

    ''' <summary>
    ''' Возврат всех страниц одним объектом
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Show() As Drawing.Bitmap
        PrintText()
        table()
        savePage()
        Show = NewBmp(pageWidth, pageHeight * pages.Count + pages.Count - 1)
        Dim y As Integer = 0
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(Show)
            For Each page In pages
                _graph.DrawImage(page, 0, y)
                y += pageHeight
                _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), 0, y, pageWidth - 1, y)
                y += 1
            Next
        End Using
    End Function

#End Region

#Region "Table"

    Private _tableNum As Integer = 0

    Private _toptxt As cellstruct = Nothing
    ''' <summary>
    ''' Строка над таблицей
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property toptxt() As String
        Get
            Return _toptxt.text
        End Get
        Set(ByVal value As String)
            Dim val As cellstruct
            val.alignH = Align.Left
            val.alignV = Align.Right
            val.fontStyle = False
            val.line = Line.None
            val.size = fontSize
            val.text = value
            _toptxt = val
        End Set
    End Property
    ''' <summary>
    ''' Строка над таблицей в bmp
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function toptxtBmp() As Drawing.Bitmap
        If _toptxt.text = Nothing Then
            toptxt = ""
        End If
        Dim _alignHorisontal_ = alignHorisontal
        Dim _alignVertical_ = alignVertical
        Dim _fontStyle_ = fontStyle
        Dim _fontLine_ = fontLine
        Dim _fontsize_ = fontSize
        alignHorisontal = _toptxt.alignH
        alignVertical = _toptxt.alignV
        fontStyle = _toptxt.fontStyle
        fontLine = _toptxt.line
        fontSize = _toptxt.size
        Dim txt = bmpText("Таблица " & _tableNum & ". " & _toptxt.text, _
                          workWidth - indentLeft - indentRight, 0)
        Dim _y As Integer = smToPix(indentTop)
        Dim res = NewBmp(txt(0).Width, _
                         txt(0).Height * (txt.Count) + _y + 1)
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(res)
            For Each s In txt
                _graph.DrawImage(s, 0, _y)
                _y += txt(0).Height
            Next
        End Using
        alignHorisontal = _alignHorisontal_
        alignVertical = _alignVertical_
        fontStyle = _fontStyle_
        fontLine = _fontLine_
        fontSize = _fontsize_
        Return res
    End Function

    Private _bothtxt As cellstruct = Nothing
    ''' <summary>
    ''' строка под таблицей
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property bothtxt() As String
        Get
            Return _bothtxt.text
        End Get
        Set(ByVal value As String)
            Dim val As cellstruct
            val.alignH = Align.Left
            val.alignV = Align.Right
            val.fontStyle = False
            val.line = Line.None
            val.size = fontSize
            val.text = value
            _bothtxt = val
        End Set
    End Property
    ''' <summary>
    ''' Строка подтаблицей в bmp
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function bothtxtBmp() As Drawing.Bitmap
        If _bothtxt.text = Nothing Then Return NewBmp(1, 1)
        If _bothtxt.text.Length <= 0 Then Return NewBmp(1, 1)
        Dim _alignHorisontal_ = alignHorisontal
        Dim _alignVertical_ = alignVertical
        Dim _fontStyle_ = fontStyle
        Dim _fontLine_ = fontLine
        Dim _fontsize_ = fontSize
        alignHorisontal = _bothtxt.alignH
        alignVertical = _bothtxt.alignV
        fontStyle = _bothtxt.fontStyle
        fontLine = _bothtxt.line
        fontSize = _bothtxt.size
        Dim txt = bmpText(_bothtxt.text, _
                          workWidth - indentLeft - indentRight, 0)
        Dim _y As Integer = 1
        Dim res = NewBmp(txt(0).Width, _
                         txt(0).Height * (txt.Count) + _y)
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(res)
            For Each s In txt
                _graph.DrawImage(s, 0, _y)
                _y += txt(0).Height
            Next
        End Using
        alignHorisontal = _alignHorisontal_
        alignVertical = _alignVertical_
        fontStyle = _fontStyle_
        fontLine = _fontLine_
        fontSize = _fontsize_
        Return res
    End Function

    ''' <summary>
    ''' Тип переноса таблицы
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Tranfers
        None
        Rows
    End Enum

    Private _transfer As Tranfers = Tranfers.None
    ''' <summary>
    ''' тип переноса таблицы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property transfer() As Tranfers
        Get
            Return _transfer
        End Get
        Set(ByVal value As Tranfers)
            _transfer = value
        End Set
    End Property

    Private _borders As Boolean = True
    ''' <summary>
    ''' Отрисовывать ли поля ячейки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property borders() As Boolean
        Get
            Return _borders
        End Get
        Set(ByVal value As Boolean)
            _borders = value
        End Set
    End Property

    Private _columnWidths As Integer() = New Integer() {}
    ''' <summary>
    '''Соотношение размера столбцов.
    ''' Первоначальное значение для отсчета количества отображаемых столбцов
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property columnWidths() As Double()
        Get
            Dim result(_columnWidths.Length - 1) As Double
            For i = 0 To _columnWidths.Length - 1
                result(i) = (_columnWidths(i) + 3) / (workWidth - 1 - smToPix(indentLeft) - smToPix(indentRight)) * 100
            Next
            Return result
        End Get
        Set(ByVal value As Double())
            Dim sum As Double = 0
            For i = 0 To value.Length - 1
                If value(i) < 0 Then value(i) = 0
                sum += value(i)
            Next
            ReDim _columnWidths(value.Length - 1)
            Dim _w As Integer = 0
            For i = 0 To value.Length - 2
                _columnWidths(i) = (workWidth - 1 - smToPix(indentLeft) - smToPix(indentRight)) / sum * value(i) - 3
                _w += _columnWidths(i)
            Next
            _columnWidths(value.Length - 1) = (workWidth - 1 - smToPix(indentLeft) - smToPix(indentRight)) - _w - value.Length * 3
        End Set
    End Property

    Private _head As Dictionary(Of coordstruct, cellstruct) = New Dictionary(Of coordstruct, cellstruct)
    ''' <summary>
    ''' Заголовок таблицы
    ''' </summary>
    ''' <param name="i"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property head(ByVal i As Integer) As String
        Get
            Try
                Return _head(Coord(0, i)).text
            Catch ex As Exception
                Return ""
            End Try
        End Get
        Set(ByVal value As String)
            Dim val As cellstruct
            val.alignH = Align.Center
            val.alignV = Align.Center
            val.fontStyle = Drawing.FontStyle.Bold
            val.line = Line.None
            val.size = fontSize
            val.text = value
            _head.Add(Coord(0, i), val)
        End Set
    End Property
    Private _selecthead As Integer = -1
    ''' <summary>
    ''' Вывод последнего, ввод следующего заголовка
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property head() As String
        Get
            Return _head(Coord(0, _selecthead)).text
        End Get
        Set(ByVal value As String)
            Dim val As cellstruct
            val.alignH = Align.Center
            val.alignV = Align.Center
            val.fontStyle = Drawing.FontStyle.Bold
            val.line = Line.None
            val.size = fontSize
            val.text = value
            _selecthead += 1
            _head.Add(Coord(0, _selecthead), val)
        End Set
    End Property
    ''' <summary>
    ''' Последний столбец заголовка
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property headMax() As Integer
        Get
            Dim val As Integer = -1
            For Each i In _head.Keys
                val = Math.Max(val, i.col)
            Next
            Return val
        End Get
    End Property
    ''' <summary>
    ''' ячейка заголовка с параметрами
    ''' </summary>
    ''' <param name="col"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property _headCS(ByVal col As Integer) As cellstruct
        Get
            Try
                Return _head(Coord(0, col))
            Catch ex As Exception
                Dim val As cellstruct
                val.alignH = Align.Center
                val.alignV = Align.Center
                val.fontStyle = Drawing.FontStyle.Bold
                val.line = Line.None
                val.size = fontSize
                val.text = ""
                Return val
            End Try
        End Get
    End Property

    ''' <summary>
    ''' (row, col) -> sruct
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="col"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Coord(ByVal row As Integer, ByVal col As Integer) As coordstruct
        Coord.row = If(row < 0, 0, row)
        Coord.col = If(col < 0, 0, col)
    End Function

    Private selectCol As Integer = -1

    Private _body As Dictionary(Of coordstruct, cellstruct) = New Dictionary(Of coordstruct, cellstruct)
    ''' <summary>
    ''' значение таблицы (строка [с 0], столбец [с 0])
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property cell(ByVal row As Integer, ByVal col As Integer) As String
        Get
            Try
                Return _body(Coord(row, col)).text
            Catch ex As Exception
                Return ""
            End Try
        End Get
        Set(ByVal value As String)
            Dim val As cellstruct
            val.alignH = alignHorisontal
            val.alignV = alignVertical
            val.text = value
            val.fontStyle = fontStyle
            val.size = fontSize
            val.line = fontLine
            _body.Add(Coord(row, col), val)
            selectCol = col
        End Set
    End Property
    ''' <summary>
    ''' значение последней строки таблицы (столбец [с 0])
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property cell(ByVal col As Integer) As String
        Get
            Try
                Return _body(Coord(maxRow, col)).text
            Catch ex As Exception
                Return ""
            End Try
        End Get
        Set(ByVal value As String)
            Dim val As cellstruct
            val.alignH = alignHorisontal
            val.alignV = alignVertical
            val.text = value
            val.fontStyle = fontStyle
            val.size = fontSize
            val.line = fontLine
            _body.Add(Coord(maxRow, col), val)
            selectCol = col
        End Set
    End Property
    ''' <summary>
    ''' значение текущей, запись в следующую ячейку таблицы
    ''' (отсчет количества строк ведется из columnWidths. При пустом - от заголовка)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property cell() As String
        Get
            Try
                Return _body(Coord(maxRow, selectCol)).text
            Catch ex As Exception
                Return ""
            End Try
        End Get
        Set(ByVal value As String)
            Dim val As cellstruct
            val.alignH = alignHorisontal
            val.alignV = alignVertical
            val.text = value
            val.fontStyle = fontStyle
            val.size = fontSize
            val.line = fontLine
            If If(_columnWidths.Length > 0, _
                  selectCol < _columnWidths.Length - 1, _
                  selectCol < headMax) Then
                selectCol += 1
                _body(Coord(Math.Max(maxRow, 0), selectCol)) = val
            Else
                _body(Coord(maxRow + 1, 0)) = val
                selectCol = 0
            End If
        End Set
    End Property
    ''' <summary>
    ''' Активирование следующей строки
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub nextRow()
        cell(Math.Max(maxRow, 0) + 1, -1) = ""
    End Sub
    Private ReadOnly Property _cell(ByVal row As Integer, ByVal col As Integer) As cellstruct
        Get
            Try
                Return _body(Coord(row, col))
            Catch ex As Exception
                Dim val As cellstruct
                val.alignH = Align.Left
                val.alignV = Align.Left
                val.fontStyle = fontStyle
                val.line = Line.None
                val.size = fontSize
                val.text = ""
                Return val
            End Try
        End Get
    End Property

    ''' <summary>
    ''' максимальный номер строки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property maxRow() As Integer
        Get
            Dim res As Integer = -1
            For Each c In _body.Keys
                res = Math.Max(res, c.row)
            Next
            Return res
        End Get
    End Property
    ''' <summary>
    ''' максимальный номер столбца
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property maxCol() As Integer
        Get
            Dim res As Integer = -1
            For Each c In _body.Keys
                res = Math.Max(res, c.col)
            Next
            Return res
        End Get
    End Property
    ''' <summary>
    ''' максимальный номер столбца
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property maxCol(ByVal row As Integer) As Integer
        Get
            Dim res As Integer = -1
            For Each c In _body.Keys
                If c.row = row Then res = Math.Max(res, c.col)
            Next
            Return res
        End Get
    End Property

    ''' <summary>
    ''' Отображение таблицы в протоколе
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub table()
        If _body.Count > 0 Then
            PrintText()
            _tableNum += 1
            If _columnWidths.Length <= 0 Then
                Dim _ws(If(headMax >= 0, headMax, maxCol)) As Double
                For i = 0 To _ws.Length - 1
                    _ws(i) = 1
                Next
                columnWidths = _ws
            End If
            Dim headBmp = NewBmp(1, 1)
            If headMax >= 1 Then
                Dim row(headMax) As cellstruct
                For i = 0 To headMax
                    row(i) = _headCS(i)
                Next
                headBmp = bmpOneRow(row)
            End If
            Dim _toptxt_ = toptxtBmp()
            Dim _bothtxt_ = bothtxtBmp()
            Dim _rows_ = bmpRows()
            If _transfer = Tranfers.None Then
                Dim height = _toptxt_.Height + _bothtxt_.Height + headBmp.Height - 1
                For Each r In _rows_
                    height += r.Height - 1
                Next
                Dim _table = NewBmp(workWidth - smToPix(indentLeft) - smToPix(indentRight), height)
                Dim _y = 0
                Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(_table)
                    _graph.DrawImage(_toptxt_, 0, _y)
                    _y += _toptxt_.Height - 1
                    _graph.DrawImage(headBmp, 0, _y)
                    _y += headBmp.Height - 1
                    For Each r In _rows_
                        _graph.DrawImage(r, 0, _y)
                        _y += r.Height - 1
                    Next
                    _graph.DrawImage(_bothtxt_, 0, _y)
                End Using
                If workHeight - Y < _table.Height Then CreatePage()
                Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(selectPage)
                    _graph.DrawImage(_table, smToPix(indentLeft), Y)
                End Using
                Y += _table.Height
            Else
                Dim lastrow = NewBmp(_rows_(_rows_.Length - 1).Width, _
                                     _rows_(_rows_.Length - 1).Height + _bothtxt_.Height)
                Dim _y = 0
                Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(lastrow)
                    _graph.DrawImage(_rows_(_rows_.Length - 1), 0, 0)
                    _graph.DrawImage(_bothtxt_, 0, _rows_(_rows_.Length - 1).Height)
                End Using
                _rows_(_rows_.Length - 1) = lastrow
                Dim fstRow = True
                For Each r In _rows_
                    If fstRow Then
                        If workHeight - Y < _toptxt_.Height + headBmp.Height + r.Height - 2 Then CreatePage()
                        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(selectPage)
                            _graph.DrawImage(_toptxt_, smToPix(indentLeft), Y)
                            Y += _toptxt_.Height - 1
                            _graph.DrawImage(headBmp, smToPix(indentLeft), Y)
                            Y += headBmp.Height - 1
                            _graph.DrawImage(r, smToPix(indentLeft), Y)
                            Y += r.Height - 1
                        End Using
                        fstRow = False
                    Else
                        If workHeight - Y < r.Height - 1 Then
                            CreatePage()
                            Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(selectPage)
                                _graph.DrawImage(headBmp, smToPix(indentLeft), Y)
                                Y += headBmp.Height - 1
                                _graph.DrawImage(r, smToPix(indentLeft), Y)
                                Y += r.Height - 1
                            End Using
                        Else
                            Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(selectPage)
                                _graph.DrawImage(r, smToPix(indentLeft), Y)
                                Y += r.Height - 1
                            End Using
                        End If
                    End If
                Next
            End If
        End If
        selectCol = -1
        _selecthead = -1
        _body.Clear()
        _head.Clear()
        _columnWidths = New Integer() {}
        toptxt = ""
        bothtxt = ""
    End Sub

    ''' <summary>
    ''' Преобразование строк в bmp()
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function bmpRows() As Drawing.Bitmap()
        Dim res(maxRow) As Drawing.Bitmap
        For i = 0 To res.Length - 1
            Dim row(_columnWidths.Length - 1) As cellstruct
            For j = 0 To row.Length - 1
                row(j) = _cell(i, j)
            Next
            res(i) = bmpOneRow(row)
        Next
        Return res
    End Function

    ''' <summary>
    ''' Проверка наличия созданных ячеек в строке
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValsInRow(ByVal row As Integer) As Boolean
        For Each i In _body.Keys
            If i.row = row And i.col >= 0 Then Return True
        Next
        Return False
    End Function

    ''' <summary>
    ''' Преобразование строки в bmp
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function bmpOneRow(ByVal row As cellstruct()) As Drawing.Bitmap
        If row.Length > 0 Then
            Dim cells(_columnWidths.Length - 1) As Drawing.Bitmap
            For i = 0 To cells.Length - 1
                cells(i) = bmpCell(row(i), _columnWidths(i))
            Next
            Dim maxH As Integer = 0
            For Each i In cells
                maxH = Math.Max(i.Height, maxH)
            Next
            Dim res As Drawing.Bitmap = NewBmp(workWidth - smToPix(indentLeft) - smToPix(indentRight), maxH + 4)
            Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(res)
                If borders Then
                    _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                    0, 0, _
                                    res.Width - 1, 0)
                    _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                    0, res.Height - 1, _
                                    res.Width - 1, res.Height - 1)
                End If
                Dim _x As Integer = 0
                For i = 0 To _columnWidths.Length - 1
                    If borders Then
                        _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                        _x, 0, _
                                        _x, res.Height - 1)
                    End If
                    Dim _y As Integer = If(row(i).alignV = Align.Left, _
                                           0, _
                                           If(row(i).alignV = Align.Right, _
                                              maxH - cells(i).Height, _
                                              (maxH - cells(i).Height) / 2))
                    _graph.DrawImage(cells(i), _x + 2, _y + 2)
                    _x += cells(i).Width + 3
                Next
                If borders Then
                    _graph.DrawLine(New Drawing.Pen(Drawing.Color.Black), _
                                    res.Width - 1, 0, _
                                    res.Width - 1, res.Height - 1)
                End If
            End Using
            Return res
        Else
            Return NewBmp(1, 1)
        End If
    End Function

    ''' <summary>
    ''' Преобразование ячейки в bmp
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <param name="width"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function bmpCell(ByVal cell As cellstruct, _
                             ByVal width As Integer) As Drawing.Bitmap
        If cell.text.Length > 0 And width > 0 Then
            Dim _fontStyle_ = fontStyle
            Dim _fontSize_ = fontSize
            Dim _alignHorisontal_ = alignHorisontal
            Dim _fontLine_ = fontLine
            Dim _indentLeft_ = indentLeft
            Dim _indentRight_ = indentRight
            Dim _indentTop_ = indentTop
            Dim _firstLine_ = firstLine
            fontStyle = cell.fontStyle
            fontSize = cell.size
            alignHorisontal = cell.alignH
            fontLine = cell.line
            indentLeft = 0
            indentRight = 0
            indentTop = 0
            firstLine = 0
            Dim arr As List(Of Drawing.Bitmap) = bmpText(cell.text, width, 0)
            Dim height As Integer = 0
            For Each i As Drawing.Bitmap In arr
                height += i.Height
            Next
            bmpCell = NewBmp(width, height)
            Dim y As Integer = 0
            Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(bmpCell)
                For Each i In arr
                    Dim x As Integer = If(alignHorisontal = Align.Right, _
                                          bmpCell.Width - i.Width, _
                                          If(alignHorisontal = Align.Center, _
                                             (bmpCell.Width - i.Width) / 2, _
                                             0))
                    _graph.DrawImage(i, x, y)
                    y += i.Height
                Next
            End Using
            fontStyle = _fontStyle_
            fontSize = _fontSize_
            alignHorisontal = _alignHorisontal_
            fontLine = _fontLine_
            indentLeft = _indentLeft_
            indentRight = _indentRight_
            indentTop = _indentTop_
            firstLine = _firstLine_
            Return bmpCell
        Else
            Return NewBmp(1, 1)
        End If
    End Function

#End Region

#Region "bmp"

    ''' <summary>
    ''' Изображение страницу
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property image() As Drawing.Bitmap
        Set(ByVal value As Drawing.Bitmap)
            PrintText()
            table()
            If value.Height > 0 Then
                Dim bmp = NewBmp(Math.Min(workWidth - smToPix(indentLeft) - smToPix(indentRight), value.Width), Math.Min(workHeight, value.Height))
                Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(bmp)
                    _graph.DrawImage(value, 0, 0)
                End Using
                If workHeight - Y < bmp.Height Then CreatePage()
                Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(selectPage)
                    Dim _x As Integer
                    If alignHorisontal = Align.Left Then
                        _x = smToPix(indentLeft)
                    ElseIf alignHorisontal = Align.Right Then
                        _x = workWidth - smToPix(indentRight) - bmp.Width
                    Else
                        _x = (workWidth - smToPix(indentLeft) - smToPix(indentRight) - bmp.Width) / 2 + smToPix(indentLeft)
                    End If
                    _graph.DrawImage(bmp, _x, Y)
                End Using
                Y += bmp.Height
            End If
        End Set
    End Property

#End Region

#Region "new()"

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу справа)</param>
    ''' <remarks></remarks>
    Public Sub New(Optional ByRef _printPageNum As Boolean = True)
        PrintPageNum = _printPageNum
        CreatePage()
    End Sub

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="borders">Размер полей в cм ≥0,5</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу справа)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal borders As Double, _
                   Optional ByRef _printPageNum As Boolean = True)
        PrintPageNum = _printPageNum
        Dim _borders As Integer = smToPix(Math.Max(borders - 0.5, 0))
        If _borders > 0 And _borders * 2 < pageWidth And _borders * 2 < pageHeight Then
            borderLeft = _borders
            borderRight = _borders
            borderTop = _borders
            borderBoth = _borders
        End If
        CreatePage()
    End Sub

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="borders">Размеры полей в см (левое, правое, верхнее, нижнее) ≥0,5</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу справа)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal borders() As Double, _
                   Optional ByRef _printPageNum As Boolean = True)
        PrintPageNum = _printPageNum
        Dim _borderLeft As Integer
        Try
            _borderLeft = smToPix(Math.Max(borders(0) - 0.5, 0))
            If _borderLeft < 0 Then _borderLeft = borderLeft
        Catch ex As Exception
            _borderLeft = borderLeft
        End Try
        Dim _borderRight As Integer
        Try
            _borderRight = smToPix(Math.Max(borders(1) - 0.5, 0))
            If _borderRight < 0 Then _borderRight = borderRight
        Catch ex As Exception
            _borderRight = borderRight
        End Try
        Dim _borderTop As Integer
        Try
            _borderTop = smToPix(Math.Max(borders(2) - 0.5, 0))
            If _borderTop < 0 Then _borderTop = borderTop
        Catch ex As Exception
            _borderTop = borderTop
        End Try
        Dim _borderBoth As Integer
        Try
            _borderBoth = smToPix(Math.Max(borders(3) - 0.5, 0))
            If _borderBoth < 0 Then _borderBoth = borderBoth
        Catch ex As Exception
            _borderBoth = borderBoth
        End Try
        If _borderLeft + _borderRight < pageWidth Then
            borderLeft = _borderLeft
            borderRight = _borderRight
        End If
        If _borderBoth + _borderTop < pageHeight Then
            borderTop = _borderTop
            borderBoth = _borderBoth
        End If
        CreatePage()
    End Sub

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="format">Формат листа</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу справа)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal format As PageFormat, _
                   Optional ByRef _printPageNum As Boolean = True)
        PrintPageNum = _printPageNum
        Select Case format
            Case PageFormat.A3v
                pageWidth = 1555
                pageHeight = 1089
            Case PageFormat.A3h
                pageWidth = 1089
                pageHeight = 1555
            Case PageFormat.A4v
                pageWidth = 759
                pageHeight = 1089
            Case PageFormat.A4h
                pageWidth = 1089
                pageHeight = 759
            Case PageFormat.A5v
                pageWidth = 759
                pageHeight = 523
            Case PageFormat.A5h
                pageWidth = 523
                pageHeight = 759
        End Select
        If borderBoth + borderTop > pageHeight Then
            borderBoth = 0
            borderTop = 0
        End If
        If borderLeft + borderRight > pageWidth Then
            borderLeft = 0
            borderRight = 0
        End If
        CreatePage()
    End Sub

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="format">Формат листа</param>
    ''' <param name="borders">Размер полей в см ≥0,5</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу справа)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal format As PageFormat, _
                   ByVal borders As Double, _
                   Optional ByRef _printPageNum As Boolean = True)
        PrintPageNum = _printPageNum
        Select Case format
            Case PageFormat.A3v
                pageWidth = 1555
                pageHeight = 1089
            Case PageFormat.A3h
                pageWidth = 1089
                pageHeight = 1555
            Case PageFormat.A4v
                pageWidth = 759
                pageHeight = 1089
            Case PageFormat.A4h
                pageWidth = 1089
                pageHeight = 759
            Case PageFormat.A5v
                pageWidth = 759
                pageHeight = 523
            Case PageFormat.A5h
                pageWidth = 523
                pageHeight = 759
        End Select
        Dim _borders As Integer = smToPix(Math.Max(borders - 0.5, 0))
        If _borders > 0 And _borders * 2 < pageWidth And _borders * 2 < pageHeight Then
            borderLeft = _borders
            borderRight = _borders
            borderTop = _borders
            borderBoth = _borders
        End If
        If borderBoth + borderTop > pageHeight Then
            borderBoth = 0
            borderTop = 0
        End If
        If borderLeft + borderRight > pageWidth Then
            borderLeft = 0
            borderRight = 0
        End If
        CreatePage()
    End Sub

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="format">Формат листа</param>
    ''' <param name="borders">Размеры полей в см (левое, правое, верхнее, нижнее) ≥0,5</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу справа)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal format As PageFormat, _
                   ByVal borders() As Double, _
                   Optional ByRef _printPageNum As Boolean = True)
        PrintPageNum = _printPageNum
        Select Case format
            Case PageFormat.A3v
                pageWidth = 1555
                pageHeight = 1089
            Case PageFormat.A3h
                pageWidth = 1089
                pageHeight = 1555
            Case PageFormat.A4v
                pageWidth = 759
                pageHeight = 1089
            Case PageFormat.A4h
                pageWidth = 1089
                pageHeight = 759
            Case PageFormat.A5v
                pageWidth = 759
                pageHeight = 523
            Case PageFormat.A5h
                pageWidth = 523
                pageHeight = 759
        End Select
        Dim _borderLeft As Integer
        Try
            _borderLeft = smToPix(Math.Max(borders(0) - 0.5, 0))
            If _borderLeft < 0 Then _borderLeft = borderLeft
        Catch ex As Exception
            _borderLeft = borderLeft
        End Try
        Dim _borderRight As Integer
        Try
            _borderRight = smToPix(Math.Max(borders(1) - 0.5, 0))
            If _borderRight < 0 Then _borderRight = borderRight
        Catch ex As Exception
            _borderRight = borderRight
        End Try
        Dim _borderTop As Integer
        Try
            _borderTop = smToPix(Math.Max(borders(2) - 0.5, 0))
            If _borderTop < 0 Then _borderTop = borderTop
        Catch ex As Exception
            _borderTop = borderTop
        End Try
        Dim _borderBoth As Integer
        Try
            _borderBoth = smToPix(Math.Max(borders(3) - 0.5, 0))
            If _borderBoth < 0 Then _borderBoth = borderBoth
        Catch ex As Exception
            _borderBoth = borderBoth
        End Try
        If _borderLeft + _borderRight < pageWidth Then
            borderLeft = _borderLeft
            borderRight = _borderRight
        End If
        If _borderBoth + _borderTop < pageHeight Then
            borderTop = _borderTop
            borderBoth = _borderBoth
        End If
        If borderBoth + borderTop > pageHeight Then
            borderBoth = 0
            borderTop = 0
        End If
        If borderLeft + borderRight > pageWidth Then
            borderLeft = 0
            borderRight = 0
        End If
        CreatePage()
    End Sub

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="width">ширина листа в см</param>
    ''' <param name="height">высота листа в см</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу справа)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal width As Double, _
                   ByVal height As Double, _
                   Optional ByRef _printPageNum As Boolean = True)
        PrintPageNum = _printPageNum
        width -= 1
        height -= 1
        If width > 0 Then pageWidth = smToPix(width)
        If height > 0 Then pageHeight = smToPix(height)
        If borderBoth + borderTop > pageHeight Then
            borderBoth = 0
            borderTop = 0
        End If
        If borderLeft + borderRight > pageWidth Then
            borderLeft = 0
            borderRight = 0
        End If
        CreatePage()
    End Sub

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="width">ширина листа в см</param>
    ''' <param name="height">высота листа в см</param>
    ''' <param name="borders">Размер полей в см ≥0,5</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу справа)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal width As Double, _
                   ByVal height As Double, _
                   ByVal borders As Double, _
                   Optional ByRef _printPageNum As Boolean = True)
        PrintPageNum = _printPageNum
        width -= 1
        height -= 1
        If width > 0 Then pageWidth = smToPix(width)
        If height > 0 Then pageHeight = smToPix(height)
        Dim _borders As Integer = smToPix(borders)
        If _borders > 0 And _borders * 2 < pageWidth And _borders * 2 < pageHeight Then
            borderLeft = _borders
            borderRight = _borders
            borderTop = _borders
            borderBoth = _borders
        End If
        If borderBoth + borderTop > pageHeight Then
            borderBoth = 0
            borderTop = 0
        End If
        If borderLeft + borderRight > pageWidth Then
            borderLeft = 0
            borderRight = 0
        End If
        CreatePage()
    End Sub

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="width">ширина листа в см</param>
    ''' <param name="height">высота листа в см</param>
    ''' <param name="borders">Размеры полей в см (левое, правое, верхнее, нижнее) ≥0,5</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу справа)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal width As Double, _
                   ByVal height As Double, _
                   ByVal borders() As Double, _
                   Optional ByRef _printPageNum As Boolean = True)
        PrintPageNum = _printPageNum
        width -= 1
        height -= 1
        If width > 0 Then pageWidth = smToPix(width)
        If height > 0 Then pageHeight = smToPix(height)
        Dim _borderLeft As Integer
        Try
            _borderLeft = smToPix(Math.Max(borders(0) - 0.5, 0))
            If _borderLeft < 0 Then _borderLeft = borderLeft
        Catch ex As Exception
            _borderLeft = borderLeft
        End Try
        Dim _borderRight As Integer
        Try
            _borderRight = smToPix(Math.Max(borders(1) - 0.5, 0))
            If _borderRight < 0 Then _borderRight = borderRight
        Catch ex As Exception
            _borderRight = borderRight
        End Try
        Dim _borderTop As Integer
        Try
            _borderTop = smToPix(Math.Max(borders(2) - 0.5, 0))
            If _borderTop < 0 Then _borderTop = borderTop
        Catch ex As Exception
            _borderTop = borderTop
        End Try
        Dim _borderBoth As Integer
        Try
            _borderBoth = smToPix(Math.Max(borders(3) - 0.5, 0))
            If _borderBoth < 0 Then _borderBoth = borderBoth
        Catch ex As Exception
            _borderBoth = borderBoth
        End Try
        If _borderLeft + _borderRight < pageWidth Then
            borderLeft = _borderLeft
            borderRight = _borderRight
        End If
        If _borderBoth + _borderTop < pageHeight Then
            borderTop = _borderTop
            borderBoth = _borderBoth
        End If
        If borderBoth + borderTop > pageHeight Then
            borderBoth = 0
            borderTop = 0
        End If
        If borderLeft + borderRight > pageWidth Then
            borderLeft = 0
            borderRight = 0
        End If
        CreatePage()
    End Sub

#End Region

    ''' <summary>
    ''' Преобразование сантиметров в пиксели
    ''' коэф = 3,79363
    ''' </summary>
    ''' <param name="sm"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function smToPix(ByVal sm As Double) As Integer
        Try
            Return Math.Ceiling(sm * 37.9363)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Формат контрольного значения
    ''' </summary>
    ''' <param name="min"></param>
    ''' <param name="max"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ControlVals(Optional ByVal min As Object = Double.MinValue, _
                                  Optional ByVal max As Object = Double.MaxValue) As String
        If (min = Double.MinValue Or min = 0) And (max = Double.MaxValue Or max = 0) Then
            Return "---"
        ElseIf min = max Then
            Try
                Return "= " & If(TypeOf max Is Double, _
                                 DoubleToString(max), _
                                 max.ToString())
            Catch ex As Exception
                Return "= ___"
            End Try
        ElseIf min = Double.MinValue Or min = 0 Then
            Try
                Return "≤ " & If(TypeOf max Is Double, _
                                 DoubleToString(max), _
                                 max.ToString())
            Catch
                Return "≤ ___"
            End Try
        ElseIf max = Double.MaxValue Or max = 0 Then
            Try
                Return "≥ " & If(TypeOf min Is Double, _
                                 DoubleToString(min), _
                                 min.ToString())
            Catch
                Return "≥ ___"
            End Try
        Else
            Try
                Return If(TypeOf min Is Double, _
                          DoubleToString(min), _
                          min.ToString()) & " .. " & If(TypeOf max Is Double, _
                                                        DoubleToString(max), _
                                                        max.ToString())
            Catch ex As Exception
                Return "___ .. ___"
            End Try
        End If
    End Function

    ''' <summary>
    ''' Формат отображения bool
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Result(ByVal val As Boolean) As String
        Return If(val, "норма", "не соотв.")
    End Function

#Region "save()"

    ''' <summary>
    ''' Сохранение протокола
    ''' </summary>
    ''' <param name="path">относительный путь к файлу</param>
    ''' <param name="name">имя файла</param>
    ''' <remarks></remarks>
    Public Function Save(ByVal path As String, ByVal name As String) As Collection
        PrintText()
        table()
        savePage()
        Save = New Collection()
        If pages.Count = 0 Then Exit Function
        If path.Length > 0 Then
            If Not System.IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
        End If
        If pages.Count = 1 Then
            Dim page As Drawing.Bitmap = pages.Item(1)
            page.Save(path & name & ".bmp", Drawing.Imaging.ImageFormat.Bmp)
            Save.Add(path & name & ".bmp")
            Exit Function
        End If
        Dim n As Integer = 0
        For Each page As Drawing.Bitmap In pages
            n += 1
            page.Save(path & name & " " & n & ".bmp", Drawing.Imaging.ImageFormat.Bmp)
            Save.Add(path & name & " " & n & ".bmp")
        Next
    End Function

    ''' <summary>
    ''' Сохранение протокола
    ''' </summary>
    ''' <param name="name">имя файла</param>
    ''' <remarks></remarks>
    Public Function Save(ByVal name As String) As Collection
        Save = Save(BasePath & "reports\", name)
    End Function

    ''' <summary>
    ''' Сохранение протокола
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Save() As Collection
        Save = Save(BasePath & "reports\", "report")
    End Function

#End Region

    Public Structure coordstruct
        Dim row As Integer
        Dim col As Integer

        Public Shared Operator =(ByVal a As coordstruct, ByVal b As coordstruct) As Boolean
            Return a.col = b.col And a.row = b.row
        End Operator
        Public Shared Operator <>(ByVal a As coordstruct, ByVal b As coordstruct) As Boolean
            Return Not a = b
        End Operator
    End Structure

    Public Structure cellstruct
        Dim text As String
        Dim alignH As Align
        Dim alignV As Align
        Dim size As Single
        Dim fontStyle As Drawing.FontStyle
        Dim line As Line
    End Structure

    ''' <summary>
    ''' Создание белого изображения
    ''' </summary>
    ''' <param name="width">ширина в пикселях</param>
    ''' <param name="height">высота в пикселях</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NewBmp(ByVal width As Integer, ByVal height As Integer) As Drawing.Bitmap
        Dim res = New Drawing.Bitmap(width, height)
        Using _graph As Drawing.Graphics = Drawing.Graphics.FromImage(res)
            _graph.Clear(Drawing.Color.White)
        End Using
        Return res
    End Function

End Class