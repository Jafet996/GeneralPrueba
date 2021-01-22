Public Module Declaraciones
#Region "Regedit"
    Public Const coConexionBD = "ConexionBD"
#End Region
#Region "Constantes"
    Public Const coMonedaColones = "C"
    Public Const coMonedaDolares = "D"
#End Region
#Region "Enum"
    Public Enum Enum_CxCMovimientoTipo
        Factura = 1
        Recibo
        AnulacionRecibo
        NotaDebito
        NotaCredito
        NotaDebitoXIntereses
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
        PendientePago = 1
        PagoProceso = 2
        Procesado = 3
    End Enum
    Public Enum Enum_CxPBitacoraTipo
        Cancelo = 1
        Pago = 2
    End Enum
    Public Enum Enum_BcoTipoPago
        Transferencia = 1
        Cheque = 2
    End Enum
#End Region
End Module