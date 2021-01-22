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
        MnuAuxiliares.Visible = pMostrar
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

                BtnConexion.Enabled = (VerificaUsuarioPermisoOpcion(Enum_Modulos.CONTABILIDAD, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuConexión") = "")
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
            End If

            If InfoMaquina.Interfaz = "3" Then
                Me.BackColor = Color.LightSkyBlue
                PanelMain.BackColor = Color.PowderBlue
                MainMenuStrip.BackColor = Color.White
                StatusBar.BackColor = Color.PowderBlue
                BtnConexion.BackColor = Color.SteelBlue
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Modulo_Id = Enum_Modulos.CONTABILIDAD
        Dim FormaMac As New FrmMacAddress
        Try

            Dim s As String = UnLockPassword("c2VydmVyPTEwLjAuMjAwLjExNTtkYXRhYmFzZT1TREZJTkFOQ0lBTDt1aWQ9c29wb3J0ZTtwYXNzd29yZD1TRC4xMjM0Ow==")
            s = LockPassword("server=JTREJOS-PC\SQLEXPRESS;database=SDFINANCIAL;uid=soporte;password=SD.1234;")

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

            Me.Text = "SD-CONTABILIDAD " & My.Application.Info.Version.ToString
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

    Private Sub MnuCatalogoContable_Click(sender As Object, e As EventArgs) Handles MnuCatalogoContable.Click
        Dim Forma As New FrmMantCatalogoLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCuentaTipo_Click(sender As Object, e As EventArgs) Handles MnuCuentaTipo.Click
        Dim Forma As New FrmMantCuentaTipoLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCuentaTIpoClase_Click(sender As Object, e As EventArgs) Handles MnuCuentaTIpoClase.Click
        Dim Forma As New FrmMantCuentaTipoClaseLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCentroDeCosto_Click(sender As Object, e As EventArgs) Handles MnuCentroDeCosto.Click
        Dim Forma As New FrmMantCentroCostoLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuTiposDeAsiento_Click(sender As Object, e As EventArgs) Handles MnuTiposDeAsiento.Click
        Dim Forma As New FrmMantAsientoTipoLista

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

    Private Sub MnuAsientos_Click(sender As Object, e As EventArgs) Handles MnuAsientos.Click
        Dim Forma As New FrmAsientoLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCierreDeMes_Click(sender As Object, e As EventArgs) Handles MnuCierreDeMes.Click
        Dim Forma As New FrmCierreProcesoMes

        Try
            If EmpresaParametroInfo.GetProcesoMes = EmpresaParametroInfo.GetMesCierreFiscal Then
                VerificaMensaje("El mes en proceso es el último mes del año fiscal, debe de realizar cierre de periodo")
            Else
                Forma.Execute()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            TSSPeriodo.Text = MesNombre(EmpresaParametroInfo.GetProcesoMes) & "-" & EmpresaParametroInfo.GetProcesoAnnio
        End Try
    End Sub

    Private Sub MnuRepAsientosDeDiario_Click(sender As Object, e As EventArgs) Handles MnuRepAsientosDeDiario.Click
        Dim Forma As New FrmRptAsientosDeDiario

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuMovimientosPorCuenta_Click(sender As Object, e As EventArgs) Handles MnuMovimientosPorCuenta.Click
        Dim Forma As New FrmRptConsultaMovimientoCuenta

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


    Private Sub MnuConsultaSaldoDeCuenta_Click(sender As Object, e As EventArgs) Handles MnuConsultaSaldoDeCuenta.Click
        Dim Forma As New FrmRptSaldoxCuentas

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuBalanceDeSituacion_Click(sender As Object, e As EventArgs) Handles MnuBalanceDeSituacion.Click
        Dim Forma As New FrmRptBalanceDeSituacion

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuEstadoDeResultados_Click(sender As Object, e As EventArgs) Handles MnuEstadoDeResultados.Click
        Dim Forma As New FrmRptEstadoResultados

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuBalanceDeComprobacion_Click(sender As Object, e As EventArgs) Handles MnuBalanceDeComprobacion.Click
        Dim Forma As New FrmRptBalanceDeComprobacion

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCierreDePeriodo_Click(sender As Object, e As EventArgs) Handles MnuCierreDePeriodo.Click
        Dim Forma As New FrmCierreProcesoAnnio

        Try
            If EmpresaParametroInfo.GetProcesoMes <> EmpresaParametroInfo.GetMesCierreFiscal Then
                VerificaMensaje("Para poder realizar el cierre de periodo el mes en proceso debe de ser " & MesNombre(EmpresaParametroInfo.GetMesCierreFiscal))
            Else
                Forma.Execute()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            TSSPeriodo.Text = MesNombre(EmpresaParametroInfo.GetProcesoMes) & "-" & EmpresaParametroInfo.GetProcesoAnnio
        End Try
    End Sub

    Private Sub MnuEstadoDeCambiosPatrimonio_Click(sender As Object, e As EventArgs) Handles MnuEstadoDeCambiosPatrimonio.Click
        Dim Forma As New FrmRptCambiosPatrimonio

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuImportarAsientos_Click(sender As Object, e As EventArgs) Handles MnuImportarAsientos.Click
        Dim Forma As New FrmAuxAsientoLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCuentaFlujoEfectivo_Click(sender As Object, e As EventArgs) Handles MnuCuentaFlujoEfectivo.Click
        Dim Forma As New FrmMantCuentaFlujoDetalle

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuEstadoFlujoEfectivo_Click(sender As Object, e As EventArgs) Handles MnuEstadoFlujoEfectivo.Click
        Dim Forma As New FrmRptFlujoEfeectivo

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

End Class