<DataContract()>
Public Class DTModulo
#Region "Definicion Variables Locales"

    Private _Modulo_Id As Integer
    Private _Nombre As String
    Private _Major As Integer
    Private _Menor As Integer
    Private _Bug As Integer
    Private _Build As Integer

#End Region
#Region "Definicion de propiedades"

    <DataMember()> _
    Public Property Modulo_Id() As Integer
        Get
            Return _Modulo_Id
        End Get
        Set(ByVal Value As Integer)
            _Modulo_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Major() As Integer
        Get
            Return _Major
        End Get
        Set(ByVal Value As Integer)
            _Major = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Menor() As Integer
        Get
            Return _Menor
        End Get
        Set(ByVal Value As Integer)
            _Menor = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Bug() As Integer
        Get
            Return _Bug
        End Get
        Set(ByVal Value As Integer)
            _Bug = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Build() As Integer
        Get
            Return _Build
        End Get
        Set(ByVal Value As Integer)
            _Build = Value
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
        _Modulo_Id = 0
        _Nombre = ""
        _Major = 0
        _Menor = 0
        _Bug = 0
        _Build = 0
    End Sub
#End Region
End Class
