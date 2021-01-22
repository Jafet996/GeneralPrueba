Imports Business
Public Class FrmConteoFisicoBodegas
    Dim Numerico() As TNumericFormat
    Dim _TomaFisica As TTomaFisicaEncabezado = Nothing

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtFisico, 8, 0, False, "0", "#,##0")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(pTomaFisica As TTomaFisicaEncabezado)
        Try

            _TomaFisica = pTomaFisica
            CargaBodega()
            FormateaCamposNumericos()
            TxtArticulo.Select()
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub InicializaDetalle()
        BtnLimpiar.Enabled = False
        PnlDetalle.Enabled = False
        TxtArticulo.Text = ""
        TxtArticuloNombre.Text = ""
        TxtFisico.Text = "0"
        TxtFisicoActual.Text = "0"
    End Sub

    Private Sub CargaBodega()
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)

        Try
            With Bodega
                .Suc_Id = _TomaFisica.Suc_Id
                .Bod_Id = _TomaFisica.Bod_Id
            End With

            VerificaMensaje(Bodega.ListKey)

            LblBodegaNombre.Text = Bodega.Nombre

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub




    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Try
            InicializaDetalle()
            TxtArticulo.Enabled = True
            TxtArticulo.Focus()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CargarDatosDetalle()
        Dim TFDetalle As New TTomaFisicaDetalle(EmpresaInfo.Emp_Id)
        Try

            TFDetalle.Suc_Id = _TomaFisica.Suc_Id
            TFDetalle.Bod_Id = _TomaFisica.Bod_Id
            TFDetalle.TomaFisica_Id = _TomaFisica.TomaFisica_Id
            TFDetalle.Art_Id = TxtArticulo.Text

            VerificaMensaje(TFDetalle.ListKey)

            If TFDetalle.RowsAffected = 0 Then
                VerificaMensaje("No se ha encontrado el artículo en la toma física actual")
            End If

            TxtArticuloNombre.Text = TFDetalle.Nombre
            TxtFisicoActual.Text = TFDetalle.Fisico
            TxtFisico.Text = "0"
            TxtFisico.Select()


            BtnLimpiar.Enabled = True
            TxtArticulo.Enabled = False
            PnlDetalle.Enabled = True
            TxtFisico.Select()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TFDetalle = Nothing
        End Try
    End Sub

    Private Sub BuscarArticulo()
        Dim Forma As New FrmBuscaArticuloTomaFisica

        Try
            Forma.Execute(_TomaFisica.Bod_Id, _TomaFisica.TomaFisica_Id)
            If Forma.Art_Id.Trim <> "" Then
                TxtArticulo.Text = Forma.Art_Id
                CargarDatosDetalle()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub TxtArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtArticulo.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BuscarArticulo()
            Case Keys.Enter
                If TxtArticulo.Text.Trim <> "" Then
                    CargarDatosDetalle()
                End If
            Case Keys.Escape
                TxtArticulo.Text = ""
        End Select
    End Sub

    Private Sub TxtArticulo_TextChanged(sender As Object, e As EventArgs) Handles TxtArticulo.TextChanged
        TxtArticuloNombre.Text = ""
    End Sub

    Private Sub AplicarMovimiento()
        Dim TFDetalle As New TTomaFisicaDetalle(EmpresaInfo.Emp_Id)
        Try

            TFDetalle.Suc_Id = _TomaFisica.Suc_Id
            TFDetalle.Bod_Id = _TomaFisica.Bod_Id
            TFDetalle.TomaFisica_Id = _TomaFisica.TomaFisica_Id
            TFDetalle.Art_Id = TxtArticulo.Text

            VerificaMensaje(TFDetalle.ConsultaArticulo)

            If TFDetalle.RowsAffected = 0 Then
                VerificaMensaje("No se ha encontrado el artículo en la toma física actual")
            End If

            If RdbSumar.Checked Then
                TFDetalle.Fisico += CInt(TxtFisico.Text.Trim)
            End If

            If RdbRestar.Checked Then
                TFDetalle.Fisico -= CInt(TxtFisico.Text.Trim)
            End If

            If RdbReemplazar.Checked Then
                TFDetalle.Fisico = CInt(TxtFisico.Text.Trim)
            End If

            VerificaMensaje(TFDetalle.ActualizaConteo)

            InicializaDetalle()

            TxtArticulo.Enabled = True
            TxtArticulo.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TFDetalle = Nothing
        End Try
    End Sub

    Private Function ValidaArticulo() As Boolean
        Try
            If Not IsNumeric(TxtFisico.Text) OrElse CDbl(TxtFisico.Text) <= 0 Then
                VerificaMensaje("La cantidad debe de ser mayor a cero")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        If ValidaArticulo() Then
            AplicarMovimiento()
        End If
    End Sub

    Private Sub TxtFisico_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFisico.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                BtnAplicar.PerformClick()
        End Select
    End Sub

    Private Sub BtnCarga_Click(sender As Object, e As EventArgs) Handles BtnCarga.Click
        CargaArticulos()
    End Sub

    Private Sub CargaArticulos()
        Dim Forma As New FrmCargaArticulos
        Dim TomaFisicaDetalle As New TTomaFisicaDetalle(EmpresaInfo.Emp_Id)
        Try

            BtnCarga.Enabled = False

            Forma.ValidaSueltos = False
            Forma.VerificaBodega = True
            Forma.Suc_Id = _TomaFisica.Suc_Id
            Forma.Bod_Id = _TomaFisica.Bod_Id
            Forma.Execute()

            If Not Forma.Guardo Then
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            With TomaFisicaDetalle
                .Suc_Id = _TomaFisica.Suc_Id
                .Bod_Id = _TomaFisica.Bod_Id
                .TomaFisica_Id = _TomaFisica.TomaFisica_Id
            End With

            With PrgProgreso
                .Visible = True
                .Minimum = 0
                .Maximum = Forma.ListaConteo.Count
                .Value = 0
            End With

            For Each conteo As TArticuloConteo In Forma.ListaConteo
                PrgProgreso.Value = PrgProgreso.Value + 1
                If conteo.Cantidad > 0 Then
                    With TomaFisicaDetalle
                        .Art_Id = conteo.Art_Id
                        .Fisico = conteo.Cantidad
                    End With
                    VerificaMensaje(TomaFisicaDetalle.SumaConteo)
                End If
            Next

            Mensaje("El archivo se cargo exitosamente")

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
            TomaFisicaDetalle = Nothing
            BtnCarga.Enabled = True
            PrgProgreso.Visible = False
            Cursor = Cursors.Default
        End Try
    End Sub

End Class