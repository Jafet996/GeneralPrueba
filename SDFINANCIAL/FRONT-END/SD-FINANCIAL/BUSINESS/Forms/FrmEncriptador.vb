Public Class FrmEncriptador
    Public Sub Execute()
        Try

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged
        Try
            If TxtValor.Text.Trim <> String.Empty Then
                If RdbEncriptar.Checked Then
                    TxtResultado.Text = LockPassword(TxtValor.Text.Trim)
                Else
                    TxtResultado.Text = UnLockPassword(TxtValor.Text.Trim)
                End If
            Else
                TxtResultado.Text = String.Empty
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class