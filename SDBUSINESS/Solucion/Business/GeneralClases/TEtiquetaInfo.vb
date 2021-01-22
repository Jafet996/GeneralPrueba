Public Class TEtiquetaInfo
#Region "Variables"
    Private _Descripcion As String
    Private _Precio As String
    Private _LeyendaImpuesto As String
    Private _Codigo As String


#End Region
#Region "Propiedades"
    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property Precio As String
        Get
            Return _Precio
        End Get
        Set(value As String)
            _Precio = value
        End Set
    End Property
    Public Property LeyendaImpuesto As String
        Get
            Return _LeyendaImpuesto
        End Get
        Set(value As String)
            _LeyendaImpuesto = value
        End Set
    End Property
    Public Property Codigo As String
        Get
            Return _Codigo
        End Get
        Set(value As String)
            _Codigo = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        _Descripcion = ""
        _Precio = ""
        _LeyendaImpuesto = ""
        _Codigo = ""
    End Sub
#End Region
End Class
