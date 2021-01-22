Public Class TTrasladoDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Traslado_Id As Integer
    Private _Detalle_Id As Integer
    Private _Art_Id As String
    Private _Cantidad As Double
    Private _CantidadLote As Double
    Private _Costo As Double
    Private _TotalLinea As Double
    Private _Suelto As Integer
    Private _Lote As Integer
    Private _Fecha As DateTime
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
    Public Property Traslado_Id() As Integer
        Get
            Return _Traslado_Id
        End Get
        Set(ByVal Value As Integer)
            _Traslado_Id = Value
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
    Public Property CantidadLote As Double
        Get
            Return _CantidadLote
        End Get
        Set(value As Double)
            _CantidadLote = value
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
    Public Property TotalLinea() As Double
        Get
            Return _TotalLinea
        End Get
        Set(ByVal Value As Double)
            _TotalLinea = Value
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
    Public Property Lote As Integer
        Get
            Return _Lote
        End Get
        Set(value As Integer)
            _Lote = value
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
        _Traslado_Id = 0
        _Detalle_Id = 0
        _Art_Id = ""
        _Cantidad = 0.0
        _Costo = 0.0
        _TotalLinea = 0.0
        _Suelto = 0
        _Fecha = CDate("1900/01/01")
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into TrasladoDetalle( Emp_Id , Traslado_Id" & _                   " , Detalle_Id , Art_Id" & _                   " , Cantidad , Costo" & _                   " , TotalLinea , Suelto" & _                   " , Fecha , UltimaModificacion" & _                   " )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Traslado_Id.ToString() & _                   "," & _Detalle_Id.ToString() & ",'" & _Art_Id & "'" & _                   "," & _Cantidad.ToString() & "," & _Costo.ToString() & _                   "," & _TotalLinea.ToString() & "," & _Suelto.ToString() & _                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "')"

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

            Query = "Delete TrasladoDetalle" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _               " And    Traslado_Id=" & _Traslado_Id.ToString() & _               " And    Detalle_Id=" & _Detalle_Id.ToString()

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

            Query = " Update dbo.TrasladoDetalle " & _
                      " SET   Art_Id='" & _Art_Id & "' " & "," & _                      " Cantidad=" & _Cantidad & "," & _                      " Costo=" & _Costo & "," & _                      " TotalLinea=" & _TotalLinea & "," & _                      " Suelto=" & _Suelto & "," & _                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _                      " And    Traslado_Id=" & _Traslado_Id.ToString() & _                      " And    Detalle_Id=" & _Detalle_Id.ToString()

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

            Query = "select * From TrasladoDetalle" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _           " And    Traslado_Id=" & _Traslado_Id.ToString() & _           " And    Detalle_Id=" & _Detalle_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Traslado_Id = Tabla.Rows(0).Item("Traslado_Id")
                _Detalle_Id = Tabla.Rows(0).Item("Detalle_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Cantidad = Tabla.Rows(0).Item("Cantidad")
                _Costo = Tabla.Rows(0).Item("Costo")
                _TotalLinea = Tabla.Rows(0).Item("TotalLinea")
                _Suelto = Tabla.Rows(0).Item("Suelto")
                _Fecha = Tabla.Rows(0).Item("Fecha")
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

            Query = "select a.*,b.Nombre From TrasladoDetalle a, Articulo b" & _
                " where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id and a.Emp_Id = " & _Emp_Id.ToString() & " and a.Traslado_Id = " & _Traslado_Id.ToString()

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

            Query = "select TrasladoDetalle_Id as Numero, Nombre From TrasladoDetalle"

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
