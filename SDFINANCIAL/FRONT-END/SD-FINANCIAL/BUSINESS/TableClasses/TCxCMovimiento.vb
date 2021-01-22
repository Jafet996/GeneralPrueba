Public Class TCxCMovimiento
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Cliente_Id As Integer

    Private _Vendedor_Id As Integer

    Private _Referencia As String
    Private _Fecha As DateTime
    Private _FechaRecibido As DateTime
    Private _FechaDocumento As Datetime
    Private _FechaVencimiento As Datetime
    Private _Moneda As Char
    Private _Monto As Double
    Private _Saldo As Double
    Private _TipoCambio As Double
    Private _Dolares As Integer
    Private _Usuario_Id As String
    Private _AplicaMora As Integer
    Private _FechaCalculoMora As DateTime
    Private _Batch_Id As Long
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _UltimaModificacion As DateTime
    Private _Suc_Id As Integer
    Private _ListaPagos As New List(Of TCxCMovimientoPago)
    Private _ListaMovimientos As New List(Of TCxCMovimientoLinea)
    Private _ListaAplicados As New List(Of TCxCMovimiento)
    Private _MontoAplicado As Double
    Private _GeneraNotaCredito As Boolean
    Private _MontoNotaCredito As Double
    Private _TipoNombre As String
    Private _UsuarioNombre As String
    Private _ClienteNombre As String
    Private _SaldoCliente As Double
    Private _Reimpresion As Boolean
    Private _MAC_Address As String
    Private _GeneraAsiento As Boolean
    Private _AsientoEncabezado As TAuxAsientoEncabezado
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCxCMovimiento
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    Public Property Mov_Id() As Long
        Get
            Return _Mov_Id
        End Get
        Set(ByVal Value As Long)
            _Mov_Id = Value
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

    Public Property Vendedor_Id() As Integer
        Get
            Return Vendedor_Id
        End Get
        Set(value As Integer)
            _Vendedor_Id = value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return _Referencia
        End Get
        Set(ByVal Value As String)
            _Referencia = Value
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
    Public Property FechaRecibido() As DateTime
        Get
            Return _FechaRecibido
        End Get
        Set(ByVal Value As DateTime)
            _FechaRecibido = Value
        End Set
    End Property
    Public Property FechaDocumento() As DateTime
        Get
            Return _FechaDocumento
        End Get
        Set(ByVal Value As DateTime)
            _FechaDocumento = Value
        End Set
    End Property
    Public Property FechaVencimiento() As DateTime
        Get
            Return _FechaVencimiento
        End Get
        Set(ByVal Value As DateTime)
            _FechaVencimiento = Value
        End Set
    End Property
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
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
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public Property AplicaMora() As Integer
        Get
            Return _AplicaMora
        End Get
        Set(ByVal Value As Integer)
            _AplicaMora = Value
        End Set
    End Property
    Public Property FechaCalculoMora() As DateTime
        Get
            Return _FechaCalculoMora
        End Get
        Set(ByVal Value As DateTime)
            _FechaCalculoMora = Value
        End Set
    End Property
    Public Property Batch_Id() As Long
        Get
            Return _Batch_Id
        End Get
        Set(ByVal Value As Long)
            _Batch_Id = Value
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property

    Public Property Suc_Id() As Integer
        Get
            Return _Suc_Id
        End Get
        Set(ByVal value As Integer)
            _Suc_Id = value
        End Set
    End Property

    Public Property ListaPagos As List(Of TCxCMovimientoPago)
        Get
            Return _ListaPagos
        End Get
        Set(value As List(Of TCxCMovimientoPago))
            _ListaPagos = value
        End Set
    End Property
    Public Property ListaMovimientos As List(Of TCxCMovimientoLinea)
        Get
            Return _ListaMovimientos
        End Get
        Set(value As List(Of TCxCMovimientoLinea))
            _ListaMovimientos = value
        End Set
    End Property
    Public Property ListaAplicados As List(Of TCxCMovimiento)
        Get
            Return _ListaAplicados
        End Get
        Set(value As List(Of TCxCMovimiento))
            _ListaAplicados = value
        End Set
    End Property
    Public Property MontoAplicado As Double
        Get
            Return _MontoAplicado
        End Get
        Set(value As Double)
            _MontoAplicado = value
        End Set
    End Property
    Public Property GeneraNotaCredito As Boolean
        Get
            Return _GeneraNotaCredito
        End Get
        Set(value As Boolean)
            _GeneraNotaCredito = value
        End Set
    End Property
    Public Property MontoNotaCredito As Double
        Get
            Return _MontoNotaCredito
        End Get
        Set(value As Double)
            _MontoNotaCredito = value
        End Set
    End Property
    Public Property TipoNombre As String
        Get
            Return _TipoNombre
        End Get
        Set(value As String)
            _TipoNombre = value
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
    Public Property ClienteNombre As String
        Get
            Return _ClienteNombre
        End Get
        Set(value As String)
            _ClienteNombre = value
        End Set
    End Property
    Public Property SaldoCliente As Double
        Get
            Return _SaldoCliente
        End Get
        Set(value As Double)
            _SaldoCliente = value
        End Set
    End Property
    Public Property Reimpresion As Boolean
        Get
            Return _Reimpresion
        End Get
        Set(value As Boolean)
            _Reimpresion = value
        End Set
    End Property
    Public Property MAC_Address As String
        Get
            Return _MAC_Address
        End Get
        Set(value As String)
            _MAC_Address = value
        End Set
    End Property
    Public Property GeneraAsiento As Boolean
        Get
            Return _GeneraAsiento
        End Get
        Set(value As Boolean)
            _GeneraAsiento = value
        End Set
    End Property
    Public Property AsientoEncabezado As TAuxAsientoEncabezado
        Get
            Return _AsientoEncabezado
        End Get
        Set(value As TAuxAsientoEncabezado)
            _AsientoEncabezado = value
        End Set
    End Property
    Public ReadOnly Property RowsAffected As Long
        Get
            Return _Resultado.RowsAffected
        End Get
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        MyBase.New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.Url <> "" Then
            _SDWCF.Url = InfoMaquina.Url
        Else
            _SDWCF.Url = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegUrl, String.Empty)
        End If
        _Emp_Id = 0
        _Tipo_Id = 0
        _Mov_Id = 0
        _Cliente_Id = 0
        _Referencia = ""
        _Fecha = CDate("1900/01/01")
        _FechaRecibido = CDate("1900/01/01")
        _FechaDocumento = CDate("1900/01/01")
        _FechaVencimiento = CDate("1900/01/01")
        _Moneda = ""
        _Monto = 0.0
        _Saldo = 0.0
        _TipoCambio = 0.0
        _Dolares = 0
        _Usuario_Id = ""
        _AplicaMora = 0
        _FechaCalculoMora = CDate("1900/01/01")
        _Batch_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _UltimaModificacion = CDate("1900/01/01")
        _ListaAplicados.Clear()
        _ListaMovimientos.Clear()
        _ListaPagos.Clear()
        _GeneraNotaCredito = False
        _MontoNotaCredito = 0.0
        _MAC_Address = ""
        _GeneraAsiento = False
        _AsientoEncabezado = New TAuxAsientoEncabezado
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Detalle As SDFinancial.DTCxCMovimientoPago
        Dim Lista As New List(Of SDFinancial.DTCxCMovimientoPago)
        Dim DetalleMov As SDFinancial.DTCxCMovimientoLinea
        Dim ListaMov As New List(Of SDFinancial.DTCxCMovimientoLinea)
        Try
            For Each Item As TCxCMovimientoPago In _ListaPagos
                Detalle = New SDFinancial.DTCxCMovimientoPago

                With Detalle
                    .Emp_Id = Item.Emp_Id
                    .Caja_Id = Item.Caja_Id
                    .Cierre_Id = Item.Cierre_Id
                    .TipoPago_Id = Item.TipoPago_Id
                    .Monto = Item.Monto
                    .Banco_Id = Item.Banco_Id
                    .Cuenta = Item.Cuenta
                    .ChequeNumero = Item.ChequeNumero
                    .ChequeFecha = Item.ChequeFecha
                    .DepositoNumero = Item.DepositoNumero
                    .DepositoFecha = Item.DepositoFecha
                    .TransferenciaNumero = Item.TransferenciaNumero
                    .Tarjeta_Id = Item.Tarjeta_Id
                    .TarjetaNumero = Item.TarjetaNumero
                    .TarjetaAutorizacion = Item.TarjetaAutorizacion
                    .Moneda = Item.Moneda
                    .TipoCambio = Item.TipoCambio
                    .Dolares = Item.Dolares
                End With

                Lista.Add(Detalle)
            Next

            For Each Item As TCxCMovimientoLinea In _ListaMovimientos
                DetalleMov = New SDFinancial.DTCxCMovimientoLinea

                With DetalleMov
                    .Emp_Id = Item.Emp_Id
                    .Tipo_Id = Item.Tipo_Id
                    .Mov_Id = Item.Mov_Id
                    .Monto = Item.Monto
                End With

                ListaMov.Add(DetalleMov)
            Next


            With _DTabla
                .Emp_Id = _Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Cliente_Id = _Cliente_Id
                .Referencia = _Referencia
                .Fecha = _Fecha
                .FechaRecibido = _FechaRecibido
                .FechaDocumento = _FechaDocumento
                .FechaVencimiento = _FechaVencimiento
                .Moneda = _Moneda
                .Monto = _Monto
                .Saldo = _Saldo
                .TipoCambio = _TipoCambio
                .Dolares = _Dolares
                .Usuario_Id = _Usuario_Id
                .AplicaMora = _AplicaMora
                .FechaCalculoMora = _FechaCalculoMora
                .Caja_Id = _Caja_Id
                .Cierre_Id = _Cierre_Id
                .ListaPagos = Lista.ToArray
                .ListaMovimientos = ListaMov.ToArray
                .GeneraNotaCredito = _GeneraNotaCredito
                .MontoNotaCredito = _MontoNotaCredito
                .MAC_Address = _MAC_Address
                .GeneraAsiento = _GeneraAsiento
                .Suc_Id = _Suc_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                    Datos.Tables.Remove(_Resultado.Datos.TableName)
                End If

                Datos.Tables.Add(_Resultado.Datos)
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function Delete() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function Modify() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Cliente_Id = _Cliente_Id
                .Referencia = _Referencia
                .Fecha = _Fecha
                .FechaRecibido = _FechaRecibido
                .FechaDocumento = _FechaDocumento
                .FechaVencimiento = _FechaVencimiento
                .Moneda = _Moneda
                .Monto = _Monto
                .Saldo = _Saldo
                .TipoCambio = _TipoCambio
                .Dolares = _Dolares
                .Usuario_Id = _Usuario_Id
                .AplicaMora = _AplicaMora
                .FechaCalculoMora = _FechaCalculoMora
                .Batch_Id = _Batch_Id
                .Caja_Id = _Caja_Id
                .Cierre_Id = _Cierre_Id
                .Suc_Id = _Suc_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Tipo_Id = _Resultado.Datos.Rows(0).Item("Tipo_Id")
                _Mov_Id = _Resultado.Datos.Rows(0).Item("Mov_Id")
                _Cliente_Id = _Resultado.Datos.Rows(0).Item("Cliente_Id")
                _Referencia = _Resultado.Datos.Rows(0).Item("Referencia")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _FechaRecibido = _Resultado.Datos.Rows(0).Item("FechaRecibido")
                _FechaDocumento = _Resultado.Datos.Rows(0).Item("FechaDocumento")
                _FechaVencimiento = _Resultado.Datos.Rows(0).Item("FechaVencimiento")
                _Moneda = _Resultado.Datos.Rows(0).Item("Moneda")
                _Monto = _Resultado.Datos.Rows(0).Item("Monto")
                _Saldo = _Resultado.Datos.Rows(0).Item("Saldo")
                _TipoCambio = _Resultado.Datos.Rows(0).Item("TipoCambio")
                _Dolares = _Resultado.Datos.Rows(0).Item("Dolares")
                _Usuario_Id = _Resultado.Datos.Rows(0).Item("Usuario_Id")
                _AplicaMora = _Resultado.Datos.Rows(0).Item("AplicaMora")
                _FechaCalculoMora = _Resultado.Datos.Rows(0).Item("FechaCalculoMora")
                _Batch_Id = _Resultado.Datos.Rows(0).Item("Batch_Id")
                _UltimaModificacion = _Resultado.Datos.Rows(0).Item("UltimaModificacion")
                _TipoNombre = _Resultado.Datos.Rows(0).Item("NombreTipo")
                _Caja_Id = IIf(IsDBNull(_Resultado.Datos.Rows(0).Item("Caja_Id")), 0, _Resultado.Datos.Rows(0).Item("Caja_Id"))
                _Cierre_Id = IIf(IsDBNull(_Resultado.Datos.Rows(0).Item("Cierre_Id")), 0, _Resultado.Datos.Rows(0).Item("Cierre_Id"))
                _UsuarioNombre = _Resultado.Datos.Rows(0).Item("NombreUsuario")
                _ClienteNombre = _Resultado.Datos.Rows(0).Item("NombreCliente")
                _SaldoCliente = _Resultado.Datos.Rows(0).Item("SaldoCliente")
            End If

            VerificaMensaje(ObtieneListaAplicados)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.CxCMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function LoadComboBox(pCombo As Windows.Forms.ComboBox) As String
        Try
            _Resultado = _SDWCF.CxCMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = _Resultado.Datos
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function ListMant(pCriterio As String) As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function NextOne() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Tipo_Id = _Tipo_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Mov_Id = _Resultado.Datos.Rows(0).Item("Mov_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function MovimientosCliente(pTipo As Integer) As String
        Dim Query As String

        Try
            Query = "select a.*, b.Nombre as TipoNombre, b.IncrementaSaldo" &
                    " from CxCMovimiento a, CxCMovimientoTipo b" &
                    " where a.Emp_Id = b.Emp_Id" &
                    " and   a.Tipo_Id = b.Tipo_Id" &
                    " and   a.Emp_Id = " & _Emp_Id.ToString() &
                    " and   a.Cliente_Id = " & _Cliente_Id.ToString()

            Select Case pTipo
                Case 1
                    Query += " and   a.Saldo > 0" &
                             " and   b.IncrementaSaldo = 1"
                Case 2
                    Query += " and   b.IncrementaSaldo = 1"
                Case 3
                    Query += " and   b.IncrementaSaldo = 0"
            End Select

            Query += " order by a.Fecha"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ConsultarFacturasAsignadas(pVendedor As Integer) As String
        Dim Query As String

        Try
            Query = "EXEC ConsultaAsignaFacturaVendedor " & EmpresaInfo.Emp_Id & " , " & pVendedor

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function GuardarFacturasAsignadas(pfacturas As List(Of TCxCMovimiento), pVendedor As Integer) As String
        Dim Query As String

        Try
            For Each factura In pfacturas
                Query = "EXEC CxCAsignaFacturaVendedorInsert " & EmpresaInfo.Emp_Id & " , " & factura.Tipo_Id & " , " & pVendedor & " , " & factura.Mov_Id & " , " & factura.Cliente_Id

                _Resultado = _SDWCF.ExecuteQuery(Query, String.Empty)

                MsgError = _Resultado.ErrorDescription
                VerificaMsgError()
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try


        Return 0
    End Function

    Public Function AsignarFacturasPendientes() As String

        Dim Query As String

        Try
            Query = "Select b.Nombre As TipoNombre, a.Mov_Id, a.Tipo_Id, a.Referencia , a.Cliente_Id , c.Nombre As Cliente , a.FechaVencimiento, a.Monto, a.Saldo " &
                     "from CxCMovimiento a, CxCMovimientoTipo b, Cliente c " &
                     "where a.Mov_Id NOT IN (SELECT d.Mov_Id FROM CxCEntregaDocumentoDetalle d " &
                                             " INNER JOIN CxCEntregaDocumentoEncabezado e On e.Emp_Id = d.Emp_Id And e.Entrega_Id = d.Entrega_Id" &
                                             " WHERE e.Fecha = CONVERT(date, getdate()))" &
                     " And   a.Emp_Id = b.Emp_Id " &
                     " And   a.Cliente_Id = c.Cliente_Id " &
                     " And   a.Tipo_Id = b.Tipo_Id " &
                    " And   a.Emp_Id = " & _Emp_Id.ToString &
                    " And   a.Tipo_Id In (1,4,6)" &
                    " And   a.Saldo > 0" &
                    " order by a.Fecha"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)


            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try


        Return 0
    End Function

    Public Function MovimientosClienteRecibo() As String
        Dim Query As String

        Try
            Query = "Select a.*, b.Nombre As TipoNombre" & _
                    " from CxCMovimiento a, CxCMovimientoTipo b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " And   a.Tipo_Id = b.Tipo_Id" & _
                    " And   a.Emp_Id = " & _Emp_Id.ToString & _
                    " And   a.Cliente_Id = " & _Cliente_Id.ToString & _
                    " And   a.Tipo_Id In (1,4,6)" & _
                    " And   a.Saldo > 0" & _
                    " order by a.Fecha"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function RptDocumentosProximosVencer() As String
        Dim Query As String

        Try
            Query = "exec RptCxCDocumentosProximosVencer " & _Emp_Id.ToString & "," & _Cliente_Id.ToString &
                    ",'" & Format(_FechaVencimiento, "yyyyMMdd") & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function RptFacturaPendiente(pInfoAdicional As Boolean) As String
        Dim Query As String

        Try
            'If pConsolidado Then
            '    Query = "exec RptFacturaPendienteConsolidado "
            'ElseIf pInterno Then
            '    Query = "exec RptFacturaPendienteInterno " & _Emp_Id.ToString
            'Else
            Query = "exec RptFacturaPendiente " & _Emp_Id.ToString & "," & _Cliente_Id.ToString & "," & pInfoAdicional

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function RptMovimientoPorCliente(pDesde As Date, pHasta As Date) As String
        Dim Query As String

        Try
            Query = "exec RptCxCEstadoCuentaCliente " & _Emp_Id.ToString & "," & _Cliente_Id.ToString & ",'" & pDesde.ToString("yyyyMMdd") & "','" & pHasta.ToString("yyyyMMdd") & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function RptEstadoCuentaPorCliente(pDesde As Date, pHasta As Date) As String

        Dim Query As String

        Try

            Query = " exec RptCxCEstadoCuentaPorCliente " & _Emp_Id.ToString & "," &
                _Cliente_Id.ToString & ",'" & pDesde & "','" & pHasta & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty

        Catch ex As Exception

            Return ex.Message

        End Try


    End Function

    Public Function RptMovimientosGenerales(pDesde As Date, pHasta As Date, pTipo As Integer) As String

        Dim Query As String

        Try

            Query = " exec RptCxCMovimientosGenerales " & _Emp_Id.ToString & "," &
                pTipo & ",'" & pDesde.ToString("yyyyMMdd") & "','" & pHasta.ToString("yyyyMMdd") & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty

        Catch ex As Exception

            Return ex.Message

        End Try


    End Function

    Public Function ObtieneListaAplicados() As String
        Dim Query As String
        Dim CxCMovimiento As TCxCMovimiento

        Try
            _ListaAplicados.Clear()

            Query = "select b.*" &
                    " ,c.Nombre as NombreTipo" &
                    " ,a.Monto as MontoAplica" &
                    " from CxCMovimientoAplica a" &
                    " ,CxCMovimiento b" &
                    " ,CxCMovimientoTipo c" &
                    " where a.Emp_Id = b.Emp_Id" &
                    " and   a.TipoAplica_Id = b.Tipo_Id" &
                    " and   a.MovAplica_Id = b.Mov_Id" &
                    " and   a.Emp_Id = c.Emp_Id" &
                    " and   a.TipoAplica_Id = c.Tipo_Id" &
                    " and   a.Emp_Id = " & _Emp_Id.ToString &
                    " and   a.Tipo_Id = " & _Tipo_Id.ToString &
                    " and   a.Mov_Id = " & _Mov_Id.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    CxCMovimiento = New TCxCMovimiento

                    With CxCMovimiento
                        .Emp_Id = Fila("Emp_Id")
                        .Tipo_Id = Fila("Tipo_Id")
                        .Mov_Id = Fila("Mov_Id")
                        .Cliente_Id = Fila("Cliente_Id")
                        .Referencia = Fila("Referencia")
                        .Fecha = Fila("Fecha")
                        .FechaDocumento = Fila("FechaDocumento")
                        .FechaVencimiento = Fila("FechaVencimiento")
                        .Moneda = Fila("Moneda")
                        .Monto = Fila("Monto")
                        .Saldo = Fila("Saldo")
                        .TipoCambio = Fila("TipoCambio")
                        .Dolares = Fila("Dolares")
                        .Usuario_Id = Fila("Usuario_Id")
                        .AplicaMora = Fila("AplicaMora")
                        .FechaCalculoMora = Fila("FechaCalculoMora")
                        .Batch_Id = Fila("Batch_Id")
                        .UltimaModificacion = Fila("UltimaModificacion")
                        .TipoNombre = Fila("NombreTipo")
                        .MontoAplicado = Fila("MontoAplica")
                    End With

                    _ListaAplicados.Add(CxCMovimiento)
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function RptCxCCobrosPorFechas(pDesde As DateTime, pHasta As DateTime) As String
        Dim Query As String

        Try


            Query = "exec RptCxCCobrosPorFechas " & Emp_Id & ",'" & pDesde.ToString("yyyyMMdd") & "','" & pHasta.ToString("yyyyMMdd") & "', " & Cliente_Id



            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function RptListaMovimientosAplicados() As String
        Dim Query As String

        Try
            Query = "exec RptListaMovimientos " & Emp_Id & ",'" & Tipo_Id & "','" & Mov_Id & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function RptCxCEstadoCuenta() As String
        Dim Query As String

        Try
            Query = "exec RptCxCEstadoCuenta " & _Emp_Id.ToString & "," & _Cliente_Id.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ObtieneListaMovimientos() As String
        Dim Query As String = ""

        Try
            Select Case _Tipo_Id
                Case Enum_CxCMovimientoTipo.Factura, Enum_CxCMovimientoTipo.NotaDebito, Enum_CxCMovimientoTipo.NotaDebitoXIntereses
                    Query = " select b.TipoAplica_Id" &
                            " ,b.MovAplica_Id" &
                            " ,d.Nombre" &
                            " ,b.Tipo_Id" &
                            " ,b.Mov_Id" &
                            " ,c.Nombre as TipoNombre" &
                            " ,b.Monto" &
                            " ,b.Fecha" &
                            " from  CxCMovimiento a," &
                            " CxCMovimientoAplica b," &
                            " CxCMovimientoTipo c," &
                            " CxCMovimientoTipo d" &
                            " where a.Emp_Id = b.Emp_Id" &
                            " and   a.Tipo_Id = b.Tipo_Id" &
                            " and   a.Mov_Id = b.Mov_Id" &
                            " and   a.Emp_Id = c.Emp_Id" &
                            " and   a.Tipo_Id = c.Tipo_Id" &
                            " and   b.Emp_Id = d.Emp_Id " &
                            " and   b.TipoAplica_Id = d.Tipo_Id" &
                            " and   b.Emp_Id = " & _Emp_Id.ToString &
                            " and   b.TipoAplica_Id = " & _Tipo_Id.ToString &
                            " and   b.MovAplica_Id= " & _Mov_Id.ToString
                Case Enum_CxCMovimientoTipo.Recibo, Enum_CxCMovimientoTipo.NotaCredito
                    Query = " select b.Tipo_Id" &
                            " ,b.Mov_Id as MovAplica_Id" &
                            " ,c.Nombre" &
                            " ,b.TipoAplica_Id" &
                            " ,b.MovAplica_Id AS Mov_Id" &
                            " ,d.Nombre  as TipoNombre" &
                            " ,b.Monto" &
                            " ,b.Fecha" &
                            " from  CxCMovimiento a," &
                            " CxCMovimientoAplica b," &
                            " CxCMovimientoTipo c," &
                            " CxCMovimientoTipo d" &
                            " where a.Emp_Id = b.Emp_Id" &
                            " and   a.Tipo_Id = b.Tipo_Id " &
                            " and   a.Mov_Id = b.Mov_Id" &
                            " and   a.Emp_Id = c.Emp_Id" &
                            " and   a.Tipo_Id = c.Tipo_Id" &
                            " and   b.Emp_Id = d.Emp_Id" &
                            " and   b.TipoAplica_Id = d.Tipo_Id" &
                            " and   a.Emp_Id  = " & _Emp_Id.ToString &
                            " and   b.Tipo_Id = " & _Tipo_Id.ToString &
                            " and   b.Mov_Id  = " & _Mov_Id.ToString
            End Select

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function AjusteFacturas(pSaldo As Double, pLista As DataTable) As String


        Try

            For Each row As DataRow In pLista.Rows

                With Me
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Tipo_Id = CInt(row(1).ToString())
                    .Cliente_Id = CInt(row(2).ToString())
                    .Referencia = "Ajuste de facturas automatico"
                    .Moneda = Moneda
                    .Monto = CInt(row(3).ToString())
                    .TipoCambio = 1
                    .Dolares = 0
                    .AplicaMora = 0
                    _ListaMovimientos = New List(Of TCxCMovimientoLinea)()
                    Dim movimientoTemporal As New TCxCMovimientoLinea()
                    With movimientoTemporal
                        .Monto = CInt(row(3).ToString())
                        .Emp_Id = _Emp_Id
                        .Mov_Id = CInt(row(0).ToString())
                        .Tipo_Id = CInt(row(4).ToString())
                    End With
                    _ListaMovimientos.Add(movimientoTemporal)
                    .MAC_Address = InfoMaquina.MAC_Address
                    .GeneraAsiento = False
                    .FechaRecibido = Today.Date()
                    .FechaDocumento = Today.Date()
                    .FechaVencimiento = Today.Date()
                    .Caja_Id = 0
                    .Cierre_Id = 0

                End With

                VerificaMensaje(Me.Insert)

            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function CargarFacturasConSaldo(pSaldo As Double) As String
        Dim Query As String

        Try
            Query = "SELECT m.Mov_id, " &
                       "CASE " &
                         " WHEN m.Tipo_Id = 1 THEN 'Factura' " &
                         " WHEN m.Tipo_Id = 4 THEN 'Nota debito' " &
                         " WHEN m.Tipo_Id = 5 THEN 'Nota credito' " &
                       " END          AS TipoNombre, " &
                       " m.Tipo_id, " &
                       " m.Referencia, " &
                       " m.FechaVencimiento, " &
                       " m.Monto, " &
                       " m.saldo AS saldo, " &
                       " CASE " &
                         " WHEN m.saldo > 0 THEN 5 " &
                         " ELSE 4 " &
                       " END          AS TipoAplica, " &
                       " m.Cliente_Id as Cliente " &
                    " FROM   cxcmovimiento m " &
                    " WHERE  m.saldo < " & pSaldo &
                           " AND m.saldo > 0 " &
                           " AND m.emp_id = " & Emp_Id

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function RptDocumentosVencidos(pVendedor_Id As Integer, pDesde As Date, pHasta As Date) As String
        Dim Query As String

        Try

            Query = "exec RptFacturasVencidasCSM  " & _Emp_Id.ToString & "," & pVendedor_Id.ToString() & ",'" & pDesde.ToString() & "','" & pHasta.ToString() & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ConsultaConsumoInterno() As String
        Dim Query As String

        Try

            Query = "exec CxC_ConsultaConsumoInterno  " & _Emp_Id.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


    Public Function ReporteConsumoInterno(pDesde As DateTime, pHasta As DateTime) As String
        Dim Query As String

        Try

            Query = "exec RptCxCConsumoInterno  " & _Emp_Id.ToString & " , '" & pDesde.ToString("yyyyMMdd") & "' , '" & pHasta.ToString("yyyyMMdd") & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            For Each Row As DataRow In _Resultado.Datos.Rows
                Dim palabras As String() = Row("Factura").ToString().Split(New Char() {"-"c})
                If palabras.Length = 2 Then
                    Row("Factura") = palabras(1)
                End If
            Next

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

#End Region
End Class