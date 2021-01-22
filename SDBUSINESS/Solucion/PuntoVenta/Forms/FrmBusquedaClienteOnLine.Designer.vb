<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaClienteOnLine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaClienteOnLine))
        Me.TxtCriterio = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RdbCedula = New System.Windows.Forms.RadioButton()
        Me.RdbNombre = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCriterio
        '
        Me.TxtCriterio.Location = New System.Drawing.Point(141, 40)
        Me.TxtCriterio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCriterio.MaxLength = 50
        Me.TxtCriterio.Name = "TxtCriterio"
        Me.TxtCriterio.Size = New System.Drawing.Size(462, 22)
        Me.TxtCriterio.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.RdbCedula)
        Me.GroupBox1.Controls.Add(Me.RdbNombre)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.LblMensaje)
        Me.GroupBox1.Controls.Add(Me.TxtCriterio)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1081, 103)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'RdbCedula
        '
        Me.RdbCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RdbCedula.ForeColor = System.Drawing.Color.White
        Me.RdbCedula.Location = New System.Drawing.Point(10, 54)
        Me.RdbCedula.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbCedula.Name = "RdbCedula"
        Me.RdbCedula.Size = New System.Drawing.Size(120, 21)
        Me.RdbCedula.TabIndex = 2
        Me.RdbCedula.Text = "&Cédula"
        Me.RdbCedula.UseVisualStyleBackColor = True
        '
        'RdbNombre
        '
        Me.RdbNombre.Checked = True
        Me.RdbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RdbNombre.ForeColor = System.Drawing.Color.White
        Me.RdbNombre.Location = New System.Drawing.Point(10, 23)
        Me.RdbNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbNombre.Name = "RdbNombre"
        Me.RdbNombre.Size = New System.Drawing.Size(120, 21)
        Me.RdbNombre.TabIndex = 1
        Me.RdbNombre.TabStop = True
        Me.RdbNombre.Text = "&Nombre"
        Me.RdbNombre.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PuntoVenta.My.Resources.Resources.view
        Me.PictureBox1.Location = New System.Drawing.Point(613, 27)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(59, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'LblMensaje
        '
        Me.LblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.ForeColor = System.Drawing.Color.White
        Me.LblMensaje.Location = New System.Drawing.Point(695, 37)
        Me.LblMensaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(371, 28)
        Me.LblMensaje.TabIndex = 6
        Me.LblMensaje.Text = "No se encontraron datos relacionados"
        Me.LblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 609)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1084, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'DGDetalle
        '
        Me.DGDetalle.AllowUserToAddRows = False
        Me.DGDetalle.AllowUserToDeleteRows = False
        Me.DGDetalle.BackgroundColor = System.Drawing.Color.White
        Me.DGDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetalle.Location = New System.Drawing.Point(3, 111)
        Me.DGDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.Size = New System.Drawing.Size(1081, 490)
        Me.DGDetalle.TabIndex = 5
        '
        'FrmBusquedaClienteOnLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1084, 631)
        Me.Controls.Add(Me.DGDetalle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaClienteOnLine"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de Clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCriterio As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents DGDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblMensaje As System.Windows.Forms.Label
    Friend WithEvents RdbCedula As RadioButton
    Friend WithEvents RdbNombre As RadioButton
End Class
