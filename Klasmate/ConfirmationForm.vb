Imports System.Data.SqlClient

Public Class ConfirmationForm
    Private Sub ConfirmationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub SiConfirmaButton_Click(sender As Object, e As EventArgs) Handles SiConfirmaButton.Click

        Dim connection As SqlConnection
        Dim command As New SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"
        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)

        Dim updateQuery As String
        updateQuery = "UPDATE KMProfile SET status=@status WHERE idStudent= " & LoginForm.user.Id_User & " "
        command = New SqlCommand(updateQuery, connection)

        With command
            .Parameters.AddWithValue("@status", False)
        End With


        connection.Open()
        command.ExecuteNonQuery()
        command.Dispose()
        connection.Close()
        MsgBox("Perfil borrado")

        Me.Close()
        LoginForm.Show()

    End Sub

    Private Sub NoConfirmaButton_Click(sender As Object, e As EventArgs) Handles NoConfirmaButton.Click

        Me.Hide()

    End Sub
End Class