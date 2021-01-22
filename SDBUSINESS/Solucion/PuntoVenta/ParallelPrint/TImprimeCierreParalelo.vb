Imports Business
Public Class TImprimeCierreParalelo
    Inherits TPrintParallel


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
        ObjStream.Writeline("Cierre Caja")
        'ObjStream.Writeline(_Sucursal.Nombre)
        'ObjStream.Writeline("  ")
        ObjStream.Writeline(_Empresa.Nombre)
        ObjStream.Writeline(_Sucursal.Nombre)
        ObjStream.Writeline("")
        ObjStream.Writeline("Caja: " + _Caja.Caja_Id.ToString & " - " & _Caja.Nombre)
        ObjStream.Writeline("Cierre: " + Format(_CajaCierreEncabezado.Cierre_Id))
        ObjStream.Writeline("Cajero: " & _CajaCierreEncabezado.UsuarioNombre)
        ObjStream.Writeline("Fecha Apertura: " + Format(_CajaCierreEncabezado.FechaApertura, "dd/MM/yyyy hh:mm:ss tt"))
        ObjStream.Writeline("Fecha Cierre  : " + Format(_CajaCierreEncabezado.FechaCierre, "dd/MM/yyyy hh:mm:ss tt"))


        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("--------------------------------------")
        ObjStream.Writeline("Total Exento y Gravado")
        ObjStream.Writeline("--------------------------------------")
        Sleep(100)
        ObjStream.Writeline("Exento  : " + CreaStrNumero(_CajaCierreEncabezado.Exento))
        ObjStream.Writeline("Gravado : " + CreaStrNumero(_CajaCierreEncabezado.Gravado))


        ObjStream.Writeline("")
        ObjStream.Writeline("--------------------------------------")
        ObjStream.Writeline("Fondo de Caja")
        ObjStream.Writeline("--------------------------------------")
        Sleep(100)
        ObjStream.Writeline("Fondo...: " + CreaStrNumero(_CajaCierreEncabezado.Fondo))


        'ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("--------------------------------------")
        ObjStream.Writeline("Totales Sistema")
        ObjStream.Writeline("--------------------------------------")
        Sleep(100)
        ObjStream.Writeline("Efectivo: " + CreaStrNumero(_CajaCierreEncabezado.Efectivo))
        ObjStream.Writeline("Tarjetas: " + CreaStrNumero(_CajaCierreEncabezado.Tarjeta))
        ObjStream.Writeline("Cheques/Trans : " + CreaStrNumero(_CajaCierreEncabezado.Cheque))
        ObjStream.Writeline("")
        ObjStream.Writeline("--------------------------------------")
        ObjStream.Writeline("Recargas Telefonicas")
        ObjStream.Writeline("--------------------------------------")
        ObjStream.Writeline("Recargas: " + CreaStrNumero(_CajaCierreEncabezado.RecargaTelefonica))
        ObjStream.Writeline("")
        _CajaCierreEncabezado.Total = _CajaCierreEncabezado.Total + _CajaCierreEncabezado.RecargaTelefonica
        ObjStream.Writeline("Total Segun Sistema   : " + CreaStrNumero(_CajaCierreEncabezado.Total))
        _CajaCierreEncabezado.Total = _CajaCierreEncabezado.Total + _CajaCierreEncabezado.Fondo
        ObjStream.Writeline("Total + Fondo Caja    : " + CreaStrNumero(_CajaCierreEncabezado.Total))
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("--------------------------------------")
        ObjStream.Writeline("Totales Cajero")
        ObjStream.Writeline("--------------------------------------")
        Sleep(100)
        ObjStream.Writeline("Efectivo   : " + CreaStrNumero(_CajaCierreEncabezado.CajeroEfectivo))
        ObjStream.Writeline("Tarjetas   : " + CreaStrNumero(_CajaCierreEncabezado.CajeroTarjeta))
        ObjStream.Writeline("Cheques/Trans    : " + CreaStrNumero(_CajaCierreEncabezado.CajeroCheque))
        ObjStream.Writeline("Documentos : " + CreaStrNumero(_CajaCierreEncabezado.CajeroCheque))

        ObjStream.Writeline("")
        ObjStream.Writeline("Total Segun Cajero   : " + CreaStrNumero(_CajaCierreEncabezado.CajeroTotal))
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("--------------------------------------")
        ObjStream.Writeline("Detalle de Diferencias")
        ObjStream.Writeline("--------------------------------------")
        Sleep(100)
        ObjStream.Writeline(IIf(_CajaCierreEncabezado.CajeroTotal - _CajaCierreEncabezado.Total >= 0, "Sobrante : ", "Faltante : ") & _
             CreaStrNumero(_CajaCierreEncabezado.CajeroTotal - _CajaCierreEncabezado.Total))



    End Sub

    Private Function CreaStrNumero(pMonto As Double) As String
        Dim MontoStr As String = ""

        MontoStr = Format(pMonto, "#,##0.00")

        MontoStr = StrDup(13 - MontoStr.Length, " ") & MontoStr


        Return MontoStr
    End Function

    Private Sub ImprimeDetalle(ByRef y As Integer)
        Dim LineaStr As String = ""

        'ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("---------------------------------------")
        ObjStream.Writeline("# Doc    Tipo Pago                Monto")
        ObjStream.Writeline("---------------------------------------")
        For Each Fila As TCajaCierreDetalle In _CajaCierreEncabezado.CajaCierreDetalles
            LineaStr = Alinea_Columnas(Format(Fila.Documento_Id, "###"), True, False, 8) & _
                Alinea_Columnas(Mid(" " & IIf(Fila.TipoPago_Id = Enum_TipoPago.Cheque, Fila.NombreBanco, Fila.NombreTipoPago), 1, 19), True, False, 15) & _
                Alinea_Columnas(Format(Fila.Monto, "#,##0.00"), True, True, 16)

            ObjStream.Writeline(LineaStr)

            'ObjStream.Writeline(Alinea_Columnas(Format(Fila.Documento_Id, "###"), True, False, 8))
            'ObjStream.Writeline(Alinea_Columnas(Mid(" " & Fila.NombreTipoPago, 1, 19), True, False, 15))
            ''ObjStream.Writeline(Alinea_Columnas(CreaStrNumero(Fila.Monto), True, True, 10))
            'ObjStream.Writeline(Alinea_Columnas(Format(Fila.Monto, "#,##0.00"), True, True, 16))
            'ObjStream.Writeline("")
            Sleep(300)
        Next
        ObjStream.Writeline("---------------------------------------")
        Sleep(300)
        'ObjStream.Writeline("")
        'ObjStream.Writeline("")
        'ObjStream.Writeline("")
        'ObjStream.Writeline("")
        'ObjStream.Writeline("------------------------------")
        'ObjStream.Writeline("Firma Cajero")

    End Sub

    Private Sub ImprimePieFactura(ByRef y As Integer)
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("    --------------------------------    ")
        ObjStream.Writeline("              Firma Cajero              ")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")
        ObjStream.Writeline("")

        'ObjStream.Writeline("Sub Total ...:" & Alinea_Columnas(Format(_CajaCierreEncabezado.Subtotal, "#,##0.00"), True, True, 24))
        'ObjStream.Writeline("Descuento ...:" & Alinea_Columnas(Format(_CajaCierreEncabezado.Descuento, "#,##0.00"), True, True, 24))
        'ObjStream.Writeline("Monto IV  ...:" & Alinea_Columnas(Format(_CajaCierreEncabezado.IV, "#,##0.00"), True, True, 24))
        'ObjStream.Writeline("Redondeo  ...:" & Alinea_Columnas(Format(_CajaCierreEncabezado.Redondeo, "#,##0.00"), True, True, 24))
        'ObjStream.Writeline("Total .......:" & Alinea_Columnas(Format(_CajaCierreEncabezado.TotalCobrado, "#,##0.00"), True, True, 24))
        Sleep(100)

    End Sub
End Class
