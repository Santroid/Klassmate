Imports System.Data.SqlClient

Public Class ScheduleRegisterForm

    '/////////////////////////EL BOTON DE TERMINAR////////////////////////////////
    Public Sub SaveSRButton_Click(sender As Object, e As EventArgs) Handles SaveSRButton.Click
        'Cuando el boton de terminar en el Form de agregar horarios despues de registrarse, se esconde eso Form y se muestra la el form de inicio -Santi
        Me.Hide()
        HomeForm.Show()

        '//////////// AGREGA EL PERIODO LECTIVO A LA BASE DE DATOS -Santi /////////////////
        Dim period As Period
        period = New Period

        period.Name_Period = NamePeriodTextBox.Text
        period.StartDate_Period = StartPeriodRegisterDateTimePicker.Value
        period.EndDate_Period = EndPeriodRegisterDateTimePicker.Value
        period.Id_Period = 0


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
            'declaramos la sentencia de INSERT para insertar a la BD
            insertQuery = "INSERT INTO Period(namePeriod, startDate, endDate, idStudent) values (@namePeriod, @startDate, @endDate, @idStudent)"

            command = New SqlCommand(insertQuery, connection)

            With command 'le asigna los valores a los espacios en la tabla

                .Parameters.AddWithValue("@idStudent", User.IdUser)
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
        MsgBox("global variable idcourse" & Course.IdCourse)

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
        ColorCoursSRComboBox.SelectedIndex = -1
        ColorCoursSRComboBox.BackColor = Color.AliceBlue
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
            .SelectedIndex = -1
        End With
        With ColorWorkSRComboBox
            .DrawMode = DrawMode.OwnerDrawFixed
            .IntegralHeight = False
            .MaxDropDownItems = 8
            .DataSource = knownColors.ToList
            .SelectedIndex = -1
        End With
        With ColorStudySRComboBox
            .DrawMode = DrawMode.OwnerDrawFixed
            .IntegralHeight = False
            .MaxDropDownItems = 8
            .DataSource = knownColors.ToList
            .SelectedIndex = -1
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
            ' Else
            '    ColorCoursSRComboBox.BackColor = Color.FromName(ColorCoursSRComboBox.SelectedItem.ToString)
        End If
    End Sub

    'Termina de agregarle colores al combobox de color cuando se agrega un curso -Santi
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


    '///////////////////////////////////////////////////////////////////////////////////////////////
    'Para agregarle colores al combobox de color cuando se agrega un horario de trabajo -Santi

    'Hace que se vean los colores como opciones en el combobox de horario de trabajo-Santi
    Private Sub ColorWorkSRComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) _
        Handles ColorWorkSRComboBox.DrawItem
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

    'Cambia el color del fondo del combobox al color escogido de horario de trabajo -Santi
    Private Sub ColorWorkSRComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorWorkSRComboBox.SelectedIndexChanged
        If ColorWorkSRComboBox.SelectedIndex <> -1 Then

            ColorWorkSRComboBox.BackColor = Color.FromName(ColorWorkSRComboBox.SelectedItem.ToString)

        End If
    End Sub

    'Termina de agregarle colores al combobox de color cuando se agrega un horario de trabajo -Santi
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    '///////////////////////////////////////////////////////////////////////////////////////////////
    'Para agregarle colores al combobox de color cuando se agrega un horario de estudio -Santi

    'Hace que se vean los colores como opciones en el combobox Horario de Estudio -Santi
    Private Sub ColorStudySRComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) _
        Handles ColorStudySRComboBox.DrawItem
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

    'Cambia el color del fondo del combobox al color escogido Horario de Estudio -Santi
    Private Sub ColorStudySRComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorStudySRComboBox.SelectedIndexChanged
        If ColorStudySRComboBox.SelectedIndex <> -1 Then

            ColorStudySRComboBox.BackColor = Color.FromName(ColorStudySRComboBox.SelectedItem.ToString)

        End If
    End Sub
    'Termina de agregarle colores al combobox de color cuando se agrega un horario de estudio -Santi
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    '////// AGREGA UN CURSO A LA BASE DE DATOS Y LIMPIA LOS CAMPOS PARA AGREGAR OTRO /////////////
    Private Sub AddCoursSRButton_Click(sender As Object, e As EventArgs) Handles AddCoursSRButton.Click

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


        Dim insertQuery
        Dim selectQuery
        Dim reader As SqlDataReader '= command.ExecuteReader

        MsgBox("This is before it added the periodo with the plus" & Period.PeriodCounter)
        'el if es para que no se agregue el mismo periodo mas de una vez a la base de datos
        If Period.PeriodCounter = 0 Then
            connection.Open()
            'declaramos la sentencia de INSERT para insertar a la BD
            insertQuery = "INSERT INTO Period(namePeriod, startDate, endDate, idStudent) values (@namePeriod, @startDate, @endDate, @idStudent)"

            command = New SqlCommand(insertQuery, connection)

            With command 'le asigna los valores a los espacios en la tabla

                .Parameters.AddWithValue("@idStudent", User.IdUser)
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
        MsgBox("global variable idcourse" & Course.IdCourse)

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
        ColorCoursSRComboBox.SelectedIndex = -1
        ColorCoursSRComboBox.BackColor = Color.AliceBlue
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

    Private Sub DayWorkSRCheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DayWorkSRCheckedListBox.SelectedIndexChanged
        '//LUNES//
        If DayWorkSRCheckedListBox.GetItemCheckState(0) = CheckState.Checked Then
            WLIDateTimePicker.Enabled = True
            WLTDateTimePicker.Enabled = True
            WLILabel.Enabled = True
            WLTLabel.Enabled = True
        Else
            WLIDateTimePicker.Enabled = False
            WLTDateTimePicker.Enabled = False
            WLILabel.Enabled = False
            WLTLabel.Enabled = False
        End If

        '//MARTES//
        If DayWorkSRCheckedListBox.GetItemCheckState(1) = CheckState.Checked Then
            WKIDateTimePicker.Enabled = True
            WKTDateTimePicker.Enabled = True
            WKILabel.Enabled = True
            WKTLabel.Enabled = True
        Else
            WKIDateTimePicker.Enabled = False
            WKTDateTimePicker.Enabled = False
            WKILabel.Enabled = False
            WKTLabel.Enabled = False
        End If

        '//MIERCOLES//
        If DayWorkSRCheckedListBox.GetItemCheckState(2) = CheckState.Checked Then
            WMIDateTimePicker.Enabled = True
            WMTDateTimePicker.Enabled = True
            WMILabel.Enabled = True
            WMTLabel.Enabled = True
        Else
            WMIDateTimePicker.Enabled = False
            WMTDateTimePicker.Enabled = False
            WMILabel.Enabled = False
            WMTLabel.Enabled = False
        End If

        '//JUEVES//
        If DayWorkSRCheckedListBox.GetItemCheckState(3) = CheckState.Checked Then
            WJIDateTimePicker.Enabled = True
            WJTDateTimePicker.Enabled = True
            WJILabel.Enabled = True
            WJTLabel.Enabled = True
        Else
            WJIDateTimePicker.Enabled = False
            WJTDateTimePicker.Enabled = False
            WJILabel.Enabled = False
            WJTLabel.Enabled = False
        End If

        '//VIERNES//
        If DayWorkSRCheckedListBox.GetItemCheckState(4) = CheckState.Checked Then
            WVIDateTimePicker.Enabled = True
            WVTDateTimePicker.Enabled = True
            WVILabel.Enabled = True
            WVTLabel.Enabled = True
        Else
            WVIDateTimePicker.Enabled = False
            WVTDateTimePicker.Enabled = False
            WVILabel.Enabled = False
            WVTLabel.Enabled = False
        End If

        '//SABADO//
        If DayWorkSRCheckedListBox.GetItemCheckState(5) = CheckState.Checked Then
            WSIDateTimePicker.Enabled = True
            WSTDateTimePicker.Enabled = True
            WSILabel.Enabled = True
            WSTLabel.Enabled = True
        Else
            WSIDateTimePicker.Enabled = False
            WSTDateTimePicker.Enabled = False
            WSILabel.Enabled = False
            WSTLabel.Enabled = False
        End If

        '//DOMINGO//
        If DayWorkSRCheckedListBox.GetItemCheckState(6) = CheckState.Checked Then
            WDIDateTimePicker.Enabled = True
            WDTDateTimePicker.Enabled = True
            WDILabel.Enabled = True
            WDTLabel.Enabled = True
        Else
            WDIDateTimePicker.Enabled = False
            WDTDateTimePicker.Enabled = False
            WDILabel.Enabled = False
            WDTLabel.Enabled = False
        End If
    End Sub

    Private Sub AddWorkSRButton_Click_Click(sender As Object, e As EventArgs) Handles AddWorkSRButton_Click.Click

        Dim Work As WorkSch
        Work = New WorkSch
        Dim connection As SqlConnection
        Dim command As SqlCommand

        Work.Name_WorkSch = NameWorkSRTextBox.Text
        Work.Color_Work = ColorWorkSRComboBox.SelectedItem.ToString

        Dim period As Period
        period = New Period

        period.Name_Period = NamePeriodTextBox.Text
        period.StartDate_Period = StartPeriodRegisterDateTimePicker.Value
        period.EndDate_Period = EndPeriodRegisterDateTimePicker.Value
        period.Id_Period = 0

        Dim sch As Schedule
        sch = New Schedule

        sch.DIndex_Schedule = DayWorkSRCheckedListBox.SelectedIndex
        'sch.TimeStart_Schedule = 

        Try
            Connect()

            Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"

            'aquí conectamos con la base de datos
            connection = New SqlConnection(connectionString)

            'abriendo la conexión

            Dim insertQuery
            Dim selectQuery
            Dim reader As SqlDataReader '= command.ExecuteReader

            MsgBox("This is before it added the periodo with the plus" & Period.PeriodCounter)
            'el if es para que no se agregue el mismo periodo mas de una vez a la base de datos
            If Period.PeriodCounter = 0 Then
                connection.Open()
                'declaramos la sentencia de INSERT para insertar a la BD
                insertQuery = "INSERT INTO Activity(idActivity, name, idStudent, color) values (@idActivity, @name, @idStudent, @color)"

                command = New SqlCommand(insertQuery, connection)

                With command 'le asigna los valores a los espacios en la tabla
                    .Parameters.AddWithValue("@idStudent", User.IdUser)
                    .Parameters.AddWithValue("@idActivity", period.Id_Period)
                    .Parameters.AddWithValue("@name", period.Name_Period)
                    .Parameters.AddWithValue("@color", Work.Color_Work)
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

                ' Dim selectQuery

                'declaramos la sentencia de INSERT para insertar a la BD
                selectQuery = "SELECT TOP 1 * FROM Period ORDER BY idPeriod DESC"

                command = New SqlCommand(selectQuery, ConnectionBD.Connection)

                connection.Open()

                'ejecuta el lector de la base de datos
                reader = command.ExecuteReader

                reader.Read()

                period.Id_Period = reader.Item("idPeriod")
                Period.IdPeriod = reader.Item("idPeriod")
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

            command = New SqlCommand(insertQuery, ConnectionBD.Connection)
            connection.Open()

            ' MsgBox("This is the global variable after the if " & Period.IdPeriod)
            With command 'le asigna los valores a los espacios en la tabla
                '.Parameters.AddWithValue("@idStudent", User.IdUser)
                .Parameters.AddWithValue("@nameSubject", Work.Name_WorkSch)
                .Parameters.AddWithValue("@color", Work.Color_Work.ToString)
                .Parameters.AddWithValue("@idPeriod", Period.IdPeriod)
            End With

            'ejecutamos la consulta
            command.ExecuteNonQuery()

            connection.Close()

            '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////

            'declaramos la sentencia de INSERT para insertar a la BD
            selectQuery = "SELECT TOP 1 * FROM Subject ORDER BY idSubject DESC"

            command = New SqlCommand(selectQuery, ConnectionBD.Connection)

            connection.Open()

            'ejecuta el lector de la base de datos
            reader = command.ExecuteReader

            reader.Read()

            Work.Id_WorkSch = reader.Item("idSubject")
            MsgBox("global variable idcourse" & Work.Id_WorkSch)

            connection.Close()

            '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////
            For Each Index In DayWorkSRCheckedListBox.CheckedIndices

                If Index = 0 Then
                    sch.Day_Schedule = "Lunes"
                    sch.TimeStart_Schedule = WLIDateTimePicker.Value
                    sch.TimeEnd_Schedule = WLTDateTimePicker.Value
                    'si Martes esta marcado
                ElseIf Index = 1 Then
                    sch.Day_Schedule = "Martes"
                    sch.TimeStart_Schedule = WKIDateTimePicker.Value
                    sch.TimeEnd_Schedule = WKTDateTimePicker.Value
                    'si miercoles esta marcado
                ElseIf Index = 2 Then
                    sch.Day_Schedule = "Miercoles"
                    sch.TimeStart_Schedule = WMIDateTimePicker.Value
                    sch.TimeEnd_Schedule = WMTDateTimePicker.Value
                    'si jueves esta marcado
                ElseIf Index = 3 Then
                    sch.Day_Schedule = "Jueves"
                    sch.TimeStart_Schedule = WJIDateTimePicker.Value
                    sch.TimeEnd_Schedule = WJTDateTimePicker.Value
                    'si viernes esta marcado
                ElseIf Index = 4 Then
                    sch.Day_Schedule = "Viernes"
                    sch.TimeStart_Schedule = WVIDateTimePicker.Value
                    sch.TimeEnd_Schedule = WVTDateTimePicker.Value
                    'si sabado esta marcado
                ElseIf Index = 5 Then
                    sch.Day_Schedule = "Sabado"
                    sch.TimeStart_Schedule = WSIDateTimePicker.Value
                    sch.TimeEnd_Schedule = WSTDateTimePicker.Value
                    'si domingo esta marcado
                ElseIf Index = 6 Then
                    sch.Day_Schedule = "Domingo"
                    sch.TimeStart_Schedule = WDIDateTimePicker.Value
                    sch.TimeEnd_Schedule = WDTDateTimePicker.Value
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
                    .Parameters.AddWithValue("@idActivity", period.Id_Period)
                    .Parameters.AddWithValue("@idSubject", Work.Id_WorkSch)
                End With

                'ejecutamos la consulta
                command.ExecuteNonQuery()

                connection.Close()

            Next


            NameWorkSRTextBox.Clear()
            ColorWorkSRComboBox.SelectedIndex = -1
            ColorWorkSRComboBox.BackColor = Color.AliceBlue
            For index = 0 To DayWorkSRCheckedListBox.Items.Count - 1
                DayWorkSRCheckedListBox.SetItemChecked(index, False)
                DayWorkSRCheckedListBox.SetItemCheckState(index, CheckState.Unchecked)
            Next

            '//LUNES//
            If DayWorkSRCheckedListBox.GetItemCheckState(0) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                WLIDateTimePicker.Enabled = True
                WLTDateTimePicker.Enabled = True
                WLILabel.Enabled = True
                WLTLabel.Enabled = True
            Else
                WLIDateTimePicker.Value = DefaultDateTimePicker.Value
                WLTDateTimePicker.Value = DefaultDateTimePicker.Value
                WLIDateTimePicker.Enabled = False
                WLTDateTimePicker.Enabled = False
                WLILabel.Enabled = False
                WLTLabel.Enabled = False
            End If

            '//MARTES//
            If DayWorkSRCheckedListBox.GetItemCheckState(1) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                WKIDateTimePicker.Enabled = True
                WKTDateTimePicker.Enabled = True
                WKILabel.Enabled = True
                WKTLabel.Enabled = True
            Else
                WKIDateTimePicker.Value = DefaultDateTimePicker.Value
                WKTDateTimePicker.Value = DefaultDateTimePicker.Value
                WKIDateTimePicker.Enabled = False
                WKTDateTimePicker.Enabled = False
                WKILabel.Enabled = False
                WKTLabel.Enabled = False
            End If

            '//MIERCOLES//
            If DayWorkSRCheckedListBox.GetItemCheckState(2) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                WMIDateTimePicker.Enabled = True
                WMTDateTimePicker.Enabled = True
                WMILabel.Enabled = True
                WMTLabel.Enabled = True
            Else
                WMIDateTimePicker.Value = DefaultDateTimePicker.Value
                WMTDateTimePicker.Value = DefaultDateTimePicker.Value
                WMIDateTimePicker.Enabled = False
                WMTDateTimePicker.Enabled = False
                WMILabel.Enabled = False
                WMTLabel.Enabled = False
            End If

            '//JUEVES//
            If DayWorkSRCheckedListBox.GetItemCheckState(3) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                WJIDateTimePicker.Enabled = True
                WJTDateTimePicker.Enabled = True
                WJILabel.Enabled = True
                WJTLabel.Enabled = True
            Else
                WJIDateTimePicker.Value = DefaultDateTimePicker.Value
                WJTDateTimePicker.Value = DefaultDateTimePicker.Value
                WJIDateTimePicker.Enabled = False
                WJTDateTimePicker.Enabled = False
                WJILabel.Enabled = False
                WJTLabel.Enabled = False
            End If

            '//VIERNES//
            If DayWorkSRCheckedListBox.GetItemCheckState(4) = CheckState.Checked Then

                '  MsgBox("Monday has been checked")
                WVIDateTimePicker.Enabled = True
                WVTDateTimePicker.Enabled = True
                WVILabel.Enabled = True
                WVTLabel.Enabled = True
            Else
                WVIDateTimePicker.Value = DefaultDateTimePicker.Value
                WVTDateTimePicker.Value = DefaultDateTimePicker.Value
                WVIDateTimePicker.Enabled = False
                WVTDateTimePicker.Enabled = False
                WVILabel.Enabled = False
                WVTLabel.Enabled = False
            End If

            '//SABADO//
            If DayWorkSRCheckedListBox.GetItemCheckState(5) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                WSIDateTimePicker.Enabled = True
                WSTDateTimePicker.Enabled = True
                SILabel.Enabled = True
                STLabel.Enabled = True
            Else
                WSIDateTimePicker.Value = DefaultDateTimePicker.Value
                WSTDateTimePicker.Value = DefaultDateTimePicker.Value
                WSIDateTimePicker.Enabled = False
                WSTDateTimePicker.Enabled = False
                WSILabel.Enabled = False
                WSTLabel.Enabled = False
            End If

            '//DOMINGO//
            If DayWorkSRCheckedListBox.GetItemCheckState(6) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                WDIDateTimePicker.Enabled = True
                WDTDateTimePicker.Enabled = True
                WDILabel.Enabled = True
                WDTLabel.Enabled = True
            Else
                WDIDateTimePicker.Value = DefaultDateTimePicker.Value
                WDTDateTimePicker.Value = DefaultDateTimePicker.Value
                WDIDateTimePicker.Enabled = False
                WDTDateTimePicker.Enabled = False
                WDILabel.Enabled = False
                WDTLabel.Enabled = False
            End If

            '\\\\\\\\\ TERMINA DE AGREGAR UN CURSO A LA BASE DE DATOS Y LIMPIA LOS CAMPOS PARA AGREGAR OTRO \\\\\\\\\\\\

        Catch ex As Exception
            MsgBox("")
        End Try

    End Sub

    Private Sub DayStudySRCheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DayStudySRCheckedListBox.SelectedIndexChanged
        '//LUNES//
        If DayStudySRCheckedListBox.GetItemCheckState(0) = CheckState.Checked Then
            SLIDateTimePicker.Enabled = True
            SLTDateTimePicker.Enabled = True
            SLILabel.Enabled = True
            SLTLabel.Enabled = True
        Else
            SLIDateTimePicker.Enabled = False
            SLTDateTimePicker.Enabled = False
            SLILabel.Enabled = False
            SLTLabel.Enabled = False
        End If

        '//MARTES//
        If DayStudySRCheckedListBox.GetItemCheckState(1) = CheckState.Checked Then
            SKIDateTimePicker.Enabled = True
            SKTDateTimePicker.Enabled = True
            SKILabel.Enabled = True
            SKTLabel.Enabled = True
        Else
            SKIDateTimePicker.Enabled = False
            SKTDateTimePicker.Enabled = False
            SKILabel.Enabled = False
            SKTLabel.Enabled = False
        End If

        '//MIERCOLES//
        If DayStudySRCheckedListBox.GetItemCheckState(2) = CheckState.Checked Then
            SMIDateTimePicker.Enabled = True
            SMTDateTimePicker.Enabled = True
            SMILabel.Enabled = True
            SMTLabel.Enabled = True
        Else
            SMIDateTimePicker.Enabled = False
            SMTDateTimePicker.Enabled = False
            SMILabel.Enabled = False
            SMTLabel.Enabled = False
        End If

        '//JUEVES//
        If DayStudySRCheckedListBox.GetItemCheckState(3) = CheckState.Checked Then
            SJIDateTimePicker.Enabled = True
            SJTDateTimePicker.Enabled = True
            SJILabel.Enabled = True
            SJTLabel.Enabled = True
        Else
            SJIDateTimePicker.Enabled = False
            SJTDateTimePicker.Enabled = False
            SJILabel.Enabled = False
            SJTLabel.Enabled = False
        End If

        '//VIERNES//
        If DayStudySRCheckedListBox.GetItemCheckState(4) = CheckState.Checked Then
            SVIDateTimePicker.Enabled = True
            SVTDateTimePicker.Enabled = True
            SVILabel.Enabled = True
            SVTLabel.Enabled = True
        Else
            SVIDateTimePicker.Enabled = False
            SVTDateTimePicker.Enabled = False
            SVILabel.Enabled = False
            SVTLabel.Enabled = False
        End If

        '//SABADO//
        If DayStudySRCheckedListBox.GetItemCheckState(5) = CheckState.Checked Then
            SSIDateTimePicker.Enabled = True
            SSTDateTimePicker.Enabled = True
            SSILabel.Enabled = True
            SSTLabel.Enabled = True
        Else
            SSIDateTimePicker.Enabled = False
            SSTDateTimePicker.Enabled = False
            SSILabel.Enabled = False
            SSTLabel.Enabled = False
        End If

        '//DOMINGO//
        If DayStudySRCheckedListBox.GetItemCheckState(6) = CheckState.Checked Then
            SDIDateTimePicker.Enabled = True
            SDTDateTimePicker.Enabled = True
            SDILabel.Enabled = True
            SDTLabel.Enabled = True
        Else
            SDIDateTimePicker.Enabled = False
            SDTDateTimePicker.Enabled = False
            SDILabel.Enabled = False
            SDTLabel.Enabled = False
        End If
    End Sub

    Private Sub AddStudySRButton_Click_Click(sender As Object, e As EventArgs) Handles AddStudySRButton_Click.Click

        Dim study As StudySch
        study = New StudySch
        Dim connection As SqlConnection
        Dim command As SqlCommand

        study.Name_StudySch = NameStudySRTextBox.Text
        study.Color_StudySch = ColorStudySRComboBox.SelectedItem.ToString

        Dim period As Period
        period = New Period

        period.Name_Period = NamePeriodTextBox.Text
        period.StartDate_Period = StartPeriodRegisterDateTimePicker.Value
        period.EndDate_Period = EndPeriodRegisterDateTimePicker.Value
        period.Id_Period = 0

        Dim sch As Schedule
        sch = New Schedule

        sch.DIndex_Schedule = DayStudySRCheckedListBox.SelectedIndex
        'sch.TimeStart_Schedule = 

        Try
            Connect()

            Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"

            'aquí conectamos con la base de datos
            connection = New SqlConnection(connectionString)

            'abriendo la conexión

            Dim insertQuery
            Dim selectQuery
            Dim reader As SqlDataReader '= command.ExecuteReader

            MsgBox("This is before it added the periodo with the plus" & Period.PeriodCounter)
            'el if es para que no se agregue el mismo periodo mas de una vez a la base de datos
            If Period.PeriodCounter = 0 Then
                connection.Open()
                'declaramos la sentencia de INSERT para insertar a la BD
                insertQuery = "INSERT INTO Activity(idActivity, name, idStudent, color) values (@idActivity, @name, @idStudent, @color)"

                command = New SqlCommand(insertQuery, connection)

                With command 'le asigna los valores a los espacios en la tabla
                    .Parameters.AddWithValue("@idStudent", User.IdUser)
                    .Parameters.AddWithValue("@idActivity", period.Id_Period)
                    .Parameters.AddWithValue("@name", period.Name_Period)
                    .Parameters.AddWithValue("@color", study.Color_StudySch)
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

                ' Dim selectQuery

                'declaramos la sentencia de INSERT para insertar a la BD
                selectQuery = "SELECT TOP 1 * FROM Period ORDER BY idPeriod DESC"

                command = New SqlCommand(selectQuery, ConnectionBD.Connection)

                connection.Open()

                'ejecuta el lector de la base de datos
                reader = command.ExecuteReader

                reader.Read()

                period.Id_Period = reader.Item("idPeriod")
                Period.IdPeriod = reader.Item("idPeriod")
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

            command = New SqlCommand(insertQuery, ConnectionBD.Connection)
            connection.Open()

            ' MsgBox("This is the global variable after the if " & Period.IdPeriod)
            With command 'le asigna los valores a los espacios en la tabla
                '.Parameters.AddWithValue("@idStudent", User.IdUser)
                .Parameters.AddWithValue("@nameSubject", study.Name_StudySch)
                .Parameters.AddWithValue("@color", study.Color_StudySch.ToString)
                .Parameters.AddWithValue("@idPeriod", Period.IdPeriod)
            End With

            'ejecutamos la consulta
            command.ExecuteNonQuery()

            connection.Close()

            '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////

            'declaramos la sentencia de INSERT para insertar a la BD
            selectQuery = "SELECT TOP 1 * FROM Subject ORDER BY idSubject DESC"

            command = New SqlCommand(selectQuery, ConnectionBD.Connection)

            connection.Open()

            'ejecuta el lector de la base de datos
            reader = command.ExecuteReader

            reader.Read()

            study.Id_StudySch = reader.Item("idSubject")
            connection.Close()

            '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////
            For Each Index In DayStudySRCheckedListBox.CheckedIndices

                If Index = 0 Then
                    sch.Day_Schedule = "Lunes"
                    sch.TimeStart_Schedule = SLIDateTimePicker.Value
                    sch.TimeEnd_Schedule = SLTDateTimePicker.Value
                    'si Martes esta marcado
                ElseIf Index = 1 Then
                    sch.Day_Schedule = "Martes"
                    sch.TimeStart_Schedule = SKIDateTimePicker.Value
                    sch.TimeEnd_Schedule = SKTDateTimePicker.Value
                    'si miercoles esta marcado
                ElseIf Index = 2 Then
                    sch.Day_Schedule = "Miercoles"
                    sch.TimeStart_Schedule = SMIDateTimePicker.Value
                    sch.TimeEnd_Schedule = SMTDateTimePicker.Value
                    'si jueves esta marcado
                ElseIf Index = 3 Then
                    sch.Day_Schedule = "Jueves"
                    sch.TimeStart_Schedule = SJIDateTimePicker.Value
                    sch.TimeEnd_Schedule = SJTDateTimePicker.Value
                    'si viernes esta marcado
                ElseIf Index = 4 Then
                    sch.Day_Schedule = "Viernes"
                    sch.TimeStart_Schedule = SVIDateTimePicker.Value
                    sch.TimeEnd_Schedule = SVTDateTimePicker.Value
                    'si sabado esta marcado
                ElseIf Index = 5 Then
                    sch.Day_Schedule = "Sabado"
                    sch.TimeStart_Schedule = SSIDateTimePicker.Value
                    sch.TimeEnd_Schedule = SSTDateTimePicker.Value
                    'si domingo esta marcado
                ElseIf Index = 6 Then
                    sch.Day_Schedule = "Domingo"
                    sch.TimeStart_Schedule = SDIDateTimePicker.Value
                    sch.TimeEnd_Schedule = SDTDateTimePicker.Value
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
                    .Parameters.AddWithValue("@idActivity", period.Id_Period)
                    .Parameters.AddWithValue("@idSubject", study.Id_StudySch)
                End With

                'ejecutamos la consulta
                command.ExecuteNonQuery()

                connection.Close()

            Next


            NameStudySRTextBox.Clear()
            ColorStudySRComboBox.SelectedIndex = -1
            ColorStudySRComboBox.BackColor = Color.AliceBlue
            For index = 0 To DayStudySRCheckedListBox.Items.Count - 1
                DayStudySRCheckedListBox.SetItemChecked(index, False)
                DayStudySRCheckedListBox.SetItemCheckState(index, CheckState.Unchecked)
            Next

            '//LUNES//
            If DayStudySRCheckedListBox.GetItemCheckState(0) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                SLIDateTimePicker.Enabled = True
                SLTDateTimePicker.Enabled = True
                SLILabel.Enabled = True
                SLTLabel.Enabled = True
            Else
                SLIDateTimePicker.Value = DefaultDateTimePicker.Value
                SLTDateTimePicker.Value = DefaultDateTimePicker.Value
                SLIDateTimePicker.Enabled = False
                SLTDateTimePicker.Enabled = False
                SLILabel.Enabled = False
                SLTLabel.Enabled = False
            End If

            '//MARTES//
            If DayStudySRCheckedListBox.GetItemCheckState(1) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                SKIDateTimePicker.Enabled = True
                SKTDateTimePicker.Enabled = True
                SKILabel.Enabled = True
                SKTLabel.Enabled = True
            Else
                SKIDateTimePicker.Value = DefaultDateTimePicker.Value
                SKTDateTimePicker.Value = DefaultDateTimePicker.Value
                SKIDateTimePicker.Enabled = False
                SKTDateTimePicker.Enabled = False
                SKILabel.Enabled = False
                SKTLabel.Enabled = False
            End If

            '//MIERCOLES//
            If DayStudySRCheckedListBox.GetItemCheckState(2) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                SMIDateTimePicker.Enabled = True
                SMTDateTimePicker.Enabled = True
                SMILabel.Enabled = True
                SMTLabel.Enabled = True
            Else
                SMIDateTimePicker.Value = DefaultDateTimePicker.Value
                SMTDateTimePicker.Value = DefaultDateTimePicker.Value
                SMIDateTimePicker.Enabled = False
                SMTDateTimePicker.Enabled = False
                SMILabel.Enabled = False
                SMTLabel.Enabled = False
            End If

            '//JUEVES//
            If DayStudySRCheckedListBox.GetItemCheckState(3) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                SJIDateTimePicker.Enabled = True
                SJTDateTimePicker.Enabled = True
                SJILabel.Enabled = True
                SJTLabel.Enabled = True
            Else
                SJIDateTimePicker.Value = DefaultDateTimePicker.Value
                SJTDateTimePicker.Value = DefaultDateTimePicker.Value
                SJIDateTimePicker.Enabled = False
                SJTDateTimePicker.Enabled = False
                SJILabel.Enabled = False
                SJTLabel.Enabled = False
            End If

            '//VIERNES//
            If DayStudySRCheckedListBox.GetItemCheckState(4) = CheckState.Checked Then

                '  MsgBox("Monday has been checked")
                SVIDateTimePicker.Enabled = True
                SVTDateTimePicker.Enabled = True
                SVILabel.Enabled = True
                SVTLabel.Enabled = True
            Else
                SVIDateTimePicker.Value = DefaultDateTimePicker.Value
                SVTDateTimePicker.Value = DefaultDateTimePicker.Value
                SVIDateTimePicker.Enabled = False
                SVTDateTimePicker.Enabled = False
                SVILabel.Enabled = False
                SVTLabel.Enabled = False
            End If

            '//SABADO//
            If DayStudySRCheckedListBox.GetItemCheckState(5) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                SSIDateTimePicker.Enabled = True
                SSTDateTimePicker.Enabled = True
                SSILabel.Enabled = True
                SSTLabel.Enabled = True
            Else
                SSIDateTimePicker.Value = DefaultDateTimePicker.Value
                SSTDateTimePicker.Value = DefaultDateTimePicker.Value
                SSIDateTimePicker.Enabled = False
                SSTDateTimePicker.Enabled = False
                SSILabel.Enabled = False
                SSTLabel.Enabled = False
            End If

            '//DOMINGO//
            If DayStudySRCheckedListBox.GetItemCheckState(6) = CheckState.Checked Then

                ' MsgBox("Monday has been checked")
                SDIDateTimePicker.Enabled = True
                SDTDateTimePicker.Enabled = True
                SDILabel.Enabled = True
                SDTLabel.Enabled = True
            Else
                SDIDateTimePicker.Value = DefaultDateTimePicker.Value
                SDTDateTimePicker.Value = DefaultDateTimePicker.Value
                SDIDateTimePicker.Enabled = False
                SDTDateTimePicker.Enabled = False
                SDILabel.Enabled = False
                SDTLabel.Enabled = False
            End If

            '\\\\\\\\\ TERMINA DE AGREGAR UN CURSO A LA BASE DE DATOS Y LIMPIA LOS CAMPOS PARA AGREGAR OTRO \\\\\\\\\\\\

        Catch ex As Exception
            MsgBox("")
        End Try

    End Sub
End Class