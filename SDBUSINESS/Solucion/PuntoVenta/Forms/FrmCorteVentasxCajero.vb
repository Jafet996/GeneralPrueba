Imports Business
Public Class FrmCorteVentasxCajero
    Public Sub Execute()
        Try

            CargaCombos()

            Me.ShowDialog()

        Catch ex As Exception
            Me.ShowDialog()
        End Try
    End Sub


    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            If CmbUsuario.SelectedIndex < 0 Then
                VerificaMensaje("Debe de seleccionar un usuario")
            End If


            If ConfirmaAccion("Desea generar un corte de ventas para el usuario " & CmbUsuario.Text) Then
                CorteVentas()
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CorteVentas()
        Dim UsuarioCierre As New TUsuarioCierre(EmpresaInfo.Emp_Id)
        Try

            Cursor.Current = Cursors.WaitCursor

            UsuarioCierre.Usuario_Id = CmbUsuario.SelectedValue

            VerificaMensaje(UsuarioCierre.CierreCajaUsuario)


            Mensaje("Se genero el corte de ventas de manera correcta")

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            UsuarioCierre = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CargaCombos()
        Dim Usuario As New TUsuario(EmpresaInfo.Emp_Id)
        Try


            VerificaMensaje(Usuario.LoadComboBox(CmbUsuario))


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Usuario = Nothing
        End Try
    End Sub

End Class