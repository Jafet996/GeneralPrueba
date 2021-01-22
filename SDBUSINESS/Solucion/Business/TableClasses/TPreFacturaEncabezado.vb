Public Class TPreFacturaEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Long
    Private _Bod_Id As Integer
    Private _Fecha As Datetime
    Private _Cliente_Id As Integer
    Private _Nombre As String
    Private _Vendedor_Id As Integer
    Private _Usuario_Id As String
    Private _Costo As Double
    Private _Subtotal As Double
    Private _Descuento As Double
    Private _IV As Double
    Private _Total As Double
    Private _Redondeo As Double
    Private _TotalCobrado As Double
    Private _Cierre_Id As Integer
    Private _CPU As String
    Private _HostName As String
    Private _IPAddress As String
    Private _Exento As Double
    Private _Gravado As Double
    Private _UltimaModificacion As DateTime
    Private _FacturaDetalles As New List(Of TPreFacturaDetalle)
    Private _TipoDocumentoNombre As String
    Private _UsuarioNombre As String
    Private _Data As DataSet

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
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
        End Set
    End Property
    Public Property TipoDoc_Id() As Integer
        Get
            Return _TipoDoc_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoDoc_Id = Value
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
    Public Property Bod_Id() As Integer
        Get
            Return _Bod_Id
        End Get
        Set(ByVal Value As Integer)
            _Bod_Id = Value
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
    Public Property Cliente_Id() As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal Value As Integer)
            _Cliente_Id = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal Value As Integer)
            _Vendedor_Id = Value
        End Set
    End Property
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
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
    Public Property Subtotal() As Double
        Get
            Return _Subtotal
        End Get
        Set(ByVal Value As Double)
            _Subtotal = Value
        End Set
    End Property
    Public Property Descuento() As Double
        Get
            Return _Descuento
        End Get
        Set(ByVal Value As Double)
            _Descuento = Value
        End Set
    End Property
    Public Property IV() As Double
        Get
            Return _IV
        End Get
        Set(ByVal Value As Double)
            _IV = Value
        End Set
    End Property
    Public Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal Value As Double)
            _Total = Value
        End Set
    End Property
    Public Property Redondeo() As Double
        Get
            Return _Redondeo
        End Get
        Set(ByVal Value As Double)
            _Redondeo = Value
        End Set
    End Property
    Public Property TotalCobrado() As Double
        Get
            Return _TotalCobrado
        End Get
        Set(ByVal Value As Double)
            _TotalCobrado = Value
        End Set
    End Property
    Public Property Cierre_Id() As Integer
        Get
            Return _Cierre_Id
        End Get
        Set(ByVal Value As Integer)
            _Cierre_Id = Value
        End Set
    End Property
    Public Property CPU() As String
        Get
            Return _CPU
        End Get
        Set(ByVal Value As String)
            _CPU = Value
        End Set
    End Property
    Public Property HostName() As String
        Get
            Return _HostName
        End Get
        Set(ByVal Value As String)
            _HostName = Value
        End Set
    End Property
    Public Property IPAddress() As String
        Get
            Return _IPAddress
        End Get
        Set(ByVal Value As String)
            _IPAddress = Value
        End Set
    End Property
    Public Property Exento() As Double
        Get
            Return _Exento
        End Get
        Set(ByVal Value As Double)
            _Exento = Value
        End Set
    End Property
    Public Property Gravado() As Double
        Get
            Return _Gravado
        End Get
        Set(ByVal Value As Double)
            _Gravado = Value
        End Set
    End Property
    Public Property FacturaDetalles As List(Of TPreFacturaDetalle)
        Get
            Return _FacturaDetalles
        End Get
        Set(ByVal value As List(Of TPreFacturaDetalle))
            _FacturaDetalles = value
        End Set
    End Property
    Public Property TipoDocumentoNombre As String
        Get
            Return _TipoDocumentoNombre
        End Get
        Set(ByVal value As String)
            _TipoDocumentoNombre = value
        End Set
    End Property
    Public Property UsuarioNombre As String
        Get
            Return _UsuarioNombre
        End Get
        Set(ByVal value As String)
            _UsuarioNombre = value
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


