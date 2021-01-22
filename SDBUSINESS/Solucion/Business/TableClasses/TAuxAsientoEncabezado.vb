Imports System.Windows.Forms
Public Class TAuxAsientoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Asiento_Id As Long
    Private _Annio As Integer
    Private _Mes As Integer
    Private _Fecha As DateTime
    Private _Tipo_Id As Integer
    Private _Comentario As String
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Usuario_Id As String
    Private _Origen_Id As Integer
    Private _MAC_Address As String
    Private _ListaDetalle As New List(Of TAuxAsientoDetalle)
    Private _Data As DataSet
    Private _SDL As New SDFinancial.SDFinancial
    Private _DTabla As New SDFinancial.DTAuxAsientoEncabezado
    Private _Resultado As New SDFinancial.TResultado
    Private _ErroresPasaConta As New List(Of String)
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
    Public Property Annio() As Integer
        Get
            Return _Annio
        End Get
        Set(ByVal Value As Integer)
            _Annio = Value
        End Set
    End Property
    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal Value As Integer)
            _Mes = Value
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
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(ByVal Value As String)
            _Comentario = Value
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
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public Property Origen_Id() As Integer
        Get
            Return _Origen_Id
        End Get
        Set(ByVal Value As Integer)
            _Origen_Id = Value
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
    Public Property ListaDetalle As List(Of TAuxAsientoDetalle)
        Get
            Return _ListaDetalle
        End Get
        Set(value As List(Of TAuxAsientoDetalle))
            _ListaDetalle = value
        End Set
    End Property
    Public ReadOnly Property ErroresPasaConta As List(Of String)
        Get
            Return _ErroresPasaConta
        End Get
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
        _Annio = 0
        _Mes = 0
        _Fecha = CDate("1900/01/01")
        _Tipo_Id = 0
        _Comentario = ""
        _Debitos = 0.0
        _Creditos = 0.0
        _Usuario_Id = ""
        _Origen_Id = 0
        _MAC_Address = ""
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Detalle As SDFinancial.DTAuxAsientoDetalle
        Dim Lista As New List(Of SDFinancial.DTAuxAsientoDetalle)

        Try
            For Each Item As TAuxAsientoDetalle In _ListaDetalle
                Detalle = New SDFinancial.DTAuxAsientoDetalle

                With Detalle
                    .Emp_Id = Item.Emp_Id
                    .Asiento_Id = Item.Asiento_Id
                    .Linea_Id = Item.Linea_Id
                    .Fecha = Item.Fecha
                    .Moneda = Item.Moneda
                    .CC_Id = Item.CC_Id
                    .Cuenta_Id = Item.Cuenta_Id
                    .Tipo = Item.Tipo
                    .Monto = Item.Monto
                    .MontoDolares = Item.MontoDolares
                    .TipoCambio = Item.TipoCambio
                    .Referencia = Item.Referencia
                    .Descripcion = Item.Descripcion
                End With

                Lista.Add(Detalle)
            Next

            With _DTabla
                .Emp_Id = _Emp_Id
                .Asiento_Id = _Asiento_Id
                .Annio = _Annio
                .Mes = _Mes
                .Fecha = _Fecha
                .Tipo_Id = _Tipo_Id
                .Comentario = _Comentario
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Usuario_Id = _Usuario_Id
                .Origen_Id = _Origen_Id
                .MAC_Address = _MAC_Address
                .ListaDetalle = Lista.ToArray
            End With

            _Resultado = _SDL.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

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
            End With

            _Resultado = _SDL.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Eliminar, String.Empty)

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
                .Annio = _Annio
                .Mes = _Mes
                .Fecha = _Fecha
                .Tipo_Id = _Tipo_Id
                .Comentario = _Comentario
                .Debitos = _Debitos
                .Creditos = _Creditos
                .Usuario_Id = _Usuario_Id
                .Origen_Id = _Origen_Id
                .MAC_Address = _MAC_Address
            End With

            _Resultado = _SDL.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

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
            End With

            _Resultado = _SDL.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.ListKey, String.Empty)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            If Not _Resultado.Datos Is Nothing AndAlso _Resultado.Datos.Rows.Count > 0 Then
                _Emp_Id = _Resultado.Datos.Rows(0).Item("Emp_Id")
                _Asiento_Id = _Resultado.Datos.Rows(0).Item("Asiento_Id")
                _Annio = _Resultado.Datos.Rows(0).Item("Annio")
                _Mes = _Resultado.Datos.Rows(0).Item("Mes")
                _Fecha = _Resultado.Datos.Rows(0).Item("Fecha")
                _Tipo_Id = _Resultado.Datos.Rows(0).Item("Tipo_Id")
                _Comentario = _Resultado.Datos.Rows(0).Item("Comentario")
                _Debitos = _Resultado.Datos.Rows(0).Item("Debitos")
                _Creditos = _Resultado.Datos.Rows(0).Item("Creditos")
                _Usuario_Id = _Resultado.Datos.Rows(0).Item("Usuario_Id")
                _Origen_Id = _Resultado.Datos.Rows(0).Item("Origen_Id")
                _MAC_Address = _Resultado.Datos.Rows(0).Item("MAC_Address")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overrides Function List() As String
        Try
            _Resultado = _SDL.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.List, String.Empty)

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
            _Resultado = _SDL.AuxAsientoEncabezadoMant(_DTabla, SDFinancial.EnumOperacionMant.LoadCombo, String.Empty)

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
    Public Function EliminaAsientoProcesado(pEmp_Id As Integer, pSuc_Id As Integer, pCaja_Id As Integer, pCierre_Id As Integer) As String
        Dim Query As String

        Try
            Query = "exec CierreCajaAsientoProcesado " & pEmp_Id.ToString & "," & pSuc_Id.ToString & "," & pCaja_Id.ToString & "," & pCierre_Id.ToString

            _Resultado = _SDL.ExecuteQuery(Query, GetConnectionString)

            MsgError = _Resultado.ErrorDescription
            VerificaMsgError()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function AsientoCierrePasaConta(ByRef pProgreso As ProgressBar) As String
        Dim CajaCierreAsiento As New TCajaCierreAsiento(_Emp_Id)
        Dim AsientoEncabezado As SDFinancial.DTAuxAsientoEncabezado
        Dim ListaAsientos As New List(Of SDFinancial.DTAuxAsientoDetalle)
        Dim AsientoDetalle As SDFinancial.DTAuxAsientoDetalle = Nothing
        Dim Linea As Integer = 0
        Dim Debe As Double = 0
        Dim Haber As Double = 0
        Try

            _ErroresPasaConta.Clear()

            With CajaCierreAsiento
                .Suc_Id = SucursalInfo.Suc_Id
            End With
            VerificaMensaje(CajaCierreAsiento.CierreAsientosPendientes)

            If CajaCierreAsiento.RowsAffected = 0 Then
                VerificaMensaje("En este momento no existen asientos pendientes de procesar a contabilidad")
            End If

            pProgreso.Minimum = 0
            pProgreso.Maximum = CajaCierreAsiento.RowsAffected
            pProgreso.Value = 0

            For Each FilaCierre As DataRow In CajaCierreAsiento.Data.Tables("Cierre").Rows


                pProgreso.Value += 1
                Debe = 0
                Haber = 0
                ListaAsientos.Clear()

                Try
                    With CajaCierreAsiento
                        .Caja_Id = FilaCierre("Caja_Id")
                        .Cierre_Id = FilaCierre("Cierre_Id")
                    End With
                    VerificaMensaje(CajaCierreAsiento.List)
                    If CajaCierreAsiento.RowsAffected = 0 Then
                        VerificaMensaje("No se encontro el detalle para el cierre # " & FilaCierre("Cierre_Id").ToString & " de la caja " & FilaCierre("Caja_Id"))
                    End If

                    Linea = 0

                    For Each FilaDetalle As DataRow In CajaCierreAsiento.Data.Tables("CierreDetalle").Rows

                        If FilaDetalle("Tipo") = coAsientoTipoDebe Then
                            Debe += FilaDetalle("Monto")
                        Else
                            Haber += FilaDetalle("Monto")
                        End If
                        Linea += 1

                        If Not ValidaCuentaContableSD(FilaDetalle("Cuenta"), False) Then
                            VerificaMensaje("Cierre de Caja #" & FilaCierre("Cierre_Id").ToString & " de la Caja #" & FilaCierre("Caja_Id") & " tiene cueentas contables no válidas")
                        End If

                        AsientoDetalle = New SDFinancial.DTAuxAsientoDetalle

                        With AsientoDetalle
                            .Emp_Id = _Emp_Id
                            .Linea_Id = Linea
                            .Fecha = FilaCierre("FechaCierre")
                            .Moneda = coMonedaColones
                            .CC_Id = 0
                            .Cuenta_Id = FilaDetalle("Cuenta")
                            .Tipo = FilaDetalle("Tipo")
                            .Monto = FilaDetalle("Monto")
                            .MontoDolares = 0
                            .TipoCambio = 1
                            .Referencia = "Cierre #" & FilaCierre("Cierre_Id").ToString
                            .Descripcion = "Cierre de Caja #" & FilaCierre("Cierre_Id").ToString & " de la Caja #" & FilaCierre("Caja_Id") & " - " & FilaCierre("NombreCaja")
                        End With


                        ListaAsientos.Add(AsientoDetalle)

                    Next

                    If Math.Abs((Debe - Haber)) > 0.1 Then
                        VerificaMensaje("Cierre de Caja #" & FilaCierre("Cierre_Id").ToString & " de la Caja #" & FilaCierre("Caja_Id") & " tiene diferencias")
                    End If



                    AsientoEncabezado = New SDFinancial.DTAuxAsientoEncabezado

                    With AsientoEncabezado
                        .Emp_Id = _Emp_Id
                        .Annio = CDate(FilaCierre("FechaCierre")).Year
                        .Mes = CDate(FilaCierre("FechaCierre")).Month
                        .Fecha = FilaCierre("FechaCierre")
                        .Tipo_Id = Enum_AsientoTipo.CierreCaja
                        .Comentario = "Cierre de Caja #" & FilaCierre("Cierre_Id") & " de la Caja #" & FilaCierre("Caja_Id") & " - " & FilaCierre("NombreCaja")
                        .Debitos = Debe
                        .Creditos = Haber
                        .Usuario_Id = coUsuarioGeneral
                        .Origen_Id = Enum_AsientoOrigen.POS_General
                        .MAC_Address = InfoMaquina.MAC_Address
                        .ListaDetalle = ListaAsientos.ToArray
                    End With

                    AsientoEncabezado.ListaDetalle = ListaAsientos.ToArray

                    _Resultado = _SDL.AuxAsientoEncabezadoMant(AsientoEncabezado, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

                    VerificaMensaje(_Resultado.ErrorDescription)

                    EliminaAsientoProcesado(_Emp_Id, SucursalInfo.Suc_Id, FilaCierre("Caja_Id"), FilaCierre("Cierre_Id"))

                Catch ex As Exception
                    _ErroresPasaConta.Add(ex.Message)
                End Try
            Next

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class