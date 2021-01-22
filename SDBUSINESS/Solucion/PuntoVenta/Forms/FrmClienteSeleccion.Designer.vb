<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmClienteSeleccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClienteSeleccion))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.PnlBotones = New System.Windows.Forms.Panel()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnInactivar = New System.Windows.Forms.Button()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 609)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1084, 22)
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
        Me.DGDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGDetalle.Location = New System.Drawing.Point(112, 0)
        Me.DGDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.Size = New System.Drawing.Size(972, 609)
        Me.DGDetalle.TabIndex = 5
        '
        'PnlBotones
        '
        Me.PnlBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlBotones.Controls.Add(Me.BtnInactivar)
        Me.PnlBotones.Controls.Add(Me.BtnCliente)
        Me.PnlBotones.Controls.Add(Me.BtnSalir)
        Me.PnlBotones.Controls.Add(Me.BtnAceptar)
        Me.PnlBotones.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlBotones.Location = New System.Drawing.Point(0, 0)
        Me.PnlBotones.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlBotones.Name = "PnlBotones"
        Me.PnlBotones.Size = New System.Drawing.Size(112, 609)
        Me.PnlBotones.TabIndex = 6
        '
        'BtnCliente
        '
        Me.BtnCliente.BackColor = System.Drawing.Color.White
        Me.BtnCliente.Enabled = False
        Me.BtnCliente.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F7
        Me.BtnCliente.Location = New System.Drawing.Point(13, 108)
        Me.BtnCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(87, 90)
        Me.BtnCliente.TabIndex = 14
        Me.BtnCliente.TabStop = False
        Me.BtnCliente.Text = "Cliente"
        Me.BtnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCliente.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(13, 304)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(87, 90)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Enabled = False
        Me.BtnAceptar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.Location = New System.Drawing.Point(12, 10)
        Me.BtnAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(87, 90)
        Me.BtnAceptar.TabIndex = 12
        Me.BtnAceptar.TabStop = False
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnInactivar
        '
        Me.BtnInactivar.BackColor = System.Drawing.Color.White
        Me.BtnInactivar.Enabled = False
        Me.BtnInactivar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F8
        Me.BtnInactivar.Location = New System.Drawing.Point(13, 206)
        Me.BtnInactivar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnInactivar.Name = "BtnInactivar"
        Me.BtnInactivar.Size = New System.Drawing.Size(87, 90)
        Me.BtnInactivar.TabIndex = 15
        Me.BtnInactivar.TabStop = False
        Me.BtnInactivar.Text = "Inactivar"
        Me.BtnInactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnInactivar.UseVisualStyleBackColor = False
        '
        'FrmClienteSeleccion
        '
        Me.AcceptButton = Me.BtnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(1084, 631)
        Me.Controls.Add(Me.DGDetalle)
        Me.Controls.Add(Me.PnlBotones)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClienteSeleccion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de Clientes"
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBotones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents DGDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents PnlBotones As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnCliente As Button
    Friend WithEvents BtnInactivar As Button
End Class
