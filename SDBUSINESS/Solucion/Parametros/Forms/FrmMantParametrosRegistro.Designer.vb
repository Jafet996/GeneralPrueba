<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantParametrosRegistro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantParametrosRegistro))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPuertoSerial = New System.Windows.Forms.TextBox()
        Me.TxtBaseDatos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtEmpresa = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPuertoParalelo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbTipoImpresora = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtCaja = New System.Windows.Forms.TextBox()
        Me.TxtServidor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtSucursal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TxtWSRecargaTelefonica = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtCodigoDetallista = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Caja :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Puerto Serial :"
        '
        'TxtPuertoSerial
        '
        Me.TxtPuertoSerial.Location = New System.Drawing.Point(117, 58)
        Me.TxtPuertoSerial.MaxLength = 5
        Me.TxtPuertoSerial.Name = "TxtPuertoSerial"
        Me.TxtPuertoSerial.Size = New System.Drawing.Size(53, 20)
        Me.TxtPuertoSerial.TabIndex = 8
        '
        'TxtBaseDatos
        '
        Me.TxtBaseDatos.Location = New System.Drawing.Point(117, 113)
        Me.TxtBaseDatos.MaxLength = 30
        Me.TxtBaseDatos.Name = "TxtBaseDatos"
        Me.TxtBaseDatos.Size = New System.Drawing.Size(154, 20)
        Me.TxtBaseDatos.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Base Datos :"
        '
        'TxtEmpresa
        '
        Me.TxtEmpresa.Location = New System.Drawing.Point(108, 39)
        Me.TxtEmpresa.MaxLength = 3
        Me.TxtEmpresa.Name = "TxtEmpresa"
        Me.TxtEmpresa.Size = New System.Drawing.Size(53, 20)
        Me.TxtEmpresa.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Empresa :"
        '
        'TxtPuertoParalelo
        '
        Me.TxtPuertoParalelo.Location = New System.Drawing.Point(117, 84)
        Me.TxtPuertoParalelo.MaxLength = 5
        Me.TxtPuertoParalelo.Name = "TxtPuertoParalelo"
        Me.TxtPuertoParalelo.Size = New System.Drawing.Size(53, 20)
        Me.TxtPuertoParalelo.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Puerto Paralelo :"
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(117, 61)
        Me.TxtPassword.MaxLength = 20
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(154, 20)
        Me.TxtPassword.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Password :"
        '
        'CmbTipoImpresora
        '
        Me.CmbTipoImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoImpresora.FormattingEnabled = True
        Me.CmbTipoImpresora.Items.AddRange(New Object() {"Serial", "Windows", "Paralela"})
        Me.CmbTipoImpresora.Location = New System.Drawing.Point(117, 31)
        Me.CmbTipoImpresora.Name = "CmbTipoImpresora"
        Me.CmbTipoImpresora.Size = New System.Drawing.Size(154, 21)
        Me.CmbTipoImpresora.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Tipo :"
        '
        'TxtCaja
        '
        Me.TxtCaja.Location = New System.Drawing.Point(108, 91)
        Me.TxtCaja.MaxLength = 3
        Me.TxtCaja.Name = "TxtCaja"
        Me.TxtCaja.Size = New System.Drawing.Size(53, 20)
        Me.TxtCaja.TabIndex = 6
        '
        'TxtServidor
        '
        Me.TxtServidor.Location = New System.Drawing.Point(117, 87)
        Me.TxtServidor.MaxLength = 50
        Me.TxtServidor.Name = "TxtServidor"
        Me.TxtServidor.Size = New System.Drawing.Size(154, 20)
        Me.TxtServidor.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Servidor :"
        '
        'TxtSucursal
        '
        Me.TxtSucursal.Location = New System.Drawing.Point(108, 65)
        Me.TxtSucursal.MaxLength = 3
        Me.TxtSucursal.Name = "TxtSucursal"
        Me.TxtSucursal.Size = New System.Drawing.Size(53, 20)
        Me.TxtSucursal.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Sucursal :"
        '
        'TxtUsuario
        '
        Me.TxtUsuario.Location = New System.Drawing.Point(117, 35)
        Me.TxtUsuario.MaxLength = 20
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(154, 20)
        Me.TxtUsuario.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(26, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Usuario :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtUsuario)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TxtPassword)
        Me.GroupBox1.Controls.Add(Me.TxtServidor)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtBaseDatos)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 161)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Conexión"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtEmpresa)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TxtCaja)
        Me.GroupBox2.Controls.Add(Me.TxtSucursal)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(323, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 161)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Empresa"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CmbTipoImpresora)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TxtPuertoSerial)
        Me.GroupBox3.Controls.Add(Me.TxtPuertoParalelo)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(518, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(305, 161)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Impresora"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtWSRecargaTelefonica)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.TxtCodigoDetallista)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 179)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(811, 109)
        Me.GroupBox4.TabIndex = 24
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Recargas Telefónicas"
        '
        'TxtWSRecargaTelefonica
        '
        Me.TxtWSRecargaTelefonica.Location = New System.Drawing.Point(117, 63)
        Me.TxtWSRecargaTelefonica.MaxLength = 200
        Me.TxtWSRecargaTelefonica.Name = "TxtWSRecargaTelefonica"
        Me.TxtWSRecargaTelefonica.Size = New System.Drawing.Size(660, 20)
        Me.TxtWSRecargaTelefonica.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "WS Recarga :"
        '
        'TxtCodigoDetallista
        '
        Me.TxtCodigoDetallista.Location = New System.Drawing.Point(117, 37)
        Me.TxtCodigoDetallista.MaxLength = 20
        Me.TxtCodigoDetallista.Name = "TxtCodigoDetallista"
        Me.TxtCodigoDetallista.Size = New System.Drawing.Size(154, 20)
        Me.TxtCodigoDetallista.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(26, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Detallista :"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(667, 294)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGuardar.TabIndex = 12
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Location = New System.Drawing.Point(748, 294)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 23)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'FrmMantParametrosRegistro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 325)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantParametrosRegistro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMantParametrosRegistro"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPuertoSerial As System.Windows.Forms.TextBox
    Friend WithEvents TxtBaseDatos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPuertoParalelo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoImpresora As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCaja As System.Windows.Forms.TextBox
    Friend WithEvents TxtServidor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCodigoDetallista As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtWSRecargaTelefonica As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
End Class
