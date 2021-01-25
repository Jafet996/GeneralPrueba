Public Class TGarantiaPeriodo
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Periodo_Id As Integer
    Public Property Nombre As String
    Public Property CantidadMes As Integer
    Public Property Activo As Integer
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
        Periodo_Id = 0
        Nombre = ""
        CantidadMes = 0
        Activo = 0
        Data = New DataSet
    End Sub
#End Region
#Region "Definition of Public Methods"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " insert into GarantiaPeriodo ( Emp_Id , Periodo_Id" &
                    " , Nombre , CantidadMes" &
                    " , Activo)" &
                    " values ( " & Emp_Id.ToString & "," & Periodo_Id.ToString &
                    ",'" & Nombre & "'" & "," & CantidadMes.ToString &
                    "," & Activo.ToString & ")"

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

            Query = " update GarantiaPeriodo " &
                    " set    Nombre = '" & Nombre & "'" &
                    "       ,CantidadMes = " & CantidadMes &
                    "       ,Activo = " & Activo &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Periodo_Id = " & Periodo_Id.ToString

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

            Query = " delete GarantiaPeriodo" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Periodo_Id = " & Periodo_Id.ToString

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
                    " from GarantiaPeriodo with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Periodo_Id = " & Periodo_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Periodo_Id = Tabla.Rows(0).Item("Periodo_Id")
                Nombre = Tabla.Rows(0).Item("Nombre")
                CantidadMes = Tabla.Rows(0).Item("CantidadMes")
                Activo = Tabla.Rows(0).Item("Activo")
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

            Query = "select * from GarantiaPeriodo with (nolock)"

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

            Query = " select Periodo_Id as Numero " &
                    "       ,Nombre" &
                    " from GarantiaPeriodo with (nolock) " &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Activo = 1" &
                    " order by CantidadMes asc"

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
