Public Class ParamValue
    Private _min As Double = Double.MinValue
    Private _max As Double = Double.MaxValue
    Private _fact As Double = 0
    Private _notVisibleVal As Double = 0
    ''' <summary>
    ''' Возвращает и задает минимальное допустимое значение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Min() As Double
        Get
            Return Math.Min(_min, _max)
        End Get
        Set(ByVal value As Double)
            If value <> Nothing Then _min = value
        End Set
    End Property
    ''' <summary>
    ''' Возвращает и задает максимальное допустимое значение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Max() As Double
        Get
            Return Math.Max(_min, _max)
        End Get
        Set(ByVal value As Double)
            If value <> Nothing Then _max = value
        End Set
    End Property
    ''' <summary>
    ''' Возвращает и задает фактическое значение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Fact() As Double
        Get
            Return _fact
        End Get
        Set(ByVal value As Double)
            If value <> Nothing Then _fact = value
        End Set
    End Property
    ''' <summary>
    ''' возвращает и задает значение до которого не отображается фактическое значение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NotVisibleVal() As Double
        Get
            Return _notVisibleVal
        End Get
        Set(ByVal value As Double)
            If value <> Nothing Then _notVisibleVal = value
        End Set
    End Property
    ''' <summary>
    ''' Возвращает входит ли значение в допуск
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Control()
        Get
            Return Min <= Fact And Fact <= Max
        End Get
    End Property
#Region "New"
    ''' <summary>
    ''' Структура значения min..fact..max
    ''' </summary>
    Public Sub New()
    End Sub
    ''' <summary>
    ''' Структура значения min..fact..max
    ''' </summary>
    ''' <param name="factVal">Задает фактическое значение</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal factVal As Double)
        Fact = factVal
    End Sub
    ''' <summary>
    ''' Структура значения min..fact..max
    ''' </summary>
    ''' <param name="minVal">Задает минимально допустимое значение</param>
    ''' <param name="maxVal">Задает максимально допустимое значение</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal minVal As Double, ByVal maxVal As Double)
        Min = minVal
        Max = maxVal
    End Sub
#End Region
End Class
