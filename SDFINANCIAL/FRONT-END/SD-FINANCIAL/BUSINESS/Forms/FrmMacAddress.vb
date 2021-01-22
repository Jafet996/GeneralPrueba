Public Class FrmMacAddress
    Public Sub Execute()
        Try

            TxtMacAddress.Text = GetMAC()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class