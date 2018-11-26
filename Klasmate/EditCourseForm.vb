Public Class EditCourseForm
    Private Sub CancelECFButton_Click(sender As Object, e As EventArgs) Handles CancelECFButton.Click
        Me.Hide()
        HomeForm.Show()
    End Sub
End Class