Imports BUSINESS
Public Class FrmMantProveedorCuentaDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private _Titulo As String
    Private _Nuevo As Boolean
    Private _Prov_Id As Integer
    Private _Cuenta_Id As Integer
    Private _GuardoCambios As Boolean = False
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
    Public WriteOnly Property Prov_Id As Integer
        Set(value As Integer)
            _Prov_Id = value
        End Set
    End Property
    Public WriteOnly Property Cuenta_Id As Integer
        Set(value As Integer)
            _Cuenta_Id = value
        End Set
    End Property
    Public ReadOnly Property GuardoCambios As Boolean
        Get
            Return _GuardoCambios
        End Get
    End Property
#End Region
#Region "Formateo de Campos"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        Try
            Me.Text = _Titulo
            CargaCombo()
            If Not _Nuevo Then VerificaMensaje(CargaDatos)

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombo()
        Dim Banco As New TBanco

        Try
            Banco.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(Banco.LoadComboBox(CmbBanco))

            CmbMoneda.SelectedIndex = 0

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Banco = Nothing
        End Try
    End Sub

    Private Function CargaDatos()
        Dim ProveedorCuenta As New TProveedorCuenta

        Try
            With ProveedorCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = _Prov_Id
                .Cuenta_Id = _Cuenta_Id
            End With
            VerificaMensaje(ProveedorCuenta.ListKey)

            If ProveedorCuenta.RowsAffected = 0 Then
                VerificaMensaje("No se encontrarón datos")
            End If

            With ProveedorCuenta
                TxtNumero.Text = .Cuenta_Id
                TxtCuenta.Text = .Cuenta
                CmbBanco.SelectedValue = .Banco_Id
                CmbMoneda.SelectedIndex = IIf(.Moneda = coMonedaColones, 0, 1)
                ChkActivo.Checked = .Activo
            End With

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ProveedorCuenta = Nothing
        End Try
    End Function

    Private Function ValidaTodo() As Boolean
        Try
            If CmbBanco.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un banco")
            End If

            If TxtCuenta.Text.Trim = "" Then
                EnfocarTexto(TxtCuenta)
                VerificaMensaje("Debe de ingresar el número de cuenta")
            End If

            If CmbMoneda.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar la moneda de la cuenta")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Guardar()
        Dim ProveedorCuenta As New TProveedorCuenta

        Try
            With ProveedorCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = _Prov_Id
                .Banco_Id = CInt(CmbBanco.SelectedValue)
                .Cuenta = TxtCuenta.Text.Trim
                .Moneda = IIf(CmbMoneda.SelectedIndex = 0, coMonedaColones, coMonedaDolares)
                .Activo = ChkActivo.Checked
            End With

            If _Nuevo Then
                VerificaMensaje(ProveedorCuenta.NextOne)
                VerificaMensaje(ProveedorCuenta.Insert)
            Else
                ProveedorCuenta.Cuenta_Id = _Cuenta_Id
                VerificaMensaje(ProveedorCuenta.Modify)
            End If

            _GuardoCambios = True

            Mensaje("Los cambios se guardaron correctamente")
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProveedorCuenta = Nothing
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

    Private Sub FrmMantProveedorCuentaDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnGuardar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

End Class