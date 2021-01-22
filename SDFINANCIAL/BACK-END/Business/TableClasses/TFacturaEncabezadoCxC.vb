Public Class TFacturaEncabezadoCxC
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Long
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Fecha As DateTime
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
    Public Property Suc_Id() As Integer
        Get
            Return _Suc_Id
        End Get
        Set(ByVal Value As Integer)
            _Suc_Id = Value
        End Set
    End Property
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
        End Set
    End Property
    Public Property TipoDoc_Id() As Integer
        Get
            Return _TipoDoc_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoDoc_Id = Value
        End Set
    End Property
    Public Property Documento_Id() As Long
        Get
            Return _Documento_Id
        End Get
        Set(ByVal Value As Long)
            _Documento_Id = Value
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
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
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
        _Suc_Id = 0
        _Caja_Id = 0
        _TipoDoc_Id = 0
        _Documento_Id = 0
        _Tipo_Id = 0
        _Mov_Id = 0
        _Fecha = CDate("1900/01/01")
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into FacturaEncabezadoCxC( Emp_Id , Suc_Id" &
       " , Caja_Id , TipoDoc_Id" &
       " , Documento_Id , Tipo_Id" &
       " , Mov_Id , Fecha" &
       " )" &
       " Values ( " & _Emp_Id.ToString & "," & _Suc_Id.ToString &
       "," & _Caja_Id.ToString & "," & _TipoDoc_Id.ToString &
       "," & _Documento_Id.ToString & "," & _Tipo_Id.ToString &
       "," & _Mov_Id.ToString & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
       ")"

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

            Query = "Delete FacturaEncabezadoCxC" &
               " Where Emp_Id = " & _Emp_Id.ToString &
               " And   Suc_Id = " & _Suc_Id.ToString &
               " And   Caja_Id = " & _Caja_Id.ToString &
               " And   TipoDoc_Id = " & _TipoDoc_Id.ToString &
               " And   Documento_Id = " & _Documento_Id.ToString &
               " And   Tipo_Id = " & _Tipo_Id.ToString &
               " And   Mov_Id = " & _Mov_Id.ToString

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

            Query = " Update FacturaEncabezadoCxC " &
           " SET    Fecha = " & _Fecha.ToString &
           " Where Emp_Id = " & _Emp_Id.ToString &
           " And   Suc_Id = " & _Suc_Id.ToString &
           " And   Caja_Id = " & _Caja_Id.ToString &
           " And   TipoDoc_Id = " & _TipoDoc_Id.ToString &
           " And   Documento_Id = " & _Documento_Id.ToString &
           " And   Tipo_Id = " & _Tipo_Id.ToString &
           " And   Mov_Id = " & _Mov_Id.ToString

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

            Query = "select * From FacturaEncabezadoCxC" &
           " Where Emp_Id = " & _Emp_Id.ToString &
           " And   Suc_Id = " & _Suc_Id.ToString &
           " And   Caja_Id = " & _Caja_Id.ToString &
           " And   TipoDoc_Id = " & _TipoDoc_Id.ToString &
           " And   Documento_Id = " & _Documento_Id.ToString &
           " And   Tipo_Id = " & _Tipo_Id.ToString &
           " And   Mov_Id = " & _Mov_Id.ToString

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
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select * From FacturaEncabezadoCxC"

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
    Public Overrides Function LoadComboBox() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select FacturaEncabezadoCxC_Id as Numero, Nombre From FacturaEncabezadoCxC" &
                    " where Emp_Id = " & _Emp_Id.ToString &
                    " and   Activo = 1"

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
    Public Overrides Function ListMant(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
 
        Try
            Cn.Open()
 
            Query = "select FacturaEncabezadoCxC_Id as Codigo, Nombre From FacturaEncabezadoCxC" & _
                    " where Emp_Id = " & _Emp_Id.ToString
 
            If pNombre.Trim <> "" Then
                Query += " and Nombre Like '%" & pNombre & "%'"
            End If

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
    Public Overrides Function NextOne() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select ISNULL(MAX(FacturaEncabezadoCxC_Id),0) + 1 as FacturaEncabezadoCxC_Id From FacturaEncabezadoCxC" &
           " Where Emp_Id = " & _Emp_Id.ToString &
           " And   Suc_Id = " & _Suc_Id.ToString &
           " And   Caja_Id = " & _Caja_Id.ToString &
           " And   TipoDoc_Id = " & _TipoDoc_Id.ToString &
           " And   Documento_Id = " & _Documento_Id.ToString &
           " And   Tipo_Id = " & _Tipo_Id.ToString

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
#End Region
End Class