#End Region
#Region "Constructores"
    Public Sub New(ByVal pEmp_Id As Integer)
        MyBase.New()
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
    Public Sub New(ByVal pEmp_Id As Integer, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Suc_Id = 0
        _Caja_Id = 0
        _TipoDoc_Id = 0
        _Documento_Id = 0
        _Bod_Id = 0
        _Fecha = CDate("1900/01/01")
        _Cliente_Id = 0
        _Nombre = ""
        _Vendedor_Id = 0
        _Usuario_Id = ""
        _Costo = 0.0
        _Subtotal = 0.0
        _Descuento = 0.0
        _IV = 0.0
        _Total = 0.0
        _Redondeo = 0.0
        _TotalCobrado = 0.0
        _Cierre_Id = 0
        _CPU = ""
        _HostName = ""
        _IPAddress = ""
        _Exento = 0.0
        _Gravado = 0.0
        _UltimaModificacion = CDate("1900/01/01")
        _FacturaDetalles.Clear()
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = " Insert into PreFacturaEncabezado( Emp_Id , Suc_Id" & _
                   " , Caja_Id , TipoDoc_Id" & _
                   " , Documento_Id , Bod_Id" & _
                   " , Fecha , Cliente_Id" & _
                   " , Nombre , Vendedor_Id" & _
                   " , Usuario_Id , Costo" & _
                   " , Subtotal , Descuento" & _
                   " , IV , Total" & _
                   " , Redondeo , TotalCobrado" & _
                   " , Cierre_Id , CPU" & _
                   " , HostName , IPAddress" & _
                   " , Exento , Gravado" & _
                   " , UltimaModificacion )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() & _
                   "," & _Documento_Id.ToString() & "," & _Bod_Id.ToString() & _
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Cliente_Id.ToString() & _
                   ",'" & _Nombre & "'" & "," & _Vendedor_Id.ToString() & _
                   ",'" & _Usuario_Id & "'" & "," & _Costo.ToString() & _
                   "," & _Subtotal.ToString() & "," & _Descuento.ToString() & _
                   "," & _IV.ToString() & "," & _Total.ToString() & _
                   "," & _Redondeo.ToString() & "," & _TotalCobrado.ToString() & _
                   "," & _Cierre_Id.ToString() & ",'" & _CPU & "'" & _
                   ",'" & _HostName & "'" & ",'" & _IPAddress & "'" & _
                   "," & _Exento.ToString() & "," & _Gravado.ToString() & _
                   ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & ")"

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

            query = "Delete PreFacturaEncabezado" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Caja_Id=" & _Caja_Id.ToString() & _
               " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
               " And    Documento_Id=" & _Documento_Id.ToString()

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

            query = " Update dbo.PreFacturaEncabezado " & _
                      " SET    Bod_Id=" & _Bod_Id.ToString() & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Cliente_Id=" & _Cliente_Id & "," & _
                      " Nombre='" & _Nombre & "'" & "," & _
                      " Vendedor_Id=" & _Vendedor_Id & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & "," & _
                      " Costo=" & _Costo & "," & _
                      " Subtotal=" & _Subtotal & "," & _
                      " Descuento=" & _Descuento & "," & _
                      " IV=" & _IV & "," & _
                      " Total=" & _Total & "," & _
                      " Redondeo=" & _Redondeo & "," & _
                      " TotalCobrado=" & _TotalCobrado & "," & _
                      " Cierre_Id=" & _Cierre_Id & "," & _
                      " CPU='" & _CPU & "'" & "," & _
                      " HostName='" & _HostName & "'" & "," & _
                      " IPAddress='" & _IPAddress & "'" & "," & _
                      " Exento=" & _Exento & "," & _
                      " Gravado=" & _Gravado & "," & _
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Caja_Id=" & _Caja_Id.ToString() & _
                      " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
                      " And    Documento_Id=" & _Documento_Id.ToString()

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
        Dim FacturaDetalle As TPreFacturaDetalle = Nothing
        Try
            Cn.Open()

            Query = "select *,b.Nombre as NombreTipo, c.Nombre as NombreUsuario From PreFacturaEncabezado a, TipoDocumento b, Usuario c" & _
           " Where  a.Emp_Id = b.Emp_Id and a.TipoDoc_Id = b.TipoDoc_Id" & _
           " and    a.Emp_Id = c.Emp_Id and a.Usuario_Id = c.Usuario_Id" & _
           " And    a.Emp_Id = " & _Emp_Id.ToString() & _
           " And    a.Suc_Id=" & _Suc_Id.ToString() & _
           " And    a.Caja_Id=" & _Caja_Id.ToString() & _
           " And    a.TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
           " And    a.Documento_Id=" & _Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Cliente_Id = Tabla.Rows(0).Item("Cliente_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Vendedor_Id = Tabla.Rows(0).Item("Vendedor_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Subtotal = Tabla.Rows(0).Item("Subtotal")
                _Descuento = Tabla.Rows(0).Item("Descuento")
                _IV = Tabla.Rows(0).Item("IV")
                _Total = Tabla.Rows(0).Item("Total")
                _Redondeo = Tabla.Rows(0).Item("Redondeo")
                _TotalCobrado = Tabla.Rows(0).Item("TotalCobrado")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _CPU = Tabla.Rows(0).Item("CPU")
                _HostName = Tabla.Rows(0).Item("HostName")
                _IPAddress = Tabla.Rows(0).Item("IPAddress")
                _Exento = Tabla.Rows(0).Item("Exento")
                _Gravado = Tabla.Rows(0).Item("Gravado")
                _TipoDocumentoNombre = Tabla.Rows(0).Item("NombreTipo")
                _UsuarioNombre = Tabla.Rows(0).Item("NombreUsuario")
            End If




            Query = "select a.*, b.Nombre as NombreArticulo From PreFacturaDetalle a, Articulo b" & _
                    " Where  a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id " & _
                    " And    a.Emp_Id = " & _Emp_Id.ToString() & _
                    " And    a.Suc_Id=" & _Suc_Id.ToString() & _
                    " And    a.Caja_Id=" & _Caja_Id.ToString() & _
                    " And    a.TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
                    " And    a.Documento_Id=" & _Documento_Id.ToString()


            Tabla = Cn.Seleccionar(Query).Copy
            For Each Fila As DataRow In Tabla.Rows
                FacturaDetalle = New TPreFacturaDetalle(_Emp_Id)

                With FacturaDetalle
                    .Emp_Id = Fila("Emp_Id")
                    .Suc_Id = Fila("Suc_Id")
                    .Caja_Id = Fila("Caja_Id")
                    .TipoDoc_Id = Fila("TipoDoc_Id")
                    .Documento_Id = Fila("Documento_Id")
                    .Detalle_Id = Fila("Detalle_Id")
                    .Art_Id = Fila("Art_Id")
                    .Cantidad = Fila("Cantidad")
                    .Fecha = Fila("Fecha")
                    .Costo = Fila("Costo")
                    .Precio = Fila("Precio")
                    .PorcDescuento = Fila("PorcDescuento")
                    .MontoDescuento = Fila("MontoDescuento")
                    .MontoIV = Fila("MontoIV")
                    .TotalLinea = Fila("TotalLinea")
                    .ExentoIV = Fila("ExentoIV")
                    .Suelto = Fila("Suelto")
                    .Descripcion = Fila("NombreArticulo")
                End With
                _FacturaDetalles.Add(FacturaDetalle)
            Next

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

            Query = "select * From PreFacturaEncabezado"

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
    Public Overrides Function LoadComboBox(ByVal pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select PreFacturaEncabezado_Id as Numero, Nombre From PreFacturaEncabezado"

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
    Public Function SiguienteFactura() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            _Documento_Id = 0

            Query = "select (isnull(max(Documento_Id),0) + 1) as SiguienteDocumento" & _
                " From PreFacturaEncabezado" & _
                " Where     Emp_Id=" & _Emp_Id.ToString() & _
                " And    Suc_Id=" & _Suc_Id.ToString() & _
                " And    Caja_Id=" & _Caja_Id.ToString() & _
                " And    TipoDoc_Id=" & _TipoDoc_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Documento_Id = Tabla.Rows(0).Item("SiguienteDocumento")
            Else
                VerificaMensaje("Se preserntaron errorres buscando el número de documento")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function GuardarDocumento() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()


            Query = " Insert into PreFacturaEncabezado( Emp_Id , Suc_Id" & _
                   " , Caja_Id , TipoDoc_Id" & _
                   " , Documento_Id , Bod_Id" & _
                   " , Fecha , Cliente_Id" & _
                   " , Nombre , Vendedor_Id" & _
                   " , Usuario_Id , Costo" & _
                   " , Subtotal , Descuento" & _
                   " , IV , Total" & _
                   " , Redondeo , TotalCobrado" & _
                   " , Cierre_Id , CPU" & _
                   " , HostName , IPAddress" & _
                   " , Exento , Gravado)" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() & _
                   "," & _Documento_Id.ToString() & "," & _Bod_Id.ToString() & _
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Cliente_Id.ToString() & _
                   ",'" & _Nombre & "'" & "," & _Vendedor_Id.ToString() & _
                   ",'" & _Usuario_Id & "'" & "," & _Costo.ToString() & _
                   "," & _Subtotal.ToString() & "," & _Descuento.ToString() & _
                   "," & _IV.ToString() & "," & _Total.ToString() & _
                   "," & _Redondeo.ToString() & "," & _TotalCobrado.ToString() & _
                   "," & _Cierre_Id.ToString() & ",'" & _CPU & "'" & _
                   ",'" & _HostName & "'" & ",'" & _IPAddress & "'" & _
                   "," & _Exento.ToString() & "," & _Gravado.ToString() & ")"

            Cn.Ejecutar(Query)

            '----------- Guarda el detalle de la factura y hace los rebajos de inventario
            For Each Detalle As TPreFacturaDetalle In _FacturaDetalles
                Query = "exec GuardaPreFacturaDetalle " & Detalle.Emp_Id.ToString() & "," & Detalle.Suc_Id.ToString() & "," & Detalle.Caja_Id.ToString() & "," & _Bod_Id.ToString() _
                    & "," & Detalle.TipoDoc_Id.ToString() & "," & Detalle.Documento_Id.ToString() & "," & Detalle.Detalle_Id.ToString() & ",'" & Detalle.Art_Id _
                    & "'," & Detalle.Cantidad.ToString() & ",'" & Format(Detalle.Fecha, "yyyyMMdd HH:mm:ss") & "'," & Detalle.Costo.ToString() & "," & Detalle.Precio.ToString() _
                    & "," & Detalle.PorcDescuento.ToString() & "," & Detalle.MontoDescuento.ToString() & "," & Detalle.MontoIV.ToString() & "," & Detalle.TotalLinea.ToString() _
                    & "," & Detalle.ExentoIV & "," & Detalle.Suelto & ",'" & _Usuario_Id & "'"

                Cn.Ejecutar(Query)
            Next

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function ListaPrefacturasPendientes() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec PreFacturasPendientes " & _Emp_Id.ToString & "," & _Suc_Id.ToString

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
#End Region
End Class
