Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmLoteSeleccion
#Region "Definition of Enums"
    Private Enum ColArticulos
        Art_Id = 0
        Nombre = 1
        Saldo = 2
        Cantidad = 3
        Escaneado = 4
        Faltan = 5
    End Enum
    Private Enum ColLotesInventario
        Lote = 0
        Vencimiento = 1
        Saldo = 2
        Cantidad = 3
        Art_Id = 4
        Disponible = 5
    End Enum
    Private Enum ColLotesFactura
        Lote = 0
        Vencimiento = 1
        Cantidad = 2
        Art_Id = 3
    End Enum
#End Region
#Region "Definition of Fields"
    Private _Lotes As List(Of TArticuloLote)
    Private _LotesRegistrados As List(Of TArticuloLote)
    Dim Numerico() As TNumericFormat
    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Bod_Id As Integer
    Private _Guardo As Boolean = False
    Private _ReadOnly As Boolean = False
#End Region
#Region "Definition of Properties"
    Public Property Emp_Id As Integer
        Get
            Return _Emp_Id
        End Get
        Set(value As Integer)
            _Emp_Id = value
        End Set
    End Property
    Public Property Suc_Id As Integer
        Get
            Return _Suc_Id
        End Get
        Set(value As Integer)
            _Suc_Id = value
        End Set
    End Property
    Public Property Bod_Id As Integer
        Get
            Return _Bod_Id
        End Get
        Set(value As Integer)
            _Bod_Id = value
        End Set
    End Property
    Public ReadOnly Property Guardo As Boolean
        Get
            Return _Guardo
        End Get
    End Property
    Public Property Lotes() As List(Of TArticuloLote)
        Get
            Return _Lotes
        End Get
        Set(ByVal value As List(Of TArticuloLote))
            _Lotes = value
        End Set
    End Property
    Public WriteOnly Property ReadLonly As Boolean
        Set(value As Boolean)
            _ReadOnly = value
        End Set
    End Property
