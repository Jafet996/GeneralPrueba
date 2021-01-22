Imports Business
Imports System.IO
Imports System.Threading
Public Class FrmMain
    Delegate Sub DlgFinalizaGuardaMenu()
    Dim Xpos As Integer
    Dim ypos As Integer

    Private Sub MnuSalir_Click(sender As System.Object, e As System.EventArgs) Handles MnuSalir.Click
        Application.Exit()
    End Sub

    Private Sub MuestraMenu(pMostrar)
        MnuProcesos.Visible = pMostrar
        MnuCatalogos.Visible = pMostrar
        MnuConsultas.Visible = pMostrar
        MnuReportes.Visible = pMostrar
        MnuTomaFisica.Visible = pMostrar
    End Sub
    Private Sub MuestraEquiquetas(pVisible As Boolean)
        LblEmpresaNombre.Visible = pVisible
        TSSCompaniaLabel.Visible = pVisible
        TSSCompania.Visible = pVisible
        TSSSucursalLabel.Visible = pVisible
        TSSSucursal.Visible = pVisible
        TSSUsuarioLabel.Visible = pVisible
        TSSUsuario.Visible = pVisible
        PnlShortCuts.Visible = pVisible
    End Sub
    Private Sub MnuConexión_Click(sender As System.Object, e As System.EventArgs) Handles MnuConexión.Click
        Dim Forma As New FrmConexion
        Try
            Inicializa()

            Forma.Execute()
            If Forma.Conecto Then
                'MuestraMenu(True)
                TSSCompania.Text = EmpresaInfo.Nombre
                TSSSucursal.Text = SucursalInfo.Nombre
                TSSUsuario.Text = UsuarioInfo.Nombre
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

                PicFacturacionElectronica.Visible = EmpresaParametroInfo.FacturacionElectronica

                BtnConexion.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Inventario, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuConexión") = "")
                BtnConsultaArticulos.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Inventario, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuConsultaArtículos") = "")
                BtnArticulo.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Inventario, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuArticulo") = "")
                BtnTrasladoDeInventario.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Inventario, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuTrasladoDeInventario") = "")
                BtnAjusteDeInventario.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Inventario, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuAjustesDeInventario") = "")
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
        TSSSucursal.Text = ""
        TSSUsuario.Text = ""
        LblEmpresaNombre.Text = ""
        MuestraEquiquetas(False)
    End Sub

    Private Sub CambiaInterfaz()
        Dim Interfaz As String = String.Empty
        Try

            'If InfoMaquina.Interfaz = "2" Then
            '    Me.BackColor = Color.White
            '    PanelMain.BackColor = Color.LightSkyBlue
            '    MainMenuStrip.BackColor = Color.Pink
            '    StatusBar.BackColor = Color.LightSkyBlue
            '    BtnConsultaArticulos.BackColor = Color.LightSkyBlue
            '    BtnConexion.BackColor = Color.LightSkyBlue
            'End If

            If InfoMaquina.Interfaz = "2" Then
                Me.BackColor = Color.White
                PanelMain.BackColor = Color.LightSkyBlue
                MainMenuStrip.BackColor = Color.Pink
                StatusBar.BackColor = Color.LightSkyBlue
                BtnTrasladoDeInventario.BackColor = Color.LightSkyBlue
                BtnConsultaArticulos.BackColor = Color.LightSkyBlue
                BtnArticulo.BackColor = Color.LightSkyBlue
                BtnConexion.BackColor = Color.LightSkyBlue
            End If

            If InfoMaquina.Interfaz = "3" Then
                Me.BackColor = Color.LightSkyBlue
                'Me.BackColor = Color.White
                PanelMain.BackColor = Color.PowderBlue
                MainMenuStrip.BackColor = Color.White
                StatusBar.BackColor = Color.PowderBlue
                BtnTrasladoDeInventario.BackColor = Color.SteelBlue
                BtnConsultaArticulos.BackColor = Color.SteelBlue
                BtnArticulo.BackColor = Color.SteelBlue
                BtnConexion.BackColor = Color.SteelBlue
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Modulo_Id = Modulos.Inventario
        Dim FormaMac As New FrmMacAddress
        Try


            VerificaMensaje(VerificaArchivoIni())

            InfoMaquina.MAC_Address = GetMaquinaId()
            If InfoMaquina.MAC_Address.Trim = String.Empty Then
                FormaMac.Execute()
                VerificaMensaje("Debe definir valor de registro")
            End If

            VerificaMensaje(InfoMaquina.ListKey)
            If InfoMaquina.RowsAffected = 0 Then
                CreaConfiguracionMaquina(InfoMaquina)
            End If

            Me.Text = "SD-BUSINESS " & My.Application.Info.Version.ToString

            VerificaVersionModulo(Modulo_Id, My.Application.Info.Version.ToString)

            CentraImagen()
            CambiaInterfaz()
            FormatearOpcionesRegionales()
            Inicializa()
            'VerificaVersion()

            MnuConexión_Click(Nothing, EventArgs.Empty)

        Catch ex As Exception
            MensajeError(ex.Message)
            Application.Exit()
        Finally
            FormaMac = Nothing
        End Try
    End Sub

    Private Sub VerificaVersion()

        Dim modulo As New TModulo(EmpresaInfo.Emp_Id)
        Dim ServerVersion As String = ""
        Dim proceso As New Process()

        Try
            modulo.Modulo_Id = Modulos.PuntoVenta

            VerificaMensaje(modulo.ListKey())

            ServerVersion = modulo.Major & "." & modulo.Menor & "." & modulo.Bug & "." & modulo.Build

            If Not Application.ProductVersion.Equals(ServerVersion) Then

                Mensaje("Existe una actualización pendiente por favor proceda a descargarla")

                proceso.Start("C:\Program Files\SOFTDESIGN\Actualizador SD\Actualizador SD Business.exe")

                Application.Exit()

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MnuAjustesDeInventario_Click(sender As System.Object, e As System.EventArgs) Handles MnuAjustesDeInventario.Click
        Dim Forma As New FrmAjusteInventario
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuArticulo_Click(sender As System.Object, e As System.EventArgs) Handles MnuArticulo.Click
        Dim Forma As New FrmMantarticuloDetalle_
        Try
            'Forma.MdiParent = Me

            If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvMantenimientodeArticulos, True) Then
                Forma.Execute()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCategoria_Click(sender As System.Object, e As System.EventArgs) Handles MnuCategoria.Click
        Dim Forma As New FrmMantCategoriaLista
        Try
            'Forma.MdiParent = Me
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuDepartamento_Click(sender As System.Object, e As System.EventArgs) Handles MnuDepartamento.Click
        Dim Forma As New FrmMantDepartamentoLista
        Try
            'Forma.MdiParent = Me
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuUnidadMedida_Click(sender As System.Object, e As System.EventArgs) Handles MnuUnidadMedida.Click
        Dim Forma As New FrmMantUnidadMedidaLista
        Try
            'Forma.MdiParent = Me
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuSubCategoría_Click(sender As System.Object, e As System.EventArgs) Handles MnuSubCategoría.Click
        Dim Forma As New FrmMantSubCategoriaLista
        Try
            'Forma.MdiParent = Me
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuConsultaArtículos_Click(sender As System.Object, e As System.EventArgs) Handles MnuConsultaArtículos.Click
        Dim Forma As New FrmConsultaArticulo
        Try
            ''Forma.MdiParent = Me
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuUsuario_Click(sender As System.Object, e As System.EventArgs) Handles MnuUsuario.Click
        Dim Forma As New FrmMantUsuarioDetalle
        Try
            'Forma.MdiParent = Me
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub



    Private Sub MnuAjusteDeCosto_Click(sender As System.Object, e As System.EventArgs) Handles MnuAjusteDeCosto.Click
        Dim Forma As New FrmAjusteCosto
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuArticuloBodega_Click(sender As System.Object, e As System.EventArgs) Handles MnuArticuloBodega.Click
        Dim Forma As New FrmArticuloBodega
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
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
        Dim Menu As New TMenu(Modulo_Id)
        Dim Dlg As DlgFinalizaGuardaMenu = AddressOf FinalizaGuardaMenu
        Try
            VerificaMensaje(Menu.Delete())

            RecorrerNivelesAltos(Menu)

            Me.Invoke(Dlg, New Object() {})

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Menu = Nothing
        End Try

    End Sub
    Private Sub FinalizaGuardaMenu()
        TSSCompaniaLabel.BackColor = Color.White
    End Sub

    Private Sub MnuGrupo_Click(sender As System.Object, e As System.EventArgs) Handles MnuGrupo.Click
        Dim Forma As New FrmMantGrupoLista
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    'Private Sub MnuGeneraListadoArticulos_Click(sender As System.Object, e As System.EventArgs) Handles MnuGeneraListadoArticulos.Click
    '    Dim Forma As New FrmGeneraListadoArticulos
    '    Try

    '        Forma.Execute()

    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    Finally
    '        Forma = Nothing
    '    End Try
    'End Sub

    Private Sub MnuSaldosInventario_Click(sender As System.Object, e As System.EventArgs) Handles MnuSaldosInventario.Click
        Dim Forma As New FrmRepSaldosInventario
        Try

            Forma.Execute(True, False)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


    Private Sub MnuSaldosInventarioProveedor_Click(sender As System.Object, e As System.EventArgs) Handles MnuSaldosInventarioProveedor.Click
        Dim Forma As New FrmRepSaldosInventarioProveedor
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


    Private Sub MnuListadoTomaFisica_Click(sender As System.Object, e As System.EventArgs) Handles MnuListadoTomaFisica.Click
        Dim Forma As New FrmRepSaldosInventarioUbicacion
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuSaldosDeInventarioSinCostos_Click(sender As System.Object, e As System.EventArgs) Handles MnuSaldosDeInventarioSinCostos.Click
        Dim Forma As New FrmRepSaldosInventario
        Try

            Forma.Execute(False, False)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnConexion_Click(sender As System.Object, e As System.EventArgs) Handles BtnConexion.Click
        MnuConexión.PerformClick()
    End Sub

    Private Sub BtnConsultaArticulos_Click(sender As System.Object, e As System.EventArgs) Handles BtnConsultaArticulos.Click
        MnuConsultaArtículos.PerformClick()
    End Sub


    Private Sub MnuAjusteCostoMasivo_Click(sender As System.Object, e As System.EventArgs) Handles MnuAjusteCostoMasivo.Click
        Dim Forma As New FrmListaArticulos
        Try

            Forma.Execute(FrmListaArticulos.EnumFuncionalidad.AjusteCosto)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCambioPrecioMasivo_Click(sender As System.Object, e As System.EventArgs) Handles MnuCambioPrecioMasivo.Click
        Dim Forma As New FrmListaArticulos
        Try

            Forma.Execute(FrmListaArticulos.EnumFuncionalidad.CambioPrecio)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuListadoPrecios_Click(sender As System.Object, e As System.EventArgs) Handles MnuListadoPrecios.Click
        Dim Forma As New FrmRepListadoPrecios
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub FrmMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        CentraImagen()
    End Sub



    Private Sub MnuIniciarTomaFisica_Click(sender As Object, e As EventArgs) Handles MnuIniciarTomaFisica.Click
        Dim Forma As New FrmTomaFisicaIniciar

        Try
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuConteoFisico_Click(sender As Object, e As EventArgs) Handles MnuConteoFisico.Click
        Dim TomaFisica As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim Forma As New FrmConteoFisicoBodegas

        Try

            TomaFisica = SeleccionaTomaFisicaActivaSucursal(SucursalInfo.Suc_Id)

            If Not TomaFisica Is Nothing Then
                Forma.Execute(TomaFisica)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TomaFisica = Nothing
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuRebajoVentas_Click(sender As Object, e As EventArgs) Handles MnuRebajoVentas.Click
        Dim TomaFisica As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim Forma As New FrmRebajoVentas
        Try

            TomaFisica = SeleccionaTomaFisicaActivaSucursal(SucursalInfo.Suc_Id)

            If Not TomaFisica Is Nothing Then
                Forma.Execute(TomaFisica)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TomaFisica = Nothing
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuReporteDiferencias_Click(sender As Object, e As EventArgs) Handles MnuReporteDiferencias.Click
        Dim TomaFisica As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim Forma As New FrmRepDiferencias
        Try

            TomaFisica = SeleccionaTomaFisicaActivaSucursal(SucursalInfo.Suc_Id)

            If Not TomaFisica Is Nothing Then
                Forma.Execute(TomaFisica)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TomaFisica = Nothing
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuAplicarTomaFisica_Click(sender As Object, e As EventArgs) Handles MnuAplicarTomaFisica.Click
        Dim TomaFisica As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim Forma As New FrmTomaFisicaAplica
        Try

            TomaFisica = SeleccionaTomaFisicaActivaSucursal(SucursalInfo.Suc_Id)

            If Not TomaFisica Is Nothing Then
                Forma.Execute(TomaFisica)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TomaFisica = Nothing
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuSaldosXBodega_Click(sender As Object, e As EventArgs) Handles MnuSaldosXBodega.Click
        Dim Forma As New FrmRepSaldoXBodega

        Try
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuAcercaDe_Click(sender As Object, e As EventArgs) Handles MnuAcercaDe.Click
        Dim Forma As New FrmAcercaDe

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuPromociones_Click(sender As Object, e As EventArgs) Handles MnuPromociones.Click
        Dim Forma As New FrmMantArticuloPromocionDetalle

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuArticulosInactivosSinSaldo_Click(sender As Object, e As EventArgs) Handles MnuArticulosInactivosSinSaldo.Click
        Dim Forma As New FrmArticuloEstado

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuTrasladoDeInventario_Click(sender As Object, e As EventArgs) Handles MnuTrasladoDeInventario.Click
        Dim Forma As New FrmTrasladoinventario

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuArticulosInactivosConSaldo_Click(sender As Object, e As EventArgs) Handles MnuArticulosInactivosConSaldo.Click
        Dim Forma As New FrmRepInactivosConSaldo

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuPonerSaldosEnCero_Click(sender As Object, e As EventArgs) Handles MnuPonerSaldosEnCero.Click
        Dim Forma As New FrmPonerSaldosenCero

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCancelarTomaFísica_Click(sender As Object, e As EventArgs) Handles MnuCancelarTomaFísica.Click
        Dim TomaFisica As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim Forma As New FrmTomaFisicaCancela
        Try

            TomaFisica = SeleccionaTomaFisicaActivaSucursal(SucursalInfo.Suc_Id)

            If Not TomaFisica Is Nothing Then
                If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.InvCancelarTomaFisica, True) Then
                    Forma.Execute(TomaFisica)
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TomaFisica = Nothing
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuKardexResumido_Click(sender As Object, e As EventArgs) Handles MnuKardexResumido.Click
        Dim Forma As New FrmRepKardexDetallado
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuKardexDetallado_Click(sender As Object, e As EventArgs) Handles MnuKardexDetallado.Click
        Dim Forma As New FrmRepKardexArticulo
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try

    End Sub

    Private Sub MnuLotes_Click(sender As Object, e As EventArgs) Handles MnuLotes.Click
        Dim Forma As New FrmMantLoteLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuResultadoTomaFísica_Click(sender As Object, e As EventArgs) Handles MnuResultadoTomaFísica.Click
        Dim Forma As New FrmRepResultadoTomaFisica

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuGenerarEtiqueta_Click(sender As Object, e As EventArgs) Handles MnuGenerarEtiqueta.Click
        Dim Forma As New FrmGeneraEtiqueta

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub PanelMain_DoubleClick(sender As Object, e As EventArgs) Handles PanelMain.DoubleClick
        Try

            Cursor.Current = Cursors.WaitCursor

            GuardaMenu()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub MnuFamilia_Click(sender As Object, e As EventArgs) Handles MnuFamilia.Click
        Dim Forma As New FrmMantFamiliaArt

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuAjusteDeProduccion_Click(sender As Object, e As EventArgs) Handles MnuAjusteDeProduccion.Click
        Dim Forma As New FrmAjusteProduccion
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnArticulo_Click(sender As Object, e As EventArgs) Handles BtnArticulo.Click
        Try
            MnuArticulo.PerformClick()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MnuSaldosPorCategoría_Click(sender As Object, e As EventArgs) Handles MnuSaldosPorCategoría.Click
        Dim Forma As New FrmRepSaldoXCategoria
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub TrasladoPorArtículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrasladoPorArtículoToolStripMenuItem.Click
        Dim Forma As New FrmRepTrasladosXArticulo
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuSaldosPorDepartamento_Click(sender As Object, e As EventArgs) Handles MnuSaldosPorDepartamento.Click
        Dim Forma As New FrmRepSaldosXDepartamento
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuGeneraEtiqueta_Click(sender As Object, e As EventArgs) Handles MnuGeneraEtiqueta.Click
        Dim Forma As New FrmGeneraEtiquetaIVP
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuAjusteVentasYCompras_Click(sender As Object, e As EventArgs)
        Dim TomaFisica As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim Forma As New FrmAjusteVentasyCompras
        Try

            TomaFisica = SeleccionaTomaFisicaActivaSucursal(SucursalInfo.Suc_Id)

            If Not TomaFisica Is Nothing Then
                Forma.Execute(TomaFisica)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TomaFisica = Nothing
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnTrasladoDeInventario_Click(sender As Object, e As EventArgs) Handles BtnTrasladoDeInventario.Click
        MnuTrasladoDeInventario.PerformClick()
    End Sub

    Private Sub ProductosActualizadosMnu_Click(sender As Object, e As EventArgs) Handles ProductosActualizadosMnu.Click
        Dim Forma As New FrmPreciosCambiados()
        Try
            Forma.execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuAjusteMargenesMasivoMnu_Click(sender As Object, e As EventArgs) Handles MnuAjusteMargenesMasivoMnu.Click
        Dim Forma As New FrmAjusteMargenMasivo()
        Try
            Forma.execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuGeneraEtiquetaCCSS_Click(sender As Object, e As EventArgs) Handles MnuGeneraEtiquetaCCSS.Click
        Dim Forma As New FrmGeneraEtiquetaMediKam()
        Try
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnAjusteDeInventario_Click(sender As Object, e As EventArgs) Handles BtnAjusteDeInventario.Click
        MnuAjustesDeInventario.PerformClick()
    End Sub

    Private Sub MnuGenerarArchivoArticulos_Click(sender As Object, e As EventArgs) Handles MnuGenerarArchivoArticulos.Click
        Dim Forma As New FrmActualizacionArticulos
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuSaldosDeInventarioAgrupado_Click(sender As Object, e As EventArgs) Handles MnuSaldosDeInventarioAgrupado.Click
        Dim Forma As New FrmRepSaldosInventarioAgrupado
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuPreciosXCategoria_Click(sender As Object, e As EventArgs) Handles MnuPreciosXCategoria.Click
        Dim Forma As New FrmRepListadoPreciosxCategoria
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub AsignaciToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignaciToolStripMenuItem.Click
        Dim Forma As New FRMBuscquedaArticuloCabys
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub SaldoInventarioLOTESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaldoInventarioLOTESToolStripMenuItem.Click
        Dim Forma As New FrmRepSaldosInventario
        Try

            Forma.Execute(True, True)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
End Class