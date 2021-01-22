<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscaArticuloTomaFisica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscaArticuloTomaFisica))
        Me.PnlCriterio = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.TxtCriterio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGDetalle = New System.Windows.Forms.DataGridView()
        Me.PnlCriterio.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlCriterio
        '
        Me.PnlCriterio.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlCriterio.Controls.Add(Me.PictureBox1)
        Me.PnlCriterio.Controls.Add(Me.LblMensaje)
        Me.PnlCriterio.Controls.Add(Me.TxtCriterio)
        Me.PnlCriterio.Controls.Add(Me.Label1)
        Me.PnlCriterio.Location = New System.Drawing.Point(1, 3)
        Me.PnlCriterio.Name = "PnlCriterio"
        Me.PnlCriterio.Size = New System.Drawing.Size(745, 57)
        Me.PnlCriterio.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Inventario.My.Resources.Resources.view
        Me.PictureBox1.Location = New System.Drawing.Point(406, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(44, 39)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'LblMensaje
        '
        Me.LblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.ForeColor = System.Drawing.Color.White
        Me.LblMensaje.Location = New System.Drawing.Point(456, 17)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(278, 23)
        Me.LblMensaje.TabIndex = 6
        Me.LblMensaje.Text = "No se encontraron datos relacionados"
        Me.LblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCriterio
        '
        Me.TxtCriterio.ForeColor = System.Drawing.Color.Black
        Me.TxtCriterio.Location = New System.Drawing.Point(91, 18)
        Me.TxtCriterio.MaxLength = 50
        Me.TxtCriterio.Name = "TxtCriterio"
        Me.TxtCriterio.Size = New System.Drawing.Size(309, 20)
        Me.TxtCriterio.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Descripción"
        '
        'DGDetalle
        '
        Me.DGDetalle.AllowUserToAddRows = False
        Me.DGDetalle.AllowUserToDeleteRows = False
        Me.DGDetalle.BackgroundColor = System.Drawing.Color.White
        Me.DGDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetalle.Location = New System.Drawing.Point(1, 57)
        Me.DGDetalle.Name = "DGDetalle"
        Me.DGDetalle.ReadOnly = True
        Me.DGDetalle.Size = New System.Drawing.Size(745, 379)
        Me.DGDetalle.TabIndex = 1
        '
        'FrmBuscaArticuloTomaFisica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 436)
        Me.Controls.Add(Me.DGDetalle)
        Me.Controls.Add(Me.PnlCriterio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBuscaArticuloTomaFisica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de Artículos"
        Me.PnlCriterio.ResumeLayout(False)
        Me.PnlCriterio.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlCriterio As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblMensaje As System.Windows.Forms.Label
    Friend WithEvents TxtCriterio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGDetalle As System.Windows.Forms.DataGridView
End Class
