Public Class TFacturaExoneracion
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Suc_Id As Integer
    Public Property Caja_Id As Integer
    Public Property TipoDoc_Id As Integer
    Public Property Documento_Id As Long
    Public Property TipoDocumento As String
    Public Property NumeroDocumento As String
    Public Property NombreInstitucion As String
    Public Property FechaEmision As Date
    Public Property PorcentajeExoneracion As Double
    Public Property MontoExoneracion As Double
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
        TipoDoc_Id = 0
        Documento_Id = 0
        TipoDocumento = ""
        NumeroDocumento = ""
        NombreInstitucion = ""
        FechaEmision = #1900/01/01#
        PorcentajeExoneracion = 0.00
        MontoExoneracion = 0.00
        Data = New DataSet
    End Sub
#End Region
#Region "Definition of Public Methods"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()
            Cn.BeginTransaction()

            Query = " insert into FacturaExoneracion ( Emp_Id , Suc_Id" &
                    " , Caja_Id , TipoDoc_Id" &
                    " , Documento_Id , TipoDocumento" &
                    " , NumeroDocumento , NombreInstitucion" &
                    " , FechaEmision , PorcentajeExoneracion" &
                    " , MontoExoneracion)" &
                    " values ( " & Emp_Id.ToString & "," & Suc_Id.ToString &
                    "," & Caja_Id.ToString & "," & TipoDoc_Id.ToString &
                    "," & Documento_Id.ToString & ",'" & TipoDocumento & "'" &
                    ",'" & NumeroDocumento & "'" & ",'" & NombreInstitucion & "'" &
                    ",'" & Format(FechaEmision, "yyyyMMdd HH:mm:ss") & "'" & "," & PorcentajeExoneracion.ToString &
                    "," & MontoExoneracion.ToString & ")"

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

            Query = " update FacturaExoneracion " &
                    " set    TipoDocumento = '" & TipoDocumento & "'" &                    "       ,NumeroDocumento = '" & NumeroDocumento & "'" &                    "       ,NombreInstitucion = '" & NombreInstitucion & "'" &                    "       ,FechaEmision = '" & Format(FechaEmision, "yyyyMMdd HH:mm:ss") & "'" &                    "       ,PorcentajeExoneracion = " & PorcentajeExoneracion &                    "       ,MontoExoneracion = " & MontoExoneracion &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Caja_Id = " & Caja_Id.ToString &
                    " and   TipoDoc_Id = " & TipoDoc_Id.ToString &
                    " and   Documento_Id = " & Documento_Id.ToString

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

            Query = " delete FacturaExoneracion" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Caja_Id = " & Caja_Id.ToString &
                    " and   TipoDoc_Id = " & TipoDoc_Id.ToString &
                    " and   Documento_Id = " & Documento_Id.ToString

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
                    " from FacturaExoneracion with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Suc_Id = " & Suc_Id.ToString &
                    " and   Caja_Id = " & Caja_Id.ToString &
                    " and   TipoDoc_Id = " & TipoDoc_Id.ToString &
                    " and   Documento_Id = " & Documento_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                TipoDocumento = Tabla.Rows(0).Item("TipoDocumento")
                NumeroDocumento = Tabla.Rows(0).Item("NumeroDocumento")
                NombreInstitucion = Tabla.Rows(0).Item("NombreInstitucion")
                FechaEmision = Tabla.Rows(0).Item("FechaEmision")
                PorcentajeExoneracion = Tabla.Rows(0).Item("PorcentajeExoneracion")
                MontoExoneracion = Tabla.Rows(0).Item("MontoExoneracion")
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

            Query = "select * from FacturaExoneracion with (nolock)"

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

            Query = " select FacturaExoneracion_Id as Numero " &
                    "       ,Nombre" &
                    " from FacturaExoneracion with (nolock) " &
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
