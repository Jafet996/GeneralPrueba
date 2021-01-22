Public Class TAuxAsientoDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Asiento_Id As Long
    Private _Linea_Id As Integer
    Private _Fecha As Datetime
    Private _Moneda As Char
    Private _CC_Id As Integer
    Private _Cuenta_Id As String
    Private _Tipo As Char
    Private _Monto As Double
    Private _MontoDolares As Double
    Private _TipoCambio As Double
    Private _Referencia As String
    Private _Descripcion As String
    Private _Data As DataSet
    Private _SDL As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTAuxAsientoDetalle
    Private _Resultado As New SDFinancial.TResultado
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
    Public Property Asiento_Id() As Long
        Get
            Return _Asiento_Id
        End Get
        Set(ByVal Value As Long)
            _Asiento_Id = Value
        End Set
    End Property
    Public Property Linea_Id() As Integer
        Get
            Return _Linea_Id
        End Get
        Set(ByVal Value As Integer)
            _Linea_Id = Value
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
    Public Property Moneda() As Char
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As Char)
            _Moneda = Value
        End Set
    End Property
    Public Property CC_Id() As Integer
        Get
            Return _CC_Id
        End Get
        Set(ByVal Value As Integer)
            _CC_Id = Value
        End Set
    End Property
    Public Property Cuenta_Id() As String
        Get
            Return _Cuenta_Id
        End Get
        Set(ByVal Value As String)
            _Cuenta_Id = Value
        End Set
    End Property
    Public Property Tipo() As Char
        Get
            Return _Tipo
        End Get
        Set(ByVal Value As Char)
            _Tipo = Value
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
    Public Property MontoDolares() As Double
        Get
            Return _MontoDolares
        End Get
        Set(ByVal Value As Double)
            _MontoDolares = Value
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
    Public Property Referencia() As String
        Get
            Return _Referencia
        End Get
        Set(ByVal Value As String)
            _Referencia = Value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
        End Set
    End Property
    Public ReadOnly Property Data() As DataSet
        Get
            Return _Data
        End Get
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
        'If Not CajaInfo Is Nothing AndAlso InfoMaquina.URLContabilidad <> "" Then
        _SDL.Url = InfoMaquina.URLContabilidad
        'Else
        '    _SDL.Url = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegURLContabilidad, String.Empty)
        'End If
        _Emp_Id = 0
        _Asiento_Id = 0
        _Linea_Id = 0
        _Fecha = CDate("1900/01/01")
        _Moneda = ""
        _CC_Id = 0
        _Cuenta_Id = ""
        _Tipo = ""
        _Monto = 0.0
        _MontoDolares = 0.0
        _TipoCambio = 0.0
        _Referencia = ""
        _Descripcion = ""
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
                .Linea_Id = _Linea_Id
                .Fecha = _Fecha
                .Moneda = _Moneda
                .CC_Id = _CC_Id
                .Cuenta_Id = _Cuenta_Id
                .Tipo = _Tipo
                .Monto = _Monto
                .MontoDolares = _MontoDolares
                .TipoCambio = _TipoCambio
                .Referencia = _Referencia
                .Descripcion = _Descripcion
            End With

            _Resultado = _SDL.AuxAsientoDetalleMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
                .Linea_Id = _Linea_Id
            End With

            _Resultado = _SDL.AuxAsientoDetalleMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
                .Linea_Id = _Linea_Id
                .Fecha = _Fecha
                .Moneda = _Moneda
                .CC_Id = _CC_Id
                .Cuenta_Id = _Cuenta_Id
                .Tipo = _Tipo
                .Monto = _Monto
                .MontoDolares = _MontoDolares
                .TipoCambio = _TipoCambio
                .Referencia = _Referencia
                .Descripcion = _Descripcion
            End With

            _Resultado = _SDL.AuxAsientoDetalleMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
                .Linea_Id = _Linea_Id
            End With

            _Resultado = _SDL.AuxAsientoDetalleMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Asiento_Id = _Resultado.Datos.Rows(0).Item("Asiento_Id")
                _Linea_Id = _Resultado.Datos.Rows(0).Item("Linea_Id")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _Moneda = _Resultado.Datos.Rows(0).Item("Moneda")
                _CC_Id = _Resultado.Datos.Rows(0).Item("CC_Id")
                _Cuenta_Id = _Resultado.Datos.Rows(0).Item("Cuenta_Id")
                _Tipo = _Resultado.Datos.Rows(0).Item("Tipo")
                _Monto = _Resultado.Datos.Rows(0).Item("Monto")
                _MontoDolares = _Resultado.Datos.Rows(0).Item("MontoDolares")
                _TipoCambio = _Resultado.Datos.Rows(0).Item("TipoCambio")
                _Referencia = _Resultado.Datos.Rows(0).Item("Referencia")
                _Descripcion = _Resultado.Datos.Rows(0).Item("Descripcion")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDL.AuxAsientoDetalleMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Data.Tables.Contains(_Resultado.Datos.TableName) Then
                Data.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Data.Tables.Add(_Resultado.Datos)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function LoadComboBox(pCombo As Windows.Forms.ComboBox) As String
        Try
            _Resultado = _SDL.AuxAsientoDetalleMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
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
#End Region
End Class