#End Region

    Private Sub ConfiguraColumnas()
        Try
            With LvwArticulos
                .Columns(ColArticulos.Art_Id).Text = "Artículo"
                .Columns(ColArticulos.Art_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColArticulos.Art_Id).Width = 100

                .Columns(ColArticulos.Nombre).Text = "Descripción"
                .Columns(ColArticulos.Nombre).TextAlign = HorizontalAlignment.Left
                .Columns(ColArticulos.Nombre).Width = 400

                .Columns(ColArticulos.Saldo).Text = "Saldo"
                .Columns(ColArticulos.Saldo).TextAlign = HorizontalAlignment.Left
                .Columns(ColArticulos.Saldo).Width = 85


                .Columns(ColArticulos.Cantidad).Text = "Cantidad"
                .Columns(ColArticulos.Cantidad).TextAlign = HorizontalAlignment.Right
                .Columns(ColArticulos.Cantidad).Width = 85

                .Columns(ColArticulos.Escaneado).Text = "Lotes"
                .Columns(ColArticulos.Escaneado).TextAlign = HorizontalAlignment.Right
                .Columns(ColArticulos.Escaneado).Width = 75

                .Columns(ColArticulos.Faltan).Text = "Faltan"
                .Columns(ColArticulos.Faltan).TextAlign = HorizontalAlignment.Right
                .Columns(ColArticulos.Faltan).Width = 75

            End With

            With LvwLotesInventario
                .Columns(ColLotesInventario.Lote).Text = "Lote"
                .Columns(ColLotesInventario.Lote).TextAlign = HorizontalAlignment.Left
                .Columns(ColLotesInventario.Lote).Width = 120

                .Columns(ColLotesInventario.Vencimiento).Text = "Vencimiento"
                .Columns(ColLotesInventario.Vencimiento).TextAlign = HorizontalAlignment.Left
                .Columns(ColLotesInventario.Vencimiento).Width = 80

                .Columns(ColLotesInventario.Saldo).Text = "Saldo"
                .Columns(ColLotesInventario.Saldo).TextAlign = HorizontalAlignment.Right
                .Columns(ColLotesInventario.Saldo).Width = 75

                .Columns(ColLotesInventario.Cantidad).Text = "Cantidad"
                .Columns(ColLotesInventario.Cantidad).TextAlign = HorizontalAlignment.Right
                .Columns(ColLotesInventario.Cantidad).Width = 75

                .Columns(ColLotesInventario.Art_Id).Text = ""
                .Columns(ColLotesInventario.Art_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColLotesInventario.Art_Id).Width = 0

                .Columns(ColLotesInventario.Disponible).Text = "Disponible"
                .Columns(ColLotesInventario.Disponible).TextAlign = HorizontalAlignment.Right
                .Columns(ColLotesInventario.Disponible).Width = 75
            End With

            With LvwLotesFactura
                .Columns(ColLotesFactura.Lote).Text = "Lote"
                .Columns(ColLotesFactura.Lote).TextAlign = HorizontalAlignment.Left
                .Columns(ColLotesFactura.Lote).Width = 135

                .Columns(ColLotesFactura.Vencimiento).Text = "Vencimiento"
                .Columns(ColLotesFactura.Vencimiento).TextAlign = HorizontalAlignment.Left
                .Columns(ColLotesFactura.Vencimiento).Width = 70

                .Columns(ColLotesFactura.Cantidad).Text = "Cantidad"
                .Columns(ColLotesFactura.Cantidad).TextAlign = HorizontalAlignment.Right
                .Columns(ColLotesFactura.Cantidad).Width = 85

                .Columns(ColLotesFactura.Art_Id).Text = ""
                .Columns(ColLotesFactura.Art_Id).TextAlign = HorizontalAlignment.Center
                .Columns(ColLotesFactura.Art_Id).Width = 0
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaArticulos()
        Dim Items(5) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwArticulos.Items.Clear()

            'Carga el array de strings conforme los datos que se enviaron 
            For Each articulo As TArticuloLote In _Lotes
                Items(ColArticulos.Art_Id) = articulo.Art_Id
                Items(ColArticulos.Nombre) = articulo.Nombre
                Items(ColArticulos.Cantidad) = Format(articulo.Cantidad, "##0.00")
                articulo.CalcularEscaneo()
                Items(ColArticulos.Escaneado) = Format(articulo.Escaneado, "##0.00")
                Items(ColArticulos.Faltan) = Format(articulo.Cantidad - articulo.Escaneado, "##0.00")

                'Crear el objeto de la lista
                Item = New ListViewItem(Items)

                Item.UseItemStyleForSubItems = False
                ListViewCambiaCeldaBackForeColor(Item, Color.White, Color.DarkBlue, ColArticulos.Saldo)
                Item.SubItems(ColArticulos.Saldo).Font = New Font(LvwArticulos.Font, FontStyle.Bold)

                CambiaColorCantidadFaltante(CDbl(Items(ColArticulos.Faltan)), Item)

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

    Private Sub CambiaColorCantidadFaltante(pFaltante As Double, ByRef pItem As ListViewItem)
        Try

            If pFaltante = 0 Then
                ListViewCambiaCeldaBackForeColor(pItem, Color.White, Color.DarkBlue, ColArticulos.Faltan)
            ElseIf pFaltante > 0 Then
                ListViewCambiaCeldaBackForeColor(pItem, Color.White, Color.DarkGreen, ColArticulos.Faltan)
            Else
                ListViewCambiaCeldaBackForeColor(pItem, Color.White, Color.Red, ColArticulos.Faltan)
            End If
            pItem.SubItems(ColArticulos.Faltan).Font = New Font(LvwArticulos.Font, FontStyle.Bold)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaLotesInventario(pArt_Id As String, pTabla As DataTable)
        Dim Items(5) As String
        Dim Item As ListViewItem = Nothing
        Dim Lote_Id As Integer = 0
        Try
            LvwLotesInventario.Items.Clear()

            'Carga el array de strings conforme los datos que se enviaron 
            For Each Fila As DataRow In pTabla.Rows
                Lote_Id += 1

                Items(ColLotesInventario.Lote) = Fila("Lote")
                Items(ColLotesInventario.Vencimiento) = Format(Fila("Vencimiento"), "dd/MM/yyyy")
                Items(ColLotesInventario.Saldo) = Format(Fila("Saldo"), "##0.00")
                Items(ColLotesInventario.Cantidad) = Format(CantidadLotesRegistradosXArt(pArt_Id, Fila("Lote"), Fila("Vencimiento")), "##0.00")
                Items(ColLotesInventario.Art_Id) = pArt_Id
                Items(ColLotesInventario.Disponible) = Format(CDbl(Items(ColLotesInventario.Saldo)) - CDbl(Items(ColLotesInventario.Cantidad)), "##0.00")

                Item = New ListViewItem(Items)
                LvwLotesInventario.Items.Add(Item)
                If Lote_Id = 1 Then
                    'ListViewCambiaFilaBackForeColor(Item, Color.Teal, Color.White)
                    Item.Font = New Font(LvwLotesInventario.Font, FontStyle.Bold)

                End If
                LvwLotesInventario.Refresh()
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaLotesFactura(pArt_Id As String)
        Dim Items(3) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwLotesFactura.Items.Clear()

            'Carga el array de strings conforme los datos que se enviaron 
            For Each Articulo As TArticuloLote In _Lotes
                If Articulo.Art_Id = pArt_Id Then
                    For Each Lote As TLote In Articulo.Lotes
                        Items(ColLotesFactura.Lote) = Lote.Lote
                        Items(ColLotesFactura.Vencimiento) = Format(Lote.Vencimiento, "dd/MM/yyyy")
                        Items(ColLotesFactura.Cantidad) = Format(Lote.Cantidad, "##0.00")
                        Items(ColLotesFactura.Art_Id) = Articulo.Art_Id

                        Item = New ListViewItem(Items)
                        LvwLotesFactura.Items.Add(Item)
                        LvwLotesFactura.Refresh()
                    Next
                End If
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub IngresaLote(pArt_Id As String, pCantidad As Double, pLote As String, pVencimiento As Date)
        Dim EncontroArticulo As Boolean = False
        Dim EncontroLote As Boolean = False
        Dim TmpLote As TLote
        Dim TmpArticulo As TArticuloLote

        Try
            For Each ArticuloLote As TArticuloLote In _Lotes
                EncontroArticulo = False
                EncontroLote = False

                If ArticuloLote.Art_Id = pArt_Id Then
                    EncontroArticulo = True

                    For Each Lote As TLote In ArticuloLote.Lotes
                        If Lote.Lote = pLote AndAlso DateValue(Lote.Vencimiento) = DateValue(pVencimiento) Then
                            EncontroLote = True
                            Lote.Cantidad = Lote.Cantidad + pCantidad
                            Exit For
                        End If
                    Next

                    If Not EncontroLote Then
                        TmpLote = New TLote

                        With TmpLote
                            .Lote = pLote
                            .Vencimiento = pVencimiento
                            .Cantidad = pCantidad
                        End With

                        ArticuloLote.Lotes.Add(TmpLote)
                    End If

                    Exit For
                End If
            Next

            If Not EncontroArticulo And Not EncontroLote Then
                TmpLote = New TLote

                With TmpLote
                    .Lote = pLote
                    .Vencimiento = pVencimiento
                    .Cantidad = pCantidad
                End With

                TmpArticulo = New TArticuloLote

                With TmpArticulo
                    .Art_Id = pArt_Id
                    .Nombre = String.Empty
                    .Cantidad = 0
                    If pCantidad > 0 Then .Lotes.Add(TmpLote)
                End With

                _Lotes.Add(TmpArticulo)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function CantidadLotesRegistradosXArt(pArt_Id As String, pLote As String, pVencimiento As Date) As Double
        Dim Cantidad As Double = 0

        Try
            For Each Articulo As TArticuloLote In _Lotes
                If Articulo.Art_Id = pArt_Id Then
                    For Each Lote As TLote In Articulo.Lotes
                        If Lote.Lote = pLote And Lote.Vencimiento.ToString("dd/MM/yyyy") = pVencimiento.ToString("dd/MM/yyyy") Then
                            Cantidad += Lote.Cantidad
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            Cantidad = -1
        End Try

        Return Cantidad
    End Function
    Private Function CantidadLotesXArticulo(pArt_Id As String) As Double
        Dim Cantidad As Double = 0

        Try
            For Each Articulo As TArticuloLote In _Lotes
                If Articulo.Art_Id = pArt_Id Then
                    For Each Lote As TLote In Articulo.Lotes
                        Cantidad += Lote.Cantidad
                    Next
                End If
            Next
        Catch ex As Exception
            Cantidad = -1
        End Try

        Return Cantidad
    End Function
    Private Sub SolicitaCantidad()
        Dim Forma As New FrmIngresaMonto
        Dim CantidadArticulo As Double = 0
        Dim CantidadLote As Double = 0
        Dim CantidadIngresada As Double = 0
        Dim CantidadIngresadaXLote As Double = 0
        Dim SaldoDisponible As Double = 0
        Dim Day As Integer = 0
        Dim Month As Integer = 0
        Dim Year As Integer = 0

        Try

            If _ReadOnly Then
                VerificaMensaje("No se permite modificar la información de lotes ")
            End If

            If LvwArticulos.SelectedItems Is Nothing OrElse LvwArticulos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un artículo de la lista")
            End If

            If LvwLotesInventario.SelectedItems Is Nothing OrElse LvwLotesInventario.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un lote de la lista")
            End If

            CantidadArticulo = CDbl(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Cantidad).Text)
            CantidadLote = CDbl(LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Saldo).Text)
            CantidadIngresada = CantidadLotesXArticulo(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Art_Id).Text)
            CantidadIngresadaXLote = CDbl(LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Cantidad).Text)
            SaldoDisponible = CantidadLote - CantidadIngresadaXLote

            If SaldoDisponible <= 0 Then VerificaMensaje("El lote seleccionado ha superado el saldo disponible")
            If CantidadArticulo = CantidadIngresada Then VerificaMensaje("Ya se ha completado la verificación de lotes para el artículo seleccionado")

            With Forma
                .Titulo = "Cantidad a ingresar del lote " & LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Lote).Text
                .Descripcion = "Cantidad"
                .PermiteDecimales = True
                .CantidadEnteros = 13
                .CantidadDecimales = 2

                ' Calcula un sugerido para completar la cantidad deseada
                If CantidadArticulo > SaldoDisponible + CantidadIngresada Then
                    .Monto = SaldoDisponible
                ElseIf SaldoDisponible > CantidadArticulo Then
                    .Monto = CantidadArticulo - CantidadIngresada
                Else
                    .Monto = CantidadArticulo - CantidadIngresada
                End If

                .ValorMaximo = .Monto
                .Execute()
            End With

            Day = CInt(LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Vencimiento).Text.Substring(0, 2))
            Month = CInt(LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Vencimiento).Text.Substring(3, 2))
            Year = CInt(LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Vencimiento).Text.Substring(6, 4))

            If Forma.Acepto Then
                IngresaLote(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Art_Id).Text, Forma.Monto, LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Lote).Text, New Date(Year, Month, Day))
                CargaLotesFactura(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Art_Id).Text)

                LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Cantidad).Text = Format(CDbl(LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Cantidad).Text) + Forma.Monto, "##0.00")

                LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Disponible).Text = Format(CDbl(LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Saldo).Text) - CDbl(LvwLotesInventario.SelectedItems(0).SubItems(ColLotesInventario.Cantidad).Text), "##0.00")

                LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Escaneado).Text = Format(CDbl(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Escaneado).Text) + Forma.Monto, "##0.00")
                LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Faltan).Text = Format(CDbl(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Cantidad).Text) - CDbl(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Escaneado).Text), "##0.00")

                CambiaColorCantidadFaltante(CDbl(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Faltan).Text), LvwArticulos.SelectedItems(0))

            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub EliminaLote()
        Dim LoteInventario As Integer = -1
        Dim Day As Integer = 0
        Dim Month As Integer = 0
        Dim Year As Integer = 0
        Try

            If _ReadOnly Then
                VerificaMensaje("No se permite modificar la información de lotes ")
            End If

            If LvwArticulos.SelectedItems Is Nothing OrElse LvwArticulos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un artículo de la lista")
            End If

            If LvwLotesFactura.SelectedItems Is Nothing OrElse LvwLotesFactura.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un lote registrado de la lista")
            End If

            If MsgBox("Seguro(a) que desea eliminar el lote seleccionado (" & LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Lote).Text & ") para el artículo " & LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Nombre).Text, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            For Each Item As ListViewItem In LvwLotesInventario.Items
                If Item.SubItems(ColLotesInventario.Art_Id).Text = LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Art_Id).Text And Item.SubItems(ColLotesInventario.Lote).Text = LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Lote).Text And Item.SubItems(ColLotesInventario.Vencimiento).Text = LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Vencimiento).Text Then
                    LoteInventario = Item.Index
                    Exit For
                End If
            Next

            LvwLotesInventario.Items(LoteInventario).SubItems(ColLotesInventario.Cantidad).Text = Format(CDbl(LvwLotesInventario.Items(LoteInventario).SubItems(ColLotesInventario.Cantidad).Text) - CDbl(LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Cantidad).Text), "##0.00")

            LvwLotesInventario.Items(LoteInventario).SubItems(ColLotesInventario.Disponible).Text = Format(CDbl(LvwLotesInventario.Items(LoteInventario).SubItems(ColLotesInventario.Saldo).Text) - CDbl(LvwLotesInventario.Items(LoteInventario).SubItems(ColLotesInventario.Cantidad).Text), "##0.00")


            LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Escaneado).Text = Format(CDbl(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Escaneado).Text) - CDbl(LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Cantidad).Text), "##0.00")
            LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Faltan).Text = Format(CDbl(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Cantidad).Text) - CDbl(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Escaneado).Text), "##0.00")
            CambiaColorCantidadFaltante(CDbl(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Faltan).Text), LvwArticulos.SelectedItems(0))

            Day = CInt(LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Vencimiento).Text.Substring(0, 2))
            Month = CInt(LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Vencimiento).Text.Substring(3, 2))
            Year = CInt(LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Vencimiento).Text.Substring(6, 4))

            For Each Articulo As TArticuloLote In _Lotes
                If Articulo.Art_Id = LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Art_Id).Text Then
                    For Each Lote As TLote In Articulo.Lotes
                        If Lote.Lote = LvwLotesFactura.SelectedItems(0).SubItems(ColLotesFactura.Lote).Text And Lote.Vencimiento = New Date(Year, Month, Day) Then
                            Articulo.Lotes.Remove(Lote)
                            Exit For
                        End If
                    Next
                End If
            Next

            LvwLotesFactura.Items.Remove(LvwLotesFactura.SelectedItems(0))
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try
            ConfiguraColumnas()
            CargaArticulos()
            LvwArticulos.Select()
            ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(pLotes As List(Of TArticuloLote))
        Dim ArticuloLoteTemp As TArticuloLote = Nothing
        Dim LoteTemp As TLote = Nothing

        Try
            _LotesRegistrados = New List(Of TArticuloLote)

            For Each ArticuloLote As TArticuloLote In pLotes
                ArticuloLoteTemp = New TArticuloLote

                With ArticuloLoteTemp
                    .Art_Id = ArticuloLote.Art_Id
                    .Nombre = ArticuloLote.Nombre
                    .Cantidad = ArticuloLote.Cantidad
                    .Escaneado = ArticuloLote.Escaneado
                End With

                For Each Lote As TLote In ArticuloLote.Lotes
                    LoteTemp = New TLote

                    With LoteTemp
                        .Lote = Lote.Lote
                        .Vencimiento = Lote.Vencimiento
                        .Cantidad = Lote.Cantidad
                    End With

                    ArticuloLoteTemp.Lotes.Add(LoteTemp)
                Next

                _LotesRegistrados.Add(ArticuloLoteTemp)
            Next

            ConfiguraColumnas()
            CargaArticulos()
            LvwArticulos.Select()
            ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function CreaTablaLotes(pArt_Id As String) As DataTable
        Dim Table As New DataTable("Lote")
        Dim Row As DataRow = Nothing

        Try
            Table.Columns.Add("Lote", GetType(String))
            Table.Columns.Add("Vencimiento", GetType(Date))
            Table.Columns.Add("Saldo", GetType(Double))

            For Each ArticuloLote As TArticuloLote In _LotesRegistrados
                If ArticuloLote.Art_Id = pArt_Id Then
                    For Each Lote As TLote In ArticuloLote.Lotes
                        Row = Table.NewRow

                        Row("Lote") = Lote.Lote
                        Row("Vencimiento") = Lote.Vencimiento
                        Row("Saldo") = Lote.Cantidad

                        Table.Rows.Add(Row)
                    Next
                End If
            Next

            Return Table
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub LvwArticulos_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles LvwArticulos.ItemSelectionChanged
        Dim ArticuloBodegaLote As New TArticuloBodegaLote(EmpresaInfo.Emp_Id)
        Dim Table As DataTable = Nothing

        Try
            LvwLotesInventario.Items.Clear()
            LvwLotesFactura.Items.Clear()

            If LvwArticulos.SelectedItems Is Nothing OrElse LvwArticulos.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Saldo).Text = "0.00"

            If _LotesRegistrados Is Nothing Then
                With ArticuloBodegaLote
                    .Emp_Id = _Emp_Id
                    .Suc_Id = _Suc_Id
                    .Bod_Id = _Bod_Id
                    .Art_Id = LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Art_Id).Text
                End With
                VerificaMensaje(ArticuloBodegaLote.ConsultaExistenciaLote())

                Table = ArticuloBodegaLote.Data.Tables(0)

                If Not Table Is Nothing AndAlso Table.Rows.Count > 0 Then
                    LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Saldo).Text = CDbl(Table.Rows(0).Item("Existencia")).ToString("##0.00")
                End If
            Else
                Table = CreaTablaLotes(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Art_Id).Text)
            End If

            CargaLotesFactura(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Art_Id).Text)
            CargaLotesInventario(LvwArticulos.SelectedItems(0).SubItems(ColArticulos.Art_Id).Text, Table)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodegaLote = Nothing
        End Try
    End Sub

    Private Sub LvwLotesInventario_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LvwLotesInventario.MouseDoubleClick
        SolicitaCantidad()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Me.Close()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmLoteSeleccion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.F3
                    BtnAceptar.PerformClick()
                Case Keys.Escape
                    BtnSalir.PerformClick()
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwLotesInventario_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwLotesInventario.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.Enter
                    SolicitaCantidad()
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwLotesFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwLotesFactura.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.Delete
                    EliminaLote()
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles LvwArticulos.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.Enter
                    If LvwLotesInventario.Items.Count > 0 Then
                        LvwLotesInventario.Select()
                        LvwLotesInventario.Items(0).Selected = True
                    End If
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmLoteSeleccion_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.Width = Screen.PrimaryScreen.WorkingArea.Size.Width
            Me.Height = Screen.PrimaryScreen.WorkingArea.Size.Height - 50

            Me.CenterToScreen()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class