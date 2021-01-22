Imports System.Windows.Forms

Public Class TFacturaElectronica
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Long
    Private _Fecha As DateTime
    Private _Emisor_Id As Integer
    Private _Doc_Id As Int64
    Private _Consecutivo As String
    Private _Clave As String
    Private _FisicoIV As Double
    Private _FisicoTotal As Double
    Private _ElectronicoIV As Double
    Private _ElectronicoTotal As Double
    Private _Mensaje As String
    Private _Leyenda As String
    Private _TipoDoc As String
    Private _TipoDocNombre As String
    Private _Batch_Id As Long
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
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
        End Set
    End Property
    Public Property Emisor_Id() As Integer
        Get
            Return _Emisor_Id
        End Get
        Set(ByVal Value As Integer)
            _Emisor_Id = Value
        End Set
    End Property
    Public Property Doc_Id() As Int64
        Get
            Return _Doc_Id
        End Get
        Set(ByVal Value As Int64)
            _Doc_Id = Value
        End Set
    End Property
    Public Property Consecutivo() As String
        Get
            Return _Consecutivo
        End Get
        Set(ByVal Value As String)
            _Consecutivo = Value
        End Set
    End Property
    Public Property Clave() As String
        Get
            Return _Clave
        End Get
        Set(ByVal Value As String)
            _Clave = Value
        End Set
    End Property
    Public Property FisicoIV() As Double
        Get
            Return _FisicoIV
        End Get
        Set(ByVal Value As Double)
            _FisicoIV = Value
        End Set
    End Property
    Public Property FisicoTotal() As Double
        Get
            Return _FisicoTotal
        End Get
        Set(ByVal Value As Double)
            _FisicoTotal = Value
        End Set
    End Property
    Public Property ElectronicoIV() As Double
        Get
            Return _ElectronicoIV
        End Get
        Set(ByVal Value As Double)
            _ElectronicoIV = Value
        End Set
    End Property
    Public Property ElectronicoTotal() As Double
        Get
            Return _ElectronicoTotal
        End Get
        Set(ByVal Value As Double)
            _ElectronicoTotal = Value
        End Set
    End Property
    Public Property Mensaje As String
        Get
            Return _Mensaje
        End Get
        Set(value As String)
            _Mensaje = value
        End Set
    End Property
    Public Property Leyenda As String
        Get
            Return _Leyenda
        End Get
        Set(value As String)
            _Leyenda = value
        End Set
    End Property
    Public Property TipoDoc As String
        Get
            Return _TipoDoc
        End Get
        Set(value As String)
            _TipoDoc = value
        End Set
    End Property
    Public Property TipoDocNombre As String
        Get
            Return _TipoDocNombre
        End Get
        Set(value As String)
            _TipoDocNombre = value
        End Set
    End Property
    Public Property Batch_Id As Long
        Get
            Return _Batch_Id
        End Get
        Set(value As Long)
            _Batch_Id = value
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
        _Fecha = CDate("1900/01/01")
        _Emisor_Id = 0
        _Doc_Id = 0
        _Consecutivo = ""
        _Clave = ""
        _FisicoIV = 0.00
        _FisicoTotal = 0.00
        _ElectronicoIV = 0.00
        _ElectronicoTotal = 0.00
        _Mensaje = String.Empty
        _Leyenda = String.Empty
        _TipoDoc = String.Empty
        _TipoDocNombre = String.Empty
        _Batch_Id = 0
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into FacturaElectronica( Emp_Id , Suc_Id" &
                   " , Caja_Id , TipoDoc_Id" &
                   " , Documento_Id , Fecha" &
                   " , Emisor_Id , Doc_Id" &
                   " , Consecutivo , Clave" &
                   " , FisicoIV , FisicoTotal" &
                   " , ElectronicoIV , ElectronicoTotal" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() &
                   "," & _Documento_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & _Emisor_Id.ToString() & "," & _Doc_Id.ToString() &
                   ",'" & _Consecutivo & "'" & ",'" & _Clave & "'" &
                   "," & _FisicoIV.ToString() & "," & _FisicoTotal.ToString() &
                   "," & _ElectronicoIV.ToString() & "," & _ElectronicoTotal.ToString() & ")"

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

            Query = "Delete FacturaElectronica" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Caja_Id=" & _Caja_Id.ToString() &
               " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
               " And    Documento_Id=" & _Documento_Id.ToString()

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

            Query = " Update dbo.FacturaElectronica " &
                      " SET    Fecha=" & _Fecha.ToString() & "," &
                      " Emisor_Id=" & _Emisor_Id & "," &
                      " Doc_Id=" & _Doc_Id & "," &
                      " Consecutivo='" & _Consecutivo & "'" & "," &
                      " Clave='" & _Clave & "'" & "," &
                      " FisicoIV=" & _FisicoIV & "," &
                      " FisicoTotal=" & _FisicoTotal & "," &
                      " ElectronicoIV=" & _ElectronicoIV & "," &
                      " ElectronicoTotal=" & _ElectronicoTotal &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Caja_Id=" & _Caja_Id.ToString() &
                      " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
                      " And    Documento_Id=" & _Documento_Id.ToString()

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

            Query = "select * From FacturaElectronica" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Caja_Id=" & _Caja_Id.ToString() &
           " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
           " And    Documento_Id=" & _Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Emisor_Id = Tabla.Rows(0).Item("Emisor_Id")
                _Doc_Id = Tabla.Rows(0).Item("Doc_Id")
                _Consecutivo = Tabla.Rows(0).Item("Consecutivo")
                _Clave = Tabla.Rows(0).Item("Clave")
                _FisicoIV = Tabla.Rows(0).Item("FisicoIV")
                _FisicoTotal = Tabla.Rows(0).Item("FisicoTotal")
                _ElectronicoIV = Tabla.Rows(0).Item("ElectronicoIV")
                _ElectronicoTotal = Tabla.Rows(0).Item("ElectronicoTotal")
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

            Query = "select * From FacturaElectronica"

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

            Query = "select FacturaElectronica_Id as Numero, Nombre From FacturaElectronica"

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

    Public Function GuardaReferencia(pCn As Connection.TConnectionManager) As String
        Dim Query As String = ""
        Try

            Query = " Insert into FacturaElectronica( Emp_Id , Suc_Id" &
                   " , Caja_Id , TipoDoc_Id" &
                   " , Documento_Id , Fecha" &
                   " , Emisor_Id , Doc_Id" &
                   " , Consecutivo , Clave" &
                   " , FisicoIV , FisicoTotal" &
                   " , ElectronicoIV , ElectronicoTotal" &
                   " , Batch_Id)" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() &
                   "," & _Documento_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & _Emisor_Id.ToString() & "," & _Doc_Id.ToString() &
                   ",'" & _Consecutivo & "'" & ",'" & _Clave & "'" &
                   "," & _FisicoIV.ToString() & "," & _FisicoTotal.ToString() &
                   "," & _ElectronicoIV.ToString() & "," & _ElectronicoTotal.ToString() &
                   "," & _Batch_Id & ")"

            pCn.Ejecutar(Query)

            BitacoraErrores(Application.StartupPath, "Almacenadp Doc " & _Clave, "Gurdando en FacturaElectronica")

            Return ""
        Catch ex As Exception
            BitacoraErrores(Application.StartupPath, ex.Message, "Gurdando en FacturaElectronica")
            Return ex.Message
        End Try
    End Function

#End Region
End Class
