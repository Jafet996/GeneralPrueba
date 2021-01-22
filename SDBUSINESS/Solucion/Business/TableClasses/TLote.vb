Public Class TLote
    Inherits TBaseClassManager
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Lote_Id As Integer
    Private _Numero As String
    Private _Vencimiento As Date
    Private _Activo As Integer
    Private _Data As DataSet

    Private _Lote As String
    Private _Cantidad As Double


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
    Public Property Lote() As String
        Get
            Return _Lote
        End Get
        Set(ByVal value As String)
            _Lote = value
        End Set
    End Property
    Public Property Lote_Id() As Integer
        Get
            Return _Lote_Id
        End Get
        Set(ByVal Value As Integer)
            _Lote_Id = Value
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
    Public Property Vencimiento() As Date
        Get
            Return _Vencimiento
        End Get
        Set(ByVal Value As Date)
            _Vencimiento = Value
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
    Public Property Cantidad As Double
        Get
            Return _Cantidad
        End Get
        Set(value As Double)
            _Cantidad = value
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

    Public Sub New()
        _Lote = String.Empty
        _Vencimiento = #01/01/1900#
        _Cantidad = 0
    End Sub
    Private Sub Inicializa()
        _Emp_Id = 0
        _Lote_Id = 0
        _Numero = ""
        _Vencimiento = CDate("1900/01/01")
        _Activo = 0
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function ListaMantenimiento(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Lote_Id as Codigo, Numero From Lote where Emp_Id = " & _Emp_Id.ToString()

            If pNombre.Trim <> "" Then
                Query = Query & " and Numero Like '%" & pNombre & "%'"
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
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(Lote_Id),0) + 1 From Lote Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Lote_Id = Tabla.Rows(0).Item(0)
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Lote( Emp_Id , Lote_Id" &
                   " , Numero , Vencimiento" &
                   " , Activo )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Lote_Id.ToString() &
                   ",'" & _Numero & "'" & ",'" & Format(_Vencimiento, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & _Activo.ToString() & ")"

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

            Query = "Delete Lote" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Lote_Id=" & _Lote_Id.ToString()

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

            Query = " Update dbo.Lote " &
                      " SET   Numero='" & _Numero & "' " & "," &
                      " Vencimiento='" & Format(_Vencimiento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " Activo=" & _Activo &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Lote_Id=" & _Lote_Id.ToString()

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

            Query = "select * From Lote" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Lote_Id=" & _Lote_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Lote_Id = Tabla.Rows(0).Item("Lote_Id")
                _Numero = Tabla.Rows(0).Item("Numero")
                _Vencimiento = Tabla.Rows(0).Item("Vencimiento")
                _Activo = Tabla.Rows(0).Item("Activo")
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

            Query = "select * From Lote where Emp_Id = " & _Emp_Id.ToString()

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

            Query = "select Lote_Id as Numero, Nombre From Lote"

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
