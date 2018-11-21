Module ConnectionBD
    'CON ESTO LOGRAMOS HACER LA CONEXIÓN
    Public StringDao As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"

    Public Connection As New SqlClient.SqlConnection(StringDao)

    Sub Connect()
        If Connection.State = ConnectionState.Closed Then
            Connection.Open()
        End If
    End Sub

    Sub Disconnect()
        If Connection.State = ConnectionState.Open Then
            Connection.Close()
        End If

    End Sub

End Module
