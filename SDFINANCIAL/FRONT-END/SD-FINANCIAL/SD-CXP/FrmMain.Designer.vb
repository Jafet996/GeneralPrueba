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
        Me.MnuBanco = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTarjeta = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTipoCambio = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSeguridad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGrupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGenerarToken = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProcesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMovimientos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDocumentosProximosVencer = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEstadoDeCuenta = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.TSSTipoCambioLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSTipoCambio = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.PnlShortCuts = New System.Windows.Forms.Panel()
        Me.BtnMovimientos = New System.Windows.Forms.Button()
        Me.BtnConexion = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblEmpresaNombre = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.TotalAdeudadoMnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripPrincipal.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.PnlShortCuts.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStripPrincipal
        '
        Me.MenuStripPrincipal.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStripPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCatalogos, Me.MnuProcesos, Me.MnuConsultas, Me.MnuReportes, Me.MnuSistema})
        Me.MenuStripPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripPrincipal.Name = "MenuStripPrincipal"
        Me.MenuStripPrincipal.Size = New System.Drawing.Size(1077, 24)
        Me.MenuStripPrincipal.TabIndex = 0
        Me.MenuStripPrincipal.Text = "MenuStrip1"
        '
        'MnuCatalogos
        '
        Me.MnuCatalogos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEmpresa, Me.MnuBanco, Me.MnuProveedor, Me.MnuTarjeta, Me.MnuTipoCambio, Me.MnuSeguridad})
        Me.MnuCatalogos.Name = "MnuCatalogos"
        Me.MnuCatalogos.Size = New System.Drawing.Size(72, 20)
        Me.MnuCatalogos.Text = "Catálogos"
        Me.MnuCatalogos.Visible = False
        '
        'MnuEmpresa
        '
        Me.MnuEmpresa.Name = "MnuEmpresa"
        Me.MnuEmpresa.Size = New System.Drawing.Size(143, 22)
        Me.MnuEmpresa.Text = "Empresa"
        '
        'MnuBanco
        '
        Me.MnuBanco.Name = "MnuBanco"
        Me.MnuBanco.Size = New System.Drawing.Size(143, 22)
        Me.MnuBanco.Text = "Banco"
        '
        'MnuProveedor
        '
        Me.MnuProveedor.Name = "MnuProveedor"
        Me.MnuProveedor.Size = New System.Drawing.Size(143, 22)
        Me.MnuProveedor.Text = "Proveedor"
        '
        'MnuTarjeta
        '
        Me.MnuTarjeta.Name = "MnuTarjeta"
        Me.MnuTarjeta.Size = New System.Drawing.Size(143, 22)
        Me.MnuTarjeta.Text = "Tarjeta"
        '
        'MnuTipoCambio
        '
        Me.MnuTipoCambio.Name = "MnuTipoCambio"
        Me.MnuTipoCambio.Size = New System.Drawing.Size(143, 22)
        Me.MnuTipoCambio.Text = "Tipo Cambio"
        '
        'MnuSeguridad
        '
        Me.MnuSeguridad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuUsuario, Me.MnuGrupo, Me.MnuGenerarToken})
        Me.MnuSeguridad.Name = "MnuSeguridad"
        Me.MnuSeguridad.Size = New System.Drawing.Size(143, 22)
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
        'MnuProcesos
        '
        Me.MnuProcesos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMovimientos})
        Me.MnuProcesos.Name = "MnuProcesos"
        Me.MnuProcesos.Size = New System.Drawing.Size(66, 20)
        Me.MnuProcesos.Text = "Procesos"
        Me.MnuProcesos.Visible = False
        '
        'MnuMovimientos
        '
        Me.MnuMovimientos.Name = "MnuMovimientos"
        Me.MnuMovimientos.Size = New System.Drawing.Size(144, 22)
        Me.MnuMovimientos.Text = "Movimientos"
        '
        'MnuConsultas
        '
        Me.MnuConsultas.Name = "MnuConsultas"
        Me.MnuConsultas.Size = New System.Drawing.Size(71, 20)
        Me.MnuConsultas.Text = "Consultas"
        Me.MnuConsultas.Visible = False
        '
        'MnuReportes
        '
        Me.MnuReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDocumentosProximosVencer, Me.MnuEstadoDeCuenta, Me.TotalAdeudadoMnu})
        Me.MnuReportes.Name = "MnuReportes"
        Me.MnuReportes.Size = New System.Drawing.Size(65, 20)
        Me.MnuReportes.Text = "Reportes"
        Me.MnuReportes.Visible = False
        '
        'MnuDocumentosProximosVencer
        '
        Me.MnuDocumentosProximosVencer.Name = "MnuDocumentosProximosVencer"
        Me.MnuDocumentosProximosVencer.Size = New System.Drawing.Size(244, 22)
        Me.MnuDocumentosProximosVencer.Text = "Documentos Próximos Vencer"
        '
        'MnuEstadoDeCuenta
        '
        Me.MnuEstadoDeCuenta.Name = "MnuEstadoDeCuenta"
        Me.MnuEstadoDeCuenta.Size = New System.Drawing.Size(244, 22)
        Me.MnuEstadoDeCuenta.Text = "Estado de Cuenta por Proveedor"
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
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSCompaniaLabel, Me.TSSCompania, Me.TSSUsuarioLabel, Me.TSSUsuario, Me.TSSPeriodoLabel, Me.TSSPeriodo, Me.TSSTipoCambioLabel, Me.TSSTipoCambio})
        Me.StatusBar.Location = New System.Drawing.Point(0, 554)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(1077, 25)
        Me.StatusBar.TabIndex = 1
        Me.StatusBar.Text = "StatusStrip1"
        '
        'TSSCompaniaLabel
        '
        Me.TSSCompaniaLabel.Image = Global.SDCXP.My.Resources.Resources.Company_Building
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
        Me.TSSUsuarioLabel.Image = Global.SDCXP.My.Resources.Resources.user1
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
        Me.TSSPeriodoLabel.Image = Global.SDCXP.My.Resources.Resources.calendar
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
        'TSSTipoCambioLabel
        '
        Me.TSSTipoCambioLabel.Image = Global.SDCXP.My.Resources.Resources.moneybag_dollar
        Me.TSSTipoCambioLabel.Name = "TSSTipoCambioLabel"
        Me.TSSTipoCambioLabel.Size = New System.Drawing.Size(41, 20)
        Me.TSSTipoCambioLabel.Text = "TC"
        '
        'TSSTipoCambio
        '
        Me.TSSTipoCambio.AutoSize = False
        Me.TSSTipoCambio.Name = "TSSTipoCambio"
        Me.TSSTipoCambio.Size = New System.Drawing.Size(60, 20)
        Me.TSSTipoCambio.Text = "0.00"
        Me.TSSTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.PnlShortCuts.Controls.Add(Me.BtnMovimientos)
        Me.PnlShortCuts.Controls.Add(Me.BtnConexion)
        Me.PnlShortCuts.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlShortCuts.Location = New System.Drawing.Point(920, 0)
        Me.PnlShortCuts.Name = "PnlShortCuts"
        Me.PnlShortCuts.Size = New System.Drawing.Size(153, 70)
        Me.PnlShortCuts.TabIndex = 14
        '
        'BtnMovimientos
        '
        Me.BtnMovimientos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMovimientos.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnMovimientos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMovimientos.ForeColor = System.Drawing.Color.White
        Me.BtnMovimientos.Image = Global.SDCXP.My.Resources.Resources.money_envelope
        Me.BtnMovimientos.Location = New System.Drawing.Point(2, 3)
        Me.BtnMovimientos.Name = "BtnMovimientos"
        Me.BtnMovimientos.Size = New System.Drawing.Size(72, 64)
        Me.BtnMovimientos.TabIndex = 3
        Me.BtnMovimientos.Text = "Saldo CxP"
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
        Me.BtnConexion.Image = Global.SDCXP.My.Resources.Resources.server_client_exchange
        Me.BtnConexion.Location = New System.Drawing.Point(73, 3)
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
        Me.Label1.Size = New System.Drawing.Size(130, 33)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "SD-CXP"
        '
        'LblEmpresaNombre
        '
        Me.LblEmpresaNombre.AutoSize = True
        Me.LblEmpresaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmpresaNombre.ForeColor = System.Drawing.Color.White
        Me.LblEmpresaNombre.Location = New System.Drawing.Point(158, 20)
        Me.LblEmpresaNombre.Name = "LblEmpresaNombre"
        Me.LblEmpresaNombre.Size = New System.Drawing.Size(0, 29)
        Me.LblEmpresaNombre.TabIndex = 7
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.SDCXP.My.Resources.Resources.LOGO_SBD_CR_web_transparencia_01
        Me.PictureBox2.Location = New System.Drawing.Point(951, 446)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(121, 106)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        'TotalAdeudadoMnu
        '
        Me.TotalAdeudadoMnu.Name = "TotalAdeudadoMnu"
        Me.TotalAdeudadoMnu.Size = New System.Drawing.Size(244, 22)
        Me.TotalAdeudadoMnu.Text = "Total Adeudado"
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
    Friend WithEvents MnuConsultas As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents MnuTipoCambio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSPeriodoLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSPeriodo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents MnuMovimientos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnMovimientos As System.Windows.Forms.Button
    Friend WithEvents MnuBanco As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTarjeta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuProveedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDocumentosProximosVencer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSTipoCambioLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSTipoCambio As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MnuEstadoDeCuenta As ToolStripMenuItem
    Friend WithEvents TotalAdeudadoMnu As ToolStripMenuItem
End Class
