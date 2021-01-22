Public Class TProveedor
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Prov_Id As Integer
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
    Private _CxP_Colones As String
    Private _CxP_Dolares As String
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _Data As DataSet
    Private _DiasCredito As Integer
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
    Public Property CxP_Colones() As String
        Get
            Return _CxP_Colones
        End Get
        Set(ByVal Value As String)
            _CxP_Colones = Value
        End Set
    End Property
    Public Property CxP_Dolares() As String
        Get
            Return _CxP_Dolares
        End Get
        Set(ByVal Value As String)
            _CxP_Dolares = Value
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
    Public Property DiasCredito() As Integer
        Get
            Return _DiasCredito
        End Get
        Set(ByVal Value As Integer)
            _DiasCredito = Value
        End Set
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
        _CxP_Colones = ""
        _CxP_Dolares = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New DataSet
        _DiasCredito = 0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Proveedor( Emp_Id , Prov_Id" &
                    " , TipoIdentificacion_Id , Identificacion" &
                    " , Nombre , Telefono1" &
                    " , Telefono2 , Email" &
                    " , Direccion , Debitos" &
                    " , Creditos , Saldo" &
                    " , CxP_Colones , CxP_Dolares" &
                    " , Activo , UltimaModificacion, DiasCredito" &
                    " )" &
                    " Values ( " & _Emp_Id.ToString & "," & _Prov_Id.ToString &
                    "," & _TipoIdentificacion_Id.ToString & ",'" & _Identificacion & "'" &
                    ",'" & _Nombre & "'" & ",'" & _Telefono1 & "'" &
                    ",'" & _Telefono2 & "'" & ",'" & _Email & "'" &
                    ",'" & _Direccion & "'" & "," & _Debitos.ToString &
                    "," & _Creditos.ToString & "," & _Saldo.ToString &
                    ",'" & _CxP_Colones & "'" & ",'" & _CxP_Dolares & "'" &
                    "," & _Activo.ToString & ",GETDATE(),'" & _DiasCredito & "'" &
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

            Query = "Delete Proveedor" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Prov_Id = " & _Prov_Id.ToString

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

            Query = " Update Proveedor " &
                    " SET    TipoIdentificacion_Id = " & _TipoIdentificacion_Id.ToString & "," &
                    " Identificacion = '" & _Identificacion & "'" & "," &
                    " Nombre = '" & _Nombre & "'" & "," &
                    " Telefono1 = '" & _Telefono1 & "'" & "," &
                    " Telefono2 = '" & _Telefono2 & "'" & "," &
                    " Email = '" & _Email & "'" & "," &
                    " Direccion = '" & _Direccion & "'" & "," &
                    " Debitos = " & _Debitos & "," &
                    " Creditos = " & _Creditos & "," &
                    " Saldo = " & _Saldo & "," &
                    " CxP_Colones = '" & _CxP_Colones & "'" & "," &
                    " CxP_Dolares = '" & _CxP_Dolares & "'" & "," &
                    " Activo = " & _Activo & "," &
                    " UltimaModificacion = GETDATE()" & "," &
                    " DiasCredito = '" & _DiasCredito & "'" &
                    " Where Emp_Id = " & _Emp_Id.ToString &
                    " And   Prov_Id = " & _Prov_Id.ToString

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

            Query = "select * From Proveedor" & _
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
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select * From Proveedor"

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

            Query = "select Prov_Id as Numero, Nombre From Proveedor" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
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

            Query = "select Prov_Id as Codigo, Nombre From Proveedor" & _
                    " where Emp_Id = " & _Emp_Id.ToString

            If pNombre.Trim <> "" Then
                Query += " and Nombre Like '%" & pNombre & "%'"
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

            Query = "select IsNull(MAX(Prov_Id),0) + 1 as Prov_Id From Proveedor" & _
                    " Where Emp_Id = " & _Emp_Id.ToString

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