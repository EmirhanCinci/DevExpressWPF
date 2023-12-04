Public Class HomeWindow
    Private ReadOnly _userItem As UserItem

    Public Sub New(userItem As UserItem)
        InitializeComponent()
        _userItem = userItem
    End Sub

    Private Sub hamburgerMenu_Loaded(sender As Object, e As RoutedEventArgs)
        Dim accountType = _userItem.AccountType

        If accountType = 1 Then

        ElseIf accountType = 2 Then

        Else

        End If
    End Sub

    Private Sub minimize_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub maximize_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub close_Click(sender As Object, e As RoutedEventArgs)
        Application.Current.Shutdown()
    End Sub
End Class
