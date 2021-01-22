<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptTotalAdeudado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptTotalAdeudado))
        Me.TxtProveedorNombre = New System.Windows.Forms.TextBox()
        Me.TxtProveedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.CbTodos = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtProveedorNombre
        '
        Me.TxtProveedorNombre.BackColor = System.Drawing.Color.White
        Me.TxtProveedorNombre.Enabled = False
        Me.TxtProveedorNombre.Location = New System.Drawing.Point(266, 95)
        Me.TxtProveedorNombre.Name = "TxtProveedorNombre"
        Me.TxtProveedorNombre.ReadOnly = True
        Me.TxtProveedorNombre.Size = New System.Drawing.Size(163, 20)
        Me.TxtProveedorNombre.TabIndex = 35
        Me.TxtProveedorNombre.TabStop = False
        '
        'TxtProveedor
        '
        Me.TxtProveedor.Location = New System.Drawing.Point(178, 95)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.Size = New System.Drawing.Size(82, 20)
        Me.TxtProveedor.TabIndex = 33
        Me.TxtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(118, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Proveedor"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(70, 170)
        Me.Panel1.TabIndex = 32
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.BackgroundImage = Global.SDCXP.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnImprimir.Location = New System.Drawing.Point(5, 5)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(59, 72)
        Me.BtnImprimir.TabIndex = 3
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.BackgroundImage = Global.SDCXP.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Location = New System.Drawing.Point(5, 83)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(59, 80)
        Me.BtnSalir.TabIndex = 3
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'CbTodos
        '
        Me.CbTodos.AutoSize = True
        Me.CbTodos.Location = New System.Drawing.Point(121, 50)
        Me.CbTodos.Name = "CbTodos"
        Me.CbTodos.Size = New System.Drawing.Size(56, 17)
        Me.CbTodos.TabIndex = 36
        Me.CbTodos.Text = "Todos"
        Me.CbTodos.UseVisualStyleBackColor = True
        '
        'FrmRptTotalAdeudado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(497, 170)
        Me.Controls.Add(Me.CbTodos)
        Me.Controls.Add(Me.TxtProveedorNombre)
        Me.Controls.Add(Me.TxtProveedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptTotalAdeudado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte total adeudado"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtProveedorNombre As TextBox
    Friend WithEvents TxtProveedor As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents CbTodos As CheckBox
End Class
