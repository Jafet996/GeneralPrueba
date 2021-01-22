Public Class TInfoGeneral
#Region "Variales"
    Private _CPU As String
    Private _IpAddress As String
    Private _HostName As String
    Private _ComPort As String
    Private _PrintLocation As String
    Private _ParallelPort As String
    Private _URLTipoCambio As String
    Private _ClienteDefault As String
    Private _Interfaz As String
    Private _PreFacturaTipoEntrega As String
    Private _ImprimePrefactura As String
    Private _ConfirmaImpresionFactura As String
    Private _FacturaContadoSolicitaCliente As String
    Private _ImprimeCodigoArticulo As String
    Private _ConfirmaImprimeReciboCxC As String
    Private _ImpresoraEtiquetaCliente As String
    Private _ImprimeInformacionCliente As String

    Private _SMSPortName As String
    Private _SMSBaudRate As Integer
    Private _SMSDataBits As Integer
    Private _SMSReadTimeOut As Integer
    Private _SMSWriteTimeOut As Integer

    Private _SMSNotificacionFacturacion As Integer
    Private _SMSNotificacionPuntos As Integer


#End Region
#Region "Propiedades"
    Public Property CPU As String
        Get
            Return _CPU
        End Get
        Set(value As String)
            _CPU = value
        End Set
    End Property
    Public Property IPAddress As String
        Get
            Return _IpAddress
        End Get
        Set(value As String)
            _IpAddress = value
        End Set
    End Property
    Public Property HostName As String
        Get
            Return _HostName
        End Get
        Set(value As String)
            _HostName = value
        End Set
    End Property
    Public Property ComPort As String
        Get
            Return _ComPort
        End Get
        Set(value As String)
            _ComPort = value
        End Set
    End Property
    Public Property PrintLocation As String
        Get
            Return _PrintLocation
        End Get
        Set(value As String)
            _PrintLocation = value
        End Set
    End Property
    Public Property ParallelPort As String
        Get
            Return _ParallelPort
        End Get
        Set(value As String)
            _ParallelPort = value
        End Set
    End Property
    Public Property URLTipoCambio As String
        Get
            Return _URLTipoCambio
        End Get
        Set(value As String)
            _URLTipoCambio = value
        End Set
    End Property
    Public Property ClienteDefault As String
        Get
            Return _ClienteDefault
        End Get
        Set(value As String)
            _ClienteDefault = value
        End Set
    End Property
    Public Property Interfaz As String
        Get
            Return _Interfaz
        End Get
        Set(value As String)
            _Interfaz = value
        End Set
    End Property
    Public Property PreFacturaTipoEntrega As String
        Get
            Return _PreFacturaTipoEntrega
        End Get
        Set(value As String)
            _PreFacturaTipoEntrega = value
        End Set
    End Property
    Public Property ImprimePrefactura As String
        Get
            Return _ImprimePrefactura
        End Get
        Set(value As String)
            _ImprimePrefactura = value
        End Set
    End Property
    Public Property ConfirmaImpresionFactura As String
        Get
            Return _ConfirmaImpresionFactura
        End Get
        Set(value As String)
            _ConfirmaImpresionFactura = value
        End Set
    End Property
    Public Property SMSPortName As String
        Get
            Return _SMSPortName
        End Get
        Set(value As String)
            _SMSPortName = value
        End Set
    End Property
    Public Property SMSBaudRate As Integer
        Get
            Return _SMSBaudRate
        End Get
        Set(value As Integer)
            _SMSBaudRate = value
        End Set
    End Property
    Public Property SMSDataBits As Integer
        Get
            Return _SMSDataBits
        End Get
        Set(value As Integer)
            _SMSDataBits = value
        End Set
    End Property
    Public Property SMSReadTimeOut As Integer
        Get
            Return _SMSReadTimeOut
        End Get
        Set(value As Integer)
            _SMSReadTimeOut = value
        End Set
    End Property
    Public Property SMSWriteTimeOut As Integer
        Get
            Return _SMSWriteTimeOut
        End Get
        Set(value As Integer)
            _SMSWriteTimeOut = value
        End Set
    End Property
    Public Property FacturaContadoSolicitaCliente As String
        Get
            Return _FacturaContadoSolicitaCliente
        End Get
        Set(value As String)
            _FacturaContadoSolicitaCliente = value
        End Set
    End Property
    Public Property ImprimeCodigoArticulo As String
        Get
            Return _ImprimeCodigoArticulo
        End Get
        Set(value As String)
            _ImprimeCodigoArticulo = value
        End Set
    End Property
    Public Property ConfirmaImprimeReciboCxC As String
        Get
            Return _ConfirmaImprimeReciboCxC
        End Get
        Set(value As String)
            _ConfirmaImprimeReciboCxC = value
        End Set
    End Property
    Public Property SMSNotificacionFacturacion As Integer
        Get
            Return _SMSNotificacionFacturacion
        End Get
        Set(value As Integer)
            _SMSNotificacionFacturacion = value
        End Set
    End Property

    Public Property SMSNotificacionPuntos As Integer
        Get
            Return _SMSNotificacionPuntos
        End Get
        Set(value As Integer)
            _SMSNotificacionPuntos = value
        End Set
    End Property

    Public Property ImpresoraEtiquetaCliente As String
        Get
            Return _ImpresoraEtiquetaCliente
        End Get
        Set(value As String)
            _ImpresoraEtiquetaCliente = value
        End Set
    End Property

    Public Property ImprimeInformacionCliente As String
        Get
            Return _ImprimeInformacionCliente
        End Get
        Set(value As String)
            _ImprimeInformacionCliente = value
        End Set
    End Property



#End Region
#Region "Constructores"
    Public Sub New()
        _CPU = ""
        _IpAddress = ""
        _HostName = ""
        _ComPort = ""
        _PrintLocation = ""
        _ParallelPort = ""
        _URLTipoCambio = ""
        _ClienteDefault = ""
        _Interfaz = ""
        _PreFacturaTipoEntrega = ""
        _ImprimePrefactura = ""
        _ConfirmaImpresionFactura = ""
        _FacturaContadoSolicitaCliente = ""
        _ImprimeCodigoArticulo = ""
        _ConfirmaImprimeReciboCxC = ""
        _ImpresoraEtiquetaCliente = ""
        _ImprimeInformacionCliente = ""

        _SMSPortName = ""
        _SMSBaudRate = 0
        _SMSDataBits = 0
        _SMSReadTimeOut = 0
        _SMSWriteTimeOut = 0
        _SMSNotificacionFacturacion = 0
        _SMSNotificacionPuntos = 0
    End Sub
#End Region
End Class