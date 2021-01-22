Public Class TPreFacturaDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Long
    Private _Detalle_Id As Integer
    Private _Art_Id As String
    Private _Cantidad As Double
    Private _Fecha As Datetime
    Private _Costo As Double
    Private _Precio As Double
    Private _PorcDescuento As Double
    Private _MontoDescuento As Double
    Private _MontoIV As Double
    Private _TotalLinea As Double
    Private _ExentoIV As Integer
    Private _Suelto As Integer
    Private _Descripcion As String
    Private _Usuario As String
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
    Public Property Detalle_Id() As Integer
        Get
            Return _Detalle_Id
        End Get
        Set(ByVal Value As Integer)
            _Detalle_Id = Value
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
    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal Value As Double)
            _Cantidad = Value
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
    Public Property Costo() As Double
        Get
            Return _Costo
        End Get
        Set(ByVal Value As Double)
            _Costo = Value
        End Set
    End Property
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal Value As Double)
            _Precio = Value
        End Set
    End Property
    Public Property PorcDescuento() As Double
        Get
            Return _PorcDescuento
        End Get
        Set(ByVal Value As Double)
            _PorcDescuento = Value
        End Set
    End Property
    Public Property MontoDescuento() As Double
        Get
            Return _MontoDescuento
        End Get
        Set(ByVal Value As Double)
            _MontoDescuento = Value
        End Set
    End Property
    Public Property MontoIV() As Double
        Get
            Return _MontoIV
        End Get
        Set(ByVal Value As Double)
            _MontoIV = Value
        End Set
    End Property
    Public Property TotalLinea() As Double
        Get
            Return _TotalLinea
        End Get
        Set(ByVal Value As Double)
            _TotalLinea = Value
        End Set
    End Property
    Public Property ExentoIV() As Integer
        Get
            Return _ExentoIV
        End Get
        Set(ByVal Value As Integer)
            _ExentoIV = Value
        End Set
    End Property
    Public Property Suelto() As Integer
        Get
            Return _Suelto
        End Get
        Set(ByVal Value As Integer)
            _Suelto = Value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
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
    Public Sub New(ByVal pEmp_Id As Integer)
        MyBase.New()
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
    Public Sub New(ByVal pEmp_Id As Integer, ByVal pCnStr As String)
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
        _Detalle_Id = 0
        _Art_Id = ""
        _Cantidad = 0.0
        _Fecha = CDate("1900/01/01")
        _Costo = 0.0
        _Precio = 0.0
        _PorcDescuento = 0.0
        _MontoDescuento = 0.0
        _MontoIV = 0.0
        _TotalLinea = 0.0
        _ExentoIV = 0
        _Suelto = 0
        _Descripcion = ""
        _Usuario = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = " Insert into PreFacturaDetalle( Emp_Id , Suc_Id" & _
                   " , Caja_Id , TipoDoc_Id" & _
                   " , Documento_Id , Detalle_Id" & _
                   " , Art_Id , Cantidad" & _
                   " , Fecha , Costo" & _
                   " , Precio , PorcDescuento" & _
                   " , MontoDescuento , MontoIV" & _
                   " , TotalLinea , ExentoIV" & _
                   " , Suelto )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() & _
                   "," & _Documento_Id.ToString() & "," & _Detalle_Id.ToString() & _
                   ",'" & _Art_Id & "'" & "," & _Cantidad.ToString() & _
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Costo.ToString() & _
                   "," & _Precio.ToString() & "," & _PorcDescuento.ToString() & _
                   "," & _MontoDescuento.ToString() & "," & _MontoIV.ToString() & _
                   "," & _TotalLinea.ToString() & "," & _ExentoIV.ToString() & _
                   "," & _Suelto.ToString() & ")"

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

            query = "Delete PreFacturaDetalle" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Caja_Id=" & _Caja_Id.ToString() & _
               " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
               " And    Documento_Id=" & _Documento_Id.ToString() & _
               " And    Detalle_Id=" & _Detalle_Id.ToString()

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

            query = " Update dbo.PreFacturaDetalle " & _
                      " SET   Art_Id='" & _Art_Id & "' " & "," & _
                      " Cantidad=" & _Cantidad & "," & _
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                      " Costo=" & _Costo & "," & _
                      " Precio=" & _Precio & "," & _
                      " PorcDescuento=" & _PorcDescuento & "," & _
                      " MontoDescuento=" & _MontoDescuento & "," & _
                      " MontoIV=" & _MontoIV & "," & _
                      " TotalLinea=" & _TotalLinea & "," & _
                      " ExentoIV=" & _ExentoIV & "," & _
                      " Suelto=" & _Suelto & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Caja_Id=" & _Caja_Id.ToString() & _
                      " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
                      " And    Documento_Id=" & _Documento_Id.ToString() & _
                      " And    Detalle_Id=" & _Detalle_Id.ToString()

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

            Query = "select * From PreFacturaDetalle" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    Caja_Id=" & _Caja_Id.ToString() & _
           " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() & _
           " And    Documento_Id=" & _Documento_Id.ToString() & _
           " And    Detalle_Id=" & _Detalle_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _Detalle_Id = Tabla.Rows(0).Item("Detalle_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Cantidad = Tabla.Rows(0).Item("Cantidad")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Precio = Tabla.Rows(0).Item("Precio")
                _PorcDescuento = Tabla.Rows(0).Item("PorcDescuento")
                _MontoDescuento = Tabla.Rows(0).Item("MontoDescuento")
                _MontoIV = Tabla.Rows(0).Item("MontoIV")
                _TotalLinea = Tabla.Rows(0).Item("TotalLinea")
                _ExentoIV = Tabla.Rows(0).Item("ExentoIV")
                _Suelto = Tabla.Rows(0).Item("Suelto")
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

            Query = "select * From PreFacturaDetalle"

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
    Public Overrides Function LoadComboBox(ByVal pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select PreFacturaDetalle_Id as Numero, Nombre From PreFacturaDetalle"

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
