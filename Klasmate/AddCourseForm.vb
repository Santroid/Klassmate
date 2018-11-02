Public Class AddCourseForm
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Cuando el boton de guardar y terminar en el Form de agregar curso, se esconde eso Form y se muestra el form de inicio
        Me.Hide()
        HomeForm.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Cuando el boton de cancelar en el Form de agregar curso, se esconde eso Form y se muestra el form de inicio
        Me.Hide()
        HomeForm.Show()
    End Sub
End Class