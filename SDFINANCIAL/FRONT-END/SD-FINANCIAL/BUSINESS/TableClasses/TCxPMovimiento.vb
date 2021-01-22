Public Class TCxPMovimiento
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Prov_Id As Integer
    Private _Estado_Id As Integer
    Private _Referencia As String
    Private _Fecha As DateTime
    Private _FechaRecibido As DateTime
    Private _FechaDocumento As DateTime
    Private _FechaVencimiento As DateTime
    Private _Moneda As Char
    Private _Monto As Double
    Private _Saldo As Double
    Private _TipoCambio As Double
    Private _Dolares As Integer
    Private _Usuario_Id As String
    Private _Batch_Id As Long
    Private _UltimaModificacion As DateTime
    Private _ListaAplicados As New List(Of TCxPMovimiento)
    Private _MontoAplicado As Double
    Private _TipoNombre As String
    Private _UsuarioNombre As String
    Private _ProveedorNombre As String
    Private _SaldoProveedor As Double
    Private _Encontro As Boolean
    Private _GeneraAsiento As Boolean
    Private _AsientoEncabezado As TAuxAsientoEncabezado
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCxPMovimiento
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
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
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
    Public Property Batch_Id() As Long
        Get
            Return _Batch_Id
        End Get
        Set(ByVal Value As Long)
            _Batch_Id = Value
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
    Public Property ListaAplicados As List(Of TCxPMovimiento)
        Get
            Return _ListaAplicados
        End Get
        Set(value As List(Of TCxPMovimiento))
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
    Public Property ProveedorNombre As String
        Get
            Return _ProveedorNombre
        End Get
        Set(value As String)
            _ProveedorNombre = value
        End Set
    End Property
    Public Property SaldoProveedor As Double
        Get
            Return _SaldoProveedor
        End Get
        Set(value As Double)
            _SaldoProveedor = value
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
    Public ReadOnly Property Encontro As Boolean
        Get
            Return _Encontro
        End Get
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
        _Prov_Id = 0
        _Estado_Id = 0
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
        _Batch_Id = 0
        _UltimaModificacion = CDate("1900/01/01")
        _TipoNombre = ""
        _UsuarioNombre = ""
        _ProveedorNombre = ""
        _SaldoProveedor = 0.0
        _Encontro = False
        _GeneraAsiento = False
        _AsientoEncabezado = New TAuxAsientoEncabezado
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Detalle As SDFinancial.DTAuxAsientoDetalle
        Dim Lista As New List(Of SDFinancial.DTAuxAsientoDetalle)

        Try
            For Each Item As TAuxAsientoDetalle In _AsientoEncabezado.ListaDetalle
                Detalle = New SDFinancial.DTAuxAsientoDetalle

                With Detalle
                    .Emp_Id = Item.Emp_Id
                    .Asiento_Id = Item.Asiento_Id
                    .Linea_Id = Item.Linea_Id
                    .Fecha = Item.Fecha
                    .Moneda = Item.Moneda
                    .CC_Id = Item.CC_Id
                    .Cuenta_Id = Item.Cuenta_Id
                    .Tipo = Item.Tipo
                    .Monto = Item.Monto
                    .MontoDolares = Item.MontoDolares
                    .TipoCambio = Item.TipoCambio
                    .Referencia = Item.Referencia
                    .Descripcion = Item.Descripcion
                End With

                Lista.Add(Detalle)
            Next

            _DTabla.AsientoEncabezado = New SDFinancial.DTAuxAsientoEncabezado

            With _DTabla.AsientoEncabezado
                .Emp_Id = _AsientoEncabezado.Emp_Id
                .Asiento_Id = _AsientoEncabezado.Asiento_Id
                .Annio = _AsientoEncabezado.Annio
                .Mes = _AsientoEncabezado.Mes
                .Fecha = _AsientoEncabezado.Fecha
                .Tipo_Id = _AsientoEncabezado.Tipo_Id
                .Comentario = _AsientoEncabezado.Comentario
                .Debitos = _AsientoEncabezado.Debitos
                .Creditos = _AsientoEncabezado.Creditos
                .Usuario_Id = _AsientoEncabezado.Usuario_Id
                .Origen_Id = _AsientoEncabezado.Origen_Id
                .MAC_Address = _AsientoEncabezado.MAC_Address
                .ListaDetalle = Lista.ToArray
            End With

            With _DTabla
                .Emp_Id = _Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Prov_Id = _Prov_Id
                .Estado_Id = _Estado_Id
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
                .GeneraAsiento = _GeneraAsiento
            End With

            _Resultado = _SDWCF.CxPMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If IsNumeric(_Resultado.Valor.Trim) Then
                _Mov_Id = CLng(_Resultado.Valor)
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

            _Resultado = _SDWCF.CxPMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Prov_Id = _Prov_Id
                .Estado_Id = _Estado_Id
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
            End With

            _Resultado = _SDWCF.CxPMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Try
            _Encontro = False

            With _DTabla
                .Emp_Id = _Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
            End With

            _Resultado = _SDWCF.CxPMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Tipo_Id = _Resultado.Datos.Rows(0).Item("Tipo_Id")
                _Mov_Id = _Resultado.Datos.Rows(0).Item("Mov_Id")
                _Prov_Id = _Resultado.Datos.Rows(0).Item("Prov_Id")
                _Estado_Id = _Resultado.Datos.Rows(0).Item("Estado_Id")
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
                _Batch_Id = _Resultado.Datos.Rows(0).Item("Batch_Id")
                _UltimaModificacion = _Resultado.Datos.Rows(0).Item("UltimaModificacion")
                _TipoNombre = _Resultado.Datos.Rows(0).Item("NombreTipo")
                _UsuarioNombre = _Resultado.Datos.Rows(0).Item("NombreUsuario")
                _ProveedorNombre = _Resultado.Datos.Rows(0).Item("NombreProveedor")
                _SaldoProveedor = _Resultado.Datos.Rows(0).Item("SaldoProveedor")
            End If

            _Encontro = True

            VerificaMensaje(ObtieneListaAplicados)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.CxPMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.CxPMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.CxPMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.CxPMovimientoMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

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
    Public Function MovimientosProveedor(pTipo As Integer) As String
        Dim Query As String

        Try
            Query = "select a.*, b.Nombre as TipoNombre, b.IncrementaSaldo" & _
                    " from CxPMovimiento a, CxPMovimientoTipo b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.Tipo_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString() & _
                    " and   a.Prov_Id = " & _Prov_Id.ToString()

            Select Case pTipo
                Case 1
                    Query += " and   a.Saldo > 0" & _
                             " and   a.Estado_Id = 1" & _
                             " and   b.IncrementaSaldo = 1"
                Case 2
                    Query += " and   a.Saldo > 0" & _
                             " and   a.Estado_Id = 2" & _
                             " and   b.IncrementaSaldo = 1"
                Case 3
                    Query += " and   b.IncrementaSaldo = 1"
                Case 4
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
    Public Function MovimientosProveedorPago() As String
        Dim Query As String

        Try
            Query = "select a.*, b.Nombre as TipoNombre" & _
                    " from CxPMovimiento a, CxPMovimientoTipo b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.Tipo_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString & _
                    " and   a.Prov_Id = " & _Prov_Id.ToString & _
                    " and   a.Estado_Id = " & Enum_CxPMovimientoEstado.Pendiente & _
                    " and   a.Tipo_Id In (1,4,6)" & _
                    " and   a.Saldo > 0" & _
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
    Public Function MovimientosProveedorProcesoPago() As String
        Dim Query As String

        Try
            Query = "select a.*" & _
                    " ,b.Nombre as TipoNombre" & _
                    " ,c.Moneda as MonedaSolicitud" & _
                    " ,c.TipoCambio as TCambio" & _
                    " ,c.Dolares as DolaresSolicitud" & _
                    " ,c.Monto as MontoPagar" & _
                    " from CxPMovimiento a " & _
                    " ,CxPMovimientoTipo b" & _
                    " ,CxPSolicitudPago c" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.Tipo_Id" & _
                    " and   a.Emp_Id = c.Emp_Id" & _
                    " and   a.Tipo_Id = c.Tipo_Id" & _
                    " and   a.Mov_Id = c.Mov_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString & _
                    " and   a.Prov_Id = " & _Prov_Id.ToString & _
                    " and   a.Estado_Id = " & Enum_CxPMovimientoEstado.EnProceso & _
                    " and   a.Tipo_Id In (1,4,6)" & _
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
    Public Function ObtieneListaAplicados() As String
        Dim Query As String
        Dim CxPMovimiento As TCxPMovimiento

        Try
            _ListaAplicados.Clear()

            Query = "select b.*" & _
                    " ,c.Nombre as NombreTipo" & _
                    " ,a.Monto as MontoAplica" & _
                    " from CxPMovimientoAplica a" & _
                    " ,CxPMovimiento b" & _
                    " ,CxPMovimientoTipo c" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.TipoAplica_Id = b.Tipo_Id" & _
                    " and   a.MovAplica_Id = b.Mov_Id" & _
                    " and   a.Emp_Id = c.Emp_Id" & _
                    " and   a.TipoAplica_Id = c.Tipo_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString & _
                    " and   a.Tipo_Id = " & _Tipo_Id.ToString & _
                    " and   a.Mov_Id = " & _Mov_Id.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    CxPMovimiento = New TCxPMovimiento

                    With CxPMovimiento
                        .Emp_Id = Fila("Emp_Id")
                        .Tipo_Id = Fila("Tipo_Id")
                        .Mov_Id = Fila("Mov_Id")
                        .Prov_Id = Fila("Prov_Id")
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
                        .Batch_Id = Fila("Batch_Id")
                        .UltimaModificacion = Fila("UltimaModificacion")
                        .TipoNombre = Fila("NombreTipo")
                        .MontoAplicado = Fila("MontoAplica")
                    End With

                    _ListaAplicados.Add(CxPMovimiento)
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function RptDocumentosProximosVencer() As String
        Dim Query As String

        Try
            Query = "exec RptCxPDocumentosProximosVencer " & _Emp_Id.ToString & "," & _Prov_Id.ToString & _
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
    Public Function RptCxPEstadoCuenta() As String
        Dim Query As String

        Try
            Query = "exec RptCxPEstadoCuenta " & _Emp_Id.ToString & "," & _Prov_Id.ToString

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

    Public Function RptCxPEstadoCuentaPorProveedor(pDesde As Date, pHasta As Date) As String
        Dim Query As String

        Try
            Query = "exec RptCxPEstadoCuentaPorProveedor " & _Emp_Id.ToString & "," & _Prov_Id.ToString & ",'" & pDesde.ToString("yyyyMMdd") & "','" & pHasta.ToString("yyyyMMdd") & "'"

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

    Public Function RptCxPTotalAdeudado() As String
        Dim Query As String

        Try
            Query = "exec RptCxPTotalAdeudado " & _Emp_Id.ToString & "," & _Prov_Id.ToString()

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
                Case Enum_CxPMovimientoTipo.Factura, Enum_CxPMovimientoTipo.NotaDebito
                    Query = " select b.TipoAplica_Id" & _
                            " ,b.MovAplica_Id" & _
                            " ,d.Nombre" & _
                            " ,b.Tipo_Id" & _
                            " ,b.Mov_Id" & _
                            " ,c.Nombre as TipoNombre" & _
                            " ,b.Monto" & _
                            " ,b.Fecha" & _
                            " from  CxPMovimiento a," & _
                            " CxPMovimientoAplica b," & _
                            " CxPMovimientoTipo c," & _
                            " CxPMovimientoTipo d" & _
                            " where a.Emp_Id = b.Emp_Id" & _
                            " and   a.Tipo_Id = b.Tipo_Id" & _
                            " and   a.Mov_Id = b.Mov_Id" & _
                            " and   a.Emp_Id = c.Emp_Id" & _
                            " and   a.Tipo_Id = c.Tipo_Id" & _
                            " and   b.Emp_Id = d.Emp_Id " & _
                            " and   b.TipoAplica_Id = d.Tipo_Id" & _
                            " and   b.Emp_Id = " & _Emp_Id.ToString & _
                            " and   b.TipoAplica_Id = " & _Tipo_Id.ToString & _
                            " and   b.MovAplica_Id= " & _Mov_Id.ToString
                Case Enum_CxPMovimientoTipo.Pago, Enum_CxPMovimientoTipo.NotaCredito
                    Query = " select b.Tipo_Id" & _
                            " ,b.Mov_Id" & _
                            " ,c.Nombre" & _
                            " ,b.TipoAplica_Id" & _
                            " ,b.MovAplica_Id" & _
                            " ,d.Nombre  as TipoNombre" & _
                            " ,b.Monto" & _
                            " ,b.Fecha" & _
                            " from  CxPMovimiento a," & _
                            " CxPMovimientoAplica b," & _
                            " CxPMovimientoTipo c," & _
                            " CxPMovimientoTipo d" & _
                            " where a.Emp_Id = b.Emp_Id" & _
                            " and   a.Tipo_Id = b.Tipo_Id " & _
                            " and   a.Mov_Id = b.Mov_Id" & _
                            " and   a.Emp_Id = c.Emp_Id" & _
                            " and   a.Tipo_Id = c.Tipo_Id" & _
                            " and   b.Emp_Id = d.Emp_Id" & _
                            " and   b.TipoAplica_Id = d.Tipo_Id" & _
                            " and   a.Emp_Id  = " & _Emp_Id.ToString & _
                            " and   b.Tipo_Id = " & _Tipo_Id.ToString & _
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
    Public Function ObtieneMontoMora(ByRef pMora As Double) As String
        Dim Query As String

        Try
            Query = " select ISNULL(SUM(Saldo),0) as MontoMora" & _
                    " from CxPMovimiento" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Tipo_Id = " & _Tipo_Id.ToString & _
                    " and   Prov_Id = " & _Prov_Id.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                pMora = CDbl(_Resultado.Datos(0).Item("MontoMora"))
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ObtieneMontoPagando(ByRef pMonto As Double) As String
        Dim Query As String

        Try
            Query = " select ISNULL(SUM(a.Monto),0) as MontoPagando" & _
                    " from CxPSolicitudPago a" & _
                    " where a.Emp_Id = " & _Emp_Id.ToString & _
                    " and   a.Prov_Id = " & _Prov_Id.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                pMonto = CDbl(_Resultado.Datos(0).Item("MontoPagando"))
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function MovimientosAplicados() As String
        Dim Query As String

        Try
            Query = " select a.Tipo_Id" & _
                    " ,a.Mov_Id" & _
                    " ,a.Moneda" & _
                    " ,b.Monto" & _
                    " from CxPMovimiento a" & _
                    " ,CxPMovimientoAplica b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.TipoAplica_Id" & _
                    " and   a.Mov_Id = b.MovAplica_Id" & _
                    " and   b.Emp_Id = " & _Emp_Id.ToString & _
                    " and   b.Tipo_Id = " & _Tipo_Id.ToString & _
                    " and   b.Mov_Id = " & _Mov_Id.ToString & _
                    " order by a.Moneda"

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
    Public Function ObtieneCuentaContable() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Query = " select d.CuentaContable" & _
                    " from CxPMovimiento a" & _
                    " ,BcoPagoDetalle b" & _
                    " ,BcoPago c" & _
                    " ,EmpresaCuenta d" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.Tipo_Id" & _
                    " and   a.Mov_Id = b.Mov_Id" & _
                    " and   b.Emp_Id = c.Emp_Id" & _
                    " and   b.BcoPago_Id = c.BcoPago_Id" & _
                    " and   c.Emp_Id = d.Emp_Id" & _
                    " and   c.Cuenta = d.Cuenta" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString & _
                    " and   a.Tipo_Id = " & _Tipo_Id.ToString & _
                    " and   a.Mov_Id = " & _Mov_Id.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Tabla = _Resultado.Datos
            Tabla.TableName = "Cuenta"

            If Datos.Tables.Contains(Tabla.TableName) Then
                Datos.Tables.Remove(Tabla.TableName)
            End If

            Datos.Tables.Add(Tabla)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class