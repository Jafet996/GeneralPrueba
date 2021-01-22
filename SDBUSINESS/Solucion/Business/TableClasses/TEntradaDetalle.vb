Public Class TEntradaDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Entrada_Id As Integer
    Private _Detalle_Id As Integer
    Private _Bod_Id As Integer
    Private _Art_Id As String
    Private _Cantidad As Double
    Private _CantidadBonificada As Double
    Private _Costo As Double
    Private _PorcDescuento As Double
    Private _MontoDescuento As Double
    Private _MontoIV As Double
    Private _TotalLinea As Double
    Private _TotalLineaBonificada As Double
    Private _ExentoIV As Integer
    Private _Fecha As Datetime
    Private _UltimaModificacion As DateTime
    Private _Margen As Double
    Private _Precio As Double
    Private _CantidadEscaneada As Double
    Private _Lotes As List(Of TEntradaDetalleLote)
    Private _Lote As Integer
    Private _Data As DataSet
    'Private _DataImpuestos As DataSet
    Private _EntradaDetalleImpuesto As New List(Of TEntradaDetalleImpuesto)

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
    Public Property Entrada_Id() As Integer
        Get
            Return _Entrada_Id
        End Get
        Set(ByVal Value As Integer)
            _Entrada_Id = Value
        End Set
    End Property
    Public Property Detalle_Id() As Integer
        Get
            Return _Detalle_Id
        End Get
        Set(ByVal Value As Integer)
            _Detalle_Id = Value
        End Set
    End Property
    Public Property Bod_Id() As Integer
        Get
            Return _Bod_Id
        End Get
        Set(ByVal Value As Integer)
            _Bod_Id = Value
        End Set
    End Property
    Public Property Art_Id() As String
        Get
            Return _Art_Id
        End Get
        Set(ByVal Value As String)
            _Art_Id = Value
        End Set
    End Property
    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal Value As Double)
            _Cantidad = Value
        End Set
    End Property
    Public Property CantidadBonificada() As Double
        Get
            Return _CantidadBonificada
        End Get
        Set(ByVal Value As Double)
            _CantidadBonificada = Value
        End Set
    End Property
    Public Property Costo() As Double
        Get
            Return _Costo
        End Get
        Set(ByVal Value As Double)
            _Costo = Value
        End Set
    End Property
    Public Property PorcDescuento() As Double
        Get
            Return _PorcDescuento
        End Get
        Set(ByVal Value As Double)
            _PorcDescuento = Value
        End Set
    End Property
    Public Property MontoDescuento() As Double
        Get
            Return _MontoDescuento
        End Get
        Set(ByVal Value As Double)
            _MontoDescuento = Value
        End Set
    End Property
    Public Property MontoIV() As Double
        Get
            Return _MontoIV
        End Get
        Set(ByVal Value As Double)
            _MontoIV = Value
        End Set
    End Property
    Public Property TotalLinea() As Double
        Get
            Return _TotalLinea
        End Get
        Set(ByVal Value As Double)
            _TotalLinea = Value
        End Set
    End Property
    Public Property TotalLineaBonificada() As Double
        Get
            Return _TotalLineaBonificada
        End Get
        Set(ByVal Value As Double)
            _TotalLineaBonificada = Value
        End Set
    End Property
    Public Property ExentoIV() As Integer
        Get
            Return _ExentoIV
        End Get
        Set(ByVal Value As Integer)
            _ExentoIV = Value
        End Set
    End Property
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
        End Set
    End Property
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public Property Margen() As Double
        Get
            Return _Margen
        End Get
        Set(ByVal Value As Double)
            _Margen = Value
        End Set
    End Property
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal Value As Double)
            _Precio = Value
        End Set
    End Property
    Public Property CantidadEscaneada() As Double
        Get
            Return _CantidadEscaneada
        End Get
        Set(ByVal Value As Double)
            _CantidadEscaneada = Value
        End Set
    End Property
    Public Property Lotes As List(Of TEntradaDetalleLote)
        Get
            Return _Lotes
        End Get
        Set(value As List(Of TEntradaDetalleLote))
            _Lotes = value
        End Set
    End Property
    Public Property Lote() As Integer
        Get
            Return _Lote
        End Get
        Set(ByVal value As Integer)
            _Lote = value
        End Set
    End Property
    Public ReadOnly Property Data() As DataSet
        Get
            Return _Data
        End Get
    End Property
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property
    Public Property EntradaDetalleImpuesto() As List(Of TEntradaDetalleImpuesto)
        Get
            Return _EntradaDetalleImpuesto
        End Get
        Set(ByVal Value As List(Of TEntradaDetalleImpuesto))
            _EntradaDetalleImpuesto = Value
        End Set
    End Property

