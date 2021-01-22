Public Class TCajaCierreAsiento
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Long
    Private _Asiento_Id As Integer
    Private _Tipo As Char
    Private _Cuenta As String
    Private _Monto As Double
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
    Public Property TipoDoc_Id() As Integer
        Get
            Return _TipoDoc_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoDoc_Id = Value
        End Set
    End Property
    Public Property Documento_Id() As Long
        Get
            Return _Documento_Id
        End Get
        Set(ByVal Value As Long)
            _Documento_Id = Value
        End Set
    End Property
    Public Property Asiento_Id() As Integer
        Get
            Return _Asiento_Id
        End Get
        Set(ByVal Value As Integer)
            _Asiento_Id = Value
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
    Public Property Cuenta() As String
        Get
            Return _Cuenta
        End Get
        Set(ByVal Value As String)
            _Cuenta = Value
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
        _Caja_Id = 0
        _Cierre_Id = 0
        _TipoDoc_Id = 0
        _Documento_Id = 0
        _Asiento_Id = 0
        _Tipo = ""
        _Cuenta = ""
        _Monto = 0.0
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CajaCierreAsiento( Emp_Id , Suc_Id" & _
                   " , Caja_Id , Cierre_Id" & _
                   " , TipoDoc_Id , Documento_Id" & _
                   " , Asiento_Id , Tipo" & _
                   " , Cuenta , Monto" & _
                   " )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() & _
                   "," & _TipoDoc_Id.ToString() & "," & _Documento_Id.ToString() & _
                   "," & _Asiento_Id.ToString() & ",'" & _Tipo & "'" & _
                   ",'" & _Cuenta & "'" & "," & _Monto.ToString() & ")"

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

            query = "Delete CajaCierreAsiento" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Caja_Id=" & _Caja_Id.ToString() & _
               " And    Cierre_Id=" & _Cierre_Id.ToString() & _
               " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
               " And    Documento_Id=" & _Documento_Id.ToString() & _
               " And    Asiento_Id=" & _Asiento_Id.ToString()

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

            query = " Update dbo.CajaCierreAsiento " & _
                      " SET   Tipo='" & _Tipo & "' " & "," & _
                      " Cuenta='" & _Cuenta & "'" & "," & _
                      " Monto=" & _Monto & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Caja_Id=" & _Caja_Id.ToString() & _
                      " And    Cierre_Id=" & _Cierre_Id.ToString() & _
                      " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
                      " And    Documento_Id=" & _Documento_Id.ToString() & _
                      " And    Asiento_Id=" & _Asiento_Id.ToString()

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

            Query = "select * From CajaCierreAsiento" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    Caja_Id=" & _Caja_Id.ToString() & _
           " And    Cierre_Id=" & _Cierre_Id.ToString() & _
           " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
           " And    Documento_Id=" & _Documento_Id.ToString() & _
           " And    Asiento_Id=" & _Asiento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _Asiento_Id = Tabla.Rows(0).Item("Asiento_Id")
                _Tipo = Tabla.Rows(0).Item("Tipo")
                _Cuenta = Tabla.Rows(0).Item("Cuenta")
                _Monto = Tabla.Rows(0).Item("Monto")
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

            Query = "select Suc_Id, Caja_Id, Cierre_Id,Cuenta,Tipo,sum (Monto) as Monto From CajaCierreAsiento" & _
            " Where     Emp_Id=" & _Emp_Id.ToString() & _
            " And    Suc_Id=" & _Suc_Id.ToString() & _
            " And    Caja_Id=" & _Caja_Id.ToString() & _
            " And    Cierre_Id=" & _Cierre_Id.ToString() & _
            "group by Suc_Id, Caja_Id, Cierre_Id,Cuenta,Tipo"

            Tabla = Cn.Seleccionar(Query).Copy
            Tabla.TableName = "CierreDetalle"

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

            Query = "select CajaCierreAsiento_Id as Numero, Nombre From CajaCierreAsiento"

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
    Public Function RptCierreContable() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "RptCierreContable " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString()

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
    Public Function SD_RptCierreContable() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec SD_RptCierreContable " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Caja_Id.ToString & "," & _Cierre_Id.ToString

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


    Public Function CierreAsientosPendientes() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "CierreAsientosPendientes " & _Emp_Id.ToString & "," & _Suc_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy
            Tabla.TableName = "Cierre"

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