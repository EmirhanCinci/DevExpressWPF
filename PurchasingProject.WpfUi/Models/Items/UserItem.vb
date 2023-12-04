Public Class UserItem
    Public Property Id As Long
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Email As String
    Public Property Phone As String
    Public Property Token As String
    Public Property AccountType As Integer

    Public ReadOnly Property FullName As String
        Get
            Return $"{FirstName} {LastName}"
        End Get
    End Property
End Class
