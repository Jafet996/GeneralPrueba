Public Class TCajaCierreEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Usuario_Id As String
    Private _Cerrado As Integer
    Private _FechaCierre As Datetime
    Private _FechaApertura As Datetime
    Private _Efectivo As Double
    Private _Tarjeta As Double
    Private _Cheque As Double
    Private _Dolares As Double
    Private _Fondo As Double
    Private _Transferencia As Double
    Private _Deposito As Double
    Private _CajeroEfectivo As Double
    Private _CajeroTarjeta As Double
    Private _CajeroCheque As Double
    Private _CajeroDocumentos As Double
    Private _CajeroDolares As Double
    Private _TipoCambio As Double
    Private _UltimaModificacion As DateTime
    Private _UsuarioNombre As String
    Private _ListaMovimientos As New List(Of TCxCMovimiento)
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCajaCierreEncabezado
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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public Property Cerrado() As Integer
        Get
            Return _Cerrado
        End Get
        Set(ByVal Value As Integer)
            _Cerrado = Value
        End Set
    End Property
    Public Property FechaCierre() As Datetime
        Get
            Return _FechaCierre
        End Get
        Set(ByVal Value As Datetime)
            _FechaCierre = Value
        End Set
    End Property
    Public Property FechaApertura() As Datetime
        Get
            Return _FechaApertura
        End Get
        Set(ByVal Value As Datetime)
            _FechaApertura = Value
        End Set
    End Property
    Public Property Efectivo() As Double
        Get
            Return _Efectivo
        End Get
        Set(ByVal Value As Double)
            _Efectivo = Value
        End Set
    End Property
    Public Property Tarjeta() As Double
        Get
            Return _Tarjeta
        End Get
        Set(ByVal Value As Double)
            _Tarjeta = Value
        End Set
    End Property
    Public Property Cheque() As Double
        Get
            Return _Cheque
        End Get
        Set(ByVal Value As Double)
            _Cheque = Value
        End Set
    End Property
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
        End Set
    End Property
    Public Property Fondo() As Double
        Get
            Return _Fondo
        End Get
        Set(ByVal Value As Double)
            _Fondo = Value
        End Set
    End Property
    Public Property Transferencia() As Double
        Get
            Return _Transferencia
        End Get
        Set(ByVal Value As Double)
            _Transferencia = Value
        End Set
    End Property
    Public Property Deposito() As Double
        Get
            Return _Deposito
        End Get
        Set(ByVal Value As Double)
            _Deposito = Value
        End Set
    End Property
    Public Property CajeroEfectivo() As Double
        Get
            Return _CajeroEfectivo
        End Get
        Set(ByVal Value As Double)
            _CajeroEfectivo = Value
        End Set
    End Property
    Public Property CajeroTarjeta() As Double
        Get
            Return _CajeroTarjeta
        End Get
        Set(ByVal Value As Double)
            _CajeroTarjeta = Value
        End Set
    End Property
    Public Property CajeroCheque() As Double
        Get
            Return _CajeroCheque
        End Get
        Set(ByVal Value As Double)
            _CajeroCheque = Value
        End Set
    End Property
    Public Property CajeroDocumentos() As Double
        Get
            Return _CajeroDocumentos
        End Get
        Set(ByVal Value As Double)
            _CajeroDocumentos = Value
        End Set
    End Property
    Public Property CajeroDolares() As Double
        Get
            Return _CajeroDolares
        End Get
        Set(ByVal Value As Double)
            _CajeroDolares = Value
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
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
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
    Public Property ListaMovimientos As List(Of TCxCMovimiento)
        Get
            Return _ListaMovimientos
        End Get
        Set(value As List(Of TCxCMovimiento))
            _ListaMovimientos = value
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
        _Caja_Id = 0
        _Cierre_Id = 0
        _Usuario_Id = ""
        _Cerrado = 0
        _FechaCierre = CDate("1900/01/01")
        _FechaApertura = CDate("1900/01/01")
        _Efectivo = 0.0
        _Tarjeta = 0.0
        _Cheque = 0.0
        _Dolares = 0.0
        _Fondo = 0.0
        _Transferencia = 0.0
        _Deposito = 0.0
        _CajeroEfectivo = 0.0
        _CajeroTarjeta = 0.0
        _CajeroCheque = 0.0
        _CajeroDocumentos = 0.0
        _CajeroDolares = 0.0
        _TipoCambio = 0.0
        _UltimaModificacion = CDate("1900/01/01")
        _UsuarioNombre = ""
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Caja_Id = _Caja_Id
                .Cierre_Id = _Cierre_Id
                .Usuario_Id = _Usuario_Id
                .Cerrado = _Cerrado
                .FechaCierre = _FechaCierre
                .FechaApertura = _FechaApertura
                .Efectivo = _Efectivo
                .Tarjeta = _Tarjeta
                .Cheque = _Cheque
                .Dolares = _Dolares
                .Fondo = _Fondo
                .Transferencia = _Transferencia
                .Deposito = _Deposito
                .CajeroEfectivo = _CajeroEfectivo
                .CajeroTarjeta = _CajeroTarjeta
                .CajeroCheque = _CajeroCheque
                .CajeroDocumentos = _CajeroDocumentos
                .CajeroDolares = _CajeroDolares
                .TipoCambio = _TipoCambio
            End With

            _Resultado = _SDWCF.CajaCierreEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function Delete() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Caja_Id = _Caja_Id
                .Cierre_Id = _Cierre_Id
            End With

            _Resultado = _SDWCF.CajaCierreEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Caja_Id = _Caja_Id
                .Cierre_Id = _Cierre_Id
                .Usuario_Id = _Usuario_Id
                .Cerrado = _Cerrado
                .FechaCierre = _FechaCierre
                .FechaApertura = _FechaApertura
                .Efectivo = _Efectivo
                .Tarjeta = _Tarjeta
                .Cheque = _Cheque
                .Dolares = _Dolares
                .Fondo = _Fondo
                .Transferencia = _Transferencia
                .Deposito = _Deposito
                .CajeroEfectivo = _CajeroEfectivo
                .CajeroTarjeta = _CajeroTarjeta
                .CajeroCheque = _CajeroCheque
                .CajeroDocumentos = _CajeroDocumentos
                .CajeroDolares = _CajeroDolares
                .TipoCambio = _TipoCambio
            End With

            _Resultado = _SDWCF.CajaCierreEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Caja_Id = _Caja_Id
                .Cierre_Id = _Cierre_Id
            End With

            _Resultado = _SDWCF.CajaCierreEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Caja_Id = _Resultado.Datos.Rows(0).Item("Caja_Id")
                _Cierre_Id = _Resultado.Datos.Rows(0).Item("Cierre_Id")
                _Usuario_Id = _Resultado.Datos.Rows(0).Item("Usuario_Id")
                _Cerrado = _Resultado.Datos.Rows(0).Item("Cerrado")
                _FechaCierre = _Resultado.Datos.Rows(0).Item("FechaCierre")
                _FechaApertura = _Resultado.Datos.Rows(0).Item("FechaApertura")
                _Efectivo = _Resultado.Datos.Rows(0).Item("Efectivo")
                _Tarjeta = _Resultado.Datos.Rows(0).Item("Tarjeta")
                _Cheque = _Resultado.Datos.Rows(0).Item("Cheque")
                _Dolares = _Resultado.Datos.Rows(0).Item("Dolares")
                _Fondo = _Resultado.Datos.Rows(0).Item("Fondo")
                _Transferencia = _Resultado.Datos.Rows(0).Item("Transferencia")
                _Deposito = _Resultado.Datos.Rows(0).Item("Deposito")
                _CajeroEfectivo = _Resultado.Datos.Rows(0).Item("CajeroEfectivo")
                _CajeroTarjeta = _Resultado.Datos.Rows(0).Item("CajeroTarjeta")
                _CajeroCheque = _Resultado.Datos.Rows(0).Item("CajeroCheque")
                _CajeroDocumentos = _Resultado.Datos.Rows(0).Item("CajeroDocumentos")
                _CajeroDolares = _Resultado.Datos.Rows(0).Item("CajeroDolares")
                _TipoCambio = _Resultado.Datos.Rows(0).Item("TipoCambio")
                _UltimaModificacion = _Resultado.Datos.Rows(0).Item("UltimaModificacion")
                _UsuarioNombre = _Resultado.Datos.Rows(0).Item("NombreUsuario")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.CajaCierreEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.CajaCierreEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.CajaCierreEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
                .Caja_Id = _Caja_Id
            End With

            _Resultado = _SDWCF.CajaCierreEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Cierre_Id = _Resultado.Datos.Rows(0).Item("CajaCierreEncabezado_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function CierreCajaApertura() As String
        Dim Query As String

        Try
            Query = "exec CierreCajaApertura " & _Emp_Id.ToString & "," & _Caja_Id.ToString & ",'" & _Usuario_Id & "'," & _Fondo.ToString()

            _Resultado = _SDWCF.ExecuteQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ObtieneMovimientos() As String
        Dim Query As String
        Dim Movimiento As TCxCMovimiento

        Try
            Query = "select a.Emp_Id" & _
                    " ,a.Tipo_Id" & _
                    " ,b.Nombre as NombreTipo" & _
                    " ,a.Mov_Id" & _
                    " ,a.Monto" & _
                    " from CxCMovimiento a" & _
                    " ,CxCMovimientoTipo b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.Tipo_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString & _
                    " and   a.Caja_Id = " & _Caja_Id.ToString & _
                    " and   a.Cierre_Id = " & _Cierre_Id.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            For Each Fila As DataRow In _Resultado.Datos.Rows
                Movimiento = New TCxCMovimiento

                With Movimiento
                    .Emp_Id = Fila("Emp_Id")
                    .Tipo_Id = Fila("Tipo_Id")
                    .TipoNombre = Fila("NombreTipo")
                    .Mov_Id = Fila("Mov_Id")
                    .Monto = Fila("Monto")
                End With

                _ListaMovimientos.Add(Movimiento)
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class