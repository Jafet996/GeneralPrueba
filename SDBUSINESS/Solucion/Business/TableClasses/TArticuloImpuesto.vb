Public Class TArticuloImpuesto
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Art_Id As String
    Public Property Codigo_Id As String
    Public Property Tarifa_Id As String
    Public Property Porcentaje As Double
    Public Property Data As DataSet
#End Region
#Region "Definicion de propiedades"
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
        Codigo_Id = ""
        Tarifa_Id = ""
        Porcentaje = 0.00
        Data = New DataSet
    End Sub
#End Region
#Region "Definition of Public Methods"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " insert into ArticuloImpuesto ( Emp_Id , Art_Id" &
                    " , Codigo_Id , Tarifa_Id" &
                    " , Porcentaje)" &
                    " values ( " & Emp_Id.ToString & ",'" & Art_Id & "'" &
                    ",'" & Codigo_Id & "'" & ",'" & Tarifa_Id & "'" &
                    "," & Porcentaje.ToString & ")"

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

            Query = " update ArticuloImpuesto " &
                    " set    Tarifa_Id = '" & Tarifa_Id & "'" &
                    "       ,Porcentaje = " & Porcentaje &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'" &
                    " and   Codigo_Id = '" & Codigo_Id & "'"

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

            Query = " delete ArticuloImpuesto" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'" &
                    " and   Codigo_Id = '" & Codigo_Id & "'"

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
                    " from ArticuloImpuesto with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'" &
                    " and   Codigo_Id = '" & Codigo_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Art_Id = Tabla.Rows(0).Item("Art_Id")
                Codigo_Id = Tabla.Rows(0).Item("Codigo_Id")
                Tarifa_Id = Tabla.Rows(0).Item("Tarifa_Id")
                Porcentaje = Tabla.Rows(0).Item("Porcentaje")
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

            Query = "select a.Codigo_Id, b.Nombre as Impuesto, a.Tarifa_Id, c.Nombre Tarifa, a.Porcentaje from ArticuloImpuesto a with (nolock) INNER JOIN ImpuestoCodigo b WITH (NOLOCK) ON a.Codigo_Id = b.Codigo_Id INNER JOIN ImpuestoTarifa c WITH(NOLOCK) ON a.Tarifa_Id = c.Tarifa_Id  where Emp_Id = " & Emp_Id.ToString() &
                    " AND Art_Id = '" & Art_Id.ToString() & "'"

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

            Query = " select ArticuloImpuesto_Id as Numero " &
                    "       ,Nombre" &
                    " from ArticuloImpuesto with (nolock) " &
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
