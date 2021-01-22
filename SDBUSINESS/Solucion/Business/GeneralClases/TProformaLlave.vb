Public Class TProformaLlave
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Documento_Id As Long
#End Region
#Region "Definicion de propiedades"
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    Public Property Suc_Id() As Integer
        Get
            Return _Suc_Id
        End Get
        Set(ByVal Value As Integer)
            _Suc_Id = Value
        End Set
    End Property
    Public Property Documento_Id() As Long
        Get
            Return _Documento_Id
        End Get
        Set(ByVal Value As Long)
            _Documento_Id = Value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
        Inicializa()
    End Sub

    Public Sub Inicializa()
        _Emp_Id = 0
        _Suc_Id = 0
        _Documento_Id = 0
    End Sub
#End Region

End Class
