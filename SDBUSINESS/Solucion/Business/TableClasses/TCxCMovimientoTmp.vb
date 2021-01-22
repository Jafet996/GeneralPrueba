Public Class TCxCMovimientoTmp
    Inherits TBaseClassManager
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Long
    Private _MensajeError As String
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
    Public Property MensajeError() As String
        Get
            Return _MensajeError
        End Get
        Set(ByVal Value As String)
            _MensajeError = Value
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
        _MensajeError = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Delete CxCMovimientoTmp" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And    Suc_Id=" & _Suc_Id.ToString() & _
                    " And    Caja_Id=" & _Caja_Id.ToString() & _
                    " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
                    " And    Documento_Id=" & _Documento_Id.ToString()

            Cn.Ejecutar(Query)

            Query = " Insert into CxCMovimientoTmp( Emp_Id , Suc_Id" & _
                    " , Caja_Id , TipoDoc_Id" & _
                    " , Documento_Id , MensajeError" & _
                    " )" & _
                    " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                    "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() & _
                    "," & _Documento_Id.ToString() & ",'" & _MensajeError & "'" & ")"

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

            Query = "Delete CxCMovimientoTmp" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And    Suc_Id=" & _Suc_Id.ToString() & _
                    " And    Caja_Id=" & _Caja_Id.ToString() & _
                    " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
                    " And    Documento_Id=" & _Documento_Id.ToString()

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

            Query = " Update dbo.CxCMovimientoTmp " & _
                    " SET   MensajeError='" & _MensajeError & "' " & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And    Suc_Id=" & _Suc_Id.ToString() & _
                    " And    Caja_Id=" & _Caja_Id.ToString() & _
                    " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
                    " And    Documento_Id=" & _Documento_Id.ToString()

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

            Query = "select * From CxCMovimientoTmp" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And    Suc_Id=" & _Suc_Id.ToString() & _
                    " And    Caja_Id=" & _Caja_Id.ToString() & _
                    " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
                    " And    Documento_Id=" & _Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _MensajeError = Tabla.Rows(0).Item("MensajeError")
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

            Query = " select a.Emp_Id" &
                    " ,a.Suc_Id" &
                    " ,a.Caja_Id" &
                    " ,a.TipoDoc_Id" &
                    " ,a.Documento_Id" &
                    " ,a.MensajeError" &
                    " ,b.Fecha" &
                    " ,b.Nombre as Cliente" &
                    " ,b.Documento_Id as Factura_Id" &
                    " ,b.TotalCobrado as Monto" &
                    " ,c.Nombre as TipoNombre" &
                    " from CxCMovimientoTmp a" &
                    " ,FacturaEncabezado b" &
                    " ,TipoDocumento c" &
                    " where a.Emp_Id = b.Emp_Id" &
                    " and   a.Suc_Id = b.Suc_Id" &
                    " and   a.Caja_Id = b.Caja_Id" &
                    " and   a.TipoDoc_Id = b.TipoDoc_Id" &
                    " and   a.Documento_Id = b.Documento_Id" &
                    " and   a.Emp_Id = c.Emp_Id" &
                    " and   a.TipoDoc_Id = c.TipoDoc_Id" &
                    " and   b.TotalCobrado > 0 " &
                    " and   a.Emp_Id = " & _Emp_Id.ToString &
                    " and   a.Suc_Id = " & _Suc_Id.ToString

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

            Query = "select CxCMovimientoTmp_Id as Numero, Nombre From CxCMovimientoTmp"

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