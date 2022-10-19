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
                Try
                    Dim hid As Integer = FindWindow("HHTaskBar", "")
                    ShowWindow(hid, If(value, SW_SHOW, SW_HIDE))
                    EnableWindow(hid, value)
                    _TaskBarShow = Not _TaskBarShow
                Catch ex As Exception

                End Try
            End If
        End Set
    End Property

    Private Structure _form
        Dim TopMost As Boolean
        Dim ControlBox As Boolean
        Dim MaximizeBox As Boolean
        Dim MinimizeBox As Boolean
        Dim FormBorderStyle As System.Windows.Forms.FormBorderStyle
        Dim WindowState As System.Windows.Forms.FormWindowState
        Dim Width As Integer
        Dim Height As Integer
        Dim Left As Integer
        Dim Top As Integer
    End Structure

    Private forms As Dictionary(Of String, _form) = New Dictionary(Of String, _form)

    ''' <summary>
    ''' Отображение формы на весь экран без меню пуск
    ''' </summary>
    ''' <param name="f"></param>
    ''' <remarks></remarks>
    Public Property GAMEMODE_FORM(ByVal f As Form, _
                                  ByVal maxWidth As Integer, _
                                  ByVal maxHeight As Integer) As Boolean
        Get
            Return f.TopMost = True _
            And f.ControlBox = False _
            And f.MaximizeBox = False _
            And f.MinimizeBox = False _
            And f.FormBorderStyle = FormBorderStyle.None _
            And f.WindowState = FormWindowState.Normal _
            And f.Left = (Screen.PrimaryScreen.Bounds.Width - f.Width) / 2 _
            And f.Top = (Screen.PrimaryScreen.Bounds.Height - f.Height) / 2
        End Get
        Set(ByVal value As Boolean)
            If (value) Then
                Dim _f As _form
                _f.TopMost = f.TopMost
                _f.ControlBox = f.ControlBox
                _f.MaximizeBox = f.MaximizeBox
                _f.MinimizeBox = f.MinimizeBox
                _f.FormBorderStyle = f.FormBorderStyle
                _f.WindowState = f.WindowState
                _f.Width = f.Width
                _f.Height = f.Height
                _f.Left = f.Left
                _f.Top = f.Top
                forms(f.Name) = _f

                If maxWidth < 1 Then maxWidth = 1
                If maxHeight < 1 Then maxWidth = 1
                Try
                    TaskBarShow = False
                Catch ex As Exception

                End Try
                Try
                    f.TopMost = True
                Catch ex As Exception

                End Try
                f.ControlBox = False
                f.MaximizeBox = False
                f.MinimizeBox = False
                f.FormBorderStyle = FormBorderStyle.None
                f.WindowState = FormWindowState.Normal
                f.Width = If(Screen.PrimaryScreen.Bounds.Width < maxWidth, Screen.PrimaryScreen.Bounds.Width, maxWidth)
                f.Height = If(Screen.PrimaryScreen.Bounds.Height < maxHeight, Screen.PrimaryScreen.Bounds.Height, maxHeight)
                f.Left = (Screen.PrimaryScreen.Bounds.Width - f.Width) / 2
                f.Top = (Screen.PrimaryScreen.Bounds.Height - f.Height) / 2
            Else
                Try
                    TaskBarShow = True
                Catch ex As Exception

                End Try
                Try
                    f.TopMost = forms(f.Name).TopMost
                Catch ex As Exception
                    f.TopMost = False
                End Try
                Try
                    f.ControlBox = forms(f.Name).ControlBox
                Catch ex As Exception
                    f.ControlBox = False
                End Try
                Try
                    f.MaximizeBox = forms(f.Name).MaximizeBox
                Catch ex As Exception
                    f.MaximizeBox = False
                End Try
                Try
                    f.MinimizeBox = forms(f.Name).MinimizeBox
                Catch ex As Exception
                    f.MinimizeBox = False
                End Try
                Try
                    f.FormBorderStyle = forms(f.Name).FormBorderStyle
                Catch ex As Exception
                    f.FormBorderStyle = FormBorderStyle.None
                End Try
                Try
                    f.WindowState = forms(f.Name).WindowState
                Catch ex As Exception
                    f.WindowState = FormWindowState.Maximized
                End Try
                Try
                    f.Width = forms(f.Name).Width
                Catch ex As Exception
                    f.Width = If(Screen.PrimaryScreen.Bounds.Width < maxWidth, Screen.PrimaryScreen.Bounds.Width, maxWidth)
                End Try
                Try
                    f.Height = forms(f.Name).Height
                Catch ex As Exception
                    f.Height = If(Screen.PrimaryScreen.Bounds.Height < maxHeight, Screen.PrimaryScreen.Bounds.Height, maxHeight)
                End Try
                Try
                    f.Left = forms(f.Name).Left
                Catch ex As Exception
                    f.Left = (Screen.PrimaryScreen.Bounds.Width - f.Width) / 2
                End Try
                Try
                    f.Top = forms(f.Name).Top
                Catch ex As Exception
                    f.Top = (Screen.PrimaryScreen.Bounds.Height - f.Height) / 2
                End Try
                Try
                    forms.Remove(f.Name)
                Catch ex As Exception

                End Try
            End If
        End Set
    End Property

    ''' <summary>
    ''' Отображение формы на весь экран без меню пуск
    ''' </summary>
    ''' <param name="f"></param>
    ''' <remarks></remarks>
    Public Property GAMEMODE_FORM(ByVal f As Form) As Boolean
        Get
            Return GAMEMODE_FORM(f, Integer.MaxValue, Integer.MaxValue)
        End Get
        Set(ByVal value As Boolean)
            GAMEMODE_FORM(f, Integer.MaxValue, Integer.MaxValue) = value
        End Set
    End Property

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
