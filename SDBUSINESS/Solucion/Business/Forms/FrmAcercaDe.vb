Imports Business
Imports System.Windows.Forms

Public Class FrmAcercaDe
    Public Sub Execute()
        Me.ShowDialog()
    End Sub

    Private Sub VisitarLink()
        LblLinkWeb.LinkVisited = True
        System.Diagnostics.Process.Start("http://www.facturar.cr")
    End Sub

    Private Sub LblLinkWeb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblLinkWeb.LinkClicked
        Try
            VisitarLink()

        Catch ex As Exception
            MensajeError("Ocurrió un error a la hora de visitar el link")
        End Try
    End Sub

    Private Sub FrmAcercaDe_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class