<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReimpresionFactura
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReimpresionFactura))
        Me.CmbTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.LvwDocumentos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmbCaja = New System.Windows.Forms.ComboBox()
        Me.FechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.BtnEnviar = New System.Windows.Forms.Button()
        Me.TxtClienteNombre = New System.Windows.Forms.TextBox()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.FechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.CbCliente = New System.Windows.Forms.CheckBox()
        Me.CbTipo = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CbCaja = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbTipoDocumento
        '
        Me.CmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoDocumento.Enabled = False
        Me.CmbTipoDocumento.FormattingEnabled = True
        Me.CmbTipoDocumento.Location = New System.Drawing.Point(342, 13)
        Me.CmbTipoDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbTipoDocumento.Name = "CmbTipoDocumento"
        Me.CmbTipoDocumento.Size = New System.Drawing.Size(208, 24)
        Me.CmbTipoDocumento.TabIndex = 1
        '
        'LvwDocumentos
        '
        Me.LvwDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12})
        Me.LvwDocumentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwDocumentos.FullRowSelect = True
        Me.LvwDocumentos.HideSelection = False
        Me.LvwDocumentos.Location = New System.Drawing.Point(0, 119)
        Me.LvwDocumentos.Margin = New System.Windows.Forms.Padding(4)
        Me.LvwDocumentos.Name = "LvwDocumentos"
        Me.LvwDocumentos.Size = New System.Drawing.Size(1728, 746)
        Me.LvwDocumentos.TabIndex = 4
        Me.LvwDocumentos.UseCompatibleStateImageBehavior = False
        Me.LvwDocumentos.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Panel1.Controls.Add(Me.CmbTipoDocumento)
        Me.Panel1.Controls.Add(Me.CmbCaja)
        Me.Panel1.Controls.Add(Me.FechaInicial)
        Me.Panel1.Controls.Add(Me.BtnEnviar)
        Me.Panel1.Controls.Add(Me.TxtClienteNombre)
        Me.Panel1.Controls.Add(Me.BtnBuscar)
        Me.Panel1.Controls.Add(Me.TxtCliente)
        Me.Panel1.Controls.Add(Me.BtnImprimir)
        Me.Panel1.Controls.Add(Me.FechaFinal)
        Me.Panel1.Controls.Add(Me.BtnSalir)
        Me.Panel1.Controls.Add(Me.CbCliente)
        Me.Panel1.Controls.Add(Me.CbTipo)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.CbCaja)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1728, 119)
        Me.Panel1.TabIndex = 7
        '
        'CmbCaja
        '
        Me.CmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCaja.Enabled = False
        Me.CmbCaja.FormattingEnabled = True
        Me.CmbCaja.Location = New System.Drawing.Point(342, 45)
        Me.CmbCaja.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(208, 24)
        Me.CmbCaja.TabIndex = 8
        '
        'FechaInicial
        '
        Me.FechaInicial.CustomFormat = "dd/MM/yyyy"
        Me.FechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FechaInicial.Location = New System.Drawing.Point(106, 13)
        Me.FechaInicial.Margin = New System.Windows.Forms.Padding(4)
        Me.FechaInicial.Name = "FechaInicial"
        Me.FechaInicial.Size = New System.Drawing.Size(125, 22)
        Me.FechaInicial.TabIndex = 10
        '
        'BtnEnviar
        '
        Me.BtnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEnviar.BackColor = System.Drawing.Color.White
        Me.BtnEnviar.Enabled = False
        Me.BtnEnviar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F4
        Me.BtnEnviar.Location = New System.Drawing.Point(1548, 6)
        Me.BtnEnviar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnEnviar.Name = "BtnEnviar"
        Me.BtnEnviar.Size = New System.Drawing.Size(80, 86)
        Me.BtnEnviar.TabIndex = 24
        Me.BtnEnviar.Text = "Enviar"
        Me.BtnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnEnviar.UseVisualStyleBackColor = False
        '
        'TxtClienteNombre
        '
        Me.TxtClienteNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.TxtClienteNombre.Enabled = False
        Me.TxtClienteNombre.Location = New System.Drawing.Point(264, 75)
        Me.TxtClienteNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtClienteNombre.Name = "TxtClienteNombre"
        Me.TxtClienteNombre.ReadOnly = True
        Me.TxtClienteNombre.Size = New System.Drawing.Size(286, 22)
        Me.TxtClienteNombre.TabIndex = 21
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscar.BackColor = System.Drawing.Color.White
        Me.BtnBuscar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F2
        Me.BtnBuscar.Location = New System.Drawing.Point(1372, 6)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(80, 86)
        Me.BtnBuscar.TabIndex = 23
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'TxtCliente
        '
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Location = New System.Drawing.Point(106, 75)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(125, 22)
        Me.TxtCliente.TabIndex = 20
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImprimir.BackColor = System.Drawing.Color.White
        Me.BtnImprimir.Enabled = False
        Me.BtnImprimir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnImprimir.Location = New System.Drawing.Point(1460, 6)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(80, 86)
        Me.BtnImprimir.TabIndex = 6
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'FechaFinal
        '
        Me.FechaFinal.CustomFormat = "dd/MM/yyyy"
        Me.FechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FechaFinal.Location = New System.Drawing.Point(106, 45)
        Me.FechaFinal.Margin = New System.Windows.Forms.Padding(4)
        Me.FechaFinal.Name = "FechaFinal"
        Me.FechaFinal.Size = New System.Drawing.Size(125, 22)
        Me.FechaFinal.TabIndex = 11
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(1636, 6)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(80, 86)
        Me.BtnSalir.TabIndex = 5
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'CbCliente
        '
        Me.CbCliente.AutoSize = True
        Me.CbCliente.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CbCliente.Location = New System.Drawing.Point(17, 77)
        Me.CbCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.CbCliente.Name = "CbCliente"
        Me.CbCliente.Size = New System.Drawing.Size(81, 21)
        Me.CbCliente.TabIndex = 19
        Me.CbCliente.Text = "Cliente :"
        Me.CbCliente.UseVisualStyleBackColor = True
        '
        'CbTipo
        '
        Me.CbTipo.AutoSize = True
        Me.CbTipo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CbTipo.Location = New System.Drawing.Point(264, 15)
        Me.CbTipo.Margin = New System.Windows.Forms.Padding(4)
        Me.CbTipo.Name = "CbTipo"
        Me.CbTipo.Size = New System.Drawing.Size(66, 21)
        Me.CbTipo.TabIndex = 17
        Me.CbTipo.Text = "Tipo :"
        Me.CbTipo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(17, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Desde"
        '
        'CbCaja
        '
        Me.CbCaja.AutoSize = True
        Me.CbCaja.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CbCaja.Location = New System.Drawing.Point(264, 47)
        Me.CbCaja.Margin = New System.Windows.Forms.Padding(4)
        Me.CbCaja.Name = "CbCaja"
        Me.CbCaja.Size = New System.Drawing.Size(66, 21)
        Me.CbCaja.TabIndex = 18
        Me.CbCaja.Text = "Caja :"
        Me.CbCaja.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(17, 50)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Hasta"
        '
        'FrmReimpresionFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(1728, 865)
        Me.Controls.Add(Me.LvwDocumentos)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReimpresionFactura"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmbTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LvwDocumentos As System.Windows.Forms.ListView
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbCaja As ComboBox
    Friend WithEvents FechaInicial As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents FechaFinal As DateTimePicker
    Friend WithEvents TxtClienteNombre As TextBox
    Friend WithEvents TxtCliente As TextBox
    Friend WithEvents CbCliente As CheckBox
    Friend WithEvents CbCaja As CheckBox
    Friend WithEvents CbTipo As CheckBox
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents BtnEnviar As Button
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
End Class
