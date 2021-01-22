Public Class TTipoCambio
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _TipoCambio_Id As Integer
    Private _Fecha As Datetime
    Private _Compra As Double
    Private _Venta As Double
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTTipoCambio
    Private _Resultado As New SDFinancial.TResultado
#End Region
#Region "Definicion de propiedades"
    Public Property TipoCambio_Id() As Integer
        Get
            Return _TipoCambio_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoCambio_Id = Value
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
    Public Property Compra() As Double
        Get
            Return _Compra
        End Get
        Set(ByVal Value As Double)
            _Compra = Value
        End Set
    End Property
    Public Property Venta() As Double
        Get
            Return _Venta
        End Get
        Set(ByVal Value As Double)
            _Venta = Value
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
        _TipoCambio_Id = 0
        _Fecha = CDate("1900/01/01")
        _Compra = 0.0
        _Venta = 0.0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Fecha = _Fecha
                .Compra = _Compra
                .Venta = _Venta
            End With

            _Resultado = _SDWCF.TipoCambioMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .TipoCambio_Id = _TipoCambio_Id
            End With

            _Resultado = _SDWCF.TipoCambioMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .TipoCambio_Id = _TipoCambio_Id
                .Fecha = _Fecha
                .Compra = _Compra
                .Venta = _Venta
            End With

            _Resultado = _SDWCF.TipoCambioMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Try
            _Resultado = _SDWCF.TipoCambioMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _Compra = _Resultado.Datos.Rows(0).Item("Compra")
                _Venta = _Resultado.Datos.Rows(0).Item("Venta")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.TipoCambioMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.TipoCambioMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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
            _Resultado = _SDWCF.TipoCambioMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
            _Resultado = _SDWCF.TipoCambioMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _TipoCambio_Id = _Resultado.Datos.Rows(0).Item("TipoCambio_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ActualizaTipoCambio() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Query = " select * from TipoCambio where TipoCambio_Id = (select MAX(TipoCambio_Id) from TipoCambio)"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Tabla = _Resultado.Datos

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                If Tabla.Rows(0).Item("Compra") <> _Compra OrElse Tabla.Rows(0).Item("Venta") <> _Venta Then
                    VerificaMensaje(Insert)
                    'Cambia Precios Articulos
                    _Resultado = _SDWCF.ExecuteQuery("exec RecalculaPrecioMoneda", String.Empty)
                End If
            Else
                VerificaMensaje(Insert)
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ListBusqueda(pTipoBusqueda As Char, pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String

        Try
            Query = " select Fecha" & _
                    " ,Compra" & _
                    " ,Venta" & _
                    " from TipoCambio"

            If pTipoBusqueda = "F" Then
                Query += " where Fecha >= '" & Format(pFechaIni, "yyyyMMdd") & "'" & _
                         " and   Fecha < '" & Format(pFechaFin, "yyyyMMdd") & "'"
            End If

            Query += " order by Fecha desc"

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
    Public Function TipoCambioCxP(ByRef pMonto As Double) As String
        Dim Query As String

        Try
            Query = " select dbo.FnTipoCambioCxP()"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos Is Nothing OrElse _Resultado.Datos.Rows.Count = 0 Then
                VerificaMensaje("No se encontró ningun valor definido para el tipo de cambio")
            End If

            pMonto = _Resultado.Datos.Rows(0).Item(0)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function TipoCambioCxC(ByRef pMonto As Double) As String
        Dim Query As String

        Try
            Query = " select dbo.FnTipoCambioCxC()"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos Is Nothing OrElse _Resultado.Datos.Rows.Count = 0 Then
                VerificaMensaje("No se encontró ningun valor definido para el tipo de cambio")
            End If

            pMonto = _Resultado.Datos.Rows(0).Item(0)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function TipoCambioBancos(ByRef pMonto As Double) As String
        Dim Query As String

        Try
            Query = " select dbo.FnTipoCambioBancos()"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos Is Nothing OrElse _Resultado.Datos.Rows.Count = 0 Then
                VerificaMensaje("No se encontró ningun valor definido para el tipo de cambio")
            End If

            pMonto = _Resultado.Datos.Rows(0).Item(0)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function TipoCambioContabilidad(ByRef pMonto As Double) As String
        Dim Query As String

        Try
            Query = " select dbo.FnTipoCambioContabilidad()"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos Is Nothing OrElse _Resultado.Datos.Rows.Count = 0 Then
                VerificaMensaje("No se encontró ningun valor definido para el tipo de cambio")
            End If

            pMonto = _Resultado.Datos.Rows(0).Item(0)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class