Imports System.IO
Imports Business
Imports System.Xml


Public Class FrmEnvioPricesmart
    Public Sub Execute()
        Try

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmEnvioPricesmart_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub EnviarAcuse()
        Dim ws As New WsPricesmart.wsRecepcion
        Dim respuesta As String = ""
        Dim errorRespuesta As Boolean = False
        Dim mensajeRespuesta As String = ""
        Dim claveFiscalDocumentoRecibido = ""
        Dim xmlContenido As String = ""
        Dim cTipoIdReceptor As String = "02"
        Dim cIdReceptor As String = "3101231707"
        Dim cConsecutivoFiscal As String = ""
        Dim cClaveFiscal As String = ""

        Try
            Dim documento As XDocument = XDocument.Load(TxtAcuse.Text)

            xmlContenido = documento.Document.ToString()

            ws.RecibirAcuseEmisor("pricesmart", "pricesmart", xmlContenido, respuesta, errorRespuesta, mensajeRespuesta, cConsecutivoFiscal, cClaveFiscal, cTipoIdReceptor, cIdReceptor)
            If errorRespuesta Then
                VerificaMensaje(mensajeRespuesta)
            Else
                If mensajeRespuesta.Equals("") Then
                    Mensaje("Documento Recibido Exitosamente")
                Else
                    Mensaje(mensajeRespuesta)
                End If
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtAcuse.Text = ""
            ws = Nothing
        End Try
    End Sub

    Private Sub Aceptar()
        Dim ws As New WsPricesmart.wsRecepcion
        Dim respuesta As String = ""
        Dim errorRespuesta As Boolean = False
        Dim mensajeRespuesta As String = ""
        Dim claveFiscalDocumentoRecibido = ""
        Dim xmlContenido As String = ""


        Try
            Dim documento As XDocument = XDocument.Load(TxtRuta.Text)

            xmlContenido = documento.Document.ToString()

            FormatearXml(xmlContenido)

            ws.ValidarDocumentoElectronico("pricesmart", "pricesmart", xmlContenido, respuesta, errorRespuesta, mensajeRespuesta, claveFiscalDocumentoRecibido, "02", "3101231707", 0)
            If errorRespuesta Then
                VerificaMensaje(mensajeRespuesta)
            Else
                If mensajeRespuesta.Equals("") Then
                    Mensaje("Este documento ya fue recibido anteriormente")
                Else
                    Mensaje(mensajeRespuesta)
                End If
                TxtRuta.Clear()
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ws = Nothing
        End Try
    End Sub

    Private Sub FormatearXml(ByRef xml As String)
        Try

            xml = Replace(xml, "xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""", "")
            xml = Replace(xml, "<FacturaElectronica xmlns=""https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/facturaElectronica"">", "<FacturaElectronica xmlns=""https:  //tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/facturaElectronica"" xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/facturaElectronica https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/facturaElectronica.xsd"">")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If Not File.Exists(TxtRuta.Text) And Not File.Exists(TxtAcuse.Text) Then
                VerificaMensaje("El archivo seleccionado no existe")
            End If


            If Not String.Equals(Path.GetExtension(TxtRuta.Text), ".xml", StringComparison.OrdinalIgnoreCase) Then
                VerificaMensaje("El tipo de archivo seleccionado no es permitido, debe de seleccionar un archivo XML")
            End If

            If Not String.Equals(Path.GetExtension(TxtAcuse.Text), ".xml", StringComparison.OrdinalIgnoreCase) Then
                VerificaMensaje("El tipo de archivo seleccionado no es permitido, debe de seleccionar un archivo XML")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            If ConfirmaAccion("Desea enviar el documento?") Then
                If ValidaTodo() Then
                    Aceptar()
                    EnviarAcuse()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnRuta_Click(sender As Object, e As EventArgs) Handles BtnRuta.Click
        Dim OFD As New OpenFileDialog()
        Try

            TxtRuta.Text = ""

            OFD.Filter = "XML Files (*.xml)|*.xml"
            OFD.FilterIndex = 0
            OFD.DefaultExt = "xml"

            If OFD.ShowDialog() = DialogResult.OK Then
                If Not String.Equals(Path.GetExtension(OFD.FileName), ".xml", StringComparison.OrdinalIgnoreCase) Then
                    VerificaMensaje("El tipo de archivo seleccionado no es permitido, debe de seleccionar un archivo XML")
                Else
                    TxtRuta.Text = OFD.FileName
                    If Not TxtAcuse.Text.Equals("") And Not TxtRuta.Text.Equals("") Then
                        BtnAceptar.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            OFD = Nothing
        End Try
    End Sub

    Private Sub TxtRuta_TextChanged(sender As Object, e As EventArgs) Handles TxtRuta.TextChanged
        BtnAceptar.Enabled = False
    End Sub


    Private Function ValidaDocumentoCargado() As Boolean
        Return TxtRuta.Text.Equals("")
    End Function

    Private Sub BtnConsultaAcuse_Click(sender As Object, e As EventArgs) Handles BtnConsultaAcuse.Click
        Dim ws As New WsPricesmart.wsRecepcion
        Dim cError As Boolean = False
        Dim cClaveFiscalCR As String = ""
        Dim cTipoIdReceptor As String = ""
        Dim cIdReceptor As String = ""
        Dim cForzarMensaje As Integer = -1
        Dim cRespuestaXML As String = ""
        Dim cMensajeRespuesta As String = ""
        Dim cConsecutivoAcuseRecepcion As String = ""
        Dim cConsecutivoDocumentoRecibido As String = ""
        Dim cFechaHoras As String = ""
        Dim cCorreoElectronicoReceptor As String = ""

        Try

            'cIdReceptor = "3101486354"

            cIdReceptor = "3101231707"

            If cIdReceptor.Length = 9 Then

                cTipoIdReceptor = "01"

            ElseIf cIdReceptor.Length > 9 Then

                cTipoIdReceptor = "02"

            End If

            If TxtRuta.Text.Equals("") Then

                cClaveFiscalCR = InputBox("Digite la clave del documento a consultar")

            Else

                Dim documento As XElement = XElement.Load(TxtRuta.Text)
                Dim factura As IEnumerable(Of XElement) = documento.Elements()
                cClaveFiscalCR = factura(0).Value().ToString()

            End If

            If cClaveFiscalCR.Equals("") Then
                Exit Sub
            End If

            ws.ObtenerAcuseRecepcion(cClaveFiscalCR, cRespuestaXML, cMensajeRespuesta, cTipoIdReceptor, cIdReceptor, cConsecutivoAcuseRecepcion, cConsecutivoDocumentoRecibido, cFechaHoras, cCorreoElectronicoReceptor, cError, cMensajeRespuesta, cForzarMensaje)

            If Not cError Then
                Dim documento As XElement = XElement.Parse(cRespuestaXML)
                Dim factura As IEnumerable(Of XElement) = documento.Elements()
                Dim mensaje As Integer = factura(3).Value.ToString()
                Select Case mensaje
                    Case 1
                        MsgBox("Aceptado")
                    Case 2
                        MsgBox("Pendiente")
                    Case 3
                        MsgBox(factura(4).Value().ToString())
                End Select
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAcuse_Click(sender As Object, e As EventArgs) Handles BtnAcuse.Click
        Dim OFD As New OpenFileDialog()
        Try

            TxtAcuse.Text = ""

            OFD.Filter = "XML Files (*.xml)|*.xml"
            OFD.FilterIndex = 0
            OFD.DefaultExt = "xml"

            If OFD.ShowDialog() = DialogResult.OK Then
                If Not String.Equals(Path.GetExtension(OFD.FileName), ".xml", StringComparison.OrdinalIgnoreCase) Then
                    VerificaMensaje("El tipo de archivo seleccionado no es permitido, debe de seleccionar un archivo XML")
                Else
                    TxtAcuse.Text = OFD.FileName
                    If Not TxtAcuse.Text.Equals("") And Not TxtRuta.Text.Equals("") Then
                        BtnAceptar.Enabled = True
                    End If

                End If
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            OFD = Nothing
        End Try
    End Sub
End Class