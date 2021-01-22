Public Class TArticuloCabys
#Region "Definicion Variables Locales"

    Public codigo As String
    Public descripcion As String
    Public categoria_1 As String
    Public descripcionCategoria_1 As String
    Public categoria_2 As String
    Public descripcionCategoria_2 As String
    Public categoria_3 As String
    Public descripcionCategoria_3 As String
    Public categoria_4 As String
    Public descripcionCategoria_4 As String
    Public categoria_5 As String
    Public descripcionCategoria_5 As String
    Public categoria_6 As String
    Public descripcionCategoria_6 As String
    Public categoria_7 As String
    Public descripcionCategoria_7 As String
    Public categoria_8 As String
    Public descripcionCategoria_8 As String
    Public exento As Boolean
    Public tarifa As Double


#End Region

    '#Region "Definicion de propiedades"
    '    Public Property codigo() As String
    '        Get
    '            Return codigo
    '        End Get
    '        Set(ByVal Value As String)
    '            codigo = Value
    '        End Set
    '    End Property

    '    Public Property Descripcion() As String
    '        Get
    '            Return _descripcion
    '        End Get
    '        Set(ByVal Value As String)
    '            _descripcion = Value
    '        End Set
    '    End Property
    '    Public Property categoria_1() As String
    '        Get
    '            Return _categoria_1
    '        End Get
    '        Set(ByVal Value As String)
    '            _categoria_1 = Value
    '        End Set
    '    End Property
    '    Public Property descripcionCategoria_1() As String
    '        Get
    '            Return _descripcionCategoria_1

    '        End Get
    '        Set(ByVal Value As String)
    '            _descripcionCategoria_1 = Value
    '        End Set
    '    End Property
    '    Public Property Categoria2() As String
    '        Get
    '            Return _categoria_2

    '        End Get
    '        Set(ByVal Value As String)
    '            _categoria_2 = Value
    '        End Set
    '    End Property
    '    Public Property descripcionCategoria_2() As String
    '        Get
    '            Return _descripcionCategoria_2

    '        End Get
    '        Set(ByVal Value As String)
    '            _descripcionCategoria_2 = Value
    '        End Set
    '    End Property
    '    Public Property Categoria3() As String
    '        Get
    '            Return _categoria_3

    '        End Get
    '        Set(ByVal Value As String)
    '            _categoria_3 = Value
    '        End Set
    '    End Property
    '    Public Property descripcionCategoria_3() As String
    '        Get
    '            Return _descripcionCategoria_3

    '        End Get
    '        Set(ByVal Value As String)
    '            _descripcionCategoria_3 = Value
    '        End Set
    '    End Property
    '    Public Property Categoria4() As String
    '        Get
    '            Return _categoria_4

    '        End Get
    '        Set(ByVal Value As String)
    '            _categoria_4 = Value
    '        End Set
    '    End Property
    '    Public Property descripcionCategoria_4() As String
    '        Get
    '            Return _descripcionCategoria_4

    '        End Get
    '        Set(ByVal Value As String)
    '            _descripcionCategoria_4 = Value
    '        End Set
    '    End Property
    '    Public Property Categoria5() As String
    '        Get
    '            Return _categoria_5

    '        End Get
    '        Set(ByVal Value As String)
    '            _categoria_5 = Value
    '        End Set
    '    End Property
    '    Public Property descripcionCategoria_5() As String
    '        Get
    '            Return _descripcionCategoria_5

    '        End Get
    '        Set(ByVal Value As String)
    '            _descripcionCategoria_5 = Value
    '        End Set
    '    End Property
    '    Public Property Categoria6() As String
    '        Get
    '            Return _categoria_6

    '        End Get
    '        Set(ByVal Value As String)
    '            _categoria_6 = Value
    '        End Set
    '    End Property
    '    Public Property descripcionCategoria_6() As String
    '        Get
    '            Return _descripcionCategoria_6

    '        End Get
    '        Set(ByVal Value As String)
    '            _descripcionCategoria_6 = Value
    '        End Set
    '    End Property
    '    Public Property Categoria7() As String
    '        Get
    '            Return _categoria_7

    '        End Get
    '        Set(ByVal Value As String)
    '            _categoria_7 = Value
    '        End Set
    '    End Property
    '    Public Property descripcionCategoria_7() As String
    '        Get
    '            Return _descripcionCategoria_7

    '        End Get
    '        Set(ByVal Value As String)
    '            _descripcionCategoria_7 = Value
    '        End Set
    '    End Property
    '    Public Property Categoria8() As String
    '        Get
    '            Return _categoria_8

    '        End Get
    '        Set(ByVal Value As String)
    '            _categoria_8 = Value
    '        End Set
    '    End Property
    '    Public Property descripcionCategoria_8() As String
    '        Get
    '            Return _descripcionCategoria_8

    '        End Get
    '        Set(ByVal Value As String)
    '            _descripcionCategoria_8 = Value
    '        End Set
    '    End Property
    '    Public Property exento() As Boolean
    '        Get
    '            Return _exento


    '        End Get
    '        Set(ByVal Value As Boolean)
    '            _exento = Value
    '        End Set
    '    End Property
    '    Public Property tarifa() As Double

    '        Get
    '            Return _tarifa

    '        End Get
    '        Set(ByVal Value As Double)
    '            _tarifa = Value
    '        End Set
    '    End Property




    '#End Region

#Region "Constructores"
    Public Sub New()
        Inicializa()
    End Sub

#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        codigo = String.Empty
        descripcion = String.Empty
        categoria_1 = String.Empty
        descripcionCategoria_1 = String.Empty
        categoria_2 = String.Empty
        descripcionCategoria_2 = String.Empty
        categoria_3 = String.Empty
        descripcionCategoria_3 = String.Empty
        categoria_4 = String.Empty
        descripcionCategoria_4 = String.Empty
        categoria_5 = String.Empty
        descripcionCategoria_5 = String.Empty
        categoria_6 = String.Empty
        descripcionCategoria_6 = String.Empty
        categoria_7 = String.Empty
        descripcionCategoria_7 = String.Empty
        categoria_8 = String.Empty
        descripcionCategoria_8 = String.Empty
        exento = False
        tarifa = 0
    End Sub
#End Region


End Class
