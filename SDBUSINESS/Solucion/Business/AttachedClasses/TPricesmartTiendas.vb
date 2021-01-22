Public Class TPricesmartTiendas
    Private _Codigo As String
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Sub New(pCodigo As String, pNombre As String)
        Me.Codigo = pCodigo
        Me.Nombre = pNombre
    End Sub
End Class
