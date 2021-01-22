Public Class TEntradaDetalleLote
    Inherits TBaseClassManager
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Entrada_Id As Integer
    Private _Detalle_Id As Integer
    Private _Lote_Id As Integer
    Private _Art_Id As String
    Private _Lote As String
    Private _Cantidad As Double
    Private _Vencimiento As DateTime
    Private _Bod_Id As Integer
    Private _Fecha As DateTime
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
    Public Property Entrada_Id() As Integer
        Get
            Return _Entrada_Id
        End Get
        Set(ByVal Value As Integer)
            _Entrada_Id = Value
        End Set
    End Property
    Public Property Detalle_Id() As Integer
        Get
            Return _Detalle_Id
        End Get
        Set(ByVal Value As Integer)
            _Detalle_Id = Value
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
    Public Property Art_Id() As String
        Get
            Return _Art_Id
        End Get
        Set(ByVal Value As String)
            _Art_Id = Value
        End Set
    End Property
    Public Property Lote() As String
        Get
            Return _Lote
        End Get
        Set(ByVal Value As String)
            _Lote = Value
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
    Public Property Vencimiento() As DateTime
        Get
            Return _Vencimiento
        End Get
        Set(ByVal Value As DateTime)
            _Vencimiento = Value
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
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
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
        _Entrada_Id = 0
        _Detalle_Id = 0
        _Lote_Id = 0
        _Art_Id = ""
        _Lote = ""
        _Cantidad = 0.00
        _Vencimiento = CDate("1900/01/01")
        _Bod_Id = 0
        _Fecha = CDate("1900/01/01")
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into EntradaDetalleLote( Emp_Id , Suc_Id" &
                   " , Entrada_Id , Detalle_Id" &
                   " , Lote_Id , Art_Id" &
                   " , Lote , Cantidad" &
                   " , Vencimiento , Bod_Id" &
                   " , Fecha )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Entrada_Id.ToString() & "," & _Detalle_Id.ToString() &
                   "," & _Lote_Id.ToString() & ",'" & _Art_Id & "'" &
                   ",'" & _Lote & "'" & "," & _Cantidad.ToString() &
                   ",'" & Format(_Vencimiento, "yyyyMMdd HH:mm:ss") & "'" & "," & _Bod_Id.ToString() &
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ")"

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

            Query = "Delete EntradaDetalleLote" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Entrada_Id=" & _Entrada_Id.ToString() &
               " And    Detalle_Id=" & _Detalle_Id.ToString() &
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

            Query = " Update dbo.EntradaDetalleLote " &
                      " SET   Art_Id='" & _Art_Id & "' " & "," &
                      " Lote='" & _Lote & "'" & "," &
                      " Cantidad=" & _Cantidad & "," &
                      " Vencimiento='" & Format(_Vencimiento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " Bod_Id=" & _Bod_Id & "," &
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Entrada_Id=" & _Entrada_Id.ToString() &
                      " And    Detalle_Id=" & _Detalle_Id.ToString() &
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

            Query = "select * From EntradaDetalleLote" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Entrada_Id=" & _Entrada_Id.ToString() &
           " And    Detalle_Id=" & _Detalle_Id.ToString() &
           " And    Lote_Id=" & _Lote_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Entrada_Id = Tabla.Rows(0).Item("Entrada_Id")
                _Detalle_Id = Tabla.Rows(0).Item("Detalle_Id")
                _Lote_Id = Tabla.Rows(0).Item("Lote_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Lote = Tabla.Rows(0).Item("Lote")
                _Cantidad = Tabla.Rows(0).Item("Cantidad")
                _Vencimiento = Tabla.Rows(0).Item("Vencimiento")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
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

            Query = "select * From EntradaDetalleLote"

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

            Query = "select EntradaDetalleLote_Id as Numero, Nombre From EntradaDetalleLote"

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
    Public Function LotesEntradaMercaderia() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec LotesEntradaMercaderia " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Entrada_Id.ToString

            Tabla = Cn.Seleccionar(Query)

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