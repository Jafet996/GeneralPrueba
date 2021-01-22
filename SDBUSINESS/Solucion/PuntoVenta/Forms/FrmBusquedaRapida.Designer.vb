<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaRapida
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaRapida))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.PicFrecuentesRight = New System.Windows.Forms.PictureBox()
        Me.PicArticuloLeft = New System.Windows.Forms.PictureBox()
        Me.PicFrecuentesLeft = New System.Windows.Forms.PictureBox()
        Me.PicSubCategoriaRight = New System.Windows.Forms.PictureBox()
        Me.PicSubCategoriaLeft = New System.Windows.Forms.PictureBox()
        Me.PicArticuloRight = New System.Windows.Forms.PictureBox()
        Me.PicCategoriaRight = New System.Windows.Forms.PictureBox()
        Me.PicCategoriaLeft = New System.Windows.Forms.PictureBox()
        Me.BtnCantidad = New System.Windows.Forms.Button()
        CType(Me.PicFrecuentesRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicArticuloLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFrecuentesLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSubCategoriaRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSubCategoriaLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicArticuloRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicCategoriaRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicCategoriaLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 685)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1239, 22)
        Me.StatusStrip1.TabIndex = 28
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'PicFrecuentesRight
        '
        Me.PicFrecuentesRight.Enabled = False
        Me.PicFrecuentesRight.Image = CType(resources.GetObject("PicFrecuentesRight.Image"), System.Drawing.Image)
        Me.PicFrecuentesRight.Location = New System.Drawing.Point(1200, 634)
        Me.PicFrecuentesRight.Name = "PicFrecuentesRight"
        Me.PicFrecuentesRight.Size = New System.Drawing.Size(32, 32)
        Me.PicFrecuentesRight.TabIndex = 29
        Me.PicFrecuentesRight.TabStop = False
        '
        'PicArticuloLeft
        '
        Me.PicArticuloLeft.Enabled = False
        Me.PicArticuloLeft.Image = CType(resources.GetObject("PicArticuloLeft.Image"), System.Drawing.Image)
        Me.PicArticuloLeft.Location = New System.Drawing.Point(655, 22)
        Me.PicArticuloLeft.Name = "PicArticuloLeft"
        Me.PicArticuloLeft.Size = New System.Drawing.Size(32, 32)
        Me.PicArticuloLeft.TabIndex = 27
        Me.PicArticuloLeft.TabStop = False
        '
        'PicFrecuentesLeft
        '
        Me.PicFrecuentesLeft.Enabled = False
        Me.PicFrecuentesLeft.Image = CType(resources.GetObject("PicFrecuentesLeft.Image"), System.Drawing.Image)
        Me.PicFrecuentesLeft.Location = New System.Drawing.Point(1200, 22)
        Me.PicFrecuentesLeft.Name = "PicFrecuentesLeft"
        Me.PicFrecuentesLeft.Size = New System.Drawing.Size(32, 32)
        Me.PicFrecuentesLeft.TabIndex = 30
        Me.PicFrecuentesLeft.TabStop = False
        '
        'PicSubCategoriaRight
        '
        Me.PicSubCategoriaRight.Enabled = False
        Me.PicSubCategoriaRight.Image = CType(resources.GetObject("PicSubCategoriaRight.Image"), System.Drawing.Image)
        Me.PicSubCategoriaRight.Location = New System.Drawing.Point(110, 634)
        Me.PicSubCategoriaRight.Name = "PicSubCategoriaRight"
        Me.PicSubCategoriaRight.Size = New System.Drawing.Size(32, 32)
        Me.PicSubCategoriaRight.TabIndex = 21
        Me.PicSubCategoriaRight.TabStop = False
        '
        'PicSubCategoriaLeft
        '
        Me.PicSubCategoriaLeft.Enabled = False
        Me.PicSubCategoriaLeft.Image = CType(resources.GetObject("PicSubCategoriaLeft.Image"), System.Drawing.Image)
        Me.PicSubCategoriaLeft.Location = New System.Drawing.Point(110, 240)
        Me.PicSubCategoriaLeft.Name = "PicSubCategoriaLeft"
        Me.PicSubCategoriaLeft.Size = New System.Drawing.Size(32, 32)
        Me.PicSubCategoriaLeft.TabIndex = 22
        Me.PicSubCategoriaLeft.TabStop = False
        '
        'PicArticuloRight
        '
        Me.PicArticuloRight.Enabled = False
        Me.PicArticuloRight.Image = CType(resources.GetObject("PicArticuloRight.Image"), System.Drawing.Image)
        Me.PicArticuloRight.Location = New System.Drawing.Point(655, 634)
        Me.PicArticuloRight.Name = "PicArticuloRight"
        Me.PicArticuloRight.Size = New System.Drawing.Size(32, 32)
        Me.PicArticuloRight.TabIndex = 23
        Me.PicArticuloRight.TabStop = False
        '
        'PicCategoriaRight
        '
        Me.PicCategoriaRight.Enabled = False
        Me.PicCategoriaRight.Image = CType(resources.GetObject("PicCategoriaRight.Image"), System.Drawing.Image)
        Me.PicCategoriaRight.Location = New System.Drawing.Point(110, 170)
        Me.PicCategoriaRight.Name = "PicCategoriaRight"
        Me.PicCategoriaRight.Size = New System.Drawing.Size(32, 32)
        Me.PicCategoriaRight.TabIndex = 24
        Me.PicCategoriaRight.TabStop = False
        '
        'PicCategoriaLeft
        '
        Me.PicCategoriaLeft.Enabled = False
        Me.PicCategoriaLeft.Image = CType(resources.GetObject("PicCategoriaLeft.Image"), System.Drawing.Image)
        Me.PicCategoriaLeft.Location = New System.Drawing.Point(110, 22)
        Me.PicCategoriaLeft.Name = "PicCategoriaLeft"
        Me.PicCategoriaLeft.Size = New System.Drawing.Size(32, 32)
        Me.PicCategoriaLeft.TabIndex = 25
        Me.PicCategoriaLeft.TabStop = False
        '
        'BtnCantidad
        '
        Me.BtnCantidad.Location = New System.Drawing.Point(12, 646)
        Me.BtnCantidad.Name = "BtnCantidad"
        Me.BtnCantidad.Size = New System.Drawing.Size(79, 36)
        Me.BtnCantidad.TabIndex = 31
        Me.BtnCantidad.Text = "Cantidad"
        Me.BtnCantidad.UseVisualStyleBackColor = True
        Me.BtnCantidad.Visible = False
        '
        'FrmBusquedaRapida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1239, 707)
        Me.Controls.Add(Me.BtnCantidad)
        Me.Controls.Add(Me.PicFrecuentesRight)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PicArticuloLeft)
        Me.Controls.Add(Me.PicFrecuentesLeft)
        Me.Controls.Add(Me.PicSubCategoriaRight)
        Me.Controls.Add(Me.PicSubCategoriaLeft)
        Me.Controls.Add(Me.PicArticuloRight)
        Me.Controls.Add(Me.PicCategoriaRight)
        Me.Controls.Add(Me.PicCategoriaLeft)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaRapida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Búsqueda de artículos"
        CType(Me.PicFrecuentesRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicArticuloLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicFrecuentesLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSubCategoriaRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSubCategoriaLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicArticuloRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicCategoriaRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicCategoriaLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicFrecuentesRight As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents PicArticuloLeft As System.Windows.Forms.PictureBox
    Friend WithEvents PicFrecuentesLeft As System.Windows.Forms.PictureBox
    Friend WithEvents PicSubCategoriaRight As System.Windows.Forms.PictureBox
    Friend WithEvents PicSubCategoriaLeft As System.Windows.Forms.PictureBox
    Friend WithEvents PicArticuloRight As System.Windows.Forms.PictureBox
    Friend WithEvents PicCategoriaRight As System.Windows.Forms.PictureBox
    Friend WithEvents PicCategoriaLeft As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCantidad As System.Windows.Forms.Button
End Class
