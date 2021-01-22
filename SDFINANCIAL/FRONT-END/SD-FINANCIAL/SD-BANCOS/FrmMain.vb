Imports BUSINESS
Imports System.IO
Imports System.Threading
Public Class FrmMain
#Region "Variables"
    Dim Xpos As Integer
    Dim ypos As Integer
#End Region

    Private Sub MnuSalir_Click(sender As System.Object, e As System.EventArgs) Handles MnuSalir.Click
        Application.Exit()
    End Sub

    Private Sub MuestraMenu(pMostrar)
        MnuProcesos.Visible = pMostrar
        MnuCatalogos.Visible = pMostrar
        MnuConsultas.Visible = pMostrar
        MnuReportes.Visible = pMostrar
    End Sub

    Private Sub MuestraEquiquetas(pVisible As Boolean)
        LblEmpresaNombre.Visible = pVisible
        TSSCompaniaLabel.Visible = pVisible
        TSSCompania.Visible = pVisible
        TSSUsuarioLabel.Visible = pVisible
        TSSUsuario.Visible = pVisible
        TSSPeriodoLabel.Visible = pVisible
        TSSPeriodo.Visible = pVisible
        TSSTipoCambioLabel.Visible = pVisible
        TSSTipoCambio.Visible = pVisible
        PnlShortCuts.Visible = pVisible
    End Sub

    Private Sub MnuConexión_Click(sender As System.Object, e As System.EventArgs) Handles MnuConexión.Click
        Dim Forma As New FrmConexion
        Dim ThdTipoCambio As Thread

        Try
            Inicializa()

            Forma.Execute()

            If Forma.Conecto Then
                TSSCompania.Text = EmpresaInfo.Nombre
                TSSUsuario.Text = UsuarioInfo.Nombre
                TSSPeriodo.Text = MesNombre(EmpresaParametroInfo.GetProcesoMes) & "-" & EmpresaParametroInfo.GetProcesoAnnio
                TSSTipoCambio.Text = Format(TipoCambioBancos(), "#,##0.00")

                MuestraEquiquetas(True)
                LblEmpresaNombre.Text = EmpresaInfo.Nombre

                HabilitaMenuGrupo(MenuStripPrincipal, UsuarioInfo.Grupo_Id, Modulo_Id)

                If Not EmpresaInfo.Logo Is Nothing Then
                    Using ms As New MemoryStream()
                        ms.Write(EmpresaInfo.Logo, 0, EmpresaInfo.Logo.Length)
                        PicLogo.Image = Image.FromStream(ms, True, True)
                    End Using
                Else
                    PicLogo.Image = Nothing
                End If

                If InfoMaquina.URLTipoCambio <> String.Empty Then
                    ThdTipoCambio = New Thread(AddressOf ActualizaTipoCambio)
                    ThdTipoCambio.Start()
                End If

                BtnConexion.Enabled = (VerificaUsuarioPermisoOpcion(Modulo_Id, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuConexión") = "")
                BtnPagosPendientes.Enabled = (VerificaUsuarioPermisoOpcion(Modulo_Id, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuPagosPendientes") = "")

            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CentraImagen()
        Xpos = (Me.Width / 2) - (PicLogo.Width / 2)
        ypos = (Me.Height / 2) - (PicLogo.Height / 2)
        Me.PicLogo.Location = New Point(Xpos, ypos)
    End Sub

    Private Sub Inicializa()
        PicLogo.Image = Nothing
        MuestraMenu(False)
        TSSCompania.Text = ""
        TSSUsuario.Text = ""
        TSSPeriodo.Text = ""
        TSSTipoCambio.Text = ""
        LblEmpresaNombre.Text = ""
        MuestraEquiquetas(False)
    End Sub

    Private Sub CambiaInterfaz()
        Dim Interfaz As String = String.Empty

        Try
            If InfoMaquina.Interfaz = "2" Then
                Me.BackColor = Color.White
                PanelMain.BackColor = Color.LightSkyBlue
                MainMenuStrip.BackColor = Color.Pink
                StatusBar.BackColor = Color.LightSkyBlue
                BtnConexion.BackColor = Color.LightSkyBlue
                BtnPagosPendientes.BackColor = Color.LightSkyBlue
            End If

            If InfoMaquina.Interfaz = "3" Then
                Me.BackColor = Color.LightSkyBlue
                PanelMain.BackColor = Color.PowderBlue
                MainMenuStrip.BackColor = Color.White
                StatusBar.BackColor = Color.PowderBlue
                BtnConexion.BackColor = Color.SteelBlue
                BtnPagosPendientes.BackColor = Color.SteelBlue
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Modulo_Id = Enum_Modulos.BANCOS
        Dim FormaMac As New FrmMacAddress
        Try

            InfoMaquina.MAC_Address = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegMaquinaId, String.Empty)
            If InfoMaquina.MAC_Address = String.Empty Then
                FormaMac.Execute()
                VerificaMensaje("Debe definir valor de registro")
            End If

            InfoMaquina.Url = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegUrl, String.Empty)
            VerificaMensaje(InfoMaquina.ListKey)

            If InfoMaquina.RowsAffected = 0 Then
                CreaConfiguracionMaquina(InfoMaquina)
            End If

            Me.Text = "SD-BANCOS " & My.Application.Info.Version.ToString

            VerificaVersionModulo(Modulo_Id, My.Application.Info.Version.ToString)

            CentraImagen()
            CambiaInterfaz()
            GuardaMenu()
            FormatearOpcionesRegionales()
            Inicializa()
            MnuConexión.PerformClick()
        Catch ex As Exception
            MensajeError(ex.Message)
            Application.Exit()
        Finally
            FormaMac = Nothing
        End Try
    End Sub

    Public Sub RecorrerNivelesAltos(pMenu As TMenu)
        Dim Orden As Integer = 0

        For Each M As ToolStripMenuItem In MenuStripPrincipal.Items
            With pMenu
                .Modulo_Id = Modulo_Id
                .Menu_Id = M.Name
                .MenuPadre_Id = ""
                .Nombre = M.Text
                .Orden = Orden
            End With
            VerificaMensaje(pMenu.Insert())

            Orden = Orden + 1
            Me.RecorrerSubMenuNivelesAltos(pMenu, Orden, M)
        Next
    End Sub

    Public Sub RecorrerSubMenuNivelesAltos(pMenu As TMenu, ByRef pOrden As Integer, ByVal M As ToolStripMenuItem)
        For Each SubMenu As ToolStripMenuItem In M.DropDownItems
            With pMenu
                .Modulo_Id = Modulo_Id
                .Menu_Id = SubMenu.Name
                .MenuPadre_Id = M.Name
                .Nombre = SubMenu.Text
                .Orden = pOrden
            End With
            VerificaMensaje(pMenu.Insert())

            pOrden = pOrden + 1

            Me.RecorrerSubMenuNivelesAltos(pMenu, pOrden, SubMenu)
        Next
    End Sub

    Private Sub GuardaMenu()
        Dim Menu As New TMenu()

        Try
            Menu.Modulo_Id = Modulo_Id
            VerificaMensaje(Menu.Delete())

            RecorrerNivelesAltos(Menu)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Menu = Nothing
        End Try
    End Sub

    Private Sub BtnConexion_Click(sender As System.Object, e As System.EventArgs) Handles BtnConexion.Click
        MnuConexión.PerformClick()
    End Sub

    Private Sub FrmMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        CentraImagen()
    End Sub

    Private Sub MnuAcercaDe_Click(sender As System.Object, e As System.EventArgs) Handles MnuAcercaDe.Click
        Dim Forma As New FrmAcercaDe

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuUsuario_Click(sender As Object, e As EventArgs) Handles MnuUsuario.Click
        Dim Forma As New FrmMantUsuarioDetalle

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuGrupo_Click(sender As Object, e As EventArgs) Handles MnuGrupo.Click
        Dim Forma As New FrmMantGrupoLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuEmpresa_Click(sender As Object, e As EventArgs) Handles MnuEmpresa.Click
        Dim Forma As New FrmMantEmpresaLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuGenerarToken_Click(sender As Object, e As EventArgs) Handles MnuGenerarToken.Click
        Dim Forma As New FrmMantUsuarioCodigoPermisoDetalle

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuTipoCambio_Click(sender As Object, e As EventArgs) Handles MnuTipoCambio.Click
        Dim Forma As New FrmMantTipoCambio

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


    Private Sub BtnMovimientos_Click(sender As Object, e As EventArgs) Handles BtnPagosPendientes.Click
        MnuPagosPendientes.PerformClick()
    End Sub

    Private Sub MnuBanco_Click(sender As Object, e As EventArgs) Handles MnuBanco.Click
        Dim Forma As New FrmMantBancoLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuTarjeta_Click(sender As Object, e As EventArgs) Handles MnuTarjeta.Click
        Dim Forma As New FrmMantTarjetaLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuProveedor_Click(sender As Object, e As EventArgs) Handles MnuProveedor.Click
        Dim Forma As New FrmMantProveedorLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuPagosPendientes_Click(sender As Object, e As EventArgs) Handles MnuPagosPendientes.Click
        Dim Forma As New FrmCxPPagoPendiente

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCuentas_Click(sender As Object, e As EventArgs) Handles MnuCuentas.Click
        Dim Forma As New FrmMantProveedorCuentaLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

End Class