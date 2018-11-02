Public Class Schedule
    Private Id As Integer
    Private Day As Day
    Private Time As DateTimeOffset

    Public Property Id_Schedule As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            Id = value
        End Set
    End Property

    Public Property Day_Schedule As Day
        Get
            Return Day
        End Get
        Set(value As Day)
            Day = value
        End Set
    End Property

    Public Property Time_Schedule As DateTimeOffset
        Get
            Return Time
        End Get
        Set(value As DateTimeOffset)
            Time = value
        End Set
    End Property
End Class
