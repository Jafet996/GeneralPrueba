Imports Business
Public Class TImprimeEntradaEfectivo
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _Sucursal As TSucursal
    Private _Caja As TCaja
    Private _CajaEntradaEfectivo As TCajaEntradaEfectivo
    Private _Resumido As Boolean
    Private _Concepto As TCajaEntradaEfectivoConcepto
#End Region

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pSucursal As TSucursal, pCaja As TCaja, ByVal pCajaEntradaEfectivo As TCajaEntradaEfectivo, ByVal pConcepto As TCajaEntradaEfectivoConcepto, pResumido As Boolean)
        MyBase.New()
        _Empresa = pEmpresa
        _Sucursal = pSucursal
        _Caja = pCaja
        _CajaEntradaEfectivo = pCajaEntradaEfectivo
        _Resumido = pResumido
        _Concepto = pConcepto
    End Sub

    Protected Overrides Sub Print_Doc()
        Dim y As Integer = 0

        ImprimeEncabezado(y)
        If Not _Resumido Then
            ImprimeDetalle(y)
        End If
        ImprimePieFactura(y)
    End Sub

    Private Sub ImprimeEncabezado(ByRef y As Integer)
        Dim Leyenda As String = ""

        Send("Entrada de Efectivo", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 30)
        'Send(_Sucursal.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsCenter, 5)
        'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
        Send(_Empresa.Nombre, PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
        'Send(_Sucursal.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Caja: " + _Caja.Caja_Id.ToString & " - " & _Caja.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cierre: " + Format(_CajaEntradaEfectivo.Cierre_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cajero: " & _CajaEntradaEfectivo.Usuario_Id, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha: " + Format(Now, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        If _CajaEntradaEfectivo.Motivo.Length > 0 Then
            Leyenda = "Motivo: " & _CajaEntradaEfectivo.Motivo
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
            Send("", PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        End If
        'Send("Motivo: " + _CajaSalidaEfectivo.Motivo, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Fecha Cierre  : " + Format(_CajaSalidaEfectivo.FechaCierre, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Total Exento y Gravado", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Sleep(100)
        ' Send("Exento  : " + CreaStrNumero(_CajaSalidaEfectivo.Exento), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Gravado : " + CreaStrNumero(_CajaSalidaEfectivo.Gravado), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)

        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("CIERRE MONEDA LOCAL", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)


        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Fondo de Caja", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Sleep(100)
        'Send("Fondo...: " + CreaStrNumero(_CajaSalidaEfectivo.Fondo), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)

        Send("      Monto: " + CreaStrNumero(_CajaEntradaEfectivo.Monto), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("      Concepto: " + _Concepto.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Total         " & _CajaEntradaEfectivo.Monto, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)
        'Send("Motivo: " + _CajaSalidaEfectivo.Motivo, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        ' Send("Cheques/Trans : " + CreaStrNumero(_CajaSalidaEfectivo.Cheque), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Puntos : " + CreaStrNumero(_CajaSalidaEfectivo.Puntos), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        'Send("Total      : " + CreaStrNumero(_CajaSalidaEfectivo.Total - _CajaSalidaEfectivo.Puntos), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Fondo Caja : " + CreaStrNumero(_CajaSalidaEfectivo.Fondo), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        ' _CajaSalidaEfectivo.Total = _CajaSalidaEfectivo.Monto + _CajaSalidaEfectivo.Fondo
        'Send("Total + Fondo Caja : " + CreaStrNumero(_CajaSalidaEfectivo.Total - _CajaSalidaEfectivo.Puntos), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Totales Cajero", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Sleep(100)
        'Send("Efectivo   : " + CreaStrNumero(_CajaSalidaEfectivo.Monto), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        ''Send("Tarjetas   : " + CreaStrNumero(_CajaSalidaEfectivo.CajeroTarjeta), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        ''Send("Cheques/Trans    : " + CreaStrNumero(_CajaSalidaEfectivo.CajeroCheque), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        ''Send("Documentos : " + CreaStrNumero(_CajaSalidaEfectivo.CajeroDocumentos), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        ''Send("Total Cajero   : " + CreaStrNumero(_CajaSalidaEfectivo.CajeroTotal), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)


        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Total Cajero ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Total General Cajero : " + CreaStrNumero(_CajaSalidaEfectivo.CajeroTotal), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)


        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Detalle de Diferencias", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Sleep(100)
        'Send(IIf(_CajaSalidaEfectivo.Monto - (_CajaSalidaEfectivo.Total - _CajaSalidaEfectivo.Puntos) >= 0, "Sobrante : ", "Faltante : ") &
        ' CreaStrNumero(_CajaSalidaEfectivo.CajeroTotal - (_CajaSalidaEfectivo.Total - _CajaSalidaEfectivo.Puntos)), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("CIERRE DOLARES", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Tipo Cambio: " + CreaStrNumero(_CajaSalidaEfectivo.TipoCambio), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Totales Sistema", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Dolares: " + CreaStrNumero(_CajaSalidaEfectivo.Dolares), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Total Cajero ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Dolares    : " + CreaStrNumero(_CajaSalidaEfectivo.CajeroDolares), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Detalle de Diferencias", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send(IIf(_CajaSalidaEfectivo.Dolares - _CajaSalidaEfectivo.CajeroDolares >= 0, "Sobrante : ", "Faltante : ") &
        '     CreaStrNumero(_CajaSalidaEfectivo.Dolares - _CajaSalidaEfectivo.CajeroDolares), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

    End Sub

    Private Function CreaStrNumero(pMonto As Double) As String
        Dim MontoStr As String = ""

        MontoStr = Format(pMonto, "#,##0.00")

        If MontoStr.Length <= 13 Then
            MontoStr = StrDup(13 - MontoStr.Length, " ") & MontoStr
        End If



        Return MontoStr
    End Function

    Private Sub ImprimeDetalle(ByRef y As Integer)

        ''Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("---------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("# Doc    Tipo Pago                Monto", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("---------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'For Each Fila As TCajaCierreDetalle In _CajaSalidaEfectivo.CajaCierreDetalles
        '    Sleep(300)
        '    Send(Alinea_Columnas(Format(Fila.Documento_Id, "###"), True, False, 8), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
        '    If Fila.TipoPago_Id = Enum_TipoPago.Cheque Then
        '        Send(Alinea_Columnas(Mid(" " & Fila.NombreBanco, 1, 15), True, False, 15), PrintFont.FontSingle, 40, y, PrintJustification.epsleft, 0)
        '    Else
        '        Send(Alinea_Columnas(Mid(" " & Fila.NombreTipoPago, 1, 15), True, False, 15), PrintFont.FontSingle, 40, y, PrintJustification.epsleft, 0)
        '    End If
        '    'Send(Alinea_Columnas(Mid(" " & Fila.NombreTipoPago, 1, 19), True, False, 15), PrintFont.FontSingle, 70, y, PrintJustification.epsleft, 0)
        '    ''''Send(Alinea_Columnas(CreaStrNumero(Fila.Monto), True, True, 10), PrintFont.FontSingle, 70, y, PrintJustification.epsRight, 0)
        '    Send(Alinea_Columnas(Format(Fila.Monto, "#,##0.00"), True, True, 16), PrintFont.FontSingle, 200, y, PrintJustification.epsRight, 0)
        '    Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
        '    Sleep(300)
        'Next
        'Send("---------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Sleep(300)
        ''Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        ''Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        ''Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        ''Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        ''Send("------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        ''Send("Firma Cajero", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("------------------------------", PrintFont.FontSingle, 25, y, PrintJustification.epsleft, 15)
        Send("Firma Cajero", PrintFont.FontSingle, 75, y, PrintJustification.epsleft, 15)

        'Send("Sub Total ...:" & Alinea_Columnas(Format(_CajaSalidaEfectivo.Subtotal, "#,##0.00"), True, True, 24), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Descuento ...:" & Alinea_Columnas(Format(_CajaSalidaEfectivo.Descuento, "#,##0.00"), True, True, 24), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Monto IV  ...:" & Alinea_Columnas(Format(_CajaSalidaEfectivo.IV, "#,##0.00"), True, True, 24), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Redondeo  ...:" & Alinea_Columnas(Format(_CajaSalidaEfectivo.Redondeo, "#,##0.00"), True, True, 24), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Total .......:" & Alinea_Columnas(Format(_CajaSalidaEfectivo.TotalCobrado, "#,##0.00"), True, True, 24), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)

    End Sub
End Class
