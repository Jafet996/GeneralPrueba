Imports System.Windows.Forms
Public Class TCuenta
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Cuenta_Id As String
    Private _Nombre As String
    Private _Tipo_Id As Integer
    Private _Clase_Id As Integer
    Private _Nivel As Integer
    Private _Padre_Id As String
    Private _Moneda As Char
    Private _AceptaMovimiento As Integer
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _SolicitaCentroCosto As Integer
    Private _TipoNombre As String
    Private _ClaseNombre As String
    Private _CCTipo_Id As Enum_CentroCostoTipo
    Private _SDWCF As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTCuenta
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
    Public Property Cuenta_Id() As String
        Get
            Return _Cuenta_Id
        End Get
        Set(ByVal Value As String)
            _Cuenta_Id = Value
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    Public Property Clase_Id() As Integer
        Get
            Return _Clase_Id
        End Get
        Set(ByVal Value As Integer)
            _Clase_Id = Value
        End Set
    End Property
    Public Property Nivel() As Integer
        Get
            Return _Nivel
        End Get
        Set(ByVal Value As Integer)
            _Nivel = Value
        End Set
    End Property
    Public Property Padre_Id() As String
        Get
            Return _Padre_Id
        End Get
        Set(ByVal Value As String)
            _Padre_Id = Value
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
    Public Property AceptaMovimiento() As Integer
        Get
            Return _AceptaMovimiento
        End Get
        Set(ByVal Value As Integer)
            _AceptaMovimiento = Value
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public Property SolicitaCentroCosto() As Integer
        Get
            Return _SolicitaCentroCosto
        End Get
        Set(ByVal Value As Integer)
            _SolicitaCentroCosto = Value
        End Set
    End Property
    Public ReadOnly Property TipoNombre As String
        Get
            Return _TipoNombre
        End Get
    End Property
    Public ReadOnly Property ClaseNombre As String
        Get
            Return _ClaseNombre
        End Get
    End Property
    Public ReadOnly Property CCTipo_Id As Enum_CentroCostoTipo
        Get
            Return _CCTipo_Id
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
        If Not InfoMaquina Is Nothing AndAlso InfoMaquina.Url <> "" Then
            _SDWCF.Url = InfoMaquina.Url
        Else
            _SDWCF.Url = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegUrl, String.Empty)
        End If
        _Emp_Id = 0
        _Cuenta_Id = ""
        _Nombre = ""
        _Tipo_Id = 0
        _Clase_Id = 0
        _Nivel = 0
        _Padre_Id = ""
        _Moneda = ""
        _AceptaMovimiento = 0
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _SolicitaCentroCosto = 0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Try
            With _DTabla
                .Emp_Id = _Emp_Id
                .Cuenta_Id = _Cuenta_Id
                .Nombre = _Nombre
                .Tipo_Id = _Tipo_Id
                .Clase_Id = _Clase_Id
                .Nivel = _Nivel
                .Padre_Id = _Padre_Id
                .Moneda = _Moneda
                .AceptaMovimiento = _AceptaMovimiento
                .Activo = _Activo
                .SolicitaCentroCosto = _SolicitaCentroCosto
            End With

            _Resultado = _SDWCF.CuentaMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
                .Cuenta_Id = _Cuenta_Id
            End With

            _Resultado = _SDWCF.CuentaMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Cuenta_Id = _Cuenta_Id
                .Nombre = _Nombre
                .Tipo_Id = _Tipo_Id
                .Clase_Id = _Clase_Id
                .Nivel = _Nivel
                .Padre_Id = _Padre_Id
                .Moneda = _Moneda
                .AceptaMovimiento = _AceptaMovimiento
                .Activo = _Activo
                .SolicitaCentroCosto = _SolicitaCentroCosto
            End With

            _Resultado = _SDWCF.CuentaMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
                .Cuenta_Id = _Cuenta_Id
            End With

            _Resultado = _SDWCF.CuentaMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Cuenta_Id = _Resultado.Datos.Rows(0).Item("Cuenta_Id")
                _Nombre = _Resultado.Datos.Rows(0).Item("Nombre")
                _Tipo_Id = _Resultado.Datos.Rows(0).Item("Tipo_Id")
                _Clase_Id = _Resultado.Datos.Rows(0).Item("Clase_Id")
                _Nivel = _Resultado.Datos.Rows(0).Item("Nivel")
                _Padre_Id = IIf(IsDBNull(_Resultado.Datos.Rows(0).Item("Padre_Id")), "", _Resultado.Datos.Rows(0).Item("Padre_Id"))
                _Moneda = _Resultado.Datos.Rows(0).Item("Moneda")
                _AceptaMovimiento = _Resultado.Datos.Rows(0).Item("AceptaMovimiento")
                _Activo = _Resultado.Datos.Rows(0).Item("Activo")
                _SolicitaCentroCosto = _Resultado.Datos.Rows(0).Item("SolicitaCentroCosto")
                _TipoNombre = _Resultado.Datos.Rows(0).Item("TipoNombre")
                _ClaseNombre = _Resultado.Datos.Rows(0).Item("ClaseNombre")
                _CCTipo_Id = _Resultado.Datos.Rows(0).Item("CCTipo_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDWCF.CuentaMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDWCF.CuentaMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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

            _Resultado = _SDWCF.CuentaMant(_DTabla, SDFinancial.EnumOperacionMant.ListMant, pCriterio)

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

            _Resultado = _SDWCF.CuentaMant(_DTabla, SDFinancial.EnumOperacionMant.NextOne, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Cuenta_Id = _Resultado.Datos.Rows(0).Item("Cuenta_Id")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function CreaArbolCuentasPadre(pArbol As TreeView) As String
        Dim Query As String = String.Empty
        Dim Nodo As TreeNode = Nothing
        Dim ResultStr As String = String.Empty

        Try
            pArbol.Nodes.Clear()


            Query = "select * from Cuenta" & _
                    " where Emp_Id = " & _Emp_Id.ToString() & _
                    " and Nivel = 1 and Activo = 1" & _
                    " Order by Cuenta_Id asc"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            If _Resultado.Datos Is Nothing OrElse _Resultado.Datos.Rows.Count = 0 Then
                Exit Try
            End If

            For Each Reg As DataRow In _Resultado.Datos.Rows
                Nodo = pArbol.Nodes.Add(IIf(Reg("Moneda") = coMonedaColones, "", "(DOL)") & "  " & Reg("Cuenta_Id") & " " & Reg("Nombre"))

                With Nodo
                    .Name = "N_" & Reg("Nivel") & "_" & Reg("Moneda") & "_" & Reg("Cuenta_Id")
                    .Tag = Reg("Cuenta_Id")

                    If Reg("AceptaMovimiento") = 0 Then
                        .ImageIndex = Enum_ImagenCatalogo.CuentaPadre
                    Else
                        .ImageIndex = Enum_ImagenCatalogo.CuentaMovimiento
                    End If
                End With
            Next

        Catch ex As Exception
            ResultStr = ex.Message
        End Try

        Return ResultStr
    End Function
    Public Function CreaArbolCuentasHija(pNodo As TreeNode) As String
        Dim Query As String = String.Empty
        Dim Nodo As TreeNode = Nothing
        Dim ResultStr As String = String.Empty

        Try
            pNodo.Nodes.Clear()

            Query = "select * from Cuenta" & _
                    " where Emp_Id = " & _Emp_Id.ToString() & _
                    " and Padre_Id = '" & pNodo.Tag & "' and Activo = 1" & _
                    " Order by Cuenta_Id asc"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Datos.Tables.Contains(_Resultado.Datos.TableName) Then
                Datos.Tables.Remove(_Resultado.Datos.TableName)
            End If

            Datos.Tables.Add(_Resultado.Datos)

            If _Resultado.Datos Is Nothing OrElse _Resultado.Datos.Rows.Count = 0 Then
                Exit Try
            End If

            For Each Reg As DataRow In _Resultado.Datos.Rows
                Nodo = pNodo.Nodes.Add(IIf(Reg("Moneda") = coMonedaColones, "", "(DOL)") & "  " & Reg("Cuenta_Id") & " " & Reg("Nombre"))

                With Nodo
                    .Name = "N_" & Reg("Nivel") & "_" & Reg("Moneda") & "_" & Reg("Cuenta_Id")
                    .Tag = Reg("Cuenta_Id")

                    If Reg("AceptaMovimiento") = 0 Then
                        .ImageIndex = Enum_ImagenCatalogo.CuentaPadre
                    Else
                        .ImageIndex = Enum_ImagenCatalogo.CuentaMovimiento
                    End If
                End With
            Next

            pNodo.Expand()

        Catch ex As Exception
            ResultStr = ex.Message
        End Try

        Return ResultStr
    End Function
    Public Function GeneraCuentaMayor() As String
        Dim Query As String = ""

        Try
            Query = "select dbo.FnGeneraCuentaMayor(" & _Emp_Id.ToString & "," & _Tipo_Id.ToString & ")"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Cuenta_Id = _Resultado.Datos.Rows(0).Item(0)
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function GeneraCuentaHija() As String
        Dim Query As String = ""

        Try
            Query = "select dbo.FnGeneraCuentaHija(" & _Emp_Id.ToString & ",'" & _Padre_Id & "')"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Cuenta_Id = _Resultado.Datos.Rows(0).Item(0)
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function CambiaAceptaMovimiento() As String
        Dim Query As String = ""

        Try
            Query = " Update Cuenta" & _
                    " set AceptaMovimiento = " & _AceptaMovimiento.ToString & _
                    " where Emp_Id = " & _Emp_Id.ToString & _
                    " and   Cuenta_Id = '" & _Cuenta_Id.ToString & "'"

            _Resultado = _SDWCF.ExecuteQuery(Query, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ListBusqueda(pCriterio As String, pTipoBusqueda As Char) As String
        Dim Query As String = ""

        Try
            Query = " select a.Cuenta_Id" & _
                    " ,a.Nombre" & _
                    " ,b.Nombre as Tipo" & _
                    " ,IIf(a.Moneda = 'C', 'COLONES', 'DÓLARES') as Moneda" & _
                    " from Cuenta a" & _
                    " ,CuentaTipo b" & _
                    " where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Tipo_Id = b.Tipo_Id" & _
                    " and   a.Activo = 1" & _
                    " and   a.AceptaMovimiento = 1" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString

            Select Case pTipoBusqueda
                Case "N"
                    Query += " and   a.Nombre like '%" & pCriterio.Trim & "%'" & _
                             " order by a.Nombre"
                Case "C"
                    Query += " and   a.Cuenta_Id like '" & pCriterio.Trim & "%'" & _
                             " order by a.Cuenta_Id"
            End Select

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

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
    Public Function RptSaldoxCuentas(pAnnioIni As Integer, pMesIni As Integer, pAnnioFin As Integer, pMesFin As Integer) As String
        Dim Query As String

        Try
            Query = " exec RptSaldoxCuentas " & _Emp_Id.ToString & ",'" & pAnnioIni.ToString & "','" & pMesIni.ToString & "'" & _
                    ",'" & pAnnioFin.ToString & "','" & pMesFin.ToString & "'," & _Nivel.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

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
    Public Function RptBalanceDeSituacion(pAnnio As Integer, pMes As Integer) As String
        Dim Query As String

        Try
            Query = " exec RptBalanceDeSituacion " & _Emp_Id.ToString & "," & pMes.ToString & "," & pAnnio.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

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
    Public Function RptEstadoResultados(pAnnio As Integer, pMes As Integer) As String
        Dim Query As String

        Try
            Query = " exec RptEstadoResultados " & _Emp_Id.ToString & "," & pAnnio.ToString & "," & pMes.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

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
    Public Function RptBalanceDeComprobacion(pAnnio As Integer, pMes As Integer, pCuentaIni As String, pCuentaFin As String) As String
        Dim Query As String

        Try
            Query = " exec RptBalanceDeComprobacion " & _Emp_Id.ToString & "," & pAnnio.ToString & "," & pMes.ToString & _
                    ",'" & pCuentaIni & "','" & pCuentaFin & "'"

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

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
    Public Function RptCambiosPatrimonio(pAnnioIni As Integer, pMesIni As Integer, pAnnioFin As Integer, pMesFin As Integer) As String
        Dim Query As String

        Try
            Query = " exec RptCambiosPatrimonio " & _Emp_Id.ToString & "," & pAnnioIni.ToString & "," & pMesIni.ToString & _
                    "," & pAnnioFin.ToString & "," & pMesFin.ToString

            _Resultado = _SDWCF.SelectQuery(Query, String.Empty)

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
#End Region
End Class