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

        'hola
    End Sub
End Class