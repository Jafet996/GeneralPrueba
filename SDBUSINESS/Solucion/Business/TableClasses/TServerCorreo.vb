Public Class TServerCorreo
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Server_Id As Integer
    Public Property Nombre As String
    Public Property Server As String
    Public Property Port As Integer
    Public Property Activo As Integer
    Public Property Data As DataSet
    Public ReadOnly Property RowsAffected As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property
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
        Server_Id = 0
        Nombre = ""
        Server = ""
        Port = 0
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

            Query = " insert into ServerCorreo ( Server_Id , Nombre" &
                    " , Server , Port" &
                    " , Activo)" &
                    " values ( " & Server_Id.ToString & ",'" & Nombre & "'" &
                    ",'" & Server & "'" & "," & Port.ToString &
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

            Query = " update ServerCorreo " &
                    " set    Nombre = '" & Nombre & "'" &                    "       ,Server = '" & Server & "'" &                    "       ,Port = " & Port &                    "       ,Activo = " & Activo &
                    " where Server_Id = " & Server_Id.ToString

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

            Query = " delete ServerCorreo" &
                    " where Server_Id = " & Server_Id.ToString

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
                    " from ServerCorreo with (nolock)" &
                    " where Server_Id = " & Server_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Server_Id = Tabla.Rows(0).Item("Server_Id")
                Nombre = Tabla.Rows(0).Item("Nombre")
                Server = Tabla.Rows(0).Item("Server")
                Port = Tabla.Rows(0).Item("Port")
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

            Query = "select * from ServerCorreo with (nolock)"

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

            Query = " select Server_Id as Numero " &
                    "       ,Nombre" &
                    " from ServerCorreo with (nolock) " &
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

