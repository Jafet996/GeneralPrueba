<DataContract()>
Public Class DTMenu
#Region "Definicion Variables Locales"

    Private _Modulo_Id As Integer
    Private _Menu_Id As String
    Private _MenuPadre_Id As String
    Private _Nombre As String
    Private _Orden As Integer

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
    Public Property Menu_Id() As String
        Get
            Return _Menu_Id
        End Get
        Set(ByVal Value As String)
            _Menu_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property MenuPadre_Id() As String
        Get
            Return _MenuPadre_Id
        End Get
        Set(ByVal Value As String)
            _MenuPadre_Id = Value
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
    Public Property Orden() As Integer
        Get
            Return _Orden
        End Get
        Set(ByVal Value As Integer)
            _Orden = Value
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
        _Menu_Id = ""
        _MenuPadre_Id = ""
        _Nombre = ""
        _Orden = 0
    End Sub
#End Region
End Class
