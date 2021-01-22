Imports System.Data.SqlClient

Public Class TEmpresa
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Nombre As String
    Private _Cedula As String
    Private _Telefono As String
    Private _Fax As String
    Private _Email As String
    Private _Direccion As String
    Private _DireccionWeb As String
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _Logo As Byte()
    Private _Data As DataSet

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
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    Public Property Cedula() As String
        Get
            Return _Cedula
        End Get
        Set(ByVal Value As String)
            _Cedula = Value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal Value As String)
            _Telefono = Value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal Value As String)
            _Fax = Value
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
    Public Property DireccionWeb() As String
        Get
            Return _DireccionWeb
        End Get
        Set(ByVal Value As String)
            _DireccionWeb = Value
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public Property Logo() As Byte()
        Get
            Return _Logo
        End Get
        Set(ByVal Value As Byte())
            _Logo = Value
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
    End Sub
    Public Sub New(pEmp_Id As Integer, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Nombre = ""
        _Cedula = ""
        _Telefono = ""
        _Fax = ""
        _Email = ""
        _Direccion = ""
        _DireccionWeb = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Logo = Nothing
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Query = "INSERT INTO Empresa(Emp_Id,Nombre,Cedula,Telefono,Fax,Email,Direccion,DireccionWeb,Activo,UltimaModificacion,Logo) VALUES(@Emp_Id,@Nombre,@Cedula,@Telefono,@Fax,@Email,@Direccion,@DireccionWeb,@Activo,@UltimaModificacion,@Logo)"

            Dim cmd As New SqlCommand(Query, Cn.ConexionObject)

            cmd.Parameters.AddWithValue("@Emp_Id", _Emp_Id)
            cmd.Parameters.AddWithValue("@Nombre", _Nombre)
            cmd.Parameters.AddWithValue("@Cedula", _Cedula)
            cmd.Parameters.AddWithValue("@Telefono", _Telefono)
            cmd.Parameters.AddWithValue("@Fax", _Fax)
            cmd.Parameters.AddWithValue("@Email", _Email)
            cmd.Parameters.AddWithValue("@Direccion", _Direccion)
            cmd.Parameters.AddWithValue("@DireccionWeb", _DireccionWeb)
            cmd.Parameters.AddWithValue("@Activo", _Activo)
            cmd.Parameters.AddWithValue("@UltimaModificacion", Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss"))

            Dim p As New SqlParameter("@Logo", SqlDbType.Image)

            If Not _Logo Is Nothing Then
                p.Value = _Logo
            Else
                p.Value = DBNull.Value
            End If

            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()

            Return ""
        Catch ex As Exception
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

            Query = "Delete Empresa" & _
               " Where     Emp_Id=" & _Emp_Id.ToString

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

        Try
            Cn.Open()

            Query = "UPDATE Empresa SET Nombre=@Nombre, Cedula=@Cedula, Telefono=@Telefono, Fax=@Fax, Email=@Email, Direccion=@Direccion, DireccionWeb=@DireccionWeb, Activo=@Activo, UltimaModificacion=@UltimaModificacion, Logo=@Logo WHERE Emp_Id = @Emp_Id"

            Dim cmd As New SqlCommand(Query, Cn.ConexionObject)
            cmd.Parameters.AddWithValue("@Emp_Id", _Emp_Id)
            cmd.Parameters.AddWithValue("@Nombre", _Nombre)
            cmd.Parameters.AddWithValue("@Cedula", _Cedula)
            cmd.Parameters.AddWithValue("@Telefono", _Telefono)
            cmd.Parameters.AddWithValue("@Fax", _Fax)
            cmd.Parameters.AddWithValue("@Email", _Email)
            cmd.Parameters.AddWithValue("@Direccion", _Direccion)
            cmd.Parameters.AddWithValue("@DireccionWeb", _DireccionWeb)
            cmd.Parameters.AddWithValue("@Activo", _Activo)
            cmd.Parameters.AddWithValue("@UltimaModificacion", Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss"))

            Dim p As New SqlParameter("@Logo", SqlDbType.Image)
            If Not _Logo Is Nothing Then
                p.Value = _Logo
            Else
                p.Value = DBNull.Value
            End If

            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()

            Return ""
        Catch ex As Exception
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

            Query = "select * From Empresa" & _
           " Where     Emp_Id=" & _Emp_Id.ToString

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
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select * From Empresa"

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
    Public Overrides Function LoadComboBox() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select Emp_Id as Numero, Nombre From Empresa"

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
    Public Overrides Function ListMant(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select Emp_Id as Codigo, Nombre From Empresa"

            If pNombre.Trim <> "" Then
                Query += " and Nombre Like '%" & pNombre & "%'"
            End If

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
    Public Overrides Function NextOne() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select IsNull(MAX(Emp_Id),0) + 1 as Emp_Id From Empresa"

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
#End Region
End Class