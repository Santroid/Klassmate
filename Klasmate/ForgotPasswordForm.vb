Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class ForgotPasswordForm
    Private Sub CancelForgotPassButton_Click(sender As Object, e As EventArgs) Handles CancelForgotPassButton.Click
        'Esconde la pantalla de Recuperar contraseña y vuelve a la pantalla de Login
        Me.Hide()
        LoginForm.Show()

    End Sub

    'Genera una contrasena aleatoria para ser enviada al usuario -Santiago
    Public Function makepw() As Object
        Dim e, f, g, h, j As Object
        e = "1234567890abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        f = Len(e)
        g = 8
        Randomize()
        h = ""
        For intstep = 1 To g
            j = Int((f * Rnd()) + 1)
            h = h & Mid(e, j, 1)

        Next
        makepw = h

    End Function


    Private Sub SendNewPassButton_Click(sender As Object, e As EventArgs) Handles SendNewPassButton.Click
        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"
        Dim selectQuery
        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)
        selectQuery = "SELECT * FROM KMProfile WHERE email='" & EmailForgotPassTextBox.Text & "'"

        command = New SqlCommand(selectQuery, connection)
        'abriendo la conexión
        connection.Open()

        Dim insertQuery
        Dim reader As SqlDataReader = command.ExecuteReader
        If reader.HasRows Then

            connection.Close()

            'Se le envia un correo al usuario con la contrasena aleatoria
            Dim RandomPassword As String = makepw()
            Try
                'create the mail message
                Dim mail As New MailMessage()

                'set the addresses
                mail.From = New MailAddress("klassmate.soporte@gmail.com")
                mail.[To].Add(EmailForgotPassTextBox.Text)

                'set the content
                mail.Subject = "Klassmate Soporte | Contraseña de recuperacion"
                mail.Body = "Usted está recibiendo este correo porque se le olvidó su contraseña. La siguiente contraseña es su clave temporal:" & vbCrLf & vbCrLf & RandomPassword & vbCrLf & vbCrLf & "Use esta contraseña para ingresar, luego cambiela a una de su gusto."

                'set the server
                Dim smtp As New SmtpClient("smtp.gmail.com")
                smtp.Port = 587
                smtp.EnableSsl = True
                smtp.Credentials = New System.Net.NetworkCredential("klassmate.soporte@gmail.com", "sajero123")


                'send the message

                smtp.Send(mail)
                MsgBox("Se le ha enviado una contraseña nueva al correo ingresado con exito!")


                'Cambia la contrasena del usuario a la contrasena aleatoria


                'declaramos la sentencia de INSERT para insertar a la BD
                insertQuery = "UPDATE KMProfile SET password=@password WHERE email=@email"

                command = New SqlCommand(insertQuery, connection)

                With command 'le asigna los valores a los espacios en la tabla

                    .Parameters.AddWithValue("@email", EmailForgotPassTextBox.Text)
                    .Parameters.AddWithValue("@password", RandomPassword)
                End With

                'abriendo la conexión
                connection.Open()

                'ejecutamos la consulta
                command.ExecuteNonQuery()

                connection.Dispose()
                connection.Close()

                Me.Close()
                LoginForm.Show()
            Catch exc As Exception
                MsgBox("Send failure: " & exc.ToString())
            End Try
        Else
            MsgBox("No existe una cuenta con el correo ingresado. Por favor asegurese de este escribiendo bien el correo o intentar con un correo diferente")
        End If



    End Sub
End Class