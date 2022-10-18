Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Module Main

#Region "ShowWindow flag's"
    Private Const SW_HIDE As Integer = 0
    Private Const SW_SHOWNORMAL As Integer = 1
    Private Const SW_NORMAL As Integer = 1
    Private Const SW_SHOWMINIMIZED As Integer = 2
    Private Const SW_SHOWMAXIMIZED As Integer = 3
    Private Const SW_MAXIMIZE As Integer = 3
    Private Const SW_SHOWNOACTIVATE As Integer = 4
    Private Const SW_SHOW As Integer = 5
    Private Const SW_MINIMIZE As Integer = 6
    Private Const SW_SHOWMINNOACTIVE As Integer = 7
    Private Const SW_SHOWNA As Integer = 8
    Private Const SW_RESTORE As Integer = 9
    Private Const SW_SHOWDEFAULT As Integer = 10
    Private Const SW_FORCEMINIMIZE As Integer = 11
    Private Const SW_MAX As Integer = 11
#End Region

    <DllImport("coredll.dll")> _
    Private Function FindWindow(ByVal className As String, ByVal windowName As String) As Integer

    End Function

    <DllImport("coredll.dll", CharSet:=CharSet.Auto)> _
    Private Function ShowWindow(ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Boolean

    End Function

    <DllImport("coredll.dll", CharSet:=CharSet.Auto)> _
    Private Function EnableWindow(ByVal hwnd As Integer, ByVal enabled As Boolean) As Boolean

    End Function

    Private _TaskBarShow As Boolean = True
    ''' <summary>
    ''' Состояние меню пуск
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TaskBarShow() As Boolean
        Get
            Return _TaskBarShow
        End Get
        Set(ByVal value As Boolean)
            If value <> _TaskBarShow Then
                Dim hid As Integer = FindWindow("HHTaskBar", "")
                ShowWindow(hid, If(value, SW_SHOW, SW_HIDE))
                EnableWindow(hid, value)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Отображение формы на весь экран без меню пуск
    ''' </summary>
    ''' <param name="f"></param>
    ''' <remarks></remarks>
    Public Function GAMEMODE_FORM(ByVal f As Form, _
                                  ByVal maxWidth As Integer, _
                                  ByVal maxHeight As Integer) As Boolean
        Try
            If maxWidth < 1 Then maxWidth = 1
            If maxHeight < 1 Then maxWidth = 1
            TaskBarShow = False
            f.ControlBox = False
            f.MaximizeBox = False
            f.MinimizeBox = False
            f.FormBorderStyle = FormBorderStyle.None
            f.WindowState = FormWindowState.Normal
            f.Width = If(Screen.PrimaryScreen.Bounds.Width < maxWidth, Screen.PrimaryScreen.Bounds.Width, maxWidth)
            f.Height = If(Screen.PrimaryScreen.Bounds.Height < maxHeight, Screen.PrimaryScreen.Bounds.Height, maxHeight)
            f.Left = (Screen.PrimaryScreen.Bounds.Width - f.Width) / 2
            f.Top = (Screen.PrimaryScreen.Bounds.Height - f.Height) / 2
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Отображение формы на весь экран без меню пуск
    ''' </summary>
    ''' <param name="f"></param>
    ''' <remarks></remarks>
    Public Function GAMEMODE_FORM(ByVal f As Form) As Boolean
        Return GAMEMODE_FORM(f, Integer.MaxValue, Integer.MaxValue)
    End Function

End Module

''' <summary>
''' Тип переменной
''' </summary>
''' <remarks></remarks>
Public Enum ValueType
    text
    uint
    int
    ureal
    real
    bool
    count
End Enum
