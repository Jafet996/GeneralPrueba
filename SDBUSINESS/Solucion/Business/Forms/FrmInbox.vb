Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports EAGetMail


Public Class FrmInbox
    Dim CancelarCarga = False


    Public Property StrXml As String


    Private Enum ColumnasEmails
        Email = 0
        Asunto = 1
        Contenido = 2
        Fecha = 3
    End Enum

    Private Enum ColumnasAdjuntos
        Archivo = 0
        Extension = 1
    End Enum

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
    Private Sub ConfiguraDetalle()
        Try

            With LvwEmail
                .Columns(ColumnasEmails.Email).Text = "De"
                .Columns(ColumnasEmails.Email).Width = 200
                .Columns(ColumnasEmails.Email).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasEmails.Asunto).Text = "Asunto"
                .Columns(ColumnasEmails.Asunto).Width = 300
                .Columns(ColumnasEmails.Asunto).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasEmails.Contenido).Text = "Contenido"
                .Columns(ColumnasEmails.Contenido).Width = 0
                .Columns(ColumnasEmails.Contenido).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasEmails.Fecha).Text = "Fecha"
                .Columns(ColumnasEmails.Fecha).Width = 110
                .Columns(ColumnasEmails.Fecha).TextAlign = HorizontalAlignment.Left
            End With

            With LvwAttachements
                .Columns(ColumnasAdjuntos.Archivo).Text = "Archivos Adjuntos"
                .Columns(ColumnasAdjuntos.Archivo).Width = PnlAttachments.Width - 20
                .Columns(ColumnasAdjuntos.Archivo).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasAdjuntos.Extension).Text = "Extension"
                .Columns(ColumnasAdjuntos.Extension).Width = 0
                .Columns(ColumnasAdjuntos.Extension).TextAlign = HorizontalAlignment.Center
            End With


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmInbox_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            Me.Width = Screen.PrimaryScreen.WorkingArea.Size.Width
            Me.Height = Screen.PrimaryScreen.WorkingArea.Size.Height - 50
            Me.CenterToScreen()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombos()
        Dim RecepcionFacturaEmail As New TRecepcionFacturaEmail(EmpresaInfo.Emp_Id)
        Try

            CmbMensajes.SelectedIndex = 1

            VerificaMensaje(RecepcionFacturaEmail.LoadComboBox(CmbEmail))


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            RecepcionFacturaEmail = Nothing
        End Try
    End Sub

    Public Sub Execute()
        Try

            CargaCombos()

            DtpDesde.Value = DateValue(EmpresaInfo.Getdate())
            DtpHasta.Value = DtpDesde.Value

            LblStatus.Text = String.Empty
            PnlHeader.Visible = False
            PnlContent.Visible = False
            PnlAttachments.Visible = False
            StrXml = String.Empty

            ConfiguraDetalle()

            CargaLista(String.Empty, DtpHasta.Value, DtpHasta.Value)

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        Dim oServer As MailServer = Nothing
        Dim oClient As MailClient = Nothing
        Dim infos() As MailInfo
        Dim count As Integer
        Dim RecepcionFacturaEmail As New TRecepcionFacturaEmail(EmpresaInfo.Emp_Id)
        Try


            If CmbEmail.SelectedValue Is Nothing OrElse CmbEmail.SelectedIndex < 0 Then
                VerificaMensaje("Debe de seleccionar una cuenta de correo")
            End If

            RecepcionFacturaEmail.Email_Id = CmbEmail.SelectedValue
            VerificaMensaje(RecepcionFacturaEmail.ListKey)
            If RecepcionFacturaEmail.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron las credenciales para la cuenta de correo")
            End If

            LvwEmail.Items.Clear()
            Emails.Clear()
            PnlHeader.Visible = False
            PnlContent.Visible = False
            PnlAttachments.Visible = False
            LblFecha.Text = String.Empty
            LblDe.Text = String.Empty
            LblPara.Text = String.Empty
            LblAsunto.Text = String.Empty
            LvwAttachements.Items.Clear()



            'Busca Email para procesar ----------------------------------------------------------
            oServer = New MailServer(RecepcionFacturaEmail.Server, RecepcionFacturaEmail.Email, UnLockPassword(RecepcionFacturaEmail.Password), RecepcionFacturaEmail.SSL, RecepcionFacturaEmail.ServerAuthType, RecepcionFacturaEmail.ServerProtocol)
            oServer.Port = RecepcionFacturaEmail.Port



            oClient = New MailClient("EG-C1508812802-00261-1832UBD96D31CBE3-BFBEFB45ABVFF297")


            LblStatus.Text = "Connecting ..." : LblStatus.Refresh() : Application.DoEvents()

            oClient.Connect(oServer)

            oClient.GetMailInfosParam.Reset()

            If CmbMensajes.SelectedIndex = 0 Then
                oClient.GetMailInfosParam.GetMailInfosOptions = GetMailInfosOptionType.NewOnly
            Else
                oClient.GetMailInfosParam.GetMailInfosOptions = GetMailInfosOptionType.OrderByDateTime
                'oClient.GetMailInfosParam.GetMailInfosOptions = GetMailInfosOptionType.All
            End If


            infos = oClient.GetMailInfos()

            LblStatus.Text = String.Format("Total {0} email(s)", infos.Length) : LblStatus.Refresh() : Application.DoEvents()

            count = infos.Length

            Threading.Thread.Sleep(500)

            BtnCancelarCarga.Visible = True : BtnCancelarCarga.Refresh() : Application.DoEvents()
            CancelarCarga = False

            For i As Integer = count - 1 To 0 Step -1

                LblStatus.Text = String.Format("Cargando {0} de {1}", Emails.Count, infos.Length) : LblStatus.Refresh() : Application.DoEvents()

                If CancelarCarga OrElse Not BtnCancelarCarga.Visible Then
                    Exit For
                End If

                Emails.Add(oClient.GetMail(infos(i)))
            Next

            CargaLista(String.Empty, #01/01/1900#, #01/01/3000#)

            LblStatus.Text = String.Empty

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            oServer = Nothing
            oClient = Nothing
            infos = Nothing
            RecepcionFacturaEmail = Nothing
            BtnCancelarCarga.Visible = False
            LblStatus.Text = String.Empty
            CancelarCarga = False
        End Try
    End Sub

    Private Sub CargaLista(pCriterio As String, pfechaIni As Date, pFechaFin As Date)
        Dim Items(3) As String
        Dim Item As ListViewItem = Nothing
        Dim Agregar As Boolean = False
        Try

            LvwEmail.Items.Clear()
            LvwEmail.Refresh()

            For Each msg As Mail In Emails
                Agregar = False
                'If ChkFechas.Checked Then
                '    Agregar = False
                '    If DtpDesde.Value >= msg.SentDate AndAlso msg.SentDate <= DateAdd(DateInterval.Day, 1, DtpHasta.Value) Then
                '        Agregar = True
                '    End If
                'End If


                If pCriterio = String.Empty AndAlso Not ChkFechas.Checked Then
                    Agregar = True
                Else
                    If pCriterio <> String.Empty Then
                        If (msg.TextBody.IndexOf(pCriterio) > 0 OrElse
                       msg.From.Address.IndexOf(pCriterio) > 0 OrElse
                       msg.From.Name.IndexOf(pCriterio) > 0 OrElse
                       msg.Subject.IndexOf(pCriterio) > 0) AndAlso
                       (Not ChkFechas.Checked OrElse (ChkFechas.Checked AndAlso DtpDesde.Value <= msg.SentDate AndAlso msg.SentDate < DateAdd(DateInterval.Day, 1, DtpHasta.Value))) Then
                            Agregar = True
                        End If
                    Else
                        If Not ChkFechas.Checked OrElse (ChkFechas.Checked AndAlso DtpDesde.Value <= msg.SentDate AndAlso msg.SentDate < DateAdd(DateInterval.Day, 1, DtpHasta.Value)) Then
                            Agregar = True
                        End If
                    End If
                End If


                If Agregar Then
                    Items(ColumnasEmails.Email) = IIf(msg.From.Name.Trim = String.Empty, msg.From.Address, msg.From.Name)
                    Items(ColumnasEmails.Asunto) = msg.Subject
                    Items(ColumnasEmails.Contenido) = msg.TextBody
                    Items(ColumnasEmails.Fecha) = msg.SentDate.ToString("dd/MM/yyyy HH:mm")

                    Item = New ListViewItem(Items)
                    Item.Tag = msg

                    LvwEmail.Items.Add(Item)
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Item = Nothing
        End Try
    End Sub


    Private Sub LvwEmail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvwEmail.SelectedIndexChanged
        Dim Item As ListViewItem = Nothing
        Dim msg As Mail = Nothing
        Dim Extension As String = String.Empty
        Dim Items(1) As String
        Try

            PnlHeader.Visible = False
            PnlContent.Visible = False
            PnlAttachments.Visible = False
            LblFecha.Text = String.Empty
            LblDe.Text = String.Empty
            LblPara.Text = String.Empty
            LblAsunto.Text = String.Empty
            LvwAttachements.Items.Clear()


            If LvwEmail.SelectedItems Is Nothing OrElse LvwEmail.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            Item = LvwEmail.SelectedItems(0)


            msg = DirectCast(Item.Tag, Mail)

            PnlHeader.Visible = True

            LblFecha.Text = msg.SentDate.ToString("dd/MM/yyyy HH:mm")
            LblDe.Text = msg.From.Name & "(" & msg.From.Address & ")"

            For Each add As MailAddress In msg.To
                LblPara.Text = LblPara.Text & IIf(LblPara.Text <> String.Empty, ";", String.Empty) & add.Address.Trim
            Next

            LblAsunto.Text = msg.Subject

            PnlContent.Visible = True
            TxtContent.Text = msg.TextBody


            If msg.Attachments.Count > 0 Then
                PnlAttachments.Visible = True

                For Each Adjunto As Attachment In msg.Attachments
                    Extension = Path.GetExtension(Adjunto.Name).ToLower

                    Items(ColumnasAdjuntos.Archivo) = Adjunto.Name
                    Items(ColumnasAdjuntos.Extension) = Extension

                    Item = New ListViewItem(Items)
                    Item.Tag = Adjunto.Content
                    Item.ImageIndex = IIf(Extension = ".xml", 0, 1)

                    LvwAttachements.Items.Add(Item)
                Next
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Item = Nothing
            msg = Nothing
        End Try
    End Sub

    Private Sub LvwAttachements_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvwAttachements.SelectedIndexChanged

    End Sub

    Private Sub LvwAttachements_DoubleClick(sender As Object, e As EventArgs) Handles LvwAttachements.DoubleClick
        Dim Item As ListViewItem = Nothing
        Dim StrXmlLocal As String = String.Empty
        Dim Arreglo() As Byte
        Try

            If LvwAttachements.SelectedItems Is Nothing OrElse LvwAttachements.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un archivo")
            End If

            Item = LvwAttachements.SelectedItems(0)

            If Item.SubItems(ColumnasAdjuntos.Extension).Text <> ".xml" Then
                VerificaMensaje("El archivo seleccionado no es válido")
            End If


            Arreglo = DirectCast(Item.Tag, Byte())

            StrXml = Encoding.UTF8.GetString(Arreglo)

            If StrXml.IndexOf(coFEMensajeHacienda) >= 0 Then
                VerificaMensaje("El tipo de documento seleccionado corresponde a un Acuse de Recibido, imposible cargar")
            End If

            If StrXml.IndexOf(coFEFacturaElectronica) < 0 AndAlso StrXml.IndexOf(coFETiqueteElectronico) < 0 Then
                VerificaMensaje("El tipo de documento no es válido, únicamente se permite cargar Facturas o Tiquetes Electrónicos")
            End If

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnCancelarCarga_Click(sender As Object, e As EventArgs) Handles BtnCancelarCarga.Click
        CancelarCarga = True
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As Object, e As EventArgs) Handles TxtCriterio.TextChanged
        CargaLista(TxtCriterio.Text.Trim, DateValue(DtpDesde.Value), DateValue(DtpHasta.Value))
    End Sub

    Private Sub DtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles DtpDesde.ValueChanged
        If ChkFechas.Checked Then
            CargaLista(TxtCriterio.Text.Trim, DateValue(DtpDesde.Value), DateValue(DtpHasta.Value))
        End If
    End Sub

    Private Sub DtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles DtpHasta.ValueChanged
        If ChkFechas.Checked Then
            CargaLista(TxtCriterio.Text.Trim, DateValue(DtpDesde.Value), DateValue(DtpHasta.Value))
        End If
    End Sub

    Private Sub ChkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFechas.CheckedChanged
        CargaLista(TxtCriterio.Text.Trim, DateValue(DtpDesde.Value), DateValue(DtpHasta.Value))
    End Sub
End Class