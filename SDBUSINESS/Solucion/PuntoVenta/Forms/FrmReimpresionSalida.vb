Imports Business
Public Class FrmReimpresionSalida
    Public Sub Execute()
        CargaCombo()
        CargaComboSalida()
        Me.Text = "Reimpresión Salida de Efectivo"
        Me.ShowDialog()
    End Sub

    Private Sub CargaCombo()
        Dim CajaCierreEncabezado As New TCajaCierreEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With CajaCierreEncabezado
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
            End With
            Mensaje = CajaCierreEncabezado.CargaComboBox(CmbCierres)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CajaCierreEncabezado = Nothing
        End Try
    End Sub
    Private Sub CargaComboSalida()
        Dim CajaSalidaEfectivo As New TCajaSalidaEfectivo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With CajaSalidaEfectivo
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CmbCierres.SelectedValue
            End With
            Mensaje = CajaSalidaEfectivo.LoadComboBox(CmbSalida)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CajaSalidaEfectivo = Nothing
        End Try
    End Sub
    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Dim CajaSalida As New TCajaSalidaEfectivo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            BtnImprimir.Enabled = False
            BtnSalir.Enabled = False


            With CajaSalida
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CajaInfo.Cierre_Id
                .Salida_Id = CmbSalida.SelectedValue
            End With
            Mensaje = CajaSalida.ListKey()
            VerificaMensaje(Mensaje)

            ImprimirSalida(CajaSalida, ChkResumido.Checked)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CajaSalida = Nothing
            BtnImprimir.Enabled = True
            BtnSalir.Enabled = True
        End Try
    End Sub

    Private Sub ImprimirSalida(pCajaSalidaEfectivo As TCajaSalidaEfectivo, pResumido As Boolean)
        Dim ImprimeCierre As TImprimeSalidaEfectivo = Nothing
        Dim ImprimeCierreParalelo As TImprimeSalidaEfectivo = Nothing
        Dim TipoImpresion As PrintLocation
        Try
            If InfoMaquina.PrintLocation = PrintLocation.ParaleloPuerto Then
                ImprimeCierreParalelo = New TImprimeSalidaEfectivo(EmpresaInfo, SucursalInfo, CajaInfo, pCajaSalidaEfectivo, pResumido)

                If Not ImprimeCierreParalelo.Print(InfoMaquina.ParallePort, False) Then
                    VerificaMensaje("Se presentaron problemas de impresión")
                End If
            Else
                Select Case InfoMaquina.PrintLocation
                    Case PrintLocation.Serial
                        TipoImpresion = PrintLocation.Serial
                    Case PrintLocation.Paralelo, PrintLocation.Carta1
                        TipoImpresion = PrintLocation.Paralelo
                    Case Else
                        TipoImpresion = PrintLocation.Paralelo
                End Select


                ImprimeCierre = New TImprimeSalidaEfectivo(EmpresaInfo, SucursalInfo, CajaInfo, pCajaSalidaEfectivo, pResumido)

                If Not ImprimeCierre.Print(TipoImpresion, False) Then
                    VerificaMensaje("Se presentaron problemas de impresión")
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ImprimeCierre = Nothing
            ImprimeCierreParalelo = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CmbCierres_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCierres.SelectedIndexChanged
        If CmbCierres.SelectedValue Is Nothing OrElse CmbCierres.SelectedValue.ToString = "System.Data.DataRowView" Then
            Exit Sub
        End If
        CargaComboSalida()
    End Sub
End Class