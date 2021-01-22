Imports Business
Public Class FrmRepListadoPreciosxCategoria
    Dim Numerico() As TNumericFormat
    Private Enum ColumnasCategoriaEnum
        Cat_Id = 0
        Nombre
    End Enum

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            'Numerico(0) = New TNumericFormat(TxtCantidad, 6, 2, False, "", "#,##0.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraDetalle()
        Try

            With LvwCategorias
                .Columns(ColumnasCategoriaEnum.Cat_Id).Text = "Código"
                .Columns(ColumnasCategoriaEnum.Cat_Id).Width = 60
                .Columns(ColumnasCategoriaEnum.Cat_Id).TextAlign = HorizontalAlignment.Left

                .Columns(ColumnasCategoriaEnum.Nombre).Text = "Nombre"
                .Columns(ColumnasCategoriaEnum.Nombre).Width = 190
                .Columns(ColumnasCategoriaEnum.Nombre).TextAlign = HorizontalAlignment.Left
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LlenaCombos()
        Dim Sucursal As New TSucursal(EmpresaInfo.Emp_Id)
        Dim Proveedor As New TProveedor(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Mensaje = Sucursal.LoadComboBox(CmbSucursal)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
            Sucursal = Nothing
        End Try
    End Sub

    Private Sub CargaCategorias()
        Dim Categoria As New TCategoria(EmpresaInfo.Emp_Id)
        Dim Items(1) As String
        Dim Item As ListViewItem = Nothing
        Try

            VerificaMensaje(Categoria.ListaCompleta)

            For Each Cat As DataRow In Categoria.Data.Tables(0).Rows
                Items(ColumnasCategoriaEnum.Cat_Id) = Cat.Item("Cat_Id")
                Items(ColumnasCategoriaEnum.Nombre) = Cat.Item("Nombre")

                Item = New ListViewItem(Items)

                Item.Checked = True

                LvwCategorias.Items.Add(Item)
            Next



        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Categoria = Nothing
        End Try
    End Sub

    Private Sub MuestraReporte()
        Dim Mensaje As String = ""
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Reporte = New RptListaPrecios
        Dim FormaReporte As New FrmReporte
        Dim Precios As String = String.Empty
        Dim Categorias As String = String.Empty
        Try

            Cursor.Current = Cursors.WaitCursor
            With ArticuloBodega
                .Suc_Id = CInt(CmbSucursal.SelectedValue)
                .Bod_Id = CInt(CmbBodega.SelectedValue)
            End With

            For Each Cat As ListViewItem In LvwCategorias.Items
                If ChkTodasLasCategorias.Checked OrElse (Not ChkTodasLasCategorias.Checked And Cat.Checked) Then
                    Categorias = Categorias & IIf(Categorias = String.Empty, String.Empty, "|") & Cat.SubItems(ColumnasCategoriaEnum.Cat_Id).Text
                End If
            Next

            Precios = IIf(ChkPrecioDetalle.Checked, "1", "0") &
                      IIf(ChkPrecioMayoreo.Checked, "1", "0") &
                      IIf(ChkPrecio3.Checked, "1", "0") &
                      IIf(ChkPrecio4.Checked, "1", "0") &
                      IIf(ChkPrecio5.Checked, "1", "0")


            Mensaje = ArticuloBodega.RptListaPrecios(Categorias, Precios)
            VerificaMensaje(Mensaje)

            If ArticuloBodega.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron datos para mostrar el reporte")
            End If

            Reporte.SetDataSource(ArticuloBodega.Data.Tables(0))

            'parametros encabezado y pie de pagina

            Reporte.SetParameterValue("NombreEmpresa", EmpresaInfo.Nombre)
            Reporte.SetParameterValue("PreciosStr", Precios)
            Reporte.SetParameterValue("MuestraSaldo", IIf(ChkMuestraSaldo.Checked, "1", "0"))

            If Form_Abierto("FrmReporte") = False Then
                FormaReporte.Execute(Reporte)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaReporte = Nothing
            ArticuloBodega = Nothing
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

            ConfiguraDetalle()
            CargaCategorias()
            LlenaCombos()
            ChkTodasLasCategorias.Checked = True

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


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

            If Not ChkTodasLasCategorias.Checked AndAlso LvwCategorias.CheckedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar al menos una categoría")
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

    Private Sub ChkTodasLasCategorias_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodasLasCategorias.CheckedChanged
        LvwCategorias.Enabled = Not ChkTodasLasCategorias.Checked
    End Sub
End Class