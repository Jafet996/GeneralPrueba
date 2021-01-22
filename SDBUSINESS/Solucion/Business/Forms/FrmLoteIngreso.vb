Imports System.Drawing
Imports System.Windows.Forms
Imports Business

Public Class FrmLoteIngreso
#Region "Enum"
    Private Enum ColumnasDetalleArticulos
        Art_Id = 0
        Nombre = 1
        Cantidad = 2
        Escaneado = 3
    End Enum

    Private Enum ColumnasDetalleLotes
        Art_Id = 0
        Nombre = 1
        Lote = 2
        Vencimiento = 3
        Cantidad = 4
    End Enum
#End Region
#Region "Variables"
    Private _Lotes As List(Of TArticuloLote)
    Private _ValidaVencimiento As Boolean = True
    Dim Numerico() As TNumericFormat
    Dim _ArtActual_Id As String = String.Empty
#End Region
#Region "Propiedades"
    Public Property Lotes() As List(Of TArticuloLote)
        Get
            Return _Lotes
        End Get
        Set(ByVal value As List(Of TArticuloLote))
            _Lotes = value
        End Set
    End Property
    Public WriteOnly Property ValidaVencimiento
        Set(value)
            _ValidaVencimiento = value
        End Set
    End Property
    Public WriteOnly Property ArtActual_Id As String
        Set(value As String)
            _ArtActual_Id = value
        End Set
    End Property
