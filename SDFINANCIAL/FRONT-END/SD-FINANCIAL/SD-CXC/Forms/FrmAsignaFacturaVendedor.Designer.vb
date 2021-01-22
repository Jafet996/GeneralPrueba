<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAsignaFacturaVendedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsignaFacturaVendedor))
        Me.LvwMovimientos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CbVendedores = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LvwMovimientos
        '
        Me.LvwMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LvwMovimientos.FullRowSelect = True
        Me.LvwMovimientos.Location = New System.Drawing.Point(4, 97)
        Me.LvwMovimientos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LvwMovimientos.Name = "LvwMovimientos"
        Me.LvwMovimientos.Size = New System.Drawing.Size(1332, 565)
        Me.LvwMovimientos.TabIndex = 5
        Me.LvwMovimientos.UseCompatibleStateImageBehavior = False
        Me.LvwMovimientos.View = System.Windows.Forms.View.Details
        '
        'CbVendedores
        '
        Me.CbVendedores.FormattingEnabled = True
        Me.CbVendedores.Location = New System.Drawing.Point(340, 38)
        Me.CbVendedores.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CbVendedores.Name = "CbVendedores"
        Me.CbVendedores.Size = New System.Drawing.Size(552, 24)
        Me.CbVendedores.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(172, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Seleccione el vendedor"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnBuscar)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Location = New System.Drawing.Point(-5, 671)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1333, 114)
        Me.Panel1.TabIndex = 9
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.White
        Me.BtnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnBuscar.Image = Global.SDCXC.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.Location = New System.Drawing.Point(1059, 4)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(84, 107)
        Me.BtnBuscar.TabIndex = 11
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnImprimir.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(1151, 4)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(84, 107)
        Me.BtnImprimir.TabIndex = 10
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnSalir.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(1243, 4)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(84, 107)
        Me.BtnSalir.TabIndex = 9
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'FrmAsignaFacturaVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1340, 786)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbVendedores)
        Me.Controls.Add(Me.LvwMovimientos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAsignaFacturaVendedor"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignacion de facturas a vendedores"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LvwMovimientos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents CbVendedores As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnBuscar As Button
End Class
