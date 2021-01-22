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
        MnuCaja.Visible = pMostrar
        MnuProcesos.Visible = pMostrar
        MnuCatalogos.Visible = pMostrar
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
        TSSCajaLabel.Visible = pVisible
        TSSCaja.Visible = pVisible
        BtnPAgoRapido.Visible = pVisible
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
                TSSCaja.Text = CajaInfo.Nombre

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
                BtnMovimientos.Enabled = (VerificaUsuarioPermisoOpcion(Modulo_Id, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuMovimientos") = "")
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
        Modulo_Id = Enum_Modulos.CXC
        Dim FormaMac As New FrmMacAddress
        Try

            InfoMaquina.MAC_Address = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegMaquinaId, String.Empty)

            InfoMaquina.Identificacion_Id = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coIdentificacion_Id, String.Empty)

            If InfoMaquina.MAC_Address = String.Empty Then
                FormaMac.Execute()
                VerificaMensaje("Debe definir valor de registro")
            End If

            InfoMaquina.Url = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegUrl, String.Empty)
            VerificaMensaje(InfoMaquina.ListKey)

            If InfoMaquina.RowsAffected = 0 Then
                CreaConfiguracionMaquina(InfoMaquina)
            End If

            Me.Text = "SD-CXC " & My.Application.Info.Version.ToString

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

    Private Sub MnuMovimientos_Click(sender As Object, e As EventArgs) Handles MnuMovimientos.Click
        Dim Forma As New FrmMovimientosCliente

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuAperturaCaja_Click(sender As Object, e As EventArgs) Handles MnuAperturaCaja.Click
        Dim Forma As New FrmCajaApertura

        Try
            VerificaMensaje(CajaEstaCerrada)

            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnMovimientos_Click(sender As Object, e As EventArgs) Handles BtnMovimientos.Click
        MnuMovimientos.PerformClick()
    End Sub

    Private Sub MnuDocumentosProximosVencer_Click(sender As Object, e As EventArgs) Handles MnuDocumentosProximosVencer.Click
        Dim Forma As New FrmRptDocumentosProximosVencer

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCompraDolares_Click(sender As Object, e As EventArgs) Handles MnuCompraDolares.Click
        Dim Forma As New FrmCambiaMoneda

        Try
            With Forma
                .Titulo = "Compra de Dólares"
                .TipoMovimiento = 1
                .Execute()
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCierreCaja_Click(sender As Object, e As EventArgs) Handles MnuCierreCaja.Click
        Dim Forma As New FrmCajaCierre

        Try
            VerificaMensaje(CajaEstaAbierta)

            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuDevolucionDolares_Click(sender As Object, e As EventArgs) Handles MnuDevolucionDolares.Click
        Dim Forma As New FrmCambiaMoneda

        Try
            With Forma
                .Titulo = "Devolución de Dólares"
                .TipoMovimiento = 2
                .Execute()
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCliente_Click(sender As Object, e As EventArgs) Handles MnuCliente.Click
        Dim Forma As New FrmMantClienteLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
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

    Private Sub MnuSaldosPendientes_Click(sender As Object, e As EventArgs) 
        Dim Forma As New FrmRptClientesConSaldo

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuFacturaPendiente_Click(sender As Object, e As EventArgs) Handles MnuFacturaPendiente.Click
        Dim Forma As New FrmRptFacturaPendiente

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuEstadoCuentaCliente_Click(sender As Object, e As EventArgs) Handles MnuEstadoCuentaCliente.Click
        Dim Forma As New FrmRptEstadoCuenta

        Try
            Forma.Nuevo = True
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuMovimientosCliente_Click(sender As Object, e As EventArgs) Handles MnuMovimientosCliente.Click
        Dim Forma As New FrmRptMovimientosPorCliente

        Try
            Forma.Nuevo = True
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CobrosPorPeriodoMnu_Click(sender As Object, e As EventArgs) Handles CobrosPorPeriodoMnu.Click
        Dim Forma As New FrmRptCobrosPorFechas
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally

            Forma = Nothing

        End Try

    End Sub

    Private Sub MnuAsignaFacturaVendedores_Click(sender As Object, e As EventArgs) Handles MnuAsignarDocumentosAVendedores.Click 
        Dim forma As New FrmAsignaFacturaVendedor()

        Try
            forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub


    Private Sub ComisionesPorVendedorMnu_Click_1(sender As Object, e As EventArgs) Handles ComisionesPorVendedorMnu.Click
        Dim forma As New FrmRptComisionesPorVendedor()

        Try

            forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub AjusteDeFacturasMnu_Click(sender As Object, e As EventArgs) Handles AjusteDeFacturasMnu.Click
        Dim forma As New FrmAjusteDeFacturaConSaldo()

        Try

            forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MnuDocumentosVencidos_Click(sender As Object, e As EventArgs) Handles MnuDocumentosVencidos.Click
        Dim forma As New FrmRptDocumentosVencidos()

        Try

            forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MnuMovimientosGenerales_Click(sender As Object, e As EventArgs) Handles MnuMovimientosGenerales.Click
        Dim forma As New FrmRptMovimientosGenerales()

        Try

            forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MnuDescargueConsumo_Click(sender As Object, e As EventArgs) Handles MnuDescargueConsumo.Click
        Dim forma As New FrmDescargueConsumo()

        Try

            forma.execute()

        Catch ex As Exception

            MensajeError(ex.Message)

        End Try
    End Sub

    Private Sub MnuRptDescargueConsumo_Click(sender As Object, e As EventArgs) Handles MnuRptDescargueConsumo.Click
        Dim forma As New FrmRptDescargueConsumoInterno()

        Try

            forma.Execute()

        Catch ex As Exception

            MensajeError(ex.Message)

        End Try
    End Sub

    Private Sub MnuPagoRapido_Click(sender As Object, e As EventArgs) Handles MnuPagoRapido.Click
        Dim forma As New FrmPagoRapidoFacturas()

        Try

            forma.Execute()

        Catch ex As Exception

            MensajeError(ex.Message)

        End Try
    End Sub

    Private Sub BtmPagoRapido_Click(sender As Object, e As EventArgs) Handles BtmPagoRapido.Click
        MnuPagoRapido.PerformClick()
    End Sub
End Class