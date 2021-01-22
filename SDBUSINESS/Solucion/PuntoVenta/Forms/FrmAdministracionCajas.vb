Imports Business

Public Class FrmAdministracionCajas
    Dim Numerico() As TNumericFormat
    Dim caja As New TCaja(EmpresaInfo.Emp_Id)

    Public Sub Execute()
        Try

            Cargacombos()
            FormateaCamposNumericos()
            Inicializa()

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Cargacombos()
        Try
            Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
            Dim Mensaje As String = ""
            Try
                Mensaje = Sucursal.LoadComboBox(CmbSucursal)
                VerificaMensaje(Mensaje)

            Catch ex As Exception
                MensajeError(ex.Message)
            Finally
                Sucursal = Nothing
            End Try
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FormateaCamposNumericos()
        Try

            ReDim Numerico(4)

            Numerico(0) = New TNumericFormat(TxtEfectivo, 7, 2, False, "", "##0.00")
            Numerico(1) = New TNumericFormat(TxtTarjetas, 7, 2, False, "", "##0.00")
            Numerico(2) = New TNumericFormat(TxtCheques, 7, 2, False, "", "##0.00")
            Numerico(3) = New TNumericFormat(TxtDocumentos, 7, 2, False, "", "##0.00")
            Numerico(4) = New TNumericFormat(TxtDolares, 7, 2, False, "", "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub



    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        Dim Caja As New TCaja(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If Not IsNumeric(CmbSucursal.SelectedValue) Then
                Exit Sub
            End If

            Caja.Suc_Id = CInt(CmbSucursal.SelectedValue)
            Mensaje = Caja.CargaComboBox(CmbCaja)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            'MensajeError(ex.Message)
        Finally
            Caja = Nothing
        End Try
    End Sub

    Private Sub HabilitarParaAbrir()
        Try

            BtnAccion.Text = "Abrir"
            BtnAccion.Enabled = True
            GrpFromasPago.Visible = True
            GrpFromasPago.Height = 47
            LblDolares.Visible = False
            lblTarjetas.Visible = False
            LblTranferencia.Visible = False
            LblSalidas.Visible = False
            TxtCheques.Visible = False
            TxtDocumentos.Visible = False
            TxtTarjetas.Visible = False
            TxtDolares.Visible = False

        Catch ex As Exception

            MensajeError(ex.Message)

        End Try
    End Sub

    Private Sub HabilitarParaCerrar()
        Try

            BtnAccion.Text = "Cerrar"
            BtnAccion.Enabled = True
            GrpFromasPago.Visible = True
            GrpFromasPago.Height = 153
            LblDolares.Visible = True
            lblTarjetas.Visible = True
            LblTranferencia.Visible = True
            LblSalidas.Visible = True
            TxtCheques.Visible = True
            TxtDocumentos.Visible = True
            TxtTarjetas.Visible = True
            TxtDolares.Visible = True

        Catch ex As Exception

            MensajeError(ex.Message)

        End Try
    End Sub

    Private Sub Inicializa()
        Try

            TxtEfectivo.Text = 0.00
            TxtCheques.Text = 0.00
            TxtDocumentos.Text = 0.00
            TxtDolares.Text = 0.00
            TxtTarjetas.Text = 0.00

        Catch ex As Exception

            MensajeError(ex.Message)

        End Try
    End Sub

    Private Sub CmbCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCaja.SelectedValueChanged

        Try

            With caja
                .Suc_Id = CmbSucursal.SelectedValue
                .Caja_Id = CmbCaja.SelectedValue
            End With

            VerificaMensaje(caja.ListKey())
            Inicializa()

            If caja.Abierta Then

                HabilitarParaCerrar()

            Else

                HabilitarParaAbrir()

            End If

        Catch ex As Exception



        End Try

    End Sub

    Private Sub BtnAccion_Click(sender As Object, e As EventArgs) Handles BtnAccion.Click
        Try
            If caja.Abierta Then
                VerificaMensaje(caja.CerrarCaja(TxtEfectivo.Text, TxtTarjetas.Text, TxtCheques.Text, TxtDocumentos.Text, TxtDolares.Text))
                VerificaMensaje(caja.ListKey())
                Mensaje("Caja #" & CmbCaja.SelectedValue & ", Sucursal: " & CmbSucursal.SelectedValue & ", cerrada exitosamente")
                BtnAccion.Enabled = False
                Inicializa()
                HabilitarParaAbrir()
            Else
                VerificaMensaje(caja.AbrirCaja(UsuarioInfo.Usuario_Id, TxtEfectivo.Text, TipoCambioCompra()))
                VerificaMensaje(caja.ListKey())
                Mensaje("Caja #" & CmbCaja.SelectedValue & ", Sucursal: " & CmbSucursal.SelectedValue & ", abierta exitosamente")
                BtnAccion.Enabled = False
                Inicializa()
                HabilitarParaCerrar()
            End If

            VerificaMensaje(CajaInfo.ListKey())


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub
End Class