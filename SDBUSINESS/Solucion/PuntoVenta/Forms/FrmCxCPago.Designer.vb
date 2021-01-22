<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCxCPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCxCPago))
        Me.GroupOpciones = New System.Windows.Forms.GroupBox()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.BtnPago = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PcbLogo = New System.Windows.Forms.PictureBox()
        Me.GpbDetalle = New System.Windows.Forms.GroupBox()
        Me.TxTReferencia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNombreVendedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtVendedor = New System.Windows.Forms.TextBox()
        Me.LvwMovimientos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.TxtSaldo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PcbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpbDetalle.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupOpciones
        '
        Me.GroupOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.GroupOpciones.Controls.Add(Me.BtnLimpiar)
        Me.GroupOpciones.Controls.Add(Me.BtnRefrescar)
        Me.GroupOpciones.Controls.Add(Me.BtnPago)
        Me.GroupOpciones.Controls.Add(Me.BtnSalir)
        Me.GroupOpciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupOpciones.Location = New System.Drawing.Point(0, 0)
        Me.GroupOpciones.Name = "GroupOpciones"
        Me.GroupOpciones.Size = New System.Drawing.Size(83, 583)
        Me.GroupOpciones.TabIndex = 8
        Me.GroupOpciones.TabStop = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F12
        Me.BtnLimpiar.Location = New System.Drawing.Point(12, 166)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(63, 71)
        Me.BtnLimpiar.TabIndex = 8
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.BackColor = System.Drawing.Color.White
        Me.BtnRefrescar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F4
        Me.BtnRefrescar.Location = New System.Drawing.Point(12, 89)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(63, 71)
        Me.BtnRefrescar.TabIndex = 6
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRefrescar.UseVisualStyleBackColor = False
        '
        'BtnPago
        '
        Me.BtnPago.BackColor = System.Drawing.Color.White
        Me.BtnPago.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnPago.Location = New System.Drawing.Point(12, 12)
        Me.BtnPago.Name = "BtnPago"
        Me.BtnPago.Size = New System.Drawing.Size(63, 71)
        Me.BtnPago.TabIndex = 5
        Me.BtnPago.Text = "Pagar"
        Me.BtnPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnPago.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 243)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(63, 71)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtNombre)
        Me.GroupBox1.Controls.Add(Me.TxtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 60)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Búsqueda Cliente "
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.White
        Me.TxtNombre.Location = New System.Drawing.Point(214, 21)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(296, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.Color.White
        Me.TxtCodigo.Location = New System.Drawing.Point(108, 21)
        Me.TxtCodigo.MaxLength = 6
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.TxtCodigo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Cliente"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PcbLogo)
        Me.Panel1.Controls.Add(Me.GpbDetalle)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(83, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(879, 154)
        Me.Panel1.TabIndex = 11
        '
        'PcbLogo
        '
        Me.PcbLogo.Location = New System.Drawing.Point(641, 7)
        Me.PcbLogo.Name = "PcbLogo"
        Me.PcbLogo.Size = New System.Drawing.Size(193, 141)
        Me.PcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PcbLogo.TabIndex = 65
        Me.PcbLogo.TabStop = False
        '
        'GpbDetalle
        '
        Me.GpbDetalle.Controls.Add(Me.TxTReferencia)
        Me.GpbDetalle.Controls.Add(Me.Label4)
        Me.GpbDetalle.Controls.Add(Me.TxtNombreVendedor)
        Me.GpbDetalle.Controls.Add(Me.Label3)
        Me.GpbDetalle.Controls.Add(Me.TxtVendedor)
        Me.GpbDetalle.Enabled = False
        Me.GpbDetalle.Location = New System.Drawing.Point(20, 68)
        Me.GpbDetalle.Name = "GpbDetalle"
        Me.GpbDetalle.Size = New System.Drawing.Size(552, 80)
        Me.GpbDetalle.TabIndex = 64
        Me.GpbDetalle.TabStop = False
        '
        'TxTReferencia
        '
        Me.TxTReferencia.BackColor = System.Drawing.Color.White
        Me.TxTReferencia.Location = New System.Drawing.Point(108, 45)
        Me.TxTReferencia.MaxLength = 300
        Me.TxTReferencia.Name = "TxTReferencia"
        Me.TxTReferencia.Size = New System.Drawing.Size(402, 20)
        Me.TxTReferencia.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.CausesValidation = False
        Me.Label4.Location = New System.Drawing.Point(43, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Referencia"
        '
        'TxtNombreVendedor
        '
        Me.TxtNombreVendedor.BackColor = System.Drawing.Color.White
        Me.TxtNombreVendedor.Location = New System.Drawing.Point(214, 14)
        Me.TxtNombreVendedor.Name = "TxtNombreVendedor"
        Me.TxtNombreVendedor.ReadOnly = True
        Me.TxtNombreVendedor.Size = New System.Drawing.Size(296, 20)
        Me.TxtNombreVendedor.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Vendedor"
        '
        'TxtVendedor
        '
        Me.TxtVendedor.BackColor = System.Drawing.Color.White
        Me.TxtVendedor.Location = New System.Drawing.Point(108, 14)
        Me.TxtVendedor.MaxLength = 5
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.Size = New System.Drawing.Size(100, 20)
        Me.TxtVendedor.TabIndex = 3
        '
        'LvwMovimientos
        '
        Me.LvwMovimientos.CheckBoxes = True
        Me.LvwMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LvwMovimientos.Dock = System.Windows.Forms.DockStyle.Top
        Me.LvwMovimientos.FullRowSelect = True
        Me.LvwMovimientos.Location = New System.Drawing.Point(83, 154)
        Me.LvwMovimientos.Name = "LvwMovimientos"
        Me.LvwMovimientos.Size = New System.Drawing.Size(879, 371)
        Me.LvwMovimientos.TabIndex = 4
        Me.LvwMovimientos.UseCompatibleStateImageBehavior = False
        Me.LvwMovimientos.View = System.Windows.Forms.View.Details
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(663, 544)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 25)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Total"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.PuntoVenta.My.Resources.Resources.Total3
        Me.PictureBox2.Location = New System.Drawing.Point(653, 531)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox2.TabIndex = 67
        Me.PictureBox2.TabStop = False
        '
        'TxtMonto
        '
        Me.TxtMonto.BackColor = System.Drawing.Color.White
        Me.TxtMonto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtMonto.Location = New System.Drawing.Point(796, 545)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(154, 22)
        Me.TxtMonto.TabIndex = 69
        Me.TxtMonto.Text = "0.00"
        Me.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSaldo
        '
        Me.TxtSaldo.BackColor = System.Drawing.Color.White
        Me.TxtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldo.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtSaldo.Location = New System.Drawing.Point(226, 545)
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.Size = New System.Drawing.Size(154, 22)
        Me.TxtSaldo.TabIndex = 72
        Me.TxtSaldo.Text = "0.00"
        Me.TxtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(93, 544)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 25)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Saldo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PuntoVenta.My.Resources.Resources.Total3
        Me.PictureBox1.Location = New System.Drawing.Point(83, 531)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(309, 52)
        Me.PictureBox1.TabIndex = 70
        Me.PictureBox1.TabStop = False
        '
        'FrmCxCPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(962, 583)
        Me.Controls.Add(Me.TxtSaldo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TxtMonto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LvwMovimientos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupOpciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCxCPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagos CxC"
        Me.GroupOpciones.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PcbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpbDetalle.ResumeLayout(False)
        Me.GpbDetalle.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupOpciones As GroupBox
    Friend WithEvents BtnPago As Button
    Friend WithEvents BtnSalir As Button
    Public WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents TxtCodigo As TextBox
    Friend WithEvents BtnRefrescar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LvwMovimientos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TxtMonto As TextBox
    Friend WithEvents BtnLimpiar As Button
    Friend WithEvents GpbDetalle As GroupBox
    Friend WithEvents TxTReferencia As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtNombreVendedor As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtVendedor As TextBox
    Friend WithEvents TxtSaldo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PcbLogo As PictureBox
End Class
