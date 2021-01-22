Imports Business
Public Class FrmComprasFacturarCR

    Private _Xml As String
    Private _Acepto As Boolean

    Public Property Xml As String
        Get
            Return _Xml
        End Get
        Set(value As String)
            _Xml = value
        End Set
    End Property
    Public Property Acepto As Boolean
        Get
            Return _Acepto
        End Get
        Set(value As Boolean)
            _Acepto = value
        End Set
    End Property

    Private Enum Columnas
        Compra = 0
        Origen
        Provedor
        FechaEmision
        TotalCobrado
        Clave
        Xml
    End Enum

    Private Sub CargaCombos()
        Dim RecepcionFacturaEmail As New TCompraFacturar(EmpresaParametroInfo.Emisor_Id, EmpresaParametroInfo.CnnFacturar)
        Try


            VerificaMensaje(RecepcionFacturaEmail.LoadComboBoxProveedor(CmbProveedor))


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            RecepcionFacturaEmail = Nothing
        End Try
    End Sub


    Private Sub ConfiguraDetalle()
        Try

            With LvwDetalle
                .Columns(Columnas.Compra).Text = "Compra"
                .Columns(Columnas.Compra).Width = 0
                .Columns(Columnas.Compra).TextAlign = HorizontalAlignment.Center

                .Columns(Columnas.Origen).Text = "Origen"
                .Columns(Columnas.Origen).Width = 80
                .Columns(Columnas.Origen).TextAlign = HorizontalAlignment.Left

                .Columns(Columnas.Provedor).Text = "Proveedor"
                .Columns(Columnas.Provedor).Width = 300
                .Columns(Columnas.Provedor).TextAlign = HorizontalAlignment.Left

                .Columns(Columnas.FechaEmision).Text = "Fecha Emisión"
                .Columns(Columnas.FechaEmision).Width = 100
                .Columns(Columnas.FechaEmision).TextAlign = HorizontalAlignment.Center

                .Columns(Columnas.TotalCobrado).Text = "Total"
                .Columns(Columnas.TotalCobrado).Width = 120
                .Columns(Columnas.TotalCobrado).TextAlign = HorizontalAlignment.Right

                .Columns(Columnas.Clave).Text = "Clave"
                .Columns(Columnas.Clave).Width = 315
                .Columns(Columnas.Clave).TextAlign = HorizontalAlignment.Left

                .Columns(Columnas.Xml).Text = "XML"
                .Columns(Columnas.Xml).Width = 0
                .Columns(Columnas.Xml).TextAlign = HorizontalAlignment.Center

            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try
            _Xml = String.Empty
            _Acepto = False

            CargaCombos()
            ConfiguraDetalle()

            DtpHasta.Value = DateValue(EmpresaInfo.Getdate())
            DtpDesde.Value = DateAdd(DateInterval.Month, -1, DtpHasta.Value)

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmComprasFacturarCR_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
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

    Public Sub CargaLista()
        Dim CompraFacturar As New TCompraFacturar(EmpresaParametroInfo.Emisor_Id, EmpresaParametroInfo.CnnFacturar)
        Dim Items(6) As String
        Dim Item As ListViewItem = Nothing
        Dim FechaIni As Date
        Dim FechaFin As Date
        Try

            Cursor = Cursors.WaitCursor

            LvwDetalle.Items.Clear()

            FechaIni = DateValue(DtpDesde.Value)
            FechaFin = DateValue(DateAdd(DateInterval.Day, 1, DtpHasta.Value))

            CompraFacturar.Prov_Id = IIf(ChkProveedor.Checked, CInt(CmbProveedor.SelectedValue), -1)

            VerificaMensaje(CompraFacturar.SDComprasxEmisor(FechaIni, FechaFin))
            If CompraFacturar.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron documentos en www.facturar.cr")
            End If

            For Each fila As DataRow In CompraFacturar.Data.Tables(0).Rows

                Items(Columnas.Compra) = fila("Compra_Id")
                Items(Columnas.Origen) = fila("Origen")
                Items(Columnas.Provedor) = fila("Nombre")
                Items(Columnas.FechaEmision) = CDate(fila("FechaEmision")).ToString("dd/MM/yyyy")
                Items(Columnas.TotalCobrado) = CDbl(fila("TotalCobrado")).ToString("#,##0.00")
                Items(Columnas.Clave) = fila("Clave")
                Items(Columnas.Xml) = fila("Xml")

                Item = New ListViewItem(Items)
                LvwDetalle.Items.Add(Item)

                If UCase(fila("Origen")) = "PENDIENTES" Then
                    ListViewCambiaColorFilaFondo(Item, Color.LightCyan)
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            CompraFacturar = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        Try

            CargaLista()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwDetalle_DoubleClick(sender As Object, e As EventArgs) Handles LvwDetalle.DoubleClick
        Try

            If LvwDetalle.SelectedItems Is Nothing OrElse LvwDetalle.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un documento")
            End If


            _Xml = LvwDetalle.SelectedItems(0).SubItems(Columnas.Xml).Text

            If _Xml.Trim = String.Empty Then
                VerificaMensaje("El xml está en blanco")
            End If

            _Acepto = True

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

End Class