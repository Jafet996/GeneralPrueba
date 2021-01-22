<DataContract()>
Public Class DTCxCEntregaDocumentoEncabezado
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Entrega_Id As Integer
    Private _Vendedor_Id As Integer
    Private _Fecha As DateTime
    Private _Usuario_Id As String
    Private _Activo As Integer
#End Region
#Region "Definicion de propiedades"
    <DataMember()>
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    <DataMember()>
    Public Property Entrega_Id() As Integer
        Get
            Return _Entrega_Id
        End Get
        Set(ByVal Value As Integer)
            _Entrega_Id = Value
        End Set
    End Property
    <DataMember()>
    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal Value As Integer)
            _Vendedor_Id = Value
        End Set
    End Property
    <DataMember()>
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
        End Set
    End Property
    <DataMember()>
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    <DataMember()>
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
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
        _Entrega_Id = 0
        _Vendedor_Id = 0
        _Fecha = CDate("1900/01/01")
        _Usuario_Id = ""
        _Activo = 0
    End Sub
#End Region
End Class


