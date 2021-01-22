Imports Business
Imports CORE_CLIENT
Public Module FacturacionElectronica


    'Private Function GetTipoDoc(pTipoDoc_Id As Enum_TipoDocumento) As String
    '    Dim Resultado As String = String.Empty

    '    Select Case pTipoDoc_Id
    '        Case Enum_TipoDocumento.Contado, Enum_TipoDocumento.Credito
    '            Resultado = "01"
    '        Case Enum_TipoDocumento.DevolucionContado, Enum_TipoDocumento.DvolucionCredito
    '            Resultado = "03"
    '        Case Else
    '            Throw New Exception("Tipo de documento no definido")
    '    End Select

    '    Return Resultado
    'End Function

    'Private Function GetIdentificacionTipo(pTipoIdentificacion_Id As Integer) As String
    '    Dim Resultado As String = String.Empty

    '    Select Case pTipoIdentificacion_Id
    '        Case 1 'Ced Física
    '            Resultado = "01"
    '        Case 2 'Ced Jurídica
    '            Resultado = "02"
    '        Case 3 'DIMEX
    '            Resultado = "03"
    '        Case 4 'NITE
    '            Resultado = "04"
    '        Case Else
    '            Throw New Exception("Tipo de identificación no definida")
    '    End Select

    '    Return Resultado
    'End Function

    'Private Function GetIdentificacionNumero(pTipoIdentificacion_Id As Integer, pNumeroIdentificacion As String) As String
    '    Dim Resultado As String = String.Empty

    '    pNumeroIdentificacion = pNumeroIdentificacion.Replace("-", "")

    '    Select Case pTipoIdentificacion_Id
    '        Case 1 'Ced Física
    '            Resultado = Mid(pNumeroIdentificacion, 1, 9)
    '        Case 2 'Ced Jurídica
    '            Resultado = Mid(pNumeroIdentificacion, 1, 10)
    '        Case 3 'DIMEX
    '            Resultado = Mid(pNumeroIdentificacion, 1, 12)
    '        Case 4 'NITE
    '            Resultado = Mid(pNumeroIdentificacion, 1, 10)
    '        Case Else
    '            Throw New Exception("Tipo de identificación no definida")
    '    End Select

    '    Return Resultado
    'End Function

    'Private Function GetIdentificacionNumeroExtrangero(pTipoIdentificacion_Id As Integer, pNumeroIdentificacion As String) As String
    '    Dim Resultado As String = String.Empty

    '    pNumeroIdentificacion = pNumeroIdentificacion.Replace("-", "")

    '    Select Case pTipoIdentificacion_Id
    '        Case 3 'DIMEX
    '            Resultado = Mid(pNumeroIdentificacion, 1, 12)
    '        Case 4 'NITE
    '            Resultado = Mid(pNumeroIdentificacion, 1, 10)
    '    End Select

    '    Return Resultado
    'End Function

    'Private Function GetLocalizacionCodigo(pValor As String) As String
    '    Dim Resultado As String = String.Empty

    '    Select Case pValor.Length
    '        Case > 2
    '            Resultado = Mid(pValor, 1, 2)
    '        Case 1
    '            Resultado = "0" & pValor
    '        Case Else
    '            Resultado = "00"
    '    End Select

    '    Return Resultado
    'End Function


    'Private Function GetNumeroTelefonico(pNumero As String) As String
    '    Dim Resultado As String = String.Empty

    '    pNumero = pNumero.Trim.Replace("-", "")

    '    If Not IsNumeric(pNumero) Then
    '        pNumero = "0"
    '    End If

    '    Resultado = pNumero

    '    Return Resultado
    'End Function


    'Private Function GetCorreoElectronico(pEmail As String) As String
    '    Dim Resultado As String = String.Empty

    '    If ValidaEmail(pEmail) = String.Empty Then
    '        Resultado = pEmail
    '    Else
    '        Resultado = String.Empty
    '    End If


    '    Return Resultado
    'End Function
    'Private Function GetCondicionVenta(pTipoDoc_Id As Enum_TipoDocumento) As String
    '    Dim Resultado As String = String.Empty

    '    Select Case pTipoDoc_Id
    '        Case Enum_TipoDocumento.Contado, Enum_TipoDocumento.DevolucionContado
    '            Resultado = "01"
    '        Case Enum_TipoDocumento.Credito, Enum_TipoDocumento.DevolucionCredito
    '            Resultado = "02"
    '        Case Else
    '            Throw New Exception("Tipo de documento no definido")
    '    End Select

    '    Return Resultado
    'End Function

    'Private Function GetTipoPago(pTipo_Id As Enum_TipoPago)
    '    Dim Resultado As String = String.Empty

    '    Select Case pTipo_Id
    '        Case Enum_TipoPago.Efectivo
    '            Resultado = "01"
    '        Case Enum_TipoPago.Tarjeta
    '            Resultado = "02"
    '        Case Enum_TipoPago.Cheque
    '            Resultado = "03"
    '        Case Else
    '            Resultado = "01"
    '    End Select

    '    Return Resultado
    'End Function


    'Private Function GetTipoPagoLista(pFacturaEncabezado As TFacturaEncabezado) As List(Of FeEncabezadoPago)
    '    Dim FePago As FeEncabezadoPago = Nothing
    '    Dim FePagos As New List(Of FeEncabezadoPago)

    '    For Each Pago As TFacturaPago In pFacturaEncabezado.FacturaPagos
    '        FePago = New FeEncabezadoPago

    '        With FePago
    '            .medioPago = GetTipoPago(Pago.TipoPago_Id)
    '        End With

    '        FePagos.Add(FePago)
    '    Next

    '    If FePagos.Count = 0 Then
    '        FePagos.Add(New FeEncabezadoPago With {.medioPago = "99"})
    '    End If

    '    If FePagos.Count > 4 Then
    '        Throw New Exception("No se permiten mas de 4 tipos de pago para un mismo documento")
    '    End If

    '    Return FePagos
    'End Function


    'Private Function GetDetallesLista(pFacturaEncabezado As TFacturaEncabezado) As List(Of FeDetalle)
    '    Dim FeLocDetalle As FeDetalle = Nothing
    '    Dim FeLocDetalles As New List(Of FeDetalle)
    '    Dim FeLocDetalleArticulo As FeDetalleArticulo = Nothing
    '    Dim FeLocDetalleArticulos As New List(Of FeDetalleArticulo)
    '    Dim FeLocDetalleImpuesto As FeDetalleImpuesto = Nothing
    '    Dim FeLocDetalleImpuestos As New List(Of FeDetalleImpuesto)



    '    For Each Detalle As TFacturaDetalle In pFacturaEncabezado.FacturaDetalles
    '        FeLocDetalle = New FeDetalle
    '        FeLocDetalleArticulo = New FeDetalleArticulo

    '        With FeLocDetalleArticulo
    '            .codigoTipo = "01"
    '            .codigo = Detalle.Art_Id
    '        End With
    '        FeLocDetalleArticulos.Add(FeLocDetalleArticulo)


    '        If Not Detalle.ExentoIV Then

    '        End If


    '        With FeLocDetalle
    '            .numeroLinea = Detalle.Detalle_Id
    '            .codigo = FeLocDetalleArticulos
    '            .cantidad = Math.Abs(Detalle.Cantidad)
    '            .unidadMedida = "Unid"
    '            .unidadMedidaComercial = "Unidad"
    '            .detalle = Detalle.Descripcion
    '            .precioUnitario = Math.Abs(Detalle.Precio)
    '            .montoTotal = Math.Abs(Detalle.Cantidad * Detalle.Precio)
    '            .montoDescuento = Math.Abs(Detalle.Cantidad * Detalle.MontoDescuento)
    '            .naturalezaDescuento = "Monto de descuentos concedidos"
    '            .subtotal = Math.Abs((Detalle.Precio * Detalle.Cantidad)) - Math.Abs((Detalle.MontoDescuento * Detalle.Cantidad))
    '            '.impuesto = New List < FeDetalleImpuesto > ();
    '            .montoTotalLinea = .subtotal + Math.Abs(Detalle.Cantidad * Detalle.MontoIV)
    '            .exento = Detalle.ExentoIV
    '            .servicio = Detalle.Servicio
    '            .comentario = Detalle.Observacion
    '        End With

    '        FeLocDetalles.Add(FeLocDetalle)
    '    Next

    '    If FeLocDetalles.Count > 1000 Then
    '        Throw New Exception("No se permiten mas de 1000 lineas para un mismo documento")
    '    End If

    '    Return FeLocDetalles

    'End Function


    'Public Function FacturaElectronicaEnvio(pFacturaEncabezado As TFacturaEncabezado) As String
    '    Dim Encabezado As New FeEncabezado()
    '    Dim Documento As New TDocumento
    '    Dim Mensaje As String = String.Empty
    '    Dim Resultado As String = String.Empty
    '    Try

    '        With Documento
    '            .CoreURL = "http://localhost:56132/"
    '            .FacturaURL = "api/Document/Create"
    '        End With


    '        With Encabezado
    '            .emisor_Id = EmpresaParametroInfo.Emisor_Id
    '            .tipoDoc = GetTipoDoc(pFacturaEncabezado.TipoDoc_Id)
    '            .fechaEmision = pFacturaEncabezado.Fecha
    '            .receptorNombre = IIf(pFacturaEncabezado.Cliente_Id = coClienteGeneral, "", pFacturaEncabezado.Cliente.Nombre)
    '            .receptorIdentificacionTipo = GetIdentificacionTipo(pFacturaEncabezado.Cliente.TipoIdentificacion_Id)
    '            .receptorIdentificacionNumero = GetIdentificacionNumero(pFacturaEncabezado.Cliente.TipoIdentificacion_Id, pFacturaEncabezado.Cliente.Cedula)
    '            .receptorIdentificacionExtranjero = GetIdentificacionNumeroExtrangero(pFacturaEncabezado.Cliente.TipoIdentificacion_Id, pFacturaEncabezado.Cliente.Cedula)
    '            .receptorNombreComercial = IIf(pFacturaEncabezado.Cliente_Id = coClienteGeneral, "", pFacturaEncabezado.Cliente.Nombre)
    '            .receptorProvincia = pFacturaEncabezado.Cliente.Provincia_Id
    '            .receptorCanton = GetLocalizacionCodigo(pFacturaEncabezado.Cliente.Canton_Id.ToString.Trim)
    '            .receptorDistrito = GetLocalizacionCodigo(pFacturaEncabezado.Cliente.Distrito_Id.ToString.Trim)
    '            .receptorBarrio = GetLocalizacionCodigo(pFacturaEncabezado.Cliente.Barrio_Id.ToString.Trim)
    '            .receptorOtrasSenas = IIf(pFacturaEncabezado.Cliente.Direccion.Trim.Length = 0, "No espeficicada", pFacturaEncabezado.Cliente.Direccion.Trim)
    '            .receptorTelefonoCodigoPais = 506
    '            .receptorTelefonoNumTelefono = GetNumeroTelefonico(pFacturaEncabezado.Cliente.Telefono1)
    '            .receptorFaxCodigoPais = 506
    '            .receptorFaxNumTelefono = GetNumeroTelefonico(pFacturaEncabezado.Cliente.Telefono2)
    '            .receptorCorreoElectronico = GetCorreoElectronico(pFacturaEncabezado.Cliente.Email)
    '            .condicionVenta = GetCondicionVenta(pFacturaEncabezado.TipoDoc_Id)
    '            .plazoCredito = pFacturaEncabezado.Cliente.DiasCredito
    '            .codigoMoneda = "CRC"
    '            .tipoCambio = TipoCambioVenta()
    '            .totalServGravados = 0.00
    '            .totalServExentos = 0.00
    '            .totalMercanciasGravadas = 0.00
    '            .totalMercanciasExentas = 0.00
    '            .totalGravado = 0.00
    '            .totalExento = 0.00
    '            .totalVenta = 0.00
    '            .totalDescuentos = 0.00
    '            .totalVentaNeta = 0.00
    '            .totalImpuesto = 0.00
    '            .totalComprobante = 0.00
    '            .comentarioFactura = ""
    '            .medioPago = GetTipoPagoLista(pFacturaEncabezado)
    '            .detalle = GetDetallesLista(pFacturaEncabezado)
    '        End With

    '        '.referencia = New List < FeEncabezadoReferencia > ()

    '        '.detalle = New List < FeDetalle > ()


    '    Catch ex As Exception
    '        Resultado = ex.Message
    '    End Try
    '    Return Resultado
    'End Function
End Module
