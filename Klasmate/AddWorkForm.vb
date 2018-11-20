Imports System.Data.SqlClient

Public Class AddWorkForm

    Private Sub AddWorkSRButton_Click(sender As Object, e As EventArgs) Handles AddWorkSRButton.Click

        Dim user As New User
        Dim Work As WorkSch
        Work = New WorkSch

        Work.Name_WorkSch = NameWorkSRTextBox.Text
        Work.Color_Work = ColorWorkSRComboBox.SelectedItem.ToString

        Dim sch As Schedule
        sch = New Schedule

        sch.DIndex_Schedule = DayWorkSRCheckedListBox.SelectedIndex

        Dim command As SqlCommand
        Dim insertQuery
        Dim selectQuery
        Dim reader As SqlDataReader

        Try
            Connect()
            insertQuery = "INSERT INTO Activity(name, color, idStudent, type, idPeriod) values (@name, @color, @idStudent, @type, @idPeriod)"

            command = New SqlCommand(insertQuery, ConnectionBD.Connection)

            With command 'le asigna los valores a los espacios en la tabla
                .Parameters.AddWithValue("@name", Work.Name_WorkSch)
                .Parameters.AddWithValue("@color", Work.Color_Work.ToString)
                .Parameters.AddWithValue("@idStudent", User.IdUser)
                .Parameters.AddWithValue("@type", 1)
                .Parameters.AddWithValue("@idPeriod", Integer.Parse(HomeForm.IdPeriodLabel.Text))
            End With
            command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("No fue posible registrar el horario de trabajo1 " + ex.Message)
        Finally
            Disconnect()
        End Try

        '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////

        Try
            Connect()
            selectQuery = "SELECT TOP 1 * FROM Activity ORDER BY idActivity DESC"
            command = New SqlCommand(selectQuery, ConnectionBD.Connection)

            reader = command.ExecuteReader
            reader.Read()

            Work.Id_WorkSch = reader.Item("idActivity")
            reader.Close()

            MsgBox("Horario guardado con éxito")
            'Work.Id_WorkSch = reader.Item("idActivity")
            'MsgBox("global variable idActivity" & Work.Id_WorkSch)

        Catch ex As Exception
            MsgBox("No fue posible registrar el horario de trabajo 2" + ex.Message)
        Finally
            Disconnect()
        End Try

        '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////
        For Each Index In DayWorkSRCheckedListBox.CheckedIndices

            'si Lunes esta marcado
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

            Try
                Connect()
                insertQuery = "INSERT INTO Schedule(day, startTime, endTime) values (@day, @startTime, @endTime)"
                command = New SqlCommand(insertQuery, ConnectionBD.Connection)

                With command 'le asigna los valores a los espacios en la tabla
                    '.Parameters.AddWithValue("@idStudent", User.IdUser)
                    .Parameters.AddWithValue("@day", sch.Day_Schedule)
                    .Parameters.AddWithValue("@startTime", sch.TimeStart_Schedule.TimeOfDay)
                    .Parameters.AddWithValue("@endTime", sch.TimeEnd_Schedule.TimeOfDay)
                End With
                command.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No fue posible registrar el horario de trabajo 3" + ex.Message)
            Finally
                Disconnect()
            End Try
            Dim IdSch As Integer
            Try
                Connect()
                selectQuery = "SELECT TOP 1 * FROM Schedule ORDER BY idSchedule DESC"
                command = New SqlCommand(selectQuery, ConnectionBD.Connection)
                reader = command.ExecuteReader
                reader.Read()
                IdSch = reader.Item("idSchedule")
                reader.Close()
            Catch ex As Exception
                MsgBox("No fue posible registrar el horario de trabajo 4" + ex.Message)
            Finally
                Disconnect()
            End Try

            Try
                Connect()
                insertQuery = "INSERT INTO ActivityHasSchedule(idSchedule, idActivity) values (@idSchedule, @idActivity)"
                command = New SqlCommand(insertQuery, ConnectionBD.Connection)

                With command 'le asigna los valores a los espacios en la tabla
                    .Parameters.AddWithValue("@idSchedule", IdSch)
                    .Parameters.AddWithValue("@idActivity", Work.Id_WorkSch)
                End With
                command.ExecuteNonQuery()
            Catch ex As Exception
                ' MsgBox("No fue posible registrar el horario de trabajo 5" + ex.Message)
            Finally
                Disconnect()
            End Try

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

    Private Sub AddWorkSRButton2_Click(sender As Object, e As EventArgs) Handles AddWorkSRButton2.Click

        Dim user As New User
        Dim Work As WorkSch
        Work = New WorkSch

        Work.Name_WorkSch = NameWorkSRTextBox.Text
        Work.Color_Work = ColorWorkSRComboBox.SelectedItem.ToString

        Dim sch As Schedule
        sch = New Schedule

        sch.DIndex_Schedule = DayWorkSRCheckedListBox.SelectedIndex

        Dim command As SqlCommand
        Dim insertQuery
        Dim selectQuery
        Dim reader As SqlDataReader

        Try
            Connect()
            insertQuery = "INSERT INTO Activity(name, color, idStudent, type, idPeriod) values (@name, @color, @idStudent, @type, @idPeriod)"

            command = New SqlCommand(insertQuery, ConnectionBD.Connection)

            With command 'le asigna los valores a los espacios en la tabla
                .Parameters.AddWithValue("@name", Work.Name_WorkSch)
                .Parameters.AddWithValue("@color", Work.Color_Work.ToString)
                .Parameters.AddWithValue("@idStudent", User.IdUser)
                .Parameters.AddWithValue("@type", 1)
                .Parameters.AddWithValue("@idPeriod", Integer.Parse(HomeForm.IdPeriodLabel.Text))
            End With
            command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("No fue posible registrar el horario de trabajo1 " + ex.Message)
        Finally
            Disconnect()
        End Try

        Try
            Connect()
            selectQuery = "SELECT TOP 1 * FROM Activity ORDER BY idActivity DESC"
            command = New SqlCommand(selectQuery, ConnectionBD.Connection)
            reader = command.ExecuteReader
            reader.Read()
            Work.Id_WorkSch = reader.Item("idActivity")
            reader.Close()
            MsgBox("Horario guardado con éxito")
        Catch ex As Exception
            MsgBox("No fue posible registrar el horario de trabajo 2" + ex.Message)
        Finally
            Disconnect()
        End Try

        '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////

        For Each Index In DayWorkSRCheckedListBox.CheckedIndices

            'si Lunes esta marcado
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

        Next

        NameWorkSRTextBox.Clear()
        ColorWorkSRComboBox.SelectedIndex = 0
        ColorWorkSRComboBox.BackColor = Color.AliceBlue
        For Index = 0 To DayWorkSRCheckedListBox.Items.Count - 1
            DayWorkSRCheckedListBox.SetItemChecked(Index, False)
            DayWorkSRCheckedListBox.SetItemCheckState(Index, CheckState.Unchecked)
        Next
        Me.Hide()
        HomeForm.Show()

        Try
            Connect()
            insertQuery = "INSERT INTO Schedule(day, startTime, endTime) values (@day, @startTime, @endTime)"
            command = New SqlCommand(insertQuery, ConnectionBD.Connection)
            With command 'le asigna los valores a los espacios en la tabla
                .Parameters.AddWithValue("@day", sch.Day_Schedule)
                .Parameters.AddWithValue("@startTime", sch.TimeStart_Schedule.TimeOfDay)
                .Parameters.AddWithValue("@endTime", sch.TimeEnd_Schedule.TimeOfDay)
            End With
            command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("No fue posible registrar el horario de trabajo 3" + ex.Message)
        Finally
            Disconnect()
        End Try
        Dim IdSch As Integer
        Try
            Connect()
            selectQuery = "SELECT TOP 1 * FROM Schedule ORDER BY idSchedule DESC"
            command = New SqlCommand(selectQuery, ConnectionBD.Connection)
            reader = command.ExecuteReader
            reader.Read()
            IdSch = reader.Item("idSchedule")
            reader.Close()
        Catch ex As Exception
            MsgBox("No fue posible registrar el horario de trabajo 4" + ex.Message)
        Finally
            Disconnect()
        End Try

        Try
            Connect()
            insertQuery = "INSERT INTO ActivityHasSchedule(idSchedule, idActivity) values (@idSchedule, @idActivity)"
            command = New SqlCommand(insertQuery, ConnectionBD.Connection)
            reader = command.ExecuteReader
            reader.Read()

            With command 'le asigna los valores a los espacios en la tabla
                .Parameters.AddWithValue("@idSchedule", IdSch)
                .Parameters.AddWithValue("@idActivity", Work.Id_WorkSch)
            End With
            command.ExecuteNonQuery()
        Catch ex As Exception
            ' MsgBox("No fue posible registrar el horario de trabajo 5" + ex.Message)
        Finally
            Disconnect()
        End Try



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

        '\\\\\\\\\ TERMINA DE AGREGAR UN HORARIO DE TRABAJO A LA BASE DE DATOS Y LIMPIA LOS CAMPOS PARA AGREGAR OTRO \\\\\\\\\\\\

        Connection.Open()
        '///// CARGA LA TABLA DE TAREAS//////
        'aca se escoge solo el color, nombre del curso, dia, horaInicio y horaFin que le pertenecen al usuario y al mismo periodo
        Dim HWstrSQL As String = "select t.color, t.nameTask, t.duedate, t.idTask
                                    from Subject s, Period p, Task t
                                    where p.idPeriod =" & Integer.Parse(IdPeriodLabel.Text) & "
                                    and p.idPeriod = s.idPeriod
                                    and s.idSubject = " & selectedCoursId & "
                                    and s.idSubject = t.idSubject
                                    and p.idStudent =" & Integer.Parse(IdUserLabel.Text) & "
                                    ;"
        Dim da2 As New SqlDataAdapter(HWstrSQL, Connection)
        Dim ds2 As New DataSet
        'If ColorCounterLabel.Text = " " Then
        Call CType(HomeForm.WSDataGridView.DataSource, DataTable).Rows.Clear()
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

    End Sub

    Private Sub ColorWorkSRComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorWorkSRComboBox.SelectedIndexChanged
        If ColorWorkSRComboBox.SelectedIndex <> -1 Then
            ColorWorkSRComboBox.BackColor = Color.FromName(ColorWorkSRComboBox.SelectedItem.ToString)
        End If
    End Sub


    Private Sub ColorWorkSRComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ColorWorkSRComboBox.DrawItem


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

    Private Sub AddWorkForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Un contador para saber si ya se registro un periodo lectivo
        'Period.PeriodCounter = 0
        'MsgBox("This is the periodocounter at load " & Period.PeriodCounter)
        Dim knownColors = System.Enum.GetNames(GetType(KnownColor)).
            Where(Function(kc) GetType(SystemColors).GetProperty(kc) Is Nothing _
            AndAlso kc <> KnownColor.Transparent.ToString()).
            OrderBy(Function(kc) kc)

        With ColorWorkSRComboBox
            .DrawMode = DrawMode.OwnerDrawFixed
            .IntegralHeight = False
            .MaxDropDownItems = 8
            .DataSource = knownColors.ToList
            .SelectedIndex = 0
            .SelectedItem = Color.AliceBlue
        End With
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Hide()
        HomeForm.Show()
    End Sub

End Class