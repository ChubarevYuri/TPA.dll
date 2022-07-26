Imports System.Runtime.InteropServices

Public Module Main

#Region "ShowWindow flag's"
    Public Const SW_HIDE As Integer = 0
    Public Const SW_SHOWNORMAL As Integer = 1
    Public Const SW_NORMAL As Integer = 1
    Public Const SW_SHOWMINIMIZED As Integer = 2
    Public Const SW_SHOWMAXIMIZED As Integer = 3
    Public Const SW_MAXIMIZE As Integer = 3
    Public Const SW_SHOWNOACTIVATE As Integer = 4
    Public Const SW_SHOW As Integer = 5
    Public Const SW_MINIMIZE As Integer = 6
    Public Const SW_SHOWMINNOACTIVE As Integer = 7
    Public Const SW_SHOWNA As Integer = 8
    Public Const SW_RESTORE As Integer = 9
    Public Const SW_SHOWDEFAULT As Integer = 10
    Public Const SW_FORCEMINIMIZE As Integer = 11
    Public Const SW_MAX As Integer = 11
#End Region

    <DllImport("coredll.dll")> _
    Public Function FindWindow(ByVal className As String, ByVal windowName As String) As Integer
    End Function

    <DllImport("coredll.dll", CharSet:=CharSet.Auto)> _
    Public Function ShowWindow(ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Boolean
    End Function

    <DllImport("coredll.dll", CharSet:=CharSet.Auto)> _
    Public Function EnableWindow(ByVal hwnd As Integer, ByVal enabled As Boolean) As Boolean

    End Function

    Public Sub TaskBarHide()
        Dim hid As Integer = FindWindow("HHTaskBar", "")
        ShowWindow(hid, SW_HIDE)
        EnableWindow(hid, False)
    End Sub

    Public Sub TaskBarShow()
        Dim hid As Integer = FindWindow("HHTaskBar", "")
        ShowWindow(hid, SW_SHOW)
        EnableWindow(hid, True)
    End Sub
End Module
