<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCxCAnulaPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCxCAnulaPago))
        Me.GroupOpciones = New System.Windows.Forms.GroupBox()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.BtnAnulaPago = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.LvwMovimientos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RdbCliente = New System.Windows.Forms.RadioButton()
        Me.RdbFecha = New System.Windows.Forms.RadioButton()
        Me.PnlCliente = New System.Windows.Forms.Panel()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PnlFechas = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupOpciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnlCliente.SuspendLayout()
        Me.PnlFechas.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupOpciones
        '
        Me.GroupOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.GroupOpciones.Controls.Add(Me.BtnLimpiar)
        Me.GroupOpciones.Controls.Add(Me.BtnRefrescar)
        Me.GroupOpciones.Controls.Add(Me.BtnAnulaPago)
        Me.GroupOpciones.Controls.Add(Me.BtnSalir)
        Me.GroupOpciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupOpciones.Location = New System.Drawing.Point(0, 0)
        Me.GroupOpciones.Name = "GroupOpciones"
        Me.GroupOpciones.Size = New System.Drawing.Size(83, 555)
        Me.GroupOpciones.TabIndex = 9
        Me.GroupOpciones.TabStop = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.BackColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F12
        Me.BtnLimpiar.Location = New System.Drawing.Point(11, 173)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(63, 71)
        Me.BtnLimpiar.TabIndex = 8
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnLimpiar.UseVisualStyleBackColor = False
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.BackColor = System.Drawing.Color.White
        Me.BtnRefrescar.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F3
        Me.BtnRefrescar.Location = New System.Drawing.Point(11, 19)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(63, 71)
        Me.BtnRefrescar.TabIndex = 6
        Me.BtnRefrescar.Text = "Buscar"
        Me.BtnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRefrescar.UseVisualStyleBackColor = False
        '
        'BtnAnulaPago
        '
        Me.BtnAnulaPago.BackColor = System.Drawing.Color.White
        Me.BtnAnulaPago.Image = Global.PuntoVenta.My.Resources.Resources.Blue_F4
        Me.BtnAnulaPago.Location = New System.Drawing.Point(11, 96)
        Me.BtnAnulaPago.Name = "BtnAnulaPago"
        Me.BtnAnulaPago.Size = New System.Drawing.Size(63, 71)
        Me.BtnAnulaPago.TabIndex = 5
        Me.BtnAnulaPago.Text = "Anular"
        Me.BtnAnulaPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAnulaPago.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.PuntoVenta.My.Resources.Resources.Blue_Esc
        Me.BtnSalir.Location = New System.Drawing.Point(11, 250)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(63, 71)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'LvwMovimientos
        '
        Me.LvwMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LvwMovimientos.Dock = System.Windows.Forms.DockStyle.Top
        Me.LvwMovimientos.FullRowSelect = True
        Me.LvwMovimientos.Location = New System.Drawing.Point(83, 99)
        Me.LvwMovimientos.MultiSelect = False
        Me.LvwMovimientos.Name = "LvwMovimientos"
        Me.LvwMovimientos.Size = New System.Drawing.Size(883, 456)
        Me.LvwMovimientos.TabIndex = 12
        Me.LvwMovimientos.UseCompatibleStateImageBehavior = False
        Me.LvwMovimientos.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RdbCliente)
        Me.Panel1.Controls.Add(Me.RdbFecha)
        Me.Panel1.Controls.Add(Me.PnlCliente)
        Me.Panel1.Controls.Add(Me.PnlFechas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(83, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(883, 99)
        Me.Panel1.TabIndex = 14
        '
        'RdbCliente
        '
        Me.RdbCliente.AutoSize = True
        Me.RdbCliente.Location = New System.Drawing.Point(407, 22)
        Me.RdbCliente.Name = "RdbCliente"
        Me.RdbCliente.Size = New System.Drawing.Size(57, 17)
        Me.RdbCliente.TabIndex = 64
        Me.RdbCliente.TabStop = True
        Me.RdbCliente.Text = "Cliente"
        Me.RdbCliente.UseVisualStyleBackColor = True
        '
        'RdbFecha
        '
        Me.RdbFecha.AutoSize = True
        Me.RdbFecha.Location = New System.Drawing.Point(17, 19)
        Me.RdbFecha.Name = "RdbFecha"
        Me.RdbFecha.Size = New System.Drawing.Size(55, 17)
        Me.RdbFecha.TabIndex = 63
        Me.RdbFecha.TabStop = True
        Me.RdbFecha.Text = "Fecha"
        Me.RdbFecha.UseVisualStyleBackColor = True
        '
        'PnlCliente
        '
        Me.PnlCliente.Controls.Add(Me.TxtNombre)
        Me.PnlCliente.Controls.Add(Me.TxtCodigo)
        Me.PnlCliente.Controls.Add(Me.Label2)
        Me.PnlCliente.Enabled = False
        Me.PnlCliente.Location = New System.Drawing.Point(407, 45)
        Me.PnlCliente.Name = "PnlCliente"
        Me.PnlCliente.Size = New System.Drawing.Size(457, 27)
        Me.PnlCliente.TabIndex = 62
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.White
        Me.TxtNombre.Location = New System.Drawing.Point(154, 3)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(296, 20)
        Me.TxtNombre.TabIndex = 58
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.Color.White
        Me.TxtCodigo.Location = New System.Drawing.Point(48, 3)
        Me.TxtCodigo.MaxLength = 6
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.TxtCodigo.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Cliente"
        '
        'PnlFechas
        '
        Me.PnlFechas.Controls.Add(Me.Label4)
        Me.PnlFechas.Controls.Add(Me.DtpHasta)
        Me.PnlFechas.Controls.Add(Me.Label3)
        Me.PnlFechas.Controls.Add(Me.DtpDesde)
        Me.PnlFechas.Enabled = False
        Me.PnlFechas.Location = New System.Drawing.Point(17, 42)
        Me.PnlFechas.Name = "PnlFechas"
        Me.PnlFechas.Size = New System.Drawing.Size(309, 30)
        Me.PnlFechas.TabIndex = 61
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(166, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Hasta"
        '
        'DtpHasta
        '
        Me.DtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHasta.Location = New System.Drawing.Point(207, 3)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(95, 20)
        Me.DtpHasta.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Desde"
        '
        'DtpDesde
        '
        Me.DtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDesde.Location = New System.Drawing.Point(47, 3)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(95, 20)
        Me.DtpDesde.TabIndex = 61
        '
        'FrmCxCAnulaPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(966, 555)
        Me.Controls.Add(Me.LvwMovimientos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupOpciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCxCAnulaPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anula Pago CxC "
        Me.GroupOpciones.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PnlCliente.ResumeLayout(False)
        Me.PnlCliente.PerformLayout()
        Me.PnlFechas.ResumeLayout(False)
        Me.PnlFechas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupOpciones As GroupBox
    Friend WithEvents BtnLimpiar As Button
    Friend WithEvents BtnRefrescar As Button
    Friend WithEvents BtnAnulaPago As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents LvwMovimientos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PnlCliente As Panel
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents TxtCodigo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PnlFechas As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents DtpHasta As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents DtpDesde As DateTimePicker
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents RdbCliente As RadioButton
    Friend WithEvents RdbFecha As RadioButton
    Friend WithEvents ColumnHeader9 As ColumnHeader
End Class
