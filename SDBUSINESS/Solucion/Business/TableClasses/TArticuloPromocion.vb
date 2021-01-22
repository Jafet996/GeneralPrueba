Public Class TArticuloPromocion
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Art_Id As String
    Private _Promocion_Id As Integer
    Private _Precio As Double
    Private _FechaInicio As Datetime
    Private _FechaFinal As Datetime
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
    Public Property Art_Id() As String
        Get
            Return _Art_Id
        End Get
        Set(ByVal Value As String)
            _Art_Id = Value
        End Set
    End Property
    Public Property Promocion_Id() As Integer
        Get
            Return _Promocion_Id
        End Get
        Set(ByVal Value As Integer)
            _Promocion_Id = Value
        End Set
    End Property
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal Value As Double)
            _Precio = Value
        End Set
    End Property
    Public Property FechaInicio() As DateTime
        Get
            Return _FechaInicio
        End Get
        Set(ByVal Value As DateTime)
            _FechaInicio = Value
        End Set
    End Property
    Public Property FechaFinal() As DateTime
        Get
            Return _FechaFinal
        End Get
        Set(ByVal Value As DateTime)
            _FechaFinal = Value
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
        _Art_Id = ""
        _Promocion_Id = 0
        _Precio = 0.0
        _FechaInicio = CDate("1900/01/01")
        _FechaFinal = CDate("1900/01/01")
        _Fecha = CDate("1900/01/01")
        _Usuario_Id = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ArticuloPromocion( Emp_Id , Art_Id" & _
                    " , Promocion_Id , Precio" & _
                    " , FechaInicio , FechaFinal" & _
                    " , Fecha , Usuario_Id" & _
                    " )" & _
                    " Values ( " & _Emp_Id.ToString() & ",'" & _Art_Id & "'" & _
                    "," & _Promocion_Id.ToString() & "," & _Precio.ToString() & _
                    ",'" & Format(_FechaInicio, "yyyyMMdd HH:mm:ss") & "','" & Format(_FechaFinal, "yyyyMMdd HH:mm:ss") & "'" & _
                    ",GETDATE(),'" & _Usuario_Id & "')"

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

            Query = "Delete ArticuloPromocion" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And     Art_Id='" & _Art_Id & "'" & _
                    " And    Promocion_Id=" & _Promocion_Id.ToString()

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

            Query = " Update dbo.ArticuloPromocion " & _
                    " SET    Precio=" & _Precio.ToString() & "," & _
                    " FechaInicio='" & Format(_FechaInicio, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " FechaFinal='" & Format(_FechaFinal, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " Usuario_Id='" & _Usuario_Id & "'" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And     Art_Id='" & _Art_Id & "'" & _
                    " And    Promocion_Id=" & _Promocion_Id.ToString()

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

            Query = "select * From ArticuloPromocion" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And     Art_Id='" & _Art_Id & "'" & _
                    " And    Promocion_Id=" & _Promocion_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Promocion_Id = Tabla.Rows(0).Item("Promocion_Id")
                _Precio = Tabla.Rows(0).Item("Precio")
                _FechaInicio = Tabla.Rows(0).Item("FechaInicio")
                _FechaFinal = Tabla.Rows(0).Item("FechaFinal")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
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

            Query = " select a.*" & _
                    " ,b.Nombre" & _
                    " from ArticuloPromocion a" & _
                    " ,Articulo b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Art_Id = b.Art_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString

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
    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select ArticuloPromocion_Id as Numero, Nombre From ArticuloPromocion"

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
    Public Function ListBusqueda(pCriterio As String) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = " select a.*" & _
                    " ,b.Nombre" & _
                    " from ArticuloPromocion a" & _
                    " ,Articulo b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Art_Id = b.Art_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString

            If pCriterio.Trim <> String.Empty Then
                Query += " and   b.Nombre like '%" & pCriterio.Trim & "%'"
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
    Public Function ListaXArticulo()
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = " select *" & _
                    " from ArticuloPromocion" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Art_Id = '" & _Art_Id & "'"

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
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = " select ISNULL(MAX(Promocion_Id),0) + 1" & _
                    " from ArticuloPromocion" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Art_Id = '" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Promocion_Id = Tabla.Rows(0).Item(0)
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
#End Region
End Class