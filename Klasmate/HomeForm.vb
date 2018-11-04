Imports System.Data.SqlClient

Public Class HomeForm
    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection As SqlConnection
        'Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"
        ' Dim selectQuery
        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)


        ' User.IdUser2
        MsgBox("Second IdUser" & User.IdUser2)
        Try
            connection.Open()
            Dim strSQL As String = "select nameSubject, color
                                    from Subject s, KMProfile k, Period p
                                    where k.idStudent = p.idStudent
                                    and p.idPeriod = s.idPeriod
                                    and k.idStudent = 16;"

            'Dim strSQL As String = "SELECT nameSubject, color FROM Subject"

            ' connection.Close()
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim ds As New DataSet
            da.Fill(ds, strSQL)
            CourseDataGridView.DataSource = ds.Tables(0)



        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try

    End Sub

    Private Sub AddHomeButton_Click(sender As Object, e As EventArgs)
        'Cuando se oprime el boton de agregar (+) se despliega o esconde el panel con las opciones
        If AddHomePanel.Visible = False Then
            AddHomePanel.Show()
            OptionsHomePanel.Hide()
        Else
            AddHomePanel.Hide()
        End If
    End Sub

    Private Sub AddHomePanel_Paint(sender As Object, e As PaintEventArgs) Handles AddHomePanel.Paint

    End Sub

    Private Sub OptionsHomeButton_Click(sender As Object, e As EventArgs)
        'Cuando se oprime el boton de opciones se despliega o esconde el panel con las opciones
        If OptionsHomePanel.Visible = False Then
            OptionsHomePanel.Show()
            AddHomePanel.Hide()
        Else
            OptionsHomePanel.Hide()
        End If
    End Sub

    Private Sub ExitHomeLabel_Click(sender As Object, e As EventArgs) Handles ExitHomeLabel.Click
        'cuando se oprime la opcion de salir se esconde el form de inicio y se muestra el form de login
        Me.Close()
        LoginForm.Show()
    End Sub

    Private Sub ProfileEditHomeLabel_Click(sender As Object, e As EventArgs) Handles ProfileEditHomeLabel.Click
        'cuando se oprime la opcion de editar perfil se despliega el panel de editar perfil
        EditProfilePanel.Show()
    End Sub

    Private Sub CancelEditProfileButton_Click(sender As Object, e As EventArgs) Handles CancelEditProfileButton.Click
        'cuando se oprime el boton de cancelar en el panel de editar perfil, se esconde el panel de editar perfil
        EditProfilePanel.Hide()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DdayAddPanelDateTimePicker.ValueChanged

    End Sub

    Private Sub CancelHWAddButton_Click(sender As Object, e As EventArgs) Handles CancelHWAddButton.Click
        'cuando se oprime el boton de cancelar en el panel de agregar tarea, se esconde el panel de agregar tarea
        AddHomeWorkPanel.Hide()
    End Sub

    Private Sub HomeworkAddHomeLabel_Click(sender As Object, e As EventArgs) Handles HomeworkAddHomeLabel.Click
        'cuando se oprime la opcion de agregar tarea se despliega el panel de agregar tarea
        AddHomeWorkPanel.Show()
    End Sub

    Private Sub ScheduleEditHomeLabel_Click(sender As Object, e As EventArgs) Handles ScheduleEditHomeLabel.Click
        'cuando se oprime la opcion de editar horario se esconde el form de inicio y se muestra el form de editar horarios
        EditScheduleForm.Show()
    End Sub

    Private Sub TermAddHomeLabel_Click(sender As Object, e As EventArgs) Handles TermAddHomeLabel.Click
        'Esconde el form de inicio y muestra el de agregar horarios

        ScheduleRegisterForm.Show()
    End Sub

    Private Sub CourseAddHomeLabel_Click(sender As Object, e As EventArgs) Handles CourseAddHomeLabel.Click
        'cuando se oprime la opcion de agregar curso se esconde el form de inicio y se muestra el form de agregar curso

        AddCourseForm.Show()
    End Sub

    Private Sub StudyAddHomeLabel_Click(sender As Object, e As EventArgs) Handles StudyAddHomeLabel.Click
        'cuando se oprime la opcion de agregar horario de estudio se esconde el form de inicio y se muestra el form de agregar horario de estudio

        AddStudyForm.Show()
    End Sub

    Private Sub WorkAddHomeLabel_Click(sender As Object, e As EventArgs) Handles WorkAddHomeLabel.Click
        'cuando se oprime la opcion de agregar horario de trabajo se esconde el form de inicio y se muestra el form de agregar horario de trabajo

        AddWorkForm.Show()
    End Sub

    Private Sub LineShape3_Click(sender As Object, e As EventArgs) Handles RectangleShape1.Click, LineShape3.Click, LineShape2.Click, LineShape1.Click
        'Cuando se oprime el boton de opciones se despliega o esconde el panel con las opciones
        If OptionsHomePanel.Visible = False Then
            OptionsHomePanel.Show()
            AddHomePanel.Hide()
        Else
            OptionsHomePanel.Hide()
        End If
    End Sub

    Private Sub LineShape8_Click(sender As Object, e As EventArgs) Handles RectangleShape3.Click, LineShape8.Click, LineShape7.Click
        'Cuando se oprime el boton de agregar (+) se despliega o esconde el panel con las opciones
        If AddHomePanel.Visible = False Then
            AddHomePanel.Show()
            OptionsHomePanel.Hide()
        Else
            AddHomePanel.Hide()
        End If
    End Sub

    Private Sub SaveHWAddButton_Click(sender As Object, e As EventArgs) Handles SaveHWAddButton.Click

        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"
        Dim insertQuery
        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)
        'declaramos la sentencia de INSERT para insertar a la BD
        insertQuery = "INSERT INTO Task(nameTask, duedate) values (@nameTask, @duedate)"

        command = New SqlCommand(insertQuery, connection)

        With command 'le asigna los valores a los espacios en la tabla

            .Parameters.AddWithValue("@nameTask", NameHWAddPanelTextBox.Text)
            .Parameters.AddWithValue("@duedate", DdayAddPanelDateTimePicker.Value)



        End With

        'abriendo la conexión
        connection.Open()

        'ejecutamos la consulta
        command.ExecuteNonQuery()

        connection.Dispose()
        connection.Close()

        MsgBox("Tarea guardada con exito")
        AddHomeWorkPanel.Hide()


    End Sub
End Class