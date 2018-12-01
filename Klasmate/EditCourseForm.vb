Imports System.Data.SqlClient

Public Class EditCourseForm
    Private Sub CancelECFButton_Click(sender As Object, e As EventArgs) Handles CancelECFButton.Click
        Me.Hide()
        HomeForm.Show()
    End Sub

    Private Sub EditCourseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cdgv As DataGridView = HomeForm.CourseDataGridView
        'LIMPIA EL COMBOBOX CADA VEZ QUE SE HACE VISIBLE EL PANEL
        If EditCourseComboBox.Items.Count > 0 Then
            Dim courseCount As Integer = EditCourseComboBox.Items.Count - 1

            While courseCount >= 0
                'CoursAddHWPanelComboBox.SelectedIndex = i
                EditCourseComboBox.Items.RemoveAt(courseCount)
                courseCount = courseCount - 1
            End While
        End If
        'VUELVE A LLENAR EL COMBOBOX CADA VEZ QUE SE HACE VISIBLE EL PANEL
        For i As Integer = 0 To cdgv.Rows.Count - 1

            Dim Course As String = cdgv.Rows(i).Cells(1).Value
            EditCourseComboBox.Items.Add(Course)

        Next

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

    Private Sub ColorCoursSRComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorCoursSRComboBox.SelectedIndexChanged
        If ColorCoursSRComboBox.SelectedIndex <> -1 Then

            ColorCoursSRComboBox.BackColor = Color.FromName(ColorCoursSRComboBox.SelectedItem.ToString)
            'ColorCoursSRComboBox.SelectedText = ""
            ' Else
            '    ColorCoursSRComboBox.BackColor = Color.FromName(ColorCoursSRComboBox.SelectedItem.ToString)
        End If
    End Sub

    Private Sub ColorCoursSRComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ColorCoursSRComboBox.DrawItem

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

    Private Sub EditCourseComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EditCourseComboBox.SelectedIndexChanged
        Dim cont As Integer = EditCourseComboBox.SelectedIndex

        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"
        Dim selectQuery
        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)

        Connect()

        'declaramos la sentencia de SELECT para seleccionar de la BD
        selectQuery = "select s.color, s.nameSubject, sc.day, sc.startTime, sc.endTime, s.idSubject
                                    from Subject s, ActivityHasSchedule a, Schedule sc
                                    where s.idSubject = " & Integer.Parse(HomeForm.CourseDataGridView.Rows(cont).Cells(5).Value) & "
                                    and s.idSubject = a.idSubject
                                    and a.idSchedule = sc.idSchedule;"
        command = New SqlCommand(selectQuery, ConnectionBD.Connection)

        'ejecuta el lector de la base de datos
        Dim reader As SqlDataReader = command.ExecuteReader

        If reader.HasRows Then
            reader.Read()
            Me.NameCoursSRTextBox.Text = reader.Item("nameSubject").ToString
            Me.ColorCoursSRComboBox.SelectedItem = Color.FromName(reader.Item("color"))



        End If
        Disconnect()

    End Sub
End Class