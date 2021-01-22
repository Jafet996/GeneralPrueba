Imports Business
Imports System.Threading
Imports System.IO
Public Class FrmMain
    Delegate Sub DlgFinalizaGuardaMenu()
#Region "Variables"
    Dim Xpos As Integer
    Dim ypos As Integer
#End Region

    Private Sub MnuSalir_Click(sender As System.Object, e As System.EventArgs) Handles MnuSalir.Click
        Application.Exit()
    End Sub

    Private Sub MnuFacturacion_Click(sender As System.Object, e As System.EventArgs) Handles MnuFacturacion.Click
        Dim Forma As New FrmPuntoVentaRetail

        Try
            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If RevisaCajaEstado(True) Then
                VerificaMensaje(CajaInfo.ListKey)
                Forma.Execute(Enum_TipoFacturacion.Factura, -1)
            Else
                VerificaMensaje("Imposible facturar, primero debe de abrir caja")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MuestraMenu(pMostrar)
        MnuProcesos.Visible = pMostrar
        MnuCatalogos.Visible = pMostrar
        MnuConsultas.Visible = pMostrar
        MnuReportes.Visible = pMostrar
        MnuControlDeServicios.Visible = pMostrar
        MnuFacturacionElectronica.Visible = pMostrar
        MnuCuentasXCobrar.Visible = pMostrar And EmpresaParametroInfo.InterfazCxC
    End Sub

    Private Sub MuestraEquiquetas(pVisible As Boolean)
        TSSUsuarioLabel.Visible = pVisible
        TSSUsuario.Visible = pVisible
        PnlShortCuts.Visible = pVisible
    End Sub

    Private Sub NombreBotonAbreCierreCaja()
        Dim Abierta As Boolean
        Try

            Abierta = RevisaCajaEstado(True)

            BtnAbreCierraCaja.Text = IIf(Abierta, coCajaCierre, coCajaApertura)

            If BtnAbreCierraCaja.Text = coCajaApertura Then
                BtnAbreCierraCaja.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuAbrirCaja") = "")
            Else
                BtnAbreCierraCaja.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuCierreCaja") = "")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub



    Private Sub MnuConexión_Click(sender As System.Object, e As System.EventArgs) Handles MnuConexión.Click
        Dim Forma As New FrmConexion
        Dim ThdTipoCambio As Thread
        'Dim ThdEncargos As Thread
        Try
            Inicializa()
            Forma.Execute()
            If Forma.Conecto Then
                TSSUsuario.Text = UsuarioInfo.Nombre
                MuestraEquiquetas(True)
                HabilitaMenuGrupo(MenuStripPrincipal, UsuarioInfo.Grupo_Id, Modulo_Id)

                'Desabilita los accesos directos
                BtnPreFactura.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuPreFactura") = "")
                BtnProforma.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuProforma") = "")
                BtnFacturacion.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuFacturacion") = "")
                BtnConexion.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuConexión") = "")
                BtnSaldosInventario.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuSaldosInventario") = "")
                BtnConsultaCliente.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuConsultaCliente") = "")
                BtnReimpresionDocumentos.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuReimpresionDocumentos") = "")
                BtnCxC.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuPagos") = "")
                BtnBoletaDeServicio.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuBoletaDeServicio") = "")
                BtnApartadoNuevo.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuApartadoNuevo") = "")
                BtnApartadoAbono.Enabled = (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuApartadoAbono") = "")

                NombreBotonAbreCierreCaja()

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

                EnviaCorreoEncagos()

                Try
                    If (EmpresaParametroInfo.InterfazCxC OrElse EmpresaParametroInfo.InterfazCxP) AndAlso Not InfoMaquina Is Nothing AndAlso InfoMaquina.URLContabilidad <> "" Then
                        EmpresaParametroInfo.FinancialDB = EmpresaParametroInfo.GetFinancialDB()
                    End If

                Catch ex As Exception
                    MensajeError(ex.Message)
                End Try


                'ThdEncargos = New Thread(AddressOf EnviarCorreoEncargos)
                'ThdEncargos.Start()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            ThdTipoCambio = Nothing
            'ThdEncargos = Nothing
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
        TSSUsuario.Text = ""
        MuestraEquiquetas(False)
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Modulo_Id = Modulos.PuntoVenta
        Dim Forma As New FrmConexion
        Dim FormaMac As New FrmMacAddress
        Dim Mensaje As String
        Dim MensajeInstancia As String
        Try


            MensajeInstancia = VerificaPuntoVentaAbierto()
            If MensajeInstancia <> String.Empty Then
                MensajeError(MensajeInstancia)
            End If


            VerificaMensaje(VerificaArchivoIni())

            'Verifica la licencia del software para la modalidad de alquiler
            VerificaMensaje(VerificaModulo(Modulo_Id))

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


            If InfoMaquina.ActualizacionAutomatica Then
                VerificaVersionModulo(Modulo_Id, My.Application.Info.Version.ToString)
            End If

            CentraImagen()
            CambiaInterfaz()

            FormatearOpcionesRegionales()
            Inicializa()
            Mensaje = CargaParametrosSistema()

            'VerificaVersion()

            If Mensaje <> "" Then
                MensajeError(Mensaje)
                Application.Exit()
            Else

                VerificaMensaje(ValidaFacturacionElectronica())

                TSSCompania.Text = EmpresaInfo.Nombre
                TSSSucursal.Text = SucursalInfo.Nombre
                TSSUsuario.Text = UsuarioInfo.Nombre
                TSSCaja.Text = CajaInfo.Nombre
                LblEmpresaNombre.Text = EmpresaInfo.Nombre

                If CajaInfo.Abierta Then
                    TSSTipoCambio.Text = Format(TipoCambioCierreCaja(CajaInfo.Suc_Id, CajaInfo.Caja_Id, CajaInfo.Cierre_Id), "#,##0.00")
                Else
                    If EmpresaParametroInfo.TipoCambioFac = "C" Then
                        TSSTipoCambio.Text = Format(TipoCambioCompra(), "#,##0.00")
                    Else
                        TSSTipoCambio.Text = Format(TipoCambioVenta(), "#,##0.00")
                    End If
                End If
                PicFacturacionElectronica.Visible = EmpresaParametroInfo.FacturacionElectronica

                MnuConexión_Click(Nothing, EventArgs.Empty)

                MnuFacturacionElectronica.Visible = EmpresaParametroInfo.FacturacionElectronica AndAlso (VerificaUsuarioPermisoOpcion(Modulos.PuntoVenta, EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, "MnuFacturacionElectronica") = "")

            End If



        Catch ex As Exception
            MensajeError(ex.Message)
            Application.Exit()
        Finally
            Forma = Nothing
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

            If Not Application.ProductVersion.ToString() = ServerVersion Then
                Mensaje("Existe una actualización pendiente por favor proceda a descargarla")

                proceso.Start(coActualizador)

                Application.Exit()

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MnuAbrirCaja_Click(sender As System.Object, e As System.EventArgs) Handles MnuAbrirCaja.Click
        Dim Forma As New FrmAbrirCaja

        Try
            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If RevisaCajaEstado(False) Then
                Forma.Execute()
            Else
                VerificaMensaje("Imposible abrir la caja, ya que esta ya se encuentra abierta")
            End If

            NombreBotonAbreCierreCaja()

            TSSTipoCambio.Text = TipoCambioCierreCaja(CajaInfo.Suc_Id, CajaInfo.Caja_Id, CajaInfo.Cierre_Id).ToString("#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuClientes_Click(sender As System.Object, e As System.EventArgs) Handles MnuClientes.Click
        Dim Forma As New FrmMantClienteLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuVentasXCategoria_Click(sender As System.Object, e As System.EventArgs) Handles MnuVentasXCategoria.Click
        Dim Forma As New FrmRepVentasxCategoria
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
        'TSSCompaniaLabel.BackColor = Color.White
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

    Private Sub MnuUsuario_Click(sender As System.Object, e As System.EventArgs) Handles MnuUsuario.Click
        Dim Forma As New FrmMantUsuarioDetalle

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuVendedor_Click(sender As System.Object, e As System.EventArgs) Handles MnuVendedor.Click
        Dim Forma As New FrmMantVendedorLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuBanco_Click(sender As System.Object, e As System.EventArgs) Handles MnuBanco.Click
        Dim Forma As New FrmMantBancoLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuTarjeta_Click(sender As System.Object, e As System.EventArgs) Handles MnuTarjeta.Click
        Dim Forma As New FrmMantTarjetaLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuEmpresa_Click(sender As System.Object, e As System.EventArgs) Handles MnuEmpresa.Click
        Dim Forma As New FrmMantEmpresaLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuVentasXFecha_Click(sender As System.Object, e As System.EventArgs) Handles MnuVentasXFecha.Click
        Dim Forma As New FrmRepVentasxFecha

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


    Private Sub MnuVentasxArticulo_Click(sender As System.Object, e As System.EventArgs) Handles MnuVentasxArticulo.Click
        Dim Forma As New FrmRepArticulosPromedioVenta

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnFacturacion_Click(sender As System.Object, e As System.EventArgs) Handles BtnFacturacion.Click
        MnuFacturacion.PerformClick()
    End Sub

    Private Sub BtnConexion_Click(sender As System.Object, e As System.EventArgs) Handles BtnConexion.Click
        MnuConexión.PerformClick()
    End Sub

    Private Sub MnuPreFactura_Click(sender As System.Object, e As System.EventArgs) Handles MnuPreFactura.Click
        Dim Forma As New FrmPuntoVentaRetail

        Try
            VerificaMensaje(CajaInfo.ListKey)
            Forma.Execute(Enum_TipoFacturacion.PreFactura, -1)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuReImprimirCierre_Click(sender As System.Object, e As System.EventArgs) Handles MnuReImprimirCierre.Click
        Dim Forma As New FrmReimpresionCierre

        Try
            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCierreCaja_Click(sender As System.Object, e As System.EventArgs) Handles MnuCierreCaja.Click
        Dim Forma As New FrmCerrarCaja
        Try
            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If RevisaCajaEstado(True) Then
                Forma.Execute()
            Else
                VerificaMensaje("Imposible cerrar la caja, ya que esta no se encuentra abierta")
            End If

            NombreBotonAbreCierreCaja()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuReimpresionDocumentos_Click(sender As System.Object, e As System.EventArgs) Handles MnuReimpresionDocumentos.Click
        Dim Forma As New FrmReimpresionFactura
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuVentasxArticuloFecha_Click(sender As System.Object, e As System.EventArgs) Handles MnuVentasxArticuloFecha.Click
        Dim Forma As New FrmRepArticulosPromedioVentaFecha
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuTipoDeCambio_Click(sender As System.Object, e As System.EventArgs) Handles MnuTipoDeCambio.Click
        Dim Forma As New FrmMantTipoCambio
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuProforma_Click(sender As System.Object, e As System.EventArgs) Handles MnuProforma.Click
        Dim Forma As New FrmPuntoVentaRetail
        Try

            VerificaMensaje(CajaInfo.ListKey)
            Forma.Execute(Enum_TipoFacturacion.Proforma, -1)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnProforma_Click(sender As System.Object, e As System.EventArgs) Handles BtnProforma.Click
        MnuProforma.PerformClick()
    End Sub

    Private Sub BtnPreFactura_Click(sender As System.Object, e As System.EventArgs) Handles BtnPreFactura.Click
        MnuPreFactura.PerformClick()
    End Sub

    Private Sub MnuArticulosPreFacturados_Click(sender As System.Object, e As System.EventArgs) Handles MnuArticulosPreFacturados.Click
        Dim Forma As New FrmRepArticulosPrefacturados
        Try

            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub



    Private Sub MnuConsultaCliente_Click(sender As System.Object, e As System.EventArgs) Handles MnuConsultaCliente.Click
        Dim Forma As New FrmConsultaCliente
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


    Private Sub BtnConsultaCliente_Click(sender As System.Object, e As System.EventArgs) Handles BtnConsultaCliente.Click
        MnuConsultaCliente.PerformClick()
    End Sub

    Private Sub CambiaInterfaz()
        Try
            If InfoMaquina.Interfaz = 2 Then
                Me.BackColor = Color.White
                PanelMain.BackColor = Color.LightSkyBlue
                MainMenuStrip.BackColor = Color.Pink
                StatusBar.BackColor = Color.LightSkyBlue
                BtnSaldosInventario.BackColor = Color.LightSkyBlue
                BtnConsultaCliente.BackColor = Color.LightSkyBlue
                BtnPreFactura.BackColor = Color.LightSkyBlue
                BtnProforma.BackColor = Color.LightSkyBlue
                BtnFacturacion.BackColor = Color.LightSkyBlue
                BtnConexion.BackColor = Color.LightSkyBlue
            End If

            If InfoMaquina.Interfaz = 3 Then
                Me.BackColor = Color.LightSkyBlue
                PanelMain.BackColor = Color.PowderBlue
                MainMenuStrip.BackColor = Color.White
                StatusBar.BackColor = Color.PowderBlue
                BtnSaldosInventario.BackColor = Color.SteelBlue
                BtnConsultaCliente.BackColor = Color.SteelBlue
                BtnPreFactura.BackColor = Color.SteelBlue
                BtnProforma.BackColor = Color.SteelBlue
                BtnFacturacion.BackColor = Color.SteelBlue
                BtnConexion.BackColor = Color.SteelBlue
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MnuReporteCliente_Click(sender As System.Object, e As System.EventArgs) Handles MnuReporteCliente.Click
        Dim Forma As New FrmRepClientes

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuVentasDetallado_Click(sender As System.Object, e As System.EventArgs) Handles MnuVentasDetallado.Click
        Dim Forma As New FrmRepVentasDetallado
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuVentasXTipoPago_Click(sender As System.Object, e As System.EventArgs) Handles MnuVentasXTipoPago.Click
        Dim Forma As New FrmRepVentasxTipoPago
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

    Private Sub MnuVentasXCliente_Click(sender As System.Object, e As System.EventArgs) Handles MnuVentasXCliente.Click
        Dim Forma As New FrmRepClientesMasFacturan

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

    Private Sub MnuVentasXArticulos_Click(sender As Object, e As EventArgs) Handles MnuVentasXArticulos.Click
        Dim Forma As New FrmRptVentasXArticulo

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuEncargoDeMercaderia_Click(sender As Object, e As EventArgs) Handles MnuEncargoDeMercaderia.Click
        Dim Forma As New FrmClienteEncargo

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub


    Private Sub MnuRepEncargosDeMercadería_Click(sender As Object, e As EventArgs) Handles MnuRepEncargosDeMercadería.Click
        Dim Forma As New FrmRepClienteEncargos

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuPreFacturas_Click(sender As Object, e As EventArgs) Handles MnuPreFacturas.Click
        Dim Forma As New FrmProformaConsulta
        Try

            Forma.Tipo = Enum_TipoFacturacion.PreFactura
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

    Private Sub MnuTipoPrecioXCliente_Click(sender As Object, e As EventArgs) Handles MnuTipoPrecioXCliente.Click
        Dim Forma As New FrmClienteTipoPrecio
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCompaDolares_Click(sender As Object, e As EventArgs) Handles MnuCompaDolares.Click
        Dim Forma As New FrmCompaDolares
        Try

            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If RevisaCajaEstado(True) Then
                VerificaMensaje(CajaInfo.ListKey)
                Forma.Execute()
            Else
                VerificaMensaje("Imposible facturar, primero debe de abrir caja")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try


    End Sub

    Private Sub BtnCompraDolares_Click(sender As Object, e As EventArgs) Handles BtnCxC.Click
        MnuPagos.PerformClick()
    End Sub

    Private Sub MnuRepVentasGenerales_Click(sender As Object, e As EventArgs) Handles MnuRepVentasGenerales.Click
        Dim Forma As New FrmRepVentasEmpresa

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuTipoPago_Click(sender As Object, e As EventArgs) Handles MnuTipoPago.Click
        Dim Forma As New FrmMantTipoPagoLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub MnuDescuentosXUsuario_Click(sender As Object, e As EventArgs) Handles MnuDescuentosXUsuario.Click
        Dim Forma As New FrmRepDescuentosXUsuario
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuSalidasDeEfectivo_Click(sender As Object, e As EventArgs) Handles MnuSalidasDeEfectivo.Click
        Dim Forma As New FrmSalidaEfectivo
        Try
            If RevisaCajaEstado(True) Then
                Forma.Execute()
            Else
                VerificaMensaje("Imposible cerrar la caja, ya que esta no se encuentra abierta")
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuReimpresionSalidas_Click(sender As Object, e As EventArgs) Handles MnuReimpresionSalidas.Click
        Dim Forma As New FrmReimpresionSalida
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuBoletaDeServicio_Click(sender As Object, e As EventArgs) Handles MnuBoletaDeServicio.Click
        Dim Forma As New FrmMantBoletaServicioLista
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnBoletaDeServicio_Click(sender As Object, e As EventArgs) Handles BtnBoletaDeServicio.Click
        MnuBoletaDeServicio.PerformClick()
    End Sub

    Private Sub BtnAbreCierraCaja_Click(sender As Object, e As EventArgs) Handles BtnAbreCierraCaja.Click
        If BtnAbreCierraCaja.Text = coCajaCierre Then
            MnuCierreCaja.PerformClick()
        Else
            MnuAbrirCaja.PerformClick()
        End If
    End Sub

    Private Sub MnuTecnico_Click(sender As Object, e As EventArgs) Handles MnuTecnico.Click
        Dim Forma As New FrmMantTecnicoLista
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuArqueoDeCaja_Click(sender As Object, e As EventArgs) Handles MnuArqueoDeCaja.Click
        Dim Forma As New FrmRepArqueoCaja
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub



    Private Sub MnuFacturaElectronica_Click(sender As Object, e As EventArgs) Handles MnuFacturaElectronicaPendiente.Click
        Dim Forma As New FrmFacturaElectronicaPendiente
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    'Private Sub MnuFacturasPendientes_Click(sender As Object, e As EventArgs) Handles MnuFacturasPendientes.Click
    '    Dim Forma As New FrmCxCFacturaPendiente
    '    Try
    '        Forma.Execute()
    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    Finally
    '        Forma = Nothing
    '    End Try
    'End Sub

    Private Sub MnuPagos_Click(sender As Object, e As EventArgs) Handles MnuPagos.Click
        Dim Forma As New FrmCxCPago
        Try

            If Not EmpresaParametroInfo.InterfazCxC Then
                VerificaMensaje("No tiene activada la interfaz de Cuentas x Cobrar")
            End If

            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If RevisaCajaEstado(True) Then
                VerificaMensaje(CajaInfo.ListKey)
                Forma.Execute()
            Else
                VerificaMensaje("Imposible facturar, primero debe de abrir caja")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuAnulaPagos_Click(sender As Object, e As EventArgs) Handles MnuAnulaPagos.Click
        Dim Forma As New FrmCxCAnulaPago
        Try

            If Not EmpresaParametroInfo.InterfazCxC Then
                VerificaMensaje("No tiene activada la interfaz de Cuentas x Cobrar")
            End If

            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If RevisaCajaEstado(True) Then
                VerificaMensaje(CajaInfo.ListKey)
                Forma.Execute()
            Else
                VerificaMensaje("Imposible facturar, primero debe de abrir caja")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuConsultaDocumentoElectronico_Click(sender As Object, e As EventArgs)
        Dim Forma As New FrmConsultaDocumentoElectronico
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuProformaBusqueda_Click(sender As Object, e As EventArgs)

        Dim Forma As New FrmBusquedaProforma
        Try

            'If LvwDetalle.Items.Count > 0 Then
            '    VerificaMensaje("Antes de cargar un documento debe de finalizar el actual")
            'End If

            Forma.Tipo = Enum_TipoFacturacion.Proforma
            Forma.TipoDoc_Id = -1
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try

    End Sub

    Private Sub VentasXHoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasXHoraToolStripMenuItem.Click
        Dim Forma As New FrmRptVentasxHora
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub ComisiónXVendedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComisiónXVendedorToolStripMenuItem.Click
        Dim Forma As New FrmRepComisionxVendedor
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub ReposicionInventario_Click(sender As Object, e As EventArgs) Handles ReposicionInventario.Click
        Dim Forma As New FrmRepReposicionInventario
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuVentasXHoraXCategoría_Click(sender As Object, e As EventArgs) Handles MnuVentasXHoraXCategoría.Click
        Dim Forma As New FrmRepVentasXHoraXCategoria
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuRepCorteVentasXCajero_Click(sender As Object, e As EventArgs) Handles MnuRepCorteVentasXCajero.Click
        Dim Forma As New FrmRepCorteVentasCajero
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCorteVentasXCajero_Click(sender As Object, e As EventArgs) Handles MnuCorteVentasXCajero.Click
        Dim Forma As New FrmCorteVentasxCajero
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuGeneracionAsientosContables_Click(sender As Object, e As EventArgs) Handles MnuGeneracionAsientosContables.Click
        Dim Forma As New FrmRepAsientosCierreSD
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuRecepcionDocumentoElectronicos_Click(sender As Object, e As EventArgs) Handles MnuRecepcionDocumentoElectronicos.Click
        Try

            System.Diagnostics.Process.Start("http://www.facturar.cr")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MnuVentasPorArtículoPorSucursal_Click(sender As Object, e As EventArgs) Handles MnuVentasPorArtículoPorSucursal.Click
        Dim Forma As New FrmRepVentaArticuloXFechaXSucursal
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCierreDeCaja_Click(sender As Object, e As EventArgs) Handles MnuCierreDeCaja.Click
        Dim Forma As New FrmRepCierreCaja
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub EnvioPricesmartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvioPricesmartToolStripMenuItem.Click
        Dim Forma As New FrmEnvioPricesmart
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub



    Private Sub MnuVentasExentasGravadas_Click(sender As Object, e As EventArgs) Handles MnuVentasExentasGravadas.Click
        Dim Forma As New FrmRepVentasExentasGravadas
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuApartadoNuevo_Click(sender As Object, e As EventArgs) Handles MnuApartadoNuevo.Click
        Dim Forma As New FrmPuntoVentaRetail

        Try
            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If SucursalParametroInfo.BodegaApartado_Id <= 0 Then
                VerificaMensaje("No se encontró definida una bodega de apartados")
            End If

            If RevisaCajaEstado(True) Then
                VerificaMensaje(CajaInfo.ListKey)
                Forma.Execute(Enum_TipoFacturacion.Apartado, -1)
            Else
                VerificaMensaje("Imposible crear apartados, primero debe de abrir caja")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuApartadoAbono_Click(sender As Object, e As EventArgs) Handles MnuApartadoAbono.Click
        Dim Forma As New FrmBusquedaApartado
        Try
            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If SucursalParametroInfo.BodegaApartado_Id <= 0 Then
                VerificaMensaje("No se encontró definida una bodega de apartados")
            End If

            If RevisaCajaEstado(True) Then
                VerificaMensaje(CajaInfo.ListKey)
                Forma.Execute()
            Else
                VerificaMensaje("Imposible crear apartados, primero debe de abrir caja")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try

    End Sub

    Private Sub BtnApartadoNuevo_Click(sender As Object, e As EventArgs) Handles BtnApartadoNuevo.Click
        Try
            MnuApartadoNuevo.PerformClick()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnApartadoAbono_Click(sender As Object, e As EventArgs) Handles BtnApartadoAbono.Click
        Try
            MnuApartadoAbono.PerformClick()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub SucursalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SucursalToolStripMenuItem.Click
        Dim Forma As New FrmMantListaSucursal
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub ApartadosPendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApartadosPendientesToolStripMenuItem.Click
        Dim Forma As New FrmApartadosPendientes
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub UtilidadXFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UtilidadXFacturaToolStripMenuItem.Click
        Dim Forma As New FrmRepUtilidadxFactura
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub FrmFacturasPendientesCxC_Click(sender As Object, e As EventArgs) Handles FrmFacturasPendientesCxC.Click
        Dim Forma As New FrmCxCFacturaPendiente

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub AdministrarCajasMnu_Click(sender As Object, e As EventArgs) Handles AdministrarCajasMnu.Click
        Dim Forma As New FrmAdministracionCajas

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuSaldosInventario_Click(sender As Object, e As EventArgs) Handles MnuSaldosInventario.Click
        Dim Forma As New FrmConsultaArticulo
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnReimpresionDocumentos_Click(sender As Object, e As EventArgs) Handles BtnReimpresionDocumentos.Click
        MnuReimpresionDocumentos.PerformClick()
    End Sub

    Private Sub MnuCostoDeVentaXFactura_Click(sender As Object, e As EventArgs) Handles MnuCostoDeVentaXFactura.Click
        Dim Forma As New FrmRepCostoVentaxFactura
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnSaldosInventario_Click(sender As Object, e As EventArgs) Handles BtnSaldosInventario.Click
        MnuSaldosInventario.PerformClick()
    End Sub

    Private Sub MnuEntradaEfectivo_Click(sender As Object, e As EventArgs) Handles MnuEntradaEfectivo.Click
        Dim Forma As New FrmEntradaEfectivo
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuFacturaElectrónicaEstado_Click(sender As Object, e As EventArgs) Handles MnuFacturaElectrónicaEstado.Click
        Dim Forma As New FrmRepEstadoFacturas
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MovimientosPorUsuarioYCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosPorUsuarioYCajaToolStripMenuItem.Click
        Dim Forma As New FrmRepMovUsuarioCaja
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub EntradaDeEfectivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntradaDeEfectivoToolStripMenuItem.Click
        Dim Forma As New FrmRepEntradaEfectivo
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuVentasXClienteDetallado_Click(sender As Object, e As EventArgs) Handles MnuVentasXClienteDetallado.Click
        Dim Forma As New FrmRepVentasxCliente
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuCierreCajaDetallado_Click(sender As Object, e As EventArgs) Handles MnuCierreCajaDetallado.Click
        Dim Forma As New FrmRepCierreCajaDetallado
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub MnuImpresionApartado_Click(sender As Object, e As EventArgs) Handles MnuImpresionApartado.Click
        Dim Forma As New FrmReimpresionAbono
        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub MnuImpresionAbono_Click(sender As Object, e As EventArgs) Handles MnuImpresionAbono.Click
        Dim Forma As New FrmBusquedaAbono
        Try
            If CajaInfo.PreFacturas Then
                VerificaMensaje("Opcion no disponible en prefacturas")
            End If

            If SucursalParametroInfo.BodegaApartado_Id <= 0 Then
                VerificaMensaje("No se encontró definida una bodega de apartados")
            End If

            If RevisaCajaEstado(True) Then
                VerificaMensaje(CajaInfo.ListKey)
                Forma.Execute()
            Else
                VerificaMensaje("Imposible crear apartados, primero debe de abrir caja")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
End Class