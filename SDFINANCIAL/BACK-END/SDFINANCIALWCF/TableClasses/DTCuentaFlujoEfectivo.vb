<DataContract()>
Public Class DTCuentaFlujoEfectivo
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Cuenta_Id As String
    Private _Entrada As Integer
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
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
    Public Property Entrada() As Integer
        Get
            Return _Entrada
        End Get
        Set(ByVal Value As Integer)
            _Entrada = Value
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
        _Tipo_Id = 0
        _Cuenta_Id = ""
        _Entrada = 0
    End Sub
#End Region
End Class