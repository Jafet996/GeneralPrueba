Public Class TEmpresaParametro
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _ProcesoAnnio As Integer
    Private _ProcesoMes As Integer
    Private _MesCierreFiscal As Integer
    Private _CuentaResultadoPeriodo As String
    Private _DiasCredito As Integer
    Private _PorcMora As Double
    Private _DiasGraciaMora As Integer
    Private _AplicaMora As Integer
    Private _CuentaIngresoXDiferencial As String
    Private _CuentaGastoXDiferencial As String
    Private _CuentaRedondeo As String
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
    Public Property ProcesoAnnio() As Integer
        Get
            Return _ProcesoAnnio
        End Get
        Set(ByVal Value As Integer)
            _ProcesoAnnio = Value
        End Set
    End Property
    Public Property ProcesoMes() As Integer
        Get
            Return _ProcesoMes
        End Get
        Set(ByVal Value As Integer)
            _ProcesoMes = Value
        End Set
    End Property
    Public Property MesCierreFiscal() As Integer
        Get
            Return _MesCierreFiscal
        End Get
        Set(ByVal Value As Integer)
            _MesCierreFiscal = Value
        End Set
    End Property
    Public Property CuentaResultadoPeriodo() As String
        Get
            Return _CuentaResultadoPeriodo
        End Get
        Set(ByVal Value As String)
            _CuentaResultadoPeriodo = Value
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
    Public Property CuentaIngresoXDiferencial() As String
        Get
            Return _CuentaIngresoXDiferencial
        End Get
        Set(ByVal Value As String)
            _CuentaIngresoXDiferencial = Value
        End Set
    End Property
    Public Property CuentaGastoXDiferencial() As String
        Get
            Return _CuentaGastoXDiferencial
        End Get
        Set(ByVal Value As String)
            _CuentaGastoXDiferencial = Value
        End Set
    End Property
    Public Property CuentaRedondeo() As String
        Get
            Return _CuentaRedondeo
        End Get
        Set(ByVal Value As String)
            _CuentaRedondeo = Value
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
        _ProcesoAnnio = 0
        _ProcesoMes = 0
        _MesCierreFiscal = 0
        _CuentaResultadoPeriodo = ""
        _DiasCredito = 0
        _PorcMora = 0.0
        _DiasGraciaMora = 0
        _AplicaMora = 0
        _CuentaIngresoXDiferencial = ""
        _CuentaGastoXDiferencial = ""
        _CuentaRedondeo = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into EmpresaParametro( Emp_Id , ProcesoAnnio" & _
                    " , ProcesoMes , MesCierreFiscal" & _
                    " , CuentaResultadoPeriodo , DiasCredito" & _
                    " , PorcMora , DiasGraciaMora" & _
                    " , AplicaMora , CuentaIngresoXDiferencial" & _
                    " , CuentaGastoXDiferencial , CuentaRedondeo )" & _
                    " Values ( " & _Emp_Id.ToString & "," & _ProcesoAnnio.ToString & _
                    "," & _ProcesoMes.ToString & "," & _MesCierreFiscal.ToString & _
                    ",'" & _CuentaResultadoPeriodo & "'" & "," & _DiasCredito.ToString & _
                    "," & _PorcMora.ToString & "," & _DiasGraciaMora.ToString & _
                    "," & _AplicaMora.ToString & ",'" & _CuentaIngresoXDiferencial & "'" & _
                    ",'" & _CuentaGastoXDiferencial & "'" & ",'" & _CuentaRedondeo & "'" & ")"

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

            Query = "Delete EmpresaParametro" & _
                    " Where Emp_Id = " & _Emp_Id.ToString

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

            Query = " Update EmpresaParametro " & _
                    " SET    ProcesoAnnio = " & _ProcesoAnnio.ToString & "," & _
                    " ProcesoMes = " & _ProcesoMes & "," & _
                    " MesCierreFiscal = " & _MesCierreFiscal & "," & _
                    " CuentaResultadoPeriodo = '" & _CuentaResultadoPeriodo & "'" & "," & _
                    " DiasCredito = " & _DiasCredito & "," & _
                    " PorcMora = " & _PorcMora & "," & _
                    " DiasGraciaMora = " & _DiasGraciaMora & "," & _
                    " AplicaMora = " & _AplicaMora & "," & _
                    " CuentaIngresoXDiferencial = '" & _CuentaIngresoXDiferencial & "'" & "," & _
                    " CuentaGastoXDiferencial = '" & _CuentaGastoXDiferencial & "'" & "," & _
                    " CuentaRedondeo = '" & _CuentaRedondeo & "'" & _
                    " Where Emp_Id = " & _Emp_Id.ToString

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

            Query = "select * From EmpresaParametro" & _
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
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select * From EmpresaParametro"

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

            Query = "select EmpresaParametro_Id as Numero, Nombre From EmpresaParametro"

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

            Query = "select EmpresaParametro_Id as Codigo, Nombre From EmpresaParametro" & _
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

            Query = "select IsNull(MAX(EmpresaParametro_Id),0) + 1 as EmpresaParametro_Id From EmpresaParametro"

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