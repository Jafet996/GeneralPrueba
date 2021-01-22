Public Class TUsuarioCodigoPermiso
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Usuario_Id As String
    Private _Codigo_Id As Integer
    Private _Codigo As String
    Private _Activo As Integer
    Private _Fecha As Datetime
    Private _FechaVencimiento As Datetime
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTUsuarioCodigoPermiso
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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public Property Codigo_Id() As Integer
        Get
            Return _Codigo_Id
        End Get
        Set(ByVal Value As Integer)
            _Codigo_Id = Value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal Value As String)
            _Codigo = Value
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
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
        End Set
    End Property
    Public Property FechaVencimiento() As Datetime
        Get
            Return _FechaVencimiento
        End Get
        Set(ByVal Value As Datetime)
            _FechaVencimiento = Value
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
        _Usuario_Id = ""
        _Codigo_Id = 0
        _Codigo = ""
        _Activo = 0
        _Fecha = CDate("1900/01/01")
        _FechaVencimiento = CDate("1900/01/01")
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Usuario_Id = _Usuario_Id
                .Codigo_Id = _Codigo_Id
                .Codigo = _Codigo
                .Activo = _Activo
                .Fecha = _Fecha
                .FechaVencimiento = _FechaVencimiento
            End With

            _Resultado = _SDWCF.UsuarioCodigoPermisoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Usuario_Id = _Usuario_Id
                .Codigo_Id = _Codigo_Id
            End With

            _Resultado = _SDWCF.UsuarioCodigoPermisoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Usuario_Id = _Usuario_Id
                .Codigo_Id = _Codigo_Id
                .Codigo = _Codigo
                .Activo = _Activo
                .Fecha = _Fecha
                .FechaVencimiento = _FechaVencimiento
            End With

            _Resultado = _SDWCF.UsuarioCodigoPermisoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Usuario_Id = _Usuario_Id
                .Codigo_Id = _Codigo_Id
            End With

            _Resultado = _SDWCF.UsuarioCodigoPermisoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Emp_Id = Fila("Emp_Id")
                    _Usuario_Id = Fila("Usuario_Id")
                    _Codigo_Id = Fila("Codigo_Id")
                    _Codigo = Fila("Codigo")
                    _Activo = Fila("Activo")
                    _Fecha = Fila("Fecha")
                    _FechaVencimiento = Fila("FechaVencimiento")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.UsuarioCodigoPermisoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.UsuarioCodigoPermisoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
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

            _Resultado = _SDWCF.UsuarioCodigoPermisoMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
                .Usuario_Id = _Usuario_Id
            End With

            _Resultado = _SDWCF.UsuarioCodigoPermisoMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Codigo_Id = Fila("Codigo_Id")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ListaxUsuario() As String
        Dim Query As String

        Try
            Query = "select * From UsuarioCodigoPermiso" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Usuario_Id = '" & _Usuario_Id & "'" & _
                    " and   FechaVencimiento >= getdate()" & _
                    " and   Activo = 1"

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
    Public Function ListKeyXCodigo() As String
        Dim Query As String

        Try
            Query = "select * From UsuarioCodigoPermiso" & _
                    " Where Emp_Id=" & _Emp_Id.ToString() & _
                    " And   Codigo='" & _Codigo & "'" & _
                    " and   FechaVencimiento >= getdate()" & _
                    " And   Activo = 1"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Emp_Id = Fila("Emp_Id")
                    _Usuario_Id = Fila("Usuario_Id")
                    _Codigo_Id = Fila("Codigo_Id")
                    _Codigo = Fila("Codigo")
                    _Activo = Fila("Activo")
                    _Fecha = Fila("Fecha")
                    _FechaVencimiento = Fila("FechaVencimiento")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class
