Imports System.Data.SqlClient

Public Class AddStudyForm

    Private Sub AddStudySRButton_Click(sender As Object, e As EventArgs) Handles AddStudySRButton.Click

        Dim user As New User
        Dim Study As StudySch
        Study = New StudySch

        Study.Name_StudySch = NameStudySRTextBox.Text
        Study.Color_StudySch = ColorStudySRComboBox.SelectedItem.ToString

        Dim sch As Schedule
        sch = New Schedule

        sch.DIndex_Schedule = DayStudySRCheckedListBox.SelectedIndex

        Dim command As SqlCommand
        Dim insertQuery
        Dim selectQuery
        Dim reader As SqlDataReader

        Try
            Connect()
            insertQuery = "INSERT INTO Activity(name, color, idStudent) values (@name, @color, @idStudent)"

            command = New SqlCommand(insertQuery, ConnectionBD.Connection)

            With command 'le asigna los valores a los espacios en la tabla
                .Parameters.AddWithValue("@name", Study.Name_StudySch)
                .Parameters.AddWithValue("@color", Study.Color_StudySch.ToString)
                .Parameters.AddWithValue("@idStudent", User.IdUser)
            End With
            command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("No fue posible registrar el horario de estudio " + ex.Message)
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

            MsgBox("Horario guardado con éxito")

        Catch ex As Exception
            MsgBox("No fue posible registrar el horario de estudio " + ex.Message)
        Finally
            Disconnect()
        End Try

        '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////
        For Each Index In DayStudySRCheckedListBox.CheckedIndices

            'si Lunes esta marcado
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
                MsgBox("No fue posible registrar el horario de estudio " + ex.Message)
            Finally
                Disconnect()
            End Try

            Try
                Connect()
                selectQuery = "SELECT TOP 1 * FROM Schedule ORDER BY idSchedule DESC"
                command = New SqlCommand(selectQuery, ConnectionBD.Connection)
            Catch ex As Exception
                MsgBox("No fue posible registrar el horario de estudio " + ex.Message)
            Finally
                Disconnect()
            End Try

            Try
                Connect()
                insertQuery = "INSERT INTO ActivityHasSchedule(idSchedule, idSubject) values (@idSchedule, @idSubject)"
                command = New SqlCommand(insertQuery, ConnectionBD.Connection)
                reader = command.ExecuteReader
                reader.Read()
                Dim IdSch As Integer = reader.Item("idSchedule")
                With command 'le asigna los valores a los espacios en la tabla
                    .Parameters.AddWithValue("@idSchedule", IdSch)
                    .Parameters.AddWithValue("@idSubject", Study.Id_StudySch)
                End With
                command.ExecuteNonQuery()
            Catch ex As Exception
                ' MsgBox("No fue posible registrar el horario de trabajo 5" + ex.Message)
            Finally
                Disconnect()
            End Try

        Next

        NameStudySRTextBox.Clear()
        ColorStudySRComboBox.SelectedIndex = -1
        ColorStudySRComboBox.BackColor = Color.AliceBlue
        For index = 0 To DayStudySRCheckedListBox.Items.Count - 1
            DayStudySRCheckedListBox.SetItemChecked(index, False)
            DayStudySRCheckedListBox.SetItemCheckState(index, CheckState.Unchecked)
        Next

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

        '\\\\\\\\\ TERMINA DE AGREGAR UN CURSO A LA BASE DE DATOS Y LIMPIA LOS CAMPOS PARA AGREGAR OTRO \\\\\\\\\\\\
    End Sub

    Private Sub AddWorkSRButton2_Click(sender As Object, e As EventArgs) Handles AddStudySRButton2.Click

        Dim user As New User
        Dim Study As StudySch
        Study = New StudySch

        Study.Name_StudySch = NameStudySRTextBox.Text
        Study.Color_StudySch = ColorStudySRComboBox.SelectedItem.ToString

        Dim sch As Schedule
        sch = New Schedule

        sch.DIndex_Schedule = DayStudySRCheckedListBox.SelectedIndex

        Dim command As SqlCommand
        Dim insertQuery
        Dim selectQuery
        Dim reader As SqlDataReader

        Try
            Connect()
            insertQuery = "INSERT INTO Activity(name, color, idStudent) values (@name, @color, @idStudent)"

            command = New SqlCommand(insertQuery, ConnectionBD.Connection)

            With command 'le asigna los valores a los espacios en la tabla
                .Parameters.AddWithValue("@name", Study.Name_StudySch)
                .Parameters.AddWithValue("@color", Study.Color_StudySch.ToString)
                .Parameters.AddWithValue("@idStudent", User.IdUser)
            End With
            command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("No fue posible registrar el horario de estudio " + ex.Message)
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

            MsgBox("Horario guardado con éxito")

        Catch ex As Exception
            MsgBox("No fue posible registrar el horario de estudio " + ex.Message)
        Finally
            Disconnect()
        End Try

        '// SE AGREGAN LOS DIAS Y HORAS DEL CURSO A LA TABLA "SHEDULE" Y SE RELACIONA CON "ACTIVITY HAS SCHEDULE" ///////
        For Each Index In DayStudySRCheckedListBox.CheckedIndices

            'si Lunes esta marcado
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
                MsgBox("No fue posible registrar el horario de estudio " + ex.Message)
            Finally
                Disconnect()
            End Try

            Try
                Connect()
                selectQuery = "SELECT TOP 1 * FROM Schedule ORDER BY idSchedule DESC"
                command = New SqlCommand(selectQuery, ConnectionBD.Connection)
            Catch ex As Exception
                MsgBox("No fue posible registrar el horario de estudio " + ex.Message)
            Finally
                Disconnect()
            End Try

            Try
                Connect()
                insertQuery = "INSERT INTO ActivityHasSchedule(idSchedule, idSubject) values (@idSchedule, @idSubject)"
                command = New SqlCommand(insertQuery, ConnectionBD.Connection)
                reader = command.ExecuteReader
                reader.Read()
                Dim IdSch As Integer = reader.Item("idSchedule")
                With command 'le asigna los valores a los espacios en la tabla
                    .Parameters.AddWithValue("@idSchedule", IdSch)
                    .Parameters.AddWithValue("@idSubject", Study.Id_StudySch)
                End With
                command.ExecuteNonQuery()
            Catch ex As Exception
                ' MsgBox("No fue posible registrar el horario de trabajo 5" + ex.Message)
            Finally
                Disconnect()
            End Try

        Next

        NameStudySRTextBox.Clear()
        ColorStudySRComboBox.SelectedIndex = -1
        ColorStudySRComboBox.BackColor = Color.AliceBlue
        For index = 0 To DayStudySRCheckedListBox.Items.Count - 1
            DayStudySRCheckedListBox.SetItemChecked(index, False)
            DayStudySRCheckedListBox.SetItemCheckState(index, CheckState.Unchecked)
        Next

        Me.Hide()
        HomeForm.Show()

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

        '\\\\\\\\\ TERMINA DE AGREGAR UN CURSO A LA BASE DE DATOS Y LIMPIA LOS CAMPOS PARA AGREGAR OTRO \\\\\\\\\\\\
    End Sub

    ' Verificar qué día escogió para habilitar la hora
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

    Private Sub ColorStudySRComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorStudySRComboBox.SelectedIndexChanged

        If ColorStudySRComboBox.SelectedIndex <> -1 Then
            ColorStudySRComboBox.BackColor = Color.FromName(ColorStudySRComboBox.SelectedItem.ToString)
        End If
    End Sub

    Private Sub ColorStudySRComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ColorStudySRComboBox.DrawItem

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

    Private Sub AddStudyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Un contador para saber si ya se registro un periodo lectivo
        Period.PeriodCounter = 0
        'MsgBox("This is the periodocounter at load " & Period.PeriodCounter)
        Dim knownColors = System.Enum.GetNames(GetType(KnownColor)).
                Where(Function(kc) GetType(SystemColors).GetProperty(kc) Is Nothing _
                AndAlso kc <> KnownColor.Transparent.ToString()).
                OrderBy(Function(kc) kc)

        With ColorStudySRComboBox
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