Imports BUSINESS
Public Class FrmMovimientoCrea
#Region "Enum"
    Private Enum ColumnasDetalle
        Cuenta = 0
        CuentaNombre
        CC
        CCNombre
        TipoCambioVisual
        DolaresVisual
        Debe
        Haber
        TipoCambio
        Dolares
    End Enum
#End Region
#Region "Constantes"
    Private coCorrecto As Drawing.Color = Color.PaleTurquoise
    Private coDiferencia As Drawing.Color = Color.LightCoral
#End Region
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Titulo As String = ""
    Private _Prov_Id As Integer = 0
    Private _Tipo_Id As Enum_CxPMovimientoTipo
    Private _Monto As Double = 0
    Private _TipoCambio As Double = 0
    Private _AplicoMovimiento As Boolean = False
    Private _CerrarPantalla As Boolean = False
    Private _ModificandoMonto As Boolean = False
    Private _IncrementaSaldo As Boolean = False
    Private _ListaMovimiento As New List(Of TCxPMovimiento)
#End Region
#Region "Propiedades"
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public WriteOnly Property Prov_Id As Integer
        Set(value As Integer)
            _Prov_Id = value
        End Set
    End Property
    Public WriteOnly Property Tipo_Id As Enum_CxPMovimientoTipo
        Set(value As Enum_CxPMovimientoTipo)
            _Tipo_Id = value
        End Set
    End Property
    Public WriteOnly Property Monto As Double
        Set(value As Double)
            _Monto = value
        End Set
    End Property
    Public ReadOnly Property AplicoMovimiento As Boolean
        Get
            Return _AplicoMovimiento
        End Get
    End Property
