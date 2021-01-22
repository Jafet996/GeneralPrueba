Public Class TCuentaTipoClase
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Clase_Id As Integer
    Private _Nombre As String
    Private _Activo As Integer
    Private _UltimaModificacion As Datetime
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    Public Property Clase_Id() As Integer
        Get
            Return _Clase_Id
        End Get
        Set(ByVal Value As Integer)
            _Clase_Id = Value
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
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
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
        _Tipo_Id = 0
        _Clase_Id = 0
        _Nombre = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CuentaTipoClase( Emp_Id , Tipo_Id" & _
                    " , Clase_Id , Nombre" & _
                    " , Activo , UltimaModificacion" & _
                    " )" & _
                    " Values ( " & _Emp_Id.ToString & "," & _Tipo_Id.ToString & _
                    "," & _Clase_Id.ToString & ",'" & _Nombre & "'" & _
                    "," & _Activo.ToString & ",GETDATE()" & _
                    ")"

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
    Public Overrides Function Delete() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Delete CuentaTipoClase" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Clase_Id = " & _Clase_Id.ToString

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

            Cn.BeginTransaction()

            Query = " Update CuentaTipoClase " & _
                    " SET   Nombre = '" & _Nombre & "' " & "," & _
                    " Activo = " & _Activo & "," & _
                    " UltimaModificacion = GETDATE()" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Clase_Id = " & _Clase_Id.ToString

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
    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select * From CuentaTipoClase" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Clase_Id = " & _Clase_Id.ToString

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

            Query = "select * From CuentaTipoClase"

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

            Query = "select Clase_Id as Numero, Nombre From CuentaTipoClase" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Tipo_Id = " & _Tipo_Id.ToString & _
                    " and   Activo = 1"

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

            Query = "select a.Tipo_Id, a.Nombre as TipoNombre" & _
                    " ,b.Clase_Id, b.Nombre as ClaseNombre" & _
                    " From CuentaTipo a" & _
                    " ,CuentaTipoClase b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.Tipo_Id" & _
                    " and   b.Emp_Id = " & _Emp_Id.ToString

            If pNombre.Trim <> "" Then
                Query += " and b.Nombre Like '%" & pNombre & "%'"
            End If

            Query += " order by a.Tipo_Id asc, b.Clase_Id asc"

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

            Query = "select IsNull(MAX(Clase_Id),0) + 1 as Clase_Id From CuentaTipoClase" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString

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