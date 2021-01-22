<DataContract()>
Public Class DTEmpresaParametro
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _ProcesoAnnio As Integer
    Private _ProcesoMes As Integer
    Private _MesCierreFiscal As Integer
    Private _CuentaResultadoPeriodo As String
    Private _DiasCredito As Integer
    Private _PorcMora As Double
    Private _DiasGraciaMora As Integer
    Private _AplicaMora As Integer
    Private _CuentaIngresoXDiferencial As String
    Private _CuentaGastoXDiferencial As String
    Private _CuentaRedondeo As String
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
    Public Property ProcesoAnnio() As Integer
        Get
            Return _ProcesoAnnio
        End Get
        Set(ByVal Value As Integer)
            _ProcesoAnnio = Value
        End Set
    End Property
    <DataMember()> _
    Public Property ProcesoMes() As Integer
        Get
            Return _ProcesoMes
        End Get
        Set(ByVal Value As Integer)
            _ProcesoMes = Value
        End Set
    End Property
    <DataMember()> _
    Public Property MesCierreFiscal() As Integer
        Get
            Return _MesCierreFiscal
        End Get
        Set(ByVal Value As Integer)
            _MesCierreFiscal = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CuentaResultadoPeriodo() As String
        Get
            Return _CuentaResultadoPeriodo
        End Get
        Set(ByVal Value As String)
            _CuentaResultadoPeriodo = Value
        End Set
    End Property
    <DataMember()> _
    Public Property DiasCredito() As Integer
        Get
            Return _DiasCredito
        End Get
        Set(ByVal Value As Integer)
            _DiasCredito = Value
        End Set
    End Property
    <DataMember()> _
    Public Property PorcMora() As Double
        Get
            Return _PorcMora
        End Get
        Set(ByVal Value As Double)
            _PorcMora = Value
        End Set
    End Property
    <DataMember()> _
    Public Property DiasGraciaMora() As Integer
        Get
            Return _DiasGraciaMora
        End Get
        Set(ByVal Value As Integer)
            _DiasGraciaMora = Value
        End Set
    End Property
    <DataMember()> _
    Public Property AplicaMora() As Integer
        Get
            Return _AplicaMora
        End Get
        Set(ByVal Value As Integer)
            _AplicaMora = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CuentaIngresoXDiferencial() As String
        Get
            Return _CuentaIngresoXDiferencial
        End Get
        Set(ByVal Value As String)
            _CuentaIngresoXDiferencial = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CuentaGastoXDiferencial() As String
        Get
            Return _CuentaGastoXDiferencial
        End Get
        Set(ByVal Value As String)
            _CuentaGastoXDiferencial = Value
        End Set
    End Property
    <DataMember()> _
    Public Property CuentaRedondeo() As String
        Get
            Return _CuentaRedondeo
        End Get
        Set(ByVal Value As String)
            _CuentaRedondeo = Value
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
        _ProcesoAnnio = 0
        _ProcesoMes = 0
        _MesCierreFiscal = 0
        _CuentaResultadoPeriodo = ""
        _DiasCredito = 0
        _PorcMora = 0.0
        _DiasGraciaMora = 0
        _AplicaMora = 0
        _CuentaIngresoXDiferencial = ""
        _CuentaGastoXDiferencial = ""
        _CuentaRedondeo = ""
    End Sub
#End Region
End Class