<DataContract()>
Public Class DTCxCMovimientoAplica
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Aplica_Id As Integer
    Private _TipoAplica_Id As Integer
    Private _MovAplica_Id As Long
    Private _Fecha As Datetime
    Private _Monto As Double

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
    Public Property Mov_Id() As Long
        Get
            Return _Mov_Id
        End Get
        Set(ByVal Value As Long)
            _Mov_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Aplica_Id() As Integer
        Get
            Return _Aplica_Id
        End Get
        Set(ByVal Value As Integer)
            _Aplica_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property TipoAplica_Id() As Integer
        Get
            Return _TipoAplica_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoAplica_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property MovAplica_Id() As Long
        Get
            Return _MovAplica_Id
        End Get
        Set(ByVal Value As Long)
            _MovAplica_Id = Value
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
    <DataMember()> _
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
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
        _Mov_Id = 0
        _Aplica_Id = 0
        _TipoAplica_Id = 0
        _MovAplica_Id = 0
        _Fecha = CDate("1900/01/01")
        _Monto = 0.0
    End Sub
#End Region
End Class