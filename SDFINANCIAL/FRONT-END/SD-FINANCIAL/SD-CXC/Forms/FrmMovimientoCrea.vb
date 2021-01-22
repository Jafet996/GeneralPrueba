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
    Private _Cliente_Id As Integer = 0
    Private _Tipo_Id As Enum_CxCMovimientoTipo
    Private _ListaMovimiento As New List(Of TCxCMovimientoLinea)
    Private _Monto As Double = 0
    Private _TipoCambio As Double = 0
    Private _AplicoMovimiento As Boolean = False
    Private _CerrarPantalla As Boolean = False
    Private _ModificandoMonto As Boolean = False
    Private _IncrementaSaldo As Boolean
#End Region
#Region "Propiedades"
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public WriteOnly Property Cliente_Id As Integer
        Set(value As Integer)
            _Cliente_Id = value
        End Set
    End Property
    Public WriteOnly Property Tipo_Id As Enum_CxCMovimientoTipo
        Set(value As Enum_CxCMovimientoTipo)
            _Tipo_Id = value
        End Set
    End Property
    Public WriteOnly Property ListaMovimiento As List(Of TCxCMovimientoLinea)
        Set(value As List(Of TCxCMovimientoLinea))
            _ListaMovimiento = value
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
            CargaDatos()
            If Not _CerrarPantalla Then Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub HabilitaPnlFechas()
        Try
            Select Case _Tipo_Id
                Case Enum_CxCMovimientoTipo.Factura, Enum_CxCMovimientoTipo.NotaDebito
                    PnlFechas.Visible = True
                    BtnFacturas.Visible = False
                    Label10.Visible = False
                Case Enum_CxCMovimientoTipo.Recibo
                    PnlFechas.Visible = True
                    Label5.Visible = False
                    Label9.Visible = False
                    Label4.Visible = True
                    DtpFechaEmision.Visible = True
                    DtpFechaEntrega.Visible = False
                    DtpFechaVencimiento.Visible = False
                    BtnFacturas.Visible = False
                    Label10.Visible = False
                Case Enum_CxCMovimientoTipo.NotaCredito
                    PnlFechas.Visible = True
                    Label5.Visible = False
                    Label9.Visible = False
                    DtpFechaEntrega.Visible = False
                    DtpFechaVencimiento.Visible = False
                    BtnFacturas.Visible = True
                    Label10.Visible = True

                Case Else
                    PnlFechas.Visible = False
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim Fecha As Date
        Dim Cliente As New TCliente
        Dim TipoMovimiento As New TCxCMovimientoTipo
        Dim Vendedor As New TVendedor
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

            With Cliente
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = _Cliente_Id

            End With
            VerificaMensaje(Cliente.ListKey)

            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("No se encontró un cliente con el código " & _Cliente_Id)
            End If

            If Not Cliente.Activo Then
                VerificaMensaje("El cliente seleccionado se encuentra inactivo")
            End If

            With Vendedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Vendedor_Id = Cliente.Vendedor_Id
            End With

            VerificaMensaje(Vendedor.ListKey)



            LblVendedor.Text = Vendedor.Nombre
            Me.Text = _Titulo
            TxtFecha.Text = Format(EmpresaInfo.Getdate, "dd/MM/yyyy")
            TxtTipo.Text = TipoMovimiento.Nombre
            TxtMontoDolares.Text = "0.00"
            TxtMonto.Text = Format(_Monto, "#,##0.00")
            LblCliente.Text = Cliente.Nombre

            If _Tipo_Id = Enum_CxCMovimientoTipo.Factura Or _Tipo_Id = Enum_CxCMovimientoTipo.NotaDebito Then
                ChkAplicaMora.Visible = True
                ChkAplicaMora.Checked = Cliente.AplicaMora

            Else
                ChkAplicaMora.Visible = False
                ChkAplicaMora.Checked = False
            End If

            CmbMoneda.SelectedIndex = 0
            DtpFechaEmision.Value = Fecha
            DtpFechaVencimiento.Value = DateAdd(DateInterval.Day, Cliente.DiasCredito, Fecha)
            _IncrementaSaldo = TipoMovimiento.IncrementaSaldo

            If _Tipo_Id = Enum_CxCMovimientoTipo.Recibo Then
                _TipoCambio = GetTipoCambioCierre(CajaInfo.Cierre_Id)
                If _TipoCambio = 0 Then
                    _CerrarPantalla = True
                    Exit Sub
                End If
            Else
                If _IncrementaSaldo Then
                    _TipoCambio = TipoCambioCxC()
                Else
                    _TipoCambio = TipoCambioCxC()
                End If
            End If

            TxtTipoCambio.Text = Format(_TipoCambio, "#,##0.00")
            HabilitaPnlFechas()
        Catch ex As Exception
            MensajeError(ex.Message)
            _CerrarPantalla = True
            Me.Close()
        Finally
            Cliente = Nothing
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
                VerificaMensaje("Debe de ingresar un monto.")
            End If

            If CDbl(TxtMonto.Text.Trim) <= 0 Then
                TxtMonto.SelectAll()
                VerificaMensaje("El monto debe de ser mayor a 0.")
            End If

            If _Tipo_Id = Enum_CxCMovimientoTipo.Factura Or _Tipo_Id = Enum_CxCMovimientoTipo.NotaDebito Then
                If DateValue(DtpFechaVencimiento.Value) < DateValue(DtpFechaEmision.Value) Then
                    VerificaMensaje("La fecha de Emisión no puede ser posterior a la de vencimiento.")
                End If
            End If

            If _Tipo_Id = Enum_CxCMovimientoTipo.Recibo Then
                VerificaMensaje(ValidaCierreCaja)
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub GuardarMovimiento()
        Dim FormaPagoFisico As New FrmMovimientoPagoFisico
        Dim FormaPagoElectronico As New FrmMovimientoPagoElectronico
        Dim FormaPago As New FrmMovimientoFormaPago
        Dim FormaVuelto As New FrmVuelto
        Dim Cliente As New TCliente
        Dim Movimiento As New TCxCMovimiento
        Dim Moneda As Char = ""
        Dim Tipo As Char = ""
        Dim Vuelto As Double = 0.0
        Dim ExedentePago As Double = 0.0

        Try
            Moneda = IIf(CmbMoneda.SelectedIndex = 0, coMonedaColones, coMonedaDolares)

            If _Tipo_Id = Enum_CxCMovimientoTipo.Recibo Then
                FormaPago.Execute()

                If Not FormaPago.Acepto Then
                    Exit Sub
                End If

                Select Case FormaPago.TipoTransaccion
                    Case Enum_TipoTransaccion.Fisica
                        With FormaPagoFisico
                            .TotalFactura = CDbl(TxtMonto.Text.Trim)
                            .Execute()
                        End With

                        If Not FormaPagoFisico.PagoDocumento Then
                            Exit Sub
                        End If

                        Vuelto = FormaPagoFisico.Vuelto
                        Movimiento.ListaPagos = FormaPagoFisico.MovimientoPagos
                    Case Enum_TipoTransaccion.Electronica
                        With FormaPagoElectronico
                            .TotalFactura = TxtMonto.Text.Trim
                            .Execute()
                        End With

                        If Not FormaPagoElectronico.PagoDocumento Then
                            Exit Sub
                        End If

                        If FormaPagoElectronico.GeneraNotaCredito Then
                            With Movimiento
                                .GeneraNotaCredito = True
                                .MontoNotaCredito = FormaPagoElectronico.Vuelto
                            End With
                        End If

                        Movimiento.ListaPagos = FormaPagoElectronico.MovimientoPagos
                    Case Else
                        VerificaMensaje("El tipo de transacción seleccionado no es válido")
                End Select

                With Cliente
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Cliente_Id = _Cliente_Id
                End With
                VerificaMensaje(Cliente.ListKey)

                If Cliente.RowsAffected = 0 Then
                    VerificaMensaje("No se encontró un cliente con el código " & _Cliente_Id)
                End If

                If Cliente.Saldo > 0 AndAlso Cliente.Saldo < CDbl(TxtMonto.Text.Trim) Then
                    ExedentePago = CDbl(TxtMonto.Text.Trim) - Cliente.Saldo

                    With Movimiento
                        .GeneraNotaCredito = True
                        .MontoNotaCredito += ExedentePago
                    End With
                End If
            End If


            With Movimiento
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = _Tipo_Id
                .Cliente_Id = _Cliente_Id
                .Referencia = TxtReferencia.Text.Trim
                .Moneda = Moneda
                .Monto = CDbl(TxtMonto.Text.Trim) - ExedentePago
                .TipoCambio = IIf(.Moneda = coMonedaColones, 1, _TipoCambio)
                .Dolares = IIf(.Moneda = coMonedaColones, 0, .Monto / _TipoCambio)
                .Usuario_Id = UsuarioInfo.Usuario_Id
                .AplicaMora = ChkAplicaMora.Checked
                .ListaMovimientos = _ListaMovimiento
                .MAC_Address = InfoMaquina.MAC_Address
                .GeneraAsiento = False
                If _Tipo_Id = Enum_CxCMovimientoTipo.Factura Or _Tipo_Id = Enum_CxCMovimientoTipo.NotaDebito Then
                    .FechaRecibido = DateValue(DtpFechaEntrega.Value)
                    .FechaDocumento = DateValue(DtpFechaEmision.Value)
                    .FechaVencimiento = DateValue(DtpFechaVencimiento.Value)
                ElseIf _Tipo_Id = Enum_CxCMovimientoTipo.Recibo Then
                    .FechaRecibido = DateValue(DtpFechaEmision.Value)
                    .FechaDocumento = DateValue(DtpFechaEmision.Value)
                    .FechaVencimiento = DateValue(DtpFechaEmision.Value)

                ElseIf _Tipo_Id = Enum_CxCMovimientoTipo.NotaCredito Then
                    .FechaRecibido = DateValue(DtpFechaEmision.Value)
                    .FechaDocumento = DateValue(DtpFechaEmision.Value)
                    .FechaVencimiento = DateValue(DtpFechaEmision.Value)

                Else
                    .FechaRecibido = DateValue(EmpresaInfo.Getdate())
                    .FechaDocumento = .FechaRecibido
                    .FechaVencimiento = .FechaDocumento
                End If
                If _Tipo_Id = Enum_CxCMovimientoTipo.Recibo Then
                    .Caja_Id = CajaInfo.Caja_Id
                    .Cierre_Id = CajaInfo.Cierre_Id
                Else
                    .Caja_Id = 0
                    .Cierre_Id = 0
                End If
            End With
            VerificaMensaje(Movimiento.Insert)
            _AplicoMovimiento = True

            For Each Fila As DataRow In Movimiento.Datos.Tables("Movimientos").Rows
                    VerificaMensaje(ImprimeMovimiento(EmpresaInfo, CInt(Fila(0)), CInt(Fila(1)), False))
                Next

            If Vuelto > 0 Then
                FormaVuelto.Execute(Vuelto)
            Else
                Mensaje("Se aplicó correctamente el movimiento")
            End If

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaVuelto = Nothing
            FormaPago = Nothing
            FormaPagoFisico = Nothing
            FormaPagoElectronico = Nothing
            Movimiento = Nothing
            Cliente = Nothing
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

    Private Sub SelecionarFacturasAplicar()
        Dim FormaSeleccion As New FrmSolictaCxCMovimientos
        Dim Monto As Integer = 0
        Dim referencia As String
        Try

            With FormaSeleccion
                .Cliente_Id = _Cliente_Id
                .Execute()
            End With

            If Not FormaSeleccion.Selecciono Then
                Exit Sub
            End If
            _ListaMovimiento = Nothing
            _ListaMovimiento = FormaSeleccion.ListaMovimientos

            If _ListaMovimiento.Count > 0 Then
                For Each elemento In _ListaMovimiento
                    Monto += elemento.Monto
                Next

                TxtMonto.Text = Monto

            End If




        Catch ex As Exception


        End Try
    End Sub



    Private Sub BtnFacturas_Click(sender As Object, e As EventArgs) Handles BtnFacturas.Click
        SelecionarFacturasAplicar()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class