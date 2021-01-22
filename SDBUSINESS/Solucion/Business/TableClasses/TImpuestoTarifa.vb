Public Class TImpuestoTarifa
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Tarifa_Id As String
    Public Property Nombre As String
    Public Property Porcentaje As Double
    Public Property Activo As Integer
    Public Property Data As DataSet
#End Region
#Region "Definition of Constructors"
    Public Sub New()
        MyBase.New()
        Inicializa()
    End Sub
    Public Sub New(pEmp_Id As Integer, pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
    End Sub
#End Region
#Region "Definition of Private Methods"
    Private Sub Inicializa()
        Tarifa_Id = ""
        Nombre = ""
        Porcentaje = 0.00
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

            Query = " insert into ImpuestoTarifa ( Tarifa_Id , Nombre" &
                    " , Porcentaje , Activo" & ")" &
                    " values ( '" & Tarifa_Id & "'" & ",'" & Nombre & "'" &
                    "," & Porcentaje.ToString & "," & Activo.ToString & ")"

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

            Query = " update ImpuestoTarifa " &
                    " set    Nombre = '" & Nombre & "'" &                    "       ,Porcentaje = " & Porcentaje &                    "       ,Activo = " & Activo &
                    " where Tarifa_Id = '" & Tarifa_Id & "'"

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

            Query = " delete ImpuestoTarifa" &
                    " where Tarifa_Id = '" & Tarifa_Id & "'"

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
                    " from ImpuestoTarifa with (nolock)" &
                    " where Tarifa_Id = '" & Tarifa_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Tarifa_Id = Tabla.Rows(0).Item("Tarifa_Id")
                Nombre = Tabla.Rows(0).Item("Nombre")
                Porcentaje = Tabla.Rows(0).Item("Porcentaje")
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

            Query = "select * from ImpuestoTarifa with (nolock)"

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

            Query = " select Tarifa_Id as Numero " &
                    "       ,Nombre" &
                    " from ImpuestoTarifa with (nolock) " &
                    " where Activo = 1"

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
