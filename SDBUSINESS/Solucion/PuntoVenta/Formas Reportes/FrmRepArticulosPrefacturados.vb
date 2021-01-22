Imports System.IO
Imports Business
Public Class FrmRepArticulosPrefacturados
    Dim Numerico() As TNumericFormat


    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LlenaCombos()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        Dim TipoEntrega As New TProformaTipoEntrega(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Mensaje = Sucursal.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)


            Mensaje = TipoEntrega.LoadComboBox(CmbTipoEntrega)
            VerificaMensaje(Mensaje)

            CmbTipoEntrega.SelectedValue = 1

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Sucursal = Nothing
        End Try
    End Sub

    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim ProformaEncabezado As New TProformaEncabezado(EmpresaInfo.Emp_Id)
        Dim ProformaDetalle As TProformaDetalle
        Dim Reporte As New RptArticulosPrefacturados
        Dim ReporteResumido As New RptArticulosPrefacturadosResumido
        Dim FormaReporte As New FrmReporte
        Dim FechaIni As Date
        Dim FechaFin As Date
        Try

            Cursor.Current = Cursors.WaitCursor



            ProformaEncabezado.ProformaDetalles.Clear()
            For Each item As ListViewItem In LvwDetalle.Items
                If item.ImageIndex <> 1 Then
                    ProformaDetalle = New TProformaDetalle(EmpresaInfo.Emp_Id)

                    With ProformaDetalle
                        .Art_Id = item.SubItems(0).Text
                        .Cantidad = item.SubItems(2).Text
                    End With

                    ProformaEncabezado.ProformaDetalles.Add(ProformaDetalle)
                End If
            Next

            VerificaMensaje(ProformaEncabezado.InsertaPrefacturadoExterno())


            FechaIni = DateValue(DtpFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpFechaFin.Value))


            With ProformaEncabezado
                .Suc_Id = CInt(CmbSucursal.SelectedValue)
                .Bod_Id = CInt(CmbBodega.SelectedValue)
            End With


            If CmbTipo.SelectedIndex = 1 Then
                Mensaje = ProformaEncabezado.RptArticulosPrefacturados(FechaIni, FechaFin, IIf(CkbTipoEntrega.Checked, CmbTipoEntrega.SelectedValue, -1))
            Else
                Mensaje = ProformaEncabezado.RptArticulosPrefacturadosResumido(FechaIni, FechaFin, IIf(CkbTipoEntrega.Checked, CmbTipoEntrega.SelectedValue, -1))
            End If
            VerificaMensaje(Mensaje)

            If ProformaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            If CmbTipo.SelectedIndex = 1 Then
                Reporte.SetDataSource(ProformaEncabezado.Data.Tables(0))
                Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
                Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            Else
                ReporteResumido.SetDataSource(ProformaEncabezado.Data.Tables(0))
                ReporteResumido.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
                ReporteResumido.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)
            End If

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("NombreSucursal", SucursalInfo.Nombre)

            If Form_Abierto("FrmReporte") = False Then
                If CmbTipo.SelectedIndex = 1 Then
                    FormaReporte.Execute(Reporte)
                Else
                    FormaReporte.Execute(ReporteResumido)
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            ProformaEncabezado = Nothing
            ProformaDetalle = Nothing
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

            DtpFechaIni.Value = DateValue(EmpresaInfo.Getdate())
            DtpFechaFin.Value = DateAdd(DateInterval.Day, 1, DtpFechaIni.Value)

            CmbTipo.SelectedIndex = 0

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

        LlenaCombos()

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


            ValidaArticulos()

            If CmbSucursal.SelectedValue Is Nothing OrElse Not IsNumeric(CmbSucursal.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una sucursal")
            End If

            If CmbBodega.SelectedValue Is Nothing OrElse Not IsNumeric(CmbBodega.SelectedValue) Then
                VerificaMensaje("Debe de seleccionar una bodega")
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

    Private Function TxtCantidad() As TextBox
        Throw New NotImplementedException
    End Function

    Private Sub CmbSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedIndexChanged

    End Sub

    Private Sub BtnArchivo_Click(sender As Object, e As EventArgs) Handles BtnArchivo.Click
        Try

            If ConfirmaAccion("Desea genera el archivo de articulos prefacturados") Then
                GeneraArchivo()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub GeneraArchivo()
        Dim Mensaje As String = ""
        Dim ProformaEncabezado As New TProformaEncabezado(EmpresaInfo.Emp_Id)
        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim saveFileDialog1 As New SaveFileDialog()
        Dim Sw As StreamWriter = Nothing
        Try



            Cursor.Current = Cursors.WaitCursor


            FechaIni = DateValue(DtpFechaIni.Value)
            FechaFin = DateAdd(DateInterval.Day, 1, DateValue(DtpFechaFin.Value))


            With ProformaEncabezado
                .Suc_Id = CInt(CmbSucursal.SelectedValue)
                .Bod_Id = CInt(CmbBodega.SelectedValue)
            End With


            Mensaje = ProformaEncabezado.RptArticulosPrefacturadosResumido(FechaIni, FechaFin, IIf(CkbTipoEntrega.Checked, CmbTipoEntrega.ValueMember, -1))
            VerificaMensaje(Mensaje)

            If ProformaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para generar el archivo")
            End If


            saveFileDialog1.Filter = "txt files (*.txt)|*.txt"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True
            saveFileDialog1.FileName = "ArticulosPrefacturados" & Format(Now, "ddMMyyyyHHmmss")

            If saveFileDialog1.ShowDialog() <> DialogResult.OK OrElse saveFileDialog1.FileName = "" Then
                VerificaMensaje("Debe de seleccionar un nombre de archivo")
            End If

            Sw = New StreamWriter(saveFileDialog1.FileName, True)

            For Each fila As DataRow In ProformaEncabezado.Data.Tables(0).Rows
                Sw.WriteLine(String.Concat(fila("Art_Id"), ",", fila("Pedido")))
            Next

            Sw.Close()

            MsgBox("El archivo se generó de manera correcta", MsgBoxStyle.Information, Me.Text)


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ProformaEncabezado = Nothing
            saveFileDialog1 = Nothing
            Sw = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnCargar_Click(sender As Object, e As EventArgs) Handles BtnCargar.Click
        CargaArchivo()
    End Sub

    Private Sub CargaArchivo()
        Dim Items(2) As String
        Dim Item As ListViewItem = Nothing
        Dim Valores() As String
        Dim Resultado As Boolean = True
        Dim OpenF As New OpenFileDialog
        Dim NombreArt As String = String.Empty
        Try
            OpenF.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            OpenF.FilterIndex = 1
            OpenF.RestoreDirectory = True
            OpenF.FileName = String.Empty
            LvwDetalle.BeginUpdate()

            If OpenF.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    Cursor = Cursors.WaitCursor

                    If (OpenF.OpenFile() IsNot Nothing) Then

                        LvwDetalle.Items.Clear()

                        Using sr As StreamReader = New StreamReader(OpenF.FileName)
                            Dim line As String

                            line = sr.ReadLine()
                            While (line <> Nothing)
                                Valores = line.Split(",")





                                Items(0) = Valores(0)
                                Items(1) = ""
                                Items(2) = Valores(1)

                                Item = New ListViewItem(Items)
                                LvwDetalle.Items.Add(Item)
                                LvwDetalle.Refresh()
                                line = sr.ReadLine()
                            End While
                        End Using
                    End If
                Catch Ex As Exception
                    MsgBox("Cannot read file from disk. Original error: " & Ex.Message)
                Finally
                    LvwDetalle.EndUpdate()
                    Cursor = Cursors.Default
                    If (OpenF.OpenFile() IsNot Nothing) Then
                        OpenF.OpenFile().Close()
                    End If
                    OpenF = Nothing
                End Try
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ValidaArticulos()
        Dim Resultado As Boolean = False
        Try

            Cursor = Cursors.WaitCursor

            With PrgCarga
                .Minimum = 0
                .Maximum = LvwDetalle.Items.Count
                .Value = 0
                .Visible = True
            End With


            For Each item As ListViewItem In LvwDetalle.Items
                PrgCarga.Value = PrgCarga.Value + 1
                PrgCarga.Refresh()
                Try
                    item.SubItems(1).Text = ValidaArticulo(item.SubItems(0).Text, Resultado)
                    item.ImageIndex = IIf(Resultado, 0, 1)
                Catch ex As Exception
                    item.ImageIndex = 1
                    item.SubItems(1).Text = ex.Message
                End Try
                If (PrgCarga.Value Mod 5) = 0 Then
                    LvwDetalle.Refresh()
                    item.EnsureVisible()
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            PrgCarga.Visible = False
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function BuscaCodigo(pArt_Id As String) As String
        Dim ArticuloEquivalente As New TArticuloEquivalente(EmpresaInfo.Emp_Id)
        Dim Codigo As String = ""
        Try
            ArticuloEquivalente.ArtEquivalente_Id = pArt_Id
            VerificaMensaje(ArticuloEquivalente.ListKey())

            If ArticuloEquivalente.RowsAffected > 0 Then
                Codigo = ArticuloEquivalente.Art_Id
            Else
                Codigo = pArt_Id
            End If

            Return Codigo
        Catch ex As Exception
            MensajeError(ex.Message)
            Return String.Empty
        End Try
    End Function


    Private Function ValidaArticulo(ByVal pArt_Id As String, ByRef pResultado As Boolean) As String
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Suc_Id As Integer = 0
        Dim Bod_Id As Integer = 0
        Try

            Suc_Id = CInt(CmbSucursal.SelectedValue)
            Bod_Id = CInt(CmbBodega.SelectedValue)


            pArt_Id = BuscaCodigo(pArt_Id)
            Articulo.Art_Id = pArt_Id
            VerificaMensaje(Articulo.ListKey())

            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("El artículo no existe")
            End If

            If Articulo.Servicio Then
                VerificaMensaje("El artículo es un servicio, imposible cargar")
            End If


            If ValidaArticuloBodega(Suc_Id, Bod_Id, pArt_Id) <> String.Empty Then
                VerificaMensaje("El artículo no esta definido en la bodega ")
            End If

            pResultado = True

            Return Articulo.Nombre
        Catch ex As Exception
            pResultado = False
            Return ex.Message
        Finally
            Articulo = Nothing
        End Try
    End Function



    Private Function ValidaArticuloBodega(pSuc_Id As Integer, pBod_Id As Integer, pArt_Id As String) As String
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Try
            With ArticuloBodega
                .Suc_Id = pSuc_Id
                .Bod_Id = pBod_Id
                .Art_Id = pArt_Id
            End With
            VerificaMensaje(ArticuloBodega.ListKey())

            If ArticuloBodega.RowsAffected = 0 Then
                VerificaMensaje("El artículo no existe en la bodega")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ArticuloBodega = Nothing
        End Try
    End Function

    Private Sub CkbTipoEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles CkbTipoEntrega.CheckedChanged
        Try
            CmbTipoEntrega.Enabled = CkbTipoEntrega.Checked
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class