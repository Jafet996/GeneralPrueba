Public Class TEntradaFactura
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Entrada_Id As Integer
    Private _Factura_Id As Integer
    Private _Prov_Id As Integer
    Private _Factura As String
    Private _Monto As Double
    Private _FechaVencimiento As DateTime
    Private _Comentario As String
    Private _Tipo_Id As Integer
    Private _TipoFacturaNombre As String
    Private _UltimaModificacion As DateTime
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
    Public Property Entrada_Id() As Integer
        Get
            Return _Entrada_Id
        End Get
        Set(ByVal Value As Integer)
            _Entrada_Id = Value
        End Set
    End Property
    Public Property Factura_Id() As Integer
        Get
            Return _Factura_Id
        End Get
        Set(ByVal Value As Integer)
            _Factura_Id = Value
        End Set
    End Property
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
        End Set
    End Property
    Public Property Factura() As String
        Get
            Return _Factura
        End Get
        Set(ByVal Value As String)
            _Factura = Value
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
    Public Property FechaVencimiento() As DateTime
        Get
            Return _FechaVencimiento
        End Get
        Set(ByVal Value As DateTime)
            _FechaVencimiento = Value
        End Set
    End Property
    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(ByVal Value As String)
            _Comentario = Value
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
    Public Property TipoFacturaNombre() As String
        Get
            Return _TipoFacturaNombre
        End Get
        Set(ByVal value As String)
            _TipoFacturaNombre = value
        End Set
    End Property

    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
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
        _Suc_Id = 0
        _Entrada_Id = 0
        _Factura_Id = 0
        _Prov_Id = 0
        _Factura = ""
        _Monto = 0.0
        _FechaVencimiento = CDate("1900/01/01")
        _Comentario = ""
        _UltimaModificacion = CDate("1900/01/01")
        _Tipo_Id = 0
        _TipoFacturaNombre = ""
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()


            Query = " Insert into EntradaFactura( Emp_Id , Suc_Id" &
            " , Entrada_Id , Factura_Id" &
            " , Prov_Id , Factura" &
            " , Monto , FechaVencimiento" &
            " , Comentario , Tipo_Id" &
            " , UltimaModificacion )" &
            " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
            "," & _Entrada_Id.ToString() & "," & _Factura_Id.ToString() &
            "," & _Prov_Id.ToString() & ",'" & _Factura & "'" &
            "," & _Monto.ToString() & ",'" & Format(_FechaVencimiento, "yyyyMMdd HH:mm:ss") & "'" &
            ",'" & _Comentario & "'" & "," & _Tipo_Id.ToString() &
            ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & ")"

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

            Query = "Delete EntradaFactura" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Entrada_Id=" & _Entrada_Id.ToString() &
               " And    Factura_Id=" & _Factura_Id.ToString()

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

            Query = " Update dbo.EntradaFactura " &
                      " SET    Prov_Id=" & _Prov_Id.ToString() & "," &
                      " Factura='" & _Factura & "'" & "," &
                      " Monto=" & _Monto & "," &
                      " FechaVencimiento='" & Format(_FechaVencimiento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " Comentario='" & _Comentario & "'" & "," &
                      " Tipo_Id=" & _Tipo_Id & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Entrada_Id=" & _Entrada_Id.ToString() &
                      " And    Factura_Id=" & _Factura_Id.ToString()

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

            Query = "select a.*, b.Nombre as TipoFacturaNombre From EntradaFactura a, EntradaFacturaTipo b" &
           " Where  a.Emp_Id        = b.Emp_Id" &
           " And    a.Tipo_Id       = b.Tipo_Id " &
           " And    a.Emp_Id        = " & _Emp_Id.ToString() &
           " And    a.Suc_Id        = " & _Suc_Id.ToString() &
           " And    a.Entrada_Id    = " & _Entrada_Id.ToString() &
           " And    a.Factura_Id    = " & _Factura_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Entrada_Id = Tabla.Rows(0).Item("Entrada_Id")
                _Factura_Id = Tabla.Rows(0).Item("Factura_Id")
                _Prov_Id = Tabla.Rows(0).Item("Prov_Id")
                _Factura = Tabla.Rows(0).Item("Factura")
                _Monto = Tabla.Rows(0).Item("Monto")
                _FechaVencimiento = Tabla.Rows(0).Item("FechaVencimiento")
                _Comentario = Tabla.Rows(0).Item("Comentario")
                _Tipo_Id = Tabla.Rows(0).Item("Tipo_Id")
                _TipoFacturaNombre = Tabla.Rows(0).Item("TipoFacturaNombre")
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

            Query = "select a.*, b.Nombre as TipoFacturaNombre From EntradaFactura a, EntradaFacturaTipo b" &
                   " Where  a.Emp_Id        = b.Emp_Id" &
                   " And    a.Tipo_Id       = b.Tipo_Id " &
                   " And    a.Emp_Id        = " & _Emp_Id.ToString() &
                   " And    a.Suc_Id        = " & _Suc_Id.ToString() &
                   " And    a.Entrada_Id    = " & _Entrada_Id.ToString()

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

            Query = "select EntradaFactura_Id as Numero, Nombre From EntradaFactura"

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

    Public Function ValidaFacturaProveedor() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From EntradaFactura" &
           " Where  Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           IIf(_Entrada_Id > 0, " And Entrada_Id <> " & _Entrada_Id.ToString(), "") &
           " And    Prov_Id = " & _Prov_Id.ToString() &
           " And    Factura = '" & _Factura & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                VerificaMensaje("La factura # " & Tabla.Rows(0).Item("Factura") & " ya se encuentra registrada para el mismo proveedor")
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
