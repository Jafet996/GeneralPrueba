Imports Business
Public Class FrmRepKardexArticulo


    Dim Numerico() As TNumericFormat


    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            'Numerico(0) = New TNumericFormat(TxtCantidad, 6, 2, False, "", "#,##0.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LlenaCombos()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        ' Dim Usuario As New TUsuario(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Mensaje = Sucursal.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)

            'Mensaje = Usuario.LoadComboBox(CmbUsuarioIni)
            'VerificaMensaje(Mensaje)

            'Mensaje = Usuario.LoadComboBox(CmbUsuarioFin)
            'VerificaMensaje(Mensaje)

            'If Usuario.RowsAffected > 0 Then
            '    CmbUsuarioFin.SelectedIndex = CmbUsuarioIni.Items.Count - 1
            'End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
            '  Usuario = Nothing
        End Try
    End Sub

    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim ArticuloKardex As New TArticuloKardex(EmpresaInfo.Emp_Id)
        Dim Reporte As New ArticuloKardex
        Dim FormaReporte As New FrmReporte
        Try

            Cursor.Current = Cursors.WaitCursor

            With ArticuloKardex
                .Suc_Id = CInt(CmbSucursal.SelectedValue)
                .Bod_Id = CInt(IIf(ChkTodas.Checked, -1, CmbBodega.SelectedValue))
                .Art_Id = TxtArticulo.Text
            End With

            Mensaje = ArticuloKardex.RptArticuloKardex(DtpFechaIni.Value, (DateAdd(DateInterval.Day, 1, DtpFechaFin.Value)))
            VerificaMensaje(Mensaje)

            If ArticuloKardex.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(ArticuloKardex.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("pDesde", DtpFechaIni.Value)
            Reporte.SetParameterValue("pHasta", DtpFechaFin.Value)
            'Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            'Reporte.SetParameterValue("TelefonoSucursal", SucursalInfo.Telefono)

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            ArticuloKardex = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Private Sub Imprimir()
        Try
            If ValidaTodo() Then
                MuestraReporte()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Sub Execute()
        Try

            LlenaCombos()

            DtpFechaIni.Value = EmpresaInfo.Getdate()
            DtpFechaFin.Value = DtpFechaIni.Value

            TxtArticulo.Select()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

        Me.ShowDialog()
    End Sub
    Private Sub FrmRepVentasxCategoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Imprimir()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If CmbSucursal.SelectedValue Is Nothing OrElse Not IsNumeric(CmbSucursal.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una sucursal")
            End If

            If CmbBodega.SelectedValue Is Nothing OrElse Not IsNumeric(CmbBodega.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una bodega")
            End If

            If DtpFechaFin.Value < DtpFechaIni.Value Then
                VerificaMensaje("La fecha inicial no puede ser menor a la fecha final")
            End If

            If Not ValidaArticuloPadre(TxtArticulo.Text) Then
                VerificaMensaje("Debe de ingresar un código de artículo válido")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRepArticulosPromedioVenta_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If Not IsNumeric(CmbSucursal.SelectedValue) Then
                Exit Sub
            End If

            Bodega.Suc_Id = CInt(CmbSucursal.SelectedValue)
            Mensaje = Bodega.LoadComboBox(CmbBodega)
            VerificaMensaje(Mensaje)


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
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

    Private Sub ChkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodas.CheckedChanged
        CmbBodega.Enabled = Not ChkTodas.Checked
    End Sub
End Class