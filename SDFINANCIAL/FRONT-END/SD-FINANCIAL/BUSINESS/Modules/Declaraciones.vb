Public Module Declaraciones
#Region "Valores del Registro"
    Public Const coRegRegionKey = "Software"
    Public Const coRegCompanyNameKey = "SOFTDESIGN"
    Public Const coRegProductNameKey = "SD-FINANCIAL"
    Public Const coRegRegion64Key = "Software\Wow6432Node\"
    Public Const coRegMaquinaId = "MaquinaId"
    Public Const coIdentificacion_Id = "Identificacion_Id"

    Public Const coRegUrl = "Url"
    Public Const coRegServer = "Server"
    Public Const coRegDataBase = "DataBase"
    Public Const coRegUser = "User"
    Public Const coRegPassword = "Password"
    Public Const coRegEmp_Id = "Emp_Id"
    Public Const coRegCaja_Id = "Caja_Id"
    Public Const coRegComPort = "ComPort"
    Public Const coRegPrintLocation = "PrintLocation"
    Public Const coRegIdenficador_Id = "Identificador_Id"
    Public Const coRegParallelPort = "ParallelPort"
    Public Const coRegURLTipoCambio = "URLTipoCambio"
    Public Const coRegClienteDefault = "ClienteDefault"
    Public Const coRegPrinterName = "PrinterName"
    Public Const coRegInterfaz = "Interfaz"
    Public Const coRegPreFacturaTipoEntrega = "PreFacturaTipoEntrega"
    Public Const coRegImprimeCodigoArticulo = "ImprimeCodigoArticulo"
    Public Const coRegImprimePrefactura = "ImprimePrefactura"
    Public Const coRegConfirmaImpresionFactura = "ConfirmaImpresionFactura"
    Public Const coRegFacturaContadoSolicitaCliente = "FacturaContadoSolicitaCliente"
#End Region
#Region "Tipos Publicos"
    Public InfoMaquina As New TMaquinaConfiguracion
    Public EmpresaInfo As New TEmpresa
    Public UsuarioInfo As New TUsuario
    Public EmpresaParametroInfo As New TEmpresaParametro
    Public CajaInfo As New TCaja
#End Region
#Region "Constantes"
    Public Const coMonedaColones = "C"
    Public Const coMonedaDolares = "D"
    Public Const coDebe = "D"
    Public Const coHaber = "H"
    Public Const coTipoCambioCompra = "C"
    Public Const coTipoCambioVenta = "V"
    Public Const coUsuarioGeneral = "admin"
#End Region
#Region "Enums"

    Public Enum Enum_Modulos
        CONTABILIDAD = 1
        CXC = 2
        CXP = 3
        BANCOS = 4
    End Enum
    Public Enum Enum_ErrorVersiones
        ErrorLicense = 7
        ErrorActive = 6
        ErrorMajor = 5
        ErrorMenor = 4
        ErrorBug = 3
        ErrorBuild = 2
        Warning = 1
        Success = 0
    End Enum
    Public Enum Enum_MesAnnio
        ENERO = 1
        FEBRERO
        MARZO
        ABRIL
        MAYO
        JUNIO
        JULIO
        AGOSTO
        SETIEMBRE
        OCTUBRE
        NOVIEMBRE
        DICIEMBRE
    End Enum
    Public Enum Enum_ImagenCatalogo
        CuentaPadre = 0
        CuentaMovimiento = 1
    End Enum
    Public Enum Enum_AsientoEstado
        Digitado = 1
        Aplicado = 2
    End Enum
    Public Enum Enum_CentroCostoTipo
        Costo = 1
        Utilidad
        Ninguno
    End Enum
    Public Enum Enum_AsientoOrigen
        Contabilidad = 1
        PuntoVenta = 2
        Automatico = 3
        PosGeneral = 4
        Compras = 5
        CXP = 6
        BANCOS = 7
        CXC = 8
    End Enum
    Public Enum Enum_AsientoTipo
        Recibo = 1
        CierreCaja = 2
        CierrePeriodo = 3
        EntradaMercaderia = 4
        PagoFactura = 5
        CxP = 6
        CxC = 7
    End Enum
    Public Enum Enum_CxCMovimientoTipo
        Factura = 1
        Recibo
        AnulacionRecibo
        NotaDebito
        NotaCredito
        NotaDebitoXIntereses
        PagoExterno
    End Enum
    Public Enum Enum_CxPMovimientoTipo
        Factura = 1
        Pago
        AnulacionRecibo
        NotaDebito
        NotaCredito
        NotaDebitoXIntereses
    End Enum
    Public Enum Enum_CxPMovimientoEstado
        Pendiente = 1
        EnProceso = 2
        Procesado = 3
    End Enum
    Public Enum Enum_TipoPago
        Efectivo = 1
        Tarjeta
        Cheque
        Dolares
        Transferencia
        Deposito
    End Enum
    Public Enum Enum_TipoTransaccion
        Fisica = 1
        Electronica = 2
    End Enum
    Public Enum Enum_CambioMonedaTipo
        Compra = 1
        Venta = 2
    End Enum
    Public Enum Enum_BcoTipoPago
        Transferencia = 1
        Cheque = 2
    End Enum
    Public Enum Enum_FormatDate
        Largo = 1
        Corto = 2
    End Enum
#End Region
#Region "Enum de Permisos"
    Public Enum Permisos
        CoAplicarAsiento = 1          'CONTABILIDAD
        CoReversaAsiento = 2          'CONTABILIDAD
        CoGuardarAsiento = 3          'CONTABILIDAD
        CoEliminaLineaAsiento = 4     'CONTABILIDAD
        CoModificaLineaAsiento = 5    'CONTABILIDAD
        CoConsultarDetalleAsiento = 6 'CONTABILIDAD
        CoAplicaCierreMes = 7         'CONTABILIDAD
        CoAplicaCierrePeriodo = 8     'CONTABILIDAD
    End Enum
#End Region
End Module