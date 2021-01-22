<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCxCFacturaPendiente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCxCFacturaPendiente))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnMuestraDetalle = New System.Windows.Forms.Button()
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.BtnPasaCxC = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.LvwFacturas = New System.Windows.Forms.ListView()
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
        Me.PrgProgreso = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnMuestraDetalle)
        Me.Panel1.Controls.Add(Me.BtnRefrescar)
        Me.Panel1.Controls.Add(Me.BtnPasaCxC)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(75, 615)
        Me.Panel1.TabIndex = 115
        '
        'BtnMuestraDetalle
        '
        Me.BtnMuestraDetalle.BackColor = System.Drawing.Color.White
        Me.BtnMuestraDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMuestraDetalle.ForeColor = System.Drawing.Color.Black
        Me.BtnMuestraDetalle.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F2
        Me.BtnMuestraDetalle.Location = New System.Drawing.Point(7, 84)
        Me.BtnMuestraDetalle.Name = "BtnMuestraDetalle"
        Me.BtnMuestraDetalle.Size = New System.Drawing.Size(61, 72)
        Me.BtnMuestraDetalle.TabIndex = 15
        Me.BtnMuestraDetalle.TabStop = False
        Me.BtnMuestraDetalle.Text = "Detalle"
        Me.BtnMuestraDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnMuestraDetalle.UseVisualStyleBackColor = False
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.BackColor = System.Drawing.Color.White
        Me.BtnRefrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefrescar.ForeColor = System.Drawing.Color.Black
        Me.BtnRefrescar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F1
        Me.BtnRefrescar.Location = New System.Drawing.Point(7, 6)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(61, 72)
        Me.BtnRefrescar.TabIndex = 14
        Me.BtnRefrescar.TabStop = False
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRefrescar.UseVisualStyleBackColor = False
        '
        'BtnPasaCxC
        '
        Me.BtnPasaCxC.BackColor = System.Drawing.Color.White
        Me.BtnPasaCxC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPasaCxC.ForeColor = System.Drawing.Color.Black
        Me.BtnPasaCxC.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnPasaCxC.Location = New System.Drawing.Point(7, 162)
        Me.BtnPasaCxC.Name = "BtnPasaCxC"
        Me.BtnPasaCxC.Size = New System.Drawing.Size(61, 72)
        Me.BtnPasaCxC.TabIndex = 13
        Me.BtnPasaCxC.TabStop = False
        Me.BtnPasaCxC.Text = "Pasa CxC"
        Me.BtnPasaCxC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnPasaCxC.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(7, 240)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(61, 72)
        Me.BtnSalir.TabIndex = 12
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'LvwFacturas
        '
        Me.LvwFacturas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.LvwFacturas.Dock = System.Windows.Forms.DockStyle.Top
        Me.LvwFacturas.FullRowSelect = True
        Me.LvwFacturas.HideSelection = False
        Me.LvwFacturas.Location = New System.Drawing.Point(75, 0)
        Me.LvwFacturas.Name = "LvwFacturas"
        Me.LvwFacturas.Size = New System.Drawing.Size(901, 603)
        Me.LvwFacturas.TabIndex = 116
        Me.LvwFacturas.UseCompatibleStateImageBehavior = False
        Me.LvwFacturas.View = System.Windows.Forms.View.Details
        '
        'PrgProgreso
        '
        Me.PrgProgreso.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PrgProgreso.Location = New System.Drawing.Point(75, 605)
        Me.PrgProgreso.Name = "PrgProgreso"
        Me.PrgProgreso.Size = New System.Drawing.Size(901, 10)
        Me.PrgProgreso.TabIndex = 117
        '
        'FrmCxCFacturaPendiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(976, 615)
        Me.Controls.Add(Me.PrgProgreso)
        Me.Controls.Add(Me.LvwFacturas)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCxCFacturaPendiente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnPasaCxC As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents LvwFacturas As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PrgProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents BtnMuestraDetalle As System.Windows.Forms.Button
    Friend WithEvents BtnRefrescar As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
End Class
