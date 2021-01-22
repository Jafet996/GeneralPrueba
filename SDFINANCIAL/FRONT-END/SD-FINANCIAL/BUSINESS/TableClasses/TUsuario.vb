Public Class TUsuario
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Usuario_Id As String
    Private _Nombre As String
    Private _Password As String
    Private _Grupo_Id As Integer
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _Modulo_Id As Integer
    Private _Permisos As New List(Of TUsuarioPermiso)
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTUsuario
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
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property
    Public Property Grupo_Id() As Integer
        Get
            Return _Grupo_Id
        End Get
        Set(ByVal Value As Integer)
            _Grupo_Id = Value
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
    Public Property Modulo_Id As Integer
        Get
            Return _Modulo_Id
        End Get
        Set(value As Integer)
            _Modulo_Id = value
        End Set
    End Property
    Public Property Permisos As List(Of TUsuarioPermiso)
        Get
            Return _Permisos
        End Get
        Set(value As List(Of TUsuarioPermiso))
            _Permisos = value
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
        _Nombre = ""
        _Password = ""
        _Grupo_Id = 0
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
    Private Function GuardaUsuarioPermiso() As String
        Dim Query As String = ""

        Try
            Query = "Delete UsuarioPermiso" & _
               " Where  Emp_Id=" & _Emp_Id.ToString() & _
               " And    Usuario_Id='" & _Usuario_Id & "'" & _
               " And    Modulo_Id=" & _Modulo_Id.ToString

            _Resultado = _SDWCF.ExecuteQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            For Each Permiso As TUsuarioPermiso In _Permisos
                Query = " Insert into UsuarioPermiso( Emp_Id , Usuario_Id" & _
                       " , Permiso_Id , Modulo_Id, UltimaModificacion )" & _
                       " Values ( " & _Emp_Id.ToString() & ",'" & _Usuario_Id & "'" & _
                       "," & Permiso.Permiso_Id.ToString() & "," & Permiso.Modulo_Id.ToString() & _
                       ",getdate())"

                _Resultado = _SDWCF.ExecuteQuery(Query, String.Empty)

                MsgError = _Resultado.ErrorDescription
                VerificaMsgError()
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Usuario_Id = _Usuario_Id
                .Nombre = _Nombre
                .Password = _Password
                .Grupo_Id = _Grupo_Id
                .Activo = _Activo
            End With

            _Resultado = _SDWCF.UsuarioMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            VerificaMensaje(GuardaUsuarioPermiso)

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
            End With

            _Resultado = _SDWCF.UsuarioMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Nombre = _Nombre
                .Password = _Password
                .Grupo_Id = _Grupo_Id
                .Activo = _Activo
            End With

            _Resultado = _SDWCF.UsuarioMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            VerificaMensaje(GuardaUsuarioPermiso)

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
            End With

            _Resultado = _SDWCF.UsuarioMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Emp_Id = Fila("Emp_Id")
                    _Usuario_Id = Fila("Usuario_Id")
                    _Nombre = Fila("Nombre")
                    _Password = Fila("Password")
                    _Grupo_Id = Fila("Grupo_Id")
                    _Activo = Fila("Activo")
                    _UltimaModificacion = Fila("UltimaModificacion")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.UsuarioMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.UsuarioMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.UsuarioMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.UsuarioMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Usuario_Id = Fila("Usuario_Id")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function VerificaUsuarioPermisoOpcion(pModulo_Id As Enum_Modulos, pMenu_Id As String) As String
        Dim Query As String

        Try
            Query = "select a.* from  Usuario a,  GrupoMenu b " & _
                    "where a.Emp_Id = b.Emp_Id And a.Grupo_Id = b.Grupo_Id " & _
                    "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Usuario_Id = '" & _Usuario_Id & "' " & _
                    "and b.Modulo_Id = " & pModulo_Id & " and b.Menu_Id = '" & pMenu_Id & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Emp_Id = Fila("Emp_Id")
                    _Usuario_Id = Fila("Usuario_Id")
                    _Nombre = Fila("Nombre")
                    _Password = Fila("Password")
                    _Grupo_Id = Fila("Grupo_Id")
                    _Activo = Fila("Activo")
                    _UltimaModificacion = Fila("UltimaModificacion")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class
