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

                BtnConexion.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Compras, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuConexión") = "")
                BtnConsultaArticulos.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Compras, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuConsultaArtículos") = "")
                BtnEntradaDeMercaderia.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Compras, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuEntradaDeMercaderia") = "")
                BtnRecepcionDeMercaderia.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Compras, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuRecepcionDeMercaderia") = "")
                BtnOrdenCompra.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Compras, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuOrdenCompra") = "")
                BtnArticulo.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.Compras, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuArticulo") = "")

                PicFacturacionElectronica.Visible = EmpresaParametroInfo.FacturacionElectronica

                CalcularPromedioVenta()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CalcularPromedioVenta()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Try

            With ArticuloBodega
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = 1
            End With

            VerificaMensaje(ArticuloBodega.CalculaPromedioVenta())


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
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
                BtnConsultaArticulos.BackColor = Color.LightSkyBlue
                BtnOrdenCompra.BackColor = Color.LightSkyBlue
                BtnEntradaDeMercaderia.BackColor = Color.LightSkyBlue
                BtnConexion.BackColor = Color.LightSkyBlue
            End If

            If InfoMaquina.Interfaz = "3" Then
                Me.BackColor = Color.LightSkyBlue
                'Me.BackColor = Color.White
                PanelMain.BackColor = Color.PowderBlue
                MainMenuStrip.BackColor = Color.White
                StatusBar.BackColor = Color.PowderBlue
                BtnConsultaArticulos.BackColor = Color.SteelBlue
                BtnOrdenCompra.BackColor = Color.SteelBlue
                BtnEntradaDeMercaderia.BackColor = Color.SteelBlue
                BtnConexion.BackColor = Color.SteelBlue
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Modulo_Id = Modulos.Compras
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

    Private Sub MnuConsultaArtículos_Click(sender As System.Object, e As System.EventArgs) Handles MnuConsultaArtículos.Click
        Dim Forma As New FrmConsultaArticulo
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuOrdenCompra_Click(sender As System.Object, e As System.EventArgs) Handles MnuOrdenCompra.Click
        Dim Forma As New FrmOrdenCompra
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub EntradaDeMercaderiaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MnuEntradaDeMercaderia.Click
        Dim Forma As New FrmEntradaMercaderia
        Try


            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuProveedor_Click(sender As System.Object, e As System.EventArgs) Handles MnuProveedor.Click
        Dim Forma As New FrmMantProveedorLista
        Try
            'Forma.MdiParent = Me
            Forma.Execute(False)

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

    Private Sub MnuComprasXFecha_Click(sender As System.Object, e As System.EventArgs)
        Dim Forma As New FrmRepEntradasxFecha
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuEtiquetasCodigoBarra_Click(sender As System.Object, e As System.EventArgs) Handles MnuEtiquetasCodigoBarra.Click
        Dim Forma As New FrmEtiquetaCodigoBarra
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuProveedoresxArticulo_Click(sender As System.Object, e As System.EventArgs) Handles MnuProveedoresxArticulo.Click
        Dim Forma As New FrmMantArticuloProveedor
        Try
            'Forma.MdiParent = Me
            Forma.Execute()

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

    Private Sub FrmMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        CentraImagen()
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

    Private Sub EntadasXUnidadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntadasXUnidadesToolStripMenuItem.Click
        Dim Forma As New FrmRepEntradasXUnidades
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub







    Private Sub MnuComprasPorFecha_Click(sender As Object, e As EventArgs) Handles MnuComprasPorFecha.Click
        Dim Forma As New FrmRepEntradasxFecha
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuComprasPorFechaDetallado_Click(sender As Object, e As EventArgs) Handles MnuComprasPorFechaDetallado.Click
        Dim Forma As New FrmRepEntradasxFechaDetallado
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuComprasPorProveedor_Click(sender As Object, e As EventArgs) Handles MnuComprasPorProveedor.Click
        Dim Forma As New FrmRepEntradasPorProveedor
        Try
            Forma.execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnOrdenCompra_Click(sender As Object, e As EventArgs) Handles BtnOrdenCompra.Click
        MnuOrdenCompra.PerformClick()
    End Sub

    Private Sub BtnEntradaDeMercaderia_Click(sender As Object, e As EventArgs) Handles BtnEntradaDeMercaderia.Click
        MnuEntradaDeMercaderia.PerformClick()
    End Sub



    Private Sub MnuArticulo_Click(sender As Object, e As EventArgs) Handles MnuArticulo.Click
        Dim Forma As New FrmMantArticuloDetalle
        Try

            If VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.ComMantenimientodeArticulos, True) Then
                Forma.Execute()
            End If

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

    Private Sub MnuRecepcionDeMercaderia_Click(sender As Object, e As EventArgs) Handles MnuRecepcionDeMercaderia.Click
        Dim forma As New FrmCargaFacturaElectronica
        Try

            forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnRecepcionDeMercaderia_Click(sender As Object, e As EventArgs) Handles BtnRecepcionDeMercaderia.Click
        MnuRecepcionDeMercaderia.PerformClick()
    End Sub

    Private Sub MnuEmailRecepcionFacturas_Click(sender As Object, e As EventArgs) Handles MnuEmailRecepcionFacturas.Click
        Dim forma As New FrmMantEmailReceptorLista
        Try

            forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class