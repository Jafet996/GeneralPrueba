<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCxPPagoPendiente
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCxPPagoPendiente))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.BtnEstadoCuenta = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnPagar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupEncabezado = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTipoCambio = New System.Windows.Forms.TextBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.BtnAgregaMovimiento = New System.Windows.Forms.Button()
        Me.CmbBcoTipoPago = New System.Windows.Forms.ComboBox()
        Me.TxtProveedorNombre = New System.Windows.Forms.TextBox()
        Me.TxtProveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblTotalSaldo = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LvwMovimientos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CmsMovimientos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCambiarMonto = New System.Windows.Forms.ToolStripMenuItem()
        Me.LstImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblTotalPago = New System.Windows.Forms.Label()
        Me.LblTotalDolares = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnGeneraDocumento = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupEncabezado.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmsMovimientos.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnGeneraDocumento)
        Me.Panel1.Controls.Add(Me.BtnRefrescar)
        Me.Panel1.Controls.Add(Me.BtnEstadoCuenta)
        Me.Panel1.Controls.Add(Me.BtnBuscar)
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnPagar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(80, 706)
        Me.Panel1.TabIndex = 2
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.BackColor = System.Drawing.Color.White
        Me.BtnRefrescar.Image = Global.SDBANCOS.My.Resources.Resources.Blue_F5
        Me.BtnRefrescar.Location = New System.Drawing.Point(8, 240)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(64, 71)
        Me.BtnRefrescar.TabIndex = 15
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRefrescar.UseVisualStyleBackColor = False
        '
        'BtnEstadoCuenta
        '
        Me.BtnEstadoCuenta.BackColor = System.Drawing.Color.White
        Me.BtnEstadoCuenta.Image = Global.SDBANCOS.My.Resources.Resources.Blue_F4
        Me.BtnEstadoCuenta.Location = New System.Drawing.Point(8, 163)
        Me.BtnEstadoCuenta.Name = "BtnEstadoCuenta"
        Me.BtnEstadoCuenta.Size = New System.Drawing.Size(64, 71)
        Me.BtnEstadoCuenta.TabIndex = 14
        Me.BtnEstadoCuenta.Text = "Estado"
        Me.BtnEstadoCuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnEstadoCuenta.UseVisualStyleBackColor = False
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.White
        Me.BtnBuscar.Image = Global.SDBANCOS.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.Location = New System.Drawing.Point(8, 9)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(64, 71)
        Me.BtnBuscar.TabIndex = 13
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.SDBANCOS.My.Resources.Resources.Blue_F12
        Me.BtnLimpiar.Location = New System.Drawing.Point(8, 394)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(64, 71)
        Me.BtnLimpiar.TabIndex = 12
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnPagar
        '
        Me.BtnPagar.BackColor = System.Drawing.Color.White
        Me.BtnPagar.Image = Global.SDBANCOS.My.Resources.Resources.Blue_F2
        Me.BtnPagar.Location = New System.Drawing.Point(8, 86)
        Me.BtnPagar.Name = "BtnPagar"
        Me.BtnPagar.Size = New System.Drawing.Size(64, 71)
        Me.BtnPagar.TabIndex = 10
        Me.BtnPagar.Text = "Pagar"
        Me.BtnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnPagar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDBANCOS.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(8, 471)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(64, 71)
        Me.BtnSalir.TabIndex = 9
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'GroupEncabezado
        '
        Me.GroupEncabezado.Controls.Add(Me.Label1)
        Me.GroupEncabezado.Controls.Add(Me.TxtTipoCambio)
        Me.GroupEncabezado.Controls.Add(Me.PictureBox5)
        Me.GroupEncabezado.Controls.Add(Me.BtnAgregaMovimiento)
        Me.GroupEncabezado.Controls.Add(Me.CmbBcoTipoPago)
        Me.GroupEncabezado.Controls.Add(Me.TxtProveedorNombre)
        Me.GroupEncabezado.Controls.Add(Me.TxtProveedor)
        Me.GroupEncabezado.Controls.Add(Me.Label8)
        Me.GroupEncabezado.Location = New System.Drawing.Point(86, 0)
        Me.GroupEncabezado.Name = "GroupEncabezado"
        Me.GroupEncabezado.Size = New System.Drawing.Size(1261, 94)
        Me.GroupEncabezado.TabIndex = 3
        Me.GroupEncabezado.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(808, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 25)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "T.C."
        '
        'TxtTipoCambio
        '
        Me.TxtTipoCambio.BackColor = System.Drawing.Color.White
        Me.TxtTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTipoCambio.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtTipoCambio.Location = New System.Drawing.Point(870, 34)
        Me.TxtTipoCambio.Name = "TxtTipoCambio"
        Me.TxtTipoCambio.ReadOnly = True
        Me.TxtTipoCambio.Size = New System.Drawing.Size(98, 31)
        Me.TxtTipoCambio.TabIndex = 69
        Me.TxtTipoCambio.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.SDBANCOS.My.Resources.Resources.user1
        Me.PictureBox5.Location = New System.Drawing.Point(22, 30)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(37, 39)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox5.TabIndex = 68
        Me.PictureBox5.TabStop = False
        '
        'BtnAgregaMovimiento
        '
        Me.BtnAgregaMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregaMovimiento.ForeColor = System.Drawing.Color.White
        Me.BtnAgregaMovimiento.Image = Global.SDBANCOS.My.Resources.Resources.add
        Me.BtnAgregaMovimiento.Location = New System.Drawing.Point(1201, 31)
        Me.BtnAgregaMovimiento.Name = "BtnAgregaMovimiento"
        Me.BtnAgregaMovimiento.Size = New System.Drawing.Size(37, 36)
        Me.BtnAgregaMovimiento.TabIndex = 67
        Me.BtnAgregaMovimiento.UseVisualStyleBackColor = True
        '
        'CmbBcoTipoPago
        '
        Me.CmbBcoTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBcoTipoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBcoTipoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBcoTipoPago.ForeColor = System.Drawing.Color.DarkBlue
        Me.CmbBcoTipoPago.FormattingEnabled = True
        Me.CmbBcoTipoPago.Location = New System.Drawing.Point(983, 33)
        Me.CmbBcoTipoPago.Name = "CmbBcoTipoPago"
        Me.CmbBcoTipoPago.Size = New System.Drawing.Size(214, 33)
        Me.CmbBcoTipoPago.TabIndex = 66
        '
        'TxtProveedorNombre
        '
        Me.TxtProveedorNombre.BackColor = System.Drawing.Color.White
        Me.TxtProveedorNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedorNombre.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtProveedorNombre.Location = New System.Drawing.Point(334, 34)
        Me.TxtProveedorNombre.Name = "TxtProveedorNombre"
        Me.TxtProveedorNombre.ReadOnly = True
        Me.TxtProveedorNombre.Size = New System.Drawing.Size(468, 31)
        Me.TxtProveedorNombre.TabIndex = 1
        Me.TxtProveedorNombre.TabStop = False
        '
        'TxtProveedor
        '
        Me.TxtProveedor.BackColor = System.Drawing.Color.White
        Me.TxtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtProveedor.Location = New System.Drawing.Point(205, 34)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.Size = New System.Drawing.Size(123, 31)
        Me.TxtProveedor.TabIndex = 0
        Me.TxtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(68, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 25)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Proveedor"
        '
        'LblTotalSaldo
        '
        Me.LblTotalSaldo.BackColor = System.Drawing.Color.White
        Me.LblTotalSaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalSaldo.ForeColor = System.Drawing.Color.Red
        Me.LblTotalSaldo.Location = New System.Drawing.Point(223, 656)
        Me.LblTotalSaldo.Name = "LblTotalSaldo"
        Me.LblTotalSaldo.Size = New System.Drawing.Size(158, 29)
        Me.LblTotalSaldo.TabIndex = 63
        Me.LblTotalSaldo.Text = "0.00"
        Me.LblTotalSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(87, 658)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 25)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Saldo Prov"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(1048, 656)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 25)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Total"
        '
        'LvwMovimientos
        '
        Me.LvwMovimientos.CheckBoxes = True
        Me.LvwMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19})
        Me.LvwMovimientos.ContextMenuStrip = Me.CmsMovimientos
        Me.LvwMovimientos.FullRowSelect = True
        Me.LvwMovimientos.Location = New System.Drawing.Point(86, 100)
        Me.LvwMovimientos.Name = "LvwMovimientos"
        Me.LvwMovimientos.Size = New System.Drawing.Size(1261, 537)
        Me.LvwMovimientos.SmallImageList = Me.LstImagenes
        Me.LvwMovimientos.TabIndex = 2
        Me.LvwMovimientos.UseCompatibleStateImageBehavior = False
        Me.LvwMovimientos.View = System.Windows.Forms.View.Details
        '
        'CmsMovimientos
        '
        Me.CmsMovimientos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDetalle, Me.MnuCambiarMonto})
        Me.CmsMovimientos.Name = "CmsMovimientos"
        Me.CmsMovimientos.Size = New System.Drawing.Size(159, 48)
        '
        'MnuDetalle
        '
        Me.MnuDetalle.Name = "MnuDetalle"
        Me.MnuDetalle.Size = New System.Drawing.Size(158, 22)
        Me.MnuDetalle.Text = "Detalle"
        '
        'MnuCambiarMonto
        '
        Me.MnuCambiarMonto.Name = "MnuCambiarMonto"
        Me.MnuCambiarMonto.Size = New System.Drawing.Size(158, 22)
        Me.MnuCambiarMonto.Text = "Cambiar Monto"
        '
        'LstImagenes
        '
        Me.LstImagenes.ImageStream = CType(resources.GetObject("LstImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.LstImagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.LstImagenes.Images.SetKeyName(0, "delete.ico")
        Me.LstImagenes.Images.SetKeyName(1, "check.ico")
        Me.LstImagenes.Images.SetKeyName(2, "currency_dollar.ico")
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.SDBANCOS.My.Resources.Resources.Total3
        Me.PictureBox3.Location = New System.Drawing.Point(1042, 645)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox3.TabIndex = 67
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDBANCOS.My.Resources.Resources.Total3
        Me.PictureBox2.Location = New System.Drawing.Point(82, 645)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox2.TabIndex = 61
        Me.PictureBox2.TabStop = False
        '
        'LblTotalPago
        '
        Me.LblTotalPago.BackColor = System.Drawing.Color.White
        Me.LblTotalPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalPago.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalPago.Location = New System.Drawing.Point(1182, 656)
        Me.LblTotalPago.Name = "LblTotalPago"
        Me.LblTotalPago.Size = New System.Drawing.Size(158, 29)
        Me.LblTotalPago.TabIndex = 69
        Me.LblTotalPago.Text = "0.00"
        Me.LblTotalPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalDolares
        '
        Me.LblTotalDolares.BackColor = System.Drawing.Color.White
        Me.LblTotalDolares.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDolares.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblTotalDolares.Location = New System.Drawing.Point(864, 656)
        Me.LblTotalDolares.Name = "LblTotalDolares"
        Me.LblTotalDolares.Size = New System.Drawing.Size(158, 29)
        Me.LblTotalDolares.TabIndex = 72
        Me.LblTotalDolares.Text = "0.00"
        Me.LblTotalDolares.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(733, 658)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 25)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Dólares"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SDBANCOS.My.Resources.Resources.Total3
        Me.PictureBox1.Location = New System.Drawing.Point(723, 645)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox1.TabIndex = 70
        Me.PictureBox1.TabStop = False
        '
        'BtnGeneraDocumento
        '
        Me.BtnGeneraDocumento.BackColor = System.Drawing.Color.White
        Me.BtnGeneraDocumento.Image = Global.SDBANCOS.My.Resources.Resources.Blue_F6
        Me.BtnGeneraDocumento.Location = New System.Drawing.Point(8, 317)
        Me.BtnGeneraDocumento.Name = "BtnGeneraDocumento"
        Me.BtnGeneraDocumento.Size = New System.Drawing.Size(64, 71)
        Me.BtnGeneraDocumento.TabIndex = 16
        Me.BtnGeneraDocumento.Text = "Generar"
        Me.BtnGeneraDocumento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGeneraDocumento.UseVisualStyleBackColor = False
        '
        'FrmCxPPagoPendiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1359, 706)
        Me.Controls.Add(Me.LblTotalDolares)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LblTotalPago)
        Me.Controls.Add(Me.LvwMovimientos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.LblTotalSaldo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupEncabezado)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCxPPagoPendiente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagos Pendientes"
        Me.Panel1.ResumeLayout(False)
        Me.GroupEncabezado.ResumeLayout(False)
        Me.GroupEncabezado.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmsMovimientos.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupEncabezado As System.Windows.Forms.GroupBox
    Friend WithEvents LblTotalSaldo As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtProveedorNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LvwMovimientos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CmbBcoTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents BtnPagar As System.Windows.Forms.Button
    Friend WithEvents BtnAgregaMovimiento As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents LstImagenes As System.Windows.Forms.ImageList
    Friend WithEvents CmsMovimientos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BtnEstadoCuenta As System.Windows.Forms.Button
    Friend WithEvents MnuDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnRefrescar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents MnuCambiarMonto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblTotalPago As System.Windows.Forms.Label
    Friend WithEvents LblTotalDolares As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnGeneraDocumento As System.Windows.Forms.Button
End Class
