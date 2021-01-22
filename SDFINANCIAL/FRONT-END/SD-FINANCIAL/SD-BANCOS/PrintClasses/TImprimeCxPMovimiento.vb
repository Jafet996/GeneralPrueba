Imports Business
Public Class TImprimeCxPMovimiento
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _CxPMovimiento As TCxPMovimiento
    Private _Reimpresion As Boolean
#End Region

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pCxPMovimiento As TCxPMovimiento, pReimpresion As Boolean)
        MyBase.New()
        _Empresa = pEmpresa
        _CxPMovimiento = pCxPMovimiento
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
        Send("Fecha  : " + Format(_CxPMovimiento.Fecha, "dd/MM/yyyy hh:mm tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Leyenda = "Cajero : " & _CxPMovimiento.UsuarioNombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End While
        Leyenda = "Proveedor: " & _CxPMovimiento.ProveedorNombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End While
        If _CxPMovimiento.Moneda = coMonedaColones Then
            Send("Moneda: COLONES", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
        Else
            Send("Moneda: DÓLARES (" & Math.Abs(_CxPMovimiento.Dolares) & ")", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
        End If
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 18)
        Leyenda = _CxPMovimiento.TipoNombre & " # " & Format(_CxPMovimiento.Mov_Id, "###")
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 25).Trim, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 20)
        End While
        Send("Monto  : " & CreaStrNumero(Math.Abs(_CxPMovimiento.Monto)), PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)

        If _CxPMovimiento.Referencia.Trim <> "" Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Leyenda = "Referencia: " & _CxPMovimiento.Referencia
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
        End If

        If _Reimpresion Then
            Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
            Send("      -- REIMPRESIÓN --", PrintFont.FontTitulo, 1, y, PrintJustification.epsleft, 15)
        End If

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
        Dim Leyenda As String = ""

        If _CxPMovimiento.ListaAplicados.Count > 0 Then
            Send("Detalle del documento", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

        For Each Fila As TCxPMovimiento In _CxPMovimiento.ListaAplicados
            Sleep(300)

            Leyenda = Fila.TipoNombre & " # " & Format(Fila.Mov_Id, "###")
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While

            If Fila.Referencia.Trim <> "" Then
                Leyenda = "Referencia    : " & Fila.Referencia
                While Leyenda.Length > 0
                    Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
                End While
            End If
            Send("Fecha              : " & Format(Fila.Fecha, "dd/MM/yyyy"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("Vencimiento    : " & Format(Fila.FechaVencimiento, "dd/MM/yyyy"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("Monto Original : ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
            Send(Alinea_Columnas(CreaStrNumero(Math.Abs(Fila.Monto)), True, True, 10), PrintFont.FontSingle, 120, y, PrintJustification.epsleft, 15)
            If Fila.Moneda = coMonedaColones Then
                Send("Moneda           : COLONES", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Else
                Send("Moneda           : DÓLARES (" & Math.Abs(Fila.Dolares) & ")", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End If
            Send("Monto Aplicado : ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
            Send(Alinea_Columnas(CreaStrNumero(Math.Abs(Fila.MontoAplicado)), True, True, 10), PrintFont.FontSingle, 120, y, PrintJustification.epsleft, 15)
            If Fila.Saldo > 0 Then
                Send("Saldo Pendiente: ", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
                Send(Alinea_Columnas(CreaStrNumero(Math.Abs(Fila.Saldo)), True, True, 10), PrintFont.FontSingle, 120, y, PrintJustification.epsleft, 15)
            End If
            Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Next
        Sleep(300)
    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Saldo del Proveedor", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Saldo Actual  :", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
        Send(Alinea_Columnas(CreaStrNumero(_CxPMovimiento.SaldoProveedor), True, True, 10), PrintFont.FontSingle, 120, y, PrintJustification.epsleft, 15)
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
