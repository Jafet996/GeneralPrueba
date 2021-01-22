Imports Business

Public Class FrmGeneraEtiquetaMediKam

    Enum EtiquetaPosicion
        Art_Id = 0
        FechaVencimiento = 1
        Lote = 2
    End Enum

    Private ValoresEtiqueta As List(Of String)


    Public Sub Execute()
        Try

            ValoresEtiqueta = New List(Of String)(3)
            ValoresEtiqueta.Add("")
            ValoresEtiqueta.Add(Now.ToString("yyMMdd"))
            ValoresEtiqueta.Add("")

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub TxtArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtArticulo.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim forma As New FrmBuscaArticuloOnLine()
            forma.Execute()
            If forma.Art_Id <> "" Then
                TxtArticulo.Text = forma.Art_Id
                CargaArticulo(TxtArticulo.Text)
            End If
        End If

        If e.KeyCode = Keys.Enter Then
            CargaArticulo(TxtArticulo.Text)
        End If
    End Sub

    Sub CargaArticulo(Art_Id As String)
        Dim consultaArticulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim ArticuloEquivalente As New TArticuloEquivalente(EmpresaInfo.Emp_Id)
        Try

            consultaArticulo.Art_Id = Art_Id
            VerificaMensaje(consultaArticulo.ListKey())

            ArticuloEquivalente.Art_Id = Art_Id
            VerificaMensaje(ArticuloEquivalente.List)

            TxtArticuloNombre.Text = consultaArticulo.Nombre


            CmbNombreMostrar.Items.Add(consultaArticulo.Nombre)
            CmbNombreMostrar.Items.Add(consultaArticulo.Anotaciones)

            CmbNombreMostrar.SelectedIndex = 0


            CmbCodigoMostrar.Items.Add(consultaArticulo.Art_Id)
            If ArticuloEquivalente.Data.Tables.Count > 0 Then
                For Each Fila As DataRow In ArticuloEquivalente.Data.Tables(0).Rows
                    CmbCodigoMostrar.Items.Add(Fila.Item("ArtEquivalente_Id"))
                Next
            End If
            CmbCodigoMostrar.SelectedIndex = 0

            CmbMoneda.SelectedIndex = 0


            HabilitarFormulario(True)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DtpVencimiento_ValueChanged(sender As Object, e As EventArgs) Handles DtpVencimiento.ValueChanged
        Try
            FormarEtiqueta(DtpVencimiento.Value.ToString("yyMMdd"), EtiquetaPosicion.FechaVencimiento)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub FormarEtiqueta(Valor As String, TipoValor As Integer)
        Try
            ValoresEtiqueta(TipoValor) = Valor
            TxtCodigo.Text = "(01)" & ValoresEtiqueta(0) & "(17)" & ValoresEtiqueta(1) & "(21)" & ValoresEtiqueta(2)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub CmbCodigoMostrar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCodigoMostrar.SelectedIndexChanged
        Try
            Dim Valor As String = CmbCodigoMostrar.Items(CmbCodigoMostrar.SelectedIndex)

            FormarEtiqueta(Valor, EtiquetaPosicion.Art_Id)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtLote_TextChanged(sender As Object, e As EventArgs) Handles TxtLote.TextChanged
        Try
            FormarEtiqueta(TxtLote.Text, EtiquetaPosicion.Lote)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtArticulo_TextChanged(sender As Object, e As EventArgs) Handles TxtArticulo.TextChanged
        Try

            If TxtArticulo.Text = "" Then

                HabilitarFormulario(False)
                ReiniciaFormulario()

            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub HabilitarFormulario(valor As Boolean)

        DtpVencimiento.Enabled = valor
        TxtLote.Enabled = valor
        CmbCodigoMostrar.Enabled = valor
        CmbNombreMostrar.Enabled = valor
        CmbMoneda.Enabled = valor

    End Sub

    Private Sub ReiniciaFormulario()
        Try

            CmbCodigoMostrar.Items.Clear()
            CmbNombreMostrar.Items.Clear()
            TxtArticulo.Text = ""
            TxtArticuloNombre.Text = ""
            DtpVencimiento.Value = Now
            TxtLote.Text = ""

            TxtCodigo.Text = "(01)(17)(21)"

            ValoresEtiqueta = New List(Of String)(3)
            ValoresEtiqueta.Add("")
            ValoresEtiqueta.Add(Now.ToString("yyMMdd"))
            ValoresEtiqueta.Add("")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        If ValidaTodo() Then
            MuestraReporte()
        End If
    End Sub

    Private Function ValidaTodo() As Boolean
        Dim mensaje As String = ""
        Try
            If TxtLote.Text = "" Then
                mensaje = "Debe incluir el lote en la etiqueta."
            End If

            If TxtArticulo.Text = "" Then
                mensaje = "Debe digitar el código del articulo a generar la etiqueta."
            End If

            VerificaMensaje(mensaje)

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MuestraReporte()

        Dim Mensaje As String = ""
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Reporte As New GeneraEtiquetaCCSS
        Dim FormaReporte As New FrmReporte
        Dim consultaArticulo As New TArticuloBodega(EmpresaInfo.Emp_Id)

        Try
            Cursor.Current = Cursors.WaitCursor

            consultaArticulo.Art_Id = TxtArticulo.Text
            consultaArticulo.Suc_Id = SucursalParametroInfo.Suc_Id
            consultaArticulo.Bod_Id = 1
            VerificaMensaje(consultaArticulo.ListKey())

            If Form_Abierto("FrmReporte") = False Then

                Dim Art_Id As String = CmbCodigoMostrar.Items(CmbCodigoMostrar.SelectedIndex)
                Dim Nombre As String = CmbNombreMostrar.Items(CmbNombreMostrar.SelectedIndex)

                Reporte.SetParameterValue("Codigo", TxtCodigo.Text)
                Reporte.SetParameterValue("Art_Id", Art_Id)
                Reporte.SetParameterValue("Precio", IIf(CmbMoneda.SelectedIndex = 0, ("₡ " & Format(consultaArticulo.Precio, "###,###.##")), ("$ " & Format((consultaArticulo.Precio / TipoCambioCompra()), "###,###.##"))))
                Reporte.SetParameterValue("Lote", TxtLote.Text)
                Reporte.SetParameterValue("FechaVencimiento", DtpVencimiento.Value.ToString("dd-MM-yyyy"))
                Reporte.SetParameterValue("Nombre", Nombre)



                'FormaReporte.Execute(Reporte)

                Dim arc As String = TxtArticulo.Text + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".pdf"

                Dim sfd As New SaveFileDialog() 'Cuadro de dialogo para elegir la ruta donde se guardará el archivo      
                sfd.Title = "Guardar Como"
                sfd.FileName = arc
                sfd.Filter = "PDF (*.pdf)|*.pdf"
                sfd.ShowDialog() 'mostrar el cuadro de dialogo

                Reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sfd.FileName) 'Indicamos el formato y la ruta a guardar

                Mensaje = "Se generó la etiqueta"
                VerificaMensaje(Mensaje)


            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub FrmGeneraEtiquetaMediKam_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            BtnImprimir.PerformClick()
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class