﻿Public Class FrmMensaje
    Private Sub FrmMensaje_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Windows.Forms.Keys.Escape, Windows.Forms.Keys.Enter
                Me.Close()
        End Select
    End Sub
    Public Sub Execute(pMensaje As String)
        LblMensaje.Text = pMensaje.Trim
        Me.Focus()
        Me.ShowDialog()
    End Sub
End Class