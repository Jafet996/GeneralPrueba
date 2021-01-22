Public Class TMaquinaConfiguracion
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _MAC_Address As String
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
    Private _FechaIngreso As Datetime
    Private _Data As DataSet

#End Region
#Region "Definicion de propiedades"

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
    Public Property FechaIngreso() As Datetime
        Get
            Return _FechaIngreso
        End Get
        Set(ByVal Value As Datetime)
            _FechaIngreso = Value
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
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into MaquinaConfiguracion( MAC_Address , Nombre" & _
                    " , Caja_Id , ClienteDefault" & _
                    " , ComPort , ConfirmaImpresionFactura" & _
                    " , Emp_Id , FacturaContadoSolicitaCliente" & _
                    " , ImprimeCodigoArticulo , ImprimePrefactura" & _
                    " , Interfaz , ParallePort" & _
                    " , PrefacturaTipoEntrega , PrinterName" & _
                    " , PrintLocation" & _
                    " , URLTipoCambio , FechaIngreso" & _
                    " )" & _
                    " Values ( '" & _MAC_Address & "'" & ",'" & _Nombre & "'" & _
                    "," & _Caja_Id.ToString & "," & _ClienteDefault.ToString & _
                    ",'" & _ComPort & "'" & "," & _ConfirmaImpresionFactura.ToString & _
                    "," & _Emp_Id.ToString & "," & _FacturaContadoSolicitaCliente.ToString & _
                    "," & _ImprimeCodigoArticulo.ToString & "," & _ImprimePrefactura.ToString & _
                    "," & _Interfaz.ToString & ",'" & _ParallePort & "'" & _
                    "," & _PrefacturaTipoEntrega.ToString & ",'" & _PrinterName & "'" & _
                    "," & _PrintLocation.ToString & _
                    ",'" & _URLTipoCambio & "'" & ",GETDATE()" & _
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

            Query = "Delete MaquinaConfiguracion" & _
                    " Where MAC_Address = '" & _MAC_Address & "'"

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

            Query = " Update dbo.MaquinaConfiguracion " & _
                    " SET   Nombre='" & _Nombre & "' " & "," & _
                    " Caja_Id=" & _Caja_Id & "," & _
                    " ClienteDefault=" & _ClienteDefault & "," & _
                    " ComPort='" & _ComPort & "'" & "," & _
                    " ConfirmaImpresionFactura=" & _ConfirmaImpresionFactura & "," & _
                    " Emp_Id=" & _Emp_Id & "," & _
                    " FacturaContadoSolicitaCliente=" & _FacturaContadoSolicitaCliente & "," & _
                    " ImprimeCodigoArticulo=" & _ImprimeCodigoArticulo & "," & _
                    " ImprimePrefactura=" & _ImprimePrefactura & "," & _
                    " Interfaz=" & _Interfaz & "," & _
                    " ParallePort='" & _ParallePort & "'" & "," & _
                    " PrefacturaTipoEntrega=" & _PrefacturaTipoEntrega & "," & _
                    " PrinterName='" & _PrinterName & "'" & "," & _
                    " PrintLocation=" & _PrintLocation & "," & _
                    " URLTipoCambio='" & _URLTipoCambio & "'" & "," & _
                    " Where MAC_Address = '" & _MAC_Address & "'"

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
                    " Where MAC_Address = '" & _MAC_Address & "'"

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
    Public Overrides Function LoadComboBox() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select MaquinaConfiguracion_Id as Numero, Nombre From MaquinaConfiguracion"

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
        Return ""
    End Function
    Public Overrides Function NextOne() As String
        Return ""
    End Function
#End Region
End Class
