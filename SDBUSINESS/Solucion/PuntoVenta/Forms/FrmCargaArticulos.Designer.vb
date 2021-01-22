<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCargaArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCargaArticulos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnCargar = New System.Windows.Forms.ToolStripButton()
        Me.BtnAplicar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.LvwDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenF = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.PrgCarga = New System.Windows.Forms.ProgressBar()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCargar, Me.BtnAplicar, Me.ToolStripSeparator4, Me.BtnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(607, 72)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnCargar
        '
        Me.BtnCargar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F2
        Me.BtnCargar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCargar.Name = "BtnCargar"
        Me.BtnCargar.Size = New System.Drawing.Size(52, 69)
        Me.BtnCargar.Text = "Cargar"
        Me.BtnCargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnAplicar
        '
        Me.BtnAplicar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F4
        Me.BtnAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(52, 69)
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 72)
        '
        'BtnSalir
        '
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(52, 69)
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LvwDetalle
        '
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.LvwDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.Location = New System.Drawing.Point(0, 72)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(707, 440)
        Me.LvwDetalle.SmallImageList = Me.ImageList1
        Me.LvwDetalle.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LvwDetalle.TabIndex = 13
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
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Gakuseisean-Ivista-2-Alarm-Tick.ico")
        Me.ImageList1.Images.SetKeyName(1, "Oxygen-Icons.org-Oxygen-Actions-window-close.ico")
        '
        'OpenF
        '
        Me.OpenF.FileName = "OpenFileDialog1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.PicLogo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(707, 72)
        Me.Panel1.TabIndex = 14
        '
        'PicLogo
        '
        Me.PicLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.PicLogo.Location = New System.Drawing.Point(607, 0)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(100, 72)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 2
        Me.PicLogo.TabStop = False
        '
        'PrgCarga
        '
        Me.PrgCarga.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PrgCarga.Location = New System.Drawing.Point(0, 512)
        Me.PrgCarga.Name = "PrgCarga"
        Me.PrgCarga.Size = New System.Drawing.Size(707, 10)
        Me.PrgCarga.TabIndex = 15
        Me.PrgCarga.Visible = False
        '
        'FrmCargaArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(707, 522)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PrgCarga)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCargaArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga de Artículos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnCargar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LvwDetalle As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents OpenF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
    Friend WithEvents PrgCarga As System.Windows.Forms.ProgressBar
End Class
