Imports Business
Public Class TImprimeFacturaPerfumes
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _EmpresaParametro As TEmpresaParametro
    Private _Sucursal As TSucursal
    Private _FacturaEncabezado As TFacturaEncabezado
    Private _CantidadTotal As Integer = 0
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

        'If _FacturaEncabezado.Reimpresion Then
        '    Send("--REIMPRESION--", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
        '    Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'End If

        If _FacturaEncabezado.ImpresionPrefactura Then
            Send("--PRE FACTURA--", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        End If

        'Send(_Empresa.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsCenter, 5)
        'Send(_Sucursal.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsCenter, 5)
        'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
        Send(_Empresa.Nombre, PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
        'Send(_Sucursal.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'If _Empresa.Cedula <> "" Then
        '    Send("Cédula Jur: " & _Empresa.Cedula, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        'End If
        If _Empresa.Telefono <> "" Then
            Send("Tel: " & _Sucursal.Telefono, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        'Send("Fax: " & _Sucursal.Fax, PrintFont.FontSingle, 140, y, PrintJustification.epsleft, 15)
        If _Sucursal.Email <> "" Then
            Send("Email: " & _Sucursal.Email, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send(CentraTexto(_FacturaEncabezado.TipoDocumentoNombre), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send(_FacturaEncabezado.TipoDocumentoNombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Caja: " + Format(_FacturaEncabezado.Caja_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Factura: " + Format(_FacturaEncabezado.Documento_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha: " + Format(_FacturaEncabezado.Fecha, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Cajero: " & _FacturaEncabezado.UsuarioNombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cliente: " & _FacturaEncabezado.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        If _FacturaEncabezado.Cliente.Telefono1 <> "" Then
            Send("Tel 1: " & _FacturaEncabezado.Cliente.Telefono1, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If

        If _FacturaEncabezado.Cliente.Telefono2 <> "" Then
            Send("Tel 2: " & _FacturaEncabezado.Cliente.Telefono2, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If


        Send("Tipo Cliente: " & IIf(_FacturaEncabezado.Cliente.Precio_Id = Enum_ClientPrecio.Detalle, "Detalle", "Mayoreo"), PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)

        Send("Vendedor: " & _FacturaEncabezado.Vendedor.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        If _FacturaEncabezado.ImpresionPrefactura AndAlso Not _FacturaEncabezado.Proforma Is Nothing Then
            If _FacturaEncabezado.Proforma.TipoEntregaNombre <> "" Then
                Send("Tipo Entrega: " & _FacturaEncabezado.Proforma.TipoEntregaNombre, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
                Send("Fecha Entrega: " & Format(_FacturaEncabezado.Proforma.FechaEntrega, "dd/MM/yyyy"), PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
                Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
            End If
        End If


        If _FacturaEncabezado.Cliente.Direccion.Length > 0 Then
            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Leyenda = "Dirección: " & _FacturaEncabezado.Cliente.Direccion
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If


        If _FacturaEncabezado.DireccionEntrega.Length > 0 Then
            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Leyenda = "Entregar En: " & _FacturaEncabezado.DireccionEntrega
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If


        If _FacturaEncabezado.Comentario.Length > 0 Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Leyenda = "Comentario: " & _FacturaEncabezado.Comentario
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cant Descripción                  Precio", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)

    End Sub

    Private Function CreaStrNumero(pMonto As Double) As String
        Dim MontoStr As String = ""

        MontoStr = Format(pMonto, "#,##0.00")

        MontoStr = StrDup(12 - MontoStr.Length, " ") & MontoStr


        Return MontoStr
    End Function

    Private Sub ImprimeDetalle(ByRef y As Integer)
        Dim Leyenda As String = ""

        For Each Fila As TFacturaDetalle In _FacturaEncabezado.FacturaDetalles
            Sleep(300)
            Send(Alinea_Columnas(Format(Fila.Cantidad, "###"), True, False, 4), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
            'Send(Alinea_Columnas(Mid(IIf(Fila.ExentoIV, " ", "*") & Fila.Descripcion, 1, 20), True, False, 24), PrintFont.FontSingle, 25, y, PrintJustification.epsleft, 0)

            If Not EsServicio(Fila.Art_Id) Then
                _CantidadTotal += Fila.Cantidad
            End If


            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Leyenda = Fila.Descripcion & IIf(Fila.Observacion <> "", " : " & Fila.Observacion, "")
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 32).Trim, PrintFont.FontSingle, 20, y, PrintJustification.epsleft, 15)
            End While
            'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

            If Math.Abs(Fila.Cantidad) > 1 Then
                Send(Alinea_Columnas(CreaStrNumero(Fila.Precio), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 15)
            End If


            Send(Alinea_Columnas(CreaStrNumero(Fila.Precio * Fila.Cantidad), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 0)
            'If Not Fila.ExentoIV Then
            '    Send(Alinea_Columnas("*", True, True, 10), PrintFont.FontSingle, 242, y, PrintJustification.epsleft, 0)
            'End If

            Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            Sleep(300)
        Next
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("* = Artículo Gravado", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(300)
    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Dim DescPago As String = ""
        Dim Leyenda As String = ""
        Dim NombreBanco As String = ""

        Send("Sub Total ...:" & Alinea_Columnas(Format(_FacturaEncabezado.Subtotal, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        If Math.Abs(_FacturaEncabezado.Descuento) > 0 Then
            Send("Descuento ...:" & Alinea_Columnas(Format(_FacturaEncabezado.Descuento, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If
        If Math.Abs(_FacturaEncabezado.IV) > 0 Then
            Send("Monto IV  ...:" & Alinea_Columnas(Format(_FacturaEncabezado.IV, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If
        If Math.Abs(_FacturaEncabezado.Redondeo) > 0 Then
            Send("Redondeo  ...:" & Alinea_Columnas(Format(_FacturaEncabezado.Redondeo, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If
        Send("Total .......:" & Alinea_Columnas(Format(_FacturaEncabezado.TotalCobrado, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        If Math.Abs(_FacturaEncabezado.MontoPrima) > 0 Then
            Send("Prima .......:" & Alinea_Columnas(Format(_FacturaEncabezado.MontoPrima, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

        If Math.Abs(_FacturaEncabezado.RecargoCredito) > 0 Then
            Send("Intereses ...:" & Alinea_Columnas(Format(_FacturaEncabezado.RecargoCredito, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

        Send("Saldo .......:" & Alinea_Columnas(Format((_FacturaEncabezado.TotalCobrado - _FacturaEncabezado.MontoPrima) + _FacturaEncabezado.RecargoCredito, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(300)



        If Not _FacturaEncabezado.ImpresionPrefactura Then
            If _FacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.Contado Then
                Send("Pagó con -------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                For Each Pago As TFacturaPago In _FacturaEncabezado.FacturaPagos
                    NombreBanco = String.Empty
                    Select Case Pago.TipoPago_Id
                        Case Enum_TipoPago.Efectivo
                            DescPago = "Efectivo ....:"
                        Case Enum_TipoPago.Cheque
                            NombreBanco = BancoNombre(Pago.Banco_Id)
                            DescPago = "Cheque ......:"
                        Case Enum_TipoPago.Tarjeta
                            DescPago = "Tarjeta .....:"
                        Case Enum_TipoPago.Puntos
                            DescPago = "Puntos ......:"
                    End Select
                    Send(DescPago & Alinea_Columnas(CreaStrNumero(Pago.Monto), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                    If NombreBanco.Trim <> String.Empty Then
                        Send(NombreBanco, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                    End If


                    Sleep(300)
                Next
                Send("Vuelto ......:" & Alinea_Columnas(CreaStrNumero(_FacturaEncabezado.Vuelto), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End If


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

            Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            Send("Total Unidades ...:" & Alinea_Columnas(Format(_CantidadTotal, "#,##0"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

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
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
        End If

        If EmpresaParametroInfo.PuntosActivo AndAlso _FacturaEncabezado.Cliente.AcumulaPuntos AndAlso _FacturaEncabezado.Puntos <> 0 Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("Puntos Ganados ......:" & Format(_FacturaEncabezado.Puntos, "#,##0"), PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
            'Send("Puntos Disponibles ..:" & Format(_FacturaEncabezado.Cliente.PuntosAcumulados - _FacturaEncabezado.Cliente.PuntosCanjeados, "#,##0"), PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
        End If

        If EmpresaParametroInfo.PuntosActivo AndAlso _FacturaEncabezado.Cliente.AcumulaPuntos Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("Puntos Disponibles ..:" & Format(_FacturaEncabezado.Cliente.PuntosAcumulados - _FacturaEncabezado.Cliente.PuntosCanjeados, "#,##0"), PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

    End Sub
End Class
