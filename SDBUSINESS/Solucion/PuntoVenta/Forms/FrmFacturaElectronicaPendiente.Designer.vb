<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFacturaElectronicaPendiente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturaElectronicaPendiente))
        Me.PnlBotones = New System.Windows.Forms.Panel()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.BntRefrescar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnEnviar = New System.Windows.Forms.Button()
        Me.LsvFacturaPendiente = New System.Windows.Forms.ListView()
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
        Me.PrgProgreso = New System.Windows.Forms.ProgressBar()
        Me.PnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBotones
        '
        Me.PnlBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlBotones.Controls.Add(Me.BtnCliente)
        Me.PnlBotones.Controls.Add(Me.BntRefrescar)
        Me.PnlBotones.Controls.Add(Me.BtnSalir)
        Me.PnlBotones.Controls.Add(Me.BtnEnviar)
        Me.PnlBotones.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlBotones.Location = New System.Drawing.Point(0, 0)
        Me.PnlBotones.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlBotones.Name = "PnlBotones"
        Me.PnlBotones.Size = New System.Drawing.Size(115, 870)
        Me.PnlBotones.TabIndex = 17
        '
        'BtnCliente
        '
        Me.BtnCliente.BackColor = System.Drawing.Color.White
        Me.BtnCliente.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F7
        Me.BtnCliente.Location = New System.Drawing.Point(16, 202)
        Me.BtnCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(81, 86)
        Me.BtnCliente.TabIndex = 15
        Me.BtnCliente.Text = "Cliente"
        Me.BtnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCliente.UseVisualStyleBackColor = False
        '
        'BntRefrescar
        '
        Me.BntRefrescar.BackColor = System.Drawing.Color.White
        Me.BntRefrescar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BntRefrescar.Location = New System.Drawing.Point(16, 108)
        Me.BntRefrescar.Margin = New System.Windows.Forms.Padding(4)
        Me.BntRefrescar.Name = "BntRefrescar"
        Me.BntRefrescar.Size = New System.Drawing.Size(81, 86)
        Me.BntRefrescar.TabIndex = 14
        Me.BntRefrescar.Text = "Refrescar"
        Me.BntRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BntRefrescar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(16, 295)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(81, 86)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnEnviar
        '
        Me.BtnEnviar.BackColor = System.Drawing.Color.White
        Me.BtnEnviar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F2
        Me.BtnEnviar.Location = New System.Drawing.Point(16, 15)
        Me.BtnEnviar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnEnviar.Name = "BtnEnviar"
        Me.BtnEnviar.Size = New System.Drawing.Size(81, 86)
        Me.BtnEnviar.TabIndex = 12
        Me.BtnEnviar.Text = "Enviar"
        Me.BtnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnEnviar.UseVisualStyleBackColor = False
        '
        'LsvFacturaPendiente
        '
        Me.LsvFacturaPendiente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.LsvFacturaPendiente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvFacturaPendiente.FullRowSelect = True
        Me.LsvFacturaPendiente.HideSelection = False
        Me.LsvFacturaPendiente.Location = New System.Drawing.Point(115, 0)
        Me.LsvFacturaPendiente.Margin = New System.Windows.Forms.Padding(4)
        Me.LsvFacturaPendiente.Name = "LsvFacturaPendiente"
        Me.LsvFacturaPendiente.Size = New System.Drawing.Size(1537, 870)
        Me.LsvFacturaPendiente.TabIndex = 22
        Me.LsvFacturaPendiente.UseCompatibleStateImageBehavior = False
        Me.LsvFacturaPendiente.View = System.Windows.Forms.View.Details
        '
        'PrgProgreso
        '
        Me.PrgProgreso.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PrgProgreso.Location = New System.Drawing.Point(115, 864)
        Me.PrgProgreso.Margin = New System.Windows.Forms.Padding(4)
        Me.PrgProgreso.Name = "PrgProgreso"
        Me.PrgProgreso.Size = New System.Drawing.Size(1537, 6)
        Me.PrgProgreso.TabIndex = 23
        '
        'FrmFacturaElectronicaPendiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1652, 870)
        Me.Controls.Add(Me.PrgProgreso)
        Me.Controls.Add(Me.LsvFacturaPendiente)
        Me.Controls.Add(Me.PnlBotones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmFacturaElectronicaPendiente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Factura Pendiente de Envío"
        Me.PnlBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnlBotones As Panel
    Friend WithEvents BntRefrescar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnEnviar As Button
    Friend WithEvents LsvFacturaPendiente As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents BtnCliente As Button
    Friend WithEvents PrgProgreso As ProgressBar
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
End Class
