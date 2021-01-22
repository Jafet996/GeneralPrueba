Imports BUSINESS
Public Class FrmMantClienteDetalle


#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
    Dim Cliente As New TCliente
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
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")
            Numerico(1) = New TNumericFormat(TxtLimiteCredito, 8, 2, False, "", "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute(pCodigo As Integer)
        Me.Text = _Titulo
        CargaCombos()
        _GuardoCambios = False

        If Not _Nuevo Then
            TxtNumero.Text = pCodigo
            CargaDatos()
        Else
            TxtDiasCredito.Text = EmpresaParametroInfo.DiasCredito
            TxtLimiteCredito.Text = "0.00"
            TxtDiasGraciaMora.Text = EmpresaParametroInfo.DiasGraciaMora
            ChkAplicaMora.Checked = EmpresaParametroInfo.AplicaMora
            TxtPorcentajeMora.Text = Format(EmpresaParametroInfo.PorcMora, "#,##0.00")
            HabilitaCampos()
        End If

        Me.ShowDialog()
    End Sub

    Private Sub CargaCombos()
        Dim TipoIdentificacion As New TTipoIdentificacion

        Try
            TipoIdentificacion.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(TipoIdentificacion.LoadComboBox(CmbTipoIdentificacion))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoIdentificacion = Nothing
        End Try
    End Sub

    Private Sub HabilitaCampos()
        Try
            If ChkAplicaMora.Checked Then
                TxtPorcentajeMora.Text = EmpresaParametroInfo.PorcMora
                TxtPorcentajeMora.ReadOnly = False
                TxtDiasGraciaMora.Text = EmpresaParametroInfo.DiasGraciaMora
                TxtDiasGraciaMora.ReadOnly = False
            Else
                TxtPorcentajeMora.Text = ""
                TxtPorcentajeMora.ReadOnly = True
                TxtDiasGraciaMora.Text = ""
                TxtDiasGraciaMora.ReadOnly = True
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaDatos()
        Cliente = New TCliente

        Try
            With Cliente
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cliente_Id = CInt(TxtNumero.Text)
            End With
            VerificaMensaje(Cliente.ListKey)

            With Cliente
                CmbTipoIdentificacion.SelectedValue = .TipoIdentificacion_Id
                FormateaIdentificacion()
                TxtIdentificacion.Text = .Identificacion
                TxtNombre.Text = .Nombre
                TxtTelefono1.Text = .Telefono1
                TxtTelefono2.Text = .Telefono2
                TxtEmail.Text = .Email
                TxtDireccion.Text = .Direccion
                TxtDiasCredito.Text = .DiasCredito
                TxtCxCColones.Text = .CxC_Colones
                TxtCxCDolares.Text = .CxC_Dolares
                ChkAplicaMora.Checked = .AplicaMora
                If .AplicaMora Then
                    TxtPorcentajeMora.Text = .PorcMora
                    TxtDiasGraciaMora.Text = .DiasGraciaMora
                End If
                TxtLimiteCredito.Text = Format(.LimiteCredito, "#,##0.00")
                ChkActivo.Checked = .Activo
                ChbInterno.Checked = .EsInterno
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub BusquedaCuenta(pTextBox As TextBox)
        Dim Forma As New FrmBusquedaCuentaContable

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                pTextBox.Text = Forma.Cuenta_Id
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub FormateaIdentificacion()
        Try
            If CmbTipoIdentificacion.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            If CmbTipoIdentificacion.SelectedValue = 1 Then
                TxtIdentificacion.Mask = "0-0000-0000"
            Else
                TxtIdentificacion.Mask = Nothing
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Dim Cliente As New TCliente

        Try
            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If TxtTelefono1.Text.Trim = "" And TxtTelefono2.Text.Trim = "" Then
                TxtTelefono1.Focus()
                VerificaMensaje("Debe de ingresar al menos un teléfono")
            End If

            If TxtIdentificacion.Text.Trim = "" And TxtIdentificacion.Text.Trim = "" Then
                TxtIdentificacion.Focus()
                VerificaMensaje("Debe de ingresar el número de identificación")
            End If

            TxtIdentificacion.Text = TxtIdentificacion.Text.Replace(" ", "")

            If CmbTipoIdentificacion.SelectedValue = 1 AndAlso TxtIdentificacion.Text.Trim.Length <> 11 Then
                VerificaMensaje("El número de cédula de identidad debe de contener 9 digitos númericos")
            End If

            With Cliente
                .Emp_Id = EmpresaInfo.Emp_Id
                .Identificacion = TxtIdentificacion.Text.Trim
            End With
            VerificaMensaje(Cliente.ListKeyByIdentificacion)

            'If Cliente.RowsAffected > 0 Then
            '    If _Nuevo Then
            '        VerificaMensaje("Ya existe registrado un cliente con este numero de identificación")
            '    ElseIf TxtNumero.Text.Trim <> Cliente.Cliente_Id Then
            '        VerificaMensaje("Ya existe registrado un cliente con este numero de identificación")
            '    End If
            'End If

            'If Not ValidaCuentaContable(TxtCxCColones.Text.Trim, True) Then
            '    TxtCxCColones.Focus()
            '    Return False
            'End If

            'If Not ValidaCuentaContable(TxtCxCDolares.Text.Trim, True) Then
            '    TxtCxCDolares.Focus()
            '    Return False
            'End If

            If Not IsNumeric(TxtLimiteCredito.Text.Trim) Then
                TxtLimiteCredito.Focus()
                VerificaMensaje("El limite de crédito debe ser númerico")
            End If

            If CDbl(TxtLimiteCredito.Text.Trim) <= 0 Then
                EnfocarTexto(TxtLimiteCredito)
                VerificaMensaje("El limite de crédito debe de ser mayor a 0")
            End If

            If Not IsNumeric(TxtDiasCredito.Text.Trim) Then
                TxtDiasCredito.Focus()
                VerificaMensaje("Los días de crédito debe ser númerico")
            End If

            If CInt(TxtDiasCredito.Text.Trim) <= 0 Then
                EnfocarTexto(TxtDiasCredito)
                VerificaMensaje("Los días de crédito debe de ser mayor a 0")
            End If

            If ChkAplicaMora.Checked Then
                If Not IsNumeric(TxtPorcentajeMora.Text.Trim) Then
                    TxtPorcentajeMora.Focus()
                    VerificaMensaje("El porcentaje de mora debe ser númerico")
                End If

                If CDbl(TxtPorcentajeMora.Text.Trim) <= 0 Then
                    EnfocarTexto(TxtPorcentajeMora)
                    VerificaMensaje("El porcentaje de mora debe de ser mayor a 0")
                End If

                If Not IsNumeric(TxtDiasGraciaMora.Text.Trim) Then
                    TxtDiasGraciaMora.Focus()
                    VerificaMensaje("Los días de gracia de mora debe ser númerico")
                End If

                If CDbl(TxtDiasGraciaMora.Text.Trim) < 0 Then
                    EnfocarTexto(TxtDiasGraciaMora)
                    VerificaMensaje("Los días de gracia de mora debe de ser mayor o igual a 0")
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
        End Try
    End Function

    Private Sub Guardar()
        Try
            Cliente.Emp_Id = EmpresaInfo.Emp_Id

            If _Nuevo Then
                VerificaMensaje(Cliente.NextOne)
            Else
                Cliente.Cliente_Id = CInt(TxtNumero.Text)
            End If

            With Cliente
                .TipoIdentificacion_Id = CmbTipoIdentificacion.SelectedValue
                .Identificacion = TxtIdentificacion.Text
                .Nombre = TxtNombre.Text
                .Telefono1 = TxtTelefono1.Text
                .Telefono2 = TxtTelefono2.Text
                .Email = TxtEmail.Text
                .Direccion = TxtDireccion.Text
                .DiasCredito = TxtDiasCredito.Text
                .AplicaMora = ChkAplicaMora.Checked
                If .AplicaMora Then
                    .DiasGraciaMora = CInt(TxtDiasGraciaMora.Text.Trim)
                    .PorcMora = CDbl(TxtPorcentajeMora.Text.Trim)
                Else
                    .DiasGraciaMora = 0
                    .PorcMora = 0
                End If
                .LimiteCredito = CDbl(TxtLimiteCredito.Text)
                .CxC_Colones = TxtCxCColones.Text.Trim
                .CxC_Dolares = TxtCxCDolares.Text.Trim
                .Activo = ChkActivo.Checked
                .EsInterno = ChbInterno.Checked
                .Vendedor_Id = Cliente.Vendedor_Id
            End With

            If _Nuevo Then
                VerificaMensaje(Cliente.Insert())
            Else
                VerificaMensaje(Cliente.Modify())
            End If

            _GuardoCambios = True
            Mensaje("Los cambios se almacenaron correctamente")
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            Guardar()
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantClienteDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnGuardar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub FrmMantClienteDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtNombre.Select()
    End Sub

    Private Sub ChkAplicaMora_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAplicaMora.CheckedChanged
        HabilitaCampos()
    End Sub

    Private Sub TxtCuentaxCobrar_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCxCColones.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BusquedaCuenta(TxtCxCColones)
        End Select
    End Sub

    Private Sub TxtCxCDolares_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCxCDolares.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BusquedaCuenta(TxtCxCDolares)
        End Select
    End Sub

    Private Sub CmbTipoIdentificacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbTipoIdentificacion.SelectedValueChanged
        FormateaIdentificacion()
    End Sub

End Class