Public Class TCajaEntradaEfectivo
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Suc_Id As Integer
    Public Property Caja_Id As Integer
    Public Property Cierre_Id As Integer
    Public Property Entrada_Id As Integer
    Public Property Concepto_Id As Integer
    Public Property Fecha As Date
    Public Property Motivo As String
    Public Property Monto As Double
    Public Property Usuario_Id As String
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
        Caja_Id = 0
        Cierre_Id = 0
        Entrada_Id = 0
        Concepto_Id = 0
        Fecha = #1900/01/01#
        Motivo = ""
        Monto = 0.00
        Usuario_Id = ""
        Data = New DataSet
    End Sub
#End Region
#Region "Definition of Public Methods"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " exec CreaEntradaEfectivo " & Emp_Id.ToString & "," & Suc_Id.ToString &
                    "," & Caja_Id.ToString & "," & Cierre_Id.ToString &
                    "," & Concepto_Id.ToString & ",'" & Motivo & "'" &
                    "," & Monto.ToString & ",'" & Usuario_Id & "'"

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

            Query = " update CajaEntradaEfectivo " &
                    " set    Concepto_Id = " & Concepto_Id.ToString &                    "       ,Fecha = '" & Format(Fecha, "yyyyMMdd HH:mm:ss") & "'" &                    "       ,Motivo = '" & Motivo & "'" &                    "       ,Monto = " & Monto &                    "       ,Usuario_Id = '" & Usuario_Id & "'" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Caja_Id = " & Caja_Id.ToString &
                    " and   Cierre_Id = " & Cierre_Id.ToString &
                    " and   Entrada_Id = " & Entrada_Id.ToString

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

            Query = " delete CajaEntradaEfectivo" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Caja_Id = " & Caja_Id.ToString &
                    " and   Cierre_Id = " & Cierre_Id.ToString &
                    " and   Entrada_Id = " & Entrada_Id.ToString

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
                    " from CajaEntradaEfectivo with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Caja_Id = " & Caja_Id.ToString &
                    " and   Cierre_Id = " & Cierre_Id.ToString &
                    " and   Entrada_Id = " & Entrada_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                Entrada_Id = Tabla.Rows(0).Item("Entrada_Id")
                Concepto_Id = Tabla.Rows(0).Item("Concepto_Id")
                Fecha = Tabla.Rows(0).Item("Fecha")
                Motivo = Tabla.Rows(0).Item("Motivo")
                Monto = Tabla.Rows(0).Item("Monto")
                Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
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

            Query = "select * from CajaEntradaEfectivo with (nolock)"

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

            Query = " select CajaEntradaEfectivo_Id as Numero " &
                    "       ,Nombre" &
                    " from CajaEntradaEfectivo with (nolock) " &
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
