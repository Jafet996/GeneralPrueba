Public Class TFacturaDetalleGarantia
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Suc_Id As Integer
    Public Property Caja_Id As Integer
    Public Property TipoDoc_Id As Integer
    Public Property Documento_Id As Long
    Public Property Detalle_Id As Integer
    Public Property Garantia_Id As Long
    Public Property FechaInicio As Date
    Public Property FechaFinal As Date
    Public Property OrdenNumero As String
    Public Property Usuario_Id As String
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
        Suc_Id = 0
        Caja_Id = 0
        TipoDoc_Id = 0
        Documento_Id = 0
        Detalle_Id = 0
        Garantia_Id = 0
        FechaInicio = #1900/01/01#
        FechaFinal = #1900/01/01#
        OrdenNumero = ""
        Usuario_Id = ""
        Data = New DataSet
    End Sub
#End Region
#Region "Definition of Public Methods"

    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(Garantia_Id),0) + 1 From FacturaDetalleGarantia Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Garantia_Id = Tabla.Rows(0).Item(0)
            Else
                VerificaMensaje("No se pudo obtener el número de garantía")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " insert into FacturaDetalleGarantia ( Emp_Id , Suc_Id" &
                    " , Caja_Id , TipoDoc_Id" &
                    " , Documento_Id , Detalle_Id" &
                    " , Garantia_Id , FechaInicio" &
                    " , FechaFinal , OrdenNumero" &
                    " , Usuario_Id)" &
                    " values ( " & Emp_Id.ToString & "," & Suc_Id.ToString &
                    "," & Caja_Id.ToString & "," & TipoDoc_Id.ToString &
                    "," & Documento_Id.ToString & "," & Detalle_Id.ToString &
                    "," & Garantia_Id.ToString & ",'" & Format(FechaInicio, "yyyyMMdd HH:mm:ss") & "'" &
                    ",'" & Format(FechaFinal, "yyyyMMdd HH:mm:ss") & "'" & ",'" & OrdenNumero & "'" &
                    ",'" & Usuario_Id & "'" & ")"

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

            Query = " update FacturaDetalleGarantia " &
                    " set    Garantia_Id = " & Garantia_Id.ToString &                    "       ,FechaInicio = '" & Format(FechaInicio, "yyyyMMdd HH:mm:ss") & "'" &                    "       ,FechaFinal = '" & Format(FechaFinal, "yyyyMMdd HH:mm:ss") & "'" &                    "       ,OrdenNumero = '" & OrdenNumero & "'" &                    "       ,Usuario_Id = '" & Usuario_Id & "'" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Caja_Id = " & Caja_Id.ToString &
                    " and   TipoDoc_Id = " & TipoDoc_Id.ToString &
                    " and   Documento_Id = " & Documento_Id.ToString &
                    " and   Detalle_Id = " & Detalle_Id.ToString

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

            Query = " delete FacturaDetalleGarantia" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Caja_Id = " & Caja_Id.ToString &
                    " and   TipoDoc_Id = " & TipoDoc_Id.ToString &
                    " and   Documento_Id = " & Documento_Id.ToString &
                    " and   Detalle_Id = " & Detalle_Id.ToString

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
                    " from FacturaDetalleGarantia with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Caja_Id = " & Caja_Id.ToString &
                    " and   TipoDoc_Id = " & TipoDoc_Id.ToString &
                    " and   Documento_Id = " & Documento_Id.ToString &
                    " and   Detalle_Id = " & Detalle_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                Detalle_Id = Tabla.Rows(0).Item("Detalle_Id")
                Garantia_Id = Tabla.Rows(0).Item("Garantia_Id")
                FechaInicio = Tabla.Rows(0).Item("FechaInicio")
                FechaFinal = Tabla.Rows(0).Item("FechaFinal")
                OrdenNumero = Tabla.Rows(0).Item("OrdenNumero")
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

            Query = "select * from FacturaDetalleGarantia with (nolock)"

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
    Public Function RptGarantia() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec RptGarantia " & Emp_Id.ToString() & "," & Garantia_Id.ToString()

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
    Public Function BuscaGarantia(pArt_Id As String, pSerie As String, pCliente_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec BuscaGarantia " & Emp_Id.ToString() & ",'" & pArt_Id & "','" & pSerie & "'," & pCliente_Id.ToString()

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

            Query = " select FacturaDetalleGarantia_Id as Numero " &
                    "       ,Nombre" &
                    " from FacturaDetalleGarantia with (nolock) " &
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
