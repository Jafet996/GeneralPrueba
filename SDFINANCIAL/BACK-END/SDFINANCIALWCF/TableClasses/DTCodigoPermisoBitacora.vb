<DataContract()>
Public Class DTCodigoPermisoBitacora
#Region "Definicion Variables Locales"

    Private _Bitacora_Id As Long
    Private _Emp_Id As Integer
    Private _Usuario_Id As String
    Private _UsuarioUtilizo_Id As String
    Private _Permiso_Id As Integer
    Private _Codigo As String
    Private _Fecha As Datetime

#End Region
#Region "Definicion de propiedades"

    <DataMember()> _
    Public Property Bitacora_Id() As Long
        Get
            Return _Bitacora_Id
        End Get
        Set(ByVal Value As Long)
            _Bitacora_Id = Value
        End Set
    End Property
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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property UsuarioUtilizo_Id() As String
        Get
            Return _UsuarioUtilizo_Id
        End Get
        Set(ByVal Value As String)
            _UsuarioUtilizo_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Permiso_Id() As Integer
        Get
            Return _Permiso_Id
        End Get
        Set(ByVal Value As Integer)
            _Permiso_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal Value As String)
            _Codigo = Value
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

#End Region
#Region "Constructores"
    Public Sub New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Bitacora_Id = 0
        _Emp_Id = 0
        _Usuario_Id = ""
        _UsuarioUtilizo_Id = ""
        _Permiso_Id = 0
        _Codigo = ""
        _Fecha = CDate("1900/01/01")
    End Sub
#End Region
End Class
