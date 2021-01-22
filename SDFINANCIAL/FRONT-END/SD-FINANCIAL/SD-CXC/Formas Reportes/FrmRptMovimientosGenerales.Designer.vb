<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptMovimientosGenerales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptMovimientosGenerales))
        Me.DpHasta = New System.Windows.Forms.DateTimePicker()
        Me.DpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.CmbtipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbTodos = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DpHasta
        '
        Me.DpHasta.CustomFormat = "dd/MM/yyyy"
        Me.DpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpHasta.Location = New System.Drawing.Point(365, 107)
        Me.DpHasta.Name = "DpHasta"
        Me.DpHasta.Size = New System.Drawing.Size(98, 20)
        Me.DpHasta.TabIndex = 34
        '
        'DpDesde
        '
        Me.DpDesde.CustomFormat = "dd/MM/yyyy"
        Me.DpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpDesde.Location = New System.Drawing.Point(167, 107)
        Me.DpDesde.Name = "DpDesde"
        Me.DpDesde.Size = New System.Drawing.Size(98, 20)
        Me.DpDesde.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(320, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(122, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 31
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
        Me.Panel1.Size = New System.Drawing.Size(70, 161)
        Me.Panel1.TabIndex = 30
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
        'CmbtipoDocumento
        '
        Me.CmbtipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbtipoDocumento.FormattingEnabled = True
        Me.CmbtipoDocumento.Location = New System.Drawing.Point(227, 61)
        Me.CmbtipoDocumento.Name = "CmbtipoDocumento"
        Me.CmbtipoDocumento.Size = New System.Drawing.Size(236, 21)
        Me.CmbtipoDocumento.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(122, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Tipo de movimiento"
        '
        'CbTodos
        '
        Me.CbTodos.AutoSize = True
        Me.CbTodos.Location = New System.Drawing.Point(125, 25)
        Me.CbTodos.Name = "CbTodos"
        Me.CbTodos.Size = New System.Drawing.Size(56, 17)
        Me.CbTodos.TabIndex = 37
        Me.CbTodos.Text = "Todos"
        Me.CbTodos.UseVisualStyleBackColor = True
        '
        'FrmRptMovimientosGenerales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 161)
        Me.Controls.Add(Me.CbTodos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbtipoDocumento)
        Me.Controls.Add(Me.DpHasta)
        Me.Controls.Add(Me.DpDesde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmRptMovimientosGenerales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Movimientos Generales"
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
    Friend WithEvents CmbtipoDocumento As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CbTodos As CheckBox
End Class
