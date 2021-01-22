Imports BUSINESS
Public Class FrmMantAsientoDetalle
#Region "Enum"
    Enum ColumnasDetalle
        Linea = 0
        Cuenta_Id = 1
        Cuenta_Nombre = 2
        CC_Id = 3
        CC_Nombre = 4
        Referencia = 5
        Descripcion = 6
        Moneda = 7
        TipoCambio = 8
        Tipo = 9
        Monto = 10
        Dolares = 11
        Debe = 12
        Haber = 13
    End Enum
    Private Enum AccionDetalle
        Nuevo = 0
        Modifica = 1
    End Enum
#End Region
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
    Private _Asiento_Id As Integer = 0
    Private _Cargo As Boolean = False
    Private _LineaAsiento As New TLineaAsiento
    Private _CerrarPantalla As Boolean = False
#End Region
#Region "Constantes"
    Private Const coCentroCostoNA = "NA"
#End Region
#Region "Propiedades"
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public WriteOnly Property Nuevo As Boolean
        Set(value As Boolean)
            _Nuevo = value
        End Set
    End Property
    Public ReadOnly Property GuardoCambios As Boolean
        Get
            Return _GuardoCambios
        End Get
    End Property
    Public WriteOnly Property Asiento_Id As Integer
        Set(value As Integer)
            _Asiento_Id = value
        End Set
    End Property

