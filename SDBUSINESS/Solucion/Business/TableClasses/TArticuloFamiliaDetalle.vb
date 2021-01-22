Public Class TArticuloFamiliaDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Familia_Id As Integer
    Private _Art_Id As String
    Private _Data As DataSet
    Private _Nombre As String

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
    Public Property Familia_Id() As Integer
        Get
            Return _Familia_Id
        End Get
        Set(ByVal Value As Integer)
            _Familia_Id = Value
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
    Public ReadOnly Property Data() As DataSet
        Get
            Return _Data
        End Get
    End Property
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
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
        _Familia_Id = 0
        _Art_Id = ""
        _Nombre = ""
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ArticuloFamiliaDetalle( Emp_Id , Familia_Id" &
                   " , Art_Id )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Familia_Id.ToString() &
                   ",'" & _Art_Id & "'" & ")"

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

            Query = "Delete ArticuloFamiliaDetalle" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Familia_Id=" & _Familia_Id.ToString() &
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
    Public Overrides Function Modify() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.ArticuloFamiliaDetalle " &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Familia_Id=" & _Familia_Id.ToString() &
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
    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From ArticuloFamiliaDetalle" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Familia_Id=" & _Familia_Id.ToString() &
           " And     Art_Id='" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Familia_Id = Tabla.Rows(0).Item("Familia_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
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

            Query = "select * From ArticuloFamiliaDetalle"

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

            Query = "select ArticuloFamiliaDetalle_Id as Numero, Nombre From ArticuloFamiliaDetalle"

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
    Public Function DetalleMantenimiento() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select a.Art_Id as Codigo, b.Nombre From ArticuloFamiliaDetalle a inner join Articulo b on a.Emp_Id = b.Emp_id and a.Art_Id = b.Art_Id where a.Emp_Id = " & _Emp_Id.ToString() & "And Familia_Id = " & _Familia_Id

            'If pNombre.Trim <> "" Then
            '    Query = Query & " and Nombre Like '%" & pNombre & "%'"
            'End If

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
