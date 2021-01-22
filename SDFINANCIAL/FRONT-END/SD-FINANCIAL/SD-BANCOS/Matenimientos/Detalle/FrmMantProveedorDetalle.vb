Imports BUSINESS
Public Class FrmMantProveedorDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
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
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")
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

    Private Sub CargaDatos()
        Dim Proveedor As New TProveedor

        Try
            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = CInt(TxtNumero.Text.Trim)
            End With
            VerificaMensaje(Proveedor.ListKey)

            With Proveedor
                CmbTipoIdentificacion.SelectedValue = .TipoIdentificacion_Id
                FormateaIdentificacion()
                TxtIdentificacion.Text = .Identificacion
                TxtNombre.Text = .Nombre
                TxtTelefono1.Text = .Telefono1
                TxtTelefono2.Text = .Telefono2
                TxtEmail.Text = .Email
                TxtDireccion.Text = .Direccion
                TxtCxPColones.Text = .CxP_Colones
                TxtCxPDolares.Text = .CxP_Dolares
                ChkActivo.Checked = .Activo
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
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
        Dim Proveedor As New TProveedor

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

            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Identificacion = TxtIdentificacion.Text.Trim
            End With
            VerificaMensaje(Proveedor.ListKeyByIdentificacion)

            If Proveedor.RowsAffected > 0 Then
                If _Nuevo Then
                    VerificaMensaje("Ya existe registrado un proveedor con este numero de identificación")
                ElseIf TxtNumero.Text.Trim <> Proveedor.Prov_Id Then
                    VerificaMensaje("Ya existe registrado un proveedor con este numero de identificación")
                End If
            End If

            If Not ValidaCuentaContable(TxtCxPColones.Text.Trim, True) Then
                TxtCxPColones.Focus()
                Return False
            End If

            If Not ValidaCuentaContable(TxtCxPDolares.Text.Trim, True) Then
                TxtCxPDolares.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            Proveedor = Nothing
        End Try
    End Function

    Private Sub Guardar()
        Dim Proveedor As New TProveedor

        Try
            Proveedor.Emp_Id = EmpresaInfo.Emp_Id

            If _Nuevo Then
                VerificaMensaje(Proveedor.NextOne)
            Else
                Proveedor.Prov_Id = CInt(TxtNumero.Text.Trim)
            End If

            With Proveedor
                .TipoIdentificacion_Id = CmbTipoIdentificacion.SelectedValue
                .Identificacion = TxtIdentificacion.Text
                .Nombre = TxtNombre.Text
                .Telefono1 = TxtTelefono1.Text
                .Telefono2 = TxtTelefono2.Text
                .Email = TxtEmail.Text
                .Direccion = TxtDireccion.Text
                .CxP_Colones = TxtCxPColones.Text.Trim
                .CxP_Dolares = TxtCxPDolares.Text.Trim
                .Activo = ChkActivo.Checked
            End With

            If _Nuevo Then
                VerificaMensaje(Proveedor.Insert())
            Else
                VerificaMensaje(Proveedor.Modify())
            End If

            _GuardoCambios = True
            Mensaje("Los cambios se almacenaron correctamente")
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            Guardar()
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantProveedorDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnGuardar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub FrmMantProveedorDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtNombre.Select()
    End Sub

    Private Sub CmbTipoIdentificacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbTipoIdentificacion.SelectedValueChanged
        FormateaIdentificacion()
    End Sub

    Private Sub TxtCxCColones_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCxPColones.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BusquedaCuenta(TxtCxPColones)
        End Select
    End Sub

    Private Sub TxtCxCDolares_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCxPDolares.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BusquedaCuenta(TxtCxPDolares)
        End Select
    End Sub

End Class