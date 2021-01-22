Public Class TVendedor
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Vendedor_Id As Integer
    Private _Nombre As String
    Private _Activo As Integer
    Private _Comision As Double
    Private _UltimaModificacion As DateTime
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTVendedor
    Private _Resultado As New SDFinancial.TResultado
    Public _RowsAffected As Integer
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
    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal Value As Integer)
            _Vendedor_Id = Value
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
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
        End Set
    End Property
    Public Property Comision() As Double
        Get
            Return _Comision
        End Get
        Set(ByVal Value As Double)
            _Comision = Value
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
        _Vendedor_Id = 0
        _Nombre = ""
        _Activo = 0
        _Comision = 0.00
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Vendedor_Id = _Vendedor_Id
                .Nombre = _Nombre
                .Activo = _Activo
                .Comision = _Comision
            End With

            _Resultado = _SDWCF.VendedorMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Vendedor_Id = _Vendedor_Id
            End With

            _Resultado = _SDWCF.VendedorMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Vendedor_Id = _Vendedor_Id
                .Nombre = _Nombre
                .Activo = _Activo
                .Comision = _Comision
            End With

            _Resultado = _SDWCF.VendedorMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Vendedor_Id = _Vendedor_Id
            End With

            _Resultado = _SDWCF.VendedorMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Vendedor_Id = _Resultado.Datos.Rows(0).Item("Vendedor_Id")
                _Nombre = _Resultado.Datos.Rows(0).Item("Nombre")
                _Activo = _Resultado.Datos.Rows(0).Item("Activo")
                _Comision = _Resultado.Datos.Rows(0).Item("Comision")
                _UltimaModificacion = _Resultado.Datos.Rows(0).Item("UltimaModificacion")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.VendedorMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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

            _Resultado = _SDWCF.VendedorMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.VendedorMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.VendedorMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Vendedor_Id = _Resultado.Datos.Rows(0).Item("Vendedor_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function RptComisionPorVendedor(pDesde As Date, pHasta As Date) As String
        Dim Query As String

        Try
            If True Then

            End If

            Query = "exec RptCxCComisionesPorVendedor " & Emp_Id & ",'" & pDesde.ToString("yyyyMMdd") & "','" & pHasta.ToString("yyyyMMdd") & "'," & Vendedor_Id

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            _RowsAffected = _Resultado.RowsAffected

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            For Each row As DataRow In _Resultado.Datos.Rows
                row.Item(2) = ExtraerConsecutivoFE(row.Item(2).ToString)
                row.Item(8) = porcentajeImpuestoRptComisionVendedor(row.Item(2).ToString)
                row.Item(9) = UtilidadFacturaRptComisionVendedor(row.Item(2).ToString)
            Next

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function porcentajeImpuestoRptComisionVendedor(pReferencia As String) As Double
        Dim Query As String
        Dim database As String
        Dim _Resultado2 As New SDFinancial.TResultado
        Try


            If pReferencia < 18 Then
                Return 0.00
            End If


            database = GetRegistryValue("Software", "SOFTDESIGN", "SD-GENERAL", "DataBase", "")

            Query = "SELECT (((b.IV)/b.Total)*100)  " &
                    "FROM   [" & database & "].dbo.FacturaElectronica a " &
                           "INNER JOIN [" & database & "].dbo.FacturaEncabezado b " &
                                   "ON a.emp_id = b.emp_id " &
                                      "And a.Documento_Id = b.Documento_Id " &
                                      "And a.Fecha = b.Fecha" &
                    " WHERE  a.consecutivo = " & pReferencia.ToString()


            _Resultado2 = _SDWCF.SelectQuery(Query, String.Empty)

            If _Resultado2.RowsAffected = 0 Then

                Query = "SELECT (((b.IV)/b.Total)*100)  " &
                    "FROM   [" & database & "].dbo.FacturaElectronicaPendiente a " &
                           "INNER JOIN [" & database & "].dbo.FacturaEncabezado b " &
                                   "ON a.emp_id = b.emp_id " &
                                      "And a.Documento_Id = b.Documento_Id " &
                                      "And a.Fecha = b.Fecha" &
                    " WHERE  a.consecutivo = " & pReferencia.ToString()
            End If

            _Resultado2 = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado2.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado2.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado2.Datos.TableName)
            End If

            Return _Resultado2.Datos.Rows(0).Item(0).ToString()
        Catch ex As Exception
            Return 0.00
        End Try
    End Function

    Private Function UtilidadFacturaRptComisionVendedor(pReferencia As String) As Double
        Dim Query As String
        Dim database As String
        Dim _Resultado2 As New SDFinancial.TResultado
        Try

            database = GetRegistryValue("Software", "SOFTDESIGN", "SD-GENERAL", "DataBase", "")

            Query = "SELECT Sum(c.Precio * c.cantidad) - Sum(c.costo * c.Cantidad) " &
                    "FROM   [" & database & "].dbo.FacturaElectronica a " &
                           "INNER JOIN [" & database & "].dbo.FacturaEncabezado b " &
                                   "ON a.emp_id = b.emp_id " &
                                      "And a.Documento_Id = b.Documento_Id " &
                                      "And a.Fecha = b.Fecha " &
                           "INNER JOIN [" & database & "].dbo.FacturaDetalle c " &
                                   "ON c.Emp_Id = b.Emp_Id " &
                                      "AND c.Documento_Id = b.Documento_Id " &
                                      "AND c.Fecha = b.Fecha " &
                    " WHERE  a.consecutivo = " & pReferencia.ToString()

            _Resultado2 = _SDWCF.SelectQuery(Query, String.Empty)

            If _Resultado2.RowsAffected = 0 Then
                Query = "SELECT Sum(c.Precio * c.cantidad) - Sum(c.costo * c.Cantidad) " &
                    "FROM   [" & database & "].dbo.FacturaElectronicaPendiente a " &
                           "INNER JOIN [" & database & "].dbo.FacturaEncabezado b " &
                                   "ON a.emp_id = b.emp_id " &
                                      "And a.Documento_Id = b.Documento_Id " &
                                      "And a.Fecha = b.Fecha " &
                           "INNER JOIN [" & database & "].dbo.FacturaDetalle c " &
                                   "ON c.Emp_Id = b.Emp_Id " &
                                      "AND c.Documento_Id = b.Documento_Id " &
                                      "AND c.Fecha = b.Fecha " &
                    " WHERE  a.consecutivo = " & pReferencia.ToString()
            End If

            MsgError = _Resultado2.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado2.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado2.Datos.TableName)
            End If

            Return _Resultado2.Datos.Rows(0).Item(0).ToString()
        Catch ex As Exception
            Return 0.00
        End Try
    End Function

    Private Function ExtraerConsecutivoFE(pReferencia As String) As String
        Try
            Dim consecutivos As String() = pReferencia.Split(New Char() {"-"c})
            Return consecutivos(1)
        Catch ex As Exception
            Return pReferencia
        End Try
    End Function


#End Region
End Class
