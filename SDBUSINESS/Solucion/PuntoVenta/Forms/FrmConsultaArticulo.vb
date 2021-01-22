Imports Business
Public Class FrmConsultaArticulo
#Region "Declaracion Variables"
    Private coErrorArticulo = "--ERROR:Articulo--"
    Private _Activo As Boolean = False
    Private _Nuevo As Boolean = True
    Private Enum AccionEnum
        Inicial = 0
        Editando = 1
    End Enum
    Private Enum ColumnasDetalle
        Sucursal = 0
        Bodega = 1
        Saldo = 2
        Comprometido = 3
        Disponible = 4
        Ubicacion = 5
        Precio = 6
        PrecioMayorista = 7
        Precio3 = 8
        Precio4 = 9
        Precio5 = 10
        Costo = 11
        CostoPromedio = 12
        CostoNeto = 13
        Suelto = 14
        FactorConversion = 15
        Exento = 16
    End Enum
#End Region
#Region "Metodos Publicos"
    Public Sub Execute()
        AsignaLogo(PicLogo)
        ConfiguraDetalle()
        Inicializa()

        Me.ShowDialog()
    End Sub
#End Region
#Region "Metodos Privados"


    Private Sub ConfiguraDetalle()
        Try
            With LvwExistencias
                .Columns(ColumnasDetalle.Sucursal).Text = "Sucursal"
                .Columns(ColumnasDetalle.Sucursal).Width = 120

                .Columns(ColumnasDetalle.Bodega).Text = "Bodega"
                .Columns(ColumnasDetalle.Bodega).Width = 120

                .Columns(ColumnasDetalle.Saldo).Text = "Saldo"
                .Columns(ColumnasDetalle.Saldo).Width = 80

                .Columns(ColumnasDetalle.Ubicacion).Text = "Ubicación"
                .Columns(ColumnasDetalle.Ubicacion).Width = 0

                .Columns(ColumnasDetalle.Comprometido).Text = "Comprometido"
                .Columns(ColumnasDetalle.Comprometido).Width = 80

                .Columns(ColumnasDetalle.Precio).Text = "Precio"
                .Columns(ColumnasDetalle.Precio).Width = 80

                .Columns(ColumnasDetalle.PrecioMayorista).Text = "Mayorista 1"
                .Columns(ColumnasDetalle.PrecioMayorista).Width = 0

                .Columns(ColumnasDetalle.Precio3).Text = "Mayorista 2"
                .Columns(ColumnasDetalle.Precio3).Width = 0

                .Columns(ColumnasDetalle.Precio4).Text = "Mayorista 3"
                .Columns(ColumnasDetalle.Precio4).Width = 0

                .Columns(ColumnasDetalle.Precio5).Text = "Mayorista 4"
                .Columns(ColumnasDetalle.Precio5).Width = 0

                .Columns(ColumnasDetalle.Costo).Text = "Costo"
                .Columns(ColumnasDetalle.Costo).Width = 0

                .Columns(ColumnasDetalle.Suelto).Text = "Suelto"
                .Columns(ColumnasDetalle.Suelto).Width = 0
                .Columns(ColumnasDetalle.Suelto).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.FactorConversion).Text = "FC"
                .Columns(ColumnasDetalle.FactorConversion).Width = 0

                .Columns(ColumnasDetalle.Exento).Text = "ExentoIV"
                .Columns(ColumnasDetalle.Exento).Width = 60
                .Columns(ColumnasDetalle.Exento).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasDetalle.Disponible).Text = "Disponible"
                .Columns(ColumnasDetalle.Disponible).Width = 80

                .Columns(ColumnasDetalle.CostoPromedio).Text = "Costo Promedio"
                .Columns(ColumnasDetalle.CostoPromedio).Width = 0

                .Columns(ColumnasDetalle.CostoNeto).Text = "Costo Neto"
                .Columns(ColumnasDetalle.CostoNeto).Width = 0

            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            TxtCodigo.Focus()
            _Nuevo = True

            LblNombreArticulo.Text = ""
            LblCategoriaNombre.Text = ""
            LblSubCategoriaNombre.Text = ""
            LblDepartamentoNombre.Text = ""
            LblUnidadMedidaNombre.Text = ""

            LvwExistencias.Items.Clear()


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaDatos()
        Dim InfoArticulo As New TInfoArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            _Nuevo = True

            TxtCodigo.Text = QuitaComillas(TxtCodigo.Text)

            InfoArticulo.Art_Id = TxtCodigo.Text.Trim
            Mensaje = InfoArticulo.ConsultaArticuloSinSaldo()
            VerificaMensaje(Mensaje)

            If InfoArticulo.RowsAffected = 0 Then
                VerificaMensaje("El código de artículo no existe")
                TxtCodigo.SelectAll()
                TxtCodigo.Focus()
                Exit Sub
            End If

            'TxtCodigo.Enabled = False
            TxtCodigo.Text = InfoArticulo.Art_Id


            If InfoArticulo.RowsAffected > 0 Then
                _Nuevo = False
                With InfoArticulo
                    LblNombreArticulo.Text = .Nombre
                    LblCategoriaNombre.Text = .CategoriaNombre.ToUpper()
                    LblSubCategoriaNombre.Text = .SubCategoriaNombre.ToUpper()
                    LblDepartamentoNombre.Text = .DepartamentoNombre.ToUpper()
                    LblUnidadMedidaNombre.Text = .UnidadMedidaNombre.ToUpper()
                End With
            End If

            CargaSaldos()

            TxtCodigo.SelectAll()
            TxtCodigo.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            InfoArticulo = Nothing
        End Try
    End Sub

    Private Sub CargaSaldos()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Items(16) As String
        Dim Item As ListViewItem = Nothing
        Dim Mensaje As String = ""
        Dim SaldoTotal As Double = 0.00
        Try

            LvwExistencias.Items.Clear()

            ArticuloBodega.Art_Id = TxtCodigo.Text
            Mensaje = ArticuloBodega.ConsultaExistencia()
            VerificaMensaje(Mensaje)

            If ArticuloBodega.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In ArticuloBodega.Data.Tables(0).Rows
                Items(ColumnasDetalle.Sucursal) = Fila("NombreSucursal")
                Items(ColumnasDetalle.Bodega) = Fila("NombreBodega")
                Items(ColumnasDetalle.Saldo) = Format(Fila("Saldo"), "##0.0000")
                Items(ColumnasDetalle.Comprometido) = Format(Fila("Comprometido"), "##0.0000")
                Items(ColumnasDetalle.Precio) = Format(Fila("Precio"), "#,##0.00")
                Items(ColumnasDetalle.PrecioMayorista) = Format(Fila("PrecioMayorista"), "#,##0.00")
                Items(ColumnasDetalle.Precio3) = Format(Fila("Precio3"), "#,##0.00")
                Items(ColumnasDetalle.Precio4) = Format(Fila("Precio4"), "#,##0.00")
                Items(ColumnasDetalle.Precio5) = Format(Fila("Precio5"), "#,##0.00")
                Items(ColumnasDetalle.Costo) = Format(Fila("Costo"), "#,##0.00")
                Items(ColumnasDetalle.CostoPromedio) = Format(Fila("CostoPromedio"), "#,##0.00")
                Items(ColumnasDetalle.CostoNeto) = Format(Fila("CostoNeto"), "#,##0.00")
                Items(ColumnasDetalle.Suelto) = IIf(Fila("Suelto"), "Si", "No")
                Items(ColumnasDetalle.FactorConversion) = Fila("FactorConversion")
                Items(ColumnasDetalle.Exento) = IIf(Fila("ExentoIV"), "Si", "No")
                Items(ColumnasDetalle.Ubicacion) = Fila("Ubicacion")
                Items(ColumnasDetalle.Disponible) = Format(CDbl(Fila("Saldo")) - CDbl(Fila("Comprometido")), "#,##0.00")


                Item = New ListViewItem(Items)
                Item = LvwExistencias.Items.Add(Item)

                Item.UseItemStyleForSubItems = False
                ListViewCambiaColorCelda(Item, Color.LightGreen, ColumnasDetalle.Disponible)
                ListViewCambiaColorCelda(Item, Color.LightSeaGreen, ColumnasDetalle.Precio)

                LvwExistencias.Refresh()

            Next

            For Each Fila As ListViewItem In LvwExistencias.Items
                SaldoTotal = SaldoTotal + (CDbl(Fila.SubItems(ColumnasDetalle.Saldo).Text))
            Next


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub



#End Region
#Region "Eventos Forma"
    Private Sub TxtCodigo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigo.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BtnBuscar.PerformClick()
            Case Keys.Enter
                If TxtCodigo.Text.Trim <> "" Then
                    CargaDatos()
                End If
        End Select
    End Sub
    Private Sub FrmMantArticulo_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not _Activo Then
            _Activo = True
            TxtCodigo.Focus()
        End If
    End Sub



    Private Sub FrmConsultaArticulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
    Private Sub TxtCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodigo.TextChanged
        Inicializa()
    End Sub
#End Region

    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        Dim Forma As New FrmBusquedaArticuloOnLine
        Try

            Forma.Execute()
            If Forma.Art_Id.Trim <> "" Then
                TxtCodigo.Text = Forma.Art_Id.Trim
                CargaDatos()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        TxtCodigo.Text = ""
        Inicializa()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class