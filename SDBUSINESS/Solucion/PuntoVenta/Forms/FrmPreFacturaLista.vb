Imports Business
Public Class FrmPreFacturaLista
    Private _FacturaSeleccionada As TFacturaLlave = Nothing

    Public Property FacturaSeleccionada As TFacturaLlave
        Get
            Return _FacturaSeleccionada
        End Get
        Set(value As TFacturaLlave)
            _FacturaSeleccionada = value
        End Set
    End Property

    Private Enum ColumnasDetalle
        Caja_Id = 0
        TipoDoc_Id = 1
        Documento_Id = 2
        ClienteNombre = 3
        Fecha = 4
        Monto = 5
    End Enum

    Private Sub ConfiguraDetalle()
        With LvwDocumentos
            .Items.Clear()
            .Columns(ColumnasDetalle.Caja_Id).Width = 0
            .Columns(ColumnasDetalle.TipoDoc_Id).Width = 0
            .Columns(ColumnasDetalle.Documento_Id).Width = 100
            .Columns(ColumnasDetalle.ClienteNombre).Width = 355
            .Columns(ColumnasDetalle.Fecha).Width = 120
            .Columns(ColumnasDetalle.Monto).Width = 100
            .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
        End With
    End Sub

    Public Sub Execute()
        TimerPreFacturas.Enabled = True
        ConfiguraDetalle()
        CargaLista(False)
        Me.ShowDialog()
    End Sub
    Private Sub FrmPreFacturaLista_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                CargaLista(True)
            Case Keys.F3, Keys.Enter
                SeleccionaFactura()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub CargaLista(pMuestraMensaje As Boolean)
        Dim PreFacturaEncabezado As New TPreFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Items(5) As String
        Dim Item As ListViewItem = Nothing
        Try
            TimerPreFacturas.Enabled = False
            LvwDocumentos.Items.Clear()

            With PreFacturaEncabezado
                .Suc_Id = CajaInfo.Suc_Id
            End With

            Mensaje = PreFacturaEncabezado.ListaPrefacturasPendientes()
            VerificaMensaje(Mensaje)

            If PreFacturaEncabezado.RowsAffected = 0 Then
                If pMuestraMensaje Then
                    VerificaMensaje("No hay prefacturas pendientes")
                End If
            Else
                For Each Fila As DataRow In PreFacturaEncabezado.Data.Tables(0).Rows
                    Items(ColumnasDetalle.Caja_Id) = Fila("Caja_Id")
                    Items(ColumnasDetalle.TipoDoc_Id) = Fila("TipoDoc_Id")
                    Items(ColumnasDetalle.Documento_Id) = Fila("Documento_Id")
                    Items(ColumnasDetalle.ClienteNombre) = Fila("Nombre")
                    Items(ColumnasDetalle.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy HH:mm:ss")
                    Items(ColumnasDetalle.Monto) = Format(Fila("TotalCobrado"), "#,##0.00")

                    Item = New ListViewItem(Items)

                    LvwDocumentos.Items.Add(Item)
                Next

                LvwDocumentos.SelectedItems.Clear()
                LvwDocumentos.Items(0).Selected = True
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            PreFacturaEncabezado = Nothing
            TimerPreFacturas.Enabled = True
        End Try
    End Sub

    Private Sub TimerPreFacturas_Tick(sender As System.Object, e As System.EventArgs) Handles TimerPreFacturas.Tick
        CargaLista(False)
    End Sub

    Private Sub SeleccionaFactura()
        Try

            If LvwDocumentos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un documento")
            End If

            _FacturaSeleccionada = New TFacturaLlave

            With _FacturaSeleccionada
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDetalle.Caja_Id).Text)
                .TipoDoc_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDetalle.TipoDoc_Id).Text)
                .Documento_Id = CLng(LvwDocumentos.SelectedItems(0).SubItems(ColumnasDetalle.Documento_Id).Text)
            End With

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class