Imports System.Data.SqlClient

Public Class LoginForm

    Dim command As SqlCommand
    Dim selectQuery
    Public user As User

    Private Sub EmailLoginTextBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailLoginTextBox.Click
        If EmailLoginTextBox.Text = "Correo" Then
            EmailLoginTextBox.Text = ""
        End If
        If PasswordLoginTextBox.Text = "" Then
            PasswordLoginTextBox.Text = "Contraseña"
            PasswordLoginTextBox.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub EmailLoginTextBox_TextChanged(sender As Object, e As EventArgs) Handles EmailLoginTextBox.TextChanged
        If EmailLoginTextBox.Text = "Correo" Then
            EmailLoginTextBox.Font = New Font("Microsoft Sans Serif", 8.0, FontStyle.Italic)
            EmailLoginTextBox.ForeColor = Color.Gray
            EmailLoginTextBox.Text = "Correo"
        Else
            If EmailLoginTextBox.Font.Italic = True Then
                EmailLoginTextBox.Font = New Font("Microsoft Sans Serif", 8.0, FontStyle.Regular)
                EmailLoginTextBox.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub PasswordLoginTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordLoginTextBox.TextChanged
        If PasswordLoginTextBox.Text = "Contraseña" Then
            PasswordLoginTextBox.Font = New Font("Microsoft Sans Serif", 8.0, FontStyle.Italic)
            PasswordLoginTextBox.ForeColor = Color.Gray
            PasswordLoginTextBox.Text = "Contraseña"
            PasswordLoginTextBox.UseSystemPasswordChar = False
        Else
            If PasswordLoginTextBox.Font.Italic = True Then
                PasswordLoginTextBox.Font = New Font("Microsoft Sans Serif", 8.0, FontStyle.Regular)
                PasswordLoginTextBox.ForeColor = Color.Black
                PasswordLoginTextBox.UseSystemPasswordChar = True
            End If
            PasswordLoginTextBox.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub PasswordLoginTextBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasswordLoginTextBox.Click
        If PasswordLoginTextBox.Text = "Contraseña" Then
            PasswordLoginTextBox.Text = ""
            PasswordLoginTextBox.UseSystemPasswordChar = True
        End If
        If EmailLoginTextBox.Text = "" Then
            PasswordLoginTextBox.UseSystemPasswordChar = True
            EmailLoginTextBox.Text = "Correo"
        End If
    End Sub

    Private Sub RegisterLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles RegisterLinkLabel.LinkClicked
        'Esconde la pantalla de Login y muestra la pantalla de Registrar
        Me.Hide()
        RegisterForm.Show()
    End Sub

    Private Sub ForgotPasswordLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ForgotPasswordLinkLabel.LinkClicked
        'Esconde la pantalla de Login y muestra la de Recuperar Contraseña
        Me.Hide()
        ForgotPasswordForm.Show()
    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        user = New User
        user.Email_User = EmailLoginTextBox.Text
        user.Password_User = PasswordLoginTextBox.Text

        Dim period As New Period


        Dim command As SqlCommand

        'CON ESTE TRY-CATCH LOGRAMOS LA CONEXIÓN EVITANDO ESCRIBIR EL STRING MUCHAS VECES -- JEFFREY VALERIO
        Try
            Connect()

            'declaramos la sentencia de INSERT para insertar a la BD
            selectQuery = "SELECT * FROM KMProfile WHERE email='" & user.Email_User & "'" & " AND password='" & user.Password_User & "'"
            command = New SqlCommand(selectQuery, ConnectionBD.Connection)

            'ejecuta el lector de la base de datos
            Dim reader As SqlDataReader = command.ExecuteReader

            If reader.HasRows Then
                reader.Read()

                user.Id_User = reader.Item("idStudent")
                ScheduleRegisterForm.IdUserLabel.Text = user.Id_User
                AddCourseForm.IdUserLabel.Text = user.Id_User
                User.IdUser = reader.Item("idStudent")
                User.IdUser2 = reader.Item("idStudent")
                'MsgBox("This is user.Id_User " & user.Id_User)
                'MsgBox("This is  User.IdUser " & User.IdUser)
                'MsgBox("This is  User.IdUser2 " & User.IdUser)
                If reader.Item("status") = False Then
                    MsgBox("El usuario asociado a ese correo esta inactivo")

                Else
                    reader.Close()
                    'Esconde la pantalla de Login y muestra la de Home
                    Dim selectQuery
                    'Dim command As SqlCommand
                    'Dim getQuery As String

                    'Connection.Open()
                    'Dim reader As SqlDataReader
                    'ESTO ES PARA QUE APARESCA EL NOMBRE DEL PERIODO LECTIVO EN LA PARTE DE ARRIBA
                    'getQuery = "Select namePeriod from Period  where idStudent = " & user.Id_User & " "

                    ' selectQuery = "SELECT TOP 1 * FROM (" & getQuery & ") ORDER BY namePeriod DESC"

                    selectQuery = "
                                    SELECT TOP 1 namePeriod, idPeriod FROM Period
                                    WHERE idStudent = " & user.Id_User & "
                                    ORDER BY idPeriod DESC ;"
                    'selectQuery = "SELECT namePeriod FROM Period WHERE idStudent=" & user.Id_User & " "
                    command = New SqlCommand(selectQuery, Connection)
                    reader = command.ExecuteReader


                    reader.Read()
                    HomeForm.PeriodHomeLabel.Text = reader.Item("namePeriod")
                    period.Id_Period = reader.Item("idPeriod")
                    HomeForm.IdPeriodLabel.Text = reader.Item("idPeriod")
                    AddCourseForm.IdUserLabel.Text = user.Id_User

                    reader.Close()
                    Connection.Close()
                    Try
                        Connection.Open()
                        'aca se escoge solo el color, nombre del curso, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
                        Dim strSQL As String = "select s.color, s.nameSubject, sc.day, sc.startTime, sc.endTime, s.idSubject
                                    from Subject s, KMProfile k, Period p, ActivityHasSchedule a, Schedule sc
                                    where k.idStudent = p.idStudent
                                    and p.idPeriod =" & period.Id_Period & "
                                    and p.idPeriod = s.idPeriod
                                    and k.idStudent =" & user.Id_User & "
                                    and s.idSubject = a.idSubject
                                    and a.idSchedule = sc.idSchedule;"

                        'Dim strSQL As String = "SELECT nameSubject, color FROM Subject"

                        ' connection.Close()
                        Dim da As New SqlDataAdapter(strSQL, Connection)
                        Dim ds As New DataSet
                        da.Fill(ds, strSQL)
                        HomeForm.CourseDataGridView.DataSource = ds.Tables(0)


                        Connection.Close()

                            '///// CARGA LA TABLA DE TAREAS//////
                            Connection.Open()
                            'aca se escoge solo el color, nombre del curso, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
                            Dim HWstrSQL As String = "select t.color, t.nameTask, t.duedate, t.idTask
                                    from Subject s, Period p, Task t
                                    where p.idPeriod =" & period.Id_Period & "
                                    and p.idPeriod = s.idPeriod
                                    and s.idSubject = t.idSubject
                                    and p.idStudent =" & user.Id_User & "
                                    ;"

                            'Dim strSQL As String = "SELECT nameSubject, color FROM Subject"

                            ' connection.Close()
                            Dim da2 As New SqlDataAdapter(HWstrSQL, Connection)
                            Dim ds2 As New DataSet
                            da2.Fill(ds2, HWstrSQL)
                        HomeForm.HomeworkDataGridView.DataSource = ds2.Tables(0)


                    Catch ex As SqlException
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                    End Try
                    Me.Hide()
                    reader.Close()

                    HomeForm.Show()
                    EmailLoginTextBox.Text = "Correo"
                    PasswordLoginTextBox.Text = "Contraseña"
                End If
            Else
                MsgBox("¡Correo o contraseña incorrecta!")
            End If
        Catch ex As SqlException
            MsgBox("No se logró conectar a la base de datos de KlassMate" & ex.Message)
        Finally
            Disconnect()
        End Try

    End Sub

    'Hace lo mismo que el boton aceptar solo que es cuando se oprime enter en el teclado
    Private Sub PasswordLoginTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PasswordLoginTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            user = New User
            user.Email_User = EmailLoginTextBox.Text
            user.Password_User = PasswordLoginTextBox.Text

            Dim period As New Period


            Dim command As SqlCommand

            'CON ESTE TRY-CATCH LOGRAMOS LA CONEXIÓN EVITANDO ESCRIBIR EL STRING MUCHAS VECES -- JEFFREY VALERIO
            Try
                Connect()

                'declaramos la sentencia de INSERT para insertar a la BD
                selectQuery = "SELECT * FROM KMProfile WHERE email='" & user.Email_User & "'" & " AND password='" & user.Password_User & "'"
                command = New SqlCommand(selectQuery, ConnectionBD.Connection)

                'ejecuta el lector de la base de datos
                Dim reader As SqlDataReader = command.ExecuteReader

                If reader.HasRows Then
                    reader.Read()

                    user.Id_User = reader.Item("idStudent")
                    ScheduleRegisterForm.IdUserLabel.Text = user.Id_User
                    HomeForm.IdUserLabel.Text = user.Id_User
                    AddCourseForm.IdUserLabel.Text = user.Id_User
                    User.IdUser = reader.Item("idStudent")
                    User.IdUser2 = reader.Item("idStudent")
                    If reader.Item("status") = False Then
                        MsgBox("El usuario asociado a ese correo esta inactivo")

                    Else
                        reader.Close()
                        Dim selectQuery
                        selectQuery = "SELECT TOP 1 namePeriod, idPeriod
                                       FROM Period
                                       WHERE idStudent = " & user.Id_User & " ORDER BY idPeriod DESC ;"

                        'selectQuery = "SELECT namePeriod FROM Period WHERE idStudent=" & user.Id_User & " "
                        command = New SqlCommand(selectQuery, Connection)
                        reader = command.ExecuteReader


                        reader.Read()
                        HomeForm.PeriodHomeLabel.Text = reader.Item("namePeriod")
                        period.Id_Period = reader.Item("idPeriod")
                        HomeForm.IdPeriodLabel.Text = reader.Item("idPeriod")
                        reader.Close()
                        Connection.Close()

                        Try
                            'Connection.Open()
                            'aca se escoge solo el color, nombre del curso, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
                            Dim strSQL As String = "select s.color, s.nameSubject, sc.day, sc.startTime, sc.endTime, s.idSubject
                                    from Subject s, KMProfile k, Period p, ActivityHasSchedule a, Schedule sc
                                    where k.idStudent = p.idStudent
                                    and p.idPeriod =" & period.Id_Period & "
                                    and p.idPeriod = s.idPeriod
                                    and k.idStudent =" & user.Id_User & "
                                    and s.idSubject = a.idSubject
                                    and a.idSchedule = sc.idSchedule;"

                            'Dim strSQL As String = "SELECT nameSubject, color FROM Subject"

                            ' connection.Close()
                            Dim da As New SqlDataAdapter(strSQL, Connection)
                            Dim ds As New DataSet
                            da.Fill(ds, strSQL)
                            HomeForm.CourseDataGridView.DataSource = ds.Tables(0)

                            Connection.Close()

                            '///// CARGA LA TABLA DE TAREAS//////
                            Connection.Open()
                            'aca se escoge solo el color, nombre del curso, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
                            Dim HWstrSQL As String = "select t.color, t.nameTask, t.duedate, t.idTask
                                    from Subject s, Period p, Task t
                                    where p.idPeriod =" & period.Id_Period & "
                                    and p.idPeriod = s.idPeriod
                                    and s.idSubject = t.idSubject
                                    and p.idStudent =" & user.Id_User & "
                                    ;"

                            'Dim strSQL As String = "SELECT nameSubject, color FROM Subject"

                            ' connection.Close()
                            Dim da2 As New SqlDataAdapter(HWstrSQL, Connection)
                            Dim ds2 As New DataSet
                            da2.Fill(ds2, HWstrSQL)
                            HomeForm.HomeworkDataGridView.DataSource = ds2.Tables(0)

                        Catch ex As SqlException
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                        End Try
                        Me.Hide()
                        reader.Close()
                        'Esconde la pantalla de Login y muestra la de Home
                        Me.Hide()
                    HomeForm.Show()
                    EmailLoginTextBox.Text = "Correo"
                        PasswordLoginTextBox.Text = "Contraseña"
                    End If
                Else
                    MsgBox("¡Correo o contraseña incorrecta!")
                End If
            Catch ex As SqlException
                MsgBox("No se logró conectar a la base de datos de KlassMate" & ex.Message)
            Finally
                Disconnect()
            End Try

        End If
    End Sub

    Private Sub CancelLoginButton_Click(sender As Object, e As EventArgs) Handles CancelLoginButton.Click
        EmailLoginTextBox.Text = "Correo"
        PasswordLoginTextBox.Text = "Contraseña"
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        PasswordLoginTextBox.UseSystemPasswordChar = False
    End Sub

End Class
