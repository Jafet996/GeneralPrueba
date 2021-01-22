Public Class TApartadoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Apartado_Id As Long
    Private _Documento_Id As Long
    Private _Bod_Id As Integer
    Private _Fecha As DateTime
    Private _Vencimiento As DateTime
    Private _Cliente_Id As Integer
    Private _Monto As Double
    Private _Saldo As Double
    Private _Prima As Double
    Private _Usuario_Id As String
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Estado_Id As Integer
    Private _UltimaModificacion As DateTime
    Private _Detalle As List(Of TApartadoDetalle)
    Private _Abonos As List(Of TApartadoAbono)
    Private _UltimoAbono_Id As Integer
    Private _AbonoImpresion As TApartadoAbono
    Private _Cliente As TCliente
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
    Public Property Apartado_Id() As Long
        Get
            Return _Apartado_Id
        End Get
        Set(ByVal Value As Long)
            _Apartado_Id = Value
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
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
        End Set
    End Property
    Public Property Vencimiento() As DateTime
        Get
            Return _Vencimiento
        End Get
        Set(ByVal Value As DateTime)
            _Vencimiento = Value
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
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
        End Set
    End Property
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property
    Public Property Prima() As Double
        Get
            Return _Prima
        End Get
        Set(ByVal Value As Double)
            _Prima = Value
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
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
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
    Public Property Estado_Id() As Integer
        Get
            Return _Estado_Id
        End Get
        Set(ByVal Value As Integer)
            _Estado_Id = Value
        End Set
    End Property
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property

    Public Property Detalle() As List(Of TApartadoDetalle)
        Get
            Return _Detalle
        End Get
        Set(ByVal Value As List(Of TApartadoDetalle))
            _Detalle = Value
        End Set
    End Property

    Public Property Abonos() As List(Of TApartadoAbono)
        Get
            Return _Abonos
        End Get
        Set(ByVal Value As List(Of TApartadoAbono))
            _Abonos = Value
        End Set
    End Property

    Public Property Cliente() As TCliente
        Get
            Return _Cliente
        End Get
        Set(ByVal Value As TCliente)
            _Cliente = Value
        End Set
    End Property


    Public Property UltimoAbono_Id() As Integer
        Get
            Return _UltimoAbono_Id
        End Get
        Set(ByVal Value As Integer)
            _UltimoAbono_Id = Value
        End Set
    End Property

    Public Property AbonoImpresion As TApartadoAbono
        Get
            Return _AbonoImpresion
        End Get
        Set(value As TApartadoAbono)
            _AbonoImpresion = value
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
        _Apartado_Id = 0
        _Documento_Id = 0
        _Bod_Id = 0
        _Fecha = CDate("1900/01/01")
        _Vencimiento = CDate("1900/01/01")
        _Cliente_Id = 0
        _Monto = 0.00
        _Saldo = 0.00
        _Prima = 0.00
        _Usuario_Id = ""
        _Caja_Id = 0
        _Cierre_Id = 0
        _Estado_Id = 0
        _UltimoAbono_Id = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Detalle = New List(Of TApartadoDetalle)()
        _Abonos = New List(Of TApartadoAbono)()
        _Cliente = New TCliente(EmpresaInfo.Emp_Id)
        _AbonoImpresion = New TApartadoAbono(EmpresaInfo.Emp_Id)
        _Data = New DataSet
    End Sub
#End Region

