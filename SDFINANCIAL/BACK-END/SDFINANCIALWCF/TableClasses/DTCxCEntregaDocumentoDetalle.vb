<DataContract()>
Public Class DTCxCEntregaDocumentoDetalle
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Entrega_Id As Integer
    Private _Doc_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
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
    Public Property Doc_Id() As Integer
        Get
            Return _Doc_Id
        End Get
        Set(ByVal Value As Integer)
            _Doc_Id = Value
        End Set
    End Property
    <DataMember()>
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    <DataMember()>
    Public Property Mov_Id() As Long
        Get
            Return _Mov_Id
        End Get
        Set(ByVal Value As Long)
            _Mov_Id = Value
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
        _Doc_Id = 0
        _Tipo_Id = 0
        _Mov_Id = 0
    End Sub
#End Region
End Class

