Public Class TArticuloKardex
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Bod_Id As Integer
    Private _Art_Id As String
    Private _Kardex_Id As Long
    Private _Fecha As Datetime
    Private _Cantidad As Double
    Private _Detalle As String
    Private _Usuario_Id As String
    Private _Saldo As Double
    Private _Suelto As Integer
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
    Public Property Suc_Id() As Integer
        Get
            Return _Suc_Id
        End Get
        Set(ByVal Value As Integer)
            _Suc_Id = Value
        End Set
    End Property
    Public Property Bod_Id() As Integer
        Get
            Return _Bod_Id
        End Get
        Set(ByVal Value As Integer)
            _Bod_Id = Value
        End Set
    End Property
    Public Property Art_Id() As String
        Get
            Return _Art_Id
        End Get
        Set(ByVal Value As String)
            _Art_Id = Value
        End Set
    End Property
    Public Property Kardex_Id() As Long
        Get
            Return _Kardex_Id
        End Get
        Set(ByVal Value As Long)
            _Kardex_Id = Value
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
    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal Value As Double)
            _Cantidad = Value
        End Set
    End Property
    Public Property Detalle() As String
        Get
            Return _Detalle
        End Get
        Set(ByVal Value As String)
            _Detalle = Value
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
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property
    Public Property Suelto() As Integer
        Get
            Return _Suelto
        End Get
        Set(ByVal Value As Integer)
            _Suelto = Value
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
        _Suc_Id = 0
        _Bod_Id = 0
        _Art_Id = ""
        _Kardex_Id = 0
        _Fecha = CDate("1900/01/01")
        _Cantidad = 0.0
        _Detalle = ""
        _Usuario_Id = ""
        _Saldo = 0.0
        _Suelto = 0
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = " Insert into ArticuloKardex( Emp_Id , Suc_Id" & _
                   " , Bod_Id , Art_Id" & _
                   " , Kardex_Id , Fecha" & _
                   " , Cantidad , Detalle" & _
                   " , Usuario_Id , Saldo" & _
                   " , Suelto )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _Bod_Id.ToString() & ",'" & _Art_Id & "'" & _
                   "," & _Kardex_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & _
                   "," & _Cantidad.ToString() & ",'" & _Detalle & "'" & _
                   ",'" & _Usuario_Id & "'" & "," & _Saldo.ToString() & _
                   "," & _Suelto.ToString() & ")"

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

            query = "Delete ArticuloKardex" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Bod_Id=" & _Bod_Id.ToString() & _
               " And     Art_Id='" & _Art_Id & "'" & _
               " And    Kardex_Id=" & _Kardex_Id.ToString()

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

            query = " Update dbo.ArticuloKardex " & _
                      " SET    Fecha=" & _Fecha.ToString() & "," & _
                      " Cantidad=" & _Cantidad & "," & _
                      " Detalle='" & _Detalle & "'" & "," & _
                      " Usuario_Id='" & _Usuario_Id & "'" & "," & _
                      " Saldo=" & _Saldo & "," & _
                      " Suelto=" & _Suelto & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Bod_Id=" & _Bod_Id.ToString() & _
                      " And     Art_Id='" & _Art_Id & "'" & _
                      " And    Kardex_Id=" & _Kardex_Id.ToString()

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

            Query = "select * From ArticuloKardex" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    Bod_Id=" & _Bod_Id.ToString() & _
           " And     Art_Id='" & _Art_Id & "'" & _
           " And    Kardex_Id=" & _Kardex_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Kardex_Id = Tabla.Rows(0).Item("Kardex_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Cantidad = Tabla.Rows(0).Item("Cantidad")
                _Detalle = Tabla.Rows(0).Item("Detalle")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Saldo = Tabla.Rows(0).Item("Saldo")
                _Suelto = Tabla.Rows(0).Item("Suelto")
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

            Query = "select * From ArticuloKardex"

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

            Query = "select ArticuloKardex_Id as Numero, Nombre From ArticuloKardex"

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

    Public Function RptArticuloKardex(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptArticuloKardex " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() & ",'" & _Art_Id & "','" &
                     Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
