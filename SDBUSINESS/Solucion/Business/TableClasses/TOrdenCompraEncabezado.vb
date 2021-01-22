Public Class TOrdenCompraEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Orden_Id As Integer
    Private _Prov_Id As Integer
    Private _Bod_Id As Integer
    Private _OrdenEstado_Id As Integer
    Private _Fecha As Datetime
    Private _Comentario As String
    Private _SubTotal As Double
    Private _Descuento As Double
    Private _IV As Double
    Private _Total As Double
    Private _TotalBonificacion As Double
    Private _Usuario_Id As String
    Private _AplicaUsuario_Id As String
    Private _AplicaFecha As Datetime
    Private _UltimaModificacion As DateTime
    Private _NombreEstado As String
    Private _OrdenCompraDetalles As New List(Of TOrdenCompraDetalle)
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
    Public Property Orden_Id() As Integer
        Get
            Return _Orden_Id
        End Get
        Set(ByVal Value As Integer)
            _Orden_Id = Value
        End Set
    End Property
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
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
    Public Property OrdenEstado_Id() As Integer
        Get
            Return _OrdenEstado_Id
        End Get
        Set(ByVal Value As Integer)
            _OrdenEstado_Id = Value
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
    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(ByVal Value As String)
            _Comentario = Value
        End Set
    End Property
    Public Property SubTotal() As Double
        Get
            Return _SubTotal
        End Get
        Set(ByVal Value As Double)
            _SubTotal = Value
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
    Public Property TotalBonificacion() As Double
        Get
            Return _TotalBonificacion
        End Get
        Set(ByVal Value As Double)
            _TotalBonificacion = Value
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
    Public Property AplicaUsuario_Id() As String
        Get
            Return _AplicaUsuario_Id
        End Get
        Set(ByVal Value As String)
            _AplicaUsuario_Id = Value
        End Set
    End Property
    Public Property AplicaFecha() As Datetime
        Get
            Return _AplicaFecha
        End Get
        Set(ByVal Value As Datetime)
            _AplicaFecha = Value
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
    Public Property NombreEstado As String
        Get
            Return _NombreEstado
        End Get
        Set(value As String)
            _NombreEstado = value
        End Set
    End Property
    Public Property OrdenCompraDetalles As List(Of TOrdenCompraDetalle)
        Get
            Return _OrdenCompraDetalles
        End Get
        Set(value As List(Of TOrdenCompraDetalle))
            _OrdenCompraDetalles = value
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
        _Orden_Id = 0
        _Prov_Id = 0
        _Bod_Id = 0
        _OrdenEstado_Id = 0
        _Fecha = CDate("1900/01/01")
        _Comentario = ""
        _SubTotal = 0.0
        _Descuento = 0.0
        _IV = 0.0
        _Total = 0.0
        _TotalBonificacion = 0.0
        _Usuario_Id = ""
        _AplicaUsuario_Id = ""
        _AplicaFecha = CDate("1900/01/01")
        _UltimaModificacion = CDate("1900/01/01")
        _NombreEstado = ""
        _OrdenCompraDetalles.Clear()
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function SiguienteConsecutivo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try


            Query = "select isnull(max(Orden_Id), 0) + 1 as Siguiente From OrdenCompraEncabezado" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Orden_Id = Tabla.Rows(0).Item("Siguiente")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
        End Try
    End Function
    Public Function GuardarDocumento() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            If _Orden_Id = 0 Then
                VerificaMensaje(SiguienteConsecutivo())

                Query = " Insert into OrdenCompraEncabezado( Emp_Id , Suc_Id" & _
                       " , Orden_Id , Prov_Id" & _
                       " , Bod_Id , OrdenEstado_Id" & _
                       " , Fecha , Comentario" & _
                       " , SubTotal , Descuento" & _
                       " , IV , Total" & _
                       " , TotalBonificacion , Usuario_Id" & _
                       " , AplicaUsuario_Id , AplicaFecha" & _
                       " , UltimaModificacion )" & _
                       " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                       "," & _Orden_Id.ToString() & "," & _Prov_Id.ToString() & _
                       "," & _Bod_Id.ToString() & "," & OrdenCompraEstadoEnum.Pendiente & _
                       ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _Comentario & "'" & _
                       "," & _SubTotal.ToString() & "," & _Descuento.ToString() & _
                       "," & _IV.ToString() & "," & _Total.ToString() & _
                       "," & _TotalBonificacion.ToString() & ",'" & _Usuario_Id & "'" & _
                       ",null,'19000101'" & _
                       ",getdate())"

                Cn.Ejecutar(Query)
            Else

                Query = " Update dbo.OrdenCompraEncabezado " & _
                          " set Prov_Id=" & _Prov_Id.ToString() & "," & _
                          " Bod_Id=" & _Bod_Id & "," & _
                          " OrdenEstado_Id=" & OrdenCompraEstadoEnum.Pendiente & "," & _
                          " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'," & _
                          " Comentario='" & _Comentario & "'" & "," & _
                          " SubTotal=" & _SubTotal & "," & _
                          " Descuento=" & _Descuento & "," & _
                          " IV=" & _IV & "," & _
                          " Total=" & _Total & "," & _
                          " TotalBonificacion=" & _TotalBonificacion & "," & _
                          " Usuario_Id='" & _Usuario_Id & "'" & "," & _
                          " AplicaUsuario_Id=Null," & _
                          " AplicaFecha='19000101'," & _
                          " UltimaModificacion=getdate()" & _
                          " Where     Emp_Id=" & _Emp_Id.ToString() & _
                          " And    Suc_Id=" & _Suc_Id.ToString() & _
                          " And    Orden_Id=" & _Orden_Id.ToString()

                Cn.Ejecutar(Query)

                Query = "Delete OrdenCompraDetalleImpuesto" &
                   " Where     Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    Orden_Id=" & _Orden_Id.ToString()
                Cn.Ejecutar(Query)

                Query = "Delete OrdenCompraDetalle" & _
                   " Where     Emp_Id=" & _Emp_Id.ToString() & _
                   " And    Suc_Id=" & _Suc_Id.ToString() & _
                   " And    Orden_Id=" & _Orden_Id.ToString()
                Cn.Ejecutar(Query)
            End If

            For Each Detalle As TOrdenCompraDetalle In _OrdenCompraDetalles
                With Detalle

                    Query = " Insert into OrdenCompraDetalle( Emp_Id , Suc_Id" &
                                       " , Orden_Id , Detalle_Id, Bod_Id" &
                                       " , Art_Id , Cantidad" &
                                       " , CantidadBonificada , Costo" &
                                       " , PorcDescuento , MontoDescuento" &
                                       " , MontoIV , TotalLinea" &
                                       " , TotalLineaBonificada , ExentoIV" &
                                       " , Fecha , UltimaModificacion )" &
                                       " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                                       "," & _Orden_Id.ToString() & "," & .Detalle_Id.ToString() & "," & _Bod_Id.ToString() &
                                       ",'" & .Art_Id & "'" & "," & .Cantidad.ToString() &
                                       "," & .CantidadBonificada.ToString() & "," & .Costo.ToString() &
                                       "," & .PorcDescuento.ToString() & "," & .MontoDescuento.ToString() &
                                       "," & .MontoIV.ToString() & "," & .TotalLinea.ToString() &
                                       "," & .TotalLineaBonificada.ToString() & "," & .ExentoIV &
                                       ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",getdate())"

                End With

                Cn.Ejecutar(Query)

                If Detalle.ExentoIV = 0 Then

                    For Each impuesto As TOrdenCompraDetalleImpuesto In Detalle.OrdenImpuestoDetalle

                        Query = " insert into OrdenCompraDetalleImpuesto ( Emp_Id , Suc_Id" &
                        " , Orden_Id , Detalle_Id" &
                        " , Codigo_Id , Tarifa_Id" &
                        " , Porcentaje , Cantidad" &
                        " , Monto , Total" &
                        " , Fecha)" &
                        " values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                        "," & _Orden_Id.ToString() & "," & Detalle.Detalle_Id.ToString() &
                        ",'" & impuesto.Codigo_Id & "'" & ",'" & impuesto.Tarifa_Id & "'" &
                        "," & impuesto.Porcentaje.ToString & "," & Detalle.Cantidad.ToString() &
                        "," & impuesto.Monto.ToString() & "," & (Detalle.Cantidad * impuesto.Monto) &
                        ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ")"

                        Cn.Ejecutar(Query)

                    Next
                End If
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

    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into OrdenCompraEncabezado( Emp_Id , Suc_Id" & _
                   " , Orden_Id , Prov_Id" & _
                   " , Bod_Id , OrdenEstado_Id" & _
                   " , Fecha , Comentario" & _
                   " , SubTotal , Descuento" & _
                   " , IV , Total" & _
                   " , TotalBonificacion , Usuario_Id" & _
                   " , AplicaUsuario_Id , AplicaFecha" & _
                   " , UltimaModificacion )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _Orden_Id.ToString() & "," & _Prov_Id.ToString() & _
                   "," & _Bod_Id.ToString() & "," & _OrdenEstado_Id.ToString() & _
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _Comentario & "'" & _
                   "," & _SubTotal.ToString() & "," & _Descuento.ToString() & _
                   "," & _IV.ToString() & "," & _Total.ToString() & _
                   "," & _TotalBonificacion.ToString() & ",'" & _Usuario_Id & "'" & _
                   ",'" & _AplicaUsuario_Id & "'" & ",'" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" & _
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

            Query = "Delete OrdenCompraEncabezado" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Orden_Id=" & _Orden_Id.ToString()

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

            Query = " Update dbo.OrdenCompraEncabezado " & _
                      " SET    Prov_Id=" & _Prov_Id.ToString() & "," & _
                      " Bod_Id=" & _Bod_Id & "," & _
                      " OrdenEstado_Id=" & _OrdenEstado_Id & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Comentario='" & _Comentario & "'" & "," & _
                      " SubTotal=" & _SubTotal & "," & _
                      " Descuento=" & _Descuento & "," & _
                      " IV=" & _IV & "," & _
                      " Total=" & _Total & "," & _
                      " TotalBonificacion=" & _TotalBonificacion & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & "," & _
                      " AplicaUsuario_Id='" & _AplicaUsuario_Id & "'" & "," & _
                      " AplicaFecha='" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Orden_Id=" & _Orden_Id.ToString()

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

            Query = "select a.*, b.Nombre as NombreEstado From OrdenCompraEncabezado a, OrdenCompraEstado b" & _
                " Where  a.Emp_Id = b.Emp_Id and a.OrdenEstado_Id = b.OrdenEstado_Id" & _
                " And a.Emp_Id = " & _Emp_Id.ToString() & _
                " And a.Suc_Id=" & _Suc_Id.ToString() & _
                " And a.Orden_Id=" & _Orden_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Orden_Id = Tabla.Rows(0).Item("Orden_Id")
                _Prov_Id = Tabla.Rows(0).Item("Prov_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _OrdenEstado_Id = Tabla.Rows(0).Item("OrdenEstado_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Comentario = Tabla.Rows(0).Item("Comentario")
                _SubTotal = Tabla.Rows(0).Item("SubTotal")
                _Descuento = Tabla.Rows(0).Item("Descuento")
                _IV = Tabla.Rows(0).Item("IV")
                _Total = Tabla.Rows(0).Item("Total")
                _TotalBonificacion = Tabla.Rows(0).Item("TotalBonificacion")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _AplicaUsuario_Id = IIf(IsDBNull(Tabla.Rows(0).Item("AplicaUsuario_Id")), "", Tabla.Rows(0).Item("AplicaUsuario_Id"))
                _AplicaFecha = Tabla.Rows(0).Item("AplicaFecha")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _NombreEstado = Tabla.Rows(0).Item("NombreEstado")
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

            Query = "select * From OrdenCompraEncabezado"

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

            Query = "select OrdenCompraEncabezado_Id as Numero, Nombre From OrdenCompraEncabezado"

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
    Public Function EliminarDocumento() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Delete OrdenCompraDetalleImpuesto" &
                   " Where  Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    Orden_Id=" & _Orden_Id.ToString()
            Cn.Ejecutar(Query)

            Query = "Delete OrdenCompraDetalle" & _
                   " Where  Emp_Id=" & _Emp_Id.ToString() & _
                   " And    Suc_Id=" & _Suc_Id.ToString() & _
                   " And    Orden_Id=" & _Orden_Id.ToString()
            Cn.Ejecutar(Query)

            Query = "Delete OrdenCompraEncabezado" & _
                   " Where  Emp_Id=" & _Emp_Id.ToString() & _
                   " And    Suc_Id=" & _Suc_Id.ToString() & _
                   " And    Orden_Id=" & _Orden_Id.ToString()
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
    Public Function AplicaOrdenCompra() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec AplicaOrdenCompra " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Orden_Id.ToString() & ",'" & _AplicaUsuario_Id & "'"
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
    Public Function RptOrdenCompra() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptOrdenCompra " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & "," & _Orden_Id.ToString()

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
    Public Function ListBusqueda(pTipoBusqueda As Integer, pCantidad As Integer, pFechaIni As Date, pFechaFin As Date, pSoloAplicadas As Boolean) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()


            Query = "select " & IIf((pTipoBusqueda = 1), "Top " & pCantidad.ToString, "") & " a.Orden_Id as Numero,  b.Nombre as Estado, convert (varchar(10),a.Fecha,103) as Fecha, c.Nombre as NombreProveedor, a.Comentario  " &
                " From OrdenCompraEncabezado a, OrdenCompraEstado b, Proveedor c where a.Emp_Id = b.Emp_Id and a.OrdenEstado_Id = b.OrdenEstado_Id and a.Emp_Id = c.Emp_Id and a.Prov_Id = c.Prov_Id" &
                " and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString

            If pTipoBusqueda = 2 Then
                Query = Query & " and a.Fecha>='" & Format(pFechaIni, "yyyyMMdd") & "' and a.Fecha<='" & Format(DateAdd(DateInterval.Day, 1, pFechaFin), "yyyyMMdd") & "'"
            End If

            If pSoloAplicadas Then
                Query = Query & " and a.OrdenEstado_Id = " & OrdenCompraEstadoEnum.Aplicada
            End If

            Query = Query & " Order by a.Orden_Id desc"

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

    Public Function SugerirCompra(pDias As Integer) As String
        Dim Query As String
        Try
            Cn.Open()

            Query = "exec CreaSugeridoCompra " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString & "," & _Prov_Id.ToString & "," & pDias.ToString

            _Data = Cn.SeleccionarDT(Query).Copy

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function LimpiarBackOrder() As String

        Dim query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = " Exec LimpiaCantidadPendiente " & Emp_Id & " , " & Suc_Id & " , " & Orden_Id

            Cn.Ejecutar(query)

            Cn.CommitTransaction()

            Return ""

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function



    'Public Function ListBusqueda(pTipoBusqueda As Integer, pFechaIni As Date, pFechaFin As Date, pProveedor As Integer) As String
    '    Dim Query As String
    '    Dim Tabla As DataTable
    '    Try
    '        Cn.Open()


    '        Query = "select  a.Orden_Id as Numero, a.Total as Monto,  b.Nombre as Estado, convert (varchar(10),a.Fecha,103) as Fecha, c.Nombre as NombreProveedor, a.Comentario  " &
    '            " From OrdenCompraEncabezado a, OrdenCompraEstado b, Proveedor c where a.Emp_Id = b.Emp_Id and a.OrdenEstado_Id = b.OrdenEstado_Id and a.Emp_Id = c.Emp_Id and a.Prov_Id = c.Prov_Id" &
    '            " and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString

    '        If pTipoBusqueda = 2 Then
    '            Query = Query & " and a.Fecha>='" & Format(pFechaIni, "yyyyMMdd") & "' and a.Fecha<='" & Format(DateAdd(DateInterval.Day, 1, pFechaFin), "yyyyMMdd") & "'"
    '        End If

    '        If pTipoBusqueda = 3 Then
    '            Query = Query & " and c.Prov_Id = " & pProveedor
    '        End If

    '        Query = Query & " and a.OrdenEstado_Id = " & OrdenCompraEstadoEnum.BackOrder

    '        Query = Query & " Order by a.Orden_Id desc"

    '        Tabla = Cn.Seleccionar(Query).Copy

    '        If _Data.Tables.Contains(Tabla.TableName) Then
    '            _Data.Tables.Remove(Tabla.TableName)
    '        End If

    '        _Data.Tables.Add(Tabla)

    '        Return ""

    '    Catch ex As Exception
    '        Return ex.Message
    '    Finally
    '        Cn.Close()
    '    End Try
    'End Function

#End Region
End Class
