Imports Business
Public Class FrmAcercaDe
    Public Sub Execute()
        Me.ShowDialog()
    End Sub

    Private Sub VisitarLink()
        LblLinkWeb.LinkVisited = True
        System.Diagnostics.Process.Start("http://www.softdesign.cr")
    End Sub

    Private Sub LblLinkWeb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblLinkWeb.LinkClicked
        Try
            VisitarLink()

        Catch ex As Exception
            MensajeError("Ocurrió un error a la hora de visitar el link")
        End Try
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick
        Encriptar()
    End Sub

End Class