﻿Public Class ResponseBody(Of T)
    Public Property Data As T
    Public Property StatusCode As Integer
    Public Property StatusMessage As String
    Public Property ErrorMessages As List(Of String)
End Class
