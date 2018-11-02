Public Class EditScheduleForm
    Private Sub SaveSRButton_Click(sender As Object, e As EventArgs) Handles SaveSRButton.Click
        'cuando se oprime el boton de guardar, se esconde el form de editar horario y se despliega el de inicio
        Me.Hide()
        HomeForm.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'cuando se oprime el boton de cancelar, se esconde el form de editar horario y se despliega el de inicio
        Me.Hide()
        HomeForm.Show()
    End Sub

End Class