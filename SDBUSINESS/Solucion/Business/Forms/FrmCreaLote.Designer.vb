<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCreaLote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCreaLote))
        Me.LblArticulo = New System.Windows.Forms.Label()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.DtpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.LblVencimiento = New System.Windows.Forms.Label()
        Me.LblLote = New System.Windows.Forms.Label()
        Me.TxtLote = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LblArticulo
        '
        Me.LblArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArticulo.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblArticulo.Location = New System.Drawing.Point(43, 21)
        Me.LblArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblArticulo.Name = "LblArticulo"
        Me.LblArticulo.Size = New System.Drawing.Size(523, 81)
        Me.LblArticulo.TabIndex = 27
        Me.LblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Green
        Me.BtnAceptar.Location = New System.Drawing.Point(43, 304)
        Me.BtnAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(524, 70)
        Me.BtnAceptar.TabIndex = 26
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'DtpVencimiento
        '
        Me.DtpVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.DtpVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpVencimiento.Location = New System.Drawing.Point(279, 245)
        Me.DtpVencimiento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtpVencimiento.Name = "DtpVencimiento"
        Me.DtpVencimiento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DtpVencimiento.Size = New System.Drawing.Size(287, 37)
        Me.DtpVencimiento.TabIndex = 24
        '
        'LblVencimiento
        '
        Me.LblVencimiento.AutoSize = True
        Me.LblVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVencimiento.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblVencimiento.Location = New System.Drawing.Point(36, 245)
        Me.LblVencimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblVencimiento.Name = "LblVencimiento"
        Me.LblVencimiento.Size = New System.Drawing.Size(91, 31)
        Me.LblVencimiento.TabIndex = 25
        Me.LblVencimiento.Text = "Vence"
        '
        'LblLote
        '
        Me.LblLote.AutoSize = True
        Me.LblLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLote.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblLote.Location = New System.Drawing.Point(39, 187)
        Me.LblLote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLote.Name = "LblLote"
        Me.LblLote.Size = New System.Drawing.Size(67, 31)
        Me.LblLote.TabIndex = 21
        Me.LblLote.Text = "Lote"
        '
        'TxtLote
        '
        Me.TxtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLote.Location = New System.Drawing.Point(279, 185)
        Me.TxtLote.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtLote.Name = "TxtLote"
        Me.TxtLote.Size = New System.Drawing.Size(287, 37)
        Me.TxtLote.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(36, 130)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 31)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Cantidad"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(279, 123)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(287, 37)
        Me.TxtCantidad.TabIndex = 22
        '
        'FrmCreaLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(597, 398)
        Me.Controls.Add(Me.LblArticulo)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.DtpVencimiento)
        Me.Controls.Add(Me.LblVencimiento)
        Me.Controls.Add(Me.LblLote)
        Me.Controls.Add(Me.TxtLote)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCantidad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCreaLote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Creación de lotes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblArticulo As Windows.Forms.Label
    Friend WithEvents BtnAceptar As Windows.Forms.Button
    Friend WithEvents DtpVencimiento As Windows.Forms.DateTimePicker
    Friend WithEvents LblVencimiento As Windows.Forms.Label
    Friend WithEvents LblLote As Windows.Forms.Label
    Friend WithEvents TxtLote As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents TxtCantidad As Windows.Forms.TextBox
End Class
