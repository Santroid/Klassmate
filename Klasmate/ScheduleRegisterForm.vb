Imports System.Data.SqlClient

Public Class ScheduleRegisterForm

    '/////////////////////////EL BOTON DE TERMINAR////////////////////////////////
    Public Sub SaveSRButton_Click(sender As Object, e As EventArgs) Handles SaveSRButton.Click
        'Cuando el boton de terminar en el Form de agregar horarios despues de registrarse, se esconde eso Form y se muestra la el form de inicio -Santi


        '//////////// AGREGA EL PERIODO LECTIVO A LA BASE DE DATOS -Santi /////////////////
        Dim period As Period
        period = New Period

        Dim user As New User
        User = New User

        period.Name_Period = NamePeriodTextBox.Text
        period.StartDate_Period = StartPeriodRegisterDateTimePicker.Value
        period.EndDate_Period = EndPeriodRegisterDateTimePicker.Value
        ' period.Id_Period = 0

        Dim IdUser As Integer = Integer.Parse(IdUserLabel.Text)
        AddCourseForm.IdUserLabel.Text = IdUser
        Dim sch As Schedule
        sch = New Schedule

        sch.DIndex_Schedule = DayCoursSRCheckedListBox.SelectedIndex

        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"

        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)

        'abriendo la conexión
        connection.Open()

        Dim insertQuery
        Dim selectQuery
        Dim reader As SqlDataReader
        'el if es para que no se agregue el mismo periodo mas de una vez a la base de datos
        'MsgBox("This is before it added the periodo with the finish" & Period.PeriodCounter)
        If Period.PeriodCounter = 0 Then
            HomeForm.PeriodHomeLabel.Text = period.Name_Period
            'declaramos la sentencia de INSERT para insertar a la BD
            insertQuery = "INSERT INTO Period(namePeriod, startDate, endDate, idStudent) values (@namePeriod, @startDate, @endDate, @idStudent)"

            command = New SqlCommand(insertQuery, connection)

            With command 'le asigna los valores a los espacios en la tabla

                .Parameters.AddWithValue("@idStudent", IdUser)
                .Parameters.AddWithValue("@namePeriod", period.Name_Period)
                .Parameters.AddWithValue("@startDate", period.StartDate_Period)
                .Parameters.AddWithValue("@endDate", period.EndDate_Period)

            End With


            'ejecutamos la consulta
            command.ExecuteNonQuery()

            connection.Close()



            'declaramos la sentencia de INSERT para insertar a la BD
            selectQuery = "SELECT TOP 1 * FROM Period ORDER BY idPeriod DESC"

            command = New SqlCommand(selectQuery, connection)

            connection.Open()

            'ejecuta el lector de la base de datos
            reader = command.ExecuteReader

            reader.Read()

            period.Id_Period = reader.Item("idPeriod")
            Period.IdPeriod = reader.Item("idPeriod")
            HomeForm.IdPeriodLabel.Text = reader.Item("idPeriod")
            HomeForm.IdUserLabel.Text = IdUser
            'MsgBox(period.Id_Period)

            connection.Close()

            'Un contador para saber si ya se registro un periodo lectivo
            Period.PeriodCounter = 1
            'MsgBox("This is after it added the periodo with the finish" & Period.PeriodCounter)
            '\\\\\\\\\\\\\\\\\\\ TERMINA DE AGREGAR EL PERIODO LECTIVO A LA BASE DE DATOS \\\\\\\\\\\\\\\\\\\\\\\\\\
        End If

        '////// AGREGA UN CURSO A LA BASE DE DATOS /////////////
        Dim course As Course
        course = New Course

        course.Name_Course = NameCoursSRTextBox.Text
        course.Color_Course = ColorCoursSRComboBox.SelectedItem.ToString

        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)

        'abriendo la conexión
        connection.Open()

        'declaramos la sentencia de INSERT para insertar a la BD
        insertQuery = "INSERT INTO Subject(nameSubject, color, idPeriod ) values (@nameSubject, @color, @idPeriod)"

        command = New SqlCommand(insertQuery, connection)

        With command 'le asigna los valores a los espacios en la tabla


            .Parameters.AddWithValue("@nameSubject", course.Name_Course)
            .Parameters.AddWithValue("@color", course.Color_Course.ToString)
            .Parameters.AddWithValue("@idPeriod", Period.IdPeriod)

        End With


        'ejecutamos la consulta
        command.ExecuteNonQuery()


        connection.Close()
        '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////


        'declaramos la sentencia de INSERT para insertar a la BD
        selectQuery = "SELECT TOP 1 * FROM Subject ORDER BY idSubject DESC"

        command = New SqlCommand(selectQuery, connection)

        connection.Open()

        'ejecuta el lector de la base de datos
        reader = command.ExecuteReader

        reader.Read()

        Course.IdCourse = reader.Item("idSubject")
        'MsgBox("global variable idcourse" & Course.IdCourse)

        connection.Close()

        '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////
        For Each Index In DayCoursSRCheckedListBox.CheckedIndices

            'si Lunes esta marcado
            If Index = 0 Then

                sch.Day_Schedule = "Lunes"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = LIDateTimePicker.Value
                sch.TimeEnd_Schedule = LTDateTimePicker.Value
                ' MsgBox("time of day" & sch.TimeEnd_Schedule.TimeOfDay.ToString)

                'si Martes esta marcado
            ElseIf Index = 1 Then

                sch.Day_Schedule = "Martes"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = KIDateTimePicker.Value
                sch.TimeEnd_Schedule = KTDateTimePicker.Value

                'si miercoles esta marcado
            ElseIf Index = 2 Then
                sch.Day_Schedule = "Miercoles"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = MIDateTimePicker.Value
                sch.TimeEnd_Schedule = MTDateTimePicker.Value

                'si jueves esta marcado
            ElseIf Index = 3 Then
                sch.Day_Schedule = "Jueves"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = JIDateTimePicker.Value
                sch.TimeEnd_Schedule = JTDateTimePicker.Value

                'si viernes esta marcado
            ElseIf Index = 4 Then
                sch.Day_Schedule = "Viernes"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = VIDateTimePicker.Value
                sch.TimeEnd_Schedule = VTDateTimePicker.Value

                'si sabado esta marcado
            ElseIf Index = 5 Then
                sch.Day_Schedule = "Sabado"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = SIDateTimePicker.Value
                sch.TimeEnd_Schedule = STDateTimePicker.Value

                'si domingo esta marcado
            ElseIf Index = 6 Then
                sch.Day_Schedule = "Domingo"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = DIDateTimePicker.Value
                sch.TimeEnd_Schedule = DTDateTimePicker.Value

            End If
            insertQuery = "INSERT INTO Schedule(day, startTime, endTime) values (@day, @startTime, @endTime)"

            command = New SqlCommand(insertQuery, connection)
            connection.Open()

            'MsgBox("This is the global variable after the if " & Period.IdPeriod)
            With command 'le asigna los valores a los espacios en la tabla

                '.Parameters.AddWithValue("@idStudent", User.IdUser)
                .Parameters.AddWithValue("@day", sch.Day_Schedule)
                .Parameters.AddWithValue("@startTime", sch.TimeStart_Schedule.TimeOfDay)
                .Parameters.AddWithValue("@endTime", sch.TimeEnd_Schedule.TimeOfDay)

            End With


            'ejecutamos la consulta
            command.ExecuteNonQuery()


            connection.Close()




            'declaramos la sentencia de INSERT para insertar a la BD
            selectQuery = "SELECT TOP 1 * FROM Schedule ORDER BY idSchedule DESC"

            command = New SqlCommand(selectQuery, connection)

            connection.Open()

            'ejecuta el lector de la base de datos
            reader = command.ExecuteReader

            reader.Read()

            Dim IdSch As Integer = reader.Item("idSchedule")


            connection.Close()

            '// se relaciona con ACTIVITY HAS SCHEDULE
            insertQuery = "INSERT INTO ActivityHasSchedule(idSchedule, idSubject) values (@idSchedule, @idSubject)"

            command = New SqlCommand(insertQuery, connection)
            connection.Open()


            With command 'le asigna los valores a los espacios en la tabla


                .Parameters.AddWithValue("@idSchedule", IdSch)
                .Parameters.AddWithValue("@idSubject", Course.IdCourse)

            End With


            'ejecutamos la consulta
            command.ExecuteNonQuery()

            connection.Close()

        Next


        NameCoursSRTextBox.Clear()
        ColorCoursSRComboBox.SelectedIndex = 0
        ColorCoursSRComboBox.BackColor = Color.AliceBlue
        ' ColorCoursSRComboBox.SelectedItem = Color.AliceBlue
        For index = 0 To DayCoursSRCheckedListBox.Items.Count - 1
            DayCoursSRCheckedListBox.SetItemChecked(index, False)
            DayCoursSRCheckedListBox.SetItemCheckState(index, CheckState.Unchecked)
        Next

        '//LUNES//
        If DayCoursSRCheckedListBox.GetItemCheckState(0) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            LIDateTimePicker.Enabled = True
            LTDateTimePicker.Enabled = True
            LILabel.Enabled = True
            LTLabel.Enabled = True
        Else
            LIDateTimePicker.Value = DefaultDateTimePicker.Value
            LTDateTimePicker.Value = DefaultDateTimePicker.Value
            LIDateTimePicker.Enabled = False
            LTDateTimePicker.Enabled = False
            LILabel.Enabled = False
            LTLabel.Enabled = False
        End If

        '//MARTES//
        If DayCoursSRCheckedListBox.GetItemCheckState(1) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            KIDateTimePicker.Enabled = True
            KTDateTimePicker.Enabled = True
            KILabel.Enabled = True
            KTLabel.Enabled = True
        Else
            KIDateTimePicker.Value = DefaultDateTimePicker.Value
            KTDateTimePicker.Value = DefaultDateTimePicker.Value
            KIDateTimePicker.Enabled = False
            KTDateTimePicker.Enabled = False
            KILabel.Enabled = False
            KTLabel.Enabled = False
        End If

        '//MIERCOLES//
        If DayCoursSRCheckedListBox.GetItemCheckState(2) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            MIDateTimePicker.Enabled = True
            MTDateTimePicker.Enabled = True
            MILabel.Enabled = True
            MTLabel.Enabled = True
        Else
            MIDateTimePicker.Value = DefaultDateTimePicker.Value
            MTDateTimePicker.Value = DefaultDateTimePicker.Value
            MIDateTimePicker.Enabled = False
            MTDateTimePicker.Enabled = False
            MILabel.Enabled = False
            MTLabel.Enabled = False
        End If

        '//JUEVES//
        If DayCoursSRCheckedListBox.GetItemCheckState(3) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            JIDateTimePicker.Enabled = True
            JTDateTimePicker.Enabled = True
            JILabel.Enabled = True
            JTLabel.Enabled = True
        Else
            JIDateTimePicker.Value = DefaultDateTimePicker.Value
            JTDateTimePicker.Value = DefaultDateTimePicker.Value
            JIDateTimePicker.Enabled = False
            JTDateTimePicker.Enabled = False
            JILabel.Enabled = False
            JTLabel.Enabled = False
        End If

        '//VIERNES//
        If DayCoursSRCheckedListBox.GetItemCheckState(4) = CheckState.Checked Then

            '  MsgBox("Monday has been checked")
            VIDateTimePicker.Enabled = True
            VTDateTimePicker.Enabled = True
            VILabel.Enabled = True
            VTLabel.Enabled = True
        Else
            VIDateTimePicker.Value = DefaultDateTimePicker.Value
            VTDateTimePicker.Value = DefaultDateTimePicker.Value
            VIDateTimePicker.Enabled = False
            VTDateTimePicker.Enabled = False
            VILabel.Enabled = False
            VTLabel.Enabled = False
        End If

        '//SABADO//
        If DayCoursSRCheckedListBox.GetItemCheckState(5) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            SIDateTimePicker.Enabled = True
            STDateTimePicker.Enabled = True
            SILabel.Enabled = True
            STLabel.Enabled = True
        Else
            SIDateTimePicker.Value = DefaultDateTimePicker.Value
            STDateTimePicker.Value = DefaultDateTimePicker.Value
            SIDateTimePicker.Enabled = False
            STDateTimePicker.Enabled = False
            SILabel.Enabled = False
            STLabel.Enabled = False
        End If

        '//DOMINGO//
        If DayCoursSRCheckedListBox.GetItemCheckState(6) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            DIDateTimePicker.Enabled = True
            DTDateTimePicker.Enabled = True
            DILabel.Enabled = True
            DTLabel.Enabled = True
        Else
            DIDateTimePicker.Value = DefaultDateTimePicker.Value
            DTDateTimePicker.Value = DefaultDateTimePicker.Value
            DIDateTimePicker.Enabled = False
            DTDateTimePicker.Enabled = False
            DILabel.Enabled = False
            DTLabel.Enabled = False
        End If
        '\\\\\\\\\ TERMINA DE AGREGAR UN CURSO A LA BASE DE DATOS \\\\\\\\\\\\

        Try
            connection.Open()
            'aca se escoge solo el color, nombre del curso, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
            Dim strSQL As String = "select s.color, s.nameSubject, sc.day, sc.startTime, sc.endTime, s.idSubject
                                    from Subject s, KMProfile k, Period p, ActivityHasSchedule a, Schedule sc
                                    where k.idStudent = p.idStudent
                                    and p.idPeriod =" & Period.IdPeriod & "
                                    and p.idPeriod = s.idPeriod
                                    and k.idStudent =" & IdUser & "
                                    and s.idSubject = a.idSubject
                                    and a.idSchedule = sc.idSchedule;"

            'Dim strSQL As String = "SELECT nameSubject, color FROM Subject"

            ' connection.Close()
            HomeForm.Show()

            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim ds As New DataSet
            If HomeForm.ColorCounterLabel.Text = " " Then
                Call CType(HomeForm.CourseDataGridView.DataSource, DataTable).Rows.Clear()
            End If
            da.Fill(ds, strSQL)
            HomeForm.CourseDataGridView.DataSource = ds.Tables(0)

            'le cambia los colores a las celdas de acuerdo a la base de datos
            Dim dgv As DataGridView = HomeForm.CourseDataGridView

            For i As Integer = 0 To dgv.Rows.Count - 1

                Dim cellColor As String = dgv.Rows(i).Cells(0).Value
                'MsgBox(cellColor)
                dgv.Rows(i).Cells(0).Style.BackColor = Color.FromName(cellColor)

            Next
            For i As Integer = 0 To dgv.Rows.Count - 1

                'Dim cellColor As String = dgv.Rows(i).Cells(1).Value
                dgv.Rows(i).Cells(0).Value = ""

            Next
            dgv.ClearSelection()
            HomeForm.ColorCounterLabel.Text = " "

            '///////////// ACTUALIZA LA TABLA DE HORARIO DE ESTUDIO
            'aca se escoge solo el color, nombre del horario de estudio, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
            Dim SSstrSQL As String = "select ac.color, ac.name, sc.day, sc.startTime, sc.endTime, ac.idActivity
                                    from Activity ac, KMProfile k, Period p, ActivityHasSchedule a, Schedule sc
                                    where k.idStudent = p.idStudent
                                    and p.idPeriod =" & Period.IdPeriod & "
                                    and ac.idPeriod = p.idPeriod
                                    and k.idStudent = ac.idStudent
                                    and k.idStudent =" & IdUser & "
                                    and ac.idActivity = a.idActivity
                                    and a.idSchedule = sc.idSchedule
                                    and ac.type = " & 0 & ";"

            'Dim strSQL As String = "SELECT nameSubject, color FROM Subject"

            ' connection.Close()
            Dim da3 As New SqlDataAdapter(SSstrSQL, connection)
            Dim ds3 As New DataSet
            Call CType(HomeForm.StudSchDataGridView.DataSource, DataTable).Rows.Clear()
            da3.Fill(ds3, SSstrSQL)
            HomeForm.StudSchDataGridView.DataSource = ds3.Tables(0)


            'le cambia los colores a las celdas de horario de estudio de acuerdo a la base de datos
            Dim SSdgv As DataGridView = HomeForm.StudSchDataGridView
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

            '///////////// ACTUALIZA LA TABLA DE TAREAS
            'aca se escoge solo el color, nombre de la tarea, dia de entregaque le pertenecen al usuario y al mismo periodo
            Dim HWstrSQL As String = "select t.color, t.nameTask, t.duedate, t.idTask
                                    from Subject s, Period p, Task t
                                    where p.idPeriod =" & Period.IdPeriod & "
                                    and p.idPeriod = s.idPeriod
                                    and s.idSubject = t.idSubject
                                    and p.idStudent =" & IdUser & "
                                    and t.status = " & 1 & ";"
            Dim da2 As New SqlDataAdapter(HWstrSQL, connection)
            Dim ds2 As New DataSet
            'If ColorCounterLabel.Text = " " Then
            Call CType(HomeForm.HomeworkDataGridView.DataSource, DataTable).Rows.Clear()

            da2.Fill(ds2, HWstrSQL)
            HomeForm.HomeworkDataGridView.DataSource = ds2.Tables(0)
            'le cambia los colores a las celdas de tareas de acuerdo a la base de datos
            Dim hwdgv As DataGridView = HomeForm.HomeworkDataGridView
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


            Me.Close()



        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try

    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ TERMINA EL BOTON DE TERMINAR \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


    '////////////////// Para agregarle colores al combobox de color cuando se agrega un curso //////////////////////
    Private Sub ScheduleRegisterForm_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load
        'Un contador para saber si ya se registro un periodo lectivo
        Period.PeriodCounter = 0
        'MsgBox("This is the periodocounter at load " & Period.PeriodCounter)
        Dim knownColors = System.Enum.GetNames(GetType(KnownColor)).
            Where(Function(kc) GetType(SystemColors).GetProperty(kc) Is Nothing _
            AndAlso kc <> KnownColor.Transparent.ToString()).
            OrderBy(Function(kc) kc)

        With ColorCoursSRComboBox
            .DrawMode = DrawMode.OwnerDrawFixed
            .IntegralHeight = False
            .MaxDropDownItems = 8
            .DataSource = knownColors.ToList
            .SelectedIndex = 0
            .SelectedItem = Color.AliceBlue

        End With

    End Sub


    '///////// Hace que se vean los colores como opciones en el combobox de curso -Santi ///////////////////////////////
    Private Sub ColorCoursSRComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) _
        Handles ColorCoursSRComboBox.DrawItem
        Dim myComboBox As ComboBox = CType(sender, ComboBox)
        Dim mySelectedColor As Color = Color.FromName(myComboBox.Items(e.Index).ToString)
        Dim myRectangleSize As Integer = e.Bounds.Height - 3

        e.DrawBackground()

        Using myBrush As New SolidBrush(e.ForeColor)
            Using mySelectedBrush As New SolidBrush(mySelectedColor)
                e.Graphics.FillRectangle(mySelectedBrush,
                                        e.Bounds.Left + 5,
                                        e.Bounds.Top + 2,
                                        70,
                                        myRectangleSize)
                e.Graphics.DrawRectangle(New Pen(Brushes.Black),
                                        e.Bounds.Left + 5,
                                        e.Bounds.Top + 2,
                                        70,
                                        myRectangleSize)
            End Using
        End Using

    End Sub

    'Cambia el color del fondo del combobox al color escogido de curso -Santi
    Private Sub ColorCoursSRComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorCoursSRComboBox.SelectedIndexChanged
        If ColorCoursSRComboBox.SelectedIndex <> -1 Then

            ColorCoursSRComboBox.BackColor = Color.FromName(ColorCoursSRComboBox.SelectedItem.ToString)
            'ColorCoursSRComboBox.SelectedText = ""
            ' Else
            '    ColorCoursSRComboBox.BackColor = Color.FromName(ColorCoursSRComboBox.SelectedItem.ToString)
        End If
    End Sub

    'Termina de agregarle colores al combobox de color cuando se agrega un curso -Santi
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


    '////// AGREGA UN CURSO A LA BASE DE DATOS Y LIMPIA LOS CAMPOS PARA AGREGAR OTRO /////////////
    Private Sub AddCoursSRButton_Click(sender As Object, e As EventArgs) Handles AddCoursSRButton.Click
        Dim user As New User

        Dim course As Course
        course = New Course


        course.Name_Course = NameCoursSRTextBox.Text
        course.Color_Course = ColorCoursSRComboBox.SelectedItem.ToString

        Dim period As Period
        period = New Period

        period.Name_Period = NamePeriodTextBox.Text
        period.StartDate_Period = StartPeriodRegisterDateTimePicker.Value
        period.EndDate_Period = EndPeriodRegisterDateTimePicker.Value
        period.Id_Period = 0

        Dim sch As Schedule
        sch = New Schedule

        sch.DIndex_Schedule = DayCoursSRCheckedListBox.SelectedIndex
        'sch.TimeStart_Schedule = 

        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"


        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)

        'abriendo la conexión
        Dim IdUser As Integer = Integer.Parse(IdUserLabel.Text)

        Dim insertQuery
        Dim selectQuery
        Dim reader As SqlDataReader '= command.ExecuteReader

        ' MsgBox("This is before it added the periodo with the plus" & Period.PeriodCounter)
        'el if es para que no se agregue el mismo periodo mas de una vez a la base de datos
        If Period.PeriodCounter = 0 Then
            HomeForm.PeriodHomeLabel.Text = period.Name_Period
            connection.Open()
            'declaramos la sentencia de INSERT para insertar a la BD
            insertQuery = "INSERT INTO Period(namePeriod, startDate, endDate, idStudent) values (@namePeriod, @startDate, @endDate, @idStudent)"

            command = New SqlCommand(insertQuery, connection)

            With command 'le asigna los valores a los espacios en la tabla

                .Parameters.AddWithValue("@idStudent", IdUser)
                .Parameters.AddWithValue("@namePeriod", period.Name_Period)
                .Parameters.AddWithValue("@startDate", period.StartDate_Period)
                .Parameters.AddWithValue("@endDate", period.EndDate_Period)

            End With


            'ejecutamos la consulta
            command.ExecuteNonQuery()

            connection.Close()

            ' Dim selectQuery

            'declaramos la sentencia de INSERT para insertar a la BD
            selectQuery = "SELECT TOP 1 * FROM Period ORDER BY idPeriod DESC"

            command = New SqlCommand(selectQuery, connection)

            connection.Open()

            'ejecuta el lector de la base de datos
            reader = command.ExecuteReader

            reader.Read()

            period.Id_Period = reader.Item("idPeriod")
            Period.IdPeriod = reader.Item("idPeriod")
            HomeForm.IdPeriodLabel.Text = reader.Item("idPeriod")
            HomeForm.IdUserLabel.Text = IdUser
            'MsgBox(period.Id_Period)
            ' MsgBox("This is the global variable " & Period.IdPeriod)

            connection.Close()

            'Un contador para saber si ya se registro un periodo lectivo
            Period.PeriodCounter = 1
            ' MsgBox("This is after it added the periodo with the plus" & Period.PeriodCounter)
            '\\\\\\\\\\\\\\\\\\\ TERMINA DE AGREGAR EL PERIODO LECTIVO A LA BASE DE DATOS \\\\\\\\\\\\\\\\\\\\\\\\\\
        End If


        'declaramos la sentencia de INSERT para insertar a la BD
        insertQuery = "INSERT INTO Subject(nameSubject, color, idPeriod) values (@nameSubject, @color, @idPeriod)"

        command = New SqlCommand(insertQuery, connection)
        connection.Open()

        ' MsgBox("This is the global variable after the if " & Period.IdPeriod)
        With command 'le asigna los valores a los espacios en la tabla

            '.Parameters.AddWithValue("@idStudent", User.IdUser)
            .Parameters.AddWithValue("@nameSubject", course.Name_Course)
            .Parameters.AddWithValue("@color", course.Color_Course.ToString)
            .Parameters.AddWithValue("@idPeriod", Period.IdPeriod)

        End With


        'ejecutamos la consulta
        command.ExecuteNonQuery()


        connection.Close()

        '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////


        'declaramos la sentencia de INSERT para insertar a la BD
        selectQuery = "SELECT TOP 1 * FROM Subject ORDER BY idSubject DESC"

        command = New SqlCommand(selectQuery, connection)

        connection.Open()

        'ejecuta el lector de la base de datos
        reader = command.ExecuteReader

        reader.Read()

        Course.IdCourse = reader.Item("idSubject")
        'MsgBox("global variable idcourse" & Course.IdCourse)

        connection.Close()

        '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////
        For Each Index In DayCoursSRCheckedListBox.CheckedIndices

            'si Lunes esta marcado
            If Index = 0 Then

                sch.Day_Schedule = "Lunes"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = LIDateTimePicker.Value
                sch.TimeEnd_Schedule = LTDateTimePicker.Value
                ' MsgBox("time of day" & sch.TimeEnd_Schedule.TimeOfDay.ToString)

                'si Martes esta marcado
            ElseIf Index = 1 Then

                sch.Day_Schedule = "Martes"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = KIDateTimePicker.Value
                sch.TimeEnd_Schedule = KTDateTimePicker.Value

                'si miercoles esta marcado
            ElseIf Index = 2 Then
                sch.Day_Schedule = "Miercoles"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = MIDateTimePicker.Value
                sch.TimeEnd_Schedule = MTDateTimePicker.Value

                'si jueves esta marcado
            ElseIf Index = 3 Then
                sch.Day_Schedule = "Jueves"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = JIDateTimePicker.Value
                sch.TimeEnd_Schedule = JTDateTimePicker.Value

                'si viernes esta marcado
            ElseIf Index = 4 Then
                sch.Day_Schedule = "Viernes"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = VIDateTimePicker.Value
                sch.TimeEnd_Schedule = VTDateTimePicker.Value

                'si sabado esta marcado
            ElseIf Index = 5 Then
                sch.Day_Schedule = "Sabado"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = SIDateTimePicker.Value
                sch.TimeEnd_Schedule = STDateTimePicker.Value

                'si domingo esta marcado
            ElseIf Index = 6 Then
                sch.Day_Schedule = "Domingo"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = DIDateTimePicker.Value
                sch.TimeEnd_Schedule = DTDateTimePicker.Value

            End If
            insertQuery = "INSERT INTO Schedule(day, startTime, endTime) values (@day, @startTime, @endTime)"

            command = New SqlCommand(insertQuery, connection)
            connection.Open()

            'MsgBox("This is the global variable after the if " & Period.IdPeriod)
            With command 'le asigna los valores a los espacios en la tabla

                '.Parameters.AddWithValue("@idStudent", User.IdUser)
                .Parameters.AddWithValue("@day", sch.Day_Schedule)
                .Parameters.AddWithValue("@startTime", sch.TimeStart_Schedule.TimeOfDay)
                .Parameters.AddWithValue("@endTime", sch.TimeEnd_Schedule.TimeOfDay)

            End With


            'ejecutamos la consulta
            command.ExecuteNonQuery()


            connection.Close()




            'declaramos la sentencia de INSERT para insertar a la BD
            selectQuery = "SELECT TOP 1 * FROM Schedule ORDER BY idSchedule DESC"

            command = New SqlCommand(selectQuery, connection)

            connection.Open()

            'ejecuta el lector de la base de datos
            reader = command.ExecuteReader

            reader.Read()

            Dim IdSch As Integer = reader.Item("idSchedule")


            connection.Close()

            '// se relaciona con ACTIVITY HAS SCHEDULE
            insertQuery = "INSERT INTO ActivityHasSchedule(idSchedule, idSubject) values (@idSchedule, @idSubject)"

            command = New SqlCommand(insertQuery, connection)
            connection.Open()


            With command 'le asigna los valores a los espacios en la tabla


                .Parameters.AddWithValue("@idSchedule", IdSch)
                .Parameters.AddWithValue("@idSubject", Course.IdCourse)

            End With


            'ejecutamos la consulta
            command.ExecuteNonQuery()

            connection.Close()

        Next


        NameCoursSRTextBox.Clear()
        ColorCoursSRComboBox.SelectedIndex = 0
        ColorCoursSRComboBox.BackColor = Color.AliceBlue
        'ColorCoursSRComboBox.SelectedItem = Color.AliceBlue
        For index = 0 To DayCoursSRCheckedListBox.Items.Count - 1
            DayCoursSRCheckedListBox.SetItemChecked(index, False)
            DayCoursSRCheckedListBox.SetItemCheckState(index, CheckState.Unchecked)
        Next

        '//LUNES//
        If DayCoursSRCheckedListBox.GetItemCheckState(0) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            LIDateTimePicker.Enabled = True
            LTDateTimePicker.Enabled = True
            LILabel.Enabled = True
            LTLabel.Enabled = True
        Else
            LIDateTimePicker.Value = DefaultDateTimePicker.Value
            LTDateTimePicker.Value = DefaultDateTimePicker.Value
            LIDateTimePicker.Enabled = False
            LTDateTimePicker.Enabled = False
            LILabel.Enabled = False
            LTLabel.Enabled = False
        End If

        '//MARTES//
        If DayCoursSRCheckedListBox.GetItemCheckState(1) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            KIDateTimePicker.Enabled = True
            KTDateTimePicker.Enabled = True
            KILabel.Enabled = True
            KTLabel.Enabled = True
        Else
            KIDateTimePicker.Value = DefaultDateTimePicker.Value
            KTDateTimePicker.Value = DefaultDateTimePicker.Value
            KIDateTimePicker.Enabled = False
            KTDateTimePicker.Enabled = False
            KILabel.Enabled = False
            KTLabel.Enabled = False
        End If

        '//MIERCOLES//
        If DayCoursSRCheckedListBox.GetItemCheckState(2) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            MIDateTimePicker.Enabled = True
            MTDateTimePicker.Enabled = True
            MILabel.Enabled = True
            MTLabel.Enabled = True
        Else
            MIDateTimePicker.Value = DefaultDateTimePicker.Value
            MTDateTimePicker.Value = DefaultDateTimePicker.Value
            MIDateTimePicker.Enabled = False
            MTDateTimePicker.Enabled = False
            MILabel.Enabled = False
            MTLabel.Enabled = False
        End If

        '//JUEVES//
        If DayCoursSRCheckedListBox.GetItemCheckState(3) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            JIDateTimePicker.Enabled = True
            JTDateTimePicker.Enabled = True
            JILabel.Enabled = True
            JTLabel.Enabled = True
        Else
            JIDateTimePicker.Value = DefaultDateTimePicker.Value
            JTDateTimePicker.Value = DefaultDateTimePicker.Value
            JIDateTimePicker.Enabled = False
            JTDateTimePicker.Enabled = False
            JILabel.Enabled = False
            JTLabel.Enabled = False
        End If

        '//VIERNES//
        If DayCoursSRCheckedListBox.GetItemCheckState(4) = CheckState.Checked Then

            '  MsgBox("Monday has been checked")
            VIDateTimePicker.Enabled = True
            VTDateTimePicker.Enabled = True
            VILabel.Enabled = True
            VTLabel.Enabled = True
        Else
            VIDateTimePicker.Value = DefaultDateTimePicker.Value
            VTDateTimePicker.Value = DefaultDateTimePicker.Value
            VIDateTimePicker.Enabled = False
            VTDateTimePicker.Enabled = False
            VILabel.Enabled = False
            VTLabel.Enabled = False
        End If

        '//SABADO//
        If DayCoursSRCheckedListBox.GetItemCheckState(5) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            SIDateTimePicker.Enabled = True
            STDateTimePicker.Enabled = True
            SILabel.Enabled = True
            STLabel.Enabled = True
        Else
            SIDateTimePicker.Value = DefaultDateTimePicker.Value
            STDateTimePicker.Value = DefaultDateTimePicker.Value
            SIDateTimePicker.Enabled = False
            STDateTimePicker.Enabled = False
            SILabel.Enabled = False
            STLabel.Enabled = False
        End If

        '//DOMINGO//
        If DayCoursSRCheckedListBox.GetItemCheckState(6) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            DIDateTimePicker.Enabled = True
            DTDateTimePicker.Enabled = True
            DILabel.Enabled = True
            DTLabel.Enabled = True
        Else
            DIDateTimePicker.Value = DefaultDateTimePicker.Value
            DTDateTimePicker.Value = DefaultDateTimePicker.Value
            DIDateTimePicker.Enabled = False
            DTDateTimePicker.Enabled = False
            DILabel.Enabled = False
            DTLabel.Enabled = False
        End If

        MsgBox("Curso guardado con exito.")
        '\\\\\\\\\ TERMINA DE AGREGAR UN CURSO A LA BASE DE DATOS Y LIMPIA LOS CAMPOS PARA AGREGAR OTRO \\\\\\\\\\\\
    End Sub



    '///////// Determina si se escogio un dia y se habilita la hora /////////////
    Private Sub DayCoursSRCheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DayCoursSRCheckedListBox.SelectedIndexChanged
        '//LUNES//
        If DayCoursSRCheckedListBox.GetItemCheckState(0) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            LIDateTimePicker.Enabled = True
            LTDateTimePicker.Enabled = True
            LILabel.Enabled = True
            LTLabel.Enabled = True
        Else
            LIDateTimePicker.Enabled = False
            LTDateTimePicker.Enabled = False
            LILabel.Enabled = False
            LTLabel.Enabled = False
        End If

        '//MARTES//
        If DayCoursSRCheckedListBox.GetItemCheckState(1) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            KIDateTimePicker.Enabled = True
            KTDateTimePicker.Enabled = True
            KILabel.Enabled = True
            KTLabel.Enabled = True
        Else
            KIDateTimePicker.Enabled = False
            KTDateTimePicker.Enabled = False
            KILabel.Enabled = False
            KTLabel.Enabled = False
        End If

        '//MIERCOLES//
        If DayCoursSRCheckedListBox.GetItemCheckState(2) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            MIDateTimePicker.Enabled = True
            MTDateTimePicker.Enabled = True
            MILabel.Enabled = True
            MTLabel.Enabled = True
        Else
            MIDateTimePicker.Enabled = False
            MTDateTimePicker.Enabled = False
            MILabel.Enabled = False
            MTLabel.Enabled = False
        End If

        '//JUEVES//
        If DayCoursSRCheckedListBox.GetItemCheckState(3) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            JIDateTimePicker.Enabled = True
            JTDateTimePicker.Enabled = True
            JILabel.Enabled = True
            JTLabel.Enabled = True
        Else
            JIDateTimePicker.Enabled = False
            JTDateTimePicker.Enabled = False
            JILabel.Enabled = False
            JTLabel.Enabled = False
        End If

        '//VIERNES//
        If DayCoursSRCheckedListBox.GetItemCheckState(4) = CheckState.Checked Then

            '  MsgBox("Monday has been checked")
            VIDateTimePicker.Enabled = True
            VTDateTimePicker.Enabled = True
            VILabel.Enabled = True
            VTLabel.Enabled = True
        Else
            VIDateTimePicker.Enabled = False
            VTDateTimePicker.Enabled = False
            VILabel.Enabled = False
            VTLabel.Enabled = False
        End If

        '//SABADO//
        If DayCoursSRCheckedListBox.GetItemCheckState(5) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            SIDateTimePicker.Enabled = True
            STDateTimePicker.Enabled = True
            SILabel.Enabled = True
            STLabel.Enabled = True
        Else
            SIDateTimePicker.Enabled = False
            STDateTimePicker.Enabled = False
            SILabel.Enabled = False
            STLabel.Enabled = False
        End If

        '//DOMINGO//
        If DayCoursSRCheckedListBox.GetItemCheckState(6) = CheckState.Checked Then

            ' MsgBox("Monday has been checked")
            DIDateTimePicker.Enabled = True
            DTDateTimePicker.Enabled = True
            DILabel.Enabled = True
            DTLabel.Enabled = True
        Else
            DIDateTimePicker.Enabled = False
            DTDateTimePicker.Enabled = False
            DILabel.Enabled = False
            DTLabel.Enabled = False
        End If
    End Sub

    Private Sub NamePeriodTextBox_TextChanged(sender As Object, e As EventArgs) Handles NamePeriodTextBox.TextChanged
        If NamePeriodTextBox.Text <> "" Then
            AddCourseSRPanel.Enabled = True
        Else
            AddCourseSRPanel.Enabled = False
        End If
    End Sub

    Private Sub CancelRegisterButton_Click(sender As Object, e As EventArgs) Handles CancelRegisterButton.Click
        LoginForm.Show()
        Me.Close()
    End Sub
End Class