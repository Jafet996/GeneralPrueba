Imports System.Threading
Imports Business
Public Class FrmCxCAnulaPago
    Dim Numerico() As TNumericFormat
#Region "Enums"
    Private Enum ColumnasDetalle
        Abono_Id = 0
        Cliente_Id
        Cliente
        Fecha
        Monto
        Usuario_Id
        Cierre_Id
        FechaOculta
        Vendedor_Id
    End Enum
#End Region
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCodigo, 6, 0, False, "", "###")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Sub Execute()
        Try
            FormateaCamposNumericos()
            ConfiguraLista()
            RdbFecha.Checked = True

            Limpiar()

            Me.ShowDialog()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub ConfiguraLista()
        Try
            With LvwMovimientos
                .Columns(ColumnasDetalle.Abono_Id).Text = "Documento"
                .Columns(ColumnasDetalle.Abono_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Abono_Id).Width = 80

                .Columns(ColumnasDetalle.Cliente_Id).Text = "Cliente_Id"
                .Columns(ColumnasDetalle.Cliente_Id).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Cliente_Id).Width = 0

                .Columns(ColumnasDetalle.Cliente).Text = "Cliente"
                .Columns(ColumnasDetalle.Cliente).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Cliente).Width = 200

                .Columns(ColumnasDetalle.Fecha).Text = "Fecha"
                .Columns(ColumnasDetalle.Fecha).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Fecha).Width = 120

                .Columns(ColumnasDetalle.Monto).Text = "Monto"
                .Columns(ColumnasDetalle.Monto).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Monto).Width = 120

                .Columns(ColumnasDetalle.Usuario_Id).Text = "Usuario"
                .Columns(ColumnasDetalle.Usuario_Id).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Usuario_Id).Width = 120

                .Columns(ColumnasDetalle.Cierre_Id).Text = "Cierre_Id"
                .Columns(ColumnasDetalle.Cierre_Id).TextAlign = HorizontalAlignment.Right
                .Columns(ColumnasDetalle.Cierre_Id).Width = 0

                .Columns(ColumnasDetalle.FechaOculta).Text = "FechaOculta"
                .Columns(ColumnasDetalle.FechaOculta).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.FechaOculta).Width = 0

                .Columns(ColumnasDetalle.Vendedor_Id).Text = "Vendedor"
                .Columns(ColumnasDetalle.Vendedor_Id).TextAlign = HorizontalAlignment.Left
                .Columns(ColumnasDetalle.Vendedor_Id).Width = 0
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub TxtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsNumeric(TxtCodigo.Text) Then
                    CargaCliente()
                    If TxtNombre.Text = "" Then
                        MensajeError("Código de cliente no válido")
                    End If
                End If
            Case Keys.F1
                BusquedaCliente()
        End Select
    End Sub
    Private Sub BusquedaCliente()
        Dim Forma As New FrmBusquedaClienteOnLine

        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCodigo.Text = Forma.Cliente_Id
                CargaCliente()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub CargaCliente()
        Dim Cliente As New TCxC_Cliente()

        Try
            Cliente.Emp_Id = EmpresaInfo.Emp_Id
            Cliente.Cliente_Id = CInt(TxtCodigo.Text.Trim)
            VerificaMensaje(Cliente.ListKey)

            With Cliente
                TxtNombre.Text = .Nombre
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub
    Private Sub CargaLista()
        Dim CXCAbonoEncabezado As New TCxCAbonoEncabezado(CajaInfo.Emp_Id)
        Dim Items(8) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwMovimientos.Items.Clear()

            With CXCAbonoEncabezado
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cliente_Id = IIf(TxtCodigo.Text = "", 0, TxtCodigo.Text)
            End With

            VerificaMensaje(CXCAbonoEncabezado.ListAbono(RdbCliente.Checked, RdbFecha.Checked, DtpDesde.Value, DtpHasta.Value))

            If CXCAbonoEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron pagos realizados")
            End If

            For Each Fila As DataRow In CXCAbonoEncabezado.Data.Tables(0).Rows
                Items(ColumnasDetalle.Abono_Id) = Fila("Abono_Id")
                Items(ColumnasDetalle.Cliente_Id) = Fila("Cliente_Id")
                Items(ColumnasDetalle.Cliente) = Fila("Nombre")
                Items(ColumnasDetalle.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy")
                Items(ColumnasDetalle.Monto) = Format(Fila("Monto"), "#,##0.00")
                Items(ColumnasDetalle.Usuario_Id) = Fila("Usuario_Id")
                Items(ColumnasDetalle.Cierre_Id) = Fila("Cierre_Id")
                Items(ColumnasDetalle.FechaOculta) = Fila("Fecha")
                Items(ColumnasDetalle.Vendedor_Id) = Fila("Vendedor_Id")

                Item = New ListViewItem(Items)
                LvwMovimientos.Items.Add(Item)
            Next

            BtnAnulaPago.Enabled = LvwMovimientos.Items.Count > 0

        Catch ex As Exception
            MensajeError(ex.Message)
            TxtCodigo.Focus()
        Finally
            CXCAbonoEncabezado = Nothing
        End Try
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Try
            Me.Dispose()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmCxCPago_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnRefrescar.PerformClick()
            Case Keys.F4
                BtnAnulaPago.PerformClick()
            Case Keys.F12
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs) Handles BtnRefrescar.Click
        Try
            If ValidaTodo() Then
                CargaLista()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If RdbCliente.Checked Then
                If TxtCodigo.Text = Nothing Or TxtNombre.Text = Nothing Then
                    TxtCodigo.Focus()
                    VerificaMensaje("Debe de seleccionar cliente")
                End If
            End If
            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Try

            Limpiar()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Limpiar()
        Try

            LvwMovimientos.Items.Clear()
            TxtCodigo.Text = ""
            TxtNombre.Text = ""

            If RdbFecha.Checked Then
                DtpDesde.Select()
            Else
                TxtCodigo.Select()
            End If

            BtnAnulaPago.Enabled = False

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub HabilitaFiltos()
        If RdbFecha.Checked Then
            PnlFechas.Enabled = True
            PnlCliente.Enabled = False
            DtpDesde.Select()
        Else
            PnlFechas.Enabled = False
            PnlCliente.Enabled = True
            TxtCodigo.Select()
        End If
    End Sub

    Private Sub TxtCodigo_TextChanged(sender As Object, e As EventArgs) Handles TxtCodigo.TextChanged
        Try
            TxtNombre.Text = ""
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAnulaPago_Click(sender As Object, e As EventArgs) Handles BtnAnulaPago.Click
        Dim AbonoEncabezado As New TCxCAbonoEncabezado(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem
        'Dim ThdImpresion As Thread
        Try

            If LvwMovimientos.SelectedItems Is Nothing OrElse LvwMovimientos.SelectedItems.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un recibo")
            End If

            If ConfirmaAccion("Desea anular el recibo seleccionado?") Then
                Item = LvwMovimientos.SelectedItems(0)

                With AbonoEncabezado
                    .Emp_Id = CajaInfo.Emp_Id
                    .Suc_Id = CajaInfo.Suc_Id
                    .Caja_Id = CajaInfo.Caja_Id
                    .Tipo_Id = Enum_CxCAbonoTipo.Abono
                    .Abono_Id = Item.SubItems(ColumnasDetalle.Abono_Id).Text
                    .Cierre_Id = CajaInfo.Cierre_Id 'Cierre actual
                    .Cliente_Id = Item.SubItems(ColumnasDetalle.Cliente_Id).Text
                    .Fecha = Item.SubItems(ColumnasDetalle.FechaOculta).Text
                    .Monto = Item.SubItems(ColumnasDetalle.Monto).Text
                    .Vendedor_Id = Item.SubItems(ColumnasDetalle.Vendedor_Id).Text
                    .Usuario_Id = UsuarioInfo.Usuario_Id
                End With

                VerificaMensaje(AbonoEncabezado.AnulaAbono())
                AbonoEncabezado.ListKey()


                ImprimeAbonoCxC(AbonoEncabezado)


                Mensaje("Pago anulado correctamente")


                Limpiar()
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AbonoEncabezado = Nothing
        End Try
    End Sub

    Private Sub RdbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles RdbFecha.CheckedChanged
        HabilitaFiltos()
    End Sub

    Private Sub RdbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles RdbCliente.CheckedChanged
        HabilitaFiltos()
    End Sub
End Class