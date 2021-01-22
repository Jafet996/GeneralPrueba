<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantCatalogoLista
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantCatalogoLista))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.TrwCuentas = New System.Windows.Forms.TreeView()
        Me.CMSCuentas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BtnNueva = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnAgregar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImgCuentas = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1.SuspendLayout()
        Me.CMSCuentas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(76, 735)
        Me.Panel1.TabIndex = 1
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.SDCONTABILIDAD.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(10, 13)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(56, 69)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'TrwCuentas
        '
        Me.TrwCuentas.ContextMenuStrip = Me.CMSCuentas
        Me.TrwCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrwCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrwCuentas.HideSelection = False
        Me.TrwCuentas.ImageIndex = 0
        Me.TrwCuentas.ImageList = Me.ImgCuentas
        Me.TrwCuentas.Location = New System.Drawing.Point(76, 0)
        Me.TrwCuentas.Name = "TrwCuentas"
        Me.TrwCuentas.SelectedImageIndex = 2
        Me.TrwCuentas.Size = New System.Drawing.Size(812, 735)
        Me.TrwCuentas.TabIndex = 2
        '
        'CMSCuentas
        '
        Me.CMSCuentas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNueva, Me.BtnAgregar, Me.BtnModificar})
        Me.CMSCuentas.Name = "CMSCuentas"
        Me.CMSCuentas.Size = New System.Drawing.Size(187, 70)
        '
        'BtnNueva
        '
        Me.BtnNueva.Name = "BtnNueva"
        Me.BtnNueva.Size = New System.Drawing.Size(186, 22)
        Me.BtnNueva.Text = "Nueva Cuenta Mayor"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(186, 22)
        Me.BtnAgregar.Text = "Agrega Sub Cuenta"
        '
        'BtnModificar
        '
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(186, 22)
        Me.BtnModificar.Text = "Modifica Cuenta"
        '
        'ImgCuentas
        '
        Me.ImgCuentas.ImageStream = CType(resources.GetObject("ImgCuentas.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgCuentas.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgCuentas.Images.SetKeyName(0, "folder.ico")
        Me.ImgCuentas.Images.SetKeyName(1, "form_blue.ico")
        Me.ImgCuentas.Images.SetKeyName(2, "arrow_right_green.ico")
        '
        'FrmMantCatalogoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 735)
        Me.Controls.Add(Me.TrwCuentas)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantCatalogoLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo Contable"
        Me.Panel1.ResumeLayout(False)
        Me.CMSCuentas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents TrwCuentas As System.Windows.Forms.TreeView
    Friend WithEvents ImgCuentas As System.Windows.Forms.ImageList
    Friend WithEvents CMSCuentas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BtnNueva As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnAgregar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnModificar As System.Windows.Forms.ToolStripMenuItem
End Class
