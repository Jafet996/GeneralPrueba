Public Class TApartadoDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Apartado_Id As Long
    Private _Detalle_Id As Integer
    Private _Art_Id As String
    Private _Cantidad As Double
    Private _Fecha As DateTime
    Private _Costo As Double
    Private _Precio As Double
    Private _PorcDescuento As Double
    Private _MontoDescuento As Double
    Private _MontoIV As Double
    Private _TotalLinea As Double
    Private _ExentoIV As Boolean
    Private _Suelto As Boolean
    Private _Observacion As String
    Private _Servicio As Boolean
    Private _Data As DataSet
    Private _Articulo As String
    Private _Monto As Double
    Private _Detalles As New List(Of TApartadoDetalle)

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
    Public Property Apartado_Id() As Long
        Get
            Return _Apartado_Id
        End Get
        Set(ByVal Value As Long)
            _Apartado_Id = Value
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
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
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
    Public Property ExentoIV() As Boolean
        Get
            Return _ExentoIV
        End Get
        Set(ByVal Value As Boolean)
            _ExentoIV = Value
        End Set
    End Property
    Public Property Suelto() As Boolean
        Get
            Return _Suelto
        End Get
        Set(ByVal Value As Boolean)
            _Suelto = Value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal Value As String)
            _Observacion = Value
        End Set
    End Property
    Public Property Servicio() As Boolean
        Get
            Return _Servicio
        End Get
        Set(ByVal Value As Boolean)
            _Servicio = Value
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
    Public Property Articulo() As String
        Get
            Return _Articulo
        End Get
        Set(ByVal Value As String)
            _Articulo = Value
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
        _Apartado_Id = 0
        _Detalle_Id = 0
        _Art_Id = ""
        _Cantidad = 0.00
        _Fecha = CDate("1900/01/01")
        _Costo = 0.00
        _Precio = 0.00
        _PorcDescuento = 0.00
        _MontoDescuento = 0.00
        _MontoIV = 0.00
        _TotalLinea = 0.00
        _ExentoIV = 0
        _Suelto = 0
        _Observacion = ""
        _Servicio = 0
        _Data = New DataSet
        _Articulo = ""
        _Monto = 0.00
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ApartadoDetalle( Emp_Id , Suc_Id" &
                   " , Apartado_Id , Detalle_Id" &
                   " , Art_Id , Cantidad" &
                   " , Fecha , Costo" &
                   " , Precio , PorcDescuento" &
                   " , MontoDescuento , MontoIV" &
                   " , TotalLinea , ExentoIV" &
                   " , Suelto , Observacion" &
                   " , Servicio )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Apartado_Id.ToString() & "," & _Detalle_Id.ToString() &
                   ",'" & _Art_Id & "'" & "," & _Cantidad.ToString() &
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Costo.ToString() &
                   "," & _Precio.ToString() & "," & _PorcDescuento.ToString() &
                   "," & _MontoDescuento.ToString() & "," & _MontoIV.ToString() &
                   "," & _TotalLinea.ToString() & "," & _ExentoIV.ToString() &
                   "," & _Suelto.ToString() & ",'" & _Observacion & "'" &
                   "," & _Servicio.ToString() & ")"

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

            Query = "Delete ApartadoDetalle" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Apartado_Id=" & _Apartado_Id.ToString() &
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

            Query = " Update dbo.ApartadoDetalle " &
                      " SET   Art_Id='" & _Art_Id & "' " & "," &
                      " Cantidad=" & _Cantidad & "," &
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " Costo=" & _Costo & "," &
                      " Precio=" & _Precio & "," &
                      " PorcDescuento=" & _PorcDescuento & "," &
                      " MontoDescuento=" & _MontoDescuento & "," &
                      " MontoIV=" & _MontoIV & "," &
                      " TotalLinea=" & _TotalLinea & "," &
                      " ExentoIV=" & _ExentoIV & "," &
                      " Suelto=" & _Suelto & "," &
                      " Observacion='" & _Observacion & "'" & "," &
                      " Servicio=" & _Servicio &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Apartado_Id=" & _Apartado_Id.ToString() &
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

            Query = "select * From ApartadoDetalle" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Apartado_Id=" & _Apartado_Id.ToString() &
           " And    Detalle_Id=" & _Detalle_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Apartado_Id = Tabla.Rows(0).Item("Apartado_Id")
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
                _Observacion = Tabla.Rows(0).Item("Observacion")
                _Servicio = Tabla.Rows(0).Item("Servicio")
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

            Query = "select * From ApartadoDetalle"

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

            Query = "select ApartadoDetalle_Id as Numero, Nombre From ApartadoDetalle"

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

    Public Function ObtenerDetallesApartado() As List(Of TApartadoDetalle)

        Dim Query As String
        Dim Tabla As DataTable
        Dim Detalles As New List(Of TApartadoDetalle)

        Try

            Cn.Open()

            Query = "SELECT * FROM ApartadoDetalle" &
                    " WHERE Emp_Id = " & Emp_Id &
                    " AND Suc_Id =" & Suc_Id &
                    " AND Apartado_Id =" & Apartado_Id

            Tabla = Cn.Seleccionar(Query).Copy

            For Each row As DataRow In Tabla.Rows

                Dim detalle As New TApartadoDetalle(EmpresaInfo.Emp_Id)

                With detalle
                    .Emp_Id = Emp_Id
                    .Suc_Id = Suc_Id
                    .Apartado_Id = Apartado_Id
                    .Detalle_Id = row.Item("Detalle_Id").ToString()
                    .Art_Id = row.Item("Art_Id").ToString()
                    .Cantidad = row.Item("Cantidad").ToString()
                    .Fecha = CDate(row.Item("Fecha").ToString())
                    .Costo = row.Item("Costo").ToString()
                    .Precio = row.Item("Precio").ToString()
                    .PorcDescuento = row.Item("PorcDescuento").ToString()
                    .MontoDescuento = row.Item("MontoDescuento").ToString()
                    .MontoIV = row.Item("MontoIV").ToString()
                    .TotalLinea = row.Item("TotalLinea").ToString()
                    .ExentoIV = row.Item("ExentoIV").ToString()
                    .Suelto = row.Item("Suelto").ToString()
                    .Observacion = row.Item("Observacion").ToString()
                    .Servicio = row.Item("Servicio").ToString()
                End With

                Detalles.Add(detalle)

            Next
            Return Detalles
        Catch ex As Exception
            Throw ex
        Finally
            Cn.Close()
        End Try

    End Function
#End Region
End Class
