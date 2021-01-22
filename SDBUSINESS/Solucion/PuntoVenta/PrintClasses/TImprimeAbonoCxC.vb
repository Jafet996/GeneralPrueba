Imports Business
Public Class TImprimeAbonoCxC
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _EmpresaParametro As TEmpresaParametro
    Private _Sucursal As TSucursal
    Private _AbonoEncabezado As TCxCAbonoEncabezado
    Private _TotalCantidad As Integer = 0
#End Region

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pEmpresaParametro As TEmpresaParametro, ByVal pSucursal As TSucursal, ByVal pAbonoEncabezado As TCxCAbonoEncabezado)
        MyBase.New()

        _Empresa = pEmpresa
        _EmpresaParametro = pEmpresaParametro
        _Sucursal = pSucursal
        _AbonoEncabezado = pAbonoEncabezado

    End Sub

    Protected Overrides Sub Print_Doc()
        Dim y As Integer = 0

        ImprimeEncabezado(y)
        ImprimeDetalle(y)
        ImprimePieFactura(y)
    End Sub

    Private Sub ImprimeEncabezado(ByRef y As Integer)
        Dim Leyenda As String = ""

        'If _AbonoEncabezado.Reimpresion Then
        '    Send("--REIMPRESION--", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
        '    Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'End If

        Leyenda = _Empresa.Nombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 25).Trim, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        End While

        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send(_AbonoEncabezado.TipoDocumentoNombre, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)


        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        If _Empresa.Cedula <> "" Then
            Send("Cédula Jur: " & _Empresa.Cedula, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        If _Sucursal.Telefono <> "" Then
            Send("Tel: " & _Sucursal.Telefono, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        'Send("Fax: " & _Sucursal.Fax, PrintFont.FontSingle, 140, y, PrintJustification.epsleft, 15)
        If _Sucursal.Email <> "" Then
            Send("Email: " & _Sucursal.Email, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send(CentraTexto(_AbonoEncabezado.TipoDocumentoNombre), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)


        Leyenda = "Sucursal: " & _Sucursal.Nombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 25).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End While

        Send("Caja: " + Format(_AbonoEncabezado.Caja_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Abono: " + Format(_AbonoEncabezado.Abono_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha: " + Format(_AbonoEncabezado.Fecha, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cajero: " & _AbonoEncabezado.UsuarioNombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cliente: " & _AbonoEncabezado.ClienteNombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Monto  :  " & Alinea_Columnas(CreaStrNumero(_AbonoEncabezado.Monto), True, True, 10), PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Saldo del Cliente", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Saldo  :  " & Alinea_Columnas(CreaStrNumero(_AbonoEncabezado.SaldoCxC), True, True, 10), PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Sleep(100)

    End Sub

    Private Function CreaStrNumero(pMonto As Double) As String
        Dim MontoStr As String = ""

        MontoStr = Format(pMonto, "#,##0.00")

        MontoStr = StrDup(14 - MontoStr.Length, " ") & MontoStr


        Return MontoStr
    End Function

    Private Sub ImprimeDetalle(ByRef y As Integer)
        Dim Leyenda As String = ""

        'For Each Fila As TFacturaDetalle In _AbonoEncabezado.FacturaDetalles
        '    Sleep(300)
        '    Send(Alinea_Columnas(Format(Fila.Cantidad, "###"), True, False, 4), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
        '    _TotalCantidad += Fila.Cantidad
        '    'Send(Alinea_Columnas(Mid(IIf(Fila.ExentoIV, " ", "*") & Fila.Descripcion, 1, 20), True, False, 24), PrintFont.FontSingle, 25, y, PrintJustification.epsleft, 0)


        '    'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '    Leyenda = IIf(InfoMaquina.ImprimeCodigoArticulo, Fila.Art_Id & " - ", "") & Fila.Descripcion & IIf(Fila.Observacion <> "", " : " & Fila.Observacion, "")
        '    While Leyenda.Length > 0
        '        Send(BuscaFraseEntera(Leyenda, 32).Trim, PrintFont.FontSingle, 20, y, PrintJustification.epsleft, 15)
        '    End While
        '    'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        '    If Math.Abs(Fila.Cantidad) > 1 Then
        '        Send(Alinea_Columnas(CreaStrNumero(Fila.Precio), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 15)
        '    End If

        '    Send(Alinea_Columnas(CreaStrNumero(Fila.Precio * Fila.Cantidad), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 0)
        '    'If Not Fila.ExentoIV Then
        '    '    Send(Alinea_Columnas("*", True, True, 10), PrintFont.FontSingle, 242, y, PrintJustification.epsleft, 0)
        '    'End If

        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Sleep(300)
        'Next
        'Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        ''Send("* = Artículo Gravado", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Sleep(300)

        '' --------------- ORIGINAL
        ''For Each Fila As TFacturaDetalle In _AbonoEncabezado.FacturaDetalles
        ''    Sleep(300)
        ''    Send(Alinea_Columnas(Format(Fila.Cantidad, "###"), True, False, 4), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
        ''    Send(Alinea_Columnas(Mid(IIf(Fila.ExentoIV, " ", "*") & Fila.Descripcion, 1, 20), True, False, 24), PrintFont.FontSingle, 25, y, PrintJustification.epsleft, 0)
        ''    Send(Alinea_Columnas(CreaStrNumero(Fila.Precio * Fila.Cantidad), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 0)
        ''    'If Not Fila.ExentoIV Then
        ''    '    Send(Alinea_Columnas("*", True, True, 10), PrintFont.FontSingle, 242, y, PrintJustification.epsleft, 0)
        ''    'End If

        ''    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        ''    Sleep(300)
        ''Next
        ''Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        ''Send("* = Artículo Gravado", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        ''Sleep(300)
    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Dim DescPago As String = ""
        Dim Leyenda As String = ""

        'Send("Cantidad Total ...:" & Alinea_Columnas(Format(_TotalCantidad, "#,##0"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Sub Total ...:" & Alinea_Columnas(Format(_AbonoEncabezado.Subtotal, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'If Math.Abs(_AbonoEncabezado.Descuento) > 0 Then
        '    Send("Descuento ...:" & Alinea_Columnas(Format(_AbonoEncabezado.Descuento, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'End If
        'If Math.Abs(_AbonoEncabezado.IV) > 0 Then
        '    Send("Monto IV  ...:" & Alinea_Columnas(Format(_AbonoEncabezado.IV, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'End If
        'If Math.Abs(_AbonoEncabezado.Redondeo) > 0 Then
        '    Send("Redondeo  ...:" & Alinea_Columnas(Format(_AbonoEncabezado.Redondeo, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'End If
        'Send("Total .......:" & Alinea_Columnas(Format(_AbonoEncabezado.TotalCobrado, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        'If _AbonoEncabezado.TipoDoc_Id = Enum_TipoDocumento.Credito AndAlso _AbonoEncabezado.MontoPrima > 0 Then
        '    Send("Prima .......:" & Alinea_Columnas(Format(_AbonoEncabezado.MontoPrima, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '    Send("Saldo .......:" & Alinea_Columnas(Format(_AbonoEncabezado.TotalCobrado - _AbonoEncabezado.MontoPrima, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'End If



        'If Math.Abs(_AbonoEncabezado.MontoPrima) > 0 Then
        '    Send("Prima .......:" & Alinea_Columnas(Format(_AbonoEncabezado.MontoPrima, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'End If

        'If Math.Abs(_AbonoEncabezado.RecargoCredito) > 0 Then
        '    Send("Intereses ...:" & Alinea_Columnas(Format(_AbonoEncabezado.RecargoCredito, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'End If

        'Send("Saldo .......:" & Alinea_Columnas(Format((_AbonoEncabezado.TotalCobrado - _AbonoEncabezado.MontoPrima) + _AbonoEncabezado.RecargoCredito, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Sleep(300)



        Sleep(300)


        'If _AbonoEncabezado.TipoDoc_Id = Enum_TipoDocumento.Contado Then
        '    Send("Pagó con -------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '    For Each Pago As TFacturaPago In _AbonoEncabezado.FacturaPagos
        '        Select Case Pago.TipoPago_Id
        '            Case Enum_TipoPago.Efectivo
        '                DescPago = "Efectivo ....:"
        '            Case Enum_TipoPago.Cheque
        '                DescPago = "Cheque ......:"
        '            Case Enum_TipoPago.Tarjeta
        '                DescPago = "Tarjeta .....:"
        '            Case Enum_TipoPago.Puntos
        '                DescPago = "Puntos ......:"
        '        End Select
        '        Send(DescPago & Alinea_Columnas(CreaStrNumero(Pago.Monto), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '        Sleep(300)
        '    Next
        '    Send("Vuelto ......:" & Alinea_Columnas(CreaStrNumero(_AbonoEncabezado.Vuelto), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'End If


        'If _AbonoEncabezado.TipoDoc_Id = Enum_TipoDocumento.Credito Then
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Send("    --------------------------------    ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '    Send("              Firma Cliente             ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        'End If

        'If _AbonoEncabezado.TipoDoc_Id = Enum_TipoDocumento.Credito Then
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Send("    --------------------------------    ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '    Send("              Firma Cliente             ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)

        '    If _AbonoEncabezado.CxCCuotaMensual <> 0 AndAlso EmpresaParametroInfo.GeneraCuotasCredito Then
        '        Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '        Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '        Send("Cuota Mensual  :" & Alinea_Columnas(CreaStrNumero(_AbonoEncabezado.CxCCuotaMensual), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '        Send("Cantidad Cuotas:" & Alinea_Columnas(CreaStrNumero(_AbonoEncabezado.CxCCuotas), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        '        Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '        Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    End If

        '    Send("Interes x mora : %" & _EmpresaParametro.PorcMora.ToString(), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        'End If



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



    End Sub
End Class
