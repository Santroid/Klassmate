﻿Imports Klasmate

Public Class StudySch
    Private Id As Integer
    Private Name As String
    Private Schedule As Schedule
    Private Color As String
    Private Period As Period

    Public Property Id_StudySch As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            Id = value
        End Set
    End Property

    Public Property Name_StudySch As String
        Get
            Return Name
        End Get
        Set(value As String)
            Name = value
        End Set
    End Property

    Public Property Schedule_StudySch As Schedule
        Get
            Return Schedule
        End Get
        Set(value As Schedule)
            Schedule = value
        End Set
    End Property

    Public Property Color_StudySch As String
        Get
            Return Color
        End Get
        Set(value As String)
            Color = value
        End Set
    End Property

    Public Property Period_User As Period
        Get
            Return Period
        End Get
        Set(value As Period)
            Period = value
        End Set
    End Property

End Class
