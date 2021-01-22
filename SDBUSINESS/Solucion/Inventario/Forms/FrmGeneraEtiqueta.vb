Imports Business

Public Class FrmGeneraEtiqueta
    Public Sub Execute()
        Try
            TxtArticulo.Select()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
        Me.Text = "Genera Etiqueta"
        Me.ShowDialog()
        TxtArticulo.Focus()
    End Sub
    Private Function ValidaTodo() As Boolean
        Try

            If TxtArticulo.Text.Trim <> "" Then
                If Not ValidaArticuloPadre(TxtArticulo.Text) Then
                    VerificaMensaje("Debe de ingresar un código de artículo válido")
                End If
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Reporte As New GeneraEtiqueta
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor

            With Articulo
                .Art_Id = TxtArticulo.Text
            End With

            Mensaje = Articulo.GeneraEtiqueta()
            VerificaMensaje(Mensaje)

            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            If Form_Abierto("FrmReporte") = False Then

                ''FormaReporte.Execute(Reporte)
                'Dim rpt As New ReportDocument()
                'rpt.Load(Application.StartupPath + "/Reports/GeneraEtiqueta.rpt") 'ruta de tu reporte

                Reporte.SetDataSource(Articulo.Data.Tables(0))
                'parametros encabezado y pie de pagina
                Reporte.SetParameterValue("pTelefono", EmpresaInfo.Telefono)
                Reporte.SetParameterValue("pCedulaJuridica", EmpresaInfo.Cedula) 'origen de datos del reporte (dataset, datatable, generic, etc)
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
            Articulo = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ValidaArticuloPadre(pCodigo As String) As Boolean
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Articulo.Art_Id = pCodigo
            Mensaje = Articulo.ListKey()
            VerificaMensaje(Mensaje)

            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("El código de artículo no es válido")
            End If

            TxtArticuloNombre.Text = Articulo.Nombre

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            Articulo = Nothing
        End Try
    End Function
    Private Sub TxtCodigoPadre_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtArticulo.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Dim Forma As New FrmBuscaArticuloOnLine

                Forma.Execute()
                If Forma.Art_Id.Trim <> "" Then
                    TxtArticulo.Text = Forma.Art_Id.Trim
                    If ValidaArticuloPadre(Forma.Art_Id.Trim) Then
                        'TxtCodigoEquivalente.Focus()
                    Else
                        TxtArticulo.SelectAll()
                        TxtArticulo.Focus()
                    End If
                End If
                Forma = Nothing
            Case Keys.Enter
                If TxtArticulo.Text.Trim <> "" Then
                    ValidaArticuloPadre(TxtArticulo.Text.Trim)
                    If ValidaArticuloPadre(TxtArticulo.Text.Trim) Then
                        'TxtCodigoEquivalente.Focus()
                    Else
                        TxtArticulo.SelectAll()
                        TxtArticulo.Focus()
                    End If
                End If
        End Select
    End Sub

    Private Sub TxtCodigoPadre_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtArticulo.TextChanged
        TxtArticuloNombre.Text = ""
    End Sub
    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        If ValidaTodo() Then
            MuestraReporte()
            TxtArticulo.Text = ""
            TxtArticuloNombre.Text = ""
            TxtArticulo.Focus()
        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmGeneraEtiqueta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                If ValidaTodo() = True Then
                    MuestraReporte()
                    TxtArticulo.Text = ""
                    TxtArticuloNombre.Text = ""
                    TxtArticulo.Focus()
                End If
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub


End Class
