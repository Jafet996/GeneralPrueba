Public Class TMaquinaConfiguracion
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _MAC_Address as String
    Private _Nombre As String
    Private _Caja_Id As Integer
    Private _ClienteDefault As Integer
    Private _ComPort As String
    Private _ConfirmaImpresionFactura As Integer
    Private _Emp_Id As Integer
    Private _FacturaContadoSolicitaCliente As Integer
    Private _ImprimeCodigoArticulo As Integer
    Private _ImprimePrefactura As Integer
    Private _Interfaz As Integer
    Private _ParallePort As String
    Private _PrefacturaTipoEntrega As Integer
    Private _PrinterName As String
    Private _PrintLocation As Integer
    Private _URLTipoCambio As String
    Private _FechaIngreso As DateTime
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTMaquinaConfiguracion
    Private _Resultado As New SDFinancial.TResultado
    Private _CPU As String
    Private _HostName As String
    Private _IP_Address As String
    Private _Url As String
    Private _Data_Base As String
    Private _Identificaion_Id As String

#End Region
#Region "Definicion de propiedades"
    Public Property Identificacion_Id() As String
        Get
            Return _Identificaion_Id
        End Get
        Set(ByVal Value As String)
            _Identificaion_Id = Value
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
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
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
    Public Property ImprimeCodigoArticulo() As Integer
        Get
            Return _ImprimeCodigoArticulo
        End Get
        Set(ByVal Value As Integer)
            _ImprimeCodigoArticulo = Value
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
    Public Property URLTipoCambio() As String
        Get
            Return _URLTipoCambio
        End Get
        Set(ByVal Value As String)
            _URLTipoCambio = Value
        End Set
    End Property
    Public Property FechaIngreso() As DateTime
        Get
            Return _FechaIngreso
        End Get
        Set(ByVal Value As DateTime)
            _FechaIngreso = Value
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
    Public Property Url As String
        Get
            Return _Url
        End Get
        Set(value As String)
            _Url = value
        End Set
    End Property
    Public Property Data_Base As String
        Get
            Return _Data_Base
        End Get
        Set(value As String)
            _Data_Base = value
        End Set
    End Property
    Public ReadOnly Property RowsAffected As Long
        Get
            Return _Resultado.RowsAffected
        End Get
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        MyBase.New()
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.Url <> "" Then
            _SDWCF.Url = InfoMaquina.Url
        Else
            _SDWCF.Url = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegUrl, String.Empty)
        End If
        _MAC_Address = ""
        _Nombre = ""
        _Caja_Id = 0
        _ClienteDefault = 0
        _ComPort = ""
        _ConfirmaImpresionFactura = 0
        _Emp_Id = 0
        _FacturaContadoSolicitaCliente = 0
        _ImprimeCodigoArticulo = 0
        _ImprimePrefactura = 0
        _Interfaz = 0
        _ParallePort = ""
        _PrefacturaTipoEntrega = 0
        _PrinterName = ""
        _PrintLocation = 0
        _URLTipoCambio = ""
        _FechaIngreso = CDate("1900/01/01")
        _Data_Base = ""
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .MAC_Address = _MAC_Address
                .Nombre = _Nombre
                .Caja_Id = _Caja_Id
                .ClienteDefault = _ClienteDefault
                .ComPort = _ComPort
                .ConfirmaImpresionFactura = _ConfirmaImpresionFactura
                .Emp_Id = _Emp_Id
                .FacturaContadoSolicitaCliente = _FacturaContadoSolicitaCliente
                .ImprimeCodigoArticulo = _ImprimeCodigoArticulo
                .ImprimePrefactura = _ImprimePrefactura
                .Interfaz = _Interfaz
                .ParallePort = _ParallePort
                .PrefacturaTipoEntrega = _PrefacturaTipoEntrega
                .PrinterName = _PrinterName
                .PrintLocation = _PrintLocation
                .URLTipoCambio = _URLTipoCambio
            End With

            _Resultado = _SDWCF.MaquinaConfiguracionMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function Delete() As String
        Try
            With _DTabla
                .MAC_Address = _MAC_Address
            End With

            _Resultado = _SDWCF.MaquinaConfiguracionMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function Modify() As String
        Try
            With _DTabla
                .MAC_Address = _MAC_Address
                .Nombre = _Nombre
                .Caja_Id = _Caja_Id
                .ClienteDefault = _ClienteDefault
                .ComPort = _ComPort
                .ConfirmaImpresionFactura = _ConfirmaImpresionFactura
                .Emp_Id = _Emp_Id
                .FacturaContadoSolicitaCliente = _FacturaContadoSolicitaCliente
                .ImprimeCodigoArticulo = _ImprimeCodigoArticulo
                .ImprimePrefactura = _ImprimePrefactura
                .Interfaz = _Interfaz
                .ParallePort = _ParallePort
                .PrefacturaTipoEntrega = _PrefacturaTipoEntrega
                .PrinterName = _PrinterName
                .PrintLocation = _PrintLocation
                .URLTipoCambio = _URLTipoCambio
            End With

            _Resultado = _SDWCF.MaquinaConfiguracionMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function ListKey() As String
        Try
            With _DTabla
                .MAC_Address = _MAC_Address
            End With

            _Resultado = _SDWCF.MaquinaConfiguracionMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _MAC_Address = Fila("MAC_Address")

                    _Nombre = Fila("Nombre")
                    _Caja_Id = Fila("Caja_Id")
                    _ClienteDefault = Fila("ClienteDefault")
                    _ComPort = Fila("ComPort")
                    _ConfirmaImpresionFactura = Fila("ConfirmaImpresionFactura")
                    _Emp_Id = Fila("Emp_Id")
                    _FacturaContadoSolicitaCliente = Fila("FacturaContadoSolicitaCliente")
                    _ImprimeCodigoArticulo = Fila("ImprimeCodigoArticulo")
                    _ImprimePrefactura = Fila("ImprimePrefactura")
                    _Interfaz = Fila("Interfaz")
                    _ParallePort = Fila("ParallePort")
                    _PrefacturaTipoEntrega = Fila("PrefacturaTipoEntrega")
                    _PrinterName = Fila("PrinterName")
                    _PrintLocation = Fila("PrintLocation")
                    _URLTipoCambio = Fila("URLTipoCambio")
                    _FechaIngreso = Fila("FechaIngreso")
                    _CPU = GetMAC()
                    _IP_Address = GetIPV4()
                    _HostName = GetHostName()
                    _Data_Base = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegDataBase, "SDHOSPITAL")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.MaquinaConfiguracionMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function LoadComboBox(pCombo As Windows.Forms.ComboBox) As String
        Try
            _Resultado = _SDWCF.MaquinaConfiguracionMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = _Resultado.Datos
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function ListMant(pCriterio As String) As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
            End With

            _Resultado = _SDWCF.MaquinaConfiguracionMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function NextOne() As String
        Return String.Empty
    End Function
#End Region
End Class
