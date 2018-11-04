Public Class Period
    Private Id As Integer
    Private Name As String
    Private StartDate As Date
    Private EndDate As Date
    Public Shared IdPeriod As Integer
    Public Shared PeriodCounter As Integer

    Public Property Id_Period As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            Id = value
        End Set
    End Property

    Public Property StartDate_Period As Date
        Get
            Return StartDate
        End Get
        Set(value As Date)
            StartDate = value
        End Set
    End Property

    Public Property EndDate_Period As Date
        Get
            Return EndDate
        End Get
        Set(value As Date)
            EndDate = value
        End Set
    End Property

    Public Property Name_Period As String
        Get
            Return Name
        End Get
        Set(value As String)
            Name = value
        End Set
    End Property
End Class
