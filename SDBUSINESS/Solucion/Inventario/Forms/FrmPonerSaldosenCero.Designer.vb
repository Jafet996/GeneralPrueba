﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPonerSaldosenCero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPonerSaldosenCero))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbSucursal = New System.Windows.Forms.ComboBox()
        Me.CmbBodega = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 178)
        Me.Panel1.TabIndex = 8
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Inventario.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(12, 85)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(59, 70)
        Me.BtnSalir.TabIndex = 13
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.White
        Me.BtnAceptar.Image = Global.Inventario.My.Resources.Resources.Blue_F3
        Me.BtnAceptar.Location = New System.Drawing.Point(12, 12)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(59, 70)
        Me.BtnAceptar.TabIndex = 12
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Sucursal"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursal.FormattingEnabled = True
        Me.CmbSucursal.Location = New System.Drawing.Point(73, 45)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(288, 21)
        Me.CmbSucursal.TabIndex = 12
        '
        'CmbBodega
        '
        Me.CmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBodega.FormattingEnabled = True
        Me.CmbBodega.Location = New System.Drawing.Point(73, 72)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Size = New System.Drawing.Size(288, 21)
        Me.CmbBodega.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Bodega"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbSucursal)
        Me.GroupBox1.Controls.Add(Me.CmbBodega)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(97, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 143)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'FrmPonerSaldosenCero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(494, 178)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPonerSaldosenCero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poner Saldos en Cero"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents CmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class