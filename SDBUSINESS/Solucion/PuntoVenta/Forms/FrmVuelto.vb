Public Class FrmVuelto
    Public Sub Execute(pLeyenda As String, pMonto As Double)
        LblLeyenda.Text = pLeyenda
        LblMonto.Text = Format(pMonto, "#,##0.00")
        Me.ShowDialog()
    End Sub

    Private Sub FrmVuelto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape, Keys.Enter
                Me.Close()
        End Select
    End Sub
End Class