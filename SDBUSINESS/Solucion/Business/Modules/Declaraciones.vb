Imports EAGetMail
Public Module Declaraciones
#Region "Variable Emails"
    Public Emails As New List(Of Mail)
#End Region
#Region "Constantes Generales"
    Public Const coClienteGeneral = 1
    Public Const coCajaApertura = "Abrir"
    Public Const coCajaCierre = "Cerrar"
    Public Const coNC_Contingencia = "08"
    Public Const coNC_Otros = "99"
    Public Const coActualizador = "C:\Program Files\SOFTDESIGN\Actualizador SD\Actualizador SD Business.exe"
    Public Const coFEMonedaDolar = "USD"
    Public Const coFEMonedaColon = "CRC"
    Public Const coSpEnvioEmail = "[FE-NOTIFICATION]..NotificacionEnvioFactura"
    Public Const coImpuestoAlValorAgregado = "01"
    Public Const coImpuestoIVACalculoEspecial = "07"
    Public Const coImpuestoIVABienesUsados = "08"
    Public Const coFeErrorYaSeRecibio = "ya fue recibido anteriormente"
    Public Const coCodRefAnulaDocumento = "01"
    Public Const coCodRefOtros = "99"
    Public Const coFEFacturaElectronica = "FacturaElectronica"
    Public Const coFETiqueteElectronico = "TiqueteElectronico"
    Public Const coFENotaCreditoElectronica = "NotaCreditoElectronica"
    Public Const coFENotaDebitoElectronica = "NotaDebitoElectronica"
    Public Const coFEMensajeHacienda = "MensajeHacienda"
    Public Const coServerCorreoOutlook = 1
    Public Const coServerCorreoHotmail = 2
    Public Const coServerCorreoGmail = 3
    Public Const coServerCorreoIMAP = 4
    Public coColorEscaneoIgual As Drawing.Color = Drawing.Color.Black
    Public coColorEscaneoMenor As Drawing.Color = Drawing.Color.Red
    Public coColorEscaneoMayor As Drawing.Color = Drawing.Color.DarkGreen
#End Region
#Region "Codigos Impuesto"
    Public Const coImpuesto01 = "01"
    Public Const coImpuesto12 = "12"
#End Region
#Region "Prefijos de botones"
    'Prefijos para los nombres de los botones en la toma de orden
    Public Const coNombreCategoriaPrefijo = "Categoria"
    Public Const coNombreSubCategoriaPrefijo = "SubCategoria"
    Public Const coNombreArticuloPrefijo = "Articulo"
    Public Const coNombreFrecuentePrefijo = "Frecuente"

    'Tipos de botones de toma de orden
    Public Const coTipoBotonCategoria = 0
    Public Const coTipoBotonSubCategoria = 1
    Public Const coTipoBotonArticulo = 2
    Public Const coTipoBotonFrecuente = 14
#End Region
#Region "Valores del Registro"
    Public Const coRegRegionKey = "Software"
    Public Const coRegCompanyNameKey = "SOFTDESIGN"
    Public Const coRegProductNameKey = "SD-GENERAL"
    Public Const coRegRegion64Key = "Software\Wow6432Node\"

    Public Const coRegContaServer = "ContaServer"
    Public Const coRegContaDataBase = "ContaDataBase"
    Public Const coRegContaUser = "ContaUser"
    Public Const coRegContaPassword = "ContaPassword"
    Public Const coRegEmp_Id = "Emp_Id"
    Public Const coRegSuc_Id = "Suc_Id"
    Public Const coRegCaja_Id = "Caja_Id"
    Public Const coRegComPort = "ComPort"
    Public Const coRegPrintLocation = "PrintLocation"
    Public Const coRegParallelPort = "ParallelPort"
    Public Const coRegCodigoDetallista = "CodigoDetallista"
    Public Const coRegURLTipoCambio = "URLTipoCambio"
    Public Const coRegClienteDefault = "ClienteDefault"
    Public Const coRegPrinterName = "PrinterName"
    Public Const coRegInterfaz = "Interfaz"
    Public Const coRegPreFacturaTipoEntrega = "PreFacturaTipoEntrega"
    Public Const coRegImprimePrefactura = "ImprimePrefactura"
    Public Const coRegConfirmaImpresionFactura = "ConfirmaImpresionFactura"
    Public Const coRegFacturaContadoSolicitaCliente = "FacturaContadoSolicitaCliente"
    Public Const coRegImprimeCodigoArticulo = "ImprimeCodigoArticulo"
    Public Const coRegConfirmaImprimeReciboCxC = "ConfirmaImprimeReciboCxC"
    'Public Const coRegURLContabilidad = "URLContabilidad"

    Public Const coRegSMSPortName = "SMSPortName"
    Public Const coRegSMSBaudRate = "SMSBaudRate"
    Public Const coRegSMSDataBits = "SMSDataBits"
    Public Const coRegSMSReadTimeOut = "SMSReadTimeOut"
    Public Const coRegSMSWriteTimeOut = "SMSWriteTimeOut"

    Public Const coRegSMSNotificacionFacturacion = "SMSNotificacionFacturacion"
    Public Const coRegSMSNotificacionPuntos = "SMSNotificacionPuntos"
    Public Const coRegImpresoraEtiquetaCliente = "ImpresoraEtiquetaCliente"
    Public Const coRegImprimeInformacionCliente = "ImprimeInformacionCliente"

