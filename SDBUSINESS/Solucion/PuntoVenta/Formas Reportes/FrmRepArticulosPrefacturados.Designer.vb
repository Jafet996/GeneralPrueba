<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepArticulosPrefacturados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepArticulosPrefacturados))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCargar = New System.Windows.Forms.Button()
        Me.BtnArchivo = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbSucursal = New System.Windows.Forms.ComboBox()
        Me.CmbBodega = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.LvwDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PrgCarga = New System.Windows.Forms.ProgressBar()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CmbTipoEntrega = New System.Windows.Forms.ComboBox()
        Me.CkbTipoEntrega = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnCargar)
        Me.Panel1.Controls.Add(Me.BtnArchivo)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 493)
        Me.Panel1.TabIndex = 8
        '
        'BtnCargar
        '
        Me.BtnCargar.BackColor = System.Drawing.Color.White
        Me.BtnCargar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F5
        Me.BtnCargar.Location = New System.Drawing.Point(12, 164)
        Me.BtnCargar.Name = "BtnCargar"
        Me.BtnCargar.Size = New System.Drawing.Size(59, 70)
        Me.BtnCargar.TabIndex = 15
        Me.BtnCargar.Text = "Cargar"
        Me.BtnCargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCargar.UseVisualStyleBackColor = False
        '
        'BtnArchivo
        '
        Me.BtnArchivo.BackColor = System.Drawing.Color.White
        Me.BtnArchivo.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F4
        Me.BtnArchivo.Location = New System.Drawing.Point(12, 88)
        Me.BtnArchivo.Name = "BtnArchivo"
        Me.BtnArchivo.Size = New System.Drawing.Size(59, 70)
        Me.BtnArchivo.TabIndex = 14
        Me.BtnArchivo.Text = "Archivo"
        Me.BtnArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnArchivo.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 240)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(59, 70)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(12, 12)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(59, 70)
        Me.BtnImprimir.TabIndex = 12
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Sucursal"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursal.FormattingEnabled = True
        Me.CmbSucursal.Location = New System.Drawing.Point(75, 19)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(255, 21)
        Me.CmbSucursal.TabIndex = 12
        '
        'CmbBodega
        '
        Me.CmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodega.FormattingEnabled = True
        Me.CmbBodega.Location = New System.Drawing.Point(75, 46)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Size = New System.Drawing.Size(255, 21)
        Me.CmbBodega.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Bodega"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CkbTipoEntrega)
        Me.GroupBox1.Controls.Add(Me.CmbTipoEntrega)
        Me.GroupBox1.Controls.Add(Me.CmbTipo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DtpFechaIni)
        Me.GroupBox1.Controls.Add(Me.CmbSucursal)
        Me.GroupBox1.Controls.Add(Me.CmbBodega)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(99, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(677, 108)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'CmbTipo
        '
        Me.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipo.FormattingEnabled = True
        Me.CmbTipo.Items.AddRange(New Object() {"RESUMIDO", "DETALLADO"})
        Me.CmbTipo.Location = New System.Drawing.Point(403, 46)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(95, 21)
        Me.CmbTipo.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(349, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Tipo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(509, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Hasta"
        '
        'DtpFechaFin
        '
        Me.DtpFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFin.Location = New System.Drawing.Point(550, 19)
        Me.DtpFechaFin.Name = "DtpFechaFin"
        Me.DtpFechaFin.Size = New System.Drawing.Size(95, 20)
        Me.DtpFechaFin.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(349, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Desde"
        '
        'DtpFechaIni
        '
        Me.DtpFechaIni.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaIni.Location = New System.Drawing.Point(403, 19)
        Me.DtpFechaIni.Name = "DtpFechaIni"
        Me.DtpFechaIni.Size = New System.Drawing.Size(95, 20)
        Me.DtpFechaIni.TabIndex = 15
        '
        'LvwDetalle
        '
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.LvwDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.Location = New System.Drawing.Point(81, 137)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(715, 356)
        Me.LvwDetalle.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LvwDetalle.TabIndex = 16
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Artículo"
        Me.ColumnHeader1.Width = 138
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripción"
        Me.ColumnHeader2.Width = 470
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Cantidad"
        Me.ColumnHeader3.Width = 69
        '
        'PrgCarga
        '
        Me.PrgCarga.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PrgCarga.Location = New System.Drawing.Point(0, 493)
        Me.PrgCarga.Name = "PrgCarga"
        Me.PrgCarga.Size = New System.Drawing.Size(796, 17)
        Me.PrgCarga.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PrgCarga.TabIndex = 17
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Gakuseisean-Ivista-2-Alarm-Tick.ico")
        Me.ImageList1.Images.SetKeyName(1, "Oxygen-Icons.org-Oxygen-Actions-window-close.ico")
        '
        'CmbTipoEntrega
        '
        Me.CmbTipoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoEntrega.Enabled = False
        Me.CmbTipoEntrega.FormattingEnabled = True
        Me.CmbTipoEntrega.Items.AddRange(New Object() {""})
        Me.CmbTipoEntrega.Location = New System.Drawing.Point(117, 73)
        Me.CmbTipoEntrega.Name = "CmbTipoEntrega"
        Me.CmbTipoEntrega.Size = New System.Drawing.Size(213, 21)
        Me.CmbTipoEntrega.TabIndex = 22
        '
        'CkbTipoEntrega
        '
        Me.CkbTipoEntrega.AutoSize = True
        Me.CkbTipoEntrega.Location = New System.Drawing.Point(24, 78)
        Me.CkbTipoEntrega.Name = "CkbTipoEntrega"
        Me.CkbTipoEntrega.Size = New System.Drawing.Size(87, 17)
        Me.CkbTipoEntrega.TabIndex = 23
        Me.CkbTipoEntrega.Text = "Tipo Entrega"
        Me.CkbTipoEntrega.UseVisualStyleBackColor = True
        '
        'FrmRepArticulosPrefacturados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(796, 510)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PrgCarga)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepArticulosPrefacturados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Artículos PreFacturados"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents CmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbTipo As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnArchivo As Button
    Friend WithEvents LvwDetalle As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents BtnCargar As Button
    Friend WithEvents PrgCarga As ProgressBar
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents CmbTipoEntrega As ComboBox
    Friend WithEvents CkbTipoEntrega As CheckBox
End Class
