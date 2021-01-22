<DataContract()>
Public Class DTAsientoEncabezado
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Asiento_Id As Long
    Private _Annio As Integer
    Private _Mes As Integer
    Private _Fecha As DateTime
    Private _Tipo_Id As Integer
    Private _Comentario As String
    Private _Estado_Id As Integer
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Usuario_Id As String
    Private _UsuarioAplica_Id As String
    Private _Origen_Id As Integer
    Private _ListaDetalle As New List(Of DTAsientoDetalle)
    Private _AplicarAsiento As Boolean

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
    Public Property Asiento_Id() As Long
        Get
            Return _Asiento_Id
        End Get
        Set(ByVal Value As Long)
            _Asiento_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Annio() As Integer
        Get
            Return _Annio
        End Get
        Set(ByVal Value As Integer)
            _Annio = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal Value As Integer)
            _Mes = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
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
    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(ByVal Value As String)
            _Comentario = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Estado_Id() As Integer
        Get
            Return _Estado_Id
        End Get
        Set(ByVal Value As Integer)
            _Estado_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Debitos() As Double
        Get
            Return _Debitos
        End Get
        Set(ByVal Value As Double)
            _Debitos = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Creditos() As Double
        Get
            Return _Creditos
        End Get
        Set(ByVal Value As Double)
            _Creditos = Value
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
    Public Property UsuarioAplica_Id() As String
        Get
            Return _UsuarioAplica_Id
        End Get
        Set(ByVal Value As String)
            _UsuarioAplica_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Origen_Id() As Integer
        Get
            Return _Origen_Id
        End Get
        Set(ByVal Value As Integer)
            _Origen_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property ListaDetalle As List(Of DTAsientoDetalle)
        Get
            Return _ListaDetalle
        End Get
        Set(value As List(Of DTAsientoDetalle))
            _ListaDetalle = value
        End Set
    End Property
    <DataMember()> _
    Public Property AplicarAsiento As Boolean
        Get
            Return _AplicarAsiento
        End Get
        Set(value As Boolean)
            _AplicarAsiento = value
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
        _Asiento_Id = 0
        _Annio = 0
        _Mes = 0
        _Fecha = CDate("1900/01/01")
        _Tipo_Id = 0
        _Comentario = ""
        _Estado_Id = 0
        _Debitos = 0.0
        _Creditos = 0.0
        _Usuario_Id = ""
        _UsuarioAplica_Id = ""
        _Origen_Id = 0
        _AplicarAsiento = False
    End Sub
#End Region
End Class