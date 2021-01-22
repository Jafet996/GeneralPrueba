Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmMantArticuloCreaMasivo
    Dim Numerico() As TNumericFormat

    Private Enum Columnas
        Art_Id = 0
        Nombre
        TipoProducto
        ExentoIVA
        Costo
        Art_Id_Tipo
        Mensaje
    End Enum



    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtUtilidad, 4, 2, False, "1", "#,##0.00")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraDetalle()
        Try

            With LvwArticulos
                .Columns(Columnas.Art_Id).Text = "Código"
                .Columns(Columnas.Art_Id).Width = 150

                .Columns(Columnas.Nombre).Text = "Descripción"
                .Columns(Columnas.Nombre).Width = 300

                .Columns(Columnas.TipoProducto).Text = "Tipo Producto"
                .Columns(Columnas.TipoProducto).Width = 120
                .Columns(Columnas.TipoProducto).TextAlign = HorizontalAlignment.Center

                .Columns(Columnas.ExentoIVA).Text = "ExentoIVA"
                .Columns(Columnas.ExentoIVA).Width = 70
                .Columns(Columnas.ExentoIVA).TextAlign = HorizontalAlignment.Center

                .Columns(Columnas.Costo).Text = "Costo"
                .Columns(Columnas.Costo).Width = 130
                .Columns(Columnas.Costo).TextAlign = HorizontalAlignment.Right

                .Columns(Columnas.Art_Id_Tipo).Text = "Cod Tipo"
                .Columns(Columnas.Art_Id_Tipo).Width = 150
                .Columns(Columnas.Art_Id_Tipo).TextAlign = HorizontalAlignment.Center

                .Columns(Columnas.Mensaje).Text = "Mensaje"
                .Columns(Columnas.Mensaje).Width = 400

            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Property Articulos As New List(Of TArticuloConteo)

    Private Sub CargaCombos()
        Dim Categoria As New TCategoria(EmpresaInfo.Emp_Id)
        Dim SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)
        Dim Departamento As New TDepartamento(EmpresaInfo.Emp_Id)
        Dim UnidadMedida As New TUnidadMedida(EmpresaInfo.Emp_Id)
        Dim ImpuestoCodigo As New TImpuestoCodigo()
        Dim ImpuestoTarifa As New TImpuestoTarifa()
        Dim Mensaje As String = ""
        Try
            Mensaje = Categoria.LoadComboBox(CmbCategoria)
            VerificaMensaje(Mensaje)

            SubCategoria.Cat_Id = Categoria.Cat_Id
            Mensaje = SubCategoria.LoadComboBox(CmbSubCategoria)
            VerificaMensaje(Mensaje)

            Mensaje = Departamento.LoadComboBox(CmbDepartamento)
            VerificaMensaje(Mensaje)

            Mensaje = UnidadMedida.LoadComboBox(CmbUnidadMedida)
            VerificaMensaje(Mensaje)


            CmbCategoria.SelectedIndex = -1
            CmbSubCategoria.SelectedIndex = -1
            CmbDepartamento.SelectedIndex = -1
            CmbUnidadMedida.SelectedIndex = -1


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Categoria = Nothing
            SubCategoria = Nothing
            Departamento = Nothing
            UnidadMedida = Nothing
            ImpuestoCodigo = Nothing
            ImpuestoTarifa = Nothing
        End Try
    End Sub
    Public Sub Execute()
        Try
            ConfiguraDetalle()
            CargaCombos()
            CargaListaArticulos()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaListaArticulos()
        Dim Item As ListViewItem = Nothing
        Dim Items(6) As String
        Try

            LvwArticulos.Items.Clear()

            For Each Art As TArticuloConteo In Articulos
                Items(Columnas.Art_Id) = Art.Art_Id
                Items(Columnas.Nombre) = Art.Descripcion
                Items(Columnas.TipoProducto) = Enum_TipoProducto.Producto.ToString
                Items(Columnas.ExentoIVA) = IIf(Art.Exento, "SI", "NO")
                Items(Columnas.Costo) = Art.Costo.ToString("#,##0.00000")
                Items(Columnas.Art_Id_Tipo) = Enum_Art_Id_Tipo.NoExiste.ToString()
                Items(Columnas.Mensaje) = String.Empty

                Item = New ListViewItem(Items)
                LvwArticulos.Items.Add(Item)
                Item.Checked = True
                Item.EnsureVisible()
            Next


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCategoria.SelectedIndexChanged
        Dim SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            If CmbCategoria.SelectedValue Is Nothing OrElse CmbCategoria.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            SubCategoria.Cat_Id = CmbCategoria.SelectedValue
            Mensaje = SubCategoria.LoadComboBox(CmbSubCategoria)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            SubCategoria = Nothing
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnCrear_Click(sender As Object, e As EventArgs) Handles BtnCrear.Click
        Dim Validacion As String = String.Empty
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Resultado As String = String.Empty
        Dim Errores As Boolean = False
        Try

            Cursor = Cursors.WaitCursor


            ValidaArticulos()


            For Each item As ListViewItem In LvwArticulos.Items
                If item.Checked Then
                    If item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.NoExiste.ToString() Then
                        With Articulo
                            .Art_Id = item.SubItems(Columnas.Art_Id).Text.Trim
                            .Nombre = item.SubItems(Columnas.Nombre).Text.Trim.ToUpper
                            .Cat_Id = CInt(CmbCategoria.SelectedValue)
                            .SubCat_Id = CInt(CmbSubCategoria.SelectedValue)
                            .Departamento_Id = CInt(CmbDepartamento.SelectedValue)
                            .UnidadMedida_Id = CInt(CmbUnidadMedida.SelectedValue)
                            .ExentoIV = IIf(item.SubItems(Columnas.ExentoIVA).Text.ToUpper() = "SI", True, False)
                            .Servicio = IIf(item.SubItems(Columnas.TipoProducto).Text = Enum_TipoProducto.Servicio.ToString(), True, False)
                            .Costo = CDbl(item.SubItems(Columnas.Costo).Text.Trim)
                            .Margen = CDbl(TxtUtilidad.Text)
                        End With

                        Resultado = Articulo.CreaArticulo()
                        If Resultado = String.Empty Then
                            item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Interno.ToString()
                            item.SubItems(Columnas.Mensaje).Text = item.SubItems(Columnas.Nombre).Text.Trim.ToUpper
                        Else
                            item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Errores.ToString
                            item.SubItems(Columnas.Mensaje).Text = Resultado
                        End If
                        item.ImageIndex = -1
                        item.EnsureVisible()
                        LvwArticulos.Refresh()
                    End If
                End If
            Next

            For Each item As ListViewItem In LvwArticulos.Items
                If item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Interno.ToString Then
                    item.Remove()
                End If
            Next


            Mensaje("Finalizó el proceso de creación de artículos")

            If LvwArticulos.Items.Count = 0 Then
                Me.Close()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ValidaArticulos()
        Dim Validacion As String = String.Empty
        Dim oTipo As Integer = 0
        Dim oArt_Id As String = String.Empty
        Dim oNombre As String = String.Empty
        Dim oServicio As Boolean = False


        If LvwArticulos.CheckedItems.Count = 0 Then
            VerificaMensaje("Debe de seleccionar al menos un producto")
        End If


        If CmbCategoria.SelectedIndex = -1 Then
            CmbCategoria.Select()
            VerificaMensaje("Debe de seleccionar una categoría")
        End If

        If CmbSubCategoria.SelectedIndex = -1 Then
            CmbSubCategoria.Select()
            VerificaMensaje("Debe de seleccionar una sub categoría")
        End If

        If CmbDepartamento.SelectedIndex = -1 Then
            CmbDepartamento.Select()
            VerificaMensaje("Debe de seleccionar un departamento")
        End If

        If CmbUnidadMedida.SelectedIndex = -1 Then
            CmbUnidadMedida.Select()
            VerificaMensaje("Debe de seleccionar un valor")
        End If

        If Not IsNumeric(TxtUtilidad.Text) OrElse CDbl(TxtUtilidad.Text) <= 0 Then
            TxtUtilidad.Select()
            VerificaMensaje("El porcentaje de utilidad debe de ser mayor a cero")
        End If


        For Each item As ListViewItem In LvwArticulos.Items
            Validacion = ValidaCodigoArticulo(0, item.SubItems(Columnas.Art_Id).Text, oTipo, oArt_Id, oNombre, oServicio)

            If Validacion.Trim() <> String.Empty Then
                item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Errores.ToString
                item.SubItems(Columnas.Mensaje).Text = Validacion
                ListViewCambiaColorFilaTexto(item, Color.Red)
            Else
                Select Case oTipo
                    Case Enum_Art_Id_Tipo.NoExiste
                        item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.NoExiste.ToString()
                        item.ImageIndex = 0
                    Case Enum_Art_Id_Tipo.Interno
                        item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Interno.ToString()
                        ListViewCambiaColorFilaTexto(item, Color.DarkBlue)
                        item.ImageIndex = 1
                    Case Enum_Art_Id_Tipo.Equivalente
                        item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.Equivalente.ToString()
                        ListViewCambiaColorFilaTexto(item, Color.DarkGreen)
                        item.ImageIndex = 1
                    Case Enum_Art_Id_Tipo.EquivalenteProveedor
                        item.SubItems(Columnas.Art_Id_Tipo).Text = Enum_Art_Id_Tipo.EquivalenteProveedor.ToString()
                        ListViewCambiaColorFilaTexto(item, Color.DarkOrange)
                        item.ImageIndex = 1
                End Select
                item.SubItems(Columnas.Mensaje).Text = oNombre
            End If
            item.EnsureVisible()
            LvwArticulos.Refresh()
        Next
    End Sub

    Private Sub FrmMantArticuloCreaMasivo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FormateaCamposNumericos()

            Me.Width = Screen.PrimaryScreen.WorkingArea.Size.Width
            Me.Height = Screen.PrimaryScreen.WorkingArea.Size.Height - 50
            Me.CenterToScreen()

            TxtUtilidad.Text = "0.00"

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CMSDetalle_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMSDetalle.Opening
        Dim Item As ListViewItem = Nothing
        Try

            If LvwArticulos.SelectedItems Is Nothing OrElse LvwArticulos.SelectedItems.Count = 0 Then
                MnuProductoServicio.Visible = False
                Exit Sub
            Else
                MnuProductoServicio.Visible = True
            End If

            Item = LvwArticulos.SelectedItems(0)

            If Item.SubItems(Columnas.TipoProducto).Text = Enum_TipoProducto.Producto.ToString Then
                MnuProductoServicio.Text = Enum_TipoProducto.Servicio.ToString()
            Else
                MnuProductoServicio.Text = Enum_TipoProducto.Producto.ToString()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MnuProductoServicio_Click(sender As Object, e As EventArgs) Handles MnuProductoServicio.Click
        Dim Item As ListViewItem = Nothing
        Try

            If Not LvwArticulos.SelectedItems Is Nothing AndAlso LvwArticulos.SelectedItems.Count > 0 Then
                Item = LvwArticulos.SelectedItems(0)
            Else
                Exit Sub
            End If

            If Item.SubItems(Columnas.TipoProducto).Text = Enum_TipoProducto.Producto.ToString() Then
                Item.SubItems(Columnas.TipoProducto).Text = Enum_TipoProducto.Servicio.ToString()
            Else
                Item.SubItems(Columnas.TipoProducto).Text = Enum_TipoProducto.Producto.ToString()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MnuMarcarTodos_Click(sender As Object, e As EventArgs) Handles MnuMarcarTodos.Click
        ListViewMarcaDesmarca(LvwArticulos, True)
    End Sub

    Private Sub MnuDesmarcharTodos_Click(sender As Object, e As EventArgs) Handles MnuDesmarcharTodos.Click
        ListViewMarcaDesmarca(LvwArticulos, False)
    End Sub
End Class