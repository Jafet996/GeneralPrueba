Public Class TCxCMovimientoAplica
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Tipo_Id As Integer
    Private _Mov_Id As Long
    Private _Aplica_Id As Integer
    Private _TipoAplica_Id As Integer
    Private _MovAplica_Id As Long
    Private _Fecha As Datetime
    Private _Monto As Double
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCxCMovimientoAplica
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
    Public Property Aplica_Id() As Integer
        Get
            Return _Aplica_Id
        End Get
        Set(ByVal Value As Integer)
            _Aplica_Id = Value
        End Set
    End Property
    Public Property TipoAplica_Id() As Integer
        Get
            Return _TipoAplica_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoAplica_Id = Value
        End Set
    End Property
    Public Property MovAplica_Id() As Long
        Get
            Return _MovAplica_Id
        End Get
        Set(ByVal Value As Long)
            _MovAplica_Id = Value
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
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal Value As Double)
            _Monto = Value
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
        _Emp_Id = 0
        _Tipo_Id = 0
        _Mov_Id = 0
        _Aplica_Id = 0
        _TipoAplica_Id = 0
        _MovAplica_Id = 0
        _Fecha = CDate("1900/01/01")
        _Monto = 0.0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Aplica_Id = _Aplica_Id
                .TipoAplica_Id = _TipoAplica_Id
                .MovAplica_Id = _MovAplica_Id
                .Fecha = _Fecha
                .Monto = _Monto
            End With

            _Resultado = _SDWCF.CxCMovimientoAplicaMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Aplica_Id = _Aplica_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoAplicaMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Aplica_Id = _Aplica_Id
                .TipoAplica_Id = _TipoAplica_Id
                .MovAplica_Id = _MovAplica_Id
                .Fecha = _Fecha
                .Monto = _Monto
            End With

            _Resultado = _SDWCF.CxCMovimientoAplicaMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
                .Aplica_Id = _Aplica_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoAplicaMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Tipo_Id = _Resultado.Datos.Rows(0).Item("Tipo_Id")
                _Mov_Id = _Resultado.Datos.Rows(0).Item("Mov_Id")
                _Aplica_Id = _Resultado.Datos.Rows(0).Item("Aplica_Id")
                _TipoAplica_Id = _Resultado.Datos.Rows(0).Item("TipoAplica_Id")
                _MovAplica_Id = _Resultado.Datos.Rows(0).Item("MovAplica_Id")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _Monto = _Resultado.Datos.Rows(0).Item("Monto")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.CxCMovimientoAplicaMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.CxCMovimientoAplicaMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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
    Public Overrides Function ListMant(pCriterio As String) As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoAplicaMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Tipo_Id = _Tipo_Id
                .Mov_Id = _Mov_Id
            End With

            _Resultado = _SDWCF.CxCMovimientoAplicaMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Aplica_Id = _Resultado.Datos.Rows(0).Item("Aplica_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class