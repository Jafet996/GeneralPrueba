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
        Me.MnuEmpresa = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCentroDeCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTipoCambio = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTiposDeCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCuentaTipo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCuentaTIpoClase = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCatalogoContable = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCuentaFlujoEfectivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTiposDeAsiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSeguridad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGrupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGenerarToken = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAuxiliares = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuImportarAsientos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProcesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAsientos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCierreDeMes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCierreDePeriodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRepAsientosDeDiario = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMovimientosPorCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConsultaSaldoDeCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBalanceDeSituacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEstadoDeResultados = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBalanceDeComprobacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEstadoDeCambiosPatrimonio = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConexión = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.TSSCompaniaLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSCompania = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSUsuarioLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSPeriodoLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSPeriodo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.PnlShortCuts = New System.Windows.Forms.Panel()
        Me.BtnConexion = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblEmpresaNombre = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.MnuEstadoFlujoEfectivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripPrincipal.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.PnlShortCuts.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStripPrincipal
        '
        Me.MenuStripPrincipal.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStripPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCatalogos, Me.MnuAuxiliares, Me.MnuProcesos, Me.MnuReportes, Me.MnuSistema})
        Me.MenuStripPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripPrincipal.Name = "MenuStripPrincipal"
        Me.MenuStripPrincipal.Size = New System.Drawing.Size(1077, 24)
        Me.MenuStripPrincipal.TabIndex = 0
        Me.MenuStripPrincipal.Text = "MenuStrip1"
        '
        'MnuCatalogos
        '
        Me.MnuCatalogos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEmpresa, Me.MnuCentroDeCosto, Me.MnuTipoCambio, Me.MnuTiposDeCuenta, Me.MnuCatalogoContable, Me.MnuCuentaFlujoEfectivo, Me.MnuTiposDeAsiento, Me.MnuSeguridad})
        Me.MnuCatalogos.Name = "MnuCatalogos"
        Me.MnuCatalogos.Size = New System.Drawing.Size(72, 20)
        Me.MnuCatalogos.Text = "Catálogos"
        Me.MnuCatalogos.Visible = False
        '
        'MnuEmpresa
        '
        Me.MnuEmpresa.Name = "MnuEmpresa"
        Me.MnuEmpresa.Size = New System.Drawing.Size(223, 22)
        Me.MnuEmpresa.Text = "Empresa"
        '
        'MnuCentroDeCosto
        '
        Me.MnuCentroDeCosto.Name = "MnuCentroDeCosto"
        Me.MnuCentroDeCosto.Size = New System.Drawing.Size(223, 22)
        Me.MnuCentroDeCosto.Text = "Centro de Costo"
        '
        'MnuTipoCambio
        '
        Me.MnuTipoCambio.Name = "MnuTipoCambio"
        Me.MnuTipoCambio.Size = New System.Drawing.Size(223, 22)
        Me.MnuTipoCambio.Text = "Tipo Cambio"
        '
        'MnuTiposDeCuenta
        '
        Me.MnuTiposDeCuenta.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCuentaTipo, Me.MnuCuentaTIpoClase})
        Me.MnuTiposDeCuenta.Name = "MnuTiposDeCuenta"
        Me.MnuTiposDeCuenta.Size = New System.Drawing.Size(223, 22)
        Me.MnuTiposDeCuenta.Text = "Tipos de Cuenta"
        '
        'MnuCuentaTipo
        '
        Me.MnuCuentaTipo.Name = "MnuCuentaTipo"
        Me.MnuCuentaTipo.Size = New System.Drawing.Size(102, 22)
        Me.MnuCuentaTipo.Text = "Tipo"
        '
        'MnuCuentaTIpoClase
        '
        Me.MnuCuentaTIpoClase.Name = "MnuCuentaTIpoClase"
        Me.MnuCuentaTIpoClase.Size = New System.Drawing.Size(102, 22)
        Me.MnuCuentaTIpoClase.Text = "Clase"
        '
        'MnuCatalogoContable
        '
        Me.MnuCatalogoContable.Name = "MnuCatalogoContable"
        Me.MnuCatalogoContable.Size = New System.Drawing.Size(223, 22)
        Me.MnuCatalogoContable.Text = "Catálogo Contable"
        '
        'MnuCuentaFlujoEfectivo
        '
        Me.MnuCuentaFlujoEfectivo.Name = "MnuCuentaFlujoEfectivo"
        Me.MnuCuentaFlujoEfectivo.Size = New System.Drawing.Size(223, 22)
        Me.MnuCuentaFlujoEfectivo.Text = "Cuentas de Flujo de Efectivo"
        '
        'MnuTiposDeAsiento
        '
        Me.MnuTiposDeAsiento.Name = "MnuTiposDeAsiento"
        Me.MnuTiposDeAsiento.Size = New System.Drawing.Size(223, 22)
        Me.MnuTiposDeAsiento.Text = "Tipos de Asiento"
        '
        'MnuSeguridad
        '
        Me.MnuSeguridad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuUsuario, Me.MnuGrupo, Me.MnuGenerarToken})
        Me.MnuSeguridad.Name = "MnuSeguridad"
        Me.MnuSeguridad.Size = New System.Drawing.Size(223, 22)
        Me.MnuSeguridad.Text = "Seguridad"
        '
        'MnuUsuario
        '
        Me.MnuUsuario.Name = "MnuUsuario"
        Me.MnuUsuario.Size = New System.Drawing.Size(150, 22)
        Me.MnuUsuario.Text = "Usuario"
        '
        'MnuGrupo
        '
        Me.MnuGrupo.Name = "MnuGrupo"
        Me.MnuGrupo.Size = New System.Drawing.Size(150, 22)
        Me.MnuGrupo.Text = "Rol"
        '
        'MnuGenerarToken
        '
        Me.MnuGenerarToken.Name = "MnuGenerarToken"
        Me.MnuGenerarToken.Size = New System.Drawing.Size(150, 22)
        Me.MnuGenerarToken.Text = "Generar Token"
        '
        'MnuAuxiliares
        '
        Me.MnuAuxiliares.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuImportarAsientos})
        Me.MnuAuxiliares.Name = "MnuAuxiliares"
        Me.MnuAuxiliares.Size = New System.Drawing.Size(69, 20)
        Me.MnuAuxiliares.Text = "Auxiliares"
        Me.MnuAuxiliares.Visible = False
        '
        'MnuImportarAsientos
        '
        Me.MnuImportarAsientos.Name = "MnuImportarAsientos"
        Me.MnuImportarAsientos.Size = New System.Drawing.Size(168, 22)
        Me.MnuImportarAsientos.Text = "Importar Asientos"
        '
        'MnuProcesos
        '
        Me.MnuProcesos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAsientos, Me.MnuCierreDeMes, Me.MnuCierreDePeriodo})
        Me.MnuProcesos.Name = "MnuProcesos"
        Me.MnuProcesos.Size = New System.Drawing.Size(66, 20)
        Me.MnuProcesos.Text = "Procesos"
        Me.MnuProcesos.Visible = False
        '
        'MnuAsientos
        '
        Me.MnuAsientos.Name = "MnuAsientos"
        Me.MnuAsientos.Size = New System.Drawing.Size(165, 22)
        Me.MnuAsientos.Text = "Asientos"
        '
        'MnuCierreDeMes
        '
        Me.MnuCierreDeMes.Name = "MnuCierreDeMes"
        Me.MnuCierreDeMes.Size = New System.Drawing.Size(165, 22)
        Me.MnuCierreDeMes.Text = "Cierre de Mes"
        '
        'MnuCierreDePeriodo
        '
        Me.MnuCierreDePeriodo.Name = "MnuCierreDePeriodo"
        Me.MnuCierreDePeriodo.Size = New System.Drawing.Size(165, 22)
        Me.MnuCierreDePeriodo.Text = "Cierre de Periodo"
        '
        'MnuReportes
        '
        Me.MnuReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuRepAsientosDeDiario, Me.MnuMovimientosPorCuenta, Me.MnuConsultaSaldoDeCuenta, Me.MnuBalanceDeSituacion, Me.MnuEstadoDeResultados, Me.MnuBalanceDeComprobacion, Me.MnuEstadoDeCambiosPatrimonio, Me.MnuEstadoFlujoEfectivo})
        Me.MnuReportes.Name = "MnuReportes"
        Me.MnuReportes.Size = New System.Drawing.Size(65, 20)
        Me.MnuReportes.Text = "Reportes"
        Me.MnuReportes.Visible = False
        '
        'MnuRepAsientosDeDiario
        '
        Me.MnuRepAsientosDeDiario.Name = "MnuRepAsientosDeDiario"
        Me.MnuRepAsientosDeDiario.Size = New System.Drawing.Size(265, 22)
        Me.MnuRepAsientosDeDiario.Text = "Asientos de Diario"
        '
        'MnuMovimientosPorCuenta
        '
        Me.MnuMovimientosPorCuenta.Name = "MnuMovimientosPorCuenta"
        Me.MnuMovimientosPorCuenta.Size = New System.Drawing.Size(265, 22)
        Me.MnuMovimientosPorCuenta.Text = "Movimientos por Cuenta"
        '
        'MnuConsultaSaldoDeCuenta
        '
        Me.MnuConsultaSaldoDeCuenta.Name = "MnuConsultaSaldoDeCuenta"
        Me.MnuConsultaSaldoDeCuenta.Size = New System.Drawing.Size(265, 22)
        Me.MnuConsultaSaldoDeCuenta.Text = "Consulta Saldo de Cuenta"
        '
        'MnuBalanceDeSituacion
        '
        Me.MnuBalanceDeSituacion.Name = "MnuBalanceDeSituacion"
        Me.MnuBalanceDeSituacion.Size = New System.Drawing.Size(265, 22)
        Me.MnuBalanceDeSituacion.Text = "Balance de Situación"
        '
        'MnuEstadoDeResultados
        '
        Me.MnuEstadoDeResultados.Name = "MnuEstadoDeResultados"
        Me.MnuEstadoDeResultados.Size = New System.Drawing.Size(265, 22)
        Me.MnuEstadoDeResultados.Text = "Estado de Resultados"
        '
        'MnuBalanceDeComprobacion
        '
        Me.MnuBalanceDeComprobacion.Name = "MnuBalanceDeComprobacion"
        Me.MnuBalanceDeComprobacion.Size = New System.Drawing.Size(265, 22)
        Me.MnuBalanceDeComprobacion.Text = "Balance de Comprobación"
        '
        'MnuEstadoDeCambiosPatrimonio
        '
        Me.MnuEstadoDeCambiosPatrimonio.Name = "MnuEstadoDeCambiosPatrimonio"
        Me.MnuEstadoDeCambiosPatrimonio.Size = New System.Drawing.Size(265, 22)
        Me.MnuEstadoDeCambiosPatrimonio.Text = "Estado de Cambios en el Patrimonio"
        '
        'MnuSistema
        '
        Me.MnuSistema.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAcercaDe, Me.MnuConexión, Me.MnuSalir})
        Me.MnuSistema.Name = "MnuSistema"
        Me.MnuSistema.Size = New System.Drawing.Size(60, 20)
        Me.MnuSistema.Text = "Sistema"
        '
        'MnuAcercaDe
        '
        Me.MnuAcercaDe.Name = "MnuAcercaDe"
        Me.MnuAcercaDe.Size = New System.Drawing.Size(127, 22)
        Me.MnuAcercaDe.Text = "Acerca De"
        '
        'MnuConexión
        '
        Me.MnuConexión.Name = "MnuConexión"
        Me.MnuConexión.Size = New System.Drawing.Size(127, 22)
        Me.MnuConexión.Text = "Conexión"
        '
        'MnuSalir
        '
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Size = New System.Drawing.Size(127, 22)
        Me.MnuSalir.Text = "Salir"
        '
        'StatusBar
        '
        Me.StatusBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSCompaniaLabel, Me.TSSCompania, Me.TSSUsuarioLabel, Me.TSSUsuario, Me.TSSPeriodoLabel, Me.TSSPeriodo})
        Me.StatusBar.Location = New System.Drawing.Point(0, 554)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(1077, 25)
        Me.StatusBar.TabIndex = 1
        Me.StatusBar.Text = "StatusStrip1"
        '
        'TSSCompaniaLabel
        '
        Me.TSSCompaniaLabel.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Company_Building
        Me.TSSCompaniaLabel.Name = "TSSCompaniaLabel"
        Me.TSSCompaniaLabel.Size = New System.Drawing.Size(82, 20)
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
        Me.TSSUsuarioLabel.Image = Global.SDCONTABILIDAD.My.Resources.Resources.user1
        Me.TSSUsuarioLabel.Name = "TSSUsuarioLabel"
        Me.TSSUsuarioLabel.Size = New System.Drawing.Size(67, 20)
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
        Me.TSSPeriodoLabel.Image = Global.SDCONTABILIDAD.My.Resources.Resources.calendar
        Me.TSSPeriodoLabel.Name = "TSSPeriodoLabel"
        Me.TSSPeriodoLabel.Size = New System.Drawing.Size(68, 20)
        Me.TSSPeriodoLabel.Text = "Periodo"
        '
        'TSSPeriodo
        '
        Me.TSSPeriodo.AutoSize = False
        Me.TSSPeriodo.Name = "TSSPeriodo"
        Me.TSSPeriodo.Size = New System.Drawing.Size(200, 20)
        Me.TSSPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelMain.Controls.Add(Me.PnlShortCuts)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.LblEmpresaNombre)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMain.Location = New System.Drawing.Point(0, 24)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1077, 74)
        Me.PanelMain.TabIndex = 2
        '
        'PnlShortCuts
        '
        Me.PnlShortCuts.Controls.Add(Me.BtnConexion)
        Me.PnlShortCuts.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlShortCuts.Location = New System.Drawing.Point(995, 0)
        Me.PnlShortCuts.Name = "PnlShortCuts"
        Me.PnlShortCuts.Size = New System.Drawing.Size(78, 70)
        Me.PnlShortCuts.TabIndex = 14
        '
        'BtnConexion
        '
        Me.BtnConexion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConexion.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnConexion.Image = Global.SDCONTABILIDAD.My.Resources.Resources.server_client_exchange
        Me.BtnConexion.Location = New System.Drawing.Point(3, 3)
        Me.BtnConexion.Name = "BtnConexion"
        Me.BtnConexion.Size = New System.Drawing.Size(72, 64)
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
        Me.Label1.Location = New System.Drawing.Point(10, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(294, 33)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "SD-CONTABILIDAD"
        '
        'LblEmpresaNombre
        '
        Me.LblEmpresaNombre.AutoSize = True
        Me.LblEmpresaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmpresaNombre.ForeColor = System.Drawing.Color.White
        Me.LblEmpresaNombre.Location = New System.Drawing.Point(310, 20)
        Me.LblEmpresaNombre.Name = "LblEmpresaNombre"
        Me.LblEmpresaNombre.Size = New System.Drawing.Size(261, 29)
        Me.LblEmpresaNombre.TabIndex = 7
        Me.LblEmpresaNombre.Text = "Nombre de la empresa"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.SDCONTABILIDAD.My.Resources.Resources.LogoSDB
        Me.PictureBox1.Location = New System.Drawing.Point(1078, 449)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(121, 106)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'PicLogo
        '
        Me.PicLogo.Location = New System.Drawing.Point(12, 104)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(514, 431)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 10
        Me.PicLogo.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.SDCONTABILIDAD.My.Resources.Resources.LogoSDB
        Me.PictureBox2.Location = New System.Drawing.Point(951, 446)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(121, 106)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'MnuEstadoFlujoEfectivo
        '
        Me.MnuEstadoFlujoEfectivo.Name = "MnuEstadoFlujoEfectivo"
        Me.MnuEstadoFlujoEfectivo.Size = New System.Drawing.Size(265, 22)
        Me.MnuEstadoFlujoEfectivo.Text = "Estado de Flujo en el Efectivo"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1077, 579)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PicLogo)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.MenuStripPrincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStripPrincipal
        Me.Name = "FrmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStripPrincipal.ResumeLayout(False)
        Me.MenuStripPrincipal.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.PnlShortCuts.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents MnuAuxiliares As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSeguridad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGrupo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PnlShortCuts As System.Windows.Forms.Panel
    Friend WithEvents BtnConexion As System.Windows.Forms.Button
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MnuAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEmpresa As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGenerarToken As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCatalogoContable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTiposDeCuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCuentaTipo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCuentaTIpoClase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCentroDeCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTiposDeAsiento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTipoCambio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAsientos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCierreDeMes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSPeriodoLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSPeriodo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MnuRepAsientosDeDiario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMovimientosPorCuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuConsultaSaldoDeCuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBalanceDeSituacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEstadoDeResultados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBalanceDeComprobacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCierreDePeriodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents MnuEstadoDeCambiosPatrimonio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuImportarAsientos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCuentaFlujoEfectivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEstadoFlujoEfectivo As System.Windows.Forms.ToolStripMenuItem
End Class
