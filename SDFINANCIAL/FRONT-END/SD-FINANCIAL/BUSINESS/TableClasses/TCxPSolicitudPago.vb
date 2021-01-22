Public Class TCxPSolicitudPago
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Solicitud_Id As Long
    Private _Prov_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Fecha As Datetime
    Private _Monto As Double
    Private _Moneda As Char
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Usuario_Id As String
    Private _UltimaModificacion As DateTime
    Private _PagoMonto As Double
    Private _PagoDolares As Double
    Private _Diferencial As Double
    Private _ListaMovimientos As New List(Of TCxPMovimientoLinea)
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCxPSolicitudPago
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
    Public Property Solicitud_Id() As Long
        Get
            Return _Solicitud_Id
        End Get
        Set(ByVal Value As Long)
            _Solicitud_Id = Value
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
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
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
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
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
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
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
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public Property PagoMonto As Double
        Get
            Return _PagoMonto
        End Get
        Set(value As Double)
            _PagoMonto = value
        End Set
    End Property
    Public Property PagoDolares As Double
        Get
            Return _PagoDolares
        End Get
        Set(value As Double)
            _PagoDolares = value
        End Set
    End Property
    Public Property Diferencial As Double
        Get
            Return _Diferencial
        End Get
        Set(value As Double)
            _Diferencial = value
        End Set
    End Property
    Public Property ListaMovimientos As List(Of TCxPMovimientoLinea)
        Get
            Return _ListaMovimientos
        End Get
        Set(value As List(Of TCxPMovimientoLinea))
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
        _Solicitud_Id = 0
        _Prov_Id = 0
        _Tipo_Id = 0
        _Mov_Id = 0
        _Fecha = CDate("1900/01/01")
        _Monto = 0.0
        _Moneda = ""
        _TipoCambio = 0.0
        _Dolares = 0.0
        _Usuario_Id = ""
        _UltimaModificacion = CDate("1900/01/01")
        _PagoMonto = 0
        _PagoDolares = 0
        _Diferencial = 0.0
        _ListaMovimientos.Clear()
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim DetalleMov As SDFinancial.DTCxPMovimientoLinea
        Dim ListaMov As New List(Of SDFinancial.DTCxPMovimientoLinea)

        Try
            For Each Item As TCxPMovimientoLinea In _ListaMovimientos
                DetalleMov = New SDFinancial.DTCxPMovimientoLinea

                With DetalleMov
                    .Emp_Id = Item.Emp_Id
                    .Tipo_Id = Item.Tipo_Id
                    .Mov_Id = Item.Mov_Id
                    .Moneda = Item.Moneda
                    .Monto = Item.Monto
                    .TipoCambio = Item.TipoCambio
                    .Dolares = Item.Dolares
                End With

                ListaMov.Add(DetalleMov)
            Next

            With _DTabla
                .Emp_Id = _Emp_Id
                .Prov_Id = _Prov_Id
                .Usuario_Id = _Usuario_Id
                .ListaMovimientos = ListaMov.ToArray
            End With

            _Resultado = _SDWCF.CxPSolicitudPagoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function Delete() As String
        Dim DetalleMov As SDFinancial.DTCxPMovimientoLinea
        Dim ListaMov As New List(Of SDFinancial.DTCxPMovimientoLinea)

        Try
            For Each Item As TCxPMovimientoLinea In _ListaMovimientos
                DetalleMov = New SDFinancial.DTCxPMovimientoLinea

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
                .Usuario_Id = _Usuario_Id
                .ListaMovimientos = ListaMov.ToArray
            End With

            _Resultado = _SDWCF.CxPSolicitudPagoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Solicitud_Id = _Solicitud_Id
                .Prov_Id = _Prov_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Fecha = _Fecha
                .Monto = _Monto
                .Moneda = _Moneda
                .TipoCambio = _TipoCambio
                .Dolares = _Dolares
                .Usuario_Id = _Usuario_Id
            End With

            _Resultado = _SDWCF.CxPSolicitudPagoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Solicitud_Id = _Solicitud_Id
            End With

            _Resultado = _SDWCF.CxPSolicitudPagoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Solicitud_Id = _Resultado.Datos.Rows(0).Item("Solicitud_Id")
                _Prov_Id = _Resultado.Datos.Rows(0).Item("Prov_Id")
                _Tipo_Id = _Resultado.Datos.Rows(0).Item("Tipo_Id")
                _Mov_Id = _Resultado.Datos.Rows(0).Item("Mov_Id")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _Monto = _Resultado.Datos.Rows(0).Item("Monto")
                _Moneda = _Resultado.Datos.Rows(0).Item("Moneda")
                _TipoCambio = _Resultado.Datos.Rows(0).Item("TipoCambio")
                _Dolares = _Resultado.Datos.Rows(0).Item("Dolares")
                _Usuario_Id = _Resultado.Datos.Rows(0).Item("Usuario_Id")
                _UltimaModificacion = _Resultado.Datos.Rows(0).Item("UltimaModificacion")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.CxPSolicitudPagoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            With _DTabla
                .Emp_Id = _Emp_Id
            End With

            _Resultado = _SDWCF.CxPSolicitudPagoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.CxPSolicitudPagoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
            End With

            _Resultado = _SDWCF.CxPSolicitudPagoMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Solicitud_Id = _Resultado.Datos.Rows(0).Item("CxPSolicitudPago_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function CxPSolicitudesPagoPendientes() As String
        Dim Query As String

        Try
            Query = "exec CxPSolicitudesPagoPendientes " & _Emp_Id.ToString & "," & _Prov_Id.ToString()

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
    Public Function RptSolicitudTransferencia(pSolicitudes As List(Of TCxPSolicitudPago)) As String
        Dim Query As String
        Dim Contador As Integer = 1

        Try
            Query = " select b.Nombre as Tipo" & _
                    " ,'#' + CAST(a.Mov_Id as varchar(10)) + IIf(c.Referencia <> '',' Referencia: ' +  c.Referencia, '') as Referencia" & _
                    " ,a.Monto" & _
                    " from CxPSolicitudPago a" & _
                    " ,CxPMovimientoTipo b" & _
                    " ,CxPMovimiento c" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.Tipo_Id" & _
                    " and   a.Emp_Id = c.Emp_Id" & _
                    " and   a.Tipo_Id = c.Tipo_Id" & _
                    " and   a.Mov_Id = c.Mov_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString & _
                    " and   a.Solicitud_Id IN ("

            For Each Item As TCxPSolicitudPago In pSolicitudes
                Query += Item.Solicitud_Id & IIf(Contador = pSolicitudes.Count, ")", ",")
                Contador += 1
            Next

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
#End Region
End Class