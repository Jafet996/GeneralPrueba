<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMBuscquedaArticuloCabys
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnSaldos = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxCabys = New System.Windows.Forms.CheckBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.RbnCodEquivalente = New System.Windows.Forms.RadioButton()
        Me.RbtDescripción = New System.Windows.Forms.RadioButton()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.TxtCriterio = New System.Windows.Forms.TextBox()
        Me.Articuloslist = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NOMBREPROD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TotalEncontrados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.BtnSaldos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(137, 640)
        Me.Panel1.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 141)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 98)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Asignar CABYS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Location = New System.Drawing.Point(13, 262)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(112, 95)
        Me.BtnSalir.TabIndex = 6
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnSaldos
        '
        Me.BtnSaldos.BackColor = System.Drawing.Color.White
        Me.BtnSaldos.Location = New System.Drawing.Point(13, 21)
        Me.BtnSaldos.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSaldos.Name = "BtnSaldos"
        Me.BtnSaldos.Size = New System.Drawing.Size(112, 98)
        Me.BtnSaldos.TabIndex = 5
        Me.BtnSaldos.Text = "Buscar Código CABYS"
        Me.BtnSaldos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSaldos.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.CheckBoxCabys)
        Me.GroupBox1.Controls.Add(Me.lblCodigo)
        Me.GroupBox1.Controls.Add(Me.RbnCodEquivalente)
        Me.GroupBox1.Controls.Add(Me.RbtDescripción)
        Me.GroupBox1.Controls.Add(Me.LblMensaje)
        Me.GroupBox1.Controls.Add(Me.TxtCriterio)
        Me.GroupBox1.Location = New System.Drawing.Point(141, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(937, 161)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'CheckBoxCabys
        '
        Me.CheckBoxCabys.AutoSize = True
        Me.CheckBoxCabys.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBoxCabys.ForeColor = System.Drawing.Color.DarkBlue
        Me.CheckBoxCabys.Location = New System.Drawing.Point(37, 86)
        Me.CheckBoxCabys.Name = "CheckBoxCabys"
        Me.CheckBoxCabys.Size = New System.Drawing.Size(245, 21)
        Me.CheckBoxCabys.TabIndex = 9
        Me.CheckBoxCabys.Text = "Articulos sin CABYS asignado"
        Me.CheckBoxCabys.UseVisualStyleBackColor = True
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(1, Byte), True)
        Me.lblCodigo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblCodigo.Location = New System.Drawing.Point(41, 127)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(110, 20)
        Me.lblCodigo.TabIndex = 7
        Me.lblCodigo.Text = "Descripciòn"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RbnCodEquivalente
        '
        Me.RbnCodEquivalente.AutoSize = True
        Me.RbnCodEquivalente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RbnCodEquivalente.ForeColor = System.Drawing.Color.DarkBlue
        Me.RbnCodEquivalente.Location = New System.Drawing.Point(37, 48)
        Me.RbnCodEquivalente.Margin = New System.Windows.Forms.Padding(4)
        Me.RbnCodEquivalente.Name = "RbnCodEquivalente"
        Me.RbnCodEquivalente.Size = New System.Drawing.Size(114, 21)
        Me.RbnCodEquivalente.TabIndex = 2
        Me.RbnCodEquivalente.Text = "&Equivalente"
        Me.RbnCodEquivalente.UseVisualStyleBackColor = True
        '
        'RbtDescripción
        '
        Me.RbtDescripción.AutoSize = True
        Me.RbtDescripción.Checked = True
        Me.RbtDescripción.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RbtDescripción.ForeColor = System.Drawing.Color.DarkBlue
        Me.RbtDescripción.Location = New System.Drawing.Point(37, 15)
        Me.RbtDescripción.Margin = New System.Windows.Forms.Padding(4)
        Me.RbtDescripción.Name = "RbtDescripción"
        Me.RbtDescripción.Size = New System.Drawing.Size(114, 21)
        Me.RbtDescripción.TabIndex = 1
        Me.RbtDescripción.TabStop = True
        Me.RbtDescripción.Text = "&Descripción"
        Me.RbtDescripción.UseVisualStyleBackColor = True
        '
        'LblMensaje
        '
        Me.LblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblMensaje.Location = New System.Drawing.Point(410, 14)
        Me.LblMensaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(371, 34)
        Me.LblMensaje.TabIndex = 4
        Me.LblMensaje.Text = "No se encontraron datos relacionados"
        Me.LblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCriterio
        '
        Me.TxtCriterio.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtCriterio.Location = New System.Drawing.Point(178, 21)
        Me.TxtCriterio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCriterio.MaxLength = 50
        Me.TxtCriterio.Name = "TxtCriterio"
        Me.TxtCriterio.Size = New System.Drawing.Size(217, 22)
        Me.TxtCriterio.TabIndex = 0
        '
        'Articuloslist
        '
        Me.Articuloslist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader7, Me.ColumnHeader8, Me.NOMBREPROD})
        Me.Articuloslist.FullRowSelect = True
        Me.Articuloslist.HideSelection = False
        Me.Articuloslist.Location = New System.Drawing.Point(144, 168)
        Me.Articuloslist.Name = "Articuloslist"
        Me.Articuloslist.Size = New System.Drawing.Size(934, 389)
        Me.Articuloslist.TabIndex = 11
        Me.Articuloslist.UseCompatibleStateImageBehavior = False
        Me.Articuloslist.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Seleccionado"
        Me.ColumnHeader10.Width = 110
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Código"
        Me.ColumnHeader7.Width = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "CABYS"
        Me.ColumnHeader8.Width = 150
        '
        'NOMBREPROD
        '
        Me.NOMBREPROD.Text = "Nombre"
        Me.NOMBREPROD.Width = 250
        '
        'TotalEncontrados
        '
        Me.TotalEncontrados.AutoSize = True
        Me.TotalEncontrados.BackColor = System.Drawing.Color.Lavender
        Me.TotalEncontrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalEncontrados.ForeColor = System.Drawing.Color.Black
        Me.TotalEncontrados.Location = New System.Drawing.Point(370, 569)
        Me.TotalEncontrados.Name = "TotalEncontrados"
        Me.TotalEncontrados.Size = New System.Drawing.Size(0, 24)
        Me.TotalEncontrados.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(158, 569)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 24)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Total Encotrados:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(159, 603)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(459, 18)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "* Esta búsqueda solo contempla artículos que están activos"
        '
        'FRMBuscquedaArticuloCabys
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 640)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TotalEncontrados)
        Me.Controls.Add(Me.Articuloslist)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "FRMBuscquedaArticuloCabys"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Código CABYS"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnSaldos As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RbtDescripción As RadioButton
    Friend WithEvents LblMensaje As Label
    Friend WithEvents TxtCriterio As TextBox
    Friend WithEvents Articuloslist As ListView
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents lblCodigo As Label
    Friend WithEvents RbnCodEquivalente As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents NOMBREPROD As ColumnHeader
    Friend WithEvents CheckBoxCabys As CheckBox
    Friend WithEvents TotalEncontrados As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
