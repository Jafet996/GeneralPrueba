Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports CORE_CLIENT
Imports CORE_CLIENT.Public_Classes

Public Class TFacturacionElectronica
#Region "Variables"
    Private _CoreURL As String
    Private _FeEncabezado As TFeEncabezado
    Private _Encabezado As TFacturaEncabezado
    Private _Token As String
    Private _Emisor_Id As Integer
    Private _Consecutivo As String
    Private _Clave As String
    Private _Batch_Id As Long
    Private _Situacion As Enum_SituacionDocumentoElectronico
    Private _Moneda As String
    Private _TipoCambio As Double
    Private _CantidadStr As String
#End Region
#Region "Propiedades"
    Public Property CoreURL As String
        Get
            Return _CoreURL
        End Get
        Set(value As String)
            _CoreURL = value
        End Set
    End Property
    Public WriteOnly Property Encabezado As TFacturaEncabezado
        Set(value As TFacturaEncabezado)
            _Encabezado = value
        End Set
    End Property
    Public WriteOnly Property Token As String
        Set(value As String)
            _Token = value
        End Set
    End Property
    Public WriteOnly Property Emisor_Id As Integer
        Set(value As Integer)
            _Emisor_Id = value
        End Set
    End Property
    Public WriteOnly Property Consecutivo As String
        Set(value As String)
            _Consecutivo = value
        End Set
    End Property
    Public WriteOnly Property Clave As String
        Set(value As String)
            _Clave = value
        End Set
    End Property
    Public WriteOnly Property Bacth_Id As Long
        Set(value As Long)
            _Batch_Id = value
        End Set
    End Property
    Public Property Moneda As String
        Get
            Return _Moneda
        End Get
        Set(value As String)
            _Moneda = value
        End Set
    End Property
    Public WriteOnly Property Situacion As Enum_SituacionDocumentoElectronico
        Set(value As Enum_SituacionDocumentoElectronico)
            _Situacion = value
        End Set
    End Property
    Public WriteOnly Property TipoCambio As Double
        Set(value As Double)
            _TipoCambio = value
        End Set
    End Property
    Public WriteOnly Property CantidadStr As String
        Set(value As String)
            _CantidadStr = value
        End Set
    End Property


#End Region
#Region "Constructores"
    Public Sub New()
        _CoreURL = String.Empty
        _FeEncabezado = New TFeEncabezado
        _Token = String.Empty
        _Emisor_Id = 0
        _Consecutivo = String.Empty
        _Clave = String.Empty
        _Batch_Id = 0
        _TipoCambio = 0
        _Moneda = String.Empty
        _CantidadStr = String.Empty
    End Sub
