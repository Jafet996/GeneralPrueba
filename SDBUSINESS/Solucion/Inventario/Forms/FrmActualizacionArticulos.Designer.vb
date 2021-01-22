<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActualizacionArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmActualizacionArticulos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnActualizar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGenerar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbBodega = New System.Windows.Forms.ComboBox()
        Me.BtnRuta = New System.Windows.Forms.Button()
        Me.TxtRuta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SaveF = New System.Windows.Forms.SaveFileDialog()
        Me.OpenF = New System.Windows.Forms.OpenFileDialog()
        Me.LvwLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnActualizar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGenerar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(75, 487)
        Me.Panel1.TabIndex = 3
        '
        'BtnActualizar
        '
        Me.BtnActualizar.BackColor = System.Drawing.Color.White
        Me.BtnActualizar.Image = Global.Inventario.My.Resources.Resources.Blue_F8
        Me.BtnActualizar.Location = New System.Drawing.Point(5, 88)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(63, 69)
        Me.BtnActualizar.TabIndex = 13
        Me.BtnActualizar.TabStop = False
        Me.BtnActualizar.Text = "Actualizar"
        Me.BtnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnActualizar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(5, 163)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(63, 73)
        Me.BtnSalir.TabIndex = 12
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGenerar
        '
        Me.BtnGenerar.BackColor = System.Drawing.Color.White
        Me.BtnGenerar.Image = Global.Inventario.My.Resources.Resources.Blue_F7
        Me.BtnGenerar.Location = New System.Drawing.Point(5, 9)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(63, 73)
        Me.BtnGenerar.TabIndex = 11
        Me.BtnGenerar.TabStop = False
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGenerar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(94, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Bodega"
        '
        'CmbBodega
        '
        Me.CmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodega.FormattingEnabled = True
        Me.CmbBodega.Location = New System.Drawing.Point(144, 36)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Size = New System.Drawing.Size(299, 21)
        Me.CmbBodega.TabIndex = 5
        '
        'BtnRuta
        '
        Me.BtnRuta.Location = New System.Drawing.Point(782, 35)
        Me.BtnRuta.Name = "BtnRuta"
        Me.BtnRuta.Size = New System.Drawing.Size(25, 23)
        Me.BtnRuta.TabIndex = 26
        Me.BtnRuta.Text = "..."
        Me.BtnRuta.UseVisualStyleBackColor = True
        '
        'TxtRuta
        '
        Me.TxtRuta.Location = New System.Drawing.Point(508, 36)
        Me.TxtRuta.MaxLength = 30
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.ReadOnly = True
        Me.TxtRuta.Size = New System.Drawing.Size(262, 20)
        Me.TxtRuta.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(458, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Ruta"
        '
        'OpenF
        '
        Me.OpenF.FileName = "OpenFileDialog1"
        '
        'LvwLog
        '
        Me.LvwLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.LvwLog.Location = New System.Drawing.Point(97, 88)
        Me.LvwLog.Name = "LvwLog"
        Me.LvwLog.Size = New System.Drawing.Size(710, 375)
        Me.LvwLog.TabIndex = 28
        Me.LvwLog.UseCompatibleStateImageBehavior = False
        Me.LvwLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width = 109
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Error"
        Me.ColumnHeader2.Width = 576
        '
        'FrmActualizacionArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(831, 487)
        Me.Controls.Add(Me.LvwLog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnRuta)
        Me.Controls.Add(Me.TxtRuta)
        Me.Controls.Add(Me.CmbBodega)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmActualizacionArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualización de Artículos"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents BtnActualizar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents BtnRuta As System.Windows.Forms.Button
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveF As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LvwLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
End Class
