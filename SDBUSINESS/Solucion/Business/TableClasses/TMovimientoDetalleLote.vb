Public Class TMovimientoDetalleLote
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Suc_Id As Integer
    Public Property TipoMov_Id As Integer
    Public Property Mov_Id As Integer
    Public Property Detalle_Id As Integer
    Public Property Lote_Id As Integer
    Public Property Art_Id As String
    Public Property Lote As String
    Public Property Vencimiento As Date
    Public Property Cantidad As Double
    Public Property Bod_Id As Integer
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
        TipoMov_Id = 0
        Mov_Id = 0
        Detalle_Id = 0
        Lote_Id = 0
        Art_Id = ""
        Lote = ""
        Vencimiento = #1900/01/01#
        Cantidad = 0.00
        Bod_Id = 0
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

            Query = " insert into MovimientoDetalleLote ( Emp_Id , Suc_Id" &
                    " , TipoMov_Id , Mov_Id" &
                    " , Detalle_Id , Lote_Id" &
                    " , Art_Id , Lote" &
                    " , Vencimiento , Cantidad" &
                    " , Bod_Id , Fecha" & ")" &
                    " values ( " & Emp_Id.ToString & "," & Suc_Id.ToString &
                    "," & TipoMov_Id.ToString & "," & Mov_Id.ToString &
                    "," & Detalle_Id.ToString & "," & Lote_Id.ToString &
                    ",'" & Art_Id & "'" & ",'" & Lote & "'" &
                    "," & Vencimiento.ToString & "," & Cantidad.ToString &
                    "," & Bod_Id.ToString & ",'" & Format(Fecha, "yyyyMMdd HH:mm:ss") & "'" & ")"

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

            Query = " update MovimientoDetalleLote " &
                    " set    Art_Id = '" & Art_Id & "'" &
                    "       ,Lote = '" & Lote & "'" &
                    "       ,Vencimiento = " & Vencimiento &
                    "       ,Cantidad = " & Cantidad &
                    "       ,Bod_Id = " & Bod_Id &
                    "       ,Fecha = '" & Format(Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   TipoMov_Id = " & TipoMov_Id.ToString &
                    " and   Mov_Id = " & Mov_Id.ToString &
                    " and   Detalle_Id = " & Detalle_Id.ToString &
                    " and   Lote_Id = " & Lote_Id.ToString

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

            Query = " delete MovimientoDetalleLote" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   TipoMov_Id = " & TipoMov_Id.ToString &
                    " and   Mov_Id = " & Mov_Id.ToString &
                    " and   Detalle_Id = " & Detalle_Id.ToString &
                    " and   Lote_Id = " & Lote_Id.ToString

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
                    " from MovimientoDetalleLote with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   TipoMov_Id = " & TipoMov_Id.ToString &
                    " and   Mov_Id = " & Mov_Id.ToString &
                    " and   Detalle_Id = " & Detalle_Id.ToString &
                    " and   Lote_Id = " & Lote_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                TipoMov_Id = Tabla.Rows(0).Item("TipoMov_Id")
                Mov_Id = Tabla.Rows(0).Item("Mov_Id")
                Detalle_Id = Tabla.Rows(0).Item("Detalle_Id")
                Lote_Id = Tabla.Rows(0).Item("Lote_Id")
                Art_Id = Tabla.Rows(0).Item("Art_Id")
                Lote = Tabla.Rows(0).Item("Lote")
                Vencimiento = Tabla.Rows(0).Item("Vencimiento")
                Cantidad = Tabla.Rows(0).Item("Cantidad")
                Bod_Id = Tabla.Rows(0).Item("Bod_Id")
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

            Query = " select *" &
                    " from MovimientoDetalleLote with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   TipoMov_Id = " & TipoMov_Id.ToString &
                    " and   Mov_Id = " & Mov_Id.ToString

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

            Query = " select MovimientoDetalleLote_Id as Numero " &
                    "       ,Nombre" &
                    " from MovimientoDetalleLote with (nolock) " &
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
    Public Function LotesAjusteInventario() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec LotesAjusteInventario " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & TipoMov_Id.ToString & "," & Mov_Id.ToString

            Tabla = Cn.Seleccionar(Query)

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
#End Region
End Class