#End Region
#Region "Metodos Privados"
    Private Function GetTipoDoc(pTipoDoc_Id As Enum_TipoDocumento) As String
        Dim Resultado As String = String.Empty

        Resultado = Mid(_Consecutivo, 9, 2)

        Return Resultado

    End Function
    Private Function GetIdentificacionTipo(pTipoIdentificacion_Id As Enum_TipoIdentificacion) As String
        Dim Resultado As String = String.Empty

        Select Case pTipoIdentificacion_Id
            Case Enum_TipoIdentificacion.Fisica 'Ced Física
                Resultado = "01"
            Case Enum_TipoIdentificacion.Juridica 'Ced Jurídica
                Resultado = "02"
            Case Enum_TipoIdentificacion.DIMEX 'DIMEX
                Resultado = "03"
            Case Enum_TipoIdentificacion.NITE 'NITE
                Resultado = "04"
            Case Else
                Resultado = "00"
        End Select

        Return Resultado
    End Function

    Private Function GetIdentificacionNumero(pTipoIdentificacion_Id As Enum_TipoIdentificacion, pNumeroIdentificacion As String) As String
        Dim Resultado As String = String.Empty

        pNumeroIdentificacion = pNumeroIdentificacion.Replace("-", "")

        Select Case pTipoIdentificacion_Id
            Case Enum_TipoIdentificacion.Fisica 'Ced Física
                Resultado = Mid(pNumeroIdentificacion, 1, 9)
            Case Enum_TipoIdentificacion.Juridica 'Ced Jurídica
                Resultado = Mid(pNumeroIdentificacion, 1, 10)
            Case Enum_TipoIdentificacion.DIMEX 'DIMEX
                Resultado = Mid(pNumeroIdentificacion, 1, 12)
            Case Enum_TipoIdentificacion.NITE 'NITE
                Resultado = Mid(pNumeroIdentificacion, 1, 10)
            Case Else
                Resultado = String.Empty
        End Select

        Return Resultado
    End Function

    Private Function GetIdentificacionNumeroExtrangero(pTipoIdentificacion_Id As Enum_TipoIdentificacion, pNumeroIdentificacion As String) As String
        Dim Resultado As String = String.Empty


        Select Case pTipoIdentificacion_Id
            Case Enum_TipoIdentificacion.Extranjero
                Resultado = Mid(pNumeroIdentificacion, 1, 20)
        End Select

        Return Resultado
    End Function

    Private Function GetLocalizacionCodigo(pValor As String) As String
        Dim Resultado As String = String.Empty


        If pValor.Trim.Length >= 2 Then
            Resultado = Mid(pValor, 1, 2)
        ElseIf pValor.Trim.Length = 1 Then
            Resultado = "0" & pValor
        Else
            VerificaMensaje("Error dandole formato a los valores de la ubicacion, favor verificar el cliente")
        End If

        Return Resultado
    End Function


    Private Function GetNumeroTelefonico(pNumero As String) As String
        Dim Resultado As String = String.Empty

        pNumero = pNumero.Trim.Replace("-", "")

        If Not IsNumeric(pNumero) Then
            pNumero = "0"
        End If

        Resultado = pNumero

        Return Resultado
    End Function


    Private Function GetCorreoElectronico(pEmail As String) As String
        Dim Resultado As String = String.Empty

        If ValidaEmail(pEmail) = String.Empty Then
            Resultado = pEmail
        Else
            Resultado = String.Empty
        End If

        Return Resultado
    End Function
    Private Function GetCondicionVenta(pTipoDoc_Id As Enum_TipoDocumento) As String
        Dim Resultado As String = String.Empty

        Select Case pTipoDoc_Id
            Case Enum_TipoDocumento.Contado, Enum_TipoDocumento.DevolucionContado
                Resultado = "01"
            Case Enum_TipoDocumento.Credito, Enum_TipoDocumento.DevolucionCredito
                Resultado = "02"
            Case Else
                Throw New Exception("Tipo de documento no definido")
        End Select

        Return Resultado
    End Function

    Public Function GetPlazoCredito(pTipoDoc_Id As Enum_TipoDocumento) As String
        Dim Resultado As String = String.Empty

        Select Case pTipoDoc_Id
            Case Enum_TipoDocumento.Contado, Enum_TipoDocumento.DevolucionContado
                Resultado = ""
            Case Enum_TipoDocumento.Credito, Enum_TipoDocumento.DevolucionCredito
                Resultado = _Encabezado.Cliente.DiasCredito.ToString()
            Case Else
                Throw New Exception("Tipo de documento no definido")
        End Select

        Return Resultado
    End Function

    Private Function GetTipoPago(pTipo_Id As Enum_TipoPago)
        Dim Resultado As String = String.Empty

        Select Case pTipo_Id
            Case Enum_TipoPago.Efectivo
                Resultado = "01"
            Case Enum_TipoPago.Tarjeta
                Resultado = "02"
            Case Enum_TipoPago.Cheque
                Resultado = "03"
            Case Else
                Resultado = "01"
        End Select

        Return Resultado
    End Function


    Private Function GetTipoPagoLista(pFacturaEncabezado As TFacturaEncabezado) As List(Of TFePago)
        Dim FePago As TFePago = Nothing
        Dim FePagos As New List(Of TFePago)

        For Each Pago As TFacturaPago In pFacturaEncabezado.FacturaPagos
            FePago = New TFePago

            With FePago
                .medioPago = GetTipoPago(Pago.TipoPago_Id)
            End With

            FePagos.Add(FePago)
        Next

        If FePagos.Count = 0 Then
            FePagos.Add(New TFePago With {.medioPago = "99"})
        End If

        If FePagos.Count > 4 Then
            Throw New Exception("No se permiten mas de 4 tipos de pago para un mismo documento")
        End If

        Return FePagos
    End Function

    Public Function GetReferenciaLista(pFacturaEncabezado As TFacturaEncabezado) As List(Of TFeReferencia)
        Dim FE As New TFacturaElectronica(EmpresaInfo.Emp_Id)
        Dim Referencias As New List(Of TFeReferencia)

        If Not pFacturaEncabezado.FacturaDev Is Nothing Then
            With FE
                .Emp_Id = pFacturaEncabezado.FacturaDev.Emp_Id
                .Suc_Id = pFacturaEncabezado.FacturaDev.Suc_Id
                .Caja_Id = pFacturaEncabezado.FacturaDev.Caja_Id
                .TipoDoc_Id = pFacturaEncabezado.FacturaDev.TipoDoc_Id
                .Documento_Id = pFacturaEncabezado.FacturaDev.Documento_Id
            End With

            VerificaMensaje(FE.ListKey())
            If FE.RowsAffected = 0 Then
                VerificaMensaje("No se encontró el documento al que se está referenciando")
            End If


            Referencias.Add(New TFeReferencia() With
                            {.tipoDoc = "01" _
                            , .numero = FE.Clave _
                            , .codigo = coCodRefAnulaDocumento _
                            , .fechaEmision = FE.Fecha _
                            , .razon = "Anulación de Factura"})
        Else
            If pFacturaEncabezado.ReferenciaNC Is Nothing Then
                VerificaMensaje("No se encontro una referencia manual a una Nota de Credito")
            Else
                Referencias.Add(New TFeReferencia() With
                {.tipoDoc = pFacturaEncabezado.ReferenciaNC.Tipo _
                , .numero = pFacturaEncabezado.ReferenciaNC.Documento _
                , .codigo = IIf(pFacturaEncabezado.ReferenciaNC.Codigo = "", coCodRefOtros, pFacturaEncabezado.ReferenciaNC.Codigo) _
                , .fechaEmision = pFacturaEncabezado.ReferenciaNC.Fecha _
                , .razon = pFacturaEncabezado.ReferenciaNC.Razon})
            End If

        End If


        Return Referencias

    End Function

    Private Function DecimalMayorCero(pNumeroSTR As String, pInicioValidacion As Integer) As Boolean
        Dim Resultado As Boolean = False


        For i As Integer = 0 To pNumeroSTR.Length - 1
            If i + 1 > pInicioValidacion Then
                If IsNumeric(Mid(pNumeroSTR, i + 1, 1)) AndAlso CInt(Mid(pNumeroSTR, i + 1, 1)) <> 0 Then
                    Resultado = True
                    Exit For
                End If
            End If
        Next

        Return Resultado

    End Function


    Private Function GetDetallesLista(pFacturaEncabezado As TFacturaEncabezado) As List(Of TFeDetalle)
        Dim FeDetalle As TFeDetalle = Nothing
        Dim FeDetalles As New List(Of TFeDetalle)

        Dim FeArticulo As TFeArticulo = Nothing
        Dim FeArticulos As List(Of TFeArticulo)

        Dim FeImpuesto As TFeImpuesto = Nothing
        Dim FeLocDetalleImpuestos As List(Of TFeImpuesto)

        Dim PrecioUnitario As Double = 0
        Dim MontoIV As Double = 0
        Dim MontoDescuento As Double = 0

        Dim numberAsString As String = String.Empty
        Dim indexOfDecimalPoint As Integer = 0
        Dim numberOfDecimals As Integer = 0
        Dim IVACalculoEspecial As Boolean = False


        For Each Detalle As TFacturaDetalle In pFacturaEncabezado.FacturaDetalles

            PrecioUnitario = 0
            MontoIV = 0
            MontoDescuento = 0


            FeDetalle = New TFeDetalle
            FeLocDetalleImpuestos = New List(Of TFeImpuesto)
            FeArticulos = New List(Of TFeArticulo)
            FeArticulo = New TFeArticulo

            With FeArticulo
                .codigoTipo = "01"
                .codigo = Detalle.Art_Id

            End With
            FeArticulos.Add(FeArticulo)


            Select Case _Moneda
                Case coFEMonedaDolar
                    PrecioUnitario = Detalle.Precio / _TipoCambio
                    MontoDescuento = Detalle.MontoDescuento / _TipoCambio
                    MontoIV = Detalle.MontoIV / _TipoCambio
                Case Else
                    PrecioUnitario = Detalle.Precio
                    MontoDescuento = Detalle.MontoDescuento
                    MontoIV = Detalle.MontoIV
            End Select

            'cambio iva
            For Each DetalleImpuesto As TFacturaDetalleImpuesto In Detalle.ArticuloImpuestos
                FeImpuesto = New TFeImpuesto

                If DetalleImpuesto.Codigo_Id = coImpuestoIVACalculoEspecial Then
                    IVACalculoEspecial = True
                End If

                With FeImpuesto
                    .codigo = DetalleImpuesto.Codigo_Id
                    .codigoTarifa = IIf(DetalleImpuesto.Tarifa_Id = "00", String.Empty, DetalleImpuesto.Tarifa_Id)
                    .tarifa = IIf(DetalleImpuesto.Codigo_Id <> coImpuestoIVABienesUsados, DetalleImpuesto.Porcentaje, 0)
                    .factorIVA = IIf(DetalleImpuesto.Codigo_Id = coImpuestoIVABienesUsados, DetalleImpuesto.Porcentaje, 0)
                    .monto = DetalleImpuesto.Total / IIf(_Moneda = coFEMonedaDolar, _TipoCambio, 1.0)
                    .montoExportacion = 0

                    If pFacturaEncabezado.Exoneracion Then
                        .exoTipoDocumento = pFacturaEncabezado.FacturaExoneracion.TipoDocumento
                        .exoNumeroDocumento = pFacturaEncabezado.FacturaExoneracion.NumeroDocumento
                        .exoNombreInstitucion = pFacturaEncabezado.FacturaExoneracion.NombreInstitucion
                        .exoFechaEmision = pFacturaEncabezado.FacturaExoneracion.FechaEmision
                        .exoPorcentajeExoneracion = pFacturaEncabezado.FacturaExoneracion.PorcentajeExoneracion
                        .exoMontoExoneracion = 0 'El API lo calcula
                    End If
                    'If Not pFacturaEncabezado.FacturaExoneracion Is Nothing AndAlso pFacturaEncabezado.FacturaExoneracion.PorcentajeExoneracion > 0 Then
                    'End If
                End With

                FeLocDetalleImpuestos.Add(FeImpuesto)
            Next


            With FeDetalle
                .numeroLinea = Detalle.Detalle_Id

                'cambio iva
                .partidaArancelaria = String.Empty
                .codigo = Detalle.CabysCodigo 'clgc
                .codigoComercial = FeArticulos

                .cantidad = Math.Abs(Detalle.Cantidad)
                .unidadMedida = IIf(Detalle.Servicio, "Sp", "Unid")
                .unidadMedidaComercial = String.Empty
                .detalle = Detalle.Descripcion.Replace("'", " ")
                .precioUnitario = Math.Abs(PrecioUnitario)
                .montoTotal = Math.Abs(Detalle.Cantidad * PrecioUnitario)

                ' cambio  iva
                If Detalle.MontoDescuento > 0 Then
                    .descuento.Add(New TFeDetalleDescuento With
                    {
                        .montoDescuento = Math.Abs(Detalle.Cantidad * MontoDescuento),
                        .naturalezaDescuento = "Monto de descuento concedido"
                    })
                End If

                .subtotal = Math.Abs((PrecioUnitario * Detalle.Cantidad)) - Math.Abs((MontoDescuento * Detalle.Cantidad))

                ' cambio  iva
                .baseImponible = IIf(IVACalculoEspecial, Math.Abs((PrecioUnitario * Detalle.Cantidad)) - Math.Abs((MontoDescuento * Detalle.Cantidad)), 0)

                .impuesto = FeLocDetalleImpuestos

                ' cambio  iva
                .impuestoNeto = 0

                .montoTotalLinea = .subtotal + Math.Abs(Detalle.Cantidad * MontoIV)
                .exento = Detalle.ExentoIV
                .servicio = Detalle.Servicio
                .bonificacion = False
                .comentario = Detalle.Observacion.Replace("'", " ")

            End With

            FeDetalles.Add(FeDetalle)
        Next

        If FeDetalles.Count = 0 Then
            Throw New Exception("El documento no tiene detalles FeDetalles:ERROR")
        End If

        If FeDetalles.Count > 1000 Then
            Throw New Exception("No se permiten mas de 1000 lineas para un mismo documento")
        End If

        Return FeDetalles
    End Function

    Public Function GetSituacionDocumentoElectronico() As String
        Dim valor As String

        Select Case _Situacion
            Case Enum_SituacionDocumentoElectronico.Normal
                valor = "1"
            Case Enum_SituacionDocumentoElectronico.Contingencia
                valor = "2"
            Case Enum_SituacionDocumentoElectronico.SinInternet
                valor = "3"
            Case Else
                valor = "0"
        End Select

        Return valor
    End Function


    Private Sub ValidaIdentificacionReceptor(ByRef pIdentificacionTipo As String, ByRef pIdentificacionNumero As String)
        Dim OmiteIdentificacion As Boolean = False

        If pIdentificacionNumero.Trim = String.Empty Then
            OmiteIdentificacion = True
        End If

        If InStr(pIdentificacionNumero, "-") > 0 Then
            OmiteIdentificacion = True
        End If

        If InStr(pIdentificacionNumero.Trim, " ") > 0 Then
            OmiteIdentificacion = True
        End If

        If Mid(pIdentificacionNumero, 1, 1) = "0" Then
            OmiteIdentificacion = True
        End If

        If Not IsNumeric(pIdentificacionNumero) Then
            OmiteIdentificacion = True
        End If

        Select Case pIdentificacionTipo
            Case "01" 'Cedula Fisica
                If pIdentificacionNumero.Trim.Length <> 9 Then
                    OmiteIdentificacion = True
                End If
            Case "02", "04" 'Cedula Juridica - NITE
                If pIdentificacionNumero.Trim.Length <> 10 Then
                    OmiteIdentificacion = True
                End If
            Case "03" 'DIMEX
                If pIdentificacionNumero.Trim.Length <> 11 And pIdentificacionNumero.Trim.Length <> 12 Then
                    OmiteIdentificacion = True
                End If
            Case Else
                OmiteIdentificacion = True
        End Select

        If OmiteIdentificacion Then
            pIdentificacionTipo = "00"
            pIdentificacionNumero = ""
        End If

    End Sub

