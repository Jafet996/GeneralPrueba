Public Class TCxCEntregaDocumentoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Entrega_Id As Integer
    Private _Vendedor_Id As Integer
    Private _Fecha As DateTime
    Private _Usuario_Id As String
    Private _Activo As Integer
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCxCEntregaDocumentoEncabezado
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
    Public Property Entrega_Id() As Integer
        Get
            Return _Entrega_Id
        End Get
        Set(ByVal Value As Integer)
            _Entrega_Id = Value
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
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
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
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
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
        _Entrega_Id = 0
        _Vendedor_Id = 0
        _Fecha = CDate("1900/01/01")
        _Usuario_Id = ""
        _Activo = 0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Entrega_Id = _Entrega_Id
                .Vendedor_Id = _Vendedor_Id
                .Fecha = _Fecha
                .Usuario_Id = _Usuario_Id
                .Activo = _Activo
            End With

            _Resultado = _SDWCF.CxCEntregaDocumentoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Entrega_Id = _Entrega_Id
            End With

            _Resultado = _SDWCF.CxCEntregaDocumentoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Entrega_Id = _Entrega_Id
                .Vendedor_Id = _Vendedor_Id
                .Fecha = _Fecha
                .Usuario_Id = _Usuario_Id
                .Activo = _Activo
            End With

            _Resultado = _SDWCF.CxCEntregaDocumentoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Entrega_Id = _Entrega_Id
            End With

            _Resultado = _SDWCF.CxCEntregaDocumentoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Entrega_Id = _Resultado.Datos.Rows(0).Item("Entrega_Id")
                _Vendedor_Id = _Resultado.Datos.Rows(0).Item("Vendedor_Id")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _Usuario_Id = _Resultado.Datos.Rows(0).Item("Usuario_Id")
                _Activo = _Resultado.Datos.Rows(0).Item("Activo")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.CxCEntregaDocumentoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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

            _Resultado = _SDWCF.CxCEntregaDocumentoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.CxCEntregaDocumentoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.CxCEntregaDocumentoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Entrega_Id = _Resultado.Datos.Rows(0).Item("CxCEntregaDocumentoEncabezado_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function RptConsultaFacturasAsignadas() As String
        Dim Query As String

        Try
            Query = "EXEC	RptConsultaAsignaFacturaVendedor " & Emp_Id & "," & Entrega_Id

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            For Each row In Datos.Tables(0).Rows
                row("Referencia") = ExtraerConsecutivoFE(row("Referencia"))
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function ExtraerConsecutivoFE(referencia As String) As String
        Try
            Dim consecutivos As String() = referencia.ToString().Split(New Char() {"-"c})
            Return consecutivos(1)
        Catch ex As Exception
            Return referencia
        End Try
    End Function

    Public Function RptConsultaFacturasAsignadasDiario() As String
        Dim Query As String

        Try
            Query = "EXEC	RptConsultaAsignaFacturaVendedorDiario " & Emp_Id & "," & Vendedor_Id & ",'" & Now().ToString("yyyyMMdd") & "'"

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

    Public Function RptConsultaFacturasAsignadasDiarioCargaLista(lista As List(Of TCxCEntregaDocumentoDetalle)) As List(Of TCxCEntregaDocumentoDetalle)
        Dim Query As String

        Try
            Query = "EXEC	RptConsultaAsignaFacturaVendedorDiarioCargaLista " & Emp_Id & "," & Vendedor_Id & ",'" & Now().ToString("yyyyMMdd") & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            lista = New List(Of TCxCEntregaDocumentoDetalle)()

            For Each row As DataRow In Datos.Tables(0).Rows
                Dim detalle As New TCxCEntregaDocumentoDetalle()
                With detalle
                    .Emp_Id = row.Item("Emp_Id")
                    .Entrega_Id = row.Item("Entrega_Id")
                    .Doc_Id = row.Item("Doc_Id")
                    .Mov_Id = row.Item("Mov_Id")
                    .Tipo_Id = row.Item("Tipo_Id")
                End With
                lista.Add(detalle)
            Next

            Return lista
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
End Class
