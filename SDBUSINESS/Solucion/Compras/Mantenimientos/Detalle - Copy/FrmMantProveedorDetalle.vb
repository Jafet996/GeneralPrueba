Imports Business
Public Class FrmMantProveedorDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private Proveedor As New TProveedor(EmpresaInfo.Emp_Id)
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
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
    Public Property NuevoId As Integer = 0
    Public Property NuevoNombre As String = String.Empty


    Public Property Nombre As String = String.Empty
    Public Property Telefono As String = String.Empty
    Public Property Email As String = String.Empty
    Public Property TipoIdentificacion As Integer = 0
    Public Property CedulaJuridica As String = String.Empty

#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")
            Numerico(1) = New TNumericFormat(TxtDiasCredito, 4, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaDatos()
        Dim Mensaje As String = ""
        Try
            Proveedor.Prov_Id = CInt(TxtNumero.Text)
            Mensaje = Proveedor.ListKey()
            VerificaMensaje(Mensaje)

            With Proveedor
                TxtNombre.Text = .Nombre
                TxtTelefono1.Text = .Telefono1
                TxtTelefono2.Text = .Telefono2
                TxtFax.Text = .Fax
                TxtApartado.Text = .Apartado
                CmbTipoIdentificacion.SelectedValue = .TipoIdentificacion_Id
                TxtCedulaJuridica.Text = .CedulaJuridica
                TxtEmail.Text = .Email
                TxtDireccion.Text = .Direccion
                ChkActivo.Checked = .Activo
                TxtCxPColones.Text = .CxP_Colones
                TxtCxPDolares.Text = .CxP_Dolares
                TxtDiasCredito.Text = .DiasCredito
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaCombos()
        Dim TipoIdentificacion As New TTipoIdentificacion(EmpresaInfo.Emp_Id)
        Try
            VerificaMensaje(TipoIdentificacion.LoadComboBox(CmbTipoIdentificacion))
            'CmbTipoIdentificacion_SelectedIndexChanged(CmbTipoIdentificacion, EventArgs.Empty)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
        End Try
    End Sub

    Public Sub Execute(pCodigo As Integer)
        Me.Text = _Titulo
        _GuardoCambios = False

        If Not _Nuevo Then
            TxtNumero.Text = pCodigo
            CargaCombos()
            CargaDatos()
        Else
            CargaCombos()
            CmbTipoIdentificacion.SelectedValue = Enum_TipoIdentificacion.Juridica


            If Nombre <> String.Empty Then
                TxtNombre.Text = Nombre.ToUpper
            End If

            If Telefono <> String.Empty Then
                TxtTelefono1.Text = Telefono
            End If

            If Email <> String.Empty Then
                TxtEmail.Text = Email.ToUpper
            End If


            If IsNumeric(TipoIdentificacion) AndAlso TipoIdentificacion > 0 Then
                CmbTipoIdentificacion.SelectedValue = TipoIdentificacion
            End If
            If Nombre <> String.Empty Then
                TxtNombre.Text = Nombre.ToUpper
            End If

            If CedulaJuridica <> String.Empty Then
                TxtCedulaJuridica.Text = CedulaJuridica
            End If

            TxtDiasCredito.Text = 30
        End If

        TxtNumero.Focus()

        Me.ShowDialog()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantCategoriaDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                BtnGuardar.PerformClick()
            Case Keys.F7
                BtnGuardar.PerformClick()
        End Select
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If
            '-------------------Telefono-----------------------------------------------
            If TxtTelefono1.Text = "" Then
                TxtTelefono1.Focus()
                VerificaMensaje("Debe de digitar al menos un telefono")
            End If
            '------Credito--------------------------------------------------------------
            If TxtCxPColones.Text.Trim <> String.Empty Then
                If Not ValidaCuentaContableSD(TxtCxPColones.Text.Trim) Then
                    TxtCxPColones.Focus()
                    VerificaMensaje("Si el proveedor permite facturas de credito debe de tener una cuenta x pagar asignada")
                End If
            End If

            If TxtCxPDolares.Text.Trim <> String.Empty Then
                If Not ValidaCuentaContableSD(TxtCxPDolares.Text.Trim) Then
                    TxtCxPDolares.Focus()
                    VerificaMensaje("Si el proveedor permite facturas de credito debe de tener una cuenta x pagar asignada")
                End If
            End If

            '-----Email---------------------------------------------------------------
            If TxtEmail.Text <> "" Then
                If ValidaEmail(TxtEmail.Text) <> "" Then
                    TxtEmail.Focus()
                    VerificaMensaje("La direccion Email no tiene un formato correcto")
                End If
            End If

            If TxtCedulaJuridica.Text.Trim = String.Empty Then
                TxtCedulaJuridica.Focus()
                VerificaMensaje("Debe de ingresar el numero de identificacion")
            End If


            ''------- Valida cedula ---------------------------------------------------
            'If EmpresaParametroInfo.FacturacionElectronica Then

            '    If TxtCedulaJuridica.Text.Trim = String.Empty Then
            '        TxtCedulaJuridica.Focus()
            '        VerificaMensaje("Debe de ingresar el numero de identificacion")
            '    End If

            '    If InStr(TxtCedulaJuridica.Text, "-") > 0 Then
            '        TxtCedulaJuridica.Focus()
            '        VerificaMensaje("El número de identificacion no puede contener guiones debe de ser un valor numerico")
            '    End If

            '    If InStr(TxtCedulaJuridica.Text.Trim, " ") > 0 Then
            '        TxtCedulaJuridica.Focus()
            '        VerificaMensaje("El número de identificacion no puede contener espacios")
            '    End If

            '    If Mid(TxtCedulaJuridica.Text, 1, 1) = "0" Then
            '        TxtCedulaJuridica.Focus()
            '        VerificaMensaje("El número de identificacion no puede iniciar con cero")
            '    End If

            '    If Not IsNumeric(TxtCedulaJuridica.Text) Then
            '        TxtCedulaJuridica.Focus()
            '        VerificaMensaje("El número de identificacion debe de ser un valor numérico")
            '    End If

            '    Select Case CmbTipoIdentificacion.SelectedValue
            '        Case 1 'Cedula Fisica
            '            If TxtCedulaJuridica.Text.Trim.Length <> 9 Then
            '                TxtCedulaJuridica.Focus()
            '                VerificaMensaje("El número de identificacion debe de contener 9 digitos")
            '            End If
            '        Case 2, 4 'Cedula Juridica - NITE
            '            If TxtCedulaJuridica.Text.Trim.Length <> 10 Then
            '                TxtCedulaJuridica.Focus()
            '                VerificaMensaje("El número de identificacion debe de contener 10 digitos")
            '            End If
            '        Case 3 'DIMEX
            '            If TxtCedulaJuridica.Text.Trim.Length <> 11 And TxtCedulaJuridica.Text.Trim.Length <> 12 Then
            '                TxtCedulaJuridica.Focus()
            '                VerificaMensaje("El número de identificacion debe de contener 11 ó 12 digitos")
            '            End If
            '    End Select
            'End If

            If Not IsNumeric(TxtDiasCredito.Text) OrElse CInt(TxtDiasCredito.Text) < 0 Then
                TxtDiasCredito.SelectAll()
                VerificaMensaje("Los dias de crédito deben de ser mayor o igual a cero ")
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
        Dim Mensaje As String = ""
        Try

            If _Nuevo Then
                Mensaje = Proveedor.Siguiente()
                VerificaMensaje(Mensaje)
            Else
                Proveedor.Prov_Id = CInt(TxtNumero.Text)
            End If

            With Proveedor
                .Nombre = TxtNombre.Text
                .Activo = ChkActivo.Checked
                .Direccion = TxtDireccion.Text
                .Telefono1 = TxtTelefono1.Text
                .Telefono2 = TxtTelefono2.Text
                .Fax = TxtFax.Text
                .Email = TxtEmail.Text
                .Apartado = TxtApartado.Text
                .TipoIdentificacion_Id = CmbTipoIdentificacion.SelectedValue
                .CedulaJuridica = TxtCedulaJuridica.Text
                .CxP_Colones = TxtCxPColones.Text
                .CxP_Dolares = TxtCxPDolares.Text
                .DiasCredito = TxtDiasCredito.Text
            End With

            If _Nuevo Then
                Mensaje = Proveedor.Insert()
            Else
                Mensaje = Proveedor.Modify()
            End If


            NuevoId = Proveedor.Prov_Id
            NuevoNombre = Proveedor.Nombre

            _GuardoCambios = True

            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmMantProveedorDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtNombre.Select()
    End Sub

    'Private Sub CmbTipoIdentificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoIdentificacion.SelectedIndexChanged
    '    Try

    '        If CmbTipoIdentificacion.SelectedValue Is Nothing OrElse CmbTipoIdentificacion.SelectedValue.ToString = "System.Data.DataRowView" Then
    '            Exit Sub
    '        End If

    '        TxtCedulaJuridica.Text = ""
    '        Select Case CmbTipoIdentificacion.SelectedValue
    '            Case 1 'CedulaFisica
    '                TxtCedulaJuridica.MaxLength = 9
    '                LblCedulaInfo.Text = "La 'Cédula física' debe de contener 9 dígitos, sin cero al inicio y sin guiones"
    '            Case 2 'Cedula Juridica
    '                TxtCedulaJuridica.MaxLength = 10
    '                LblCedulaInfo.Text = "La 'cédula de personas Jurídicas' debe contener 10 dígitos y sin guiones"
    '            Case 3 'DIMEX(Pasaporte)
    '                TxtCedulaJuridica.MaxLength = 12
    '                LblCedulaInfo.Text = "El 'Documento de Identificación Migratorio para Extranjeros(DIMEX)' debe contener 11 o 12 dígitos, sin ceros al inicio y sin guiones"
    '            Case 4 'NITE 
    '                TxtCedulaJuridica.MaxLength = 10
    '                LblCedulaInfo.Text = "El 'Documento de Identificación de la DGT( NITE)' debe contener 10 dígitos y sin guiones."
    '        End Select


    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    End Try

    'End Sub

    Private Sub TxtCxPColones_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCxPColones.KeyDown
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCxPColones.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCxPDolares_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCxPDolares.KeyDown
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCxPDolares.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class