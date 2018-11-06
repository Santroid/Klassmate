Module ConnectionBD
    'CON ESTO LOGRAMOS HACER LA CONEXIÓN
    Public StringDao As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"

    Public Connection As New SqlClient.SqlConnection(StringDao)

    Sub Connect()
        If Connection.State = ConnectionState.Open Then
        Else
            Connection.Open()
        End If
    End Sub

    Sub Disconnect()
        Connection.Close()
    End Sub

End Module
