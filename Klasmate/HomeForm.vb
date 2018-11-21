﻿Imports System.Data.SqlClient

Public Class HomeForm
    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim user As New User
        Dim period As New Period
        ' Dim sch As New ScheduleRegisterForm
        'Dim LUserId As Integer = LoginForm.user.Id_User
        'Dim RUserId As Integer = RegisterForm.user.Id_User
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
        'Try
        '    connection.Open()
        '    'aca se escoge solo el color, nombre del curso, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
        '    Dim strSQL As String = "select s.color, s.nameSubject, sc.day, sc.startTime, sc.endTime, s.idSubject
        '                            from Subject s, KMProfile k, Period p, ActivityHasSchedule a, Schedule sc
        '                            where k.idStudent = p.idStudent
        '                            and p.idPeriod = s.idPeriod
        '                            and k.idStudent =" & LoginForm.user.Id_User & "
        '                            and s.idSubject = a.idSubject
        '                            and a.idSchedule = sc.idSchedule;"

        '    'Dim strSQL As String = "SELECT nameSubject, color FROM Subject"

        '    ' connection.Close()
        '    Dim da As New SqlDataAdapter(strSQL, connection)
        '    Dim ds As New DataSet
        '    da.Fill(ds, strSQL)
        '    CourseDataGridView.DataSource = ds.Tables(0)



        'Catch ex As SqlException
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        'End Try

        'ESTO ES PARA QUE LE PONGA LOS COLORES AL DGV SOLO UNA VEZ Y NO SE REPITA
        Dim dgv As DataGridView = CourseDataGridView

        If ColorCounterLabel.Text <> " " Then
            'le cambia los colores a las celdas de acuerdo a la base de datos

            For i As Integer = 0 To dgv.Rows.Count - 1

                Dim cellColor As String = dgv.Rows(i).Cells(0).Value
                'MsgBox(cellColor)
                dgv.Rows(i).Cells(0).Style.BackColor = Drawing.Color.FromName(cellColor)

            Next
            For i As Integer = 0 To dgv.Rows.Count - 1

                Dim cellColor As String = dgv.Rows(i).Cells(1).Value
                dgv.Rows(i).Cells(0).Value = ""

            Next
            dgv.ClearSelection()

        End If

        'le cambia los colores a las celdas de tareas de acuerdo a la base de datos
        Dim hwdgv As DataGridView = HomeworkDataGridView
        For i As Integer = 0 To hwdgv.Rows.Count - 1

            Dim cellColor As String = hwdgv.Rows(i).Cells(0).Value
            'MsgBox(cellColor)
            hwdgv.Rows(i).Cells(0).Style.BackColor = Drawing.Color.FromName(cellColor)

        Next
        For i As Integer = 0 To hwdgv.Rows.Count - 1

            Dim cellColor As String = hwdgv.Rows(i).Cells(1).Value
            hwdgv.Rows(i).Cells(0).Value = ""

        Next
        hwdgv.ClearSelection()

        'le cambia los colores a las celdas de horario de estudio de acuerdo a la base de datos
        Dim SSdgv As DataGridView = StudSchDataGridView
        For i As Integer = 0 To SSdgv.Rows.Count - 1

            Dim cellColor As String = SSdgv.Rows(i).Cells(0).Value
            'MsgBox(cellColor)
            SSdgv.Rows(i).Cells(0).Style.BackColor = Drawing.Color.FromName(cellColor)

        Next
        For i As Integer = 0 To SSdgv.Rows.Count - 1

            Dim cellColor As String = SSdgv.Rows(i).Cells(1).Value
            SSdgv.Rows(i).Cells(0).Value = ""

        Next
        SSdgv.ClearSelection()

        'le cambia los colores a las celdas de horario de trabajo de acuerdo a la base de datos
        Dim WSdgv As DataGridView = WSDataGridView
        For i As Integer = 0 To WSdgv.Rows.Count - 1

            Dim cellColor As String = WSdgv.Rows(i).Cells(0).Value
            'MsgBox(cellColor)
            WSdgv.Rows(i).Cells(0).Style.BackColor = Drawing.Color.FromName(cellColor)

        Next
        For i As Integer = 0 To WSdgv.Rows.Count - 1

            Dim cellColor As String = WSdgv.Rows(i).Cells(1).Value
            WSdgv.Rows(i).Cells(0).Value = ""

        Next
        WSdgv.ClearSelection()
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
        OptionsHomePanel.Hide()
        EditProfilePanel.Show()

        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"
        Dim selectQuery
        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)

        Connect()

        'declaramos la sentencia de INSERT para insertar a la BD
        selectQuery = "SELECT * FROM KMProfile WHERE idStudent= " & LoginForm.user.Id_User & " "
        command = New SqlCommand(selectQuery, ConnectionBD.Connection)

        'ejecuta el lector de la base de datos
        Dim reader As SqlDataReader = Command.ExecuteReader

        If reader.HasRows Then
            reader.Read()
            Me.NameEditProfileTextBox.Text = reader.Item("name").ToString
            Me.EmailEditProfileTextBox.Text = reader.Item("email").ToString
            Me.PasswordEditProfileTextBox.Text = reader.Item("password").ToString


        End If
        Disconnect()


    End Sub

    Private Function selectQuery() As String
        Throw New NotImplementedException()
    End Function

    Private Sub CancelEditProfileButton_Click(sender As Object, e As EventArgs) Handles CancelEditProfileButton.Click
        'cuando se oprime el boton de cancelar en el panel de editar perfil, se esconde el panel de editar perfil
        EditProfilePanel.Hide()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DdayAddPanelDateTimePicker.ValueChanged

    End Sub

    Private Sub CancelHWAddButton_Click(sender As Object, e As EventArgs) Handles CancelHWAddButton.Click
        'cuando se oprime el boton de cancelar en el panel de agregar tarea, se esconde el panel de agregar tarea
        AddHomeWorkPanel.Hide()
        NameHWAddPanelTextBox.Text = ""
        CoursAddHWPanelComboBox.SelectedIndex = -1
        DdayAddPanelDateTimePicker.Value = Date.Today


    End Sub

    Private Sub HomeworkAddHomeLabel_Click(sender As Object, e As EventArgs) Handles HomeworkAddHomeLabel.Click
        'cuando se oprime la opcion de agregar tarea se despliega el panel de agregar tarea
        AddHomeWorkPanel.Show()
        AddHomePanel.Hide()
    End Sub

    Private Sub ScheduleEditHomeLabel_Click(sender As Object, e As EventArgs) Handles ScheduleEditHomeLabel.Click
        'cuando se oprime la opcion de editar horario se esconde el form de inicio y se muestra el form de editar horarios
        EditScheduleForm.Show()
        OptionsHomePanel.Hide()
    End Sub

    Private Sub TermAddHomeLabel_Click(sender As Object, e As EventArgs) Handles TermAddHomeLabel.Click
        'Esconde el form de inicio y muestra el de agregar horarios
        ScheduleRegisterForm.IdUserLabel.Text = IdUserLabel.Text
        ScheduleRegisterForm.Show()
        AddHomePanel.Hide()
    End Sub

    Private Sub CourseAddHomeLabel_Click(sender As Object, e As EventArgs) Handles CourseAddHomeLabel.Click
        'cuando se oprime la opcion de agregar curso se esconde el form de inicio y se muestra el form de agregar curso
        AddHomePanel.Hide()
        AddCourseForm.Show()
    End Sub

    Private Sub StudyAddHomeLabel_Click(sender As Object, e As EventArgs) Handles StudyAddHomeLabel.Click
        'cuando se oprime la opcion de agregar horario de estudio se esconde el form de inicio y se muestra el form de agregar horario de estudio
        AddHomePanel.Hide()
        AddStudyForm.Show()
    End Sub

    Private Sub WorkAddHomeLabel_Click(sender As Object, e As EventArgs) Handles WorkAddHomeLabel.Click
        'cuando se oprime la opcion de agregar horario de trabajo se esconde el form de inicio y se muestra el form de agregar horario de trabajo
        AddHomePanel.Hide()
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
        LoginForm.HWCounterLabel.Text = "1"

        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"
        Dim insertQuery
        Dim selectQuery
        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)
        ' MsgBox(CoursAddHWPanelComboBox.SelectedItem.ToString)
        '// agarra el idSubject del curso escogido en el combobox
        Dim dgv As DataGridView = CourseDataGridView
        Dim SubColor As String
        For i As Integer = 0 To dgv.Rows.Count - 1
            If dgv.Rows(i).Cells(1).Value = CoursAddHWPanelComboBox.SelectedItem.ToString Then
                Course.IdCourse2 = dgv.Rows(i).Cells(5).Value.ToString

                i = dgv.Rows.Count - 1
            End If

        Next
        Connect()

        'ESTO ES PARA QUE LA TAREA TENGA EL MISMO COLOR QUE EL CURSO
        selectQuery = "SELECT color FROM Subject WHERE idSubject= " & Integer.Parse(Course.IdCourse2) & " "
        command = New SqlCommand(selectQuery, ConnectionBD.Connection)

        'ejecuta el lector de la base de datos
        Dim reader As SqlDataReader = command.ExecuteReader

        reader.Read()
        SubColor = reader.Item("color").ToString
        connection.Close()
        reader.Close()

        'declaramos la sentencia de INSERT para insertar a la BD
        insertQuery = "INSERT INTO Task(nameTask, duedate, idSubject, color) values (@nameTask, @duedate, @idSubject, @color)"

        command = New SqlCommand(insertQuery, connection)
        ' MsgBox(DdayAddPanelDateTimePicker.Value.ToString("dd/MMM/yyyy"))
        With command 'le asigna los valores a los espacios en la tabla

            .Parameters.AddWithValue("@nameTask", NameHWAddPanelTextBox.Text)
            .Parameters.AddWithValue("@duedate", DdayAddPanelDateTimePicker.Value)
            .Parameters.AddWithValue("@idSubject", Course.IdCourse2)
            .Parameters.AddWithValue("@color", SubColor)



        End With

        'abriendo la conexión
        connection.Open()

        'ejecutamos la consulta
        command.ExecuteNonQuery()


        connection.Close()

        MsgBox("Tarea guardada con exito")
        NameHWAddPanelTextBox.Text = ""
        CoursAddHWPanelComboBox.SelectedIndex = -1
        DdayAddPanelDateTimePicker.Value = Date.Today
        AddHomeWorkPanel.Hide()
        connection.Open()
        '///// CARGA LA TABLA DE TAREAS//////
        'aca se escoge solo el color, nombre de la tarea, dia de entregaque le pertenecen al usuario y al mismo periodo
        Dim HWstrSQL As String = "select t.color, t.nameTask, t.duedate, t.idTask
                                    from Subject s, Period p, Task t
                                    where p.idPeriod =" & Integer.Parse(IdPeriodLabel.Text) & "
                                    and p.idPeriod = s.idPeriod
                                    and s.idSubject = t.idSubject
                                    and p.idStudent =" & Integer.Parse(IdUserLabel.Text) & "
                                    ;"
        Dim da2 As New SqlDataAdapter(HWstrSQL, connection)
        Dim ds2 As New DataSet
        'If ColorCounterLabel.Text = " " Then
        Call CType(HomeworkDataGridView.DataSource, DataTable).Rows.Clear()

        da2.Fill(ds2, HWstrSQL)
        HomeworkDataGridView.DataSource = ds2.Tables(0)
        'le cambia los colores a las celdas de tareas de acuerdo a la base de datos
        Dim hwdgv As DataGridView = HomeworkDataGridView
        For i As Integer = 0 To hwdgv.Rows.Count - 1

            Dim cellColor As String = hwdgv.Rows(i).Cells(0).Value
            'MsgBox(cellColor)
            hwdgv.Rows(i).Cells(0).Style.BackColor = Drawing.Color.FromName(cellColor)

        Next
        For i As Integer = 0 To hwdgv.Rows.Count - 1

            Dim cellColor As String = hwdgv.Rows(i).Cells(1).Value
            hwdgv.Rows(i).Cells(0).Value = ""

        Next
        hwdgv.ClearSelection()
        connection.Close()

    End Sub


    Private Sub SaveEditProfileButton_Click(sender As Object, e As EventArgs) Handles SaveEditProfileButton.Click

        Dim connection As SqlConnection
        Dim command As New SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"
        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)

        Dim updateQuery As String
        updateQuery = "UPDATE KMProfile SET name=@name, email=@email, password=@password WHERE idStudent= " & LoginForm.user.Id_User & " "
        command = New SqlCommand(updateQuery, connection)

        With command
            .Parameters.AddWithValue("@name", NameEditProfileTextBox.Text)
            .Parameters.AddWithValue("@email", EmailEditProfileTextBox.Text)
            .Parameters.AddWithValue("@password", PasswordEditProfileTextBox.Text)
        End With


        connection.Open()
        command.ExecuteNonQuery()
        command.Dispose()
        connection.Close()

        MsgBox("Cambios realizados con exito")

    End Sub

    Private Sub DeleteProfileButton_Click(sender As Object, e As EventArgs) Handles DeleteProfileButton.Click

        ConfirmationForm.Show()

    End Sub

    Private Sub AddHomeWorkPanel_VisibleChanged(sender As Object, e As EventArgs) Handles AddHomeWorkPanel.VisibleChanged
        OptionsHomePanel.Hide()
        AddHomeWorkPanel.Left = 210
        AddHomeWorkPanel.Top = 125
        Dim dgv As DataGridView = CourseDataGridView
        'LIMPIA EL COMBOBOX CADA VEZ QUE SE HACE VISIBLE EL PANEL
        If CoursAddHWPanelComboBox.Items.Count > 0 Then
            Dim courseCount As Integer = CoursAddHWPanelComboBox.Items.Count - 1

            While courseCount >= 0
                'CoursAddHWPanelComboBox.SelectedIndex = i
                CoursAddHWPanelComboBox.Items.RemoveAt(courseCount)
                courseCount = courseCount - 1
            End While
        End If
        'VUELVE A LLENAR EL COMBOBOX CADA VEZ QUE SE HACE VISIBLE EL PANEL
        For i As Integer = 0 To dgv.Rows.Count - 1

            Dim Course As String = dgv.Rows(i).Cells(1).Value
            'MsgBox("iteracion " & i)
            'dgv.Rows(i).Cells(1).Style.BackColor = Drawing.Color.FromName(cellColor)
            CoursAddHWPanelComboBox.Items.Add(Course)

        Next

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        OptionsHomePanel.Hide()
    End Sub

    '///////ESTO ES PARA QUE SOLO SALGAN LAS TAREAS SEGUN EL CURSO QUE ESCOGA EL USUARIO//////////////////
    Private Sub CourseDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CourseDataGridView.CellContentClick

        Dim index As String = CourseDataGridView.CurrentRow.Index
        'MsgBox(index.ToString)
        Dim selectedCoursId As Integer = CourseDataGridView.Rows(index).Cells(5).Value
        'MsgBox(selectedCoursId.ToString)

        Connection.Open()
        '///// CARGA LA TABLA DE TAREAS//////
        'aca se escoge solo el color, nombre del curso, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
        Dim HWstrSQL As String = "select t.color, t.nameTask, t.duedate, t.idTask
                                    from Subject s, Period p, Task t
                                    where p.idPeriod =" & Integer.Parse(IdPeriodLabel.Text) & "
                                    and p.idPeriod = s.idPeriod
                                    and s.idSubject = " & selectedCoursId & "
                                    and s.idSubject = t.idSubject
                                    and p.idStudent =" & Integer.Parse(IdUserLabel.Text) & ";"
        Dim da2 As New SqlDataAdapter(HWstrSQL, Connection)
        Dim ds2 As New DataSet
        'If ColorCounterLabel.Text = " " Then
        Call CType(HomeworkDataGridView.DataSource, DataTable).Rows.Clear()
        'End If
        'da2.Fill(ds2, HWstrSQL)
        'HomeworkDataGridView.DataSource = ds2.Tables(0)



        'Dim strSQL As String = "SELECT nameSubject, color FROM Subject"

        ' connection.Close()

        da2.Fill(ds2, HWstrSQL)
        HomeworkDataGridView.DataSource = ds2.Tables(0)
        'le cambia los colores a las celdas de tareas de acuerdo a la base de datos
        Dim hwdgv As DataGridView = HomeworkDataGridView
        For i As Integer = 0 To hwdgv.Rows.Count - 1

            Dim cellColor As String = hwdgv.Rows(i).Cells(0).Value
            'MsgBox(cellColor)
            hwdgv.Rows(i).Cells(0).Style.BackColor = Drawing.Color.FromName(cellColor)

        Next
        For i As Integer = 0 To hwdgv.Rows.Count - 1

            Dim cellColor As String = hwdgv.Rows(i).Cells(1).Value
            hwdgv.Rows(i).Cells(0).Value = ""

        Next
        hwdgv.ClearSelection()
        Connection.Close()

        CleanHWSelButton.Visible = True
    End Sub


    '////ESTO ES PARA QUE CUANDO SE OPRIME EL BOTON DE LIMPIAR LA SELECCION, SE VUELVAN A MOSTRAR TODAS LAS TAREAS/////////////
    Private Sub CleanHWSelButton_Click(sender As Object, e As EventArgs) Handles CleanHWSelButton.Click
        Connection.Open()
        '///// CARGA LA TABLA DE TAREAS//////
        'aca se escoge solo el color, nombre del curso, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
        Dim HWstrSQL As String = "select t.color, t.nameTask, t.duedate, t.idTask
                                    from Subject s, Period p, Task t
                                    where p.idPeriod =" & Integer.Parse(IdPeriodLabel.Text) & "
                                    and p.idPeriod = s.idPeriod
                                    and s.idSubject = t.idSubject
                                    and p.idStudent =" & Integer.Parse(IdUserLabel.Text) & "
                                    ;"
        Dim da2 As New SqlDataAdapter(HWstrSQL, Connection)
        Dim ds2 As New DataSet
        'If ColorCounterLabel.Text = " " Then
        Call CType(HomeworkDataGridView.DataSource, DataTable).Rows.Clear()
        'End If
        'da2.Fill(ds2, HWstrSQL)
        'HomeworkDataGridView.DataSource = ds2.Tables(0)



        'Dim strSQL As String = "SELECT nameSubject, color FROM Subject"

        ' connection.Close()

        da2.Fill(ds2, HWstrSQL)
        HomeworkDataGridView.DataSource = ds2.Tables(0)
        'le cambia los colores a las celdas de tareas de acuerdo a la base de datos
        Dim hwdgv As DataGridView = HomeworkDataGridView
        For i As Integer = 0 To hwdgv.Rows.Count - 1

            Dim cellColor As String = hwdgv.Rows(i).Cells(0).Value
            'MsgBox(cellColor)
            hwdgv.Rows(i).Cells(0).Style.BackColor = Drawing.Color.FromName(cellColor)

        Next
        For i As Integer = 0 To hwdgv.Rows.Count - 1

            Dim cellColor As String = hwdgv.Rows(i).Cells(1).Value
            hwdgv.Rows(i).Cells(0).Value = ""

        Next
        hwdgv.ClearSelection()
        Connection.Close()
        CourseDataGridView.ClearSelection()
        CleanHWSelButton.Visible = False
    End Sub


End Class