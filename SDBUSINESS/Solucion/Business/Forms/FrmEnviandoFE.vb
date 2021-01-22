Public Class FrmEnviandoFE
    Public Sub Execute(pClave As String, pCantidadStr As String)
        LblClave.Text = pClave.Trim
        LblClave.Refresh()
        LblCantidadStr.Text = pCantidadStr
        LblCantidadStr.Refresh()
        LblFecha.Text = Format(Now, "dd-MM-yyyy HH:mm:ss")

        TimerPrincipal.Enabled = True

        Me.ShowDialog()
    End Sub

    Private Sub TimerPrincipal_Tick(sender As Object, e As EventArgs) Handles TimerPrincipal.Tick
        TimerPrincipal.Enabled = False
        Me.Close()
    End Sub
End Class