#End Region
#Region "Metodos Publicos"
    Public Function Facturar(pCn As Connection.TConnectionManager) As String
        Dim DE As New TDocumentoElectronico
        Dim documentResponse As New DocumentResponse
        Dim FacturaElectonica As New TFacturaElectronica(EmpresaInfo.Emp_Id)

        Try
            MensajeEnviaFE(_Clave, _CantidadStr)

            With DE
                .CoreURL = _CoreURL
            End With

            With _FeEncabezado
                .numeroConsecutivo = _Consecutivo
                .clave = _Clave
                .suc_Id = _Encabezado.Suc_Id
                .caja_Id = _Encabezado.Caja_Id
                .token = _Token
                .emisor_Id = _Emisor_Id
                .tipoDoc = GetTipoDoc(_Encabezado.TipoDoc_Id)
                .fechaEmision = _Encabezado.Fecha
                .documento = _Encabezado.Emp_Id.ToString() & "|" & _Encabezado.Suc_Id.ToString() & "|" & _Encabezado.Caja_Id.ToString() & "|" & _Encabezado.TipoDoc_Id.ToString() & "|" & _Encabezado.Documento_Id.ToString() & "|SDBUSINESS"

                If EmpresaParametroInfo.FeReceptor Then
                    .receptorNombre = IIf(_Encabezado.Cliente_Id = coClienteGeneral, "", _Encabezado.Cliente.Nombre)
                    .receptorCorreoElectronico = IIf(_Encabezado.Cliente_Id = coClienteGeneral, "", GetCorreoElectronico(_Encabezado.Cliente.Email))
                    If _Encabezado.Cliente_Id <> coClienteGeneral Then
                        If EmpresaParametroInfo.FeReceptorIdentificacion Then
                            .receptorIdentificacionTipo = GetIdentificacionTipo(_Encabezado.Cliente.TipoIdentificacion_Id)
                            .receptorIdentificacionNumero = GetIdentificacionNumero(_Encabezado.Cliente.TipoIdentificacion_Id, _Encabezado.Cliente.Cedula)
                        Else
                            .receptorIdentificacionTipo = "00"
                            .receptorIdentificacionNumero = ""
                        End If

                        .receptorIdentificacionExtranjero = GetIdentificacionNumeroExtrangero(_Encabezado.Cliente.TipoIdentificacion_Id, _Encabezado.Cliente.Cedula)
                        .receptorNombreComercial = IIf(_Encabezado.Cliente_Id = coClienteGeneral, "", _Encabezado.Cliente.Nombre)

                        If EmpresaParametroInfo.FeReceptorUbicacion Then
                            .receptorProvincia = _Encabezado.Cliente.Provincia_Id
                            .receptorCanton = GetLocalizacionCodigo(_Encabezado.Cliente.Canton_Id.ToString.Trim)
                            .receptorDistrito = GetLocalizacionCodigo(_Encabezado.Cliente.Distrito_Id.ToString.Trim)
                            .receptorBarrio = GetLocalizacionCodigo(_Encabezado.Cliente.Barrio_Id.ToString.Trim)
                            .receptorOtrasSenas = IIf(_Encabezado.Cliente.Direccion.Trim.Length > 0 And .receptorIdentificacionNumero <> "", _Encabezado.Cliente.Direccion.Trim, "No especificada")
                            .receptorOtrasSenasExtranjero = IIf(.receptorIdentificacionExtranjero <> String.Empty, _Encabezado.Cliente.Direccion.Trim, String.Empty)
                        Else
                            .receptorProvincia = "0"
                            .receptorCanton = "00"
                            .receptorDistrito = "00"
                            .receptorBarrio = "00"
                            .receptorOtrasSenas = ""
                            .receptorOtrasSenasExtranjero = ""
                        End If

                        If EmpresaParametroInfo.FeReceptorTelefono Then
                            .receptorTelefonoCodigoPais = 506
                            .receptorTelefonoNumTelefono = GetNumeroTelefonico(_Encabezado.Cliente.Telefono1)
                            .receptorFaxCodigoPais = 506
                            .receptorFaxNumTelefono = GetNumeroTelefonico(_Encabezado.Cliente.Telefono2)
                            .receptorCorreoElectronico = GetCorreoElectronico(_Encabezado.Cliente.Email)
                        Else
                            .receptorTelefonoCodigoPais = 0
                            .receptorTelefonoNumTelefono = 0
                            .receptorFaxCodigoPais = 0
                            .receptorFaxNumTelefono = 0
                        End If
                    End If
                Else
                    .receptorNombre = String.Empty
                End If

                ''>>---------------------------------------------------------------
                'If .tipoDoc = coFacturaElectronica And .receptorNombre = "" Then
                '    .receptorNombre = _Encabezado.Cliente.Nombre
                '    .receptorIdentificacionTipo = "01"
                '    .receptorIdentificacionNumero = "000000000"
                'End If
                ''<<---------------------------------------------------------------


                .condicionVenta = GetCondicionVenta(_Encabezado.TipoDoc_Id) 'MIKEVO
                .plazoCredito = GetPlazoCredito(_Encabezado.TipoDoc_Id)
                .codigoMoneda = _Moneda
                .tipoCambio = _TipoCambio
                .comentarioFactura = _Encabezado.Comentario.Trim.Replace("'", "")
                .situacion = GetSituacionDocumentoElectronico()
                .medioPago = GetTipoPagoLista(_Encabezado)

                ' cambio iva
                .detalle = GetDetallesLista(_Encabezado)

                If _Encabezado.TipoDoc_Id = Enum_TipoDocumento.DevolucionContado Or _Encabezado.TipoDoc_Id = Enum_TipoDocumento.DevolucionCredito Then
                    .referencia = GetReferenciaLista(_Encabezado)
                End If

                If (_Encabezado.TipoDoc_Id = Enum_TipoDocumento.Contado Or _Encabezado.TipoDoc_Id = Enum_TipoDocumento.Credito) AndAlso Not _Encabezado.ReferenciaNC Is Nothing Then
                    .referencia = GetReferenciaLista(_Encabezado)
                End If


                If _Encabezado.Cliente.Adjunto_Id = Enum_FeAdjuntos.Pricesmart Then
                    .otros = FeOtrosPricesmart(Enum_FeAdjuntos.Pricesmart)
                End If

                'If _Encabezado.Cliente.Adjunto_Id = Enum_FeAdjuntos.ICE Then

                'End If

            End With

            _Encabezado.Vendedor.ListKey()

            _FeEncabezado.otros.otroTexto.Add(New TFeOtroTexto With {.codigo = "Vendedor", .texto = _Encabezado.VendedorNombre})
            _FeEncabezado.otros.otroTexto.Add(New TFeOtroTexto With {.codigo = "DocumentoSTR", .texto = _Encabezado.GetDocumentoSTR()})
            If _Encabezado.Cliente.CorreoCotizaciones.Trim <> String.Empty Then
                _FeEncabezado.otros.otroTexto.Add(New TFeOtroTexto With {.codigo = "CorreoCotizacion", .texto = _Encabezado.Cliente.CorreoCotizaciones})
            End If
            If _Encabezado.Cliente.Direccion.Trim <> String.Empty Then
                _FeEncabezado.otros.otroTexto.Add(New TFeOtroTexto With {.codigo = "Direccion", .texto = _Encabezado.Cliente.Direccion.Trim().Replace("'", "")})
            End If

            For Each valor As TOtroValor In _Encabezado.OtroValores
                _FeEncabezado.otros.otroTexto.Add(New TFeOtroTexto With {.codigo = valor.Etiqueta, .texto = valor.Valor})
            Next

            documentResponse = DE.Facturar(_FeEncabezado)
            VerificaMensaje(documentResponse.message)

            With FacturaElectonica
                .Emp_Id = _Encabezado.Emp_Id
                .Suc_Id = _Encabezado.Suc_Id
                .Caja_Id = _Encabezado.Caja_Id
                .TipoDoc_Id = _Encabezado.TipoDoc_Id
                .Documento_Id = _Encabezado.Documento_Id
                .Fecha = _Encabezado.Fecha
                .Emisor_Id = _Emisor_Id
                .Doc_Id = documentResponse.doc_Id
                .Consecutivo = documentResponse.consecutivo
                .Clave = documentResponse.clave
                Select Case _Moneda
                    Case coFEMonedaDolar
                        .FisicoIV = _Encabezado.IV / _TipoCambio
                        .FisicoTotal = _Encabezado.Total / _TipoCambio
                    Case Else
                        .FisicoIV = _Encabezado.IV
                        .FisicoTotal = _Encabezado.Total
                End Select
                .ElectronicoIV = documentResponse.totalImpuesto
                .ElectronicoTotal = documentResponse.totalComprobante
                .Leyenda = documentResponse.leyendaResolucion
                .Batch_Id = _Batch_Id
            End With
            VerificaMensaje(FacturaElectonica.GuardaReferencia(pCn))

            Return String.Empty

        Catch ex As Exception
            Return ex.Message
        Finally
            DE = Nothing
            documentResponse = Nothing
        End Try
    End Function

    Public Function Consultar(pEmisor_Id As Integer, pToken As String, pClave As String) As String
        Dim DE As New TDocumentoElectronico
        Dim stateResponse As New StateResponse
        Dim Consulta As New TFeConsultaDocumento
        Try

            With DE
                .CoreURL = _CoreURL
            End With

            With Consulta
                .emisor_Id = pEmisor_Id
                .token = pToken
                .clave = pClave
            End With

            stateResponse = DE.ConsultaDocumento(Consulta)


            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function FeOtrosPricesmart(pAdjunto_Id As Enum_FeAdjuntos) As TFeOtros
        Dim Resultado As New TFeOtros
        Dim otroTexto As New TFeOtroTexto
        Dim FeAdjunto As New TFeAdjuntoEncabezado(EmpresaInfo.Emp_Id)
        Dim OtroContenido As New TFeOtroContenido
        Dim Pricesmart As New TPricesmart
        Dim LugarDeEntrega As New TPricesmartLugarDeEntrega
        Dim OrdenDeCompra As New TPricesmartOrdenDeCompra

        FeAdjunto.Adjunto_Id = pAdjunto_Id
        VerificaMensaje(FeAdjunto.CargaAdjuntos)

        For Each t As DataRow In FeAdjunto.Data.Tables(0).Rows

            If ("NumeroVendedor" = t.Item("Etiqueta")) Then
                Pricesmart.NumeroVendedor = t.Item("Valor")
            End If

            '-----------------------------------------------
            If ("NumeroOrden" = t.Item("Etiqueta")) Then
                OrdenDeCompra.NumeroOrden = t.Item("Valor")
            End If

            If ("FechaOrden" = t.Item("Etiqueta")) Then
                OrdenDeCompra.FechaOrden = t.Item("Valor")
            End If
            '-----------------------------------------------
            '-----------------------------------------------
            If ("GLNLugarDeEntrega" = t.Item("Etiqueta")) Then
                LugarDeEntrega.GLNLugarDeEntrega = t.Item("Valor")
            End If

            If ("DireccionLugarDeEntrega" = t.Item("Etiqueta")) Then
                LugarDeEntrega.DireccionLugarDeEntrega = t.Item("Valor")
            End If
            '-----------------------------------------------


        Next

        Pricesmart.OrdenDeCompra = OrdenDeCompra
        Pricesmart.LugarDeEntrega = LugarDeEntrega

        OtroContenido.contenido = RetornaOtrosPricesmart(Pricesmart)

        Resultado.otroContenido.Add(OtroContenido)

        Return Resultado
    End Function

    'Private Function FeReferenciaICE(pAdjunto_Id As Enum_FeAdjuntos) As TFeReferencia
    '    Dim Resultado As New TFeReferencia
    '    Dim FeAdjunto As New TFeAdjuntoEncabezado(EmpresaInfo.Emp_Id)

    '    FeAdjunto.Adjunto_Id = pAdjunto_Id
    '    VerificaMensaje(FeAdjunto.CargaAdjuntos)

    '    For Each t As DataRow In FeAdjunto.Data.Tables(0).Rows

    '        If ("NumeroVendedor" = t.Item("Etiqueta")) Then
    '            Pricesmart.NumeroVendedor = t.Item("Valor")
    '        End If

    '        '-----------------------------------------------
    '        If ("NumeroOrden" = t.Item("Etiqueta")) Then
    '            OrdenDeCompra.NumeroOrden = t.Item("Valor")
    '        End If

    '        If ("FechaOrden" = t.Item("Etiqueta")) Then
    '            OrdenDeCompra.FechaOrden = t.Item("Valor")
    '        End If
    '        '-----------------------------------------------
    '        '-----------------------------------------------
    '        If ("GLNLugarDeEntrega" = t.Item("Etiqueta")) Then
    '            LugarDeEntrega.GLNLugarDeEntrega = t.Item("Valor")
    '        End If

    '        If ("DireccionLugarDeEntrega" = t.Item("Etiqueta")) Then
    '            LugarDeEntrega.DireccionLugarDeEntrega = t.Item("Valor")
    '        End If
    '        '-----------------------------------------------


    '    Next

    '    Pricesmart.OrdenDeCompra = OrdenDeCompra
    '    Pricesmart.LugarDeEntrega = LugarDeEntrega

    '    OtroContenido.contenido = RetornaOtrosPricesmart(Pricesmart)

    '    Resultado.otroContenido.Add(OtroContenido)

    '    Return Resultado
    'End Function

    Private Function RetornaOtrosPricesmart(ByRef pFacturaElectronica As TPricesmart)
        Dim XmlCreator As New XmlSerializer(pFacturaElectronica.GetType)
        Dim stream As Stream = New MemoryStream()
        Dim xtWriter As XmlTextWriter = New XmlTextWriter(stream, Encoding.UTF8)
        Dim reader As StreamReader = New StreamReader(stream, Encoding.UTF8)
        Dim doc As New XmlDocument
        Dim pXmlStr As String = ""
        Dim TmpXml As String = ""

        Try
            XmlCreator.Serialize(xtWriter, pFacturaElectronica)
            xtWriter.Flush()
            stream.Seek(0, SeekOrigin.Begin)
            pXmlStr = reader.ReadToEnd()


            TmpXml = "<retail:Complemento xmlns:retail=""https://invoicer.ekomercio.com/esquemas"" xsi:schemaLocation=""https://invoicer.ekomercio.com/esquemas https://invoicer.ekomercio.com/esquemas/ComplementoPricesmartCR_V1_0.xsd"""
            pXmlStr = Replace(pXmlStr, "<?xml version=""1.0"" encoding=""utf-8""?>", "")
            pXmlStr = Replace(pXmlStr, "_x003A_", ":")
            'pXmlStr = Replace(pXmlStr, "<FacturaElectronica xmlns=""https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/facturaElectronica"" >", "<FacturaElectronica xmlns=""https: //tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/facturaElectronica"" xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/facturaElectronica https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/facturaElectronica.xsd"">")
            pXmlStr = Replace(pXmlStr, "<retail:Complemento", TmpXml)
            doc.LoadXml(pXmlStr)

            Return pXmlStr
        Catch ex As Exception
            Return ""
        Finally
            XmlCreator = Nothing
            stream = Nothing
            xtWriter = Nothing
            reader = Nothing
            pXmlStr = Nothing
        End Try
    End Function
#End Region
End Class