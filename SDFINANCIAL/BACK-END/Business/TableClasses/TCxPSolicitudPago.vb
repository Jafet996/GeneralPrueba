Public Class TCxPSolicitudPago
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Solicitud_Id As Long
    Private _Prov_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Fecha As Datetime
    Private _Monto As Double
    Private _Moneda As Char
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Usuario_Id As String
    Private _UltimaModificacion As DateTime
    Private _PagoMonto As Double
    Private _PagoDolares As Double
    Private _Diferencial As Double
    Private _ListaMovimientos As New List(Of TCxPMovimientoLinea)
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
    Public Property Solicitud_Id() As Long
        Get
            Return _Solicitud_Id
        End Get
        Set(ByVal Value As Long)
            _Solicitud_Id = Value
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
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
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
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public Property PagoMonto As Double
        Get
            Return _PagoMonto
        End Get
        Set(value As Double)
            _PagoMonto = value
        End Set
    End Property
    Public Property PagoDolares As Double
        Get
            Return _PagoDolares
        End Get
        Set(value As Double)
            _PagoDolares = value
        End Set
    End Property
    Public Property Diferencial As Double
        Get
            Return _Diferencial
        End Get
        Set(value As Double)
            _Diferencial = value
        End Set
    End Property
    Public Property ListaMovimientos As List(Of TCxPMovimientoLinea)
        Get
            Return _ListaMovimientos
        End Get
        Set(value As List(Of TCxPMovimientoLinea))
            _ListaMovimientos = value
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
        _Solicitud_Id = 0
        _Prov_Id = 0
        _Tipo_Id = 0
        _Mov_Id = 0
        _Fecha = CDate("1900/01/01")
        _Monto = 0.0
        _Moneda = ""
        _TipoCambio = 0.0
        _Dolares = 0.0
        _Usuario_Id = ""
        _UltimaModificacion = CDate("1900/01/01")
        _PagoMonto = 0
        _PagoDolares = 0
        _Diferencial = 0.0
        _ListaMovimientos.Clear()
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String

        Try
            Cn.Open()

            Cn.BeginTransaction()

            For Each Movimiento As TCxPMovimientoLinea In _ListaMovimientos
                Query = "exec CxP_CreaSolicitudPago " & _Emp_Id.ToString & "," & _Prov_Id.ToString & _
                        "," & Movimiento.Tipo_Id.ToString & "," & Movimiento.Mov_Id.ToString & _
                        "," & Movimiento.Monto.ToString & ",'" & Movimiento.Moneda & "'," & Movimiento.TipoCambio.ToString & _
                        "," & Movimiento.Dolares.ToString & ",'" & _Usuario_Id & "'"

                Cn.Ejecutar(Query)
            Next

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

            For Each Movimiento As TCxPMovimientoLinea In _ListaMovimientos
                Query = "exec CxP_CancelaSolicitudPago " & _Emp_Id.ToString & "," & Movimiento.Tipo_Id.ToString & _
                        "," & Movimiento.Mov_Id.ToString & ",'" & _Usuario_Id & "'"

                Cn.Ejecutar(Query)
            Next

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

            Query = " Update CxPSolicitudPago " & _
                    " SET    Prov_Id = " & _Prov_Id.ToString & "," & _
                    " Tipo_Id = " & _Tipo_Id.ToString & "," & _
                    " Mov_Id = " & _Mov_Id & "," & _
                    " Fecha = '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " Monto = " & _Monto & "," & _
                    " Moneda = '" & _Moneda & "'" & "," & _
                    " TipoCambio = " & _TipoCambio & "," & _
                    " Dolares = " & _Dolares & "," & _
                    " Usuario_Id = '" & _Usuario_Id & "'" & "," & _
                    " UltimaModificacion = GETDATE()" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Solicitud_Id = " & _Solicitud_Id.ToString

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

            Query = "select * From CxPSolicitudPago" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Solicitud_Id = " & _Solicitud_Id.ToString

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

            Query = "select * From CxPSolicitudPago"

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

            Query = "select CxPSolicitudPago_Id as Numero, Nombre From CxPSolicitudPago" & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
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

            Query = "select CxPSolicitudPago_Id as Codigo, Nombre From CxPSolicitudPago" & _
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

            Query = "select ISNULL(MAX(CxPSolicitudPago_Id),0) + 1 as CxPSolicitudPago_Id From CxPSolicitudPago" & _
                    " Where Emp_Id = " & _Emp_Id.ToString

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