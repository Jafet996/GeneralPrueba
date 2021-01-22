Imports Business
Public Class FrmRepTrasladosXArticulo
    Public Sub Execute()
        Try
            DtpFechaIni.Value = EmpresaInfo.Getdate
            DtpFechaFin.Value = EmpresaInfo.Getdate
            TxtArticulo.Select()
            CargaCombos()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
        Me.Text = "Traslados de inventario"
        Me.ShowDialog()
        TxtArticulo.Focus()
    End Sub

    Private Sub CargaCombos()
        Dim sucursales As New TSucursal(EmpresaInfo.Emp_Id)

        Try

            sucursales.LoadComboBox(CmbSucursales)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Function ValidaTodo() As Boolean
        Try

            If TxtArticuloNombre.Text = "" And TxtArticulo.Text <> "" Then
                VerificaMensaje("Debe de ingresar un código de artículo válido")
                TxtArticulo.Select()
            End If

            If TxtArticulo.Text.Trim <> "" And TxtArticuloNombre.Text <> "" Then
                If Not ValidaArticuloPadre(TxtArticulo.Text) Then
                    VerificaMensaje("Debe de ingresar un código de artículo válido")
                    TxtArticulo.Select()
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
        Dim Traslado As New TTrasladoEncabezado(EmpresaInfo.Emp_Id)
        Dim Reporte As New RptTrasladoXArticulo
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor

            Mensaje = Traslado.RptTrasladoxArticulo(TxtArticulo.Text, DtpFechaIni.Value, DtpFechaFin.Value, IIf(ChkSucusal.Checked, CmbSucursales.SelectedValue, -1))
            VerificaMensaje(Mensaje)

            If Traslado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(Traslado.Data.Tables(0))

            Reporte.SetParameterValue("pEmpresa", EmpresaInfo.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            Traslado = Nothing
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

    Private Sub ChkSucusal_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSucusal.CheckedChanged
        CmbSucursales.Enabled = ChkSucusal.Checked
    End Sub
End Class