#End Region

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCantidad, 9, 4, False, "", "###0.0000")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(ByRef pLotes As List(Of TArticuloLote))
        Try
            _Lotes = pLotes
            ConfiguraColumnas()
            CargaArticulos()
            FormateaCamposNumericos()
            inicializa()
            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub inicializa()
        Try
            GrpLoteDetalle.Visible = False
            TxtCantidad.Text = ""
            TxtLote.Text = ""
            TxtVencimiento.Text = ""
            BtnAgregar.Enabled = False
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub ConfiguraColumnas()
        Try
            With LvwArticulos
                .Columns(ColumnasDetalleArticulos.Art_Id).Text = "Artículo"
                .Columns(ColumnasDetalleArticulos.Art_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalleArticulos.Art_Id).Width = 100

                .Columns(ColumnasDetalleArticulos.Nombre).Text = "Descripción"
                .Columns(ColumnasDetalleArticulos.Nombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalleArticulos.Nombre).Width = 400

                .Columns(ColumnasDetalleArticulos.Cantidad).Text = "Cantidad"
                .Columns(ColumnasDetalleArticulos.Cantidad).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalleArticulos.Cantidad).Width = 85

                .Columns(ColumnasDetalleArticulos.Escaneado).Text = "Escaneado"
                .Columns(ColumnasDetalleArticulos.Escaneado).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalleArticulos.Escaneado).Width = 85
            End With

            With LvwLotes
                .Columns(ColumnasDetalleLotes.Art_Id).Text = "Artículo"
                .Columns(ColumnasDetalleLotes.Art_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalleLotes.Art_Id).Width = 0

                .Columns(ColumnasDetalleLotes.Nombre).Text = "Nombre"
                .Columns(ColumnasDetalleLotes.Nombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalleLotes.Nombre).Width = 0

                .Columns(ColumnasDetalleLotes.Lote).Text = "Lote"
                .Columns(ColumnasDetalleLotes.Lote).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalleLotes.Lote).Width = 150

                .Columns(ColumnasDetalleLotes.Vencimiento).Text = "Vence"
                .Columns(ColumnasDetalleLotes.Vencimiento).TextAlign = HorizontalAlignment.Center
                .Columns(ColumnasDetalleLotes.Vencimiento).Width = 100

                .Columns(ColumnasDetalleLotes.Cantidad).Text = "Cantidad "
                .Columns(ColumnasDetalleLotes.Cantidad).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalleLotes.Cantidad).Width = -2
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaArticulos()
        Dim Items(3) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwArticulos.Items.Clear()

            'Carga el array de strings conforme los datos que se enviaron 
            For Each articulo As TArticuloLote In _Lotes

                If _ArtActual_Id <> String.Empty AndAlso _ArtActual_Id <> articulo.Art_Id Then
                    Continue For
                End If

                Items(ColumnasDetalleArticulos.Art_Id) = articulo.Art_Id
                Items(ColumnasDetalleArticulos.Nombre) = articulo.Nombre
                Items(ColumnasDetalleArticulos.Cantidad) = Format(articulo.Cantidad, "##0.0000")
                articulo.CalcularEscaneo()
                Items(ColumnasDetalleArticulos.Escaneado) = Format(articulo.Escaneado, "##0.0000")

                'If articulo.Escaneado > 0 Then
                'Crear el objeto de la lista
                Item = New ListViewItem(Items)


                If articulo.Cantidad = articulo.Escaneado Then
                    ListViewCambiaColorFilaTexto(Item, coColorEscaneoIgual)
                ElseIf articulo.Cantidad < articulo.Escaneado Then
                    ListViewCambiaColorFilaTexto(Item, coColorEscaneoMayor)
                Else
                    ListViewCambiaColorFilaTexto(Item, coColorEscaneoMenor)
                End If


                'Agrega el objeto al ListView
                LvwArticulos.Items.Add(Item)

                'Refresa el ListView
                LvwArticulos.Refresh()
                'End If
            Next

            LvwArticulos.SelectedItems.Clear()

            If LvwArticulos.Items.Count > 0 Then
                LvwArticulos.Items(0).Selected = True
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    'Coloca como selecionado el articulo que le envia por parametro
    'Private Sub CargaArticulos(pArt_Id As String)
    '    Dim Items(3) As String
    '    Dim Item As ListViewItem = Nothing
    '    Dim indice As Integer

    '    Try
    '        LvwArticulos.Items.Clear()

    '        'Carga el array de strings conforme los datos que se enviaron 
    '        For Each articulo As TArticuloLote In Lotes
    '            Items(ColumnasDetalleArticulos.Art_Id) = articulo.Art_Id
    '            Items(ColumnasDetalleArticulos.Nombre) = articulo.Nombre
    '            Items(ColumnasDetalleArticulos.Cantidad) = Format(articulo.Cantidad, "##0.0000")
    '            articulo.CalcularEscaneo()
    '            Items(ColumnasDetalleArticulos.Escaneado) = Format(articulo.Escaneado, "##0.0000")

    '            'Crear el objeto de la lista
    '            Item = New ListViewItem(Items)

    '            'Agrega el objeto al ListView
    '            LvwArticulos.Items.Add(Item)

    '            If articulo.Art_Id = pArt_Id Then
    '                indice = LvwArticulos.Items.Count - 1
    '            End If

    '            'Refresa el ListView
    '            LvwArticulos.Refresh()
    '        Next

    '        LvwArticulos.Items(indice).Selected = True
    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    End Try
    'End Sub

    Private Sub CargaLotesArticulo()
        Dim Items(4) As String
        Dim Item As ListViewItem = Nothing
        Dim Articulo As New TArticuloLote
        Dim Total As Double = 0

        Try
            If LvwArticulos.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            'Limpia el ListView
            LvwLotes.Items.Clear()

            'Busca los lotes del articulo
            For Each elemento As TArticuloLote In Lotes
                If elemento.Art_Id = LvwArticulos.SelectedItems(0).SubItems(ColumnasDetalleArticulos.Art_Id).Text.ToString Then
                    Articulo = elemento
                    Exit For
                End If
            Next

            'Carga el array de strings conforme los datos que se enviaron 
            For Each lote As TLote In Articulo.Lotes
                Items(ColumnasDetalleLotes.Art_Id) = Articulo.Art_Id
                Items(ColumnasDetalleLotes.Nombre) = Articulo.Nombre
                Items(ColumnasDetalleLotes.Cantidad) = Format(lote.Cantidad, "##0.0000")
                Items(ColumnasDetalleLotes.Lote) = lote.Lote
                Items(ColumnasDetalleLotes.Vencimiento) = lote.Vencimiento.ToString("dd/MM/yyyy")

                'Crear el objeto de la lista
                Item = New ListViewItem(Items)
                'Agrega el objeto al ListView
                LvwLotes.Items.Add(Item)

                Total += lote.Cantidad
            Next

            LvwLotes.Refresh()

            TxtCantidadTotal.Text = Format(Total, "##0.0000")
            BtnAgregar.Enabled = True
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub EliminarLote()
        Dim Art_Id As String = ""

        Try
            'Busca los lotes del articulo
            For Each elemento As TArticuloLote In Lotes
                If elemento.Art_Id = LvwLotes.SelectedItems(0).SubItems(ColumnasDetalleLotes.Art_Id).Text.ToString Then

                    Art_Id = elemento.Art_Id

                    For Each lote In elemento.Lotes
                        If lote.Lote = LvwLotes.SelectedItems(0).SubItems(ColumnasDetalleLotes.Lote).Text.ToString Then

                            'Lo remueve de la lista
                            elemento.Lotes.Remove(lote)

                            If elemento.Lotes.Count = 0 Then
                                CargaArticulos()

                                If LvwArticulos.Items.Count = 0 Then
                                    Me.Close()
                                End If

                                Exit Sub
                            End If

                            Exit For

                        End If
                    Next
                End If

            Next

            LvwArticulos.Items.Clear()

            'CargaArticulos(Art_Id)
            CargaArticulos()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub VerificaCantidadLotes()

    End Sub


    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Me.Close()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub LvwArticulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvwArticulos.SelectedIndexChanged
        Try
            If LvwArticulos.SelectedItems.Count > 0 Then
                CargaLotesArticulo()
                inicializaGrpLoteDetalle()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub inicializaGrpLoteDetalle()
        Try
            GrpLoteDetalle.Visible = False
            TxtCantidad.Text = ""
            TxtLote.Text = ""
            TxtVencimiento.Text = ""
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwLotes.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If MsgBox("Desea eliminar el lote?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    EliminarLote()
                End If
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub LvwLotes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvwLotes.SelectedIndexChanged
        CargaDatosLote()
    End Sub

    Private Sub CargaDatosLote()
        Try
            If LvwLotes.SelectedItems.Count = 0 Then
                inicializaGrpLoteDetalle()
                Exit Sub
            End If

            GrpLoteDetalle.Visible = True
            GrpLoteDetalle.Text = LvwLotes.SelectedItems(0).SubItems(ColumnasDetalleLotes.Nombre).Text
            TxtLote.Text = LvwLotes.SelectedItems(0).SubItems(ColumnasDetalleLotes.Lote).Text
            TxtVencimiento.Text = LvwLotes.SelectedItems(0).SubItems(ColumnasDetalleLotes.Vencimiento).Text

            TxtCantidad.Text = LvwLotes.SelectedItems(0).SubItems(ColumnasDetalleLotes.Cantidad).Text
            TxtCantidad.SelectAll()

        Catch ex As Exception

            MensajeError(ex.Message)

        End Try
    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Dim Art_Id As String = ""

        Try
            If ValidaTodo() Then

                For Each elemento In Lotes
                    If elemento.Art_Id = LvwLotes.SelectedItems(0).SubItems(ColumnasDetalleLotes.Art_Id).Text Then

                        Art_Id = elemento.Art_Id

                        For Each Lote In elemento.Lotes
                            If Lote.Lote = TxtLote.Text And Lote.Vencimiento.ToString("dd/MM/yyyy") = TxtVencimiento.Text Then
                                Lote.Cantidad = TxtCantidad.Text
                                elemento.CalcularEscaneo()
                                Exit For

                            End If
                        Next
                    End If
                Next

                MarcaLineasCantidadEscaneado()
                inicializa()
                'CargaArticulos(Art_Id)
                CargaArticulos()

                inicializaGrpLoteDetalle()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If Not IsNumeric(TxtCantidad.Text) OrElse CDbl(TxtCantidad.Text) <= 0 Then
                TxtCantidad.Select()
                VerificaMensaje("La cantidad tiene que se mayor a 0 y no puede esta vacia.")
            End If

            If TxtLote.Text = "" Then
                TxtLote.Select()
                VerificaMensaje("El lote no puede ser vacio.")
            End If

            'If _ValidaVencimiento AndAlso DtpVencimiento.Value.Date < Now.Date Then
            '    DtpVencimiento.Select()
            '    VerificaMensaje("la fecha de vencimiento no puede ser menor a la actual.")
            'End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub MarcaLineasCantidadEscaneado()
        Dim CantidadLinea As Double = 0

        Try
            For Each item As ListViewItem In LvwArticulos.Items
                CantidadLinea = CDbl(item.SubItems(ColumnasDetalleArticulos.Cantidad).Text)

                If CantidadLinea = CDbl(item.SubItems(ColumnasDetalleArticulos.Escaneado).Text) Then
                    ListViewCambiaColorFilaTexto(item, coColorEscaneoIgual)
                ElseIf CantidadLinea < CDbl(item.SubItems(ColumnasDetalleArticulos.Escaneado).Text) Then
                    ListViewCambiaColorFilaTexto(item, coColorEscaneoMayor)
                Else
                    ListViewCambiaColorFilaTexto(item, coColorEscaneoMenor)
                End If
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Dim FrmCreaLote As New FrmCreaLote()
        Dim Lote As TLote
        Dim Art_Id As String = ""

        Try
            If LvwArticulos.SelectedItems Is Nothing OrElse LvwArticulos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un producto")
            End If

            FrmCreaLote.ValidaVencimiento = _ValidaVencimiento
            FrmCreaLote.Execute(LvwArticulos.SelectedItems(0).SubItems(ColumnasDetalleArticulos.Nombre).Text)

            If FrmCreaLote.CerroVentana Then
                Lote = FrmCreaLote.Lote

                For Each elemento In Lotes
                    If elemento.Art_Id = LvwArticulos.SelectedItems(0).SubItems(ColumnasDetalleArticulos.Art_Id).Text Then
                        Art_Id = elemento.Art_Id
                        For Each LoteTemporal In elemento.Lotes
                            If LoteTemporal.Lote = Lote.Lote AndAlso DateValue(LoteTemporal.Vencimiento) = DateValue(Lote.Vencimiento) Then
                                VerificaMensaje("El lote digitado ya fue ingresado anteriormente")
                            End If
                        Next

                        elemento.Lotes.Add(Lote)
                        elemento.CalcularEscaneo()
                        Exit For
                    End If
                Next

                MarcaLineasCantidadEscaneado()
                inicializa()
                CargaArticulos()
                BtnAgregar.Select()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub FrmLoteIngreso_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.F4
                BtnAgregar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        BtnAgregar.PerformClick()
    End Sub

    Private Sub TxtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCantidad.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                If Not IsNumeric(TxtCantidad.Text) Then
                    Exit Sub
                End If

                BtnModificar.PerformClick()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class