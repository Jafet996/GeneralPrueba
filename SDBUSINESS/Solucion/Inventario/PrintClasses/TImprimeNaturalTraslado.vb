Imports Business
Public Class TImprimeNaturalTraslado
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _EmpresaParametro As TEmpresaParametro
    Private _SucursalOrigen As TSucursal
    Private _SucursalDestino As TSucursal
    Private _TrasladoEncabezado As TTrasladoEncabezado
    Private _TotalCantidad As Double = 0.00

#End Region

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pEmpresaParametro As TEmpresaParametro, ByVal pTrasladoEncabezado As TTrasladoEncabezado)
        MyBase.New()

        _Empresa = pEmpresa
        _EmpresaParametro = pEmpresaParametro
        _TrasladoEncabezado = pTrasladoEncabezado

        _SucursalOrigen = New TSucursal(EmpresaInfo.Emp_Id)
        _SucursalOrigen.Suc_Id = pTrasladoEncabezado.SucOrigen_Id
        _SucursalOrigen.ListKey()

        _SucursalDestino = New TSucursal(EmpresaInfo.Emp_Id)
        _SucursalDestino.Suc_Id = pTrasladoEncabezado.SucDestino_Id
        _SucursalDestino.ListKey()
    End Sub

    Protected Overrides Sub Print_Doc()
        Dim y As Integer = 0

        ImprimeEncabezado(y)
        ImprimeDetalle(y)
        ImprimePieFactura(y)
    End Sub

    Private Sub ImprimeEncabezado(ByRef y As Integer)
        Dim Leyenda As String = ""





        Leyenda = _Empresa.Nombre
        While Leyenda.Length > 0
            Send(BuscaFraseEntera(Leyenda, 25).Trim, PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)
        End While



        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        If _Empresa.Cedula <> "" Then
            Send("Cédula Jurídica : " & _Empresa.Cedula, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Sucursal: " & _SucursalOrigen.Nombre, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        If _SucursalOrigen.Telefono <> "" Then
            Send("Tel: " & _SucursalOrigen.Telefono, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        'Send("Fax: " & _Sucursal.Fax, PrintFont.FontSingle, 140, y, PrintJustification.epsleft, 15)
        If _SucursalOrigen.Email <> "" Then
            Send("Email: " & _SucursalOrigen.Email, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If
        'Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        'Send(CentraTexto(_FacturaEncabezado.TipoDocumentoNombre), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Traslado", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Fecha: " + Format(_TrasladoEncabezado.Fecha, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Comentario: " & _TrasladoEncabezado.Comentario, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Origen: " & _SucursalOrigen.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Destino: " & _SucursalDestino.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)


        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("DESCRIPCION", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("CANTIDAD     COSTO UNIT     TOTAL LINEA", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
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
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)

        For Each Fila As TTrasladoDetalle In _TrasladoEncabezado.ListaDetalles
            Sleep(300)
            Articulo.Art_Id = Fila.Art_Id
            Articulo.ListKey()

            Leyenda = " " & IIf(InfoMaquina.ImprimeCodigoArticulo, Fila.Art_Id & " - ", "") & Articulo.Nombre
            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 31).Trim, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
            End While

            Send(Alinea_Columnas(IIf(Articulo.ExentoIV = 0, "*", " ") & Format(Fila.Cantidad, "0.0000"), True, False, 4), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)
            _TotalCantidad += Fila.Cantidad

            Send(Alinea_Columnas(CreaStrNumero(Fila.Costo), True, True, 10), PrintFont.FontSingle, 60, y, PrintJustification.epsleft, 0)

            Send(Alinea_Columnas(CreaStrNumero(Fila.Costo * Fila.Cantidad), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 15)


            Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            Sleep(300)
        Next
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("* = Artículo Gravado", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(300)

    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Dim DescPago As String = ""
        Dim Leyenda As String = ""
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsCenter, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsCenter, 15)

        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send(Alinea_Columnas("Firma", True, True, 10), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send(Alinea_Columnas("ORIGEN: " & _SucursalOrigen.Nombre, True, True, 10), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsCenter, 15)
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send(Alinea_Columnas("Firma", True, True, 10), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send(Alinea_Columnas("DESTINO: " & _SucursalDestino.Nombre, True, True, 10), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsCenter, 15)
        Send("", PrintFont.FontSingle, 0, y, PrintJustification.epsCenter, 15)
        Send("Cantidad Total ...:" & Alinea_Columnas(Format(_TotalCantidad, "#,##0.0000"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)

        Send("", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 10)
        Send("Total ¢" & Alinea_Columnas(Format(_TrasladoEncabezado.Costo, "#,##0.00"), True, True, 26), PrintFont.FontTitulo, 0, y, PrintJustification.epsleft, 15)





        Sleep(300)





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
