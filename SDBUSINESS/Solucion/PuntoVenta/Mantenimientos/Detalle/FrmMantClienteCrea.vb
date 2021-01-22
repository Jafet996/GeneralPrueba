Imports Business
Public Class FrmMantClienteCrea
#Region "Enum"
    Private Enum ColumnasContactos
        Nombre = 0
    End Enum
#End Region
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private Cliente As New TCliente(EmpresaInfo.Emp_Id)
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
    Private _ClienteNuevo As Integer
    Private _Cargando As Boolean = True

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
    Public ReadOnly Property ClienteNuevo As Integer
        Get
            Return _ClienteNuevo
        End Get
    End Property
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(7)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")
            Numerico(1) = New TNumericFormat(TxtLimiteCredito, 7, 2, False, "", "#,##0.00")
            Numerico(2) = New TNumericFormat(TxtPorcDescContado, 3, 2, True, "", "#,##0.00")
            Numerico(3) = New TNumericFormat(TxtPorcDescCredito, 3, 2, True, "", "#,##0.00")

            Numerico(4) = New TNumericFormat(TxtDiasCredito, 4, 0, False, "", "###")
            Numerico(5) = New TNumericFormat(TxtDiasGraciaMora, 4, 0, False, "", "###")
            Numerico(6) = New TNumericFormat(TxtPorcMora, 3, 2, False, "", "#,##0.00")
            Numerico(7) = New TNumericFormat(TxtLimiteCredito, 9, 2, False, "", "#,##0.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaCombos()
        Dim ClientePrecio As New TClientePrecio(EmpresaInfo.Emp_Id)
        Dim TipoIdentificacion As New TTipoIdentificacion(EmpresaInfo.Emp_Id)
        Dim Provincia As New TProvincia(EmpresaInfo.Emp_Id)
        Dim TipoDocumentoElectronico As New TTipoDocumentoElectronico(EmpresaInfo.Emp_Id)
        Dim Vendedor As New TVendedor(EmpresaInfo.Emp_Id)
        Dim Plantilla As New TFeAdjuntoEncabezado(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(ClientePrecio.LoadComboBox(CmbPrecio))
            VerificaMensaje(TipoIdentificacion.LoadComboBox(CmbTipoIdentificacion))
            VerificaMensaje(Provincia.LoadComboBox(CmbProvincia))
            VerificaMensaje(TipoDocumentoElectronico.LoadComboBox(CmbDocumentoElectronico))
            VerificaMensaje(Vendedor.LoadComboBox(CmbVendedor))
            VerificaMensaje(Plantilla.LoadComboBox(CmbPlantilla))

            CmbTipoIdentificacion_SelectedIndexChanged(CmbTipoIdentificacion, EventArgs.Empty)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ClientePrecio = Nothing
            TipoIdentificacion = Nothing
            Provincia = Nothing
            TipoDocumentoElectronico = Nothing
        End Try
    End Sub

    Private Sub CargaDatos()
        Try
            Cliente.Cliente_Id = CInt(TxtNumero.Text)
            VerificaMensaje(Cliente.ListKey())

            With Cliente
                TxtNombre.Text = .Nombre
                TxtNombreComercial.Text = .NombreComercial
                TxtTelefono1.Text = .Telefono1
                TxtTelefono2.Text = .Telefono2
                TxtApartado.Text = .Apartado
                TxtEmail.Text = .Email
                txtCorreoCotizaciones.Text = .CorreoCotizaciones
                TxtDireccion.Text = .Direccion
                TxtLimiteCredito.Text = Format(.LimiteCredito, "#,##0.00")

                TxtCxCColones.Text = .CxC_Colones
                TxtCxCDolares.Text = .CxC_Dolares

                TxtDiasCredito.Text = .DiasCredito
                TxtDiasGraciaMora.Text = .DiasGraciaMora
                TxtPorcMora.Text = Format(.PorcMora, "#,##0.00")
                ChkAplicaMora.Checked = .AplicaMora
                ChkFacturaCredito.Checked = .FacturaCredito
                TxtPorcDescContado.Text = Format(.PorcDescContado, "#,##0.00")
                TxtPorcDescCredito.Text = Format(.PorcDescCredito, "#,##0.00")
                ChkActivo.Checked = .Activo
                ChkAcumulaPuntos.Checked = .AcumulaPuntos
                CmbPrecio.SelectedValue = .Precio_Id
                CmbTipoIdentificacion.SelectedValue = .TipoIdentificacion_Id
                TxtCedula.Text = .Cedula
                CmbProvincia.SelectedValue = .Provincia_Id
                CmbCanton.SelectedValue = .Canton_Id
                CmbDistrito.SelectedValue = .Distrito_Id
                CmbBarrio.SelectedValue = .Barrio_Id
                txtReferencia.Text = .Referencia
                TxtAnotaciones.Text = .Anotaciones
                CmbDocumentoElectronico.SelectedValue = .TipoDoc
                CmbVendedor.SelectedValue = .Vendedor_id
                CmbPlantilla.SelectedValue = .Adjunto_Id
                VerificaMensaje(Cliente.ConsultaContactosCliente())
                For Each item In .Contactos
                    LvwAnotaciones.Items.Add(item.ToString())
                Next

            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(pCodigo As Integer)
        Me.Text = _Titulo
        _GuardoCambios = False
        _ClienteNuevo = 0

        CargaCombos()

        If Not _Nuevo Then
            TxtNumero.Text = pCodigo
            CargaDatos()
        Else
            TxtDiasCredito.Text = EmpresaParametroInfo.DiasCredito
            TxtDiasGraciaMora.Text = EmpresaParametroInfo.DiasGraciaMora
            TxtPorcMora.Text = Format(EmpresaParametroInfo.PorcMora, "#,##0.00")
            ChkAplicaMora.Checked = True
            ChkFacturaCredito.Checked = False
            TxtPorcDescContado.Text = "0.00"
            TxtPorcDescCredito.Text = "0.00"
            TxtLimiteCredito.Text = "1.00"

            CmbDocumentoElectronico.SelectedValue = EmpresaParametroInfo.FeTipoDocumentoCliente

            _Cargando = False
        End If

        TxtNumero.Focus()
        _Cargando = False

        Me.ShowDialog()
    End Sub

    'Private Sub HabilitaCampos()
    '    Try
    '        'If _Cargando Then
    '        '    Exit Sub
    '        'End If

    '        If ChkFacturaCredito.Checked Then
    '            TxtLimiteCredito.ReadOnly = False
    '            TxtDiasCredito.Text = EmpresaParametroInfo.DiasCredito
    '            TxtDiasCredito.ReadOnly = False
    '            TxtCxCColones.ReadOnly = False
    '            TxtCxCDolares.ReadOnly = False
    '            ChkAplicaMora.Enabled = True
    '            If ChkAplicaMora.Checked Then
    '                TxtPorcMora.Text = EmpresaParametroInfo.PorcMora
    '                TxtPorcMora.ReadOnly = False
    '                TxtDiasGraciaMora.Text = EmpresaParametroInfo.DiasGraciaMora
    '                TxtDiasGraciaMora.ReadOnly = False
    '            Else
    '                TxtPorcMora.Text = ""
    '                TxtPorcMora.ReadOnly = True
    '                TxtDiasGraciaMora.Text = ""
    '                TxtDiasGraciaMora.ReadOnly = True
    '            End If
    '        Else
    '            TxtLimiteCredito.Text = "0.00"
    '            TxtLimiteCredito.ReadOnly = True
    '            TxtDiasCredito.Text = ""
    '            TxtDiasCredito.ReadOnly = True
    '            ChkAplicaMora.Checked = False
    '            ChkAplicaMora.Enabled = False
    '            TxtCxCColones.ReadOnly = True
    '            TxtCxCDolares.ReadOnly = True


    '            TxtPorcMora.Text = ""
    '            TxtPorcMora.ReadOnly = True
    '            TxtDiasGraciaMora.Text = ""
    '            TxtDiasGraciaMora.ReadOnly = True
    '        End If
    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    End Try
    'End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantCategoriaDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                BtnGuardar.PerformClick()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub BusquedaCuenta()
        'Dim Forma As New FrmBusquedaCuentaContable

        'Try
        '    Forma.Execute()

        '    If Forma.Selecciono Then
        '        TxtCuentaxCobrar.Text = Forma.Cuenta_Id
        '    End If

        'Catch ex As Exception
        '    MensajeError(ex.Message)
        'Finally
        '    Forma = Nothing
        'End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            '------- Valida Email ------------------------------------------------------
            If EmpresaParametroInfo.FacturacionElectronica Then
                If TxtEmail.Text.Trim() = String.Empty Then
                    TxtEmail.Select()
                    VerificaMensaje("El email es necesario para la creación de un cliente para Facturación Electrónica")
                End If

                If TxtEmail.Text.Trim() <> String.Empty Then
                    If ValidaEmail(TxtEmail.Text.Trim()) <> String.Empty Then
                        TxtEmail.Select()
                        VerificaMensaje("Formato de email no válido")
                    End If
                End If
            End If

            '------- Valida Telefono ---------------------------------------------------
            If EmpresaParametroInfo.FacturacionElectronica AndAlso EmpresaParametroInfo.FeReceptor AndAlso EmpresaParametroInfo.FeReceptorTelefono Then
                If TxtTelefono1.Text.Trim = "" Then
                    TxtTelefono1.Focus()
                    VerificaMensaje("Debe de ingresar al menos un teléfono")
                End If

                If InStr(TxtTelefono1.Text, "-") > 0 Then
                    TxtTelefono1.Focus()
                    VerificaMensaje("El número de teléfono no puede contener guiones debe de ser un valor numerico")
                End If

                If InStr(TxtTelefono1.Text.Trim, " ") > 0 Then
                    TxtTelefono1.Focus()
                    VerificaMensaje("El número de teléfono no puede contener espacios")
                End If

                If Mid(TxtTelefono1.Text, 1, 1) = "0" Then
                    TxtTelefono1.Focus()
                    VerificaMensaje("El número de teléfono no puede iniciar con cero")
                End If

                If Not IsNumeric(TxtTelefono1.Text) Then
                    TxtTelefono1.Focus()
                    VerificaMensaje("El número de teléfono debe de ser un valor numérico")
                End If

                If TxtTelefono1.Text.Trim.Length < 8 Then
                    TxtTelefono1.Focus()
                    VerificaMensaje("El número de teléfono debe de tener al menos 8 digitos")
                End If
            End If


            If CmbTipoIdentificacion.SelectedValue Is Nothing OrElse CmbTipoIdentificacion.SelectedIndex < 0 Then
                CmbTipoIdentificacion.Focus()
                VerificaMensaje("Debe de seleccionar el tipo de identificacion")
            End If

            '------- Valida cedula ---------------------------------------------------
            If EmpresaParametroInfo.FacturacionElectronica AndAlso EmpresaParametroInfo.FeReceptor AndAlso EmpresaParametroInfo.FeReceptorIdentificacion Then
                If TxtCedula.Text.Trim = String.Empty Then
                    TxtCedula.Focus()
                    VerificaMensaje("Debe de ingresar el numero de identificacion")
                End If

                If InStr(TxtCedula.Text, "-") > 0 Then
                    TxtCedula.Focus()
                    VerificaMensaje("El número de identificacion no puede contener guiones debe de ser un valor numerico")
                End If

                If InStr(TxtCedula.Text.Trim, " ") > 0 Then
                    TxtCedula.Focus()
                    VerificaMensaje("El número de identificacion no puede contener espacios")
                End If

                If Mid(TxtCedula.Text, 1, 1) = "0" Then
                    TxtCedula.Focus()
                    VerificaMensaje("El número de identificacion no puede iniciar con cero")
                End If

                If Not IsNumeric(TxtCedula.Text) Then
                    TxtCedula.Focus()
                    VerificaMensaje("El número de identificacion debe de ser un valor numérico")
                End If

                Select Case CmbTipoIdentificacion.SelectedValue
                    Case Enum_TipoIdentificacion.Fisica 'Cedula Fisica
                        If TxtCedula.Text.Trim.Length <> 9 Then
                            TxtCedula.Focus()
                            VerificaMensaje("El número de identificacion debe de contener 9 digitos")
                        End If
                    Case Enum_TipoIdentificacion.Juridica, Enum_TipoIdentificacion.NITE 'Cedula Juridica - NITE
                        If TxtCedula.Text.Trim.Length <> 10 Then
                            TxtCedula.Focus()
                            VerificaMensaje("El número de identificacion debe de contener 10 digitos")
                        End If
                    Case Enum_TipoIdentificacion.DIMEX 'DIMEX
                        If TxtCedula.Text.Trim.Length <> 11 And TxtCedula.Text.Trim.Length <> 12 Then
                            TxtCedula.Focus()
                            VerificaMensaje("El número de identificacion debe de contener 11 ó 12 digitos")
                        End If
                End Select
            End If

            If Not IsNumeric(TxtPorcDescContado.Text) OrElse Math.Abs(CDbl(TxtPorcDescContado.Text)) > 100 Then
                TxtPorcDescContado.Focus()
                VerificaMensaje("El porcentaje de descuento debe de estar entre 0 y 100")
            End If

            If Not IsNumeric(TxtPorcDescCredito.Text) OrElse Math.Abs(CDbl(TxtPorcDescCredito.Text)) > 100 Then
                TxtPorcDescCredito.Focus()
                VerificaMensaje("El porcentaje de descuento debe de estar entre 0 y 100")
            End If


            If CmbProvincia.SelectedValue Is Nothing OrElse CmbProvincia.SelectedIndex < 0 Then
                CmbProvincia.Focus()
                VerificaMensaje("Debe de seleccionar la provincia")
            End If

            If CmbCanton.SelectedValue Is Nothing OrElse CmbCanton.SelectedIndex < 0 Then
                CmbCanton.Focus()
                VerificaMensaje("Debe de seleccionar el canton")
            End If

            If CmbDistrito.SelectedValue Is Nothing OrElse CmbBarrio.SelectedIndex < 0 Then
                CmbBarrio.Focus()
                VerificaMensaje("Debe de seleccionar el barrio")
            End If

            If CmbBarrio.SelectedValue Is Nothing OrElse CmbDistrito.SelectedIndex < 0 Then
                CmbDistrito.Focus()
                VerificaMensaje("Debe de seleccionar el distrito")
            End If

            TxtDireccion.Text = TxtDireccion.Text.Replace("'", " ")


            '------- Valida cedula ---------------------------------------------------
            If EmpresaParametroInfo.FacturacionElectronica AndAlso EmpresaParametroInfo.FeReceptor AndAlso EmpresaParametroInfo.FeReceptorUbicacion Then
                If TxtDireccion.Text.Trim.Length = 0 Then
                    TxtDireccion.Focus()
                    VerificaMensaje("Debe de indicar la dirección")
                End If
            End If


            If ChkFacturaCredito.Checked Then
                If TxtCxCColones.Text.Trim <> String.Empty Then
                    If Not ValidaCuentaContableSD(TxtCxCColones.Text.Trim) Then
                        TxtCxCColones.Focus()
                        VerificaMensaje("Si el cliente permite facturas de credito debe de tener una cuenta x cobrar asignada")
                    End If
                End If

                If TxtCxCDolares.Text.Trim <> String.Empty Then
                    If Not ValidaCuentaContableSD(TxtCxCDolares.Text.Trim) Then
                        TxtCxCDolares.Focus()
                        VerificaMensaje("Si el cliente permite facturas de credito debe de tener una cuenta x cobrar asignada")
                    End If
                End If

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
                    If Not IsNumeric(TxtPorcMora.Text.Trim) Then
                        TxtPorcMora.Focus()
                        VerificaMensaje("El porcentaje de mora debe ser númerico")
                    End If

                    If CDbl(TxtPorcMora.Text.Trim) <= 0 Then
                        EnfocarTexto(TxtPorcMora)
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
            End If

            If CmbDocumentoElectronico.SelectedIndex < 0 Then
                VerificaMensaje("Debe de seleccionar un tipo de documento electrónico")
            End If


            If CmbTipoIdentificacion.SelectedValue = Enum_TipoIdentificacion.Extranjero And CmbDocumentoElectronico.SelectedValue <> coTiqueteElectronico Then
                VerificaMensaje("Si el cliente es un extranjero únicamente puede generar Tiquete Electrónico")
            End If



            Dim FacturaCredito As Boolean = (Cliente.FacturaCredito = -1)

            If (FacturaCredito <> ChkFacturaCredito.Checked) And (Not _Nuevo) Then
                If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.OtorgaCredito, False) Then
                    VerificaMensaje("No posee persimo para otorgar credito a los clientes")
                End If
            End If

            If ChkFacturaCredito.Checked Then

                If _Nuevo Then
                    If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.OtorgaCredito, False) Then
                        VerificaMensaje("No posee persimo para otorgar credito a los clientes")
                    End If

                Else

                    If Cliente.DiasCredito <> Integer.Parse(TxtDiasCredito.Text) Or Cliente.DiasGraciaMora <> Integer.Parse(TxtDiasGraciaMora.Text) Or Cliente.PorcMora <> Double.Parse(TxtPorcMora.Text) Or Cliente.LimiteCredito <> Double.Parse(TxtLimiteCredito.Text) Then
                        If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.OtorgaCredito, False) Then
                            VerificaMensaje("No posee persimo para otorgar credito a los clientes")
                        End If
                    End If

                End If


            End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)

            Return False
        End Try
    End Function

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            Guardar()
        End If
    End Sub

    Private Sub Guardar()
        Try
            If _Nuevo Then
                VerificaMensaje(Cliente.Siguiente())
            Else
                Cliente.Cliente_Id = CInt(TxtNumero.Text)
            End If

            With Cliente
                .Nombre = TxtNombre.Text.Trim.ToUpper
                .NombreComercial = TxtNombreComercial.Text.Trim.ToUpper
                .Telefono1 = TxtTelefono1.Text
                .Telefono2 = TxtTelefono2.Text
                .Email = TxtEmail.Text
                .CorreoCotizaciones = txtCorreoCotizaciones.Text
                .Direccion = TxtDireccion.Text
                .Apartado = TxtApartado.Text
                .PorcDescContado = CDbl(TxtPorcDescContado.Text)
                .PorcDescCredito = CDbl(TxtPorcDescCredito.Text)
                .FacturaCredito = ChkFacturaCredito.Checked

                .CxC_Colones = TxtCxCColones.Text.Trim
                .CxC_Dolares = TxtCxCDolares.Text.Trim
                .LimiteCredito = CDbl(TxtLimiteCredito.Text.Trim)
                .DiasCredito = CInt(TxtDiasCredito.Text.Trim)
                .AplicaMora = ChkAplicaMora.Checked
                If TxtDiasGraciaMora.Text.Trim.Equals("") Then
                    .DiasGraciaMora = 0
                Else
                    .DiasGraciaMora = CInt(TxtDiasGraciaMora.Text.Trim)
                End If

                .PorcMora = CDbl(TxtPorcMora.Text.Trim)

                .Precio_Id = CmbPrecio.SelectedValue
                .Activo = ChkActivo.Checked
                .AcumulaPuntos = ChkAcumulaPuntos.Checked

                .TipoIdentificacion_Id = CmbTipoIdentificacion.SelectedValue
                .Cedula = TxtCedula.Text
                .Provincia_Id = CmbProvincia.SelectedValue
                .Canton_Id = CmbCanton.SelectedValue
                .Distrito_Id = CmbDistrito.SelectedValue
                .Barrio_Id = CmbBarrio.SelectedValue
                .Referencia = txtReferencia.Text.Trim()
                .Anotaciones = DepuraTexto(TxtAnotaciones.Text.Trim())
                .TipoDoc = CmbDocumentoElectronico.SelectedValue
                .Vendedor_id = CmbVendedor.SelectedValue
                .Adjunto_Id = CmbPlantilla.SelectedValue

                .Contactos.Clear()
                For Each item As ListViewItem In LvwAnotaciones.Items
                    .Contactos.Add(item.SubItems(0).Text.ToString)
                Next


            End With

            If _Nuevo Then
                VerificaMensaje(Cliente.Insert())
                _ClienteNuevo = Cliente.Cliente_Id
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
    Private Sub FrmMantClienteDetalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        TxtNombre.Select()
    End Sub

    Private Sub TxtCuentaxCobrar_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F1
                BusquedaCuenta()
        End Select
    End Sub

    Private Sub ChkFacturaCredito_CheckedChanged(sender As Object, e As EventArgs)
        GroupCredito.Enabled = ChkFacturaCredito.Checked
        'HabilitaCampos()
        'ChkAplicaMora.Checked = ChkFacturaCredito.Checked
    End Sub

    Private Sub ChkAplicaMora_CheckedChanged(sender As Object, e As EventArgs)
        'HabilitaCampos()
    End Sub

    Private Sub TxtCxCColones_KeyDown(sender As Object, e As KeyEventArgs)
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCxCColones.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCxCDolares_KeyDown(sender As Object, e As KeyEventArgs)
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCxCDolares.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CmbProvincia_SelectedValueChanged(sender As Object, e As EventArgs)
        CargarComboCanton()
    End Sub

    Private Sub CmbCanton_SelectedValueChanged(sender As Object, e As EventArgs)
        CargarComboDistrito()
    End Sub
    Private Sub CargarComboCanton()
        Dim Canton As New TCanton(EmpresaInfo.Emp_Id)

        Try
            If CmbProvincia.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            Canton.Provincia_Id = CmbProvincia.SelectedValue
            VerificaMensaje(Canton.LoadComboBox(CmbCanton))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Canton = Nothing
        End Try
    End Sub

    Private Sub CargarComboDistrito()
        Dim Distrito As New TDistrito(EmpresaInfo.Emp_Id)

        Try
            If CmbProvincia.SelectedValue Is Nothing OrElse CmbCanton.SelectedValue Is Nothing OrElse
                CmbProvincia.SelectedValue.ToString = "System.Data.DataRowView" OrElse CmbCanton.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            With Distrito
                .Provincia_Id = CmbProvincia.SelectedValue
                .Canton_Id = CmbCanton.SelectedValue
            End With
            VerificaMensaje(Distrito.LoadComboBox(CmbDistrito))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Distrito = Nothing
        End Try
    End Sub

    Private Sub CargarComboBarrio()
        Dim Barrio As New TBarrio(EmpresaInfo.Emp_Id)

        Try
            If CmbProvincia.SelectedValue Is Nothing OrElse CmbCanton.SelectedValue Is Nothing OrElse CmbDistrito.SelectedValue Is Nothing OrElse
                CmbProvincia.SelectedValue.ToString = "System.Data.DataRowView" OrElse CmbCanton.SelectedValue.ToString = "System.Data.DataRowView" OrElse CmbDistrito.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            With Barrio
                .Provincia_Id = CmbProvincia.SelectedValue
                .Canton_Id = CmbCanton.SelectedValue
                .Distrito_Id = CmbDistrito.SelectedValue
            End With
            VerificaMensaje(Barrio.LoadComboBox(CmbBarrio))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Barrio = Nothing
        End Try
    End Sub

    Private Sub CmbDistrito_SelectedValueChanged(sender As Object, e As EventArgs)
        CargarComboBarrio()
    End Sub

    Private Sub CmbTipoIdentificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoIdentificacion.SelectedIndexChanged
        Try

            If CmbTipoIdentificacion.SelectedValue Is Nothing OrElse CmbTipoIdentificacion.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            TxtCedula.Text = ""
            Select Case CmbTipoIdentificacion.SelectedValue
                Case 1 'CedulaFisica
                    TxtCedula.MaxLength = 9
                    LblCedulaInfo.Text = "La 'Cédula física' debe de contener 9 dígitos, sin cero al inicio y sin guiones"
                Case 2 'Cedula Juridica
                    TxtCedula.MaxLength = 10
                    LblCedulaInfo.Text = "La 'cédula de personas Jurídicas' debe contener 10 dígitos y sin guiones"
                Case 3 'DIMEX(Pasaporte)
                    TxtCedula.MaxLength = 12
                    LblCedulaInfo.Text = "El 'Documento de Identificación Migratorio para Extranjeros(DIMEX)' debe contener 11 o 12 dígitos, sin ceros al inicio y sin guiones"
                Case 4 'NITE 
                    TxtCedula.MaxLength = 10
                    LblCedulaInfo.Text = "El 'Documento de Identificación de la DGT( NITE)' debe contener 10 dígitos y sin guiones."
                Case 999 'Extrangero
                    TxtCedula.MaxLength = 20
                    LblCedulaInfo.Text = "El 'Documento de Identificación de Extrangero' debe contener 00 dígitos y sin guiones."
            End Select


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub BtnAnotacionAgregar_Click(sender As Object, e As EventArgs)

        If (TxtAgregaContacto.Text <> "") Then

            LvwAnotaciones.Items.Add(TxtAgregaContacto.Text.Trim())
            TxtAgregaContacto.Text = ""
        End If
    End Sub
    Private Sub CargaListaAnotaciones(pCliente As Integer)
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Items(0) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwAnotaciones.Items.Clear()
            '  BtnAnotacionEliminar.Enabled = False

            Cliente.Cliente_Id = pCliente
            VerificaMensaje(Cliente.ConsultaContactosCliente)

            For Each Fila As DataRow In Cliente.Data.Tables(0).Rows
                Items(ColumnasContactos.Nombre) = Fila("Nombre")

                Item = New ListViewItem(Items)
                LvwAnotaciones.Items.Add(Item)
            Next

            ' BtnAnotacionEliminar.Enabled = LvwAnotaciones.Items.Count > 0

            If LvwAnotaciones.Items.Count > 0 Then
                LvwAnotaciones.Items(LvwAnotaciones.Items.Count - 1).EnsureVisible()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub TxtAgregaContacto_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If (TxtAgregaContacto.Text <> "") Then

                        LvwAnotaciones.Items.Add(TxtAgregaContacto.Text.Trim())
                        TxtAgregaContacto.Text = ""
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwAnotaciones_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Delete

                    For i As Integer = LvwAnotaciones.SelectedItems.Count - 1 To 0 Step -1
                        LvwAnotaciones.SelectedItems(i).Remove()
                    Next

            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click

    End Sub
End Class