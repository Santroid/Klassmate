Imports System.Data.SqlClient

Public Class RegisterForm
    Public user As User
    '  user = New User
    Private Sub CancelRegisterButton_Click(sender As Object, e As EventArgs) Handles CancelRegisterButton.Click
        'Esconde la pantalla de Registrar y vuelve a la pantalla de Login
        Me.Hide()
        LoginForm.Show()

    End Sub

    Private Sub RegisterButton_Click(sender As Object, e As EventArgs) Handles RegisterButton.Click
        user = New User



        user.Name_User = NameRegisterTextBox.Text
        User.Email_User = EmailRegisterTextBox.Text
        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"
        Dim selectQuery
        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)
        selectQuery = "SELECT * FROM KMProfile WHERE email='" & User.Email_User & "'"

        command = New SqlCommand(selectQuery, connection)
        'abriendo la conexión
        connection.Open()

        Dim insertQuery
        Dim reader As SqlDataReader = command.ExecuteReader
        'determina si ya existe un usuario con ese correo -Santiago
        If reader.HasRows = False Then

            connection.Close()
            'Si el formato de correo no es correcto manda un error -Santiago
            If User.Email_User.Contains("@") = False Then
                EmailErrorLabel.Visible = True
                EmailErrorLabel.Text = "El formato de correo no es correcto!"

            Else

                'si con
                If PasswordRegisterTextBox.Text = Password2RegisterTextBox.Text Then
                    User.Password_User = PasswordRegisterTextBox.Text

                    'Esconde la pantalla de Registrar y muestra la de agregar horarios -Santiago
                    Me.Hide()
                    ScheduleRegisterForm.Show()


                    'declaramos la sentencia de INSERT para insertar a la BD
                    insertQuery = "INSERT INTO KMProfile(name, email, password) values (@name, @email, @Password)"

                    command = New SqlCommand(insertQuery, connection)

                    With command 'le asigna los valores a los espacios en la tabla

                        .Parameters.AddWithValue("@name", User.Name_User)
                        .Parameters.AddWithValue("@email", User.Email_User)
                        .Parameters.AddWithValue("@password", User.Password_User)

                    End With

                    'abriendo la conexión
                    connection.Open()

                    'ejecutamos la consulta
                    command.ExecuteNonQuery()


                    connection.Close()

                    'Aca se usa una variable para guardar el id del usuario
                    'Dim selectQuery

                    'declaramos la sentencia de INSERT para insertar a la BD
                    selectQuery = "SELECT TOP 1 * FROM KMProfile ORDER BY idStudent DESC"

                    command = New SqlCommand(selectQuery, connection)

                    connection.Open()

                    'ejecuta el lector de la base de datos
                    reader = command.ExecuteReader

                    reader.Read()

                    User.Id_User = reader.Item("idStudent")
                    'MsgBox("This is the global variable IdUser" & user.Id_User)



                    connection.Close()

                Else
                    PasswordErrorLabel.Visible = True
                End If
            End If
        Else
            EmailErrorLabel.Visible = True
            EmailErrorLabel.Text = "Ya existe un usuario con el correo ingresado." & vbCrLf & " Por favor utlice un correo diferente."

        End If


    End Sub
End Class