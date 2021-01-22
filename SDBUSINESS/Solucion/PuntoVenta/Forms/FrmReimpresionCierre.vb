Imports Business
Public Class FrmReimpresionCierre
    Private Sub CargaCombos()
        Dim CajaCierreEncabezado As New TCajaCierreEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            With CajaCierreEncabezado
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
            End With
            Mensaje = CajaCierreEncabezado.LoadComboBox(CmbCierres)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CajaCierreEncabezado = Nothing
        End Try
    End Sub


    Public Sub Execute()
        CargaCombos()
        BtnImprimir.Enabled = (CmbCierres.Items.Count > 0)
        Me.ShowDialog()
    End Sub



    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Dim CajaCierreEncabezado As New TCajaCierreEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            BtnImprimir.Enabled = False
            BtnSalir.Enabled = False


            With CajaCierreEncabezado
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CmbCierres.SelectedValue
            End With
            Mensaje = CajaCierreEncabezado.ListKey()
            VerificaMensaje(Mensaje)

            ImprimirCierre(CajaCierreEncabezado, ChkResumido.Checked)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CajaCierreEncabezado = Nothing
            BtnImprimir.Enabled = True
            BtnSalir.Enabled = True
        End Try
    End Sub

    Private Sub ImprimirCierre(pCajaCierreEncabezado As TCajaCierreEncabezado, pResumido As Boolean)
        Dim ImprimeCierre As TImprimeCierre = Nothing
        Dim ImprimeCierreParalelo As TImprimeCierreParalelo = Nothing
        Dim TipoImpresion As PrintLocation
        Try

            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.ParaleloPuerto
                    ImprimeCierreParalelo = New TImprimeCierreParalelo(EmpresaInfo, SucursalInfo, CajaInfo, pCajaCierreEncabezado, pResumido)

                    If Not ImprimeCierreParalelo.Print(InfoMaquina.ParallePort, False) Then
                        VerificaMensaje("Se presentaron problemas de impresión")
                    End If
                Case PrintLocation.Tectel
                    ImprimeCierreCajaCarta(SucursalInfo.Suc_Id, CajaInfo.Caja_Id, CmbCierres.SelectedValue)

                Case Else

                    TipoImpresion = PrintLocation.Paralelo
                    ImprimeCierre = New TImprimeCierre(EmpresaInfo, SucursalInfo, CajaInfo, pCajaCierreEncabezado, pResumido)

                    If Not ImprimeCierre.Print(TipoImpresion, False) Then
                        VerificaMensaje("Se presentaron problemas de impresión")
                    End If

            End Select


            'If InfoMaquina.PrintLocation = PrintLocation.ParaleloPuerto Then
            '    ImprimeCierreParalelo = New TImprimeCierreParalelo(EmpresaInfo, SucursalInfo, CajaInfo, pCajaCierreEncabezado, pResumido)

            '    If Not ImprimeCierreParalelo.Print(InfoMaquina.ParallePort, False) Then
            '        VerificaMensaje("Se presentaron problemas de impresión")
            '    End If
            'Else
            '    Select Case InfoMaquina.PrintLocation
            '        Case PrintLocation.Serial
            '            TipoImpresion = PrintLocation.Serial
            '        Case PrintLocation.Paralelo, PrintLocation.Carta1
            '            TipoImpresion = PrintLocation.Paralelo
            '        Case Else
            '            TipoImpresion = PrintLocation.Paralelo
            '    End Select


            '    ImprimeCierre = New TImprimeCierre(EmpresaInfo, SucursalInfo, CajaInfo, pCajaCierreEncabezado, pResumido)

            '    If Not ImprimeCierre.Print(TipoImpresion, False) Then
            '        VerificaMensaje("Se presentaron problemas de impresión")
            '    End If
            'End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ImprimeCierre = Nothing
            ImprimeCierreParalelo = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class