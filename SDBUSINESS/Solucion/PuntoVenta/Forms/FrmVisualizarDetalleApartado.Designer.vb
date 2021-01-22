<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisualizarDetalleApartado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVisualizarDetalleApartado))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtVencimiento = New System.Windows.Forms.TextBox()
        Me.TxtEstado = New System.Windows.Forms.TextBox()
        Me.TxtSaldo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.TxtFecha = New System.Windows.Forms.TextBox()
        Me.TxtApartado = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.LvwAbonos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAbandonar = New System.Windows.Forms.Button()
        Me.BtnAbonar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtAbono = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Apartado:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(585, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Monto:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(279, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Saldo:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtVencimiento)
        Me.GroupBox1.Controls.Add(Me.TxtEstado)
        Me.GroupBox1.Controls.Add(Me.TxtSaldo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtMonto)
        Me.GroupBox1.Controls.Add(Me.TxtFecha)
        Me.GroupBox1.Controls.Add(Me.TxtApartado)
        Me.GroupBox1.Controls.Add(Me.TxtCliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(122, 11)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(863, 151)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Apartado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(585, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Vencimiento:"
        '
        'TxtVencimiento
        '
        Me.TxtVencimiento.Location = New System.Drawing.Point(713, 97)
        Me.TxtVencimiento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtVencimiento.Name = "TxtVencimiento"
        Me.TxtVencimiento.ReadOnly = True
        Me.TxtVencimiento.Size = New System.Drawing.Size(113, 22)
        Me.TxtVencimiento.TabIndex = 14
        '
        'TxtEstado
        '
        Me.TxtEstado.Location = New System.Drawing.Point(417, 69)
        Me.TxtEstado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.ReadOnly = True
        Me.TxtEstado.Size = New System.Drawing.Size(113, 22)
        Me.TxtEstado.TabIndex = 13
        '
        'TxtSaldo
        '
        Me.TxtSaldo.Location = New System.Drawing.Point(417, 97)
        Me.TxtSaldo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.ReadOnly = True
        Me.TxtSaldo.Size = New System.Drawing.Size(113, 22)
        Me.TxtSaldo.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(279, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Estado:"
        '
        'TxtMonto
        '
        Me.TxtMonto.Location = New System.Drawing.Point(148, 97)
        Me.TxtMonto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.ReadOnly = True
        Me.TxtMonto.Size = New System.Drawing.Size(113, 22)
        Me.TxtMonto.TabIndex = 8
        '
        'TxtFecha
        '
        Me.TxtFecha.Location = New System.Drawing.Point(713, 68)
        Me.TxtFecha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.ReadOnly = True
        Me.TxtFecha.Size = New System.Drawing.Size(113, 22)
        Me.TxtFecha.TabIndex = 7
        '
        'TxtApartado
        '
        Me.TxtApartado.Location = New System.Drawing.Point(148, 68)
        Me.TxtApartado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtApartado.Name = "TxtApartado"
        Me.TxtApartado.ReadOnly = True
        Me.TxtApartado.Size = New System.Drawing.Size(113, 22)
        Me.TxtApartado.TabIndex = 6
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(148, 38)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(383, 22)
        Me.TxtCliente.TabIndex = 5
        '
        'LvwAbonos
        '
        Me.LvwAbonos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.LvwAbonos.FullRowSelect = True
        Me.LvwAbonos.HideSelection = False
        Me.LvwAbonos.Location = New System.Drawing.Point(122, 228)
        Me.LvwAbonos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LvwAbonos.Name = "LvwAbonos"
        Me.LvwAbonos.Size = New System.Drawing.Size(861, 341)
        Me.LvwAbonos.TabIndex = 6
        Me.LvwAbonos.UseCompatibleStateImageBehavior = False
        Me.LvwAbonos.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnAbandonar)
        Me.Panel1.Controls.Add(Me.BtnAbonar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(112, 578)
        Me.Panel1.TabIndex = 7
        '
        'BtnAbandonar
        '
        Me.BtnAbandonar.BackColor = System.Drawing.Color.White
        Me.BtnAbandonar.ForeColor = System.Drawing.Color.Red
        Me.BtnAbandonar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F4
        Me.BtnAbandonar.Location = New System.Drawing.Point(8, 113)
        Me.BtnAbandonar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAbandonar.Name = "BtnAbandonar"
        Me.BtnAbandonar.Size = New System.Drawing.Size(97, 87)
        Me.BtnAbandonar.TabIndex = 8
        Me.BtnAbandonar.Text = "&Abandono"
        Me.BtnAbandonar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAbandonar.UseVisualStyleBackColor = False
        '
        'BtnAbonar
        '
        Me.BtnAbonar.BackColor = System.Drawing.Color.White
        Me.BtnAbonar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnAbonar.Location = New System.Drawing.Point(8, 15)
        Me.BtnAbonar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAbonar.Name = "BtnAbonar"
        Me.BtnAbonar.Size = New System.Drawing.Size(97, 87)
        Me.BtnAbonar.TabIndex = 6
        Me.BtnAbonar.Text = "&Abonar"
        Me.BtnAbonar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAbonar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(8, 210)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(97, 87)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Green
        Me.Label8.Location = New System.Drawing.Point(476, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(221, 32)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Monto a abonar:"
        '
        'TxtAbono
        '
        Me.TxtAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAbono.Location = New System.Drawing.Point(706, 177)
        Me.TxtAbono.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtAbono.Name = "TxtAbono"
        Me.TxtAbono.Size = New System.Drawing.Size(277, 38)
        Me.TxtAbono.TabIndex = 17
        '
        'FrmVisualizarDetalleApartado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(989, 578)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtAbono)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LvwAbonos)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVisualizarDetalleApartado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apartado detalles"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtMonto As TextBox
    Friend WithEvents TxtFecha As TextBox
    Friend WithEvents TxtApartado As TextBox
    Friend WithEvents TxtCliente As TextBox
    Friend WithEvents LvwAbonos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents TxtSaldo As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnAbonar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents TxtEstado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtVencimiento As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtAbono As TextBox
    Friend WithEvents BtnAbandonar As Button
End Class
