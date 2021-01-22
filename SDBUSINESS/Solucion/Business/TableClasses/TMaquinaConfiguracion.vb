Public Class TMaquinaConfiguracion
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _MAC_Address As String
    Private _Nombre As String
    Private _Caja_Id As Integer
    Private _ClienteDefault As Integer
    Private _FacturaContadoSolicitaCliente As Integer
    Private _ComPort As String
    Private _ConfirmaImpresionFactura As Integer
    Private _ContaDataBase As String
    Private _ContaPassword As String
    Private _ContaServer As String
    Private _ContaUser As String
    Private _Data_Base As String
    Private _Emp_Id As Integer
    Private _ImprimePrefactura As Integer
    Private _Interfaz As Integer
    Private _ParallePort As String
    Private _PrefacturaTipoEntrega As Integer
    Private _PrinterName As String
    Private _PrintLocation As Integer
    Private _SMSBaudRate As String
    Private _SMSDataBits As String
    Private _SMSNotificacionFacturacion As Integer
    Private _SMSNotificacionPuntos As Integer
    Private _SMSPortName As String
    Private _SMSReadTimeOut As String
    Private _SMSWriteTimeOut As String
    Private _Suc_Id As Integer
    Private _URLTipoCambio As String
    Private _URLContabilidad As String
    Private _ImprimeInformacionCliente As Integer
    Private _ImprimeCodigoArticulo As Integer
    Private _ImpresoraEtiquetaCliente As String
    Private _ConfirmaImprimeReciboCxC As Integer
    Private _CPU As String
    Private _HostName As String
    Private _IP_Address As String
    Private _URLCoreAPI As String
    Private _VerificaPreFacturasCliente As Integer
    Private _InterfazFactura As Integer
    Private _RecalculaPrecioEntradaMercaderia As Integer
    Private _ActualizacionAutomatica As Integer
    Private _URLFEMaster As String
    Private _IdentificadorId As String
    Private _Data As DataSet
