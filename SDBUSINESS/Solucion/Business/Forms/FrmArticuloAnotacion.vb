Imports System.Windows.Forms
Imports Business
Public Class FrmArticuloAnotacion
    Private _Art_Id As String

    Public WriteOnly Property Art_Id As String
        Set(value As String)
            _Art_Id = value
        End Set
    End Property

    Public Sub execute()
        Me.ShowDialog()
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If TxtAnotacion.Text.Trim = String.Empty Then
                VerificaMensaje("Debe de ingresar una anotación")
            End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Guardar()
        Dim ArticuloAnotacion As New TArticuloAnotacion(EmpresaInfo.Emp_Id)
        Try

            With ArticuloAnotacion
                .Art_Id = _Art_Id
                VerificaMensaje(ArticuloAnotacion.Siguiente)
                .Anotacion = TxtAnotacion.Text.Trim
                .Usuario_Id = UsuarioInfo.Usuario_Id
            End With

            VerificaMensaje(ArticuloAnotacion.Insert())

            BtnSalir.PerformClick()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloAnotacion = Nothing
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            Guardar()
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmClienteAnotacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                BtnGuardar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
End Class