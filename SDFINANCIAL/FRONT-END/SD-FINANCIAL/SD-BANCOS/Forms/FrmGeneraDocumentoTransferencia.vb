Imports BUSINESS
Public Class FrmGeneraDocumentoTransferencia
#Region "Variables"
    Private _Titulo As String = "Pago por transferencia"
    Private _Prov_Id As Integer = 0
    Private _Monto As Double = 0.0
    Private _Solicitudes As New List(Of TCxPSolicitudPago)
#End Region
#Region "Propiedades"
    Public WriteOnly Property Prov_Id As Integer
        Set(value As Integer)
            _Prov_Id = value
        End Set
    End Property
    Public WriteOnly Property Monto As Double
        Set(value As Double)
            _Monto = value
        End Set
    End Property
    Public WriteOnly Property Solicitudes As List(Of TCxPSolicitudPago)
        Set(value As List(Of TCxPSolicitudPago))
            _Solicitudes = value
        End Set
    End Property
#End Region

    Public Sub Execute()
        CargaDatos()
        CargaComboBanco()
        Me.Text = _Titulo
        Me.ShowDialog()
    End Sub

    Private Function CargaDatos() As String
        Dim Proveedor As New TProveedor

        Try
            With Proveedor
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = _Prov_Id
            End With
            VerificaMensaje(Proveedor.ListKey)

            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("No se encontró un proveedor con el código #" & _Prov_Id.ToString)
            End If

            If Not Proveedor.Activo Then
                VerificaMensaje("El proveedor se encuentra inactivo")
            End If

            If Proveedor.Identificacion.Trim = "" Then
                VerificaMensaje("El proveedor no tiene un número de identificación registrado")
            End If

            TxtBeneficiario.Text = Proveedor.Nombre
            TxtBeneficiario.Tag = Proveedor.Identificacion.Trim
            LblMonto.Text = Format(_Monto, "#,##0.00")

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Proveedor = Nothing
        End Try
    End Function

    Private Sub CargaComboBanco()
        Dim ProveedorCuenta As New TProveedorCuenta

        Try
            CmbBancoProveedor.DataSource = Nothing
            CmbBancoProveedor.Items.Clear()

            CmbCuentaBeneficiario.DataSource = Nothing
            CmbCuentaBeneficiario.Items.Clear()

            With ProveedorCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = _Prov_Id
            End With
            VerificaMensaje(ProveedorCuenta.LoadComboBoxProveedorCuenta(CmbBancoProveedor))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProveedorCuenta = Nothing
        End Try
    End Sub

    Private Sub CargaComboCuenta()
        Dim ProveedorCuenta As New TProveedorCuenta

        Try
            If CmbBancoProveedor.SelectedValue Is Nothing OrElse CmbBancoProveedor.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
                Exit Sub
            End If

            CmbCuentaBeneficiario.DataSource = Nothing

            With ProveedorCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Banco_Id = CmbBancoProveedor.SelectedValue
                .Prov_Id = _Prov_Id
            End With
            VerificaMensaje(ProveedorCuenta.LoadComboBox(CmbCuentaBeneficiario))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProveedorCuenta = Nothing
        End Try
    End Sub

    Private Sub AsignaMonedaCuentaBeneficiario()
        Dim ProveedorCuenta As New TProveedorCuenta

        Try
            If CmbCuentaBeneficiario.SelectedValue Is Nothing OrElse CmbCuentaBeneficiario.SelectedValue.ToString.Equals("System.Data.DataRowView") Then
                Exit Sub
            End If

            With ProveedorCuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Prov_Id = _Prov_Id
                .Cuenta_Id = CmbCuentaBeneficiario.SelectedValue
            End With
            VerificaMensaje(ProveedorCuenta.ListKey)

            CmbMonedaBeneficiario.SelectedIndex = IIf(ProveedorCuenta.Moneda = coMonedaColones, 0, 1)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProveedorCuenta = Nothing
        End Try
    End Sub

    Private Sub ProveedorCuentas()
        Dim Forma As New FrmMantProveedorCuentaLista

        Try
            With Forma
                .Prov_Id = _Prov_Id
                .Execute()
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CargaComboBanco()
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtBeneficiario.Text.Trim = "" Then
                VerificaMensaje("Debe de ingresar el nombre del proveedor")
            End If

            If TxtBeneficiario.Tag.ToString.Trim = "" Then
                VerificaMensaje("El proveedor no tiene registrado un número de identificación, por favor dirigase al catalogo de proveedores e ingreselo")
            End If

            If CmbBancoProveedor.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar el banco del proveedor")
            End If

            If CmbCuentaBeneficiario.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar la cuenta del proveedor")
            End If

            If CmbMonedaBeneficiario.SelectedIndex = -1 Then
                VerificaMensaje("La moneda de la cuenta es inválida")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub ImprimeDocumento()
        Dim Solicitud As New TCxPSolicitudPago
        Dim Reporte As New RptSolicitudTransferencia
        Dim FormaReporte As New FrmReporte

        Try
            Cursor = Cursors.WaitCursor

            With Solicitud
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(Solicitud.RptSolicitudTransferencia(_Solicitudes))

            If Solicitud.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.SetDataSource(Solicitud.Datos.Tables(0))
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Datos.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreBeneficiario", TxtBeneficiario.Text.Trim)
            Reporte.SetParameterValue("CedulaJuridica", TxtBeneficiario.Tag)
            Reporte.SetParameterValue("NombreBanco", CmbBancoProveedor.Text)
            Reporte.SetParameterValue("CuentaBancaria", CmbCuentaBeneficiario.Text)
            Reporte.SetParameterValue("MonedaCuenta", CmbMonedaBeneficiario.Text)
            Reporte.SetParameterValue("MontoLetras", EmpresaInfo.ConvierteNumeroLetras(_Monto))
            Reporte.SetParameterValue("NombreUsuario", UsuarioInfo.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Solicitud = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Imprimir()
        If ValidaTodo() Then
            ImprimeDocumento()
        End If
    End Sub

    Private Sub CmbBancoProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbBancoProveedor.SelectedValueChanged
        CargaComboCuenta()
    End Sub

    Private Sub CmbCuentaBeneficiario_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCuentaBeneficiario.SelectedValueChanged
        AsignaMonedaCuentaBeneficiario()
    End Sub

    Private Sub BtnAgregarCuenta_Click(sender As Object, e As EventArgs) Handles BtnAgregarCuenta.Click
        ProveedorCuentas()
    End Sub

    Private Sub FrmGeneraDocumentoTransferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class