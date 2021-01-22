<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptComisionesPorVendedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptComisionesPorVendedor))
        Me.DpHasta = New System.Windows.Forms.DateTimePicker()
        Me.DpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbVendedores = New System.Windows.Forms.ComboBox()
        Me.ChbTodos = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DpHasta
        '
        Me.DpHasta.CustomFormat = "dd/MM/yyyy"
        Me.DpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpHasta.Location = New System.Drawing.Point(335, 86)
        Me.DpHasta.Name = "DpHasta"
        Me.DpHasta.Size = New System.Drawing.Size(98, 20)
        Me.DpHasta.TabIndex = 33
        '
        'DpDesde
        '
        Me.DpDesde.CustomFormat = "dd/MM/yyyy"
        Me.DpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpDesde.Location = New System.Drawing.Point(137, 86)
        Me.DpDesde.Name = "DpDesde"
        Me.DpDesde.Size = New System.Drawing.Size(98, 20)
        Me.DpDesde.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(294, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(92, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Desde"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(70, 162)
        Me.Panel1.TabIndex = 29
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(5, 5)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(59, 72)
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
        Me.BtnSalir.Location = New System.Drawing.Point(5, 83)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(59, 72)
        Me.BtnSalir.TabIndex = 3
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(92, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Vendedor"
        '
        'CbVendedores
        '
        Me.CbVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbVendedores.FormattingEnabled = True
        Me.CbVendedores.Location = New System.Drawing.Point(233, 35)
        Me.CbVendedores.Name = "CbVendedores"
        Me.CbVendedores.Size = New System.Drawing.Size(200, 21)
        Me.CbVendedores.TabIndex = 35
        '
        'ChbTodos
        '
        Me.ChbTodos.AutoSize = True
        Me.ChbTodos.Location = New System.Drawing.Point(163, 35)
        Me.ChbTodos.Name = "ChbTodos"
        Me.ChbTodos.Size = New System.Drawing.Size(56, 17)
        Me.ChbTodos.TabIndex = 37
        Me.ChbTodos.Text = "Todos"
        Me.ChbTodos.UseVisualStyleBackColor = True
        '
        'FrmRptComisionesPorVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(476, 162)
        Me.Controls.Add(Me.ChbTodos)
        Me.Controls.Add(Me.CbVendedores)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DpHasta)
        Me.Controls.Add(Me.DpDesde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptComisionesPorVendedor"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comisiones por vendedor"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DpHasta As DateTimePicker
    Friend WithEvents DpDesde As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents CbVendedores As ComboBox
    Friend WithEvents ChbTodos As CheckBox
End Class
