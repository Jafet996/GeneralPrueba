Imports Business
Public Class FrmGarantiaBusqueda
    Dim Numerico() As TNumericFormat

    Private Enum ColumnasDetalle
        Garantia_Id = 0
        Cliente_Id
        ClienteNombre
        Art_Id
        ArtNombre
        Boleta
        Fecha
        Vencimiento
        Meses
        SaldoDias
        FacturaNumero
        FacturaFecha
        Lote
        LoteVencimiento
    End Enum
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCliente, 6, 0, False, "", "###0")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub ConfiguraDetalle()
        Try
            With LvwDetalle
                .Columns(ColumnasDetalle.Garantia_Id).Text = "Garantía"
                .Columns(ColumnasDetalle.Garantia_Id).Width = 60

                .Columns(ColumnasDetalle.Boleta).Text = "Boleta"
                .Columns(ColumnasDetalle.Boleta).Width = 100

                .Columns(ColumnasDetalle.Fecha).Text = "Fecha"
                .Columns(ColumnasDetalle.Fecha).Width = 80

                .Columns(ColumnasDetalle.Vencimiento).Text = "Vence"
                .Columns(ColumnasDetalle.Vencimiento).Width = 80

                .Columns(ColumnasDetalle.Meses).Text = "Meses"
                .Columns(ColumnasDetalle.Meses).Width = 60

                .Columns(ColumnasDetalle.SaldoDias).Text = "Quedan"
                .Columns(ColumnasDetalle.SaldoDias).Width = 60

                .Columns(ColumnasDetalle.Cliente_Id).Text = "Cliente_Id"
                .Columns(ColumnasDetalle.Cliente_Id).Width = 0

                .Columns(ColumnasDetalle.ClienteNombre).Text = "Cliente"
                .Columns(ColumnasDetalle.ClienteNombre).Width = 250

                .Columns(ColumnasDetalle.Art_Id).Text = "Art_Id"
                .Columns(ColumnasDetalle.Art_Id).Width = 0

                .Columns(ColumnasDetalle.ArtNombre).Text = "Artículo"
                .Columns(ColumnasDetalle.ArtNombre).Width = 250

                .Columns(ColumnasDetalle.FacturaNumero).Text = "Factura"
                .Columns(ColumnasDetalle.FacturaNumero).Width = 60

                .Columns(ColumnasDetalle.FacturaFecha).Text = "Fecha Fact"
                .Columns(ColumnasDetalle.FacturaFecha).Width = 80

                .Columns(ColumnasDetalle.Lote).Text = "Serie"
                .Columns(ColumnasDetalle.Lote).Width = 80

                .Columns(ColumnasDetalle.LoteVencimiento).Text = "Fecha Serie"
                .Columns(ColumnasDetalle.LoteVencimiento).Width = 80
            End With


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub



    Public Sub Execute()
        Try

            ConfiguraDetalle()

            TxtCliente.Select()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmGarantiaBusqueda_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FormateaCamposNumericos()

            Me.Width = Screen.PrimaryScreen.WorkingArea.Size.Width
            Me.Height = Screen.PrimaryScreen.WorkingArea.Size.Height - 50
            Me.CenterToScreen()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Buscar()
    End Sub

    Private Sub Buscar()
        Dim FacturaDetalleGarantia As New TFacturaDetalleGarantia(EmpresaInfo.Emp_Id)
        Dim Art_Id As String = String.Empty
        Dim Serie As String = String.Empty
        Dim Cliente_Id As Integer = 0
        Dim Items(13) As String
        Dim Item As ListViewItem = Nothing
        Try

            If Not ChkArticulo.Checked AndAlso Not ChkSerie.Checked AndAlso Not ChkCliente.Checked Then
                VerificaMensaje("Debe de seleccionar al menos un criterio")
            End If

            If ChkArticulo.Checked Then
                If TxtArticulo.Text.Trim() = String.Empty Then
                    TxtArticulo.Select()
                    VerificaMensaje("Debe de ingresar un valor")
                End If
                VerificaMensaje(ValidaArticulo())

                Art_Id = TxtArticulo.Text.Trim()
            End If

            If ChkCliente.Checked Then
                If Not IsNumeric(TxtCliente.Text) Then
                    TxtCliente.Select()
                    VerificaMensaje("Debe de ingresar un valor")
                End If
                VerificaMensaje(ValidaCliente())

                Cliente_Id = CInt(TxtCliente.Text)
            End If

            If ChkSerie.Checked Then
                If TxtCliente.Text.Trim = String.Empty Then
                    TxtSerie.Select()
                    VerificaMensaje("Debe de ingresar un valor")
                End If
                Serie = QuitaComillas(TxtSerie.Text.Trim)
            End If

            LvwDetalle.Items.Clear()

            VerificaMensaje(FacturaDetalleGarantia.BuscaGarantia(Art_Id, Serie, Cliente_Id))
            If FacturaDetalleGarantia.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron garantías")
            End If

            For Each fila As DataRow In FacturaDetalleGarantia.Data.Tables(0).Rows
                Items(ColumnasDetalle.Garantia_Id) = fila("Garantia_Id")
                Items(ColumnasDetalle.Cliente_Id) = fila("Cliente_Id")
                Items(ColumnasDetalle.ClienteNombre) = fila("ClienteNombre")
                Items(ColumnasDetalle.Art_Id) = fila("Art_Id")
                Items(ColumnasDetalle.ArtNombre) = fila("ArtNombre")
                Items(ColumnasDetalle.Boleta) = fila("OrdenNumero")
                Items(ColumnasDetalle.Fecha) = Format(fila("FechaInicio"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Vencimiento) = Format(fila("FechaFinal"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Meses) = fila("Meses")
                Items(ColumnasDetalle.SaldoDias) = IIf(fila("DiasSaldo") < 0, 0, fila("DiasSaldo")) & " días"
                Items(ColumnasDetalle.FacturaNumero) = fila("Factura")
                Items(ColumnasDetalle.FacturaFecha) = Format(fila("FacturaFecha"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Lote) = fila("Lote").ToString
                Items(ColumnasDetalle.LoteVencimiento) = Format(fila("LoteFechaVencimiento").ToString, "dd/MM/yyyy")


                Item = New ListViewItem(Items)


                LvwDetalle.Items.Add(Item)


            Next

            BtnImprimir.Enabled = FacturaDetalleGarantia.RowsAffected > 0


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaDetalleGarantia = Nothing
        End Try
    End Sub
    Private Sub BusquedaCliente()
        Dim Forma As New FrmBusquedaClienteOnLine
        Try

            Forma.Execute()

            If Forma.Selecciono Then
                TxtCliente.Text = Forma.Cliente_Id

                ValidaCliente()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Function ValidaCliente() As String
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Try

            If Not IsNumeric(TxtCliente.Text) Then
                Exit Function
            End If

            Cliente.Cliente_Id = CInt(TxtCliente.Text)
            VerificaMensaje(Cliente.ListKey())
            If Cliente.RowsAffected = 0 Then
                VerificaMensaje("El código de cliente no es válido")
            End If

            LblCliente.Text = Cliente.Nombre

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cliente = Nothing
        End Try
    End Function
    Private Sub BusquedaArticulo()
        Dim Forma As New FrmBusquedaArticuloOnLine
        Dim Art_Id As String = String.Empty
        Try

            Forma.Execute()

            If Forma.Articulos.Count > 0 Then
                Art_Id = Forma.Articulos(0)
            Else
                Art_Id = Forma.Art_Id
            End If

            If Art_Id.Trim <> String.Empty Then
                TxtArticulo.Text = Art_Id
                ValidaArticulo()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Function ValidaArticulo() As String
        Dim Articulo As New TInfoArticulo(EmpresaInfo.Emp_Id)
        Try


            Articulo.Art_Id = TxtArticulo.Text
            VerificaMensaje(Articulo.ConsultaArticuloSinSaldo())
            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("El código de artículo no es válido")
            End If


            LblArticulo.Text = Articulo.Nombre


            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub TxtArticulo_TextChanged(sender As Object, e As EventArgs) Handles TxtArticulo.TextChanged
        LblArticulo.Text = String.Empty
    End Sub

    Private Sub TxtArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtArticulo.KeyDown
        Dim Mensaje As String = String.Empty
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    BusquedaArticulo()
                Case Keys.Enter
                    If TxtArticulo.Text.Trim() <> String.Empty Then
                        Mensaje = ValidaArticulo()
                        If Mensaje.Trim() = String.Empty Then
                            BtnBuscar.Select()
                        Else
                            TxtArticulo.SelectAll()
                            VerificaMensaje(Mensaje)
                        End If

                    End If
            End Select


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub TxtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCliente.KeyDown
        Dim Mensaje As String = String.Empty
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    BusquedaCliente()
                Case Keys.Enter
                    Mensaje = ValidaCliente()
                    If Mensaje.Trim() = String.Empty Then
                        TxtSerie.Select()
                    Else
                        TxtCliente.SelectAll()
                        VerificaMensaje(Mensaje)
                    End If
            End Select


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCliente.TextChanged
        LblCliente.Text = String.Empty
    End Sub

    Private Sub TxtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSerie.KeyDown
        Try

            Select Case e.KeyCode
                Case Keys.Enter
                    TxtArticulo.Select()
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Try

            If LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar una garantía")
            End If

            Cursor.Current = Cursors.WaitCursor

            ImprimeGarantia(CLng(LvwDetalle.SelectedItems(0).SubItems(ColumnasDetalle.Garantia_Id).Text), True)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class