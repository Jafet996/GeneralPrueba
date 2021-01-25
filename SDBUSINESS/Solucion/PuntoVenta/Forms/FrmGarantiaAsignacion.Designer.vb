<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGarantiaAsignacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGarantiaAsignacion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtOrden = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbGarantiaPeriodo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnEliminar)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(129, 228)
        Me.Panel1.TabIndex = 0
        '
        'BtnEliminar
        '
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.ForeColor = System.Drawing.Color.White
        Me.BtnEliminar.Location = New System.Drawing.Point(10, 82)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(108, 64)
        Me.BtnEliminar.TabIndex = 3
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.ForeColor = System.Drawing.Color.White
        Me.BtnAceptar.Location = New System.Drawing.Point(10, 12)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(108, 64)
        Me.BtnAceptar.TabIndex = 2
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(10, 152)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(108, 64)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(188, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha"
        '
        'DtpFecha
        '
        Me.DtpFecha.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText
        Me.DtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.DtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha.Location = New System.Drawing.Point(341, 29)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(170, 30)
        Me.DtpFecha.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(188, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Orden #"
        '
        'TxtOrden
        '
        Me.TxtOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrden.Location = New System.Drawing.Point(341, 75)
        Me.TxtOrden.MaxLength = 30
        Me.TxtOrden.Name = "TxtOrden"
        Me.TxtOrden.Size = New System.Drawing.Size(170, 30)
        Me.TxtOrden.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(188, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Duración"
        '
        'CmbGarantiaPeriodo
        '
        Me.CmbGarantiaPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGarantiaPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbGarantiaPeriodo.FormattingEnabled = True
        Me.CmbGarantiaPeriodo.Location = New System.Drawing.Point(341, 121)
        Me.CmbGarantiaPeriodo.Name = "CmbGarantiaPeriodo"
        Me.CmbGarantiaPeriodo.Size = New System.Drawing.Size(170, 33)
        Me.CmbGarantiaPeriodo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(188, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Vencimiento"
        '
        'DtpVencimiento
        '
        Me.DtpVencimiento.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText
        Me.DtpVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.DtpVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpVencimiento.Location = New System.Drawing.Point(341, 171)
        Me.DtpVencimiento.Name = "DtpVencimiento"
        Me.DtpVencimiento.Size = New System.Drawing.Size(170, 30)
        Me.DtpVencimiento.TabIndex = 8
        '
        'FrmGarantiaAsignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(588, 228)
        Me.Controls.Add(Me.DtpVencimiento)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbGarantiaPeriodo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtOrden)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGarantiaAsignacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmGarantiaAsignacion"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents DtpFecha As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtOrden As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CmbGarantiaPeriodo As ComboBox
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents DtpVencimiento As DateTimePicker
    Friend WithEvents BtnEliminar As Button
End Class
