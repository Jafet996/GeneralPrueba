<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptDocumentosProximosVencer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptDocumentosProximosVencer))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCantidadDias = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.TxtClienteNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.TextVendedoNombre = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(93, 199)
        Me.Panel1.TabIndex = 5
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(7, 6)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(79, 89)
        Me.BtnImprimir.TabIndex = 6
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
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(151, 105)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Plazo de Vencimiento (en días)"
        '
        'TxtCantidadDias
        '
        Me.TxtCantidadDias.Location = New System.Drawing.Point(369, 102)
        Me.TxtCantidadDias.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCantidadDias.Name = "TxtCantidadDias"
        Me.TxtCantidadDias.Size = New System.Drawing.Size(240, 22)
        Me.TxtCantidadDias.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(151, 66)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Cliente"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(210, 63)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(91, 22)
        Me.TxtCliente.TabIndex = 1
        Me.TxtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtClienteNombre
        '
        Me.TxtClienteNombre.BackColor = System.Drawing.Color.White
        Me.TxtClienteNombre.Location = New System.Drawing.Point(316, 64)
        Me.TxtClienteNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtClienteNombre.Name = "TxtClienteNombre"
        Me.TxtClienteNombre.ReadOnly = True
        Me.TxtClienteNombre.Size = New System.Drawing.Size(293, 22)
        Me.TxtClienteNombre.TabIndex = 2
        Me.TxtClienteNombre.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(151, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Vendedor"
        Me.Label2.Visible = False
        '
        'txtVendedor
        '
        Me.txtVendedor.Location = New System.Drawing.Point(252, 169)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(91, 22)
        Me.txtVendedor.TabIndex = 3
        Me.txtVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtVendedor.Visible = False
        '
        'TextVendedoNombre
        '
        Me.TextVendedoNombre.Location = New System.Drawing.Point(355, 169)
        Me.TextVendedoNombre.Name = "TextVendedoNombre"
        Me.TextVendedoNombre.ReadOnly = True
        Me.TextVendedoNombre.Size = New System.Drawing.Size(293, 22)
        Me.TextVendedoNombre.TabIndex = 4
        Me.TextVendedoNombre.Visible = False
        '
        'FrmRptDocumentosProximosVencer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(677, 199)
        Me.Controls.Add(Me.TextVendedoNombre)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtClienteNombre)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCantidadDias)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptDocumentosProximosVencer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Documentos Próximos a Vencer"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidadDias As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents TxtClienteNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents TextVendedoNombre As TextBox
End Class
