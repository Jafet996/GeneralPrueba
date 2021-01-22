Imports CrystalDecisions.Shared
Imports System.Threading
Imports Business
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing

Public Module General
#Region "Variables"
    Public Modulo_Id As Modulos
#End Region

    Public Function VerificaModificacionFactura(pTipo As Enum_TipoFacturacion, pProforma As TProformaEncabezado) As String
        Try
            Select Case pTipo
                Case Enum_TipoFacturacion.Factura
                    If EmpresaParametroInfo.PrefacturaCompromete AndAlso Not pProforma Is Nothing AndAlso pProforma.Tipo = Enum_TipoFacturacion.PreFactura Then
                        VerificaMensaje("Imposible modificar el documento debido a que la prefactura comprometió inventario, para cualquier modificación debe de eliminar la prefactura y volver a crearla")
                    End If
            End Select

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function RevisaCajaEstado(pAbierta As Boolean) As Boolean
        Dim Caja As New TCaja(EmpresaInfo.Emp_Id)
        Try

            With Caja
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
            End With
            VerificaMensaje(Caja.ListKey)

            Return (pAbierta = Caja.Abierta)
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            Caja = Nothing
        End Try
    End Function
    Public Function ImprimeCierreCajaCarta(pSuc_Id As String, pCaja_Id As String, pCierre_Id As String)

        Dim Mensaje As String = ""
        Dim Cierre As New TCajaCierreEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptCierreCaja
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor
            With Cierre
                .Suc_Id = pSuc_Id
                .Caja_Id = pCaja_Id
                .Cierre_Id = pCierre_Id
            End With

            Mensaje = Cierre.RepCierreCaja()
            VerificaMensaje(Mensaje)

            If Cierre.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Cierre.Data.Tables(0))
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)


            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Cierre = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function
    Public Sub ImprimePrefactura(pProformaEncabezado As TProformaEncabezado)
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim FacturaDetalle As TFacturaDetalle
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim ThdImpresion As Thread

        Try

            VerificaMensaje(pProformaEncabezado.ListKey())

            Cliente.Cliente_Id = pProformaEncabezado.Cliente_Id
            VerificaMensaje(Cliente.ListKey())

            With FacturaEncabezado
                .Emp_Id = pProformaEncabezado.Emp_Id
                .Suc_Id = pProformaEncabezado.Suc_Id
                .Caja_Id = 0
                .TipoDoc_Id = pProformaEncabezado.TipoDoc_Id
                .Documento_Id = pProformaEncabezado.Documento_Id
                .Bod_Id = pProformaEncabezado.Bod_Id
                .Fecha = pProformaEncabezado.Fecha
                .Cliente_Id = pProformaEncabezado.Cliente_Id
                .Nombre = pProformaEncabezado.Nombre
                .Vendedor_Id = pProformaEncabezado.Vendedor_Id
                .Usuario_Id = pProformaEncabezado.Usuario_Id
                .Comentario = pProformaEncabezado.Comentario
                .Costo = pProformaEncabezado.Costo
                .Subtotal = pProformaEncabezado.Subtotal
                .Descuento = pProformaEncabezado.Descuento
                .IV = pProformaEncabezado.IV
                .Total = pProformaEncabezado.Total
                .Redondeo = pProformaEncabezado.Redondeo
                .TotalCobrado = pProformaEncabezado.TotalCobrado
                .Cierre_Id = pProformaEncabezado.Cierre_Id
                .CPU = pProformaEncabezado.CPU
                .HostName = pProformaEncabezado.HostName
                .IPAddress = pProformaEncabezado.IPAddress
                .TipoDocumentoNombre = pProformaEncabezado.TipoDocumentoNombre
                .UsuarioNombre = pProformaEncabezado.UsuarioNombre
                .Vuelto = 0
                .Exento = pProformaEncabezado.Exento
                .Gravado = pProformaEncabezado.Gravado
                .Dolares = pProformaEncabezado.Dolares
                .TipoCambio = pProformaEncabezado.TipoCambio
                .Reimpresion = False
                .ImpresionPrefactura = True
                .Cliente = Cliente
                .Proforma = pProformaEncabezado
                .DireccionEntrega = pProformaEncabezado.DireccionEntrega
                .Vendedor.Emp_Id = pProformaEncabezado.Emp_Id
                .Vendedor.Vendedor_Id = pProformaEncabezado.Vendedor_Id
                '.IVA1 = pProformaEncabezado.IVA1
                '.IVA13 = pProformaEncabezado.IVA13
            End With
            VerificaMensaje(FacturaEncabezado.Vendedor.ListKey())

            For Each Det As TProformaDetalle In pProformaEncabezado.ProformaDetalles
                FacturaDetalle = New TFacturaDetalle(EmpresaInfo.Emp_Id)

                With FacturaDetalle
                    .Emp_Id = Det.Emp_Id
                    .Suc_Id = Det.Suc_Id
                    .Caja_Id = 0
                    .TipoDoc_Id = pProformaEncabezado.TipoDoc_Id
                    .Documento_Id = Det.Documento_Id
                    .Detalle_Id = Det.Detalle_Id
                    .Art_Id = Det.Art_Id
                    .Cantidad = Det.Cantidad
                    .Fecha = Det.Fecha
                    .Costo = Det.Costo
                    .Precio = Det.Precio
                    .PorcDescuento = Det.PorcDescuento
                    .MontoDescuento = Det.MontoDescuento
                    .MontoIV = Det.MontoIV
                    .TotalLinea = Det.TotalLinea
                    .ExentoIV = Det.ExentoIV
                    .Suelto = Det.Suelto
                    .Descripcion = Det.Descripcion
                    .Usuario = Det.Usuario
                    .Observacion = Det.Observacion
                    .Ubicacion = Det.Ubicacion
                    .CodigoProveedor = Det.CodigoProveedor
                End With

                FacturaEncabezado.FacturaDetalles.Add(FacturaDetalle)
            Next

            ThdImpresion = New Thread(AddressOf ImprimePrefacturaFormulario)
            ThdImpresion.Start(FacturaEncabezado)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaEncabezado = Nothing
            FacturaDetalle = Nothing
        End Try
    End Sub
    Public Function ImprimeFactura(pFacturaEncabezado As TFacturaEncabezado)
        Try
            'Cambios Mike: 03/11/2020
            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.ParaleloPuerto, PrintLocation.LaPerfumeria, PrintLocation.PerfumesPOS, PrintLocation.Serial, PrintLocation.Paralelo
                    If Not pFacturaEncabezado.Reimpresion Then
                        AbrirCajon()
                    End If
            End Select

            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.ParaleloPuerto
                    Return ImprimeDocumentoParalelo(pFacturaEncabezado)
                Case PrintLocation.Carta1
                    Return CargaDatosFactura(PrintLocation.Carta1, pFacturaEncabezado)
                Case PrintLocation.Perfumes
                    Return CargaDatosFactura(PrintLocation.Perfumes, pFacturaEncabezado)
                Case PrintLocation.NuevaPiel
                    Return CargaDatosFactura(PrintLocation.NuevaPiel, pFacturaEncabezado)
                Case PrintLocation.LaPerfumeria
                    Return ImprimeLaPerfumeria(pFacturaEncabezado)
                Case PrintLocation.PerfumesPOS
                    Return ImprimePerfumesPOS(pFacturaEncabezado)
                Case PrintLocation.Tectel
                    Return CargaDatosFactura(PrintLocation.Tectel, pFacturaEncabezado)
                Case PrintLocation.CartaPety
                    Return CargaDatosFactura(PrintLocation.CartaPety, pFacturaEncabezado)
                Case PrintLocation.CartaGeneral
                    Return CargaDatosFactura(PrintLocation.CartaGeneral, pFacturaEncabezado)
                Case PrintLocation.PCW
                    Return CargaDatosFactura(PrintLocation.CartaGeneral, pFacturaEncabezado)
                Case PrintLocation.EVISecurity
                    Return CargaDatosFactura(PrintLocation.EVISecurity, pFacturaEncabezado)
                Case PrintLocation.SanMartinPOS
                    Return CargaDatosFactura(PrintLocation.SanMartinPOS, pFacturaEncabezado)
                    'Return ImprimeSanMartinPOS(pFacturaEncabezado)
                    'Cambios Mike: 03/11/2020
                Case PrintLocation.CartaFrutyLac
                    Return CargaDatosFactura(PrintLocation.CartaFrutyLac, pFacturaEncabezado)
                Case PrintLocation.ServicentroDelCarmen
                    If (pFacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.Credito) Then
                        ImprimeDocumento(pFacturaEncabezado)
                        Return ImprimeDocumento(pFacturaEncabezado)
                    Else
                        If MessageBox.Show("¿Desean Imprimir la factura?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            Return ImprimeDocumento(pFacturaEncabezado)
                        Else
                            Return ""
                        End If
                    End If

                Case Else
                    Return ImprimeDocumento(pFacturaEncabezado)
            End Select


        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ImprimePrefacturaFormulario(pFacturaEncabezado As TFacturaEncabezado)
        Try

            pFacturaEncabezado.EsPrefactura = True

            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.ParaleloPuerto
                    Return ImprimeDocumentoParalelo(pFacturaEncabezado)
                Case PrintLocation.Carta1
                    Return CargaDatosFactura(PrintLocation.Carta1, pFacturaEncabezado)
                Case PrintLocation.Perfumes
                    Return CargaDatosFactura(PrintLocation.Perfumes, pFacturaEncabezado)
                Case PrintLocation.NuevaPiel
                    Return CargaDatosFactura(PrintLocation.NuevaPiel, pFacturaEncabezado)
                Case PrintLocation.LaPerfumeria
                    Return ImprimeLaPerfumeria(pFacturaEncabezado)
                Case PrintLocation.PerfumesPOS
                    Return ImprimePerfumesPOS(pFacturaEncabezado)
                Case PrintLocation.Tectel
                    Return CargaDatosFactura(PrintLocation.Tectel, pFacturaEncabezado)
                Case PrintLocation.CartaPety
                    Return CargaDatosPrefactura(PrintLocation.CartaPety, pFacturaEncabezado)
                Case PrintLocation.CartaGeneral
                    Return CargaDatosPrefactura(PrintLocation.CartaGeneral, pFacturaEncabezado)
                Case PrintLocation.SanMartinPOS
                    Return CargaDatosFactura(PrintLocation.SanMartinPOS, pFacturaEncabezado)
                Case Else
                    Return ImprimeDocumento(pFacturaEncabezado)
            End Select


        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ImprimeProforma(pProformaEncabezado As TProformaEncabezado)
        Try
            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Paralelo
                    Return CargaDatosProforma(InfoMaquina.PrintLocation, pProformaEncabezado)
                Case PrintLocation.Carta1
                    Return CargaDatosProforma(PrintLocation.Carta1, pProformaEncabezado)
                Case PrintLocation.Tectel
                    Return CargaDatosProforma(InfoMaquina.PrintLocation, pProformaEncabezado)
                Case PrintLocation.EVISecurity
                    Return CargaDatosProforma(InfoMaquina.PrintLocation, pProformaEncabezado)
                Case PrintLocation.PCW
                    Return CargaDatosProforma(PrintLocation.PCW, pProformaEncabezado)
                Case Else
                    Return CargaDatosProforma(PrintLocation.CartaGeneral, pProformaEncabezado)
            End Select

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ImprimePerfumesPOS(pFacturaEncabezado As TFacturaEncabezado) As String
        Dim ImprimeFactura As New TImprimeFacturaPerfumes(EmpresaInfo, EmpresaParametroInfo, SucursalInfo, pFacturaEncabezado)
        Dim TipoImpresion As PrintLocation

        Try
            TipoImpresion = PrintLocation.Paralelo

            If ImprimeFactura.Print(TipoImpresion, True) Then
                If Not pFacturaEncabezado.ImpresionPrefactura Then
                    If InfoMaquina.ImprimeInformacionCliente Then
                        If Not pFacturaEncabezado.Proforma Is Nothing AndAlso (pFacturaEncabezado.Proforma.TipoEntrega_Id = Enum_TipoEntrega.Encomienda Or pFacturaEncabezado.Proforma.TipoEntrega_Id = Enum_TipoEntrega.Mensajero) Then
                            ImprimeClienteInformacion(pFacturaEncabezado.Cliente_Id, pFacturaEncabezado.DireccionEntrega)
                        End If
                    End If
                End If
                Return ""
            Else
                Return "Se presentaron problemas al imprimir el documento"
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeFactura = Nothing
        End Try
    End Function

    Public Function ImprimeLaPerfumeria(pFacturaEncabezado As TFacturaEncabezado) As String
        Dim ImprimeFactura As New TImprimeLaPerfumeria(EmpresaInfo, EmpresaParametroInfo, SucursalInfo, pFacturaEncabezado)
        Dim TipoImpresion As PrintLocation

        Try
            TipoImpresion = PrintLocation.Paralelo

            If ImprimeFactura.Print(TipoImpresion, True) Then
                'If Not pFacturaEncabezado.ImpresionPrefactura Then
                '    If InfoMaquina.ImprimeInformacionCliente Then
                '        If Not pFacturaEncabezado.Proforma Is Nothing AndAlso (pFacturaEncabezado.Proforma.TipoEntrega_Id = Enum_TipoEntrega.Encomienda Or pFacturaEncabezado.Proforma.TipoEntrega_Id = Enum_TipoEntrega.Mensajero) Then
                '            ImprimeClienteInformacion(pFacturaEncabezado.Cliente_Id, pFacturaEncabezado.DireccionEntrega)
                '        End If
                '    End If
                'End If
                Return ""
            Else
                Return "Se presentaron problemas al imprimir el documento"
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeFactura = Nothing
        End Try
    End Function

    Public Function ImprimeDocumento(pFacturaEncabezado As TFacturaEncabezado) As String
        Dim ImprimeFactura As New TImprimeFactura(EmpresaInfo, EmpresaParametroInfo, SucursalInfo, pFacturaEncabezado)
        Dim TipoImpresion As PrintLocation

        Try
            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Serial
                    TipoImpresion = PrintLocation.Serial
                Case PrintLocation.Paralelo
                    TipoImpresion = PrintLocation.Paralelo
                Case PrintLocation.ServicentroDelCarmen
                    TipoImpresion = PrintLocation.Paralelo
                Case Else
                    TipoImpresion = PrintLocation.Serial
            End Select

            If ImprimeFactura.Print(TipoImpresion, True) Then
                Return ""
            Else
                Return "Se presentaron problemas al imprimir el documento"
            End If

        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeFactura = Nothing
        End Try
    End Function
    Public Function ImprimeSanMartinPOS(pFacturaEncabezado As TFacturaEncabezado) As String
        Dim ImprimeFactura As New TImprimeSanMartinPOS(EmpresaInfo, EmpresaParametroInfo, SucursalInfo, pFacturaEncabezado)
        Dim TipoImpresion As PrintLocation
        Try

            TipoImpresion = PrintLocation.Paralelo

            If ImprimeFactura.Print(TipoImpresion, True) Then
                Return ""
            Else
                Return "Se presentaron problemas al imprimir el documento"
            End If

        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeFactura = Nothing
        End Try
    End Function

    Public Function ImprimeDocumentoParalelo(pFacturaEncabezado As TFacturaEncabezado) As String
        Dim ImprimeFacturaParalelo As New TImprimeFacturaParalelo(EmpresaInfo, EmpresaParametroInfo, SucursalInfo, pFacturaEncabezado)

        Try
            If ImprimeFacturaParalelo.Print(InfoMaquina.ParallePort, True) Then
                Return ""
            Else
                Return "Se presentaron problemas al imprimir el documento"
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeFacturaParalelo = Nothing
        End Try
    End Function


    Public Function VerificaSaldoArticulo(pSuc_Id As Integer, pBod_Id As Integer, pArt_Id As String, pCantidad As Double) As String
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Try


            With ArticuloBodega
                .Suc_Id = pSuc_Id
                .Bod_Id = pBod_Id
                .Art_Id = pArt_Id
            End With

            VerificaMensaje(ArticuloBodega.VerificaArticuloApartado(pCantidad))

            If ArticuloBodega.RowsAffected = 0 Then
                VerificaMensaje("El artículo no esta definido para la bodega de ventas ")
            End If



            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ArticuloBodega = Nothing
        End Try
    End Function


#Region "Imprime Formatos Crystal"
    Public Function CargaDatosFactura(pPrintLocation As PrintLocation, pFacturaEncabezado As TFacturaEncabezado) As String
        Dim Ds As New DatosPuntoVenta()
        Dim Reg As DataRow = Nothing
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Vencimiento As DateTime = #1/1/1900#
        Dim TipoPago As String = ""
        Dim TipoCambio As Double = 1
        Dim Banco As New TBanco(EmpresaInfo.Emp_Id)
        Dim DocumentoSTR As String
        Dim cont As Integer = 0

        Try
            'DocumentoSTR = pFacturaEncabezado.Suc_Id.ToString + pFacturaEncabezado.Caja_Id.ToString + pFacturaEncabezado.TipoDoc_Id.ToString + StrDup(7 - pFacturaEncabezado.Documento_Id.ToString.Length, "0") + pFacturaEncabezado.Documento_Id.ToString

            DocumentoSTR = pFacturaEncabezado.GetDocumentoSTR()

            'Carga valores de la empresa
            Reg = Ds.Tables("Empresa").NewRow()
            Reg("Emp_Id") = EmpresaInfo.Emp_Id
            Reg("Nombre") = EmpresaInfo.Nombre
            Reg("Cedula") = EmpresaInfo.Cedula
            Reg("Telefono") = EmpresaInfo.Telefono
            Reg("Fax") = EmpresaInfo.Fax
            Reg("Email") = EmpresaInfo.Email
            Reg("Direccion") = EmpresaInfo.Direccion
            Reg("Activo") = EmpresaInfo.Activo
            Reg("Leyenda1") = EmpresaParametroInfo.LeyendaFactura1
            Reg("Leyenda2") = EmpresaParametroInfo.LeyendaFactura2
            Ds.Tables("Empresa").Rows.Add(Reg)

            'Carga valores del Cliente
            Cliente.Cliente_Id = pFacturaEncabezado.Cliente_Id
            VerificaMensaje(Cliente.ListKey())

            Reg = Ds.Tables("Cliente").NewRow()
            Reg("Emp_Id") = Cliente.Emp_Id
            Reg("Cliente_Id") = Cliente.Cliente_Id
            Reg("Nombre") = Cliente.Nombre
            Reg("Telefono1") = Cliente.Telefono1
            Reg("Telefono2") = Cliente.Telefono2
            Reg("Email") = Cliente.Email
            Reg("CorreoCotizaciones") = Cliente.CorreoCotizaciones
            Reg("Direccion") = Cliente.Direccion
            Reg("Apartado") = Cliente.Apartado
            Reg("PorcDescContado") = Cliente.PorcDescContado
            Reg("PorcDescCredito") = Cliente.PorcDescCredito
            Reg("LimiteCredito") = Cliente.LimiteCredito
            Reg("Saldo") = Cliente.Saldo
            Reg("FacturaCredito") = Cliente.FacturaCredito
            Reg("DiasCredito") = Cliente.DiasCredito
            Reg("PorcMora") = Cliente.PorcMora
            Reg("DiasGraciaMora") = Cliente.DiasGraciaMora
            Reg("AplicaMora") = Cliente.AplicaMora
            Reg("Activo") = Cliente.Activo
            Reg("UltimaModificacion") = Cliente.UltimaModificacion
            Reg("Precio_Id") = Cliente.Precio_Id
            Reg("Cedula") = Cliente.Cedula
            Ds.Tables("Cliente").Rows.Add(Reg)

            TipoPago = ""
            'Busca el tipo de pago
            For Each Pago As TFacturaPago In pFacturaEncabezado.FacturaPagos
                Select Case Pago.TipoPago_Id
                    Case Enum_TipoPago.Efectivo
                        If InStr(TipoPago, "Efectivo") = 0 Then
                            TipoPago = TipoPago & IIf(TipoPago = String.Empty, "", "/") & "Efectivo"
                        End If
                    Case Enum_TipoPago.Tarjeta
                        If InStr(TipoPago, "Tarjeta") = 0 Then
                            TipoPago = TipoPago & IIf(TipoPago = String.Empty, "", "/") & "Tarjeta"
                        End If
                    Case Enum_TipoPago.Cheque
                        Banco.Banco_Id = Pago.Banco_Id
                        Banco.ListKey()
                        If InStr(TipoPago, "Cheque") = 0 Then
                            TipoPago = TipoPago & IIf(TipoPago = String.Empty, "", "/") & IIf(Banco.Transferencia, "Transferencia", "Cheque")
                        End If
                End Select
            Next

            If pFacturaEncabezado.Dolares Then
                TipoCambio = IIf(pFacturaEncabezado.TipoCambio > 0, pFacturaEncabezado.TipoCambio, 1)
            End If

            'Carga valores del encabezado
            Reg = Ds.Tables("FacturaEncabezado").NewRow()
            Reg("Emp_Id") = pFacturaEncabezado.Emp_Id
            Reg("Suc_Id") = pFacturaEncabezado.Suc_Id
            Reg("Caja_Id") = pFacturaEncabezado.Caja_Id
            Reg("TipoDoc_Id") = pFacturaEncabezado.TipoDoc_Id
            Reg("Documento_Id") = pFacturaEncabezado.Documento_Id
            Reg("Bod_Id") = pFacturaEncabezado.Bod_Id
            Reg("Fecha") = pFacturaEncabezado.Fecha
            Reg("Vencimiento") = Vencimiento
            Reg("Cliente_Id") = pFacturaEncabezado.Cliente_Id
            Reg("Nombre") = pFacturaEncabezado.Nombre
            Reg("Vendedor_Id") = pFacturaEncabezado.Vendedor_Id
            Reg("Usuario_Id") = pFacturaEncabezado.Usuario_Id
            Reg("Comentario") = pFacturaEncabezado.Comentario
            Reg("TipoPago") = TipoPago
            Reg("Costo") = pFacturaEncabezado.Costo / TipoCambio
            Reg("Subtotal") = pFacturaEncabezado.Subtotal / TipoCambio
            Reg("Descuento") = pFacturaEncabezado.Descuento / TipoCambio
            Reg("IV") = pFacturaEncabezado.IV / TipoCambio
            Reg("Total") = pFacturaEncabezado.Total / TipoCambio
            Reg("Redondeo") = pFacturaEncabezado.Redondeo / TipoCambio
            Reg("TotalCobrado") = pFacturaEncabezado.TotalCobrado / TipoCambio
            Reg("Cierre_Id") = pFacturaEncabezado.Cierre_Id
            Reg("CPU") = pFacturaEncabezado.CPU
            Reg("HostName") = pFacturaEncabezado.HostName
            Reg("IPAddress") = pFacturaEncabezado.IPAddress
            Reg("Exento") = pFacturaEncabezado.Exento / TipoCambio
            Reg("Gravado") = pFacturaEncabezado.Gravado / TipoCambio
            Reg("Dolares") = pFacturaEncabezado.Dolares
            Reg("TipoCambio") = pFacturaEncabezado.TipoCambio
            Reg("ConsecutivoFE") = pFacturaEncabezado.FacturaElectronica.Consecutivo
            Reg("ClaveFE") = pFacturaEncabezado.FacturaElectronica.Clave
            Reg("FeLeyenda") = pFacturaEncabezado.FacturaElectronica.Leyenda
            Reg("TipoDocNombreFE") = pFacturaEncabezado.FacturaElectronica.TipoDocNombre
            Reg("DocumentoSTR") = DocumentoSTR
            Reg("MontoEnLetras") = pFacturaEncabezado.MontoEnLetras()
            Reg("VendedorNombre") = pFacturaEncabezado.Vendedor.Nombre
            'Cambios Mike: 03/11/2020

            pFacturaEncabezado.IVA1 = 0
            pFacturaEncabezado.IVA13 = 0

            For Each IVA As TFacturaDetalle In pFacturaEncabezado.FacturaDetalles()
                If IVA.ArticuloImpuestos.Count > 0 AndAlso (IVA.ArticuloImpuestos.Item(0).Codigo_Id = "01" Or IVA.ArticuloImpuestos.Item(0).Codigo_Id = "07") Then
                    '0.1%
                    pFacturaEncabezado.IVA1 += IIf(IVA.ArticuloImpuestos.Item(0).Porcentaje = 1, (IVA.ArticuloImpuestos.Item(0).Monto * IVA.Cantidad) / pFacturaEncabezado.TipoCambio, 0)
                    '0.13%
                    pFacturaEncabezado.IVA13 += IIf(IVA.ArticuloImpuestos.Item(0).Porcentaje = 13, (IVA.ArticuloImpuestos.Item(0).Monto * IVA.Cantidad) / pFacturaEncabezado.TipoCambio, 0)

                End If

                Reg("IVA1") = pFacturaEncabezado._IVA1
                Reg("IVA13") = pFacturaEncabezado._IVA13
            Next

            Ds.Tables("FacturaEncabezado").Rows.Add(Reg)

            'Carga valores del detalle
            For Each Det As TFacturaDetalle In pFacturaEncabezado.FacturaDetalles()
                Reg = Ds.Tables("FacturaDetalle").NewRow()
                Reg("Emp_Id") = Det.Emp_Id
                Reg("Suc_Id") = Det.Suc_Id
                Reg("Caja_Id") = Det.Caja_Id
                Reg("TipoDoc_Id") = Det.TipoDoc_Id
                Reg("Documento_Id") = Det.Documento_Id
                Reg("Detalle_Id") = Det.Detalle_Id
                Reg("Art_Id") = Det.Art_Id
                Reg("Cantidad") = Det.Cantidad
                Reg("Fecha") = Det.Fecha
                Reg("Costo") = Det.Costo / TipoCambio
                Reg("Precio") = Det.Precio / TipoCambio
                Reg("PorcDescuento") = Det.PorcDescuento
                Reg("MontoDescuento") = Det.MontoDescuento / TipoCambio
                Reg("MontoIV") = Det.MontoIV / TipoCambio
                Reg("TotalLinea") = Det.TotalLinea / TipoCambio
                Reg("ExentoIV") = Det.ExentoIV
                Reg("Suelto") = Det.Suelto
                Reg("ArtNombre") = Det.Descripcion
                Reg("Observacion") = Det.Observacion
                ' Se agrega campo para mostrar porcentaje de IVA - CLGC - 16/07/2020 
                ' Se agrega el % al campo PorcImpuesto -LMCG - 20/07/2020 
                ' poner una validacion

                If Det.ArticuloImpuestos.Count = 0 Then
                    Reg("PorcImpuesto") = 0 & "%"
                Else
                    Reg("PorcImpuesto") = Det.ArticuloImpuestos.Item(0).Porcentaje & "%"
                End If



                Ds.Tables("FacturaDetalle").Rows.Add(Reg)

            Next

            Select Case pPrintLocation
                Case PrintLocation.Carta1
                    Do
                        ImprimeCarta1(Ds)
                    Loop While MsgBox("Desea imprimir otra copia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Impresión de factura") = MsgBoxResult.Yes
                Case PrintLocation.Perfumes
                    Do
                        ImprimeFacturaPerfumes(Ds)
                    Loop While MsgBox("Desea imprimir otra copia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Impresión de factura") = MsgBoxResult.Yes
                Case PrintLocation.NuevaPiel
                    Do
                        ImprimeFacturaNuevaPiel(Ds)
                    Loop While MsgBox("Desea imprimir otra copia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Impresión de factura") = MsgBoxResult.Yes
                Case PrintLocation.Tectel
                    VerificaMensaje(ImprimeFacturaTectel(Ds, pFacturaEncabezado.Cliente.Nombre, DocumentoSTR, pFacturaEncabezado.Reimpresion))
                Case PrintLocation.EVISecurity
                    VerificaMensaje(ImprimeFacturaEvySecurity(Ds, pFacturaEncabezado.Cliente.Nombre, DocumentoSTR, pFacturaEncabezado.Reimpresion))
                Case PrintLocation.CartaPety
                    VerificaMensaje(ImprimeCartaPety(Ds, pFacturaEncabezado.Cliente.Nombre, DocumentoSTR, pFacturaEncabezado.Reimpresion))
                Case PrintLocation.SanMartinPOS
                    Do
                        ImprimeSanMartinPOS(pFacturaEncabezado)
                        If cont >= 1 Then
                            Exit Do
                        End If
                        cont = cont + 1
                    Loop While MsgBox("Desea imprimir otra copia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Impresión de factura") = MsgBoxResult.Yes
                'Cambios Mike: 03/11/2020
                Case PrintLocation.CartaFrutyLac
                    Do
                        ImprimeCartaFrutyLac(Ds)
                    Loop While MsgBox("Desea imprimir otra copia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Impresión de factura") = MsgBoxResult.Yes
                Case Else
                    VerificaMensaje(ImprimeCartaGeneral(Ds, pFacturaEncabezado.Cliente.Nombre, DocumentoSTR, pFacturaEncabezado.Reimpresion))
            End Select

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Ds = Nothing
            Cliente = Nothing
            Banco = Nothing
        End Try
    End Function
    Public Function CargaDatosPrefactura(pPrintLocation As PrintLocation, pFacturaEncabezado As TFacturaEncabezado) As String
        Dim Ds As New DatosPuntoVenta()
        Dim Reg As DataRow = Nothing
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Vencimiento As DateTime = #1/1/1900#
        Dim TipoPago As String = ""
        Dim TipoCambio As Double = 1
        Dim Banco As New TBanco(EmpresaInfo.Emp_Id)
        Dim DocumentoSTR As String

        Try
            DocumentoSTR = pFacturaEncabezado.Suc_Id.ToString + pFacturaEncabezado.Caja_Id.ToString + pFacturaEncabezado.TipoDoc_Id.ToString + StrDup(7 - pFacturaEncabezado.Documento_Id.ToString.Length, "0") + pFacturaEncabezado.Documento_Id.ToString
            'Carga valores de la empresa
            Reg = Ds.Tables("Empresa").NewRow()
            Reg("Emp_Id") = EmpresaInfo.Emp_Id
            Reg("Nombre") = EmpresaInfo.Nombre
            Reg("Cedula") = EmpresaInfo.Cedula
            Reg("Telefono") = EmpresaInfo.Telefono
            Reg("Fax") = EmpresaInfo.Fax
            Reg("Email") = EmpresaInfo.Email
            Reg("Direccion") = EmpresaInfo.Direccion
            Reg("Activo") = EmpresaInfo.Activo
            Reg("Leyenda1") = EmpresaParametroInfo.LeyendaFactura1
            Reg("Leyenda2") = EmpresaParametroInfo.LeyendaFactura2
            Ds.Tables("Empresa").Rows.Add(Reg)

            'Carga valores del Cliente
            Cliente.Cliente_Id = pFacturaEncabezado.Cliente_Id
            VerificaMensaje(Cliente.ListKey())

            Reg = Ds.Tables("Cliente").NewRow()
            Reg("Emp_Id") = Cliente.Emp_Id
            Reg("Cliente_Id") = Cliente.Cliente_Id
            Reg("Nombre") = Cliente.Nombre
            Reg("Telefono1") = Cliente.Telefono1
            Reg("Telefono2") = Cliente.Telefono2
            Reg("Email") = Cliente.Email
            Reg("Direccion") = Cliente.Direccion
            Reg("Apartado") = Cliente.Apartado
            Reg("PorcDescContado") = Cliente.PorcDescContado
            Reg("PorcDescCredito") = Cliente.PorcDescCredito
            Reg("LimiteCredito") = Cliente.LimiteCredito
            Reg("Saldo") = Business.SaldoClienteCxC(Cliente.Cliente_Id)
            Reg("FacturaCredito") = Cliente.FacturaCredito
            Reg("DiasCredito") = Cliente.DiasCredito
            Reg("PorcMora") = Cliente.PorcMora
            Reg("DiasGraciaMora") = Cliente.DiasGraciaMora
            Reg("AplicaMora") = Cliente.AplicaMora
            Reg("Activo") = Cliente.Activo
            Reg("UltimaModificacion") = Cliente.UltimaModificacion
            Reg("Precio_Id") = Cliente.Precio_Id
            Reg("Cedula") = Cliente.Cedula
            Reg("Referencia") = Cliente.Referencia
            Ds.Tables("Cliente").Rows.Add(Reg)

            TipoPago = ""
            'Busca el tipo de pago
            For Each Pago As TFacturaPago In pFacturaEncabezado.FacturaPagos
                Select Case Pago.TipoPago_Id
                    Case Enum_TipoPago.Efectivo
                        If InStr(TipoPago, "Efectivo") = 0 Then
                            TipoPago = TipoPago & IIf(TipoPago = String.Empty, "", "/") & "Efectivo"
                        End If
                    Case Enum_TipoPago.Tarjeta
                        If InStr(TipoPago, "Tarjeta") = 0 Then
                            TipoPago = TipoPago & IIf(TipoPago = String.Empty, "", "/") & "Tarjeta"
                        End If
                    Case Enum_TipoPago.Cheque
                        Banco.Banco_Id = Pago.Banco_Id
                        Banco.ListKey()
                        If InStr(TipoPago, "Cheque") = 0 Then
                            TipoPago = TipoPago & IIf(TipoPago = String.Empty, "", "/") & IIf(Banco.Transferencia, "Transferencia", "Cheque")
                        End If
                End Select
            Next

            If pFacturaEncabezado.Dolares Then
                TipoCambio = IIf(pFacturaEncabezado.TipoCambio > 0, pFacturaEncabezado.TipoCambio, 1)
            End If

            'Carga valores del encabezado
            Reg = Ds.Tables("FacturaEncabezado").NewRow()
            Reg("Emp_Id") = pFacturaEncabezado.Emp_Id
            Reg("Suc_Id") = pFacturaEncabezado.Suc_Id
            Reg("Caja_Id") = pFacturaEncabezado.Caja_Id
            Reg("TipoDoc_Id") = pFacturaEncabezado.TipoDoc_Id
            Reg("Documento_Id") = pFacturaEncabezado.Documento_Id
            Reg("Bod_Id") = pFacturaEncabezado.Bod_Id
            Reg("Fecha") = pFacturaEncabezado.Fecha
            Reg("Vencimiento") = Vencimiento
            Reg("Cliente_Id") = pFacturaEncabezado.Cliente_Id
            Reg("Nombre") = pFacturaEncabezado.Nombre
            Reg("Vendedor_Id") = pFacturaEncabezado.Vendedor_Id
            Reg("Usuario_Id") = pFacturaEncabezado.Usuario_Id
            Reg("Comentario") = pFacturaEncabezado.Comentario
            Reg("TipoPago") = TipoPago
            Reg("Costo") = pFacturaEncabezado.Costo / TipoCambio
            Reg("Subtotal") = pFacturaEncabezado.Subtotal / TipoCambio
            Reg("Descuento") = pFacturaEncabezado.Descuento / TipoCambio
            Reg("IV") = pFacturaEncabezado.IV / TipoCambio
            Reg("Total") = pFacturaEncabezado.Total / TipoCambio
            Reg("Redondeo") = pFacturaEncabezado.Redondeo / TipoCambio
            Reg("TotalCobrado") = pFacturaEncabezado.TotalCobrado / TipoCambio
            Reg("Cierre_Id") = pFacturaEncabezado.Cierre_Id
            Reg("CPU") = pFacturaEncabezado.CPU
            Reg("HostName") = pFacturaEncabezado.HostName
            Reg("IPAddress") = pFacturaEncabezado.IPAddress
            Reg("Exento") = pFacturaEncabezado.Exento / TipoCambio
            Reg("Gravado") = pFacturaEncabezado.Gravado / TipoCambio
            Reg("Dolares") = pFacturaEncabezado.Dolares
            Reg("TipoCambio") = pFacturaEncabezado.TipoCambio
            Reg("ConsecutivoFE") = pFacturaEncabezado.FacturaElectronica.Consecutivo
            Reg("ClaveFE") = pFacturaEncabezado.FacturaElectronica.Clave
            Reg("FeLeyenda") = pFacturaEncabezado.FacturaElectronica.Leyenda
            Reg("TipoDocNombreFE") = pFacturaEncabezado.FacturaElectronica.TipoDocNombre
            Reg("DocumentoSTR") = DocumentoSTR
            Reg("MontoEnLetras") = pFacturaEncabezado.MontoEnLetras()
            Reg("VendedorNombre") = pFacturaEncabezado.Vendedor.Nombre
            Ds.Tables("FacturaEncabezado").Rows.Add(Reg)

            'Carga valores del detalle
            For Each Det As TFacturaDetalle In pFacturaEncabezado.FacturaDetalles()
                Reg = Ds.Tables("FacturaDetalle").NewRow()
                Reg("Emp_Id") = Det.Emp_Id
                Reg("Suc_Id") = Det.Suc_Id
                Reg("Caja_Id") = Det.Caja_Id
                Reg("TipoDoc_Id") = Det.TipoDoc_Id
                Reg("Documento_Id") = Det.Documento_Id
                Reg("Detalle_Id") = Det.Detalle_Id
                Reg("Art_Id") = Det.Art_Id
                Reg("Cantidad") = Det.Cantidad
                Reg("Fecha") = Det.Fecha
                Reg("Costo") = Det.Costo / TipoCambio
                Reg("Precio") = Det.Precio / TipoCambio
                Reg("PorcDescuento") = Det.PorcDescuento
                Reg("MontoDescuento") = Det.MontoDescuento / TipoCambio
                Reg("MontoIV") = Det.MontoIV / TipoCambio
                Reg("TotalLinea") = Det.TotalLinea / TipoCambio
                Reg("ExentoIV") = Det.ExentoIV
                Reg("Suelto") = Det.Suelto
                Reg("ArtNombre") = Det.Descripcion
                Reg("Observacion") = Det.Observacion
                Reg("Ubicacion") = Det.Ubicacion
                Reg("CodigoProveedor") = Det.CodigoProveedor
                Ds.Tables("FacturaDetalle").Rows.Add(Reg)
            Next

            Select Case pPrintLocation
                Case PrintLocation.Carta1
                    Do
                        ImprimeCarta1(Ds)
                    Loop While MsgBox("Desea imprimir otra copia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Impresión de factura") = MsgBoxResult.Yes
                Case PrintLocation.Perfumes
                    Do
                        ImprimeFacturaPerfumes(Ds)
                    Loop While MsgBox("Desea imprimir otra copia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Impresión de factura") = MsgBoxResult.Yes
                Case PrintLocation.NuevaPiel
                    Do
                        ImprimeFacturaNuevaPiel(Ds)
                    Loop While MsgBox("Desea imprimir otra copia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Impresión de factura") = MsgBoxResult.Yes
                Case PrintLocation.Tectel
                    VerificaMensaje(ImprimeFacturaTectel(Ds, pFacturaEncabezado.Cliente.Nombre, DocumentoSTR, pFacturaEncabezado.Reimpresion))
                Case PrintLocation.CartaPety
                    VerificaMensaje(ImprimePrefacturaPety(Ds, pFacturaEncabezado.Cliente.Nombre, "", pFacturaEncabezado.Reimpresion))
                Case PrintLocation.CartaGeneral
                    VerificaMensaje(ImprimePrefacturaCartaGeneral(Ds, pFacturaEncabezado.Cliente.Nombre, "", pFacturaEncabezado.Reimpresion))
            End Select

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Ds = Nothing
            Cliente = Nothing
            Banco = Nothing
        End Try
    End Function

    Private Function ImprimeCarta1(pDs As DataSet) As String
        Dim Reporte As New RptFacturaFormatoCarta1

        Try
            Cursor.Current = Cursors.WaitCursor


            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
            Reporte.SetDataSource(pDs)
            Reporte.PrintOptions.PrinterName = InfoMaquina.PrinterName
            Reporte.PrintToPrinter(1, True, 0, 0) '

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function
    Private Function ImprimeFacturaTectel(pDs As DataSet, pNombreCliente As String, pFactura As String, pReImpresion As Boolean) As String
        Dim Reporte As New RptFacturaTectel
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor


            'VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.SetDataSource(pDs)
            'Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetParameterValue("SucursalNombre", SucursalInfo.Nombre)
            Reporte.SetParameterValue("DireccionWeb", EmpresaInfo.DireccionWeb)
            If InfoMaquina.PrinterName.Trim <> String.Empty Then
                Reporte.PrintOptions.PrinterName = InfoMaquina.PrinterName
            End If

            If EmpresaParametroInfo.FacturaGeneraArchivo Then
                ExportToPdf(Reporte, EmpresaParametroInfo.FacturaCarpeta & "\Factura", pNombreCliente, pFactura)
            End If

            If EmpresaParametroInfo.FacturaImprime = Enum_FacturaImprime.Siempre OrElse pReImpresion Then
                If Not pReImpresion Then
                    Reporte.PrintToPrinter(1, True, 0, 0)
                Else
                    FormaReporte.Execute(Reporte)
                End If
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function ImprimeFacturaEvySecurity(pDs As DataSet, pNombreCliente As String, pFactura As String, pReImpresion As Boolean) As String
        Dim Reporte As New RptFacturaEvySecurity
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor


            'VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.SetDataSource(pDs)
            'Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetParameterValue("SucursalNombre", SucursalInfo.Nombre)
            Reporte.SetParameterValue("DireccionWeb", EmpresaInfo.DireccionWeb)
            If InfoMaquina.PrinterName.Trim <> String.Empty Then
                Reporte.PrintOptions.PrinterName = InfoMaquina.PrinterName
            End If

            If EmpresaParametroInfo.FacturaGeneraArchivo Then
                ExportToPdf(Reporte, EmpresaParametroInfo.FacturaCarpeta & "\Factura", pNombreCliente, pFactura)
            End If

            If EmpresaParametroInfo.FacturaImprime = Enum_FacturaImprime.Siempre OrElse pReImpresion Then
                If Not pReImpresion Then
                    Reporte.PrintToPrinter(1, True, 0, 0)
                Else
                    FormaReporte.Execute(Reporte)
                End If
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function ImprimeCartaPety(pDs As DataSet, pNombreCliente As String, pFactura As String, pReImpresion As Boolean) As String
        Dim Reporte As New RptFacturaCartaPety
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor


            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetDataSource(pDs)
            'Reporte.SetParameterValue("SucursalNombre", SucursalInfo.Nombre)
            'Reporte.SetParameterValue("DireccionWeb", EmpresaInfo.DireccionWeb)
            If InfoMaquina.PrinterName.Trim <> String.Empty Then
                Reporte.PrintOptions.PrinterName = InfoMaquina.PrinterName
            End If

            If EmpresaParametroInfo.FacturaGeneraArchivo Then
                ExportToPdf(Reporte, EmpresaParametroInfo.FacturaCarpeta & "\Factura", pNombreCliente, pFactura)
            End If

            If EmpresaParametroInfo.FacturaImprime = Enum_FacturaImprime.Siempre OrElse pReImpresion Then
                If Not pReImpresion Then
                    Reporte.PrintToPrinter(2, True, 0, 0)

                Else
                    FormaReporte.Execute(Reporte)
                End If
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function ImprimeCartaGeneral(pDs As DataSet, pNombreCliente As String, pFactura As String, pReImpresion As Boolean) As String
        Dim Reporte As New RptFacturaCartaGeneral
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor


            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetDataSource(pDs)
            'Reporte.SetParameterValue("SucursalNombre", SucursalInfo.Nombre)
            'Reporte.SetParameterValue("DireccionWeb", EmpresaInfo.DireccionWeb)
            If InfoMaquina.PrinterName.Trim <> String.Empty Then
                Reporte.PrintOptions.PrinterName = InfoMaquina.PrinterName
            End If

            If EmpresaParametroInfo.FacturaGeneraArchivo Then
                ExportToPdf(Reporte, EmpresaParametroInfo.FacturaCarpeta & "\Factura", pNombreCliente, pFactura)
            End If

            If EmpresaParametroInfo.FacturaImprime = Enum_FacturaImprime.Siempre OrElse pReImpresion Then
                If Not pReImpresion Then
                    Reporte.PrintToPrinter(1, True, 0, 0)
                Else
                    FormaReporte.Execute(Reporte)
                End If
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function
    Private Function ImprimePrefacturaPety(pDs As DataSet, pNombreCliente As String, pFactura As String, pReImpresion As Boolean) As String
        Dim Reporte As New RptPrefacturaPety
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor


            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
            Reporte.SetParameterValue("pSaldo", 55000)
            Reporte.SetDataSource(pDs)
            'Reporte.SetParameterValue("SucursalNombre", SucursalInfo.Nombre)
            'Reporte.SetParameterValue("DireccionWeb", EmpresaInfo.DireccionWeb)

            If InfoMaquina.PrinterName.Trim <> String.Empty Then
                Reporte.PrintOptions.PrinterName = InfoMaquina.PrinterName
            Else
                Dim printer As New PrinterSettings()
                Reporte.PrintOptions.PrinterName = printer.PrinterName
            End If




            'If EmpresaParametroInfo.FacturaGeneraArchivo Then
            '    ExportToPdf(Reporte, EmpresaParametroInfo.FacturaCarpeta & "\Factura", pNombreCliente, pFactura)
            'End If

            If EmpresaParametroInfo.FacturaImprime = Enum_FacturaImprime.Siempre OrElse pReImpresion Then
                If Not pReImpresion Then
                    Reporte.PrintToPrinter(1, False, 0, 0)
                Else
                    FormaReporte.Execute(Reporte)
                End If
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function ImprimePrefacturaCartaGeneral(pDs As DataSet, pNombreCliente As String, pFactura As String, pReImpresion As Boolean) As String
        Dim Reporte As New RptPrefacturaCarta
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor


            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetDataSource(pDs)
            'Reporte.SetParameterValue("SucursalNombre", SucursalInfo.Nombre)
            'Reporte.SetParameterValue("DireccionWeb", EmpresaInfo.DireccionWeb)
            If InfoMaquina.PrinterName.Trim <> String.Empty Then
                Reporte.PrintOptions.PrinterName = InfoMaquina.PrinterName
            End If

            'If EmpresaParametroInfo.FacturaGeneraArchivo Then
            '    ExportToPdf(Reporte, EmpresaParametroInfo.FacturaCarpeta & "\Factura", pNombreCliente, pFactura)
            'End If

            If EmpresaParametroInfo.FacturaImprime = Enum_FacturaImprime.Siempre OrElse pReImpresion Then
                If Not pReImpresion Then
                    Reporte.PrintToPrinter(1, True, 0, 0)
                Else
                    FormaReporte.Execute(Reporte)
                End If
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function ImprimeCxCAbonoTectel(pDs As DataSet, pNombreCliente As String, pFactura As String, pReImpresion As Boolean) As String
        Dim Reporte As New RptCxCAbonoTectel
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor


            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetDataSource(pDs)

            'Reporte.SetParameterValue("DireccionWeb", EmpresaInfo.DireccionWeb)
            If InfoMaquina.PrinterName.Trim <> String.Empty Then
                Reporte.PrintOptions.PrinterName = InfoMaquina.PrinterName
            End If

            'If EmpresaParametroInfo.FacturaGeneraArchivo Then
            '    ExportToPdf(Reporte, EmpresaParametroInfo.FacturaCarpeta & "\Abono", pNombreCliente, pFactura)
            'End If

            If EmpresaParametroInfo.FacturaImprime = Enum_FacturaImprime.Siempre OrElse pReImpresion Then
                If Not pReImpresion Then
                    Reporte.PrintToPrinter(1, True, 0, 0)
                Else
                    FormaReporte.Execute(Reporte)
                End If
            Else
                FormaReporte.Execute(Reporte)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function ImprimeCxCAbono(pDs As DataSet, pNombreCliente As String, pFactura As String, pReImpresion As Boolean) As String
        Dim Reporte As New RptCxCAbono
        Dim FormaReporte As New FrmReporte

        Try
            Cursor.Current = Cursors.WaitCursor


            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            Reporte.SetDataSource(pDs)

            Reporte.SetParameterValue("pEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pSucursal", SucursalInfo.Nombre)
            If InfoMaquina.PrinterName.Trim <> String.Empty Then
                Reporte.PrintOptions.PrinterName = InfoMaquina.PrinterName
            End If

            'If EmpresaParametroInfo.FacturaGeneraArchivo Then
            '    ExportToPdf(Reporte, EmpresaParametroInfo.FacturaCarpeta & "\Abono", pNombreCliente, pFactura)
            'End If

            If EmpresaParametroInfo.FacturaImprime = Enum_FacturaImprime.Siempre OrElse pReImpresion Then
                If Not pReImpresion Then
                    Reporte.PrintToPrinter(1, True, 0, 0)
                Else
                    FormaReporte.Execute(Reporte)
                End If
            Else
                FormaReporte.Execute(Reporte)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function
    Private Function ImprimeFacturaPerfumes(pDs As DataSet) As String
        Dim Reporte As New RptFacturaPerfumes

        Try
            Cursor.Current = Cursors.WaitCursor
            Reporte.SetDataSource(pDs)
            Reporte.PrintOptions.PrinterName = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPrinterName)
            Reporte.PrintOptions.PaperOrientation = PaperOrientation.Portrait
            Reporte.PrintToPrinter(1, True, 0, 0) '

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function
    Private Function ImprimeFacturaNuevaPiel(pDs As DataSet) As String
        Dim Reporte As New RptFacturaNuevaPiel

        Try
            Cursor.Current = Cursors.WaitCursor
            Reporte.SetDataSource(pDs)
            Reporte.PrintOptions.PrinterName = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPrinterName)
            Reporte.PrintOptions.PaperOrientation = PaperOrientation.Portrait
            Reporte.PrintToPrinter(1, True, 0, 0) '

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    'Cambios Mike: 03/11/2020
    Private Function ImprimeCartaFrutyLac(pDs As DataSet) As String
        Dim Reporte As New RptFacturaCartaFrutyLac

        Try
            Cursor.Current = Cursors.WaitCursor

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
            Reporte.SetDataSource(pDs)
            Reporte.PrintOptions.PrinterName = InfoMaquina.PrinterName
            Reporte.PrintToPrinter(1, True, 0, 0) '

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function
#End Region
#Region "Imprime Proforma"
    Public Function CargaDatosProforma(pPrintLocation As PrintLocation, pProformaEncabezado As TProformaEncabezado) As String
        Dim Ds As New DatosProforma
        Dim Reg As DataRow = Nothing
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Vencimiento As DateTime = #1/1/1900#
        Dim TipoPago As String = ""
        Dim TipoCambio As Double = 1
        Try

            'Carga valores de la empresa
            Reg = Ds.Tables("Empresa").NewRow()
            Reg("Emp_Id") = EmpresaInfo.Emp_Id
            Reg("Nombre") = EmpresaInfo.Nombre
            Reg("Cedula") = EmpresaInfo.Cedula
            Reg("Telefono") = EmpresaInfo.Telefono
            Reg("Fax") = EmpresaInfo.Fax
            Reg("Email") = EmpresaInfo.Email
            Reg("Direccion") = EmpresaInfo.Direccion
            Reg("DireccionWeb") = EmpresaInfo.DireccionWeb
            Reg("Activo") = EmpresaInfo.Activo
            Reg("Leyenda1") = EmpresaParametroInfo.LeyendaFactura1
            Reg("Leyenda2") = EmpresaParametroInfo.LeyendaFactura2
            Reg("Logo") = EmpresaInfo.Logo
            Ds.Tables("Empresa").Rows.Add(Reg)

            'Carga valores del Cliente
            Cliente.Cliente_Id = pProformaEncabezado.Cliente_Id
            VerificaMensaje(Cliente.ListKey())

            Reg = Ds.Tables("Cliente").NewRow()
            Reg("Emp_Id") = Cliente.Emp_Id
            Reg("Cliente_Id") = Cliente.Cliente_Id
            Reg("Nombre") = Cliente.Nombre
            Reg("Telefono1") = Cliente.Telefono1
            Reg("Telefono2") = Cliente.Telefono2
            Reg("Email") = Cliente.Email
            Reg("CorreoCotizaciones") = Cliente.CorreoCotizaciones
            Reg("Direccion") = Cliente.Direccion
            Reg("Apartado") = Cliente.Apartado
            Reg("PorcDescContado") = Cliente.PorcDescContado
            Reg("PorcDescCredito") = Cliente.PorcDescCredito
            Reg("LimiteCredito") = Cliente.LimiteCredito
            Reg("Saldo") = Cliente.Saldo
            Reg("FacturaCredito") = Cliente.FacturaCredito
            Reg("DiasCredito") = Cliente.DiasCredito
            Reg("PorcMora") = Cliente.PorcMora
            Reg("DiasGraciaMora") = Cliente.DiasGraciaMora
            Reg("AplicaMora") = Cliente.AplicaMora
            Reg("Activo") = Cliente.Activo
            Reg("UltimaModificacion") = Cliente.UltimaModificacion
            Reg("Cedula") = Cliente.Cedula
            Ds.Tables("Cliente").Rows.Add(Reg)


            If pProformaEncabezado.Dolares Then
                TipoCambio = IIf(pProformaEncabezado.TipoCambio > 0, pProformaEncabezado.TipoCambio, 1)
            End If

            'Carga valores del encabezado
            Reg = Ds.Tables("ProformaEncabezado").NewRow()
            Reg("Emp_Id") = pProformaEncabezado.Emp_Id
            Reg("Suc_Id") = pProformaEncabezado.Suc_Id

            Reg("Documento_Id") = pProformaEncabezado.Documento_Id
            Reg("Bod_Id") = pProformaEncabezado.Bod_Id

            Reg("TipoDoc_Id") = pProformaEncabezado.TipoDoc_Id

            Reg("Fecha") = pProformaEncabezado.Fecha
            Reg("Vencimiento") = pProformaEncabezado.Vencimiento
            'Reg("Vencimiento") = Vencimiento
            Reg("Cliente_Id") = pProformaEncabezado.Cliente_Id
            Reg("Nombre") = pProformaEncabezado.Nombre
            Reg("Vendedor_Id") = pProformaEncabezado.Vendedor_Id
            Reg("Usuario_Id") = pProformaEncabezado.Usuario_Id
            Reg("Comentario") = pProformaEncabezado.Comentario

            Reg("Costo") = pProformaEncabezado.Costo / TipoCambio
            Reg("Subtotal") = pProformaEncabezado.Subtotal / TipoCambio
            Reg("Descuento") = pProformaEncabezado.Descuento / TipoCambio
            Reg("IV") = pProformaEncabezado.IV / TipoCambio
            Reg("Total") = pProformaEncabezado.Total / TipoCambio
            Reg("Redondeo") = pProformaEncabezado.Redondeo / TipoCambio
            Reg("TotalCobrado") = pProformaEncabezado.TotalCobrado / TipoCambio
            Reg("Cierre_Id") = pProformaEncabezado.Cierre_Id
            Reg("CPU") = pProformaEncabezado.CPU
            Reg("HostName") = pProformaEncabezado.HostName
            Reg("IPAddress") = pProformaEncabezado.IPAddress
            Reg("Exento") = pProformaEncabezado.Exento / TipoCambio
            Reg("Gravado") = pProformaEncabezado.Gravado / TipoCambio
            Reg("Dolares") = pProformaEncabezado.Dolares
            Reg("TipoCambio") = pProformaEncabezado.TipoCambio
            Reg("Tipo") = pProformaEncabezado.Tipo
            Reg("MontoEnLetras") = pProformaEncabezado.MontoEnLetras
            Reg("VendedorNombre") = pProformaEncabezado.VendedorNombre
            Ds.Tables("ProformaEncabezado").Rows.Add(Reg)

            'Carga valores del detalle
            For Each Det As TProformaDetalle In pProformaEncabezado.ProformaDetalles()
                Reg = Ds.Tables("ProformaDetalle").NewRow()
                Reg("Emp_Id") = Det.Emp_Id
                Reg("Suc_Id") = Det.Suc_Id
                Reg("Documento_Id") = Det.Documento_Id
                Reg("Detalle_Id") = Det.Detalle_Id
                Reg("Art_Id") = Det.Art_Id
                Reg("Cantidad") = Det.Cantidad
                Reg("Fecha") = Det.Fecha
                Reg("Costo") = Det.Costo / TipoCambio
                Reg("Precio") = Det.Precio / TipoCambio
                Reg("PorcDescuento") = Det.PorcDescuento
                Reg("MontoDescuento") = Det.MontoDescuento / TipoCambio
                Reg("MontoIV") = Det.MontoIV / TipoCambio
                Reg("TotalLinea") = Det.TotalLinea / TipoCambio
                Reg("ExentoIV") = Det.ExentoIV
                Reg("Suelto") = Det.Suelto
                Reg("ArtNombre") = Det.Descripcion
                Reg("Observacion") = Det.Observacion
                Ds.Tables("ProformaDetalle").Rows.Add(Reg)
            Next


            Select Case pPrintLocation
                Case PrintLocation.Carta1
                    ImprimeProforma1(Ds, Cliente.Nombre, pProformaEncabezado.Documento_Id)
                Case PrintLocation.Paralelo
                    ImprimeProformaStandard(Ds, Cliente.Nombre, pProformaEncabezado.Documento_Id)
                Case PrintLocation.Tectel
                    ImprimeProformaTectel(Ds, Cliente.Nombre, pProformaEncabezado.Documento_Id)
                Case PrintLocation.EVISecurity
                    ImprimeProformaEVYSecurity(Ds, Cliente.Nombre, pProformaEncabezado.Documento_Id)
                Case PrintLocation.PCW
                    ImprimeProformaPCW(Ds, Cliente.Nombre, pProformaEncabezado.Documento_Id)
                Case Else
                    ImprimeProformaCartaGeneral(Ds, Cliente.Nombre, pProformaEncabezado.Documento_Id)
            End Select

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Ds = Nothing
            Cliente = Nothing
        End Try
    End Function

    Private Function ImprimeProforma1(pDs As DataSet, pNombreCliente As String, pFactura As String) As String
        Dim Mensaje As String = ""
        Dim Reporte As New RptProformaFormatoCarta1
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor

            Reporte.SetDataSource(pDs)


            If EmpresaParametroInfo.ProformaTipoImpresion = Enum_TipoImpresion.Directa Then
                Reporte.PrintToPrinter(1, True, 0, 0)
            Else
                FormaReporte.Execute(Reporte)
            End If

            If EmpresaParametroInfo.ProformaGeneraArchivo Then
                ExportToPdf(Reporte, EmpresaParametroInfo.ProformaCarpeta & "\Proforma", pNombreCliente, pFactura)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function ImprimeProformaTectel(pDs As DataSet, pNombreCliente As String, pFactura As String) As String
        Dim Mensaje As String = ""
        Dim Reporte As New RptProformaTectel
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor

            Reporte.SetDataSource(pDs)


            If EmpresaParametroInfo.ProformaTipoImpresion = Enum_TipoImpresion.Directa Then
                Reporte.PrintToPrinter(1, True, 0, 0)
            Else
                FormaReporte.Execute(Reporte)
            End If

            If EmpresaParametroInfo.ProformaGeneraArchivo Then
                ExportToPdf(Reporte, EmpresaParametroInfo.ProformaCarpeta & "\Proforma", pNombreCliente, pFactura)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function
    Private Function ImprimeProformaEVYSecurity(pDs As DataSet, pNombreCliente As String, pFactura As String) As String
        Dim Mensaje As String = ""
        Dim Reporte As New RptProformaEvySecurity
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor

            Reporte.SetDataSource(pDs)


            If EmpresaParametroInfo.ProformaTipoImpresion = Enum_TipoImpresion.Directa Then
                Reporte.PrintToPrinter(1, True, 0, 0)
            Else
                FormaReporte.Execute(Reporte)
            End If

            If EmpresaParametroInfo.ProformaGeneraArchivo Then
                ExportToPdf(Reporte, EmpresaParametroInfo.ProformaCarpeta & "\Proforma", pNombreCliente, pFactura)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function
    Private Function ImprimeProformaCartaGeneral(pDs As DataSet, pNombreCliente As String, pFactura As String) As String
        Dim Mensaje As String = ""
        Dim Reporte As New RptProformaFormatoCartaGeneral
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor

            Reporte.SetDataSource(pDs)
            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))

            If EmpresaParametroInfo.ProformaTipoImpresion = Enum_TipoImpresion.Directa Then
                Reporte.PrintToPrinter(1, True, 0, 0)
            Else
                FormaReporte.Execute(Reporte)
            End If

            If EmpresaParametroInfo.ProformaGeneraArchivo Then
                ExportToPdf(Reporte, EmpresaParametroInfo.ProformaCarpeta & "\Proforma", pNombreCliente, pFactura)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function ImprimeProformaStandard(pDs As DataSet, pNombreCliente As String, pFactura As String) As String
        Dim Mensaje As String = ""
        Dim Reporte As New RptProformaFormatoCartaStandard
        Dim FormaReporte As New FrmReporte
        Dim cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim cedula As String
        Try

            Cursor.Current = Cursors.WaitCursor

            With cliente
                .Nombre = pNombreCliente
            End With


            Reporte.SetDataSource(pDs)
            Reporte.SetParameterValue("pCedula", cliente.ConsultaCedulaPorNommbre())

            If EmpresaParametroInfo.ProformaTipoImpresion = Enum_TipoImpresion.Directa Then
                Reporte.PrintToPrinter(1, True, 0, 0)
            Else
                FormaReporte.Execute(Reporte)
            End If

            If EmpresaParametroInfo.ProformaGeneraArchivo Then
                ExportToPdf(Reporte, EmpresaParametroInfo.ProformaCarpeta & "\Proforma", pNombreCliente, pFactura)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function ImprimeProformaPCW(pDs As DataSet, pNombreCliente As String, pFactura As String) As String
        Dim Mensaje As String = ""
        Dim Reporte As New RptProformaFormatoCartaPCW
        Dim FormaReporte As New FrmReporte
        Dim cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim cedula As String
        Try

            Cursor.Current = Cursors.WaitCursor

            With cliente
                .Nombre = pNombreCliente
            End With


            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
            Reporte.SetDataSource(pDs)
            Reporte.SetParameterValue("pCedula", cliente.ConsultaCedulaPorNommbre())
            Reporte.SetParameterValue("PUsuario", UsuarioInfo.Nombre)

            If EmpresaParametroInfo.ProformaTipoImpresion = Enum_TipoImpresion.Directa Then
                Reporte.PrintToPrinter(1, True, 0, 0)
            Else
                FormaReporte.Execute(Reporte)
            End If

            If EmpresaParametroInfo.ProformaGeneraArchivo Then
                ExportToPdf(Reporte, EmpresaParametroInfo.ProformaCarpeta & "\Proforma", pNombreCliente, pFactura)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Reporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function ExportToPdf(pReporte As ReportClass, pReportePath As String, pNombreCliente As String, pFactura As String) As String
        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        Dim Fecha As DateTime = EmpresaInfo.Getdate()
        Try


            Try
                If Not System.IO.Directory.Exists(pReportePath & "\" & Fecha.Year & "\" & Fecha.Month & "\" & Fecha.Day) Then
                    System.IO.Directory.CreateDirectory(pReportePath & "\" & Fecha.Year & "\" & Fecha.Month & "\" & Fecha.Day)

                End If
            Catch ex As Exception
                MensajeError(ex.Message)
            End Try

            CrDiskFileDestinationOptions.DiskFileName = pReportePath & "\" & Fecha.Year & "\" & Fecha.Month & "\" & Fecha.Day & "\" & pNombreCliente & "_" & pFactura & ".pdf"

            CrExportOptions = pReporte.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            pReporte.Export()

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            CrExportOptions = Nothing
            CrDiskFileDestinationOptions = Nothing
            CrFormatTypeOptions = Nothing
        End Try
    End Function
#End Region
#Region "Abono"

    Public Function ImprimeAbonoAbonoApartado(pAbonoEncabezado As TApartadoEncabezado, Optional pReimpresion As Boolean = False) As String
        Try

            If Not pReimpresion Then AbrirCajon()

            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Paralelo
                    Return ImprimirAbonoApartado(pAbonoEncabezado, pReimpresion)
                    'Case PrintLocation.ParaleloPuerto
                    '    'Return ImprimeDocumentoParalelo(pAbonoEncabezado)
                    'Case PrintLocation.Carta1
                    '   ' Return CargaDatosFactura(PrintLocation.Carta1, pAbonoEncabezado)
                    'Case PrintLocation.Perfumes
                    '    'Return CargaDatosFactura(PrintLocation.Perfumes, pAbonoEncabezado)
                    'Case PrintLocation.NuevaPiel
                    '    'Return CargaDatosFactura(PrintLocation.NuevaPiel, pAbonoEncabezado)
                    'Case PrintLocation.LaPerfumeria
                    '    'Return ImprimeLaPerfumeria(pAbonoEncabezado)
                    'Case PrintLocation.PerfumesPOS
                    '    'Return ImprimePerfumesPOS(pAbonoEncabezado)
                    'Case PrintLocation.Tectel
                    '    Return CargaDatosAbono(PrintLocation.Tectel, pAbonoEncabezado)
                Case Else
                    Return ImprimirAbonoApartado(pAbonoEncabezado)
            End Select

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ImprimeApartado(pApartadoEncabezado As TApartadoEncabezado, Optional pReimpresion As Boolean = false) As String
        Try
            If Not pReimpresion Then AbrirCajon()

            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Paralelo
                    Return ImprimirApartado(pApartadoEncabezado, pReimpresion)
                    'Case PrintLocation.ParaleloPuerto
                    '    'Return ImprimeDocumentoParalelo(pAbonoEncabezado)
                    'Case PrintLocation.Carta1
                    '   ' Return CargaDatosFactura(PrintLocation.Carta1, pAbonoEncabezado)
                    'Case PrintLocation.Perfumes
                    '    'Return CargaDatosFactura(PrintLocation.Perfumes, pAbonoEncabezado)
                    'Case PrintLocation.NuevaPiel
                    '    'Return CargaDatosFactura(PrintLocation.NuevaPiel, pAbonoEncabezado)
                    'Case PrintLocation.LaPerfumeria
                    '    'Return ImprimeLaPerfumeria(pAbonoEncabezado)
                    'Case PrintLocation.PerfumesPOS
                    '    'Return ImprimePerfumesPOS(pAbonoEncabezado)
                    'Case PrintLocation.Tectel
                    '    Return CargaDatosAbono(PrintLocation.Tectel, pAbonoEncabezado)
                Case Else
                    Return ImprimirApartado(pApartadoEncabezado, pReimpresion)
            End Select

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ImprimirApartado(pApartadoEncabezado As TApartadoEncabezado, Optional pReimpresion As Boolean = False) As String


        Dim ImprimeFactura As New TImprimeApartado(EmpresaInfo, EmpresaParametroInfo, SucursalInfo, pApartadoEncabezado, pReimpresion)
        Dim TipoImpresion As PrintLocation

        Try
            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Serial
                    TipoImpresion = PrintLocation.Serial
                Case PrintLocation.Paralelo
                    TipoImpresion = PrintLocation.Paralelo
                Case Else
                    TipoImpresion = PrintLocation.Paralelo
            End Select

            If ImprimeFactura.Print(TipoImpresion, pReimpresion) Then
                Return ""
            Else
                Return "Se presentaron problemas al imprimir el documento"
            End If

        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeFactura = Nothing
        End Try
    End Function

    Public Function ImprimirAbonoApartado(pApartadoEncabezado As TApartadoEncabezado, Optional pReimpresion As Boolean = False) As String


        Dim ImprimeFactura As New TImprimeAbonoComp(EmpresaInfo, EmpresaParametroInfo, SucursalInfo, pApartadoEncabezado, pReimpresion)
        Dim TipoImpresion As PrintLocation

        Try
            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Serial
                    TipoImpresion = PrintLocation.Serial
                Case PrintLocation.Paralelo
                    TipoImpresion = PrintLocation.Paralelo
                Case Else
                    TipoImpresion = PrintLocation.Serial
            End Select

            If ImprimeFactura.Print(TipoImpresion, pReimpresion) Then
                Return ""
            Else
                Return "Se presentaron problemas al imprimir el documento"
            End If

        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeFactura = Nothing
        End Try
    End Function

    Public Function ImprimeAbonoCxC(pAbonoEncabezado As TCxCAbonoEncabezado) As String
        Try

            AbrirCajon()

            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Paralelo
                    Return ImprimirAbonoCxC(pAbonoEncabezado)
                'Case PrintLocation.ParaleloPuerto
                '    'Return ImprimeDocumentoParalelo(pAbonoEncabezado)
                'Case PrintLocation.Carta1
                '   ' Return CargaDatosFactura(PrintLocation.Carta1, pAbonoEncabezado)
                'Case PrintLocation.Perfumes
                '    'Return CargaDatosFactura(PrintLocation.Perfumes, pAbonoEncabezado)
                'Case PrintLocation.NuevaPiel
                '    'Return CargaDatosFactura(PrintLocation.NuevaPiel, pAbonoEncabezado)
                'Case PrintLocation.LaPerfumeria
                '    'Return ImprimeLaPerfumeria(pAbonoEncabezado)
                'Case PrintLocation.PerfumesPOS
                '    'Return ImprimePerfumesPOS(pAbonoEncabezado)
                Case PrintLocation.Tectel
                    Return CargaDatosAbono(PrintLocation.Tectel, pAbonoEncabezado)
                Case Else
                    Return ImprimirAbonoCxC(pAbonoEncabezado)
            End Select

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ImprimirAbonoCxC(pFacturaEncabezado As TCxCAbonoEncabezado) As String
        Dim ImprimeFactura As New TImprimeAbonoCxC(EmpresaInfo, EmpresaParametroInfo, SucursalInfo, pFacturaEncabezado)
        Dim TipoImpresion As PrintLocation

        Try
            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Serial
                    TipoImpresion = PrintLocation.Serial
                Case PrintLocation.Paralelo
                    TipoImpresion = PrintLocation.Paralelo
                Case Else
                    TipoImpresion = PrintLocation.Paralelo
            End Select

            If ImprimeFactura.Print(TipoImpresion, True) Then
                Return ""
            Else
                Return "Se presentaron problemas al imprimir el documento"
            End If

        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeFactura = Nothing
        End Try
    End Function



    Public Function CargaDatosAbono(pPrintLocation As PrintLocation, pAbonoEncabezado As TCxCAbonoEncabezado) As String
        Dim Ds As New DatosCxCAbono()
        Dim Reg As DataRow = Nothing
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Vencimiento As DateTime = #1/1/1900#
        Dim TipoPago As String = ""
        Dim TipoCambio As Double = 1
        Dim Banco As New TBanco(EmpresaInfo.Emp_Id)


        Try
            'Carga valores de la empresa
            Reg = Ds.Tables("Empresa").NewRow()
            Reg("Emp_Id") = EmpresaInfo.Emp_Id
            Reg("Nombre") = EmpresaInfo.Nombre
            Reg("Cedula") = EmpresaInfo.Cedula
            Reg("Telefono") = EmpresaInfo.Telefono
            Reg("Fax") = EmpresaInfo.Fax
            Reg("Email") = EmpresaInfo.Email
            Reg("Direccion") = EmpresaInfo.Direccion
            Reg("Activo") = EmpresaInfo.Activo
            Reg("Leyenda1") = EmpresaParametroInfo.LeyendaFactura1
            Reg("Leyenda2") = EmpresaParametroInfo.LeyendaFactura2
            Ds.Tables("Empresa").Rows.Add(Reg)

            'Carga valores del Cliente
            Cliente.Cliente_Id = pAbonoEncabezado.Cliente_Id
            VerificaMensaje(Cliente.ListKey())

            Reg = Ds.Tables("Cliente").NewRow()
            Reg("Emp_Id") = Cliente.Emp_Id
            Reg("Cliente_Id") = Cliente.Cliente_Id
            Reg("Nombre") = Cliente.Nombre
            Reg("Telefono1") = Cliente.Telefono1
            Reg("Telefono2") = Cliente.Telefono2
            Reg("Email") = Cliente.Email
            Reg("Direccion") = Cliente.Direccion
            Reg("Apartado") = Cliente.Apartado
            Reg("PorcDescContado") = Cliente.PorcDescContado
            Reg("PorcDescCredito") = Cliente.PorcDescCredito
            Reg("LimiteCredito") = Cliente.LimiteCredito
            Reg("Saldo") = Cliente.Saldo
            Reg("FacturaCredito") = Cliente.FacturaCredito
            Reg("DiasCredito") = Cliente.DiasCredito
            Reg("PorcMora") = Cliente.PorcMora
            Reg("DiasGraciaMora") = Cliente.DiasGraciaMora
            Reg("AplicaMora") = Cliente.AplicaMora
            Reg("Activo") = Cliente.Activo
            Reg("UltimaModificacion") = Cliente.UltimaModificacion
            Reg("Precio_Id") = Cliente.Precio_Id
            Reg("Cedula") = Cliente.Cedula
            Ds.Tables("Cliente").Rows.Add(Reg)

            'TipoPago = ""
            ''Busca el tipo de pago
            'For Each Pago As TCxCAbonoPago In pAbonoEncabezado.
            '    Select Case Pago.TipoPago_Id
            '        Case Enum_TipoPago.Efectivo
            '    If InStr(TipoPago, "Efectivo") = 0 Then
            '        TipoPago = TipoPago & IIf(TipoPago = String.Empty, "", "/") & "Efectivo"
            '    End If
            '    Case Enum_TipoPago.Tarjeta
            '    If InStr(TipoPago, "Tarjeta") = 0 Then
            '        TipoPago = TipoPago & IIf(TipoPago = String.Empty, "", "/") & "Tarjeta"
            '    End If
            '    Case Enum_TipoPago.Cheque
            '    Banco.Banco_Id = Pago.Banco_Id
            '    Banco.ListKey()
            '    If InStr(TipoPago, "Cheque") = 0 Then
            '        TipoPago = TipoPago & IIf(TipoPago = String.Empty, "", "/") & IIf(Banco.Transferencia, "Transferencia", "Cheque")
            '    End If
            '    End Select
            'Next

            'If pAbonoEncabezado.Dolares Then
            '    TipoCambio = IIf(pAbonoEncabezado.TipoCambio > 0, pAbonoEncabezado.TipoCambio, 1)
            'End If

            'Carga valores del encabezado
            Reg = Ds.Tables("CxCAbonoEncabezado").NewRow()
            Reg("Emp_Id") = pAbonoEncabezado.Emp_Id
            Reg("Suc_Id") = pAbonoEncabezado.Suc_Id
            Reg("Caja_Id") = pAbonoEncabezado.Caja_Id
            Reg("Cierre_Id") = pAbonoEncabezado.Cierre_Id
            Reg("Abono_Id") = pAbonoEncabezado.Abono_Id
            Reg("Cliente_Id") = pAbonoEncabezado.Cliente_Id
            Reg("Tipo_Id") = pAbonoEncabezado.Tipo_Id
            Reg("Fecha") = pAbonoEncabezado.Fecha
            Reg("Monto") = pAbonoEncabezado.Monto
            Reg("Usuario_Id") = pAbonoEncabezado.Usuario_Id
            Reg("Anulado") = pAbonoEncabezado.Anulado
            Reg("AnuladoFecha") = pAbonoEncabezado.AnuladoFecha
            Reg("TipoNombre") = IIf(pAbonoEncabezado.Tipo_Id = Enum_CxCAbonoTipo.Abono, "Pago CxC", "Anulación Pago CxC")
            Reg("Vendedor_Id") = pAbonoEncabezado.Vendedor_Id
            Reg("VendedorNombre") = pAbonoEncabezado.VendedorNombre
            Ds.Tables("CxCAbonoEncabezado").Rows.Add(Reg)

            'Carga valores del detalle
            For Each Det As TCxCAbonoDetalle In pAbonoEncabezado.Detalles

                Reg = Ds.Tables("CxCAbonoDetalle").NewRow()
                Reg("Emp_Id") = Det.Emp_Id
                Reg("Suc_Id") = Det.Suc_Id
                Reg("Caja_Id") = Det.Caja_Id
                Reg("Cierre_Id") = Det.Cierre_Id
                Reg("Abono_Id") = Det.Abono_Id
                Reg("Detalle_Id") = Det.Detalle_Id
                Reg("Fecha") = Det.Fecha
                Reg("Tipo_Id") = Det.Tipo_Id
                Reg("Mov_Id") = Det.Mov_Id
                Reg("Referencia") = Det.Referencia
                Ds.Tables("CxCAbonoDetalle").Rows.Add(Reg)
            Next

            Select Case pPrintLocation
                'Case PrintLocation.Carta1
                '    Do
                '        '  ImprimeCarta1(Ds)
                '    Loop While MsgBox("Desea imprimir otra copia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Impresión de factura") = MsgBoxResult.Yes
                Case PrintLocation.Tectel
                    VerificaMensaje(ImprimeCxCAbonoTectel(Ds, pAbonoEncabezado.Cliente.Nombre, pAbonoEncabezado.Abono_Id, 0))
                Case Else
                    VerificaMensaje(ImprimeCxCAbono(Ds, pAbonoEncabezado.Cliente.Nombre, pAbonoEncabezado.Abono_Id, 0))
            End Select

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Ds = Nothing
            Cliente = Nothing
            Banco = Nothing
        End Try
    End Function
#End Region
#Region "Impresion Cliente"

    Public Sub ImprimeClienteInformacion(pCliente_Id As Integer, pDireccion As String)
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim ClienteImpresion As New TClienteImpresion

        Try
            Cliente.Cliente_Id = pCliente_Id
            VerificaMensaje(Cliente.ListKey())

            With ClienteImpresion
                .Cliente_Id = Cliente.Cliente_Id
                .Nombre = Cliente.Nombre
                .Telefono = Cliente.Telefono1
                .Direccion = IIf(pDireccion.Trim = String.Empty, Cliente.Direccion, pDireccion)
                .Email = Cliente.Email
            End With
            VerificaMensaje(ImprimirCliente(ClienteImpresion))

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ImprimirCliente(pClienteImpresion As TClienteImpresion) As String
        Dim ImprimeCliente As New TImprimeCliente(InfoMaquina.ImpresoraEtiquetaCliente, pClienteImpresion)
        Dim TipoImpresion As PrintLocation

        Try
            TipoImpresion = PrintLocation.Paralelo

            If Not ImprimeCliente.Print(TipoImpresion, True) Then
                VerificaMensaje("Se presentaron problemas al imprimir el cliente")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeCliente = Nothing
        End Try
    End Function

#End Region
End Module