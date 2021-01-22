Imports Business
Public Class TImprimeCierre
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _Caja As TCaja
    Private _CajaCierreEncabezado As TCajaCierreEncabezado
    Private _Resumido As Boolean
    Private _Reimpresion As Boolean
#End Region

    Public Sub New(pEmpresa As TEmpresa, pCaja As TCaja, pCajaCierreEncabezado As TCajaCierreEncabezado, pResumido As Boolean, pReimpresion As Boolean)
        MyBase.New()

        _Empresa = pEmpresa
        _Caja = pCaja
        _CajaCierreEncabezado = pCajaCierreEncabezado
        _Resumido = pResumido
        _Reimpresion = pReimpresion
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
        Dim TotalSistema As Double = 0.0
        Dim TotalCajero As Double = 0.0
        Dim Diferencia As Double = 0.0
        Dim DiferenciaDolares As Double = 0.0

        TotalSistema = _CajaCierreEncabezado.Efectivo + _CajaCierreEncabezado.Tarjeta + _CajaCierreEncabezado.Cheque
        TotalCajero = _CajaCierreEncabezado.CajeroEfectivo + _CajaCierreEncabezado.CajeroTarjeta + _CajaCierreEncabezado.CajeroCheque + _CajaCierreEncabezado.CajeroDocumentos
        Diferencia = (TotalSistema + _CajaCierreEncabezado.Fondo) - TotalCajero
        DiferenciaDolares = _CajaCierreEncabezado.Dolares - _CajaCierreEncabezado.CajeroDolares

        Send("================================================", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Leyenda = _Empresa.Nombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 25).Trim, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        End While
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Cierre de Caja", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 30)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        If _Reimpresion Then
            Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
            Send("      -- REIMPRESIÓN --", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
            Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        End If
        Send("Caja: " + _Caja.Caja_Id.ToString & " - " & _Caja.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cierre: " + Format(_CajaCierreEncabezado.Cierre_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cajero: " & _CajaCierreEncabezado.UsuarioNombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha Apertura: " + Format(_CajaCierreEncabezado.FechaApertura, "dd/MM/yyyy hh:mm tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha Cierre  : " + Format(_CajaCierreEncabezado.FechaCierre, "dd/MM/yyyy hh:mm tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Indicadores Sistema", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)
        Send("Efectivo          : " + CreaStrNumero(_CajaCierreEncabezado.Efectivo), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Tarjeta           : " + CreaStrNumero(_CajaCierreEncabezado.Tarjeta), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cheques          : " + CreaStrNumero(_CajaCierreEncabezado.Cheque), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Total              : " + CreaStrNumero(TotalSistema), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fondo Caja      : " + CreaStrNumero(_CajaCierreEncabezado.Fondo), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Total + Fondo Caja: " + CreaStrNumero(TotalSistema + _CajaCierreEncabezado.Fondo), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Dólares           : " + CreaStrNumero(_CajaCierreEncabezado.Dolares), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Transferencias : " + CreaStrNumero(_CajaCierreEncabezado.Transferencia), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Depositos        : " + CreaStrNumero(_CajaCierreEncabezado.Deposito), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Indicadores Cajero", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)
        Send("Efectivo   : " + CreaStrNumero(_CajaCierreEncabezado.CajeroEfectivo), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Tarjetas   : " + CreaStrNumero(_CajaCierreEncabezado.CajeroTarjeta), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cheques   : " + CreaStrNumero(_CajaCierreEncabezado.CajeroCheque), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Vales       : " + CreaStrNumero(_CajaCierreEncabezado.CajeroDocumentos), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Total       : " + CreaStrNumero(TotalCajero), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Dólares    : " + CreaStrNumero(_CajaCierreEncabezado.CajeroDolares), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Detalle de Diferencia", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        If Diferencia > 0 Then
            Send("Faltante   ¢: " + CreaStrNumero(Diferencia), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Else
            Send("Sobrante   ¢: " + CreaStrNumero(Math.Abs(Diferencia)), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If
        Sleep(100)
        If DiferenciaDolares > 0 Then
            Send("Faltante   $: " + CreaStrNumero(DiferenciaDolares), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Else
            Send("Sobrante   $: " + CreaStrNumero(Math.Abs(DiferenciaDolares)), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If
        Sleep(100)
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
        If _CajaCierreEncabezado.ListaMovimientos.Count > 0 Then
            Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
            Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("Mov #    Tipo Mov                 Monto", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            For Each Fila As TCxCMovimiento In _CajaCierreEncabezado.ListaMovimientos
                Send(Alinea_Columnas(Format(Fila.Mov_Id, "###"), True, False, 8), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
                Send(Alinea_Columnas(Mid(" " & Fila.TipoNombre, 1, 15), True, False, 15), PrintFont.FontSingle, 40, y, PrintJustification.epsleft, 0)
                Send(Alinea_Columnas(Format(Fila.Monto, "#,##0.00"), True, True, 15), PrintFont.FontSingle, 200, y, PrintJustification.epsRight, 0)
                Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
                Sleep(100)
            Next
            Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Sleep(300)
        End If
    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsRight, 15)
        Send("              --------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("                        Firma", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("      Sistema desarrollado por SoftDesign", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("                 www.softdesign.cr", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("================================================", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(100)
    End Sub

End Class
