<DataContract()>
Public Class DTBcoPago
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _BcoPago_Id As Long
    Private _TipoPago_Id As Integer
    Private _Prov_Id As Integer
    Private _Banco_Id As Integer
    Private _Cuenta As String
    Private _Moneda As Char
    Private _Fecha As Datetime
    Private _Monto As Double
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Usuario_Id As String
    Private _Concepto As String
    Private _Cheque As DTBcoPagoCheque
    Private _Transferencia As DTBcoPagoTransferencia
    Private _ListaSolicitudes As New List(Of DTCxPSolicitudPago)
#End Region
#Region "Definicion de propiedades"
    <DataMember()> _
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property BcoPago_Id() As Long
        Get
            Return _BcoPago_Id
        End Get
        Set(ByVal Value As Long)
            _BcoPago_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property TipoPago_Id() As Integer
        Get
            Return _TipoPago_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoPago_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Banco_Id() As Integer
        Get
            Return _Banco_Id
        End Get
        Set(ByVal Value As Integer)
            _Banco_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Cuenta() As String
        Get
            Return _Cuenta
        End Get
        Set(ByVal Value As String)
            _Cuenta = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
        End Set
    End Property
    <DataMember()> _
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Concepto() As String
        Get
            Return _Concepto
        End Get
        Set(ByVal Value As String)
            _Concepto = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Cheque() As DTBcoPagoCheque
        Get
            Return _Cheque
        End Get
        Set(value As DTBcoPagoCheque)
            _Cheque = value
        End Set
    End Property
    <DataMember()> _
    Public Property Transferencia() As DTBcoPagoTransferencia
        Get
            Return _Transferencia
        End Get
        Set(value As DTBcoPagoTransferencia)
            _Transferencia = value
        End Set
    End Property
    <DataMember()> _
    Public Property ListaSolicitudes As List(Of DTCxPSolicitudPago)
        Get
            Return _ListaSolicitudes
        End Get
        Set(value As List(Of DTCxPSolicitudPago))
            _ListaSolicitudes = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _BcoPago_Id = 0
        _TipoPago_Id = 0
        _Prov_Id = 0
        _Banco_Id = 0
        _Cuenta = ""
        _Moneda = ""
        _Fecha = CDate("1900/01/01")
        _Monto = 0.0
        _TipoCambio = 0.0
        _Dolares = 0.0
        _Usuario_Id = ""
        _Concepto = ""
        _Cheque = New DTBcoPagoCheque
        _Transferencia = New DTBcoPagoTransferencia
        _ListaSolicitudes.Clear()
    End Sub
#End Region
End Class