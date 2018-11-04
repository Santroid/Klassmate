Imports Klasmate

Public Class User
    Private Id As Integer
    Private Name As String
    Private Email As String
    Private Password As String
    Private Course As List(Of Course)
    Private WorkSch As WorkSch
    Private StudySch As StudySch

    Public Shared IdUser As Integer
    Public Shared IdUser2 As Integer


    Public Property Id_User As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            Id = value
        End Set
    End Property

    Public Property Name_User As String
        Get
            Return Name
        End Get
        Set(value As String)
            Name = value
        End Set
    End Property

    Public Property Email_User As String
        Get
            Return Email
        End Get
        Set(value As String)
            Email = value
        End Set
    End Property

    Public Property Password_User As String
        Get
            Return Password
        End Get
        Set(value As String)
            Password = value
        End Set
    End Property


    Public Property WorkSch_User As WorkSch
        Get
            Return WorkSch
        End Get
        Set(value As WorkSch)
            WorkSch = value
        End Set
    End Property

    Public Property StudySch_User As StudySch
        Get
            Return StudySch
        End Get
        Set(value As StudySch)
            StudySch = value
        End Set
    End Property

    Public Property Course1 As List(Of Course)
        Get
            Return Course
        End Get
        Set(value As List(Of Course))
            Course = value
        End Set
    End Property
End Class
