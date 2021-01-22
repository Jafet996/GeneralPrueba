Public Class TArticuloEquivalente
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Art_Id As String
    Private _ArtEquivalente_Id As String
    Private _UltimaModificacion As Datetime
    Private _Data As DataSet

#End Region

#Region "Definicion de propiedades"

    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    Public Property Art_Id() As String
        Get
            Return _Art_Id
        End Get
        Set(ByVal Value As String)
            _Art_Id = Value
        End Set
    End Property
    Public Property ArtEquivalente_Id() As String
        Get
            Return _ArtEquivalente_Id
        End Get
        Set(ByVal Value As String)
            _ArtEquivalente_Id = Value
        End Set
    End Property
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
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
    Public Sub New(pEmp_Id As Integer)
        MyBase.New()
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
    Public Sub New(pEmp_Id As Integer, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Art_Id = ""
        _ArtEquivalente_Id = ""
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ArticuloEquivalente( Emp_Id , Art_Id" & _
                   " , ArtEquivalente_Id , UltimaModificacion" & _
                   " )" & _
                   " Values ( " & _Emp_Id.ToString() & ",'" & _Art_Id & "'" & _
                   ",'" & _ArtEquivalente_Id & "'" & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "')"

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

            query = "Delete ArticuloEquivalente" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And     Art_Id='" & _Art_Id & "'" & _
               " And     ArtEquivalente_Id='" & _ArtEquivalente_Id & "'"

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

            query = " Update dbo.ArticuloEquivalente " & _
                      " SET    UltimaModificacion=" & _UltimaModificacion.ToString() & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And     Art_Id='" & _Art_Id & "'" & _
                      " And     ArtEquivalente_Id='" & _ArtEquivalente_Id & "'"

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

            ' Query = "select * From ArticuloEquivalente" & _
            '" Where     Emp_Id=" & _Emp_Id.ToString() & _
            '" And     Art_Id='" & _Art_Id & "'" & _
            '" And     ArtEquivalente_Id='" & _ArtEquivalente_Id & "'"


            Query = "select * From ArticuloEquivalente" & _
                " Where   Emp_Id=" & _Emp_Id.ToString() & _
                " And     ArtEquivalente_Id='" & _ArtEquivalente_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _ArtEquivalente_Id = Tabla.Rows(0).Item("ArtEquivalente_Id")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
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

            Query = "select * From ArticuloEquivalente where Emp_Id = " & _Emp_Id.ToString & " and Art_Id = '" & _Art_Id & "'"

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

            Query = "select ArticuloEquivalente_Id as Numero, Nombre From ArticuloEquivalente"

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
#End Region
End Class
