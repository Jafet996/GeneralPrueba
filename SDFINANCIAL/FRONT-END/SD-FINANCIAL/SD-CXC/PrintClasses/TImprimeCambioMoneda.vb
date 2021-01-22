Imports BUSINESS
Public Class TImprimeCambioMoneda
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _CambioMoneda As TCambioMoneda
    Private _Reimpresion As Boolean
#End Region

    Public Sub New(pEmpresa As TEmpresa, pCambioMoneda As TCambioMoneda, pReimpresion As Boolean)
        MyBase.New()
        _Empresa = pEmpresa
        _CambioMoneda = pCambioMoneda
        _Reimpresion = pReimpresion
    End Sub

    Protected Overrides Sub Print_Doc()
        Dim y As Integer = 0

        ImprimeEncabezado(y)
        ImprimeDetalle(y)
        ImprimePieFactura(y)
    End Sub

    Private Sub ImprimeEncabezado(ByRef y As Integer)
        Dim Leyenda As String = ""

        Send("================================================", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Leyenda = _Empresa.Nombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 25).Trim, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        End While
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)

        If _Empresa.Cedula <> "" Then
            Send("Cédula Jur: " & _Empresa.Cedula, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        If _Empresa.Telefono <> "" Then
            Send("Tel     : " & _Empresa.Telefono, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        If _Empresa.Email <> "" Then
            Send("Email  : " & _Empresa.Email, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If

        Sleep(100)

        If _CambioMoneda.Caja_Id > 0 Then Send("Caja   : " & Format(_CambioMoneda.Caja_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha  : " & Format(_CambioMoneda.Fecha, "dd/MM/yyyy hh:mm tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Leyenda = "Cajero : " & _CambioMoneda.UsuarioNombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End While
        Send("Transacción #" & _CambioMoneda.Cambio_Id.ToString, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        If _Reimpresion Then
            Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
            Send("      -- REIMPRESIÓN --", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
        End If

        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        If _CambioMoneda.Tipo_Id = Enum_CambioMonedaTipo.Compra Then
            Send("COMPRA DE DÓLARES", PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 0)
        Else
            Send("DEVOLUCIÓN DE DÓLARES", PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 0)
        End If
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Sleep(100)
    End Sub

    Private Function CreaStrNumero(pMonto As Double) As String
        Dim MontoStr As String = ""

        MontoStr = Format(pMonto, "#,##0.00")

        If MontoStr.Length <= 12 Then
            MontoStr = StrDup(12 - MontoStr.Length, " ") & MontoStr
        End If

        Return MontoStr
    End Function

    Private Sub ImprimeDetalle(ByRef y As Integer)
        Send("Detalle de la transacción", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("TIPO CAMBIO: ¢" & CreaStrNumero(_CambioMoneda.TipoCambio), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        If _CambioMoneda.Tipo_Id = Enum_CambioMonedaTipo.Compra Then
            Send("RECIBE:          $" & CreaStrNumero(Math.Abs(_CambioMoneda.Dolares)), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("MONTO:          ¢" & CreaStrNumero(Math.Abs(_CambioMoneda.Efectivo)), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Else
            Send("RECIBE:          ¢" & CreaStrNumero(Math.Abs(_CambioMoneda.Efectivo)), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("MONTO:          $" & CreaStrNumero(Math.Abs(_CambioMoneda.Dolares)), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(300)
    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("              --------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("                        Firma", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("      Sistema desarrollado por SoftDesign", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("                 www.softdesign.cr", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("================================================", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
    End Sub

End Class