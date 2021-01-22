Imports BUSINESS
Imports System.IO
Public Module General
#Region "Variables"
    Public Modulo_Id As Enum_Modulos
#End Region

    Public Function ImprimeListaToken(pTokens As List(Of TUsuarioCodigoPermiso))
        Dim Token As List(Of TUsuarioCodigoPermiso)

        Try
            Token = pTokens

            Select Case InfoMaquina.PrintLocation
                Case Else
                    VerificaMensaje(ImprimeToken(Token))
            End Select

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Token = Nothing
        End Try
    End Function

    Public Function ImprimeToken(pTokens As List(Of TUsuarioCodigoPermiso)) As String
        Dim ImprimeTokens As New TImprimeToken(EmpresaInfo, EmpresaParametroInfo, pTokens)
        Dim TipoImpresion As PrintLocation

        Try
            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.POS_Serial
                    TipoImpresion = PrintLocation.POS_Serial
                Case Else
                    TipoImpresion = PrintLocation.POS_Windows
            End Select

            If Not ImprimeTokens.Print(TipoImpresion, True) Then
                VerificaMensaje("Se presentaron problemas al imprimir el documento")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeTokens = Nothing
        End Try
    End Function

    Public Sub AsignaLogo(ByRef pPicLogo As PictureBox)
        Dim ToolTip1 As New ToolTip

        Try
            If Not EmpresaInfo.Logo Is Nothing Then
                Using ms As New MemoryStream()
                    ms.Write(EmpresaInfo.Logo, 0, EmpresaInfo.Logo.Length)
                    pPicLogo.Image = Image.FromStream(ms, True, True)
                End Using
            Else
                pPicLogo.Image = Nothing
            End If

            ToolTip1.SetToolTip(pPicLogo, EmpresaInfo.Nombre)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ToolTip1 = Nothing
        End Try
    End Sub

    Public Function VerificaAperturaCaja(pMuestraApertura As Boolean) As String
        Dim Caja As New TCaja
        Dim FormaCajaApertura As New FrmCajaApertura

        Try
            With Caja
                .Emp_Id = EmpresaInfo.Emp_Id
                .Caja_Id = InfoMaquina.Caja_Id
            End With
            VerificaMensaje(Caja.ListKey)

            If Caja.RowsAffected = 0 Then
                VerificaMensaje("Caja no existe")
            End If

            If Not Caja.Activo Then
                VerificaMensaje("Caja se encuentra desactivada")
            End If

            If Not Caja.Abierta Then
                If Not pMuestraApertura Then
                    VerificaMensaje("Caja se encuentra Cerrada")
                Else
                    FormaCajaApertura.Execute()
                    VerificaMensaje(VerificaAperturaCaja(False))
                End If
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Caja = Nothing
            FormaCajaApertura = Nothing
        End Try
    End Function

