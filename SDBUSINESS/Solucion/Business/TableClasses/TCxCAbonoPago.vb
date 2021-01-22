Public Class TCxCAbonoPago
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _Abono_Id As Integer
    Private _Pago_Id As Integer
    Private _TipoPago_Id As Integer
    Private _Monto As Double
    Private _Banco_Id As Integer
    Private _ChequeNumero As String
    Private _ChequeFecha As DateTime
    Private _Tarjeta_Id As Integer
    Private _TarjetaNumero As String
    Private _TarjetaAutorizacion As String
    Private _Fecha As DateTime
    Private _Dolares As Double
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
    Public Property Abono_Id() As Integer
        Get
            Return _Abono_Id
        End Get
        Set(ByVal Value As Integer)
            _Abono_Id = Value
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
    Public Property ChequeFecha() As DateTime
        Get
            Return _ChequeFecha
        End Get
        Set(ByVal Value As DateTime)
            _ChequeFecha = Value
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
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
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
        _Abono_Id = 0
        _Pago_Id = 0
        _TipoPago_Id = 0
        _Monto = 0.00
        _Banco_Id = 0
        _ChequeNumero = ""
        _ChequeFecha = CDate("1900/01/01")
        _Tarjeta_Id = 0
        _TarjetaNumero = ""
        _TarjetaAutorizacion = ""
        _Fecha = CDate("1900/01/01")
        _Data = New DataSet
        _Dolares = 0.00
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into CxCAbonoPago( Emp_Id , Suc_Id" &
                   " , Caja_Id , Cierre_Id" &
                   " , Abono_Id , Pago_Id" &
                   " , TipoPago_Id , Monto" &
                   " , Banco_Id , ChequeNumero" &
                   " , ChequeFecha , Tarjeta_Id" &
                   " , TarjetaNumero , TarjetaAutorizacion" &
                   " , Fecha )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _Cierre_Id.ToString() &
                   "," & _Abono_Id.ToString() & "," & _Pago_Id.ToString() &
                   "," & _TipoPago_Id.ToString() & "," & _Monto.ToString() &
                   "," & _Banco_Id.ToString() & ",'" & _ChequeNumero & "'" &
                   ",'" & Format(_ChequeFecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Tarjeta_Id.ToString() &
                   ",'" & _TarjetaNumero & "'" & ",'" & _TarjetaAutorizacion & "'" &
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & ")"

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

            Query = "Delete CxCAbonoPago" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Suc_Id=" & _Suc_Id.ToString() &
               " And    Caja_Id=" & _Caja_Id.ToString() &
               " And    Cierre_Id=" & _Cierre_Id.ToString() &
               " And    Abono_Id=" & _Abono_Id.ToString() &
               " And    Pago_Id=" & _Pago_Id.ToString()

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

            Query = " Update dbo.CxCAbonoPago " &
                      " SET    TipoPago_Id=" & _TipoPago_Id.ToString() & "," &
                      " Monto=" & _Monto & "," &
                      " Banco_Id=" & _Banco_Id & "," &
                      " ChequeNumero='" & _ChequeNumero & "'" & "," &
                      " ChequeFecha='" & Format(_ChequeFecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " Tarjeta_Id=" & _Tarjeta_Id & "," &
                      " TarjetaNumero='" & _TarjetaNumero & "'" & "," &
                      " TarjetaAutorizacion='" & _TarjetaAutorizacion & "'" & "," &
                      " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Suc_Id=" & _Suc_Id.ToString() &
                      " And    Caja_Id=" & _Caja_Id.ToString() &
                      " And    Cierre_Id=" & _Cierre_Id.ToString() &
                      " And    Abono_Id=" & _Abono_Id.ToString() &
                      " And    Pago_Id=" & _Pago_Id.ToString()

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

            Query = "select * From CxCAbonoPago" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Suc_Id=" & _Suc_Id.ToString() &
           " And    Caja_Id=" & _Caja_Id.ToString() &
           " And    Cierre_Id=" & _Cierre_Id.ToString() &
           " And    Abono_Id=" & _Abono_Id.ToString() &
           " And    Pago_Id=" & _Pago_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _Abono_Id = Tabla.Rows(0).Item("Abono_Id")
                _Pago_Id = Tabla.Rows(0).Item("Pago_Id")
                _TipoPago_Id = Tabla.Rows(0).Item("TipoPago_Id")
                _Monto = Tabla.Rows(0).Item("Monto")
                _Banco_Id = Tabla.Rows(0).Item("Banco_Id")
                _ChequeNumero = Tabla.Rows(0).Item("ChequeNumero")
                _ChequeFecha = Tabla.Rows(0).Item("ChequeFecha")
                _Tarjeta_Id = Tabla.Rows(0).Item("Tarjeta_Id")
                _TarjetaNumero = Tabla.Rows(0).Item("TarjetaNumero")
                _TarjetaAutorizacion = Tabla.Rows(0).Item("TarjetaAutorizacion")
                _Fecha = Tabla.Rows(0).Item("Fecha")
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

            Query = "select * From CxCAbonoPago"

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

            Query = "select CxCAbonoPago_Id as Numero, Nombre From CxCAbonoPago"

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