#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ApartadoEncabezado( Emp_Id , Suc_Id" &
       " , Apartado_Id , Documento_Id" &
       " , Bod_Id , Fecha" &
       " , Vencimiento , Cliente_Id" &
       " , Monto , Saldo" &
       " , Prima , Usuario_Id" &
       " , Caja_Id , Cierre_Id" &
       " , Estado_Id , UltimaModificacion" &
       " )" &
       " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
       "," & _Apartado_Id.ToString() & "," & _Documento_Id.ToString() &
       "," & _Bod_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
       ",'" & Format(_Vencimiento, "yyyyMMdd HH:mm:ss") & "'" & "," & _Cliente_Id.ToString() &
       "," & _Monto.ToString() & "," & _Saldo.ToString() &
       "," & _Prima.ToString() & ",'" & _Usuario_Id & "'" &
       "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() &
       "," & _Estado_Id.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
        ")"

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

            Query = "Delete ApartadoEncabezado" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Apartado_Id=" & _Apartado_Id.ToString()

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

            Query = " Update dbo.ApartadoEncabezado " &
           " SET    Documento_Id=" & _Documento_Id.ToString() & "," &
           " Bod_Id=" & _Bod_Id & "," &
           " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
           " Vencimiento='" & Format(_Vencimiento, "yyyyMMdd HH:mm:ss") & "'" & "," &
           " Cliente_Id=" & _Cliente_Id & "," &
           " Monto=" & _Monto & "," &
           " Saldo=" & _Saldo & "," &
           " Prima=" & _Prima & "," &
           " Usuario_Id='" & _Usuario_Id & "'" & "," &
           " Caja_Id=" & _Caja_Id & "," &
           " Cierre_Id=" & _Cierre_Id & "," &
           " Estado_Id=" & _Estado_Id & "," &
           " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Apartado_Id=" & _Apartado_Id.ToString()

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
        Dim DetallesApartado As New TApartadoDetalle(EmpresaInfo.Emp_Id)
        Dim AbonosApartado As New TApartadoAbono(EmpresaInfo.Emp_Id)
        Try
            Cn.Open()

            Query = "select * From ApartadoEncabezado" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Apartado_Id=" & _Apartado_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Apartado_Id = Tabla.Rows(0).Item("Apartado_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Vencimiento = Tabla.Rows(0).Item("Vencimiento")
                _Cliente_Id = Tabla.Rows(0).Item("Cliente_Id")
                _Monto = Tabla.Rows(0).Item("Monto")
                _Saldo = Tabla.Rows(0).Item("Saldo")
                _Prima = Tabla.Rows(0).Item("Prima")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _Estado_Id = Tabla.Rows(0).Item("Estado_Id")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
            End If

            With DetallesApartado
                .Emp_Id = Emp_Id
                .Suc_Id = Suc_Id
                .Apartado_Id = Apartado_Id
            End With
            Detalle = DetallesApartado.ObtenerDetallesApartado()

            With AbonosApartado
                .Emp_Id = Emp_Id
                .Suc_Id = Suc_Id
                .Apartado_Id = Apartado_Id
            End With
            Abonos = AbonosApartado.ObtenerAbonosApartados()


            With Cliente
                .Cliente_Id = _Cliente_Id
                .ListKey()
            End With


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

            Query = "select * From ApartadoEncabezado"

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

            Query = "select ApartadoEncabezado_Id as Numero, Nombre From ApartadoEncabezado"

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

    Public Function ApartadosDelCliente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From ApartadoEncabezado" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Cliente_Id=" & _Cliente_Id.ToString() &
           " And    Estado_Id <> " & Enum_ApartadoEstado.Abandonado &
           " order by Fecha desc"

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

    Public Function IngresarDeFacturaApartado(pProforma As TProformaEncabezado, pPagos As List(Of TFacturaPago), pPrimaMonto As Double) As String
        Try
            Dim Query As String = ""
            Dim Articulos As String = ""
            Dim CantidadLineas As Integer = 0
            Dim Tabla As DataTable
            Dim Traslado_Id As Long = 0

            Cn.Open()
            Cn.BeginTransaction()


            'Crea la prefactura correspondiente al apartado
            '-----------------------------------------------------------
            '-----------------------------------------------------------

            Query = " Insert into ProformaEncabezado( Emp_Id , Suc_Id" &
                   " , Documento_Id , TipoDoc_Id, Bod_Id" &
                   " , Fecha , Vencimiento, Cliente_Id" &
                   " , Nombre , Vendedor_Id" &
                   " , Usuario_Id , Comentario" &
                   " , Costo , Subtotal" &
                   " , Descuento , IV" &
                   " , Total , Redondeo" &
                   " , TotalCobrado , Cierre_Id" &
                   " , CPU , HostName" &
                   " , IPAddress , Exento" &
                   " , Gravado , Dolares" &
                   " , TipoCambio , UltimaModificacion" &
                   " , Tipo, TipoEntrega_Id, FechaEntrega" &
                   " , DireccionEntrega)" &
                   " Values ( " & pProforma.Emp_Id.ToString() & "," & pProforma.Suc_Id.ToString() &
                   "," & pProforma.Documento_Id.ToString() & "," & pProforma.TipoDoc_Id.ToString() & "," & pProforma.Bod_Id.ToString() &
                   ",'" & Format(pProforma.Fecha, "yyyyMMdd HH:mm:ss") & "',dateadd(day," & pProforma.ProformaDiasVencimiento & ", getdate())," & pProforma.Cliente_Id.ToString() &
                   ",'" & pProforma.Nombre & "'" & "," & pProforma.Vendedor_Id.ToString() &
                   ",'" & pProforma.Usuario_Id & "'" & ",'" & pProforma.Comentario & "'" &
                   "," & pProforma.Costo.ToString() & "," & pProforma.Subtotal.ToString() &
                   "," & pProforma.Descuento.ToString() & "," & pProforma.IV.ToString() &
                   "," & pProforma.Total.ToString() & "," & pProforma.Redondeo.ToString() &
                   "," & pProforma.TotalCobrado.ToString() & "," & pProforma.Cierre_Id.ToString() &
                   ",'" & pProforma.CPU & "'" & ",'" & pProforma.HostName & "'" &
                   ",'" & pProforma.IPAddress & "'" & "," & pProforma.Exento.ToString() &
                   "," & pProforma.Gravado.ToString() & "," & pProforma.Dolares.ToString() &
                   "," & pProforma.TipoCambio.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & pProforma.Tipo.ToString() & "," & pProforma.TipoEntrega_Id.ToString() & ",'" & Format(pProforma.FechaEntrega, "yyyyMMdd") & "'" &
                   ",'" & pProforma.DireccionEntrega & "')"

            Cn.Ejecutar(Query)

            '----------- Guarda el detalle de la factura y hace los rebajos de inventario
            For Each Detalle As TProformaDetalle In pProforma.ProformaDetalles

                Articulos = Articulos & IIf(Articulos.Trim.Length = 0, "", "|") & Detalle.Art_Id
                CantidadLineas += 1


                Query = " Insert into ProformaDetalle( Emp_Id , Suc_Id" &
                       " , Documento_Id , Detalle_Id" &
                       " , Art_Id , Cantidad" &
                       " , Fecha , Costo" &
                       " , Precio , PorcDescuento" &
                       " , MontoDescuento , MontoIV" &
                       " , TotalLinea , ExentoIV" &
                       " , Suelto , Observacion, Servicio" &
                       " )" &
                       " Values ( " & pProforma.Emp_Id.ToString() & "," & pProforma.Suc_Id.ToString() &
                       "," & pProforma.Documento_Id.ToString() & "," & Detalle.Detalle_Id.ToString() &
                       ",'" & Detalle.Art_Id & "'" & "," & Detalle.Cantidad.ToString() &
                       ",'" & Format(pProforma.Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & Detalle.Costo.ToString() &
                       "," & Detalle.Precio.ToString() & "," & Detalle.PorcDescuento.ToString() &
                       "," & Detalle.MontoDescuento.ToString() & "," & Detalle.MontoIV.ToString() &
                       "," & Detalle.TotalLinea.ToString() & "," & Detalle.ExentoIV.ToString() &
                       "," & Detalle.Suelto.ToString() & ",'" & Detalle.Observacion & "'," & Detalle.Servicio.ToString() & ")"
                Cn.Ejecutar(Query)

                For Each impuesto As TFacturaDetalleImpuesto In Detalle.ArticuloImpuestos

                    Query = " insert into ProformaDetalleImpuesto ( Emp_Id , Suc_Id" &
                    " , Documento_Id , Detalle_Id" &
                    " , Codigo_Id , Tarifa_Id" &
                    " , Porcentaje , Cantidad" &
                    " , Monto , Total" &
                    " , Fecha)" &
                    " values ( " & pProforma.Emp_Id.ToString() & "," & pProforma.Suc_Id.ToString() &
                    "," & pProforma.Documento_Id.ToString() & "," & Detalle.Detalle_Id.ToString &
                    ",'" & impuesto.Codigo_Id & "'" & ",'" & impuesto.Tarifa_Id & "'" &
                    "," & impuesto.Porcentaje.ToString & "," & Detalle.Cantidad.ToString() &
                    "," & impuesto.Monto & "," & (Detalle.Cantidad * impuesto.Monto).ToString() &
                    ",'" & Format(Fecha, "yyyyMMdd HH:mm:ss") & "'" & ")"


                    Cn.Ejecutar(Query)
                Next

            Next

            Query = "exec InsertaFacturaBitacora " & pProforma.Cliente_Id.ToString() & "," & pProforma.Emp_Id.ToString() & "," & pProforma.Suc_Id.ToString() & ",0," &
                pProforma.TipoDoc_Id.ToString() & "," & pProforma.Documento_Id.ToString() & ",'" & pProforma.Usuario_Id & "','" & pProforma.IPAddress & "'," & pProforma.Tipo.ToString() &
                ",-1,'" & Articulos & "'," & CantidadLineas.ToString()
            Cn.Ejecutar(Query)


            Query = "CreaTrasladoApartado " & pProforma.Emp_Id & "," & pProforma.Suc_Id & "," & pProforma.Documento_Id

            Tabla = Cn.Seleccionar(Query).Copy

            If Tabla Is Nothing OrElse Tabla.Rows.Count() = 0 Then
                VerificaMensaje("No se obtuvo el numero de traslado")
            Else
                Traslado_Id = Tabla.Rows(0).Item("Traslado_Id")
            End If


            Query = "AplicaTrasladoInventario " & pProforma.Emp_Id & "," & Traslado_Id & ",'" & pProforma.Usuario_Id & "'"

            Cn.Ejecutar(Query)


            '--- Fin Jimmy ---------------------------------------------------------------------------------------------------------------------------------------------

            '-----------------------------------------------------------
            '-----------------------------------------------------------
            '***********************************************************
            'Ingresar el encabezado del Apartado
            '-----------------------------------------------------------
            '-----------------------------------------------------------

            With Me
                .Emp_Id = pProforma.Emp_Id
                .Suc_Id = pProforma.Suc_Id
                .NextOne()
                .Documento_Id = pProforma.Documento_Id
                .Bod_Id = pProforma.Bod_Id
                .Fecha = pProforma.Fecha
                .Vencimiento = pProforma.Vencimiento
                .Cliente_Id = pProforma.Cliente_Id
                .Monto = pProforma.TotalCobrado
                .Saldo = pProforma.TotalCobrado - pPrimaMonto
                .Prima = pPrimaMonto
                .Usuario_Id = pProforma.Usuario_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = pProforma.Cierre_Id
                .Estado_Id = Enum_ApartadoEstado.Pendiente
                .UltimaModificacion = _UltimaModificacion
            End With

            Query = " Insert into ApartadoEncabezado( Emp_Id , Suc_Id" &
                   " , Apartado_Id , Documento_Id" &
                   " , Bod_Id , Fecha" &
                   " , Vencimiento , Cliente_Id" &
                   " , Monto , Saldo" &
                   " , Prima , Usuario_Id" &
                   " , Caja_Id , Cierre_Id" &
                   " , Estado_Id , UltimaModificacion" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Apartado_Id.ToString() & "," & _Documento_Id.ToString() &
                   "," & _Bod_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                   ",'" & Format(_Vencimiento, "yyyyMMdd HH:mm:ss") & "'" & "," & _Cliente_Id.ToString() &
                   "," & _Monto.ToString() & "," & _Saldo.ToString() &
                   "," & _Prima.ToString() & ",'" & _Usuario_Id & "'" &
                   "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() &
                   "," & _Estado_Id.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                    ")"

            Cn.Ejecutar(Query)

            'Finaliza el ingreso del Encabezado
            '-----------------------------------------------------------
            '-----------------------------------------------------------
            '***********************************************************
            'Ingresar los detalles del Apartado
            '-----------------------------------------------------------
            '-----------------------------------------------------------
            For index = 0 To pProforma.ProformaDetalles.Count - 1

                Query = " Insert into ApartadoDetalle( Emp_Id , Suc_Id" &
                   " , Apartado_Id , Detalle_Id" &
                   " , Art_Id , Cantidad" &
                   " , Fecha , Costo" &
                   " , Precio , PorcDescuento" &
                   " , MontoDescuento , MontoIV" &
                   " , TotalLinea , ExentoIV" &
                   " , Suelto , Observacion" &
                   " , Servicio )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Apartado_Id.ToString() & "," & index + 1 &
                   ",'" & pProforma.ProformaDetalles(index).Art_Id & "'" & "," & pProforma.ProformaDetalles(index).Cantidad.ToString() &
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & pProforma.ProformaDetalles(index).Costo.ToString() &
                   "," & pProforma.ProformaDetalles(index).Precio.ToString() & "," & pProforma.ProformaDetalles(index).PorcDescuento.ToString() &
                   "," & pProforma.ProformaDetalles(index).MontoDescuento.ToString() & "," & pProforma.ProformaDetalles(index).MontoIV.ToString() &
                   "," & pProforma.ProformaDetalles(index).TotalLinea.ToString() & "," & pProforma.ProformaDetalles(index).ExentoIV.ToString() &
                   "," & pProforma.ProformaDetalles(index).Suelto.ToString() & ",'" & pProforma.ProformaDetalles(index).Observacion & "'" &
                   "," & pProforma.ProformaDetalles(index).Servicio.ToString() & ")"

                Cn.Ejecutar(Query)
            Next

            'Finaliza el ingreso de los detalles
            '-----------------------------------------------------------
            '-----------------------------------------------------------
            '***********************************************************
            'Ingresar la prima inicial
            '-----------------------------------------------------------
            '-----------------------------------------------------------
            If pPrimaMonto > 0 Then
                Query = " Insert into ApartadoAbono( Emp_Id , Suc_Id" &
                                   " , Apartado_Id , Abono_Id" &
                                   " , Fecha , Monto" &
                                   " , Caja_Id , Cierre_Id" &
                                   " , Usuario_Id , CPU" &
                                   " , HostName , IPAddress" &
                                   " , Anulado , AnuladoFecha" &
                                   " )" &
                                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                                   "," & _Apartado_Id.ToString() & "," & 1 &
                                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & pPrimaMonto & "'" &
                                   "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() &
                                   ",'" & _Usuario_Id & "'" & ",'" & pProforma.CPU & "'" &
                                   ",'" & pProforma.HostName & "'" & ",'" & pProforma.IPAddress & "'" &
                                   "," & 0 & ",'19000101'" &
                                   ")"

                Cn.Ejecutar(Query)





                For index = 0 To pPagos.Count - 1

                    Query = " Insert into ApartadoPago( Emp_Id , Suc_Id" &
                                   " , Apartado_Id , Abono_Id" &
                                   " , Pago_Id , TipoPago_Id" &
                                   " , Monto , Banco_Id" &
                                   " , ChequeNumero , ChequeFecha" &
                                   " , Tarjeta_Id , TarjetaNumero" &
                                   " , TarjetaAutorizacion , Fecha" &
                                   " )" &
                                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                                   "," & _Apartado_Id.ToString() & "," & 1.ToString() &
                                   "," & index + 1 & "," & pPagos(index).TipoPago_Id.ToString() &
                                   "," & pPagos(index).Monto.ToString() & "," & IIf(pPagos(index).Banco_Id > 0, pPagos(index).Banco_Id.ToString(), "null") &
                                   ",'" & pPagos(index).ChequeNumero.ToString() & "'" & ",'" & Format(pPagos(index).ChequeFecha, "yyyyMMdd HH:mm:ss") & "'" &
                                   "," & IIf(pPagos(index).Tarjeta_Id > 0, pPagos(index).Tarjeta_Id.ToString(), "null") & ",'" & pPagos(index).TarjetaNumero & "'" &
                                   ",'" & pPagos(index).TarjetaAutorizacion & "'" & ",'" & Format(pPagos(index).Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                                    ")"


                    Cn.Ejecutar(Query)

                Next


                Query = "exec CierreCajaAcumulaApartadoAbonoPago " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," &
                    Apartado_Id & "," & 1.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString()

                Cn.Ejecutar(Query)


            End If
            'Finaliza el ingreso de la prima inicial
            '-----------------------------------------------------------
            '-----------------------------------------------------------
            '***********************************************************
            'Ingresar pago del apartado
            '-----------------------------------------------------------
            '-----------------------------------------------------------

            'Finaliza el ingreso de los pagos
            '-----------------------------------------------------------
            '-----------------------------------------------------------
            Cn.CommitTransaction()
            'Realiza Commit de toda la transacción
            '-----------------------------------------------------------
            '-----------------------------------------------------------
            Me.ListKey()



            Return ""

        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message()
        End Try

    End Function

    Public Sub NextOne()

        Dim Query As String
        Dim Tabla As DataTable

        Try
            'Cn.Open()

            Query = "select IsNull(MAX(Apartado_Id),0) + 1 as Mov_Id From ApartadoEncabezado" &
                    " Where Emp_Id = " & _Emp_Id.ToString &
                    " And   Suc_Id = " & Suc_Id

            Tabla = Cn.Seleccionar(Query).Copy

            _Apartado_Id = CInt(Tabla.Rows(0).Item(0).ToString())

        Catch ex As Exception
            Throw ex
        Finally
            'Cn.Close()
        End Try

    End Sub

    Public Function CrearAbono(Pagos As List(Of TFacturaPago), pMontoTotal As Double) As String
        Dim Abono As New TApartadoAbono(EmpresaInfo.Emp_Id)
        Dim Pago As New TApartadoPago(EmpresaInfo.Emp_Id)
        Dim Tabla As DataTable
        'Dim Monto As Double
        Dim Query As String = ""

        Try

            Cn.Open()

            Cn.BeginTransaction()

            '-----------------------------------------------
            ''Calcula el monto a abonar----------------------
            ''-----------------------------------------------

            'For Each elemento In Pagos
            '    Monto = Monto + elemento.Monto
            'Next

            '-----------------------------------------------
            'Insertar Abono---------------------------------
            '-----------------------------------------------

            Query = "select IsNull(MAX(Abono_Id),0) + 1 as Mov_Id From ApartadoAbono" &
                    " Where Emp_Id = " & _Emp_Id.ToString &
                    " And   Suc_Id = " & Suc_Id &
                    " And   Apartado_Id = " & Apartado_Id

            Tabla = Cn.Seleccionar(Query).Copy


            _UltimoAbono_Id = CInt(Tabla.Rows(0).Item(0).ToString())


            With Abono
                .Suc_Id = Suc_Id
                .Apartado_Id = Apartado_Id
                .Abono_Id = _UltimoAbono_Id
                .Fecha = Now
                .Monto = pMontoTotal
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CajaInfo.Cierre_Id
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .CPU = InfoMaquina.CPU
                .HostName = InfoMaquina.HostName
                .IPAddress = InfoMaquina.IP_Address
                .Anulado = False
                .AnuladoFecha = CDate("1900/01/01")
            End With

            _AbonoImpresion = Abono

            Query = " Insert into ApartadoAbono( Emp_Id , Suc_Id" &
                   " , Apartado_Id , Abono_Id" &
                   " , Fecha , Monto" &
                   " , Caja_Id , Cierre_Id" &
                   " , Usuario_Id , CPU" &
                   " , HostName , IPAddress" &
                   " , Anulado , AnuladoFecha" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Apartado_Id.ToString() & "," & Abono.Abono_Id.ToString() &
                   ",'" & Format(Abono.Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & Abono.Monto & "'" &
                   "," & Abono.Caja_Id.ToString() & "," & Abono.Cierre_Id.ToString() &
                   ",'" & Abono.Usuario_Id & "'" & ",'" & Abono.CPU & "'" &
                   ",'" & Abono.HostName & "'" & ",'" & Abono.IPAddress & "'" &
                   "," & If(Abono.Anulado, 1, 0) & ",'" & Format(Abono.AnuladoFecha, "yyyyMMdd HH:mm:ss") & "'" &
                   ")"

            Cn.Ejecutar(Query)


            '-----------------------------------------------
            'Insertar Pagos---------------------------------
            '-----------------------------------------------

            Query = "select IsNull(MAX(Abono_Id),0) + 1 as Mov_Id From ApartadoPago" &
                    " Where Emp_Id = " & _Emp_Id.ToString &
                    " And   Suc_Id = " & Suc_Id &
                    " And   Apartado_Id = " & Apartado_Id &
                    " And   Abono_Id = " & Abono.Abono_Id

            Tabla = Cn.Seleccionar(Query).Copy

            Dim Pago_Id As Integer = CInt(Tabla.Rows(0).Item(0).ToString())

            For Each Elemento In Pagos



                Query = " Insert into ApartadoPago( Emp_Id , Suc_Id" &
                   " , Apartado_Id , Abono_Id" &
                   " , Pago_Id , TipoPago_Id" &
                   " , Monto , Banco_Id" &
                   " , ChequeNumero , ChequeFecha" &
                   " , Tarjeta_Id , TarjetaNumero" &
                   " , TarjetaAutorizacion , Fecha" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Apartado_Id.ToString() & "," & Abono.Abono_Id.ToString() &
                   "," & Pago_Id.ToString() & "," & Elemento.TipoPago_Id.ToString() &
                   "," & Elemento.Monto.ToString() & "," & If(Elemento.Banco_Id.ToString() = "0", "Null", Elemento.Banco_Id.ToString()) &
                   ",'" & Elemento.ChequeNumero & "'" & ",'" & Format(Elemento.ChequeFecha, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & If(Elemento.Tarjeta_Id.ToString() = "0", "Null", Elemento.Tarjeta_Id.ToString()) & ",'" & Elemento.TarjetaNumero & "'" &
                   ",'" & Elemento.TarjetaAutorizacion & "'" & ",'" & Format(Elemento.Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                    ")"

                Cn.Ejecutar(Query)



                'Query = "exec CierreCajaAcumulaApartadoAbonoPago " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," &
                'CajaInfo.Caja_Id.ToString() & "," & Elemento.TipoPago_Id.ToString() & "," & Apartado_Id & "," &
                'CajaInfo.Cierre_Id.ToString() & "," & Abono.Abono_Id

                Pago_Id = Pago_Id + 1

            Next


            Query = "exec CierreCajaAcumulaApartadoAbonoPago " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," &
                    Apartado_Id & "," & Abono.Abono_Id.ToString() & "," & CajaInfo.Caja_Id & "," & CajaInfo.Cierre_Id



            Cn.Ejecutar(Query)


            '-----------------------------------------------
            'Actualiza estado y saldo del apartado----------
            '-----------------------------------------------


            'If Monto >= Saldo Then
            '    Estado_Id = Enum_ApartadoEstado.Retirado
            '    Saldo = 0
            '    UltimaModificacion = Now
            'Else
            '    Saldo = Saldo - Monto
            '    UltimaModificacion = Now
            'End If

            Query = " Update dbo.ApartadoEncabezado " &
           " set Saldo = Saldo - " & pMontoTotal & "," &
           " Estado_Id=" & IIf((_Saldo - pMontoTotal) > 0, Enum_ApartadoEstado.Pendiente, Enum_ApartadoEstado.Retirado) & "," &
           " UltimaModificacion = getdate()" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Apartado_Id=" & _Apartado_Id.ToString()

            Cn.Ejecutar(Query)





            If (_Saldo - pMontoTotal) <= 0 Then

                Query = " Update dbo.ProformaEncabezado " &
                       " SET    Tipo=" & Enum_TipoFacturacion.ApartadoRetirado &
                       " Where     Emp_Id=" & _Emp_Id.ToString() &
                       " And    Suc_Id=" & _Suc_Id.ToString() &
                       " And    Documento_Id=" & _Documento_Id.ToString() &
                       " And    Bod_Id=" & CajaInfo.Bod_Id

                Cn.Ejecutar(Query)


            End If


            Cn.CommitTransaction()



            Return ""

        Catch ex As Exception
            Cn.RollBackTransaction()
            Throw ex
        End Try


        'Ingresar Abono 
        'Ingresar Metodo de pago
        'Actualizar Saldo apartado
        'Actualizar Estado del apartado

    End Function

    Public Sub BuscaYColocaVencidos()
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Exec BuscarApartadosVencidos"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

        Catch ex As Exception

        Finally

        End Try
    End Sub

    Public Function Abandonar() As String

        Dim Query As String = ""
        Dim tabla As DataTable
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.ApartadoEncabezado " &
           " SET    Documento_Id=" & _Documento_Id.ToString() & "," &
           " Bod_Id=" & _Bod_Id & "," &
           " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
           " Vencimiento='" & Format(_Vencimiento, "yyyyMMdd HH:mm:ss") & "'" & "," &
           " Cliente_Id=" & _Cliente_Id & "," &
           " Monto=" & _Monto & "," &
           " Saldo=" & _Saldo & "," &
           " Prima=" & _Prima & "," &
           " Usuario_Id='" & _Usuario_Id & "'" & "," &
           " Caja_Id=" & _Caja_Id & "," &
           " Cierre_Id=" & _Cierre_Id & "," &
           " Estado_Id=" & _Estado_Id & "," &
           " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Apartado_Id=" & _Apartado_Id.ToString()

            Cn.Ejecutar(Query)
            Query = "ReversaTrasladoApartado " & EmpresaInfo.Emp_Id & " , " & SucursalInfo.Suc_Id & " , " & _Documento_Id
            tabla = Cn.Seleccionar(Query).Copy
            Query = "AplicaTrasladoInventario " & EmpresaInfo.Emp_Id & " , " & CInt(tabla.Rows(0).Item(0).ToString()) & " , " & UsuarioInfo.Usuario_Id
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
    Public Function RptApartPending(pStartDate As Date, pEndDate As Date, pCheckAll As Boolean) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()
            Query = "EXEC [RptReportApartadosPendientes]" & _Emp_Id & " ," & _Suc_Id & " ,'" & Format(pStartDate, "yyyyMMdd") & "','" & Format(pEndDate, "yyyyMMdd") & "'," & pCheckAll & ""
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
    Public Function BusquedaApartados(ByVal pDesde As Date,
                                       ByVal pHasta As Date,
                                       ByVal IdCliente As Integer) As String
        Dim Query As String
        Dim orderBy As String = " order by AE.Fecha desc"
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "SELECT AE.Suc_Id
                           ,AE.Cliente_Id As CodCliente
                           ,c.Nombre AS Cliente
                           ,AE.Apartado_Id AS Apartado
                           ,S.Nombre AS Sucursal
                           ,AE.Fecha AS Fecha
                           ,AE.Vencimiento AS Vencimiento
                           ,AE.Monto AS Monto
                           ,AE.Saldo AS Saldo
                    FROM ApartadoEncabezado AS AE (nolock) 
                        INNER JOIN Cliente AS C (nolock) ON AE.Emp_Id = C.Emp_Id AND AE.Cliente_Id = C.Cliente_Id
                        INNER JOIN Sucursal AS S (nolock) ON AE.Emp_Id = S.Emp_Id AND AE.Suc_Id = S.Suc_Id" &
                    " WHERE AE.Emp_Id = " & _Emp_Id.ToString() &
                       "And (AE.Fecha >= '" & pDesde.ToString("yyyyMMdd") & "' " &
                       "And AE.Fecha < '" & pHasta.ToString("yyyyMMdd") & "')"

            If IdCliente <> 0 Then
                Query = Query & " And C.Cliente_Id = '" & IdCliente & "'"
            End If

            Query = Query & orderBy

            Tabla = Cn.Seleccionar(Query).Copy

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