#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(4)

            Numerico(0) = New TNumericFormat(TxtNumero, 7, 0, False, "", "###")
            Numerico(1) = New TNumericFormat(TxtCentroCosto, 4, 0, False, "", "###")
            Numerico(2) = New TNumericFormat(TxtDebe, 15, 2, False, "", "#,##0.00")
            Numerico(3) = New TNumericFormat(TxtHaber, 15, 2, False, "", "#,##0.00")
            Numerico(4) = New TNumericFormat(TxtTipoCambio, 4, 2, False, "", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ConfiguraDetalle()
        Try
            With LvwDetalle
                .Columns(ColumnasDetalle.Linea).Text = "Linea"
                .Columns(ColumnasDetalle.Linea).Width = 0
                .Columns(ColumnasDetalle.Linea).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.Cuenta_Id).Text = "Cuenta"
                .Columns(ColumnasDetalle.Cuenta_Id).Width = 120
                .Columns(ColumnasDetalle.Cuenta_Id).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.Cuenta_Nombre).Text = "Nombre"
                .Columns(ColumnasDetalle.Cuenta_Nombre).Width = 240
                .Columns(ColumnasDetalle.Cuenta_Nombre).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.CC_Id).Text = "CC"
                .Columns(ColumnasDetalle.CC_Id).Width = 50
                .Columns(ColumnasDetalle.CC_Id).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.CC_Nombre).Text = "Nombre"
                .Columns(ColumnasDetalle.CC_Nombre).Width = 140
                .Columns(ColumnasDetalle.CC_Nombre).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.Moneda).Text = "M"
                .Columns(ColumnasDetalle.Moneda).Width = 20
                .Columns(ColumnasDetalle.Moneda).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.Referencia).Text = "Referencia"
                .Columns(ColumnasDetalle.Referencia).Width = 90
                .Columns(ColumnasDetalle.Referencia).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.Descripcion).Text = "Descripción"
                .Columns(ColumnasDetalle.Descripcion).Width = 200
                .Columns(ColumnasDetalle.Descripcion).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasDetalle.TipoCambio).Text = "TC"
                .Columns(ColumnasDetalle.TipoCambio).Width = 50
                .Columns(ColumnasDetalle.TipoCambio).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Tipo).Text = "Tipo"
                .Columns(ColumnasDetalle.Tipo).Width = 0
                .Columns(ColumnasDetalle.Tipo).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).Width = 0
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Dolares).Text = "Dólares"
                .Columns(ColumnasDetalle.Dolares).Width = 90
                .Columns(ColumnasDetalle.Dolares).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Debe).Text = "Debe"
                .Columns(ColumnasDetalle.Debe).Width = 110
                .Columns(ColumnasDetalle.Debe).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasDetalle.Haber).Text = "Haber"
                .Columns(ColumnasDetalle.Haber).Width = 110
                .Columns(ColumnasDetalle.Haber).TextAlign = HorizontalAlignment.Right
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombos()
        Dim AsientoTipo As New TAsientoTipo
        Dim AsientoEstado As New TAsientoEstado

        Try
            AsientoTipo.Emp_Id = EmpresaInfo.Emp_Id
            AsientoTipo.Activo = True
            VerificaMensaje(AsientoTipo.LoadComboBox(CmbTipo))

            AsientoEstado.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(AsientoEstado.LoadComboBox(CmbEstado))

            CargaComboAnnio(CmbAnnio)
            CargaComboMes(CmbMes)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoTipo = Nothing
            AsientoEstado = Nothing
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            CancelaEdicionLinea()
            LvwDetalle.Items.Clear()
            LblDebeColonesTotal.Text = "0.00"
            LblDebeDolaresTotal.Text = "0.00"
            LblDebeColonizadoTotal.Text = "0.00"
            LblHaberColonesTotal.Text = "0.00"
            LblHaberDolaresTotal.Text = "0.00"
            LblHaberColonizadoTotal.Text = "0.00"
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Me.Text = _Titulo
        _GuardoCambios = False

        Inicializa()
        ConfiguraDetalle()
        CargaCombos()

        If Not _Nuevo Then
            TxtNumero.Text = _Asiento_Id
            CargaDatos()
        Else
            CmbEstado.SelectedValue = Enum_AsientoEstado.Digitado
            TxtFecha.Text = Format(EmpresaInfo.Getdate(), "dd/MM/yyyy")
        End If

        Me.ShowDialog()
    End Sub

    Private Sub DeshabilitaCampos()
        CmbTipo.Enabled = False
        CmbAnnio.Enabled = False
        CmbMes.Enabled = False
        TxtComentario.Enabled = False
        TxtCuenta.Enabled = False
        BtnGuardar.Enabled = False
        BtnAplicar.Enabled = False

    End Sub

    Private Sub CargaDatos()
        Dim AsientoEncabezado As New TAsientoEncabezado
        Dim Item As ListViewItem = Nothing
        Dim Items(13) As String

        Try
            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Asiento_Id = CInt(TxtNumero.Text.Trim)
            End With
            VerificaMensaje(AsientoEncabezado.ListKey())

            With AsientoEncabezado
                CmbTipo.SelectedValue = .Tipo_Id
                CmbMes.SelectedIndex = .Mes - 1
                CmbAnnio.Text = .Annio
                TxtComentario.Text = .Comentario
                TxtFecha.Text = Format(.Fecha, "dd/MM/yyyy")
                CmbEstado.SelectedValue = .Estado_Id
            End With

            For Each Detalle As TAsientoDetalle In AsientoEncabezado.ListaDetalle
                Items(0) = Detalle.Linea_Id.ToString
                Items(1) = Detalle.Cuenta_Id
                Items(2) = Detalle.CuentaNombre
                Items(3) = IIf(Detalle.CC_Id = -1, coCentroCostoNA, Detalle.CC_Id.ToString)
                Items(4) = IIf(Detalle.CC_Id = -1, coCentroCostoNA, Detalle.CC_Nombre)
                Items(5) = Detalle.Referencia
                Items(6) = Detalle.Descripcion
                Items(7) = Detalle.Moneda
                Items(8) = Format(Detalle.TipoCambio, "#,##0.00")
                Items(9) = Detalle.Tipo
                Items(10) = Detalle.Monto.ToString
                Items(11) = IIf(Detalle.Moneda = coMonedaDolares, Format(Detalle.Monto / Detalle.TipoCambio, "#,##0.00"), String.Empty)
                Items(12) = IIf(Detalle.Tipo = coDebe, Format(Detalle.Monto, "#,##0.00"), String.Empty)
                Items(13) = IIf(Detalle.Tipo = coHaber, Format(Detalle.Monto, "#,##0.00"), String.Empty)

                Item = New ListViewItem(Items)
                LvwDetalle.Items.Add(Item)
            Next

            CalculaTotales()

            If CmbEstado.SelectedValue = Enum_AsientoEstado.Aplicado Then
                BtnReversar.Enabled = True
                DeshabilitaCampos()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub BusquedaCuenta()
        Dim Forma As New FrmBusquedaCuentaContable

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCuenta.Text = Forma.Cuenta_Id
                VerificaMensaje(VerificaCuenta(TxtCuenta.Text, False))
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function VerificaCentroCosto() As String
        Dim CentroCosto As New TCentroCosto

        Try
            If TxtCentroCosto.Text.Trim = "" Then
                VerificaMensaje("Debe de seleccionar un centro de costo")
            End If

            With CentroCosto
                .Emp_Id = EmpresaInfo.Emp_Id
                .CC_Id = CInt(TxtCentroCosto.Text.Trim)
            End With
            VerificaMensaje(CentroCosto.ListKey)

            If CentroCosto.RowsAffected = 0 Then
                VerificaMensaje("No se encontró un centro de costo con el código: " & TxtCentroCosto.Text.Trim)
            End If

            If Not CentroCosto.Activo Then
                VerificaMensaje("El centro de costo seleccionado se encuentra inactivo")
            End If

            If CInt(_LineaAsiento.CCTipo_Id) <> CentroCosto.CCTipo_Id Then
                VerificaMensaje("El tipo de centro de costo es inválido, tiene que ser de tipo " & _LineaAsiento.CCTipo_Id.ToString())
            End If

            With _LineaAsiento
                .CC_Id = CentroCosto.CC_Id
                .CCNombre = CentroCosto.Nombre
            End With

            TxtCentroCostoNombre.Text = CentroCosto.Nombre
            TxtReferencia.Focus()

            Return String.Empty
        Catch ex As Exception
            TxtCentroCosto.Focus()
            TxtCentroCosto.SelectAll()
            Return ex.Message
        Finally
            CentroCosto = Nothing
        End Try
    End Function

    Private Sub BuscaCentroCosto()
        Dim Forma As New FrmBusquedaCentroCosto

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCentroCosto.Text = Forma.CC_Id
                VerificaMensaje(VerificaCentroCosto())
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function VerificaTipoCambio() As String
        Try
            If Not IsNumeric(TxtTipoCambio.Text) OrElse CDbl(TxtTipoCambio.Text) <= 0 Then
                VerificaMensaje("El tipo de cambio debe de ser mayor o igual a 1")
            End If

            If _LineaAsiento.Moneda = coMonedaColones Then
                TxtTipoCambio.Text = "1.00"
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub BuscaTipoCambio()
        Dim Forma As New FrmBusquedaTipoCambio

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                Select Case Forma.TipoCambioSeleccionado
                    Case coTipoCambioVenta
                        TxtTipoCambio.Text = Forma.TipoCambioVenta
                    Case coTipoCambioCompra
                        TxtTipoCambio.Text = Forma.TipoCambioCompra
                End Select
                VerificaMensaje(VerificaTipoCambio)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function ValidaTodo(pAplica As Boolean) As Boolean
        Try

            If Not _Nuevo Then
                If GetAsientoEstado(CLng(TxtNumero.Text)) <> Enum_AsientoEstado.Digitado Then
                    VerificaMensaje("No puede guardar el asiento, debido a que este ya fue aplicado por otro usuario")
                End If
            End If


            If CInt(CmbAnnio.Text) < EmpresaParametroInfo.GetProcesoAnnio OrElse _
                (CInt(CmbAnnio.Text) = EmpresaParametroInfo.GetProcesoAnnio And MesNumero(CmbMes.Text.Trim) < EmpresaParametroInfo.GetProcesoMes) Then
                VerificaMensaje("El periodo seleccionado ya ha sido cerrado")
            End If

            If LvwDetalle Is Nothing OrElse LvwDetalle.Items.Count = 0 Then
                VerificaMensaje("No puede guardar un asiento sin un detalle")
            End If


            If pAplica Then
                If CDbl(LblDiferenciaColonizado.Text.Trim) <> 0 Then
                    VerificaMensaje("No puede aplicar el asiento, debido a que existe una diferencia")
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Function ValidaReversion(pAplica As Boolean) As Boolean
        Try

            If GetAsientoEstado(CLng(TxtNumero.Text)) <> Enum_AsientoEstado.Aplicado Then
                VerificaMensaje("No puede guardar el asiento, debido a que este no se encuentra aplicado")
            End If

            If CInt(CmbAnnio.Text) < EmpresaParametroInfo.GetProcesoAnnio OrElse _
                (CInt(CmbAnnio.Text) = EmpresaParametroInfo.GetProcesoAnnio And MesNumero(CmbMes.Text.Trim) < EmpresaParametroInfo.GetProcesoMes) Then
                VerificaMensaje("Unicamente se pueden hacer reversiones de asientos del periodo actual")
            End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Guardar(pAplica As Boolean)
        Dim AsientoEncabezado As New TAsientoEncabezado
        Dim AsientoDetalle As TAsientoDetalle
        Dim Fecha As DateTime
        Dim Linea As Integer = 1
        Dim Mensaje As String

        Try
            Fecha = EmpresaInfo.Getdate

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, Permisos.CoGuardarAsiento, False) Then
                VerificaMensaje("No tiene permiso para guardar asientos")
            End If

            If pAplica Then
                If Not VerificaPermiso(EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, Permisos.CoAplicarAsiento, False) Then
                    VerificaMensaje("No tiene permiso para aplicar asientos")
                End If
            End If

            If Not _Nuevo Then
                With AsientoEncabezado
                    .Asiento_Id = CInt(TxtNumero.Text.Trim)
                End With
            End If

            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Annio = CInt(CmbAnnio.Text)
                .Mes = MesNumero(CmbMes.Text.Trim)
                .Fecha = Fecha
                .Tipo_Id = CInt(CmbTipo.SelectedValue)
                .Comentario = TxtComentario.Text.Trim
                .Estado_Id = CInt(CmbEstado.SelectedValue)
                .Debitos = CDbl(LblDebeColonizadoTotal.Text.Trim)
                .Creditos = CDbl(LblHaberColonizadoTotal.Text.Trim)
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .UsuarioAplica_Id = UsuarioInfo.Usuario_Id
                .Origen_Id = Enum_AsientoOrigen.Contabilidad
                .AplicarAsiento = pAplica
            End With

            For Each Item As ListViewItem In LvwDetalle.Items
                AsientoDetalle = New TAsientoDetalle

                With AsientoDetalle
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Linea_Id = Linea
                    .Fecha = Fecha
                    .Moneda = Item.SubItems(ColumnasDetalle.Moneda).Text.Trim
                    .CC_Id = IIf(Item.SubItems(ColumnasDetalle.CC_Id).Text.Trim <> coCentroCostoNA, Item.SubItems(ColumnasDetalle.CC_Id).Text.Trim, 0)
                    .Cuenta_Id = Item.SubItems(ColumnasDetalle.Cuenta_Id).Text.Trim
                    .Tipo = Item.SubItems(ColumnasDetalle.Tipo).Text.Trim
                    .Monto = CDbl(Item.SubItems(ColumnasDetalle.Monto).Text.Trim)
                    .MontoDolares = CDbl(IIf(Item.SubItems(ColumnasDetalle.Dolares).Text.Trim <> "", Item.SubItems(ColumnasDetalle.Dolares).Text.Trim, 0))
                    .TipoCambio = CDbl(Item.SubItems(ColumnasDetalle.TipoCambio).Text.Trim)
                    .Referencia = Item.SubItems(ColumnasDetalle.Referencia).Text.Trim
                    .Descripcion = Item.SubItems(ColumnasDetalle.Descripcion).Text.Trim
                End With

                AsientoEncabezado.ListaDetalle.Add(AsientoDetalle)
                Linea += 1
            Next
            VerificaMensaje(AsientoEncabezado.Insert())

            _GuardoCambios = True
            _CerrarPantalla = True

            If pAplica Then
                Mensaje = "El asiento se aplicó correctamente"
            Else
                Mensaje = "Los cambios se almacenaron correctamente"
            End If

            MsgBox(Mensaje, MsgBoxStyle.Information, Me.Text)
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoEncabezado = Nothing
        End Try
    End Sub

    Private Sub ReversaAsiento()
        Dim AsientoEncabezado As New TAsientoEncabezado

        Try
            If Not VerificaPermiso(EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, Permisos.CoReversaAsiento, False) Then
                VerificaMensaje("No tiene permiso para reversar asientos")
            End If

            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Asiento_Id = CLng(TxtNumero.Text)
            End With
            VerificaMensaje(AsientoEncabezado.ReversaAsiento)

            MsgBox("El asiento ha sido reversado", MsgBoxStyle.Information, Me.Text)

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoEncabezado = Nothing
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If ValidaTodo(False) Then
            Guardar(False)
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantAsientoDetalle_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not _Cargo Then
            _Cargo = True
            TxtCuenta.Focus()
        End If
    End Sub

    Private Sub FrmMantAsientoDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Busquedas()
            Case Keys.F2
                BtnGuardar.PerformClick()
            Case Keys.F3
                BtnAplicar.PerformClick()
            Case Keys.Escape
                If Me.ActiveControl.Name = TxtCuentaNombre.Name OrElse _
                   Me.ActiveControl.Name = TxtCentroCosto.Name OrElse _
                   Me.ActiveControl.Name = TxtCentroCostoNombre.Name OrElse _
                   Me.ActiveControl.Name = TxtReferencia.Name OrElse _
                   Me.ActiveControl.Name = TxtDescripcion.Name OrElse _
                   Me.ActiveControl.Name = TxtMoneda.Name OrElse _
                   Me.ActiveControl.Name = TxtTipoCambio.Name OrElse _
                   Me.ActiveControl.Name = TxtDebe.Name OrElse _
                   Me.ActiveControl.Name = TxtHaber.Name Then
                    CancelaEdicionLinea()
                Else
                    BtnSalir.PerformClick()
                End If
        End Select
    End Sub

    Private Sub FrmMantCentroCostoDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormateaCamposNumericos()
    End Sub

    Private Sub CancelaEdicionLinea()
        _LineaAsiento.Inicializa()
        LvwDetalle.Tag = Nothing
        TxtCuenta.Enabled = True
        TxtCuentaNombre.Enabled = False
        TxtCentroCosto.Enabled = False
        TxtCentroCostoNombre.Enabled = False
        TxtReferencia.Enabled = False
        TxtDescripcion.Enabled = False
        TxtMoneda.Enabled = False
        TxtTipoCambio.Enabled = False
        TxtDebe.Enabled = False
        TxtHaber.Enabled = False
        TxtCuenta.Text = ""
        TxtCuentaNombre.Text = ""
        TxtCentroCosto.Text = ""
        TxtCentroCostoNombre.Text = ""
        TxtReferencia.Text = ""
        TxtDescripcion.Text = ""
        TxtMoneda.Text = ""
        TxtTipoCambio.Text = ""
        TxtDebe.Text = ""
        TxtHaber.Text = ""
        TxtCuenta.Focus()
    End Sub

    Private Sub Busquedas()
        Try
            Select Case Me.ActiveControl.Name
                Case "TxtCuenta"
                    BusquedaCuenta()
                Case "TxtCentroCosto"
                    BuscaCentroCosto()
                Case "TxtTipoCambio"
                    BuscaTipoCambio()
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuenta.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If TxtCuenta.Text.Trim.Length > 0 Then
                        VerificaMensaje(VerificaCuenta(TxtCuenta.Text.Trim, False))
                    End If
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function VerificaCuenta(pCuenta_Id As String, pModificando As Boolean) As String
        Dim Cuenta As New TCuenta

        Try
            _LineaAsiento.Inicializa()

            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = DepuraNumeroCuenta(TxtCuenta.Text)
            End With
            VerificaMensaje(Cuenta.ListKey)

            If Cuenta.RowsAffected = 0 Then
                VerificaMensaje("El número de cuenta no existe")
            End If

            If Not Cuenta.AceptaMovimiento Then
                VerificaMensaje("La cuenta no recibe movimientos")
            End If

            If Not Cuenta.Activo Then
                VerificaMensaje("La cuenta se encuentra desactivada")
            End If

            TxtCuentaNombre.Text = Cuenta.Nombre
            TxtMoneda.Text = Cuenta.Moneda
            TxtDebe.Text = "0.00"
            TxtHaber.Text = "0.00"

            With _LineaAsiento
                .Cuenta = Cuenta.Cuenta_Id
                .CuentaNombre = Cuenta.Nombre
                .Moneda = Cuenta.Moneda
                .CCTipo_Id = Cuenta.CCTipo_Id
                .TipoCambio = IIf(Cuenta.Moneda = coMonedaColones, 1, TipoCambioContabilidad())
                .SolicitaCentroCosto = Cuenta.SolicitaCentroCosto
            End With

            TxtCuenta.Enabled = False
            TxtCuentaNombre.Enabled = True
            TxtReferencia.Enabled = True
            TxtDescripcion.Enabled = True
            TxtMoneda.Enabled = True
            TxtDebe.Enabled = True
            TxtHaber.Enabled = True

            If Cuenta.SolicitaCentroCosto Then
                TxtCentroCosto.Enabled = True
                TxtCentroCostoNombre.Enabled = True
                TxtCentroCosto.Focus()
            Else
                TxtCentroCosto.Enabled = False
                TxtCentroCostoNombre.Enabled = False
                TxtReferencia.Focus()
            End If

            TxtTipoCambio.Enabled = IIf(Cuenta.Moneda = coMonedaDolares, True, False)
            TxtTipoCambio.Text = _LineaAsiento.TipoCambio

            Return String.Empty
        Catch ex As Exception
            TxtCuenta.Text = String.Empty
            TxtCuenta.Focus()
            Return ex.Message
        Finally
            Cuenta = Nothing
        End Try
    End Function

    Private Sub IncializaLinea()
        TxtCuenta.Text = ""
    End Sub

    Private Sub TxtCentroCosto_TextChanged(sender As Object, e As EventArgs) Handles TxtCentroCosto.TextChanged
        TxtCentroCostoNombre.Text = ""
    End Sub

    Private Sub TxtCentroCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCentroCosto.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If IsNumeric(TxtCentroCosto.Text) Then
                        VerificaMensaje(VerificaCentroCosto)
                    End If
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtDebe_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDebe.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    VerificaMensaje(VerificaDebe())
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtHaber_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtHaber.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    VerificaMensaje(VerificaHaber())
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function VerificaDebe() As String
        Try
            If Not IsNumeric(TxtDebe.Text) OrElse CDbl(TxtDebe.Text) < 0 Then
                TxtDebe.Text = "0.00"
            End If

            If CDbl(TxtDebe.Text) = 0 Then
                TxtHaber.Focus()
            Else
                VerificaMensaje(VerificaLineaAsiento())
                IngresaLinea()
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function VerificaHaber() As String
        Try
            If Not IsNumeric(TxtHaber.Text) OrElse CDbl(TxtHaber.Text) < 0 Then
                TxtHaber.Text = "0.00"
            End If
            VerificaMensaje(VerificaLineaAsiento())

            IngresaLinea()

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function VerificaLineaAsiento() As String
        Try
            If _LineaAsiento.SolicitaCentroCosto Then
                VerificaMensaje(VerificaCentroCosto)
            End If
            VerificaMensaje(VerificaTipoCambio)

            If Not IsNumeric(TxtDebe.Text) OrElse CDbl(TxtDebe.Text) < 0 Then
                TxtDebe.Text = "0.00"
            End If

            If Not IsNumeric(TxtHaber.Text) OrElse CDbl(TxtHaber.Text) < 0 Then
                TxtHaber.Text = "0.00"
            End If

            If CDbl(TxtDebe.Text) <= 0 And CDbl(TxtHaber.Text) <= 0 Then
                TxtDebe.SelectAll()
                TxtDebe.Focus()
                VerificaMensaje("No se puede ingresar una cuenta sin monto a ambos lados")
            End If

            If CDbl(TxtDebe.Text) > 0 And CDbl(TxtHaber.Text) > 0 Then
                TxtDebe.SelectAll()
                TxtDebe.Focus()
                VerificaMensaje("La cuenta puede llevar monto únicamente a un lado")
            End If

            With _LineaAsiento
                .Referencia = TxtReferencia.Text.Trim
                .Descripcion = TxtDescripcion.Text.Trim
                .Debe = CDbl(TxtDebe.Text)
                .Haber = CDbl(TxtHaber.Text)
            End With

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function BuscaItemCuenta(pCuenta_Id As String) As ListViewItem
        Dim Item As ListViewItem = Nothing

        Try
            For Each Linea As ListViewItem In LvwDetalle.Items
                If Linea.SubItems(ColumnasDetalle.Cuenta_Id).Text = pCuenta_Id Then
                    Item = Linea
                End If
            Next

            Return Item
        Catch ex As Exception
            MensajeError(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub IngresaLinea()
        Dim Item As ListViewItem
        Dim Items(13) As String
        Dim Linea_Id As Integer = 0
        Dim Accion As AccionDetalle = AccionDetalle.Nuevo

        Try

            If Not LvwDetalle.Tag Is Nothing Then
                Item = LvwDetalle.Tag
                Linea_Id = CInt(Item.SubItems(ColumnasDetalle.Linea).Text)
                Accion = AccionDetalle.Modifica
            Else
                Item = New ListViewItem(Items)
                Linea_Id = LvwDetalle.Items.Count + 1
                Accion = AccionDetalle.Nuevo
            End If

            With Item
                .SubItems(ColumnasDetalle.Linea).Text = Linea_Id
                .SubItems(ColumnasDetalle.Cuenta_Id).Text = _LineaAsiento.Cuenta
                .SubItems(ColumnasDetalle.Cuenta_Nombre).Text = _LineaAsiento.CuentaNombre
                .SubItems(ColumnasDetalle.CC_Id).Text = IIf(_LineaAsiento.CC_Id = -1, coCentroCostoNA, _LineaAsiento.CC_Id)
                .SubItems(ColumnasDetalle.CC_Nombre).Text = IIf(_LineaAsiento.CC_Id = -1, coCentroCostoNA, _LineaAsiento.CCNombre)
                .SubItems(ColumnasDetalle.Referencia).Text = _LineaAsiento.Referencia
                .SubItems(ColumnasDetalle.Descripcion).Text = _LineaAsiento.Descripcion
                .SubItems(ColumnasDetalle.Moneda).Text = _LineaAsiento.Moneda
                .SubItems(ColumnasDetalle.TipoCambio).Text = Format(_LineaAsiento.TipoCambio, "#,##0.00")
                .SubItems(ColumnasDetalle.Tipo).Text = IIf(_LineaAsiento.Debe > 0, coDebe, coHaber)
                .SubItems(ColumnasDetalle.Monto).Text = IIf(_LineaAsiento.Debe > 0, _LineaAsiento.Debe, _LineaAsiento.Haber) * _LineaAsiento.TipoCambio
                .SubItems(ColumnasDetalle.Dolares).Text = IIf(_LineaAsiento.Moneda = coMonedaDolares, Format(IIf(_LineaAsiento.Debe > 0, _LineaAsiento.Debe, _LineaAsiento.Haber), "#,##0.00"), String.Empty)
                .SubItems(ColumnasDetalle.Debe).Text = IIf(_LineaAsiento.Debe > 0, Format(_LineaAsiento.Debe * _LineaAsiento.TipoCambio, "#,##0.00"), String.Empty)
                .SubItems(ColumnasDetalle.Haber).Text = IIf(_LineaAsiento.Haber > 0, Format(_LineaAsiento.Haber * _LineaAsiento.TipoCambio, "#,##0.00"), String.Empty)
            End With

            If Accion = AccionDetalle.Nuevo Then
                LvwDetalle.Items.Add(Item)
                Item.EnsureVisible()
            End If

            TxtCuenta.Text = ""
            CancelaEdicionLinea()
            TxtCuenta.Focus()
            CalculaTotales()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtReferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtReferencia.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TxtDescripcion.Focus()
        End Select
    End Sub

    Private Sub TxtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDescripcion.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If _LineaAsiento.Moneda = coMonedaDolares Then
                    TxtTipoCambio.Focus()
                Else
                    TxtDebe.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtTipoCambio_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTipoCambio.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    VerificaMensaje(VerificaTipoCambio)
                    _LineaAsiento.TipoCambio = CDbl(TxtTipoCambio.Text)
                    TxtDebe.Focus()
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwDetalle_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LvwDetalle.MouseDoubleClick
        Try
            ModificaLinea()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ModificaLinea()
        Dim Debe As Double = 0
        Dim Haber As Double = 0

        Try
            If Not TxtCuenta.Enabled OrElse LvwDetalle.Items.Count = 0 OrElse LvwDetalle.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, Permisos.CoModificaLineaAsiento, False) Then
                VerificaMensaje("No tiene permiso para modificar la linea del asiento")
            End If

            If IsNumeric(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Debe).Text.Trim) Then
                Debe = CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Debe).Text.Trim)
            Else
                Haber = CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Haber).Text.Trim)
            End If

            CancelaEdicionLinea()
            TxtCuenta.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Cuenta_Id).Text
            VerificaCuenta(TxtCuenta.Text, True)
            TxtReferencia.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Referencia).Text
            TxtDescripcion.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Descripcion).Text
            TxtTipoCambio.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.TipoCambio).Text
            TxtDebe.Text = Format(Debe / CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.TipoCambio).Text), "#,##0.00")
            TxtHaber.Text = Format(Haber / CDbl(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.TipoCambio).Text), "#,##0.00")

            If _LineaAsiento.SolicitaCentroCosto Then
                TxtCentroCosto.Text = LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.CC_Id).Text
                VerificaMensaje(VerificaCentroCosto)
                TxtCentroCosto.Focus()
            Else
                TxtReferencia.Focus()
            End If

            LvwDetalle.Tag = LvwDetalle.SelectedItems(0)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub EliminaLinea()
        Try
            If Not TxtCuenta.Enabled Then
                Exit Sub
            End If

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, Permisos.CoEliminaLineaAsiento, False) Then
                VerificaMensaje("No tiene permiso eliminar lineas del asiento")
            End If

            If MsgBox("Desea eliminar la línea del detalle", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar líneas") <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            If LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una línea")
            End If

            LvwDetalle.Tag = Nothing
            LvwDetalle.Items.Remove(LvwDetalle.SelectedItems(0))
            CalculaTotales()
            TxtCuenta.Focus()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwDetalle.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Delete
                    EliminaLinea()
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CalculaTotales()
        Dim DebeColones As Double = 0
        Dim DebeDolares As Double = 0
        Dim DebeColonizado As Double = 0
        Dim HaberColones As Double = 0
        Dim HaberDolares As Double = 0
        Dim HaberColonizado As Double = 0

        Try
            For Each item As ListViewItem In LvwDetalle.Items
                If item.SubItems(ColumnasDetalle.Tipo).Text = coDebe Then
                    Select Case item.SubItems(ColumnasDetalle.Moneda).Text
                        Case coMonedaColones
                            DebeColones += CDbl(item.SubItems(ColumnasDetalle.Monto).Text)
                            DebeColonizado += CDbl(item.SubItems(ColumnasDetalle.Monto).Text)
                        Case coMonedaDolares
                            DebeDolares += CDbl(item.SubItems(ColumnasDetalle.Monto).Text) / CDbl(item.SubItems(ColumnasDetalle.TipoCambio).Text)
                            DebeColonizado += CDbl(item.SubItems(ColumnasDetalle.Monto).Text)
                    End Select
                Else
                    Select Case item.SubItems(ColumnasDetalle.Moneda).Text
                        Case coMonedaColones
                            HaberColones += CDbl(item.SubItems(ColumnasDetalle.Monto).Text)
                            HaberColonizado += CDbl(item.SubItems(ColumnasDetalle.Monto).Text)
                        Case coMonedaDolares
                            HaberDolares += CDbl(item.SubItems(ColumnasDetalle.Monto).Text) / CDbl(item.SubItems(ColumnasDetalle.TipoCambio).Text)
                            HaberColonizado += CDbl(item.SubItems(ColumnasDetalle.Monto).Text)
                    End Select
                End If
            Next

            LblDebeColonesTotal.Text = Format(DebeColones, "#,##0.00")
            LblDebeDolaresTotal.Text = Format(DebeDolares, "#,##0.00")
            LblDebeColonizadoTotal.Text = Format(DebeColonizado, "#,##0.00")
            LblHaberColonesTotal.Text = Format(HaberColones, "#,##0.00")
            LblHaberDolaresTotal.Text = Format(HaberDolares, "#,##0.00")
            LblHaberColonizadoTotal.Text = Format(HaberColonizado, "#,##0.00")
            LblDiferenciaColones.Text = Format(DebeColones - HaberColones, "#,##0.00")
            LblDiferenciaDolares.Text = Format(DebeDolares - HaberDolares, "#,##0.00")
            LblDiferenciaColonizado.Text = Format(DebeColonizado - HaberColonizado, "#,##0.00")
            LblDiferenciaColonizado.ForeColor = IIf(Math.Abs(CDbl(LblDiferenciaColonizado.Text)) = 0, Color.Blue, Color.Red)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        If MsgBox("¿Seguro(a) que desea aplicar el asiento?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Aplicar Asiento") = MsgBoxResult.Ok Then
            If ValidaTodo(True) Then
                Guardar(True)
            End If
        End If
    End Sub

    Private Sub FrmMantAsientoDetalle_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _CerrarPantalla AndAlso CmbEstado.SelectedValue <> Enum_AsientoEstado.Aplicado And LvwDetalle.Items.Count > 0 Then
            If MsgBox("¿Está seguro(a) que desea salir?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Salir") <> MsgBoxResult.Ok Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BtnReversar_Click(sender As Object, e As EventArgs) Handles BtnReversar.Click
        If MsgBox("¿Seguro(a) que desea reversar el asiento?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Aplicar Asiento") = MsgBoxResult.Ok Then
            If ValidaReversion(True) Then
                ReversaAsiento()
            End If
        End If
    End Sub

End Class