Public Class TModulo
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Modulo_Id As Integer
    Private _Nombre As String
    Private _Major As Integer
    Private _Menor As Integer
    Private _Bug As Integer
    Private _Build As Integer
    Private _Resultado As Integer
    Private _Caduco As Boolean
    Private _Mensaje As String
    Private _Data As DataSet
#End Region
#Region "Definicion de propiedades"

    Public Property Modulo_Id() As Integer
        Get
            Return _Modulo_Id
        End Get
        Set(ByVal Value As Integer)
            _Modulo_Id = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    Public Property Major() As Integer
        Get
            Return _Major
        End Get
        Set(ByVal Value As Integer)
            _Major = Value
        End Set
    End Property
    Public Property Menor() As Integer
        Get
            Return _Menor
        End Get
        Set(ByVal Value As Integer)
            _Menor = Value
        End Set
    End Property
    Public Property Bug() As Integer
        Get
            Return _Bug
        End Get
        Set(ByVal Value As Integer)
            _Bug = Value
        End Set
    End Property
    Public Property Build() As Integer
        Get
            Return _Build
        End Get
        Set(ByVal Value As Integer)
            _Build = Value
        End Set
    End Property
    Public Property Resultado As Integer
        Get
            Return _Resultado
        End Get
        Set(value As Integer)
            _Resultado = value
        End Set
    End Property
    Public Property Caduco() As Boolean
        Get
            Return _Caduco
        End Get
        Set(ByVal value As Boolean)
            _Caduco = value
        End Set
    End Property
    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property

    Public ReadOnly Property Data() As DataSet
        Get
            Return _Data
        End Get
    End Property
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property


#End Region
#Region "Constructores"
    Public Sub New()
        MyBase.New()
        Inicializa()
    End Sub
    Public Sub New(ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Modulo_Id = 0
        _Nombre = ""
        _Major = 0
        _Menor = 0
        _Bug = 0
        _Build = 0
        _Resultado = Enum_ErrorVersiones.Success
        _Caduco = False
        _Mensaje = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Modulo( Modulo_Id , Nombre" & _
                   " , Major , Menor" & _
                   " , Bug , Build" & _
                   " )" & _
                   " Values ( " & _Modulo_Id.ToString() & ",'" & _Nombre & "'" & _
                   "," & _Major.ToString() & "," & _Menor.ToString() & _
                   "," & _Bug.ToString() & "," & _Build.ToString() & ")"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
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

            query = "Delete Modulo" & _
               " Where     Modulo_Id=" & _Modulo_Id.ToString()

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
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

            query = " Update dbo.Modulo " & _
                      " SET   Nombre='" & _Nombre & "' " & "," & _
                      " Major=" & _Major & "," & _
                      " Menor=" & _Menor & "," & _
                      " Bug=" & _Bug & "," & _
                      " Build=" & _Build & _
                      " Where     Modulo_Id=" & _Modulo_Id.ToString()

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
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
            Cn = New Connection.TConnectionManager(GetConnectionString())
            Cn.Open()

            Query = "select * From Modulo" &
           " Where     Modulo_Id=" & _Modulo_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Modulo_Id = Tabla.Rows(0).Item("Modulo_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Major = Tabla.Rows(0).Item("Major")
                _Menor = Tabla.Rows(0).Item("Menor")
                _Bug = Tabla.Rows(0).Item("Bug")
                _Build = Tabla.Rows(0).Item("Build")
            End If

            Return ""

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

            Query = "select * From Modulo"

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
    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Modulo_Id as Numero, Nombre From Modulo"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function VerificaVersion() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec VerificaVersion " & _Modulo_Id.ToString() & "," & _Major.ToString() & "," & _Menor.ToString() & "," & _Bug.ToString() & "," & _Build.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Resultado = Tabla.Rows(0).Item("Resultado")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function


    Public Function VerificaModulo(pModulo As Modulos) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try

            _Caduco = False
            _Mensaje = String.Empty

            Cn.Open()

            Query = "exec VerificaModulo " & pModulo & ",30"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Caduco = Tabla.Rows(0).Item("Caduco")
                _Mensaje = Tabla.Rows(0).Item("Mensaje")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
#End Region
End Class