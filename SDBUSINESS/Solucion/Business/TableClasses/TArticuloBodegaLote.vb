Public Class TArticuloBodegaLote
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Suc_Id As Integer
    Public Property Bod_Id As Integer
    Public Property Art_Id As String
    Public Property Lote As String
    Public Property Vencimiento As Date
    Public Property Saldo As Double
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
        Suc_Id = 0
        Bod_Id = 0
        Art_Id = ""
        Lote = ""
        Vencimiento = #1900/01/01#
        Saldo = 0.00
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

            Query = " insert into ArticuloBodegaLote ( Emp_Id , Suc_Id" &
                    " , Bod_Id , Art_Id" &
                    " , Lote , Vencimiento" &
                    " , Saldo , UltimaModificacion" & ")" &
                    " values ( " & Emp_Id.ToString & "," & Suc_Id.ToString &
                    "," & Bod_Id.ToString & ",'" & Art_Id & "'" &
                    ",'" & Lote & "'" & "," & Vencimiento.ToString &
                    "," & Saldo.ToString & ",'" & Format(UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & ")"

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

            Query = " update ArticuloBodegaLote " &
                    " set    Saldo = " & Saldo.ToString &                    "       ,UltimaModificacion = '" & Format(UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Bod_Id = " & Bod_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'" &
                    " and   Lote = '" & Lote & "'" &
                    " and   Vencimiento = " & Vencimiento.ToString

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

            Query = " delete ArticuloBodegaLote" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Bod_Id = " & Bod_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'" &
                    " and   Lote = '" & Lote & "'" &
                    " and   Vencimiento = " & Vencimiento.ToString

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
                    " from ArticuloBodegaLote with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Bod_Id = " & Bod_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'" &
                    " and   Lote = '" & Lote & "'" &
                    " and   Vencimiento = " & Vencimiento.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                Art_Id = Tabla.Rows(0).Item("Art_Id")
                Lote = Tabla.Rows(0).Item("Lote")
                Vencimiento = Tabla.Rows(0).Item("Vencimiento")
                Saldo = Tabla.Rows(0).Item("Saldo")
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

            Query = "select * from ArticuloBodegaLote with (nolock)"

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

            Query = " select ArticuloBodegaLote_Id as Numero " &
                    "       ,Nombre" &
                    " from ArticuloBodegaLote with (nolock) " &
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
    Public Function ConsultaExistenciaLote() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Query = "exec ConsultaExistenciaLote " & Emp_Id.ToString &
                    "," & Suc_Id.ToString &
                    "," & Bod_Id.ToString &
                    ",'" & Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class
