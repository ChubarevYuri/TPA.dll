Imports System.Drawing
Imports TPA.Line

''' <summary>
''' Создание отчета в виде серии изображений bmp
''' </summary>
''' <remarks></remarks>
Public Class Report

    Public Sub ReserveLines(ByVal count As Integer)
        If count > (pageHeight - borderBoth - Y) / 25 Then
            CreatePage()
        End If
    End Sub

#Region "global val"

    Private pages As New Collection
    Private pageNum As Integer = 0
    Private printPageNum As Boolean = False
    Private selectPage As Bitmap = New Drawing.Bitmap(1, _
                                                      1, _
                                                      Imaging.PixelFormat.Format16bppRgb555)
    Public ReadOnly Property ClearZoneLines() As Integer
        Get
            Return Math.Floor((pageHeight - borderBoth - Y) / 25)
        End Get
    End Property
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

#End Region

#Region "new()"

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу слева)</param>
    ''' <remarks></remarks>
    Public Sub New(Optional ByRef _printPageNum As Boolean = False)
        printPageNum = _printPageNum
        CreatePage()
    End Sub

    ''' <summary>
    ''' Создание отчета в виде файла bmp
    ''' </summary>
    ''' <param name="borders">Размер полей в мм</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу слева)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal borders As Double, _
                   Optional ByRef _printPageNum As Boolean = False)
        printPageNum = _printPageNum
        borders -= 5
        Dim _borders As Integer = mmToPix(borders)
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
    ''' <param name="borders">Размеры полей в мм (левое, правое, верхнее, нижнее)</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу слева)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal borders() As Double, _
                   Optional ByRef _printPageNum As Boolean = False)
        printPageNum = _printPageNum
        For i = 0 To borders.Length - 1
            borders(i) -= 5
        Next
        Dim _borderLeft As Integer
        Try
            _borderLeft = mmToPix(borders(0))
            If _borderLeft < 0 Then _borderLeft = borderLeft
        Catch ex As Exception
            _borderLeft = borderLeft
        End Try
        Dim _borderRight As Integer
        Try
            _borderRight = mmToPix(borders(1))
            If _borderRight < 0 Then _borderRight = borderRight
        Catch ex As Exception
            _borderRight = borderRight
        End Try
        Dim _borderTop As Integer
        Try
            _borderTop = mmToPix(borders(2))
            If _borderTop < 0 Then _borderTop = borderTop
        Catch ex As Exception
            _borderTop = borderTop
        End Try
        Dim _borderBoth As Integer
        Try
            _borderBoth = mmToPix(borders(3))
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
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу слева)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal format As PageFormat, _
                   Optional ByRef _printPageNum As Boolean = False)
        printPageNum = _printPageNum
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
    ''' <param name="borders">Размер полей в мм</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу слева)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal format As PageFormat, _
                   ByVal borders As Double, _
                   Optional ByRef _printPageNum As Boolean = False)
        printPageNum = _printPageNum
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
        borders -= 5
        Dim _borders As Integer = mmToPix(borders)
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
    ''' <param name="borders">Размеры полей в мм (левое, правое, верхнее, нижнее)</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу слева)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal format As PageFormat, _
                   ByVal borders() As Double, _
                   Optional ByRef _printPageNum As Boolean = False)
        printPageNum = _printPageNum
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
        For i = 0 To borders.Length - 1
            borders(i) -= 5
        Next
        Dim _borderLeft As Integer
        Try
            _borderLeft = mmToPix(borders(0))
            If _borderLeft < 0 Then _borderLeft = borderLeft
        Catch ex As Exception
            _borderLeft = borderLeft
        End Try
        Dim _borderRight As Integer
        Try
            _borderRight = mmToPix(borders(1))
            If _borderRight < 0 Then _borderRight = borderRight
        Catch ex As Exception
            _borderRight = borderRight
        End Try
        Dim _borderTop As Integer
        Try
            _borderTop = mmToPix(borders(2))
            If _borderTop < 0 Then _borderTop = borderTop
        Catch ex As Exception
            _borderTop = borderTop
        End Try
        Dim _borderBoth As Integer
        Try
            _borderBoth = mmToPix(borders(3))
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
    ''' <param name="width">ширина листа в мм</param>
    ''' <param name="height">высота листа в мм</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу слева)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal width As Double, _
                   ByVal height As Double, _
                   Optional ByRef _printPageNum As Boolean = False)
        printPageNum = _printPageNum
        width -= 5
        height -= 5
        If width > 0 Then pageWidth = mmToPix(width)
        If height > 0 Then pageHeight = mmToPix(height)
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
    ''' <param name="width">ширина листа в мм</param>
    ''' <param name="height">высота листа в мм</param>
    ''' <param name="borders">Размер полей в мм</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу слева)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal width As Double, _
                   ByVal height As Double, _
                   ByVal borders As Double, _
                   Optional ByRef _printPageNum As Boolean = False)
        printPageNum = _printPageNum
        width -= 5
        height -= 5
        If width > 0 Then pageWidth = mmToPix(width)
        If height > 0 Then pageHeight = mmToPix(height)
        borders -= 5
        Dim _borders As Integer = mmToPix(borders)
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
    ''' <param name="width">ширина листа в мм</param>
    ''' <param name="height">высота листа в мм</param>
    ''' <param name="borders">Размеры полей в мм (левое, правое, верхнее, нижнее)</param>
    ''' <param name="_printPageNum">Задает необходимость печати номеров страниц (внизу слева)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal width As Double, _
                   ByVal height As Double, _
                   ByVal borders() As Double, _
                   Optional ByRef _printPageNum As Boolean = False)
        printPageNum = _printPageNum
        width -= 5
        height -= 5
        If width > 0 Then pageWidth = mmToPix(width)
        If height > 0 Then pageHeight = mmToPix(height)
        For i = 0 To borders.Length - 1
            borders(i) -= 5
        Next
        Dim _borderLeft As Integer
        Try
            _borderLeft = mmToPix(borders(0))
            If _borderLeft < 0 Then _borderLeft = borderLeft
        Catch ex As Exception
            _borderLeft = borderLeft
        End Try
        Dim _borderRight As Integer
        Try
            _borderRight = mmToPix(borders(1))
            If _borderRight < 0 Then _borderRight = borderRight
        Catch ex As Exception
            _borderRight = borderRight
        End Try
        Dim _borderTop As Integer
        Try
            _borderTop = mmToPix(borders(2))
            If _borderTop < 0 Then _borderTop = borderTop
        Catch ex As Exception
            _borderTop = borderTop
        End Try
        Dim _borderBoth As Integer
        Try
            _borderBoth = mmToPix(borders(3))
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

#Region "Line"

    ''' <summary>
    ''' Запись строки в файл
    ''' </summary>
    ''' <param name="text">Текст для записи</param>
    ''' <remarks></remarks>
    Public Sub Line(ByVal text As String)
        Y = _WriteMultiLine(text, borderLeft, Y, workWidth)
    End Sub

    ''' <summary>
    ''' Запись форматированной строки в файл
    ''' </summary>
    ''' <param name="text">форматированная строка Line</param>
    ''' <remarks></remarks>
    Public Sub Line(ByVal text As Line)
        Y = _WriteMultiLine(text.text, _
                            borderLeft + mmToPix(text.indentLeft), _
                            Y, _
                            workWidth - mmToPix(text.indentLeft) - mmToPix(text.indentRight), _
                            text.indentTop, _
                            text.interval, _
                            text.textAlign, _
                            text.fontLine, _
                            text.fontSize, _
                            text.fontBold)
    End Sub

    ''' <summary>
    ''' Запись нескольких строк в ряд
    ''' </summary>
    ''' <param name="text">массив форматированных строк</param>
    ''' <remarks></remarks>
    Public Sub Line(ByVal text As Line())
        Line(text, New Integer() {})
    End Sub

    ''' <summary>
    ''' Запись нескольких строк в ряд
    ''' </summary>
    ''' <param name="text">массив форматированных строк</param>
    ''' <param name="size">коэффициент длины строки</param>
    ''' <param name="_borderLeft">отступ слева в мм</param>
    ''' <param name="_borderRight">отступ справа в мм</param>
    ''' <remarks></remarks>
    Public Function Line(ByVal text As Line(), _
                         ByVal size As Integer(), _
                         Optional ByVal _borderLeft As Integer = 0, _
                         Optional ByVal _borderRight As Integer = 0) As Integer()
        If text.Length = 0 Then Return New Integer() {}
        _borderLeft = mmToPix(_borderLeft)
        If _borderLeft < 0 Then _borderLeft = 0
        _borderRight = mmToPix(_borderRight)
        If _borderRight < 0 Then _borderRight = 0
        _borderLeft += borderLeft
        _borderRight += borderRight
        Dim linesWeidth As Integer = pageWidth - _borderLeft - _borderRight
        Dim del As Integer = 0
        Dim _size(text.Length) As Integer
        _size(0) = _borderLeft
        _size(text.Length) = linesWeidth + _borderLeft
        For i As Integer = 0 To text.Length - 2
            Try
                del += size(i)
                _size(i + 1) = size(i)
            Catch ex As Exception
                _size(i + 1) = 1
                del += 1
            End Try
        Next
        Try
            del += size(text.Length - 1)
        Catch ex As Exception
            del += 1
        End Try
        For i As Integer = 1 To text.Length - 1
            _size(i) = linesWeidth * _size(i) / del + _size(i - 1)
        Next
        Dim _y As Integer = 0
        For i As Integer = 1 To (text.Length)
            Dim w As Integer = _WriteMultiLine(text(i - 1).text, _
                                               _size(i - 1) + mmToPix(text(i - 1).indentLeft) + 1, _
                                               Y, _
                                               _size(i) - _size(i - 1) - mmToPix(text(i - 1).indentRight) - 2, _
                                               text(i - 1).indentTop, _
                                               text(i - 1).interval, _
                                               text(i - 1).textAlign, _
                                               text(i - 1).fontLine, _
                                               text(i - 1).fontSize, _
                                               text(i - 1).fontBold)
            If _y < workHeight Then _y = w
        Next
        Y = _y
        Return _size
    End Function

    ''' <summary>
    ''' Запись строки с переносом
    ''' </summary>
    ''' <param name="text">текст</param>
    ''' <param name="_x">горизонтальная позиция верхнего левого угла</param>
    ''' <param name="_y">вертикальная позиция верхнего левого угла</param>
    ''' <param name="_width">ширина поля</param>
    ''' <param name="indent">Отступ сверху</param>
    ''' <param name="interval">межстроковый интервал</param>
    ''' <param name="textAlign">Выравнивание текста</param>
    ''' <param name="fontLine">Тип подчеркивания</param>
    ''' <param name="fontSize">Размер шрифта</param>
    ''' <param name="fontBold">Жирный текст</param>
    ''' <returns>вертикальная позиция верхнего левого угла для следующего объекта</returns>
    ''' <remarks></remarks>
    Private Function _WriteMultiLine(ByRef text As String, _
                                     ByVal _x As Integer, _
                                     ByVal _y As Integer, _
                                     ByVal _width As Integer, _
                                     Optional ByVal indent As Single = 0, _
                                     Optional ByVal interval As Single = 1, _
                                     Optional ByVal textAlign As Align = Align.Left, _
                                     Optional ByVal fontLine As StyleLine = StyleLine.None, _
                                     Optional ByVal fontSize As Single = 10, _
                                     Optional ByVal fontBold As Boolean = False) As Integer
        If fontSize < 0 Then fontSize = 0
        Dim font As Font
        If fontBold Then
            font = New Font("Segoe UI", fontSize, FontStyle.Bold)
        Else
            font = New Font("Segoe UI", fontSize, FontStyle.Regular)
        End If
        If indent < 0 Then indent = 0
        If _x > pageWidth - borderRight Or _x < borderLeft Then _x = borderLeft
        If _x + _width > pageWidth - borderRight Then _width = pageWidth - borderRight - _x
        If _width < 0 Then _width = 0
        Dim _heights As Integer = 0
        Using _graph As Drawing.Graphics = Graphics.FromImage(selectPage)
            _heights = _graph.MeasureString(text, font).Height
        End Using
        _y += indent * _heights
        Dim str() As String = New String() {"", ""}
        Dim i = text.Length
        Dim _w As Integer = 0
        Do
            Try
                str(1) = text.Substring(i)
                Do While str(1)(0) = " "
                    str(1) = str(1).Substring(1)
                Loop
            Catch ex As Exception
                str(1) = ""
            End Try
            str(0) = text.Substring(0, i)
            If Not (str(0).EndsWith("0") Or _
                    str(0).EndsWith("1") Or _
                    str(0).EndsWith("2") Or _
                    str(0).EndsWith("3") Or _
                    str(0).EndsWith("4") Or _
                    str(0).EndsWith("5") Or _
                    str(0).EndsWith("6") Or _
                    str(0).EndsWith("7") Or _
                    str(0).EndsWith("8") Or _
                    str(0).EndsWith("9") Or _
                    str(0).EndsWith("   ") Or _
                    str(0).EndsWith(" ") Or _
                    str(0).EndsWith(".") Or _
                    str(0).EndsWith(",") Or _
                    str(0).EndsWith("!") Or _
                    str(0).EndsWith("^") Or _
                    str(0).EndsWith(":") Or _
                    str(0).EndsWith(";") Or _
                    str(0).EndsWith("/") Or _
                    str(0).EndsWith("|") Or _
                    str(0).EndsWith("\") Or _
                    str(0).EndsWith("&") Or _
                    str(0).EndsWith("*") Or _
                    str(0).EndsWith("+") Or _
                    str(0).EndsWith("-")) And str(1).Length > 0 Then
                str(0) &= "-"
            End If
            i -= 1
            Using _graph As Drawing.Graphics = Graphics.FromImage(selectPage)
                _w = _graph.MeasureString(str(0), font).Width
            End Using
        Loop While _w > _width And i >= 0
        Dim _y0 As Integer = 0
        Dim _y1 As Integer = 0
        _y0 = Math.Max(_y, _WriteOneLine(str(0), _x, _y, _width, interval, textAlign, fontLine, fontSize, fontBold))
        If str(1).Length > 0 Then _y1 = Math.Max(_y, _WriteMultiLine(str(1), _x, _y0, _width, 0, interval, textAlign, fontLine, fontSize, fontBold))
        _y = Math.Max(_y0, _y1)
        If _y + interval * _heights + fontSize > pageHeight - borderBoth Then
            CreatePage()
            _y = Y
        End If
        Return _y
    End Function

    ''' <summary>
    ''' Запись строки
    ''' </summary>
    ''' <param name="text">текст</param>
    ''' <param name="_x">горизонтальная позиция верхнего левого угла</param>
    ''' <param name="_y">вертикальная позиция верхнего левого угла</param>
    ''' <param name="_width">ширина поля</param>
    ''' <param name="interval">межстроковый интервал</param>
    ''' <param name="textAlign">Выравнивание текста</param>
    ''' <param name="fontLine">Тип подчеркивания</param>
    ''' <param name="fontSize">Размер шрифта</param>
    ''' <param name="fontBold">Жирный текст</param>
    ''' <param name="bordersControl">Надо ли учитывать проверку размера</param>
    ''' <returns>вертикальная позиция верхнего левого угла для следующего объекта</returns>
    ''' <remarks></remarks>
    Private Function _WriteOneLine(ByRef text As String, _
                                   ByVal _x As Integer, _
                                   ByVal _y As Integer, _
                                   ByVal _width As Integer, _
                                   Optional ByVal interval As Single = 1, _
                                   Optional ByVal textAlign As Align = Align.Left, _
                                   Optional ByVal fontLine As StyleLine = StyleLine.None, _
                                   Optional ByVal fontSize As Single = 10, _
                                   Optional ByVal fontBold As Boolean = False, _
                                   Optional ByVal bordersControl As Boolean = True) As Integer
        If fontSize < 0 Then fontSize = 0
        Dim font As Font
        If fontBold Then
            font = New Font("Segoe UI", fontSize, FontStyle.Bold)
        Else
            font = New Font("Segoe UI", fontSize, FontStyle.Regular)
        End If
        interval -= 1
        If interval < 0 Then interval = 0
        If _x > pageWidth - borderRight Or _x < borderLeft Then _x = borderLeft
        If _x + _width > pageWidth - borderRight Then _width = pageWidth - borderRight - _x
        If _width < 0 Then _width = 0
        Dim _heights As Integer = 0
        Using _graph As Drawing.Graphics = Graphics.FromImage(selectPage)
            _heights = _graph.MeasureString(text & "0g", font).Height
        End Using
        _y += interval * _heights
        If _y + fontSize > pageHeight - borderBoth And bordersControl Then
            CreatePage()
            _y = borderTop + interval * fontSize
        End If
        Using _graph As Drawing.Graphics = Graphics.FromImage(selectPage)
            Dim _widths As Integer = _graph.MeasureString(text, font).Width + 1
            If _widths > _width Then _widths = _width
            If fontLine = StyleLine.FillUnderline Or fontLine = StyleLine.FillUnderlineStrikethrough Then
                Dim _yf As Integer = _y + _heights - 2
                _graph.DrawLine(New Pen(Color.Black), _
                                _x, _yf, _
                                _x + _width, _yf)
            End If
            If text.Length > 0 Then
                Select Case textAlign
                    Case Align.Left
                    Case Align.Center
                        _x += (_width - _widths) / 2
                    Case Align.Right
                        _x += _width - _widths
                End Select
                _graph.DrawString(text, _
                                  font, _
                                  New SolidBrush(Color.Black), _
                                  _x, _y)
                If fontLine = StyleLine.Underline Or fontLine = StyleLine.UnderlineStrikethrough Then
                    Dim _yf As Integer = _y + _heights - 2
                    If Not text.Length > 0 Then _widths = _width
                    _graph.DrawLine(New Pen(Color.Black), _
                                    _x, _yf, _
                                    _x + _widths, _yf)
                End If
                If fontLine = StyleLine.Strikethrough Or fontLine = StyleLine.UnderlineStrikethrough Then
                    Dim _yf As Integer = _y + (_heights / 1.7)
                    _graph.DrawLine(New Pen(Color.Black), _
                                    _x, _yf, _
                                    _x + _widths, _yf)
                End If
            End If
        End Using
        Return (_y + _heights)
    End Function

