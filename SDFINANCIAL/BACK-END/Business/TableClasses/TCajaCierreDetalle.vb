Public Class TCajaCierreDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Detalle_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Pago_Id As Integer
    Private _TipoPago_Id As Integer
    Private _Monto As Double
    Private _Banco_Id As Integer
    Private _ChequeNumero As String
    Private _Tarjeta_Id As Integer
    Private _TarjetaNumero As String
    Private _TarjetaAutorizacion As String
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
    Public Property Detalle_Id() As Integer
        Get
            Return _Detalle_Id
        End Get
        Set(ByVal Value As Integer)
            _Detalle_Id = Value
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
    Public Property ChequeNumero() As String
        Get
            Return _ChequeNumero
        End Get
        Set(ByVal Value As String)
            _ChequeNumero = Value
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
        _Caja_Id = 0
        _Cierre_Id = 0
        _Detalle_Id = 0
        _Tipo_Id = 0
        _Mov_Id = 0
        _Pago_Id = 0
        _TipoPago_Id = 0
        _Monto = 0.0
        _Banco_Id = 0
        _ChequeNumero = ""
        _Tarjeta_Id = 0
        _TarjetaNumero = ""
        _TarjetaAutorizacion = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CajaCierreDetalle( Emp_Id , Caja_Id" & _
                    " , Cierre_Id , Detalle_Id" & _
                    " , Tipo_Id , Mov_Id" & _
                    " , Pago_Id , TipoPago_Id" & _
                    " , Monto , Banco_Id" & _
                    " , ChequeNumero , Tarjeta_Id" & _
                    " , TarjetaNumero , TarjetaAutorizacion" & _
                    " )" & _
                    " Values ( " & _Emp_Id.ToString & "," & _Caja_Id.ToString & _
                    "," & _Cierre_Id.ToString & "," & _Detalle_Id.ToString & _
                    "," & _Tipo_Id.ToString & "," & _Mov_Id.ToString & _
                    "," & _Pago_Id.ToString & "," & _TipoPago_Id.ToString & _
                    "," & _Monto.ToString & "," & _Banco_Id.ToString & _
                    ",'" & _ChequeNumero & "'" & "," & _Tarjeta_Id.ToString & _
                    ",'" & _TarjetaNumero & "'" & ",'" & _TarjetaAutorizacion & "'" & _
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

            Query = "Delete CajaCierreDetalle" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Caja_Id = " & _Caja_Id.ToString & _
                    " And   Cierre_Id = " & _Cierre_Id.ToString & _
                    " And   Detalle_Id = " & _Detalle_Id.ToString

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

            Query = " Update CajaCierreDetalle " & _
                    " SET    Tipo_Id = " & _Tipo_Id.ToString & "," & _
                    " Mov_Id = " & _Mov_Id & "," & _
                    " Pago_Id = " & _Pago_Id & "," & _
                    " TipoPago_Id = " & _TipoPago_Id & "," & _
                    " Monto = " & _Monto & "," & _
                    " Banco_Id = " & _Banco_Id & "," & _
                    " ChequeNumero = '" & _ChequeNumero & "'" & "," & _
                    " Tarjeta_Id = " & _Tarjeta_Id & "," & _
                    " TarjetaNumero = '" & _TarjetaNumero & "'" & "," & _
                    " TarjetaAutorizacion = '" & _TarjetaAutorizacion & "'" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Caja_Id = " & _Caja_Id.ToString & _
                    " And   Cierre_Id = " & _Cierre_Id.ToString & _
                    " And   Detalle_Id = " & _Detalle_Id.ToString

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

            Query = "select * From CajaCierreDetalle" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Caja_Id = " & _Caja_Id.ToString & _
                    " And   Cierre_Id = " & _Cierre_Id.ToString & _
                    " And   Detalle_Id = " & _Detalle_Id.ToString

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

            Query = "select * From CajaCierreDetalle"

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

            Query = "select CajaCierreDetalle_Id as Numero, Nombre From CajaCierreDetalle"

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

            Query = "select CajaCierreDetalle_Id as Codigo, Nombre From CajaCierreDetalle" & _
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

            Query = "select IsNull(MAX(Detalle_Id),0) + 1 as Detalle_Id From CajaCierreDetalle" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Caja_Id = " & _Caja_Id.ToString & _
                    " And   Cierre_Id = " & _Cierre_Id.ToString

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