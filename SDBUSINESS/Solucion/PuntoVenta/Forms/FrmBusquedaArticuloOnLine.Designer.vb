<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaArticuloOnLine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaArticuloOnLine))
        Me.TxtCriterio = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbnCodEquivalente = New System.Windows.Forms.RadioButton()
        Me.RbtDescripción = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblSeleccionCantidad = New System.Windows.Forms.Label()
        Me.LblSeleccionLeyenda = New System.Windows.Forms.Label()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnSaldos = New System.Windows.Forms.Button()
        Me.LvwArticuloBodega = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtCriterio
        '
        Me.TxtCriterio.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtCriterio.Location = New System.Drawing.Point(203, 27)
        Me.TxtCriterio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCriterio.MaxLength = 50
        Me.TxtCriterio.Name = "TxtCriterio"
        Me.TxtCriterio.Size = New System.Drawing.Size(411, 22)
        Me.TxtCriterio.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.RbnCodEquivalente)
        Me.GroupBox1.Controls.Add(Me.RbtDescripción)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.LblMensaje)
        Me.GroupBox1.Controls.Add(Me.TxtCriterio)
        Me.GroupBox1.Location = New System.Drawing.Point(145, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1512, 91)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'RbnCodEquivalente
        '
        Me.RbnCodEquivalente.AutoSize = True
        Me.RbnCodEquivalente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RbnCodEquivalente.ForeColor = System.Drawing.Color.DarkBlue
        Me.RbnCodEquivalente.Location = New System.Drawing.Point(37, 43)
        Me.RbnCodEquivalente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RbnCodEquivalente.Name = "RbnCodEquivalente"
        Me.RbnCodEquivalente.Size = New System.Drawing.Size(114, 21)
        Me.RbnCodEquivalente.TabIndex = 2
        Me.RbnCodEquivalente.Text = "&Equivalente"
        Me.RbnCodEquivalente.UseVisualStyleBackColor = True
        '
        'RbtDescripción
        '
        Me.RbtDescripción.AutoSize = True
        Me.RbtDescripción.Checked = True
        Me.RbtDescripción.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RbtDescripción.ForeColor = System.Drawing.Color.DarkBlue
        Me.RbtDescripción.Location = New System.Drawing.Point(37, 15)
        Me.RbtDescripción.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RbtDescripción.Name = "RbtDescripción"
        Me.RbtDescripción.Size = New System.Drawing.Size(114, 21)
        Me.RbtDescripción.TabIndex = 1
        Me.RbtDescripción.TabStop = True
        Me.RbtDescripción.Text = "&Descripción"
        Me.RbtDescripción.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = Global.PuntoVenta.My.Resources.Resources.view
        Me.PictureBox1.Location = New System.Drawing.Point(623, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(59, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'LblMensaje
        '
        Me.LblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblMensaje.Location = New System.Drawing.Point(704, 18)
        Me.LblMensaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(371, 34)
        Me.LblMensaje.TabIndex = 4
        Me.LblMensaje.Text = "No se encontraron datos relacionados"
        Me.LblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Location = New System.Drawing.Point(137, 747)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1524, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'DGDetalle
        '
        Me.DGDetalle.AllowUserToAddRows = False
        Me.DGDetalle.AllowUserToDeleteRows = False
        Me.DGDetalle.BackgroundColor = System.Drawing.Color.White
        Me.DGDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetalle.Location = New System.Drawing.Point(145, 98)
        Me.DGDetalle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.Size = New System.Drawing.Size(1512, 422)
        Me.DGDetalle.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LblSeleccionCantidad)
        Me.Panel1.Controls.Add(Me.LblSeleccionLeyenda)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnSaldos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(137, 769)
        Me.Panel1.TabIndex = 6
        '
        'LblSeleccionCantidad
        '
        Me.LblSeleccionCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeleccionCantidad.ForeColor = System.Drawing.Color.White
        Me.LblSeleccionCantidad.Location = New System.Drawing.Point(7, 668)
        Me.LblSeleccionCantidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSeleccionCantidad.Name = "LblSeleccionCantidad"
        Me.LblSeleccionCantidad.Size = New System.Drawing.Size(120, 33)
        Me.LblSeleccionCantidad.TabIndex = 9
        Me.LblSeleccionCantidad.Text = "2"
        Me.LblSeleccionCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblSeleccionCantidad.Visible = False
        '
        'LblSeleccionLeyenda
        '
        Me.LblSeleccionLeyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeleccionLeyenda.ForeColor = System.Drawing.Color.White
        Me.LblSeleccionLeyenda.Location = New System.Drawing.Point(9, 709)
        Me.LblSeleccionLeyenda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSeleccionLeyenda.Name = "LblSeleccionLeyenda"
        Me.LblSeleccionLeyenda.Size = New System.Drawing.Size(116, 39)
        Me.LblSeleccionLeyenda.TabIndex = 8
        Me.LblSeleccionLeyenda.Text = "Items Seleccionados"
        Me.LblSeleccionLeyenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblSeleccionLeyenda.Visible = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(29, 111)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(76, 89)
        Me.BtnSalir.TabIndex = 6
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnSaldos
        '
        Me.BtnSaldos.BackColor = System.Drawing.Color.White
        Me.BtnSaldos.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSaldos.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F2
        Me.BtnSaldos.Location = New System.Drawing.Point(29, 15)
        Me.BtnSaldos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSaldos.Name = "BtnSaldos"
        Me.BtnSaldos.Size = New System.Drawing.Size(76, 89)
        Me.BtnSaldos.TabIndex = 5
        Me.BtnSaldos.Text = "Saldos"
        Me.BtnSaldos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSaldos.UseVisualStyleBackColor = False
        '
        'LvwArticuloBodega
        '
        Me.LvwArticuloBodega.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.LvwArticuloBodega.FullRowSelect = True
        Me.LvwArticuloBodega.HideSelection = False
        Me.LvwArticuloBodega.Location = New System.Drawing.Point(145, 528)
        Me.LvwArticuloBodega.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LvwArticuloBodega.Name = "LvwArticuloBodega"
        Me.LvwArticuloBodega.Size = New System.Drawing.Size(1511, 207)
        Me.LvwArticuloBodega.TabIndex = 7
        Me.LvwArticuloBodega.UseCompatibleStateImageBehavior = False
        Me.LvwArticuloBodega.View = System.Windows.Forms.View.Details
        '
        'FrmBusquedaArticuloOnLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1661, 769)
        Me.Controls.Add(Me.LvwArticuloBodega)
        Me.Controls.Add(Me.DGDetalle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaArticuloOnLine"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de Artículos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCriterio As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents DGDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblMensaje As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSaldos As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents LvwArticuloBodega As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents RbnCodEquivalente As RadioButton
    Friend WithEvents RbtDescripción As RadioButton
    Friend WithEvents LblSeleccionCantidad As Label
    Friend WithEvents LblSeleccionLeyenda As Label
End Class
