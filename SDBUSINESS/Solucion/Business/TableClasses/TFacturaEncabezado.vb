Imports System.Windows.Forms

Public Class TFacturaEncabezado
    Inherits TBaseClassManager
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Caja_Id As Integer
    Private _TipoDoc_Id As Integer
    Private _Documento_Id As Long
    Private _Bod_Id As Integer
    Private _Fecha As DateTime
    Private _Cliente_Id As Integer
    Private _Nombre As String
    Private _Vendedor_Id As Integer
    Private _Usuario_Id As String
    Private _Comentario As String
    Private _Costo As Double
    Private _Subtotal As Double
    Private _Descuento As Double
    Private _IV As Double
    Private _IVDevuelto As Double
    Private _Total As Double
    Private _Redondeo As Double
    Private _TotalCobrado As Double
    Private _Cierre_Id As Integer
    Private _CPU As String
    Private _HostName As String
    Private _IPAddress As String
    Private _TipoDocumentoNombre As String
    Private _UsuarioNombre As String
    Private _Vuelto As Double
    Private _TotalEfectivo As Double
    Private _Exento As Double
    Private _Gravado As Double
    Private _Dolares As Integer
    Private _TipoCambio As Double
    Private _Puntos As Integer
    Private _FacturaPagos As New List(Of TFacturaPago)
    Private _FacturaDetalles As New List(Of TFacturaDetalle)
    Private _FacturaExoneracion As TFacturaExoneracion
    Private _Reimpresion As Boolean
    Private _ImpresionPrefactura As Boolean
    Private _CxCCuotas As Int16
    Private _CxCPorcInteres As Double
    Private _CXCFechaPago As Date
    Private _CXCReferencia As String
    Private _RecargoCredito As Double
    Private _CxCCuotaMensual As Double
    Private _MontoPrima As Double
    Private _Cliente As TCliente
    Private _Vendedor As TVendedor
    Private _FacturaCxCLlave As TFacturaCxCLlave
    Private _Proforma As TProformaEncabezado
    Private _DireccionEntrega As String
    Private _DetallesGuardados As Integer
    Private _Articulos As String
    Private _ErroresPasaCxC As New List(Of String)
    Private _FacturaDev As TFacturaEncabezado
    Private _ReferenciaNC As TReferenciaNC
    Private _Exoneracion As Integer
    Private _Data As DataSet
    Private _SDL As New SDFinancial.SDFinancial
    Private _DTMovimiento As New SDFinancial.DTCxCMovimiento
    Private _FacturaElectronica As TFacturaElectronica
    Private _Resultado As New SDFinancial.TResultado
    Private _TipoDevolucion As Enum_TipoDevolucion
    Public Tabla As DataTable
    Private _CxCDevolucionFacturas As New List(Of SDFinancial.DTCxCMovimientoLinea)
    Private _MontoNotaAdicional As Double = 0
    Private _MontoDevolucionFacturas As Double = 0
    Private _FacturandoApartado As Boolean
    Private _VendedorNombre As String
    Private _EsPrefactura As Boolean
    Private _OtroValores As New List(Of TOtroValor)
    'Cambios Mike: 03/11/2020
    Public _IVA1 As Double = 0
    Public _IVA13 As Double = 0
    Private _TotalDevuelveIVImp As Double = 0
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
    Public Property Bod_Id() As Integer
        Get
            Return _Bod_Id
        End Get
        Set(ByVal Value As Integer)
            _Bod_Id = Value
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
    Public Property Cliente_Id() As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal Value As Integer)
            _Cliente_Id = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal Value As Integer)
            _Vendedor_Id = Value
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
    Public Property Comentario As String
        Get
            Return _Comentario
        End Get
        Set(value As String)
            _Comentario = value
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
    Public Property Subtotal() As Double
        Get
            Return _Subtotal
        End Get
        Set(ByVal Value As Double)
            _Subtotal = Value
        End Set
    End Property
    Public Property Descuento() As Double
        Get
            Return _Descuento
        End Get
        Set(ByVal Value As Double)
            _Descuento = Value
        End Set
    End Property
    Public Property IV() As Double
        Get
            Return _IV
        End Get
        Set(ByVal Value As Double)
            _IV = Value
        End Set
    End Property
    'MIKE 16/12/2020
    Public Property IVDevuelto() As Double
        Get
            Return _IVDevuelto
        End Get
        Set(ByVal Value As Double)
            _IVDevuelto = Value
        End Set
    End Property
    Public Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal Value As Double)
            _Total = Value
        End Set
    End Property
    Public Property Redondeo() As Double
        Get
            Return _Redondeo
        End Get
        Set(ByVal Value As Double)
            _Redondeo = Value
        End Set
    End Property
    Public Property TotalCobrado() As Double
        Get
            Return _TotalCobrado
        End Get
        Set(ByVal Value As Double)
            _TotalCobrado = Value
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
    Public Property CPU() As String
        Get
            Return _CPU
        End Get
        Set(ByVal Value As String)
            _CPU = Value
        End Set
    End Property
    Public Property HostName() As String
        Get
            Return _HostName
        End Get
        Set(ByVal Value As String)
            _HostName = Value
        End Set
    End Property
    Public Property IPAddress() As String
        Get
            Return _IPAddress
        End Get
        Set(ByVal Value As String)
            _IPAddress = Value
        End Set
    End Property
    Public Property TipoDocumentoNombre As String
        Get
            Return _TipoDocumentoNombre
        End Get
        Set(value As String)
            _TipoDocumentoNombre = value
        End Set
    End Property
    Public Property UsuarioNombre As String
        Get
            Return _UsuarioNombre
        End Get
        Set(value As String)
            _UsuarioNombre = value
        End Set
    End Property
    Public Property Vuelto As Double
        Get
            Return _Vuelto
        End Get
        Set(value As Double)
            _Vuelto = value
        End Set
    End Property
    Public Property TotalEfectivo As Double
        Get
            Return _TotalEfectivo
        End Get
        Set(value As Double)
            _TotalEfectivo = value
        End Set
    End Property
    Public Property Exento As Double
        Get
            Return _Exento
        End Get
        Set(value As Double)
            _Exento = value
        End Set
    End Property
    Public Property Gravado As Double
        Get
            Return _Gravado
        End Get
        Set(value As Double)
            _Gravado = value
        End Set
    End Property
    Public Property Dolares As Integer
        Get
            Return _Dolares
        End Get
        Set(value As Integer)
            _Dolares = value
        End Set
    End Property
    Public Property TipoCambio As Double
        Get
            Return _TipoCambio
        End Get
        Set(value As Double)
            _TipoCambio = value
        End Set
    End Property
    Public Property MontoPrima() As Double
        Get
            Return _MontoPrima
        End Get
        Set(ByVal Value As Double)
            _MontoPrima = Value
        End Set
    End Property
    Public Property FacturaPagos As List(Of TFacturaPago)
        Get
            Return _FacturaPagos
        End Get
        Set(value As List(Of TFacturaPago))
            _FacturaPagos = value
        End Set
    End Property
    Public Property FacturaDetalles As List(Of TFacturaDetalle)
        Get
            Return _FacturaDetalles
        End Get
        Set(value As List(Of TFacturaDetalle))
            _FacturaDetalles = value
        End Set
    End Property
    Public Property FacturaExoneracion As TFacturaExoneracion
        Get
            Return _FacturaExoneracion
        End Get
        Set(value As TFacturaExoneracion)
            _FacturaExoneracion = value
        End Set
    End Property
    Public Property Reimpresion As Boolean
        Get
            Return _Reimpresion
        End Get
        Set(ByVal value As Boolean)
            _Reimpresion = value
        End Set
    End Property

    Public Property ImpresionPrefactura As Boolean
        Get
            Return _ImpresionPrefactura
        End Get
        Set(value As Boolean)
            _ImpresionPrefactura = value
        End Set
    End Property

    Public Property Cliente As TCliente
        Get
            Return _Cliente
        End Get
        Set(value As TCliente)
            _Cliente = value
        End Set
    End Property
    Public Property Vendedor As TVendedor
        Get
            Return _Vendedor
        End Get
        Set(value As TVendedor)
            _Vendedor = value
        End Set
    End Property
    Public Property Puntos As Integer
        Get
            Return _Puntos
        End Get
        Set(value As Integer)
            _Puntos = value
        End Set
    End Property

    Public WriteOnly Property TipoDevolucion As Enum_TipoDevolucion
        Set(value As Enum_TipoDevolucion)
            _TipoDevolucion = value
        End Set
    End Property


    Public Property CxCCuotas As Int16
        Get
            Return _CxCCuotas
        End Get
        Set(value As Int16)
            _CxCCuotas = value
        End Set
    End Property
    Public Property CxCPorcInteres As Double
        Get
            Return _CxCPorcInteres
        End Get
        Set(value As Double)
            _CxCPorcInteres = value
        End Set
    End Property
    Public Property CXCFechaPago As Date
        Get
            Return _CXCFechaPago
        End Get
        Set(value As Date)
            _CXCFechaPago = value
        End Set
    End Property
    Public Property CXCReferencia As String
        Get
            Return _CXCReferencia
        End Get
        Set(value As String)
            _CXCReferencia = value
        End Set
    End Property
    Public Property RecargoCredito As Double
        Get
            Return _RecargoCredito
        End Get
        Set(value As Double)
            _RecargoCredito = value
        End Set
    End Property
    Public Property CxCCuotaMensual As Double
        Get
            Return _CxCCuotaMensual
        End Get
        Set(value As Double)
            _CxCCuotaMensual = value
        End Set
    End Property
    Public Property DireccionEntrega() As String
        Get
            Return _DireccionEntrega
        End Get
        Set(ByVal Value As String)
            _DireccionEntrega = Value
        End Set
    End Property
    Public Property FacturaCxCLlave As TFacturaCxCLlave
        Get
            Return _FacturaCxCLlave
        End Get
        Set(value As TFacturaCxCLlave)
            _FacturaCxCLlave = value
        End Set
    End Property
    Public Property Proforma As TProformaEncabezado
        Get
            Return _Proforma
        End Get
        Set(value As TProformaEncabezado)
            _Proforma = value
        End Set
    End Property
    Public Property FacturaDev As TFacturaEncabezado
        Get
            Return _FacturaDev
        End Get
        Set(value As TFacturaEncabezado)
            _FacturaDev = value
        End Set
    End Property
    Public Property ReferenciaNC As TReferenciaNC
        Get
            Return _ReferenciaNC
        End Get
        Set(value As TReferenciaNC)
            _ReferenciaNC = value
        End Set
    End Property
    Public Property ErroresPasaCxC As List(Of String)
        Get
            Return _ErroresPasaCxC
        End Get
        Set(value As List(Of String))
            _ErroresPasaCxC = value
        End Set
    End Property
    Public Property FacturaElectronica As TFacturaElectronica
        Get
            Return _FacturaElectronica
        End Get
        Set(value As TFacturaElectronica)
            _FacturaElectronica = value
        End Set
    End Property

    Public ReadOnly Property MontoEnLetras() As String
        Get
            Return Letras(Format(IIf(_Dolares = 0, _TotalCobrado, _TotalCobrado / IIf(_TipoCambio = 0, 1, _TipoCambio)), "###0.00"), IIf(_Dolares = 0, "colones", "dólares"))
        End Get
    End Property

    Public ReadOnly Property DetallesGuardados As Integer
        Get
            Return _DetallesGuardados
        End Get
    End Property

    Public Property Articulos() As String
        Get
            Return _Articulos
        End Get
        Set(ByVal value As String)
            _Articulos = value
        End Set
    End Property


    Public Property CxCDevolucionFacturas As List(Of SDFinancial.DTCxCMovimientoLinea)
        Get
            Return _CxCDevolucionFacturas
        End Get
        Set(value As List(Of SDFinancial.DTCxCMovimientoLinea))
            _CxCDevolucionFacturas = value
        End Set
    End Property

    Public Property MontoNotaAdicional As Double
        Get
            Return _MontoNotaAdicional
        End Get
        Set(value As Double)
            _MontoNotaAdicional = value
        End Set
    End Property

    Public Property MontoDevolucionFacturas As Double
        Get
            Return _MontoDevolucionFacturas
        End Get
        Set(value As Double)
            _MontoDevolucionFacturas = value
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

    Public Property FacturandoApartado() As Boolean
        Get
            Return _FacturandoApartado
        End Get
        Set(ByVal value As Boolean)
            _FacturandoApartado = value
        End Set
    End Property

    Public Property Exoneracion As Integer
        Get
            Return _Exoneracion
        End Get
        Set(value As Integer)
            _Exoneracion = value
        End Set
    End Property
    Public Property VendedorNombre As String
        Get
            Return _VendedorNombre
        End Get
        Set(value As String)
            _VendedorNombre = value
        End Set
    End Property
    Public Property OtroValores As List(Of TOtroValor)
        Get
            Return _OtroValores
        End Get
        Set(value As List(Of TOtroValor))
            _OtroValores = value
        End Set
    End Property
    Public Property EsPrefactura As Boolean
        Get
            Return _EsPrefactura
        End Get
        Set(value As Boolean)
            _EsPrefactura = value
        End Set
    End Property
    'Cambios Mike: 03/11/2020
    Public Property IVA1 As Double
        Get
            Return _IVA1
        End Get
        Set(ByVal value As Double)
            _IVA1 = value
        End Set
    End Property
    'Cambios Mike: 03/11/2020
    Public Property IVA13 As Double
        Get
            Return _IVA13
        End Get
        Set(ByVal value As Double)
            _IVA13 = value
        End Set
    End Property
    'Mike 16/12/2020
    Public Property TotalDevuelveIVImp As Double
        Get
            Return _TotalDevuelveIVImp
        End Get
        Set(ByVal value As Double)
            _TotalDevuelveIVImp = value
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
        _Suc_Id = 0
        _Caja_Id = 0
        _TipoDoc_Id = 0
        _Documento_Id = 0
        _Bod_Id = 0
        _Fecha = CDate("1900/01/01")
        _Cliente_Id = 0
        _Nombre = ""
        _Vendedor_Id = 0
        _Usuario_Id = ""
        _Comentario = ""
        _Costo = 0.0
        _Subtotal = 0.0
        _Descuento = 0.0
        _IV = 0.0
        _IVDevuelto = 0.0 'revisar
        _Total = 0.0
        _Redondeo = 0.0
        _TotalCobrado = 0.0
        _Cierre_Id = 0
        _CPU = ""
        _HostName = ""
        _IPAddress = ""
        _TipoDocumentoNombre = ""
        _Vuelto = 0.0
        _TotalEfectivo = 0.0
        _Exento = 0.0
        _Gravado = 0.0
        _Dolares = 0
        _TipoCambio = 1
        _Puntos = 0
        _ImpresionPrefactura = False
        _CxCCuotas = 0
        _CxCPorcInteres = 0
        _CXCFechaPago = #1/1/1900#
        _CXCReferencia = String.Empty
        _RecargoCredito = 0
        _CxCCuotaMensual = 0
        _MontoPrima = 0
        _DireccionEntrega = ""
        _FacturaPagos.Clear()
        _FacturaDetalles.Clear()
        _FacturaExoneracion = New TFacturaExoneracion(_Emp_Id)
        _Reimpresion = False
        _FacturaCxCLlave = Nothing
        _DetallesGuardados = 0
        _Articulos = ""
        _Vendedor = New TVendedor(_Emp_Id)
        _Proforma = Nothing
        _FacturaDev = Nothing
        _ReferenciaNC = Nothing
        _FacturaElectronica = New TFacturaElectronica(_Emp_Id)
        _CxCDevolucionFacturas.Clear()
        _MontoNotaAdicional = 0
        _MontoDevolucionFacturas = 0
        _TipoDevolucion = Enum_TipoDevolucion.Original
        _FacturandoApartado = False
        _Exoneracion = 0
        _VendedorNombre = String.Empty
        _EsPrefactura = False
        _OtroValores.Clear()
        _Data = New DataSet
        _IVA1 = 0.0
        _IVA13 = 0.0
        _TotalDevuelveIVImp = 0.0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into FacturaEncabezado( Emp_Id , Suc_Id" &
                   " , Caja_Id , TipoDoc_Id" &
                   " , Documento_Id , Bod_Id" &
                   " , Fecha , Cliente_Id" &
                   " , Nombre , Vendedor_Id" &
                   " , Usuario_Id , Comentario, Costo" &
                   " , Subtotal , Descuento" &
                   " , IV , IVDevuelto, Total" &'revisar
                   " , Redondeo , TotalCobrado" &
                   " , Cierre_Id , CPU" &
                   " , HostName , IPAddress" &
                   " , Exento , Gravado, Dolares, TipoCambio" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() &
                   "," & _Documento_Id.ToString() & "," & _Bod_Id.ToString() &
                   ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Cliente_Id.ToString() &
                   ",'" & _Nombre & "'" & "," & _Vendedor_Id.ToString() &
                   ",'" & _Usuario_Id & "','" & _Comentario & "'," & _Costo.ToString() &
                   "," & _Subtotal.ToString() & "," & _Descuento.ToString() &
                   "," & _IV.ToString() & "," & _IVDevuelto.ToString & "," & _Total.ToString() &
                   "," & _Redondeo.ToString() & "," & _TotalCobrado.ToString() &
                   "," & _Cierre_Id.ToString() & ",'" & _CPU & "'" &
                   ",'" & _HostName & "'" & ",'" & _IPAddress & "'" &
                   "," & _Exento.ToString() & "," & _Gravado.ToString() & "," & _Dolares & "," & _TipoCambio & ")"

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

            Query = "Delete FacturaEncabezado" &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Caja_Id=" & _Caja_Id.ToString() &
                    " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
                    " And    Documento_Id=" & _Documento_Id.ToString()

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

            Query = " Update dbo.FacturaEncabezado " &
                    " SET    Bod_Id=" & _Bod_Id.ToString() & "," &
                    " Fecha='" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " Cliente_Id=" & _Cliente_Id & "," &
                    " Nombre='" & _Nombre & "'" & "," &
                    " Vendedor_Id=" & _Vendedor_Id & "," &
                    " Usuario_Id='" & _Usuario_Id & "'" & "," &
                    " Comentario='" & _Comentario & "'" & "," &
                    " Costo=" & _Costo & "," &
                    " Subtotal=" & _Subtotal & "," &
                    " Descuento=" & _Descuento & "," &
                    " IV=" & _IV & "," &
                    " IVDevuelto=" & _IVDevuelto & "," & 'revisar
                    " Total=" & _Total & "," &
                    " Redondeo=" & _Redondeo & "," &
                    " TotalCobrado=" & _TotalCobrado & "," &
                    " Cierre_Id=" & _Cierre_Id & "," &
                    " CPU='" & _CPU & "'" & "," &
                    " HostName='" & _HostName & "'" & "," &
                    " IPAddress='" & _IPAddress & "'" & "," &
                    " Exento=" & _Exento & "," &
                    " Gravado=" & _Gravado & "," &
                    " Dolares=" & _Dolares & "," &
                    " TipoCambio = " & _TipoCambio & "" &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Caja_Id=" & _Caja_Id.ToString() &
                    " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
                    " And    Documento_Id=" & _Documento_Id.ToString()

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
        Dim FacturaDetalle As TFacturaDetalle = Nothing
        Dim FacturaDetalleImpuesto As TFacturaDetalleImpuesto = Nothing
        Dim FacturaPago As TFacturaPago = Nothing
        Dim TablaImpuesto As DataTable = Nothing
        Try
            Cn.Open()

            Query = "select *,b.Nombre as NombreTipo, c.Nombre as NombreUsuario From FacturaEncabezado a, TipoDocumento b, Usuario c" &
                    " Where  a.Emp_Id = b.Emp_Id and a.TipoDoc_Id = b.TipoDoc_Id" &
                    " and    a.Emp_Id = c.Emp_Id and a.Usuario_Id = c.Usuario_Id" &
                    " And    a.Emp_Id = " & _Emp_Id.ToString() &
                    " And    a.Suc_Id=" & _Suc_Id.ToString() &
                    " And    a.Caja_Id=" & _Caja_Id.ToString() &
                    " And    a.TipoDoc_Id=" & _TipoDoc_Id.ToString() &
                    " And    a.Documento_Id=" & _Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                _Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _Cliente_Id = Tabla.Rows(0).Item("Cliente_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Vendedor_Id = Tabla.Rows(0).Item("Vendedor_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Comentario = Tabla.Rows(0).Item("Comentario")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Subtotal = Tabla.Rows(0).Item("Subtotal")
                _Descuento = Tabla.Rows(0).Item("Descuento")
                _IV = Tabla.Rows(0).Item("IV")
                _IVDevuelto = Tabla.Rows(0).Item("IVDevuelto") 'Revisar
                _Total = Tabla.Rows(0).Item("Total")
                _Redondeo = Tabla.Rows(0).Item("Redondeo")
                _TotalCobrado = Tabla.Rows(0).Item("TotalCobrado")
                _Cierre_Id = Tabla.Rows(0).Item("Cierre_Id")
                _CPU = Tabla.Rows(0).Item("CPU")
                _HostName = Tabla.Rows(0).Item("HostName")
                _IPAddress = Tabla.Rows(0).Item("IPAddress")
                _Exento = Tabla.Rows(0).Item("Exento")
                _Gravado = Tabla.Rows(0).Item("Gravado")
                _Puntos = Tabla.Rows(0).Item("Puntos")
                _Dolares = Tabla.Rows(0).Item("Dolares")
                _TipoCambio = Tabla.Rows(0).Item("TipoCambio")
                _RecargoCredito = Tabla.Rows(0).Item("RecargoCredito")
                _MontoPrima = Tabla.Rows(0).Item("MontoPrima")
                _TipoDocumentoNombre = Tabla.Rows(0).Item("NombreTipo")
                _UsuarioNombre = Tabla.Rows(0).Item("NombreUsuario")
                _DireccionEntrega = Tabla.Rows(0).Item("DireccionEntrega")
                _Exoneracion = Tabla.Rows(0).Item("Exoneracion")
            End If


            If _Exoneracion Then
                Query = "select * From FacturaExoneracion" &
                    " Where  Emp_Id = " & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Caja_Id=" & _Caja_Id.ToString() &
                    " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
                    " And    Documento_Id=" & _Documento_Id.ToString()

                Tabla = Cn.Seleccionar(Query).Copy

                With _FacturaExoneracion
                    .TipoDocumento = Tabla.Rows(0).Item("TipoDocumento")
                    .NumeroDocumento = Tabla.Rows(0).Item("NumeroDocumento")
                    .NombreInstitucion = Tabla.Rows(0).Item("NombreInstitucion")
                    .FechaEmision = Tabla.Rows(0).Item("FechaEmision")
                    .PorcentajeExoneracion = Tabla.Rows(0).Item("PorcentajeExoneracion")
                    .MontoExoneracion = Tabla.Rows(0).Item("MontoExoneracion")
                End With
            End If




            Query = "select * From FacturaPago" &
                    " Where  Emp_Id = " & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Caja_Id=" & _Caja_Id.ToString() &
                    " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
                    " And    Documento_Id=" & _Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            For Each Fila As DataRow In Tabla.Rows
                FacturaPago = New TFacturaPago(_Emp_Id)

                With FacturaPago
                    .Emp_Id = Fila("Emp_Id")
                    .Suc_Id = Fila("Suc_Id")
                    .Caja_Id = Fila("Caja_Id")
                    .TipoDoc_Id = Fila("TipoDoc_Id")
                    .Documento_Id = Fila("Documento_Id")
                    .Pago_Id = Fila("Pago_Id")
                    .TipoPago_Id = Fila("TipoPago_Id")
                    .Monto = Fila("Monto")
                    .Banco_Id = IIf(IsDBNull(Fila("Banco_Id")), 0, Fila("Banco_Id"))
                    .ChequeNumero = Fila("ChequeNumero")
                    .Tarjeta_Id = IIf(IsDBNull(Fila("Tarjeta_Id")), 0, Fila("Tarjeta_Id"))
                    .TarjetaNumero = Fila("TarjetaNumero")
                    .TarjetaAutorizacion = Fila("TarjetaAutorizacion")
                    .Fecha = Fila("Fecha")
                End With

                _FacturaPagos.Add(FacturaPago)
            Next



            If EmpresaParametroInfo.FacturacionElectronica Then
                Query = "Select a.*, b.TipoDocNombre " &
            " From FacturaElectronica a" &
            " inner join TipoDocumento b on a.Emp_Id = b.Emp_Id and a.TipoDoc_Id = b.TipoDoc_Id" &
            " Where  a.Emp_Id = " & _Emp_Id.ToString() &
            " And    a.Suc_Id=" & _Suc_Id.ToString() &
            " And    a.Caja_Id=" & _Caja_Id.ToString() &
            " And    a.TipoDoc_Id=" & _TipoDoc_Id.ToString() &
            " And    a.Documento_Id=" & _Documento_Id.ToString()

                Tabla = Cn.Seleccionar(Query).Copy

                If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                    With _FacturaElectronica
                        .Clave = Tabla.Rows(0).Item("Clave")
                        .Consecutivo = Tabla.Rows(0).Item("Consecutivo")
                        .Leyenda = EmpresaParametroInfo.FeLeyenda
                        .TipoDocNombre = Tabla.Rows(0).Item("TipoDocNombre")
                    End With
                End If

                If Tabla Is Nothing OrElse Tabla.Rows.Count = 0 Then
                    Query = "Select a.*, b.TipoDocNombre " &
                " From FacturaElectronicaPendiente a" &
                " inner join TipoDocumento b on a.Emp_Id = b.Emp_Id and a.TipoDoc_Id = b.TipoDoc_Id" &
                " Where  a.Emp_Id = " & _Emp_Id.ToString() &
                " And    a.Suc_Id=" & _Suc_Id.ToString() &
                " And    a.Caja_Id=" & _Caja_Id.ToString() &
                " And    a.TipoDoc_Id=" & _TipoDoc_Id.ToString() &
                " And    a.Documento_Id=" & _Documento_Id.ToString()

                    Tabla = Cn.Seleccionar(Query).Copy

                    If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                        With _FacturaElectronica
                            .Clave = Tabla.Rows(0).Item("Clave")
                            .Consecutivo = Tabla.Rows(0).Item("Consecutivo")
                            .Leyenda = EmpresaParametroInfo.FeLeyenda
                            .TipoDocNombre = Tabla.Rows(0).Item("TipoDocNombre")
                        End With
                    End If

                End If
            End If


            _ReferenciaNC = Nothing

            If _TipoDoc_Id = Enum_TipoDocumento.DevolucionContado Or _TipoDoc_Id = Enum_TipoDocumento.DevolucionCredito Then
                Query = "select Suc_Id, Caja_Id, TipoDoc_Id, Documento_Id" &
                " from  FacturaDevolucion" &
                " Where  Emp_Id = " & _Emp_Id.ToString() &
                " And    Dev_Suc_Id =" & _Suc_Id.ToString() &
                " And    Dev_Caja_Id =" & _Caja_Id.ToString() &
                " And    Dev_TipoDoc_Id =" & _TipoDoc_Id.ToString() &
                " And    Dev_Documento_Id =" & _Documento_Id.ToString()

                Tabla = Cn.Seleccionar(Query).Copy

                If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                    _FacturaDev = New TFacturaEncabezado(_Emp_Id)
                    With _FacturaDev
                        .Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                        .Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                        .TipoDoc_Id = Tabla.Rows(0).Item("TipoDoc_Id")
                        .Documento_Id = Tabla.Rows(0).Item("Documento_Id")
                    End With
                End If

                If Cn.RowsAffected = 0 Then 'Busca a ver si tiene una nota manual
                    Query = "select Fecha, Tipo, Documento, Razon, Codigo" &
                    " from  FacturaReferenciaNC " &
                    " Where  Emp_Id = " & _Emp_Id.ToString() &
                    " And    Suc_Id =" & _Suc_Id.ToString() &
                    " And    Caja_Id =" & _Caja_Id.ToString() &
                    " And    TipoDoc_Id =" & _TipoDoc_Id.ToString() &
                    " And    Documento_Id =" & _Documento_Id.ToString()

                    Tabla = Cn.Seleccionar(Query).Copy

                    If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                        _ReferenciaNC = New TReferenciaNC()
                        With _ReferenciaNC
                            .Fecha = Tabla.Rows(0).Item("Fecha")
                            .Tipo = Tabla.Rows(0).Item("Tipo")
                            .Documento = Tabla.Rows(0).Item("Documento")
                            .Razon = Tabla.Rows(0).Item("Razon")
                            .Codigo = Tabla.Rows(0).Item("Codigo")
                        End With
                    End If

                End If
            Else
                Query = "select Fecha, Tipo, Documento, Razon, Codigo" &
                " from  FacturaReferenciaNC " &
                " Where  Emp_Id = " & _Emp_Id.ToString() &
                " And    Suc_Id =" & _Suc_Id.ToString() &
                " And    Caja_Id =" & _Caja_Id.ToString() &
                " And    TipoDoc_Id =" & _TipoDoc_Id.ToString() &
                " And    Documento_Id =" & _Documento_Id.ToString()

                Tabla = Cn.Seleccionar(Query).Copy

                If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                    _ReferenciaNC = New TReferenciaNC()
                    With _ReferenciaNC
                        .Fecha = Tabla.Rows(0).Item("Fecha")
                        .Tipo = Tabla.Rows(0).Item("Tipo")
                        .Documento = Tabla.Rows(0).Item("Documento")
                        .Razon = Tabla.Rows(0).Item("Razon")
                        .Codigo = Tabla.Rows(0).Item("Codigo")
                    End With
                End If
            End If


            Query = "select * from FacturaDetalleImpuesto" &
                    " where Emp_Id = " & _Emp_Id.ToString() &
                    " And Suc_Id = " & _Suc_Id.ToString() &
                    " And Caja_Id = " & _Caja_Id.ToString() &
                    " And TipoDoc_Id = " & _TipoDoc_Id.ToString() &
                    " And Documento_Id = " & _Documento_Id.ToString()

            TablaImpuesto = Cn.Seleccionar(Query).Copy

            If Cn.RowsAffected = 0 Then
                Query = " Select a.Emp_Id" &
                        "  ,a.Suc_Id" &
                        "  ,a.Caja_Id" &
                        "  ,a.TipoDoc_Id" &
                        "  ,a.Documento_Id" &
                        "  ,a.Detalle_Id" &
                        "  ,b.Codigo_Id" &
                        "  ,b.Tarifa_Id" &
                        "  ,b.Porcentaje" &
                        "  ,a.Cantidad" &
                        "  ,((a.Precio - a.MontoDescuento) * (b.Porcentaje / 100)) as Monto" &
                        "  ,(((a.Precio - a.MontoDescuento) * (b.Porcentaje / 100)) * a.Cantidad) as Total " &
                        "  ,Fecha" &
                    " From FacturaDetalle a with (nolock)" &
                    " inner Join ArticuloImpuesto b with (nolock) on a.Emp_Id = b.Emp_Id And a.Art_Id = b.Art_Id" &
                    " where a.Emp_Id = " & _Emp_Id.ToString() &
                    " And   a.Suc_Id = " & _Suc_Id.ToString() &
                    " And   a.Caja_Id = " & _Caja_Id.ToString() &
                    " And   a.TipoDoc_Id = " & _TipoDoc_Id.ToString() &
                    " And   a.Documento_Id = " & _Documento_Id.ToString() &
                    " And   a.ExentoIV = 0"


                TablaImpuesto = Cn.Seleccionar(Query).Copy
            End If


            Query = "Select a.*, b.Nombre As NombreArticulo, c.Abreviatura as UnidadMedidaNombre, b.CabysCodigo From FacturaDetalle a, Articulo b, UnidadMedida c" &
                    " Where a.Emp_Id = b.Emp_Id And a.Art_Id = b.Art_Id " &
                    " And b.Emp_Id = c.Emp_Id And b.UnidadMedida_Id = c.UnidadMedida_Id " &
                    " And a.Emp_Id = " & _Emp_Id.ToString() &
                    " And a.Suc_Id = " & _Suc_Id.ToString() &
                    " And a.Caja_Id = " & _Caja_Id.ToString() &
                    " And a.TipoDoc_Id = " & _TipoDoc_Id.ToString() &
                    " And a.Documento_Id = " & _Documento_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            _FacturaDetalles.Clear()

            For Each Fila As DataRow In Tabla.Rows
                FacturaDetalle = New TFacturaDetalle(_Emp_Id)

                With FacturaDetalle
                    .Emp_Id = Fila("Emp_Id")
                    .Suc_Id = Fila("Suc_Id")
                    .Caja_Id = Fila("Caja_Id")
                    .TipoDoc_Id = Fila("TipoDoc_Id")
                    .Documento_Id = Fila("Documento_Id")
                    .Detalle_Id = Fila("Detalle_Id")
                    .Art_Id = Fila("Art_Id")
                    .Cantidad = Fila("Cantidad")
                    .Fecha = Fila("Fecha")
                    .Costo = Fila("Costo")
                    .Precio = Fila("Precio")
                    .PorcDescuento = Fila("PorcDescuento")
                    .MontoDescuento = Fila("MontoDescuento")
                    .MontoIV = Fila("MontoIV")
                    .TotalLinea = Fila("TotalLinea")
                    .ExentoIV = Fila("ExentoIV")
                    .Suelto = Fila("Suelto")
                    .Descripcion = Fila("NombreArticulo")
                    .Observacion = Fila("Observacion")
                    .Servicio = Fila("Servicio")
                    .UnidadMedidaNombre = Fila("UnidadMedidaNombre")
                    .CabysCodigo = Fila("CabysCodigo")
                    'Mike 15/12/2020 Para Reimprimir facturas, error DBNULL.
                    If Reimpresion And (Fila("CabysCodigo").ToString = "" Or Fila("CabysCodigo").ToString = Nothing Or IsDBNull(Fila("CabysCodigo"))) Then
                        .CabysCodigo = ""
                    Else 'Valida si en la devolucion el cabys esta vacio.
                        If (Fila("CabysCodigo").ToString = "" Or Fila("CabysCodigo").ToString = Nothing Or IsDBNull(Fila("CabysCodigo"))) Then
                            .CabysCodigo = ""
                        Else
                            .CabysCodigo = Fila("CabysCodigo")
                        End If
                    End If
                End With

                For Each FilaImpuesto As DataRow In TablaImpuesto.Rows
                    If FilaImpuesto("Detalle_Id") = Fila("Detalle_Id") Then
                        FacturaDetalleImpuesto = New TFacturaDetalleImpuesto(_Emp_Id)
                        With FacturaDetalleImpuesto
                            .Suc_Id = FilaImpuesto("Suc_Id")
                            .Caja_Id = FilaImpuesto("Caja_Id")
                            .TipoDoc_Id = FilaImpuesto("TipoDoc_Id")
                            .Documento_Id = FilaImpuesto("Documento_Id")
                            .Detalle_Id = FilaImpuesto("Detalle_Id")
                            .Codigo_Id = FilaImpuesto("Codigo_Id")
                            .Tarifa_Id = FilaImpuesto("Tarifa_Id")
                            .Porcentaje = FilaImpuesto("Porcentaje")
                            .Cantidad = FilaImpuesto("Cantidad")
                            .Monto = FilaImpuesto("Monto")
                            .Total = FilaImpuesto("Total")
                            .Fecha = FilaImpuesto("Fecha")
                        End With
                        FacturaDetalle.ArticuloImpuestos.Add(FacturaDetalleImpuesto)
                    End If
                Next

                _FacturaDetalles.Add(FacturaDetalle)

            Next

            _Cliente = New TCliente(_Emp_Id)
            _Cliente.Cliente_Id = _Cliente_Id
            VerificaMensaje(_Cliente.ListKey())

            With _Vendedor
                .Emp_Id = _Emp_Id
                .Vendedor_Id = _Vendedor_Id
            End With
            VerificaMensaje(_Vendedor.ListKey())

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function BusquedaFacturas(pTipoBusqueda) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec BusquedaFacturas " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & pTipoBusqueda.ToString() & "," & _Cliente_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd") & "','" & _Nombre & "'"

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

    Public Function BusquedaFacturasDev(pTipoBusqueda As Integer, pTipoDoc_Id As Integer, pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()


            Query = "exec BusquedaFacturasDev " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString & "," & pTipoBusqueda.ToString() & "," & _Cliente_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(DateAdd(DateInterval.Day, 1, pFechaFin), "yyyyMMdd") & "','" & _Nombre & "'," & pTipoDoc_Id.ToString()

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

            Query = "select FacturaEncabezado_Id as Numero, Nombre From FacturaEncabezado"

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
    Public Function SiguienteFactura() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            _Documento_Id = 0

            Query = "select (isnull(max(Documento_Id),0) + 1) as SiguienteDocumento" &
                    " From FacturaEncabezado" &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Caja_Id=" & _Caja_Id.ToString() &
                    " And    TipoDoc_Id=" & _TipoDoc_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Documento_Id = Tabla.Rows(0).Item("SiguienteDocumento")
            Else
                VerificaMensaje("Se preserntaron errorres buscando el número de documento")
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Private Function AcumulaPuntosUtilidad() As Integer
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim TipoAcumulacion As New TTipoAcumulacion(EmpresaInfo.Emp_Id)
        Dim Puntos As Integer = 0

        For Each Detalle As TFacturaDetalle In _FacturaDetalles
            TipoAcumulacion.Factor = 0

            Articulo.Art_Id = Detalle.Art_Id
            VerificaMensaje(Articulo.ListKey())

            TipoAcumulacion.TipoAcumulacion_Id = Articulo.TipoAcumulacion_Id
            VerificaMensaje(TipoAcumulacion.ListKey())

            If Detalle.Costo <> 0 Then
                Puntos = Puntos + ((((Detalle.Precio - Detalle.Costo) * Detalle.Cantidad) \ EmpresaParametroInfo.PuntosPorCada) * EmpresaParametroInfo.PuntosAcumula) * TipoAcumulacion.Factor
            End If
        Next

        Articulo = Nothing
        TipoAcumulacion = Nothing

        Return Puntos
    End Function
    Private Function UsoPuntosPago() As Boolean
        Dim resultado As Boolean = False

        For Each Pago As TFacturaPago In _FacturaPagos
            If Pago.TipoPago_Id = Enum_TipoPago.Puntos Then
                resultado = True
                Exit For
            End If
        Next

        Return resultado
    End Function

    Public Function GetConsecutivoFE() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try

            Query = "exec GetConsecutivoFE " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() & "," & _Cliente_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                With _FacturaElectronica
                    .Clave = Tabla.Rows(0).Item("Clave").ToString()
                    .Consecutivo = Tabla.Rows(0).Item("Consecutivo").ToString()
                    .Leyenda = Tabla.Rows(0).Item("Leyenda").ToString()
                    .TipoDoc = Tabla.Rows(0).Item("TipoDoc").ToString()
                    .TipoDocNombre = Tabla.Rows(0).Item("TipoDocNombre").ToString()
                    .Batch_Id = Tabla.Rows(0).Item("Batch_Id").ToString()
                End With
            Else
                VerificaMensaje("No se pudo obtener el consecutivo del documento electronico")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Function VefiricaSaldoFacturaCxC() As Boolean
        Dim Mensaje As String = ""
        Dim Query As String = ""
        Dim CxC_Cliente = New TCxC_Cliente
        Dim DTMovimientoTemp As New SDFinancial.DTCxCMovimiento()
        Try
            Cn.Open()

            Cn.BeginTransaction()

            If EmpresaParametroInfo.InterfazCxC AndAlso _TipoDoc_Id = Enum_TipoDocumento.DevolucionCredito Then


                'Verifica que el codigo del cliente sea del formato esperado
                If Not IsNumeric(Cliente.ClienteExterno) Then
                    VerificaMensaje("El código asociado al cliente en CxC debe de ser númerico")
                End If

                Mensaje = _SDL.VerificaCliente(EmpresaParametroInfo.EmpresaExterna, Cliente.ClienteExterno)

                ' Valida que el cliente exista en el módulo de CxC
                If Mensaje <> "" Then
                    VerificaMensaje("El codigo de cliente asignado no es valido en CXC")
                End If

                With CxC_Cliente
                    .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                    .Cliente_Id = _Cliente.ClienteExterno
                End With
                VerificaMensaje(CxC_Cliente.ListKey)

                Select Case _TipoDoc_Id
                    Case Enum_TipoDocumento.Credito
                        _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.Factura
                        _DTMovimiento.Referencia = "Factura"
                    Case Enum_TipoDocumento.DevolucionCredito
                        _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito
                        _DTMovimiento.Referencia = "Devolución"
                End Select


                Dim ListaMovimientos(0) As SDFinancial.DTCxCMovimientoLinea
                Dim ListaMovimiento As New SDFinancial.DTCxCMovimientoLinea

                'Verifica que la factura en cxc tenga un saldo
                'igual al valor de la factura en el POS

                If _TipoDoc_Id = Enum_TipoDocumento.DevolucionCredito Then

                    Query = "select * From FacturaCxCMovimiento" &
                       " Where     Emp_Id=" & _Emp_Id.ToString() &
                       " And    Suc_Id=" & _Suc_Id.ToString() &
                       " And    Caja_Id=" & _Caja_Id.ToString() &
                       " And    TipoDoc_Id=" & _FacturaDev.TipoDoc_Id.ToString() &
                       " And    Documento_Id=" & _FacturaDev.Documento_Id.ToString()

                    Tabla = Cn.Seleccionar(Query).Copy

                    If Tabla.Rows.Count > 0 Then


                        With DTMovimientoTemp
                            .Emp_Id = Tabla.Rows(0).Item("CXC_Emp_Id").ToString()
                            .Tipo_Id = Tabla.Rows(0).Item("CXC_Tipo_Doc").ToString()
                            .Mov_Id = Tabla.Rows(0).Item("CXC_Mov_Id").ToString()
                        End With

                        _Resultado = _SDL.CxCMovimientoMant(DTMovimientoTemp, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

                        Tabla = _Resultado.Datos

                        ListaMovimiento.Monto = Math.Abs(CDbl(_Resultado.Datos.Rows(0).Item("Saldo").ToString()))

                        Return ListaMovimiento.Monto >= Math.Abs(TotalCobrado)


                    End If

                End If
            End If

            Return False
        Catch ex As Exception
            MensajeError(ex.Message)
            Return True
        Finally
            CxC_Cliente = Nothing
            DTMovimientoTemp = Nothing
        End Try
    End Function

    Public Function GetDocumentoSTR() As String
        Return _Suc_Id.ToString + "-" + _Caja_Id.ToString + "-" + _TipoDoc_Id.ToString + "-" + StrDup(7 - _Documento_Id.ToString.Length, "0") + _Documento_Id.ToString
    End Function


    Public Function GuardarDocumento() As String
        Dim Query As String = ""
        Dim DocAnterior As Long = -1
        Dim Mensaje As String = ""
        Dim FE As New TFacturacionElectronica()
        Dim MensajeFE As String = String.Empty
        Dim ListaMovimientos() As SDFinancial.DTCxCMovimientoLinea
        Dim Movimiento_Id As Integer = 0
        Dim CXCFacturaEncabezado As New SDFinancial.TFacturaEncabezado
        Try

            Cn.Close()

            Cn.Open()

            Cn.BeginTransaction()


            If EmpresaParametroInfo.FacturacionElectronica Then

                VerificaMensaje(GetConsecutivoFE())

                Query = " Insert into FacturaElectronicaPendiente( Emp_Id , Suc_Id" &
                   " , Caja_Id , TipoDoc_Id" &
                   " , Documento_Id , Fecha" &
                   " , Emisor_Id , Consecutivo" &
                   " , Clave , Batch_Id" &
                   " )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                   "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() &
                   "," & _Documento_Id.ToString() & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & EmpresaParametroInfo.Emisor_Id.ToString() & ",'" & _FacturaElectronica.Consecutivo & "'" &
                   ",'" & _FacturaElectronica.Clave & "'" & "," & FacturaElectronica.Batch_Id.ToString() & ")"

                Cn.Ejecutar(Query)
            End If

            If EmpresaParametroInfo.InterfazCxC AndAlso (_TipoDoc_Id = Enum_TipoDocumento.Credito Or _TipoDoc_Id = Enum_TipoDocumento.DevolucionCredito) Then

                With CXCFacturaEncabezado
                    .Emp_Id = _Emp_Id
                    .Suc_Id = _Suc_Id
                    .Caja_Id = _Caja_Id
                    .TipoDoc_Id = _TipoDoc_Id
                    .Documento_Id = _Documento_Id
                End With

                If _Total <> 0 Then
                    Query = " Insert into CxCMovimientoTmp( Emp_Id , Suc_Id" &
                        " , Caja_Id , TipoDoc_Id" &
                        " , Documento_Id , MensajeError" &
                        " )" &
                        " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                        "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() &
                        "," & _Documento_Id.ToString() & ",'Pendiente Envio CxC')"

                    Cn.Ejecutar(Query)
                End If

            End If



            Query = " update Cliente set FechaUltimaCompra = getdate() " &
                " where Emp_Id = " & _Emp_Id.ToString() & " and Cliente_Id = " & _Cliente_Id.ToString()

            Cn.Ejecutar(Query)

            If EmpresaParametroInfo.PuntosActivo And Not UsoPuntosPago() Then
                _Puntos = AcumulaPuntosUtilidad()
            End If

            Query = " Insert into FacturaEncabezado( Emp_Id , Suc_Id" &
                    " , Caja_Id , TipoDoc_Id" &
                    " , Documento_Id , Bod_Id" &
                    " , Fecha , Cliente_Id" &
                    " , Nombre , Vendedor_Id" &
                    " , Usuario_Id , Comentario, Costo" &
                    " , Subtotal , Descuento" &
                    " , IV , IVDevuelto, Total" &
                    " , Redondeo , TotalCobrado" &
                    " , Cierre_Id , CPU" &
                    " , HostName , IPAddress" &
                    " , Exento , Gravado, Dolares, TipoCambio, Puntos, RecargoCredito, MontoPrima" &
                    " , DireccionEntrega, Exoneracion)" &
                    " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                    "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() &
                    "," & _Documento_Id.ToString() & "," & _Bod_Id.ToString() &
                    ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _Cliente_Id.ToString() &
                    ",'" & _Nombre & "'" & "," & _Vendedor_Id.ToString() &
                    ",'" & _Usuario_Id & "','" & _Comentario & "'," & _Costo.ToString() &
                    "," & _Subtotal.ToString() & "," & _Descuento.ToString() &
                    "," & _IV.ToString() & "," & _IVDevuelto.ToString & "," & _Total.ToString() &
                    "," & _Redondeo.ToString() & "," & _TotalCobrado.ToString() &
                    "," & _Cierre_Id.ToString() & ",'" & _CPU & "'" &
                    ",'" & _HostName & "'" & ",'" & _IPAddress & "'" &
                    "," & _Exento.ToString() & "," & _Gravado.ToString() &
                    "," & _Dolares & "," & _TipoCambio & "," & _Puntos.ToString() & "," & _RecargoCredito.ToString() & "," & _MontoPrima &
                    ",'" & _DireccionEntrega & "'," & _Exoneracion & ")"

            Cn.Ejecutar(Query)


            If _Exoneracion Then

                If _FacturaExoneracion Is Nothing Then
                    VerificaMensaje("Imposible almacenar no se encontraron datos de la exoneracion")
                End If

                Query = " insert into FacturaExoneracion ( Emp_Id , Suc_Id" &
                    " , Caja_Id , TipoDoc_Id" &
                    " , Documento_Id , TipoDocumento" &
                    " , NumeroDocumento , NombreInstitucion" &
                    " , FechaEmision , PorcentajeExoneracion" &
                    " , MontoExoneracion)" &
                    " values ( " & Emp_Id.ToString & "," & Suc_Id.ToString &
                    "," & Caja_Id.ToString & "," & TipoDoc_Id.ToString &
                    "," & Documento_Id.ToString & ",'" & _FacturaExoneracion.TipoDocumento & "'" &
                    ",'" & _FacturaExoneracion.NumeroDocumento & "'" & ",'" & _FacturaExoneracion.NombreInstitucion & "'" &
                    ",'" & Format(_FacturaExoneracion.FechaEmision, "yyyyMMdd HH:mm:ss") & "'" & "," & _FacturaExoneracion.PorcentajeExoneracion.ToString &
                    "," & _FacturaExoneracion.MontoExoneracion & ")"

                Cn.Ejecutar(Query)

            End If


            If EmpresaParametroInfo.PuntosActivo And Not UsoPuntosPago() Then
                Query = " update Cliente set PuntosAcumulados = PuntosAcumulados + " & _Puntos.ToString() &
                " where Emp_Id = " & _Emp_Id.ToString() & " and Cliente_Id = " & _Cliente_Id.ToString()

                Cn.Ejecutar(Query)
            End If

            '----------- Guarda los pagos asociados a la factura
            For Each Pago As TFacturaPago In _FacturaPagos

                Query = " Insert into FacturaPago( Emp_Id , Suc_Id" &
                        " , Caja_Id , TipoDoc_Id" &
                        " , Documento_Id , Pago_Id" &
                        " , TipoPago_Id , Monto" &
                        " , Banco_Id , ChequeNumero, ChequeFecha" &
                        " , Tarjeta_Id , TarjetaNumero" &
                        " , TarjetaAutorizacion , Fecha" &
                        " )" &
                        " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                        "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() &
                        "," & _Documento_Id.ToString() & "," & Pago.Pago_Id.ToString() &
                        "," & Pago.TipoPago_Id.ToString() & "," & Pago.Monto.ToString() &
                        "," & IIf(Pago.Banco_Id > 0, Pago.Banco_Id.ToString(), "null") & ",'" & Pago.ChequeNumero & "','" & Format(Pago.ChequeFecha, "yyyyMMdd") & "'" &
                        "," & IIf(Pago.Tarjeta_Id > 0, Pago.Tarjeta_Id.ToString(), "null") & ",'" & Pago.TarjetaNumero & "'" &
                        ",'" & Pago.TarjetaAutorizacion & "'" & ",'" & Format(Pago.Fecha, "yyyyMMdd HH:mm:ss") & "')"

                Cn.Ejecutar(Query)

                If EmpresaParametroInfo.PuntosActivo AndAlso Pago.TipoPago_Id = Enum_TipoPago.Puntos Then
                    Query = " update Cliente set PuntosCanjeados = PuntosCanjeados + " & Pago.Monto &
                    " where Emp_Id = " & _Emp_Id.ToString() & " and Cliente_Id = " & _Cliente_Id.ToString()

                    Cn.Ejecutar(Query)
                End If
            Next

            _DetallesGuardados = 0



            'Llamar al sp que reversa el traslado de bodega del apartado
            If FacturandoApartado Then
                Query = "ReversaTrasladoApartado " & EmpresaInfo.Emp_Id & " , " & SucursalInfo.Suc_Id & " , " & _Proforma.Documento_Id
                Tabla = Cn.Seleccionar(Query).Copy

                Query = "AplicaTrasladoInventario " & EmpresaInfo.Emp_Id & " , " & CInt(Tabla.Rows(0).Item(0).ToString()) & " , " & UsuarioInfo.Usuario_Id
                Cn.Ejecutar(Query)

            End If


            '----------- Guarda el detalle de la factura y hace los rebajos de inventario
            For Each Detalle As TFacturaDetalle In _FacturaDetalles
                'If EmpresaParametroInfo.PrefacturaCompromete Then
                '    Query = "VerificaArticuloComprometido " & Emp_Id.ToString() & " , " & SucursalInfo.Suc_Id & " , " & Bod_Id & " , '" & Detalle.Art_Id & "' , " & Detalle.Cantidad

                '    Cn.Ejecutar(Query)
                'End If

                If Detalle.Precio < Detalle.MontoIV Then
                    VerificaMensaje("El impuesto no puede ser mayor al precio")
                End If

                Query = "exec GuardaFacturaDetalle " & Detalle.Emp_Id.ToString() & "," & Detalle.Suc_Id.ToString() & "," & Detalle.Caja_Id.ToString() & "," & _Bod_Id.ToString() _
                    & "," & Detalle.TipoDoc_Id.ToString() & "," & Detalle.Documento_Id.ToString() & "," & Detalle.Detalle_Id.ToString() & ",'" & Detalle.Art_Id _
                    & "'," & Detalle.Cantidad.ToString() & ",'" & Format(Detalle.Fecha, "yyyyMMdd HH:mm:ss") & "'," & Detalle.Costo.ToString() & "," & Detalle.Precio.ToString() _
                    & "," & Detalle.PorcDescuento.ToString() & "," & Detalle.MontoDescuento.ToString() & "," & Detalle.MontoIV.ToString() & "," & Detalle.TotalLinea.ToString() _
                    & "," & Detalle.ExentoIV & "," & Detalle.Suelto & ",'" & _Usuario_Id & "','" & Detalle.Observacion & "'," & Detalle.Servicio & ",'" & Mid(Cliente.Nombre.ToUpper(), 1, 80) _
                    & "','" & _FacturaElectronica.Consecutivo & "','" & _FacturaElectronica.Clave & "'"

                Cn.Ejecutar(Query)

                For Each impuesto As TFacturaDetalleImpuesto In Detalle.ArticuloImpuestos


                    impuesto.Total = Math.Abs((Detalle.Cantidad * impuesto.Monto))

                    Query = " insert into FacturaDetalleImpuesto ( Emp_Id , Suc_Id" &
                    " , Caja_Id , TipoDoc_Id" &
                    " , Documento_Id , Detalle_Id" &
                    " , Codigo_Id , Tarifa_Id" &
                    " , Porcentaje , Cantidad" &
                    " , Monto , Total" &
                    " , Fecha)" &
                    " values ( " & Detalle.Emp_Id.ToString() & "," & Detalle.Suc_Id.ToString() &
                    "," & Detalle.Caja_Id.ToString() & "," & Detalle.TipoDoc_Id.ToString() &
                    "," & Detalle.Documento_Id.ToString() & "," & Detalle.Detalle_Id.ToString() &
                    ",'" & impuesto.Codigo_Id & "'" & ",'" & impuesto.Tarifa_Id & "'" &
                    "," & impuesto.Porcentaje.ToString & "," & Detalle.Cantidad.ToString() &
                    "," & impuesto.Monto.ToString() & "," & impuesto.Total &
                    ",'" & Format(Detalle.Fecha, "yyyyMMdd HH:mm:ss") & "'" & ")"



                    Cn.Ejecutar(Query)
                Next

                If _TipoDoc_Id = Enum_TipoDocumento.Contado Or _TipoDoc_Id = Enum_TipoDocumento.Credito Then
                    'Marcar el articulo como facturado si existe algun encargo
                    Query = "update ClienteEncargo set Facturado = 1, FacturadoFecha=getdate()" &
                    " where Emp_Id = " & _Emp_Id.ToString() & " and Cliente_Id = " & _Cliente_Id.ToString() & " and Art_Id = '" & Detalle.Art_Id & "' and Facturado = 0"
                    Cn.Ejecutar(Query)
                End If

                _DetallesGuardados += 1


            Next


            'If no esta facturando apartado
            If Not FacturandoApartado Then
                '----------- Acumula para el cierre de caja 
                If _TipoDoc_Id = Enum_TipoDocumento.Contado Or (_TipoDoc_Id = Enum_TipoDocumento.Credito And _FacturaPagos.Count > 0) Then
                    Query = "CierreCajaAcumulaPago " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Caja_Id.ToString & "," & _TipoDoc_Id.ToString & "," & _Documento_Id.ToString & "," & _Cierre_Id.ToString

                    Cn.Ejecutar(Query)
                End If
            End If


            'este es el que hay que cambiar
            If _TipoDoc_Id = Enum_TipoDocumento.DevolucionContado Then
                If _TipoDevolucion = Enum_TipoDevolucion.Original AndAlso Not _FacturaDev Is Nothing Then
                    Query = "CierreCajaReversaPago " & _FacturaDev.Emp_Id.ToString & "," & _FacturaDev.Suc_Id.ToString & "," & _FacturaDev.Caja_Id.ToString & "," & _FacturaDev.TipoDoc_Id.ToString & "," & _FacturaDev.Documento_Id.ToString & "," & _Cierre_Id.ToString & "," & _TipoDoc_Id.ToString() & "," & _Documento_Id.ToString()
                ElseIf _TipoDevolucion = Enum_TipoDevolucion.Tarjeta Or _TipoDevolucion = Enum_TipoDevolucion.Transferencia Then
                    Query = "CierreCajaReversaPagoTipado " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Caja_Id.ToString & "," & _TipoDoc_Id.ToString & "," & _Documento_Id.ToString & "," & _Cierre_Id.ToString & "," & _TotalCobrado.ToString & "," & _TipoDevolucion
                Else
                    Query = "CierreCajaAcumulaMonto " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Caja_Id.ToString & "," & _TipoDoc_Id.ToString & "," & _Documento_Id.ToString & "," & _Cierre_Id.ToString & "," & _TotalCobrado.ToString & ",1"
                End If
                Cn.Ejecutar(Query)
            End If

            If FacturandoApartado Then
                Query = "exec VinculaFacturaApartado " & Emp_Id & "," & Suc_Id & "," & Proforma.Documento_Id & "," & _Documento_Id & "," & Caja_Id
                Cn.Ejecutar(Query)
            End If

            If _TipoDoc_Id = Enum_TipoDocumento.Contado Or _TipoDoc_Id = Enum_TipoDocumento.Credito Then
                If Not _Proforma Is Nothing Then
                    If _Proforma.Tipo = Enum_TipoFacturacion.PreFactura OrElse (_Proforma.Tipo = Enum_TipoFacturacion.Proforma And EmpresaParametroInfo.ProformaElimina) OrElse FacturandoApartado Then
                        'Este proceso verifica al eliminar la proforma si es cuna prefactura si la empresa compromete saldos, este sp los libera
                        Query = "EliminaProforma " & _Proforma.Emp_Id.ToString() & "," & _Proforma.Suc_Id() & "," & _Proforma.Documento_Id.ToString()

                        Cn.Ejecutar(Query)
                    End If
                End If
            End If


            If Not _FacturaDev Is Nothing AndAlso (_TipoDoc_Id = Enum_TipoDocumento.DevolucionContado OrElse _TipoDoc_Id = Enum_TipoDocumento.DevolucionCredito) Then
                Query = "MarcaFacturaDevolucion " & _Emp_Id.ToString() & "," & _FacturaDev.Suc_Id & "," & _FacturaDev.Caja_Id & "," & _FacturaDev.TipoDoc_Id & "," & _FacturaDev.Documento_Id &
                    "," & _Suc_Id & "," & _Caja_Id & "," & _TipoDoc_Id & "," & _Documento_Id & "," & _TotalCobrado

                Cn.Ejecutar(Query)
            End If

            If Not _Proforma Is Nothing Then
                DocAnterior = _Proforma.Documento_Id
            End If

            If Not _ReferenciaNC Is Nothing Then
                Query = "insert into FacturaReferenciaNC (Emp_Id, Suc_Id, Caja_Id, TipoDoc_Id, Documento_Id, Fecha, Tipo, Documento, Razon, Codigo) " &
                    "values(" & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() & "," & _Documento_Id.ToString() &
                    ",'" & Format(_ReferenciaNC.Fecha, "yyyyMMdd") & "','" & _ReferenciaNC.Tipo & "','" & _ReferenciaNC.Documento & "','" & _ReferenciaNC.Razon & "','" & _ReferenciaNC.Codigo & "')"

                Cn.Ejecutar(Query)
            End If


            If Articulos <> "" AndAlso DetallesGuardados > 0 Then
                Query = "exec InsertaFacturaBitacora " & _Cliente_Id.ToString() & "," & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Caja_Id & "," &
                    _TipoDoc_Id.ToString() & "," & _Documento_Id.ToString() & ",'" & _Usuario_Id & "','" & _IPAddress & "',1," & DocAnterior.ToString() & ",'" & Articulos & "'," & _DetallesGuardados

                Cn.Ejecutar(Query)
            Else
                VerificaMensaje("Se presentaron errores almacenando el documento por falta de comunicacion con el server" & vbCrLf & "No Cierre esta pantalla y comuniquese con el proveedor del software")
            End If


            Cn.CommitTransaction()


            If EmpresaParametroInfo.FacturacionElectronica Then
                Try

                    With FE
                        .Encabezado = Me
                        .CoreURL = InfoMaquina.URLCoreAPI
                        .Moneda = IIf(_Dolares <> 0, coFEMonedaDolar, coFEMonedaColon)
                        .Emisor_Id = EmpresaParametroInfo.Emisor_Id
                        .Token = EmpresaParametroInfo.FeToken
                        .Clave = _FacturaElectronica.Clave
                        .Consecutivo = _FacturaElectronica.Consecutivo
                        .Bacth_Id = _FacturaElectronica.Batch_Id
                        .Situacion = Enum_SituacionDocumentoElectronico.Normal
                        .TipoCambio = _TipoCambio
                    End With

                    MensajeFE = FE.Facturar(Cn)

                    If MensajeFE.Trim = String.Empty Then
                        Query = "delete FacturaElectronicaPendiente" &
                        " where Emp_Id = " & _Emp_Id.ToString &
                        " and Suc_Id = " & _Suc_Id.ToString &
                        " and Caja_Id = " & _Caja_Id.ToString &
                        " and TipoDoc_Id = " & _TipoDoc_Id.ToString &
                        " and Documento_Id = " & _Documento_Id.ToString()

                        Cn.Ejecutar(Query)
                    Else

                        Query = "update FacturaElectronicaPendiente set Mensaje = '" & MensajeFE.Replace("'", " ") & "'" &
                        " where Emp_Id = " & _Emp_Id.ToString &
                        " and Suc_Id = " & _Suc_Id.ToString &
                        " and Caja_Id = " & _Caja_Id.ToString &
                        " and TipoDoc_Id = " & _TipoDoc_Id.ToString &
                        " and Documento_Id = " & _Documento_Id.ToString()

                        Cn.Ejecutar(Query)
                    End If

                Catch ex As Exception
                    BitacoraErrores(Application.StartupPath, ex.Message, "Error enviando documento electronico" & _FacturaElectronica.Clave)
                End Try
            End If

            If EmpresaParametroInfo.InterfazCxC AndAlso (_TipoDoc_Id = Enum_TipoDocumento.Credito Or _TipoDoc_Id = Enum_TipoDocumento.DevolucionCredito) Then
                Dim CxC_Cliente = New TCxC_Cliente
                Try

                    'Verifica que el codigo del cliente sea del formato esperado
                    If Not IsNumeric(Cliente.ClienteExterno) Then
                        VerificaMensaje("El código asociado al cliente en CxC debe de ser númerico")
                    End If

                    Mensaje = _SDL.VerificaCliente(EmpresaParametroInfo.EmpresaExterna, Cliente.ClienteExterno)

                    ' Valida que el cliente exista en el módulo de CxC
                    If Mensaje <> "" Then
                        VerificaMensaje("El codigo de cliente asignado no es valido en CXC")
                    End If

                    With CxC_Cliente
                        .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                        .Cliente_Id = _Cliente.ClienteExterno
                    End With

                    VerificaMensaje(CxC_Cliente.ListKey)

                    If _TipoDoc_Id = Enum_TipoDocumento.Credito Then
                        'Factura de credito
                        _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.Factura
                        _DTMovimiento.Referencia = "Factura"

                        With _DTMovimiento
                            .Emp_Id = Emp_Id
                            .Cliente_Id = _Cliente.ClienteExterno
                            .Referencia = GetReferenciaCxC(_Suc_Id, _Caja_Id, _TipoDoc_Id, _Documento_Id) & IIf(FacturaElectronica.Consecutivo.Trim <> "", "-", "") & FacturaElectronica.Consecutivo
                            .FechaRecibido = _Fecha
                            .FechaDocumento = _Fecha
                            .FechaVencimiento = DateAdd(DateInterval.Day, CxC_Cliente.DiasCredito, _Fecha)
                            .Moneda = IIf(_Dolares, coMonedaDolares, coMonedaColones)
                            .Monto = _Total
                            .Saldo = _Total
                            .TipoCambio = _TipoCambio
                            .Usuario_Id = coUsuarioGeneral
                            .AplicaMora = CxC_Cliente.AplicaMora
                            .Caja_Id = CajaInfo.Caja_Id
                            .Cierre_Id = CajaInfo.Cierre_Id
                        End With

                        _Resultado = _SDL.CxCMovimientoMantSD(_DTMovimiento, SDFinancial.EnumOperacionMant.Insertar, String.Empty, CXCFacturaEncabezado)
                        VerificaMensaje(_Resultado.ErrorDescription)

                    Else
                        'Nota de credito

                        _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito
                        _DTMovimiento.Referencia = "Devolución"


                        If _CxCDevolucionFacturas.Count > 0 Then

                            ReDim ListaMovimientos(_CxCDevolucionFacturas.Count - 1)


                            For Each Mov As SDFinancial.DTCxCMovimientoLinea In _CxCDevolucionFacturas
                                ListaMovimientos(Movimiento_Id) = Mov
                                Movimiento_Id += 1
                            Next

                            With _DTMovimiento
                                .Emp_Id = Emp_Id
                                .Cliente_Id = _Cliente.ClienteExterno
                                .Referencia = GetReferenciaCxC(_Suc_Id, _Caja_Id, _TipoDoc_Id, _Documento_Id) & IIf(FacturaElectronica.Consecutivo.Trim <> "", "-", "") & FacturaElectronica.Consecutivo
                                .FechaRecibido = _Fecha
                                .FechaDocumento = _Fecha
                                .FechaVencimiento = DateAdd(DateInterval.Day, CxC_Cliente.DiasCredito, _Fecha)
                                .Moneda = IIf(_Dolares, coMonedaDolares, coMonedaColones)
                                .Monto = Math.Abs(_MontoDevolucionFacturas)
                                .Saldo = 0
                                .TipoCambio = _TipoCambio
                                .Usuario_Id = coUsuarioGeneral
                                .AplicaMora = CxC_Cliente.AplicaMora
                                .Caja_Id = CajaInfo.Caja_Id
                                .Cierre_Id = CajaInfo.Cierre_Id
                                .ListaMovimientos = ListaMovimientos
                                If _MontoNotaAdicional > 0 Then
                                    .GeneraNotaCredito = True
                                    .MontoNotaCredito = _MontoNotaAdicional
                                Else
                                    .GeneraNotaCredito = False
                                    .MontoNotaCredito = 0
                                End If
                            End With

                            _Resultado = _SDL.CxCMovimientoMantSD(_DTMovimiento, SDFinancial.EnumOperacionMant.Insertar, String.Empty, CXCFacturaEncabezado)
                            VerificaMensaje(_Resultado.ErrorDescription)

                        Else
                            If _MontoNotaAdicional > 0 Then

                                _DTMovimiento = New SDFinancial.DTCxCMovimiento()

                                _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito

                                With _DTMovimiento
                                    .Emp_Id = Emp_Id
                                    .Cliente_Id = _Cliente.ClienteExterno
                                    .Referencia = GetReferenciaCxC(_Suc_Id, _Caja_Id, _TipoDoc_Id, _Documento_Id) & IIf(FacturaElectronica.Consecutivo.Trim <> "", "-", "") & FacturaElectronica.Consecutivo
                                    .FechaRecibido = _Fecha
                                    .FechaDocumento = _Fecha
                                    .FechaVencimiento = DateAdd(DateInterval.Day, CxC_Cliente.DiasCredito, _Fecha)
                                    .Moneda = IIf(_Dolares, coMonedaDolares, coMonedaColones)
                                    .Monto = Math.Abs(_MontoNotaAdicional)
                                    .Saldo = 0
                                    .TipoCambio = _TipoCambio
                                    .Usuario_Id = coUsuarioGeneral
                                    .AplicaMora = CxC_Cliente.AplicaMora
                                    .Caja_Id = CajaInfo.Caja_Id
                                    .Cierre_Id = CajaInfo.Cierre_Id
                                End With

                                _Resultado = _SDL.CxCMovimientoMantSD(_DTMovimiento, SDFinancial.EnumOperacionMant.Insertar, String.Empty, CXCFacturaEncabezado)
                                VerificaMensaje(_Resultado.ErrorDescription)

                            End If
                        End If
                    End If

                    Query = "Delete CxCMovimientoTmp" &
                            " Where  Emp_Id=" & _Emp_Id.ToString() &
                            " And    Suc_Id=" & _Suc_Id.ToString() &
                            " And    Caja_Id=" & _Caja_Id.ToString() &
                            " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
                            " And    Documento_Id=" & _Documento_Id.ToString()

                    Cn.Ejecutar(Query)

                Catch ex As Exception
                    BitacoraErrores(Application.StartupPath, ex.Message, "Error enviando CXC Ref " & _DTMovimiento.Referencia)
                End Try
            End If

            Return ""
        Catch ex As Exception
            If Cn.ActiveTansaction Then
                Cn.RollBackTransaction()
            End If
            Return ex.Message
        Finally
            FE = Nothing
            Cn.Close()
        End Try
    End Function

    'Private Function GuardaErrorEnvioCxC(pMensaje As String)
    '    Dim Query As String
    '    Try

    '        Query = "Delete CxCMovimientoTmp" &
    '        " Where     Emp_Id=" & _Emp_Id.ToString() &
    '        " And    Suc_Id=" & _Suc_Id.ToString() &
    '        " And    Caja_Id=" & _Caja_Id.ToString() &
    '        " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
    '        " And    Documento_Id=" & _Documento_Id.ToString()

    '        Cn.Ejecutar(Query)

    '        Query = " Insert into CxCMovimientoTmp( Emp_Id , Suc_Id" &
    '        " , Caja_Id , TipoDoc_Id" &
    '        " , Documento_Id , MensajeError" &
    '        " )" &
    '        " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
    '        "," & _Caja_Id.ToString() & "," & _TipoDoc_Id.ToString() &
    '        "," & _Documento_Id.ToString() & ",'" & pMensaje.Trim().Replace("'", "") & "'" & ")"

    '        Cn.Ejecutar(Query)


    '        Return String.Empty
    '    Catch ex As Exception
    '        Return ex.Message
    '    End Try

    'End Function


    Public Function RptVentasCategoria(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentasCategoria " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    Public Function RptVentasFecha(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentasxFecha " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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

    Public Function RptCostoVentaxFactura(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptCostoVentaxFactura " & _Emp_Id.ToString & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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

    Public Function RptVentaArticuloXFechaXSucursal(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentaArticuloXFechaXSucursal " & _Emp_Id.ToString & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    Public Function RptExentoGravado(pStartDate As Date, pEndDate As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()
            Query = "EXEC [RptExentoGravados]" & _Emp_Id.ToString & " ,'" & Format(pStartDate, "yyyyMMdd") & "','" & Format(pEndDate, "yyyyMMdd") & "'"
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
    Public Function RptVentasxTipoPago(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentasxTipoPago " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    Public Function DocumentosRecientes(ByVal pDesde As Date,
                                        ByVal pHasta As Date,
                                        ByVal IdCliente As Integer,
                                        ByVal CajaId As Integer,
                                        ByVal TipoDocumento As Integer) As String
        Dim Query As String
        Dim orderBy As String = " order by a.Fecha desc"
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select a.Caja_Id as caja
                           ,d.Nombre as CajaNombre
                           ,b.Nombre as Tipo
                           ,a.Documento_Id as Numero
                           ,a.Fecha
                           ,c.Nombre as Cliente
                           ,a.Total as Monto
                           ,a.TipoDoc_Id
                           ,c.Email
                           ,isnull(e.Clave,'') as Clave 
                           ,substring(isnull(e.Consecutivo,'00000000000000000000'),9,2) as TipoDoc 
                           ,isnull(e.Doc_Id,0) as Doc_Id
                           ,isnull(f.Nombre,0) as EstadoNombre
                    From FacturaEncabezado a (nolock)
                        inner join TipoDocumento b (nolock) on a.Emp_Id = b.Emp_Id and a.TipoDoc_Id =  b.TipoDoc_Id 
                        inner join Cliente c (nolock) on a.Emp_Id = c.Emp_Id and a.Cliente_Id = c.Cliente_Id
                        inner join Caja d (nolock) on a.Emp_Id = d.Emp_Id and a.Suc_Id = d.Suc_Id and a.Caja_Id = d.Caja_Id
                        left join FacturaElectronica e (nolock) on a.Emp_Id = e.Emp_Id and a.Suc_Id = e.Suc_Id and a.Caja_Id = e.Caja_Id and a.TipoDoc_Id = e.TipoDoc_Id and a.Documento_Id = e.Documento_Id 
                        left join FacturaElectronicaEstado f (nolock) on e.Estado_Id = f.Estado_Id" &
                    " where a.Emp_Id = " & _Emp_Id.ToString() &
                       "and a.Suc_Id = " & _Suc_Id.ToString() &
                       "And (a.Fecha >= '" & pDesde.ToString("yyyyMMdd") & "' " &
                        "and a.Fecha <  '" & pHasta.ToString("yyyyMMdd") & "')"




            If IdCliente <> 0 Then
                Query = Query & " And a.Cliente_Id = '" & IdCliente & "'"
            End If

            If CajaId <> 0 Then
                Query = Query & " and a.Caja_Id = '" & CajaId & "'"
            End If

            If TipoDocumento <> 0 Then
                Query = Query & " and b.TipoDoc_Id = '" & TipoDocumento & "'"
            End If

            Query = Query & orderBy

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

    Public Function RptFacturaElectronicaEstado(ByVal pDesde As Date,
                                        ByVal pHasta As Date,
                                        ByVal IdCliente As Integer,
                                        ByVal CajaId As Integer,
                                        ByVal TipoDocumento As Integer) As String
        Dim Query As String

        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "Exec RptFacturaElectronicaEstado " & Emp_Id & "," & Suc_Id & ",'" &
            pDesde.ToString("yyyyMMdd") & "','" & pHasta.AddDays(1).ToString("yyyyMMdd") &
             "'," & IdCliente & "," & CajaId & "," & TipoDocumento


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

    Public Function RptArticulosPromedioVenta(pCantidad As Double) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptArticulosPromedioVenta " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString & "," & pCantidad.ToString

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
    Public Function RptArticulosPromedioVentaFecha(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptArticulosPromedioVentaFecha " & _Emp_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    Public Function RptFacturasDetallado(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptFacturasDetallado " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    'MIKE 13/11/2020
    Public Function RptFacturasDetalladoCR(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptFacturasDetallado_CR " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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

    Public Function RptFacturasDetalladoPorDocumento(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptFacturasDetalladoPorTipoDocumento " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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

            Query = "select * From FacturaEncabezado"

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

    Public Function HistorialFactura(pTipo As Enum_TipoFacturacion) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = " select a.*,b.Nombre" &
                    " from FacturaBitacora a, Usuario b" &
                    " where a.Emp_Id = b.Emp_Id and a.Usuario_Id = b.Usuario_Id " &
                    " and   a.Cliente_Id  = " & _Cliente_Id.ToString() &
                    " and   a.Emp_Id      = " & _Emp_Id.ToString() &
                    " and   a.Suc_Id      = " & _Suc_Id.ToString()

            If pTipo = Enum_TipoFacturacion.Factura Then
                Query += " and   a.Caja_Id = " & _Caja_Id.ToString() &
                         " and   a.TipoDoc_Id = " & _TipoDoc_Id.ToString() &
                         " and   a.Documento_Id = " & _Documento_Id.ToString()
            Else
                Query += " and   a.Documento_Id = " & _Documento_Id.ToString()
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
    Public Function PasaFacturasPendientesCxC(ByRef pProgreso As ProgressBar) As String
        Dim Movimiento As New TCxCMovimientoTmp(_Emp_Id)
        Dim MovimientoTmp As TCxCMovimientoTmp = Nothing
        Dim FacturaEncabezado As TFacturaEncabezado = Nothing
        Dim Mensaje As String = ""

        Try
            _ErroresPasaCxC.Clear()

            Movimiento.Suc_Id = _Suc_Id
            VerificaMensaje(Movimiento.List)

            If Movimiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontrarón Documentos pendientes de pasar a CxC")
            End If

            pProgreso.Minimum = 0
            pProgreso.Maximum = Movimiento.RowsAffected
            pProgreso.Value = 0

            For Each Fila As DataRow In Movimiento.Data.Tables(0).Rows
                pProgreso.Value += 1

                Try
                    FacturaEncabezado = New TFacturaEncabezado(CInt(Fila("Emp_Id")))

                    With FacturaEncabezado
                        .Suc_Id = CInt(Fila("Suc_Id"))
                        .Caja_Id = CInt(Fila("Caja_Id"))
                        .TipoDoc_Id = CInt(Fila("TipoDoc_Id"))
                        .Documento_Id = CInt(Fila("Documento_Id"))
                    End With
                    VerificaMensaje(FacturaEncabezado.ListKey)

                    Dim CxC_Cliente = New TCxC_Cliente

                    _Cliente = New TCliente(FacturaEncabezado.Emp_Id)
                    _Cliente.Cliente_Id = FacturaEncabezado.Cliente_Id
                    VerificaMensaje(Cliente.ListKey)

                    'Verifica que el codigo del cliente sea del formato esperado
                    If Not IsNumeric(_Cliente.ClienteExterno) Then
                        VerificaMensaje(GuardaErrorCxC(FacturaEncabezado.Emp_Id, FacturaEncabezado.Suc_Id, FacturaEncabezado.Caja_Id, FacturaEncabezado.TipoDoc_Id, FacturaEncabezado.Documento_Id, "El código asociado al cliente en CxC debe de ser númerico"))
                        VerificaMensaje("El código asociado al cliente en CxC debe de ser númerico")
                    End If

                    Mensaje = _SDL.VerificaCliente(EmpresaParametroInfo.EmpresaExterna, _Cliente.ClienteExterno)

                    ' Valida que el cliente exista en el módulo de CxC
                    If Mensaje <> "" Then
                        VerificaMensaje(GuardaErrorCxC(FacturaEncabezado.Emp_Id, FacturaEncabezado.Suc_Id, FacturaEncabezado.Caja_Id, FacturaEncabezado.TipoDoc_Id, FacturaEncabezado.Documento_Id, Mensaje))
                        VerificaMensaje(Mensaje)
                    End If

                    With CxC_Cliente
                        .Emp_Id = EmpresaParametroInfo.EmpresaExterna
                        .Cliente_Id = _Cliente.ClienteExterno
                    End With
                    VerificaMensaje(CxC_Cliente.ListKey)

                    Select Case FacturaEncabezado.TipoDoc_Id
                        Case Enum_TipoDocumento.Credito
                            _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.Factura
                        Case Enum_TipoDocumento.DevolucionCredito
                            _DTMovimiento.Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito
                    End Select


                    With _DTMovimiento
                        .Emp_Id = EmpresaParametroInfo.Emp_Id
                        .Cliente_Id = _Cliente.ClienteExterno
                        .Referencia = GetReferenciaCxC(FacturaEncabezado.Suc_Id, FacturaEncabezado.Caja_Id, FacturaEncabezado.TipoDoc_Id, FacturaEncabezado.Documento_Id) & IIf(FacturaEncabezado.FacturaElectronica.Consecutivo.Trim <> "", "-", "") & FacturaEncabezado.FacturaElectronica.Consecutivo
                        .FechaRecibido = FacturaEncabezado.Fecha
                        .FechaDocumento = FacturaEncabezado.Fecha
                        .FechaVencimiento = DateAdd(DateInterval.Day, CxC_Cliente.DiasCredito, FacturaEncabezado.Fecha)
                        .Moneda = IIf(FacturaEncabezado.Dolares, coMonedaDolares, coMonedaColones)
                        .Monto = Math.Abs(FacturaEncabezado.TotalCobrado)
                        .Saldo = Math.Abs(FacturaEncabezado.TotalCobrado)
                        .TipoCambio = FacturaEncabezado.TipoCambio
                        .Usuario_Id = coUsuarioGeneral
                        .AplicaMora = CxC_Cliente.AplicaMora
                        .Caja_Id = CajaInfo.Caja_Id
                        .Cierre_Id = CajaInfo.Cierre_Id
                    End With

                    _Resultado = _SDL.CxCMovimientoMant(_DTMovimiento, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

                    If _Resultado.ErrorDescription <> "" Then
                        VerificaMensaje(GuardaErrorCxC(FacturaEncabezado.Emp_Id, FacturaEncabezado.Suc_Id, FacturaEncabezado.Caja_Id, FacturaEncabezado.TipoDoc_Id, FacturaEncabezado.Documento_Id, _Resultado.ErrorDescription))
                        VerificaMensaje(_Resultado.ErrorDescription)
                    End If

                    MovimientoTmp = New TCxCMovimientoTmp(FacturaEncabezado.Emp_Id)

                    With MovimientoTmp
                        .Suc_Id = FacturaEncabezado.Suc_Id
                        .Caja_Id = FacturaEncabezado.Caja_Id
                        .TipoDoc_Id = FacturaEncabezado.TipoDoc_Id
                        .Documento_Id = FacturaEncabezado.Documento_Id
                    End With
                    VerificaMensaje(MovimientoTmp.Delete)

                Catch ex As Exception
                    _ErroresPasaCxC.Add(ex.Message)
                End Try
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Movimiento = Nothing
            FacturaEncabezado = Nothing
        End Try
    End Function
    Public Function RptVentasXArticulo(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec RptVentasXArticulo " & _Emp_Id.ToString & "," & _Suc_Id.ToString & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    Public Function RptVentasDetalladoXEmpresa(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentasDetalladoXEmpresa '" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    Public Function RptVentasDetalladoXEmpresa_CR(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentasDetalladoXEmpresa_CR '" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    Public Function RptVentasResumidoXEmpresa(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentasDetalladoXEmpresa '" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    Public Function RptDescuentosXUsuario(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec RptDescuentosXUsuario " & _Emp_Id.ToString & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    Public Function RptVentasxHora(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentasxHora '" & _Emp_Id & "','" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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

    Public Function RptComisionxVendedor(pFechaIni As DateTime, pFechaFin As DateTime, pVendedor_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptComisionesxVendedor '" & _Emp_Id & "','" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'," & pVendedor_Id

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

    Public Function RptComisionxProveedor(pFechaIni As DateTime, pFechaFin As DateTime, pVendedor_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptComisionesxProveedor '" & _Emp_Id & "','" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'," & pVendedor_Id

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

    Public Function RptComisionxVendedorVentasContado(pFechaIni As DateTime, pFechaFin As DateTime, pVendedor_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptComisionesPorVendedorVentasContado " & _Emp_Id & "," & _Suc_Id & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'," & pVendedor_Id

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


    Public Function RptComisionxServicios(pFechaIni As DateTime, pFechaFin As DateTime, pVendedor_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptComisionesxServicio '" & _Emp_Id & "','" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'," & pVendedor_Id

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

    Public Function RptVentasxHoraxCategoria(pFechaIni As DateTime, pFechaFin As DateTime, pCategoria As Integer, pHoraIni As DateTime, pHoraFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentasXHoraXCategoria " & _Emp_Id & "," & pCategoria & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "','" & Format(pHoraIni, "HH:mm") & "','" & Format(pHoraFin, "HH:mm") & "'"

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
    Public Function RptVentasPrecioPromedio(pFechaIni As Date, pFechaFin As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentasPrecioPromedio " & _Emp_Id.ToString & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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

    Public Function SaldoDocumentoCxC(ByRef pCXCEmp_Id As Integer, ByRef pCXCTipoDoc As Integer, ByRef pCXCMov_Id As Long, ByRef pMonto As Double, ByRef pSaldo As Double) As String
        Dim DTMovimientoTemp As New SDFinancial.DTCxCMovimiento()
        Dim Query As String = String.Empty
        Try

            pCXCEmp_Id = 0
            pCXCTipoDoc = 0
            pCXCMov_Id = 0
            pMonto = 0
            pSaldo = 0

            Query = "select * From FacturaEncabezadoCxC" &
                   " Where  Emp_Id=" & _Emp_Id.ToString() &
                   " And    Suc_Id=" & _Suc_Id.ToString() &
                   " And    Caja_Id=" & _Caja_Id.ToString() &
                   " And    TipoDoc_Id=" & _TipoDoc_Id.ToString() &
                   " And    Documento_Id=" & _Documento_Id.ToString()

            _Resultado = _SDL.SelectQuery(Query, "")


            Tabla = _Resultado.Datos

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then


                With DTMovimientoTemp
                    .Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                    .Tipo_Id = Tabla.Rows(0).Item("Tipo_Id")
                    .Mov_Id = Tabla.Rows(0).Item("Mov_Id")

                    pCXCEmp_Id = Tabla.Rows(0).Item("Emp_Id")
                    pCXCTipoDoc = Tabla.Rows(0).Item("Tipo_Id")
                    pCXCMov_Id = Tabla.Rows(0).Item("Mov_Id")
                End With

                _Resultado = _SDL.CxCMovimientoMant(DTMovimientoTemp, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

                Tabla = _Resultado.Datos

                If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                    pMonto = Tabla.Rows(0).Item("Monto")
                    pSaldo = Tabla.Rows(0).Item("Saldo")
                End If

            End If


            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            DTMovimientoTemp = Nothing
        End Try
    End Function
    Public Function RptUtilidadxFactura(pStartDate As Date, pEndDate As Date) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()
            Query = "EXEC [RptUtilidadxFactura]" & _Emp_Id.ToString & "," & _Suc_Id.ToString & " ,'" & Format(pStartDate, "yyyyMMdd") & "','" & Format(pEndDate, "yyyyMMdd") & "'"
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