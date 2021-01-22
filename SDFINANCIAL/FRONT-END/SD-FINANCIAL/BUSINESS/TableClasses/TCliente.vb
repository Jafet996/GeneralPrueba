Public Class TCliente
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Cliente_Id As Integer
    Private _TipoIdentificacion_Id As Integer
    Private _Identificacion As String
    Private _Nombre As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _Email As String
    Private _Direccion As String
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Saldo As Double
    Private _DiasCredito As Integer
    Private _PorcMora As Double
    Private _DiasGraciaMora As Integer
    Private _AplicaMora As Integer
    Private _LimiteCredito As Double
    Private _CxC_Colones As String
    Private _CxC_Dolares As String
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _Vendedor_Id As Integer
    Private _EsInterno As Boolean
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCliente
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
    Public Property Cliente_Id() As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal Value As Integer)
            _Cliente_Id = Value
        End Set
    End Property
    Public Property TipoIdentificacion_Id() As Integer
        Get
            Return _TipoIdentificacion_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoIdentificacion_Id = Value
        End Set
    End Property
    Public Property Identificacion() As String
        Get
            Return _Identificacion
        End Get
        Set(ByVal Value As String)
            _Identificacion = Value
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
    Public Property Telefono1() As String
        Get
            Return _Telefono1
        End Get
        Set(ByVal Value As String)
            _Telefono1 = Value
        End Set
    End Property
    Public Property Telefono2() As String
        Get
            Return _Telefono2
        End Get
        Set(ByVal Value As String)
            _Telefono2 = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal Value As String)
            _Email = Value
        End Set
    End Property
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal Value As String)
            _Direccion = Value
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
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property
    Public Property DiasCredito() As Integer
        Get
            Return _DiasCredito
        End Get
        Set(ByVal Value As Integer)
            _DiasCredito = Value
        End Set
    End Property
    Public Property PorcMora() As Double
        Get
            Return _PorcMora
        End Get
        Set(ByVal Value As Double)
            _PorcMora = Value
        End Set
    End Property
    Public Property DiasGraciaMora() As Integer
        Get
            Return _DiasGraciaMora
        End Get
        Set(ByVal Value As Integer)
            _DiasGraciaMora = Value
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
    Public Property LimiteCredito() As Double
        Get
            Return _LimiteCredito
        End Get
        Set(ByVal Value As Double)
            _LimiteCredito = Value
        End Set
    End Property
    Public Property CxC_Colones() As String
        Get
            Return _CxC_Colones
        End Get
        Set(ByVal Value As String)
            _CxC_Colones = Value
        End Set
    End Property
    Public Property CxC_Dolares() As String
        Get
            Return _CxC_Dolares
        End Get
        Set(ByVal Value As String)
            _CxC_Dolares = Value
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
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
        End Set
    End Property

    Public Property EsInterno() As Boolean
        Get
            Return _EsInterno
        End Get
        Set(ByVal Value As Boolean)
            _EsInterno = Value
        End Set
    End Property

    Public ReadOnly Property RowsAffected As Long
        Get
            Return _Resultado.RowsAffected
        End Get
    End Property

    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal value As Integer)
            _Vendedor_Id = value
        End Set
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
        _Cliente_Id = 0
        _TipoIdentificacion_Id = 0
        _Identificacion = ""
        _Nombre = ""
        _Telefono1 = ""
        _Telefono2 = ""
        _Email = ""
        _Direccion = ""
        _Debitos = 0.0
        _Creditos = 0.0
        _Saldo = 0.0
        _DiasCredito = 0
        _PorcMora = 0.0
        _DiasGraciaMora = 0
        _AplicaMora = 0
        _LimiteCredito = 0.0
        _CxC_Colones = ""
        _CxC_Dolares = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Cliente_Id = _Cliente_Id
                .TipoIdentificacion_Id = _TipoIdentificacion_Id
                .Identificacion = _Identificacion
                .Nombre = _Nombre
                .Telefono1 = _Telefono1
                .Telefono2 = _Telefono2
                .Email = _Email
                .Direccion = _Direccion
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Saldo = _Saldo
                .DiasCredito = _DiasCredito
                .PorcMora = _PorcMora
                .DiasGraciaMora = _DiasGraciaMora
                .AplicaMora = _AplicaMora
                .LimiteCredito = _LimiteCredito
                .CxC_Colones = _CxC_Colones
                .CxC_Dolares = _CxC_Dolares
                .Activo = _Activo
                .Vendedor_Id = _Vendedor_Id
                .EsInterno = _EsInterno
            End With

            _Resultado = _SDWCF.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Cliente_Id = _Cliente_Id
            End With

            _Resultado = _SDWCF.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Cliente_Id = _Cliente_Id
                .TipoIdentificacion_Id = _TipoIdentificacion_Id
                .Identificacion = _Identificacion
                .Nombre = _Nombre
                .Telefono1 = _Telefono1
                .Telefono2 = _Telefono2
                .Email = _Email
                .Direccion = _Direccion
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Saldo = _Saldo
                .DiasCredito = _DiasCredito
                .PorcMora = _PorcMora
                .DiasGraciaMora = _DiasGraciaMora
                .AplicaMora = _AplicaMora
                .LimiteCredito = _LimiteCredito
                .CxC_Colones = _CxC_Colones
                .CxC_Dolares = _CxC_Dolares
                .Activo = _Activo
                .EsInterno = _EsInterno
                .Vendedor_Id = _Vendedor_Id
            End With

            _Resultado = _SDWCF.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Cliente_Id = _Cliente_Id
            End With

            _Resultado = _SDWCF.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Cliente_Id = _Resultado.Datos.Rows(0).Item("Cliente_Id")
                _TipoIdentificacion_Id = _Resultado.Datos.Rows(0).Item("TipoIdentificacion_Id")
                _Identificacion = _Resultado.Datos.Rows(0).Item("Identificacion")
                _Nombre = _Resultado.Datos.Rows(0).Item("Nombre")
                _Telefono1 = _Resultado.Datos.Rows(0).Item("Telefono1")
                _Telefono2 = _Resultado.Datos.Rows(0).Item("Telefono2")
                _Email = _Resultado.Datos.Rows(0).Item("Email")
                _Direccion = _Resultado.Datos.Rows(0).Item("Direccion")
                _Debitos = _Resultado.Datos.Rows(0).Item("Debitos")
                _Creditos = _Resultado.Datos.Rows(0).Item("Creditos")
                _Saldo = _Resultado.Datos.Rows(0).Item("Saldo")
                _DiasCredito = _Resultado.Datos.Rows(0).Item("DiasCredito")
                _PorcMora = _Resultado.Datos.Rows(0).Item("PorcMora")
                _DiasGraciaMora = _Resultado.Datos.Rows(0).Item("DiasGraciaMora")
                _AplicaMora = _Resultado.Datos.Rows(0).Item("AplicaMora")
                _LimiteCredito = _Resultado.Datos.Rows(0).Item("LimiteCredito")
                _CxC_Colones = _Resultado.Datos.Rows(0).Item("CxC_Colones")
                _CxC_Dolares = _Resultado.Datos.Rows(0).Item("CxC_Dolares")
                _Activo = _Resultado.Datos.Rows(0).Item("Activo")
                _UltimaModificacion = _Resultado.Datos.Rows(0).Item("UltimaModificacion")
                _Vendedor_Id = _Resultado.Datos.Rows(0).Item("Vendedor_Id")
                _EsInterno = _Resultado.Datos.Rows(0).Item("EsInterno")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Cliente_Id = _Resultado.Datos.Rows(0).Item("Cliente_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ListBusqueda(pCriterio As String, pTipoBusqueda As Integer) As String
        Dim Query As String

        Try
            Query = " select a.Cliente_Id as Codigo" & _
                    " ,a.Nombre" & _
                    " ,b.Nombre as TipoIdentificacion" & _
                    " ,a.Identificacion" & _
                    " from Cliente a" & _
                    " ,TipoIdentificacion b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.TipoIdentificacion_Id = b.TipoIdentificacion_Id" & _
                    " and   a.Activo = 1" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString

            Select Case pTipoBusqueda
                Case 1
                    If pCriterio <> "" Then
                        Query += " and   a.Nombre like '%" & pCriterio & "%'"
                    End If
                Case 2
                    If pCriterio <> "" Then
                        Query += " and   a.Identificacion like '%" & pCriterio & "%'"
                    End If
                Case Else
                    VerificaMensaje("El tipo de búsqueda indicado no es válido")
            End Select

            Query += " order by a.Nombre"

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
    Public Function CalculaMontoMora(pFecha As DateTime, pUsuario_Id As String, pCreaMov As Integer, ByRef pMontoMora As Double) As String
        Dim Query As String

        Try
            Query = " exec CxC_CalculaMoraCliente " & _Emp_Id.ToString & "," & _Cliente_Id.ToString & _
                    ",'" & Format(pFecha, "yyyyMMdd") & "','" & pUsuario_Id & "'," & pCreaMov.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                pMontoMora = _Resultado.Datos.Rows(0).Item("MontoMora")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ListKeyByIdentificacion() As String
        Dim Query As String

        Try
            Query = " select *" & _
                    " from Cliente" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Identificacion = '" & _Identificacion.ToString & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Cliente_Id = _Resultado.Datos.Rows(0).Item("Cliente_Id")
                _TipoIdentificacion_Id = _Resultado.Datos.Rows(0).Item("TipoIdentificacion_Id")
                _Identificacion = _Resultado.Datos.Rows(0).Item("Identificacion")
                _Nombre = _Resultado.Datos.Rows(0).Item("Nombre")
                _Telefono1 = _Resultado.Datos.Rows(0).Item("Telefono1")
                _Telefono2 = _Resultado.Datos.Rows(0).Item("Telefono2")
                _Email = _Resultado.Datos.Rows(0).Item("Email")
                _Direccion = _Resultado.Datos.Rows(0).Item("Direccion")
                _Debitos = _Resultado.Datos.Rows(0).Item("Debitos")
                _Creditos = _Resultado.Datos.Rows(0).Item("Creditos")
                _Saldo = _Resultado.Datos.Rows(0).Item("Saldo")
                _DiasCredito = _Resultado.Datos.Rows(0).Item("DiasCredito")
                _PorcMora = _Resultado.Datos.Rows(0).Item("PorcMora")
                _DiasGraciaMora = _Resultado.Datos.Rows(0).Item("DiasGraciaMora")
                _AplicaMora = _Resultado.Datos.Rows(0).Item("AplicaMora")
                _LimiteCredito = _Resultado.Datos.Rows(0).Item("LimiteCredito")
                _CxC_Colones = _Resultado.Datos.Rows(0).Item("CxC_Colones")
                _CxC_Dolares = _Resultado.Datos.Rows(0).Item("CxC_Dolares")
                _Activo = _Resultado.Datos.Rows(0).Item("Activo")
                _UltimaModificacion = _Resultado.Datos.Rows(0).Item("UltimaModificacion")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function RptConsultaInformacionCliente() As String
        Dim Query As String

        Try
            Query = "exec RptConsultaInformacionCliente " & _Emp_Id.ToString & "," & _Cliente_Id.ToString

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
    Public Function RptCxCClientesConSaldo(pSaldo As Double) As String
        Dim Query As String

        Try
            Query = "exec RptCxCClientesConSaldo " & _Emp_Id.ToString & "," & pSaldo.ToString

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