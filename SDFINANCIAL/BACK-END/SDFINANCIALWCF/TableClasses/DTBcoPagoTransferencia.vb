<DataContract()>
Public Class DTBcoPagoTransferencia
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _BcoPago_Id As Long
    Private _Banco_Id As Integer
    Private _Cuenta As String
    Private _Moneda As Char
    Private _Fecha As Datetime
    Private _TipoCambio As Double
    Private _Numero As String
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
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal Value As String)
            _Numero = Value
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
        _Banco_Id = 0
        _Cuenta = ""
        _Moneda = ""
        _Fecha = CDate("1900/01/01")
        _TipoCambio = 0.0
        _Numero = ""
    End Sub
#End Region
End Class