Public Class TArticuloUpc
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Art_Id As String
    Public Property Upc_Id As Integer
    Public Property Data As DataSet
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property
#End Region
#Region "Definition of Constructors"
    Public Sub New(pEmp_Id As Integer)
        MyBase.New()
        Inicializa()
        Emp_Id = pEmp_Id
    End Sub
    Public Sub New(pEmp_Id As Integer, pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        Emp_Id = pEmp_Id
    End Sub
#End Region
#Region "Definition of Private Methods"
    Private Sub Inicializa()
        Emp_Id = 0
        Art_Id = ""
        Upc_Id = 0
        Data = New DataSet
    End Sub
#End Region
#Region "Definition of Public Methods"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " insert into ArticuloUpc ( Emp_Id , Art_Id" &
                    " , Upc_Id)" &
                    " values ( " & Emp_Id.ToString & ",'" & Art_Id & "'" &
                    "," & Upc_Id.ToString & ")"

            Cn.Ejecutar(Query)
            Cn.CommitTransaction()

            Return String.Empty
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

            Query = String.Empty

            Cn.Ejecutar(Query)
            Cn.CommitTransaction()

            Return String.Empty
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

            Query = " delete ArticuloUpc" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'" &
                    " and   Upc_Id = " & Upc_Id.ToString

            Cn.Ejecutar(Query)
            Cn.CommitTransaction()

            Return String.Empty
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

            Query = " select *" &
                    " from ArticuloUpc with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'" &
                    " and   Upc_Id = " & Upc_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Art_Id = Tabla.Rows(0).Item("Art_Id")
                Upc_Id = Tabla.Rows(0).Item("Upc_Id")
            End If

            Return String.Empty
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

            Query = "select a.Art_Id, a.Upc_Id, b.Nombre, b.Cantidad from ArticuloUpc a with (nolock)" &
                " inner join Upc b with (nolock) on a.Emp_Id = b.Emp_Id and a.Upc_Id = b.Upc_Id" &
                " where a.Emp_Id = " & Emp_Id.ToString() &
                " And   a.Art_Id = '" & Art_Id & "'" &
                " order by b.Cantidad asc"


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
    Public Overrides Function LoadComboBox(pCombo As Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = " select ArticuloUpc_Id as Numero " &
                    "       ,Nombre" &
                    " from ArticuloUpc with (nolock) " &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Activo = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
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

