Public Class TProveedorCuenta
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Prov_Id As Integer
    Private _Cuenta_Id As Integer
    Private _Banco_Id As Integer
    Private _Cuenta As String
    Private _Moneda As Char
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
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
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
        End Set
    End Property
    Public Property Cuenta_Id() As Integer
        Get
            Return _Cuenta_Id
        End Get
        Set(ByVal Value As Integer)
            _Cuenta_Id = Value
        End Set
    End Property
    Public Property Banco_Id() As Integer
        Get
            Return _Banco_Id
        End Get
        Set(ByVal Value As Integer)
            _Banco_Id = Value
        End Set
    End Property
    Public Property Cuenta() As String
        Get
            Return _Cuenta
        End Get
        Set(ByVal Value As String)
            _Cuenta = Value
        End Set
    End Property
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
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
        _Prov_Id = 0
        _Cuenta_Id = 0
        _Banco_Id = 0
        _Cuenta = ""
        _Moneda = ""
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

            Query = " Insert into ProveedorCuenta( Emp_Id , Prov_Id" & _
                    " , Cuenta_Id , Banco_Id" & _
                    " , Cuenta , Moneda" & _
                    " , Activo , UltimaModificacion" & _
                    " )" & _
                    " Values ( " & _Emp_Id.ToString & "," & _Prov_Id.ToString & _
                    "," & _Cuenta_Id.ToString & "," & _Banco_Id.ToString & _
                    ",'" & _Cuenta & "'" & ",'" & _Moneda.ToString & "'" & _
                    "," & _Activo.ToString & ",GETDATE()" & _
                    ")"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return String.Empty
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

            Query = "Delete ProveedorCuenta" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Prov_Id = " & _Prov_Id.ToString & _
                    " And   Cuenta_Id = " & _Cuenta_Id.ToString

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return String.Empty
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

            Query = " Update ProveedorCuenta " & _
                    " SET    Banco_Id = " & _Banco_Id.ToString & "," & _
                    " Cuenta = '" & _Cuenta & "'" & "," & _
                    " Moneda = '" & _Moneda & "'" & "," & _
                    " Activo = " & _Activo & "," & _
                    " UltimaModificacion = GETDATE()" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Prov_Id = " & _Prov_Id.ToString & _
                    " And   Cuenta_Id = " & _Cuenta_Id.ToString

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return String.Empty
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

            Query = "select * From ProveedorCuenta" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Prov_Id = " & _Prov_Id.ToString & _
                    " And   Cuenta_Id = " & _Cuenta_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = "select * From ProveedorCuenta"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = " select Cuenta_Id as Numero, Cuenta as Nombre From ProveedorCuenta" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Banco_Id = " & _Banco_Id.ToString & _
                    " and   Prov_Id = " & _Prov_Id.ToString & _
                    " and   Activo = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = " select a.Cuenta_Id as Codigo" & _
                    " ,b.Nombre" & _
                    " ,a.Cuenta" & _
                    " ,IIf(a.Moneda = 'C','COLONES','DOLARES') as Moneda" & _
                    " From ProveedorCuenta a" & _
                    " ,Banco b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Banco_Id = b.Banco_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString & _
                    " and   a.Prov_Id = " & _Prov_Id.ToString

            If pNombre.Trim <> "" Then
                Query += " and   b.Nombre like '%" & pNombre & "%'"
            End If

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
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

            Query = "select ISNULL(MAX(Cuenta_Id),0) + 1 as Cuenta_Id From ProveedorCuenta" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Prov_Id = " & _Prov_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
#End Region
End Class