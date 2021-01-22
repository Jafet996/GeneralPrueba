Imports System.Windows.Forms
Public Class FrmUpcVenta
    Public Sub Execute()
        Try

            TxtPresentacion.Select()
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class