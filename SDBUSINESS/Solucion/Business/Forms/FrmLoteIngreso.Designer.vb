<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLoteIngreso
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
        Me.BtnModificar = New System.Windows.Forms.Button()
        Me.LblVencimiento = New System.Windows.Forms.Label()
        Me.LblLote = New System.Windows.Forms.Label()
        Me.TxtLote = New System.Windows.Forms.TextBox()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.GrpLoteDetalle = New System.Windows.Forms.GroupBox()
        Me.TxtVencimiento = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TxtCantidadTotal = New System.Windows.Forms.TextBox()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpLotes = New System.Windows.Forms.GroupBox()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.LvwLotes = New System.Windows.Forms.ListView()
        Me.GrpArticulos = New System.Windows.Forms.GroupBox()
        Me.LvwArticulos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.GrpLoteDetalle.SuspendLayout()
        Me.GrpLotes.SuspendLayout()
        Me.GrpArticulos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnModificar
        '
        Me.BtnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnModificar.ForeColor = System.Drawing.Color.Green
        Me.BtnModificar.Location = New System.Drawing.Point(21, 214)
        Me.BtnModificar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(488, 70)
        Me.BtnModificar.TabIndex = 11
        Me.BtnModificar.Text = "Modificar"
        Me.BtnModificar.UseVisualStyleBackColor = True
        '
        'LblVencimiento
        '
        Me.LblVencimiento.AutoSize = True
        Me.LblVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVencimiento.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblVencimiento.Location = New System.Drawing.Point(17, 87)
        Me.LblVencimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblVencimiento.Name = "LblVencimiento"
        Me.LblVencimiento.Size = New System.Drawing.Size(91, 31)
        Me.LblVencimiento.TabIndex = 10
        Me.LblVencimiento.Text = "Vence"
        '
        'LblLote
        '
        Me.LblLote.AutoSize = True
        Me.LblLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLote.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblLote.Location = New System.Drawing.Point(15, 39)
        Me.LblLote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLote.Name = "LblLote"
        Me.LblLote.Size = New System.Drawing.Size(67, 31)
        Me.LblLote.TabIndex = 6
        Me.LblLote.Text = "Lote"
        '
        'TxtLote
        '
        Me.TxtLote.BackColor = System.Drawing.Color.White
        Me.TxtLote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLote.Location = New System.Drawing.Point(224, 36)
        Me.TxtLote.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLote.Name = "TxtLote"
        Me.TxtLote.ReadOnly = True
        Me.TxtLote.Size = New System.Drawing.Size(284, 30)
        Me.TxtLote.TabIndex = 8
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(224, 148)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(284, 37)
        Me.TxtCantidad.TabIndex = 7
        '
        'GrpLoteDetalle
        '
        Me.GrpLoteDetalle.Controls.Add(Me.TxtVencimiento)
        Me.GrpLoteDetalle.Controls.Add(Me.BtnModificar)
        Me.GrpLoteDetalle.Controls.Add(Me.LblVencimiento)
        Me.GrpLoteDetalle.Controls.Add(Me.LblLote)
        Me.GrpLoteDetalle.Controls.Add(Me.TxtLote)
        Me.GrpLoteDetalle.Controls.Add(Me.Label2)
        Me.GrpLoteDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpLoteDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpLoteDetalle.Location = New System.Drawing.Point(1104, 500)
        Me.GrpLoteDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpLoteDetalle.Name = "GrpLoteDetalle"
        Me.GrpLoteDetalle.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpLoteDetalle.Size = New System.Drawing.Size(528, 305)
        Me.GrpLoteDetalle.TabIndex = 9
        Me.GrpLoteDetalle.TabStop = False
        Me.GrpLoteDetalle.Text = "NombreArticulo"
        '
        'TxtVencimiento
        '
        Me.TxtVencimiento.BackColor = System.Drawing.Color.White
        Me.TxtVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVencimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVencimiento.Location = New System.Drawing.Point(224, 87)
        Me.TxtVencimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtVencimiento.Name = "TxtVencimiento"
        Me.TxtVencimiento.ReadOnly = True
        Me.TxtVencimiento.Size = New System.Drawing.Size(284, 30)
        Me.TxtVencimiento.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(15, 151)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 31)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Cantidad"
        '
        'TxtCantidadTotal
        '
        Me.TxtCantidadTotal.BackColor = System.Drawing.Color.White
        Me.TxtCantidadTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidadTotal.Location = New System.Drawing.Point(223, 423)
        Me.TxtCantidadTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCantidadTotal.Name = "TxtCantidadTotal"
        Me.TxtCantidadTotal.ReadOnly = True
        Me.TxtCantidadTotal.Size = New System.Drawing.Size(284, 41)
        Me.TxtCantidadTotal.TabIndex = 5
        Me.TxtCantidadTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(119, 427)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 36)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Total:"
        '
        'GrpLotes
        '
        Me.GrpLotes.BackColor = System.Drawing.Color.Transparent
        Me.GrpLotes.Controls.Add(Me.BtnAgregar)
        Me.GrpLotes.Controls.Add(Me.TxtCantidadTotal)
        Me.GrpLotes.Controls.Add(Me.Label1)
        Me.GrpLotes.Controls.Add(Me.LvwLotes)
        Me.GrpLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpLotes.Location = New System.Drawing.Point(1107, 5)
        Me.GrpLotes.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpLotes.Name = "GrpLotes"
        Me.GrpLotes.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpLotes.Size = New System.Drawing.Size(528, 490)
        Me.GrpLotes.TabIndex = 8
        Me.GrpLotes.TabStop = False
        Me.GrpLotes.Text = "Lotes"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.Image = Global.Business.My.Resources.Resources.add1
        Me.BtnAgregar.Location = New System.Drawing.Point(20, 423)
        Me.BtnAgregar.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(51, 43)
        Me.BtnAgregar.TabIndex = 6
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'LvwLotes
        '
        Me.LvwLotes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.LvwLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwLotes.FullRowSelect = True
        Me.LvwLotes.HideSelection = False
        Me.LvwLotes.Location = New System.Drawing.Point(20, 32)
        Me.LvwLotes.Margin = New System.Windows.Forms.Padding(4)
        Me.LvwLotes.Name = "LvwLotes"
        Me.LvwLotes.Size = New System.Drawing.Size(487, 372)
        Me.LvwLotes.TabIndex = 3
        Me.LvwLotes.UseCompatibleStateImageBehavior = False
        Me.LvwLotes.View = System.Windows.Forms.View.Details
        '
        'GrpArticulos
        '
        Me.GrpArticulos.Controls.Add(Me.LvwArticulos)
        Me.GrpArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpArticulos.Location = New System.Drawing.Point(123, 5)
        Me.GrpArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpArticulos.Name = "GrpArticulos"
        Me.GrpArticulos.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpArticulos.Size = New System.Drawing.Size(975, 800)
        Me.GrpArticulos.TabIndex = 7
        Me.GrpArticulos.TabStop = False
        Me.GrpArticulos.Text = "Articulos"
        '
        'LvwArticulos
        '
        Me.LvwArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader9})
        Me.LvwArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwArticulos.FullRowSelect = True
        Me.LvwArticulos.HideSelection = False
        Me.LvwArticulos.Location = New System.Drawing.Point(8, 36)
        Me.LvwArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.LvwArticulos.MultiSelect = False
        Me.LvwArticulos.Name = "LvwArticulos"
        Me.LvwArticulos.Size = New System.Drawing.Size(957, 742)
        Me.LvwArticulos.TabIndex = 2
        Me.LvwArticulos.UseCompatibleStateImageBehavior = False
        Me.LvwArticulos.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnNuevo)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(112, 809)
        Me.Panel1.TabIndex = 6
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.Color.White
        Me.BtnNuevo.Image = Global.Business.My.Resources.Resources.Blue_F4
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnNuevo.Location = New System.Drawing.Point(12, 108)
        Me.BtnNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(85, 86)
        Me.BtnNuevo.TabIndex = 13
        Me.BtnNuevo.Text = "Agregar"
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Business.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalir.Location = New System.Drawing.Point(12, 202)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(85, 87)
        Me.BtnSalir.TabIndex = 12
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.Business.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAceptar.Location = New System.Drawing.Point(12, 15)
        Me.BtnAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(85, 86)
        Me.BtnAceptar.TabIndex = 9
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'FrmLoteIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1641, 809)
        Me.Controls.Add(Me.GrpLoteDetalle)
        Me.Controls.Add(Me.GrpLotes)
        Me.Controls.Add(Me.GrpArticulos)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLoteIngreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Lotes"
        Me.GrpLoteDetalle.ResumeLayout(False)
        Me.GrpLoteDetalle.PerformLayout()
        Me.GrpLotes.ResumeLayout(False)
        Me.GrpLotes.PerformLayout()
        Me.GrpArticulos.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnModificar As Windows.Forms.Button
    Friend WithEvents LblVencimiento As Windows.Forms.Label
    Friend WithEvents LblLote As Windows.Forms.Label
    Friend WithEvents TxtLote As Windows.Forms.TextBox
    Friend WithEvents TxtCantidad As Windows.Forms.TextBox
    Friend WithEvents GrpLoteDetalle As Windows.Forms.GroupBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents ColumnHeader8 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As Windows.Forms.ColumnHeader
    Friend WithEvents BtnAgregar As Windows.Forms.Button
    Friend WithEvents TxtCantidadTotal As Windows.Forms.TextBox
    Friend WithEvents ColumnHeader4 As Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents GrpLotes As Windows.Forms.GroupBox
    Friend WithEvents LvwLotes As Windows.Forms.ListView
    Friend WithEvents GrpArticulos As Windows.Forms.GroupBox
    Friend WithEvents LvwArticulos As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As Windows.Forms.ColumnHeader
    Friend WithEvents BtnNuevo As Windows.Forms.Button
    Friend WithEvents BtnSalir As Windows.Forms.Button
    Friend WithEvents BtnAceptar As Windows.Forms.Button
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents TxtVencimiento As Windows.Forms.TextBox
End Class
