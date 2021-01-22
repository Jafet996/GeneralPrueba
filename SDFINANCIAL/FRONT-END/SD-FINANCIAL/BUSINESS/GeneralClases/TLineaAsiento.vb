Public Class TLineaAsiento
#Region "Variables"
    Private _Cuenta As String
    Private _CuentaNombre As String
    Private _CC_Id As Integer
    Private _CCNombre As String
    Private _Moneda As String
    Private _TipoCambio As Double
    Private _Debe As Double
    Private _Haber As Double
    Private _CCTipo_Id As Enum_CentroCostoTipo
    Private _SolicitaCentroCosto As Boolean
    Private _Referencia As String
    Private _Descripcion As String
    Private _Modificando As Boolean
    Private _LineaModificada As Integer
#End Region
#Region "Propiedades"
    Public Property Cuenta As String
        Get
            Return _Cuenta
        End Get
        Set(value As String)
            _Cuenta = value
        End Set
    End Property
    Public Property CuentaNombre As String
        Get
            Return _CuentaNombre
        End Get
        Set(value As String)
            _CuentaNombre = value
        End Set
    End Property
    Public Property CCNombre As String
        Get
            Return _CCNombre
        End Get
        Set(value As String)
            _CCNombre = value
        End Set
    End Property

    Public Property CC_Id As Integer
        Get
            Return _CC_Id
        End Get
        Set(value As Integer)
            _CC_Id = value
        End Set
    End Property
    Public Property Moneda As String
        Get
            Return _Moneda
        End Get
        Set(value As String)
            _Moneda = value
        End Set
    End Property
    Public Property TipoCambio As Double
        Get
            Return _TipoCambio
        End Get
        Set(value As Double)
            _TipoCambio = value
        End Set
    End Property
    Public Property Debe As Double
        Get
            Return _Debe
        End Get
        Set(value As Double)
            _Debe = value
        End Set
    End Property
    Public Property Haber As Double
        Get
            Return _Haber
        End Get
        Set(value As Double)
            _Haber = value
        End Set
    End Property
    Public Property CCTipo_Id As Enum_CentroCostoTipo
        Get
            Return _CCTipo_Id
        End Get
        Set(value As Enum_CentroCostoTipo)
            _CCTipo_Id = value
        End Set
    End Property
    Public Property SolicitaCentroCosto As Boolean
        Get
            Return _SolicitaCentroCosto
        End Get
        Set(value As Boolean)
            _SolicitaCentroCosto = value
        End Set
    End Property
    Public Property Referencia As String
        Get
            Return _Referencia
        End Get
        Set(value As String)
            _Referencia = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property
#End Region
#Region "MetodosPublicos"
    Public Sub Inicializa()
        _Cuenta = String.Empty
        _CuentaNombre = String.Empty
        _CC_Id = -1
        _CCNombre = String.Empty
        _Moneda = String.Empty
        _TipoCambio = 0
        _Debe = 0
        _Haber = 0
        _CCTipo_Id = Enum_CentroCostoTipo.Ninguno
        _SolicitaCentroCosto = False
        _Referencia = String.Empty
        _Descripcion = String.Empty
    End Sub
#End Region
End Class