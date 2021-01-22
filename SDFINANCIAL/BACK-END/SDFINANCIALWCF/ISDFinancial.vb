Imports Business
<ServiceContract()>
Public Interface ISDFinancial
#Region "A"
    <OperationContract>
    <XmlSerializerFormat()>
    Function AsientoDetalleMant(ByVal pTabla As DTAsientoDetalle, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function AsientoEncabezadoMant(ByVal pTabla As DTAsientoEncabezado, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function AsientoEstadoMant(ByVal pTabla As DTAsientoEstado, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function AsientoOrigenMant(ByVal pTabla As DTAsientoOrigen, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function AsientoTipoMant(ByVal pTabla As DTAsientoTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function AuxAsientoDetalleMant(ByVal pTabla As DTAuxAsientoDetalle, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function AuxAsientoEncabezadoMant(ByVal pTabla As DTAuxAsientoEncabezado, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado
#End Region
#Region "B"
    <OperationContract>
    <XmlSerializerFormat()>
    Function BancoMant(ByVal pTabla As DTBanco, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function BcoPagoMant(ByVal pTabla As DTBcoPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function BcoPagoChequeMant(ByVal pTabla As DTBcoPagoCheque, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function BcoPagoTransferenciaMant(ByVal pTabla As DTBcoPagoTransferencia, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function BcoTipoPagoMant(ByVal pTabla As DTBcoTipoPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado
#End Region
#Region "C"
    <OperationContract>
    <XmlSerializerFormat()>
    Function CajaMant(ByVal pTabla As DTCaja, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CajaCierreDetalleMant(ByVal pTabla As DTCajaCierreDetalle, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CajaCierreEncabezadoMant(ByVal pTabla As DTCajaCierreEncabezado, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CambioMonedaMant(ByVal pTabla As DTCambioMoneda, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CambioMonedaTipoMant(ByVal pTabla As DTCambioMonedaTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CentroCostoMant(ByVal pTabla As DTCentroCosto, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CentroCostoTipoMant(ByVal pTabla As DTCentroCostoTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function ClienteMant(ByVal pTabla As DTCliente, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function ClienteMovimientos(ByVal pTabla As DTCliente, ByVal pDesde As Date, ByVal pHasta As Date) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CodigoPermisoBitacoraMant(ByVal pTabla As DTCodigoPermisoBitacora, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function ConvierteNumeroLetras(ByVal pNumero As Double) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CuentaMant(ByVal pTabla As DTCuenta, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CuentaFlujoEfectivoMant(ByVal pTabla As DTCuentaFlujoEfectivo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CuentaTipoMant(ByVal pTabla As DTCuentaTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CuentaTipoClaseMant(ByVal pTabla As DTCuentaTipoClase, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CuentaTipoFlujoEfectivoMant(ByVal pTabla As DTCuentaTipoFlujoEfectivo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxCMovimientoMant(ByVal pTabla As DTCxCMovimiento, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxCMovimientoMantSD(ByVal pTabla As DTCxCMovimiento, pOperacion As EnumOperacionMant, pCriterio As String, ByVal pFacturaEncabezado As TFacturaEncabezado) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxCMovimientoAplicaMant(ByVal pTabla As DTCxCMovimientoAplica, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxCMovimientoPagoMant(ByVal pTabla As DTCxCMovimientoPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxCMovimientoTipoMant(ByVal pTabla As DTCxCMovimientoTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxPMovimientoMant(ByVal pTabla As DTCxPMovimiento, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxPMovimientoAplicaMant(ByVal pTabla As DTCxPMovimientoAplica, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxPMovimientoPagoMant(ByVal pTabla As DTCxPMovimientoPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxPMovimientoTipoMant(ByVal pTabla As DTCxPMovimientoTipo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxPSolicitudPagoMant(ByVal pTabla As DTCxPSolicitudPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxCEntregaDocumentoEncabezadoMant(ByVal pTabla As DTCxCEntregaDocumentoEncabezado, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function CxCEntregaDocumentoDetalleMant(ByVal pTabla As DTCxCEntregaDocumentoDetalle, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado


#End Region
#Region "D"
#End Region
#Region "E"
    <OperationContract>
    <XmlSerializerFormat()>
    Function EmpresaMant(ByVal pTabla As DTEmpresa, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function EmpresaCuentaMant(ByVal pTabla As DTEmpresaCuenta, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function EmpresaParametroMant(ByVal pTabla As DTEmpresaParametro, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function ExecuteQuery(ByVal pQuery As String, Optional ByVal pCnStr As String = "") As TResultado
#End Region
#Region "F"
    <OperationContract>
    <XmlSerializerFormat()>
    Function FacturaEncabezadoCxCMant(ByVal pTabla As DTFacturaEncabezadoCxC, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado
#End Region
#Region "G"
    <OperationContract>
    <XmlSerializerFormat()>
    Function GrupoMant(ByVal pTabla As DTGrupo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function GrupoMenuMant(ByVal pTabla As DTGrupoMenu, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function GetIp(pIp As String) As TResultado

#End Region
#Region "M"
    <OperationContract>
    <XmlSerializerFormat()>
    Function MaquinaConfiguracionMant(ByVal pTabla As DTMaquinaConfiguracion, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function MenuMant(ByVal pTabla As DTMenu, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function ModuloMant(ByVal pTabla As DTModulo, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado
#End Region
#Region "P"
    <OperationContract>
    <XmlSerializerFormat()>
    Function PermisoMant(ByVal pTabla As DTPermiso, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function PermisoBitacoraMant(ByVal pTabla As DTPermisoBitacora, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function ProveedorMant(ByVal pTabla As DTProveedor, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function ProveedorCuentaMant(ByVal pTabla As DTProveedorCuenta, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado
#End Region
#Region "S"
    <OperationContract>
    <XmlSerializerFormat()>
    Function SelectQuery(ByVal pQuery As String, Optional ByVal pCnStr As String = "") As TResultado
#End Region
#Region "T"
    <OperationContract>
    <XmlSerializerFormat()>
    Function TipoIdentificacionMant(ByVal pTabla As DTTipoIdentificacion, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function TarjetaMant(ByVal pTabla As DTTarjeta, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function TipoCambioMant(ByVal pTabla As DTTipoCambio, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function TipoPagoMant(ByVal pTabla As DTTipoPago, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado
#End Region
#Region "U"
    <OperationContract>
    <XmlSerializerFormat()>
    Function UsuarioMant(ByVal pTabla As DTUsuario, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function UsuarioCodigoPermisoMant(ByVal pTabla As DTUsuarioCodigoPermiso, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado

    <OperationContract>
    <XmlSerializerFormat()>
    Function UsuarioPermisoMant(ByVal pTabla As DTUsuarioPermiso, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado
#End Region
#Region "V"
    <OperationContract>
    <XmlSerializerFormat()>
    Function VerificaCliente(ByVal pEmp_Id As Integer, ByVal pCliente_Id As Integer) As String

    <OperationContract>
    <XmlSerializerFormat()>
    Function VerificaProveedor(ByVal pEmp_Id As Integer, ByVal pProveedor_Id As Integer) As String

    <OperationContract>
    <XmlSerializerFormat()>
    Function VendedorMant(ByVal pTabla As DTVendedor, pOperacion As EnumOperacionMant, pCriterio As String) As TResultado
#End Region
End Interface