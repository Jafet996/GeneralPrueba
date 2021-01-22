Public Class TCxCMovimientoPago
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Pago_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _TipoPago_Id As Integer
    Private _Monto As Double
    Private _Banco_Id As Integer
    Private _Cuenta As String
    Private _ChequeNumero As String
    Private _ChequeFecha As DateTime
    Private _DepositoNumero As String
    Private _DepositoFecha As DateTime
    Private _TransferenciaNumero As String
    Private _Tarjeta_Id As Integer
    Private _TarjetaNumero As String
    Private _TarjetaAutorizacion As String
    Private _Moneda As Char
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Fecha As DateTime
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
    Public Property Pago_Id() As Integer
        Get
            Return _Pago_Id
        End Get
        Set(ByVal Value As Integer)
            _Pago_Id = Value
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
    Public Property Cierre_Id() As Integer
        Get
            Return _Cierre_Id
        End Get
        Set(ByVal Value As Integer)
            _Cierre_Id = Value
        End Set
    End Property
    Public Property TipoPago_Id() As Integer
        Get
            Return _TipoPago_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoPago_Id = Value
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
    Public Property Banco_Id() As Integer
        Get
            Return _Banco_Id
        End Get
        Set(ByVal Value As Integer)
            _Banco_Id = Value
        End Set
    End Property
    Public Property Cuenta() As String
        Get
            Return _Cuenta
        End Get
        Set(ByVal Value As String)
            _Cuenta = Value
        End Set
    End Property
    Public Property ChequeNumero() As String
        Get
            Return _ChequeNumero
        End Get
        Set(ByVal Value As String)
            _ChequeNumero = Value
        End Set
    End Property
    Public Property ChequeFecha() As DateTime
        Get
            Return _ChequeFecha
        End Get
        Set(ByVal Value As DateTime)
            _ChequeFecha = Value
        End Set
    End Property
    Public Property DepositoNumero() As String
        Get
            Return _DepositoNumero
        End Get
        Set(ByVal Value As String)
            _DepositoNumero = Value
        End Set
    End Property
    Public Property DepositoFecha() As DateTime
        Get
            Return _DepositoFecha
        End Get
        Set(ByVal Value As DateTime)
            _DepositoFecha = Value
        End Set
    End Property
    Public Property TransferenciaNumero() As String
        Get
            Return _TransferenciaNumero
        End Get
        Set(ByVal Value As String)
            _TransferenciaNumero = Value
        End Set
    End Property
    Public Property Tarjeta_Id() As Integer
        Get
            Return _Tarjeta_Id
        End Get
        Set(ByVal Value As Integer)
            _Tarjeta_Id = Value
        End Set
    End Property
    Public Property TarjetaNumero() As String
        Get
            Return _TarjetaNumero
        End Get
        Set(ByVal Value As String)
            _TarjetaNumero = Value
        End Set
    End Property
    Public Property TarjetaAutorizacion() As String
        Get
            Return _TarjetaAutorizacion
        End Get
        Set(ByVal Value As String)
            _TarjetaAutorizacion = Value
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
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
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
        _Pago_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _TipoPago_Id = 0
        _Monto = 0.0
        _Banco_Id = 0
        _Cuenta = ""
        _ChequeNumero = ""
        _ChequeFecha = CDate("1900/01/01")
        _DepositoNumero = ""
        _DepositoFecha = CDate("1900/01/01")
        _TransferenciaNumero = ""
        _Tarjeta_Id = 0
        _TarjetaNumero = ""
        _TarjetaAutorizacion = ""
        _Moneda = ""
        _TipoCambio = 0.0
        _Dolares = 0.0
        _Fecha = CDate("1900/01/01")
        _Batch_Id = 0
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CxCMovimientoPago( Emp_Id , Tipo_Id" & _
                    " , Mov_Id , Pago_Id" & _
                    " , Caja_Id , Cierre_Id" & _
                    " , TipoPago_Id , Monto" & _
                    " , Banco_Id , Cuenta" & _
                    " , ChequeNumero , ChequeFecha" & _
                    " , DepositoNumero , DepositoFecha" & _
                    " , TransferenciaNumero , Tarjeta_Id" & _
                    " , TarjetaNumero , TarjetaAutorizacion" & _
                    " , Fecha , Moneda" & _
                    " , TipoCambio , Dolares" & _
                    " , Batch_Id )" & _
                    " Values ( " & _Emp_Id.ToString & "," & _Tipo_Id.ToString & _
                    "," & _Mov_Id.ToString & "," & _Pago_Id.ToString & _
                    "," & _Caja_Id.ToString & "," & _Cierre_Id.ToString & _
                    "," & _TipoPago_Id.ToString & "," & _Monto.ToString & _
                    "," & _Banco_Id.ToString & ",'" & _Cuenta & "'" & _
                    ",'" & _ChequeNumero & "'" & ",'" & Format(_ChequeFecha, "yyyyMMdd HH:mm:ss") & "'" & _
                    ",'" & _DepositoNumero & "'" & ",'" & Format(_DepositoFecha, "yyyyMMdd HH:mm:ss") & "'" & _
                    ",'" & _TransferenciaNumero & "'" & "," & _Tarjeta_Id.ToString & _
                    ",'" & _TarjetaNumero & "'" & ",'" & _TarjetaAutorizacion & "'" & _
                    ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _Moneda & "'" & _
                    "," & _TipoCambio.ToString & "," & _Dolares.ToString & _
                    "," & _Batch_Id.ToString & ")"

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

            Query = "Delete CxcMovimientoPago" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Mov_Id = " & _Mov_Id.ToString & _
                    " And   Pago_Id = " & _Pago_Id.ToString

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

            Query = " Update CxcMovimientoPago " & _
                    " SET    Caja_Id = " & _Caja_Id.ToString & "," & _
                    " Cierre_Id = " & _Cierre_Id & "," & _
                    " TipoPago_Id = " & _TipoPago_Id & "," & _
                    " Monto = " & _Monto & "," & _
                    " Banco_Id = " & _Banco_Id & "," & _
                    " Cuenta = '" & _Cuenta & "'" & "," & _
                    " ChequeNumero = '" & _ChequeNumero & "'" & "," & _
                    " ChequeFecha = '" & Format(_ChequeFecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " DepositoNumero = '" & _DepositoNumero & "'" & "," & _
                    " DepositoFecha = '" & Format(_DepositoFecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " TransferenciaNumero = '" & _TransferenciaNumero & "'" & "," & _
                    " Tarjeta_Id = " & _Tarjeta_Id & "," & _
                    " TarjetaNumero = '" & _TarjetaNumero & "'" & "," & _
                    " TarjetaAutorizacion = '" & _TarjetaAutorizacion & "'" & "," & _
                    " Moneda = '" & _Moneda & "'" & "," & _
                    " TipoCambio = " & _TipoCambio & "," & _
                    " Dolares = " & _Dolares & "," & _
                    " Fecha = '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " Batch_Id = " & _Batch_Id & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Mov_Id = " & _Mov_Id.ToString & _
                    " And   Pago_Id = " & _Pago_Id.ToString

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

            Query = "select * From CxcMovimientoPago" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Tipo_Id = " & _Tipo_Id.ToString & _
                    " And   Mov_Id = " & _Mov_Id.ToString & _
                    " And   Pago_Id = " & _Pago_Id.ToString

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

            Query = "select * From CxcMovimientoPago"

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

            Query = "select Pago_Id as Numero, Nombre From CxcMovimientoPago"

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

            Query = "select Pago_Id as Codigo, Nombre From CxcMovimientoPago" & _
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

            Query = "select IsNull(MAX(Pago_Id),0) + 1 as Pago_Id From CxcMovimientoPago" & _
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