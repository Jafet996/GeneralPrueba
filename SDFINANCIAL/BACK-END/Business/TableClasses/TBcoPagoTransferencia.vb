Public Class TBcoPagoTransferencia
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _BcoPago_Id As Long
    Private _Banco_Id As Integer
    Private _Cuenta As String
    Private _Moneda As Char
    Private _Fecha As Datetime
    Private _TipoCambio As Double
    Private _Numero As String
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
    Public Property BcoPago_Id() As Long
        Get
            Return _BcoPago_Id
        End Get
        Set(ByVal Value As Long)
            _BcoPago_Id = Value
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
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
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
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal Value As String)
            _Numero = Value
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
        _BcoPago_Id = 0
        _Banco_Id = 0
        _Cuenta = ""
        _Moneda = ""
        _Fecha = CDate("1900/01/01")
        _TipoCambio = 0.0
        _Numero = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into BcoPagoTransferencia( Emp_Id , BcoPago_Id" & _
                    " , Banco_Id , Cuenta" & _
                    " , Moneda , Fecha" & _
                    " , TipoCambio , Numero" & _
                    " )" & _
                    " Values ( " & _Emp_Id.ToString & "," & _BcoPago_Id.ToString & _
                    "," & _Banco_Id.ToString & ",'" & _Cuenta & "'" & _
                    ",'" & _Moneda & "'" & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & _
                    "," & _TipoCambio.ToString & ",'" & _Numero & "'" & _
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

            Query = "Delete BcoPagoTransferencia" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   BcoPago_Id = " & _BcoPago_Id.ToString

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

            Query = " Update BcoPagoTransferencia " & _
                    " SET    Banco_Id = " & _Banco_Id.ToString & "," & _
                    " Cuenta = '" & _Cuenta & "'" & "," & _
                    " Moneda = '" & _Moneda & "'" & "," & _
                    " Fecha = '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " TipoCambio = " & _TipoCambio & "," & _
                    " Numero = '" & _Numero & "'" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   BcoPago_Id = " & _BcoPago_Id.ToString

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

            Query = "select * From BcoPagoTransferencia" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   BcoPago_Id = " & _BcoPago_Id.ToString

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

            Query = "select * From BcoPagoTransferencia"

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

            Query = "select BcoPagoTransferencia_Id as Numero, Nombre From BcoPagoTransferencia" & _
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

            Query = "select BcoPagoTransferencia_Id as Codigo, Nombre From BcoPagoTransferencia" & _
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

            Query = "select ISNULL(MAX(BcoPagoTransferencia_Id),0) + 1 as BcoPagoTransferencia_Id From BcoPagoTransferencia" & _
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