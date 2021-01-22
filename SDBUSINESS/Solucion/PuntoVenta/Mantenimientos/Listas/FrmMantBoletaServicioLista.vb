Imports Business
Imports CrystalDecisions.Shared

Public Class FrmMantBoletaServicioLista
#Region "variables"
    Private Numerico() As TNumericFormat
#End Region
    Public Sub Execute()
        Try

            DpDesde.Value = Format(DateAdd(DateInterval.Month, -1, EmpresaInfo.Getdate))
            CargaCombos()
            Refrescar()
            CkbEstado.Checked = True
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtBoleta, 9, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Refrescar()
        Dim BoletaServicio As New TBoletaServicio(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            DGDetalle.DataSource = Nothing

            Mensaje = BoletaServicio.ListaMantenimiento(TxtNombre.Text, CkbEstado.Checked, CmbEstado.SelectedValue, DpDesde.Value, DpHasta.Value, TxtBoleta.Text)
            VerificaMensaje(Mensaje)

            DGDetalle.DataSource = BoletaServicio.Data.Tables(0)

            DGDetalle.Columns(0).HeaderText = "Boleta"
            DGDetalle.Columns(1).HeaderText = "Cliente"
            DGDetalle.Columns(2).HeaderText = "Asunto"
            DGDetalle.Columns(3).HeaderText = "Fecha"
            DGDetalle.Columns(4).HeaderText = "Estado"
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 200
            DGDetalle.Columns(2).Width = 300
            DGDetalle.Columns(3).Width = 75
            DGDetalle.Columns(4).Width = 75
            BtnModificar.Enabled = False
            BtnAsignar.Enabled = False
            BtnCerrar.Enabled = False

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            BoletaServicio = Nothing
        End Try
    End Sub
    Private Sub CargaCombos()
        Dim Estado As New TBoletaServicioEstado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            Mensaje = Estado.LoadComboBox(CmbEstado)
            VerificaMensaje(Mensaje)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Estado = Nothing
        End Try

    End Sub
    'Private Function ValidaTipo()
    '    Try

    '    Catch ex As Exception

    '    End Try
    'End Function

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim Forma As New FrmMantBoletaServicioDetalle
        Dim Mensaje As String = ""
        Try

            'Forma.Titulo = coTitulo
            Forma.Nuevo = True
            Forma.Execute(-1)

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Dim Forma As New FrmMantBoletaServicioDetalle
        Dim Codigo As Integer = -1
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If


            Codigo = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Forma.Nuevo = False
            Forma.Execute(Codigo)

            '_GuardoCambios = Forma.GuardoCambios

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message, "Boleta")
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub BtnAsignar_Click(sender As Object, e As EventArgs) Handles BtnAsignar.Click
        Dim Forma As New FrmMantBoletaServicioDetalle
        Dim Codigo As Integer = -1
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If


            Codigo = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Forma.Asignar = True
            Forma.Execute(Codigo)

            '_GuardoCambios = Forma.GuardoCambios

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message, "Boleta")
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dim Forma As New FrmMantBoletaServicioDetalle
        Dim Codigo As Integer = -1
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If


            Codigo = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Forma.Cerrar = True
            Forma.Execute(Codigo)

            '_GuardoCambios = Forma.GuardoCambios

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message, "Boleta")
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub BtnControl_Click(sender As Object, e As EventArgs) Handles BtnControl.Click
        Dim Forma As New FrmMantBoletaServicioDetalle
        Dim Codigo As Integer = -1
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If


            Codigo = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Forma.PostServicio = True
            Forma.Execute(Codigo)

            '_GuardoCambios = Forma.GuardoCambios

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message, "Boleta")
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CkbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles CkbEstado.CheckedChanged
        If (CkbEstado.Checked) Then
            CmbEstado.Enabled = True
            Refrescar()
        Else
            CmbEstado.Enabled = False
            CmbEstado.SelectedValue = 1
            Refrescar()
        End If
    End Sub
    Private Sub TxtNombre_TextChanged(sender As Object, e As EventArgs) Handles TxtNombre.TextChanged
        Try
            Refrescar()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEstado.SelectedIndexChanged
        Try
            If Not IsNumeric(CmbEstado.SelectedValue) Then
                Exit Sub
            End If

            Refrescar()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub DpDesde_ValueChanged(sender As Object, e As EventArgs) Handles DpDesde.ValueChanged
        Try

            Refrescar()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub DpHasta_ValueChanged(sender As Object, e As EventArgs) Handles DpHasta.ValueChanged
        Try
            Refrescar()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub DGDetalle_SelectionChanged(sender As Object, e As EventArgs) Handles DGDetalle.SelectionChanged
        Try
            If DGDetalle.SelectedCells.Count <> 0 Then
                'N de Fila:
                Dim NFila As Integer = DGDetalle.SelectedCells(0).RowIndex

                'Con el N de Fila, me posiciono y recupero la Columna 'Estado'
                Dim CodArt As String = DGDetalle.Rows(NFila).DataBoundItem("Estado").ToString
                If CodArt = "Pendiente" Then
                    BtnModificar.Enabled = True
                    BtnAsignar.Enabled = True
                    BtnCerrar.Enabled = False
                    BtnControl.Enabled = False
                    BtnImprimir.Enabled = True
                End If
                If CodArt = "Asignado" Then
                    BtnModificar.Enabled = False
                    BtnAsignar.Enabled = True
                    BtnCerrar.Enabled = True
                    BtnControl.Enabled = False
                    BtnImprimir.Enabled = True
                End If
                If CodArt = "Cerrado" Then
                    BtnModificar.Enabled = False
                    BtnAsignar.Enabled = False
                    BtnCerrar.Enabled = False
                    BtnControl.Enabled = True
                    BtnImprimir.Enabled = True
                End If
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub FrmMantBoletaServicioLista_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnNuevo.PerformClick()
            Case Keys.F3
                BtnModificar.PerformClick()
            Case Keys.F4
                BtnAsignar.PerformClick()
            Case Keys.F5
                BtnCerrar.PerformClick()
            Case Keys.F6
                BtnImprimir.PerformClick()
            Case Keys.F7
                BtnControl.PerformClick()
            Case Keys.F8
                btnCliente.PerformClick()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub TxtBoleta_TextChanged(sender As Object, e As EventArgs) Handles TxtBoleta.TextChanged
        Try
            Refrescar()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMantBoletaServicioLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormateaCamposNumericos()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Try
            MuestraReporte()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim Boleta As New TBoletaServicio(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptBoletaServicio
        Dim FormaReporte As New FrmReporte

        'Dim Rpt_AExportar As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        'Dim exportOpts As ExportOptions = New ExportOptions()
        'Dim pdfRtfWordOpts As PdfRtfWordFormatOptions = ExportOptions.CreatePdfRtfWordFormatOptions()
        'Dim destinationOpts As DiskFileDestinationOptions = ExportOptions.CreateDiskFileDestinationOptions()
        'Dim NombreArchivo As String = ""

        Try

            Cursor.Current = Cursors.WaitCursor

            With Boleta
                .Boleta_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            End With

            Mensaje = Boleta.RptBoletaServicio()
            VerificaMensaje(Mensaje)

            If Boleta.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Boleta.Data.Tables(0))

            VerificaMensaje(EmpresaInfo.GetLogoEmpresa)
            Reporte.Subreports(0).SetDataSource(EmpresaInfo.Data.Tables(0))
            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("Cedula", EmpresaInfo.Cedula)
            Reporte.SetParameterValue("Leyenda", EmpresaParametroInfo.LeyendaFactura2)
            Reporte.SetParameterValue("telefono1", EmpresaInfo.Telefono)
            Reporte.SetParameterValue("fax", EmpresaInfo.Fax)
            Reporte.SetParameterValue("direccion", EmpresaInfo.Direccion)
            Reporte.SetParameterValue("DireccionWeb", EmpresaInfo.DireccionWeb)
            Reporte.SetParameterValue("Email", EmpresaInfo.Email)
            If Form_Abierto("FrmReporte") = False Then
                ' NombreArchivo = (DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(1).Value).ToString + "_B#" + (DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value).ToString + ".pdf"
                'Reporte.PrintToPrinter(1, False, 0, 0)
                FormaReporte.Execute(Reporte)


                'Rpt_AExportar = TryCast(Reporte, CrystalDecisions.CrystalReports.Engine.ReportDocument)
                'pdfRtfWordOpts.FirstPageNumber = 0
                'pdfRtfWordOpts.LastPageNumber = 0
                'pdfRtfWordOpts.UsePageRange = False
                'exportOpts.ExportFormatOptions = pdfRtfWordOpts
                'exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
                'destinationOpts.DiskFileName = "C:\SD\" + NombreArchivo
                'exportOpts.ExportDestinationOptions = destinationOpts
                'exportOpts.ExportDestinationType = ExportDestinationType.DiskFile

                'Rpt_AExportar.Export(exportOpts)
                'VerificaMensaje("La boleta se almaceno correctamente")

            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Boleta = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub DGDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDetalle.CellClick
        Try
            If DGDetalle.SelectedCells.Count <> 0 Then
                'N de Fila:
                Dim NFila As Integer = DGDetalle.SelectedCells(0).RowIndex

                'Con el N de Fila, me posiciono y recupero la Columna 'Estado'
                Dim CodArt As String = DGDetalle.Rows(NFila).DataBoundItem("Estado").ToString
                If CodArt = "Pendiente" Then
                    BtnModificar.Enabled = True
                    BtnAsignar.Enabled = True
                    BtnCerrar.Enabled = False
                    BtnControl.Enabled = False
                    BtnImprimir.Enabled = True
                End If
                If CodArt = "Asignado" Then
                    BtnModificar.Enabled = False
                    BtnAsignar.Enabled = True
                    BtnCerrar.Enabled = True
                    BtnControl.Enabled = False
                    BtnImprimir.Enabled = True
                End If
                If CodArt = "Cerrado" Then
                    BtnModificar.Enabled = False
                    BtnAsignar.Enabled = False
                    BtnCerrar.Enabled = False
                    BtnControl.Enabled = True
                    BtnImprimir.Enabled = True
                End If
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Try
            MantCliente()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MantCliente()
        Dim Forma As New FrmMantClienteLista

        Try
            Forma.Execute()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
End Class