#End Region
#Region "Constructores"
    Public Sub New(pEmp_Id As Integer)
        MyBase.New()
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
    Public Sub New(pEmp_Id As Integer, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Suc_Id = 0
        _Entrada_Id = 0
        _Detalle_Id = 0
        _Bod_Id = 0
        _Art_Id = ""
        _Cantidad = 0.0
        _CantidadBonificada = 0.0
        _Costo = 0.0
        _PorcDescuento = 0.0
        _MontoDescuento = 0.0
        _MontoIV = 0.0
        _TotalLinea = 0.0
        _TotalLineaBonificada = 0.0
        _ExentoIV = 0
        _Fecha = CDate("1900/01/01")
        _UltimaModificacion = CDate("1900/01/01")
        _Margen = 0
        _Precio = 0
        _Data = New DataSet
        _EntradaDetalleImpuesto.Clear()
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into EntradaDetalle( Emp_Id , Suc_Id" & _
                   " , Entrada_Id , Detalle_Id" & _
                   " , Bod_Id , Art_Id" & _
                   " , Cantidad , CantidadBonificada" & _
                   " , Costo , PorcDescuento" & _
                   " , MontoDescuento , MontoIV" & _
                   " , TotalLinea , TotalLineaBonificada" & _
                   " , ExentoIV , Fecha" & _
                   " , UltimaModificacion , Margen" & _
                   " , Precio )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _Entrada_Id.ToString() & "," & _Detalle_Id.ToString() & _
                   "," & _Bod_Id.ToString() & ",'" & _Art_Id & "'" & _
                   "," & _Cantidad.ToString() & "," & _CantidadBonificada.ToString() & _
                   "," & _Costo.ToString() & "," & _PorcDescuento.ToString() & _
                   "," & _MontoDescuento.ToString() & "," & _MontoIV.ToString() & _
                   "," & _TotalLinea.ToString() & "," & _TotalLineaBonificada.ToString() & _
                   "," & _ExentoIV.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & _
                   ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & "," & _Margen.ToString() & _
                   "," & _Precio.ToString() & ")"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Delete() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = "Delete EntradaDetalle" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Entrada_Id=" & _Entrada_Id.ToString() & _
               " And    Detalle_Id=" & _Detalle_Id.ToString()

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Modify() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.EntradaDetalle " & _
                      " SET    Bod_Id=" & _Bod_Id.ToString() & "," & _
                      " Art_Id='" & _Art_Id & "'" & "," & _
                      " Cantidad=" & _Cantidad & "," & _
                      " CantidadBonificada=" & _CantidadBonificada & "," & _
                      " Costo=" & _Costo & "," & _
                      " PorcDescuento=" & _PorcDescuento & "," & _
                      " MontoDescuento=" & _MontoDescuento & "," & _
                      " MontoIV=" & _MontoIV & "," & _
                      " TotalLinea=" & _TotalLinea & "," & _
                      " TotalLineaBonificada=" & _TotalLineaBonificada & "," & _
                      " ExentoIV=" & _ExentoIV & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Margen=" & _Margen & "," & _
                      " Precio=" & _Precio & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Entrada_Id=" & _Entrada_Id.ToString() & _
                      " And    Detalle_Id=" & _Detalle_Id.ToString()

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From EntradaDetalle" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    Entrada_Id=" & _Entrada_Id.ToString() & _
           " And    Detalle_Id=" & _Detalle_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Entrada_Id = Tabla.Rows(0).Item("Entrada_Id")
                _Detalle_Id = Tabla.Rows(0).Item("Detalle_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Cantidad = Tabla.Rows(0).Item("Cantidad")
                _CantidadBonificada = Tabla.Rows(0).Item("CantidadBonificada")
                _Costo = Tabla.Rows(0).Item("Costo")
                _PorcDescuento = Tabla.Rows(0).Item("PorcDescuento")
                _MontoDescuento = Tabla.Rows(0).Item("MontoDescuento")
                _MontoIV = Tabla.Rows(0).Item("MontoIV")
                _TotalLinea = Tabla.Rows(0).Item("TotalLinea")
                _TotalLineaBonificada = Tabla.Rows(0).Item("TotalLineaBonificada")
                _ExentoIV = Tabla.Rows(0).Item("ExentoIV")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _Margen = Tabla.Rows(0).Item("Margen")
                _Precio = Tabla.Rows(0).Item("Precio")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim TablaImpuesto As DataTable
        Try
            Cn.Open()


            Query = "select * from EntradaDetalleImpuesto" &
                    " where Emp_Id = " & _Emp_Id.ToString() &
                    " And Suc_Id = " & _Suc_Id.ToString() &
                    " And Entrada_Id = " & _Entrada_Id.ToString()

            TablaImpuesto = Cn.Seleccionar(Query).Copy
            TablaImpuesto.TableName = "TablaImpuesto"


            If _Data.Tables.Contains(TablaImpuesto.TableName) Then
                _Data.Tables.Remove(TablaImpuesto.TableName)
            End If

            _Data.Tables.Add(TablaImpuesto)

            Query = "select a.*, b.Nombre as NombreArticulo, b.FactorConversion, b.Suelto, c.Minimo, c.Maximo, c.PromedioVenta, c.Costo as CostoActual" &
                " From EntradaDetalle a, Articulo b, ArticuloBodega c" &
                " where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id" &
                " and a.Emp_Id = c.Emp_Id and a.Suc_Id = c.Suc_Id and a.Bod_Id = c.Bod_Id and a.Art_Id = c.Art_Id " &
                " and a.Emp_Id = " & _Emp_Id.ToString &
                " and a.Suc_Id = " & _Suc_Id.ToString &
                " and a.Entrada_Id = " & _Entrada_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy
            Tabla.TableName = "TablaDetalle"

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select EntradaDetalle_Id as Numero, Nombre From EntradaDetalle"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
#End Region
End Class
