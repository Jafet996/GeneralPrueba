<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMovimientosCliente
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovimientosCliente))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnMovimiento = New System.Windows.Forms.Button()
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.BtnEstadoCuenta = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnMora = New System.Windows.Forms.Button()
        Me.BtnPagar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupEncabezado = New System.Windows.Forms.GroupBox()
        Me.CmbFiltro = New System.Windows.Forms.ComboBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.BtnAgregaMovimiento = New System.Windows.Forms.Button()
        Me.CmbMovimientoTipo = New System.Windows.Forms.ComboBox()
        Me.TxtClienteNombre = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblTotalMora = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblTotalSaldo = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblTotalCreditos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblTotalDebitos = New System.Windows.Forms.Label()
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
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CmsMovimientos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuReimprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.LstImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupEncabezado.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmsMovimientos.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnMovimiento)
        Me.Panel1.Controls.Add(Me.BtnRefrescar)
        Me.Panel1.Controls.Add(Me.BtnEstadoCuenta)
        Me.Panel1.Controls.Add(Me.BtnBuscar)
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnMora)
        Me.Panel1.Controls.Add(Me.BtnPagar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(107, 783)
        Me.Panel1.TabIndex = 2
        '
        'BtnMovimiento
        '
        Me.BtnMovimiento.BackColor = System.Drawing.Color.White
        Me.BtnMovimiento.Image = Global.SDCXC.My.Resources.Resources.Blue_F6
        Me.BtnMovimiento.Location = New System.Drawing.Point(11, 485)
        Me.BtnMovimiento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnMovimiento.Name = "BtnMovimiento"
        Me.BtnMovimiento.Size = New System.Drawing.Size(85, 87)
        Me.BtnMovimiento.TabIndex = 16
        Me.BtnMovimiento.Text = "Movimient"
        Me.BtnMovimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnMovimiento.UseVisualStyleBackColor = False
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.BackColor = System.Drawing.Color.White
        Me.BtnRefrescar.Image = Global.SDCXC.My.Resources.Resources.Blue_F5
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
        Me.BtnEstadoCuenta.Image = Global.SDCXC.My.Resources.Resources.Blue_F4
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
        Me.BtnBuscar.Image = Global.SDCXC.My.Resources.Resources.Blue_F1
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
        Me.BtnLimpiar.Image = Global.SDCXC.My.Resources.Resources.Blue_F12
        Me.BtnLimpiar.Location = New System.Drawing.Point(11, 580)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(85, 87)
        Me.BtnLimpiar.TabIndex = 12
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnMora
        '
        Me.BtnMora.BackColor = System.Drawing.Color.White
        Me.BtnMora.Image = Global.SDCXC.My.Resources.Resources.Blue_F31
        Me.BtnMora.Location = New System.Drawing.Point(11, 201)
        Me.BtnMora.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnMora.Name = "BtnMora"
        Me.BtnMora.Size = New System.Drawing.Size(85, 87)
        Me.BtnMora.TabIndex = 11
        Me.BtnMora.Text = "Mora"
        Me.BtnMora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnMora.UseVisualStyleBackColor = False
        '
        'BtnPagar
        '
        Me.BtnPagar.BackColor = System.Drawing.Color.White
        Me.BtnPagar.Image = Global.SDCXC.My.Resources.Resources.Blue_F2
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
        Me.BtnSalir.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(11, 674)
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
        Me.GroupEncabezado.Controls.Add(Me.TxtClienteNombre)
        Me.GroupEncabezado.Controls.Add(Me.TxtCliente)
        Me.GroupEncabezado.Controls.Add(Me.Label8)
        Me.GroupEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupEncabezado.Location = New System.Drawing.Point(107, 0)
        Me.GroupEncabezado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupEncabezado.Name = "GroupEncabezado"
        Me.GroupEncabezado.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupEncabezado.Size = New System.Drawing.Size(1693, 116)
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
        Me.CmbFiltro.Items.AddRange(New Object() {"Todo", "Pendientes", "Debitos", "Créditos"})
        Me.CmbFiltro.Location = New System.Drawing.Point(1037, 44)
        Me.CmbFiltro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbFiltro.Name = "CmbFiltro"
        Me.CmbFiltro.Size = New System.Drawing.Size(241, 38)
        Me.CmbFiltro.TabIndex = 69
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.SDCXC.My.Resources.Resources.user1
        Me.PictureBox5.Location = New System.Drawing.Point(40, 32)
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
        Me.BtnAgregaMovimiento.Image = Global.SDCXC.My.Resources.Resources.add
        Me.BtnAgregaMovimiento.Location = New System.Drawing.Point(1593, 44)
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
        Me.CmbMovimientoTipo.Location = New System.Drawing.Point(1332, 44)
        Me.CmbMovimientoTipo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbMovimientoTipo.Name = "CmbMovimientoTipo"
        Me.CmbMovimientoTipo.Size = New System.Drawing.Size(223, 38)
        Me.CmbMovimientoTipo.TabIndex = 66
        '
        'TxtClienteNombre
        '
        Me.TxtClienteNombre.BackColor = System.Drawing.Color.White
        Me.TxtClienteNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClienteNombre.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtClienteNombre.Location = New System.Drawing.Point(392, 44)
        Me.TxtClienteNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtClienteNombre.Name = "TxtClienteNombre"
        Me.TxtClienteNombre.ReadOnly = True
        Me.TxtClienteNombre.Size = New System.Drawing.Size(623, 37)
        Me.TxtClienteNombre.TabIndex = 1
        Me.TxtClienteNombre.TabStop = False
        '
        'TxtCliente
        '
        Me.TxtCliente.BackColor = System.Drawing.Color.White
        Me.TxtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtCliente.Location = New System.Drawing.Point(220, 44)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(163, 37)
        Me.TxtCliente.TabIndex = 0
        Me.TxtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(97, 48)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 31)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Cliente"
        '
        'LblTotalMora
        '
        Me.LblTotalMora.BackColor = System.Drawing.Color.White
        Me.LblTotalMora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalMora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMora.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalMora.Location = New System.Drawing.Point(194, 20)
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
        Me.Label3.Location = New System.Drawing.Point(19, 23)
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
        Me.LblTotalSaldo.Location = New System.Drawing.Point(1442, 24)
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
        Me.Label12.Location = New System.Drawing.Point(1267, 23)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 31)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Saldo"
        '
        'LblTotalCreditos
        '
        Me.LblTotalCreditos.BackColor = System.Drawing.Color.White
        Me.LblTotalCreditos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalCreditos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalCreditos.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalCreditos.Location = New System.Drawing.Point(1026, 20)
        Me.LblTotalCreditos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalCreditos.Name = "LblTotalCreditos"
        Me.LblTotalCreditos.Size = New System.Drawing.Size(211, 36)
        Me.LblTotalCreditos.TabIndex = 69
        Me.LblTotalCreditos.Text = "0.00"
        Me.LblTotalCreditos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(851, 23)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 31)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Créditos"
        '
        'LblTotalDebitos
        '
        Me.LblTotalDebitos.BackColor = System.Drawing.Color.White
        Me.LblTotalDebitos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblTotalDebitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDebitos.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalDebitos.Location = New System.Drawing.Point(610, 20)
        Me.LblTotalDebitos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalDebitos.Name = "LblTotalDebitos"
        Me.LblTotalDebitos.Size = New System.Drawing.Size(211, 36)
        Me.LblTotalDebitos.TabIndex = 72
        Me.LblTotalDebitos.Text = "0.00"
        Me.LblTotalDebitos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(435, 23)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 31)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Débitos"
        '
        'LvwMovimientos
        '
        Me.LvwMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.LvwMovimientos.ContextMenuStrip = Me.CmsMovimientos
        Me.LvwMovimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwMovimientos.FullRowSelect = True
        Me.LvwMovimientos.HideSelection = False
        Me.LvwMovimientos.Location = New System.Drawing.Point(107, 116)
        Me.LvwMovimientos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LvwMovimientos.Name = "LvwMovimientos"
        Me.LvwMovimientos.Size = New System.Drawing.Size(1693, 588)
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
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.SDCXC.My.Resources.Resources.Total3
        Me.PictureBox4.Location = New System.Drawing.Point(422, 7)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(412, 64)
        Me.PictureBox4.TabIndex = 70
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.SDCXC.My.Resources.Resources.Total3
        Me.PictureBox3.Location = New System.Drawing.Point(838, 7)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(412, 64)
        Me.PictureBox3.TabIndex = 67
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SDCXC.My.Resources.Resources.Total3
        Me.PictureBox1.Location = New System.Drawing.Point(6, 7)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(412, 64)
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDCXC.My.Resources.Resources.Total3
        Me.PictureBox2.Location = New System.Drawing.Point(1254, 7)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(412, 64)
        Me.PictureBox2.TabIndex = 61
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LblTotalMora)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.LblTotalSaldo)
        Me.Panel2.Controls.Add(Me.LblTotalDebitos)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.LblTotalCreditos)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(107, 704)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1693, 79)
        Me.Panel2.TabIndex = 73
        '
        'FrmMovimientosCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1800, 783)
        Me.Controls.Add(Me.LvwMovimientos)
        Me.Controls.Add(Me.GroupEncabezado)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMovimientosCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos x Cliente"
        Me.Panel1.ResumeLayout(False)
        Me.GroupEncabezado.ResumeLayout(False)
        Me.GroupEncabezado.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmsMovimientos.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents LblTotalCreditos As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTotalDebitos As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtClienteNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
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
    Friend WithEvents BtnMora As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LstImagenes As System.Windows.Forms.ImageList
    Friend WithEvents CmsMovimientos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuReimprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnEstadoCuenta As System.Windows.Forms.Button
    Friend WithEvents MnuDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnRefrescar As System.Windows.Forms.Button
    Friend WithEvents BtnMovimiento As Button
    Friend WithEvents Panel2 As Panel
End Class
