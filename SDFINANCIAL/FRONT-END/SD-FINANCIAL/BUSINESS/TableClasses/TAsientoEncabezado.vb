Imports System.Windows.Forms

Public Class TAsientoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Asiento_Id As Long
    Private _Annio As Integer
    Private _Mes As Integer
    Private _Fecha As DateTime
    Private _Tipo_Id As Integer
    Private _Comentario As String
    Private _Estado_Id As Integer
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Usuario_Id As String
    Private _UsuarioAplica_Id As String
    Private _Origen_Id As Integer
    Private _ListaDetalle As New List(Of TAsientoDetalle)
    Private _ListaErrores As New List(Of String)
    Private _AplicarAsiento As Boolean
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTAsientoEncabezado
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
    Public Property Asiento_Id() As Long
        Get
            Return _Asiento_Id
        End Get
        Set(ByVal Value As Long)
            _Asiento_Id = Value
        End Set
    End Property
    Public Property Annio() As Integer
        Get
            Return _Annio
        End Get
        Set(ByVal Value As Integer)
            _Annio = Value
        End Set
    End Property
    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal Value As Integer)
            _Mes = Value
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
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
    Public Property Estado_Id() As Integer
        Get
            Return _Estado_Id
        End Get
        Set(ByVal Value As Integer)
            _Estado_Id = Value
        End Set
    End Property
    Public Property Debitos() As Double
        Get
            Return _Debitos
        End Get
        Set(ByVal Value As Double)
            _Debitos = Value
        End Set
    End Property
    Public Property Creditos() As Double
        Get
            Return _Creditos
        End Get
        Set(ByVal Value As Double)
            _Creditos = Value
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
    Public Property UsuarioAplica_Id() As String
        Get
            Return _UsuarioAplica_Id
        End Get
        Set(ByVal Value As String)
            _UsuarioAplica_Id = Value
        End Set
    End Property
    Public Property Origen_Id() As Integer
        Get
            Return _Origen_Id
        End Get
        Set(ByVal Value As Integer)
            _Origen_Id = Value
        End Set
    End Property
    Public Property ListaDetalle As List(Of TAsientoDetalle)
        Get
            Return _ListaDetalle
        End Get
        Set(value As List(Of TAsientoDetalle))
            _ListaDetalle = value
        End Set
    End Property
    Public ReadOnly Property ListaErrores As List(Of String)
        Get
            Return _ListaErrores
        End Get
    End Property
    Public Property AplicarAsiento As Boolean
        Get
            Return _AplicarAsiento
        End Get
        Set(value As Boolean)
            _AplicarAsiento = value
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
        _Asiento_Id = 0
        _Annio = 0
        _Mes = 0
        _Fecha = CDate("1900/01/01")
        _Tipo_Id = 0
        _Comentario = ""
        _Estado_Id = 0
        _Debitos = 0.0
        _Creditos = 0.0
        _Usuario_Id = ""
        _UsuarioAplica_Id = ""
        _Origen_Id = 0
        _AplicarAsiento = False
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Detalle As SDFinancial.DTAsientoDetalle
        Dim Lista As New List(Of SDFinancial.DTAsientoDetalle)

        Try
            For Each Item As TAsientoDetalle In _ListaDetalle
                Detalle = New SDFinancial.DTAsientoDetalle

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

            With _DTabla
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
                .Annio = _Annio
                .Mes = _Mes
                .Fecha = _Fecha
                .Tipo_Id = _Tipo_Id
                .Comentario = _Comentario
                .Estado_Id = _Estado_Id
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Usuario_Id = _Usuario_Id
                .UsuarioAplica_Id = _UsuarioAplica_Id
                .Origen_Id = _Origen_Id
                .ListaDetalle = Lista.ToArray
                .AplicarAsiento = _AplicarAsiento
            End With

            _Resultado = _SDWCF.AsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Asiento_Id = _Asiento_Id
                .Usuario_Id = _Usuario_Id
            End With

            _Resultado = _SDWCF.AsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Asiento_Id = _Asiento_Id
                .Annio = _Annio
                .Mes = _Mes
                .Fecha = _Fecha
                .Tipo_Id = _Tipo_Id
                .Comentario = _Comentario
                .Estado_Id = _Estado_Id
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Usuario_Id = _Usuario_Id
                .UsuarioAplica_Id = _UsuarioAplica_Id
                .Origen_Id = _Origen_Id
            End With

            _Resultado = _SDWCF.AsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Dim AsientoDetalle As New SDFinancial.DTAsientoDetalle
        Dim Detalle As TAsientoDetalle

        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
            End With

            _Resultado = _SDWCF.AsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Asiento_Id = _Resultado.Datos.Rows(0).Item("Asiento_Id")
                _Annio = _Resultado.Datos.Rows(0).Item("Annio")
                _Mes = _Resultado.Datos.Rows(0).Item("Mes")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _Tipo_Id = _Resultado.Datos.Rows(0).Item("Tipo_Id")
                _Comentario = _Resultado.Datos.Rows(0).Item("Comentario")
                _Estado_Id = _Resultado.Datos.Rows(0).Item("Estado_Id")
                _Debitos = _Resultado.Datos.Rows(0).Item("Debitos")
                _Creditos = _Resultado.Datos.Rows(0).Item("Creditos")
                _Usuario_Id = _Resultado.Datos.Rows(0).Item("Usuario_Id")
                _UsuarioAplica_Id = IIf(IsDBNull(_Resultado.Datos.Rows(0).Item("UsuarioAplica_Id")), "", _Resultado.Datos.Rows(0).Item("UsuarioAplica_Id"))
                _Origen_Id = _Resultado.Datos.Rows(0).Item("Origen_Id")
            End If

            _ListaDetalle.Clear()

            With AsientoDetalle
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
            End With

            _Resultado = _SDWCF.AsientoDetalleMant(AsientoDetalle, SDFinancial.EnumOperacionMant.List, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count = 0 Then
                VerificaMensaje("No se encontraron detalles para el asiento seleccionado")
            End If

            For Each Fila As DataRow In _Resultado.Datos.Rows
                Detalle = New TAsientoDetalle

                With Detalle
                    .Emp_Id = Fila("Emp_Id")
                    .Asiento_Id = Fila("Asiento_Id")
                    .Linea_Id = Fila("Linea_Id")
                    .Fecha = Fila("Fecha")
                    .Moneda = Fila("Moneda")
                    .CC_Id = IIf(IsDBNull(Fila("CC_Id")), -1, Fila("CC_Id"))
                    .Cuenta_Id = Fila("Cuenta_Id")
                    .Tipo = Fila("Tipo")
                    .Monto = Fila("Monto")
                    .TipoCambio = Fila("TipoCambio")
                    .Referencia = Fila("Referencia")
                    .Descripcion = Fila("Descripcion")
                    .CuentaNombre = Fila("CuentaNombre")
                    .CC_Nombre = IIf(IsDBNull(Fila("CC_Nombre")), "", Fila("CC_Nombre"))
                End With

                _ListaDetalle.Add(Detalle)
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.AsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.AsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.AsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.AsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Asiento_Id = _Resultado.Datos.Rows(0).Item("Asiento_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ListaResumida(pFiltroFechas As Boolean, pFechaInicio As DateTime, pFechaFinal As DateTime, pEstado_Id As Integer, pMes As Integer, pAnnio As Integer) As String
        Dim Query As String

        Try
            Query = " select a.Asiento_Id" & _
                    " ,b.Nombre as Tipo" & _
                    " ,d.Nombre as Origen" & _
                    " ,a.Comentario" & _
                    " ,dbo.FnNombrePeriodo(a.Mes,a.Annio) as Periodo" & _
                    " ,a.Fecha" & _
                    " ,a.Estado_Id" & _
                    " ,c.Nombre as Estado" & _
                    " ,a.Debitos" & _
                    " ,a.Creditos" & _
                    " from AsientoEncabezado a" & _
                    " ,AsientoTipo b" & _
                    " ,AsientoEstado c" & _
                    " ,AsientoOrigen d" & _
                    " Where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.Tipo_Id" & _
                    " and   a.Emp_Id = c.Emp_Id" & _
                    " and   a.Estado_Id = c.Estado_Id" & _
                    " and   a.Emp_Id = d.Emp_Id" & _
                    " and   a.Origen_Id = d.Origen_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString

            If _Tipo_Id > 0 Then
                Query += " and   a.Tipo_Id = " & _Tipo_Id.ToString
            End If

            If pFiltroFechas Then
                Query += " and   a.Fecha >= '" & Format(pFechaInicio, "yyyyMMdd") & "'" & _
                         " and   a.Fecha < '" & Format(pFechaFinal, "yyyyMMdd") & "'"
            End If

            If pEstado_Id > 0 Then
                Query += " and   a.Estado_Id = " & pEstado_Id.ToString
            End If

            If pMes > 0 And pAnnio > 0 Then
                Query += " and   a.Mes = " & pMes.ToString & _
                         " and   a.Annio = " & pAnnio.ToString
            End If

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
    Public Function RptAsientosDeDiario(pFiltroFecha As Integer, pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String

        Try
            Query = " exec RptAsientosDeDiario " & _Emp_Id.ToString & "," & _Tipo_Id.ToString & "," & _Annio.ToString & _
                    "," & _Mes.ToString & "," & pFiltroFecha.ToString & ",'" & Format(pFechaIni, "yyyyMMdd") & "'" & _
                    ",'" & Format(pFechaFin, "yyyyMMdd") & "'," & _Estado_Id.ToString & "," & _Origen_Id.ToString

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
    Public Function RptConsultaMovimientoCuenta(pAnnioFin As String, pMesFin As String, pCuentaIni As String, pCuentaFin As String) As String
        Dim Query As String

        Try
            Query = " exec RptConsultaMovimientoCuenta " & _Emp_Id.ToString & ",'" & _Annio.ToString & "','" & _Mes.ToString & "'" & _
                    ",'" & pAnnioFin & "','" & pMesFin & "','" & pCuentaIni & "','" & pCuentaFin & "'," & _Tipo_Id.ToString & _
                    "," & _Origen_Id.ToString

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
    Public Function ReversaAsiento() As String
        Dim Query As String

        Try
            Query = "exec ReversaAsiento " & _Emp_Id.ToString & "," & _Asiento_Id.ToString

            _Resultado = _SDWCF.ExecuteQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function AsientosSinAplicar() As String
        Dim Query As String

        Try
            Query = " Select * from AsientoEncabezado" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Annio = " & _Annio.ToString & _
                    " and   Mes = " & _Mes.ToString & _
                    " and   Estado_Id <> " & Enum_AsientoEstado.Aplicado

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
    Public Function AplicarMasivo(pAsientos() As Integer, ByRef pProgreso As ProgressBar) As String
        Dim AsientoEncabezado As TAsientoEncabezado

        Try
            If pAsientos.Length = 0 Then
                VerificaMensaje("Debe de seleccionar al menos un asiento")
            End If

            pProgreso.Minimum = 0
            pProgreso.Maximum = pAsientos.Length
            pProgreso.Value = 0

            For Each Asiento As Integer In pAsientos
                Try
                    pProgreso.Value += 1

                    If Asiento = 0 Then
                        Continue For
                    End If

                    AsientoEncabezado = New TAsientoEncabezado

                    With AsientoEncabezado
                        .Emp_Id = _Emp_Id
                        .Asiento_Id = Asiento
                    End With
                    VerificaMensaje(AsientoEncabezado.ListKey)

                    If AsientoEncabezado.RowsAffected = 0 Then
                        VerificaMensaje("No se encontró un Asiento con el número " & Asiento.ToString)
                    End If

                    If AsientoEncabezado.Estado_Id = Enum_AsientoEstado.Aplicado Then
                        VerificaMensaje("El asiento #" & Asiento & " ya se encuentra aplicado")
                    End If

                    If AsientoEncabezado.Annio <> EmpresaParametroInfo.GetProcesoAnnio Then
                        VerificaMensaje("Asiento #" & Asiento & ": No puede aplicar asientos de un periodo distinto al actual")
                    End If

                    If AsientoEncabezado.Annio = EmpresaParametroInfo.GetProcesoAnnio Then
                        If AsientoEncabezado.Mes <> EmpresaParametroInfo.GetProcesoMes Then
                            VerificaMensaje("Asiento #" & Asiento & ": No puede aplicar asientos de un periodo distinto al actual")
                        End If
                    End If

                    AsientoEncabezado.AplicarAsiento = True
                    AsientoEncabezado.UsuarioAplica_Id = UsuarioInfo.Usuario_Id
                    VerificaMensaje(AsientoEncabezado.Insert)
                Catch ex As Exception
                    _ListaErrores.Add(ex.Message)
                End Try
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function RptFlujoEfeectivo(pAnnioIni As String, pMesIni As String, pAnnioFin As String, pMesFin As String) As String
        Dim Query As String

        Try
            Query = " exec RptFlujoEfeectivo " & _Emp_Id.ToString & "," & pMesIni & "," & pAnnioIni & _
                    "," & pMesFin & "," & pAnnioFin

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