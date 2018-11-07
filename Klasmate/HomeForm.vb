Imports System.Data.SqlClient

Public Class HomeForm
    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection As SqlConnection

        'Dim user As User
        'user = New User
        'user.GetHashCode.
        'Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"
        ' Dim selectQuery
        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)


        ' User.IdUser2
        'MsgBox("Second IdUser" & User.IdUser2)
        '/// aca se agrega el color, nombre del curso, dia, horaInicio y horaFin al DataGridView para que el usuario lo vea en el HomeForm
        Try
            connection.Open()
            'aca se escoge solo el color, nombre del curso, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
            Dim strSQL As String = "select s.color, s.nameSubject, sc.day, sc.startTime, sc.endTime, s.idSubject
                                    from Subject s, KMProfile k, Period p, ActivityHasSchedule a, Schedule sc
                                    where k.idStudent = p.idStudent
                                    and p.idPeriod = s.idPeriod
                                    and k.idStudent =" & LoginForm.user.Id_User & "
                                    and s.idSubject = a.idSubject
                                    and a.idSchedule = sc.idSchedule;"

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


        'le cambia los colores a las celdas de acuerdo a la base de datos
        Dim dgv As DataGridView = CourseDataGridView

        For i As Integer = 0 To dgv.Rows.Count - 2

            Dim cellColor As String = dgv.Rows(i).Cells(0).Value
            'MsgBox(cellColor)
            dgv.Rows(i).Cells(0).Style.BackColor = Drawing.Color.FromName(cellColor)

        Next
        For i As Integer = 0 To dgv.Rows.Count - 2

            Dim cellColor As String = dgv.Rows(i).Cells(1).Value
            dgv.Rows(i).Cells(0).Value = ""

        Next
        dgv.ClearSelection()

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
        insertQuery = "INSERT INTO Task(nameTask, duedate, idSubject) values (@nameTask, @duedate, @idSubject)"

        command = New SqlCommand(insertQuery, connection)
        MsgBox(CoursAddHWPanelComboBox.SelectedItem.ToString)
        '// agarra el idSubject del curso escogido en el combobox
        Dim dgv As DataGridView = CourseDataGridView
        For i As Integer = 0 To dgv.Rows.Count - 2
            If dgv.Rows(i).Cells(1).Value = CoursAddHWPanelComboBox.SelectedItem.ToString Then
                Course.IdCourse2 = dgv.Rows(i).Cells(5).Value

                i = dgv.Rows.Count - 2
            End If


            'MsgBox("iteracion " & i)
            'dgv.Rows(i).Cells(1).Style.BackColor = Drawing.Color.FromName(cellColor)


        Next


        With command 'le asigna los valores a los espacios en la tabla

            .Parameters.AddWithValue("@nameTask", NameHWAddPanelTextBox.Text)
            .Parameters.AddWithValue("@duedate", DdayAddPanelDateTimePicker.Value)
            .Parameters.AddWithValue("@idSubject", Course.IdCourse2)



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



    Private Sub AddHomeWorkPanel_Enter(sender As Object, e As EventArgs) Handles AddHomeWorkPanel.Enter
        Me.CenterToScreen()
        Dim dgv As DataGridView = CourseDataGridView
        For i As Integer = 0 To dgv.Rows.Count - 2

            Dim Course As String = dgv.Rows(i).Cells(1).Value
            'MsgBox("iteracion " & i)
            'dgv.Rows(i).Cells(1).Style.BackColor = Drawing.Color.FromName(cellColor)
            CoursAddHWPanelComboBox.Items.Add(Course)

        Next
    End Sub
End Class
