Imports Business
Public Class TImprimeSanMartinPOS
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
        If _Empresa.Cedula <> "" Then
            Send("Cédula Jurídica : " & _Empresa.Cedula, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Sucursal: " & _Sucursal.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        If _Sucursal.Telefono <> "" Then
            Send("Tel: " & _Sucursal.Telefono, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        'Send("Fax: " & _Sucursal.Fax, PrintFont.FontSingle, 140, y, PrintJustification.epsleft, 15)
        If _Sucursal.Email <> "" Then
            Send("Email: " & _Sucursal.Email, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send(CentraTexto(_FacturaEncabezado.TipoDocumentoNombre), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send(_FacturaEncabezado.TipoDocumentoNombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Caja: " + Format(_FacturaEncabezado.Caja_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Factura: " + Format(_FacturaEncabezado.Documento_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha: " + Format(_FacturaEncabezado.Fecha, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cajero: " & _FacturaEncabezado.UsuarioNombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cliente: " & _FacturaEncabezado.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        If _FacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.Credito Then
            Send("Vencimiento: " & Format(DateAdd(DateInterval.Day, _FacturaEncabezado.Cliente.DiasCredito, _FacturaEncabezado.Fecha), "dd/MM/yyyy"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

        If _FacturaEncabezado.Comentario.Length > 0 Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Leyenda = "Comentario: " & _FacturaEncabezado.Comentario
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("DESCRIPCION", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("CANTIDAD     PRECIO UNIT     TOTAL LINEA", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
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

        For Each Fila As TFacturaDetalle In _FacturaEncabezado.FacturaDetalles
            Sleep(300)

            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Leyenda = " " & IIf(InfoMaquina.ImprimeCodigoArticulo, Fila.Art_Id & " - ", "") & Fila.Descripcion & IIf(Fila.Observacion <> "", " : " & Fila.Observacion, "")
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 31).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)


            Send(Alinea_Columnas(IIf(Fila.ExentoIV = 0, "*", " ") & Format(Fila.Cantidad, "0.0000"), True, False, 4), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
            _TotalCantidad += Fila.Cantidad


            'Send(Alinea_Columnas(Mid(IIf(Fila.ExentoIV, " ", "*") & Fila.Descripcion, 1, 20), True, False, 24), PrintFont.FontSingle, 25, y, PrintJustification.epsleft, 0)

            Send(Alinea_Columnas(CreaStrNumero(Fila.Precio), True, True, 10), PrintFont.FontSingle, 60, y, PrintJustification.epsleft, 0)

            Send(Alinea_Columnas(CreaStrNumero(Fila.Precio * Fila.Cantidad), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 15)

            'Send(Alinea_Columnas(Fila.UnidadMedidaNombre, True, False, 4), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)


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

        Send("Cantidad Total ...:" & Alinea_Columnas(Format(_TotalCantidad, "#,##0.0000"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Sub Total ¢ " & Alinea_Columnas(Format(_FacturaEncabezado.Subtotal, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '        If Math.Abs(_FacturaEncabezado.Descuento) > 0 Then
        Send("Descuento ¢ " & Alinea_Columnas(Format(_FacturaEncabezado.Descuento, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '       End If
        '      If Math.Abs(_FacturaEncabezado.IV) > 0 Then
        Send("Impuesto de Venta ¢" & Alinea_Columnas(Format(_FacturaEncabezado.IV, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '     End If
        'Send("Sub Total ...:" & Alinea_Columnas(Format(_FacturaEncabezado.Total, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        If Math.Abs(_FacturaEncabezado.Redondeo) > 0 Then
            Send("Redondeo ¢" & Alinea_Columnas(Format(_FacturaEncabezado.Redondeo, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Total ¢" & Alinea_Columnas(Format(_FacturaEncabezado.TotalCobrado, "#,##0.00"), True, True, 26), PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)

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
            If _FacturaEncabezado.TotalEfectivo > 0 Then
                Send("Pagó con ......:" & Alinea_Columnas(CreaStrNumero(_FacturaEncabezado.TotalEfectivo + _FacturaEncabezado.Vuelto), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Else
                Send("Pagó con -------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End If
            For Each Pago As TFacturaPago In _FacturaEncabezado.FacturaPagos
                Select Case Pago.TipoPago_Id
                    Case Enum_TipoPago.Efectivo
                        DescPago = "Efectivo ....:"
                    Case Enum_TipoPago.Cheque
                        DescPago = "Cheque ......:"
                    Case Enum_TipoPago.Tarjeta
                        DescPago = "Tarjeta .....:"
                    Case Enum_TipoPago.Puntos
                        DescPago = "Puntos ......:"
                End Select
                Send(DescPago & Alinea_Columnas(CreaStrNumero(Pago.Monto), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
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
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)

            Send("Esta factura constituye: Título", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("Ejecutivo de conformidad con el", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("artículo 460 del Código de Comercio", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("y devenga un " & _FacturaEncabezado.Cliente.PorcMora & "% de interés mensual", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
            Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("    Nombre Recibe                       ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
            Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("    Firma Persona Recibe                ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
            Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("    Cédula Persona Recibe               ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)

            'If _FacturaEncabezado.CxCCuotaMensual <> 0 AndAlso EmpresaParametroInfo.GeneraCuotasCredito Then
            '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            '    Send("Cuota Mensual  :" & Alinea_Columnas(CreaStrNumero(_FacturaEncabezado.CxCCuotaMensual), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            '    Send("Cantidad Cuotas:" & Alinea_Columnas(CreaStrNumero(_FacturaEncabezado.CxCCuotas), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            'End If

            'Send("Interes x mora : %" & _EmpresaParametro.PorcMora.ToString(), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

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

            'Send(NombreDocumentoElectronico(Mid(_FacturaEncabezado.FacturaElectronica.Consecutivo, 9, 2)), PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
            Send(_FacturaEncabezado.FacturaElectronica.TipoDocNombre, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
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
