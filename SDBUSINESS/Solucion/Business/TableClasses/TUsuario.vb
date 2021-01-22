Public Class TUsuario
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Usuario_Id As String
    Private _Nombre As String
    Private _Password As String
    Private _Vendedor_Id As Integer
    Private _Grupo_Id As Integer
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _Modulo_Id As Integer
    Private _Permisos As New List(Of TUsuarioPermiso)
    Private _Data As DataSet
    Private _SDL As New SDFinancial.SDFinancial
    Dim SDFResultado As New SDFinancial.TResultado()
    Dim mensaje As String
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
    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal Value As Integer)
            _Vendedor_Id = Value
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
    Public ReadOnly Property Data() As DataSet
        Get
            Return _Data
        End Get
    End Property
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property


#End Region
#Region "Constructores"
    Public Sub New(pEmp_Id As Integer)
        MyBase.New()
        Inicializa()
        _Emp_Id = pEmp_Id
        '_SDL.Url = InfoMaquina.URLContabilidad
    End Sub
    Public Sub New(pEmp_Id As Integer, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        _Emp_Id = pEmp_Id
        '_SDL.Url = InfoMaquina.URLContabilidad
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Usuario_Id = ""
        _Nombre = ""
        _Password = ""
        _Vendedor_Id = 0
        _Grupo_Id = 0
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Modulo_Id = 0
        _Permisos.Clear()
        _Data = New Dataset
    End Sub
    Private Function GuardaUsuarioPermiso() As String
        Dim Query As String = ""
        Try

            Query = "Delete UsuarioPermiso" & _
               " Where  Emp_Id=" & _Emp_Id.ToString() & _
               " And    Usuario_Id='" & _Usuario_Id & "'" & _
               " And    Modulo_Id=" & _Modulo_Id.ToString

            Cn.Ejecutar(Query)

            For Each Permiso As TUsuarioPermiso In _Permisos
                Query = " Insert into UsuarioPermiso( Emp_Id , Usuario_Id" & _
                       " , Permiso_Id , Modulo_Id, UltimaModificacion )" & _
                       " Values ( " & _Emp_Id.ToString() & ",'" & _Usuario_Id & "'" & _
                       "," & Permiso.Permiso_Id.ToString() & "," & Permiso.Modulo_Id.ToString() & _
                       ",getdate())"

                Cn.Ejecutar(Query)
            Next

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        _SDL.Url = InfoMaquina.URLContabilidad
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Usuario( Emp_Id , Usuario_Id" & _
                   " , Nombre , Password" & _
                   " , Vendedor_Id , Grupo_Id" & _
                   " , Activo , UltimaModificacion" & _
                   " )" & _
                   " Values ( " & _Emp_Id.ToString() & ",'" & _Usuario_Id & "'" & _
                   ",'" & _Nombre & "'" & ",'" & _Password & "'" & _
                   "," & _Vendedor_Id.ToString() & "," & _Grupo_Id.ToString() & _
                   "," & _Activo.ToString() & ",getdate())"

            Cn.Ejecutar(Query)

            VerificaMensaje(GuardaUsuarioPermiso)

            'If EmpresaParametroInfo.InterfazCxC Then
            '    Dim usuario As New SDFinancial.DTUsuario()

            '    With usuario
            '        .Activo = _Activo
            '        .Emp_Id = .Emp_Id
            '        .Grupo_Id = Grupo_Id
            '        .Nombre = _Nombre
            '        .Password = _Password
            '        .UltimaModificacion = _UltimaModificacion
            '        .Usuario_Id = _Usuario_Id
            '    End With

            '    SDFResultado = _SDL.UsuarioMant(usuario, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            '    If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" OrElse SDFResultado.RowsAffected = 0 Then
            '        If Not SDFResultado Is Nothing Then
            '            Mensaje = SDFResultado.ErrorDescription
            '        End If

            '        VerificaMensaje("Se presentaron errores creando usuario en CXC : " & mensaje.ToString())
            '    End If

            'End If

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Delete() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = "Delete Usuario" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And     Usuario_Id='" & _Usuario_Id & "'"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Modify() As String
        Dim Query As String = ""
        _SDL.Url = InfoMaquina.URLContabilidad
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.Usuario " & _
                      " SET   Nombre='" & _Nombre & "' " & "," & _
                      " Password='" & _Password & "'" & "," & _
                      " Vendedor_Id=" & _Vendedor_Id & "," & _
                      " Grupo_Id=" & _Grupo_Id & "," & _
                      " Activo=" & _Activo & "," & _
                      " UltimaModificacion = getdate()" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And     Usuario_Id='" & _Usuario_Id & "'"

            Cn.Ejecutar(Query)

            VerificaMensaje(GuardaUsuarioPermiso)

            'If EmpresaParametroInfo.InterfazCxC Then
            '    Dim usuario As New SDFinancial.DTUsuario()

            '    With usuario
            '        .Activo = _Activo
            '        .Emp_Id = .Emp_Id
            '        .Grupo_Id = Grupo_Id
            '        .Nombre = _Nombre
            '        .Password = _Password
            '        .UltimaModificacion = _UltimaModificacion
            '        .Usuario_Id = _Usuario_Id
            '    End With

            '    SDFResultado = _SDL.UsuarioMant(usuario, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

            '    If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" Then
            '        If Not SDFResultado Is Nothing Then
            '            mensaje = SDFResultado.ErrorDescription
            '        End If

            '        VerificaMensaje("Se presentaron errores creando usuario en CXC : " & mensaje)
            '    End If

            '    'If SDFResultado.RowsAffected = 0 Then
            '    '    SDFResultado = _SDL.UsuarioMant(usuario, SDFinancial.EnumOperacionMant.Insertar, String.Empty)
            '    '    If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" OrElse SDFResultado.RowsAffected = 0 Then
            '    '        If Not SDFResultado Is Nothing Then
            '    '            mensaje = SDFResultado.ErrorDescription
            '    '        End If

            '    '        VerificaMensaje("Se presentaron errores creando usuario en CXC : " & mensaje)
            '    '    End If
            '    'End If

            'End If

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From Usuario" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And     Usuario_Id='" & _Usuario_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Password = Tabla.Rows(0).Item("Password")
                _Vendedor_Id = Tabla.Rows(0).Item("Vendedor_Id")
                _Grupo_Id = Tabla.Rows(0).Item("Grupo_Id")
                _Activo = Tabla.Rows(0).Item("Activo")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Usuario_Id as Codigo, Nombre From Usuario where Emp_Id = " & _Emp_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Usuario_Id as Numero, Nombre From Usuario where Emp_Id = " & _Emp_Id.ToString & " Order By Nombre asc "

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function ListBusqueda(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Usuario_Id as Codigo, Nombre From Usuario " & _
                "where Emp_Id = " & _Emp_Id.ToString & " and Nombre like '%" & pNombre & "%' and Activo = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function VerificaUsuarioPermisoOpcion(pModulo_Id As Modulos, pMenu_Id As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select a.* from  Usuario a,  GrupoMenu b " & _
            "where a.Emp_Id = b.Emp_Id And a.Grupo_Id = b.Grupo_Id " & _
            "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Usuario_Id = '" & _Usuario_Id & "' " & _
            "and b.Modulo_Id = " & pModulo_Id & " and b.Menu_Id = '" & pMenu_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Password = Tabla.Rows(0).Item("Password")
                _Vendedor_Id = Tabla.Rows(0).Item("Vendedor_Id")
                _Grupo_Id = Tabla.Rows(0).Item("Grupo_Id")
                _Activo = Tabla.Rows(0).Item("Activo")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

#End Region
End Class
