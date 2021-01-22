Public Class TCambioMoneda
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Cambio_Id As Integer
    Private _Tipo_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Efectivo As Double
    Private _Dolares As Double
    Private _TipoCambio As Double
    Private _Fecha As Datetime
    Private _Usuario_Id As String
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
    Public Property Cambio_Id() As Integer
        Get
            Return _Cambio_Id
        End Get
        Set(ByVal Value As Integer)
            _Cambio_Id = Value
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
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
        End Set
    End Property
    Public Property Cierre_Id() As Integer
        Get
            Return _Cierre_Id
        End Get
        Set(ByVal Value As Integer)
            _Cierre_Id = Value
        End Set
    End Property
    Public Property Efectivo() As Double
        Get
            Return _Efectivo
        End Get
        Set(ByVal Value As Double)
            _Efectivo = Value
        End Set
    End Property
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
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
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
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
        _Cambio_Id = 0
        _Tipo_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _Efectivo = 0.0
        _Dolares = 0.0
        _TipoCambio = 0.0
        _Fecha = CDate("1900/01/01")
        _Usuario_Id = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec CierreCajaAcumulaCambioMoneda " & _Emp_Id.ToString & "," & _Caja_Id.ToString & _
                    "," & _Cierre_Id.ToString & "," & _Efectivo.ToString & "," & _Dolares.ToString & _
                    "," & _TipoCambio.ToString & "," & _Tipo_Id.ToString & ",'" & _Usuario_Id & "'"

            Tabla = Cn.Seleccionar(Query)

            If Not Tabla Is Nothing OrElse Tabla.Rows.Count > 0 Then
                _Cambio_Id = Tabla.Rows(0).Item("Cambio_Id")
            Else
                VerificaMensaje("Ocurrió un error al obtener el consecutivo del movimiento")
            End If

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

            Query = "Delete CambioMoneda" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Cambio_Id = " & _Cambio_Id.ToString

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

            Query = " Update CambioMoneda " & _
                    " SET    Tipo_Id = " & _Tipo_Id.ToString & "," & _
                    " Caja_Id = " & _Caja_Id & "," & _
                    " Cierre_Id = " & _Cierre_Id & "," & _
                    " Efectivo = " & _Efectivo & "," & _
                    " Dolares = " & _Dolares & "," & _
                    " TipoCambio = " & _TipoCambio & "," & _
                    " Fecha = '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " Usuario_Id = '" & _Usuario_Id & "'" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Cambio_Id = " & _Cambio_Id.ToString

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

            Query = " select a.*" & _
                    " ,b.Nombre as UsuarioNombre" & _
                    " From CambioMoneda a" & _
                    " ,Usuario b" & _
                    " Where a.Emp_Id = b.Emp_Id" & _
                    " And   a.Usuario_Id = b.Usuario_Id" & _
                    " And   a.Emp_Id = " & _Emp_Id.ToString & _
                    " And   a.Cambio_Id = " & _Cambio_Id.ToString

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

            Query = "select * From CambioMoneda"

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

            Query = "select CambioMoneda_Id as Numero, Nombre From CambioMoneda" & _
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

            Query = "select CambioMoneda_Id as Codigo, Nombre From CambioMoneda" & _
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

            Query = "select IsNull(MAX(CambioMoneda_Id),0) + 1 as CambioMoneda_Id From CambioMoneda" & _
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