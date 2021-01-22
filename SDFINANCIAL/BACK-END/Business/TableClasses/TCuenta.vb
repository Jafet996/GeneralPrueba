Public Class TCuenta
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Cuenta_Id As String
    Private _Nombre As String
    Private _Tipo_Id As Integer
    Private _Clase_Id As Integer
    Private _Nivel As Integer
    Private _Padre_Id As String
    Private _Moneda As Char
    Private _AceptaMovimiento As Integer
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _SolicitaCentroCosto As Integer
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
    Public Property Cuenta_Id() As String
        Get
            Return _Cuenta_Id
        End Get
        Set(ByVal Value As String)
            _Cuenta_Id = Value
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
    Public Property Nivel() As Integer
        Get
            Return _Nivel
        End Get
        Set(ByVal Value As Integer)
            _Nivel = Value
        End Set
    End Property
    Public Property Padre_Id() As String
        Get
            Return _Padre_Id
        End Get
        Set(ByVal Value As String)
            _Padre_Id = Value
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
    Public Property AceptaMovimiento() As Integer
        Get
            Return _AceptaMovimiento
        End Get
        Set(ByVal Value As Integer)
            _AceptaMovimiento = Value
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
    Public Property SolicitaCentroCosto() As Integer
        Get
            Return _SolicitaCentroCosto
        End Get
        Set(ByVal Value As Integer)
            _SolicitaCentroCosto = Value
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
        _Cuenta_Id = ""
        _Nombre = ""
        _Tipo_Id = 0
        _Clase_Id = 0
        _Nivel = 0
        _Padre_Id = ""
        _Moneda = ""
        _AceptaMovimiento = 0
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _SolicitaCentroCosto = 0
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Cuenta( Emp_Id , Cuenta_Id" & _
                    " , Nombre , Tipo_Id" & _
                    " , Clase_Id , Nivel" & _
                    " , Padre_Id , Moneda" & _
                    " , AceptaMovimiento , Activo" & _
                    " , UltimaModificacion , SolicitaCentroCosto" & _
                    " )" & _
                    " Values ( " & _Emp_Id.ToString & ",'" & _Cuenta_Id & "'" & _
                    ",'" & _Nombre & "'" & "," & _Tipo_Id.ToString & _
                    "," & _Clase_Id.ToString & "," & _Nivel.ToString & _
                    "," & IIf(_Nivel = 1, "Null", "'" & _Padre_Id & "'") & ",'" & _Moneda & "'" & _
                    "," & _AceptaMovimiento.ToString & "," & _Activo.ToString & _
                    ",GETDATE()" & "," & _SolicitaCentroCosto.ToString & _
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

            Query = "Delete Cuenta" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Cuenta_Id = '" & _Cuenta_Id & "'"

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

            Query = " Update Cuenta " & _
                    " SET   Nombre = '" & _Nombre & "' " & "," & _
                    " Tipo_Id = " & _Tipo_Id & "," & _
                    " Clase_Id = " & _Clase_Id & "," & _
                    " Nivel = " & _Nivel & "," & _
                    " Moneda = '" & _Moneda & "'" & "," & _
                    " AceptaMovimiento = " & _AceptaMovimiento & "," & _
                    " Activo = " & _Activo & "," & _
                    " UltimaModificacion = GETDATE()" & "," & _
                    " SolicitaCentroCosto = " & _SolicitaCentroCosto & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Cuenta_Id = '" & _Cuenta_Id & "'"

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


            Query = "select a.*, b.Nombre as TipoNombre, b.CCTipo_Id, c.Nombre as ClaseNombre" & _
                    " from  Cuenta a, CuentaTipo b, CuentaTipoClase c" & _
                    " where a.Emp_Id = b.Emp_Id And a.Tipo_Id = b.Tipo_Id" & _
                    " and   a.Emp_Id = c.Emp_Id and a.Tipo_Id = c.Tipo_Id and a.Clase_Id = c.Clase_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString & " And a.Cuenta_Id = '" & _Cuenta_Id & "'"

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

            Query = "select * From Cuenta"

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

            Query = "select Cuenta_Id as Numero, Nombre From Cuenta"

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

            Query = "select Cuenta_Id as Codigo, Nombre From Cuenta" & _
                    " where Emp_Id = " & _Emp_Id.ToString

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

            Query = "select IsNull(MAX(Cuenta_Id),0) + 1 as Cuenta_Id From Cuenta" & _
                    " Where Emp_Id = " & _Emp_Id.ToString

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