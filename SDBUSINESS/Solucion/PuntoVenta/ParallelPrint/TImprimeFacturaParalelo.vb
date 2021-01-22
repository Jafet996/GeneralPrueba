Imports Business
Public Class TImprimeFacturaParalelo
    Inherits TPrintParallel


#Region "Declaracion de variables"
    Private _Empresa As TEmpresa
    Private _EmpresaParametro As TEmpresaParametro
    Private _Sucursal As TSucursal
    Private _FacturaEncabezado As TFacturaEncabezado
#End Region

    Private Function CreaStrNumero(pMonto As Double) As String
        Dim MontoStr As String = ""

        MontoStr = Format(pMonto, "#,##0.00")

        MontoStr = StrDup(12 - MontoStr.Length, " ") & MontoStr


        Return MontoStr
    End Function

    Public Sub New(ByVal pEmpresa As TEmpresa, ByVal pEmpresaParametro As TEmpresaParametro, ByVal pSucursal As TSucursal, ByVal pFacturaEnzabezado As TFacturaEncabezado)
        MyBase.New()
        _Empresa = pEmpresa
        _EmpresaParametro = pEmpresaParametro
        _Sucursal = pSucursal
        _FacturaEncabezado = pFacturaEnzabezado
    End Sub

    Protected Overrides Sub Print_Doc()
        ImprimeEncabezado()
        ImprimeDetalle()
        ImprimePieFactura()
    End Sub

    Private Sub ImprimeEncabezado()
        Dim Leyenda As String

        If _FacturaEncabezado.Reimpresion Then
            ObjStream.Writeline("REIMPRESION")
            ObjStream.Writeline("")
        End If

        ObjStream.Writeline(_Empresa.Nombre)
        ObjStream.Writeline("")
        If _Empresa.Cedula <> "" Then
            ObjStream.Writeline("Cédula Jur: " & _Empresa.Cedula)
        End If
        If _Sucursal.Telefono <> "" Then
            ObjStream.Writeline("Tel: " & _Sucursal.Telefono)
        End If
        If _Sucursal.Email <> "" Then
            ObjStream.Writeline("Email: " & _Sucursal.Email)
        End If
        ObjStream.Writeline(_FacturaEncabezado.TipoDocumentoNombre)
        ObjStream.Writeline("Caja: " + Format(_FacturaEncabezado.Caja_Id))
        ObjStream.Writeline("Factura: " + Format(_FacturaEncabezado.Documento_Id))
        ObjStream.Writeline("Fecha: " + Format(_FacturaEncabezado.Fecha, "dd/MM/yyyy hh:mm:ss tt"))
        ObjStream.Writeline("Cajero: " & _FacturaEncabezado.UsuarioNombre)
        ObjStream.Writeline("Cliente: " & _FacturaEncabezado.Nombre)

        If _FacturaEncabezado.Comentario.Length > 0 Then
            ObjStream.Writeline("")
            Leyenda = "Comentario: " & _FacturaEncabezado.Comentario
            While Leyenda.Length > 0
                ObjStream.Writeline(BuscaFraseEntera(Leyenda, 36).Trim)
            End While
            ObjStream.Writeline("", PrintFont.FontSingle)
        End If


        ObjStream.Writeline("----------------------------------------")
        ObjStream.Writeline("Cant Descripcion                  Precio")
        ObjStream.Writeline("----------------------------------------")
        Sleep(100)
    End Sub
    Private Sub ImprimeDetalle()
        Dim LineaStr As String = ""

        For Each Fila As TFacturaDetalle In _FacturaEncabezado.FacturaDetalles
            Sleep(300)
            LineaStr = Alinea_Columnas(Format(Fila.Cantidad, "###"), True, False, 4) & Alinea_Columnas(Mid(IIf(Fila.ExentoIV, " ", "*") & Fila.Descripcion, 1, 20), True, False, 24) & Alinea_Columnas(CreaStrNumero(Fila.Precio * Fila.Cantidad), True, True, 10)
            ObjStream.Writeline(LineaStr)
            Sleep(300)
        Next
        ObjStream.Writeline("----------------------------------------")
        ObjStream.Writeline("* = Articulo Gravado")
        Sleep(300)
    End Sub

    Private Sub ImprimePieFactura()
        Dim DescPago As String = ""
        Dim Leyenda As String = ""

        ObjStream.Writeline("Sub Total ...:" & Alinea_Columnas(Format(_FacturaEncabezado.Subtotal, "#,##0.00"), True, True, 26))
        If Math.Abs(_FacturaEncabezado.Descuento) > 0 Then
            ObjStream.Writeline("Descuento ...:" & Alinea_Columnas(Format(_FacturaEncabezado.Descuento, "#,##0.00"), True, True, 26))
        End If
        If Math.Abs(_FacturaEncabezado.IV) > 0 Then
            ObjStream.Writeline("Monto IV  ...:" & Alinea_Columnas(Format(_FacturaEncabezado.IV, "#,##0.00"), True, True, 26))
        End If
        If Math.Abs(_FacturaEncabezado.Redondeo) > 0 Then
            ObjStream.Writeline("Redondeo  ...:" & Alinea_Columnas(Format(_FacturaEncabezado.Redondeo, "#,##0.00"), True, True, 26))
        End If
        ObjStream.Writeline("Total .......:" & Alinea_Columnas(Format(_FacturaEncabezado.TotalCobrado, "#,##0.00"), True, True, 26))
        Sleep(300)


        If _FacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.Contado Then
            ObjStream.Writeline("Pago con -------------------------------")
            For Each Pago As TFacturaPago In _FacturaEncabezado.FacturaPagos
                Select Case Pago.TipoPago_Id
                    Case Enum_TipoPago.Efectivo
                        DescPago = "Efectivo ....:"
                    Case Enum_TipoPago.Cheque
                        DescPago = "Cheque ......:"
                    Case Enum_TipoPago.Tarjeta
                        DescPago = "Tarjeta .....:"
                    Case Enum_TipoPago.Puntos
                        DescPago = "Puntos ......:"
                End Select
                ObjStream.Writeline(DescPago & Alinea_Columnas(CreaStrNumero(Pago.Monto), True, True, 26))
                Sleep(300)
            Next
            ObjStream.Writeline("Vuelto ......:" & Alinea_Columnas(CreaStrNumero(_FacturaEncabezado.Vuelto), True, True, 26))
        End If

        If _EmpresaParametro.LeyendaFactura1.Trim <> "" Then
            ObjStream.Writeline("")
            ObjStream.Writeline("")

            Leyenda = _EmpresaParametro.LeyendaFactura1
            While Leyenda.Length > 0
                ObjStream.Writeline(BuscaFraseEntera(Leyenda, 36).Trim)
            End While
        End If
        Sleep(200)
        If _EmpresaParametro.LeyendaFactura2.Trim <> "" Then
            ObjStream.Writeline("")
            ObjStream.Writeline("")

            Leyenda = _EmpresaParametro.LeyendaFactura2
            While Leyenda.Length > 0
                ObjStream.Writeline(BuscaFraseEntera(Leyenda, 36).Trim)
            End While
        End If



        If _FacturaEncabezado.TipoDoc_Id = Enum_TipoDocumento.Credito Then
            ObjStream.Writeline("")
            ObjStream.Writeline("")
            ObjStream.Writeline("    --------------------------------    ")
            ObjStream.Writeline("              Firma Cliente             ")
            ObjStream.Writeline("")
            ObjStream.Writeline("")
        End If


        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")


    End Sub


End Class
