Imports System.Text.Json
Imports DevExpress.Xpf.Core

Partial Public Class MainWindow
    Inherits ThemedWindow

    Private ReadOnly _httpApiService As IHttpApiService

    Public Sub New(httpApiService As IHttpApiService)
        _httpApiService = httpApiService
        InitializeComponent()
    End Sub

    ' Açılan ekranı alta alan metot '
    Private Sub minimize_Click(sender As Object, e As RoutedEventArgs)
        WindowState = WindowState.Minimized
    End Sub

    ' Açılan ekranı büyütüp küçülten metot '
    Private Sub maximize_Click(sender As Object, e As RoutedEventArgs)
        If WindowState = WindowState.Normal Then
            WindowState = WindowState.Maximized
        Else
            WindowState = WindowState.Normal
        End If
    End Sub

    ' Uygulamayı kapatan metot '
    Private Sub close_Click(sender As Object, e As RoutedEventArgs)
        Application.Current.Shutdown()
    End Sub

    ' Facebook ile giriş yapılmasını sağlayan metot '
    Private Sub btnFacebook_Click(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Facebook Uygulaması", "Bilgi Mesajı", MessageBoxButton.OK, MessageBoxImage.Information)
    End Sub

    ' Twitter ile giriş yapılmasını sağlayan metot '
    Private Sub btnTwitter_Click(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Twitter Uygulaması", "Bilgi Mesajı", MessageBoxButton.OK, MessageBoxImage.Information)
    End Sub

    ' Github ile giriş yapılmasını sağlayan metot '
    Private Sub btnGithub_Click(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Github Uygulaması", "Bilgi Mesajı", MessageBoxButton.OK, MessageBoxImage.Information)
    End Sub

    ' Email inputuna focus olmasını sağlayan metot '
    Private Sub textEmail_MouseDown(sender As Object, e As MouseButtonEventArgs)
        txtEmail.Focus()
    End Sub

    ' Email inputundaki placeholder'ın yazıp yazmamasını sağlayan metot '
    Private Sub txtEmail_TextChanged(sender As Object, e As TextChangedEventArgs)
        If Not String.IsNullOrEmpty(txtEmail.Text) AndAlso txtEmail.Text.Length > 0 Then
            textEmail.Visibility = Visibility.Collapsed
        Else
            textEmail.Visibility = Visibility.Visible
        End If
    End Sub

    ' Şifre inputuna focus olmasını sağlayan metot '
    Private Sub textPassword_MouseDown(sender As Object, e As MouseButtonEventArgs)
        txtPassword.Focus()
    End Sub

    ' Şifre inputundaki placeholder'ın yazıp yazmamasını sağlayan metot '
    Private Sub txtPassword_PasswordChanged(sender As Object, e As RoutedEventArgs)
        If Not String.IsNullOrEmpty(txtPassword.Password) AndAlso txtPassword.Password.Length > 0 Then
            textPassword.Visibility = Visibility.Collapsed
        Else
            textPassword.Visibility = Visibility.Visible
        End If
    End Sub

    ' Kullanıcının login olmasını sağlayan metot '
    Private Async Sub logInButton_Click(sender As Object, e As RoutedEventArgs)
        If String.IsNullOrEmpty(txtEmail.Text) AndAlso String.IsNullOrEmpty(txtPassword.Password) Then
            MessageBox.Show("Email ve şifre bilgilerinizi eksiksiz giriniz.", "Uyarı Mesajı", MessageBoxButton.OK, MessageBoxImage.Warning)
            Return
        End If
        If String.IsNullOrEmpty(txtEmail.Text) Then
            MessageBox.Show("Email alanı boş bırakılamaz.", "Uyarı Mesajı", MessageBoxButton.OK, MessageBoxImage.Warning)
            Return
        End If
        If String.IsNullOrEmpty(txtPassword.Password) Then
            MessageBox.Show("Şifre alanı boş bırakılamaz.", "Uyarı Mesajı", MessageBoxButton.OK, MessageBoxImage.Warning)
            Return
        End If

        Try
            Dim apiUrl As String = "/Users/Login"
            Dim email As String = txtEmail.Text
            Dim password As String = txtPassword.Password

            Dim loginData As New With {
                .Email = email,
                .Password = password
            }
            Dim jsonData As String = JsonSerializer.Serialize(loginData)

            Dim result = Await _httpApiService.PostDataAsync(Of ResponseBody(Of UserItem))(apiUrl, jsonData)

            If result.StatusCode = 200 Then
                Me.Hide()
                Dim homeWindow As New HomeWindow(result.Data)
                homeWindow.Show()
            Else
                MessageBox.Show("Giriş bilgileriniz eksik veya hatalıdır. Lütfen tekrar deneyiniz.", "Uyarı Mesajı", MessageBoxButton.OKCancel, MessageBoxImage.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Bir hata meydana geldi. Lütfen daha sonra tekrar deneyiniz.", "Hata Mesajı", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    ' Kullanıcının şifresini sıfırlayan metot '
    Private Sub forgotPassword_Click(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Şifremi Unuttum!", "Bilgi Mesajı", MessageBoxButton.YesNo, MessageBoxImage.Information)
    End Sub
End Class