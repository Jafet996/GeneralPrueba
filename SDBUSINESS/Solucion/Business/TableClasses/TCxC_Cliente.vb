Public Class TCxC_Cliente
    Inherits WCF_BaseClass

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Cliente_Id As Integer
    Private _Nombre As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _Email As String
    Private _Direccion As String
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Saldo As Double
    Private _DiasCredito As Integer
    Private _PorcMora As Double
    Private _DiasGraciaMora As Integer
    Private _AplicaMora As Integer
    Private _Activo As Integer
    Private _UltimaModificacion As Datetime
    Private _SDL As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCliente
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
    Public Property Telefono1() As String
        Get
            Return _Telefono1
        End Get
        Set(ByVal Value As String)
            _Telefono1 = Value
        End Set
    End Property
    Public Property Telefono2() As String
        Get
            Return _Telefono2
        End Get
        Set(ByVal Value As String)
            _Telefono2 = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal Value As String)
            _Email = Value
        End Set
    End Property
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal Value As String)
            _Direccion = Value
        End Set
    End Property
    Public Property Debitos() As Double
        Get
            Return _Debitos
        End Get
        Set(ByVal Value As Double)
            _Debitos = Value
        End Set
    End Property
    Public Property Creditos() As Double
        Get
            Return _Creditos
        End Get
        Set(ByVal Value As Double)
            _Creditos = Value
        End Set
    End Property
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property
    Public Property DiasCredito() As Integer
        Get
            Return _DiasCredito
        End Get
        Set(ByVal Value As Integer)
            _DiasCredito = Value
        End Set
    End Property
    Public Property PorcMora() As Double
        Get
            Return _PorcMora
        End Get
        Set(ByVal Value As Double)
            _PorcMora = Value
        End Set
    End Property
    Public Property DiasGraciaMora() As Integer
        Get
            Return _DiasGraciaMora
        End Get
        Set(ByVal Value As Integer)
            _DiasGraciaMora = Value
        End Set
    End Property
    Public Property AplicaMora() As Integer
        Get
            Return _AplicaMora
        End Get
        Set(ByVal Value As Integer)
            _AplicaMora = Value
        End Set
    End Property
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
        End Set
    End Property
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
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
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.URLContabilidad <> "" Then
            _SDL.Url = InfoMaquina.URLContabilidad
        End If
        _Emp_Id = 0
        _Cliente_Id = 0
        _Nombre = ""
        _Telefono1 = ""
        _Telefono2 = ""
        _Email = ""
        _Direccion = ""
        _Debitos = 0.0
        _Creditos = 0.0
        _Saldo = 0.0
        _DiasCredito = 0
        _PorcMora = 0.0
        _DiasGraciaMora = 0
        _AplicaMora = 0
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Cliente_Id = _Cliente_Id
                .Nombre = _Nombre
                .Telefono1 = _Telefono1
                .Telefono2 = _Telefono2
                .Email = _Email
                .Direccion = _Direccion
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Saldo = _Saldo
                .DiasCredito = _DiasCredito
                .PorcMora = _PorcMora
                .DiasGraciaMora = _DiasGraciaMora
                .AplicaMora = _AplicaMora
                .Activo = _Activo
            End With

            _Resultado = _SDL.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Cliente_Id = _Cliente_Id
            End With

            _Resultado = _SDL.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Cliente_Id = _Cliente_Id
                .Nombre = _Nombre
                .Telefono1 = _Telefono1
                .Telefono2 = _Telefono2
                .Email = _Email
                .Direccion = _Direccion
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Saldo = _Saldo
                .DiasCredito = _DiasCredito
                .PorcMora = _PorcMora
                .DiasGraciaMora = _DiasGraciaMora
                .AplicaMora = _AplicaMora
                .Activo = _Activo
            End With

            _Resultado = _SDL.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Cliente_Id = _Cliente_Id
            End With

            _Resultado = _SDL.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Cliente_Id = _Resultado.Datos.Rows(0).Item("Cliente_Id")
                _Nombre = _Resultado.Datos.Rows(0).Item("Nombre")
                _Telefono1 = _Resultado.Datos.Rows(0).Item("Telefono1")
                _Telefono2 = _Resultado.Datos.Rows(0).Item("Telefono2")
                _Email = _Resultado.Datos.Rows(0).Item("Email")
                _Direccion = _Resultado.Datos.Rows(0).Item("Direccion")
                _Debitos = _Resultado.Datos.Rows(0).Item("Debitos")
                _Creditos = _Resultado.Datos.Rows(0).Item("Creditos")
                _Saldo = _Resultado.Datos.Rows(0).Item("Saldo")
                _DiasCredito = _Resultado.Datos.Rows(0).Item("DiasCredito")
                _PorcMora = _Resultado.Datos.Rows(0).Item("PorcMora")
                _DiasGraciaMora = _Resultado.Datos.Rows(0).Item("DiasGraciaMora")
                _AplicaMora = _Resultado.Datos.Rows(0).Item("AplicaMora")
                _Activo = _Resultado.Datos.Rows(0).Item("Activo")
                _UltimaModificacion = _Resultado.Datos.Rows(0).Item("UltimaModificacion")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDL.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDL.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDL.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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
            End With

            _Resultado = _SDL.ClienteMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Cliente_Id = _Resultado.Datos.Rows(0).Item("Cliente_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ListBusqueda(pCriterio As String, pTipoBusqueda As Integer) As String
        Dim Query As String

        Try
            Query = " select a.Cliente_Id as Codigo" &
                    " ,a.Nombre" &
                    " ,b.Nombre as TipoIdentificacion" &
                    " ,a.Identificacion" &
                    " from Cliente a" &
                    " ,TipoIdentificacion b" &
                    " where a.Emp_Id = b.Emp_Id" &
                    " and   a.TipoIdentificacion_Id = b.TipoIdentificacion_Id" &
                    " and   a.Activo = 1" &
                    " and   a.Emp_Id = " & _Emp_Id.ToString

            Select Case pTipoBusqueda
                Case 1
                    If pCriterio <> "" Then
                        Query += " and   a.Nombre like '%" & pCriterio & "%'"
                    End If
                Case 2
                    If pCriterio <> "" Then
                        Query += " and   a.Identificacion like '%" & pCriterio & "%'"
                    End If
                Case Else
                    VerificaMensaje("El tipo de búsqueda indicado no es válido")
            End Select

            Query += " order by a.Nombre"

            _Resultado = _SDL.SelectQuery(Query, String.Empty)

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
    Public Function MovimientosClienteRecibo() As String
        Dim Query As String

        Try
            Query = "select a.*, b.Nombre as TipoNombre" &
                    " from CxCMovimiento a, CxCMovimientoTipo b" &
                    " where a.Emp_Id = b.Emp_Id" &
                    " and   a.Tipo_Id = b.Tipo_Id" &
                    " and   a.Emp_Id = " & _Emp_Id.ToString &
                    " and   a.Cliente_Id = " & _Cliente_Id.ToString &
                    " and   a.Tipo_Id In (1,4,6)" &
                    " and   a.Saldo > 0" &
                    " order by a.Fecha"

            _Resultado = _SDL.SelectQuery(Query, String.Empty)

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


    Public Function MovimientosClienteCxCPendientePago() As String
        Dim Tabla As DataTable
        Dim Query As String
        Try

            Query = "select * from  CxCMovimiento" &
                " where Emp_Id = " & Emp_Id.ToString() & " and   (Tipo_Id = 1 or Tipo_Id = 4)" &
                " And   Cliente_Id = " & _Cliente_Id.ToString() & " And Saldo > 0"


            _Resultado = _SDL.SelectQuery(Query, "")


            Tabla = _Resultado.Datos


            If Datos.Tables.Contains(Tabla.TableName) Then
                Datos.Tables.Remove(Tabla.TableName)
            End If

            Datos.Tables.Add(Tabla)

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


    Public Function MovimientosClienteCxC() As String
        Dim Tabla As DataTable
        Dim DTMovimiento As SDFinancial.DTCxCMovimiento = Nothing
        Try


            DTMovimiento = New SDFinancial.DTCxCMovimiento()
            With DTMovimiento
                .Emp_Id = _Emp_Id
                .Cliente_Id = _Cliente_Id
            End With

            _Resultado = _SDL.CxCMovimientoMant(DTMovimiento, SDFinancial.EnumOperacionMant.List, String.Empty)


            Tabla = _Resultado.Datos


            If Datos.Tables.Contains(Tabla.TableName) Then
                Datos.Tables.Remove(Tabla.TableName)
            End If

            Datos.Tables.Add(Tabla)

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

#End Region
End Class