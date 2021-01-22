Public Class TFacturaDevolucion
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Long
    Private _Dev_Suc_Id As Integer
    Private _Dev_Caja_Id As Integer
    Private _Dev_TipoDoc_Id As Integer
    Private _Dev_Documento_Id As Long
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
    Public Property Dev_Suc_Id() As Integer
        Get
            Return _Dev_Suc_Id
        End Get
        Set(ByVal Value As Integer)
            _Dev_Suc_Id = Value
        End Set
    End Property
    Public Property Dev_Caja_Id() As Integer
        Get
            Return _Dev_Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Dev_Caja_Id = Value
        End Set
    End Property
    Public Property Dev_TipoDoc_Id() As Integer
        Get
            Return _Dev_TipoDoc_Id
        End Get
        Set(ByVal Value As Integer)
            _Dev_TipoDoc_Id = Value
        End Set
    End Property
    Public Property Dev_Documento_Id() As Long
        Get
            Return _Dev_Documento_Id
        End Get
        Set(ByVal Value As Long)
            _Dev_Documento_Id = Value
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
        _TipoDoc_Id = 0
        _Documento_Id = 0
        _Dev_Suc_Id = 0
        _Dev_Caja_Id = 0
        _Dev_TipoDoc_Id = 0
        _Dev_Documento_Id = 0
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into FacturaDevolucion( Emp_Id , Suc_Id" &
                   " , Caja_Id , TipoDoc_Id" &
                   " , Documento_Id , Dev_Suc_Id" &
                   " , Dev_Caja_Id , Dev_TipoDoc_Id" &
                   " , Dev_Documento_Id )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() &
                   "," & _Documento_Id.ToString() & "," & _Dev_Suc_Id.ToString() &
                   "," & _Dev_Caja_Id.ToString() & "," & _Dev_TipoDoc_Id.ToString() &
                   "," & _Dev_Documento_Id.ToString() & ")"

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

            Query = "Delete FacturaDevolucion" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Caja_Id=" & _Caja_Id.ToString() &
               " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
               " And    Documento_Id=" & _Documento_Id.ToString() &
               " And    Dev_Suc_Id=" & _Dev_Suc_Id.ToString() &
               " And    Dev_Caja_Id=" & _Dev_Caja_Id.ToString() &
               " And    Dev_TipoDoc_Id=" & _Dev_TipoDoc_Id.ToString() &
               " And    Dev_Documento_Id=" & _Dev_Documento_Id.ToString()

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

            Query = ""

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

            Query = "select * From FacturaDevolucion" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Caja_Id=" & _Caja_Id.ToString() &
           " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
           " And    Documento_Id=" & _Documento_Id.ToString() &
           " And    Dev_Suc_Id=" & _Dev_Suc_Id.ToString() &
           " And    Dev_Caja_Id=" & _Dev_Caja_Id.ToString() &
           " And    Dev_TipoDoc_Id=" & _Dev_TipoDoc_Id.ToString() &
           " And    Dev_Documento_Id=" & _Dev_Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _Dev_Suc_Id = Tabla.Rows(0).Item("Dev_Suc_Id")
                _Dev_Caja_Id = Tabla.Rows(0).Item("Dev_Caja_Id")
                _Dev_TipoDoc_Id = Tabla.Rows(0).Item("Dev_TipoDoc_Id")
                _Dev_Documento_Id = Tabla.Rows(0).Item("Dev_Documento_Id")
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

            Query = "select * From FacturaDevolucion"

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

            Query = "select FacturaDevolucion_Id as Numero, Nombre From FacturaDevolucion"

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
#End Region
End Class
