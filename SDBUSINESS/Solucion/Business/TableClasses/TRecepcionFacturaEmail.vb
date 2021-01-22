Public Class TRecepcionFacturaEmail
    Inherits TBaseClassManager
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
    Public Property Email_Id As Integer
    Public Property Email As String
    Public Property Nombre As String
    Public Property Server_Id As Integer
    Public Property Server As String
    Public Property Password As String
    Public Property SSL As Integer
    Public Property ServerAuthType As Integer
    Public Property ServerProtocol As Integer
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
        Email_Id = 0
        Email = ""
        Nombre = ""
        Server_Id = 0
        Server = ""
        Password = ""
        SSL = 0
        ServerAuthType = 0
        ServerProtocol = 0
        Port = 0
        Activo = 0
        Data = New DataSet
    End Sub
#End Region
#Region "Definition of Public Methods"
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(Email_Id),0) + 1 From RecepcionFacturaEmail Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Email_Id = Tabla.Rows(0).Item(0)
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

            Query = " insert into RecepcionFacturaEmail ( Emp_Id , Email_Id" &
                    " , Email , Nombre" &
                    " , Server_Id , Server" &
                    " , Password , SSL" &
                    " , ServerAuthType , ServerProtocol" &
                    " , Port , Activo" & ")" &
                    " values ( " & Emp_Id.ToString & "," & Email_Id.ToString &
                    ",'" & Email & "'" & ",'" & Nombre & "'" &
                    "," & Server_Id.ToString & ",'" & Server & "'" &
                    ",'" & Password & "'" & "," & SSL.ToString &
                    "," & ServerAuthType.ToString & "," & ServerProtocol.ToString &
                    "," & Port.ToString & "," & Activo.ToString & ")"

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

            Query = " update RecepcionFacturaEmail " &
                    " set    Email = '" & Email & "'" &
                    "       ,Nombre = '" & Nombre & "'" &
                    "       ,Server_Id = " & Server_Id &
                    "       ,Server = '" & Server & "'" &
                    "       ,Password = '" & Password & "'" &
                    "       ,SSL = " & SSL &
                    "       ,ServerAuthType = " & ServerAuthType &
                    "       ,ServerProtocol = " & ServerProtocol &
                    "       ,Port = " & Port &
                    "       ,Activo = " & Activo &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Email_Id = " & Email_Id.ToString

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

            Query = " delete RecepcionFacturaEmail" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Email_Id = " & Email_Id.ToString

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
                    " from RecepcionFacturaEmail with (nolock)" &
                    " where Emp_Id = " & Emp_Id.ToString &
                    " and   Email_Id = " & Email_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                Email_Id = Tabla.Rows(0).Item("Email_Id")
                Email = Tabla.Rows(0).Item("Email")
                Nombre = Tabla.Rows(0).Item("Nombre")
                Server_Id = Tabla.Rows(0).Item("Server_Id")
                Server = Tabla.Rows(0).Item("Server")
                Password = Tabla.Rows(0).Item("Password")
                SSL = Tabla.Rows(0).Item("SSL")
                ServerAuthType = Tabla.Rows(0).Item("ServerAuthType")
                ServerProtocol = Tabla.Rows(0).Item("ServerProtocol")
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

            Query = "select * from RecepcionFacturaEmail with (nolock) where Emp_Id = " & Emp_Id.ToString()

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

            Query = " select Email_Id as Numero " &
                    "       ,Nombre" &
                    " from RecepcionFacturaEmail with (nolock) " &
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
    Public Function ListaMantenimiento(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Email_Id as Codigo, Nombre From RecepcionFacturaEmail where Emp_Id = " & _Emp_Id.ToString()

            If pNombre.Trim <> "" Then
                Query = Query & " and Nombre Like '%" & pNombre & "%'"
            End If

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
#End Region
End Class
