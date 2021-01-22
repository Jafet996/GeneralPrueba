Imports Business
Public Class FrmMantCuentaMayorDetalle
#Region "Variables"
    Private _Nuevo As Boolean
    Private _GuardoCambios As Boolean
#End Region
#Region "Propiedades"
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

    Public Sub Execute(pCuenta_Id As String)
        CargaComboTipo()
        Inicializa()

        If Not _Nuevo Then
            TxtCuenta.Text = pCuenta_Id.Trim
            CargaDatos()
        Else
            GeneraCuentaMayor()
        End If

        Me.ShowDialog()
    End Sub

    Private Sub Inicializa()
        TxtCuenta.Text = ""
        TxtNombre.Text = ""
        If CmbTipo.Items.Count > 0 Then CmbTipo.SelectedIndex = 0
        If CmbClase.Items.Count > 0 Then CmbClase.SelectedIndex = 0
        If CmbMoneda.Items.Count > 0 Then CmbMoneda.SelectedIndex = 0
        ChkActivo.Checked = True
    End Sub

    Private Sub CargaComboTipo()
        Dim CuentaTipo As New TCuentaTipo

        Try
            CuentaTipo.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(CuentaTipo.LoadComboBox(CmbTipo))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CuentaTipo = Nothing
        End Try
    End Sub

    Private Sub CargaComboClase()
        Dim CuentaTipoClase As New TCuentaTipoClase

        Try
            If CmbTipo.SelectedValue Is Nothing OrElse CmbTipo.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            If _Nuevo Then
                GeneraCuentaMayor()
            End If

            With CuentaTipoClase
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = CmbTipo.SelectedValue
            End With
            VerificaMensaje(CuentaTipoClase.LoadComboBox(CmbClase))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CuentaTipoClase = Nothing
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim Cuenta As New TCuenta

        Try
            If TxtCuenta.Text.Trim = "" Then
                VerificaMensaje("No se pudo obtener acceso a la cuenta")
            End If

            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = TxtCuenta.Text.Trim
            End With
            VerificaMensaje(Cuenta.ListKey)

            If Cuenta.RowsAffected = 0 Then
                _GuardoCambios = True
                VerificaMensaje("No se encontraron datos de la cuenta seleccionada")
            End If

            With Cuenta
                TxtNombre.Text = .Nombre
                CmbTipo.SelectedValue = .Tipo_Id
                CmbClase.SelectedValue = .Clase_Id
                CmbMoneda.SelectedIndex = IIf(.Moneda = coMonedaColones, 0, 1)
                ChkActivo.Checked = .Activo
                CmbTipo.Enabled = False
                CmbMoneda.Enabled = False
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
            Me.Close()
        Finally
            Cuenta = Nothing
        End Try
    End Sub

    Private Sub GeneraCuentaMayor()
        Dim Cuenta As New TCuenta

        Try
            If CmbTipo.SelectedIndex = -1 Then
                Exit Sub
            End If

            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = CmbTipo.SelectedValue
            End With
            VerificaMensaje(Cuenta.GeneraCuentaMayor())

            TxtCuenta.Text = Cuenta.Cuenta_Id

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cuenta = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If CmbTipo.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un tipo")
            End If

            If CmbClase.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar una clase")
            End If

            If CmbMoneda.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar una moneda")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Guardar()
        Dim Cuenta As New TCuenta

        Try
            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Nombre = TxtNombre.Text.Trim
                .Tipo_Id = CmbTipo.SelectedValue
                .Clase_Id = CmbClase.SelectedValue
                .Moneda = IIf(CmbMoneda.SelectedIndex = 0, coMonedaColones, coMonedaDolares)
                .Activo = ChkActivo.Checked
                .Nivel = 1
                .AceptaMovimiento = 0
                .SolicitaCentroCosto = 0
            End With

            If _Nuevo Then
                VerificaMensaje(Cuenta.GeneraCuentaMayor)
                VerificaMensaje(Cuenta.Insert)
            Else
                Cuenta.Cuenta_Id = TxtCuenta.Text.Trim
                VerificaMensaje(Cuenta.Modify)
            End If

            _GuardoCambios = True
            MsgBox("Los cambios se guardaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cuenta = Nothing
        End Try
    End Sub

    Private Sub CmbTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbTipo.SelectedValueChanged
        Try
            If CmbTipo.SelectedValue Is Nothing Then
                Exit Sub
            End If

            CargaComboClase()

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

End Class