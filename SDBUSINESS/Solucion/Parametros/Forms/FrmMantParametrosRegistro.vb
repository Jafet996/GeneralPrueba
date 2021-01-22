Imports Business
Public Class FrmMantParametrosRegistro
    Dim Numerico() As TNumericFormat
    Dim _ValoresAlmacenados As Boolean


    Public ReadOnly Property ValoresAlmacenados As Boolean
        Get
            Return _ValoresAlmacenados
        End Get
    End Property


    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(4)

            Numerico(0) = New TNumericFormat(TxtEmpresa, 3, 0, False, "", "###")
            Numerico(1) = New TNumericFormat(TxtSucursal, 3, 0, False, "", "###")
            Numerico(2) = New TNumericFormat(TxtCaja, 3, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargarDatos()
        Dim TipoImpresora As String = ""
        Try

            TxtUsuario.Text = UnLockPassword(GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegUser))
            TxtPassword.Text = UnLockPassword(GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPassword))
            TxtServidor.Text = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegServer)
            TxtBaseDatos.Text = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegDataBase)
            TxtEmpresa.Text = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegEmp_Id)
            TxtSucursal.Text = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegSuc_Id)
            TxtCaja.Text = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegCaja_Id)
            TipoImpresora = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPrintLocation)
            If IsNumeric(TipoImpresora) Then
                CmbTipoImpresora.SelectedIndex = CInt(TipoImpresora)
            End If
            TxtPuertoSerial.Text = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegComPort)
            TxtPuertoParalelo.Text = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegParallelPort)
            TxtCodigoDetallista.Text = GetRegistryServicioValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegServiceNameKey, coRegCodigoDetallista, "")
            TxtWSRecargaTelefonica.Text = GetRegistryServicioValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegServiceNameKey, coRegWSRecargaTelefonica, "")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub Guardar()
        Try

            SetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegUser, LockPassword(TxtUsuario.Text.Trim))
            SetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPassword, LockPassword(TxtPassword.Text))
            SetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegServer, TxtServidor.Text)
            SetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegDataBase, TxtBaseDatos.Text)
            SetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegEmp_Id, TxtEmpresa.Text)
            SetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegSuc_Id, TxtSucursal.Text)
            SetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegCaja_Id, TxtCaja.Text)
            SetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPrintLocation, CmbTipoImpresora.SelectedIndex)
            SetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegComPort, TxtPuertoSerial.Text)
            SetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegParallelPort, TxtPuertoParalelo.Text)
            SetRegistryServicioValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegServiceNameKey, coRegCodigoDetallista, TxtCodigoDetallista.Text)
            SetRegistryServicioValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegServiceNameKey, coRegWSRecargaTelefonica, TxtWSRecargaTelefonica.Text)

            _ValoresAlmacenados = True

            MsgBox("Los parametros se guardaron correctamente", MsgBoxStyle.Information, Me.Text)


            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()


        CargarDatos()

        Me.ShowDialog()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _ValoresAlmacenados = False
        Me.Close()
    End Sub

    Private Sub CmbTipoImpresora_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoImpresora.SelectedIndexChanged
        Select Case CmbTipoImpresora.SelectedIndex
            Case 0 'Serial
                TxtPuertoSerial.Enabled = True
                TxtPuertoParalelo.Enabled = False
            Case 1 'Windows
                TxtPuertoSerial.Enabled = False
                TxtPuertoParalelo.Enabled = False
            Case 2 'Paralela
                TxtPuertoSerial.Enabled = False
                TxtPuertoParalelo.Enabled = True
        End Select
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Guardar()
    End Sub

    Private Sub FrmMantParametrosRegistro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _ValoresAlmacenados = False
        FormateaCamposNumericos()
        TxtUsuario.Select()
    End Sub
End Class