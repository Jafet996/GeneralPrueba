Public Class TCxPMovimiento
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Prov_Id As Integer
    Private _Estado_Id As Integer
    Private _Referencia As String
    Private _Fecha As DateTime
    Private _FechaRecibido As DateTime
    Private _FechaDocumento As DateTime
    Private _FechaVencimiento As DateTime
    Private _Moneda As Char
    Private _Monto As Double
    Private _Saldo As Double
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Usuario_Id As String
    Private _Batch_Id As Long
    Private _UltimaModificacion As DateTime
    Private _GeneraAsiento As Boolean
    Private _AsientoEncabezado As TAuxAsientoEncabezado
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
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
        End Set
    End Property
    Public Property Estado_Id() As Integer
        Get
            Return _Estado_Id
        End Get
        Set(ByVal Value As Integer)
            _Estado_Id = Value
        End Set
    End Property
    Public Property Referencia() As String
        Get
            Return _Referencia
        End Get
        Set(ByVal Value As String)
            _Referencia = Value
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
    Public Property FechaRecibido() As DateTime
        Get
            Return _FechaRecibido
        End Get
        Set(ByVal Value As DateTime)
            _FechaRecibido = Value
        End Set
    End Property
    Public Property FechaDocumento() As DateTime
        Get
            Return _FechaDocumento
        End Get
        Set(ByVal Value As DateTime)
            _FechaDocumento = Value
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
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
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
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
        End Set
    End Property
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
        End Set
    End Property
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public Property Batch_Id() As Long
        Get
            Return _Batch_Id
        End Get
        Set(ByVal Value As Long)
            _Batch_Id = Value
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
    Public Property GeneraAsiento As Boolean
        Get
            Return _GeneraAsiento
        End Get
        Set(value As Boolean)
            _GeneraAsiento = value
        End Set
    End Property
    Public Property AsientoEncabezado As TAuxAsientoEncabezado
        Get
            Return _AsientoEncabezado
        End Get
        Set(value As TAuxAsientoEncabezado)
            _AsientoEncabezado = value
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
        _Prov_Id = 0
        _Estado_Id = 0
        _Referencia = ""
        _Fecha = CDate("1900/01/01")
        _FechaRecibido = CDate("1900/01/01")
        _FechaDocumento = CDate("1900/01/01")
        _FechaVencimiento = CDate("1900/01/01")
        _Moneda = ""
        _Monto = 0.0
        _Saldo = 0.0
        _TipoCambio = 0.0
        _Dolares = 0
        _Usuario_Id = ""
        _Batch_Id = 0
        _UltimaModificacion = CDate("1900/01/01")
        _GeneraAsiento = False
        _AsientoEncabezado = New TAuxAsientoEncabezado(0)
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Dim Tabla As New DataTable

        Try
            Cn.Open()

            Cn.BeginTransaction()

            'Busca y asigna el siguiente número de batch
            VerificaMensaje(GetSiguienteBatch)

            'Guarda el encabezado del movimiento y este retorna el numero de movimiento
            Query = "exec CxP_CreaMovimiento " & _Emp_Id.ToString & "," & _Tipo_Id.ToString & "," & _Prov_Id.ToString & _
                    "," & _Estado_Id.ToString & ",'" & _Referencia & "','" & Format(_FechaRecibido, "yyyyMMdd") & "'" & _
                    ",'" & Format(_FechaDocumento, "yyyyMMdd") & "','" & Format(_FechaVencimiento, "yyyyMMdd") & "'" & _
                    ",'" & _Moneda & "'," & _Monto.ToString & "," & _TipoCambio.ToString & ",'" & _Usuario_Id & "'" & _
                    "," & _Batch_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            'Asigna el numero de movimiento retornado anteriormente
            If Not Tabla Is Nothing OrElse Tabla.Rows.Count > 0 Then
                _Mov_Id = Tabla.Rows(0).Item("Mov_Id")
            Else
                VerificaMensaje("Ocurrió un error al obtener el consecutivo del movimiento")
            End If

            If _GeneraAsiento Then
                Select Case _Tipo_Id
                    Case Enum_CxPMovimientoTipo.Factura, Enum_CxPMovimientoTipo.NotaCredito, Enum_CxPMovimientoTipo.NotaDebito, Enum_CxPMovimientoTipo.NotaDebitoXIntereses
                        Query = " exec CreaAuxAsientoEncabezado " & AsientoEncabezado.Emp_Id.ToString & "," & AsientoEncabezado.Annio.ToString & _
                                "," & AsientoEncabezado.Mes.ToString & ",'" & Format(AsientoEncabezado.Fecha, "yyyyMMdd HH:mm:ss") & "'," & AsientoEncabezado.Tipo_Id.ToString & _
                                ",'" & AsientoEncabezado.Comentario & "'" & "," & AsientoEncabezado.Debitos.ToString & "," & AsientoEncabezado.Creditos.ToString & ",'" & _Usuario_Id & "'" & _
                                "," & AsientoEncabezado.Origen_Id.ToString & ",'" & AsientoEncabezado.MAC_Address & "'"

                        Tabla = Cn.Seleccionar(Query).Copy

                        If Not Tabla Is Nothing OrElse Tabla.Rows.Count > 0 Then
                            AsientoEncabezado.Asiento_Id = Tabla.Rows(0).Item("Asiento_Id")
                        End If

                        For Each Item As TAuxAsientoDetalle In AsientoEncabezado.ListaDetalle
                            Query = " exec CreaAuxAsientoDetalle " & Item.Emp_Id.ToString & "," & AsientoEncabezado.Asiento_Id.ToString & _
                                    "," & Item.Linea_Id.ToString & ",'" & Format(Item.Fecha, "yyyyMMdd HH:mm:ss") & "'" & _
                                    ",'" & Item.Moneda.ToString & "'," & Item.CC_Id.ToString & ",'" & Item.Cuenta_Id & "'" & _
                                    ",'" & Item.Tipo.ToString & "'," & Item.Monto.ToString & "," & Item.MontoDolares.ToString & _
                                    "," & Item.TipoCambio.ToString & ",'" & Item.Referencia & "','" & Item.Descripcion & "'"

                            Cn.Ejecutar(Query)
                        Next
                End Select
            End If

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

            Query = "Delete CxPMovimiento" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
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

            Query = " Update CxPMovimiento " & _
                    " SET    Cliente_Id = " & _Prov_Id.ToString & "," & _
                    " Estado_Id = " & _Estado_Id & "," & _
                    " Referencia = '" & _Referencia & "'" & "," & _
                    " Fecha = '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " FechaRecibido = '" & Format(_FechaRecibido, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " FechaDocumento = '" & Format(_FechaDocumento, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " FechaVencimiento = '" & Format(_FechaVencimiento, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " Moneda = '" & _Moneda & "'" & "," & _
                    " Monto = " & _Monto & "," & _
                    " Saldo = " & _Saldo & "," & _
                    " TipoCambio = " & _TipoCambio & "," & _
                    " Dolares = " & _Dolares & "," & _
                    " Usuario_Id = '" & _Usuario_Id & "'" & "," & _
                    " Batch_Id = " & _Batch_Id & "," & _
                    " UltimaModificacion = GETDATE()" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
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

            Query = "select a.*" & _
                    " ,b.Nombre as NombreTipo" & _
                    " ,c.Nombre as NombreUsuario" & _
                    " ,d.Nombre as NombreProveedor" & _
                    " ,d.Saldo as SaldoProveedor" & _
                    " From CxPMovimiento a" & _
                    " ,CxPMovimientoTipo b" & _
                    " ,Usuario c" & _
                    " ,Proveedor d" & _
                    " Where a.Emp_Id = b.Emp_Id" & _
                    " And   a.Tipo_Id = b.Tipo_Id" & _
                    " And   a.Emp_Id = c.Emp_Id" & _
                    " And   a.Usuario_Id = c.Usuario_Id" & _
                    " And   a.Emp_Id = d.Emp_Id" & _
                    " And   a.Prov_Id = d.Prov_Id" & _
                    " And   a.Emp_Id = " & _Emp_Id.ToString & _
                    " And   a.Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   a.Mov_Id = " & _Mov_Id.ToString

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

            Query = "select * From CxPMovimiento"

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

            Query = "select Mov_Id as Numero, Nombre From CxPMovimiento"

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

            Query = "select Mov_Id as Codigo, Nombre From CxPMovimiento" & _
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

            Query = "select IsNull(MAX(Mov_Id),0) + 1 as Mov_Id From CxPMovimiento" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
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
    Private Function GetSiguienteBatch() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Query = "SELECT NEXT VALUE FOR BatchNumber as Batch_Id"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Batch_Id = Tabla.Rows(0).Item("Batch_Id")
            Else
                VerificaMensaje("Ocurrió un error buscando el número de batch")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class