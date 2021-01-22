Public Class TEmpresaParametro
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    'Private _PorcIV As Double
    Private _FactorRedondeo As Integer
    Private _TopeRedondeo As Double
    Private _LeyendaFactura1 As String
    Private _LeyendaFactura2 As String
    Private _SaldoMinimoRecarga As Double
    Private _ImprimeRecarga As Integer
    Private _DiasCredito As Integer
    Private _PorcMora As Double
    Private _DiasGraciaMora As Integer
    Private _MinutosPrefactura As Integer
    Private _ProformaDiasVencimiento As Integer
    Private _ProformaGeneraArchivo As Integer
    Private _ProformaCarpeta As String
    Private _ProformaTipoImpresion As Integer
    Private _ProformaElimina As Integer
    Private _PrefacturaCompromete As Integer
    Private _PuntosActivo As Integer
    Private _PuntosPorCada As Double
    Private _PuntosAcumula As Integer
    Private _PorcInteresCredito As Double
    Private _GeneraCuotasCredito As Integer
    Private _DiasMayoreo As Integer
    Private _CuentaEfectivoxDepositar As String
    Private _CuentaTarjetaRenta As String
    Private _PorcTarjetaRenta As Double
    Private _CuentaGastoComisionTarjeta As String
    Private _CuentaDescuento As String
    Private _CuentaDescuentoCompras As String
    Private _CuentaIV As String
    Private _CuentaRedondeo As String
    Private _EmpresaExterna As String
    Private _InterfazCxC As Integer
    Private _InterfazCxP As Integer
    Private _MailUser As String
    Private _MailPassword As String
    Private _MailServer As String
    Private _MailFrom As String
    Private _FacturacionElectronica As Integer
    Private _Emisor_Id As Integer
    Private _FeToken As String
    Private _FeLeyenda As String
    Private _FeReceptor As Integer
    Private _FeReceptorIdentificacion As Integer
    Private _FeReceptorTelefono As Integer
    Private _FeReceptorUbicacion As Integer
    Private _FacturaGeneraArchivo As Boolean
    Private _FacturaCarpeta As String
    Private _FacturaImprime As Integer
    Private _BusquedaArticuloOnline As Boolean
    Private _BusquedaClienteOnline As Boolean
    Private _VerificaExistenciaFactura As Integer
    Private _FeTipoDocumentoCliente As String
    Private _ClienteVendedorAsociado As Integer
    Private _VerificaFacturaAnulada As Boolean
    Private _ApartadoPrimaPorcentaje As Double
    Private _ApartadoDiasVencimiento As Integer
    Private _TipoFacturaDefault As Integer
    Private _ArticuloSolicitaCantidadDefault As Integer
    Private _ProformaCopiaGuardado As Integer
    Private _PermiteFacturacionBajoCosto As Integer
    Private _ValidaCedulaDuplicada As Integer
    Private _FinancialDB As String
    Private _TipoCambioFac As String
    Private _CnnFacturar As String
    Private _ValidaCabys As Boolean
    Private _EscaneaEntradaMercaderia As Boolean
    Public Property ValidaClienteMorosoCxC As Integer
    Private _SDL As New SDFinancial.SDFinancial()
    Private _Resultado As New SDFinancial.TResultado

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
    Public Property ValidaCabys() As Boolean
        Get
            Return _ValidaCabys
        End Get
        Set(ByVal Value As Boolean)
            _ValidaCabys = Value
        End Set
    End Property
    'Public Property PorcIV() As Double
    '    Get
    '        Return _PorcIV
    '    End Get
    '    Set(ByVal Value As Double)
    '        _PorcIV = Value
    '    End Set
    'End Property
    Public Property FactorRedondeo() As Integer
        Get
            Return _FactorRedondeo
        End Get
        Set(ByVal Value As Integer)
            _FactorRedondeo = Value
        End Set
    End Property
    Public Property TopeRedondeo() As Double
        Get
            Return _TopeRedondeo
        End Get
        Set(ByVal Value As Double)
            _TopeRedondeo = Value
        End Set
    End Property
    Public Property LeyendaFactura1() As String
        Get
            Return _LeyendaFactura1
        End Get
        Set(ByVal Value As String)
            _LeyendaFactura1 = Value
        End Set
    End Property
    Public Property LeyendaFactura2() As String
        Get
            Return _LeyendaFactura2
        End Get
        Set(ByVal Value As String)
            _LeyendaFactura2 = Value
        End Set
    End Property
    Public Property SaldoMinimoRecarga As Double
        Get
            Return _SaldoMinimoRecarga
        End Get
        Set(value As Double)
            _SaldoMinimoRecarga = value
        End Set
    End Property
    Public Property ImprimeRecarga() As Integer
        Get
            Return _ImprimeRecarga
        End Get
        Set(ByVal Value As Integer)
            _ImprimeRecarga = Value
        End Set
    End Property
    Public Property DiasCredito As Integer
        Get
            Return _DiasCredito
        End Get
        Set(value As Integer)
            _DiasCredito = value
        End Set
    End Property
    Public Property PorcMora As Double
        Get
            Return _PorcMora
        End Get
        Set(ByVal value As Double)
            _PorcMora = value
        End Set
    End Property
    Public Property DiasGraciaMora As Integer
        Get
            Return _DiasGraciaMora
        End Get
        Set(ByVal value As Integer)
            _DiasGraciaMora = value
        End Set
    End Property
    Public Property MinutosPrefactura() As Integer
        Get
            Return _MinutosPrefactura
        End Get
        Set(ByVal Value As Integer)
            _MinutosPrefactura = Value
        End Set
    End Property
    Public Property ProformaDiasVencimiento As Integer
        Get
            Return _ProformaDiasVencimiento
        End Get
        Set(value As Integer)
            _ProformaDiasVencimiento = value
        End Set
    End Property
    Public Property ProformaGeneraArchivo() As Integer
        Get
            Return _ProformaGeneraArchivo
        End Get
        Set(ByVal Value As Integer)
            _ProformaGeneraArchivo = Value
        End Set
    End Property
    Public Property ProformaCarpeta() As String
        Get
            Return _ProformaCarpeta
        End Get
        Set(ByVal Value As String)
            _ProformaCarpeta = Value
        End Set
    End Property
    Public Property ProformaTipoImpresion() As Integer
        Get
            Return _ProformaTipoImpresion
        End Get
        Set(ByVal Value As Integer)
            _ProformaTipoImpresion = Value
        End Set
    End Property
    Public Property ProformaElimina() As Integer
        Get
            Return _ProformaElimina
        End Get
        Set(ByVal Value As Integer)
            _ProformaElimina = Value
        End Set
    End Property
    Public Property PrefacturaCompromete() As Integer
        Get
            Return _PrefacturaCompromete
        End Get
        Set(ByVal Value As Integer)
            _PrefacturaCompromete = Value
        End Set
    End Property

    Public Property PuntosActivo() As Integer
        Get
            Return _PuntosActivo
        End Get
        Set(ByVal Value As Integer)
            _PuntosActivo = Value
        End Set
    End Property
    Public Property PuntosPorCada() As Double
        Get
            Return _PuntosPorCada
        End Get
        Set(ByVal Value As Double)
            _PuntosPorCada = Value
        End Set
    End Property
    Public Property PuntosAcumula() As Integer
        Get
            Return _PuntosAcumula
        End Get
        Set(ByVal Value As Integer)
            _PuntosAcumula = Value
        End Set
    End Property
    Public Property PorcInteresCredito() As Double
        Get
            Return _PorcInteresCredito
        End Get
        Set(ByVal Value As Double)
            _PorcInteresCredito = Value
        End Set
    End Property
    Public Property GeneraCuotasCredito() As Integer
        Get
            Return _GeneraCuotasCredito
        End Get
        Set(ByVal Value As Integer)
            _GeneraCuotasCredito = Value
        End Set
    End Property
    Public Property DiasMayoreo() As Integer
        Get
            Return _DiasMayoreo
        End Get
        Set(ByVal Value As Integer)
            _DiasMayoreo = Value
        End Set
    End Property
    Public Property CuentaEfectivoxDepositar() As String
        Get
            Return _CuentaEfectivoxDepositar
        End Get
        Set(ByVal Value As String)
            _CuentaEfectivoxDepositar = Value
        End Set
    End Property
    Public Property CuentaTarjetaRenta() As String
        Get
            Return _CuentaTarjetaRenta
        End Get
        Set(ByVal Value As String)
            _CuentaTarjetaRenta = Value
        End Set
    End Property
    Public Property PorcTarjetaRenta() As Double
        Get
            Return _PorcTarjetaRenta
        End Get
        Set(ByVal Value As Double)
            _PorcTarjetaRenta = Value
        End Set
    End Property
    Public Property CuentaGastoComisionTarjeta() As String
        Get
            Return _CuentaGastoComisionTarjeta
        End Get
        Set(ByVal Value As String)
            _CuentaGastoComisionTarjeta = Value
        End Set
    End Property
    Public Property CuentaDescuento() As String
        Get
            Return _CuentaDescuento
        End Get
        Set(ByVal Value As String)
            _CuentaDescuento = Value
        End Set
    End Property
    Public Property CuentaDescuentoCompras() As String
        Get
            Return _CuentaDescuentoCompras
        End Get
        Set(ByVal Value As String)
            _CuentaDescuentoCompras = Value
        End Set
    End Property
    Public Property CuentaIV() As String
        Get
            Return _CuentaIV
        End Get
        Set(ByVal Value As String)
            _CuentaIV = Value
        End Set
    End Property
    Public Property CuentaRedondeo() As String
        Get
            Return _CuentaRedondeo
        End Get
        Set(ByVal Value As String)
            _CuentaRedondeo = Value
        End Set
    End Property
    Public Property EmpresaExterna() As String
        Get
            Return _EmpresaExterna
        End Get
        Set(ByVal Value As String)
            _EmpresaExterna = Value
        End Set
    End Property

    Public Property InterfazCxC() As Integer
        Get
            Return _InterfazCxC
        End Get
        Set(ByVal Value As Integer)
            _InterfazCxC = Value
        End Set
    End Property
    Public Property InterfazCxP() As Integer
        Get
            Return _InterfazCxP
        End Get
        Set(ByVal Value As Integer)
            _InterfazCxP = Value
        End Set
    End Property

    Public Property MailUser() As String
        Get
            Return _MailUser
        End Get
        Set(ByVal Value As String)
            _MailUser = Value
        End Set
    End Property
    Public Property MailPassword() As String
        Get
            Return _MailPassword
        End Get
        Set(ByVal Value As String)
            _MailPassword = Value
        End Set
    End Property
    Public Property MailServer() As String
        Get
            Return _MailServer
        End Get
        Set(ByVal Value As String)
            _MailServer = Value
        End Set
    End Property
    Public Property MailFrom() As String
        Get
            Return _MailFrom
        End Get
        Set(ByVal Value As String)
            _MailFrom = Value
        End Set
    End Property
    Public Property FacturacionElectronica() As Integer
        Get
            Return _FacturacionElectronica
        End Get
        Set(ByVal Value As Integer)
            _FacturacionElectronica = Value
        End Set
    End Property
    Public Property Emisor_Id As Integer
        Get
            Return _Emisor_Id
        End Get
        Set(value As Integer)
            _Emisor_Id = value
        End Set
    End Property
    Public Property FeToken() As String
        Get
            Return _FeToken
        End Get
        Set(ByVal Value As String)
            _FeToken = Value
        End Set
    End Property
    Public Property FeLeyenda As String
        Get
            Return _FeLeyenda
        End Get
        Set(value As String)
            _FeLeyenda = value
        End Set
    End Property
    Public Property FeReceptor() As Integer
        Get
            Return _FeReceptor
        End Get
        Set(ByVal Value As Integer)
            _FeReceptor = Value
        End Set
    End Property
    Public Property FeReceptorIdentificacion() As Integer
        Get
            Return _FeReceptorIdentificacion
        End Get
        Set(ByVal Value As Integer)
            _FeReceptorIdentificacion = Value
        End Set
    End Property
    Public Property FeReceptorTelefono() As Integer
        Get
            Return _FeReceptorTelefono
        End Get
        Set(ByVal Value As Integer)
            _FeReceptorTelefono = Value
        End Set
    End Property
    Public Property FeReceptorUbicacion() As Integer
        Get
            Return _FeReceptorUbicacion
        End Get
        Set(ByVal Value As Integer)
            _FeReceptorUbicacion = Value
        End Set
    End Property

    Public Property VerificaExistenciaFactura() As Integer
        Get
            Return _VerificaExistenciaFactura
        End Get
        Set(ByVal Value As Integer)
            _VerificaExistenciaFactura = Value
        End Set
    End Property
    Public Property FeTipoDocumentoCliente() As String
        Get
            Return _FeTipoDocumentoCliente
        End Get
        Set(ByVal Value As String)
            _FeTipoDocumentoCliente = Value
        End Set
    End Property
    Public Property ClienteVendedorAsociado() As Integer
        Get
            Return _ClienteVendedorAsociado
        End Get
        Set(ByVal Value As Integer)
            _ClienteVendedorAsociado = Value
        End Set
    End Property

    Public Property TipoFacturaDefault() As Integer
        Get
            Return _TipoFacturaDefault
        End Get
        Set(ByVal Value As Integer)
            _TipoFacturaDefault = Value
        End Set
    End Property

    Public ReadOnly Property Data() As DataSet
        Get
            Return _Data
        End Get
    End Property

    Public Property EscaneaEntradaMercaderia() As Boolean
        Get
            Return _EscaneaEntradaMercaderia
        End Get
        Set(ByVal value As Boolean)
            _EscaneaEntradaMercaderia = value
        End Set
    End Property

    Public ReadOnly Property RowsAffected() As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property
    Public Property FacturaGeneraArchivo() As Boolean
        Get
            Return _FacturaGeneraArchivo
        End Get
        Set(ByVal Value As Boolean)
            _FacturaGeneraArchivo = Value
        End Set
    End Property

    Public Property FacturaCarpeta() As String
        Get
            Return _FacturaCarpeta
        End Get
        Set(ByVal Value As String)
            _FacturaCarpeta = Value
        End Set
    End Property

    Public Property FacturaImprime() As Integer
        Get
            Return _FacturaImprime
        End Get
        Set(ByVal Value As Integer)
            _FacturaImprime = Value
        End Set
    End Property

    Public Property BusquedaArticuloOnline() As Boolean
        Get
            Return _BusquedaArticuloOnline
        End Get
        Set(ByVal Value As Boolean)
            _BusquedaArticuloOnline = Value
        End Set
    End Property
    Public Property BusquedaClienteOnline() As Boolean
        Get
            Return _BusquedaClienteOnline
        End Get
        Set(ByVal Value As Boolean)
            _BusquedaClienteOnline = Value
        End Set
    End Property

    Public Property DevolucionMarcaFacturaAnulada() As Boolean
        Get
            Return _VerificaFacturaAnulada
        End Get
        Set(ByVal Value As Boolean)
            _VerificaFacturaAnulada = Value
        End Set
    End Property

    Public Property ApartadoPrimaPorcentaje() As Double
        Get
            Return _ApartadoPrimaPorcentaje
        End Get
        Set(ByVal Value As Double)
            _ApartadoPrimaPorcentaje = Value
        End Set
    End Property
    Public Property ApartadoDiasVencimiento() As Integer
        Get
            Return _ApartadoDiasVencimiento
        End Get
        Set(ByVal Value As Integer)
            _ApartadoDiasVencimiento = Value
        End Set
    End Property

    Public Property TipoCambioFac() As String
        Get
            Return _TipoCambioFac
        End Get
        Set(ByVal Value As String)
            _TipoCambioFac = Value
        End Set
    End Property

    Public Property ArticuloSolicitaCantidadDefault() As Integer
        Get
            Return _ArticuloSolicitaCantidadDefault
        End Get
        Set(ByVal Value As Integer)
            _ArticuloSolicitaCantidadDefault = Value
        End Set
    End Property
    Public Property ProformaCopiaGuardado() As Integer
        Get
            Return _ProformaCopiaGuardado
        End Get
        Set(value As Integer)
            _ProformaCopiaGuardado = value
        End Set
    End Property
    Public Property PermiteFacturacionBajoCosto As Integer
        Get
            Return _PermiteFacturacionBajoCosto
        End Get
        Set(value As Integer)
            _PermiteFacturacionBajoCosto = value
        End Set
    End Property
    Public Property ValidaCedulaDuplicada As Integer
        Get
            Return _ValidaCedulaDuplicada
        End Get
        Set(value As Integer)
            _ValidaCedulaDuplicada = value
        End Set
    End Property

    Public Property FinancialDB As String
        Get
            Return _FinancialDB
        End Get
        Set(value As String)
            _FinancialDB = value
        End Set
    End Property
    Public Property CnnFacturar As String
        Get
            Return _CnnFacturar
        End Get
        Set(value As String)
            _CnnFacturar = value
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
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.URLContabilidad <> "" Then
            _SDL.Url = InfoMaquina.URLContabilidad
        End If
        _Emp_Id = 0
        '_PorcIV = 0.0
        _FactorRedondeo = 0
        _TopeRedondeo = 0.0
        _LeyendaFactura1 = ""
        _LeyendaFactura2 = ""
        _SaldoMinimoRecarga = 0
        _ImprimeRecarga = 0
        _DiasCredito = 0
        _PorcMora = 0.0
        _DiasGraciaMora = 0
        _MinutosPrefactura = 0
        _ProformaDiasVencimiento = 0
        _ProformaGeneraArchivo = 0
        _ProformaCarpeta = ""
        _ProformaTipoImpresion = 0
        _ProformaElimina = 0
        _PrefacturaCompromete = 0
        _PuntosActivo = 0
        _PuntosPorCada = 0.0
        _PuntosAcumula = 0
        _PorcInteresCredito = 0
        _GeneraCuotasCredito = 0
        _DiasMayoreo = 0
        _CuentaEfectivoxDepositar = ""
        _CuentaTarjetaRenta = ""
        _PorcTarjetaRenta = 0.0
        _CuentaGastoComisionTarjeta = ""
        _CuentaDescuento = ""
        _CuentaDescuentoCompras = ""
        _CuentaIV = ""
        _CuentaRedondeo = ""
        _EmpresaExterna = ""
        _InterfazCxC = 0
        _InterfazCxP = 0
        _MailUser = ""
        _MailPassword = ""
        _MailServer = ""
        _MailFrom = ""
        _FacturacionElectronica = 0
        _Emisor_Id = 0
        _FeToken = ""
        _FeLeyenda = ""
        _FeReceptor = 0
        _FeReceptorIdentificacion = 0
        _FeReceptorTelefono = 0
        _FeReceptorUbicacion = 0
        _FacturaGeneraArchivo = 0
        _FacturaCarpeta = ""
        _FacturaImprime = 0
        _BusquedaClienteOnline = 0
        _BusquedaArticuloOnline = 0
        _VerificaExistenciaFactura = 0
        _FeTipoDocumentoCliente = ""
        _ClienteVendedorAsociado = 0
        _ApartadoPrimaPorcentaje = 0
        _ApartadoDiasVencimiento = 0
        _TipoFacturaDefault = Enum_TipoDocumento.Contado
        ValidaClienteMorosoCxC = 0
        _ProformaCopiaGuardado = 0
        _PermiteFacturacionBajoCosto = 0
        _TipoCambioFac = ""
        _ValidaCedulaDuplicada = 0
        _FinancialDB = String.Empty
        _CnnFacturar = String.Empty
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into EmpresaParametro( Emp_Id " &
                    " , FactorRedondeo , TopeRedondeo" &
                    " , LeyendaFactura1 , LeyendaFactura2" &
                    " , SaldoMinimoRecarga , ImprimeRecarga" &
                    " , DiasCredito , PorcMora" &
                    " , DiasGraciaMora , MinutosPrefactura" &
                    " , ProformaDiasVencimiento , ProformaGeneraArchivo" &
                    " , ProformaCarpeta , ProformaTipoImpresion" &
                    " , ProformaElimina , PrefacturaCompromete" &
                    " , PuntosActivo , PuntosPorCada" &
                    " , PuntosAcumula , PorcInteresCredito" &
                    " , GeneraCuotasCredito , DiasMayoreo" &
                    " , CuentaEfectivoxDepositar" &
                    " , CuentaTarjetaRenta , PorcTarjetaRenta" &
                    " , CuentaGastoComisionTarjeta , CuentaDescuento" &
                    " , CuentaDescuentoCompras , CuentaIV" &
                    " , CuentaRedondeo , EmpresaExterna" &
                    " , InterfazCxC , InterfazCxP" &
                    " , FacturaGeneraArchivo , FacturaCarpeta" &
                    " , FacturaImprime)" &
                    " Values ( " & _Emp_Id.ToString() &
                    "," & _FactorRedondeo.ToString() & "," & _TopeRedondeo.ToString() &
                    ",'" & _LeyendaFactura1 & "'" & ",'" & _LeyendaFactura2 & "'" &
                    "," & _SaldoMinimoRecarga.ToString() & "," & _ImprimeRecarga.ToString() &
                    "," & _DiasCredito.ToString() & "," & _PorcMora.ToString() &
                    "," & _DiasGraciaMora.ToString() & "," & _MinutosPrefactura.ToString() &
                    "," & _ProformaDiasVencimiento.ToString() & "," & _ProformaGeneraArchivo.ToString() &
                    ",'" & _ProformaCarpeta & "'" & "," & _ProformaTipoImpresion.ToString() &
                    "," & _ProformaElimina.ToString() & "," & _PrefacturaCompromete.ToString() &
                    "," & _PuntosActivo.ToString() & "," & _PuntosPorCada.ToString() &
                    "," & _PuntosAcumula.ToString() & "," & _PorcInteresCredito.ToString() &
                    "," & _GeneraCuotasCredito.ToString() & "," & _DiasMayoreo.ToString() &
                    ",'" & _CuentaEfectivoxDepositar & "'" &
                    ",'" & _CuentaTarjetaRenta & "'" & "," & _PorcTarjetaRenta.ToString() &
                    ",'" & _CuentaGastoComisionTarjeta & "'" & ",'" & _CuentaDescuento & "'" &
                    ",'" & _CuentaDescuentoCompras & "'" & ",'" & _CuentaIV & "'" &
                    ",'" & _CuentaRedondeo & "'" & ",'" & _EmpresaExterna & "'" &
                    "," & _InterfazCxC & "," & _InterfazCxP &
                    ",'" & _FacturaGeneraArchivo & "','" & _FacturaCarpeta & "'" &
                    "," & _FacturaImprime & ")"

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

            Query = "Delete EmpresaParametro" &
                    " Where     Emp_Id=" & _Emp_Id.ToString()

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

            Query = " Update dbo.EmpresaParametro " &
                    " SET  FactorRedondeo=" & _FactorRedondeo & "," &
                    " TopeRedondeo=" & _TopeRedondeo & "," &
                    " LeyendaFactura1='" & _LeyendaFactura1 & "'" & "," &
                    " LeyendaFactura2='" & _LeyendaFactura2 & "'" & "," &
                    " SaldoMinimoRecarga=" & _SaldoMinimoRecarga & "," &
                    " ImprimeRecarga=" & _ImprimeRecarga & "," &
                    " DiasCredito=" & _DiasCredito & "," &
                    " PorcMora=" & _PorcMora & "," &
                    " DiasGraciaMora=" & _DiasGraciaMora & "," &
                    " MinutosPrefactura=" & _MinutosPrefactura & "," &
                    " ProformaDiasVencimiento=" & _ProformaDiasVencimiento & "," &
                    " ProformaGeneraArchivo=" & _ProformaGeneraArchivo & "," &
                    " ProformaCarpeta='" & _ProformaCarpeta & "'" & "," &
                    " ProformaTipoImpresion=" & _ProformaTipoImpresion & "," &
                    " ProformaElimina=" & _ProformaElimina & "," &
                    " PrefacturaCompromete=" & _PrefacturaCompromete & "," &
                    " PuntosActivo=" & _PuntosActivo & "," &
                    " PuntosPorCada=" & _PuntosPorCada & "," &
                    " PuntosAcumula=" & _PuntosAcumula & "," &
                    " PorcInteresCredito=" & _PorcInteresCredito & "," &
                    " GeneraCuotasCredito=" & _GeneraCuotasCredito & "," &
                    " DiasMayoreo=" & _DiasMayoreo & "," &
                    " CuentaEfectivoxDepositar='" & _CuentaEfectivoxDepositar & "'" & "," &
                    " CuentaTarjetaRenta='" & _CuentaTarjetaRenta & "'" & "," &
                    " PorcTarjetaRenta=" & _PorcTarjetaRenta & "," &
                    " CuentaGastoComisionTarjeta='" & _CuentaGastoComisionTarjeta & "'" & "," &
                    " CuentaDescuento='" & _CuentaDescuento & "'" & "," &
                    " CuentaDescuentoCompras='" & _CuentaDescuentoCompras & "'" & "," &
                    " CuentaIV='" & _CuentaIV & "'" & "," &
                    " CuentaRedondeo='" & _CuentaRedondeo & "'" & "," &
                    " InterfazCxC=" & _InterfazCxC & "," &
                    " InterfazCxP=" & _InterfazCxP & "," &
                    " EmpresaExterna='" & _EmpresaExterna & "'," &
                    " FacturaGeneraArchivo = '" & _FacturaGeneraArchivo & "'," &
                    " FacturaCarpeta = '" & _FacturaCarpeta & "'," &
                    " FacturaImprime = " & _FacturaImprime &
                    " Where     Emp_Id=" & _Emp_Id.ToString()

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

            Query = "select * From EmpresaParametro" &
                    " Where     Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                '_PorcIV = Tabla.Rows(0).Item("PorcIV")
                _FactorRedondeo = Tabla.Rows(0).Item("FactorRedondeo")
                _TopeRedondeo = Tabla.Rows(0).Item("TopeRedondeo")
                _LeyendaFactura1 = Tabla.Rows(0).Item("LeyendaFactura1")
                _LeyendaFactura2 = Tabla.Rows(0).Item("LeyendaFactura2")
                _SaldoMinimoRecarga = Tabla.Rows(0).Item("SaldoMinimoRecarga")
                _ImprimeRecarga = Tabla.Rows(0).Item("ImprimeRecarga")
                _DiasCredito = Tabla.Rows(0).Item("DiasCredito")
                _PorcMora = Tabla.Rows(0).Item("PorcMora")
                _DiasGraciaMora = Tabla.Rows(0).Item("DiasGraciaMora")
                _MinutosPrefactura = Tabla.Rows(0).Item("MinutosPrefactura")
                _ProformaDiasVencimiento = Tabla.Rows(0).Item("ProformaDiasVencimiento")
                _ProformaGeneraArchivo = Tabla.Rows(0).Item("ProformaGeneraArchivo")
                _ProformaCarpeta = Tabla.Rows(0).Item("ProformaCarpeta")
                _ProformaTipoImpresion = Tabla.Rows(0).Item("ProformaTipoImpresion")
                _ProformaElimina = Tabla.Rows(0).Item("ProformaElimina")
                _PrefacturaCompromete = Tabla.Rows(0).Item("PrefacturaCompromete")
                _PuntosActivo = Tabla.Rows(0).Item("PuntosActivo")
                _PuntosPorCada = Tabla.Rows(0).Item("PuntosPorCada")
                _PuntosAcumula = Tabla.Rows(0).Item("PuntosAcumula")
                _PorcInteresCredito = Tabla.Rows(0).Item("PorcInteresCredito")
                _GeneraCuotasCredito = Tabla.Rows(0).Item("GeneraCuotasCredito")
                _DiasMayoreo = Tabla.Rows(0).Item("DiasMayoreo")
                _CuentaEfectivoxDepositar = Tabla.Rows(0).Item("CuentaEfectivoxDepositar")
                _CuentaTarjetaRenta = Tabla.Rows(0).Item("CuentaTarjetaRenta")
                _PorcTarjetaRenta = Tabla.Rows(0).Item("PorcTarjetaRenta")
                _CuentaGastoComisionTarjeta = Tabla.Rows(0).Item("CuentaGastoComisionTarjeta")
                _CuentaDescuento = Tabla.Rows(0).Item("CuentaDescuento")
                _CuentaDescuentoCompras = Tabla.Rows(0).Item("CuentaDescuentoCompras")
                _CuentaIV = Tabla.Rows(0).Item("CuentaIV")
                _CuentaRedondeo = Tabla.Rows(0).Item("CuentaRedondeo")
                _EmpresaExterna = Tabla.Rows(0).Item("EmpresaExterna")
                _InterfazCxC = Tabla.Rows(0).Item("InterfazCxC")
                _InterfazCxP = Tabla.Rows(0).Item("InterfazCxP")
                _MailUser = Tabla.Rows(0).Item("MailUser")
                _MailPassword = Tabla.Rows(0).Item("MailPassword")
                _MailServer = Tabla.Rows(0).Item("MailServer")
                _MailFrom = Tabla.Rows(0).Item("MailFrom")
                _FacturacionElectronica = Tabla.Rows(0).Item("FacturacionElectronica")
                _Emisor_Id = Tabla.Rows(0).Item("Emisor_Id")
                _FeToken = Tabla.Rows(0).Item("FeToken")
                _FeLeyenda = Tabla.Rows(0).Item("FeLeyenda")
                _FeReceptor = Tabla.Rows(0).Item("FeReceptor")
                _FeReceptorIdentificacion = Tabla.Rows(0).Item("FeReceptorIdentificacion")
                _FeReceptorTelefono = Tabla.Rows(0).Item("FeReceptorTelefono")
                _FeReceptorUbicacion = Tabla.Rows(0).Item("FeReceptorUbicacion")
                _FacturaGeneraArchivo = Tabla.Rows(0).Item("FacturaGeneraArchivo")
                _FacturaCarpeta = Tabla.Rows(0).Item("FacturaCarpeta")
                _FacturaImprime = Tabla.Rows(0).Item("FacturaImprime")
                _BusquedaArticuloOnline = Tabla.Rows(0).Item("BusquedaArticuloOnline")
                _BusquedaClienteOnline = Tabla.Rows(0).Item("BusquedaClienteOnline")
                _VerificaExistenciaFactura = Tabla.Rows(0).Item("VerificaExistenciaFactura")
                _FeTipoDocumentoCliente = Tabla.Rows(0).Item("FeTipoDocumentoCliente")
                _ClienteVendedorAsociado = Tabla.Rows(0).Item("ClienteVendedorAsociado")
                _VerificaFacturaAnulada = Tabla.Rows(0).Item("VerificaFacturaAnulada")
                _ApartadoPrimaPorcentaje = Tabla.Rows(0).Item("ApartadoPrimaPorcentaje")
                _ApartadoDiasVencimiento = Tabla.Rows(0).Item("ApartadoDiasVencimiento")
                _TipoFacturaDefault = Tabla.Rows(0).Item("TipoFacturaDefault")
                ValidaClienteMorosoCxC = Tabla.Rows(0).Item("ValidaClienteMorosoCxC")
                _ArticuloSolicitaCantidadDefault = Tabla.Rows(0).Item("ArticuloSolicitaCantidadDefecto")
                _ProformaCopiaGuardado = Tabla.Rows(0).Item("ProformaCopiaGuardado")
                _PermiteFacturacionBajoCosto = Tabla.Rows(0).Item("PermiteFacturacionBajoCosto")
                _TipoCambioFac = Tabla.Rows(0).Item("TipoCambioFacturacion")
                _ValidaCedulaDuplicada = Tabla.Rows(0).Item("ValidaCedulaDuplicada")
                _CnnFacturar = UnLockPassword(Tabla.Rows(0).Item("CnnFacturar"))
                _ValidaCabys = Tabla.Rows(0).Item("ValidaCabys")

                Try
                    _EscaneaEntradaMercaderia = Tabla.Rows(0).Item("EscaneaEntradaMercaderia")
                Catch ex As Exception
                    _EscaneaEntradaMercaderia = False
                End Try

                If Not InfoMaquina Is Nothing AndAlso InfoMaquina.URLContabilidad <> "" Then
                    _SDL.Url = InfoMaquina.URLContabilidad
                End If
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

            Query = "select * From EmpresaParametro"

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

            Query = "select EmpresaParametro_Id as Numero, Nombre From EmpresaParametro"

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
    Public Function GetFinancialDB() As String
        Dim Query As String

        Query = "select DB_NAME() as DB"

        _Resultado = _SDL.SelectQuery(Query, String.Empty)

        MsgError = _Resultado.ErrorDescription
        VerificaMsgError()

        Return _Resultado.Datos.Rows(0).Item(0).ToString()

    End Function

#End Region
End Class