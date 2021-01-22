Public Class TCajaCierreDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Detalle_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Long
    Private _Pago_Id As Integer
    Private _TipoPago_Id As Integer
    Private _Monto As Double
    Private _Banco_Id As Integer
    Private _ChequeNumero As String
    Private _Tarjeta_Id As Integer
    Private _TarjetaNumero As String
    Private _TarjetaAutorizacion As String
    Private _NombreTipoDocumento As String
    Private _NombreTipoPago As String
    Private _NombreBanco As String
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
    Public Property NombreTipoDocumento As String
        Get
            Return _NombreTipoDocumento
        End Get
        Set(value As String)
            _NombreTipoDocumento = value
        End Set
    End Property
    Public Property NombreTipoPago As String
        Get
            Return _NombreTipoPago
        End Get
        Set(value As String)
            _NombreTipoPago = value
        End Set
    End Property
    Public Property NombreBanco As String
        Get
            Return _NombreBanco
        End Get
        Set(value As String)
            _NombreBanco = value
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
        _Cierre_Id = 0
        _Detalle_Id = 0
        _TipoDoc_Id = 0
        _Documento_Id = 0
        _Pago_Id = 0
        _TipoPago_Id = 0
        _Monto = 0.0
        _Banco_Id = 0
        _ChequeNumero = ""
        _Tarjeta_Id = 0
        _TarjetaNumero = ""
        _TarjetaAutorizacion = ""
        _NombreTipoDocumento = ""
        _NombreTipoPago = ""
        _NombreBanco = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = " Insert into CajaCierreDetalle( Emp_Id , Suc_Id" & _
                   " , Caja_Id , Cierre_Id" & _
                   " , Detalle_Id , TipoDoc_Id" & _
                   " , Documento_Id , Pago_Id" & _
                   " , TipoPago_Id , Monto" & _
                   " , Banco_Id , ChequeNumero" & _
                   " , Tarjeta_Id , TarjetaNumero" & _
                   " , TarjetaAutorizacion )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() & _
                   "," & _Detalle_Id.ToString() & "," & _TipoDoc_Id.ToString() & _
                   "," & _Documento_Id.ToString() & "," & _Pago_Id.ToString() & _
                   "," & _TipoPago_Id.ToString() & "," & _Monto.ToString() & _
                   "," & _Banco_Id.ToString() & ",'" & _ChequeNumero & "'" & _
                   "," & _Tarjeta_Id.ToString() & ",'" & _TarjetaNumero & "'" & _
                   ",'" & _TarjetaAutorizacion & "'" & ")"

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

            query = "Delete CajaCierreDetalle" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Caja_Id=" & _Caja_Id.ToString() & _
               " And    Cierre_Id=" & _Cierre_Id.ToString() & _
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

            query = " Update dbo.CajaCierreDetalle " & _
                      " SET    TipoDoc_Id=" & _TipoDoc_Id.ToString() & "," & _
                      " Documento_Id=" & _Documento_Id & "," & _
                      " Pago_Id=" & _Pago_Id & "," & _
                      " TipoPago_Id=" & _TipoPago_Id & "," & _
                      " Monto=" & _Monto & "," & _
                      " Banco_Id=" & _Banco_Id & "," & _
                      " ChequeNumero='" & _ChequeNumero & "'" & "," & _
                      " Tarjeta_Id=" & _Tarjeta_Id & "," & _
                      " TarjetaNumero='" & _TarjetaNumero & "'" & "," & _
                      " TarjetaAutorizacion='" & _TarjetaAutorizacion & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Caja_Id=" & _Caja_Id.ToString() & _
                      " And    Cierre_Id=" & _Cierre_Id.ToString() & _
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

            Query = "select * From CajaCierreDetalle" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    Caja_Id=" & _Caja_Id.ToString() & _
           " And    Cierre_Id=" & _Cierre_Id.ToString() & _
           " And    Detalle_Id=" & _Detalle_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _Detalle_Id = Tabla.Rows(0).Item("Detalle_Id")
                _TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _Pago_Id = Tabla.Rows(0).Item("Pago_Id")
                _TipoPago_Id = Tabla.Rows(0).Item("TipoPago_Id")
                _Monto = Tabla.Rows(0).Item("Monto")
                _Banco_Id = Tabla.Rows(0).Item("Banco_Id")
                _ChequeNumero = Tabla.Rows(0).Item("ChequeNumero")
                _Tarjeta_Id = Tabla.Rows(0).Item("Tarjeta_Id")
                _TarjetaNumero = Tabla.Rows(0).Item("TarjetaNumero")
                _TarjetaAutorizacion = Tabla.Rows(0).Item("TarjetaAutorizacion")
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
    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select CajaCierreDetalle_Id as Numero, Nombre From CajaCierreDetalle"

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
