<DataContract()>
Public Class DTCxCMovimientoLinea
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
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
    Public Property Monto As Double
        Get
            Return _Monto
        End Get
        Set(value As Double)
            _Monto = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        MyBase.New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Tipo_Id = 0
        _Mov_Id = 0
        _Monto = 0.0
    End Sub
#End Region
End Class
