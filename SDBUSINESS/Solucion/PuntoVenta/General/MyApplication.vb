Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object,
        ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) _
        Handles Me.StartupNextInstance
            MessageBox.Show("Ya existe una instancia abierta...", "Verificación de instancias", Nothing, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace