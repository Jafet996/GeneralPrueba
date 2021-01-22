Imports Business
Public Class FrmRepAsientosCierreSD
#Region "Constantes"
    Private ColorAsiento1 As Color = Color.Blue
    Private ColorAsiento2 As Color = Color.Black
    Private ColorDiferencia As Color = Color.Red
    Private ColorSinCuenta As Color = Color.MediumPurple
#End Region

    Public Sub Execute()
        CargaDetalle()

        Me.ShowDialog()
    End Sub

    Private Sub MuestraReporte(Optional pCaja_Id As Integer = -1, Optional pCierre_Id As Long = -1)
        Dim CajaCierreAsiento As New TCajaCierreAsiento(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptCierreContable
        Dim FormaReporte As New FrmReporte
        Dim Precio_Id As Integer = -1

        Try
            Cursor.Current = Cursors.WaitCursor

            With CajaCierreAsiento
                .Suc_Id = SucursalInfo.Suc_Id
                .Caja_Id = pCaja_Id
                .Cierre_Id = pCierre_Id
            End With
            VerificaMensaje(CajaCierreAsiento.RptCierreContable)

            If CajaCierreAsiento.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(CajaCierreAsiento.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            CajaCierreAsiento = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub ImprimirTodo()
        Try
            If ValidaTodo() Then
                MuestraReporte()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ImprimirAsiento()
        Dim Caja_Id As Integer
        Dim Cierre_Id As Long

        Try
            If LvwAsientos.SelectedItems Is Nothing OrElse LvwAsientos.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            Caja_Id = CInt(LvwAsientos.SelectedItems(0).SubItems(8).Text)
            Cierre_Id = CLng(LvwAsientos.SelectedItems(0).SubItems(2).Text)

            If ValidaTodo() Then
                MuestraReporte(Caja_Id, Cierre_Id)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmRepVentasxCategoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                If BtnRefresca.Enabled Then
                    BtnRefresca.PerformClick()
                End If
            Case Keys.F2
                If BtnImprimir.Enabled Then
                    BtnImprimir.PerformClick()
                End If
            Case Keys.F3
                If BtnImprimirAsiento.Enabled Then
                    BtnImprimirAsiento.PerformClick()
                End If
            Case Keys.F4
                If BtnDetalleCierre.Enabled Then
                    BtnDetalleCierre.PerformClick()
                End If
            Case Keys.F5
                If BtnAplicar.Enabled Then
                    BtnAplicar.PerformClick()
                End If
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        ImprimirTodo()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CargaDetalle()
        Dim CajaCierreAsiento As New TCajaCierreAsiento(EmpresaInfo.Emp_Id)
        Dim Items(8) As String
        Dim Item As ListViewItem
        Dim Caja_Id As Short = -1
        Dim Cierre_Id As Long = -1
        Dim TotalDebe As Double = 0
        Dim TotalHaber As Double = 0
        Dim ColorAsiento As System.Drawing.Color = Color.Black

        Try
            Cursor = Cursors.WaitCursor

            LvwAsientos.Items.Clear()

            With CajaCierreAsiento
                .Suc_Id = SucursalInfo.Suc_Id
                .Caja_Id = -1
                .Cierre_Id = -1
            End With
            VerificaMensaje(CajaCierreAsiento.SD_RptCierreContable)

            For Each Fila As DataRow In CajaCierreAsiento.Data.Tables(0).Rows
                If Caja_Id <> -1 AndAlso (Caja_Id <> Fila("Caja_Id") OrElse Cierre_Id <> Fila("Cierre_Id")) Then

                    Items(0) = ""
                    Items(1) = "TOTAL CIERRE"
                    Items(2) = Cierre_Id
                    Items(3) = StrDup(36, "-")
                    Items(4) = StrDup(34, "-")
                    Items(5) = StrDup(73, "-") & ">"
                    Items(6) = Format(TotalDebe, "#,##0.00")
                    Items(7) = Format(TotalHaber, "#,##0.00")
                    Items(8) = Caja_Id

                    Item = New ListViewItem(Items)
                    ColorAsiento = IIf(ColorAsiento = ColorAsiento2, ColorAsiento1, ColorAsiento2)
                    ListViewCambiaColorFilaTexto(Item, ColorAsiento)
                    If Format(TotalDebe, "#,##0.00") <> Format(TotalHaber, "#,##0.00") Then ListViewCambiaColorFilaTexto(Item, ColorDiferencia)
                    LvwAsientos.Items.Add(Item)

                    TotalDebe = 0
                    TotalHaber = 0
                End If

                TotalDebe = TotalDebe + Fila("Debe")
                TotalHaber = TotalHaber + Fila("Haber")

                Items(0) = Fila("NombreSucursal")
                Items(1) = Fila("NombreCaja")
                Items(2) = Fila("Cierre_Id")
                Items(3) = Fila("FechaCierre")
                Items(4) = Fila("Cuenta")
                Items(5) = Fila("CuentaNombre")
                Items(6) = Format(Fila("Debe"), "#,##0.00")
                Items(7) = Format(Fila("Haber"), "#,##0.00")
                Items(8) = Fila("Caja_Id")

                Item = New ListViewItem(Items)

                Item.SubItems(6).BackColor = Color.AliceBlue
                Item.SubItems(7).BackColor = Color.LavenderBlush

                LvwAsientos.Items.Add(Item)
                ListViewCambiaColorFilaTexto(Item, ColorAsiento)

                If Fila("Cuenta") = "" Then
                    ListViewCambiaColorFilaTexto(Item, ColorSinCuenta)
                End If

                Caja_Id = Fila("Caja_Id") : Cierre_Id = Fila("Cierre_Id")
            Next

            If Not CajaCierreAsiento.Data.Tables(0) Is Nothing AndAlso CajaCierreAsiento.Data.Tables(0).Rows.Count > 0 Then
                Items(0) = ""
                Items(1) = "TOTAL CIERRE"
                Items(2) = Cierre_Id
                Items(3) = StrDup(36, "-")
                Items(4) = StrDup(34, "-")
                Items(5) = StrDup(73, "-") & ">"
                Items(6) = Format(TotalDebe, "#,##0.00")
                Items(7) = Format(TotalHaber, "#,##0.00")
                Items(8) = Caja_Id

                Item = New ListViewItem(Items)
                LvwAsientos.Items.Add(Item)
                ListViewCambiaColorFilaTexto(Item, Color.Blue)
            End If

            BtnImprimir.Enabled = LvwAsientos.Items.Count > 0
            BtnImprimirAsiento.Enabled = LvwAsientos.Items.Count > 0
            BtnDetalleCierre.Enabled = LvwAsientos.Items.Count > 0
            BtnAplicar.Enabled = LvwAsientos.Items.Count > 0

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CajaCierreAsiento = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnAplicar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAplicar.Click
        If ConfirmaAccion("Desea pasar los asientos a Contabilidad") Then
            If VerificaEstadoFinancialWCF() = String.Empty Then
                AplicarConta()
            Else
                MensajeError("Imposible enviar los asiento a contabilidad debido a que no se tiene conexión con el modulo Financiero")
            End If
        End If
    End Sub

    Private Sub AplicarConta()
        Dim AuxAsientoEncabezado As New TAuxAsientoEncabezado

        Try
            PrgProgreso.Visible = True
            Cursor = Cursors.WaitCursor

            AuxAsientoEncabezado.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(AuxAsientoEncabezado.AsientoCierrePasaConta(PrgProgreso))

            If AuxAsientoEncabezado.ErroresPasaConta.Count = 0 Then
                MsgBox("¡El proceso se completo exitosamente!", MsgBoxStyle.Information, Me.Text)
            Else
                MsgBox("¡Se presentaron errores al ejecutar el pase a contabilidad!", MsgBoxStyle.Critical, Me.Text)
                MuestraListaResultados(AuxAsientoEncabezado.ErroresPasaConta)
            End If

            CargaDetalle()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AuxAsientoEncabezado = Nothing
            Cursor = Cursors.Default
            PrgProgreso.Value = 0
            PrgProgreso.Visible = False
        End Try
    End Sub

    Private Sub BtnRefresca_Click(sender As System.Object, e As System.EventArgs) Handles BtnRefresca.Click
        CargaDetalle()
    End Sub

    Private Sub BtnDetalleCierre_Click(sender As System.Object, e As System.EventArgs) Handles BtnDetalleCierre.Click
        MuestraReporteCierre()
    End Sub

    Private Sub MuestraReporteCierre()
        Dim ProformaEncabezado As New TCajaCierreEncabezado(SucursalInfo.Emp_Id)
        Dim Reporte As New RptCierreCaja
        Dim FormaReporte As New FrmReporte

        Try
            If LvwAsientos.SelectedItems Is Nothing OrElse LvwAsientos.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            With ProformaEncabezado
                .Suc_Id = SucursalInfo.Suc_Id
                .Caja_Id = CInt(LvwAsientos.SelectedItems(0).SubItems(8).Text)
                .Cierre_Id = CLng(LvwAsientos.SelectedItems(0).SubItems(2).Text)
            End With
            VerificaMensaje(ProformaEncabezado.RepCierreCaja)

            If ProformaEncabezado.Data.Tables(0).Rows.Count = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(ProformaEncabezado.Data.Tables(0))
            ' Reporte.Subreports(0).SetDataSource(ProformaEncabezado.Data.Tables(1))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            ProformaEncabezado = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnImprimirAsiento_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimirAsiento.Click
        ImprimirAsiento()
    End Sub

    Private Sub BtnRegeneraAsiento_Click(sender As System.Object, e As System.EventArgs) Handles BtnRegeneraAsiento.Click
        Try
            If LvwAsientos.SelectedItems Is Nothing OrElse LvwAsientos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un asiento contable")
            End If

            If ConfirmaAccion("Desea Regenerar el asiento seleccionado") Then
                RegeneraAsiento()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RegeneraAsiento()
        Dim Caja As New TCaja(EmpresaInfo.Emp_Id)
        Dim Caja_Id As Integer
        Dim Cierre_Id As Long

        Try
            If LvwAsientos.SelectedItems Is Nothing OrElse LvwAsientos.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            Caja_Id = CInt(LvwAsientos.SelectedItems(0).SubItems(8).Text)
            Cierre_Id = CLng(LvwAsientos.SelectedItems(0).SubItems(2).Text)

            With Caja
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = Caja_Id
                .Cierre_Id = Cierre_Id
            End With
            VerificaMensaje(Caja.GeneraAsientoCierre())

            MsgBox("¡Proceso exitoso!", MsgBoxStyle.Information)

            CargaDetalle()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

End Class