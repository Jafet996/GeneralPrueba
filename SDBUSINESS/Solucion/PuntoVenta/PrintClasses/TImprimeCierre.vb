Imports Business
Public Class TImprimeCierre
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _Sucursal As TSucursal
    Private _Caja As TCaja
    Private _CajaCierreEncabezado As TCajaCierreEncabezado
    Private _Resumido As Boolean
#End Region

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pSucursal As TSucursal, pCaja As TCaja, ByVal pCajaCierreEncabezado As TCajaCierreEncabezado, pResumido As Boolean)
        MyBase.New()

        _Empresa = pEmpresa
        _Sucursal = pSucursal
        _Caja = pCaja
        _CajaCierreEncabezado = pCajaCierreEncabezado
        _Resumido = pResumido
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
        Send("Cierre Caja", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 30)
        'Send(_Sucursal.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsCenter, 5)
        'Send("  ", PrintFont.FontSingle, 200, 0, PrintJustification.epsleft, 1)
        Send(_Empresa.Nombre, PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
        'Send(_Sucursal.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Caja: " + _Caja.Caja_Id.ToString & " - " & _Caja.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cierre: " + Format(_CajaCierreEncabezado.Cierre_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cajero: " & _CajaCierreEncabezado.UsuarioNombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha Apertura: " + Format(_CajaCierreEncabezado.FechaApertura, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha Cierre  : " + Format(_CajaCierreEncabezado.FechaCierre, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Total Exento y Gravado", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)
        Send("Exento  : " + CreaStrNumero(_CajaCierreEncabezado.Exento), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Gravado : " + CreaStrNumero(_CajaCierreEncabezado.Gravado), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)

        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("CIERRE MONEDA LOCAL", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)


        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Fondo de Caja", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Sleep(100)
        'Send("Fondo...: " + CreaStrNumero(_CajaCierreEncabezado.Fondo), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Totales Sistema", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Salidas: " + CreaStrNumero(_CajaCierreEncabezado.Salidas), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Nota: El monto de salidas ya", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("esta rebajado del efectivo", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("se muestra como informacion adicional", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Sleep(100)
        Send("Efectivo: " + CreaStrNumero(_CajaCierreEncabezado.Efectivo), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Tarjetas: " + CreaStrNumero(_CajaCierreEncabezado.Tarjeta), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cheques/Trans : " + CreaStrNumero(_CajaCierreEncabezado.Cheque), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Puntos : " + CreaStrNumero(_CajaCierreEncabezado.Puntos), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Total      : " + CreaStrNumero(_CajaCierreEncabezado.Total - _CajaCierreEncabezado.Puntos), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fondo Caja : " + CreaStrNumero(_CajaCierreEncabezado.Fondo), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        _CajaCierreEncabezado.Total = _CajaCierreEncabezado.Total + _CajaCierreEncabezado.Fondo
        Send("Total + Fondo Caja : " + CreaStrNumero(_CajaCierreEncabezado.Total - _CajaCierreEncabezado.Puntos), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Totales Cajero", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)
        Send("Efectivo   : " + CreaStrNumero(_CajaCierreEncabezado.CajeroEfectivo), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Salidas   : " + CreaStrNumero(_CajaCierreEncabezado.Salidas), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Tarjetas   : " + CreaStrNumero(_CajaCierreEncabezado.CajeroTarjeta), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cheques/Trans    : " + CreaStrNumero(_CajaCierreEncabezado.CajeroCheque), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Documentos : " + CreaStrNumero(_CajaCierreEncabezado.CajeroDocumentos), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Total Cajero   : " + CreaStrNumero(_CajaCierreEncabezado.CajeroTotal), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)


        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Total Cajero ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Total General Cajero : " + CreaStrNumero(_CajaCierreEncabezado.CajeroTotal), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)


        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Detalle de Diferencias", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)
        Send(IIf(_CajaCierreEncabezado.CajeroTotal - (_CajaCierreEncabezado.Total - _CajaCierreEncabezado.Puntos - _CajaCierreEncabezado.Salidas) >= 0, "Sobrante : ", "Faltante : ") &
             CreaStrNumero(_CajaCierreEncabezado.CajeroTotal - (_CajaCierreEncabezado.Total - _CajaCierreEncabezado.Puntos)), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("CIERRE DOLARES", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Tipo Cambio: " + CreaStrNumero(_CajaCierreEncabezado.TipoCambio), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Totales Sistema", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Dolares: " + CreaStrNumero(_CajaCierreEncabezado.Dolares), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Total Cajero ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Dolares    : " + CreaStrNumero(_CajaCierreEncabezado.CajeroDolares), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Detalle de Diferencias", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("--------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send(IIf(_CajaCierreEncabezado.Dolares - _CajaCierreEncabezado.CajeroDolares >= 0, "Sobrante : ", "Faltante : ") &
             CreaStrNumero(_CajaCierreEncabezado.Dolares - _CajaCierreEncabezado.CajeroDolares), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)




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

        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("---------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("# Doc    Tipo Pago                Monto", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("---------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        For Each Fila As TCajaCierreDetalle In _CajaCierreEncabezado.CajaCierreDetalles
            Sleep(300)
            Send(Alinea_Columnas(Format(Fila.Documento_Id, "###"), True, False, 8), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
            If Fila.TipoPago_Id = Enum_TipoPago.Cheque Then
                Send(Alinea_Columnas(Mid(" " & Fila.NombreBanco, 1, 15), True, False, 15), PrintFont.FontSingle, 40, y, PrintJustification.epsleft, 0)
            Else
                Send(Alinea_Columnas(Mid(" " & Fila.NombreTipoPago, 1, 15), True, False, 15), PrintFont.FontSingle, 40, y, PrintJustification.epsleft, 0)
            End If
            'Send(Alinea_Columnas(Mid(" " & Fila.NombreTipoPago, 1, 19), True, False, 15), PrintFont.FontSingle, 70, y, PrintJustification.epsleft, 0)
            ''''Send(Alinea_Columnas(CreaStrNumero(Fila.Monto), True, True, 10), PrintFont.FontSingle, 70, y, PrintJustification.epsRight, 0)
            Send(Alinea_Columnas(Format(Fila.Monto, "#,##0.00"), True, True, 16), PrintFont.FontSingle, 200, y, PrintJustification.epsRight, 0)
            Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            Sleep(300)
        Next
        Send("---------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(300)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        'Send("------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Firma Cajero", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("------------------------------", PrintFont.FontSingle, 25, y, PrintJustification.epsleft, 15)
        Send("Firma Cajero", PrintFont.FontSingle, 75, y, PrintJustification.epsleft, 15)

        'Send("Sub Total ...:" & Alinea_Columnas(Format(_CajaCierreEncabezado.Subtotal, "#,##0.00"), True, True, 24), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Descuento ...:" & Alinea_Columnas(Format(_CajaCierreEncabezado.Descuento, "#,##0.00"), True, True, 24), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Monto IV  ...:" & Alinea_Columnas(Format(_CajaCierreEncabezado.IV, "#,##0.00"), True, True, 24), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Redondeo  ...:" & Alinea_Columnas(Format(_CajaCierreEncabezado.Redondeo, "#,##0.00"), True, True, 24), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        'Send("Total .......:" & Alinea_Columnas(Format(_CajaCierreEncabezado.TotalCobrado, "#,##0.00"), True, True, 24), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)

    End Sub
End Class
