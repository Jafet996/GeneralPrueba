Imports Business
Public Class TImprimeFactura
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _EmpresaParametro As TEmpresaParametro
    Private _Sucursal As TSucursal
    Private _FacturaEncabezado As TFacturaEncabezado
    Private _TotalCantidad As Double = 0.00
#End Region

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pEmpresaParametro As TEmpresaParametro, ByVal pSucursal As TSucursal, ByVal pFacturaEnzabezado As TFacturaEncabezado)
        MyBase.New()

        _Empresa = pEmpresa
        _EmpresaParametro = pEmpresaParametro
        _Sucursal = pSucursal
        _FacturaEncabezado = pFacturaEnzabezado

    End Sub

    Protected Overrides Sub Print_Doc()
        Dim y As Integer = 0

        ImprimeEncabezado(y)
        ImprimeDetalle(y)
        ImprimePieFactura(y)
    End Sub

    Private Sub ImprimeEncabezado(ByRef y As Integer)
        Dim Leyenda As String = ""

        If _FacturaEncabezado.Reimpresion Then
            Send("--REIMPRESION--", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        End If

        'Send(_Empresa.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsCenter, 5)
        'Send(_Sucursal.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsCenter, 5)
        'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
        'Send(_Empresa.Nombre, PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
        'Send(_Sucursal.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)


        Leyenda = _Empresa.Nombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 25).Trim, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        End While
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        If _Empresa.RazonSocial <> "" Then
            Send(_Empresa.RazonSocial, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        If _Empresa.Cedula <> "" Then
            If _Empresa.TipoIdentificacion_Id = Enum_TipoIdentificacion.Fisica Then
                Send("Cédula Física: " & _Empresa.Cedula, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
            ElseIf _Empresa.TipoIdentificacion_Id = Enum_TipoIdentificacion.Juridica Then
                Send("Cédula Jurídica: " & _Empresa.Cedula, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
            Else
                Send("Cédula: " & _Empresa.Cedula, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
            End If
        End If
        If _Sucursal.Telefono <> "" Then
            Send("Tel: " & _Sucursal.Telefono, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        'Send("Fax: " & _Sucursal.Fax, PrintFont.FontSingle, 140, y, PrintJustification.epsleft, 15)
        If _Sucursal.Email <> "" Then
            Send("Email: " & _Sucursal.Email, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send(CentraTexto(_FacturaEncabezado.TipoDocumentoNombre), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send(_FacturaEncabezado.TipoDocumentoNombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Caja: " + Format(_FacturaEncabezado.Caja_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Factura: " + Format(_FacturaEncabezado.Documento_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha: " + Format(_FacturaEncabezado.Fecha, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cajero: " & _FacturaEncabezado.UsuarioNombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cliente: " & _FacturaEncabezado.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Moneda: " & IIf(_FacturaEncabezado.Dolares = 0, "Colones", "Dólares"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        If _FacturaEncabezado.Comentario.Length > 0 Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Leyenda = "Comentario: " & _FacturaEncabezado.Comentario
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If


        If _FacturaEncabezado.EsPrefactura Then
            Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
            Send("-- PRE FACTURA --", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        End If


        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cant Descripción                  Precio", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)

    End Sub

    Private Function CreaStrNumero(pMonto As Double) As String
        Dim MontoStr As String = ""

        MontoStr = Format(pMonto, "#,##0.00")

        If MontoStr.ToString().Length <= 12 Then
            MontoStr = StrDup(12 - MontoStr.Length, " ") & MontoStr
        End If

        Return MontoStr
    End Function

    Private Sub ImprimeDetalle(ByRef y As Integer)
        Dim Leyenda As String = ""
        Dim Precio As Double = 0

        For Each Fila As TFacturaDetalle In _FacturaEncabezado.FacturaDetalles
            If _FacturaEncabezado.Dolares Then
                Precio = Fila.Precio / _FacturaEncabezado.TipoCambio
            Else
                Precio = Fila.Precio
            End If


            Sleep(300)
            Send(Alinea_Columnas(IIf(Fila.ExentoIV = 0, "*", " ") & Format(Fila.Cantidad, "0.00"), True, False, 4), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
            _TotalCantidad += Fila.Cantidad
            'Send(Alinea_Columnas(Mid(IIf(Fila.ExentoIV, " ", "*") & Fila.Descripcion, 1, 20), True, False, 24), PrintFont.FontSingle, 25, y, PrintJustification.epsleft, 0)


            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Leyenda = " " & IIf(InfoMaquina.ImprimeCodigoArticulo, Fila.Art_Id & " - ", "") & Fila.Descripcion & IIf(Fila.Observacion <> "", " : " & Fila.Observacion, "")
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 31).Trim, PrintFont.FontSingle, 45, y, PrintJustification.epsleft, 15)
            End While
            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

            If Math.Abs(Fila.Cantidad) > 1 Then
                Send(Alinea_Columnas(CreaStrNumero(Precio), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 15)
            End If
            If _FacturaEncabezado.TipoDoc_Id = "3" Or _FacturaEncabezado.TipoDoc_Id = "4" Then

                Send(Alinea_Columnas(CreaStrNumero(Math.Round(Precio * Fila.Cantidad)), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 0)
            Else
                Send(Alinea_Columnas(CreaStrNumero(Precio * Fila.Cantidad), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 0)
            End If

            'Send(Alinea_Columnas(CreaStrNumero(Precio * Fila.Cantidad), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 0)
            'If Not Fila.ExentoIV Then
            '    Send(Alinea_Columnas("*", True, True, 10), PrintFont.FontSingle, 242, y, PrintJustification.epsleft, 0)
            'End If

            Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            Sleep(300)
        Next
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("* = Artículo Gravado", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(300)

        ' --------------- ORIGINAL
        'For Each Fila As TFacturaDetalle In _FacturaEncabezado.FacturaDetalles
        '    Sleep(300)
        '    Send(Alinea_Columnas(Format(Fila.Cantidad, "###"), True, False, 4), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
        '    Send(Alinea_Columnas(Mid(IIf(Fila.ExentoIV, " ", "*") & Fila.Descripcion, 1, 20), True, False, 24), PrintFont.FontSingle, 25, y, PrintJustification.epsleft, 0)
        '    Send(Alinea_Columnas(CreaStrNumero(Fila.Precio * Fila.Cantidad), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 0)
        '    'If Not Fila.ExentoIV Then
        '    '    Send(Alinea_Columnas("*", True, True, 10), PrintFont.FontSingle, 242, y, PrintJustification.epsleft, 0)
        '    'End If

        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Sleep(300)
        'Next
        'Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("* = Artículo Gravado", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Sleep(300)
    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Dim DescPago As String = ""
        Dim Leyenda As String = ""
        Dim SubTotal As Double = 0
        Dim Descuento As Double = 0
        Dim IV As Double = 0
        Dim Redondeo As Double = 0
        Dim TotalCobrado As Double = 0
        Dim _CalculaMontoIV As Double = 0
        Dim IVNeto As Double = 0

        If _FacturaEncabezado.Dolares Then
            SubTotal = _FacturaEncabezado.Subtotal / _FacturaEncabezado.TipoCambio
            Descuento = _FacturaEncabezado.Descuento / _FacturaEncabezado.TipoCambio
            IV = _FacturaEncabezado.IV / _FacturaEncabezado.TipoCambio
            Redondeo = _FacturaEncabezado.Redondeo / _FacturaEncabezado.TipoCambio
            TotalCobrado = _FacturaEncabezado.TotalCobrado / _FacturaEncabezado.TipoCambio
        Else
            SubTotal = _FacturaEncabezado.Subtotal
            Descuento = _FacturaEncabezado.Descuento
            IV = _FacturaEncabezado.IV
            Redondeo = _FacturaEncabezado.Redondeo
            TotalCobrado = _FacturaEncabezado.TotalCobrado
        End If



        Send("Cantidad Total ...:" & Alinea_Columnas(Format(_TotalCantidad, "#,##0"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Sub Total ...:" & Alinea_Columnas(Format(SubTotal, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        If Math.Abs(Descuento) > 0 Then
            Send("Descuento ...:" & Alinea_Columnas(Format(Descuento, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If
        If Math.Abs(_FacturaEncabezado.IV) > 0 Then
            Send("Monto IVA...:" & Alinea_Columnas(Format(IV, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If
        'Mike 16/12/2020
        For Each Pago As TFacturaPago In _FacturaEncabezado.FacturaPagos
            If Pago.TipoPago_Id = 2 AndAlso EmpresaInfo.DevuelveIV Then
                If Math.Round(_FacturaEncabezado.TotalDevuelveIVImp) <> 0 Then
                    Send("IVA Devuelto .......: " & Alinea_Columnas(IIf(_FacturaEncabezado.Dolares <> 0, Format(IV, "#,##0.00"), Format(_FacturaEncabezado.TotalDevuelveIVImp, "#,##0.00")), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                    If _FacturaEncabezado.TotalDevuelveIVImp <> 0 Then
                        Send("IVA Neto .......: " & Alinea_Columnas(Format(IVNeto, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                    End If
                    Exit For
                End If
            End If
        Next
        If Math.Abs(Redondeo) > 0 Then
            Send("Redondeo  ...:" & Alinea_Columnas(Format(Redondeo, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

        Send("Total .......:" & Alinea_Columnas(IIf(_FacturaEncabezado.Dolares = 0, Format(_FacturaEncabezado.TotalCobrado, "#,##0.00"), Format(TotalCobrado, "#,##0.00")), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'If _FacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.Credito AndAlso _FacturaEncabezado.MontoPrima > 0 Then
        '    Send("Prima .......:" & Alinea_Columnas(Format(_FacturaEncabezado.MontoPrima, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '    Send("Saldo .......:" & Alinea_Columnas(Format(_FacturaEncabezado.TotalCobrado - _FacturaEncabezado.MontoPrima, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'End If



        'If Math.Abs(_FacturaEncabezado.MontoPrima) > 0 Then
        '    Send("Prima .......:" & Alinea_Columnas(Format(_FacturaEncabezado.MontoPrima, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'End If

        'If Math.Abs(_FacturaEncabezado.RecargoCredito) > 0 Then
        '    Send("Intereses ...:" & Alinea_Columnas(Format(_FacturaEncabezado.RecargoCredito, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'End If

        'Send("Saldo .......:" & Alinea_Columnas(Format((_FacturaEncabezado.TotalCobrado - _FacturaEncabezado.MontoPrima) + _FacturaEncabezado.RecargoCredito, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Sleep(300)

        Sleep(300)

        If _FacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.Contado Then
            If _FacturaEncabezado.TotalEfectivo > 0 AndAlso _CalculaMontoIV <> 0 Then                 '_FacturaEncabezado.TotalEfectivo + _FacturaEncabezado.Vuelto
                Send("Pagó con ......:" & Alinea_Columnas(CreaStrNumero(_CalculaMontoIV), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Else
                Send("Pagó con -------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End If
            For Each Pago As TFacturaPago In _FacturaEncabezado.FacturaPagos
                If Pago.Monto > 0 Then
                    Select Case Pago.TipoPago_Id
                        Case Enum_TipoPago.Efectivo
                            DescPago = "Efectivo ....:"
                        Case Enum_TipoPago.Cheque
                            DescPago = "Cheque ......:"
                        Case Enum_TipoPago.Tarjeta
                            DescPago = "Tarjeta .....:"
                        Case Enum_TipoPago.Puntos
                            DescPago = "Puntos ......:"
                        Case Enum_TipoPago.Dolares
                            DescPago = "Dólares  ....:"
                    End Select

                    Send(DescPago & Alinea_Columnas(CreaStrNumero(Pago.Monto), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                End If

                Sleep(300)
            Next
            Send("Vuelto ......:" & Alinea_Columnas(CreaStrNumero(_FacturaEncabezado.Vuelto), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If


        'If _FacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.Credito Then
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Send("    --------------------------------    ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '    Send("              Firma Cliente             ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        'End If

        If _FacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.Credito Then
            Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            Send("    --------------------------------    ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("              Firma Cliente             ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)

            If _FacturaEncabezado.CxCCuotaMensual <> 0 AndAlso EmpresaParametroInfo.GeneraCuotasCredito Then
                Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
                Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
                Send("Cuota Mensual  :" & Alinea_Columnas(CreaStrNumero(_FacturaEncabezado.CxCCuotaMensual), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                Send("Cantidad Cuotas:" & Alinea_Columnas(CreaStrNumero(_FacturaEncabezado.CxCCuotas), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
                Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            End If

            Send("Interes x mora : %" & _EmpresaParametro.PorcMora.ToString(), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        End If



        If _EmpresaParametro.LeyendaFactura1.Trim <> "" Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

            Leyenda = _EmpresaParametro.LeyendaFactura1
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
        End If
        Sleep(200)
        If _EmpresaParametro.LeyendaFactura2.Trim <> "" Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

            Leyenda = _EmpresaParametro.LeyendaFactura2
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
            End While
        End If

        'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Sistema Desarrollado por SoftDesign", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send(Alinea_Columnas("          www.softdesign.cr", 15, True), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        If EmpresaParametroInfo.PuntosActivo AndAlso _FacturaEncabezado.Puntos <> 0 Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("Puntos Ganados ......:" & Format(_FacturaEncabezado.Puntos, "#,##0"), PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
            Send("Puntos Disponibles ..:" & Format(_FacturaEncabezado.Cliente.PuntosAcumulados - _FacturaEncabezado.Cliente.PuntosCanjeados, "#,##0"), PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If


        If _EmpresaParametro.FacturacionElectronica Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

            If Not _FacturaEncabezado.ReferenciaNC Is Nothing AndAlso _FacturaEncabezado.ReferenciaNC.Codigo <> "" Then
                Send("Información de Referencia", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                Send("Fecha : " & Format(_FacturaEncabezado.Fecha, "dd/MM/yyyy"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                Send("Documento : " & _FacturaEncabezado.ReferenciaNC.Documento, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                Send("Razón : " & _FacturaEncabezado.ReferenciaNC.Razon, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End If

            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)


            Send(NombreDocumentoElectronico(Mid(_FacturaEncabezado.FacturaElectronica.Consecutivo, 9, 2)), PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
            Send(_FacturaEncabezado.FacturaElectronica.Consecutivo, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
            Send("Clave ------------------------------------", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
            Send(Mid(_FacturaEncabezado.FacturaElectronica.Clave, 1, 25), PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
            Send(Mid(_FacturaEncabezado.FacturaElectronica.Clave, 26, 25), PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)

            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

            Leyenda = _FacturaEncabezado.FacturaElectronica.Leyenda
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While

            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

            Send(Alinea_Columnas("www.facturar.cr", 15, True), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        End If


    End Sub
End Class
