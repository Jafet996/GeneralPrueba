Public Class TModulo
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Modulo_Id As Integer
    Private _Nombre As String
    Private _Major As Integer
    Private _Menor As Integer
    Private _Bug As Integer
    Private _Build As Integer
    Private _CodigoResultado As Integer
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTModulo
    Private _Resultado As New SDFinancial.TResultado
#End Region
#Region "Definicion de propiedades"
    Public Property Modulo_Id() As Integer
        Get
            Return _Modulo_Id
        End Get
        Set(ByVal Value As Integer)
            _Modulo_Id = Value
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
    Public Property Major() As Integer
        Get
            Return _Major
        End Get
        Set(ByVal Value As Integer)
            _Major = Value
        End Set
    End Property
    Public Property Menor() As Integer
        Get
            Return _Menor
        End Get
        Set(ByVal Value As Integer)
            _Menor = Value
        End Set
    End Property
    Public Property Bug() As Integer
        Get
            Return _Bug
        End Get
        Set(ByVal Value As Integer)
            _Bug = Value
        End Set
    End Property
    Public Property Build() As Integer
        Get
            Return _Build
        End Get
        Set(ByVal Value As Integer)
            _Build = Value
        End Set
    End Property
    Public Property CodigoResultado() As Integer
        Get
            Return _CodigoResultado
        End Get
        Set(ByVal Value As Integer)
            _CodigoResultado = Value
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
        _Modulo_Id = 0
        _Nombre = ""
        _Major = 0
        _Menor = 0
        _Bug = 0
        _Build = 0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Modulo_Id = _Modulo_Id
                .Nombre = _Nombre
                .Major = _Major
                .Menor = _Menor
                .Bug = _Bug
                .Build = _Build
            End With

            _Resultado = _SDWCF.ModuloMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Modulo_Id = _Modulo_Id
            End With

            _Resultado = _SDWCF.ModuloMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Modulo_Id = _Modulo_Id
                .Nombre = _Nombre
                .Major = _Major
                .Menor = _Menor
                .Bug = _Bug
                .Build = _Build
            End With

            _Resultado = _SDWCF.ModuloMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Modulo_Id = _Modulo_Id
            End With

            _Resultado = _SDWCF.ModuloMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Modulo_Id = Fila("Modulo_Id")
                    _Nombre = Fila("Nombre")
                    _Major = Fila("Major")
                    _Menor = Fila("Menor")
                    _Bug = Fila("Bug")
                    _Build = Fila("Build")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.ModuloMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.ModuloMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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
            _Resultado = _SDWCF.ModuloMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
            _Resultado = _SDWCF.ModuloMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _Modulo_Id = Fila("Modulo_Id")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function VerificaVersion() As String
        Dim Query As String

        Try
            Query = "exec VerificaVersion " & _Modulo_Id.ToString() & "," & _Major.ToString() & "," & _Menor.ToString() & "," & _Bug.ToString() & "," & _Build.ToString()

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                For Each Fila As DataRow In _Resultado.Datos.Rows
                    _CodigoResultado = Fila("Resultado")
                Next
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class
