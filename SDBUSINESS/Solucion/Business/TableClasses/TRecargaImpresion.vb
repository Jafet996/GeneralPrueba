Public Class TRecargaImpresion
#Region "Definicion Variables Locales"
    Private _Operacion As String
    Private _NombreTipoRecarga As String
    Private _NombreEmpresa As String
    Private _Cajero As String
    Private _Numero As String
    Private _Transaccion As String
    Private _Serie As String
    Private _Monto As Double
    Private _Fecha As DateTime
#End Region

#Region "Definicion de propiedades"
    Public Property Operacion As String
        Get
            Return _Operacion
        End Get
        Set(ByVal value As String)
            _Operacion = value
        End Set
    End Property
    Public Property NombreTipoRecarga As String
        Get
            Return _NombreTipoRecarga
        End Get
        Set(ByVal value As String)
            _NombreTipoRecarga = value
        End Set
    End Property

    Public Property NombreEmpresa() As String
        Get
            Return _NombreEmpresa
        End Get
        Set(ByVal Value As String)
            _NombreEmpresa = Value
        End Set
    End Property
    Public Property Cajero() As String
        Get
            Return _Cajero
        End Get
        Set(ByVal Value As String)
            _Cajero = Value
        End Set
    End Property
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal Value As String)
            _Numero = Value
        End Set
    End Property
    Public Property Transaccion() As String
        Get
            Return _Transaccion
        End Get
        Set(ByVal Value As String)
            _Transaccion = Value
        End Set
    End Property
    Public Property Serie() As String
        Get
            Return _Serie
        End Get
        Set(ByVal Value As String)
            _Serie = Value
        End Set
    End Property
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
        End Set
    End Property
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
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
        _Operacion = ""
        _NombreTipoRecarga = ""
        _NombreEmpresa = ""
        _Cajero = ""
        _Numero = ""
        _Transaccion = ""
        _Serie = ""
        _Monto = 0.0
        _Fecha = #1/1/1900#
    End Sub
#End Region
End Class
