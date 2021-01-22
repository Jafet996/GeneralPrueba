Public Class TTipoPago
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _TipoPago_Id As Integer
    Private _Nombre As String
    Private _PorcDescuentoDesde As Double
    Private _PorcDescuentoHasta As Double
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
    Public Property TipoPago_Id() As Integer
        Get
            Return _TipoPago_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoPago_Id = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    Public Property PorcDescuentoDesde() As Double
        Get
            Return _PorcDescuentoDesde
        End Get
        Set(ByVal Value As Double)
            _PorcDescuentoDesde = Value
        End Set
    End Property
    Public Property PorcDescuentoHasta() As Double
        Get
            Return _PorcDescuentoHasta
        End Get
        Set(ByVal Value As Double)
            _PorcDescuentoHasta = Value
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
        _TipoPago_Id = 0
        _Nombre = ""
        _PorcDescuentoDesde = 0.00
        _PorcDescuentoHasta = 0.00
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function ListaMantenimiento(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select TipoPago_Id as Codigo, Nombre From TipoPago where Emp_Id = " & _Emp_Id.ToString()

            If pNombre.Trim <> "" Then
                Query = Query & " and Nombre Like '%" & pNombre & "%'"
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

            Query = "select isnull(max(TipoPago_Id),0) + 1 From TipoPago Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _TipoPago_Id = Tabla.Rows(0).Item(0)
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

            Query = " Insert into TipoPago( Emp_Id , TipoPago_Id" &
                   " , Nombre , PorcDescuentoDesde, PorcDescuentoHasta" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _TipoPago_Id.ToString() &
                   ",'" & _Nombre & "'" & "," & _PorcDescuentoDesde.ToString() & "," & _PorcDescuentoHasta.ToString() & ")"
            '------------------------------------------------
            '-----------------------------------------------
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

            Query = "Delete TipoPago" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    TipoPago_Id=" & _TipoPago_Id.ToString()

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

            Query = " Update dbo.TipoPago " &
           " SET   Nombre='" & _Nombre & "' " & "," &
           " PorcDescuentoDesde=" & _PorcDescuentoDesde & "," &
           " PorcDescuentoHasta=" & _PorcDescuentoHasta &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    TipoPago_Id=" & _TipoPago_Id.ToString()

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

            Query = "select * From TipoPago" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    TipoPago_Id=" & _TipoPago_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _TipoPago_Id = Tabla.Rows(0).Item("TipoPago_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _PorcDescuentoDesde = Tabla.Rows(0).Item("PorcDescuentoDesde")
                _PorcDescuentoHasta = Tabla.Rows(0).Item("PorcDescuentoHasta")
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

            Query = "select * From TipoPago"

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

            Query = "select TipoPago_Id as Numero, Nombre From TipoPago"

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

    Public Function GetRangoDescuento(pTipo As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = " select max(PorcDescuentoDesde) as PorcDescuentoDesde, min(PorcDescuentoHasta) as PorcDescuentoHasta" &
            " from TipoPago where Emp_Id = " & _Emp_Id.ToString() & " And TipoPago_Id in (" & pTipo & ")"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _PorcDescuentoDesde = Tabla.Rows(0).Item("PorcDescuentoDesde")
                _PorcDescuentoHasta = Tabla.Rows(0).Item("PorcDescuentoHasta")
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
