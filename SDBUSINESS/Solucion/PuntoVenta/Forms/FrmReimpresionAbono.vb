Imports Business
Public Class FrmReimpresionAbono
    Dim Numerico() As TNumericFormat

    Private Enum ColumnasLvwDocumentos

        CodCliente = 0
        Cliente = 1
        Apartado = 2
        Sucursal = 3
        FechaInicial = 4
        FechaVencimiento = 5
        Saldo = 6
        Monto = 7
        Suc_Id = 8


    End Enum

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCliente, 8, 0, False, "", "###0")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DocumentosRecientes()
        Dim ApartadoEncabezado As New TApartadoEncabezado(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(8) As String

        Dim CodigoCliente As Integer
        Try

            Me.Cursor = Cursors.WaitCursor

            LvwDocumentos.Items.Clear()

            If TxtCliente.Text.Equals("") Then
                CodigoCliente = 0
            Else
                CodigoCliente = TxtCliente.Text
            End If

            VerificaMensaje(ApartadoEncabezado.BusquedaApartados(DateValue(FechaInicial.Value),
                                                        DateValue(DateAdd(DateInterval.Day, 1, FechaFinal.Value)),
                                                        CodigoCliente))


            If ApartadoEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron documentos para los criterios seleccionados")
            End If

            For Each Fila As DataRow In ApartadoEncabezado.Data.Tables(0).Rows
                Items(ColumnasLvwDocumentos.CodCliente) = Fila("CodCliente")
                Items(ColumnasLvwDocumentos.Cliente) = Fila("Cliente")
                Items(ColumnasLvwDocumentos.Apartado) = Fila("Apartado")
                Items(ColumnasLvwDocumentos.Sucursal) = Fila("Sucursal")
                Items(ColumnasLvwDocumentos.FechaInicial) = Format(Fila("Fecha"), "MM/dd/yyyy HH:mm:ss")
                Items(ColumnasLvwDocumentos.FechaVencimiento) = Format(Fila("Vencimiento"), "MM/dd/yyyy HH:mm:ss")
                Items(ColumnasLvwDocumentos.Monto) = Format(Fila("Monto"), "#,##0.00")
                Items(ColumnasLvwDocumentos.Saldo) = Format(Fila("Saldo"), "#,##0.00")

                Item = New ListViewItem(Items)

                LvwDocumentos.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ApartadoEncabezado = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ConfiguraLvwDocumentos()
        Try
            With LvwDocumentos

                .Columns(ColumnasLvwDocumentos.CodCliente).Text = "Cod Cliente"
                .Columns(ColumnasLvwDocumentos.CodCliente).Width = 80
                .Columns(ColumnasLvwDocumentos.CodCliente).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasLvwDocumentos.Cliente).Text = "Cliente"
                .Columns(ColumnasLvwDocumentos.Cliente).Width = 180
                .Columns(ColumnasLvwDocumentos.Cliente).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasLvwDocumentos.Apartado).Text = "Apartado"
                .Columns(ColumnasLvwDocumentos.Apartado).Width = 78
                .Columns(ColumnasLvwDocumentos.Apartado).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasLvwDocumentos.Sucursal).Text = "Sucursal"
                .Columns(ColumnasLvwDocumentos.Sucursal).Width = 130
                .Columns(ColumnasLvwDocumentos.Sucursal).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasLvwDocumentos.FechaInicial).Text = "Fecha"
                .Columns(ColumnasLvwDocumentos.FechaInicial).Width = 150
                .Columns(ColumnasLvwDocumentos.FechaInicial).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasLvwDocumentos.FechaVencimiento).Text = "Vencimiento"
                .Columns(ColumnasLvwDocumentos.FechaVencimiento).Width = 150
                .Columns(ColumnasLvwDocumentos.FechaVencimiento).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasLvwDocumentos.Monto).Text = "Monto"
                .Columns(ColumnasLvwDocumentos.Monto).Width = 110
                .Columns(ColumnasLvwDocumentos.Monto).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasLvwDocumentos.Saldo).Text = "Saldo"
                .Columns(ColumnasLvwDocumentos.Saldo).Width = 110
                .Columns(ColumnasLvwDocumentos.Saldo).TextAlign = HorizontalAlignment.Center

                .Columns(ColumnasLvwDocumentos.Suc_Id).Text = "Suc_Id"
                .Columns(ColumnasLvwDocumentos.Suc_Id).Width = 0

            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try
            ConfiguraLvwDocumentos()
            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmReimpresionAbono_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.CenterToScreen()
            FormateaCamposNumericos()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub LvwDocumentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LvwDocumentos.SelectedIndexChanged
        Try
            If LvwDocumentos.SelectedItems Is Nothing OrElse LvwDocumentos.SelectedItems.Count = 0 Then
                BtnImprimir.Enabled = False
                Exit Sub
            Else
                BtnImprimir.Enabled = True
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Function ValidaFactura() As Boolean
        Try
            If LvwDocumentos.SelectedItems.Count <= 0 Then
                Return False
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim ApartadoEncabezado As New TApartadoEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""

        Try
            If Not ValidaFactura() Then
                Exit Sub
            End If

            With ApartadoEncabezado
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Apartado_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLvwDocumentos.Apartado).Text)
            End With
            VerificaMensaje(ApartadoEncabezado.ListKey)

            If ApartadoEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontro el documento")
            End If

            VerificaMensaje(ImprimeApartado(ApartadoEncabezado, True))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ApartadoEncabezado = Nothing
        End Try
    End Sub

    Private Sub CbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles CbCliente.CheckedChanged
        If CbCliente.Checked Then
            TxtCliente.Enabled = True
            TxtCliente.Select()
        Else
            TxtCliente.Enabled = False
            TxtCliente.Clear()
        End If
    End Sub


    Private Sub FrmReimpresionAbono_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Select Case Me.ActiveControl.Name
                    Case "TxtCliente"
                        BusquedaCliente()
                End Select
            Case Keys.F2
                BtnBuscar.PerformClick()
            Case Keys.F3
                Me.BtnImprimir.PerformClick()
            Case Keys.Escape
                Me.BtnSalir.PerformClick()
        End Select
    End Sub



    Private Sub BusquedaCliente()
        Dim Forma As New FrmBusquedaClienteOnLine
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Try
            Forma.Execute()

            If Forma.Selecciono Then
                TxtCliente.Text = Forma.Cliente_Id
                Cliente.Cliente_Id = CInt(TxtCliente.Text)
                VerificaMensaje(Cliente.ListKey)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Try

            BtnImprimir.Enabled = False

            DocumentosRecientes()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function VerificaDocumentoEstado(pCnnStr As String, pDoc_Id As Long)
        Dim Cnn As New SqlClient.SqlConnection
        Dim Cmd As New SqlClient.SqlCommand()
        Dim reader As SqlClient.SqlDataReader
        Try


            Cnn.ConnectionString = pCnnStr
            Cnn.Open()

            Cmd.Connection = Cnn
            Cmd.CommandText = "select Aceptado from FeEncabezadoFinal with (nolock) where Emisor_Id = " & EmpresaParametroInfo.Emisor_Id & " and Doc_Id = " & pDoc_Id

            reader = Cmd.ExecuteReader()

            If Not reader.HasRows Then
                VerificaMensaje("El documento aun se encuentra en proceso")
            End If


            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            If Cnn.State = ConnectionState.Open Then
                Cnn.Close()
            End If
            Cnn = Nothing
            Cmd = Nothing
            reader = Nothing
        End Try
    End Function
End Class