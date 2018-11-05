Public Class Schedule
    Private Id As Integer
    Private Day As String
    Private TimeStart As DateTime
    Private TimeEnd As DateTime
    Private DIndex As Integer

    Public Property Id_Schedule As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            Id = value
        End Set
    End Property

    Public Property Day_Schedule As String
        Get
            Return Day
        End Get
        Set(value As String)
            Day = value
        End Set
    End Property

    Public Property TimeStart_Schedule As DateTime
        Get
            Return TimeStart
        End Get
        Set(value As DateTime)
            TimeStart = value
        End Set
    End Property

    Public Property DIndex_Schedule As Integer
        Get
            Return DIndex
        End Get
        Set(value As Integer)
            DIndex = value
        End Set
    End Property

    Public Property TimeEnd_Schedule As DateTime
        Get
            Return TimeEnd
        End Get
        Set(value As DateTime)
            TimeEnd = value
        End Set
    End Property
End Class
