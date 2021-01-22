<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMovimientoPagoFisico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovimientoPagoFisico))
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
        Me.RdbEfectivoColones = New System.Windows.Forms.RadioButton()
        Me.TxtTarjetaNumero = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbTarjeta = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTarjetaMonto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.PanelTiposDePago = New System.Windows.Forms.Panel()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DtpChequeFecha = New System.Windows.Forms.DateTimePicker()
        Me.PicEfectivo = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.BtnFacturar = New System.Windows.Forms.ToolStripButton()
        Me.BtnMuestraCalculadora = New System.Windows.Forms.ToolStripButton()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.PanelFaltan.SuspendLayout()
        Me.PanelTiposDePago.SuspendLayout()
        CType(Me.PicEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtTarjetaAutorizacion
        '
        Me.TxtTarjetaAutorizacion.Location = New System.Drawing.Point(188, 235)
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
        Me.LblTotalFaltante.Size = New System.Drawing.Size(440, 103)
        Me.LblTotalFaltante.TabIndex = 0
        Me.LblTotalFaltante.Text = "0.00"
        Me.LblTotalFaltante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(142, 239)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Auto #"
        '
        'PanelFaltan
        '
        Me.PanelFaltan.Controls.Add(Me.LblTotalFaltante)
        Me.PanelFaltan.Location = New System.Drawing.Point(483, 8)
        Me.PanelFaltan.Name = "PanelFaltan"
        Me.PanelFaltan.Size = New System.Drawing.Size(440, 103)
        Me.PanelFaltan.TabIndex = 29
        '
        'TxtChequeNumero
        '
        Me.TxtChequeNumero.Location = New System.Drawing.Point(70, 396)
        Me.TxtChequeNumero.MaxLength = 20
        Me.TxtChequeNumero.Name = "TxtChequeNumero"
        Me.TxtChequeNumero.Size = New System.Drawing.Size(184, 20)
        Me.TxtChequeNumero.TabIndex = 18
        '
        'CmbBanco
        '
        Me.CmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBanco.FormattingEnabled = True
        Me.CmbBanco.Location = New System.Drawing.Point(70, 331)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(184, 21)
        Me.CmbBanco.TabIndex = 14
        '
        'LblFaltaEtiqueta
        '
        Me.LblFaltaEtiqueta.AutoSize = True
        Me.LblFaltaEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFaltaEtiqueta.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LblFaltaEtiqueta.Location = New System.Drawing.Point(279, 32)
        Me.LblFaltaEtiqueta.Name = "LblFaltaEtiqueta"
        Me.LblFaltaEtiqueta.Size = New System.Drawing.Size(135, 55)
        Me.LblFaltaEtiqueta.TabIndex = 30
        Me.LblFaltaEtiqueta.Text = "Falta"
        Me.LblFaltaEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 399)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Número"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 336)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Banco"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.White
        Me.BtnAgregar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnAgregar.Image = Global.SDCXC.My.Resources.Resources.add
        Me.BtnAgregar.Location = New System.Drawing.Point(9, 641)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(245, 41)
        Me.BtnAgregar.TabIndex = 31
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'TxtChequeMonto
        '
        Me.TxtChequeMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChequeMonto.Location = New System.Drawing.Point(70, 361)
        Me.TxtChequeMonto.Name = "TxtChequeMonto"
        Me.TxtChequeMonto.Size = New System.Drawing.Size(184, 29)
        Me.TxtChequeMonto.TabIndex = 16
        Me.TxtChequeMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 371)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Monto"
        '
        'RdbCheque
        '
        Me.RdbCheque.AutoSize = True
        Me.RdbCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbCheque.ForeColor = System.Drawing.Color.White
        Me.RdbCheque.Location = New System.Drawing.Point(9, 295)
        Me.RdbCheque.Name = "RdbCheque"
        Me.RdbCheque.Size = New System.Drawing.Size(108, 17)
        Me.RdbCheque.TabIndex = 12
        Me.RdbCheque.Text = "Cheque (Alt-C)"
        Me.RdbCheque.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 694)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1072, 22)
        Me.StatusStrip1.TabIndex = 27
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'RdbTarjeta
        '
        Me.RdbTarjeta.AutoSize = True
        Me.RdbTarjeta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbTarjeta.ForeColor = System.Drawing.Color.White
        Me.RdbTarjeta.Location = New System.Drawing.Point(9, 134)
        Me.RdbTarjeta.Name = "RdbTarjeta"
        Me.RdbTarjeta.Size = New System.Drawing.Size(108, 17)
        Me.RdbTarjeta.TabIndex = 3
        Me.RdbTarjeta.Text = "Tarjeta (Alt-T)"
        Me.RdbTarjeta.UseVisualStyleBackColor = True
        '
        'RdbEfectivoColones
        '
        Me.RdbEfectivoColones.AutoSize = True
        Me.RdbEfectivoColones.Checked = True
        Me.RdbEfectivoColones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbEfectivoColones.ForeColor = System.Drawing.Color.White
        Me.RdbEfectivoColones.Location = New System.Drawing.Point(9, 25)
        Me.RdbEfectivoColones.Name = "RdbEfectivoColones"
        Me.RdbEfectivoColones.Size = New System.Drawing.Size(110, 17)
        Me.RdbEfectivoColones.TabIndex = 0
        Me.RdbEfectivoColones.TabStop = True
        Me.RdbEfectivoColones.Text = "Efectivo (Alt-E)"
        Me.RdbEfectivoColones.UseVisualStyleBackColor = True
        '
        'TxtTarjetaNumero
        '
        Me.TxtTarjetaNumero.Location = New System.Drawing.Point(70, 235)
        Me.TxtTarjetaNumero.MaxLength = 16
        Me.TxtTarjetaNumero.Name = "TxtTarjetaNumero"
        Me.TxtTarjetaNumero.Size = New System.Drawing.Size(66, 20)
        Me.TxtTarjetaNumero.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tarjeta #"
        '
        'CmbTarjeta
        '
        Me.CmbTarjeta.BackColor = System.Drawing.Color.White
        Me.CmbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbTarjeta.FormattingEnabled = True
        Me.CmbTarjeta.Location = New System.Drawing.Point(70, 170)
        Me.CmbTarjeta.Name = "CmbTarjeta"
        Me.CmbTarjeta.Size = New System.Drawing.Size(184, 21)
        Me.CmbTarjeta.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tarjeta"
        '
        'TxtTarjetaMonto
        '
        Me.TxtTarjetaMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTarjetaMonto.Location = New System.Drawing.Point(70, 200)
        Me.TxtTarjetaMonto.Name = "TxtTarjetaMonto"
        Me.TxtTarjetaMonto.Size = New System.Drawing.Size(184, 29)
        Me.TxtTarjetaMonto.TabIndex = 7
        Me.TxtTarjetaMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Monto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Monto"
        '
        'TxtEfectivoMonto
        '
        Me.TxtEfectivoMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEfectivoMonto.Location = New System.Drawing.Point(70, 61)
        Me.TxtEfectivoMonto.Name = "TxtEfectivoMonto"
        Me.TxtEfectivoMonto.Size = New System.Drawing.Size(184, 29)
        Me.TxtEfectivoMonto.TabIndex = 0
        Me.TxtEfectivoMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.LvwListaPagos.Size = New System.Drawing.Size(787, 470)
        Me.LvwListaPagos.TabIndex = 0
        Me.LvwListaPagos.UseCompatibleStateImageBehavior = False
        Me.LvwListaPagos.View = System.Windows.Forms.View.Details
        '
        'PanelTiposDePago
        '
        Me.PanelTiposDePago.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelTiposDePago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTiposDePago.Controls.Add(Me.LblTipoCambio)
        Me.PanelTiposDePago.Controls.Add(Me.Label9)
        Me.PanelTiposDePago.Controls.Add(Me.Label11)
        Me.PanelTiposDePago.Controls.Add(Me.DtpChequeFecha)
        Me.PanelTiposDePago.Controls.Add(Me.TxtTarjetaAutorizacion)
        Me.PanelTiposDePago.Controls.Add(Me.RdbEfectivoColones)
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
        Me.PanelTiposDePago.Location = New System.Drawing.Point(0, -3)
        Me.PanelTiposDePago.Name = "PanelTiposDePago"
        Me.PanelTiposDePago.Size = New System.Drawing.Size(273, 715)
        Me.PanelTiposDePago.TabIndex = 25
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.BackColor = System.Drawing.Color.White
        Me.LblTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTipoCambio.Location = New System.Drawing.Point(70, 592)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(184, 29)
        Me.LblTipoCambio.TabIndex = 64
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(9, 602)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 13)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "TC"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(9, 428)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Fecha"
        '
        'DtpChequeFecha
        '
        Me.DtpChequeFecha.CustomFormat = "dd/MM/yyyy"
        Me.DtpChequeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpChequeFecha.Location = New System.Drawing.Point(70, 422)
        Me.DtpChequeFecha.Name = "DtpChequeFecha"
        Me.DtpChequeFecha.Size = New System.Drawing.Size(184, 20)
        Me.DtpChequeFecha.TabIndex = 55
        '
        'PicEfectivo
        '
        Me.PicEfectivo.Image = CType(resources.GetObject("PicEfectivo.Image"), System.Drawing.Image)
        Me.PicEfectivo.Location = New System.Drawing.Point(222, 25)
        Me.PicEfectivo.Name = "PicEfectivo"
        Me.PicEfectivo.Size = New System.Drawing.Size(32, 30)
        Me.PicEfectivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicEfectivo.TabIndex = 0
        Me.PicEfectivo.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(222, 134)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(222, 295)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 20
        Me.PictureBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.LvwListaPagos)
        Me.GroupBox1.Location = New System.Drawing.Point(274, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(793, 489)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(274, 609)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(793, 79)
        Me.Panel1.TabIndex = 35
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCancelar, Me.BtnFacturar, Me.BtnMuestraCalculadora})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(793, 79)
        Me.ToolStrip1.TabIndex = 61
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(57, 76)
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnFacturar
        '
        Me.BtnFacturar.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnFacturar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnFacturar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFacturar.Name = "BtnFacturar"
        Me.BtnFacturar.Size = New System.Drawing.Size(54, 76)
        Me.BtnFacturar.Text = "Facturar"
        Me.BtnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnMuestraCalculadora
        '
        Me.BtnMuestraCalculadora.Image = Global.SDCXC.My.Resources.Resources.Blue_F1
        Me.BtnMuestraCalculadora.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnMuestraCalculadora.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnMuestraCalculadora.Name = "BtnMuestraCalculadora"
        Me.BtnMuestraCalculadora.Size = New System.Drawing.Size(74, 76)
        Me.BtnMuestraCalculadora.Text = "Calculadora"
        Me.BtnMuestraCalculadora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PicLogo
        '
        Me.PicLogo.Location = New System.Drawing.Point(940, -3)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(129, 124)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 34
        Me.PicLogo.TabStop = False
        '
        'FrmMovimientoPagoFisico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1072, 716)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PicLogo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PanelFaltan)
        Me.Controls.Add(Me.LblFaltaEtiqueta)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PanelTiposDePago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMovimientoPagoFisico"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago de Factura"
        Me.PanelFaltan.ResumeLayout(False)
        Me.PanelTiposDePago.ResumeLayout(False)
        Me.PanelTiposDePago.PerformLayout()
        CType(Me.PicEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents RdbEfectivoColones As System.Windows.Forms.RadioButton
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DtpChequeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnMuestraCalculadora As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnFacturar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
