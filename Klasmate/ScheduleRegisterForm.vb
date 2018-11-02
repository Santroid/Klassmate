Public Class ScheduleRegisterForm

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DayCoursSRCheckedListBox.SelectedIndexChanged

    End Sub

    Private Sub SaveSRButton_Click(sender As Object, e As EventArgs) Handles SaveSRButton.Click
        'Cuando el boton de terminar en el Form de agregar horarios despues de registrarse, se esconde eso Form y se muestra la el form de inicio
        Me.Hide()
        HomeForm.Show()

    End Sub
End Class