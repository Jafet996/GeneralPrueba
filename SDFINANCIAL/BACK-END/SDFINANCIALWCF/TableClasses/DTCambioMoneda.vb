<DataContract()>
Public Class DTCambioMoneda
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Cambio_Id As Integer
    Private _Tipo_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Efectivo As Double
    Private _Dolares As Double
    Private _TipoCambio As Double
    Private _Fecha As Datetime
    Private _Usuario_Id As String

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
    Public Property Cambio_Id() As Integer
        Get
            Return _Cambio_Id
        End Get
        Set(ByVal Value As Integer)
            _Cambio_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Cierre_Id() As Integer
        Get
            Return _Cierre_Id
        End Get
        Set(ByVal Value As Integer)
            _Cierre_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Efectivo() As Double
        Get
            Return _Efectivo
        End Get
        Set(ByVal Value As Double)
            _Efectivo = Value
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
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
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
        _Cambio_Id = 0
        _Tipo_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _Efectivo = 0.0
        _Dolares = 0.0
        _TipoCambio = 0.0
        _Fecha = CDate("1900/01/01")
        _Usuario_Id = ""
    End Sub
#End Region
End Class
