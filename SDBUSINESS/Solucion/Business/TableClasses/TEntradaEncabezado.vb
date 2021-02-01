Public Class TEntradaEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Entrada_Id As Integer
    Private _Prov_Id As Integer
    Private _Bod_Id As Integer
    Private _EntradaEstado_Id As Integer
    Private _Fecha As Datetime
    Private _Comentario As String
    Private _SubTotal As Double
    Private _Descuento As Double
    Private _IV As Double
    Private _Total As Double
    Private _TotalBonificacion As Double
    Private _Comprobante As String
    Private _Exento As Double
    Private _Gravado As Double

    Private _Usuario_Id As String
    Private _Clave As String
    Private _AplicaUsuario_Id As String
    Private _AplicaFecha As Datetime
    Private _UltimaModificacion As DateTime
    Private _NombreEstado As String
    Private _Orden_Id As Integer
    Private _EntradaDetalles As New List(Of TEntradaDetalle)
    Private _EntradaFacturas As New List(Of TEntradaFactura)
    Private _Lotes As New List(Of TArticuloLote)

    Private _Data As DataSet

    Private _SDL As New SDFinancial.SDFinancial
    Private _DTMovimiento As New SDFinancial.DTCxPMovimiento
    Private _Resultado As New SDFinancial.TResultado

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
    Public Property EntradaEstado_Id() As Integer
        Get
            Return _EntradaEstado_Id
        End Get
        Set(ByVal Value As Integer)
            _EntradaEstado_Id = Value
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

    Public Property Comprobante() As String
        Get
            Return _Comprobante
        End Get
        Set(ByVal Value As String)
            _Comprobante = Value
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

    Public Property Exento As Double
        Get
            Return _Exento
        End Get
        Set(value As Double)
            _Exento = value
        End Set
    End Property
    Public Property Gravado As Double
        Get
            Return _Gravado
        End Get
        Set(value As Double)
            _Gravado = value
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
    Public Property Orden_Id() As Integer
        Get
            Return _Orden_Id
        End Get
        Set(ByVal Value As Integer)
            _Orden_Id = Value
        End Set
    End Property
    Public Property EntradaDetalles As List(Of TEntradaDetalle)
        Get
            Return _EntradaDetalles
        End Get
        Set(value As List(Of TEntradaDetalle))
            _EntradaDetalles = value
        End Set
    End Property
    Public Property EntradaFacturas As List(Of TEntradaFactura)
        Get
            Return _EntradaFacturas
        End Get
        Set(value As List(Of TEntradaFactura))
            _EntradaFacturas = value
        End Set
    End Property
    Public Property Clave As String
        Get
            Return _Clave
        End Get
        Set(value As String)
            _Clave = value
        End Set
    End Property
    Public Property Lotes As List(Of TArticuloLote)
        Get
            Return _Lotes
        End Get
        Set(value As List(Of TArticuloLote))
            _Lotes = value
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
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.URLContabilidad <> "" Then
            _SDL.Url = InfoMaquina.URLContabilidad
        End If
        _Emp_Id = 0
        _Suc_Id = 0
        _Entrada_Id = 0
        _Prov_Id = 0
        _Bod_Id = 0
        _EntradaEstado_Id = 0
        _Fecha = CDate("1900/01/01")
        _Comentario = ""
        _SubTotal = 0.0
        _Descuento = 0.0
        _IV = 0.0
        _Total = 0.0
        _TotalBonificacion = 0.0
        _Exento = 0.0
        _Gravado = 0.0
        _Usuario_Id = ""
        _AplicaUsuario_Id = ""
        _AplicaFecha = CDate("1900/01/01")
        _UltimaModificacion = CDate("1900/01/01")
        _NombreEstado = ""
        _Orden_Id = 0
        _Comprobante = ""
        _Clave = String.Empty
        _EntradaDetalles.Clear()
        _EntradaFacturas.Clear()
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()


            Query = " Insert into EntradaEncabezado( Emp_Id , Suc_Id" &
                   " , Entrada_Id , Prov_Id" &
                   " , Bod_Id , EntradaEstado_Id" &
                   " , Fecha , Comentario" &
                   " , SubTotal , Descuento" &
                   " , IV , Total" &
                   " , TotalBonificacion , Usuario_Id" &
                   " , AplicaUsuario_Id , AplicaFecha" &
                   " , Orden_Id , UltimaModificacion" &
                   " , Exento , Gravado)" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Entrada_Id.ToString() & "," & _Prov_Id.ToString() &
                   "," & _Bod_Id.ToString() & "," & _EntradaEstado_Id.ToString() &
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _Comentario & "'" &
                   "," & _SubTotal.ToString() & "," & _Descuento.ToString() &
                   "," & _IV.ToString() & "," & _Total.ToString() &
                   "," & _TotalBonificacion.ToString() & ",'" & _Usuario_Id & "'" &
                   ",'" & _AplicaUsuario_Id & "'" & ",'" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & _Orden_Id.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & _Exento.ToString() & "," & _Gravado.ToString() & ")"


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

            query = "Delete EntradaEncabezado" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Entrada_Id=" & _Entrada_Id.ToString()

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

            Query = " Update dbo.EntradaEncabezado " &
                      " SET    Prov_Id=" & _Prov_Id.ToString() & "," &
                      " Bod_Id=" & _Bod_Id & "," &
                      " EntradaEstado_Id=" & _EntradaEstado_Id & "," &
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " Comentario='" & _Comentario & "'" & "," &
                      " SubTotal=" & _SubTotal & "," &
                      " Descuento=" & _Descuento & "," &
                      " IV=" & _IV & "," &
                      " Total=" & _Total & "," &
                      " TotalBonificacion=" & _TotalBonificacion & "," &
                      " Usuario_Id='" & _Usuario_Id & "'" & "," &
                      " AplicaUsuario_Id='" & _AplicaUsuario_Id & "'" & "," &
                      " AplicaFecha='" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " Orden_Id=" & _Orden_Id & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Entrada_Id=" & _Entrada_Id.ToString()

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

            Query = "select a.*,b.Nombre as NombreEstado From EntradaEncabezado a, EntradaEstado b" &
           " Where  a.Emp_Id = b.Emp_Id and a.EntradaEstado_Id = b.EntradaEstado_Id" &
           " And    a.Emp_Id = " & _Emp_Id.ToString() &
           " And    a.Suc_Id=" & _Suc_Id.ToString() &
           " And    a.Entrada_Id=" & _Entrada_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Entrada_Id = Tabla.Rows(0).Item("Entrada_Id")
                _Prov_Id = Tabla.Rows(0).Item("Prov_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _EntradaEstado_Id = Tabla.Rows(0).Item("EntradaEstado_Id")
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
                _Orden_Id = IIf(IsDBNull(Tabla.Rows(0).Item("Orden_Id")), 0, Tabla.Rows(0).Item("Orden_Id"))
                _Exento = Tabla.Rows(0).Item("Exento")
                _Gravado = Tabla.Rows(0).Item("Gravado")
                _Comprobante = Tabla.Rows(0).Item("Comprobante")
                _Clave = Tabla.Rows(0).Item("Clave")
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

            Query = "select * From EntradaEncabezado"

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

    Private Function FacturasLista() As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim resultado As String = " "


        Query = "select Factura From EntradaFactura Where Emp_Id = " & _Emp_Id &
                    " AND Suc_Id = " & _Suc_Id &
                    " AND Entrada_Id IN(" & _Entrada_Id.ToString() & ")"

        Tabla = Cn.Seleccionar(Query).Copy


        For Each row As DataRow In Tabla.Rows
            If resultado = "" Then
                resultado = resultado + row(0)
            Else
                resultado = resultado + "," + row(0)
            End If

        Next

        Return resultado
    End Function

    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select EntradaEncabezado_Id as Numero, Nombre From EntradaEncabezado"

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

    Public Function AplicaEntrada() As String
        Dim Query As String = ""
        Dim Proveedor As New TProveedor(EmpresaInfo.Emp_Id)
        Dim Facturas = New TEntradaEncabezado(Emp_Id)
        Dim Factura_Id As Integer = 1
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec AplicaEntrada " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Entrada_Id.ToString() & ",'" & _AplicaUsuario_Id & "'"
            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            'Interfaz entre Compras y Cuentas x Pagar Software Design Business
            If EmpresaParametroInfo.InterfazCxP Then
                Try

                    Proveedor.Prov_Id = _Prov_Id
                    VerificaMensaje(Proveedor.ListKey)

                    With Facturas
                        .Entrada_Id = Entrada_Id
                        .Suc_Id = Suc_Id
                    End With


                    For Each EntradaFactura As TEntradaFactura In _EntradaFacturas

                        If EntradaFactura.Tipo_Id = 1 Then

                            With _DTMovimiento
                                .Emp_Id = EmpresaInfo.Emp_Id
                                .Prov_Id = Proveedor.Prov_Id
                                .Referencia = " Entrada" & _Entrada_Id & ", Factura # " & EntradaFactura.Factura
                                .FechaRecibido = _Fecha
                                .FechaDocumento = _Fecha
                                .FechaVencimiento = EntradaFactura.FechaVencimiento
                                .Moneda = coMonedaColones
                                .Monto = EntradaFactura.Monto
                                .Tipo_Id = EnumCxPTipo.Factura
                                .Estado_Id = EnumCxPEstado.Pendiente
                                .Saldo = EntradaFactura.Monto
                                .TipoCambio = TipoCambioCompra()
                                .Usuario_Id = Usuario_Id
                            End With

                            _Resultado = _SDL.CxPMovimientoMant(_DTMovimiento, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

                            If _Resultado.ErrorDescription <> "" Then
                                VerificaMensaje(GuardaErrorCxP(_Emp_Id, _Suc_Id, Entrada_Id, Factura_Id, _Resultado.ErrorDescription))
                            End If

                            Factura_Id += 1

                        End If

                    Next

                Catch ex As Exception
                    VerificaMensaje(GuardaErrorCxP(_Emp_Id, _Suc_Id, Entrada_Id, Factura_Id + 1, _Resultado.ErrorDescription))
                End Try
            End If

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Proveedor = Nothing
            Cn.Close()
        End Try
    End Function

    Public Function EliminarDocumento() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " delete EntradaDetalleLote" &
                    " where Emp_Id = " & _Emp_Id.ToString &
                    " and   Suc_Id = " & _Suc_Id.ToString &
                    " and   Entrada_Id = " & _Entrada_Id.ToString

            Cn.Ejecutar(Query)


            Query = "Delete EntradaDetalleImpuesto" &
                   " Where  Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    Entrada_Id=" & _Entrada_Id.ToString()
            Cn.Ejecutar(Query)

            Query = "Delete EntradaDetalle" &
                   " Where  Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    Entrada_Id=" & _Entrada_Id.ToString()
            Cn.Ejecutar(Query)

            Query = "Delete EntradaEncabezado" &
                   " Where  Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    Entrada_Id=" & _Entrada_Id.ToString()
            Cn.Ejecutar(Query)


            If _Orden_Id > 0 Then
                'Le cambia el estado a la orden para que no sea utilizada por otra entrada
                Query = "Update OrdenCompraEncabezado set OrdenEstado_Id = " & OrdenCompraEstadoEnum.Aplicada & ",UltimaModificacion=getdate() " &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Orden_Id=" & _Orden_Id.ToString()

                Cn.Ejecutar(Query)
            End If

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function SiguienteConsecutivo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try


            Query = "select isnull(max(Entrada_Id), 0) + 1 as Siguiente From EntradaEncabezado" &
           " Where  Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Entrada_Id = Tabla.Rows(0).Item("Siguiente")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
        End Try
    End Function

    Public Function GuardarDocumento() As String
        Dim Query As String = ""
        Dim Lote_Id As Integer = 0
        Try
            Cn.Open()

            Cn.BeginTransaction()

            If _Entrada_Id = 0 Then
                VerificaMensaje(SiguienteConsecutivo())

                Query = " Insert into EntradaEncabezado( Emp_Id , Suc_Id" &
                       " , Entrada_Id , Prov_Id" &
                       " , Bod_Id , EntradaEstado_Id" &
                       " , Fecha , Comentario" &
                       " , SubTotal , Descuento" &
                       " , IV , Total" &
                       " , TotalBonificacion , Usuario_Id" &
                       " , AplicaUsuario_Id , AplicaFecha" &
                       " , Orden_Id , UltimaModificacion" &
                       ", Exento, Gravado, Comprobante,Clave)" &
                       " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                       "," & _Entrada_Id.ToString() & "," & _Prov_Id.ToString() &
                       "," & _Bod_Id.ToString() & "," & _EntradaEstado_Id.ToString() &
                       ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _Comentario & "'" &
                       "," & _SubTotal.ToString() & "," & _Descuento.ToString() &
                       "," & _IV.ToString() & "," & _Total.ToString() &
                       "," & _TotalBonificacion.ToString() & ",'" & _Usuario_Id & "'" &
                       "," & IIf(_AplicaUsuario_Id = "", "Null", "'" & _AplicaUsuario_Id & "'") & ",'" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" &
                       "," & IIf(_Orden_Id <= 0, "Null", _Orden_Id.ToString()) & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") &
                       "'," & _Exento.ToString & "," & _Gravado.ToString & ",'" & _Comprobante & "','" & _Clave & "')"


                Cn.Ejecutar(Query)
            Else

                Query = " Update dbo.EntradaEncabezado " &
                          " SET    Prov_Id=" & _Prov_Id.ToString() & "," &
                          " Bod_Id=" & _Bod_Id & "," &
                          " EntradaEstado_Id=" & _EntradaEstado_Id & "," &
                          " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                          " Comentario='" & _Comentario & "'" & "," &
                          " SubTotal=" & _SubTotal & "," &
                          " Descuento=" & _Descuento & "," &
                          " Comprobante='" & _Comprobante & "'," &
                          " IV=" & _IV & "," &
                          " Total=" & _Total & "," &
                          " TotalBonificacion=" & _TotalBonificacion & "," &
                          " Usuario_Id='" & _Usuario_Id & "'" & "," &
                          " AplicaUsuario_Id=" & IIf(_AplicaUsuario_Id = "", "Null", "'" & _AplicaUsuario_Id & "'") & "," &
                          " AplicaFecha='" & Format(_AplicaFecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                          " Orden_Id=" & IIf(_Orden_Id <= 0, "Null", _Orden_Id.ToString()) & "," &
                          " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'," &
                          " Exento = " & _Exento.ToString() & "," &
                          " Gravado = " & _Gravado.ToString &
                          " Where     Emp_Id=" & _Emp_Id.ToString() &
                          " And    Suc_Id=" & _Suc_Id.ToString() &
                          " And    Entrada_Id=" & _Entrada_Id.ToString()

                Cn.Ejecutar(Query)


                Query = " Delete EntradaDetalleLote" &
                        " where Emp_Id = " & _Emp_Id.ToString &
                        " and   Suc_Id = " & _Suc_Id.ToString &
                        " and   Entrada_Id = " & _Entrada_Id.ToString

                Cn.Ejecutar(Query)

                Query = "Delete EntradaDetalleImpuesto" &
                   " Where     Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    Entrada_Id=" & _Entrada_Id.ToString()
                Cn.Ejecutar(Query)

                Query = "Delete EntradaDetalle" &
                   " Where  Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    Entrada_Id=" & _Entrada_Id.ToString()
                Cn.Ejecutar(Query)


                Query = "Delete EntradaFactura" &
                   " Where  Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    Entrada_Id=" & _Entrada_Id.ToString()
                Cn.Ejecutar(Query)

            End If

            For Each Detalle As TEntradaDetalle In _EntradaDetalles
                With Detalle

                    Query = " Insert into EntradaDetalle( Emp_Id , Suc_Id" &
                           " , Entrada_Id , Detalle_Id" &
                           " , Bod_Id , Art_Id" &
                           " , Cantidad , CantidadBonificada" &
                           " , Costo , PorcDescuento" &
                           " , MontoDescuento , MontoIV" &
                           " , TotalLinea , TotalLineaBonificada" &
                           " , ExentoIV , Fecha" &
                           " , UltimaModificacion" &
                           " , Margen, Precio,Lote,CantidadEscaneada)" &
                           " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                           "," & _Entrada_Id.ToString() & "," & .Detalle_Id.ToString() &
                           "," & _Bod_Id.ToString() & ",'" & .Art_Id & "'" &
                           "," & .Cantidad.ToString() & "," & .CantidadBonificada.ToString() &
                           "," & .Costo.ToString() & "," & .PorcDescuento.ToString() &
                           "," & .MontoDescuento.ToString() & "," & .MontoIV.ToString() &
                           "," & .TotalLinea.ToString() & "," & .TotalLineaBonificada.ToString() &
                           "," & .ExentoIV.ToString() & ",'" & Format(.Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                           ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                           "," & .Margen.ToString() & "," & .Precio.ToString() & ",'" & .Lote & "','" & .CantidadEscaneada & "')"

                    Cn.Ejecutar(Query)
                    Lote_Id = 0
                    For Each ArticuloLote As TArticuloLote In _Lotes
                        If ArticuloLote.Art_Id = Detalle.Art_Id Then
                            For Each Lote As TLote In ArticuloLote.Lotes
                                If Lote.Cantidad > 0 Then
                                    Lote_Id += 1

                                    Query = " insert into EntradaDetalleLote (" &
                                        "  Emp_Id" &
                                        " ,Suc_Id" &
                                        " ,Entrada_Id" &
                                        " ,Detalle_Id" &
                                        " ,Lote_Id" &
                                        " ,Art_Id" &
                                        " ,Lote" &
                                        " ,Cantidad" &
                                        " ,Vencimiento" &
                                        " ,Bod_Id" &
                                        " ,Fecha )" &
                                        " values (" &
                                        _Emp_Id.ToString &
                                        "," & _Suc_Id.ToString &
                                        "," & _Entrada_Id.ToString &
                                        "," & Detalle.Detalle_Id.ToString &
                                        "," & Lote_Id.ToString &
                                        ",'" & ArticuloLote.Art_Id & "'" &
                                        ",'" & Lote.Lote & "'" &
                                        "," & Lote.Cantidad.ToString &
                                        ",'" & Lote.Vencimiento.ToString("yyyyMMdd") & "'" &
                                        "," & _Bod_Id.ToString &
                                        ",GETDATE())"

                                    Cn.Ejecutar(Query)
                                End If
                            Next
                        End If
                    Next


                    Query = " Update Articulo" &
                            " set UltimaModificacion = '" & Now.ToString("yyyyMMdd") & "'" &
                            " where Emp_Id = " & _Emp_Id & " and Art_Id = '" & .Art_Id & "'"

                    Cn.Ejecutar(Query)
                End With

                If Detalle.ExentoIV = 0 Then

                    For Each impuesto As TEntradaDetalleImpuesto In Detalle.EntradaDetalleImpuesto

                        Query = " insert into EntradaDetalleImpuesto ( Emp_Id , Suc_Id" &
                        " , Entrada_Id , Detalle_Id" &
                        " , Codigo_Id , Tarifa_Id" &
                        " , Porcentaje , Cantidad" &
                        " , Monto , Total" &
                        " , Fecha)" &
                        " values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                        "," & _Entrada_Id.ToString() & "," & Detalle.Detalle_Id.ToString() &
                        ",'" & impuesto.Codigo_Id & "'" & ",'" & impuesto.Tarifa_Id & "'" &
                        "," & impuesto.Porcentaje.ToString & "," & Detalle.Cantidad.ToString() &
                        "," & impuesto.Monto.ToString() & "," & (Detalle.Cantidad * impuesto.Monto) &
                        ",'" & Format(Detalle.Fecha, "yyyyMMdd HH:mm:ss") & "'" & ")"

                        Cn.Ejecutar(Query)

                    Next
                End If



            Next


            For Each Factura As TEntradaFactura In _EntradaFacturas
                With Factura
                    Query = " Insert into EntradaFactura( Emp_Id , Suc_Id" &
                           " , Entrada_Id , Factura_Id" &
                           " , Prov_Id , Factura" &
                           " , Monto , FechaVencimiento" &
                           " , Comentario , Tipo_Id,  UltimaModificacion)" &
                           " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                           "," & _Entrada_Id.ToString() & "," & .Factura_Id.ToString() &
                           "," & _Prov_Id.ToString() & ",'" & .Factura & "'" &
                           "," & .Monto.ToString() & ",'" & Format(.FechaVencimiento, "yyyyMMdd") & "'" &
                           ",'" & .Comentario & "'" & "," & .Tipo_Id.ToString() & ",getdate())"
                End With

                Cn.Ejecutar(Query)
            Next



            If _Orden_Id > 0 Then
                'Le cambia el estado a la orden para que no sea utilizada por otra entrada
                Query = "Update OrdenCompraEncabezado set OrdenEstado_Id = " & OrdenCompraEstadoEnum.Cerrada & ",UltimaModificacion=getdate() " &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Orden_Id=" & _Orden_Id.ToString()
                Cn.Ejecutar(Query)

            End If

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ListBusqueda(pTipoBusqueda As Integer, pCantidad As Integer, pFechaIni As Date, pFechaFin As Date, pSoloAplicadas As Boolean, pFactura As String, pComemtario As String, pProveedor As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()


            Query = "select " & IIf((pTipoBusqueda = 1), "Top " & pCantidad.ToString, "") & " a.Entrada_Id as Numero,  b.Nombre as Estado, convert (varchar(10),a.Fecha,103) as Fecha, c.Nombre as NombreProveedor, a.Comentario, a.Comprobante " &
                " From EntradaEncabezado a, EntradaEstado b, Proveedor c where a.Emp_Id = b.Emp_Id and a.EntradaEstado_Id = b.EntradaEstado_Id and a.Emp_Id = c.Emp_Id and a.Prov_Id = c.Prov_Id" &
                " and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString

            If pTipoBusqueda = 2 Then
                Query = Query & " and a.Fecha>='" & Format(pFechaIni, "yyyyMMdd") & "' and a.Fecha<='" & Format(DateAdd(DateInterval.Day, 1, pFechaFin), "yyyyMMdd") & "'"
            End If

            If pTipoBusqueda = 3 Then
                Query = Query & " and Orden_Id = '" & pFactura & "'"
            End If
            If pTipoBusqueda = 4 Then
                Query = Query & " and Comentario ='" & pComemtario & "'"
            End If
            If pTipoBusqueda = 5 Then
                Query = Query & " and c.Nombre LIKE '%" & pProveedor & "%'"
            End If

            If pSoloAplicadas Then
                Query = Query & " and a.EntradaEstado_Id = " & EntradaEstadoEnum.Aplicado
            End If

            Query = Query & " Order by a.Entrada_Id desc"

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

    Public Function RptEntradaMercaderia() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptEntradaMercaderia " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & "," & _Entrada_Id.ToString

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

    Public Function RptEntradaMercaderiaxFecha(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptEntradaMercaderiaxFecha " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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

    Public Function RptBackOrdersPorFecha(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptBackOrdersxFecha " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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

    Public Function RptEntradasxUnidades(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptEntradasXUnidades " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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

    Public Function RptEntradaMercaderiaxProveedor(pFechaIni As Date, pFechaFin As Date, pConsolidado As Boolean) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()
            If pConsolidado Then
                Query = "exec RptEntradaMercaderiaxProveedorConsolidado " & _Emp_Id.ToString & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"
            Else
                Query = "exec RptEntradaMercaderiaxProveedor " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"
            End If
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

    Public Function RptEntradaXFechaDetallado(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()
            Query = "exec RptEntradaMercaderiaxFechaDetallado " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"
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

    Public Function VerificaComprobanteRegistrado() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()
            Query = " select Comprobante from EntradaEncabezado" &
                    " where Emp_Id = " & Emp_Id &
                    "   and Prov_Id= " & Prov_Id &
                    "   and Comprobante = '" & Comprobante & "'" &
                    "   and EntradaEstado_Id = 2"
            Tabla = Cn.Seleccionar(Query).Copy

            If Tabla.Rows.Count > 0 Then
                Return "El comprobante ya fue registrado."
            End If
            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function AnulaCompra(MovimientoEncabezado As TMovimientoEncabezado) As String
        Dim Query As String
        Try

            Cn.Open()

            Cn.BeginTransaction()

            If MovimientoEncabezado.Mov_Id = 0 Then
                VerificaMensaje(MovimientoEncabezado.SiguienteConsecutivo())

                Query = " Insert into MovimientoEncabezado( Emp_Id , Suc_Id" &
                       " , TipoMov_Id , Mov_Id" &
                       " , Bod_Id , Fecha" &
                       " , Comentario , Costo" &
                       " , Aplicado , Usuario_Id" &
                       " , Suc_Id_Destino , Bod_Id_Destino" &
                       " , AplicaUsuario_Id , AplicaFecha" &
                       " , UltimaModificacion )" &
                       " Values ( " & MovimientoEncabezado.Emp_Id.ToString() & "," & MovimientoEncabezado.Suc_Id.ToString() &
                       "," & MovimientoEncabezado.TipoMov_Id.ToString() & "," & MovimientoEncabezado.Mov_Id.ToString() &
                       "," & MovimientoEncabezado.Bod_Id.ToString() & ",'" & Format(MovimientoEncabezado.Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                       ",'" & MovimientoEncabezado.Comentario & "'" & "," & MovimientoEncabezado.Costo.ToString() &
                       ",0,'" & MovimientoEncabezado.Usuario_Id & "'" &
                       "," & IIf(MovimientoEncabezado.Suc_Id_Destino > 0, MovimientoEncabezado.Suc_Id_Destino.ToString(), "null") & "," & IIf(MovimientoEncabezado.Bod_Id_Destino > 0, MovimientoEncabezado.Bod_Id_Destino.ToString(), "null") &
                       ",null,'19000101',getdate())"

                Cn.Ejecutar(Query)
            End If

            For Each Detalle As TMovimientoDetalle In MovimientoEncabezado.ListaDetalles
                With Detalle
                    Query = "GuardaMovimientoDetalle " & .Emp_Id.ToString & "," & .Suc_Id.ToString & "," & .TipoMov_Id.ToString & "," & MovimientoEncabezado.Mov_Id.ToString() & "," &
                        .Detalle_Id.ToString & ",'" & .Art_Id & "'," & .Cantidad.ToString & "," & .Costo.ToString & "," & .TotalLinea & "," & .Suelto & ",'" &
                        Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ", 0,0"
                End With

                Cn.Ejecutar(Query)
            Next

            Query = "exec AplicaMovimientoAjuste " & MovimientoEncabezado.Emp_Id.ToString() & "," & MovimientoEncabezado.Suc_Id.ToString & "," & MovimientoEncabezado.TipoMov_Id.ToString & "," & MovimientoEncabezado.Mov_Id.ToString & ",'" & MovimientoEncabezado.AplicaUsuario_Id & "'"
            Cn.Ejecutar(Query)

            Query = "update EntradaEncabezado set EntradaEstado_Id = 3, AnulaUsuario_Id = '" & MovimientoEncabezado.AplicaUsuario_Id & "' where Emp_Id=" & Emp_Id & " and Suc_Id = " & Suc_Id & " and Entrada_Id = " & Entrada_Id
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

    Public Function EntradaxClave() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select a.*,b.Nombre as NombreEstado From EntradaEncabezado a, EntradaEstado b" &
           " Where  a.Emp_Id = b.Emp_Id and a.EntradaEstado_Id = b.EntradaEstado_Id" &
           " And    a.Emp_Id = " & _Emp_Id.ToString() &
           " And    a.Clave  = '" & _Clave & "'" &
           " order by a.Fecha desc"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Entrada_Id = Tabla.Rows(0).Item("Entrada_Id")
                _Prov_Id = Tabla.Rows(0).Item("Prov_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _EntradaEstado_Id = Tabla.Rows(0).Item("EntradaEstado_Id")
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
                _Orden_Id = IIf(IsDBNull(Tabla.Rows(0).Item("Orden_Id")), 0, Tabla.Rows(0).Item("Orden_Id"))
                _Exento = Tabla.Rows(0).Item("Exento")
                _Gravado = Tabla.Rows(0).Item("Gravado")
                _Comprobante = Tabla.Rows(0).Item("Comprobante")
                _Clave = Tabla.Rows(0).Item("Clave")
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
