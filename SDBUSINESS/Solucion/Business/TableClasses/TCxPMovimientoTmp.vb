Public Class TCxPMovimientoTmp
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Suc_Id As Integer
    Public Property Entrada_Id As Integer
    Public Property Factura_Id As Integer
    Public Property MensajeError As String
    Public Property Fecha As Date
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
        Suc_Id = 0
        Entrada_Id = 0
        Factura_Id = 0
        MensajeError = ""
        Fecha = #1900/01/01#
        Data = New DataSet
    End Sub
#End Region
#Region "Definition of Public Methods"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " insert into CxPMovimientoTmp ( Emp_Id , Suc_Id" &
                    " , Entrada_Id , Factura_Id" &
                    " , MensajeError , Fecha" & ")" &
                    " values ( " & Emp_Id.ToString & "," & Suc_Id.ToString &
                    "," & Entrada_Id.ToString & "," & Factura_Id.ToString &
                    ",'" & MensajeError & "'" & ",'" & Format(Fecha, "yyyyMMdd HH:mm:ss") & "'" & ")"

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

            Query = " update CxPMovimientoTmp " &
                    " set    MensajeError = '" & MensajeError & "'" &
                    "       ,Fecha = '" & Format(Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Entrada_Id = " & Entrada_Id.ToString &
                    " and   Factura_Id = " & Factura_Id.ToString

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

            Query = " delete CxPMovimientoTmp" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Entrada_Id = " & Entrada_Id.ToString &
                    " and   Factura_Id = " & Factura_Id.ToString

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
                    " from CxPMovimientoTmp with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Entrada_Id = " & Entrada_Id.ToString &
                    " and   Factura_Id = " & Factura_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                Entrada_Id = Tabla.Rows(0).Item("Entrada_Id")
                Factura_Id = Tabla.Rows(0).Item("Factura_Id")
                MensajeError = Tabla.Rows(0).Item("MensajeError")
                Fecha = Tabla.Rows(0).Item("Fecha")
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

            Query = "select * from CxPMovimientoTmp with (nolock)"

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

            Query = " select CxPMovimientoTmp_Id as Numero " &
                    "       ,Nombre" &
                    " from CxPMovimientoTmp with (nolock) " &
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