#Region "Imprime Movimiento"

    Public Function ImprimeMovimiento(pEmpresa As TEmpresa, pTipo_Id As Integer, pMov_Id As Long, pReimpresion As Boolean) As String
        Dim CxCMovimiento As New TCxCMovimiento
        Try

            With CxCMovimiento
                .Emp_Id = pEmpresa.Emp_Id
                .Tipo_Id = pTipo_Id
                .Mov_Id = pMov_Id
                .Reimpresion = pReimpresion
            End With
            VerificaMensaje(CxCMovimiento.ListKey)


            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Tectel
                    'Formato Tectel
                Case Else
                    Dim resultado As Integer = MessageBox.Show("¿Desea imprimir el recibo?", "Impresión", MessageBoxButtons.YesNo)

                    If resultado = DialogResult.Yes Then
                        ImprimeMovimientoPOS(pEmpresa, CxCMovimiento, pReimpresion)

                        resultado = MessageBox.Show("¿Desea imprimir otra copia?", "Impresión", MessageBoxButtons.YesNo)

                        If resultado = DialogResult.Yes Then
                            ImprimeMovimientoPOS(pEmpresa, CxCMovimiento, pReimpresion)
                        End If

                    End If

            End Select

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            CxCMovimiento = Nothing
        End Try
    End Function

    Public Function ImprimeMovimientoPOS(pEmpresa As TEmpresa, pCxCMovimiento As TCxCMovimiento, pReimpresion As Boolean) As String
        Dim ImprimeMovimiento As TImprimeCxCMovimiento
        Dim TipoImpresion As PrintLocation
        Try


            ImprimeMovimiento = New TImprimeCxCMovimiento(pEmpresa, pCxCMovimiento)

            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.POS_Serial
                    TipoImpresion = PrintLocation.POS_Serial
                Case Else
                    TipoImpresion = PrintLocation.POS_Windows
            End Select

            If Not ImprimeMovimiento.Print(TipoImpresion, True) Then
                VerificaMensaje("Se presentaron problemas al imprimir el documento")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ImprimeMovimientoTectel(pEmpresa As TEmpresa, pCxCMovimiento As TCxCMovimiento, pReimpresion As Boolean) As String
        Dim Reporte As New RptClientesConSaldo
        Dim FormaReporte As New FrmReporte
        Try

            'VerificaMensaje(pCxCMovimiento.RptCxCClientesConSaldo(CDbl(TxtSaldo.Text)))

            'If Movimiento.RowsAffected = 0 Then
            '    VerificaMensaje("No se encontraron datos para mostrar el reporte")
            'End If

            'Reporte.SetDataSource(Movimiento.Datos.Tables(0))
            'VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            'Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            'Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)

            'If Form_Abierto("FrmReporte") = False Then
            '    FormaReporte.Execute(Reporte)
            'End If


            Return String.Empty
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
        End Try
    End Function

#End Region


    Public Function ImprimeCambioMoneda(pEmpresa As TEmpresa, pCambio_Id As Integer, pReimpresion As Boolean) As String
        Dim CambioMoneda As New TCambioMoneda
        Dim ImprimeCambio As TImprimeCambioMoneda
        Dim TipoImpresion As PrintLocation

        Try
            With CambioMoneda
                .Emp_Id = pEmpresa.Emp_Id
                .Cambio_Id = pCambio_Id
            End With
            VerificaMensaje(CambioMoneda.ListKey)

            ImprimeCambio = New TImprimeCambioMoneda(pEmpresa, CambioMoneda, pReimpresion)

            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.POS_Serial
                    TipoImpresion = PrintLocation.POS_Serial
                Case Else
                    TipoImpresion = PrintLocation.POS_Windows
            End Select

            If Not ImprimeCambio.Print(TipoImpresion, True) Then
                VerificaMensaje("Se presentaron problemas al imprimir el documento")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            CambioMoneda = Nothing
        End Try
    End Function

    Public Function ImprimeCierreCaja(pEmpresa As TEmpresa, pCaja As TCaja, pResumido As Boolean, pReimpresion As Boolean) As String
        Dim CajaCierreEncabezado As New TCajaCierreEncabezado
        Dim ImprimeCierre As TImprimeCierre
        Dim TipoImpresion As PrintLocation

        Try
            With CajaCierreEncabezado
                .Emp_Id = pEmpresa.Emp_Id
                .Caja_Id = pCaja.Caja_Id
                .Cierre_Id = pCaja.Cierre_Id
            End With
            VerificaMensaje(CajaCierreEncabezado.ListKey)
            VerificaMensaje(CajaCierreEncabezado.ObtieneMovimientos)

            ImprimeCierre = New TImprimeCierre(pEmpresa, pCaja, CajaCierreEncabezado, pResumido, pReimpresion)

            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.POS_Serial
                    TipoImpresion = PrintLocation.POS_Serial
                Case Else
                    TipoImpresion = PrintLocation.POS_Windows
            End Select

            If Not ImprimeCierre.Print(TipoImpresion, True) Then
                VerificaMensaje("Se presentaron problemas al imprimir el documento")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            CajaCierreEncabezado = Nothing
        End Try
    End Function

End Module