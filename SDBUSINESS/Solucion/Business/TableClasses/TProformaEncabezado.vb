Public Class TProformaEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Documento_Id As Long
    Private _TipoDoc_Id As Integer
    Private _Bod_Id As Integer
    Private _Fecha As DateTime
    Private _Vencimiento As DateTime
    Private _Cliente_Id As Integer
    Private _Nombre As String
    Private _Vendedor_Id As Integer
    Private _Usuario_Id As String
    Private _Comentario As String
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
    Private _Dolares As Integer
    Private _TipoCambio As Double
    Private _UltimaModificacion As DateTime
    Private _Tipo As Integer
    Private _ProformaDetalles As New List(Of TProformaDetalle)
    Private _TipoDocumentoNombre As String
    Private _UsuarioNombre As String
    Private _ProformaDiasVencimiento As Integer
    Private _TipoEntrega_Id As Integer
    Private _FechaEntrega As Date
    Private _Cliente As TCliente
    Private _TipoEntregaNombre As String
    Private _DireccionEntrega As String
    Private _VendedorNombre As String
    Private _ProformaAnterior As New TProformaLlave
    Private _Exoneracion As Integer
    Private _FacturaExoneracion As TFacturaExoneracion
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
    Public Property Documento_Id() As Long
        Get
            Return _Documento_Id
        End Get
        Set(ByVal Value As Long)
            _Documento_Id = Value
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
    Public Property Vencimiento As Date
        Get
            Return _Vencimiento
        End Get
        Set(value As Date)
            _Vencimiento = value
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
    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(ByVal Value As String)
            _Comentario = Value
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
    Public Property Dolares() As Integer
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Integer)
            _Dolares = Value
        End Set
    End Property
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
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
    Public Property Tipo() As Integer
        Get
            Return _Tipo
        End Get
        Set(ByVal Value As Integer)
            _Tipo = Value
        End Set
    End Property
    Public Property ProformaDetalles As List(Of TProformaDetalle)
        Get
            Return _ProformaDetalles
        End Get
        Set(value As List(Of TProformaDetalle))
            _ProformaDetalles = value
        End Set
    End Property
    Public Property TipoDocumentoNombre As String
        Get
            Return _TipoDocumentoNombre
        End Get
        Set(value As String)
            _TipoDocumentoNombre = value
        End Set
    End Property
    Public Property UsuarioNombre As String
        Get
            Return _UsuarioNombre
        End Get
        Set(value As String)
            _UsuarioNombre = value
        End Set
    End Property
    Public Property ProformaDiasVencimiento As Integer
        Get
            Return _ProformaDiasVencimiento
        End Get
        Set(value As Integer)
            _ProformaDiasVencimiento = value
        End Set
    End Property
    Public Property TipoEntrega_Id As Integer
        Get
            Return _TipoEntrega_Id
        End Get
        Set(value As Integer)
            _TipoEntrega_Id = value
        End Set
    End Property
    Public Property FechaEntrega As Date
        Get
            Return _FechaEntrega
        End Get
        Set(value As Date)
            _FechaEntrega = value
        End Set
    End Property
    Public Property Cliente As TCliente
        Get
            Return _Cliente
        End Get
        Set(value As TCliente)
            _Cliente = value
        End Set
    End Property
    Public Property TipoEntregaNombre As String
        Get
            Return _TipoEntregaNombre
        End Get
        Set(value As String)
            _TipoEntregaNombre = value
        End Set
    End Property
    Public Property DireccionEntrega() As String
        Get
            Return _DireccionEntrega
        End Get
        Set(ByVal Value As String)
            _DireccionEntrega = Value
        End Set
    End Property

    Public ReadOnly Property MontoEnLetras
        Get
            Return Letras(Format(IIf(_Dolares = 0, _TotalCobrado, _TotalCobrado / IIf(_TipoCambio = 0, 1, _TipoCambio)), "###0.00"), IIf(_Dolares = 0, "colones", "dólares"))

        End Get
    End Property

    Public Property VendedorNombre As String
        Get
            Return _VendedorNombre
        End Get
        Set(value As String)
            _VendedorNombre = value
        End Set
    End Property

    Public Property ProformaAnterior As TProformaLlave
        Get
            Return _ProformaAnterior
        End Get
        Set(value As TProformaLlave)
            _ProformaAnterior = value
        End Set
    End Property
    Public Property Exoneracion As Integer
        Get
            Return _Exoneracion
        End Get
        Set(value As Integer)
            _Exoneracion = value
        End Set
    End Property

    Public Property FacturaExoneracion As TFacturaExoneracion
        Get
            Return _FacturaExoneracion
        End Get
        Set(value As TFacturaExoneracion)
            _FacturaExoneracion = value
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
        _Documento_Id = 0
        _TipoDoc_Id = 0
        _Bod_Id = 0
        _Fecha = CDate("1900/01/01")
        _Vencimiento = CDate("1900/01/01")
        _Cliente_Id = 0
        _Nombre = ""
        _Vendedor_Id = 0
        _Usuario_Id = ""
        _Comentario = ""
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
        _Dolares = 0
        _TipoCambio = 0.0
        _UltimaModificacion = CDate("1900/01/01")
        _Tipo = 0
        _ProformaDetalles.Clear()
        _TipoDocumentoNombre = ""
        _UsuarioNombre = ""
        _ProformaDiasVencimiento = 0
        _Cliente = Nothing
        _TipoEntregaNombre = ""
        _DireccionEntrega = ""
        _VendedorNombre = ""
        _ProformaAnterior.Inicializa()

        _Exoneracion = 0
        _FacturaExoneracion = New TFacturaExoneracion(_Emp_Id)

        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ProformaEncabezado( Emp_Id , Suc_Id" & _
                   " , Documento_Id ,TipoDoc_Id, Bod_Id" & _
                   " , Fecha , Cliente_Id" & _
                   " , Nombre , Vendedor_Id" & _
                   " , Usuario_Id , Comentario" & _
                   " , Costo , Subtotal" & _
                   " , Descuento , IV" & _
                   " , Total , Redondeo" & _
                   " , TotalCobrado , Cierre_Id" & _
                   " , CPU , HostName" & _
                   " , IPAddress , Exento" & _
                   " , Gravado , Dolares" & _
                   " , TipoCambio , UltimaModificacion" & _
                   " , Tipo )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _Documento_Id.ToString() & "," & _TipoDoc_Id.ToString() & "," & _Bod_Id.ToString() & _
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Cliente_Id.ToString() & _
                   ",'" & _Nombre & "'" & "," & _Vendedor_Id.ToString() & _
                   ",'" & _Usuario_Id & "'" & ",'" & _Comentario & "'" & _
                   "," & _Costo.ToString() & "," & _Subtotal.ToString() & _
                   "," & _Descuento.ToString() & "," & _IV.ToString() & _
                   "," & _Total.ToString() & "," & _Redondeo.ToString() & _
                   "," & _TotalCobrado.ToString() & "," & _Cierre_Id.ToString() & _
                   ",'" & _CPU & "'" & ",'" & _HostName & "'" & _
                   ",'" & _IPAddress & "'" & "," & _Exento.ToString() & _
                   "," & _Gravado.ToString() & "," & _Dolares.ToString() & _
                   "," & _TipoCambio.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                   "," & _Tipo.ToString() & ")"

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


            'Este proceso verifica al eliminar la proforma si es cuna prefactura si la empresa compromete saldos, este sp los libera
            Query = "exec EliminaProforma " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Documento_Id.ToString()

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

            Query = " Update dbo.ProformaEncabezado " & _
                      " SET TipoDoc_Id=" & _TipoDoc_Id.ToString() & "," & _
                      " Bod_Id=" & _Bod_Id & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Cliente_Id=" & _Cliente_Id & "," & _
                      " Nombre='" & _Nombre & "'" & "," & _
                      " Vendedor_Id=" & _Vendedor_Id & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & "," & _
                      " Comentario='" & _Comentario & "'" & "," & _
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
                      " Dolares=" & _Dolares & "," & _
                      " TipoCambio=" & _TipoCambio & "," & _
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Tipo=" & _Tipo & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
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
        Dim ProformaDetalle As TProformaDetalle = Nothing
        Dim FacturaDetalleImpuesto As TFacturaDetalleImpuesto = Nothing
        Dim TablaImpuesto As DataTable = Nothing
        Try
            Cn.Open()

            Query = "select * From ProformaEncabezado" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    Documento_Id=" & _Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Cliente_Id = Tabla.Rows(0).Item("Cliente_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Vendedor_Id = Tabla.Rows(0).Item("Vendedor_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Comentario = Tabla.Rows(0).Item("Comentario")
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
                _Dolares = Tabla.Rows(0).Item("Dolares")
                _TipoCambio = Tabla.Rows(0).Item("TipoCambio")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _Tipo = Tabla.Rows(0).Item("Tipo")
                _TipoEntrega_Id = Tabla.Rows(0).Item("TipoEntrega_Id")
                _FechaEntrega = Tabla.Rows(0).Item("FechaEntrega")
                _DireccionEntrega = Tabla.Rows(0).Item("DireccionEntrega")
                _Exoneracion = Tabla.Rows(0).Item("Exoneracion")
            End If


            If _Exoneracion Then
                Query = "select * From ProformaExoneracion" &
                    " Where  Emp_Id = " & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Documento_Id=" & _Documento_Id.ToString()

                Tabla = Cn.Seleccionar(Query).Copy

                With _FacturaExoneracion
                    .TipoDocumento = Tabla.Rows(0).Item("TipoDocumento")
                    .NumeroDocumento = Tabla.Rows(0).Item("NumeroDocumento")
                    .NombreInstitucion = Tabla.Rows(0).Item("NombreInstitucion")
                    .FechaEmision = Tabla.Rows(0).Item("FechaEmision")
                    .PorcentajeExoneracion = Tabla.Rows(0).Item("PorcentajeExoneracion")
                    .MontoExoneracion = Tabla.Rows(0).Item("MontoExoneracion")
                End With

            End If




            Query = "select * from ProformaDetalleImpuesto" &
           " Where  Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Documento_Id=" & _Documento_Id.ToString()

            TablaImpuesto = Cn.Seleccionar(Query).Copy

            If Cn.RowsAffected = 0 Then
                Query = " Select a.Emp_Id" &
                        "  ,a.Suc_Id" &
                        "  ,a.Documento_Id" &
                        "  ,a.Detalle_Id" &
                        "  ,b.Codigo_Id" &
                        "  ,b.Tarifa_Id" &
                        "  ,b.Porcentaje" &
                        "  ,a.Cantidad" &
                        "  ,((a.Precio - a.MontoDescuento) * (b.Porcentaje / 100)) as Monto" &
                        "  ,(((a.Precio - a.MontoDescuento) * (b.Porcentaje / 100)) * a.Cantidad) as Total " &
                        "  ,Fecha" &
                    " From ProformaDetalle a with (nolock)" &
                    " inner Join ArticuloImpuesto b with (nolock) on a.Emp_Id = b.Emp_Id And a.Art_Id = b.Art_Id" &
                    " Where  a.Emp_Id = " & _Emp_Id.ToString() &
                    " And    a.Suc_Id = " & _Suc_Id.ToString() &
                    " And    a.Documento_Id = " & _Documento_Id.ToString()

                TablaImpuesto = Cn.Seleccionar(Query).Copy
            End If


            _ProformaDetalles.Clear()

            Query = "select a.*, b.Nombre as NombreArticulo, c.Ubicacion, b.CodigoProveedor,b.Lote, b.Garantia" _
             & " From ProformaDetalle a" _
            & " inner join Articulo b on a.Emp_Id = b.Emp_Id And a.Art_Id = b.Art_Id" _
            & " inner join ArticuloBodega c on a.Emp_Id = c.Emp_Id And a.Suc_Id = c.Suc_Id and a.Art_Id = c.Art_Id" _
            & " where  a.Emp_Id = " & _Emp_Id.ToString() _
            & " And    a.Suc_Id = " & _Suc_Id.ToString() _
            & " And    a.Documento_Id=" & _Documento_Id.ToString() _
            & " And    c.Bod_Id = " & _Bod_Id.ToString()


            Tabla = Cn.Seleccionar(Query).Copy
            For Each Fila As DataRow In Tabla.Rows
                ProformaDetalle = New TProformaDetalle(_Emp_Id)

                With ProformaDetalle
                    .Emp_Id = Fila("Emp_Id")
                    .Suc_Id = Fila("Suc_Id")
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
                    .Observacion = Fila("Observacion")
                    .Servicio = Fila("Servicio")
                    .Ubicacion = Fila("Ubicacion")
                    .CodigoProveedor = Fila("CodigoProveedor")
                    .Lote = Fila("Lote")
                    .Garantia = Fila("Garantia")
                End With


                For Each FilaImpuesto As DataRow In TablaImpuesto.Rows
                    If FilaImpuesto("Detalle_Id") = Fila("Detalle_Id") Then
                        FacturaDetalleImpuesto = New TFacturaDetalleImpuesto(_Emp_Id)
                        With FacturaDetalleImpuesto
                            .Suc_Id = FilaImpuesto("Suc_Id")
                            .Documento_Id = FilaImpuesto("Documento_Id")
                            .Detalle_Id = FilaImpuesto("Detalle_Id")
                            .Codigo_Id = FilaImpuesto("Codigo_Id")
                            .Tarifa_Id = FilaImpuesto("Tarifa_Id")
                            .Porcentaje = FilaImpuesto("Porcentaje")
                            .Cantidad = FilaImpuesto("Cantidad")
                            .Monto = FilaImpuesto("Monto")
                            .Total = FilaImpuesto("Total")
                            .Fecha = FilaImpuesto("Fecha")
                        End With
                        ProformaDetalle.ArticuloImpuestos.Add(FacturaDetalleImpuesto)
                    End If
                Next

                _ProformaDetalles.Add(ProformaDetalle)
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

            Query = "select * From ProformaEncabezado"

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

            Query = "select ProformaEncabezado_Id as Numero, Nombre From ProformaEncabezado"

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

    Public Function GuardarDocumento() As String
        Dim Query As String = ""
        Dim Articulos As String = ""
        Dim CantidadLineas As Integer = 0
        Try
            Cn.Open()

            Cn.BeginTransaction()


            'Elimina la proforma anterior y descompromete en caso que la empresa comprometa inventario
            If _ProformaAnterior.Documento_Id <> -1 Then
                Query = "exec EliminaProforma " & _ProformaAnterior.Emp_Id.ToString() & "," & _ProformaAnterior.Suc_Id.ToString() & "," & _ProformaAnterior.Documento_Id.ToString()
                Cn.Ejecutar(Query)
            End If



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
                   " , DireccionEntrega, Exoneracion)" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Documento_Id.ToString() & "," & _TipoDoc_Id.ToString() & "," & _Bod_Id.ToString() &
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "',dateadd(day," & _ProformaDiasVencimiento & ", getdate())," & _Cliente_Id.ToString() &
                   ",'" & _Nombre & "'" & "," & _Vendedor_Id.ToString() &
                   ",'" & _Usuario_Id & "'" & ",'" & _Comentario & "'" &
                   "," & _Costo.ToString() & "," & _Subtotal.ToString() &
                   "," & _Descuento.ToString() & "," & _IV.ToString() &
                   "," & _Total.ToString() & "," & _Redondeo.ToString() &
                   "," & _TotalCobrado.ToString() & "," & _Cierre_Id.ToString() &
                   ",'" & _CPU & "'" & ",'" & _HostName & "'" &
                   ",'" & _IPAddress & "'" & "," & _Exento.ToString() &
                   "," & _Gravado.ToString() & "," & _Dolares.ToString() &
                   "," & _TipoCambio.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & _Tipo.ToString() & "," & _TipoEntrega_Id.ToString() & ",'" & Format(_FechaEntrega, "yyyyMMdd") & "'" &
                   ",'" & _DireccionEntrega & "'," & _Exoneracion & ")"

            Cn.Ejecutar(Query)



            If _Exoneracion Then

                If _FacturaExoneracion Is Nothing Then
                    VerificaMensaje("Imposible almacenar no se encontraron datos de la exoneracion")
                End If

                Query = " insert into ProformaExoneracion ( Emp_Id , Suc_Id" &
                    " , Documento_Id , TipoDocumento" &
                    " , NumeroDocumento , NombreInstitucion" &
                    " , FechaEmision , PorcentajeExoneracion" &
                    " , MontoExoneracion)" &
                    " values ( " & Emp_Id.ToString & "," & Suc_Id.ToString &
                    "," & Documento_Id.ToString & ",'" & _FacturaExoneracion.TipoDocumento & "'" &
                    ",'" & _FacturaExoneracion.NumeroDocumento & "'" & ",'" & _FacturaExoneracion.NombreInstitucion & "'" &
                    ",'" & Format(_FacturaExoneracion.FechaEmision, "yyyyMMdd HH:mm:ss") & "'" & "," & _FacturaExoneracion.PorcentajeExoneracion.ToString &
                    "," & _FacturaExoneracion.MontoExoneracion.ToString & ")"

                Cn.Ejecutar(Query)

            End If

            '----------- Guarda el detalle de la factura y hace los rebajos de inventario
            For Each Detalle As TProformaDetalle In _ProformaDetalles

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
                       " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                       "," & _Documento_Id.ToString() & "," & Detalle.Detalle_Id.ToString() &
                       ",'" & Detalle.Art_Id & "'" & "," & Detalle.Cantidad.ToString() &
                       ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & Detalle.Costo.ToString() &
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
                    " values ( " & Emp_Id.ToString & "," & Suc_Id.ToString &
                    "," & Documento_Id.ToString & "," & Detalle.Detalle_Id.ToString &
                    ",'" & impuesto.Codigo_Id & "'" & ",'" & impuesto.Tarifa_Id & "'" &
                    "," & impuesto.Porcentaje.ToString & "," & Detalle.Cantidad.ToString() &
                    "," & impuesto.Monto & "," & (Detalle.Cantidad * impuesto.Monto).ToString() &
                    ",'" & Format(Fecha, "yyyyMMdd HH:mm:ss") & "'" & ")"


                    Cn.Ejecutar(Query)
                Next


                If _Tipo = Enum_TipoFacturacion.PreFactura AndAlso EmpresaParametroInfo.PrefacturaCompromete Then
                    Query = "ComprometeInventarioArticulo " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() & ",'" _
                        & Detalle.Art_Id & "'," & Detalle.Cantidad.ToString() & ",1"

                    Cn.Ejecutar(Query)
                End If
            Next

            Query = "exec InsertaFacturaBitacora " & _Cliente_Id.ToString() & "," & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & ",0," &
                _TipoDoc_Id.ToString() & "," & _Documento_Id.ToString() & ",'" & _Usuario_Id & "','" & _IPAddress & "'," & _Tipo.ToString() &
                ",-1,'" & Articulos & "'," & CantidadLineas.ToString()
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
    Public Function SiguienteProforma() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            _Documento_Id = 0

            Query = "exec SiguienteProforma " & _Emp_Id.ToString() & "," & _Suc_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Documento_Id = Tabla.Rows(0).Item("Proforma_Id")
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
    Public Function ListaProformasPendientes(pTipo As Integer, pTipoBusqueda As Integer, pFecha As Date, pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ProformasPendientes " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _TipoDoc_Id.ToString() & "," & pTipo.ToString() & "," & pTipoBusqueda.ToString() & ",'" & Format(pFecha, "yyyyMMdd") & "','" & pNombre & "'"

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


    Public Function ListaPreFacturasPendientes(pTipo As String, pTipoBusqueda As Integer, pFecha As Date, pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec PreFacturasPendientes " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _TipoDoc_Id.ToString() & ",'" & pTipo.ToString() & "'," & pTipoBusqueda.ToString() & ",'" & Format(pFecha, "yyyyMMdd") & "','" & pNombre & "'"

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

    Public Function RptArticulosPrefacturados(pFechaIni As Date, pFechaFin As Date, pTipoEntrega As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()


            Query = "exec RptArticulosPrefacturados " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'," & pTipoEntrega

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

    Public Function RptArticulosPrefacturadosResumido(pFechaIni As Date, pFechaFin As Date, pTipoEntrega As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()


            Query = "exec RptArticulosPrefacturadosResumido " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'," & pTipoEntrega

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

    Public Function ConsultaProformaCliente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim ProformaDetalle As TProformaDetalle = Nothing
        Try
            Cn.Open()

            Query = "select * From ProformaEncabezado" &
           " Where  Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Cliente_Id=" & _Cliente_Id.ToString() &
           " And    Tipo = " & _Tipo


            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
            Else
                _Documento_Id = -1
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function InsertaPrefacturadoExterno() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()


            Query = "Delete ReportePrefacturadoExterno"

            Cn.Ejecutar(Query)


            For Each Art As TProformaDetalle In _ProformaDetalles
                Query = " Insert into ReportePrefacturadoExterno( Emp_Id , Art_Id , Pedido )" &
               " Values ( " & _Emp_Id.ToString() & ",'" & Art.Art_Id & "'," & Art.Cantidad & ")"

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

    Public Function ObtieneFormaPagoApartado() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ObtieneFormaPagoApartado " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            Tabla.TableName = "PagosApartado"

            If _Data.Tables.Contains("PagosApartado") Then
                _Data.Tables.Remove("PagosApartado")
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
