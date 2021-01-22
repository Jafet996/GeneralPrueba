Public Class TArticuloConteo
    Private _Art_Id As String
    Private _Cantidad As Double
    Private _Descripcion As String
    Private _Costo As Double
    Private _Exento As Boolean
    Private _Descuento As Double

    Public Property Art_Id As String
        Get
            Return _Art_Id
        End Get
        Set(value As String)
            _Art_Id = value
        End Set
    End Property

    Public Property Cantidad As Double
        Get
            Return _Cantidad
        End Get
        Set(value As Double)
            _Cantidad = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Costo() As Double
        Get
            Return _Costo
        End Get
        Set(ByVal value As Double)
            _Costo = value
        End Set
    End Property
    Public Property Exento As Boolean
        Get
            Return _Exento
        End Get
        Set(value As Boolean)
            _Exento = value
        End Set
    End Property
    Public Property Descuento As Double
        Get
            Return _Descuento
        End Get
        Set(value As Double)
            _Descuento = value
        End Set
    End Property

    Public Sub New()
        _Art_Id = String.Empty
        _Cantidad = 0
        _Descripcion = String.Empty
        _Costo = 0
        _Exento = 0
        _Descuento = 0
    End Sub
End Class
