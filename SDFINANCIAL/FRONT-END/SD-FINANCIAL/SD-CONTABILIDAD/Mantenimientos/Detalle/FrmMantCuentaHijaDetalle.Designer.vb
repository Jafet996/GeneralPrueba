<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantCuentaHijaDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantCuentaHijaDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.LblCuentaPadre = New System.Windows.Forms.Label()
        Me.LblNombrePadre = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbMoneda = New System.Windows.Forms.ComboBox()
        Me.CmbClase = New System.Windows.Forms.ComboBox()
        Me.CmbTipo = New System.Windows.Forms.ComboBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtCuenta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtNivel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkAceptaMovimientos = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChkSolicitaCentroCosto = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(85, 270)
        Me.Panel1.TabIndex = 2
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Location = New System.Drawing.Point(4, 56)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 38)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.TabStop = False
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Location = New System.Drawing.Point(4, 12)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 38)
        Me.BtnGuardar.TabIndex = 7
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'LblCuentaPadre
        '
        Me.LblCuentaPadre.BackColor = System.Drawing.Color.White
        Me.LblCuentaPadre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblCuentaPadre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblCuentaPadre.Location = New System.Drawing.Point(15, 23)
        Me.LblCuentaPadre.Name = "LblCuentaPadre"
        Me.LblCuentaPadre.Size = New System.Drawing.Size(129, 23)
        Me.LblCuentaPadre.TabIndex = 4
        Me.LblCuentaPadre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblNombrePadre
        '
        Me.LblNombrePadre.BackColor = System.Drawing.Color.White
        Me.LblNombrePadre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblNombrePadre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblNombrePadre.Location = New System.Drawing.Point(150, 23)
        Me.LblNombrePadre.Name = "LblNombrePadre"
        Me.LblNombrePadre.Size = New System.Drawing.Size(276, 23)
        Me.LblNombrePadre.TabIndex = 5
        Me.LblNombrePadre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblCuentaPadre)
        Me.GroupBox1.Controls.Add(Me.LblNombrePadre)
        Me.GroupBox1.Font = New System.Drawing.Font("Tempus Sans ITC", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox1.Location = New System.Drawing.Point(91, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(439, 61)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cuenta Padre"
        '
        'CmbMoneda
        '
        Me.CmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMoneda.FormattingEnabled = True
        Me.CmbMoneda.Items.AddRange(New Object() {"Colones", "Dolares"})
        Me.CmbMoneda.Location = New System.Drawing.Point(78, 130)
        Me.CmbMoneda.Name = "CmbMoneda"
        Me.CmbMoneda.Size = New System.Drawing.Size(137, 21)
        Me.CmbMoneda.TabIndex = 4
        '
        'CmbClase
        '
        Me.CmbClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbClase.Enabled = False
        Me.CmbClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbClase.FormattingEnabled = True
        Me.CmbClase.Location = New System.Drawing.Point(78, 103)
        Me.CmbClase.Name = "CmbClase"
        Me.CmbClase.Size = New System.Drawing.Size(349, 21)
        Me.CmbClase.TabIndex = 3
        '
        'CmbTipo
        '
        Me.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipo.Enabled = False
        Me.CmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTipo.FormattingEnabled = True
        Me.CmbTipo.Location = New System.Drawing.Point(78, 76)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(349, 21)
        Me.CmbTipo.TabIndex = 2
        '
        'TxtNombre
        '
        Me.TxtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.Location = New System.Drawing.Point(78, 50)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(349, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Checked = True
        Me.ChkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkActivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkActivo.Location = New System.Drawing.Point(302, 134)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(56, 17)
        Me.ChkActivo.TabIndex = 6
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(26, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Moneda"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(26, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Clase"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(26, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Tipo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(26, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Nombre"
        '
        'TxtCuenta
        '
        Me.TxtCuenta.BackColor = System.Drawing.Color.White
        Me.TxtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuenta.Location = New System.Drawing.Point(78, 24)
        Me.TxtCuenta.Name = "TxtCuenta"
        Me.TxtCuenta.ReadOnly = True
        Me.TxtCuenta.Size = New System.Drawing.Size(240, 20)
        Me.TxtCuenta.TabIndex = 0
        Me.TxtCuenta.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(26, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Cuenta"
        '
        'TxtNivel
        '
        Me.TxtNivel.BackColor = System.Drawing.Color.White
        Me.TxtNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNivel.Location = New System.Drawing.Point(372, 24)
        Me.TxtNivel.Name = "TxtNivel"
        Me.TxtNivel.ReadOnly = True
        Me.TxtNivel.Size = New System.Drawing.Size(55, 20)
        Me.TxtNivel.TabIndex = 23
        Me.TxtNivel.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(335, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Nivel"
        '
        'ChkAceptaMovimientos
        '
        Me.ChkAceptaMovimientos.AutoSize = True
        Me.ChkAceptaMovimientos.Checked = True
        Me.ChkAceptaMovimientos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAceptaMovimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAceptaMovimientos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkAceptaMovimientos.Location = New System.Drawing.Point(78, 157)
        Me.ChkAceptaMovimientos.Name = "ChkAceptaMovimientos"
        Me.ChkAceptaMovimientos.Size = New System.Drawing.Size(122, 17)
        Me.ChkAceptaMovimientos.TabIndex = 5
        Me.ChkAceptaMovimientos.Text = "Acepta Movimientos"
        Me.ChkAceptaMovimientos.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkSolicitaCentroCosto)
        Me.GroupBox2.Controls.Add(Me.TxtCuenta)
        Me.GroupBox2.Controls.Add(Me.ChkAceptaMovimientos)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TxtNivel)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.ChkActivo)
        Me.GroupBox2.Controls.Add(Me.CmbMoneda)
        Me.GroupBox2.Controls.Add(Me.TxtNombre)
        Me.GroupBox2.Controls.Add(Me.CmbClase)
        Me.GroupBox2.Controls.Add(Me.CmbTipo)
        Me.GroupBox2.Font = New System.Drawing.Font("Tempus Sans ITC", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox2.Location = New System.Drawing.Point(91, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(439, 191)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sub Cuenta"
        '
        'ChkSolicitaCentroCosto
        '
        Me.ChkSolicitaCentroCosto.AutoSize = True
        Me.ChkSolicitaCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkSolicitaCentroCosto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkSolicitaCentroCosto.Location = New System.Drawing.Point(302, 157)
        Me.ChkSolicitaCentroCosto.Name = "ChkSolicitaCentroCosto"
        Me.ChkSolicitaCentroCosto.Size = New System.Drawing.Size(124, 17)
        Me.ChkSolicitaCentroCosto.TabIndex = 25
        Me.ChkSolicitaCentroCosto.Text = "Solicita Centro Costo"
        Me.ChkSolicitaCentroCosto.UseVisualStyleBackColor = True
        '
        'FrmMantCuentaHijaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(536, 270)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantCuentaHijaDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents LblCuentaPadre As System.Windows.Forms.Label
    Friend WithEvents LblNombrePadre As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents CmbClase As System.Windows.Forms.ComboBox
    Friend WithEvents CmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNivel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkAceptaMovimientos As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkSolicitaCentroCosto As System.Windows.Forms.CheckBox
End Class
