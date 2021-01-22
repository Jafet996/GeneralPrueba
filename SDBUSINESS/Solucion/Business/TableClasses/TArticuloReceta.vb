Public Class TArticuloReceta
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Art_Id As String
    Private _Ingrediente_Id As String
    Private _Cantidad As Double
    Private _UltimaModificacion As DateTime
    Private _Data As DataSet
    Private _Ingredientes As New List(Of String)

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
    Public Property Ingrediente_Id() As String
        Get
            Return _Ingrediente_Id
        End Get
        Set(ByVal Value As String)
            _Ingrediente_Id = Value
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
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
    Public Property Ingredientes As List(Of String)
        Get
            Return _Ingredientes
        End Get
        Set(value As List(Of String))
            _Ingredientes = value
        End Set
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
        _Ingrediente_Id = ""
        _Cantidad = 0.00
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ArticuloReceta( Emp_Id , Art_Id" &
                   " , Ingrediente_Id , Cantidad" &
                   " , UltimaModificacion )" &
                   " Values ( " & _Emp_Id.ToString() & ",'" & _Art_Id & "'" &
                   ",'" & _Ingrediente_Id.ToString() & "'" & "," & _Cantidad.ToString() &
                   ",'" & Format(_UltimaModificacion, "yyyyMMdd") & "'" & ")"

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

            Query = "Delete ArticuloReceta" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And     Art_Id='" & _Art_Id & "'" &
               " And     Ingrediente_Id='" & _Ingrediente_Id & "'"

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

            Query = " Update dbo.ArticuloReceta " &
                      " SET    Cantidad=" & _Cantidad.ToString() & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And     Art_Id='" & _Art_Id & "'" &
                      " And     Ingrediente_Id='" & _Ingrediente_Id & "'"

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

            Query = "select * From ArticuloReceta" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And     Art_Id='" & _Art_Id & "'" &
           " And     Ingrediente_Id='" & _Ingrediente_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Ingrediente_Id = Tabla.Rows(0).Item("Ingrediente_Id")
                _Cantidad = Tabla.Rows(0).Item("Cantidad")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
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

            Query = "select * From ArticuloReceta"

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

            Query = "select ArticuloReceta_Id as Numero, Nombre From ArticuloReceta"

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
    Public Function ListaMantenimiento(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            If pNombre.Trim <> "" Then
                Query = "select a.Art_Id as Codigo, b.Nombre " &
                    "From ArticuloReceta a inner join Articulo b on a.Emp_Id =b.Emp_Id and a.Art_Id = b.Art_Id" &
                    " where a.Emp_Id = " & _Emp_Id.ToString() &
                    " and Nombre Like '%" & pNombre & "%'" &
                    " group by a.Art_Id, b.Nombre"

            Else
                Query = "select a.Art_Id as Codigo, b.Nombre " &
                    "From ArticuloReceta a inner join Articulo b on a.Emp_Id =b.Emp_Id and a.Art_Id = b.Art_Id" &
                    " where a.Emp_Id = " & _Emp_Id.ToString() &
                    " group by a.Art_Id, b.Nombre"
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
    'Public Function DeleteArticulos() As String
    '    Dim Query As String = ""
    '    Try
    '        Cn.Open()
    '        Cn.BeginTransaction()

    '        Query = "Delete ArticuloFamiliaDetalle" &
    '           " Where     Emp_Id=" & _Emp_Id.ToString() &
    '           " And    Familia_Id=" & _Familia_Id.ToString()

    '        Cn.Ejecutar(Query)

    '        Cn.CommitTransaction()

    '        Return ""
    '    Catch ex As Exception
    '        Cn.RollBackTransaction()
    '        Return ex.Message
    '    Finally
    '        Cn.Close()
    '    End Try
    'End Function
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(Ingrediente_Id),0) + 1 From ArticuloReceta Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Ingrediente_Id = Tabla.Rows(0).Item(0)
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function ListaMateriaPrima() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select a.*, b.Nombre, c.Costo" &
                " From ArticuloReceta a inner join Articulo b on a.Emp_Id = b.Emp_Id and a.Ingrediente_Id = b.Art_Id" &
                " inner join ArticuloBodega c on a.Emp_Id = c.Emp_Id and a.Ingrediente_Id = c.Art_Id" &
                " where a.Emp_Id = " & _Emp_Id &
                " and a.Art_Id = '" & Art_Id & "'" &
                " and c.Suc_Id = " & SucursalParametroInfo.Suc_Id &
                " and c.Bod_Id = " & SucursalParametroInfo.BodCompra_Id


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
    Public Function BorraReceta() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Delete ArticuloReceta" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And     Art_Id='" & _Art_Id & "'"

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

    Public Function ActualizaCosto(costo As Double) As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Update ArticuloBodega" &
               " set costo = " & costo &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And     Art_Id='" & _Art_Id & "'"

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
#End Region
End Class
