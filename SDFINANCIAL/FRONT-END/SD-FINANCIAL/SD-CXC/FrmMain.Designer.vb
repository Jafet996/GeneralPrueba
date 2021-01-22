<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.MenuStripPrincipal = New System.Windows.Forms.MenuStrip()
        Me.MnuCatalogos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEmpresa = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBanco = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTarjeta = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTipoCambio = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSeguridad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGrupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGenerarToken = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAperturaCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCierreCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConexión = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProcesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMovimientos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCompraDolares = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDevolucionDolares = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAsignarDocumentosAVendedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjusteDeFacturasMnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDescargueConsumo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPagoRapido = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDocumentosProximosVencer = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFacturaPendiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEstadoCuentaCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMovimientosCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.CobrosPorPeriodoMnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComisionesPorVendedorMnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDocumentosVencidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMovimientosGenerales = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRptDescargueConsumo = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.TSSCompaniaLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSCompania = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSUsuarioLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSPeriodoLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSPeriodo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSCajaLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSCaja = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.BtnPAgoRapido = New System.Windows.Forms.Panel()
        Me.BtmPagoRapido = New System.Windows.Forms.Button()
        Me.BtnMovimientos = New System.Windows.Forms.Button()
        Me.BtnConexion = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblEmpresaNombre = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.MenuStripPrincipal.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.BtnPAgoRapido.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStripPrincipal
        '
        Me.MenuStripPrincipal.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStripPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCatalogos, Me.MnuCaja, Me.MnuProcesos, Me.MnuReportes, Me.MnuSistema})
        Me.MenuStripPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripPrincipal.Name = "MenuStripPrincipal"
        Me.MenuStripPrincipal.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStripPrincipal.Size = New System.Drawing.Size(1436, 28)
        Me.MenuStripPrincipal.TabIndex = 0
        Me.MenuStripPrincipal.Text = "MenuStrip1"
        '
        'MnuCatalogos
        '
        Me.MnuCatalogos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEmpresa, Me.MnuBanco, Me.MnuCliente, Me.MnuTarjeta, Me.MnuTipoCambio, Me.MnuSeguridad})
        Me.MnuCatalogos.Name = "MnuCatalogos"
        Me.MnuCatalogos.Size = New System.Drawing.Size(88, 24)
        Me.MnuCatalogos.Text = "Catálogos"
        Me.MnuCatalogos.Visible = False
        '
        'MnuEmpresa
        '
        Me.MnuEmpresa.Name = "MnuEmpresa"
        Me.MnuEmpresa.Size = New System.Drawing.Size(170, 26)
        Me.MnuEmpresa.Text = "Empresa"
        '
        'MnuBanco
        '
        Me.MnuBanco.Name = "MnuBanco"
        Me.MnuBanco.Size = New System.Drawing.Size(170, 26)
        Me.MnuBanco.Text = "Banco"
        '
        'MnuCliente
        '
        Me.MnuCliente.Name = "MnuCliente"
        Me.MnuCliente.Size = New System.Drawing.Size(170, 26)
        Me.MnuCliente.Text = "Cliente"
        '
        'MnuTarjeta
        '
        Me.MnuTarjeta.Name = "MnuTarjeta"
        Me.MnuTarjeta.Size = New System.Drawing.Size(170, 26)
        Me.MnuTarjeta.Text = "Tarjeta"
        '
        'MnuTipoCambio
        '
        Me.MnuTipoCambio.Name = "MnuTipoCambio"
        Me.MnuTipoCambio.Size = New System.Drawing.Size(170, 26)
        Me.MnuTipoCambio.Text = "Tipo Cambio"
        '
        'MnuSeguridad
        '
        Me.MnuSeguridad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuUsuario, Me.MnuGrupo, Me.MnuGenerarToken})
        Me.MnuSeguridad.Name = "MnuSeguridad"
        Me.MnuSeguridad.Size = New System.Drawing.Size(170, 26)
        Me.MnuSeguridad.Text = "Seguridad"
        '
        'MnuUsuario
        '
        Me.MnuUsuario.Name = "MnuUsuario"
        Me.MnuUsuario.Size = New System.Drawing.Size(179, 26)
        Me.MnuUsuario.Text = "Usuario"
        '
        'MnuGrupo
        '
        Me.MnuGrupo.Name = "MnuGrupo"
        Me.MnuGrupo.Size = New System.Drawing.Size(179, 26)
        Me.MnuGrupo.Text = "Grupo"
        '
        'MnuGenerarToken
        '
        Me.MnuGenerarToken.Name = "MnuGenerarToken"
        Me.MnuGenerarToken.Size = New System.Drawing.Size(179, 26)
        Me.MnuGenerarToken.Text = "Generar Token"
        '
        'MnuCaja
        '
        Me.MnuCaja.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAperturaCaja, Me.MnuCierreCaja})
        Me.MnuCaja.Name = "MnuCaja"
        Me.MnuCaja.Size = New System.Drawing.Size(50, 24)
        Me.MnuCaja.Text = "Caja"
        Me.MnuCaja.Visible = False
        '
        'MnuAperturaCaja
        '
        Me.MnuAperturaCaja.Name = "MnuAperturaCaja"
        Me.MnuAperturaCaja.Size = New System.Drawing.Size(142, 26)
        Me.MnuAperturaCaja.Text = "Apertura"
        '
        'MnuCierreCaja
        '
        Me.MnuCierreCaja.Name = "MnuCierreCaja"
        Me.MnuCierreCaja.Size = New System.Drawing.Size(142, 26)
        Me.MnuCierreCaja.Text = "Cierre"
        '
        'MnuSistema
        '
        Me.MnuSistema.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAcercaDe, Me.MnuConexión, Me.MnuSalir})
        Me.MnuSistema.Name = "MnuSistema"
        Me.MnuSistema.Size = New System.Drawing.Size(73, 24)
        Me.MnuSistema.Text = "Sistema"
        '
        'MnuAcercaDe
        '
        Me.MnuAcercaDe.Name = "MnuAcercaDe"
        Me.MnuAcercaDe.Size = New System.Drawing.Size(216, 26)
        Me.MnuAcercaDe.Text = "Acerca De"
        '
        'MnuConexión
        '
        Me.MnuConexión.Name = "MnuConexión"
        Me.MnuConexión.Size = New System.Drawing.Size(216, 26)
        Me.MnuConexión.Text = "Conexión"
        '
        'MnuSalir
        '
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Size = New System.Drawing.Size(216, 26)
        Me.MnuSalir.Text = "Salir"
        '
        'MnuProcesos
        '
        Me.MnuProcesos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMovimientos, Me.MnuCompraDolares, Me.MnuDevolucionDolares, Me.MnuAsignarDocumentosAVendedores, Me.AjusteDeFacturasMnu, Me.MnuDescargueConsumo, Me.MnuPagoRapido})
        Me.MnuProcesos.Name = "MnuProcesos"
        Me.MnuProcesos.Size = New System.Drawing.Size(79, 24)
        Me.MnuProcesos.Text = "Procesos"
        Me.MnuProcesos.Visible = False
        '
        'MnuMovimientos
        '
        Me.MnuMovimientos.Name = "MnuMovimientos"
        Me.MnuMovimientos.Size = New System.Drawing.Size(313, 26)
        Me.MnuMovimientos.Text = "Movimientos"
        '
        'MnuCompraDolares
        '
        Me.MnuCompraDolares.Name = "MnuCompraDolares"
        Me.MnuCompraDolares.Size = New System.Drawing.Size(313, 26)
        Me.MnuCompraDolares.Text = "Compra Dólares"
        '
        'MnuDevolucionDolares
        '
        Me.MnuDevolucionDolares.Name = "MnuDevolucionDolares"
        Me.MnuDevolucionDolares.Size = New System.Drawing.Size(313, 26)
        Me.MnuDevolucionDolares.Text = "Devolución Dólares"
        '
        'MnuAsignarDocumentosAVendedores
        '
        Me.MnuAsignarDocumentosAVendedores.Name = "MnuAsignarDocumentosAVendedores"
        Me.MnuAsignarDocumentosAVendedores.Size = New System.Drawing.Size(313, 26)
        Me.MnuAsignarDocumentosAVendedores.Text = "Asignar documentos a vendedores"
        '
        'AjusteDeFacturasMnu
        '
        Me.AjusteDeFacturasMnu.Name = "AjusteDeFacturasMnu"
        Me.AjusteDeFacturasMnu.Size = New System.Drawing.Size(313, 26)
        Me.AjusteDeFacturasMnu.Text = "Ajuste de facturas"
        '
        'MnuDescargueConsumo
        '
        Me.MnuDescargueConsumo.Name = "MnuDescargueConsumo"
        Me.MnuDescargueConsumo.Size = New System.Drawing.Size(313, 26)
        Me.MnuDescargueConsumo.Text = "Descargue Consumo  Interno"
        '
        'MnuPagoRapido
        '
        Me.MnuPagoRapido.Name = "MnuPagoRapido"
        Me.MnuPagoRapido.Size = New System.Drawing.Size(313, 26)
        Me.MnuPagoRapido.Text = "Pago Rápido"
        '
        'MnuReportes
        '
        Me.MnuReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDocumentosProximosVencer, Me.MnuFacturaPendiente, Me.MnuEstadoCuentaCliente, Me.MnuMovimientosCliente, Me.CobrosPorPeriodoMnu, Me.ComisionesPorVendedorMnu, Me.MnuDocumentosVencidos, Me.MnuMovimientosGenerales, Me.MnuRptDescargueConsumo})
        Me.MnuReportes.Name = "MnuReportes"
        Me.MnuReportes.Size = New System.Drawing.Size(80, 24)
        Me.MnuReportes.Text = "Reportes"
        Me.MnuReportes.Visible = False
        '
        'MnuDocumentosProximosVencer
        '
        Me.MnuDocumentosProximosVencer.Name = "MnuDocumentosProximosVencer"
        Me.MnuDocumentosProximosVencer.Size = New System.Drawing.Size(293, 26)
        Me.MnuDocumentosProximosVencer.Text = "Documentos Próximos a Vencer"
        '
        'MnuFacturaPendiente
        '
        Me.MnuFacturaPendiente.Name = "MnuFacturaPendiente"
        Me.MnuFacturaPendiente.Size = New System.Drawing.Size(293, 26)
        Me.MnuFacturaPendiente.Text = "Factura Pendiente "
        '
        'MnuEstadoCuentaCliente
        '
        Me.MnuEstadoCuentaCliente.Name = "MnuEstadoCuentaCliente"
        Me.MnuEstadoCuentaCliente.Size = New System.Drawing.Size(293, 26)
        Me.MnuEstadoCuentaCliente.Text = "Estado Cuenta Cliente"
        '
        'MnuMovimientosCliente
        '
        Me.MnuMovimientosCliente.Name = "MnuMovimientosCliente"
        Me.MnuMovimientosCliente.Size = New System.Drawing.Size(293, 26)
        Me.MnuMovimientosCliente.Text = "Movimientos Cliente"
        '
        'CobrosPorPeriodoMnu
        '
        Me.CobrosPorPeriodoMnu.Name = "CobrosPorPeriodoMnu"
        Me.CobrosPorPeriodoMnu.Size = New System.Drawing.Size(293, 26)
        Me.CobrosPorPeriodoMnu.Text = "Cobros por Fechas"
        '
        'ComisionesPorVendedorMnu
        '
        Me.ComisionesPorVendedorMnu.Name = "ComisionesPorVendedorMnu"
        Me.ComisionesPorVendedorMnu.Size = New System.Drawing.Size(293, 26)
        Me.ComisionesPorVendedorMnu.Text = "Comisiones por vendedor"
        '
        'MnuDocumentosVencidos
        '
        Me.MnuDocumentosVencidos.Name = "MnuDocumentosVencidos"
        Me.MnuDocumentosVencidos.Size = New System.Drawing.Size(293, 26)
        Me.MnuDocumentosVencidos.Text = "Documentos Vencidos"
        '
        'MnuMovimientosGenerales
        '
        Me.MnuMovimientosGenerales.Name = "MnuMovimientosGenerales"
        Me.MnuMovimientosGenerales.Size = New System.Drawing.Size(293, 26)
        Me.MnuMovimientosGenerales.Text = "Movimientos Generales"
        '
        'MnuRptDescargueConsumo
        '
        Me.MnuRptDescargueConsumo.Name = "MnuRptDescargueConsumo"
        Me.MnuRptDescargueConsumo.Size = New System.Drawing.Size(293, 26)
        Me.MnuRptDescargueConsumo.Text = "Descargue Consumo"
        '
        'StatusBar
        '
        Me.StatusBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSCompaniaLabel, Me.TSSCompania, Me.TSSUsuarioLabel, Me.TSSUsuario, Me.TSSPeriodoLabel, Me.TSSPeriodo, Me.TSSCajaLabel, Me.TSSCaja})
        Me.StatusBar.Location = New System.Drawing.Point(0, 688)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusBar.Size = New System.Drawing.Size(1436, 25)
        Me.StatusBar.TabIndex = 1
        Me.StatusBar.Text = "StatusStrip1"
        '
        'TSSCompaniaLabel
        '
        Me.TSSCompaniaLabel.Image = Global.SDCXC.My.Resources.Resources.Company_Building
        Me.TSSCompaniaLabel.Name = "TSSCompaniaLabel"
        Me.TSSCompaniaLabel.Size = New System.Drawing.Size(97, 20)
        Me.TSSCompaniaLabel.Text = "Compañía"
        '
        'TSSCompania
        '
        Me.TSSCompania.AutoSize = False
        Me.TSSCompania.Name = "TSSCompania"
        Me.TSSCompania.Size = New System.Drawing.Size(200, 20)
        Me.TSSCompania.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSSUsuarioLabel
        '
        Me.TSSUsuarioLabel.Image = Global.SDCXC.My.Resources.Resources.user1
        Me.TSSUsuarioLabel.Name = "TSSUsuarioLabel"
        Me.TSSUsuarioLabel.Size = New System.Drawing.Size(79, 20)
        Me.TSSUsuarioLabel.Text = "Usuario"
        '
        'TSSUsuario
        '
        Me.TSSUsuario.AutoSize = False
        Me.TSSUsuario.Name = "TSSUsuario"
        Me.TSSUsuario.Size = New System.Drawing.Size(200, 20)
        Me.TSSUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSSPeriodoLabel
        '
        Me.TSSPeriodoLabel.Image = Global.SDCXC.My.Resources.Resources.calendar
        Me.TSSPeriodoLabel.Name = "TSSPeriodoLabel"
        Me.TSSPeriodoLabel.Size = New System.Drawing.Size(80, 20)
        Me.TSSPeriodoLabel.Text = "Periodo"
        '
        'TSSPeriodo
        '
        Me.TSSPeriodo.AutoSize = False
        Me.TSSPeriodo.Name = "TSSPeriodo"
        Me.TSSPeriodo.Size = New System.Drawing.Size(200, 20)
        Me.TSSPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSSCajaLabel
        '
        Me.TSSCajaLabel.Image = Global.SDCXC.My.Resources.Resources.cashier
        Me.TSSCajaLabel.Name = "TSSCajaLabel"
        Me.TSSCajaLabel.Size = New System.Drawing.Size(58, 20)
        Me.TSSCajaLabel.Text = "Caja"
        '
        'TSSCaja
        '
        Me.TSSCaja.AutoSize = False
        Me.TSSCaja.Name = "TSSCaja"
        Me.TSSCaja.Size = New System.Drawing.Size(200, 20)
        Me.TSSCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelMain.Controls.Add(Me.BtnPAgoRapido)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.LblEmpresaNombre)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMain.Location = New System.Drawing.Point(0, 28)
        Me.PanelMain.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1436, 90)
        Me.PanelMain.TabIndex = 2
        '
        'BtnPAgoRapido
        '
        Me.BtnPAgoRapido.Controls.Add(Me.BtmPagoRapido)
        Me.BtnPAgoRapido.Controls.Add(Me.BtnMovimientos)
        Me.BtnPAgoRapido.Controls.Add(Me.BtnConexion)
        Me.BtnPAgoRapido.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPAgoRapido.Location = New System.Drawing.Point(1115, 0)
        Me.BtnPAgoRapido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPAgoRapido.Name = "BtnPAgoRapido"
        Me.BtnPAgoRapido.Size = New System.Drawing.Size(317, 86)
        Me.BtnPAgoRapido.TabIndex = 14
        '
        'BtmPagoRapido
        '
        Me.BtmPagoRapido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtmPagoRapido.BackColor = System.Drawing.Color.SteelBlue
        Me.BtmPagoRapido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtmPagoRapido.ForeColor = System.Drawing.Color.White
        Me.BtmPagoRapido.Image = Global.SDCXC.My.Resources.Resources.money
        Me.BtmPagoRapido.Location = New System.Drawing.Point(23, 4)
        Me.BtmPagoRapido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtmPagoRapido.Name = "BtmPagoRapido"
        Me.BtmPagoRapido.Size = New System.Drawing.Size(96, 79)
        Me.BtmPagoRapido.TabIndex = 4
        Me.BtmPagoRapido.Text = "Pago"
        Me.BtmPagoRapido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtmPagoRapido.UseVisualStyleBackColor = False
        '
        'BtnMovimientos
        '
        Me.BtnMovimientos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMovimientos.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnMovimientos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMovimientos.ForeColor = System.Drawing.Color.White
        Me.BtnMovimientos.Image = Global.SDCXC.My.Resources.Resources.money_envelope
        Me.BtnMovimientos.Location = New System.Drawing.Point(117, 4)
        Me.BtnMovimientos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnMovimientos.Name = "BtnMovimientos"
        Me.BtnMovimientos.Size = New System.Drawing.Size(96, 79)
        Me.BtnMovimientos.TabIndex = 3
        Me.BtnMovimientos.Text = "Saldo CxC"
        Me.BtnMovimientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnMovimientos.UseVisualStyleBackColor = False
        '
        'BtnConexion
        '
        Me.BtnConexion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConexion.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnConexion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConexion.ForeColor = System.Drawing.Color.White
        Me.BtnConexion.Image = Global.SDCXC.My.Resources.Resources.server_client_exchange
        Me.BtnConexion.Location = New System.Drawing.Point(211, 4)
        Me.BtnConexion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnConexion.Name = "BtnConexion"
        Me.BtnConexion.Size = New System.Drawing.Size(96, 79)
        Me.BtnConexion.TabIndex = 2
        Me.BtnConexion.Text = "Conexión"
        Me.BtnConexion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnConexion.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 42)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "SD-CXC"
        '
        'LblEmpresaNombre
        '
        Me.LblEmpresaNombre.AutoSize = True
        Me.LblEmpresaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmpresaNombre.ForeColor = System.Drawing.Color.White
        Me.LblEmpresaNombre.Location = New System.Drawing.Point(211, 25)
        Me.LblEmpresaNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEmpresaNombre.Name = "LblEmpresaNombre"
        Me.LblEmpresaNombre.Size = New System.Drawing.Size(0, 36)
        Me.LblEmpresaNombre.TabIndex = 7
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.SDCXC.My.Resources.Resources.LOGO_SB_CR_web_01
        Me.PictureBox2.Location = New System.Drawing.Point(1268, 549)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(161, 130)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(1437, 553)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(161, 130)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'PicLogo
        '
        Me.PicLogo.Location = New System.Drawing.Point(16, 128)
        Me.PicLogo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(685, 530)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 10
        Me.PicLogo.TabStop = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1436, 713)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PicLogo)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.MenuStripPrincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStripPrincipal
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStripPrincipal.ResumeLayout(False)
        Me.MenuStripPrincipal.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.BtnPAgoRapido.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStripPrincipal As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuProcesos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSistema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuConexión As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents TSSCompaniaLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSCompania As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents LblEmpresaNombre As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TSSUsuarioLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MnuCatalogos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSeguridad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGrupo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnPAgoRapido As System.Windows.Forms.Panel
    Friend WithEvents BtnConexion As System.Windows.Forms.Button
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MnuAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEmpresa As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGenerarToken As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTipoCambio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSPeriodoLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSPeriodo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents MnuMovimientos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSCajaLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSCaja As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MnuCaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAperturaCaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCierreCaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnMovimientos As System.Windows.Forms.Button
    Friend WithEvents MnuDocumentosProximosVencer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCompraDolares As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDevolucionDolares As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBanco As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTarjeta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuFacturaPendiente As ToolStripMenuItem
    Friend WithEvents MnuEstadoCuentaCliente As ToolStripMenuItem
    Friend WithEvents MnuMovimientosCliente As ToolStripMenuItem
    Friend WithEvents CobrosPorPeriodoMnu As ToolStripMenuItem
    Friend WithEvents MnuAsignarDocumentosAVendedores As ToolStripMenuItem
    Friend WithEvents ComisionesPorVendedorMnu As ToolStripMenuItem
    Friend WithEvents AjusteDeFacturasMnu As ToolStripMenuItem
    Friend WithEvents MnuDocumentosVencidos As ToolStripMenuItem
    Friend WithEvents MnuMovimientosGenerales As ToolStripMenuItem
    Friend WithEvents MnuDescargueConsumo As ToolStripMenuItem
    Friend WithEvents MnuRptDescargueConsumo As ToolStripMenuItem
    Friend WithEvents MnuPagoRapido As ToolStripMenuItem
    Friend WithEvents BtmPagoRapido As Button
End Class
