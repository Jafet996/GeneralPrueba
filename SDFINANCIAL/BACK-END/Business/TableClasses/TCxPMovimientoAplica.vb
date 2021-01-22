Public Class TCxPMovimientoAplica
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Aplica_Id As Integer
    Private _TipoAplica_Id As Integer
    Private _MovAplica_Id As Long
    Private _Fecha As Datetime
    Private _Monto As Double
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    Public Property Mov_Id() As Long
        Get
            Return _Mov_Id
        End Get
        Set(ByVal Value As Long)
            _Mov_Id = Value
        End Set
    End Property
    Public Property Aplica_Id() As Integer
        Get
            Return _Aplica_Id
        End Get
        Set(ByVal Value As Integer)
            _Aplica_Id = Value
        End Set
    End Property
    Public Property TipoAplica_Id() As Integer
        Get
            Return _TipoAplica_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoAplica_Id = Value
        End Set
    End Property
    Public Property MovAplica_Id() As Long
        Get
            Return _MovAplica_Id
        End Get
        Set(ByVal Value As Long)
            _MovAplica_Id = Value
        End Set
    End Property
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
        End Set
    End Property
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
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
        _Tipo_Id = 0
        _Mov_Id = 0
        _Aplica_Id = 0
        _TipoAplica_Id = 0
        _MovAplica_Id = 0
        _Fecha = CDate("1900/01/01")
        _Monto = 0.0
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CxPMovimientoAplica( Emp_Id , Tipo_Id" & _
                    " , Mov_Id , Aplica_Id" & _
                    " , TipoAplica_Id , MovAplica_Id" & _
                    " , Fecha , Monto" & _
                    " )" & _
                    " Values ( " & _Emp_Id.ToString & "," & _Tipo_Id.ToString & _
                    "," & _Mov_Id.ToString & "," & _Aplica_Id.ToString & _
                    "," & _TipoAplica_Id.ToString & "," & _MovAplica_Id.ToString & _
                    ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Monto.ToString & _
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

            Query = "Delete CxPMovimientoAplica" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Mov_Id = " & _Mov_Id.ToString & _
                    " And   Aplica_Id = " & _Aplica_Id.ToString

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

            Query = " Update CxPMovimientoAplica " & _
                    " SET    TipoAplica_Id = " & _TipoAplica_Id.ToString & "," & _
                    " MovAplica_Id = " & _MovAplica_Id & "," & _
                    " Fecha = '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " Monto = " & _Monto & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Mov_Id = " & _Mov_Id.ToString & _
                    " And   Aplica_Id = " & _Aplica_Id.ToString

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

            Query = "select * From CxPMovimientoAplica" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Mov_Id = " & _Mov_Id.ToString & _
                    " And   Aplica_Id = " & _Aplica_Id.ToString

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

            Query = "select * From CxPMovimientoAplica"

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

            Query = "select Aplica_Id as Numero, Nombre From CxPMovimientoAplica"

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

            Query = "select Aplica_Id as Codigo, Nombre From CxPMovimientoAplica" & _
                    " where Emp_Id = " & _Emp_Id.ToString

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

            Query = "select IsNull(MAX(Aplica_Id),0) + 1 as Aplica_Id From CxPMovimientoAplica" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Mov_Id = " & _Mov_Id.ToString

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