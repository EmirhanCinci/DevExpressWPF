Public Class HomeWindow
    Private ReadOnly _userItem As UserItem
    Private ReadOnly _httpApiService As IHttpApiService

    Public Sub New(userItem As UserItem)
        InitializeComponent()
        _userItem = userItem
    End Sub

    Public Sub New(userItem As UserItem, httpApiService As IHttpApiService)
        InitializeComponent()
        _userItem = userItem
        _httpApiService = _httpApiService
    End Sub

    Private Sub hamburgerMenu_Loaded(sender As Object, e As RoutedEventArgs)
        Dim accountType = _userItem.AccountType

        If accountType = 1 Then

        ElseIf accountType = 2 Then
            companyButton.Visibility = Visibility.Collapsed
        Else
            companyButton.Visibility = Visibility.Collapsed
            departmentButton.Visibility = Visibility.Collapsed
            personsButton.Visibility = Visibility.Collapsed
            categoryButton.Visibility = Visibility.Collapsed
            currencyButton.Visibility = Visibility.Collapsed
            supplierButton.Visibility = Visibility.Collapsed
        End If
    End Sub

    Private Sub homeButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub companyButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub departmentButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub personsButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub categoryButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub currencyButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub supplierButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
