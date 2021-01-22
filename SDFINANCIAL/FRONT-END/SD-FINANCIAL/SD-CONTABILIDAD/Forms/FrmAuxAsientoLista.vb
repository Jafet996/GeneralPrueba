Imports BUSINESS
Public Class FrmAuxAsientoLista
#Region "Enum"
    Private Enum Enum_Columna
        Asiento_Id = 0
        Tipo = 1
        Origen = 2
        Comentario = 3
        Periodo = 4
        Fecha = 5
        Debito = 6
        Credito = 7
    End Enum
#End Region
#Region "Variables"
    Private _Titulo As String = "Auxiliar de Asientos"
    Private _ColorDiferencia As Color = Color.LightCoral
#End Region

    Public Sub Execute()
        Try
            Me.Text = _Titulo
            CargaCombo()
            ConfiguraLista()
            ChkPeriodo.Checked = True

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombo()
        Dim AsientoTipo As New TAsientoTipo
        Dim AsientoOrigen As New TAsientoOrigen

        Try
            AsientoTipo.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(AsientoTipo.LoadComboBox(CmbTipoAsiento))
            AsientoOrigen.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(AsientoOrigen.LoadComboBox(CmbOrigen))

            CargaComboAnnio(CmbAnnio)
            CargaComboMes(CmbMes)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoTipo = Nothing
            AsientoOrigen = Nothing
        End Try
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwAsientos
                .Columns(Enum_Columna.Asiento_Id).Text = "N°"
                .Columns(Enum_Columna.Asiento_Id).Width = 50

                .Columns(Enum_Columna.Tipo).Text = "Tipo"
                .Columns(Enum_Columna.Tipo).Width = 120

                .Columns(Enum_Columna.Origen).Text = "Origen"
                .Columns(Enum_Columna.Origen).Width = 120

                .Columns(Enum_Columna.Comentario).Text = "Comentario"
                .Columns(Enum_Columna.Comentario).Width = 400

                .Columns(Enum_Columna.Periodo).Text = "Periodo"
                .Columns(Enum_Columna.Periodo).Width = 90

                .Columns(Enum_Columna.Fecha).Text = "Fecha"
                .Columns(Enum_Columna.Fecha).Width = 90

                .Columns(Enum_Columna.Debito).Text = "Debito"
                .Columns(Enum_Columna.Debito).Width = 130
                .Columns(Enum_Columna.Debito).TextAlign = HorizontalAlignment.Right

                .Columns(Enum_Columna.Credito).Text = "Crédito"
                .Columns(Enum_Columna.Credito).Width = 130
                .Columns(Enum_Columna.Credito).TextAlign = HorizontalAlignment.Right
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub HabilitaBotones(pHabilita As Boolean)
        Try
            BtnConsultar.Enabled = pHabilita
            BtnAplicar.Enabled = pHabilita
            BtnBorrar.Enabled = pHabilita
            BtnSalir.Enabled = pHabilita
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As String
        Try
            If ChkAsientoTipo.Checked AndAlso CmbTipoAsiento.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un tipo de asiento")
            End If

            If ChkPeriodo.Checked AndAlso CmbMes.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un tipo de asiento")
            End If

            If ChkPeriodo.Checked AndAlso CmbAnnio.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un tipo de asiento")
            End If

            If ChkOrigen.Checked AndAlso CmbOrigen.SelectedIndex = -1 Then
                VerificaMensaje("Debe de digitar un texto para buscar")
            End If

            If ChkTotal.Checked AndAlso CmbTotal.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar un distintivo en los totales")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub CargaLista()
        Dim AsientoEncabezado As New TAuxAsientoEncabezado
        Dim Item As ListViewItem = Nothing
        Dim Items(7) As String
        Dim Totales As Integer = -1

        Try
            Cursor = Cursors.WaitCursor
            HabilitaBotones(False)
            LvwAsientos.Items.Clear()
            VerificaMensaje(ValidaTodo)

            If ChkTotal.Checked Then
                Totales = CmbTotal.SelectedIndex
            End If

            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = IIf(Not ChkAsientoTipo.Checked, 0, CmbTipoAsiento.SelectedValue)
                .Mes = IIf(ChkPeriodo.Checked, CmbMes.SelectedIndex + 1, 0)
                .Annio = IIf(ChkPeriodo.Checked, CmbAnnio.Text, 0)
                .Origen_Id = IIf(ChkOrigen.Checked, CmbOrigen.SelectedValue, 0)
            End With
            VerificaMensaje(AsientoEncabezado.ListaResumida(Totales))

            If AsientoEncabezado.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In AsientoEncabezado.Datos.Tables(0).Rows
                Items(0) = Fila("Asiento_Id")
                Items(1) = Fila("Tipo")
                Items(2) = Fila("Origen")
                Items(3) = Fila("Comentario")
                Items(4) = Fila("Periodo")
                Items(5) = Format(Fila("Fecha"), "dd/MM/yyyy")
                Items(6) = Fila("Debitos")
                Items(7) = Fila("Creditos")

                Item = New ListViewItem(Items)
                Item.Checked = True
                If CDbl(Fila("Debitos")) <> CDbl(Fila("Creditos")) Then
                    Item.BackColor = _ColorDiferencia
                    Item.Checked = False
                End If
                LvwAsientos.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoEncabezado = Nothing
            Cursor = Cursors.Default
            HabilitaBotones(True)
        End Try
    End Sub

    Private Sub ConsultaDetalle()
        Dim Forma As New FrmAsientoDetalle
        Dim Num As Integer = 0

        Try
            If LvwAsientos.SelectedItems Is Nothing OrElse LvwAsientos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un asiento de la lista")
            End If

            Num = CInt(LvwAsientos.SelectedItems(0).SubItems(0).Text.Trim)

            With Forma
                .Titulo = "Detalle del Asiento Aux #" & Num
                .Asiento_Id = Num
                .TipoReporte = FrmAsientoDetalle.Enum_TipoReporte.AuxAsiento
                .Execute()
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Function ValidaAplicarAsientos() As String
        Try
            If ChkPeriodo.Checked Then
                If CInt(CmbAnnio.Text) < EmpresaParametroInfo.GetProcesoAnnio Then
                    VerificaMensaje("No puede subir asientos a contabilidad de un periodo cerrado")
                End If
                If CInt(CmbAnnio.Text) = EmpresaParametroInfo.GetProcesoAnnio Then
                    If MesNumero(CmbMes.Text) < EmpresaParametroInfo.GetProcesoMes Then
                        VerificaMensaje("No puede subir asientos a contabilidad de un periodo cerrado")
                    End If
                End If
            End If

            If LvwAsientos Is Nothing OrElse LvwAsientos.CheckedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar al menos un asiento para poder aplicar")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub AplicarAsientos()
        Dim AuxAsientoEncabezado As New TAuxAsientoEncabezado
        Dim Forma As New FrmListaResultados
        Dim Todos As Boolean = True
        Dim Respondio As Boolean = False
        Dim Asientos() As Integer
        Dim Diferencias As Integer = 0
        Dim i As Integer = 0

        Try
            HabilitaBotones(False)
            VerificaMensaje(ValidaAplicarAsientos)

            If MsgBox("¿Desea pasar a contabilidad los asientos seleccionados en la lista?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            ReDim Preserve Asientos(LvwAsientos.CheckedItems.Count - 1)

            For Each Item As ListViewItem In LvwAsientos.CheckedItems
                If Item.BackColor = _ColorDiferencia Then
                    Diferencias += 1
                    If Not Respondio AndAlso Todos Then
                        If MsgBox("¿Desea pasar los asientos que tienen diferencias?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                            Todos = False
                        End If
                        Respondio = True
                    End If
                End If
                If Item.BackColor = _ColorDiferencia And Not Todos Then
                    i += 1
                    Continue For
                End If
                Asientos(i) = CInt(Item.SubItems(0).Text)
                i += 1
            Next

            If Diferencias = LvwAsientos.CheckedItems.Count And Not Todos Then
                VerificaMensaje("Todos los asientos disponibles poseen diferencias")
            End If

            AuxAsientoEncabezado.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(AuxAsientoEncabezado.AuxAsientoPasaConta(Asientos, PrgProgreso))
            CargaLista()
            MsgBox("¡El proceso se completo exitosamente!", MsgBoxStyle.Information, Me.Text)
            If AuxAsientoEncabezado.ListaErrores.Count > 0 Then Forma.Execute(AuxAsientoEncabezado.ListaErrores)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AuxAsientoEncabezado = Nothing
            Cursor = Cursors.Default
            HabilitaBotones(True)
        End Try
    End Sub

    Private Function ValidaElimiarAsientos() As String
        Try
            If LvwAsientos Is Nothing OrElse LvwAsientos.CheckedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar al menos un asiento para borrarlo")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub EliminarAsientos()
        Dim AuxAsientoEncabezado As TAuxAsientoEncabezado
        Dim ListaErrores As New List(Of String)
        Dim Forma As New FrmListaResultados
        Dim Asiento As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            HabilitaBotones(False)
            VerificaMensaje(ValidaElimiarAsientos)

            If MsgBox("¿Desea eliminar los asientos seleccionados de la lista?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            PrgProgreso.Minimum = 0
            PrgProgreso.Maximum = LvwAsientos.CheckedItems.Count
            PrgProgreso.Value = 0

            For Each Item As ListViewItem In LvwAsientos.CheckedItems
                Try
                    PrgProgreso.Value += 1
                    AuxAsientoEncabezado = New TAuxAsientoEncabezado

                    With AuxAsientoEncabezado
                        .Emp_Id = EmpresaInfo.Emp_Id
                        .Asiento_Id = CInt(Item.SubItems(Enum_Columna.Asiento_Id).Text.Trim)
                        .Usuario_Id = UsuarioInfo.Usuario_Id
                    End With
                    VerificaMensaje(AuxAsientoEncabezado.Delete)
                Catch ex As Exception
                    ListaErrores.Add("Asiento #" & Asiento & ": " & ex.Message)
                End Try

            Next

            CargaLista()
            MsgBox("¡El proceso se completo exitosamente!", MsgBoxStyle.Information, Me.Text)
            If ListaErrores.Count > 0 Then Forma.Execute(ListaErrores)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AuxAsientoEncabezado = Nothing
            Cursor = Cursors.Default
            HabilitaBotones(True)
        End Try
    End Sub

    Private Sub MarcarTodos()
        Try
            For Each Item As ListViewItem In LvwAsientos.Items
                Item.Checked = True
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DesmarcarTodo()
        Try
            For Each Item As ListViewItem In LvwAsientos.CheckedItems
                Item.Checked = False
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub InvertirSeleccion()
        Try
            For Each Item As ListViewItem In LvwAsientos.Items
                Item.Checked = Not Item.Checked
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MarcarSeleccionados()
        Try
            For Each Item As ListViewItem In LvwAsientos.SelectedItems
                Item.Checked = True
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DesmarcarSeleccionados()
        Try
            For Each Item As ListViewItem In LvwAsientos.SelectedItems
                Item.Checked = False
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ChkAsientoTipo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAsientoTipo.CheckedChanged
        CmbTipoAsiento.Enabled = ChkAsientoTipo.Checked
        CargaLista()
    End Sub

    Private Sub CmbTipoAsiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoAsiento.SelectedIndexChanged
        If Not ChkAsientoTipo.Checked OrElse CmbTipoAsiento.SelectedValue.ToString = "System.Data.DataRowView" Then
            Exit Sub
        End If

        CargaLista()
    End Sub

    Private Sub ChkOrigen_CheckedChanged(sender As Object, e As EventArgs) Handles ChkOrigen.CheckedChanged
        CmbOrigen.Enabled = ChkOrigen.Checked
        CargaLista()
    End Sub

    Private Sub CmbOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbOrigen.SelectedIndexChanged
        If Not ChkOrigen.Checked OrElse CmbOrigen.SelectedValue.ToString = "System.Data.DataRowView" Then
            Exit Sub
        End If

        CargaLista()
    End Sub

    Private Sub ChkPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPeriodo.CheckedChanged
        CmbMes.Enabled = ChkPeriodo.Checked
        CmbAnnio.Enabled = ChkPeriodo.Checked
        CargaLista()
    End Sub

    Private Sub CmbAnnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAnnio.SelectedIndexChanged
        If Not ChkPeriodo.Checked Or CmbAnnio.SelectedIndex = -1 Then
            Exit Sub
        End If

        CargaLista()
    End Sub

    Private Sub CmbMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMes.SelectedIndexChanged
        If Not ChkPeriodo.Checked Or CmbMes.SelectedIndex = -1 Then
            Exit Sub
        End If

        CargaLista()
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        ConsultaDetalle()
    End Sub

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        AplicarAsientos()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmAuxAsientoLista_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnConsultar.PerformClick()
            Case Keys.F3
                BtnAplicar.PerformClick()
            Case Keys.F4
                BtnBorrar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub LvwAsientos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LvwAsientos.MouseDoubleClick
        Try
            LvwAsientos.SelectedItems(0).Checked = Not LvwAsientos.SelectedItems(0).Checked

            ConsultaDetalle()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ChkTotal_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTotal.CheckedChanged
        CmbTotal.Enabled = ChkTotal.Checked
        If CmbTotal.SelectedIndex < 0 Then CmbTotal.SelectedIndex = 0
        CargaLista()
    End Sub

    Private Sub CmbTotal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTotal.SelectedIndexChanged
        If Not ChkTotal.Checked OrElse CmbTotal.SelectedIndex = -1 Then
            Exit Sub
        End If

        CargaLista()
    End Sub

    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles BtnBorrar.Click
        EliminarAsientos()
    End Sub

    Private Sub BtnMarcarTodo_Click(sender As Object, e As EventArgs) Handles BtnMarcarTodo.Click
        MarcarTodos()
    End Sub

    Private Sub BtnDesmarcarTodo_Click(sender As Object, e As EventArgs) Handles BtnDesmarcarTodo.Click
        DesmarcarTodo()
    End Sub

    Private Sub BtnInvertirSeleccion_Click(sender As Object, e As EventArgs) Handles BtnInvertirSeleccion.Click
        InvertirSeleccion()
    End Sub

    Private Sub BtnMarcarSeleccionados_Click(sender As Object, e As EventArgs) Handles BtnMarcarSeleccionados.Click
        MarcarSeleccionados()
    End Sub

    Private Sub BtnDesmarcarSeleccionados_Click(sender As Object, e As EventArgs) Handles BtnDesmarcarSeleccionados.Click
        DesmarcarSeleccionados()
    End Sub

    Private Sub CmsAyudaLvw_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmsAyudaLvw.Opening
        If LvwAsientos.SelectedItems Is Nothing OrElse LvwAsientos.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

End Class