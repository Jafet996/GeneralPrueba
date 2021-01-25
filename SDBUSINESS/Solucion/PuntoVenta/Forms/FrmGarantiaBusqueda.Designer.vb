<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGarantiaBusqueda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGarantiaBusqueda))
        Me.PnlBotones = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.LvwDetalle = New System.Windows.Forms.ListView()
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
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.TxtSerie = New System.Windows.Forms.TextBox()
        Me.LblArticulo = New System.Windows.Forms.Label()
        Me.TxtArticulo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ChkCliente = New System.Windows.Forms.CheckBox()
        Me.ChkSerie = New System.Windows.Forms.CheckBox()
        Me.ChkArticulo = New System.Windows.Forms.CheckBox()
        Me.PnlBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBotones
        '
        Me.PnlBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlBotones.Controls.Add(Me.BtnImprimir)
        Me.PnlBotones.Controls.Add(Me.BtnSalir)
        Me.PnlBotones.Controls.Add(Me.BtnBuscar)
        Me.PnlBotones.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlBotones.Location = New System.Drawing.Point(0, 0)
        Me.PnlBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PnlBotones.Name = "PnlBotones"
        Me.PnlBotones.Size = New System.Drawing.Size(133, 734)
        Me.PnlBotones.TabIndex = 5
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnImprimir.Enabled = False
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.ForeColor = System.Drawing.Color.White
        Me.BtnImprimir.Location = New System.Drawing.Point(12, 103)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(101, 76)
        Me.BtnImprimir.TabIndex = 5
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(12, 186)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(101, 76)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscar.ForeColor = System.Drawing.Color.White
        Me.BtnBuscar.Location = New System.Drawing.Point(12, 22)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(101, 76)
        Me.BtnBuscar.TabIndex = 3
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'LvwDetalle
        '
        Me.LvwDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.LvwDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwDetalle.FullRowSelect = True
        Me.LvwDetalle.HideSelection = False
        Me.LvwDetalle.Location = New System.Drawing.Point(133, 124)
        Me.LvwDetalle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LvwDetalle.Name = "LvwDetalle"
        Me.LvwDetalle.Size = New System.Drawing.Size(1184, 610)
        Me.LvwDetalle.TabIndex = 5
        Me.LvwDetalle.UseCompatibleStateImageBehavior = False
        Me.LvwDetalle.View = System.Windows.Forms.View.Details
        '
        'LblCliente
        '
        Me.LblCliente.BackColor = System.Drawing.Color.White
        Me.LblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCliente.Location = New System.Drawing.Point(261, 22)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(498, 22)
        Me.LblCliente.TabIndex = 8
        Me.LblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(117, 22)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCliente.MaxLength = 13
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(139, 22)
        Me.TxtCliente.TabIndex = 0
        '
        'TxtSerie
        '
        Me.TxtSerie.Location = New System.Drawing.Point(117, 50)
        Me.TxtSerie.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtSerie.MaxLength = 20
        Me.TxtSerie.Name = "TxtSerie"
        Me.TxtSerie.Size = New System.Drawing.Size(139, 22)
        Me.TxtSerie.TabIndex = 1
        Me.TxtSerie.Visible = False
        '
        'LblArticulo
        '
        Me.LblArticulo.BackColor = System.Drawing.Color.White
        Me.LblArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblArticulo.Location = New System.Drawing.Point(261, 78)
        Me.LblArticulo.Name = "LblArticulo"
        Me.LblArticulo.Size = New System.Drawing.Size(498, 22)
        Me.LblArticulo.TabIndex = 2
        Me.LblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtArticulo
        '
        Me.TxtArticulo.Location = New System.Drawing.Point(117, 78)
        Me.TxtArticulo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtArticulo.MaxLength = 13
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(139, 22)
        Me.TxtArticulo.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ChkCliente)
        Me.Panel1.Controls.Add(Me.ChkSerie)
        Me.Panel1.Controls.Add(Me.ChkArticulo)
        Me.Panel1.Controls.Add(Me.LblArticulo)
        Me.Panel1.Controls.Add(Me.LblCliente)
        Me.Panel1.Controls.Add(Me.TxtArticulo)
        Me.Panel1.Controls.Add(Me.TxtCliente)
        Me.Panel1.Controls.Add(Me.TxtSerie)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(133, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1184, 124)
        Me.Panel1.TabIndex = 8
        '
        'ChkCliente
        '
        Me.ChkCliente.AutoSize = True
        Me.ChkCliente.Checked = True
        Me.ChkCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCliente.Location = New System.Drawing.Point(27, 23)
        Me.ChkCliente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChkCliente.Name = "ChkCliente"
        Me.ChkCliente.Size = New System.Drawing.Size(73, 21)
        Me.ChkCliente.TabIndex = 9
        Me.ChkCliente.Text = "Cliente"
        Me.ChkCliente.UseVisualStyleBackColor = True
        '
        'ChkSerie
        '
        Me.ChkSerie.AutoSize = True
        Me.ChkSerie.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChkSerie.Location = New System.Drawing.Point(27, 50)
        Me.ChkSerie.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChkSerie.Name = "ChkSerie"
        Me.ChkSerie.Size = New System.Drawing.Size(63, 21)
        Me.ChkSerie.TabIndex = 8
        Me.ChkSerie.Text = "Serie"
        Me.ChkSerie.UseVisualStyleBackColor = True
        Me.ChkSerie.Visible = False
        '
        'ChkArticulo
        '
        Me.ChkArticulo.AutoSize = True
        Me.ChkArticulo.Location = New System.Drawing.Point(27, 78)
        Me.ChkArticulo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChkArticulo.Name = "ChkArticulo"
        Me.ChkArticulo.Size = New System.Drawing.Size(77, 21)
        Me.ChkArticulo.TabIndex = 7
        Me.ChkArticulo.Text = "Artículo"
        Me.ChkArticulo.UseVisualStyleBackColor = True
        '
        'FrmGarantiaBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1317, 734)
        Me.Controls.Add(Me.LvwDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlBotones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGarantiaBusqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmGarantiaBusqueda"
        Me.PnlBotones.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnlBotones As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents LvwDetalle As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents LblCliente As Label
    Friend WithEvents TxtCliente As TextBox
    Friend WithEvents TxtSerie As TextBox
    Friend WithEvents LblArticulo As Label
    Friend WithEvents TxtArticulo As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ChkCliente As CheckBox
    Friend WithEvents ChkSerie As CheckBox
    Friend WithEvents ChkArticulo As CheckBox
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents BtnImprimir As Button
End Class
