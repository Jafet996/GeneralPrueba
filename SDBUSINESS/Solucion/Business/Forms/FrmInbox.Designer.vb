<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInbox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInbox))
        Me.PnlMenu = New System.Windows.Forms.Panel()
        Me.ChkFechas = New System.Windows.Forms.CheckBox()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.TxtCriterio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnCancelarCarga = New System.Windows.Forms.Button()
        Me.CmbMensajes = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.BtnRefrescar = New System.Windows.Forms.Button()
        Me.CmbEmail = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.PnlEmails = New System.Windows.Forms.Panel()
        Me.LvwEmail = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PnlDetail = New System.Windows.Forms.Panel()
        Me.PnlContent = New System.Windows.Forms.Panel()
        Me.TxtContent = New System.Windows.Forms.TextBox()
        Me.PnlAttachments = New System.Windows.Forms.Panel()
        Me.LvwAttachements = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImgLstAttachment = New System.Windows.Forms.ImageList(Me.components)
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.LblAsunto = New System.Windows.Forms.Label()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.LblPara = New System.Windows.Forms.Label()
        Me.LblDe = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PnlMenu.SuspendLayout()
        Me.PnlEmails.SuspendLayout()
        Me.PnlDetail.SuspendLayout()
        Me.PnlContent.SuspendLayout()
        Me.PnlAttachments.SuspendLayout()
        Me.PnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlMenu
        '
        Me.PnlMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PnlMenu.Controls.Add(Me.ChkFechas)
        Me.PnlMenu.Controls.Add(Me.DtpHasta)
        Me.PnlMenu.Controls.Add(Me.Label6)
        Me.PnlMenu.Controls.Add(Me.DtpDesde)
        Me.PnlMenu.Controls.Add(Me.TxtCriterio)
        Me.PnlMenu.Controls.Add(Me.Label5)
        Me.PnlMenu.Controls.Add(Me.BtnCancelarCarga)
        Me.PnlMenu.Controls.Add(Me.CmbMensajes)
        Me.PnlMenu.Controls.Add(Me.Label4)
        Me.PnlMenu.Controls.Add(Me.LblStatus)
        Me.PnlMenu.Controls.Add(Me.BtnRefrescar)
        Me.PnlMenu.Controls.Add(Me.CmbEmail)
        Me.PnlMenu.Controls.Add(Me.Label1)
        Me.PnlMenu.Controls.Add(Me.BtnSalir)
        Me.PnlMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.PnlMenu.Name = "PnlMenu"
        Me.PnlMenu.Size = New System.Drawing.Size(1525, 99)
        Me.PnlMenu.TabIndex = 0
        '
        'ChkFechas
        '
        Me.ChkFechas.AutoSize = True
        Me.ChkFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFechas.ForeColor = System.Drawing.Color.White
        Me.ChkFechas.Location = New System.Drawing.Point(248, 15)
        Me.ChkFechas.Name = "ChkFechas"
        Me.ChkFechas.Size = New System.Drawing.Size(91, 29)
        Me.ChkFechas.TabIndex = 14
        Me.ChkFechas.Text = "Desde"
        Me.ChkFechas.UseVisualStyleBackColor = True
        '
        'DtpHasta
        '
        Me.DtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.DtpHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHasta.Location = New System.Drawing.Point(602, 14)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(146, 30)
        Me.DtpHasta.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(519, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 25)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Hasta"
        '
        'DtpDesde
        '
        Me.DtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.DtpDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDesde.Location = New System.Drawing.Point(353, 14)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(146, 30)
        Me.DtpDesde.TabIndex = 11
        '
        'TxtCriterio
        '
        Me.TxtCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCriterio.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtCriterio.Location = New System.Drawing.Point(353, 54)
        Me.TxtCriterio.Name = "TxtCriterio"
        Me.TxtCriterio.Size = New System.Drawing.Size(395, 30)
        Me.TxtCriterio.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(243, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 25)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Buscar"
        '
        'BtnCancelarCarga
        '
        Me.BtnCancelarCarga.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnCancelarCarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelarCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarCarga.ForeColor = System.Drawing.Color.White
        Me.BtnCancelarCarga.Location = New System.Drawing.Point(767, 12)
        Me.BtnCancelarCarga.Name = "BtnCancelarCarga"
        Me.BtnCancelarCarga.Size = New System.Drawing.Size(100, 73)
        Me.BtnCancelarCarga.TabIndex = 8
        Me.BtnCancelarCarga.Text = "Cancelar"
        Me.BtnCancelarCarga.UseVisualStyleBackColor = False
        Me.BtnCancelarCarga.Visible = False
        '
        'CmbMensajes
        '
        Me.CmbMensajes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbMensajes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMensajes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMensajes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMensajes.FormattingEnabled = True
        Me.CmbMensajes.Items.AddRange(New Object() {"NUEVOS", "TODOS"})
        Me.CmbMensajes.Location = New System.Drawing.Point(1220, 56)
        Me.CmbMensajes.Name = "CmbMensajes"
        Me.CmbMensajes.Size = New System.Drawing.Size(293, 28)
        Me.CmbMensajes.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1108, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Mensajes"
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.ForeColor = System.Drawing.Color.White
        Me.LblStatus.Location = New System.Drawing.Point(873, 36)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(30, 25)
        Me.LblStatus.TabIndex = 5
        Me.LblStatus.Text = "..."
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefrescar.ForeColor = System.Drawing.Color.White
        Me.BtnRefrescar.Location = New System.Drawing.Point(12, 12)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(100, 73)
        Me.BtnRefrescar.TabIndex = 4
        Me.BtnRefrescar.Text = "Refrescar"
        Me.BtnRefrescar.UseVisualStyleBackColor = True
        '
        'CmbEmail
        '
        Me.CmbEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbEmail.FormattingEnabled = True
        Me.CmbEmail.Location = New System.Drawing.Point(1220, 22)
        Me.CmbEmail.Name = "CmbEmail"
        Me.CmbEmail.Size = New System.Drawing.Size(293, 28)
        Me.CmbEmail.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1108, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Correo"
        '
        'BtnSalir
        '
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Location = New System.Drawing.Point(118, 12)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(100, 73)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'PnlEmails
        '
        Me.PnlEmails.Controls.Add(Me.LvwEmail)
        Me.PnlEmails.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlEmails.Location = New System.Drawing.Point(0, 99)
        Me.PnlEmails.Name = "PnlEmails"
        Me.PnlEmails.Size = New System.Drawing.Size(951, 834)
        Me.PnlEmails.TabIndex = 1
        '
        'LvwEmail
        '
        Me.LvwEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LvwEmail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6})
        Me.LvwEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwEmail.ForeColor = System.Drawing.Color.DarkBlue
        Me.LvwEmail.FullRowSelect = True
        Me.LvwEmail.HideSelection = False
        Me.LvwEmail.Location = New System.Drawing.Point(0, 0)
        Me.LvwEmail.Name = "LvwEmail"
        Me.LvwEmail.Size = New System.Drawing.Size(951, 834)
        Me.LvwEmail.TabIndex = 0
        Me.LvwEmail.UseCompatibleStateImageBehavior = False
        Me.LvwEmail.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = ""
        '
        'PnlDetail
        '
        Me.PnlDetail.Controls.Add(Me.PnlContent)
        Me.PnlDetail.Controls.Add(Me.PnlAttachments)
        Me.PnlDetail.Controls.Add(Me.PnlHeader)
        Me.PnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDetail.Location = New System.Drawing.Point(951, 99)
        Me.PnlDetail.Name = "PnlDetail"
        Me.PnlDetail.Size = New System.Drawing.Size(574, 834)
        Me.PnlDetail.TabIndex = 2
        '
        'PnlContent
        '
        Me.PnlContent.Controls.Add(Me.TxtContent)
        Me.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlContent.Location = New System.Drawing.Point(0, 153)
        Me.PnlContent.Name = "PnlContent"
        Me.PnlContent.Size = New System.Drawing.Size(574, 532)
        Me.PnlContent.TabIndex = 2
        '
        'TxtContent
        '
        Me.TxtContent.BackColor = System.Drawing.Color.White
        Me.TxtContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtContent.Location = New System.Drawing.Point(0, 0)
        Me.TxtContent.Multiline = True
        Me.TxtContent.Name = "TxtContent"
        Me.TxtContent.ReadOnly = True
        Me.TxtContent.Size = New System.Drawing.Size(574, 532)
        Me.TxtContent.TabIndex = 0
        '
        'PnlAttachments
        '
        Me.PnlAttachments.Controls.Add(Me.LvwAttachements)
        Me.PnlAttachments.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlAttachments.Location = New System.Drawing.Point(0, 685)
        Me.PnlAttachments.Name = "PnlAttachments"
        Me.PnlAttachments.Size = New System.Drawing.Size(574, 149)
        Me.PnlAttachments.TabIndex = 1
        '
        'LvwAttachements
        '
        Me.LvwAttachements.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5})
        Me.LvwAttachements.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvwAttachements.HideSelection = False
        Me.LvwAttachements.Location = New System.Drawing.Point(0, 0)
        Me.LvwAttachements.Name = "LvwAttachements"
        Me.LvwAttachements.Size = New System.Drawing.Size(574, 149)
        Me.LvwAttachements.SmallImageList = Me.ImgLstAttachment
        Me.LvwAttachements.TabIndex = 0
        Me.LvwAttachements.UseCompatibleStateImageBehavior = False
        Me.LvwAttachements.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Archivos Adjuntos"
        '
        'ImgLstAttachment
        '
        Me.ImgLstAttachment.ImageStream = CType(resources.GetObject("ImgLstAttachment.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLstAttachment.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLstAttachment.Images.SetKeyName(0, "iconfinder_ic_attach_file_48px_352032.ico")
        Me.ImgLstAttachment.Images.SetKeyName(1, "delete.ico")
        '
        'PnlHeader
        '
        Me.PnlHeader.Controls.Add(Me.LblAsunto)
        Me.PnlHeader.Controls.Add(Me.LblFecha)
        Me.PnlHeader.Controls.Add(Me.LblPara)
        Me.PnlHeader.Controls.Add(Me.LblDe)
        Me.PnlHeader.Controls.Add(Me.Label3)
        Me.PnlHeader.Controls.Add(Me.Label2)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(574, 153)
        Me.PnlHeader.TabIndex = 0
        '
        'LblAsunto
        '
        Me.LblAsunto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblAsunto.Location = New System.Drawing.Point(22, 102)
        Me.LblAsunto.Name = "LblAsunto"
        Me.LblAsunto.Size = New System.Drawing.Size(528, 36)
        Me.LblAsunto.TabIndex = 5
        Me.LblAsunto.Text = "Asunto"
        '
        'LblFecha
        '
        Me.LblFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.Location = New System.Drawing.Point(141, 18)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(409, 17)
        Me.LblFecha.TabIndex = 4
        Me.LblFecha.Text = "01/01/1900"
        Me.LblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblPara
        '
        Me.LblPara.Location = New System.Drawing.Point(63, 75)
        Me.LblPara.Name = "LblPara"
        Me.LblPara.Size = New System.Drawing.Size(501, 17)
        Me.LblPara.TabIndex = 3
        Me.LblPara.Text = "Para"
        '
        'LblDe
        '
        Me.LblDe.Location = New System.Drawing.Point(64, 47)
        Me.LblDe.Name = "LblDe"
        Me.LblDe.Size = New System.Drawing.Size(501, 17)
        Me.LblDe.TabIndex = 2
        Me.LblDe.Text = "De"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Para"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "De"
        '
        'FrmInbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1525, 933)
        Me.Controls.Add(Me.PnlDetail)
        Me.Controls.Add(Me.PnlEmails)
        Me.Controls.Add(Me.PnlMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInbox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buzón de Correo Electrónico"
        Me.PnlMenu.ResumeLayout(False)
        Me.PnlMenu.PerformLayout()
        Me.PnlEmails.ResumeLayout(False)
        Me.PnlDetail.ResumeLayout(False)
        Me.PnlContent.ResumeLayout(False)
        Me.PnlContent.PerformLayout()
        Me.PnlAttachments.ResumeLayout(False)
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnlMenu As Windows.Forms.Panel
    Friend WithEvents BtnSalir As Windows.Forms.Button
    Friend WithEvents CmbEmail As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents PnlEmails As Windows.Forms.Panel
    Friend WithEvents LvwEmail As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents PnlDetail As Windows.Forms.Panel
    Friend WithEvents BtnRefrescar As Windows.Forms.Button
    Friend WithEvents LblStatus As Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As Windows.Forms.ColumnHeader
    Friend WithEvents PnlHeader As Windows.Forms.Panel
    Friend WithEvents PnlContent As Windows.Forms.Panel
    Friend WithEvents PnlAttachments As Windows.Forms.Panel
    Friend WithEvents TxtContent As Windows.Forms.TextBox
    Friend WithEvents LblAsunto As Windows.Forms.Label
    Friend WithEvents LblFecha As Windows.Forms.Label
    Friend WithEvents LblPara As Windows.Forms.Label
    Friend WithEvents LblDe As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents LvwAttachements As Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As Windows.Forms.ColumnHeader
    Friend WithEvents ImgLstAttachment As Windows.Forms.ImageList
    Friend WithEvents CmbMensajes As Windows.Forms.ComboBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents BtnCancelarCarga As Windows.Forms.Button
    Friend WithEvents ColumnHeader6 As Windows.Forms.ColumnHeader
    Friend WithEvents ChkFechas As Windows.Forms.CheckBox
    Friend WithEvents DtpHasta As Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents DtpDesde As Windows.Forms.DateTimePicker
    Friend WithEvents TxtCriterio As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