#End Region
#Region "Metodos Privados"
    Private Sub FormateCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtMonto, 12, 2, False, "", "#,##0.00")
            Numerico(1) = New TNumericFormat(TxtMontoDolares, 12, 4, False, "", "#,##0.0000")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        Try
            FormateCamposNumericos()
            HabilitaPanelFechas()
            CargaDatos()
            If Not _CerrarPantalla Then Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub HabilitaPanelFechas()
        Try
            Select Case _Tipo_Id
                Case Enum_CxPMovimientoTipo.Factura, Enum_CxPMovimientoTipo.NotaDebito
                    PnlFechas.Visible = True
                Case Enum_CxPMovimientoTipo.NotaCredito
                    PnlFechas.Visible = True
                    DtpFechaEmision.Visible = True
                    DtpFechaEntrega.Visible = False
                    DtpFechaVencimiento.Visible = False
                    Label4.Visible = True
                    Label9.Visible = False
                    Label5.Visible = False
                Case Else
                    PnlFechas.Visible = False
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim Fecha As Date
        Dim Proveedor As New TProveedor
        Dim TipoMovimiento As New TCxPMovimientoTipo

        Try
            Fecha = EmpresaInfo.Getdate

            With TipoMovimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = _Tipo_Id
            End With
            VerificaMensaje(TipoMovimiento.ListKey)

            If TipoMovimiento.RowsAffected = 0 Then
                VerificaMensaje("Debe de seleccionar un tipo de movimiento válido")
            End If

            If Not TipoMovimiento.Activo Then
                VerificaMensaje("El tipo de movimiento seleccionado no se encuentra disponible")
            End If

            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = _Prov_Id
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("No se encontró un proveedor con el código " & _Prov_Id)
            End If

            If Not Proveedor.Activo Then
                VerificaMensaje("El proveedor seleccionado se encuentra inactivo")
            End If

            Me.Text = _Titulo
            TxtFecha.Text = Format(Fecha, "dd/MM/yyyy")
            TxtTipo.Text = TipoMovimiento.Nombre
            TxtMontoDolares.Text = "0.00"
            TxtMonto.Text = Format(_Monto, "#,##0.00")
            LblProveedor.Text = Proveedor.Nombre
            CmbMoneda.SelectedIndex = 0
            DtpFechaEmision.Value = Fecha
            DtpFechaVencimiento.Value = Fecha
            DtpFechaEntrega.Value = Fecha
            _IncrementaSaldo = TipoMovimiento.IncrementaSaldo
            If _IncrementaSaldo Then
                _TipoCambio = TipoCambioCxP()
            Else
                _TipoCambio = TipoCambioCxP()
            End If
            TxtTipoCambio.Text = Format(_TipoCambio, "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
            _CerrarPantalla = True
            Me.Close()
        Finally
            Proveedor = Nothing
            TipoMovimiento = Nothing
        End Try
    End Sub


    Private Function ValidaTodo() As Boolean
        Try
            If CmbMoneda.SelectedIndex < 0 Or CmbMoneda.SelectedIndex > 1 Then
                VerificaMensaje("La moneda seleccionada no es válida")
            End If

            If Not IsNumeric(TxtMonto.Text.Trim) Then
                TxtMonto.SelectAll()
                VerificaMensaje("Debe de ingresar un monto")
            End If

            If CDbl(TxtMonto.Text.Trim) <= 0 Then
                TxtMonto.SelectAll()
                VerificaMensaje("El monto debe de ser mayor a 0")
            End If

            If _Tipo_Id = Enum_CxPMovimientoTipo.Factura Or _Tipo_Id = Enum_CxPMovimientoTipo.NotaDebito Then
                If DateValue(DtpFechaVencimiento.Value) < DateValue(DtpFechaEmision.Value) Then
                    VerificaMensaje("La fecha de emisión no puede ser posterior a la de vencimiento")
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub GuardarMovimiento()
        Dim Movimiento As New TCxPMovimiento
        Dim Moneda As Char = ""
        Dim Tipo As Char = ""

        Try
            Moneda = IIf(CmbMoneda.SelectedIndex = 0, coMonedaColones, coMonedaDolares)


            With Movimiento.AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Annio = DateValue(DtpFechaEmision.Value).Year
                .Mes = DateValue(DtpFechaEmision.Value).Month
                .Fecha = DateValue(DtpFechaEmision.Value)
                .Tipo_Id = Enum_AsientoTipo.CxP
                .Comentario = TxtReferencia.Text.Trim
                .Debitos = 0
                .Creditos = 0
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .Origen_Id = Enum_AsientoOrigen.CXP
                .MAC_Address = InfoMaquina.MAC_Address
            End With

            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = _Tipo_Id
                .Prov_Id = _Prov_Id
                .Estado_Id = Enum_CxPMovimientoEstado.Pendiente
                .Referencia = TxtReferencia.Text.Trim
                .Moneda = IIf(CmbMoneda.SelectedIndex = 0, coMonedaColones, coMonedaDolares)
                .Monto = CDbl(TxtMonto.Text.Trim)
                .TipoCambio = IIf(.Moneda = coMonedaColones, 1, _TipoCambio)
                .Dolares = IIf(.Moneda = coMonedaColones, 0, .Monto / _TipoCambio)
                .Usuario_Id = UsuarioInfo.Usuario_Id
                If .Tipo_Id = Enum_CxPMovimientoTipo.NotaCredito Then

                    .FechaRecibido = DateValue(DtpFechaEmision.Value)
                    .FechaDocumento = DateValue(DtpFechaEmision.Value)
                    .FechaVencimiento = DateValue(DtpFechaEmision.Value)

                Else

                    .FechaRecibido = DateValue(DtpFechaEntrega.Value)
                    .FechaDocumento = DateValue(DtpFechaEmision.Value)
                    .FechaVencimiento = DateValue(DtpFechaVencimiento.Value)

                End If

                .GeneraAsiento = True
            End With
            VerificaMensaje(Movimiento.Insert)
            _AplicoMovimiento = True
            VerificaMensaje(ImprimeCxPMovimiento(EmpresaInfo, Movimiento.Tipo_Id, Movimiento.Mov_Id, False))
            Mensaje("Se aplicó correctamente el movimiento", Me.Text)
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Movimiento = Nothing
        End Try
    End Sub

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        If ValidaTodo() Then
            GuardarMovimiento()
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMovimientoCrea_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAplicar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub TxtMonto_TextChanged(sender As Object, e As EventArgs) Handles TxtMonto.TextChanged
        Try
            If _ModificandoMonto Then
                Exit Sub
            End If

            If Not IsNumeric(TxtMonto.Text) Then
                TxtMonto.Text = "0.00"
                TxtMonto.SelectAll()
            End If

            _ModificandoMonto = True
            TxtMontoDolares.Text = Format(CDbl(TxtMonto.Text.Trim) / _TipoCambio, "#,##0.0000")

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            _ModificandoMonto = False
        End Try
    End Sub

    Private Sub TxtMontoDolares_TextChanged(sender As Object, e As EventArgs) Handles TxtMontoDolares.TextChanged
        Try
            If _ModificandoMonto Then
                Exit Sub
            End If

            If Not IsNumeric(TxtMontoDolares.Text) Then
                TxtMontoDolares.Text = "0.0000"
                TxtMontoDolares.SelectAll()
            End If

            _ModificandoMonto = True
            TxtMonto.Text = Format(CDbl(TxtMontoDolares.Text.Trim) * _TipoCambio, "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            _ModificandoMonto = False
        End Try
    End Sub

    Private Sub FrmMovimientoCrea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtMonto.Select()
        TxtMonto.SelectAll()
    End Sub

    Private Sub BtnFacturas_Click(sender As Object, e As EventArgs)
        SelecionarFacturasAplicar()
    End Sub

    Private Sub SelecionarFacturasAplicar()
        Dim FormaSeleccion As New FrmSolictaCxPMovimientos
        Dim Monto As Integer = 0
        Dim referencia As String
        Try

            With FormaSeleccion
                .Prov_Id = _Prov_Id
                .Tipo_Id = 1
                .Execute()
            End With

            If Not FormaSeleccion.Selecciono Then
                Exit Sub
            End If
            _ListaMovimiento = Nothing
            _ListaMovimiento = FormaSeleccion.ListaMovimientosCxP

            If _ListaMovimiento.Count > 0 Then
                For Each elemento In _ListaMovimiento
                    Monto += elemento.Monto

                Next

                TxtMonto.Text = Monto

            End If




        Catch ex As Exception

        End Try
    End Sub
End Class