<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPagoRapidoFacturas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagoRapidoFacturas))
        Me.PnlEncabezado = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnPagar = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.LvwFacturas = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPago = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Código = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.PnlEncabezado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlEncabezado
        '
        Me.PnlEncabezado.BackColor = System.Drawing.Color.SteelBlue
        Me.PnlEncabezado.Controls.Add(Me.BtnSalir)
        Me.PnlEncabezado.Controls.Add(Me.BtnLimpiar)
        Me.PnlEncabezado.Controls.Add(Me.BtnPagar)
        Me.PnlEncabezado.Controls.Add(Me.BtnBuscar)
        Me.PnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.PnlEncabezado.Name = "PnlEncabezado"
        Me.PnlEncabezado.Size = New System.Drawing.Size(615, 80)
        Me.PnlEncabezado.TabIndex = 3
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnSalir.Image = Global.SDCXC.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(226, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(66, 73)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLimpiar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLimpiar.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnLimpiar.Image = Global.SDCXC.My.Resources.Resources.Blue_F12
        Me.BtnLimpiar.Location = New System.Drawing.Point(154, 4)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(66, 73)
        Me.BtnLimpiar.TabIndex = 7
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnPagar
        '
        Me.BtnPagar.BackColor = System.Drawing.Color.White
        Me.BtnPagar.Enabled = False
        Me.BtnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPagar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPagar.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnPagar.Image = Global.SDCXC.My.Resources.Resources.Blue_F3
        Me.BtnPagar.Location = New System.Drawing.Point(82, 4)
        Me.BtnPagar.Name = "BtnPagar"
        Me.BtnPagar.Size = New System.Drawing.Size(66, 73)
        Me.BtnPagar.TabIndex = 6
        Me.BtnPagar.Text = "Pagar"
        Me.BtnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnPagar.UseVisualStyleBackColor = False
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.White
        Me.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscar.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnBuscar.Image = Global.SDCXC.My.Resources.Resources.Blue_F1
        Me.BtnBuscar.Location = New System.Drawing.Point(10, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(66, 73)
        Me.BtnBuscar.TabIndex = 5
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'LvwFacturas
        '
        Me.LvwFacturas.CheckBoxes = True
        Me.LvwFacturas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LvwFacturas.FullRowSelect = True
        Me.LvwFacturas.Location = New System.Drawing.Point(9, 296)
        Me.LvwFacturas.Name = "LvwFacturas"
        Me.LvwFacturas.Size = New System.Drawing.Size(597, 332)
        Me.LvwFacturas.TabIndex = 5
        Me.LvwFacturas.UseCompatibleStateImageBehavior = False
        Me.LvwFacturas.View = System.Windows.Forms.View.Details
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtReferencia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtPago)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtNombre)
        Me.GroupBox1.Controls.Add(Me.Código)
        Me.GroupBox1.Controls.Add(Me.TxtCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 86)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(596, 204)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de ingreso"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 82)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(17, 101)
        Me.TxtReferencia.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(557, 20)
        Me.TxtReferencia.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(13, 132)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 26)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Monto a pagar"
        '
        'TxtPago
        '
        Me.TxtPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPago.Location = New System.Drawing.Point(17, 160)
        Me.TxtPago.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtPago.Name = "TxtPago"
        Me.TxtPago.Size = New System.Drawing.Size(266, 32)
        Me.TxtPago.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(134, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nombre"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(136, 46)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(438, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'Código
        '
        Me.Código.AutoSize = True
        Me.Código.Location = New System.Drawing.Point(17, 28)
        Me.Código.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Código.Name = "Código"
        Me.Código.Size = New System.Drawing.Size(40, 13)
        Me.Código.TabIndex = 1
        Me.Código.Text = "Código"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(17, 46)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(94, 20)
        Me.TxtCodigo.TabIndex = 0
        '
        'FrmPagoRapidoFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 629)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LvwFacturas)
        Me.Controls.Add(Me.PnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPagoRapidoFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago Facturas"
        Me.PnlEncabezado.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlEncabezado As Panel
    Friend WithEvents BtnLimpiar As Button
    Friend WithEvents BtnPagar As Button
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents LvwFacturas As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents GroupBox1 As GroupBox
    Private WithEvents Label2 As Label
    Friend WithEvents TxtPago As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents Código As Label
    Friend WithEvents TxtCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtReferencia As TextBox
End Class
