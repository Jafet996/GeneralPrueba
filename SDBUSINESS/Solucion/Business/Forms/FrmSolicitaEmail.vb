Imports System.Windows.Forms

Public Class FrmSolicitaEmail


    Public Property Email As String
    Public Property Acepto As Boolean = False

    Public Sub Execute()


        If Email <> String.Empty AndAlso IsValidEmailFormat(Email) Then
            TxtEmail.Text = Email

            TxtEmail.Select()
        End If


        Me.ShowDialog()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Email = String.Empty
        Acepto = False

        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            If TxtEmail.Text.Trim = String.Empty Then
                VerificaMensaje("Debe de ingresar un Email")
            End If

            If Not IsValidEmailFormat(TxtEmail.Text.Trim) Then
                VerificaMensaje("El Email no es válido")
            End If

            Email = TxtEmail.Text.Trim

            Acepto = True

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmSolicitaEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try

            Select Case e.KeyCode
                Case Keys.F3
                    BtnAceptar.PerformClick()
                Case Keys.Escape
                    BtnSalir.PerformClick()
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class