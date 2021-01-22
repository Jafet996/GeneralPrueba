<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMovimientosProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovimientosProveedor))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnPagando = New System.Windows.Forms.Button()
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.BtnEstadoCuenta = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnPagar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupEncabezado = New System.Windows.Forms.GroupBox()
        Me.CmbFiltro = New System.Windows.Forms.ComboBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.BtnAgregaMovimiento = New System.Windows.Forms.Button()
        Me.CmbMovimientoTipo = New System.Windows.Forms.ComboBox()
        Me.TxtProveedorNombre = New System.Windows.Forms.TextBox()
        Me.TxtProveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblTotalMora = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblTotalSaldo = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblTotalProcesoPago = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.CmsMovimientos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuReimprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.LstImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.GroupEncabezado.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmsMovimientos.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnPagando)
        Me.Panel1.Controls.Add(Me.BtnRefrescar)
        Me.Panel1.Controls.Add(Me.BtnEstadoCuenta)
        Me.Panel1.Controls.Add(Me.BtnBuscar)
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnPagar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(107, 869)
        Me.Panel1.TabIndex = 2
        '
        'BtnPagando
        '
        Me.BtnPagando.BackColor = System.Drawing.Color.White
        Me.BtnPagando.Image = Global.SDCXP.My.Resources.Resources.Blue_F3
        Me.BtnPagando.Location = New System.Drawing.Point(11, 201)
        Me.BtnPagando.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPagando.Name = "BtnPagando"
        Me.BtnPagando.Size = New System.Drawing.Size(85, 87)
        Me.BtnPagando.TabIndex = 16
        Me.BtnPagando.Text = "Pagando"
        Me.BtnPagando.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnPagando.UseVisualStyleBackColor = False
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.BackColor = System.Drawing.Color.White
        Me.BtnRefrescar.Image = Global.SDCXP.My.Resources.Resources.Blue_F5
        Me.BtnRefrescar.Location = New System.Drawing.Point(11, 390)
        Me.BtnRefrescar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(85, 87)
        Me.BtnRefrescar.TabIndex = 15
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRefrescar.UseVisualStyleBackColor = False
        '
        'BtnEstadoCuenta
        '
        Me.BtnEstadoCuenta.BackColor = System.Drawing.Color.White
        Me.BtnEstadoCuenta.Image = Global.SDCXP.My.Resources.Resources.Blue_F4
        Me.BtnEstadoCuenta.Location = New System.Drawing.Point(11, 295)
        Me.BtnEstadoCuenta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnEstadoCuenta.Name = "BtnEstadoCuenta"
        Me.BtnEstadoCuenta.Size = New System.Drawing.Size(85, 87)
        Me.BtnEstadoCuenta.TabIndex = 14
        Me.BtnEstadoCuenta.Text = "Estado"
        Me.BtnEstadoCuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnEstadoCuenta.UseVisualStyleBackColor = False
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.White
        Me.BtnBuscar.Image = Global.SDCXP.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.Location = New System.Drawing.Point(11, 11)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(85, 87)
        Me.BtnBuscar.TabIndex = 13
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.SDCXP.My.Resources.Resources.Blue_F12
        Me.BtnLimpiar.Location = New System.Drawing.Point(11, 485)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(85, 87)
        Me.BtnLimpiar.TabIndex = 12
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnPagar
        '
        Me.BtnPagar.BackColor = System.Drawing.Color.White
        Me.BtnPagar.Image = Global.SDCXP.My.Resources.Resources.Blue_F2
        Me.BtnPagar.Location = New System.Drawing.Point(11, 106)
        Me.BtnPagar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPagar.Name = "BtnPagar"
        Me.BtnPagar.Size = New System.Drawing.Size(85, 87)
        Me.BtnPagar.TabIndex = 10
        Me.BtnPagar.Text = "Pagar"
        Me.BtnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnPagar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCXP.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(11, 580)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(85, 87)
        Me.BtnSalir.TabIndex = 9
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'GroupEncabezado
        '
        Me.GroupEncabezado.Controls.Add(Me.CmbFiltro)
        Me.GroupEncabezado.Controls.Add(Me.PictureBox5)
        Me.GroupEncabezado.Controls.Add(Me.BtnAgregaMovimiento)
        Me.GroupEncabezado.Controls.Add(Me.CmbMovimientoTipo)
        Me.GroupEncabezado.Controls.Add(Me.TxtProveedorNombre)
        Me.GroupEncabezado.Controls.Add(Me.TxtProveedor)
        Me.GroupEncabezado.Controls.Add(Me.Label8)
        Me.GroupEncabezado.Location = New System.Drawing.Point(115, 0)
        Me.GroupEncabezado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupEncabezado.Name = "GroupEncabezado"
        Me.GroupEncabezado.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupEncabezado.Size = New System.Drawing.Size(1681, 116)
        Me.GroupEncabezado.TabIndex = 3
        Me.GroupEncabezado.TabStop = False
        '
        'CmbFiltro
        '
        Me.CmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbFiltro.ForeColor = System.Drawing.Color.DarkBlue
        Me.CmbFiltro.FormattingEnabled = True
        Me.CmbFiltro.Items.AddRange(New Object() {"Todo", "Pendientes", "Proceso Pago", "Debitos", "Créditos"})
        Me.CmbFiltro.Location = New System.Drawing.Point(1161, 41)
        Me.CmbFiltro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbFiltro.Name = "CmbFiltro"
        Me.CmbFiltro.Size = New System.Drawing.Size(215, 38)
        Me.CmbFiltro.TabIndex = 69
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.SDCXP.My.Resources.Resources.user1
        Me.PictureBox5.Location = New System.Drawing.Point(29, 37)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(49, 48)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox5.TabIndex = 68
        Me.PictureBox5.TabStop = False
        '
        'BtnAgregaMovimiento
        '
        Me.BtnAgregaMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregaMovimiento.ForeColor = System.Drawing.Color.White
        Me.BtnAgregaMovimiento.Image = Global.SDCXP.My.Resources.Resources.add
        Me.BtnAgregaMovimiento.Location = New System.Drawing.Point(1601, 38)
        Me.BtnAgregaMovimiento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAgregaMovimiento.Name = "BtnAgregaMovimiento"
        Me.BtnAgregaMovimiento.Size = New System.Drawing.Size(49, 44)
        Me.BtnAgregaMovimiento.TabIndex = 67
        Me.BtnAgregaMovimiento.UseVisualStyleBackColor = True
        '
        'CmbMovimientoTipo
        '
        Me.CmbMovimientoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMovimientoTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMovimientoTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMovimientoTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.CmbMovimientoTipo.FormattingEnabled = True
        Me.CmbMovimientoTipo.Location = New System.Drawing.Point(1395, 41)
        Me.CmbMovimientoTipo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbMovimientoTipo.Name = "CmbMovimientoTipo"
        Me.CmbMovimientoTipo.Size = New System.Drawing.Size(200, 38)
        Me.CmbMovimientoTipo.TabIndex = 66
        '
        'TxtProveedorNombre
        '
        Me.TxtProveedorNombre.BackColor = System.Drawing.Color.White
        Me.TxtProveedorNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedorNombre.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtProveedorNombre.Location = New System.Drawing.Point(445, 42)
        Me.TxtProveedorNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtProveedorNombre.Name = "TxtProveedorNombre"
        Me.TxtProveedorNombre.ReadOnly = True
        Me.TxtProveedorNombre.Size = New System.Drawing.Size(675, 37)
        Me.TxtProveedorNombre.TabIndex = 1
        Me.TxtProveedorNombre.TabStop = False
        '
        'TxtProveedor
        '
        Me.TxtProveedor.BackColor = System.Drawing.Color.White
        Me.TxtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtProveedor.Location = New System.Drawing.Point(273, 42)
        Me.TxtProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.Size = New System.Drawing.Size(163, 37)
        Me.TxtProveedor.TabIndex = 0
        Me.TxtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(91, 46)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 31)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Proveedor"
        '
        'LblTotalMora
        '
        Me.LblTotalMora.BackColor = System.Drawing.Color.White
        Me.LblTotalMora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalMora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMora.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalMora.Location = New System.Drawing.Point(303, 807)
        Me.LblTotalMora.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalMora.Name = "LblTotalMora"
        Me.LblTotalMora.Size = New System.Drawing.Size(211, 36)
        Me.LblTotalMora.TabIndex = 66
        Me.LblTotalMora.Text = "0.00"
        Me.LblTotalMora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(128, 810)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 31)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Mora"
        '
        'LblTotalSaldo
        '
        Me.LblTotalSaldo.BackColor = System.Drawing.Color.White
        Me.LblTotalSaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalSaldo.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalSaldo.Location = New System.Drawing.Point(1571, 807)
        Me.LblTotalSaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalSaldo.Name = "LblTotalSaldo"
        Me.LblTotalSaldo.Size = New System.Drawing.Size(211, 36)
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
        Me.Label12.Location = New System.Drawing.Point(1396, 810)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 31)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Saldo"
        '
        'LblTotalProcesoPago
        '
        Me.LblTotalProcesoPago.BackColor = System.Drawing.Color.White
        Me.LblTotalProcesoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalProcesoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalProcesoPago.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalProcesoPago.Location = New System.Drawing.Point(719, 807)
        Me.LblTotalProcesoPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalProcesoPago.Name = "LblTotalProcesoPago"
        Me.LblTotalProcesoPago.Size = New System.Drawing.Size(211, 36)
        Me.LblTotalProcesoPago.TabIndex = 72
        Me.LblTotalProcesoPago.Text = "0.00"
        Me.LblTotalProcesoPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(544, 810)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 31)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Pagando"
        '
        'LvwMovimientos
        '
        Me.LvwMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.LvwMovimientos.ContextMenuStrip = Me.CmsMovimientos
        Me.LvwMovimientos.FullRowSelect = True
        Me.LvwMovimientos.HideSelection = False
        Me.LvwMovimientos.Location = New System.Drawing.Point(115, 123)
        Me.LvwMovimientos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LvwMovimientos.Name = "LvwMovimientos"
        Me.LvwMovimientos.Size = New System.Drawing.Size(1680, 660)
        Me.LvwMovimientos.SmallImageList = Me.LstImagenes
        Me.LvwMovimientos.TabIndex = 2
        Me.LvwMovimientos.UseCompatibleStateImageBehavior = False
        Me.LvwMovimientos.View = System.Windows.Forms.View.Details
        '
        'CmsMovimientos
        '
        Me.CmsMovimientos.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CmsMovimientos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuReimprimir, Me.MnuDetalle})
        Me.CmsMovimientos.Name = "CmsMovimientos"
        Me.CmsMovimientos.Size = New System.Drawing.Size(153, 52)
        '
        'MnuReimprimir
        '
        Me.MnuReimprimir.Name = "MnuReimprimir"
        Me.MnuReimprimir.Size = New System.Drawing.Size(152, 24)
        Me.MnuReimprimir.Text = "Reimprimir"
        '
        'MnuDetalle
        '
        Me.MnuDetalle.Name = "MnuDetalle"
        Me.MnuDetalle.Size = New System.Drawing.Size(152, 24)
        Me.MnuDetalle.Text = "Detalle"
        '
        'LstImagenes
        '
        Me.LstImagenes.ImageStream = CType(resources.GetObject("LstImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.LstImagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.LstImagenes.Images.SetKeyName(0, "delete.ico")
        Me.LstImagenes.Images.SetKeyName(1, "check.ico")
        Me.LstImagenes.Images.SetKeyName(2, "currency_dollar.ico")
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.SDCXP.My.Resources.Resources.Total3
        Me.PictureBox4.Location = New System.Drawing.Point(531, 794)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(412, 64)
        Me.PictureBox4.TabIndex = 70
        Me.PictureBox4.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SDCXP.My.Resources.Resources.Total3
        Me.PictureBox1.Location = New System.Drawing.Point(115, 794)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(412, 64)
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDCXP.My.Resources.Resources.Total3
        Me.PictureBox2.Location = New System.Drawing.Point(1383, 794)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(412, 64)
        Me.PictureBox2.TabIndex = 61
        Me.PictureBox2.TabStop = False
        '
        'FrmMovimientosProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1812, 869)
        Me.Controls.Add(Me.LvwMovimientos)
        Me.Controls.Add(Me.LblTotalProcesoPago)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.LblTotalMora)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LblTotalSaldo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupEncabezado)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMovimientosProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos x Proveedor"
        Me.Panel1.ResumeLayout(False)
        Me.GroupEncabezado.ResumeLayout(False)
        Me.GroupEncabezado.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmsMovimientos.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupEncabezado As System.Windows.Forms.GroupBox
    Friend WithEvents LblTotalMora As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTotalSaldo As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTotalProcesoPago As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
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
    Friend WithEvents CmbMovimientoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents BtnPagar As System.Windows.Forms.Button
    Friend WithEvents BtnAgregaMovimiento As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents LstImagenes As System.Windows.Forms.ImageList
    Friend WithEvents CmsMovimientos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuReimprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnEstadoCuenta As System.Windows.Forms.Button
    Friend WithEvents MnuDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnRefrescar As System.Windows.Forms.Button
    Friend WithEvents BtnPagando As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader13 As ColumnHeader
End Class
