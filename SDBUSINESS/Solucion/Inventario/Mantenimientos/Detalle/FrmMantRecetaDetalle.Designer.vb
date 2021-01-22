<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMantRecetaDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantRecetaDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCosto = New System.Windows.Forms.Button()
        Me.BtnPrecio = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtUtilidadActual = New System.Windows.Forms.TextBox()
        Me.TxtPrecioActual = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PicPrecio = New System.Windows.Forms.PictureBox()
        Me.TxtCostoActual = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtCostoCalculado = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.TxtUtilidadCalculada = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PnlMateriaPrima = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtCostoMateriaPrima = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtMateriaPrima = New System.Windows.Forms.TextBox()
        Me.TxtNombreMateriaPrima = New System.Windows.Forms.TextBox()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.TxtPrecioIVIActual = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlMateriaPrima.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnCosto)
        Me.Panel1.Controls.Add(Me.BtnPrecio)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(85, 632)
        Me.Panel1.TabIndex = 16
        '
        'BtnCosto
        '
        Me.BtnCosto.BackColor = System.Drawing.Color.White
        Me.BtnCosto.Image = Global.Inventario.My.Resources.Resources.Blue_F5
        Me.BtnCosto.Location = New System.Drawing.Point(11, 93)
        Me.BtnCosto.Name = "BtnCosto"
        Me.BtnCosto.Size = New System.Drawing.Size(64, 72)
        Me.BtnCosto.TabIndex = 11
        Me.BtnCosto.Text = "Costo"
        Me.BtnCosto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCosto.UseVisualStyleBackColor = False
        '
        'BtnPrecio
        '
        Me.BtnPrecio.BackColor = System.Drawing.Color.White
        Me.BtnPrecio.Image = Global.Inventario.My.Resources.Resources.Blue_F6
        Me.BtnPrecio.Location = New System.Drawing.Point(11, 171)
        Me.BtnPrecio.Name = "BtnPrecio"
        Me.BtnPrecio.Size = New System.Drawing.Size(62, 72)
        Me.BtnPrecio.TabIndex = 10
        Me.BtnPrecio.TabStop = False
        Me.BtnPrecio.Text = "Precio"
        Me.BtnPrecio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnPrecio.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(11, 249)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(62, 72)
        Me.BtnSalir.TabIndex = 9
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnGuardar.Location = New System.Drawing.Point(11, 15)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(62, 72)
        Me.BtnGuardar.TabIndex = 8
        Me.BtnGuardar.TabStop = False
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'DGDetalle
        '
        Me.DGDetalle.AllowUserToAddRows = False
        Me.DGDetalle.AllowUserToDeleteRows = False
        Me.DGDetalle.BackgroundColor = System.Drawing.Color.White
        Me.DGDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Nombre, Me.Cantidad, Me.Costo, Me.Total})
        Me.DGDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGDetalle.Location = New System.Drawing.Point(0, 57)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGDetalle.Size = New System.Drawing.Size(909, 450)
        Me.DGDetalle.TabIndex = 7
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 120
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 420
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        '
        'Costo
        '
        Me.Costo.HeaderText = "Costo"
        Me.Costo.Name = "Costo"
        Me.Costo.ReadOnly = True
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtPrecioIVIActual)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.PictureBox5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TxtUtilidadActual)
        Me.GroupBox1.Controls.Add(Me.TxtPrecioActual)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.PicPrecio)
        Me.GroupBox1.Controls.Add(Me.TxtCostoActual)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtCostoCalculado)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.TxtUtilidadCalculada)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(85, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(909, 119)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label9.Location = New System.Drawing.Point(35, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 20)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Calculado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Location = New System.Drawing.Point(35, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 20)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Actual"
        '
        'TxtUtilidadActual
        '
        Me.TxtUtilidadActual.BackColor = System.Drawing.Color.White
        Me.TxtUtilidadActual.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUtilidadActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUtilidadActual.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtUtilidadActual.Location = New System.Drawing.Point(518, 28)
        Me.TxtUtilidadActual.MaxLength = 30
        Me.TxtUtilidadActual.Name = "TxtUtilidadActual"
        Me.TxtUtilidadActual.ReadOnly = True
        Me.TxtUtilidadActual.Size = New System.Drawing.Size(117, 19)
        Me.TxtUtilidadActual.TabIndex = 39
        Me.TxtUtilidadActual.TabStop = False
        Me.TxtUtilidadActual.Text = "0.00"
        Me.TxtUtilidadActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPrecioActual
        '
        Me.TxtPrecioActual.BackColor = System.Drawing.Color.White
        Me.TxtPrecioActual.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrecioActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecioActual.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtPrecioActual.Location = New System.Drawing.Point(754, 28)
        Me.TxtPrecioActual.MaxLength = 30
        Me.TxtPrecioActual.Name = "TxtPrecioActual"
        Me.TxtPrecioActual.ReadOnly = True
        Me.TxtPrecioActual.Size = New System.Drawing.Size(114, 19)
        Me.TxtPrecioActual.TabIndex = 28
        Me.TxtPrecioActual.TabStop = False
        Me.TxtPrecioActual.Text = "0.00"
        Me.TxtPrecioActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(655, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Precio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(421, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 20)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "%Utilidad"
        '
        'PicPrecio
        '
        Me.PicPrecio.Image = Global.Inventario.My.Resources.Resources.Total6
        Me.PicPrecio.Location = New System.Drawing.Point(647, 17)
        Me.PicPrecio.Name = "PicPrecio"
        Me.PicPrecio.Size = New System.Drawing.Size(232, 40)
        Me.PicPrecio.TabIndex = 33
        Me.PicPrecio.TabStop = False
        '
        'TxtCostoActual
        '
        Me.TxtCostoActual.BackColor = System.Drawing.Color.White
        Me.TxtCostoActual.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCostoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCostoActual.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtCostoActual.Location = New System.Drawing.Point(285, 28)
        Me.TxtCostoActual.MaxLength = 30
        Me.TxtCostoActual.Name = "TxtCostoActual"
        Me.TxtCostoActual.ReadOnly = True
        Me.TxtCostoActual.Size = New System.Drawing.Size(115, 19)
        Me.TxtCostoActual.TabIndex = 37
        Me.TxtCostoActual.TabStop = False
        Me.TxtCostoActual.Text = "0.00"
        Me.TxtCostoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(184, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 20)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Costo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(184, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 20)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Costo"
        '
        'TxtCostoCalculado
        '
        Me.TxtCostoCalculado.BackColor = System.Drawing.Color.White
        Me.TxtCostoCalculado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCostoCalculado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCostoCalculado.ForeColor = System.Drawing.Color.DarkGreen
        Me.TxtCostoCalculado.Location = New System.Drawing.Point(285, 71)
        Me.TxtCostoCalculado.MaxLength = 30
        Me.TxtCostoCalculado.Name = "TxtCostoCalculado"
        Me.TxtCostoCalculado.ReadOnly = True
        Me.TxtCostoCalculado.Size = New System.Drawing.Size(115, 19)
        Me.TxtCostoCalculado.TabIndex = 30
        Me.TxtCostoCalculado.TabStop = False
        Me.TxtCostoCalculado.Text = "0.00"
        Me.TxtCostoCalculado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Inventario.My.Resources.Resources.Total6
        Me.PictureBox3.Location = New System.Drawing.Point(178, 17)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(232, 40)
        Me.PictureBox3.TabIndex = 40
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.Inventario.My.Resources.Resources.Total6
        Me.PictureBox4.Location = New System.Drawing.Point(412, 17)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(232, 40)
        Me.PictureBox4.TabIndex = 41
        Me.PictureBox4.TabStop = False
        '
        'TxtUtilidadCalculada
        '
        Me.TxtUtilidadCalculada.BackColor = System.Drawing.Color.White
        Me.TxtUtilidadCalculada.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUtilidadCalculada.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUtilidadCalculada.ForeColor = System.Drawing.Color.DarkGreen
        Me.TxtUtilidadCalculada.Location = New System.Drawing.Point(518, 71)
        Me.TxtUtilidadCalculada.MaxLength = 30
        Me.TxtUtilidadCalculada.Name = "TxtUtilidadCalculada"
        Me.TxtUtilidadCalculada.ReadOnly = True
        Me.TxtUtilidadCalculada.Size = New System.Drawing.Size(117, 19)
        Me.TxtUtilidadCalculada.TabIndex = 32
        Me.TxtUtilidadCalculada.TabStop = False
        Me.TxtUtilidadCalculada.Text = "0.00"
        Me.TxtUtilidadCalculada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label4.Location = New System.Drawing.Point(421, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "%Utilidad"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Inventario.My.Resources.Resources.Total6
        Me.PictureBox2.Location = New System.Drawing.Point(412, 60)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(232, 40)
        Me.PictureBox2.TabIndex = 35
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Inventario.My.Resources.Resources.Total6
        Me.PictureBox1.Location = New System.Drawing.Point(178, 60)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(232, 40)
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'PnlMateriaPrima
        '
        Me.PnlMateriaPrima.Controls.Add(Me.GroupBox2)
        Me.PnlMateriaPrima.Controls.Add(Me.BtnAgregar)
        Me.PnlMateriaPrima.Controls.Add(Me.DGDetalle)
        Me.PnlMateriaPrima.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlMateriaPrima.Location = New System.Drawing.Point(85, 125)
        Me.PnlMateriaPrima.Name = "PnlMateriaPrima"
        Me.PnlMateriaPrima.Size = New System.Drawing.Size(909, 507)
        Me.PnlMateriaPrima.TabIndex = 33
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtCostoMateriaPrima)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtCantidad)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TxtMateriaPrima)
        Me.GroupBox2.Controls.Add(Me.TxtNombreMateriaPrima)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(824, 48)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        '
        'TxtCostoMateriaPrima
        '
        Me.TxtCostoMateriaPrima.BackColor = System.Drawing.Color.White
        Me.TxtCostoMateriaPrima.ForeColor = System.Drawing.Color.Black
        Me.TxtCostoMateriaPrima.Location = New System.Drawing.Point(734, 16)
        Me.TxtCostoMateriaPrima.MaxLength = 30
        Me.TxtCostoMateriaPrima.Name = "TxtCostoMateriaPrima"
        Me.TxtCostoMateriaPrima.ReadOnly = True
        Me.TxtCostoMateriaPrima.Size = New System.Drawing.Size(79, 20)
        Me.TxtCostoMateriaPrima.TabIndex = 33
        Me.TxtCostoMateriaPrima.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(694, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Costo"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Enabled = False
        Me.TxtCantidad.Location = New System.Drawing.Point(606, 16)
        Me.TxtCantidad.MaxLength = 30
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(82, 20)
        Me.TxtCantidad.TabIndex = 5
        Me.TxtCantidad.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(551, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Cantidad"
        '
        'TxtMateriaPrima
        '
        Me.TxtMateriaPrima.Location = New System.Drawing.Point(23, 16)
        Me.TxtMateriaPrima.MaxLength = 30
        Me.TxtMateriaPrima.Name = "TxtMateriaPrima"
        Me.TxtMateriaPrima.Size = New System.Drawing.Size(100, 20)
        Me.TxtMateriaPrima.TabIndex = 3
        Me.TxtMateriaPrima.TabStop = False
        '
        'TxtNombreMateriaPrima
        '
        Me.TxtNombreMateriaPrima.BackColor = System.Drawing.Color.White
        Me.TxtNombreMateriaPrima.Location = New System.Drawing.Point(130, 16)
        Me.TxtNombreMateriaPrima.MaxLength = 20
        Me.TxtNombreMateriaPrima.Name = "TxtNombreMateriaPrima"
        Me.TxtNombreMateriaPrima.ReadOnly = True
        Me.TxtNombreMateriaPrima.Size = New System.Drawing.Size(415, 20)
        Me.TxtNombreMateriaPrima.TabIndex = 4
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.White
        Me.BtnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAgregar.Image = Global.Inventario.My.Resources.Resources.add
        Me.BtnAgregar.Location = New System.Drawing.Point(840, 9)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(37, 39)
        Me.BtnAgregar.TabIndex = 6
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'TxtPrecioIVIActual
        '
        Me.TxtPrecioIVIActual.BackColor = System.Drawing.Color.White
        Me.TxtPrecioIVIActual.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrecioIVIActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecioIVIActual.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtPrecioIVIActual.Location = New System.Drawing.Point(754, 71)
        Me.TxtPrecioIVIActual.MaxLength = 30
        Me.TxtPrecioIVIActual.Name = "TxtPrecioIVIActual"
        Me.TxtPrecioIVIActual.ReadOnly = True
        Me.TxtPrecioIVIActual.Size = New System.Drawing.Size(114, 19)
        Me.TxtPrecioIVIActual.TabIndex = 45
        Me.TxtPrecioIVIActual.TabStop = False
        Me.TxtPrecioIVIActual.Text = "0.00"
        Me.TxtPrecioIVIActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.Location = New System.Drawing.Point(655, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 20)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Precio IVI"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.Inventario.My.Resources.Resources.Total6
        Me.PictureBox5.Location = New System.Drawing.Point(647, 60)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(232, 40)
        Me.PictureBox5.TabIndex = 46
        Me.PictureBox5.TabStop = False
        '
        'FrmMantRecetaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(994, 632)
        Me.Controls.Add(Me.PnlMateriaPrima)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantRecetaDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMantRecetaDetalle"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlMateriaPrima.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents DGDetalle As DataGridView
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PnlMateriaPrima As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TxtCantidad As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtMateriaPrima As TextBox
    Friend WithEvents TxtNombreMateriaPrima As TextBox
    Friend WithEvents TxtPrecioActual As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCostoCalculado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtUtilidadCalculada As TextBox
    Friend WithEvents TxtCostoMateriaPrima As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PicPrecio As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Costo As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents BtnPrecio As Button
    Friend WithEvents BtnCosto As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtUtilidadActual As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtCostoActual As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents TxtPrecioIVIActual As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox5 As PictureBox
End Class
