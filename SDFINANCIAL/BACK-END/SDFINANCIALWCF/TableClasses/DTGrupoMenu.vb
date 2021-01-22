<DataContract()>
Public Class DTGrupoMenu
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Grupo_Id As Integer
    Private _Modulo_Id As Integer
    Private _Menu_Id As String

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
    Public Property Grupo_Id() As Integer
        Get
            Return _Grupo_Id
        End Get
        Set(ByVal Value As Integer)
            _Grupo_Id = Value
        End Set
    End Property
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

#End Region
#Region "Constructores"
    Public Sub New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Grupo_Id = 0
        _Modulo_Id = 0
        _Menu_Id = ""
    End Sub
#End Region
End Class
