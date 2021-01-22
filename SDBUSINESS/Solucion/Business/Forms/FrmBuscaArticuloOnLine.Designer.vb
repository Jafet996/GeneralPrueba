<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscaArticuloOnLine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscaArticuloOnLine))
        Me.TxtCriterio = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RdbIniciaCon = New System.Windows.Forms.RadioButton()
        Me.RdbContiene = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RdbCodigoInterno = New System.Windows.Forms.RadioButton()
        Me.RdbCodigoPtoveedor = New System.Windows.Forms.RadioButton()
        Me.RdbCodigoEquivalente = New System.Windows.Forms.RadioButton()
        Me.RdbCodigo = New System.Windows.Forms.RadioButton()
        Me.RdbDescripcion = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCriterio
        '
        Me.TxtCriterio.ForeColor = System.Drawing.Color.Black
        Me.TxtCriterio.Location = New System.Drawing.Point(65, 128)
        Me.TxtCriterio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCriterio.MaxLength = 50
        Me.TxtCriterio.Name = "TxtCriterio"
        Me.TxtCriterio.Size = New System.Drawing.Size(686, 22)
        Me.TxtCriterio.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.LblMensaje)
        Me.GroupBox1.Controls.Add(Me.TxtCriterio)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1524, 181)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RdbIniciaCon)
        Me.GroupBox3.Controls.Add(Me.RdbContiene)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(759, 15)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(267, 95)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo Busqueda"
        '
        'RdbIniciaCon
        '
        Me.RdbIniciaCon.AutoSize = True
        Me.RdbIniciaCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbIniciaCon.Location = New System.Drawing.Point(129, 57)
        Me.RdbIniciaCon.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbIniciaCon.Name = "RdbIniciaCon"
        Me.RdbIniciaCon.Size = New System.Drawing.Size(104, 22)
        Me.RdbIniciaCon.TabIndex = 8
        Me.RdbIniciaCon.Text = "Inicia Con"
        Me.RdbIniciaCon.UseVisualStyleBackColor = True
        '
        'RdbContiene
        '
        Me.RdbContiene.AutoSize = True
        Me.RdbContiene.Checked = True
        Me.RdbContiene.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbContiene.Location = New System.Drawing.Point(129, 25)
        Me.RdbContiene.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbContiene.Name = "RdbContiene"
        Me.RdbContiene.Size = New System.Drawing.Size(96, 22)
        Me.RdbContiene.TabIndex = 7
        Me.RdbContiene.TabStop = True
        Me.RdbContiene.Text = "Contiene"
        Me.RdbContiene.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RdbCodigoInterno)
        Me.GroupBox2.Controls.Add(Me.RdbCodigoPtoveedor)
        Me.GroupBox2.Controls.Add(Me.RdbCodigoEquivalente)
        Me.GroupBox2.Controls.Add(Me.RdbCodigo)
        Me.GroupBox2.Controls.Add(Me.RdbDescripcion)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(65, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(686, 95)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Criterio"
        '
        'RdbCodigoInterno
        '
        Me.RdbCodigoInterno.AutoSize = True
        Me.RdbCodigoInterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbCodigoInterno.Location = New System.Drawing.Point(513, 25)
        Me.RdbCodigoInterno.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbCodigoInterno.Name = "RdbCodigoInterno"
        Me.RdbCodigoInterno.Size = New System.Drawing.Size(140, 22)
        Me.RdbCodigoInterno.TabIndex = 9
        Me.RdbCodigoInterno.Text = "Código Interno"
        Me.RdbCodigoInterno.UseVisualStyleBackColor = True
        '
        'RdbCodigoPtoveedor
        '
        Me.RdbCodigoPtoveedor.AutoSize = True
        Me.RdbCodigoPtoveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbCodigoPtoveedor.Location = New System.Drawing.Point(253, 57)
        Me.RdbCodigoPtoveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbCodigoPtoveedor.Name = "RdbCodigoPtoveedor"
        Me.RdbCodigoPtoveedor.Size = New System.Drawing.Size(166, 22)
        Me.RdbCodigoPtoveedor.TabIndex = 8
        Me.RdbCodigoPtoveedor.Text = "Código Proveedor"
        Me.RdbCodigoPtoveedor.UseVisualStyleBackColor = True
        '
        'RdbCodigoEquivalente
        '
        Me.RdbCodigoEquivalente.AutoSize = True
        Me.RdbCodigoEquivalente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbCodigoEquivalente.Location = New System.Drawing.Point(253, 25)
        Me.RdbCodigoEquivalente.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbCodigoEquivalente.Name = "RdbCodigoEquivalente"
        Me.RdbCodigoEquivalente.Size = New System.Drawing.Size(174, 22)
        Me.RdbCodigoEquivalente.TabIndex = 7
        Me.RdbCodigoEquivalente.Text = "Código Equivalente"
        Me.RdbCodigoEquivalente.UseVisualStyleBackColor = True
        '
        'RdbCodigo
        '
        Me.RdbCodigo.AutoSize = True
        Me.RdbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbCodigo.Location = New System.Drawing.Point(63, 57)
        Me.RdbCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbCodigo.Name = "RdbCodigo"
        Me.RdbCodigo.Size = New System.Drawing.Size(83, 22)
        Me.RdbCodigo.TabIndex = 6
        Me.RdbCodigo.Text = "Código"
        Me.RdbCodigo.UseVisualStyleBackColor = True
        '
        'RdbDescripcion
        '
        Me.RdbDescripcion.AutoSize = True
        Me.RdbDescripcion.Checked = True
        Me.RdbDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbDescripcion.Location = New System.Drawing.Point(63, 25)
        Me.RdbDescripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbDescripcion.Name = "RdbDescripcion"
        Me.RdbDescripcion.Size = New System.Drawing.Size(119, 22)
        Me.RdbDescripcion.TabIndex = 5
        Me.RdbDescripcion.TabStop = True
        Me.RdbDescripcion.Text = "Descripción"
        Me.RdbDescripcion.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Business.My.Resources.Resources.view
        Me.PictureBox1.Location = New System.Drawing.Point(1069, 41)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(59, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'LblMensaje
        '
        Me.LblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.ForeColor = System.Drawing.Color.White
        Me.LblMensaje.Location = New System.Drawing.Point(1135, 48)
        Me.LblMensaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(371, 28)
        Me.LblMensaje.TabIndex = 2
        Me.LblMensaje.Text = "No se encontraron datos relacionados"
        Me.LblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 773)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1524, 22)
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
        Me.DGDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGDetalle.Location = New System.Drawing.Point(0, 181)
        Me.DGDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.Size = New System.Drawing.Size(1524, 592)
        Me.DGDetalle.TabIndex = 5
        '
        'FrmBuscaArticuloOnLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1524, 795)
        Me.Controls.Add(Me.DGDetalle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBuscaArticuloOnLine"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de Artículos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCriterio As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents DGDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents LblMensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents RdbIniciaCon As Windows.Forms.RadioButton
    Friend WithEvents RdbContiene As Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents RdbCodigo As Windows.Forms.RadioButton
    Friend WithEvents RdbDescripcion As Windows.Forms.RadioButton
    Friend WithEvents RdbCodigoPtoveedor As Windows.Forms.RadioButton
    Friend WithEvents RdbCodigoEquivalente As Windows.Forms.RadioButton
    Friend WithEvents RdbCodigoInterno As Windows.Forms.RadioButton
End Class
