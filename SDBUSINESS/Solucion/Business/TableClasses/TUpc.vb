Public Class TUpc
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Upc_Id As Integer
    Public Property Nombre As String
    Public Property Cantidad As Integer
    Public Property Activo As Integer
    Public Property UltimaModificacion As Date
    Public Property Data As DataSet
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
        Upc_Id = 0
        Nombre = ""
        Cantidad = 0
        Activo = 0
        UltimaModificacion = #1900/01/01#
        Data = New DataSet
    End Sub
#End Region
#Region "Definition of Public Methods"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " insert into Upc ( Emp_Id , Upc_Id" &
                    " , Nombre , Cantidad" &
                    " , Activo , UltimaModificacion" & ")" &
                    " values ( " & Emp_Id.ToString & "," & Upc_Id.ToString &
                    ",'" & Nombre & "'" & "," & Cantidad.ToString &
                    "," & Activo.ToString & ",'" & Format(UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & ")"

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

            Query = " update Upc " &
                    " set    Nombre = '" & Nombre & "'" &                    "       ,Cantidad = " & Cantidad &                    "       ,Activo = " & Activo &                    "       ,UltimaModificacion = '" & Format(UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                    " where Emp_Id = " & Emp_Id.ToString &
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
    Public Overrides Function Delete() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " delete Upc" &
                    " where Emp_Id = " & Emp_Id.ToString &
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
                    " from Upc with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Upc_Id = " & Upc_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Upc_Id = Tabla.Rows(0).Item("Upc_Id")
                Nombre = Tabla.Rows(0).Item("Nombre")
                Cantidad = Tabla.Rows(0).Item("Cantidad")
                Activo = Tabla.Rows(0).Item("Activo")
                UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
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

            Query = "select * from Upc with (nolock)"

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

            Query = " select Upc_Id as Numero " &
                    "       ,Nombre" &
                    " from Upc with (nolock) " &
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


