Public Class TArticuloEquivalenteProveedor
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Prov_Id As Integer
    Public Property Art_Id As String
    Public Property ArtEquivalente_Id As String
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
        Prov_Id = 0
        Art_Id = ""
        ArtEquivalente_Id = ""
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

            Query = " insert into ArticuloEquivalenteProveedor ( Emp_Id , Prov_Id" &
                    " , Art_Id , ArtEquivalente_Id" &
                    " , UltimaModificacion)" &
                    " values ( " & Emp_Id.ToString & "," & Prov_Id.ToString &
                    ",'" & Art_Id & "'" & ",'" & ArtEquivalente_Id & "'" &
                    ",'" & Format(UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & ")"

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

            Query = " update ArticuloEquivalenteProveedor " &
                    " set    ArtEquivalente_Id = '" & ArtEquivalente_Id & "'" &                    "       ,UltimaModificacion = '" & Format(UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Prov_Id = " & Prov_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'"

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

            Query = " delete ArticuloEquivalenteProveedor" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Prov_Id = " & Prov_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'"

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
                    " from ArticuloEquivalenteProveedor with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Prov_Id = " & Prov_Id.ToString &
                    " and   Art_Id = '" & Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Prov_Id = Tabla.Rows(0).Item("Prov_Id")
                Art_Id = Tabla.Rows(0).Item("Art_Id")
                ArtEquivalente_Id = Tabla.Rows(0).Item("ArtEquivalente_Id")
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

            Query = "select * from ArticuloEquivalenteProveedor with (nolock)"

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

            Query = " select ArticuloEquivalenteProveedor_Id as Numero " &
                    "       ,Nombre" &
                    " from ArticuloEquivalenteProveedor with (nolock) " &
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