#End Region

#Region "Table"

    ''' <summary>
    ''' Запись таблицы
    ''' </summary>
    ''' <param name="head">Заголовок таблицы</param>
    ''' <param name="text">Тело таблицы</param>
    ''' <param name="_borderLeft">отступ слева в мм</param>
    ''' <param name="_borderRight">отступ справа в мм</param>
    ''' <remarks></remarks>
    Public Sub Table(ByRef head As Line(), _
                     ByRef text As Collection, _
                     Optional ByVal _borderLeft As Integer = 0, _
                     Optional ByVal _borderRight As Integer = 0)
        Dim _text As Collection = New Collection
        _text.Add(head)
        For Each row In text
            _text.Add(row)
        Next
        Table(_text, New Integer() {}, _borderLeft, _borderRight)
    End Sub

    ''' <summary>
    ''' Запись таблицы
    ''' </summary>
    ''' <param name="head">Заголовок таблицы</param>
    ''' <param name="text">Тело таблицы</param>
    ''' <param name="size">коэффициент размера колонок</param>
    ''' <param name="_borderLeft">отступ слева в мм</param>
    ''' <param name="_borderRight">отступ справа в мм</param>
    ''' <remarks></remarks>
    Public Sub Table(ByRef head As Line(), _
                     ByRef text As Collection, _
                     ByRef size As Integer(), _
                     Optional ByVal _borderLeft As Integer = 0, _
                     Optional ByVal _borderRight As Integer = 0)
        Dim _text As Collection = New Collection
        _text.Add(head)
        For Each row In text
            _text.Add(row)
        Next
        Table(_text, size, _borderLeft, _borderRight)
    End Sub

    ''' <summary>
    ''' Запись таблицы
    ''' </summary>
    ''' <param name="text">Тело таблицы</param>
    ''' <param name="_borderLeft">отступ слева в мм</param>
    ''' <param name="_borderRight">отступ справа в мм</param>
    ''' <remarks></remarks>
    Public Sub Table(ByRef text As Collection, _
                     Optional ByVal _borderLeft As Integer = 0, _
                     Optional ByVal _borderRight As Integer = 0)
        Table(text, New Integer() {}, _borderLeft, _borderRight)
    End Sub

    ''' <summary>
    ''' Запись таблицы
    ''' </summary>
    ''' <param name="text">Тело таблицы</param>
    ''' <param name="size">коэффициент размера колонок</param>
    ''' <param name="_borderLeft">отступ слева в мм</param>
    ''' <param name="_borderRight">отступ справа в мм</param>
    ''' <remarks></remarks>
    Public Sub Table(ByRef text As Collection, _
                     ByRef size As Integer(), _
                     Optional ByVal _borderLeft As Integer = 0, _
                     Optional ByVal _borderRight As Integer = 0)
        Dim _ystart As Integer = Y
        Dim _vertlines As Integer()
        Dim read As Boolean = True
        If text.Count = 0 Then Exit Sub
        Using _graph As Drawing.Graphics = Graphics.FromImage(selectPage)
            _graph.DrawLine(New Pen(Color.Black), _
                                    _borderLeft + borderLeft, _ystart, _
                                    pageWidth - _borderRight - borderRight, _ystart)
        End Using
        For Each row In text
            _ystart = Y
            If read Then

                _vertlines = Line(row, size, _borderLeft, _borderRight)
                read = False
            Else
                Line(row, size, _borderLeft, _borderRight)
            End If
            Using _graph As Drawing.Graphics = Graphics.FromImage(selectPage)
                _graph.DrawLine(New Pen(Color.Black), _
                                _borderLeft + borderLeft, Y - 1, _
                                pageWidth - _borderRight - borderRight, Y - 1)
                If _ystart > Y Then
                    _ystart = borderTop
                    _graph.DrawLine(New Pen(Color.Black), _
                                    _borderLeft + borderLeft, _ystart, _
                                    pageWidth - _borderRight - borderRight, _ystart)
                End If
                For Each col In _vertlines
                    _graph.DrawLine(New Pen(Color.Black), _
                                    col, _ystart, _
                                    col, Y - 1)
                Next
            End Using
        Next
        Using _graph As Drawing.Graphics = Graphics.FromImage(selectPage)
        End Using
    End Sub

    ''' <summary>
    ''' Запись таблицы
    ''' </summary>
    ''' <param name="text">Тело таблицы</param>
    ''' <param name="_borderLeft">отступ слева в мм</param>
    ''' <param name="_borderRight">отступ справа в мм</param>
    ''' <remarks></remarks>
    Public Sub Table(ByRef text As Line(), _
                     Optional ByVal _borderLeft As Integer = 0, _
                     Optional ByVal _borderRight As Integer = 0)
        Dim _text As Collection = New Collection
        _text.Add(text)
        Table(_text, New Integer() {}, _borderLeft, _borderRight)
    End Sub

    ''' <summary>
    ''' Запись таблицы
    ''' </summary>
    ''' <param name="text">Тело таблицы</param>
    ''' <param name="size">коэффициент размера колонок</param>
    ''' <param name="_borderLeft">отступ слева в мм</param>
    ''' <param name="_borderRight">отступ справа в мм</param>
    ''' <remarks></remarks>
    Public Sub Table(ByRef text As Line(), _
                     ByRef size As Integer(), _
                     Optional ByVal _borderLeft As Integer = 0, _
                     Optional ByVal _borderRight As Integer = 0)
        Dim _text As Collection = New Collection
        _text.Add(text)
        Table(_text, size, _borderLeft, _borderRight)
    End Sub

#End Region

    ''' <summary>
    ''' Создание новой страницы
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreatePage()
        savePage()
        pageNum += 1
        selectPage = New Drawing.Bitmap(pageWidth, _
                                        pageHeight, _
                                        Imaging.PixelFormat.Format16bppRgb555)
        Using _graph As Drawing.Graphics = Graphics.FromImage(selectPage)
            _graph.Clear(Color.White)
        End Using
        Using _graph As Drawing.Graphics = Graphics.FromImage(selectPage)
            If printPageNum Then _WriteOneLine(pageNum, borderLeft, pageHeight - borderBoth, workWidth, bordersControl:=False)
        End Using
        Y = borderTop
    End Sub

    ''' <summary>
    ''' Сохранение активного листа
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub savePage()
        If pageNum > 0 And selectPage.Height > 1 Then pages.Add(selectPage)
        selectPage = New Drawing.Bitmap(1, _
                                        1, _
                                        Imaging.PixelFormat.Format16bppRgb555)
    End Sub

    ''' <summary>
    ''' Преобразование миллиметров в пиксели
    ''' коэф = 3,79363
    ''' </summary>
    ''' <param name="mm"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function mmToPix(ByVal mm As Double) As String
        Try
            mm *= 3.79363
            If mm Mod 1 >= 0.5 Then mm += 1
            mmToPix = mm
        Catch ex As Exception
            mmToPix = 0
        End Try
    End Function

    ''' <summary>
    ''' Возврат всех страниц одним объектом
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Show() As Bitmap
        savePage()
        Show = New Bitmap(pageWidth, _
                          pageHeight * pages.Count + pages.Count - 1, _
                          Imaging.PixelFormat.Format16bppRgb555)
        Dim y As Integer = 0
        Using _graph As Drawing.Graphics = Graphics.FromImage(Show)
            For Each page In pages
                _graph.DrawImage(page, 0, y)
                y += pageHeight + 1
            Next
        End Using
    End Function

#Region "save()"

    ''' <summary>
    ''' Сохранение протокола
    ''' </summary>
    ''' <param name="path">относительный путь к файлу</param>
    ''' <param name="name">имя файла</param>
    ''' <remarks></remarks>
    Public Function Save(ByVal path As String, ByVal name As String) As Collection
        savePage()
        Save = New Collection()
        If pages.Count = 0 Then Exit Function
        If path.Length > 0 Then
            If Not System.IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
        End If
        If pages.Count = 1 Then
            Dim page As Bitmap = pages.Item(1)
            page.Save(path & name & ".bmp", Imaging.ImageFormat.Bmp)
            Save.Add(path & name & ".bmp")
            Exit Function
        End If
        Dim n As Integer = 0
        For Each page As Bitmap In pages
            n += 1
            page.Save(path & name & " " & n & ".bmp", Imaging.ImageFormat.Bmp)
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

End Class
