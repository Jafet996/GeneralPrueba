Imports BUSINESS
Public Class FrmCierreProcesoAnnio
    Private Sub CargaDatos()
        Try
            If EmpresaParametroInfo.RowsAffected = 0 Then
                VerificaMensaje("No se pudo obtener el mes en proceso")
            End If

            LblMes.Tag = EmpresaParametroInfo.GetProcesoMes
            LblMes.Text = MesNombre(LblMes.Tag)
            LblAnnio.Tag = EmpresaParametroInfo.GetProcesoAnnio
            LblAnnio.Text = LblAnnio.Tag
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try
            CargaDatos()

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Function ValidaTodo() As Boolean
        Dim AsientoEncabezado As New TAsientoEncabezado
        Try

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, Permisos.CoAplicaCierrePeriodo, False) Then
                VerificaMensaje("No tiene permiso para realizar el proceso de cierre de periodo")
            End If


            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Annio = EmpresaParametroInfo.GetProcesoAnnio
                .Mes = EmpresaParametroInfo.GetProcesoMes
            End With
            VerificaMensaje(AsientoEncabezado.AsientosSinAplicar)
            If AsientoEncabezado.RowsAffected > 0 Then
                VerificaMensaje("No se puede cerrar mes, debido que hay movimientos sin aplicar")
            End If

            If EmpresaParametroInfo.GetProcesoMes <> EmpresaParametroInfo.GetMesCierreFiscal Then
                VerificaMensaje("No se puede cerrar el periodo, debido que " & MesNombre(EmpresaParametroInfo.GetMesCierreFiscal()) & " es el mes que esta definido como cierre de periodo")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            AsientoEncabezado = Nothing
        End Try
    End Function

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        Try

            If MsgBox("Desea cerrar el Periodo Fiscal?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If ValidaTodo() Then
                    Aplicar()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Aplicar()
        Dim CierrePeriodo As New TCierrePeriodo
        Try

            With CierrePeriodo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Usuario_Id = UsuarioInfo.Usuario_Id
            End With

            VerificaMensaje(CierrePeriodo.CierraPeriodoAnnio)

            MensajeError("El proceso se ejecutó correctamente")

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

End Class