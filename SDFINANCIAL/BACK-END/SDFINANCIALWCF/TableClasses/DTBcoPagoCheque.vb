<DataContract()>
Public Class DTBcoPagoCheque
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _BcoPago_Id As Long
    Private _Nombre As String
    Private _Numero As String
    Private _Fecha As Datetime
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
    Public Property BcoPago_Id() As Long
        Get
            Return _BcoPago_Id
        End Get
        Set(ByVal Value As Long)
            _BcoPago_Id = Value
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
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal Value As String)
            _Numero = Value
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
        _Emp_Id = 0
        _BcoPago_Id = 0
        _Nombre = ""
        _Numero = ""
        _Fecha = CDate("1900/01/01")
    End Sub
#End Region
End Class