Public Class TModulo
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Modulo_Id As Integer
    Private _Nombre As String
    Private _Major As Integer
    Private _Menor As Integer
    Private _Bug As Integer
    Private _Build As Integer
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
                    " Values ( " & _Modulo_Id.ToString & ",'" & _Nombre & "'" & _
                    "," & _Major.ToString & "," & _Menor.ToString & _
                    "," & _Bug.ToString & "," & _Build.ToString & _
                    ")"

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

            Query = "Delete Modulo" & _
                    " Where     Modulo_Id=" & _Modulo_Id.ToString

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

            Query = " Update dbo.Modulo " & _
                    " SET   Nombre='" & _Nombre & "' " & "," & _
                    " Major=" & _Major & "," & _
                    " Menor=" & _Menor & "," & _
                    " Bug=" & _Bug & "," & _
                    " Build=" & _Build & _
                    " Where     Modulo_Id=" & _Modulo_Id.ToString

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
            Cn.Open()

            Query = "select * From Modulo" & _
                    " Where     Modulo_Id=" & _Modulo_Id.ToString

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
    Public Overrides Function LoadComboBox() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select Modulo_Id as Numero, Nombre From Modulo"

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
    Public Overrides Function ListMant(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select Modulo_Id as Codigo, Nombre From Modulo"

            If pNombre.Trim <> "" Then
                Query += " and Nombre Like '%" & pNombre & "%'"
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
    Public Overrides Function NextOne() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select IsNull(MAX(Modulo_Id),0) + 1 From Modulo"

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
