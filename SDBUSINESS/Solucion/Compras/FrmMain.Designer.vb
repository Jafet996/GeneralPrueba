<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.MenuStripPrincipal = New System.Windows.Forms.MenuStrip()
        Me.MnuCatalogos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSeguridad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGrupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuArticulo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProveedoresxArticulo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEmailRecepcionFacturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProcesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOrdenCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEntradaDeMercaderia = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRecepcionDeMercaderia = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEtiquetasCodigoBarra = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConsultaArtículos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntadasXUnidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuComprasPorFecha = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuComprasPorProveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuComprasPorFechaDetallado = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConexión = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.TSSCompaniaLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSCompania = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSSucursalLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSSucursal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSUsuarioLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.PnlShortCuts = New System.Windows.Forms.Panel()
        Me.BtnRecepcionDeMercaderia = New System.Windows.Forms.Button()
        Me.BtnArticulo = New System.Windows.Forms.Button()
        Me.BtnOrdenCompra = New System.Windows.Forms.Button()
        Me.BtnEntradaDeMercaderia = New System.Windows.Forms.Button()
        Me.BtnConsultaArticulos = New System.Windows.Forms.Button()
        Me.BtnConexion = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblEmpresaNombre = New System.Windows.Forms.Label()
        Me.PicFacturacionElectronica = New System.Windows.Forms.PictureBox()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.MenuStripPrincipal.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.PnlShortCuts.SuspendLayout()
        CType(Me.PicFacturacionElectronica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStripPrincipal
        '
        Me.MenuStripPrincipal.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStripPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCatalogos, Me.MnuProcesos, Me.MnuConsultas, Me.MnuReportes, Me.MnuSistema})
        Me.MenuStripPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripPrincipal.Name = "MenuStripPrincipal"
        Me.MenuStripPrincipal.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStripPrincipal.Size = New System.Drawing.Size(1613, 28)
        Me.MenuStripPrincipal.TabIndex = 0
        Me.MenuStripPrincipal.Text = "MenuStrip1"
        '
        'MnuCatalogos
        '
        Me.MnuCatalogos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuProveedor, Me.MnuSeguridad, Me.MnuArticulo, Me.MnuProveedoresxArticulo, Me.MnuEmailRecepcionFacturas})
        Me.MnuCatalogos.Name = "MnuCatalogos"
        Me.MnuCatalogos.Size = New System.Drawing.Size(88, 24)
        Me.MnuCatalogos.Text = "Catálogos"
        Me.MnuCatalogos.Visible = False
        '
        'MnuProveedor
        '
        Me.MnuProveedor.Name = "MnuProveedor"
        Me.MnuProveedor.Size = New System.Drawing.Size(251, 26)
        Me.MnuProveedor.Text = "Proveedor"
        '
        'MnuSeguridad
        '
        Me.MnuSeguridad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuUsuario, Me.MnuGrupo})
        Me.MnuSeguridad.Name = "MnuSeguridad"
        Me.MnuSeguridad.Size = New System.Drawing.Size(251, 26)
        Me.MnuSeguridad.Text = "Seguridad"
        '
        'MnuUsuario
        '
        Me.MnuUsuario.Name = "MnuUsuario"
        Me.MnuUsuario.Size = New System.Drawing.Size(134, 26)
        Me.MnuUsuario.Text = "Usuario"
        '
        'MnuGrupo
        '
        Me.MnuGrupo.Name = "MnuGrupo"
        Me.MnuGrupo.Size = New System.Drawing.Size(134, 26)
        Me.MnuGrupo.Text = "Grupo"
        '
        'MnuArticulo
        '
        Me.MnuArticulo.Name = "MnuArticulo"
        Me.MnuArticulo.Size = New System.Drawing.Size(251, 26)
        Me.MnuArticulo.Text = "Artículo"
        '
        'MnuProveedoresxArticulo
        '
        Me.MnuProveedoresxArticulo.Name = "MnuProveedoresxArticulo"
        Me.MnuProveedoresxArticulo.Size = New System.Drawing.Size(251, 26)
        Me.MnuProveedoresxArticulo.Text = "Proveedores x Artículo"
        '
        'MnuEmailRecepcionFacturas
        '
        Me.MnuEmailRecepcionFacturas.Name = "MnuEmailRecepcionFacturas"
        Me.MnuEmailRecepcionFacturas.Size = New System.Drawing.Size(251, 26)
        Me.MnuEmailRecepcionFacturas.Text = "Email Recepción Facturas"
        '
        'MnuProcesos
        '
        Me.MnuProcesos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuOrdenCompra, Me.MnuEntradaDeMercaderia, Me.MnuRecepcionDeMercaderia, Me.MnuEtiquetasCodigoBarra})
        Me.MnuProcesos.Name = "MnuProcesos"
        Me.MnuProcesos.Size = New System.Drawing.Size(79, 24)
        Me.MnuProcesos.Text = "Procesos"
        Me.MnuProcesos.Visible = False
        '
        'MnuOrdenCompra
        '
        Me.MnuOrdenCompra.Name = "MnuOrdenCompra"
        Me.MnuOrdenCompra.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MnuOrdenCompra.Size = New System.Drawing.Size(285, 26)
        Me.MnuOrdenCompra.Text = "Orden de Compra"
        '
        'MnuEntradaDeMercaderia
        '
        Me.MnuEntradaDeMercaderia.Name = "MnuEntradaDeMercaderia"
        Me.MnuEntradaDeMercaderia.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.MnuEntradaDeMercaderia.Size = New System.Drawing.Size(285, 26)
        Me.MnuEntradaDeMercaderia.Text = "Entrada de Mercaderia"
        '
        'MnuRecepcionDeMercaderia
        '
        Me.MnuRecepcionDeMercaderia.Name = "MnuRecepcionDeMercaderia"
        Me.MnuRecepcionDeMercaderia.Size = New System.Drawing.Size(285, 26)
        Me.MnuRecepcionDeMercaderia.Text = "Recepción de Mercadería"
        '
        'MnuEtiquetasCodigoBarra
        '
        Me.MnuEtiquetasCodigoBarra.Name = "MnuEtiquetasCodigoBarra"
        Me.MnuEtiquetasCodigoBarra.Size = New System.Drawing.Size(285, 26)
        Me.MnuEtiquetasCodigoBarra.Text = "Etiquetas Código Barra"
        '
        'MnuConsultas
        '
        Me.MnuConsultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuConsultaArtículos})
        Me.MnuConsultas.Name = "MnuConsultas"
        Me.MnuConsultas.Size = New System.Drawing.Size(84, 24)
        Me.MnuConsultas.Text = "Consultas"
        Me.MnuConsultas.Visible = False
        '
        'MnuConsultaArtículos
        '
        Me.MnuConsultaArtículos.Name = "MnuConsultaArtículos"
        Me.MnuConsultaArtículos.Size = New System.Drawing.Size(224, 26)
        Me.MnuConsultaArtículos.Text = "Consulta de Artículos"
        '
        'MnuReportes
        '
        Me.MnuReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntadasXUnidadesToolStripMenuItem, Me.MnuComprasPorFecha, Me.MnuComprasPorProveedor, Me.MnuComprasPorFechaDetallado})
        Me.MnuReportes.Name = "MnuReportes"
        Me.MnuReportes.Size = New System.Drawing.Size(80, 24)
        Me.MnuReportes.Text = "Reportes"
        Me.MnuReportes.Visible = False
        '
        'EntadasXUnidadesToolStripMenuItem
        '
        Me.EntadasXUnidadesToolStripMenuItem.Name = "EntadasXUnidadesToolStripMenuItem"
        Me.EntadasXUnidadesToolStripMenuItem.Size = New System.Drawing.Size(282, 26)
        Me.EntadasXUnidadesToolStripMenuItem.Text = "Entradas x Unidades"
        '
        'MnuComprasPorFecha
        '
        Me.MnuComprasPorFecha.Name = "MnuComprasPorFecha"
        Me.MnuComprasPorFecha.Size = New System.Drawing.Size(282, 26)
        Me.MnuComprasPorFecha.Text = "Compras por Fecha"
        '
        'MnuComprasPorProveedor
        '
        Me.MnuComprasPorProveedor.Name = "MnuComprasPorProveedor"
        Me.MnuComprasPorProveedor.Size = New System.Drawing.Size(282, 26)
        Me.MnuComprasPorProveedor.Text = "Compras por Proveedor"
        '
        'MnuComprasPorFechaDetallado
        '
        Me.MnuComprasPorFechaDetallado.Name = "MnuComprasPorFechaDetallado"
        Me.MnuComprasPorFechaDetallado.Size = New System.Drawing.Size(282, 26)
        Me.MnuComprasPorFechaDetallado.Text = "Compras por Fecha Detallado"
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
        'StatusBar
        '
        Me.StatusBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSCompaniaLabel, Me.TSSCompania, Me.TSSSucursalLabel, Me.TSSSucursal, Me.TSSUsuarioLabel, Me.TSSUsuario})
        Me.StatusBar.Location = New System.Drawing.Point(0, 709)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusBar.Size = New System.Drawing.Size(1613, 25)
        Me.StatusBar.TabIndex = 1
        Me.StatusBar.Text = "StatusStrip1"
        '
        'TSSCompaniaLabel
        '
        Me.TSSCompaniaLabel.ActiveLinkColor = System.Drawing.Color.White
        Me.TSSCompaniaLabel.BackColor = System.Drawing.Color.White
        Me.TSSCompaniaLabel.Image = Global.Compras.My.Resources.Resources.Company_Building
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
        'TSSSucursalLabel
        '
        Me.TSSSucursalLabel.Image = Global.Compras.My.Resources.Resources.House__2_
        Me.TSSSucursalLabel.Name = "TSSSucursalLabel"
        Me.TSSSucursalLabel.Size = New System.Drawing.Size(83, 20)
        Me.TSSSucursalLabel.Text = "Sucursal"
        '
        'TSSSucursal
        '
        Me.TSSSucursal.AutoSize = False
        Me.TSSSucursal.Name = "TSSSucursal"
        Me.TSSSucursal.Size = New System.Drawing.Size(200, 20)
        Me.TSSSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSSUsuarioLabel
        '
        Me.TSSUsuarioLabel.Image = Global.Compras.My.Resources.Resources.user1
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
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelMain.Controls.Add(Me.PnlShortCuts)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.LblEmpresaNombre)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMain.Location = New System.Drawing.Point(0, 28)
        Me.PanelMain.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1613, 86)
        Me.PanelMain.TabIndex = 2
        '
        'PnlShortCuts
        '
        Me.PnlShortCuts.Controls.Add(Me.BtnRecepcionDeMercaderia)
        Me.PnlShortCuts.Controls.Add(Me.BtnArticulo)
        Me.PnlShortCuts.Controls.Add(Me.BtnOrdenCompra)
        Me.PnlShortCuts.Controls.Add(Me.BtnEntradaDeMercaderia)
        Me.PnlShortCuts.Controls.Add(Me.BtnConsultaArticulos)
        Me.PnlShortCuts.Controls.Add(Me.BtnConexion)
        Me.PnlShortCuts.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlShortCuts.Location = New System.Drawing.Point(1023, 0)
        Me.PnlShortCuts.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlShortCuts.Name = "PnlShortCuts"
        Me.PnlShortCuts.Size = New System.Drawing.Size(586, 82)
        Me.PnlShortCuts.TabIndex = 13
        '
        'BtnRecepcionDeMercaderia
        '
        Me.BtnRecepcionDeMercaderia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRecepcionDeMercaderia.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnRecepcionDeMercaderia.ForeColor = System.Drawing.Color.White
        Me.BtnRecepcionDeMercaderia.Image = Global.Compras.My.Resources.Resources.box_preferences
        Me.BtnRecepcionDeMercaderia.Location = New System.Drawing.Point(7, 4)
        Me.BtnRecepcionDeMercaderia.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnRecepcionDeMercaderia.Name = "BtnRecepcionDeMercaderia"
        Me.BtnRecepcionDeMercaderia.Size = New System.Drawing.Size(96, 75)
        Me.BtnRecepcionDeMercaderia.TabIndex = 12
        Me.BtnRecepcionDeMercaderia.Text = "Recepción"
        Me.BtnRecepcionDeMercaderia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRecepcionDeMercaderia.UseVisualStyleBackColor = False
        '
        'BtnArticulo
        '
        Me.BtnArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnArticulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnArticulo.ForeColor = System.Drawing.Color.White
        Me.BtnArticulo.Image = Global.Compras.My.Resources.Resources.product
        Me.BtnArticulo.Location = New System.Drawing.Point(391, 4)
        Me.BtnArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnArticulo.Name = "BtnArticulo"
        Me.BtnArticulo.Size = New System.Drawing.Size(96, 75)
        Me.BtnArticulo.TabIndex = 11
        Me.BtnArticulo.Text = "Artículo"
        Me.BtnArticulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnArticulo.UseVisualStyleBackColor = False
        '
        'BtnOrdenCompra
        '
        Me.BtnOrdenCompra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOrdenCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnOrdenCompra.ForeColor = System.Drawing.Color.White
        Me.BtnOrdenCompra.Image = Global.Compras.My.Resources.Resources.note_add
        Me.BtnOrdenCompra.Location = New System.Drawing.Point(103, 4)
        Me.BtnOrdenCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnOrdenCompra.Name = "BtnOrdenCompra"
        Me.BtnOrdenCompra.Size = New System.Drawing.Size(96, 75)
        Me.BtnOrdenCompra.TabIndex = 10
        Me.BtnOrdenCompra.Text = "Orden"
        Me.BtnOrdenCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnOrdenCompra.UseVisualStyleBackColor = False
        '
        'BtnEntradaDeMercaderia
        '
        Me.BtnEntradaDeMercaderia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEntradaDeMercaderia.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnEntradaDeMercaderia.ForeColor = System.Drawing.Color.White
        Me.BtnEntradaDeMercaderia.Image = Global.Compras.My.Resources.Resources.box_add
        Me.BtnEntradaDeMercaderia.Location = New System.Drawing.Point(199, 4)
        Me.BtnEntradaDeMercaderia.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnEntradaDeMercaderia.Name = "BtnEntradaDeMercaderia"
        Me.BtnEntradaDeMercaderia.Size = New System.Drawing.Size(96, 75)
        Me.BtnEntradaDeMercaderia.TabIndex = 9
        Me.BtnEntradaDeMercaderia.Text = "Entrada"
        Me.BtnEntradaDeMercaderia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnEntradaDeMercaderia.UseVisualStyleBackColor = False
        '
        'BtnConsultaArticulos
        '
        Me.BtnConsultaArticulos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultaArticulos.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnConsultaArticulos.ForeColor = System.Drawing.Color.White
        Me.BtnConsultaArticulos.Image = Global.Compras.My.Resources.Resources.box_view
        Me.BtnConsultaArticulos.Location = New System.Drawing.Point(295, 4)
        Me.BtnConsultaArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnConsultaArticulos.Name = "BtnConsultaArticulos"
        Me.BtnConsultaArticulos.Size = New System.Drawing.Size(96, 75)
        Me.BtnConsultaArticulos.TabIndex = 6
        Me.BtnConsultaArticulos.Text = "Saldos"
        Me.BtnConsultaArticulos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnConsultaArticulos.UseVisualStyleBackColor = False
        '
        'BtnConexion
        '
        Me.BtnConexion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConexion.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnConexion.ForeColor = System.Drawing.Color.White
        Me.BtnConexion.Image = Global.Compras.My.Resources.Resources.server_client_exchange
        Me.BtnConexion.Location = New System.Drawing.Point(486, 4)
        Me.BtnConexion.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnConexion.Name = "BtnConexion"
        Me.BtnConexion.Size = New System.Drawing.Size(96, 75)
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
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 42)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "SD-COMPRAS"
        '
        'LblEmpresaNombre
        '
        Me.LblEmpresaNombre.AutoSize = True
        Me.LblEmpresaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmpresaNombre.ForeColor = System.Drawing.Color.White
        Me.LblEmpresaNombre.Location = New System.Drawing.Point(316, 26)
        Me.LblEmpresaNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEmpresaNombre.Name = "LblEmpresaNombre"
        Me.LblEmpresaNombre.Size = New System.Drawing.Size(313, 36)
        Me.LblEmpresaNombre.TabIndex = 7
        Me.LblEmpresaNombre.Text = "Nombre de la empresa"
        '
        'PicFacturacionElectronica
        '
        Me.PicFacturacionElectronica.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicFacturacionElectronica.Image = Global.Compras.My.Resources.Resources.FacturaElectronica
        Me.PicFacturacionElectronica.Location = New System.Drawing.Point(1177, 599)
        Me.PicFacturacionElectronica.Margin = New System.Windows.Forms.Padding(4)
        Me.PicFacturacionElectronica.Name = "PicFacturacionElectronica"
        Me.PicFacturacionElectronica.Size = New System.Drawing.Size(420, 103)
        Me.PicFacturacionElectronica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFacturacionElectronica.TabIndex = 12
        Me.PicFacturacionElectronica.TabStop = False
        '
        'PicLogo
        '
        Me.PicLogo.Location = New System.Drawing.Point(16, 124)
        Me.PicLogo.Margin = New System.Windows.Forms.Padding(4)
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
        Me.ClientSize = New System.Drawing.Size(1613, 734)
        Me.Controls.Add(Me.PicFacturacionElectronica)
        Me.Controls.Add(Me.PicLogo)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.MenuStripPrincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStripPrincipal
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStripPrincipal.ResumeLayout(False)
        Me.MenuStripPrincipal.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.PnlShortCuts.ResumeLayout(False)
        CType(Me.PicFacturacionElectronica, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TSSSucursalLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSSucursal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents LblEmpresaNombre As System.Windows.Forms.Label
    Friend WithEvents MnuOrdenCompra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TSSUsuarioLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MnuCatalogos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuConsultas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuConsultaArtículos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEntradaDeMercaderia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuProveedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSeguridad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGrupo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEtiquetasCodigoBarra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuProveedoresxArticulo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PnlShortCuts As System.Windows.Forms.Panel
    Friend WithEvents BtnConsultaArticulos As System.Windows.Forms.Button
    Friend WithEvents BtnConexion As System.Windows.Forms.Button
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
    Friend WithEvents MnuAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicFacturacionElectronica As PictureBox
    Friend WithEvents EntadasXUnidadesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuComprasPorFecha As ToolStripMenuItem
    Friend WithEvents MnuComprasPorProveedor As ToolStripMenuItem
    Friend WithEvents MnuComprasPorFechaDetallado As ToolStripMenuItem
    Friend WithEvents BtnOrdenCompra As Button
    Friend WithEvents BtnEntradaDeMercaderia As Button
    Friend WithEvents BtnArticulo As Button
    Friend WithEvents MnuArticulo As ToolStripMenuItem
    Friend WithEvents BtnRecepcionDeMercaderia As Button
    Friend WithEvents MnuRecepcionDeMercaderia As ToolStripMenuItem
    Friend WithEvents MnuEmailRecepcionFacturas As ToolStripMenuItem
End Class
