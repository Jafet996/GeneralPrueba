﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMovimientoFormaPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovimientoFormaPago))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnElectronica = New System.Windows.Forms.Button()
        Me.BtnFisica = New System.Windows.Forms.Button()
        Me.PicVolver = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PicVolver, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(38, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccione el tipo de transacción a realizar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(335, 61)
        Me.Panel1.TabIndex = 1
        '
        'BtnElectronica
        '
        Me.BtnElectronica.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BtnElectronica.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnElectronica.Location = New System.Drawing.Point(95, 129)
        Me.BtnElectronica.Name = "BtnElectronica"
        Me.BtnElectronica.Size = New System.Drawing.Size(172, 43)
        Me.BtnElectronica.TabIndex = 3
        Me.BtnElectronica.Text = "Transacción Electrónica"
        Me.BtnElectronica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnElectronica.UseVisualStyleBackColor = False
        '
        'BtnFisica
        '
        Me.BtnFisica.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BtnFisica.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFisica.Location = New System.Drawing.Point(95, 80)
        Me.BtnFisica.Name = "BtnFisica"
        Me.BtnFisica.Size = New System.Drawing.Size(172, 43)
        Me.BtnFisica.TabIndex = 2
        Me.BtnFisica.Text = "Transacción Física"
        Me.BtnFisica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnFisica.UseVisualStyleBackColor = False
        '
        'PicVolver
        '
        Me.PicVolver.Image = CType(resources.GetObject("PicVolver.Image"), System.Drawing.Image)
        Me.PicVolver.Location = New System.Drawing.Point(0, 186)
        Me.PicVolver.Name = "PicVolver"
        Me.PicVolver.Size = New System.Drawing.Size(32, 32)
        Me.PicVolver.TabIndex = 30
        Me.PicVolver.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SDCXC.My.Resources.Resources.cashier
        Me.PictureBox1.Location = New System.Drawing.Point(57, 84)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SDCXC.My.Resources.Resources.laptop
        Me.PictureBox2.Location = New System.Drawing.Point(57, 134)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 32
        Me.PictureBox2.TabStop = False
        '
        'FrmMovimientoFormaPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(335, 218)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PicVolver)
        Me.Controls.Add(Me.BtnElectronica)
        Me.Controls.Add(Me.BtnFisica)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMovimientoFormaPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PicVolver, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnFisica As System.Windows.Forms.Button
    Friend WithEvents BtnElectronica As System.Windows.Forms.Button
    Friend WithEvents PicVolver As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
