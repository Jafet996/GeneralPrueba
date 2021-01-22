Imports Business
Public Class TImprimeApartado
    Inherits TPrint

#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _EmpresaParametro As TEmpresaParametro
    Private _Sucursal As TSucursal
    Private _ApartadoEncabezado As TApartadoEncabezado
    Private _TotalCantidad As Double = 0.00
    Private _EsReimpresion As Boolean = False
#End Region

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pEmpresaParametro As TEmpresaParametro, ByVal pSucursal As TSucursal, ByVal pApartadoEncabezado As TApartadoEncabezado, Optional pReimpresion As Boolean = False)
        MyBase.New()

        _Empresa = pEmpresa
        _EmpresaParametro = pEmpresaParametro
        _Sucursal = pSucursal
        _ApartadoEncabezado = pApartadoEncabezado
        _EsReimpresion = pReimpresion

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

        If _EsReimpresion Then
            Send("*** REIMRESIÓN APARTADO ***", PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If

        If _Empresa.Cedula <> "" Then
            Send("Cédula Jur: " & _Empresa.Cedula, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If

        If _Sucursal.Telefono <> "" Then
            Send("Tel: " & _Sucursal.Telefono, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If

        If _Sucursal.Email <> "" Then
            Send("Email: " & _Sucursal.Email, PrintFont.FontSingle, 1, y, PrintJustification.epsleft, 15)
        End If

        Send("Caja: " + Format(_ApartadoEncabezado.Caja_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        If _EsReimpresion Then
            Send("Apartado: " + Format(_ApartadoEncabezado.Apartado_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Else
            Send("Apartado: " + Format(_ApartadoEncabezado.Documento_Id), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

        Send("Fecha: " + Format(_ApartadoEncabezado.Fecha, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)

        If _EsReimpresion Then
            Send("Vencimiento: " + Format(_ApartadoEncabezado.Vencimiento, "dd/MM/yyyy hh:mm:ss tt"), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        End If

        Send("Cliente: " & _ApartadoEncabezado.Cliente.Nombre, PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Cant Descripción                  Precio", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
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

        For Each Fila As TApartadoDetalle In _ApartadoEncabezado.Detalle
            Sleep(300)

            Send(Alinea_Columnas(IIf(Fila.ExentoIV = 0, "*", " ") & Format(Fila.Cantidad, "0.00"), True, False, 4), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 0)

            _TotalCantidad += Fila.Cantidad

            Dim articulo As New TArticulo(EmpresaInfo.Emp_Id)
            articulo.Art_Id = Fila.Art_Id
            articulo.ListKey()

            Leyenda = " " & IIf(InfoMaquina.ImprimeCodigoArticulo, Fila.Art_Id & " - ", "") & articulo.Nombre & IIf(Fila.Observacion <> "", " : " & Fila.Observacion, "")

            While Leyenda.Length > 0
                Send(BuscaFraseEntera(Leyenda, 31).Trim, PrintFont.FontSingle, 45, y, PrintJustification.epsleft, 15)
            End While

            If Math.Abs(Fila.Cantidad) > 1 Then
                Send(Alinea_Columnas(CreaStrNumero(Fila.Precio), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 15)
            End If

            Send(Alinea_Columnas(CreaStrNumero(Fila.Precio * Fila.Cantidad), True, True, 10), PrintFont.FontSingle, 160, y, PrintJustification.epsleft, 0)


            Send("", PrintFont.FontSingle, 240, y, PrintJustification.epsRight, 15)
            Sleep(300)
        Next
        Send("----------------------------------------", PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Sleep(300)
    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        Dim DescPago As String = ""
        Dim Leyenda As String = ""

        Send("Monto ...:" & Alinea_Columnas(Format(_ApartadoEncabezado.Monto, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Prima ...:" & Alinea_Columnas(Format(_ApartadoEncabezado.Prima, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)
        Send("Saldo ...:" & Alinea_Columnas(Format(_ApartadoEncabezado.Saldo, "#,##0.00"), True, True, 26), PrintFont.FontSingle, 0, y, PrintJustification.epsleft, 15)


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
