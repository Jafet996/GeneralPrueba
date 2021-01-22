Imports Business
Public Class FrmMantArticuloPromocionDetalle
#Region "Enum"
    Private Enum ColumnaDetalle
        Codigo = 0
        Nombre = 1
        Inicio = 2
        Final = 3
        Promocion = 4
        Promocion_Id = 5
    End Enum
#End Region
#Region "Variables"
    Dim Numerico() As TNumericFormat
#End Region
#Region "Formateo de Campos"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(2)

            Numerico(0) = New TNumericFormat(TxtPrecioConvenio, 12, 2, False, "0.00", "#,##0.00")
            Numerico(1) = New TNumericFormat(TxtPrecioActual, 12, 2, False, "0.00", "#,##0.00")
            Numerico(2) = New TNumericFormat(TxtPorcentajeDescuento, 2, 2, False, "0.00", "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        Try
            FormateaCamposNumericos()
            Inicializa()
            ConfiguraLista()
            CargaLista()
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Inicializa()
        PnlDetalle.Enabled = True
        LvwArticulos.Enabled = False
        InicializaDetalle()
    End Sub

    Private Sub InicializaDetalle()
        TxtArticulo.Text = ""
        TxtArticuloNombre.Text = ""
        TxtPrecioConvenio.Text = ""
        TxtPrecioActual.Text = ""
        TxtPorcentajeDescuento.Text = ""
        DtpFechaInicio.Value = EmpresaInfo.Getdate
        DtpFechaFin.Value = EmpresaInfo.Getdate
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwArticulos
                .Columns(ColumnaDetalle.Codigo).Text = "Código"
                .Columns(ColumnaDetalle.Codigo).Width = 100

                .Columns(ColumnaDetalle.Nombre).Text = "Descripción"
                .Columns(ColumnaDetalle.Nombre).Width = 150

                .Columns(ColumnaDetalle.Inicio).Text = "Inicia"
                .Columns(ColumnaDetalle.Inicio).Width = 122

                .Columns(ColumnaDetalle.Final).Text = "Finaliza"
                .Columns(ColumnaDetalle.Final).Width = 122

                .Columns(ColumnaDetalle.Promocion).Text = "Promoción"
                .Columns(ColumnaDetalle.Promocion).Width = 90

                .Columns(ColumnaDetalle.Promocion_Id).Text = "Id"
                .Columns(ColumnaDetalle.Promocion_Id).Width = 0
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaLista()
        Dim ArticuloPromocion As New TArticuloPromocion(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(5) As String

        Try
            LvwArticulos.Items.Clear()
            VerificaMensaje(ArticuloPromocion.ListBusqueda(TxtCriterio.Text.Trim))

            If ArticuloPromocion.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In ArticuloPromocion.Data.Tables(0).Rows
                Items(ColumnaDetalle.Codigo) = Fila("Art_Id")
                Items(ColumnaDetalle.Nombre) = Fila("Nombre")
                Items(ColumnaDetalle.Inicio) = Fila("FechaInicio")
                Items(ColumnaDetalle.Final) = Fila("FechaFinal")
                Items(ColumnaDetalle.Promocion) = Format(Fila("Precio"), "#,##0.00")
                Items(ColumnaDetalle.Promocion_Id) = Fila("Promocion_Id")
                Item = New ListViewItem(Items)
                LvwArticulos.Items.Add(Item)
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloPromocion = Nothing
            LvwArticulos.Enabled = LvwArticulos.Items.Count > 0
        End Try
    End Sub

    Private Sub BuscarArticulo()
        Dim Forma As New FrmBuscaArticuloOnLine

        Try
            Forma.Execute()

            If Forma.Art_Id.Trim <> "" Then
                TxtArticulo.Text = Forma.Art_Id
                CargarDatosArticulo()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub CargarDatosArticulo()
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)

        Try
            If TxtArticulo.Text.Trim = "" Then
                VerificaMensaje("Debe de seleccionar un artículo")
                TxtArticulo.Focus()
            End If

            Articulo.Art_Id = TxtArticulo.Text.Trim
            VerificaMensaje(Articulo.ListKey)

            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("No se ha encontrado un artículo con este código: " & TxtArticulo.Text.Trim)
                TxtArticulo.Select()
                TxtArticulo.Focus()
            End If

            With ArticuloBodega
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = SucursalParametroInfo.BodCompra_Id
                .Art_Id = Articulo.Art_Id
            End With
            VerificaMensaje(ArticuloBodega.ListKey)

            TxtArticuloNombre.Text = Articulo.Nombre
            TxtPrecioActual.Text = ArticuloBodega.Precio
            TxtPrecioConvenio.Enabled = True
            TxtPorcentajeDescuento.Enabled = True
            TxtPrecioConvenio.Text = TxtPrecioActual.Text.Trim
            TxtPorcentajeDescuento.Text = 0
            TxtPrecioConvenio.Select()
            TxtPrecioConvenio.Focus()
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub

    Private Function CalculaPrecio(Actual As Double, Porcentaje As Double) As Double
        Dim Resultado As Double = 0

        Try
            If Porcentaje >= 0 Then
                If TxtPrecioActual.Text.Trim <> "" AndAlso TxtPrecioActual.Text >= 0 Then
                    Resultado = CDbl(TxtPrecioActual.Text.Trim) - CDbl(TxtPrecioActual.Text * (Porcentaje / 100))
                End If
            End If

            Return Resultado
        Catch ex As Exception
            MensajeError(ex.Message)
            Return Resultado
        End Try
    End Function

    Private Function CalculaPorcentaje(Actual As Double, Convenio As Double) As Double
        Dim Resultado As Double = 0

        Try
            If Convenio >= 0 Then
                If Actual >= 0 Then
                    Resultado = CDbl(CDbl(Actual - Convenio) * 100) / Actual
                End If
            End If

            Return Resultado
        Catch ex As Exception
            MensajeError(ex.Message)
            Return Resultado
        End Try
    End Function

    Private Function ValidaTodo() As Boolean
        Dim ArticuloPromocion As New TArticuloPromocion(EmpresaInfo.Emp_Id)

        Try
            If TxtArticuloNombre.Text.Trim = "" Then
                VerificaMensaje("Debe de seleccionar un artículo.")
                TxtArticulo.Select()
                TxtArticulo.Focus()
            End If

            If TxtPrecioConvenio.Text.Trim = "" OrElse Not IsNumeric(TxtPrecioConvenio.Text.Trim) Then
                VerificaMensaje("El precio debe de ser un valor númerico.")
                TxtPrecioConvenio.Select()
                TxtPrecioConvenio.Focus()
            End If

            If TxtPrecioActual.Text.Trim = "" OrElse Not IsNumeric(TxtPrecioActual.Text.Trim) Then
                VerificaMensaje("El precio debe de ser un valor númerico.")
                TxtPrecioActual.Select()
                TxtPrecioActual.Focus()
            End If

            If CDbl(TxtPrecioActual.Text.Trim) = 0 Then
                VerificaMensaje("No se puede asignar el descuento al artículo " & TxtArticuloNombre.Text.Trim & _
                    " debido a que el precio actual de este es 0.")
            End If

            If CDbl(TxtPrecioConvenio.Text.Trim) = 0 Then
                VerificaMensaje("No se puede asignar el descuento al artículo " & TxtArticuloNombre.Text.Trim & _
                    " debido a que el precio asignado para la promoción es 0.")
            End If

            If DtpFechaInicio.Value >= DtpFechaFin.Value Then
                VerificaMensaje("La fecha de inicio no puede ser superior o igual a la de finalización.")
            End If

            With ArticuloPromocion
                .Art_Id = TxtArticulo.Text.Trim
            End With
            VerificaMensaje(ArticuloPromocion.ListaXArticulo)

            If ArticuloPromocion.RowsAffected > 0 Then
                For Each Fila As DataRow In ArticuloPromocion.Data.Tables(0).Rows
                    If DtpFechaInicio.Value >= CDate(Fila("FechaInicio")) And DtpFechaInicio.Value <= CDate(Fila("FechaFinal")) Then
                        VerificaMensaje("Ya existe una promoción para el articulo seleccionado en el rango de fechas asignado")
                    End If

                    If DtpFechaFin.Value >= CDate(Fila("FechaInicio")) And DtpFechaFin.Value <= CDate(Fila("FechaFinal")) Then
                        VerificaMensaje("Ya existe una promoción para el articulo seleccionado en el rango de fechas asignado")
                    End If

                    If DtpFechaInicio.Value <= CDate(Fila("FechaInicio")) And DtpFechaFin.Value >= CDate(Fila("FechaFinal")) Then
                        VerificaMensaje("Ya existe una promoción para el articulo seleccionado en el rango de fechas asignado")
                    End If
                Next
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Guardar()
        Dim ArticuloPromocion As New TArticuloPromocion(EmpresaInfo.Emp_Id)

        Try
            With ArticuloPromocion
                .Art_Id = TxtArticulo.Text.Trim
                .FechaInicio = DtpFechaInicio.Value
                .FechaFinal = DtpFechaFin.Value
                .Precio = TxtPrecioConvenio.Text.Trim
                .Usuario_Id = UsuarioInfo.Usuario_Id
            End With
            VerificaMensaje(ArticuloPromocion.Siguiente)
            VerificaMensaje(ArticuloPromocion.Insert)

            InicializaDetalle()
            TxtPrecioConvenio.Enabled = False
            TxtPorcentajeDescuento.Enabled = False
            CargaLista()
            Mensaje("La promoción se agregó correctamente")
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloPromocion = Nothing
        End Try
    End Sub

    Private Sub Eliminar()
        Dim Convenio As New TArticuloPromocion(EmpresaInfo.Emp_Id)

        Try
            If LvwArticulos.SelectedItems Is Nothing OrElse LvwArticulos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un detalle de la lista")
            End If

            With Convenio
                .Art_Id = LvwArticulos.SelectedItems(0).SubItems(ColumnaDetalle.Codigo).Text.Trim
                .Promocion_Id = CInt(LvwArticulos.SelectedItems(0).SubItems(ColumnaDetalle.Promocion_Id).Text.Trim)
            End With
            VerificaMensaje(Convenio.Delete())

            CargaLista()
            Mensaje("El articulo se borró correctamente")
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Convenio = Nothing
        End Try
    End Sub

    Private Sub TxtPrecioConvenio_TextChanged(sender As Object, e As EventArgs) Handles TxtPrecioConvenio.TextChanged
        Dim Actual As Double = 0
        Dim Convenio As Double = 0

        Try
            If TxtPrecioActual.Tag <> "" Then
                Exit Sub
            End If

            TxtPrecioActual.Tag = "p"

            If Not IsNumeric(TxtPrecioActual.Text.Trim) Then
                Actual = 0
            Else
                Actual = CDbl(TxtPrecioActual.Text.Trim)
            End If

            If Not IsNumeric(TxtPrecioConvenio.Text.Trim) Then
                Convenio = 0
            Else
                Convenio = CDbl(TxtPrecioConvenio.Text.Trim)
            End If

            TxtPorcentajeDescuento.Text = Format(CalculaPorcentaje(Actual, Convenio), "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtPrecioActual.Tag = ""
        End Try
    End Sub

    Private Sub TxtPorcentajeDescuento_TextChanged(sender As Object, e As EventArgs) Handles TxtPorcentajeDescuento.TextChanged
        Dim Actual As Double = 0
        Dim Porcentaje As Double = 0

        Try
            If TxtPrecioActual.Tag <> "" Then
                Exit Sub
            End If

            TxtPrecioActual.Tag = "m"

            If Not IsNumeric(TxtPrecioActual.Text.Trim) Then
                Actual = 0
            Else
                Actual = CDbl(TxtPrecioActual.Text.Trim)
            End If

            If Not IsNumeric(TxtPorcentajeDescuento.Text.Trim) Then
                Porcentaje = 0
            Else
                Porcentaje = CDbl(TxtPorcentajeDescuento.Text.Trim)
            End If

            TxtPrecioConvenio.Text = Format(CalculaPrecio(Actual, Porcentaje), "##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TxtPrecioActual.Tag = ""
        End Try
    End Sub

    Private Sub BtnConfirmar_Click(sender As Object, e As EventArgs) Handles BtnConfirmar.Click
        If ValidaTodo() Then
            Guardar()
            TxtArticulo.Focus()
        End If
    End Sub

    Private Sub LvwArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwArticulos.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                Eliminar()
        End Select
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        BuscarArticulo()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtArticulo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TxtArticulo.Text.Trim <> "" Then
                    CargarDatosArticulo()
                End If
            Case Keys.Escape
                TxtArticulo.Text = ""
        End Select
    End Sub

    Private Sub TxtArticulo_TextChanged(sender As Object, e As EventArgs) Handles TxtArticulo.TextChanged
        TxtArticuloNombre.Text = ""
    End Sub

    Private Sub FrmMantArticuloPromocionDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BtnBuscar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub FrmMantArticuloPromocionDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtArticulo.Select()
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As Object, e As EventArgs) Handles TxtCriterio.TextChanged
        CargaLista()
        PicBorrar.Visible = TxtCriterio.Text.Trim.Length > 0
    End Sub

    Private Sub PicBorrar_Click(sender As Object, e As EventArgs) Handles PicBorrar.Click
        TxtCriterio.Text = ""
    End Sub

End Class