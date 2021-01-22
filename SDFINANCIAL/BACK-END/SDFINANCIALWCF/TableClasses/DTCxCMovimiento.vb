<DataContract()>
Public Class DTCxCMovimiento
#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Cliente_Id As Integer
    Private _Referencia As String
    Private _Fecha As DateTime
    Private _FechaRecibido As DateTime
    Private _FechaDocumento As Datetime
    Private _FechaVencimiento As Datetime
    Private _Moneda As Char
    Private _Monto As Double
    Private _Saldo As Double
    Private _TipoCambio As Double
    Private _Dolares As Double
    Private _Usuario_Id As String
    Private _AplicaMora As Integer
    Private _FechaCalculoMora As DateTime
    Private _Batch_Id As Long
    Private _Caja_Id As Integer
    Private _Cierre_Id As Integer
    Private _UltimaModificacion As DateTime
    Private _Suc_Id As Integer
    Private _ListaPagos As New List(Of DTCxCMovimientoPago)
    Private _ListaMovimientos As New List(Of DTCxCMovimientoLinea)
    Private _GeneraNotaCredito As Boolean
    Private _MontoNotaCredito As Double
    Private _MAC_Address As String
    Private _GeneraAsiento As Boolean
    Private _AsientoEncabezado As DTAuxAsientoEncabezado
#End Region
#Region "Definicion de propiedades"
    <DataMember()> _
        Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Mov_Id() As Long
        Get
            Return _Mov_Id
        End Get
        Set(ByVal Value As Long)
            _Mov_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Cliente_Id() As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal Value As Integer)
            _Cliente_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Referencia() As String
        Get
            Return _Referencia
        End Get
        Set(ByVal Value As String)
            _Referencia = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
        End Set
    End Property
    <DataMember()> _
    Public Property FechaRecibido() As DateTime
        Get
            Return _FechaRecibido
        End Get
        Set(ByVal Value As DateTime)
            _FechaRecibido = Value
        End Set
    End Property
    <DataMember()> _
    Public Property FechaDocumento() As Datetime
        Get
            Return _FechaDocumento
        End Get
        Set(ByVal Value As Datetime)
            _FechaDocumento = Value
        End Set
    End Property
    <DataMember()> _
    Public Property FechaVencimiento() As Datetime
        Get
            Return _FechaVencimiento
        End Get
        Set(ByVal Value As Datetime)
            _FechaVencimiento = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property
    <DataMember()> _
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal Value As Double)
            _TipoCambio = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Dolares() As Double
        Get
            Return _Dolares
        End Get
        Set(ByVal Value As Double)
            _Dolares = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property AplicaMora() As Integer
        Get
            Return _AplicaMora
        End Get
        Set(ByVal Value As Integer)
            _AplicaMora = Value
        End Set
    End Property
    <DataMember()> _
    Public Property FechaCalculoMora() As Datetime
        Get
            Return _FechaCalculoMora
        End Get
        Set(ByVal Value As Datetime)
            _FechaCalculoMora = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Batch_Id() As Long
        Get
            Return _Batch_Id
        End Get
        Set(ByVal Value As Long)
            _Batch_Id = Value
        End Set
    End Property
    <DataMember()> _
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
        End Set
    End Property
    <DataMember()>
    Public Property Cierre_Id() As Integer
        Get
            Return _Cierre_Id
        End Get
        Set(ByVal Value As Integer)
            _Cierre_Id = Value
        End Set
    End Property

    <DataMember()> _
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property

    <DataMember()>
    Public Property Suc_Id() As Integer
        Get
            Return _Suc_Id
        End Get
        Set(ByVal Value As Integer)
            _Suc_Id = Value
        End Set
    End Property

    <DataMember()> _
    Public Property ListaPagos As List(Of DTCxCMovimientoPago)
        Get
            Return _ListaPagos
        End Get
        Set(value As List(Of DTCxCMovimientoPago))
            _ListaPagos = value
        End Set
    End Property
    <DataMember()> _
    Public Property ListaMovimientos As List(Of DTCxCMovimientoLinea)
        Get
            Return _ListaMovimientos
        End Get
        Set(value As List(Of DTCxCMovimientoLinea))
            _ListaMovimientos = value
        End Set
    End Property
    <DataMember()> _
    Public Property GeneraNotaCredito As Boolean
        Get
            Return _GeneraNotaCredito
        End Get
        Set(value As Boolean)
            _GeneraNotaCredito = value
        End Set
    End Property
    <DataMember()> _
    Public Property MontoNotaCredito As Double
        Get
            Return _MontoNotaCredito
        End Get
        Set(value As Double)
            _MontoNotaCredito = value
        End Set
    End Property
    <DataMember()> _
    Public Property MAC_Address As String
        Get
            Return _MAC_Address
        End Get
        Set(value As String)
            _MAC_Address = value
        End Set
    End Property
    <DataMember()> _
    Public Property GeneraAsiento As Boolean
        Get
            Return _GeneraAsiento
        End Get
        Set(value As Boolean)
            _GeneraAsiento = value
        End Set
    End Property
    <DataMember()> _
    Public Property AsientoEncabezado As DTAuxAsientoEncabezado
        Get
            Return _AsientoEncabezado
        End Get
        Set(value As DTAuxAsientoEncabezado)
            _AsientoEncabezado = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Tipo_Id = 0
        _Mov_Id = 0
        _Cliente_Id = 0
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
        _AplicaMora = 0
        _FechaCalculoMora = CDate("1900/01/01")
        _Batch_Id = 0
        _Caja_Id = 0
        _Cierre_Id = 0
        _UltimaModificacion = CDate("1900/01/01")
        _ListaMovimientos.Clear()
        _ListaPagos.Clear()
        _GeneraNotaCredito = False
        _MontoNotaCredito = 0.0
        _MAC_Address = ""
        _GeneraAsiento = False
        _AsientoEncabezado = New DTAuxAsientoEncabezado
    End Sub
#End Region
End Class