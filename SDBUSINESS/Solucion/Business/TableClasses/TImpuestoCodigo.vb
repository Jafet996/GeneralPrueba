Public Class TImpuestoCodigo
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Codigo_Id As Char
    Public Property Nombre As String
    Public Property Activo As Integer
    Public Property PermiteModifcar As Integer
    Public Property PoseeTarifa As Integer

    Public Property Data As DataSet
#End Region
#Region "Definition of Constructors"
    Public Sub New()
        MyBase.New()
        Inicializa()
    End Sub
    Public Sub New(pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
    End Sub
#End Region
#Region "Definition of Private Methods"
    Private Sub Inicializa()
        Codigo_Id = ""
        Nombre = ""
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

            Query = " insert into ImpuestoCodigo ( Codigo_Id , Nombre" &
                    " , Activo)" &
                    " values ( '" & Codigo_Id & "'" & ",'" & Nombre & "'" &
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

            Query = " update ImpuestoCodigo " &
                    " set    Nombre = '" & Nombre & "'" &                    "       ,Activo = " & Activo &
                    " where Codigo_Id = '" & Codigo_Id & "'"

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

            Query = " delete ImpuestoCodigo" &
                    " where Codigo_Id = '" & Codigo_Id & "'"

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
                    " from ImpuestoCodigo with (nolock)" &
                    " where Codigo_Id = '" & Codigo_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Codigo_Id = Tabla.Rows(0).Item("Codigo_Id")
                Nombre = Tabla.Rows(0).Item("Nombre")
                Activo = Tabla.Rows(0).Item("Activo")
                PermiteModifcar = Tabla.Rows(0).Item("PermiteModificar")
                PoseeTarifa = Tabla.Rows(0).Item("PoseeTarifa")
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

            Query = "select * from ImpuestoCodigo with (nolock)"

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

            Query = " select Codigo_Id as Numero " &
                    "       ,Nombre" &
                    " from ImpuestoCodigo with (nolock) " &
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
