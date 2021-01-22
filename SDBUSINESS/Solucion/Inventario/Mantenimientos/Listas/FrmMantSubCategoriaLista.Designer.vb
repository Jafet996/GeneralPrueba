<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantSubCategoriaLista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantSubCategoriaLista))
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.BtnModificar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.GroupOpciones = New System.Windows.Forms.GroupBox()
        Me.GroupLista = New System.Windows.Forms.GroupBox()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupOpciones.SuspendLayout()
        Me.GroupLista.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.BackColor = System.Drawing.Color.White
        Me.BtnRefrescar.Location = New System.Drawing.Point(12, 151)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(75, 38)
        Me.BtnRefrescar.TabIndex = 4
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.UseVisualStyleBackColor = False
        '
        'BtnModificar
        '
        Me.BtnModificar.BackColor = System.Drawing.Color.White
        Me.BtnModificar.Enabled = False
        Me.BtnModificar.Location = New System.Drawing.Point(12, 63)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(75, 38)
        Me.BtnModificar.TabIndex = 3
        Me.BtnModificar.Text = "Modificar"
        Me.BtnModificar.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.White
        Me.BtnEliminar.Enabled = False
        Me.BtnEliminar.Location = New System.Drawing.Point(12, 107)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(75, 38)
        Me.BtnEliminar.TabIndex = 2
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(12, 195)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 38)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.Color.White
        Me.BtnNuevo.Location = New System.Drawing.Point(12, 19)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(75, 38)
        Me.BtnNuevo.TabIndex = 0
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'DGDetalle
        '
        Me.DGDetalle.AllowUserToAddRows = False
        Me.DGDetalle.AllowUserToDeleteRows = False
        Me.DGDetalle.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.DGDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGDetalle.Location = New System.Drawing.Point(3, 16)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.Size = New System.Drawing.Size(548, 388)
        Me.DGDetalle.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(656, 31)
        Me.Panel1.TabIndex = 5
        '
        'LblTitulo
        '
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.SystemColors.Window
        Me.LblTitulo.Location = New System.Drawing.Point(8, 4)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(548, 23)
        Me.LblTitulo.TabIndex = 0
        '
        'GroupOpciones
        '
        Me.GroupOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.GroupOpciones.Controls.Add(Me.BtnNuevo)
        Me.GroupOpciones.Controls.Add(Me.BtnSalir)
        Me.GroupOpciones.Controls.Add(Me.BtnEliminar)
        Me.GroupOpciones.Controls.Add(Me.BtnRefrescar)
        Me.GroupOpciones.Controls.Add(Me.BtnModificar)
        Me.GroupOpciones.Location = New System.Drawing.Point(0, 37)
        Me.GroupOpciones.Name = "GroupOpciones"
        Me.GroupOpciones.Size = New System.Drawing.Size(96, 407)
        Me.GroupOpciones.TabIndex = 6
        Me.GroupOpciones.TabStop = False
        '
        'GroupLista
        '
        Me.GroupLista.Controls.Add(Me.DGDetalle)
        Me.GroupLista.Location = New System.Drawing.Point(102, 37)
        Me.GroupLista.Name = "GroupLista"
        Me.GroupLista.Size = New System.Drawing.Size(554, 407)
        Me.GroupLista.TabIndex = 7
        Me.GroupLista.TabStop = False
        Me.GroupLista.Text = ""
        '
        'FrmMantSubCategoriaLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(656, 444)
        Me.Controls.Add(Me.GroupLista)
        Me.Controls.Add(Me.GroupOpciones)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantSubCategoriaLista"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupOpciones.ResumeLayout(False)
        Me.GroupLista.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnModificar As System.Windows.Forms.Button
    Friend WithEvents BtnRefrescar As System.Windows.Forms.Button
    Friend WithEvents DGDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents GroupOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents GroupLista As System.Windows.Forms.GroupBox
End Class
