Imports BUSINESS
Public Class FrmMantCuentaHijaDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
    Private _Padre As String
    Private _Nivel As Integer
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

            'Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute(pPadre As String, pHija As String, pMoneda As String, pNivel As Integer)
        Me.Text = _Titulo
        _GuardoCambios = False
        _Padre = pPadre
        _Nivel = pNivel

        CargaComboTipo()
        Inicializa()
        CargaCuentaPadre()

        If Not _Nuevo Then
            TxtCuenta.Text = pHija
            CargaDatos()
        Else
            TxtNivel.Text = pNivel + 1
            GeneraCuentaHija()
        End If

        TxtNombre.Focus()

        Me.ShowDialog()
    End Sub

    Private Sub Inicializa()
        TxtCuenta.Text = ""
        TxtNombre.Text = ""
        LblCuentaPadre.Text = ""
        LblNombrePadre.Text = ""
        If CmbTipo.Items.Count > 0 Then CmbTipo.SelectedIndex = 0
        If CmbClase.Items.Count > 0 Then CmbClase.SelectedIndex = 0
        If CmbMoneda.Items.Count > 0 Then CmbMoneda.SelectedIndex = 0
        ChkActivo.Checked = True
        ChkAceptaMovimientos.Checked = True
        ChkSolicitaCentroCosto.Checked = False
    End Sub

    Private Sub CargaCuentaPadre()
        Dim Cuenta As New TCuenta

        Try
            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = _Padre
            End With
            VerificaMensaje(Cuenta.ListKey)

            If Cuenta.RowsAffected = 0 Then
                VerificaMensaje("No se encontró la cuenta padre")
            End If

            With Cuenta
                LblCuentaPadre.Text = .Cuenta_Id
                LblNombrePadre.Text = .Nombre
                CmbTipo.SelectedValue = .Tipo_Id
                CmbClase.SelectedValue = .Clase_Id
                CmbMoneda.SelectedIndex = IIf(.Moneda = coMonedaColones, 0, 1)
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
            Me.Close()
        Finally
            Cuenta = Nothing
        End Try
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
            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = TxtCuenta.Text
            End With
            VerificaMensaje(Cuenta.ListKey())

            With Cuenta
                TxtNombre.Text = .Nombre
                CmbTipo.SelectedValue = .Tipo_Id
                CmbClase.SelectedValue = .Clase_Id
                TxtNivel.Text = .Nivel
                CmbMoneda.SelectedIndex = IIf(.Moneda = coMonedaColones, 0, 1)
                ChkAceptaMovimientos.Checked = .AceptaMovimiento
                ChkActivo.Checked = .Activo
                ChkSolicitaCentroCosto.Checked = .SolicitaCentroCosto
                CmbMoneda.Enabled = False
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cuenta = Nothing
        End Try
    End Sub

    Private Sub GeneraCuentaHija()
        Dim Cuenta As New TCuenta

        Try
            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Padre_Id = _Padre
            End With
            VerificaMensaje(Cuenta.GeneraCuentaHija())

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


            If CmbTipo.SelectedIndex < 0 Then
                CmbTipo.Focus()
                VerificaMensaje("Debe de seleccionar el tipo de cuenta")
            End If

            If CmbClase.SelectedIndex < 0 Then
                CmbClase.Focus()
                VerificaMensaje("Debe de seleccionar la clase de cuenta")
            End If


            If CmbMoneda.SelectedIndex < 0 Then
                CmbMoneda.Focus()
                VerificaMensaje("Debe de seleccionar la moneda de la cuenta")
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
            Cuenta.Emp_Id = EmpresaInfo.Emp_Id

            If _Nuevo Then
                GeneraCuentaHija()
            End If

            With Cuenta
                .Cuenta_Id = TxtCuenta.Text.Trim
                .Nombre = TxtNombre.Text.Trim
                .Tipo_Id = CmbTipo.SelectedValue
                .Clase_Id = CmbClase.SelectedValue
                .Nivel = CInt(TxtNivel.Text.Trim)
                .Moneda = IIf(CmbMoneda.SelectedIndex = 0, coMonedaColones, coMonedaDolares)
                .AceptaMovimiento = ChkAceptaMovimientos.Checked
                .SolicitaCentroCosto = ChkSolicitaCentroCosto.Checked
                .Activo = ChkActivo.Checked
                .Padre_Id = LblCuentaPadre.Text.Trim
            End With

            If _Nuevo Then
                VerificaMensaje(Cuenta.Insert())
            Else
                VerificaMensaje(Cuenta.Modify())
            End If

            VerificaMensaje(ModificaCuentaPadre)
            _GuardoCambios = True
            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cuenta = Nothing
        End Try
    End Sub

    Private Function ModificaCuentaPadre() As String
        Dim Cuenta As New TCuenta

        Try
            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = _Padre
                .SolicitaCentroCosto = 0
                .AceptaMovimiento = 0
            End With
            VerificaMensaje(Cuenta.CambiaAceptaMovimiento)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cuenta = Nothing
        End Try
    End Function

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            Guardar()
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantCategoriaDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FrmMantCuentaHijaDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        TxtNombre.Select()
    End Sub

    Private Sub CmbTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbTipo.SelectedValueChanged
        Try
            If CmbTipo.SelectedValue Is Nothing OrElse CmbTipo.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            CargaComboClase()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ChkAceptaMovimientos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAceptaMovimientos.CheckedChanged
        ChkSolicitaCentroCosto.Enabled = ChkAceptaMovimientos.Checked
        If Not ChkSolicitaCentroCosto.Enabled Then ChkSolicitaCentroCosto.Checked = False
    End Sub

End Class