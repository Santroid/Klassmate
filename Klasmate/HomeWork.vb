Imports Klasmate

Public Class HomeWork
    Private Id As Integer
    Private Name As String
    Private DueDate As Date
    Private Course As Course

    Public Property Id_HomeWork As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            Id = value
        End Set
    End Property

    Public Property Name_HomeWork As String
        Get
            Return Name
        End Get
        Set(value As String)
            Name = value
        End Set
    End Property

    Public Property DueDate_HomeWork As Date
        Get
            Return DueDate
        End Get
        Set(value As Date)
            DueDate = value
        End Set
    End Property

    Public Property Course_HomeWork As Course
        Get
            Return Course
        End Get
        Set(value As Course)
            Course = value
        End Set
    End Property
End Class