#End Region
#Region "Definicion de propiedades"


    Public Property IdentificadorId() As String
        Get
            Return _IdentificadorId
        End Get
        Set(ByVal Value As String)
            _IdentificadorId = Value
        End Set
    End Property



    Public Property MAC_Address() As String
        Get
            Return _MAC_Address
        End Get
        Set(ByVal Value As String)
            _MAC_Address = Value
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
    Public Property Caja_Id() As Integer
        Get
            Return _Caja_Id
        End Get
        Set(ByVal Value As Integer)
            _Caja_Id = Value
        End Set
    End Property
    Public Property ClienteDefault() As Integer
        Get
            Return _ClienteDefault
        End Get
        Set(ByVal Value As Integer)
            _ClienteDefault = Value
        End Set
    End Property
    Public Property FacturaContadoSolicitaCliente() As Integer
        Get
            Return _FacturaContadoSolicitaCliente
        End Get
        Set(ByVal Value As Integer)
            _FacturaContadoSolicitaCliente = Value
        End Set
    End Property
    Public Property ComPort() As String
        Get
            Return _ComPort
        End Get
        Set(ByVal Value As String)
            _ComPort = Value
        End Set
    End Property
    Public Property ConfirmaImpresionFactura() As Integer
        Get
            Return _ConfirmaImpresionFactura
        End Get
        Set(ByVal Value As Integer)
            _ConfirmaImpresionFactura = Value
        End Set
    End Property
    Public Property ContaDataBase() As String
        Get
            Return _ContaDataBase
        End Get
        Set(ByVal Value As String)
            _ContaDataBase = Value
        End Set
    End Property
    Public Property ContaPassword() As String
        Get
            Return _ContaPassword
        End Get
        Set(ByVal Value As String)
            _ContaPassword = Value
        End Set
    End Property
    Public Property ContaServer() As String
        Get
            Return _ContaServer
        End Get
        Set(ByVal Value As String)
            _ContaServer = Value
        End Set
    End Property
    Public Property ContaUser() As String
        Get
            Return _ContaUser
        End Get
        Set(ByVal Value As String)
            _ContaUser = Value
        End Set
    End Property
    Public Property Data_Base() As String
        Get
            Return _Data_Base
        End Get
        Set(ByVal Value As String)
            _Data_Base = Value
        End Set
    End Property
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    Public Property ImprimePrefactura() As Integer
        Get
            Return _ImprimePrefactura
        End Get
        Set(ByVal Value As Integer)
            _ImprimePrefactura = Value
        End Set
    End Property
    Public Property Interfaz() As Integer
        Get
            Return _Interfaz
        End Get
        Set(ByVal Value As Integer)
            _Interfaz = Value
        End Set
    End Property
    Public Property ParallePort() As String
        Get
            Return _ParallePort
        End Get
        Set(ByVal Value As String)
            _ParallePort = Value
        End Set
    End Property
    Public Property PrefacturaTipoEntrega() As Integer
        Get
            Return _PrefacturaTipoEntrega
        End Get
        Set(ByVal Value As Integer)
            _PrefacturaTipoEntrega = Value
        End Set
    End Property
    Public Property PrinterName() As String
        Get
            Return _PrinterName
        End Get
        Set(ByVal Value As String)
            _PrinterName = Value
        End Set
    End Property
    Public Property PrintLocation() As Integer
        Get
            Return _PrintLocation
        End Get
        Set(ByVal Value As Integer)
            _PrintLocation = Value
        End Set
    End Property
    Public Property SMSBaudRate() As String
        Get
            Return _SMSBaudRate
        End Get
        Set(ByVal Value As String)
            _SMSBaudRate = Value
        End Set
    End Property
    Public Property SMSDataBits() As String
        Get
            Return _SMSDataBits
        End Get
        Set(ByVal Value As String)
            _SMSDataBits = Value
        End Set
    End Property
    Public Property SMSNotificacionFacturacion() As Integer
        Get
            Return _SMSNotificacionFacturacion
        End Get
        Set(ByVal Value As Integer)
            _SMSNotificacionFacturacion = Value
        End Set
    End Property
    Public Property SMSNotificacionPuntos() As Integer
        Get
            Return _SMSNotificacionPuntos
        End Get
        Set(ByVal Value As Integer)
            _SMSNotificacionPuntos = Value
        End Set
    End Property
    Public Property SMSPortName() As String
        Get
            Return _SMSPortName
        End Get
        Set(ByVal Value As String)
            _SMSPortName = Value
        End Set
    End Property
    Public Property SMSReadTimeOut() As String
        Get
            Return _SMSReadTimeOut
        End Get
        Set(ByVal Value As String)
            _SMSReadTimeOut = Value
        End Set
    End Property
    Public Property SMSWriteTimeOut() As String
        Get
            Return _SMSWriteTimeOut
        End Get
        Set(ByVal Value As String)
            _SMSWriteTimeOut = Value
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
    Public Property URLTipoCambio() As String
        Get
            Return _URLTipoCambio
        End Get
        Set(ByVal Value As String)
            _URLTipoCambio = Value
        End Set
    End Property
    Public Property URLContabilidad() As String
        Get
            Return _URLContabilidad
        End Get
        Set(ByVal Value As String)
            _URLContabilidad = Value
        End Set
    End Property
    Public Property ImprimeInformacionCliente() As Integer
        Get
            Return _ImprimeInformacionCliente
        End Get
        Set(ByVal Value As Integer)
            _ImprimeInformacionCliente = Value
        End Set
    End Property
    Public Property ImprimeCodigoArticulo() As Integer
        Get
            Return _ImprimeCodigoArticulo
        End Get
        Set(ByVal Value As Integer)
            _ImprimeCodigoArticulo = Value
        End Set
    End Property
    Public Property ImpresoraEtiquetaCliente() As String
        Get
            Return _ImpresoraEtiquetaCliente
        End Get
        Set(ByVal Value As String)
            _ImpresoraEtiquetaCliente = Value
        End Set
    End Property
    Public Property ConfirmaImprimeReciboCxC() As Integer
        Get
            Return _ConfirmaImprimeReciboCxC
        End Get
        Set(ByVal Value As Integer)
            _ConfirmaImprimeReciboCxC = Value
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
    Public Property IP_Address() As String
        Get
            Return _IP_Address
        End Get
        Set(ByVal Value As String)
            _IP_Address = Value
        End Set
    End Property
    Public Property URLCoreAPI() As String
        Get
            Return _URLCoreAPI
        End Get
        Set(ByVal Value As String)
            _URLCoreAPI = Value
        End Set
    End Property
    Public Property VerificaPreFacturasCliente() As Integer
        Get
            Return _VerificaPreFacturasCliente
        End Get
        Set(ByVal Value As Integer)
            _VerificaPreFacturasCliente = Value
        End Set
    End Property
    Public Property InterfazFactura() As Integer
        Get
            Return _InterfazFactura
        End Get
        Set(ByVal Value As Integer)
            _InterfazFactura = Value
        End Set
    End Property
    Public Property RecalculaPrecioEntradaMercaderia() As Integer
        Get
            Return _RecalculaPrecioEntradaMercaderia
        End Get
        Set(ByVal Value As Integer)
            _RecalculaPrecioEntradaMercaderia = Value
        End Set
    End Property
    Public Property ActualizacionAutomatica() As Integer
        Get
            Return _ActualizacionAutomatica
        End Get
        Set(ByVal Value As Integer)
            _ActualizacionAutomatica = Value
        End Set
    End Property
    Public Property URLFEMaster As String
        Get
            Return _URLFEMaster
        End Get
        Set(value As String)
            _URLFEMaster = value
        End Set
    End Property
    Public Property PV_Width As Integer
    Public Property PV_Height As Integer
    Public Property URLSD As String

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
    Public Sub New()
        MyBase.New()
        Inicializa()
    End Sub
    Public Sub New(ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _MAC_Address = ""
        _Nombre = ""
        _Caja_Id = 0
        _ClienteDefault = 0
        _FacturaContadoSolicitaCliente = 0
        _ComPort = ""
        _ConfirmaImpresionFactura = 0
        _ContaDataBase = ""
        _ContaPassword = ""
        _ContaServer = ""
        _ContaUser = ""
        _Data_Base = ""
        _Emp_Id = 0
        _ImprimePrefactura = 0
        _Interfaz = 0
        _ParallePort = ""
        _PrefacturaTipoEntrega = 0
        _PrinterName = ""
        _PrintLocation = 0
        _SMSBaudRate = ""
        _SMSDataBits = ""
        _SMSNotificacionFacturacion = 0
        _SMSNotificacionPuntos = 0
        _SMSPortName = ""
        _SMSReadTimeOut = ""
        _SMSWriteTimeOut = ""
        _Suc_Id = 0
        _URLTipoCambio = ""
        _URLContabilidad = ""
        _ImprimeInformacionCliente = 0
        _ImprimeCodigoArticulo = 0
        _ImpresoraEtiquetaCliente = ""
        _ConfirmaImprimeReciboCxC = 0
        _URLCoreAPI = ""
        _VerificaPreFacturasCliente = 0
        _InterfazFactura = 1
        _RecalculaPrecioEntradaMercaderia = 0
        _ActualizacionAutomatica = 0
        _URLFEMaster = String.Empty
        PV_Width = -1
        PV_Height = -1
        URLSD = String.Empty
        _IdentificadorId = String.Empty

        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into MaquinaConfiguracion( MAC_Address , Nombre" &
                    " , Caja_Id , ClienteDefault" &
                    " , ComPort , ConfirmaImpresionFactura" &
                    " , ContaDataBase , ContaPassword" &
                    " , ContaServer , ContaUser" &
                    " , Data_Base , Emp_Id" &
                    " , ImprimePrefactura , Interfaz" &
                    " , ParallePort , PrefacturaTipoEntrega" &
                    " , PrinterName , PrintLocation" &
                    " , SMSBaudRate , SMSDataBits" &
                    " , SMSNotificacionFacturacion , SMSNotificacionPuntos" &
                    " , SMSPortName , SMSReadTimeOut" &
                    " , SMSWriteTimeOut , Suc_Id" &
                    " , URLTipoCambio , URLContabilidad" &
                    " , ImprimeInformacionCliente , ImprimeCodigoArticulo" &
                    " , ImpresoraEtiquetaCliente , ConfirmaImprimeReciboCxC" &
                    " , FacturaContadoSolicitaCliente, URLCoreAPI, VerificaPreFacturasCliente" &
                    " , InterfazFactura , RecalculaPrecioEntradaMercaderia" &
                    " )" &
                    " Values ( '" & _MAC_Address & "'" & ",'" & _Nombre & "'" &
                    "," & _Caja_Id.ToString() & "," & _ClienteDefault.ToString() &
                    ",'" & _ComPort & "'" & "," & _ConfirmaImpresionFactura.ToString() &
                    ",'" & _ContaDataBase & "'" & ",'" & _ContaPassword & "'" &
                    ",'" & _ContaServer & "'" & ",'" & _ContaUser & "'" &
                    ",'" & _Data_Base & "'" & "," & _Emp_Id.ToString() &
                    "," & _ImprimePrefactura.ToString() & "," & _Interfaz.ToString() &
                    ",'" & _ParallePort & "'" & "," & _PrefacturaTipoEntrega.ToString() &
                    ",'" & _PrinterName & "'" & "," & _PrintLocation.ToString() &
                    ",'" & _SMSBaudRate & "'" & ",'" & _SMSDataBits & "'" &
                    "," & _SMSNotificacionFacturacion.ToString() & "," & _SMSNotificacionPuntos.ToString() &
                    ",'" & _SMSPortName & "'" & ",'" & _SMSReadTimeOut & "'" &
                    ",'" & _SMSWriteTimeOut & "'" & "," & _Suc_Id.ToString() &
                    ",'" & _URLTipoCambio & "'" & ",'" & _URLContabilidad & "'" &
                    "," & _ImprimeInformacionCliente.ToString() & "," & _ImprimeCodigoArticulo.ToString() &
                    ",'" & _ImpresoraEtiquetaCliente & "'" & "," & _ConfirmaImprimeReciboCxC.ToString() &
                    "," & _FacturaContadoSolicitaCliente.ToString() & ",'" & _URLCoreAPI &
                    "'," & _VerificaPreFacturasCliente & "," & _InterfazFactura & "," & _RecalculaPrecioEntradaMercaderia.ToString() & ")"

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

            Query = "Delete MaquinaConfiguracion" & _
                    " Where     MAC_Address='" & _MAC_Address & "'"

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

            Query = " Update dbo.MaquinaConfiguracion " &
                    " SET   Nombre='" & _Nombre & "' " & "," &
                    " Caja_Id=" & _Caja_Id.ToString() & "," &
                    " ClienteDefault=" & _ClienteDefault & "," &
                    " FacturaContadoSolicitaCliente=" & _FacturaContadoSolicitaCliente & "," &
                    " ComPort='" & _ComPort & "'" & "," &
                    " ConfirmaImpresionFactura=" & _ConfirmaImpresionFactura & "," &
                    " ContaDataBase='" & _ContaDataBase & "'" & "," &
                    " ContaPassword='" & _ContaPassword & "'" & "," &
                    " ContaServer='" & _ContaServer & "'" & "," &
                    " ContaUser='" & _ContaUser & "'" & "," &
                    " Data_Base='" & _Data_Base & "'" & "," &
                    " Emp_Id=" & _Emp_Id & "," &
                    " ImprimePrefactura=" & _ImprimePrefactura & "," &
                    " Interfaz=" & _Interfaz & "," &
                    " ParallePort='" & _ParallePort & "'" & "," &
                    " PrefacturaTipoEntrega=" & _PrefacturaTipoEntrega & "," &
                    " PrinterName='" & _PrinterName & "'" & "," &
                    " PrintLocation=" & _PrintLocation & "," &
                    " SMSBaudRate='" & _SMSBaudRate & "'" & "," &
                    " SMSDataBits='" & _SMSDataBits & "'" & "," &
                    " SMSNotificacionFacturacion=" & _SMSNotificacionFacturacion & "," &
                    " SMSNotificacionPuntos=" & _SMSNotificacionPuntos & "," &
                    " SMSPortName='" & _SMSPortName & "'" & "," &
                    " SMSReadTimeOut='" & _SMSReadTimeOut & "'" & "," &
                    " SMSWriteTimeOut='" & _SMSWriteTimeOut & "'" & "," &
                    " Suc_Id=" & _Suc_Id & "," &
                    " URLTipoCambio='" & _URLTipoCambio & "'" & "," &
                    " URLCoreAPI = '" & _URLCoreAPI & "'," &
                    " VerificaPreFacturasCliente=" & _VerificaPreFacturasCliente & "," &
                    " InterfazFactura=" & _InterfazFactura & "," &
                    " URLContabilidad='" & _URLContabilidad & "'" & "," &
                    " ImprimeInformacionCliente=" & _ImprimeInformacionCliente & "," &
                    " ImprimeCodigoArticulo=" & _ImprimeCodigoArticulo & "," &
                    " ImpresoraEtiquetaCliente='" & _ImpresoraEtiquetaCliente & "'" & "," &
                    " ConfirmaImprimeReciboCxC=" & _ConfirmaImprimeReciboCxC & "," &
                    " RecalculaPrecioEntradaMercaderia=" & _RecalculaPrecioEntradaMercaderia &
                    " Where     MAC_Address='" & _MAC_Address & "'"

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

            Query = "select * From MaquinaConfiguracion" & _
                    " Where     MAC_Address='" & _MAC_Address & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _MAC_Address = Tabla.Rows(0).Item("MAC_Address")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Caja_Id = Tabla.Rows(0).Item("Caja_Id")
                _ClienteDefault = Tabla.Rows(0).Item("ClienteDefault")
                _FacturaContadoSolicitaCliente = Tabla.Rows(0).Item("FacturaContadoSolicitaCliente")
                _ComPort = Tabla.Rows(0).Item("ComPort")
                _ConfirmaImpresionFactura = Tabla.Rows(0).Item("ConfirmaImpresionFactura")
                _ContaDataBase = Tabla.Rows(0).Item("ContaDataBase")
                _ContaPassword = Tabla.Rows(0).Item("ContaPassword")
                _ContaServer = Tabla.Rows(0).Item("ContaServer")
                _ContaUser = Tabla.Rows(0).Item("ContaUser")
                _Data_Base = Tabla.Rows(0).Item("Data_Base")
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _ImprimePrefactura = Tabla.Rows(0).Item("ImprimePrefactura")
                _Interfaz = Tabla.Rows(0).Item("Interfaz")
                _ParallePort = Tabla.Rows(0).Item("ParallePort")
                _PrefacturaTipoEntrega = Tabla.Rows(0).Item("PrefacturaTipoEntrega")
                _PrinterName = Tabla.Rows(0).Item("PrinterName")
                _PrintLocation = Tabla.Rows(0).Item("PrintLocation")
                _SMSBaudRate = Tabla.Rows(0).Item("SMSBaudRate")
                _SMSDataBits = Tabla.Rows(0).Item("SMSDataBits")
                _SMSNotificacionFacturacion = Tabla.Rows(0).Item("SMSNotificacionFacturacion")
                _SMSNotificacionPuntos = Tabla.Rows(0).Item("SMSNotificacionPuntos")
                _SMSPortName = Tabla.Rows(0).Item("SMSPortName")
                _SMSReadTimeOut = Tabla.Rows(0).Item("SMSReadTimeOut")
                _SMSWriteTimeOut = Tabla.Rows(0).Item("SMSWriteTimeOut")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _URLTipoCambio = Tabla.Rows(0).Item("URLTipoCambio")
                _URLContabilidad = Tabla.Rows(0).Item("URLContabilidad")
                _URLCoreAPI = Tabla.Rows(0).Item("URLCoreAPI")
                _ImprimeInformacionCliente = Tabla.Rows(0).Item("ImprimeInformacionCliente")
                _ImprimeCodigoArticulo = Tabla.Rows(0).Item("ImprimeCodigoArticulo")
                _ImpresoraEtiquetaCliente = Tabla.Rows(0).Item("ImpresoraEtiquetaCliente")
                _ConfirmaImprimeReciboCxC = Tabla.Rows(0).Item("ConfirmaImprimeReciboCxC")
                _VerificaPreFacturasCliente = Tabla.Rows(0).Item("VerificaPreFacturasCliente")
                _InterfazFactura = Tabla.Rows(0).Item("InterfazFactura")
                _RecalculaPrecioEntradaMercaderia = Tabla.Rows(0).Item("RecalculaPrecioEntradaMercaderia")
                _ActualizacionAutomatica = Tabla.Rows(0).Item("ActualizacionAutomatica")
                _URLFEMaster = Tabla.Rows(0).Item("URLFEMaster")
                _IdentificadorId = Tabla.Rows(0).Item("Identificador_Id")

                Try
                    PV_Width = Tabla.Rows(0).Item("PV_Width")
                Catch ex As Exception
                    PV_Width = -1
                End Try
                Try
                    PV_Height = Tabla.Rows(0).Item("PV_Height")
                Catch ex As Exception
                    PV_Height = -1
                End Try
                Try
                    URLSD = Tabla.Rows(0).Item("URLSD")
                Catch ex As Exception
                    URLSD = String.Empty
                End Try



                _CPU = GetMAC()
                _HostName = GetHostName()
                _IP_Address = GetIPV4()
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

            Query = "select * From MaquinaConfiguracion"

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

            Query = "select MaquinaConfiguracion_Id as Numero, Nombre From MaquinaConfiguracion"

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