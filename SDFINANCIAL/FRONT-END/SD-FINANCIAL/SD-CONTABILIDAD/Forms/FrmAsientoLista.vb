Imports BUSINESS
Public Class FrmAsientoLista
#Region "Enum"
    Private Enum Enum_Columna
        Asiento_Id = 0
        Tipo = 1
        Origen = 2
        Comentario = 3
        Periodo = 4
        Fecha = 5
        Estado = 6
        Debito = 7
        Credito = 8
    End Enum
#End Region
#Region "Variables"
    Private _Titulo As String = "Resumen de Asientos"
    Private _ColorDiferencia As Color = Color.LightCoral
#End Region

    Public Sub Execute()
        Me.Text = _Titulo
        CargaCombo()
        ConfiguraLista()
        ChkPeriodo.Checked = True

        Me.ShowDialog()
    End Sub

    Private Sub HabilitaBotones(pHabilita As Boolean)
        Try
            BtnNuevo.Enabled = pHabilita
            BtnModificar.Enabled = pHabilita
            BtnDetalle.Enabled = pHabilita
            BtnAplicar.Enabled = pHabilita
            BtnBorrar.Enabled = pHabilita
            BtnReversa.Enabled = pHabilita
            BtnSalir.Enabled = pHabilita
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub HabilitaBotonesxEstado()
        Dim Estado As Integer = 0

        Try
            If ChkEstado.Checked Then Estado = CmbEstado.SelectedValue

            Select Case Estado
                Case Enum_AsientoEstado.Digitado
                    BtnAplicar.Enabled = True
                    BtnBorrar.Enabled = True
                    BtnReversa.Enabled = False
                Case Enum_AsientoEstado.Aplicado
                    BtnAplicar.Enabled = False
                    BtnBorrar.Enabled = False
                    BtnReversa.Enabled = True
                Case Else
                    BtnAplicar.Enabled = False
                    BtnBorrar.Enabled = False
                    BtnReversa.Enabled = False
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombo()
        Dim AsientoTipo As New TAsientoTipo
        Dim AsientoEstado As New TAsientoEstado

        Try
            AsientoTipo.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(AsientoTipo.LoadComboBox(CmbTipoAsiento))
            AsientoEstado.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(AsientoEstado.LoadComboBox(CmbEstado))

            CargaComboAnnio(CmbAnnio)
            CargaComboMes(CmbMes)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoTipo = Nothing
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
                .Columns(Enum_Columna.Origen).Width = 110

                .Columns(Enum_Columna.Comentario).Text = "Comentario"
                .Columns(Enum_Columna.Comentario).Width = 380

                .Columns(Enum_Columna.Periodo).Text = "Periodo"
                .Columns(Enum_Columna.Periodo).Width = 80

                .Columns(Enum_Columna.Fecha).Text = "Fecha"
                .Columns(Enum_Columna.Fecha).Width = 90

                .Columns(Enum_Columna.Estado).Text = "Estado"
                .Columns(Enum_Columna.Estado).Width = 80

                .Columns(Enum_Columna.Debito).Text = "Debito"
                .Columns(Enum_Columna.Debito).Width = 150
                .Columns(Enum_Columna.Debito).TextAlign = HorizontalAlignment.Right

                .Columns(Enum_Columna.Credito).Text = "Crédito"
                .Columns(Enum_Columna.Credito).Width = 150
                .Columns(Enum_Columna.Credito).TextAlign = HorizontalAlignment.Right
            End With
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

            If ChkEstado.Checked AndAlso CmbEstado.SelectedIndex = -1 Then
                VerificaMensaje("Debe de digitar un texto para buscar")
            End If

            If ChkFechas.Checked AndAlso DateValue(DtpFechaInicio.Value) > DateValue(DtpFechaFinal.Value) Then
                VerificaMensaje("La fecha de Inicio no puede ser posterior a la de finalización")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub CargaLista()
        Dim AsientoEncabezado As New TAsientoEncabezado
        Dim FechaFinal As DateTime
        Dim Mes As Integer = 0
        Dim Annio As Integer = 0
        Dim Estado As Integer = 0
        Dim Item As ListViewItem = Nothing
        Dim Items(8) As String

        Try
            LvwAsientos.Items.Clear()
            HabilitaBotones(False)
            VerificaMensaje(ValidaTodo)
            FechaFinal = DateAdd(DateInterval.Day, 1, DtpFechaFinal.Value)
            Mes = IIf(ChkPeriodo.Checked, CmbMes.SelectedIndex + 1, 0)
            Annio = IIf(ChkPeriodo.Checked, CmbAnnio.Text, 0)
            Estado = IIf(ChkEstado.Checked, CmbEstado.SelectedValue, 0)

            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Tipo_Id = IIf(Not ChkAsientoTipo.Checked, 0, CmbTipoAsiento.SelectedValue)
            End With
            VerificaMensaje(AsientoEncabezado.ListaResumida(ChkFechas.Checked, DtpFechaInicio.Value, FechaFinal, Estado, Mes, Annio))

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
                Items(6) = Fila("Estado")
                Items(7) = Format(Fila("Debitos"), "#,##0.00")
                Items(8) = Format(Fila("Creditos"), "#,##0.00")

                Item = New ListViewItem(Items)
                Item.Tag = Fila("Estado_Id")
                If CInt(Fila("Estado_Id")) = Estado Then Item.Checked = True
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
            HabilitaBotones(True)
            HabilitaBotonesxEstado()
        End Try
    End Sub

    Private Sub Nuevo()
        Dim Forma As New FrmMantAsientoDetalle

        Try
            With Forma
                .Nuevo = True
                .Titulo = "Nuevo Asiento Contable"
                .Asiento_Id = -1
                .Execute()
            End With

            If Forma.GuardoCambios Then
                CargaLista()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub Modificar()
        Dim Forma As New FrmMantAsientoDetalle
        Dim Asiento As Integer = 0

        Try
            If LvwAsientos.SelectedItems Is Nothing OrElse LvwAsientos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un asiento para poder consultarlo")
            End If

            If Not VerificaPermiso(EmpresaInfo.Emp_Id, UsuarioInfo.Usuario_Id, Permisos.CoConsultarDetalleAsiento, False) Then
                VerificaMensaje("No tiene permiso para consultar el detalle del asiento")
            End If

            Asiento = CInt(LvwAsientos.SelectedItems.Item(0).SubItems(Enum_Columna.Asiento_Id).Text.Trim)

            With Forma
                .Nuevo = False
                .Titulo = "Asiento Contable #" & Asiento.ToString
                .Asiento_Id = Asiento
                .Execute()
            End With

            If Forma.GuardoCambios Then
                CargaLista()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
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
                .Titulo = "Detalle del Asiento #" & Num
                .Asiento_Id = Num
                .TipoReporte = FrmAsientoDetalle.Enum_TipoReporte.Asiento
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
                If CInt(CmbAnnio.Text) <> EmpresaParametroInfo.GetProcesoAnnio Then
                    VerificaMensaje("No puede aplicar asientos de un periodo distinto al actual")
                End If
                If CInt(CmbAnnio.Text) = EmpresaParametroInfo.GetProcesoAnnio Then
                    If MesNumero(CmbMes.Text) <> EmpresaParametroInfo.GetProcesoMes Then
                        VerificaMensaje("No puede aplicar asientos de un periodo distinto al actual")
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
        Dim AsientoEncabezado As New TAsientoEncabezado
        Dim Forma As New FrmListaResultados
        Dim Asientos() As Integer
        Dim Diferencias As Integer = 0
        Dim i As Integer = 0

        Try
            HabilitaBotones(False)
            VerificaMensaje(ValidaAplicarAsientos)

            If MsgBox("¿Desea aplicar los asientos seleccionados en la lista?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            ReDim Preserve Asientos(LvwAsientos.CheckedItems.Count - 1)

            For Each Item As ListViewItem In LvwAsientos.CheckedItems
                If Item.BackColor = _ColorDiferencia Then
                    Diferencias += 1
                    Continue For
                End If
                Asientos(i) = CInt(Item.SubItems(0).Text)
                i += 1
            Next

            If Diferencias = LvwAsientos.CheckedItems.Count Then
                VerificaMensaje("No se pueden aplicar asientos con diferencias")
            End If

            AsientoEncabezado.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(AsientoEncabezado.AplicarMasivo(Asientos, PrgProgreso))
            CargaLista()
            MsgBox("¡El proceso se completo exitosamente!", MsgBoxStyle.Information, Me.Text)
            If AsientoEncabezado.ListaErrores.Count > 0 Then Forma.Execute(AsientoEncabezado.ListaErrores)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoEncabezado = Nothing
            Cursor = Cursors.Default
            HabilitaBotones(True)
            HabilitaBotonesxEstado()
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
        Dim AuxAsientoEncabezado As TAsientoEncabezado
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
                    Asiento = CInt(Item.SubItems(Enum_Columna.Asiento_Id).Text.Trim)

                    If Item.Tag = Enum_AsientoEstado.Aplicado Then
                        VerificaMensaje("No puede borrar asientos aplicados")
                    End If

                    AuxAsientoEncabezado = New TAsientoEncabezado

                    With AuxAsientoEncabezado
                        .Emp_Id = EmpresaInfo.Emp_Id
                        .Asiento_Id = Asiento
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
            HabilitaBotonesxEstado()
        End Try
    End Sub

    Private Function ValidaReversaAsientos() As String
        Try
            If LvwAsientos Is Nothing OrElse LvwAsientos.CheckedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar al menos un asiento para reversar")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub ReversaAsientos()
        Dim AuxAsientoEncabezado As TAsientoEncabezado
        Dim ListaErrores As New List(Of String)
        Dim Forma As New FrmListaResultados
        Dim Asiento As Integer = 0

        Try
            HabilitaBotones(False)
            Cursor = Cursors.WaitCursor
            VerificaMensaje(ValidaReversaAsientos)

            If MsgBox("¿Desea reversar los asientos seleccionados de la lista?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            PrgProgreso.Minimum = 0
            PrgProgreso.Maximum = LvwAsientos.CheckedItems.Count
            PrgProgreso.Value = 0

            For Each Item As ListViewItem In LvwAsientos.CheckedItems
                Try
                    PrgProgreso.Value += 1
                    Asiento = CInt(Item.SubItems(Enum_Columna.Asiento_Id).Text.Trim)

                    If Item.Tag <> Enum_AsientoEstado.Aplicado Then
                        VerificaMensaje("No puede reversar asientos que no han sido aplicados")
                    End If

                    AuxAsientoEncabezado = New TAsientoEncabezado

                    With AuxAsientoEncabezado
                        .Emp_Id = EmpresaInfo.Emp_Id
                        .Asiento_Id = Asiento
                    End With
                    VerificaMensaje(AuxAsientoEncabezado.ReversaAsiento)

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
            HabilitaBotonesxEstado()
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

    Private Sub CmbTipoAsiento_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbTipoAsiento.SelectedValueChanged
        If Not ChkAsientoTipo.Checked OrElse CmbTipoAsiento.SelectedValue.ToString = "System.Data.DataRowView" Then
            Exit Sub
        End If

        CargaLista()
    End Sub

    Private Sub DtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles DtpFechaInicio.ValueChanged
        If Not ChkFechas.Checked Then
            Exit Sub
        End If

        CargaLista()
    End Sub

    Private Sub DtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles DtpFechaFinal.ValueChanged
        If Not ChkFechas.Checked Then
            Exit Sub
        End If

        CargaLista()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Nuevo()
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmAsientoLista_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnNuevo.PerformClick()
            Case Keys.F3
                BtnModificar.PerformClick()
            Case Keys.F4
                BtnDetalle.PerformClick()
            Case Keys.F5
                BtnAplicar.PerformClick()
            Case Keys.F6
                BtnBorrar.PerformClick()
            Case Keys.F7
                BtnReversa.PerformClick()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub ChkAsientoTipo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAsientoTipo.CheckedChanged
        CmbTipoAsiento.Enabled = ChkAsientoTipo.Checked
        CargaLista()
    End Sub

    Private Sub ChkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFechas.CheckedChanged
        DtpFechaInicio.Enabled = ChkFechas.Checked
        DtpFechaFinal.Enabled = ChkFechas.Checked
        CargaLista()
    End Sub

    Private Sub ChkComentario_CheckedChanged(sender As Object, e As EventArgs) Handles ChkEstado.CheckedChanged
        CmbEstado.Enabled = ChkEstado.Checked
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

    Private Sub CmbEstado_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbEstado.SelectedValueChanged
        If Not ChkEstado.Checked Or CmbEstado.SelectedIndex = -1 Then
            Exit Sub
        End If

        CargaLista()
    End Sub

    Private Sub LvwAsientos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LvwAsientos.MouseDoubleClick
        Try
            LvwAsientos.SelectedItems(0).Checked = Not LvwAsientos.SelectedItems(0).Checked

            Modificar()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnDetalle_Click(sender As Object, e As EventArgs) Handles BtnDetalle.Click
        ConsultaDetalle()
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

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        AplicarAsientos()
    End Sub

    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles BtnBorrar.Click
        EliminarAsientos()
    End Sub

    Private Sub BtnReversa_Click(sender As Object, e As EventArgs) Handles BtnReversa.Click
        ReversaAsientos()
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