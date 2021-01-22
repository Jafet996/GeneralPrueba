Imports Business
Public Class TImprimeCxCMovimiento
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _CxCMovimiento As TCxCMovimiento
#End Region

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pCxCMovimiento As TCxCMovimiento)
        MyBase.New()
        _Empresa = pEmpresa
        _CxCMovimiento = pCxCMovimiento
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
        If _CxCMovimiento.Caja_Id > 0 Then Send("Caja   : " + Format(_CxCMovimiento.Caja_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha  : " + Format(_CxCMovimiento.Fecha, "dd/MM/yyyy hh:mm tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Leyenda = "Cajero : " & _CxCMovimiento.UsuarioNombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End While
        Leyenda = "Cliente: " & _CxCMovimiento.ClienteNombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End While
        If _CxCMovimiento.Moneda = coMonedaColones Then
            Send("Moneda: COLONES", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
        Else
            Send("Moneda: DÓLARES (" & Math.Abs(_CxCMovimiento.Dolares) & ")", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
        End If
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 18)
        Leyenda = _CxCMovimiento.TipoNombre & " # " & Format(_CxCMovimiento.Mov_Id, "###")
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 25).Trim, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 20)
        End While
        Send("Monto  : " & CreaStrNumero(Math.Abs(_CxCMovimiento.Monto)), PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)

        If _CxCMovimiento.Referencia.Trim <> "" Then
            Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Leyenda = "Referencia: " & _CxCMovimiento.Referencia
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 36).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While
        End If

        If _CxCMovimiento.Reimpresion Then
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

        If _CxCMovimiento.ListaAplicados.Count > 0 Then
            Send("Detalle del documento", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

        For Each Fila As TCxCMovimiento In _CxCMovimiento.ListaAplicados
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
        Send("Saldo del Cliente", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("------------------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Saldo Actual  :", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
        Send(Alinea_Columnas(CreaStrNumero(_CxCMovimiento.SaldoCliente), True, True, 10), PrintFont.FontSingle, 120, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("              --------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("                        Firma", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("================================================", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
    End Sub

End Class
