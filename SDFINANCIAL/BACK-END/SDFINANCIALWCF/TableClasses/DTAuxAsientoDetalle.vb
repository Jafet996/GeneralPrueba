<DataContract()>
Public Class DTAuxAsientoDetalle
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Asiento_Id As Long
    Private _Linea_Id As Integer
    Private _Fecha As Datetime
    Private _Moneda As Char
    Private _CC_Id As Integer
    Private _Cuenta_Id As String
    Private _Tipo As Char
    Private _Monto As Double
    Private _MontoDolares As Double
    Private _TipoCambio As Double
    Private _Referencia As String
    Private _Descripcion As String

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
    Public Property Asiento_Id() As Long
        Get
            Return _Asiento_Id
        End Get
        Set(ByVal Value As Long)
            _Asiento_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Linea_Id() As Integer
        Get
            Return _Linea_Id
        End Get
        Set(ByVal Value As Integer)
            _Linea_Id = Value
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
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CC_Id() As Integer
        Get
            Return _CC_Id
        End Get
        Set(ByVal Value As Integer)
            _CC_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Cuenta_Id() As String
        Get
            Return _Cuenta_Id
        End Get
        Set(ByVal Value As String)
            _Cuenta_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Tipo() As Char
        Get
            Return _Tipo
        End Get
        Set(ByVal Value As Char)
            _Tipo = Value
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
    Public Property MontoDolares() As Double
        Get
            Return _MontoDolares
        End Get
        Set(ByVal Value As Double)
            _MontoDolares = Value
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
    Public Property Referencia() As String
        Get
            Return _Referencia
        End Get
        Set(ByVal Value As String)
            _Referencia = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
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
        _Asiento_Id = 0
        _Linea_Id = 0
        _Fecha = CDate("1900/01/01")
        _Moneda = ""
        _CC_Id = 0
        _Cuenta_Id = ""
        _Tipo = ""
        _Monto = 0.0
        _MontoDolares = 0.0
        _TipoCambio = 0.0
        _Referencia = ""
        _Descripcion = ""
    End Sub
#End Region
End Class