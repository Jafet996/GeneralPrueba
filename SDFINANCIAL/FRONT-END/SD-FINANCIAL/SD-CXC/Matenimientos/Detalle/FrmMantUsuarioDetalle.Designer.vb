<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantUsuarioDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantUsuarioDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LvwPermisos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.PanelGeneral1 = New System.Windows.Forms.Panel()
        Me.CmbGrupo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtConfirmar = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPrincipal = New System.Windows.Forms.TabControl()
        Me.Panel1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PanelGeneral1.SuspendLayout()
        Me.TabPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(85, 488)
        Me.Panel1.TabIndex = 0
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Location = New System.Drawing.Point(4, 56)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(75, 38)
        Me.BtnLimpiar.TabIndex = 7
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(4, 100)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 38)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.Location = New System.Drawing.Point(4, 12)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 38)
        Me.BtnGuardar.TabIndex = 6
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.LvwPermisos)
        Me.TabPage1.Controls.Add(Me.TxtCodigo)
        Me.TabPage1.Controls.Add(Me.PanelGeneral1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(442, 438)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LvwPermisos
        '
        Me.LvwPermisos.CheckBoxes = True
        Me.LvwPermisos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.LvwPermisos.Location = New System.Drawing.Point(6, 160)
        Me.LvwPermisos.Name = "LvwPermisos"
        Me.LvwPermisos.Size = New System.Drawing.Size(430, 275)
        Me.LvwPermisos.TabIndex = 28
        Me.LvwPermisos.UseCompatibleStateImageBehavior = False
        Me.LvwPermisos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Permisos"
        Me.ColumnHeader1.Width = 408
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(108, 15)
        Me.TxtCodigo.MaxLength = 20
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(121, 20)
        Me.TxtCodigo.TabIndex = 0
        '
        'PanelGeneral1
        '
        Me.PanelGeneral1.Controls.Add(Me.CmbGrupo)
        Me.PanelGeneral1.Controls.Add(Me.Label6)
        Me.PanelGeneral1.Controls.Add(Me.Label4)
        Me.PanelGeneral1.Controls.Add(Me.TxtConfirmar)
        Me.PanelGeneral1.Controls.Add(Me.Label3)
        Me.PanelGeneral1.Controls.Add(Me.TxtPassword)
        Me.PanelGeneral1.Controls.Add(Me.ChkActivo)
        Me.PanelGeneral1.Controls.Add(Me.Label2)
        Me.PanelGeneral1.Controls.Add(Me.TxtNombre)
        Me.PanelGeneral1.Location = New System.Drawing.Point(6, 37)
        Me.PanelGeneral1.Name = "PanelGeneral1"
        Me.PanelGeneral1.Size = New System.Drawing.Size(430, 117)
        Me.PanelGeneral1.TabIndex = 27
        '
        'CmbGrupo
        '
        Me.CmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGrupo.FormattingEnabled = True
        Me.CmbGrupo.Location = New System.Drawing.Point(102, 81)
        Me.CmbGrupo.Name = "CmbGrupo"
        Me.CmbGrupo.Size = New System.Drawing.Size(295, 21)
        Me.CmbGrupo.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Grupo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Confirmar"
        '
        'TxtConfirmar
        '
        Me.TxtConfirmar.Location = New System.Drawing.Point(102, 55)
        Me.TxtConfirmar.MaxLength = 20
        Me.TxtConfirmar.Name = "TxtConfirmar"
        Me.TxtConfirmar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmar.Size = New System.Drawing.Size(121, 20)
        Me.TxtConfirmar.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Password"
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(102, 29)
        Me.TxtPassword.MaxLength = 20
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(121, 20)
        Me.TxtPassword.TabIndex = 2
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Checked = True
        Me.ChkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivo.Location = New System.Drawing.Point(341, 54)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(56, 17)
        Me.ChkActivo.TabIndex = 5
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(102, 3)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(295, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código"
        '
        'TabPrincipal
        '
        Me.TabPrincipal.Controls.Add(Me.TabPage1)
        Me.TabPrincipal.Location = New System.Drawing.Point(91, 12)
        Me.TabPrincipal.Name = "TabPrincipal"
        Me.TabPrincipal.SelectedIndex = 0
        Me.TabPrincipal.Size = New System.Drawing.Size(450, 464)
        Me.TabPrincipal.TabIndex = 25
        '
        'FrmMantUsuarioDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(543, 488)
        Me.Controls.Add(Me.TabPrincipal)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantUsuarioDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        Me.Panel1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.PanelGeneral1.ResumeLayout(False)
        Me.PanelGeneral1.PerformLayout()
        Me.TabPrincipal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents LvwPermisos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents PanelGeneral1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPrincipal As System.Windows.Forms.TabControl
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbGrupo As System.Windows.Forms.ComboBox
End Class
