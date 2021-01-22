<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPago))
        Me.TxtTarjetaAutorizacion = New System.Windows.Forms.TextBox()
        Me.LblTotalFaltante = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PanelFaltan = New System.Windows.Forms.Panel()
        Me.TxtChequeNumero = New System.Windows.Forms.TextBox()
        Me.CmbBanco = New System.Windows.Forms.ComboBox()
        Me.LblFaltaEtiqueta = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.TxtChequeMonto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RdbCheque = New System.Windows.Forms.RadioButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RdbTarjeta = New System.Windows.Forms.RadioButton()
        Me.RdbEfectivo = New System.Windows.Forms.RadioButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtTarjetaNumero = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbTarjeta = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTarjetaMonto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtEfectivoMonto = New System.Windows.Forms.TextBox()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LvwListaPagos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PicEfectivo = New System.Windows.Forms.PictureBox()
        Me.PanelTiposDePago = New System.Windows.Forms.Panel()
        Me.ChkDolares = New System.Windows.Forms.CheckBox()
        Me.TxtDolaresMonto = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.RdbPuntos = New System.Windows.Forms.RadioButton()
        Me.TxtPuntosMonto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DtpChequeFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblPuntosTitulo = New System.Windows.Forms.Label()
        Me.LblPuntos = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblFacturar = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PicFacturar = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LbDevuelveIVTitle = New System.Windows.Forms.Label()
        Me.LbDevuelveIVMonto = New System.Windows.Forms.Label()
        Me.LblDolaresMonto = New System.Windows.Forms.Label()
        Me.LblDolaresTitulo = New System.Windows.Forms.Label()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PanelFaltan.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTiposDePago.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFacturar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtTarjetaAutorizacion
        '
        Me.TxtTarjetaAutorizacion.Location = New System.Drawing.Point(189, 254)
        Me.TxtTarjetaAutorizacion.MaxLength = 6
        Me.TxtTarjetaAutorizacion.Name = "TxtTarjetaAutorizacion"
        Me.TxtTarjetaAutorizacion.Size = New System.Drawing.Size(66, 20)
        Me.TxtTarjetaAutorizacion.TabIndex = 11
        '
        'LblTotalFaltante
        '
        Me.LblTotalFaltante.BackColor = System.Drawing.Color.White
        Me.LblTotalFaltante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTotalFaltante.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalFaltante.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LblTotalFaltante.Location = New System.Drawing.Point(0, 0)
        Me.LblTotalFaltante.Name = "LblTotalFaltante"
        Me.LblTotalFaltante.Size = New System.Drawing.Size(474, 126)
        Me.LblTotalFaltante.TabIndex = 0
        Me.LblTotalFaltante.Text = "20,000,000.00"
        Me.LblTotalFaltante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(143, 258)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Auto #"
        '
        'PanelFaltan
        '
        Me.PanelFaltan.Controls.Add(Me.LblTotalFaltante)
        Me.PanelFaltan.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelFaltan.Location = New System.Drawing.Point(481, 0)
        Me.PanelFaltan.Name = "PanelFaltan"
        Me.PanelFaltan.Size = New System.Drawing.Size(474, 126)
        Me.PanelFaltan.TabIndex = 29
        '
        'TxtChequeNumero
        '
        Me.TxtChequeNumero.Location = New System.Drawing.Point(71, 401)
        Me.TxtChequeNumero.MaxLength = 20
        Me.TxtChequeNumero.Name = "TxtChequeNumero"
        Me.TxtChequeNumero.Size = New System.Drawing.Size(184, 20)
        Me.TxtChequeNumero.TabIndex = 18
        '
        'CmbBanco
        '
        Me.CmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBanco.FormattingEnabled = True
        Me.CmbBanco.Location = New System.Drawing.Point(71, 336)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(184, 21)
        Me.CmbBanco.TabIndex = 14
        '
        'LblFaltaEtiqueta
        '
        Me.LblFaltaEtiqueta.AutoSize = True
        Me.LblFaltaEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFaltaEtiqueta.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LblFaltaEtiqueta.Location = New System.Drawing.Point(6, 32)
        Me.LblFaltaEtiqueta.Name = "LblFaltaEtiqueta"
        Me.LblFaltaEtiqueta.Size = New System.Drawing.Size(135, 55)
        Me.LblFaltaEtiqueta.TabIndex = 30
        Me.LblFaltaEtiqueta.Text = "Falta"
        Me.LblFaltaEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(10, 404)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Número"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(10, 339)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Banco"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.White
        Me.BtnAgregar.Location = New System.Drawing.Point(10, 563)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(245, 37)
        Me.BtnAgregar.TabIndex = 31
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'TxtChequeMonto
        '
        Me.TxtChequeMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChequeMonto.Location = New System.Drawing.Point(71, 366)
        Me.TxtChequeMonto.Name = "TxtChequeMonto"
        Me.TxtChequeMonto.Size = New System.Drawing.Size(184, 29)
        Me.TxtChequeMonto.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 369)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Monto"
        '
        'RdbCheque
        '
        Me.RdbCheque.AutoSize = True
        Me.RdbCheque.ForeColor = System.Drawing.Color.White
        Me.RdbCheque.Location = New System.Drawing.Point(10, 300)
        Me.RdbCheque.Name = "RdbCheque"
        Me.RdbCheque.Size = New System.Drawing.Size(163, 17)
        Me.RdbCheque.TabIndex = 12
        Me.RdbCheque.Text = "Cheque/Transferencia (Alt-C)"
        Me.RdbCheque.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 630)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1368, 22)
        Me.StatusStrip1.TabIndex = 27
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'RdbTarjeta
        '
        Me.RdbTarjeta.AutoSize = True
        Me.RdbTarjeta.ForeColor = System.Drawing.Color.White
        Me.RdbTarjeta.Location = New System.Drawing.Point(10, 153)
        Me.RdbTarjeta.Name = "RdbTarjeta"
        Me.RdbTarjeta.Size = New System.Drawing.Size(89, 17)
        Me.RdbTarjeta.TabIndex = 3
        Me.RdbTarjeta.Text = "Tarjeta (Alt-T)"
        Me.RdbTarjeta.UseVisualStyleBackColor = True
        '
        'RdbEfectivo
        '
        Me.RdbEfectivo.AutoSize = True
        Me.RdbEfectivo.Checked = True
        Me.RdbEfectivo.ForeColor = System.Drawing.Color.White
        Me.RdbEfectivo.Location = New System.Drawing.Point(10, 27)
        Me.RdbEfectivo.Name = "RdbEfectivo"
        Me.RdbEfectivo.Size = New System.Drawing.Size(95, 17)
        Me.RdbEfectivo.TabIndex = 0
        Me.RdbEfectivo.TabStop = True
        Me.RdbEfectivo.Text = "Efectivo (Alt-E)"
        Me.RdbEfectivo.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(223, 300)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 20
        Me.PictureBox2.TabStop = False
        '
        'TxtTarjetaNumero
        '
        Me.TxtTarjetaNumero.Location = New System.Drawing.Point(71, 254)
        Me.TxtTarjetaNumero.MaxLength = 16
        Me.TxtTarjetaNumero.Name = "TxtTarjetaNumero"
        Me.TxtTarjetaNumero.Size = New System.Drawing.Size(66, 20)
        Me.TxtTarjetaNumero.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 258)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tarjeta #"
        '
        'CmbTarjeta
        '
        Me.CmbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTarjeta.FormattingEnabled = True
        Me.CmbTarjeta.Location = New System.Drawing.Point(71, 189)
        Me.CmbTarjeta.Name = "CmbTarjeta"
        Me.CmbTarjeta.Size = New System.Drawing.Size(184, 21)
        Me.CmbTarjeta.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tarjeta"
        '
        'TxtTarjetaMonto
        '
        Me.TxtTarjetaMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTarjetaMonto.Location = New System.Drawing.Point(71, 219)
        Me.TxtTarjetaMonto.Name = "TxtTarjetaMonto"
        Me.TxtTarjetaMonto.Size = New System.Drawing.Size(184, 29)
        Me.TxtTarjetaMonto.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 223)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Monto"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(223, 153)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Colones"
        '
        'TxtEfectivoMonto
        '
        Me.TxtEfectivoMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEfectivoMonto.Location = New System.Drawing.Point(71, 102)
        Me.TxtEfectivoMonto.Name = "TxtEfectivoMonto"
        Me.TxtEfectivoMonto.Size = New System.Drawing.Size(184, 29)
        Me.TxtEfectivoMonto.TabIndex = 0
        '
        'LvwListaPagos
        '
        Me.LvwListaPagos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12})
        Me.LvwListaPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwListaPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwListaPagos.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.LvwListaPagos.FullRowSelect = True
        Me.LvwListaPagos.HideSelection = False
        Me.LvwListaPagos.Location = New System.Drawing.Point(3, 16)
        Me.LvwListaPagos.Name = "LvwListaPagos"
        Me.LvwListaPagos.Size = New System.Drawing.Size(1089, 485)
        Me.LvwListaPagos.TabIndex = 0
        Me.LvwListaPagos.UseCompatibleStateImageBehavior = False
        Me.LvwListaPagos.View = System.Windows.Forms.View.Details
        '
        'PicEfectivo
        '
        Me.PicEfectivo.Image = CType(resources.GetObject("PicEfectivo.Image"), System.Drawing.Image)
        Me.PicEfectivo.Location = New System.Drawing.Point(223, 27)
        Me.PicEfectivo.Name = "PicEfectivo"
        Me.PicEfectivo.Size = New System.Drawing.Size(32, 30)
        Me.PicEfectivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicEfectivo.TabIndex = 0
        Me.PicEfectivo.TabStop = False
        '
        'PanelTiposDePago
        '
        Me.PanelTiposDePago.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PanelTiposDePago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTiposDePago.Controls.Add(Me.ChkDolares)
        Me.PanelTiposDePago.Controls.Add(Me.TxtDolaresMonto)
        Me.PanelTiposDePago.Controls.Add(Me.Label16)
        Me.PanelTiposDePago.Controls.Add(Me.RdbPuntos)
        Me.PanelTiposDePago.Controls.Add(Me.TxtPuntosMonto)
        Me.PanelTiposDePago.Controls.Add(Me.Label12)
        Me.PanelTiposDePago.Controls.Add(Me.PictureBox5)
        Me.PanelTiposDePago.Controls.Add(Me.Label11)
        Me.PanelTiposDePago.Controls.Add(Me.DtpChequeFecha)
        Me.PanelTiposDePago.Controls.Add(Me.TxtTarjetaAutorizacion)
        Me.PanelTiposDePago.Controls.Add(Me.RdbEfectivo)
        Me.PanelTiposDePago.Controls.Add(Me.BtnAgregar)
        Me.PanelTiposDePago.Controls.Add(Me.TxtChequeNumero)
        Me.PanelTiposDePago.Controls.Add(Me.TxtEfectivoMonto)
        Me.PanelTiposDePago.Controls.Add(Me.Label8)
        Me.PanelTiposDePago.Controls.Add(Me.Label5)
        Me.PanelTiposDePago.Controls.Add(Me.Label1)
        Me.PanelTiposDePago.Controls.Add(Me.PicEfectivo)
        Me.PanelTiposDePago.Controls.Add(Me.CmbBanco)
        Me.PanelTiposDePago.Controls.Add(Me.PictureBox1)
        Me.PanelTiposDePago.Controls.Add(Me.CmbTarjeta)
        Me.PanelTiposDePago.Controls.Add(Me.Label6)
        Me.PanelTiposDePago.Controls.Add(Me.Label3)
        Me.PanelTiposDePago.Controls.Add(Me.Label4)
        Me.PanelTiposDePago.Controls.Add(Me.TxtChequeMonto)
        Me.PanelTiposDePago.Controls.Add(Me.TxtTarjetaMonto)
        Me.PanelTiposDePago.Controls.Add(Me.TxtTarjetaNumero)
        Me.PanelTiposDePago.Controls.Add(Me.Label7)
        Me.PanelTiposDePago.Controls.Add(Me.Label2)
        Me.PanelTiposDePago.Controls.Add(Me.RdbTarjeta)
        Me.PanelTiposDePago.Controls.Add(Me.RdbCheque)
        Me.PanelTiposDePago.Controls.Add(Me.PictureBox2)
        Me.PanelTiposDePago.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelTiposDePago.Location = New System.Drawing.Point(0, 0)
        Me.PanelTiposDePago.Name = "PanelTiposDePago"
        Me.PanelTiposDePago.Size = New System.Drawing.Size(273, 630)
        Me.PanelTiposDePago.TabIndex = 25
        '
        'ChkDolares
        '
        Me.ChkDolares.AutoSize = True
        Me.ChkDolares.Location = New System.Drawing.Point(240, 74)
        Me.ChkDolares.Name = "ChkDolares"
        Me.ChkDolares.Size = New System.Drawing.Size(15, 14)
        Me.ChkDolares.TabIndex = 1
        Me.ChkDolares.UseVisualStyleBackColor = True
        '
        'TxtDolaresMonto
        '
        Me.TxtDolaresMonto.BackColor = System.Drawing.Color.White
        Me.TxtDolaresMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDolaresMonto.Location = New System.Drawing.Point(71, 67)
        Me.TxtDolaresMonto.Name = "TxtDolaresMonto"
        Me.TxtDolaresMonto.ReadOnly = True
        Me.TxtDolaresMonto.Size = New System.Drawing.Size(163, 29)
        Me.TxtDolaresMonto.TabIndex = 63
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(10, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 64
        Me.Label16.Text = "Dólares"
        '
        'RdbPuntos
        '
        Me.RdbPuntos.AutoSize = True
        Me.RdbPuntos.ForeColor = System.Drawing.Color.White
        Me.RdbPuntos.Location = New System.Drawing.Point(10, 477)
        Me.RdbPuntos.Name = "RdbPuntos"
        Me.RdbPuntos.Size = New System.Drawing.Size(89, 17)
        Me.RdbPuntos.TabIndex = 61
        Me.RdbPuntos.Text = "Puntos (Alt-P)"
        Me.RdbPuntos.UseVisualStyleBackColor = True
        '
        'TxtPuntosMonto
        '
        Me.TxtPuntosMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPuntosMonto.Location = New System.Drawing.Point(71, 513)
        Me.TxtPuntosMonto.Name = "TxtPuntosMonto"
        Me.TxtPuntosMonto.Size = New System.Drawing.Size(184, 29)
        Me.TxtPuntosMonto.TabIndex = 60
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(10, 513)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Monto"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(223, 477)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 59
        Me.PictureBox5.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(10, 433)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Fecha"
        '
        'DtpChequeFecha
        '
        Me.DtpChequeFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpChequeFecha.Location = New System.Drawing.Point(71, 427)
        Me.DtpChequeFecha.Name = "DtpChequeFecha"
        Me.DtpChequeFecha.Size = New System.Drawing.Size(184, 20)
        Me.DtpChequeFecha.TabIndex = 55
        '
        'LblPuntosTitulo
        '
        Me.LblPuntosTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblPuntosTitulo.AutoSize = True
        Me.LblPuntosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPuntosTitulo.ForeColor = System.Drawing.Color.White
        Me.LblPuntosTitulo.Location = New System.Drawing.Point(3, 39)
        Me.LblPuntosTitulo.Name = "LblPuntosTitulo"
        Me.LblPuntosTitulo.Size = New System.Drawing.Size(86, 24)
        Me.LblPuntosTitulo.TabIndex = 58
        Me.LblPuntosTitulo.Text = "Puntos :"
        Me.LblPuntosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblPuntosTitulo.Visible = False
        '
        'LblPuntos
        '
        Me.LblPuntos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblPuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPuntos.ForeColor = System.Drawing.Color.White
        Me.LblPuntos.Location = New System.Drawing.Point(95, 40)
        Me.LblPuntos.Name = "LblPuntos"
        Me.LblPuntos.Size = New System.Drawing.Size(68, 23)
        Me.LblPuntos.TabIndex = 57
        Me.LblPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblPuntos.Visible = False
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1037, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Salir"
        '
        'LblFacturar
        '
        Me.LblFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFacturar.AutoSize = True
        Me.LblFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFacturar.ForeColor = System.Drawing.Color.White
        Me.LblFacturar.Location = New System.Drawing.Point(916, 71)
        Me.LblFacturar.Name = "LblFacturar"
        Me.LblFacturar.Size = New System.Drawing.Size(54, 13)
        Me.LblFacturar.TabIndex = 53
        Me.LblFacturar.Text = "Facturar"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.PictureBox4.Location = New System.Drawing.Point(1030, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(49, 49)
        Me.PictureBox4.TabIndex = 52
        Me.PictureBox4.TabStop = False
        '
        'PicFacturar
        '
        Me.PicFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicFacturar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.PicFacturar.Location = New System.Drawing.Point(920, 19)
        Me.PicFacturar.Name = "PicFacturar"
        Me.PicFacturar.Size = New System.Drawing.Size(49, 49)
        Me.PicFacturar.TabIndex = 51
        Me.PicFacturar.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.LvwListaPagos)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(273, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1095, 504)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'PicLogo
        '
        Me.PicLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.PicLogo.Location = New System.Drawing.Point(955, 0)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(140, 126)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 34
        Me.PicLogo.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LbDevuelveIVTitle)
        Me.Panel1.Controls.Add(Me.LbDevuelveIVMonto)
        Me.Panel1.Controls.Add(Me.LblDolaresMonto)
        Me.Panel1.Controls.Add(Me.LblDolaresTitulo)
        Me.Panel1.Controls.Add(Me.LblTipoCambio)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.PictureBox6)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.PicFacturar)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.LblFacturar)
        Me.Panel1.Controls.Add(Me.LblPuntosTitulo)
        Me.Panel1.Controls.Add(Me.LblPuntos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(273, 535)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1095, 95)
        Me.Panel1.TabIndex = 35
        '
        'LbDevuelveIVTitle
        '
        Me.LbDevuelveIVTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LbDevuelveIVTitle.AutoSize = True
        Me.LbDevuelveIVTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbDevuelveIVTitle.ForeColor = System.Drawing.Color.White
        Me.LbDevuelveIVTitle.Location = New System.Drawing.Point(514, 39)
        Me.LbDevuelveIVTitle.Name = "LbDevuelveIVTitle"
        Me.LbDevuelveIVTitle.Size = New System.Drawing.Size(206, 24)
        Me.LbDevuelveIVTitle.TabIndex = 66
        Me.LbDevuelveIVTitle.Text = "Devuelve impuesto : "
        Me.LbDevuelveIVTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LbDevuelveIVTitle.Visible = False
        '
        'LbDevuelveIVMonto
        '
        Me.LbDevuelveIVMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LbDevuelveIVMonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.LbDevuelveIVMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbDevuelveIVMonto.ForeColor = System.Drawing.Color.White
        Me.LbDevuelveIVMonto.Location = New System.Drawing.Point(716, 39)
        Me.LbDevuelveIVMonto.Name = "LbDevuelveIVMonto"
        Me.LbDevuelveIVMonto.Size = New System.Drawing.Size(95, 23)
        Me.LbDevuelveIVMonto.TabIndex = 65
        Me.LbDevuelveIVMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LbDevuelveIVMonto.Visible = False
        '
        'LblDolaresMonto
        '
        Me.LblDolaresMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblDolaresMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDolaresMonto.ForeColor = System.Drawing.Color.PaleGreen
        Me.LblDolaresMonto.Location = New System.Drawing.Point(410, 40)
        Me.LblDolaresMonto.Name = "LblDolaresMonto"
        Me.LblDolaresMonto.Size = New System.Drawing.Size(98, 23)
        Me.LblDolaresMonto.TabIndex = 64
        Me.LblDolaresMonto.Text = "0.00"
        Me.LblDolaresMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblDolaresMonto.Visible = False
        '
        'LblDolaresTitulo
        '
        Me.LblDolaresTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblDolaresTitulo.AutoSize = True
        Me.LblDolaresTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDolaresTitulo.ForeColor = System.Drawing.Color.PaleGreen
        Me.LblDolaresTitulo.Location = New System.Drawing.Point(311, 39)
        Me.LblDolaresTitulo.Name = "LblDolaresTitulo"
        Me.LblDolaresTitulo.Size = New System.Drawing.Size(93, 24)
        Me.LblDolaresTitulo.TabIndex = 63
        Me.LblDolaresTitulo.Text = "Dólares :"
        Me.LblDolaresTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblDolaresTitulo.Visible = False
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.White
        Me.LblTipoCambio.Location = New System.Drawing.Point(224, 40)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(81, 23)
        Me.LblTipoCambio.TabIndex = 62
        Me.LblTipoCambio.Text = "560.99"
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(169, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 24)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "TC :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F1
        Me.PictureBox6.Location = New System.Drawing.Point(974, 18)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(49, 49)
        Me.PictureBox6.TabIndex = 59
        Me.PictureBox6.TabStop = False
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(982, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 60
        Me.Label13.Text = "Calc"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PanelFaltan)
        Me.Panel2.Controls.Add(Me.PicLogo)
        Me.Panel2.Controls.Add(Me.LblFaltaEtiqueta)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(273, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1095, 126)
        Me.Panel2.TabIndex = 36
        '
        'FrmPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1368, 652)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PanelTiposDePago)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPago"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago de Factura"
        Me.PanelFaltan.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTiposDePago.ResumeLayout(False)
        Me.PanelTiposDePago.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicFacturar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtTarjetaAutorizacion As System.Windows.Forms.TextBox
    Friend WithEvents LblTotalFaltante As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PanelFaltan As System.Windows.Forms.Panel
    Friend WithEvents TxtChequeNumero As System.Windows.Forms.TextBox
    Friend WithEvents CmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents LblFaltaEtiqueta As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents TxtChequeMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RdbCheque As System.Windows.Forms.RadioButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents RdbTarjeta As System.Windows.Forms.RadioButton
    Friend WithEvents RdbEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtTarjetaNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbTarjeta As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTarjetaMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtEfectivoMonto As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LvwListaPagos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PicEfectivo As System.Windows.Forms.PictureBox
    Friend WithEvents PanelTiposDePago As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblFacturar As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PicFacturar As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DtpChequeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblPuntos As System.Windows.Forms.Label
    Friend WithEvents LblPuntosTitulo As System.Windows.Forms.Label
    Friend WithEvents RdbPuntos As System.Windows.Forms.RadioButton
    Friend WithEvents TxtPuntosMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblTipoCambio As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TxtDolaresMonto As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents ChkDolares As CheckBox
    Friend WithEvents LblDolaresMonto As Label
    Friend WithEvents LblDolaresTitulo As Label
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LbDevuelveIVTitle As Label
    Friend WithEvents LbDevuelveIVMonto As Label
End Class
