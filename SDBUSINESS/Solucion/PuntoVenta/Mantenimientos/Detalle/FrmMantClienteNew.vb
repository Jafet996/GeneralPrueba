Imports Business
Public Class FrmMantClienteNew
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
    Private _ClienteNuevo As Integer
    Private _Cargando As Boolean = True

#End Region
#Region "Propiedades"
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
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
            ReDim Numerico(0)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Function CargaCombos() As String
        Dim ClientePrecio As New TClientePrecio(EmpresaInfo.Emp_Id)
        Dim TipoIdentificacion As New TTipoIdentificacion(EmpresaInfo.Emp_Id)
        Dim Provincia As New TProvincia(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(TipoIdentificacion.LoadComboBox(CmbTipoIdentificacion))
            VerificaMensaje(Provincia.LoadComboBox(CmbProvincia))

            CmbTipoIdentificacion_SelectedIndexChanged(CmbTipoIdentificacion, EventArgs.Empty)


            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ClientePrecio = Nothing
            TipoIdentificacion = Nothing
            Provincia = Nothing
        End Try
    End Function

    Public Sub Execute()
        Try

            Me.Cursor = Cursors.Default

            Me.Text = _Titulo
            _GuardoCambios = False
            _ClienteNuevo = 0

            LblTelefono.Visible = EmpresaParametroInfo.FeReceptorTelefono
            TxtTelefono1.Visible = EmpresaParametroInfo.FeReceptorTelefono
            GroupDireccion.Visible = EmpresaParametroInfo.FeReceptorUbicacion

            Me.Width = IIf(EmpresaParametroInfo.FeReceptorUbicacion, Me.Width, 660)

            VerificaMensaje(CargaCombos())

            TxtNombre.Select()
            _Cargando = False

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantCategoriaDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                BtnLimpiar.PerformClick()
            Case Keys.F7
                BtnGuardar.PerformClick()
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                If BtnGuardar.Text = "Aceptar" And Me.ActiveControl.Name <> "TxtCedula" Then
                    BtnGuardar.PerformClick()
                End If
        End Select
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
            If EmpresaParametroInfo.FacturacionElectronica AndAlso EmpresaParametroInfo.FeReceptorTelefono Then
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
                ValidaCedula()
            End If


            If EmpresaParametroInfo.FacturacionElectronica AndAlso EmpresaParametroInfo.FeReceptorUbicacion Then
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

                If TxtDireccion.Text.Trim.Length = 0 Then
                    TxtDireccion.Focus()
                    VerificaMensaje("Debe de indicar la dirección")
                End If
            End If


            Return True
        Catch ex As Exception
            MensajeError(ex.Message)

            Return False
        End Try
    End Function

    Private Sub ValidaCedula()
        If TxtCedula.Text.Trim = String.Empty Then
            TxtCedula.Focus()
            TxtCedula.SelectAll()
            VerificaMensaje("Debe de ingresar el numero de identificacion")
        End If

        If InStr(TxtCedula.Text, "-") > 0 Then
            TxtCedula.Focus()
            TxtCedula.SelectAll()
            VerificaMensaje("El número de identificacion no puede contener guiones debe de ser un valor numerico")
        End If

        If InStr(TxtCedula.Text.Trim, " ") > 0 Then
            TxtCedula.Focus()
            TxtCedula.SelectAll()
            VerificaMensaje("El número de identificacion no puede contener espacios")
        End If

        If Mid(TxtCedula.Text, 1, 1) = "0" Then
            TxtCedula.Focus()
            TxtCedula.SelectAll()
            VerificaMensaje("El número de identificacion no puede iniciar con cero")
        End If

        If Not IsNumeric(TxtCedula.Text) Then
            TxtCedula.Focus()
            TxtCedula.SelectAll()
            VerificaMensaje("El número de identificacion debe de ser un valor numérico")
        End If

        Select Case CmbTipoIdentificacion.SelectedValue
            Case Enum_TipoIdentificacion.Fisica 'Cedula Fisica
                If TxtCedula.Text.Trim.Length <> 9 Then
                    TxtCedula.Focus()
                    TxtCedula.SelectAll()
                    VerificaMensaje("El número de identificacion debe de contener 9 digitos")
                End If
            Case Enum_TipoIdentificacion.Juridica, Enum_TipoIdentificacion.NITE 'Cedula Juridica - NITE
                If TxtCedula.Text.Trim.Length <> 10 Then
                    TxtCedula.Focus()
                    TxtCedula.SelectAll()
                    VerificaMensaje("El número de identificacion debe de contener 10 digitos")
                End If
            Case Enum_TipoIdentificacion.DIMEX 'DIMEX
                If TxtCedula.Text.Trim.Length <> 11 And TxtCedula.Text.Trim.Length <> 12 Then
                    TxtCedula.Focus()
                    TxtCedula.SelectAll()
                    VerificaMensaje("El número de identificacion debe de contener 11 ó 12 digitos")
                End If
        End Select

    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            If _ClienteNuevo > 0 Then
                _GuardoCambios = True
                Me.Close()
            Else
                Guardar()
            End If
        End If
    End Sub

    Private Sub Guardar()
        Try
            VerificaMensaje(Cliente.Siguiente())

            With Cliente
                .Nombre = TxtNombre.Text.Trim.ToUpper
                .NombreComercial = TxtNombreComercial.Text.Trim.ToUpper
                If EmpresaParametroInfo.FeReceptorTelefono Then
                    .Telefono1 = TxtTelefono1.Text
                Else
                    .Telefono1 = "0"
                End If
                .Telefono2 = String.Empty
                .Email = TxtEmail.Text
                .CorreoCotizaciones = String.Empty
                .Apartado = String.Empty
                .PorcDescContado = 0
                .PorcDescCredito = 0
                .FacturaCredito = 0

                .CxC_Colones = String.Empty
                .CxC_Dolares = String.Empty
                .LimiteCredito = 0
                .DiasCredito = 0
                .AplicaMora = 0
                .DiasGraciaMora = 0
                .PorcMora = 0

                .Precio_Id = 1
                .Activo = 1
                .AcumulaPuntos = 0

                .TipoIdentificacion_Id = CmbTipoIdentificacion.SelectedValue
                .Cedula = TxtCedula.Text

                If EmpresaParametroInfo.FeReceptorUbicacion Then
                    .Provincia_Id = CmbProvincia.SelectedValue
                    .Canton_Id = CmbCanton.SelectedValue
                    .Distrito_Id = CmbDistrito.SelectedValue
                    .Barrio_Id = CmbBarrio.SelectedValue
                    .Direccion = TxtDireccion.Text
                Else
                    .Provincia_Id = 1
                    .Canton_Id = 1
                    .Distrito_Id = 1
                    .Barrio_Id = 1
                    .Direccion = "No especificada"
                End If

                .Referencia = String.Empty
                .Anotaciones = String.Empty
                .TipoDoc = coFacturaElectronica
                .Vendedor_id = 1
                .Adjunto_Id = 1

                .Contactos.Clear()

            End With

            VerificaMensaje(Cliente.Insert())
            _ClienteNuevo = Cliente.Cliente_Id

            _GuardoCambios = True
            'Mensaje("El cliente se creó correctamente!!!")
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmMantClienteDetalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        TxtCedula.Select()
    End Sub

    Private Sub CmbProvincia_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbProvincia.SelectedValueChanged
        CargarComboCanton()
    End Sub

    Private Sub CmbCanton_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCanton.SelectedValueChanged
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

    Private Sub CmbDistrito_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbDistrito.SelectedValueChanged
        CargarComboBarrio()
    End Sub

    Private Sub CmbTipoIdentificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoIdentificacion.SelectedIndexChanged
        Try
            BtnVerificaCedula.Enabled = False

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

            BtnVerificaCedula.Enabled = (CmbTipoIdentificacion.SelectedValue = 1)


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub BtnArroba_Click(sender As Object, e As EventArgs) Handles BtnArroba.Click
        TxtEmail.Text = TxtEmail.Text & "@"
    End Sub

    Private Sub BtnOutlook_Click(sender As Object, e As EventArgs) Handles BtnOutlook.Click
        TxtEmail.Text = TxtEmail.Text & "@outlook.com"
    End Sub

    Private Sub BtnGmail_Click(sender As Object, e As EventArgs) Handles BtnGmail.Click
        TxtEmail.Text = TxtEmail.Text & "@gmail.com"
    End Sub

    Private Sub BtnYahoo_Click(sender As Object, e As EventArgs) Handles BtnYahoo.Click
        TxtEmail.Text = TxtEmail.Text & "@yahoo.com"
    End Sub

    Private Sub BtnHotmail_Click(sender As Object, e As EventArgs) Handles BtnHotmail.Click
        TxtEmail.Text = TxtEmail.Text & "@hotmail.com"
    End Sub

    Private Sub BtnIcloud_Click(sender As Object, e As EventArgs) Handles BtnIcloud.Click
        TxtEmail.Text = TxtEmail.Text & "@icloud.com"
    End Sub

    Private Sub TxtNombre_TextChanged(sender As Object, e As EventArgs) Handles TxtNombre.TextChanged
        TxtNombreComercial.Text = TxtNombre.Text
    End Sub

    Private Sub BtnVerificaCedula_Click(sender As Object, e As EventArgs) Handles BtnVerificaCedula.Click
        VerificaCedula()
    End Sub
    Private Sub VerificaCedula()
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim SDWCF As New WsSDWCF.SDWCF
        Dim Persona As New WsSDWCF.TPersona
        Dim ClienteReg As DataRow = Nothing
        Dim FormaSeleccion As New FrmClienteSeleccion
        Try

            ValidaCedula()


            Cliente.Cedula = TxtCedula.Text.Trim()
            Cliente.ConsultaClienteCedula()


            If Not Cliente.Data.Tables("ClientesxCedula") Is Nothing AndAlso Not Cliente.Data.Tables("ClientesxCedula").Rows Is Nothing AndAlso Cliente.Data.Tables("ClientesxCedula").Rows.Count > 0 Then
                If Cliente.Data.Tables("ClientesxCedula").Rows.Count > 1 Then
                    FormaSeleccion.Tabla = Cliente.Data.Tables("ClientesxCedula")
                    FormaSeleccion.Execute()

                    If Not FormaSeleccion.Selecciono OrElse FormaSeleccion.Registro Is Nothing Then
                        MensajeError("Existe más de 1 cliente para el mismo número de cédula, favor verificar desde el mantenimiento de clientes")
                        Me.Close()
                        Exit Sub
                    Else
                        ClienteReg = FormaSeleccion.Registro
                    End If
                Else
                    ClienteReg = Cliente.Data.Tables("ClientesxCedula").Rows(0)
                End If


                With Persona
                    TxtNombre.Text = ClienteReg("Nombre")
                    If Trim(ClienteReg("NombreComercial")) = String.Empty Then
                        TxtNombreComercial.Text = ClienteReg("Nombre")
                    End If
                    If TxtTelefono1.Visible Then
                        TxtTelefono1.Text = ClienteReg("Telefono1")
                    End If
                    TxtEmail.Text = ClienteReg("Email")
                    If GroupDireccion.Visible Then
                        CmbProvincia.SelectedValue = ClienteReg("Provincia_Id")
                        CmbCanton.SelectedValue = ClienteReg("Canton_Id")
                        CmbDistrito.SelectedValue = ClienteReg("Distrito_Id")
                        CmbBarrio.SelectedValue = ClienteReg("Barrio_Id")
                        TxtDireccion.Text = ClienteReg("Direccion")
                    End If
                    _ClienteNuevo = ClienteReg("Cliente_Id")
                End With

                TxtEmail.Focus()

                BtnGuardar.Enabled = True
                BtnGuardar.Text = "Aceptar"
            Else

                SDWCF.Url = InfoMaquina.URLSD

                Persona = SDWCF.ConsultaCedula(TxtCedula.Text)

                If Persona.ErrorCode = "00" Then
                    With Persona
                        TxtNombre.Text = .NombreCompleto
                        TxtNombreComercial.Text = .NombreCompleto
                    End With

                    If TxtTelefono1.Visible Then
                        TxtTelefono1.Focus()
                    Else
                        TxtEmail.Focus()
                    End If
                End If
                If Persona.ErrorCode = "01" Then
                    If Not ConfirmaAccion("No se encontró el número de identificación, Desea Crear un cliente con este número de Identificacion") Then
                        Me.Close()
                    Else
                        TxtNombre.Focus()
                    End If
                End If
                If Persona.ErrorCode <> "00" AndAlso Persona.ErrorCode <> "01" Then
                    VerificaMensaje(Persona.ErrorDescription)
                End If

                BtnGuardar.Enabled = True
                BtnGuardar.Text = "Crear"
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            SDWCF = Nothing
            Persona = Nothing
            Cliente = Nothing
            FormaSeleccion = Nothing
        End Try
    End Sub
    Private Sub Limpiar()
        Try
            TxtNombre.Text = String.Empty
            TxtNombreComercial.Text = String.Empty
            TxtTelefono1.Text = String.Empty
            TxtEmail.Text = String.Empty
            CmbProvincia.SelectedValue = 1
            CmbCanton.SelectedValue = 1
            CmbDistrito.SelectedValue = 1
            CmbBarrio.SelectedValue = 1
            TxtDireccion.Text = String.Empty
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCedula_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCedula.KeyDown
        Try

            If e.KeyCode = Keys.Enter AndAlso TxtCedula.Text.Trim <> String.Empty Then
                BtnVerificaCedula.PerformClick()
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        BtnGuardar.Enabled = False
        Limpiar()
        TxtCedula.Text = String.Empty
        TxtCedula.Select()
    End Sub
End Class