Imports System.Windows.Forms

Public Class TAuxAsientoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Asiento_Id As Long
    Private _Annio As Integer
    Private _Mes As Integer
    Private _Fecha As DateTime
    Private _Tipo_Id As Integer
    Private _Comentario As String
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Usuario_Id As String
    Private _Origen_Id As Integer
    Private _MAC_Address As String
    Private _ListaErrores As New List(Of String)
    Private _ListaDetalle As New List(Of TAuxAsientoDetalle)
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTAuxAsientoEncabezado
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
    Public Property Origen_Id() As Integer
        Get
            Return _Origen_Id
        End Get
        Set(ByVal Value As Integer)
            _Origen_Id = Value
        End Set
    End Property
    Public Property MAC_Address() As String
        Get
            Return _MAC_Address
        End Get
        Set(ByVal Value As String)
            _MAC_Address = Value
        End Set
    End Property
    Public Property ListaDetalle As List(Of TAuxAsientoDetalle)
        Get
            Return _ListaDetalle
        End Get
        Set(value As List(Of TAuxAsientoDetalle))
            _ListaDetalle = value
        End Set
    End Property
    Public ReadOnly Property ListaErrores As List(Of String)
        Get
            Return _ListaErrores
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
        _Asiento_Id = 0
        _Annio = 0
        _Mes = 0
        _Fecha = CDate("1900/01/01")
        _Tipo_Id = 0
        _Comentario = ""
        _Debitos = 0.0
        _Creditos = 0.0
        _Usuario_Id = ""
        _Origen_Id = 0
        _MAC_Address = ""
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Detalle As SDFinancial.DTAuxAsientoDetalle
        Dim Lista As New List(Of SDFinancial.DTAuxAsientoDetalle)

        Try
            For Each Item As TAuxAsientoDetalle In _ListaDetalle
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

            With _DTabla
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
                .Annio = _Annio
                .Mes = _Mes
                .Fecha = _Fecha
                .Tipo_Id = _Tipo_Id
                .Comentario = _Comentario
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Usuario_Id = _Usuario_Id
                .Origen_Id = _Origen_Id
                .MAC_Address = _MAC_Address
                .ListaDetalle = Lista.ToArray
            End With

            _Resultado = _SDWCF.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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

            _Resultado = _SDWCF.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Usuario_Id = _Usuario_Id
                .Origen_Id = _Origen_Id
                .MAC_Address = _MAC_Address
            End With

            _Resultado = _SDWCF.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Dim AuxAsientoDetalle As New SDFinancial.DTAuxAsientoDetalle
        Dim AuxDetalle As TAuxAsientoDetalle

        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
            End With

            _Resultado = _SDWCF.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

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
                _Debitos = _Resultado.Datos.Rows(0).Item("Debitos")
                _Creditos = _Resultado.Datos.Rows(0).Item("Creditos")
                _Usuario_Id = _Resultado.Datos.Rows(0).Item("Usuario_Id")
                _Origen_Id = _Resultado.Datos.Rows(0).Item("Origen_Id")
                _MAC_Address = _Resultado.Datos.Rows(0).Item("MAC_Address")
            End If

            _ListaDetalle.Clear()

            With AuxAsientoDetalle
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
            End With

            _Resultado = _SDWCF.AuxAsientoDetalleMant(AuxAsientoDetalle, SDFinancial.EnumOperacionMant.List, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count = 0 Then
                VerificaMensaje("No se encontraron detalles para el asiento seleccionado")
            End If

            For Each Fila As DataRow In _Resultado.Datos.Rows
                AuxDetalle = New TAuxAsientoDetalle

                With AuxDetalle
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
                End With

                _ListaDetalle.Add(AuxDetalle)
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
        Return String.Empty
    End Function
    Public Function ListaResumida(pTotales As Integer) As String
        Dim Query As String

        Try
            Query = " select a.Asiento_Id" & _
                    " ,b.Nombre as Tipo" & _
                    " ,d.Nombre as Origen" & _
                    " ,a.Comentario" & _
                    " ,dbo.FnNombrePeriodo(a.Mes,a.Annio) as Periodo" & _
                    " ,a.Fecha" & _
                    " ,a.Debitos" & _
                    " ,a.Creditos" & _
                    " from AuxAsientoEncabezado a" & _
                    " ,AsientoTipo b" & _
                    " ,AsientoOrigen d" & _
                    " Where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.Tipo_Id" & _
                    " and   a.Emp_Id = d.Emp_Id" & _
                    " and   a.Origen_Id = d.Origen_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString

            If _Tipo_Id > 0 Then
                Query += " and   a.Tipo_Id = " & _Tipo_Id.ToString
            End If

            If _Origen_Id > 0 Then
                Query += " and   a.Origen_Id = " & _Origen_Id.ToString
            End If

            If _Mes > 0 And _Annio > 0 Then
                Query += " and   a.Mes = " & _Mes.ToString & _
                         " and   a.Annio = " & _Annio.ToString
            End If

            If pTotales >= 0 Then
                Select Case pTotales
                    Case 0
                        Query += " and   a.Debitos <> a.Creditos"
                    Case 1
                        Query += " and   a.Debitos = a.Creditos"
                End Select
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
    Public Function EliminaAsientoAux() As String
        Dim Query As String

        Try
            Query = " exec EliminaAsientoAux " & _Emp_Id.ToString & "," & _Asiento_Id.ToString

            _Resultado = _SDWCF.ExecuteQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function AuxAsientoPasaConta(pAsientos() As Integer, ByRef pProgreso As ProgressBar) As String
        Dim AuxAsientoEncabezado As TAuxAsientoEncabezado
        Dim AsientoEncabezado As TAsientoEncabezado
        Dim AsientoDetalle As TAsientoDetalle
        Dim Mensaje As String = ""

        Try
            pProgreso.Minimum = 0
            pProgreso.Maximum = pAsientos.Length
            pProgreso.Value = 0

            For Each Asiento As Integer In pAsientos
                pProgreso.Value += 1

                If Asiento <= 0 Then
                    Continue For
                End If

                Try
                    AuxAsientoEncabezado = New TAuxAsientoEncabezado

                    With AuxAsientoEncabezado
                        .Emp_Id = _Emp_Id
                        .Asiento_Id = Asiento
                    End With
                    Mensaje = AuxAsientoEncabezado.ListKey
                    If Mensaje <> "" Then
                        VerificaMensaje("Asiento Aux #" & Asiento & ":" & Mensaje)
                    End If

                    If AuxAsientoEncabezado.RowsAffected = 0 Then
                        VerificaMensaje("Asiento Aux #" & Asiento & ": No se encontrarón datos")
                    End If

                    If AuxAsientoEncabezado.Annio < EmpresaParametroInfo.GetProcesoAnnio Then
                        VerificaMensaje("Asiento Aux #" & Asiento & ": No puede digitar asientos de un periodo anterior al actual" & vbCrLf)
                    End If

                    If AuxAsientoEncabezado.Annio = EmpresaParametroInfo.GetProcesoAnnio Then
                        If AuxAsientoEncabezado.Mes < EmpresaParametroInfo.GetProcesoMes Then
                            VerificaMensaje("Asiento Aux #" & Asiento & ": No puede digitar asientos de un periodo anterior al actual" & vbCrLf)
                        End If
                    End If

                    AsientoEncabezado = New TAsientoEncabezado

                    With AsientoEncabezado
                        .Emp_Id = AuxAsientoEncabezado.Emp_Id
                        .Annio = AuxAsientoEncabezado.Annio
                        .Mes = AuxAsientoEncabezado.Mes
                        .Fecha = AuxAsientoEncabezado.Fecha
                        .Tipo_Id = AuxAsientoEncabezado.Tipo_Id
                        .Comentario = AuxAsientoEncabezado.Comentario
                        .Estado_Id = Enum_AsientoEstado.Digitado
                        .Debitos = AuxAsientoEncabezado.Debitos
                        .Creditos = AuxAsientoEncabezado.Creditos
                        .Usuario_Id = AuxAsientoEncabezado.Usuario_Id
                        .Origen_Id = AuxAsientoEncabezado.Origen_Id
                    End With

                    For Each Detalle As TAuxAsientoDetalle In AuxAsientoEncabezado.ListaDetalle
                        AsientoDetalle = New TAsientoDetalle

                        With AsientoDetalle
                            .Emp_Id = Detalle.Emp_Id
                            .Linea_Id = Detalle.Linea_Id
                            .Fecha = Detalle.Fecha
                            .Moneda = Detalle.Moneda
                            .CC_Id = Detalle.CC_Id
                            .Cuenta_Id = Detalle.Cuenta_Id
                            .Tipo = Detalle.Tipo
                            .Monto = Detalle.Monto
                            .MontoDolares = Detalle.MontoDolares
                            .TipoCambio = Detalle.TipoCambio
                            .Referencia = Detalle.Referencia
                            .Descripcion = Detalle.Descripcion
                        End With

                        AsientoEncabezado.ListaDetalle.Add(AsientoDetalle)
                    Next
                    Mensaje = AsientoEncabezado.Insert
                    If Mensaje <> "" Then
                        VerificaMensaje("Asiento Aux #" & Asiento & ":" & Mensaje & vbCrLf)
                    End If

                    Mensaje = AuxAsientoEncabezado.EliminaAsientoAux
                    If Mensaje <> "" Then
                        VerificaMensaje("Asiento Aux #" & Asiento & ":" & Mensaje & vbCrLf)
                    End If
                Catch ex As Exception
                    _ListaErrores.Add(ex.Message)
                End Try
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class