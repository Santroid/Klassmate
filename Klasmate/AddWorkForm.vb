Imports System.Data.SqlClient

Public Class AddWorkForm

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        'Cuando el boton de cancelar en el Form de agregar horarios de trabajo, se esconde eso Form y se muestra el form de inicio
        Me.Hide()
        HomeForm.Show()
    End Sub

    Private Sub AddWorkSRButton_Click(sender As Object, e As EventArgs) Handles AddWorkSRButton.Click

        Dim user As New User
        Dim Work As WorkSch
        Work = New WorkSch

        Work.Name_WorkSch = NameWorkSRTextBox.Text
        Work.Color_Work = ColorWorkSRComboBox.SelectedItem.ToString

        Dim sch As Schedule
        sch = New Schedule

        sch.DIndex_Schedule = DayWorkSRCheckedListBox.SelectedIndex

        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"


        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)

        'abriendo la conexión

        Dim insertQuery
        Dim selectQuery
        Dim reader As SqlDataReader '= command.ExecuteReader

        'declaramos la sentencia de INSERT para insertar a la BD
        insertQuery = "INSERT INTO Subject(nameSubject, color, idPeriod) values (@nameSubject, @color, @idPeriod)"

        command = New SqlCommand(insertQuery, connection)
        connection.Open()

        ' MsgBox("This is the global variable after the if " & Period.IdPeriod)
        With command 'le asigna los valores a los espacios en la tabla

            '.Parameters.AddWithValue("@idStudent", User.IdUser)
            '.Parameters.AddWithValue("@nameSubject", Course.Name_Course)
            '.Parameters.AddWithValue("@color", Course.Color_Course.ToString)
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
        For Each Index In DayWorkSRCheckedListBox.CheckedIndices

            'si Lunes esta marcado
            If Index = 0 Then

                sch.Day_Schedule = "Lunes"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = WLIDateTimePicker.Value
                sch.TimeEnd_Schedule = WLTDateTimePicker.Value
                ' MsgBox("time of day" & sch.TimeEnd_Schedule.TimeOfDay.ToString)

                'si Martes esta marcado
            ElseIf Index = 1 Then

                sch.Day_Schedule = "Martes"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = WKIDateTimePicker.Value
                sch.TimeEnd_Schedule = WKTDateTimePicker.Value

                'si miercoles esta marcado
            ElseIf Index = 2 Then
                sch.Day_Schedule = "Miercoles"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = WMIDateTimePicker.Value
                sch.TimeEnd_Schedule = WMTDateTimePicker.Value

                'si jueves esta marcado
            ElseIf Index = 3 Then
                sch.Day_Schedule = "Jueves"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = WJIDateTimePicker.Value
                sch.TimeEnd_Schedule = WJTDateTimePicker.Value

                'si viernes esta marcado
            ElseIf Index = 4 Then
                sch.Day_Schedule = "Viernes"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = WVIDateTimePicker.Value
                sch.TimeEnd_Schedule = WVTDateTimePicker.Value

                'si sabado esta marcado
            ElseIf Index = 5 Then
                sch.Day_Schedule = "Sabado"
                ' MsgBox(sch.Day_Schedule)
                sch.TimeStart_Schedule = WSIDateTimePicker.Value
                sch.TimeEnd_Schedule = WSTDateTimePicker.Value

                'si domingo esta marcado
            ElseIf Index = 6 Then
                sch.Day_Schedule = "Domingo"
                ' MsgBox(sch.Day_Schedule)
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
                .Parameters.AddWithValue("@idSubject", Course.IdCourse)

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
            WSILabel.Enabled = True
            WSTLabel.Enabled = True
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
    End Sub

    ' Verificar qué día escogió para habilitar la hora
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

    Private Sub AddWorkForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class