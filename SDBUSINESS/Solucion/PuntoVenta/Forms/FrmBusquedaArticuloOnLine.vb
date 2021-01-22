Imports Business
Public Class FrmBusquedaArticuloOnLine
#Region "Enum"
    Private Enum Enum_Columnas
        Bodega = 0
        NombreBodega
        Articulo
        NombreArticulo
        Saldo
        Precio
    End Enum
#End Region
#Region "Variables"
    Private _Art_Id As String
    Private _Nombre As String
    Dim tipoBusqueda As Integer = 1
    Private _Articulos As List(Of String)

#End Region
#Region "Propiedades"
    Public ReadOnly Property Articulos() As List(Of String)
        Get
            Return _Articulos
        End Get
    End Property
    Public ReadOnly Property Art_Id As String
        Get
            Return _Art_Id
        End Get
    End Property
    Public ReadOnly Property Nombre As String
        Get
            Return _Nombre
        End Get
    End Property
#End Region

    Public Sub Execute()
        _Art_Id = ""
        _Articulos = New List(Of String)()
        _Nombre = ""
        LblMensaje.Text = ""
        ConfiguraLista()

        Me.ShowDialog()
    End Sub

    Private Sub TxtCriterio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCriterio.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                If DGDetalle.Rows.Count > 0 Then
                    DGDetalle.Rows(0).Selected = True
                    DGDetalle.Focus()
                End If
            Case Keys.Enter
                If TxtCriterio.Text <> "" Then
                    Buscar()
                End If
        End Select
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCriterio.TextChanged
        If TxtCriterio.Text.Trim.Length >= 3 And EmpresaParametroInfo.BusquedaArticuloOnline Then
            Buscar()
        Else
            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()
            LvwArticuloBodega.Items.Clear()
        End If
    End Sub

    Private Sub Buscar()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)

        Try
            If TxtCriterio.Text.Trim = "" Then
                DGDetalle.DataSource = Nothing
                DGDetalle.Rows.Clear()
                LvwArticuloBodega.Items.Clear()
                Exit Sub
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()
            LvwArticuloBodega.Items.Clear()

            With ArticuloBodega
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Bod_Id = CajaInfo.Bod_Id
            End With
            VerificaMensaje(ArticuloBodega.ListBusquedaPuntoVenta(TxtCriterio.Text.Trim, tipoBusqueda))

            If ArticuloBodega.RowsAffected = 0 Then
                LblMensaje.Text = "No se encontraron datos relacionados"
            Else
                LblMensaje.Text = ""
            End If

            DGDetalle.DataSource = ArticuloBodega.Data.Tables(0)
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 400
            DGDetalle.Columns(2).Width = 80
            DGDetalle.Columns(3).Width = 80
            DGDetalle.Columns(4).Width = 80
            DGDetalle.Columns(5).Width = 80
            DGDetalle.Columns(6).Width = 80
            DGDetalle.Columns(7).Width = 80
            DGDetalle.Columns(8).Width = 60

            DGDetalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGDetalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGDetalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGDetalle.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGDetalle.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGDetalle.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGDetalle.Columns(3).DefaultCellStyle.Format = "#,##0.00"
            DGDetalle.Columns(4).DefaultCellStyle.Format = "#,##0.00"
            DGDetalle.Columns(5).DefaultCellStyle.Format = "#,##0.00"
            DGDetalle.Columns(6).DefaultCellStyle.Format = "#,##0.00"
            DGDetalle.Columns(7).DefaultCellStyle.Format = "#,##0.00"


            'For Each row As DataGridViewRow In DGDetalle.Rows
            '    If row.Cells(8).Value = "No" Then
            '        row.Cells(8).Style.BackColor = Color.DarkGreen
            '        row.Cells(8).Style.ForeColor = Color.White
            '    End If
            'Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwArticuloBodega
                .Columns(Enum_Columnas.Bodega).Text = "# Bodega"
                .Columns(Enum_Columnas.Bodega).Width = 75

                .Columns(Enum_Columnas.NombreBodega).Text = "Nombre"
                .Columns(Enum_Columnas.NombreBodega).Width = 150

                .Columns(Enum_Columnas.Articulo).Text = "Código"
                .Columns(Enum_Columnas.Articulo).Width = 100

                .Columns(Enum_Columnas.NombreArticulo).Text = "Articulo"
                .Columns(Enum_Columnas.NombreArticulo).Width = 370

                .Columns(Enum_Columnas.Saldo).Text = "Saldo"
                .Columns(Enum_Columnas.Saldo).Width = 50

                .Columns(Enum_Columnas.Precio).Text = "Precio"
                .Columns(Enum_Columnas.Precio).Width = 120
                .Columns(Enum_Columnas.Precio).TextAlign = HorizontalAlignment.Right
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaListaSaldos()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(5) As String
        Dim totalSuc As Double = 0.00

        Try
            LvwArticuloBodega.Items.Clear()

            If DGDetalle.CurrentCell Is Nothing Then
                Exit Sub
            End If

            With ArticuloBodega
                .Suc_Id = SucursalInfo.Suc_Id
                .Art_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            End With
            VerificaMensaje(ArticuloBodega.ListaSaldosXBodega)

            If ArticuloBodega.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In ArticuloBodega.Data.Tables(0).Rows
                Items(Enum_Columnas.Bodega) = Fila("Bod_Id")
                Items(Enum_Columnas.NombreBodega) = Fila("NombreBodega")
                Items(Enum_Columnas.Articulo) = Fila("Art_Id")
                Items(Enum_Columnas.NombreArticulo) = Fila("NombreArticulo")
                Items(Enum_Columnas.Saldo) = Fila("Saldo")
                Items(Enum_Columnas.Precio) = Format(Fila("Precio"), "#,##0.00")

                Item = New ListViewItem(Items)
                LvwArticuloBodega.Items.Add(Item)
            Next


            For Each Fila As ListViewItem In LvwArticuloBodega.Items
                totalSuc = totalSuc + (CDbl(Fila.SubItems(Enum_Columnas.Saldo).Text))
            Next

            Items(Enum_Columnas.Bodega) = ""
            Items(Enum_Columnas.NombreBodega) = "TOTAL GENERAL"
            Items(Enum_Columnas.Articulo) = ""
            Items(Enum_Columnas.NombreArticulo) = ""
            Items(Enum_Columnas.Saldo) = totalSuc
            Items(Enum_Columnas.Precio) = ""

            Item = New ListViewItem(Items)
            LvwArticuloBodega.Items.Add(Item)
            Item.BackColor = Color.SteelBlue
            Item.ForeColor = Color.White

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Seleccionar()
    End Sub

    Private Sub DGDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter

                If Not DGDetalle.SelectedRows Is Nothing AndAlso DGDetalle.SelectedRows.Count > 1 Then
                    SeleccionarMultiples()
                Else
                    Seleccionar()
                End If

        End Select
    End Sub

    Private Sub SeleccionarMultiples()
        Try

            Articulos.Clear

            For index = 0 To (DGDetalle.SelectedRows.Count - 1)
                Articulos.Add(DGDetalle.SelectedRows(index).Cells(0).Value)
            Next
            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Seleccionar()
        Try

            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            _Art_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            _Nombre = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(1).Value

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmBusquedaArticulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TxtCriterio.SelectAll()
                TxtCriterio.Focus()
            Case Keys.F2
                ConsultaSaldoBodegas()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub ConsultaSaldoBodegas()
        Dim Forma As New FrmConsultaSaldoBodegas

        Try
            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            Forma.Art_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnSaldos_Click(sender As Object, e As EventArgs) Handles BtnSaldos.Click
        ConsultaSaldoBodegas()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub DGDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDetalle.CellContentClick
        CargaListaSaldos()
    End Sub

    Private Sub DGDetalle_SelectionChanged(sender As Object, e As EventArgs) Handles DGDetalle.SelectionChanged
        CargaListaSaldos()
        MuestraLeyendaSeleccionados()
    End Sub

    Private Sub MuestraLeyendaSeleccionados()
        Try

            LblSeleccionLeyenda.Visible = False
            LblSeleccionCantidad.Visible = False


            If Not DGDetalle.SelectedRows Is Nothing AndAlso DGDetalle.SelectedRows.Count > 0 Then
                LblSeleccionCantidad.Text = DGDetalle.SelectedRows.Count.ToString()
                LblSeleccionLeyenda.Visible = True
                LblSeleccionCantidad.Visible = True
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub RbtDescripción_CheckedChanged(sender As Object, e As EventArgs) Handles RbtDescripción.CheckedChanged
        Try
            If RbtDescripción.Checked Then
                tipoBusqueda = 1
                RbnCodEquivalente.Checked = False
                TxtCriterio.Focus()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RbnCodEquivalente_CheckedChanged(sender As Object, e As EventArgs) Handles RbnCodEquivalente.CheckedChanged
        Try
            If RbnCodEquivalente.Checked Then
                tipoBusqueda = 2
                RbtDescripción.Checked = False
                TxtCriterio.Focus()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class