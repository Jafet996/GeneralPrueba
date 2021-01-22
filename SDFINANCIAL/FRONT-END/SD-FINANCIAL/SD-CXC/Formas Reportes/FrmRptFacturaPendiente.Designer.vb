<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRptFacturaPendiente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptFacturaPendiente))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.CkbCliente = New System.Windows.Forms.CheckBox()
        Me.PnlCliente = New System.Windows.Forms.Panel()
        Me.TxtClienteNombre = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CkbClienteInfoAdicional = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.PnlCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(93, 204)
        Me.Panel1.TabIndex = 6
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(7, 6)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(79, 89)
        Me.BtnImprimir.TabIndex = 3
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(7, 102)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(79, 89)
        Me.BtnSalir.TabIndex = 3
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'CkbCliente
        '
        Me.CkbCliente.AutoSize = True
        Me.CkbCliente.Location = New System.Drawing.Point(125, 21)
        Me.CkbCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.CkbCliente.Name = "CkbCliente"
        Me.CkbCliente.Size = New System.Drawing.Size(73, 21)
        Me.CkbCliente.TabIndex = 7
        Me.CkbCliente.Text = "Cliente"
        Me.CkbCliente.UseVisualStyleBackColor = True
        '
        'PnlCliente
        '
        Me.PnlCliente.Controls.Add(Me.TxtClienteNombre)
        Me.PnlCliente.Controls.Add(Me.TxtCliente)
        Me.PnlCliente.Controls.Add(Me.Label3)
        Me.PnlCliente.Enabled = False
        Me.PnlCliente.Location = New System.Drawing.Point(125, 70)
        Me.PnlCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlCliente.Name = "PnlCliente"
        Me.PnlCliente.Size = New System.Drawing.Size(507, 81)
        Me.PnlCliente.TabIndex = 8
        '
        'TxtClienteNombre
        '
        Me.TxtClienteNombre.BackColor = System.Drawing.Color.White
        Me.TxtClienteNombre.Location = New System.Drawing.Point(187, 28)
        Me.TxtClienteNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtClienteNombre.Name = "TxtClienteNombre"
        Me.TxtClienteNombre.ReadOnly = True
        Me.TxtClienteNombre.Size = New System.Drawing.Size(293, 22)
        Me.TxtClienteNombre.TabIndex = 16
        Me.TxtClienteNombre.TabStop = False
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(87, 28)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(91, 22)
        Me.TxtCliente.TabIndex = 14
        Me.TxtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 32)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Cliente"
        '
        'CkbClienteInfoAdicional
        '
        Me.CkbClienteInfoAdicional.AutoSize = True
        Me.CkbClienteInfoAdicional.Location = New System.Drawing.Point(231, 21)
        Me.CkbClienteInfoAdicional.Margin = New System.Windows.Forms.Padding(4)
        Me.CkbClienteInfoAdicional.Name = "CkbClienteInfoAdicional"
        Me.CkbClienteInfoAdicional.Size = New System.Drawing.Size(164, 21)
        Me.CkbClienteInfoAdicional.TabIndex = 9
        Me.CkbClienteInfoAdicional.Text = "Informacion Adicional"
        Me.CkbClienteInfoAdicional.UseVisualStyleBackColor = True
        '
        'FrmRptFacturaPendiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(683, 204)
        Me.Controls.Add(Me.CkbClienteInfoAdicional)
        Me.Controls.Add(Me.PnlCliente)
        Me.Controls.Add(Me.CkbCliente)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmRptFacturaPendiente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturas Pendientes por Cliente"
        Me.Panel1.ResumeLayout(False)
        Me.PnlCliente.ResumeLayout(False)
        Me.PnlCliente.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents CkbCliente As CheckBox
    Friend WithEvents PnlCliente As Panel
    Friend WithEvents TxtClienteNombre As TextBox
    Friend WithEvents TxtCliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CkbClienteInfoAdicional As CheckBox
End Class
