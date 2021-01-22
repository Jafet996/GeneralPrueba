Public Class TAuxAsientoDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Asiento_Id As Long
    Private _Linea_Id As Integer
    Private _Fecha As Datetime
    Private _Moneda As Char
    Private _CC_Id As Integer
    Private _Cuenta_Id As String
    Private _Tipo As Char
    Private _Monto As Double
    Private _MontoDolares As Double
    Private _TipoCambio As Double
    Private _Referencia As String
    Private _Descripcion As String
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
    Public Property Asiento_Id() As Long
        Get
            Return _Asiento_Id
        End Get
        Set(ByVal Value As Long)
            _Asiento_Id = Value
        End Set
    End Property
    Public Property Linea_Id() As Integer
        Get
            Return _Linea_Id
        End Get
        Set(ByVal Value As Integer)
            _Linea_Id = Value
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
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
        End Set
    End Property
    Public Property CC_Id() As Integer
        Get
            Return _CC_Id
        End Get
        Set(ByVal Value As Integer)
            _CC_Id = Value
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
    Public Property Tipo() As Char
        Get
            Return _Tipo
        End Get
        Set(ByVal Value As Char)
            _Tipo = Value
        End Set
    End Property
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
        End Set
    End Property
    Public Property MontoDolares() As Double
        Get
            Return _MontoDolares
        End Get
        Set(ByVal Value As Double)
            _MontoDolares = Value
        End Set
    End Property
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
        End Set
    End Property
    Public Property Referencia() As String
        Get
            Return _Referencia
        End Get
        Set(ByVal Value As String)
            _Referencia = Value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
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
        _Asiento_Id = 0
        _Linea_Id = 0
        _Fecha = CDate("1900/01/01")
        _Moneda = ""
        _CC_Id = 0
        _Cuenta_Id = ""
        _Tipo = ""
        _Monto = 0.0
        _MontoDolares = 0.0
        _TipoCambio = 0.0
        _Referencia = ""
        _Descripcion = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into AuxAsientoDetalle( Emp_Id , Asiento_Id" & _
                    " , Linea_Id , Fecha" & _
                    " , Moneda , CC_Id" & _
                    " , Cuenta_Id , Tipo" & _
                    " , Monto , MontoDolares" & _
                    " , TipoCambio , Referencia" & _
                    " , Descripcion )" & _
                    " Values ( " & _Emp_Id.ToString & "," & _Asiento_Id.ToString & _
                    "," & _Linea_Id.ToString & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & _
                    ",'" & _Moneda & "'" & "," & _CC_Id.ToString & _
                    ",'" & _Cuenta_Id & "'" & ",'" & _Tipo & "'" & _
                    "," & _Monto.ToString & "," & _MontoDolares.ToString & _
                    "," & _TipoCambio.ToString & ",'" & _Referencia & "'" & _
                    ",'" & _Descripcion & "'" & ")"

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

            Query = "Delete AuxAsientoDetalle" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Asiento_Id = " & _Asiento_Id.ToString & _
                    " And   Linea_Id = " & _Linea_Id.ToString

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

            Query = " Update AuxAsientoDetalle " & _
                    " SET    Fecha = " & _Fecha.ToString & "," & _
                    " Moneda = '" & _Moneda & "'" & "," & _
                    " CC_Id = " & _CC_Id & "," & _
                    " Cuenta_Id = '" & _Cuenta_Id & "'" & "," & _
                    " Tipo = '" & _Tipo & "'" & "," & _
                    " Monto = " & _Monto & "," & _
                    " MontoDolares = " & _MontoDolares & "," & _
                    " TipoCambio = " & _TipoCambio & "," & _
                    " Referencia = '" & _Referencia & "'" & "," & _
                    " Descripcion = '" & _Descripcion & "'" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Asiento_Id = " & _Asiento_Id.ToString & _
                    " And   Linea_Id = " & _Linea_Id.ToString

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

            Query = "select * From AuxAsientoDetalle" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Asiento_Id = " & _Asiento_Id.ToString & _
                    " And   Linea_Id = " & _Linea_Id.ToString

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

            Query = " select a.*" & _
                    " ,b.Nombre as CuentaNombre" & _
                    " From AuxAsientoDetalle a" & _
                    " ,Cuenta b" & _
                    " Where a.Emp_Id = b.Emp_Id" & _
                    " And   a.Cuenta_Id = b.Cuenta_Id" & _
                    " And   a.Emp_Id = " & _Emp_Id.ToString & _
                    " And   a.Asiento_Id = " & _Asiento_Id.ToString

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

            Query = "select AuxAsientoDetalle_Id as Numero, Nombre From AuxAsientoDetalle"

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

            Query = "select AuxAsientoDetalle_Id as Codigo, Nombre From AuxAsientoDetalle" & _
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

            Query = "select IsNull(MAX(AuxAsientoDetalle_Id),0) + 1 as AuxAsientoDetalle_Id From AuxAsientoDetalle" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Asiento_Id = " & _Asiento_Id.ToString

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