#End Region
#Region "Tipos de Documento Facturacion"
    Public Enum Enum_TipoFacturacion
        Factura = 1
        Proforma = 2
        PreFactura = 3
        Apartado = 4
        ApartadoRetirado = 5
    End Enum
    Public Enum Enum_TipoDocumento
        Contado = 1
        Credito = 2
        DevolucionContado = 3
        DevolucionCredito = 4
    End Enum
    Public Enum Enum_TipoPago
        Efectivo = 1
        Tarjeta = 2
        Cheque
        Puntos
        Dolares
    End Enum
    Public Enum Enum_TipoImpresion
        Directa = 0
        VistaPrevia = 1
    End Enum
    Public Enum Enum_ClientPrecio
        Detalle = 1
        Mayoreo = 2
        Precio3 = 3
        Precio4 = 4
        Precio5 = 5
    End Enum
    Public Enum Enum_TipoIdentificacion
        Fisica = 1
        Juridica = 2
        DIMEX = 3
        NITE = 4
        Extranjero = 999
    End Enum

#End Region
#Region "Tipos Publicos"
    Public EmpresaInfo As New TEmpresa(0)
    Public SucursalInfo As New TSucursal(0)
    Public UsuarioInfo As New TUsuario(0)
    Public CajaInfo As New TCaja(0)
    Public EmpresaParametroInfo As New TEmpresaParametro(0)
    Public SucursalParametroInfo As New TSucursalParametro(0)
    Public InfoMaquina As New TMaquinaConfiguracion
#End Region
#Region "Enums"

    Public Enum Enum_TipoProducto
        Producto = 0
        Servicio = 1
    End Enum

    Public Enum Enum_TipoDevolucion
        Original = 1
        Efectivo = 2
        Tarjeta = 3
        Transferencia = 4
    End Enum

    Public Enum Enum_InterfazFacturacion
        Standard = 1
        Reducida = 2
        CantidadAntes = 3
    End Enum
    Public Enum Enum_EstadoDocumentoElectronico
        Pendiente = 1
        Aceptado = 2
        Rechazado = 3
        Invalido = 4
    End Enum

    Public Enum Modulos
        PuntoVenta = 1
        Inventario = 2
        Compras = 3
        TomaFisica = 4
    End Enum
    Public Enum Enum_ErrorVersiones
        ErrorActive = 6
        ErrorMajor = 5
        ErrorMenor = 4
        ErrorBug = 3
        ErrorBuild = 2
        Warning = 1
        Success = 0
    End Enum
    Public Enum OrdenCompraEstadoEnum
        Pendiente = 1
        Aplicada = 2
        Cerrada = 3
    End Enum
    Public Enum EntradaEstadoEnum
        Pendiente = 1
        Aplicado = 2
    End Enum
    Public Enum EtiquetasEnum
        DosColumna_CincoxDosPuntoDos = 1 '5x2.2 cm x 2 filas
        UnaColumna_NuevexDosPuntoCinco = 2 '9.01 x 2.54 cm x 1 Columna
        CincoColumna_CincoxDosPuntoDos = 3 '5x2.2 cm x 5 filas
    End Enum
    Public Enum ClientePrecioEnum
        Detalle = 1
        Mayoreo = 2
    End Enum
    Public Enum Enum_TipoEntrega
        Tienda = 1
        Mensajero = 2
        Encomienda = 3
    End Enum
    Public Enum Enum_AsientoTipo
        Recibo = 1
        CierreCaja = 2
    End Enum
    Public Enum Enum_AsientoOrigen
        Digitado = 1
        PuntoVenta = 2
        Automatico = 3
        POS_General = 4
    End Enum
    Public Enum Enum_ImagenCatalogo
        CuentaPadre = 0
        CuentaMovimiento = 1
    End Enum
    Public Enum Enum_CuentaTipo
        Activos = 1
        Pasivos = 2
        Patrimonio = 3
        Ingresos = 4
        Gastos = 5
        OrdenDeudora = 6
        OrdenAcreedora = 7
        Costos = 8
    End Enum
    Public Enum Enum_CxCMovimientoTipo
        Factura = 1
        Recibo
        AnulacionRecibo
        NotaDebito
        NotaCredito
        NotaDebitoXIntereses
    End Enum
    Public Enum Enum_SituacionDocumentoElectronico
        Normal = 1
        Contingencia = 2
        SinInternet = 3
    End Enum
    Public Enum Enum_FacturaImprime
        Siempre = 1
        Nunca = 2
    End Enum

    Public Enum Enum_CxCAbonoTipo
        Abono = 1
        AbonoAnulacion = 2
    End Enum

    Public Enum Enum_FeAdjuntos
        Ninguna = 1
        Pricesmart = 2
        ICE = 3
    End Enum

    Public Enum Enum_ApartadoEstado
        Pendiente = 1
        Retirado = 2
        Vencido = 3
        Abandonado = 4
    End Enum

    Public Enum Enum_Art_Id_Tipo
        Errores = -1
        NoExiste = 0
        Interno = 1
        Equivalente = 2
        EquivalenteProveedor = 3
    End Enum
