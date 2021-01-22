Public Class TBoton
    Inherits System.Windows.Forms.Button
    'Tipo de boton (Categorias, subcategorias, articulos, etc)
    Private _TipoBoton As Integer

    'Indica si el tipo de boton permite seleccionar varios botones al mismo tiempo
    Private _SeleccionMultiple As Boolean
    'Se utiliza en los botones de propiedades para indicar a cual metodo pertenecen
    Private _MetodoPadre As Integer
    Private _ArticuloTipo As Enum_ArticuloTipo

    Private _Precio As Double
    Private _ExentoIV As Boolean

    Private _Orden_Id As Long
    Private _Mesa_Id As Integer
    Private _EsOrdenServicio As Boolean

    Private _ImagenId As Integer

    Private _SeleccionObligatoria As Boolean
    'Private _Negrita As Boolean

    'Public Property Negrita As Boolean
    '    Get
    '        Return _Negrita
    '    End Get
    '    Set(value As Boolean)
    '        _Negrita = value
    '    End Set
    'End Property

    Public Property Imagen() As Integer
        Get
            Return _ImagenId
        End Get
        Set(ByVal value As Integer)
            _ImagenId = value
        End Set
    End Property

    Public Property EsOrdenServicio() As Boolean
        Get
            Return _EsOrdenServicio
        End Get
        Set(ByVal value As Boolean)
            _EsOrdenServicio = value
        End Set
    End Property

    Public Property Mesa_Id() As Integer
        Get
            Return _Mesa_Id
        End Get
        Set(ByVal value As Integer)
            _Mesa_Id = value
        End Set
    End Property

    Public Property Orden_Id() As Long
        Get
            Return _Orden_Id
        End Get
        Set(ByVal value As Long)
            _Orden_Id = value
        End Set
    End Property

    Public Property ExentoIV() As Boolean
        Get
            Return _ExentoIV
        End Get
        Set(ByVal value As Boolean)
            _ExentoIV = value
        End Set
    End Property

    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal value As Double)
            _Precio = value
        End Set
    End Property



    Public Property ArticuloTipo() As Enum_ArticuloTipo
        Get
            Return _ArticuloTipo
        End Get
        Set(ByVal value As Enum_ArticuloTipo)
            _ArticuloTipo = value
        End Set
    End Property


    Public Property TipoBoton() As Integer
        Get
            Return _TipoBoton
        End Get
        Set(ByVal value As Integer)
            _TipoBoton = value
        End Set
    End Property

    Public Property SeleccionMultiple() As Boolean
        Get
            Return _SeleccionMultiple
        End Get
        Set(ByVal value As Boolean)
            _SeleccionMultiple = value
        End Set
    End Property

    Public Property SeleccionObligatoria() As Boolean
        Get
            Return _SeleccionObligatoria
        End Get
        Set(ByVal Value As Boolean)
            _SeleccionObligatoria = Value
        End Set
    End Property


    Public ReadOnly Property ColorSelection() As Drawing.Color
        Get
            Return Drawing.Color.Blue
        End Get
    End Property

    Public ReadOnly Property ColorDefault() As Drawing.Color
        Get
            Return Drawing.SystemColors.ControlText
        End Get
    End Property


    Public Property MetodoPadre() As Integer
        Get
            Return _MetodoPadre
        End Get
        Set(ByVal value As Integer)
            _MetodoPadre = value
        End Set
    End Property

    Public Sub New()
        _EsOrdenServicio = False
    End Sub
End Class
