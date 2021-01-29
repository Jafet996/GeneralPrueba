Public Class TProformaDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Documento_Id As Long
    Private _Detalle_Id As Integer
    Private _Art_Id As String
    Private _Cantidad As Double
    Private _Fecha As Datetime
    Private _Costo As Double
    Private _Precio As Double
    Private _PorcDescuento As Double
    Private _MontoDescuento As Double
    Private _MontoIV As Double
    Private _TotalLinea As Double
    Private _ExentoIV As Integer
    Private _Suelto As Integer
    Private _Observacion As String
    Private _Descripcion As String
    Private _Usuario As String
    Private _Servicio As Integer
    Private _CalculaCantidadFactura As Integer
    Private _Ubicacion As String
    Private _CodigoProveedor As String
    Private _CabysCodigo As String
    Private _ArticuloImpuestos As New List(Of TFacturaDetalleImpuesto)
    Private _Data As DataSet
    Private _Lote As Integer
    Private _Garantia As Integer
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
    Public Property Lote As Integer
        Get
            Return _Lote
        End Get
        Set(value As Integer)
            _Lote = value
        End Set
    End Property
    Public Property Garantia As Integer
        Get
            Return _Garantia
        End Get
        Set(value As Integer)
            _Garantia = value
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
    Public Property Detalle_Id() As Integer
        Get
            Return _Detalle_Id
        End Get
        Set(ByVal Value As Integer)
            _Detalle_Id = Value
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
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
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
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal Value As Double)
            _Precio = Value
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
    Public Property ExentoIV() As Integer
        Get
            Return _ExentoIV
        End Get
        Set(ByVal Value As Integer)
            _ExentoIV = Value
        End Set
    End Property
    Public Property Suelto() As Integer
        Get
            Return _Suelto
        End Get
        Set(ByVal Value As Integer)
            _Suelto = Value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal Value As String)
            _Observacion = Value
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
    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property
    Public Property Servicio As Integer
        Get
            Return _Servicio
        End Get
        Set(value As Integer)
            _Servicio = value
        End Set
    End Property
    Public Property CalculaCantidadFactura() As Integer
        Get
            Return _CalculaCantidadFactura
        End Get
        Set(ByVal Value As Integer)
            _CalculaCantidadFactura = Value
        End Set
    End Property
    Public Property Ubicacion() As String
        Get
            Return _Ubicacion
        End Get
        Set(ByVal Value As String)
            _Ubicacion = Value
        End Set
    End Property
    Public Property CodigoProveedor() As String
        Get
            Return _CodigoProveedor
        End Get
        Set(ByVal Value As String)
            _CodigoProveedor = Value
        End Set
    End Property
    Public Property ArticuloImpuestos As List(Of TFacturaDetalleImpuesto)
        Get
            Return _ArticuloImpuestos
        End Get
        Set(value As List(Of TFacturaDetalleImpuesto))
            _ArticuloImpuestos = value
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
    Public Property CabysCodigo() As String
        Get
            Return _CabysCodigo
        End Get
        Set(ByVal Value As String)
            _CodigoProveedor = Value
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
        _Documento_Id = 0
        _Detalle_Id = 0
        _Art_Id = ""
        _Cantidad = 0.0
        _Fecha = CDate("1900/01/01")
        _Costo = 0.0
        _Precio = 0.0
        _PorcDescuento = 0.0
        _MontoDescuento = 0.0
        _MontoIV = 0.0
        _TotalLinea = 0.0
        _ExentoIV = 0
        _Suelto = 0
        _Observacion = ""
        _Descripcion = ""
        _Usuario = ""
        _Servicio = 0
        _Lote = 0
        _Garantia = 0
        _CalculaCantidadFactura = 0
        _Ubicacion = ""
        _CodigoProveedor = ""
        _CabysCodigo = ""
        _ArticuloImpuestos.Clear()
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ProformaDetalle( Emp_Id , Suc_Id" &
                   " , Documento_Id , Detalle_Id" &
                   " , Art_Id , Cantidad" &
                   " , Fecha , Costo" &
                   " , Precio , PorcDescuento" &
                   " , MontoDescuento , MontoIV" &
                   " , TotalLinea , ExentoIV" &
                   " , Suelto , Observacion, Servicio" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Documento_Id.ToString() & "," & _Detalle_Id.ToString() &
                   ",'" & _Art_Id & "'" & "," & _Cantidad.ToString() &
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Costo.ToString() &
                   "," & _Precio.ToString() & "," & _PorcDescuento.ToString() &
                   "," & _MontoDescuento.ToString() & "," & _MontoIV.ToString() &
                   "," & _TotalLinea.ToString() & "," & _ExentoIV.ToString() &
                   "," & _Suelto.ToString() & ",'" & _Observacion & "'," & Servicio.ToString() & ")"

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

            query = "Delete ProformaDetalle" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Documento_Id=" & _Documento_Id.ToString() & _
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

            Query = " Update dbo.ProformaDetalle " &
                      " SET   Art_Id='" & _Art_Id & "' " & "," &
                      " Cantidad=" & _Cantidad & "," &
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " Costo=" & _Costo & "," &
                      " Precio=" & _Precio & "," &
                      " PorcDescuento=" & _PorcDescuento & "," &
                      " MontoDescuento=" & _MontoDescuento & "," &
                      " MontoIV=" & _MontoIV & "," &
                      " TotalLinea=" & _TotalLinea & "," &
                      " ExentoIV=" & _ExentoIV & "," &
                      " Suelto=" & _Suelto & "," &
                      " Servicio=" & _Servicio & "," &
                      " Observacion='" & _Observacion & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Documento_Id=" & _Documento_Id.ToString() &
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

            Query = "select * From ProformaDetalle" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    Documento_Id=" & _Documento_Id.ToString() & _
           " And    Detalle_Id=" & _Detalle_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _Detalle_Id = Tabla.Rows(0).Item("Detalle_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Cantidad = Tabla.Rows(0).Item("Cantidad")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Precio = Tabla.Rows(0).Item("Precio")
                _PorcDescuento = Tabla.Rows(0).Item("PorcDescuento")
                _MontoDescuento = Tabla.Rows(0).Item("MontoDescuento")
                _MontoIV = Tabla.Rows(0).Item("MontoIV")
                _TotalLinea = Tabla.Rows(0).Item("TotalLinea")
                _ExentoIV = Tabla.Rows(0).Item("ExentoIV")
                _Suelto = Tabla.Rows(0).Item("Suelto")
                _Observacion = Tabla.Rows(0).Item("Observacion")
                _Servicio = Tabla.Rows(0).Item("Servicio")
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
        Try
            Cn.Open()

            Query = "select * From ProformaDetalle"

            Tabla = Cn.Seleccionar(Query).Copy

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

            Query = "select ProformaDetalle_Id as Numero, Nombre From ProformaDetalle"

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

    Public Function ConsultaDetalleProforma() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ConsultaDetalleProforma " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

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


    Public Function GetPreFacturadoArticulo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Isnull(sum(Cantidad),0) as Cantidad From ProformaDetalle" &
           " Where  Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Documento_Id=" & _Documento_Id.ToString()


            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Cantidad = Tabla.Rows(0).Item("Cantidad")
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