#End Region
#Region "Enum de Permisos"
    Public Enum Permisos
        InvGuardaArticuloBodega = 0             'Inventario
        InvAplicaAjusteInventario = 1           'Inventario
        InvAplicaAjusteCosto = 2                'Inventario
        PvFacturaCredito = 3                    'Punto Venta
        PvDevolucionContado = 4                 'Punto Venta
        PvDevolucionCredito = 5                 'Punto Venta
        PvModificaLineaFactura = 6              'Punto Venta
        PvEliminaLineaFactura = 7               'Punto Venta
        PvCobroServicios = 8                    'Punto Venta
        PvDescuentoFacturaGlobal = 9            'Punto Venta
        PvDescuentoFacturaLinea = 10            'Punto Venta
        PvFacturaSobreLimiteCredito = 11        'Punto Venta
        PVIngresaPantallaCXC = 12               'Punto Venta
        PVDisminuyeCantidadLineaFactura = 13    'Punto Venta
        PVCancelaFactura = 14                   'Punto Venta
        PVCreaMovimientoCreditoCxC = 15         'Punto Venta ' Depositos o Notas Credito
        PVCrearFacturaDolares = 16              'Punto Venta
        PVModificaPrecioFactura = 17            'Punto Venta
        PVModificaClienteFacturacion = 18       'Punto Venta
        PVFacturaSinSaldo = 19                  'Punto Venta
        InvAplicaTrasladoInventario = 20        'Inventario
        InvPonerSaldosEnCero = 21               'Inventario
        InvIniciaTomaFisica = 22                'Inventario
        InvCancelarTomaFisica = 23              'Inventario
        invAplicaTomaFisica = 24                'Inventario
        PVDescuentoPorTipoPago = 25             'Punto Venta   
        PvAbreCajon = 26                        'Punto Venta 
        InvModificaReceta = 27                  'Inventario
        InvAplicaAjusteProduccion = 28          'Inventario
        InvMantenimientodeArticulos = 29        'Inventario
        PVEliminaPrefactura = 30                'Punto Venta 
        InvRebajoVentasAutomatico = 31          'Inventario
        PVApartaBajoPrima = 32                  'Punto Venta
        ComAplicaEntradaMercaderia = 33         'Compras
        OtorgaCredito = 34                      'Punto Venta
        PVFacturarMoroso = 35                   'Punto Venta
        InvAccesoCosto = 36                     'Inventario
        InvAccesoPrecio = 37                    'Inventario
        ComAnulaEntradaMercaderia = 38          'Compras
        PVPermiteFacturacionBajoCosto = 39      'Punto Venta
        PVAbandonaApartado = 40                 'Punto Venta
        ComMantenimientodeArticulos = 41        'Compras
        PVMantenimientodeArticulos = 42         'PuntoVenta
    End Enum
#End Region
#Region "Constantes de SD-Contabilidad"
    Public Const coMonedaColones = "C"
    Public Const coMonedaDolares = "D"
    Public Const coAsientoTipoDebe = "D"
    Public Const coAsientoTipoHaber = "H"
    Public Const coUsuarioGeneral = "admin"
    Public Enum EnumCxPEstado
        Pendiente = 1
        PagoProcesado = 2
        Procesado = 3
    End Enum
    Public Enum EnumCxPTipo
        Factura = 1
        Pago = 2
        Anulacion = 3
        NotaDebito = 4
        NotaCredito = 5
        Intereses = 6
    End Enum
#End Region
#Region "Contantes Archivo Actualizacion Articulos"
    Public Const coSeparaColumna = "|"
    Public Const coCategoria = "[CATEGORIA]"
    Public Const coSubCategoria = "[SUBCATEGORIA]"
    Public Const coDepartamento = "[DEPARTAMENTO]"
    Public Const coTipoAcumulacion = "[TIPOACUMULACION]"
    Public Const coUnidadMedida = "[UNIDADMEDIDA]"
    Public Const coArticulo = "[ARTICULO]"
    Public Const coArticuloBodega = "[ARTICULOBODEGA]"
#End Region
#Region "Documentos Electronicos"
    Public Const coFacturaElectronica = "01"
    Public Const coNotaDebitoElectronica = "02"
    Public Const coNotaCreditoElectronica = "03"
    Public Const coTiqueteElectronico = "04"
    Public Const coNotaCreditoElectronicaTitulo = "Nota de Crédito Electrónica"
#End Region
End Module