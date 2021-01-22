Imports Business
Public Class FrmReimpresionFactura
    Dim Numerico() As TNumericFormat

    Private Enum ColumnasLvwDocumentos

        Caja = 0
        Tipo = 1
        Numero = 2
        Fecha = 3
        Cliente = 4
        Monto = 5
        CajaId = 6
        Clave = 7
        Email = 8
        TipoDoc = 9
        Doc_Id = 10
        Estado = 11
    End Enum

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCliente, 8, 0, False, "", "###0")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombos()
        Dim TipoDocumento As New TTipoDocumento(EmpresaInfo.Emp_Id)
        Dim Caja As New TCaja(EmpresaInfo.Emp_Id)
        Try

            Caja.Suc_Id = SucursalInfo.Suc_Id

            TipoDocumento.Emp_Id = CajaInfo.Emp_Id
            VerificaMensaje(TipoDocumento.LoadComboBox(CmbTipoDocumento))
            VerificaMensaje(Caja.LoadComboBox(CmbCaja))



        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoDocumento = Nothing
        End Try
    End Sub

    Private Sub DocumentosRecientes()
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Item As ListViewItem = Nothing
        Dim Items(11) As String
        Dim CodigoCliente As Integer
        Dim TipoDocumento As Integer
        Dim NumeroCaja As Integer
        Try

            Me.Cursor = Cursors.WaitCursor

            LvwDocumentos.Items.Clear()

            With FacturaEncabezado
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
            End With


            If TxtCliente.Text.Equals("") Then
                CodigoCliente = 0
            Else
                CodigoCliente = TxtCliente.Text
            End If


            If CbTipo.Checked Then
                TipoDocumento = CmbTipoDocumento.SelectedValue
            Else
                TipoDocumento = 0
            End If


            If CbCaja.Checked Then
                NumeroCaja = CmbCaja.SelectedValue
            Else
                NumeroCaja = 0
            End If




            VerificaMensaje(FacturaEncabezado.DocumentosRecientes(DateValue(FechaInicial.Value),
                                                        DateValue(DateAdd(DateInterval.Day, 1, FechaFinal.Value)),
                                                        CodigoCliente,
                                                        NumeroCaja,
                                                        TipoDocumento))



            If FacturaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron documentos para los criterios seleccionados")
            End If

            For Each Fila As DataRow In FacturaEncabezado.Data.Tables(0).Rows
                Items(ColumnasLvwDocumentos.Caja) = Fila("CajaNombre")
                Items(ColumnasLvwDocumentos.Tipo) = Fila("Tipo")
                Items(ColumnasLvwDocumentos.Numero) = Fila("Numero")
                Items(ColumnasLvwDocumentos.Fecha) = Format(Fila("Fecha"), "dd/MM/yyyy HH:mm:ss")
                Items(ColumnasLvwDocumentos.Cliente) = Fila("Cliente")
                Items(ColumnasLvwDocumentos.Monto) = Format(Fila("Monto"), "#,##0.00")
                Items(ColumnasLvwDocumentos.CajaId) = Fila("Caja")
                Items(ColumnasLvwDocumentos.Clave) = Fila("Clave")
                Items(ColumnasLvwDocumentos.Email) = Fila("Email")
                Items(ColumnasLvwDocumentos.TipoDoc) = Fila("TipoDoc")
                Items(ColumnasLvwDocumentos.Doc_Id) = Fila("Doc_Id")
                Items(ColumnasLvwDocumentos.Estado) = Fila("EstadoNombre")

                Item = New ListViewItem(Items)
                Item.Tag = Fila("TipoDoc_Id")

                LvwDocumentos.Items.Add(Item)
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaEncabezado = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ConfiguraLvwDocumentos()
        Try
            With LvwDocumentos

                .Columns(ColumnasLvwDocumentos.Tipo).Text = "Tipo"
                .Columns(ColumnasLvwDocumentos.Tipo).Width = 105

                .Columns(ColumnasLvwDocumentos.Numero).Text = "Número"
                .Columns(ColumnasLvwDocumentos.Numero).Width = 60

                .Columns(ColumnasLvwDocumentos.Fecha).Text = "Fecha"
                .Columns(ColumnasLvwDocumentos.Fecha).Width = 120

                .Columns(ColumnasLvwDocumentos.Cliente).Text = "Cliente"
                .Columns(ColumnasLvwDocumentos.Cliente).Width = 200

                .Columns(ColumnasLvwDocumentos.Caja).Text = "Caja"
                .Columns(ColumnasLvwDocumentos.Caja).Width = 80


                .Columns(ColumnasLvwDocumentos.Monto).Text = "Monto"
                .Columns(ColumnasLvwDocumentos.Monto).Width = 100
                .Columns(ColumnasLvwDocumentos.Monto).TextAlign = HorizontalAlignment.Right

                .Columns(ColumnasLvwDocumentos.CajaId).Text = "Cajaid"
                .Columns(ColumnasLvwDocumentos.CajaId).Width = 0


                .Columns(ColumnasLvwDocumentos.Clave).Text = "Clave"
                .Columns(ColumnasLvwDocumentos.Clave).Width = 315

                .Columns(ColumnasLvwDocumentos.Email).Text = "Email"
                .Columns(ColumnasLvwDocumentos.Email).Width = 210

                .Columns(ColumnasLvwDocumentos.TipoDoc).Text = "TipoDoc"
                .Columns(ColumnasLvwDocumentos.TipoDoc).Width = 0

                .Columns(ColumnasLvwDocumentos.Doc_Id).Text = "Doc_Id"
                .Columns(ColumnasLvwDocumentos.Doc_Id).Width = 0

                .Columns(ColumnasLvwDocumentos.Estado).Text = "Estado"
                .Columns(ColumnasLvwDocumentos.Estado).Width = 80


            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute()
        Try
            ConfiguraLvwDocumentos()
            CargaCombos()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmReimpresionFactura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Me.Width = Screen.PrimaryScreen.WorkingArea.Size.Width
            Me.Height = Screen.PrimaryScreen.WorkingArea.Size.Height - 50
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

            CmbTipoDocumento.SelectedValue = LvwDocumentos.SelectedItems(0).Tag

            If (LvwDocumentos.SelectedItems(0).SubItems(ColumnasLvwDocumentos.TipoDoc).Text = coFacturaElectronica Or LvwDocumentos.SelectedItems(0).SubItems(ColumnasLvwDocumentos.TipoDoc).Text = coNotaCreditoElectronica) Then
                BtnEnviar.Enabled = IsValidEmailFormat(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLvwDocumentos.Email).Text)
            Else
                BtnEnviar.Enabled = False
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

            If CmbTipoDocumento.SelectedValue Is Nothing OrElse CmbTipoDocumento.SelectedIndex = -1 Then
                CmbTipoDocumento.Focus()
                VerificaMensaje("Debe de seleccionar un tipo de documento")
            End If

            'If Not IsNumeric(TxtNumero.Text) Then
            '    TxtNumero.Focus()
            '    VerificaMensaje("Debe de ingresar un numero de documento")
            'End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim FacturaEncabezado As New TFacturaEncabezado(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If Not ValidaFactura() Then
                Exit Sub
            End If

            With FacturaEncabezado
                .Emp_Id = CajaInfo.Emp_Id
                .Suc_Id = CajaInfo.Suc_Id
                .Caja_Id = CInt(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLvwDocumentos.CajaId).Text)
                .TipoDoc_Id = LvwDocumentos.SelectedItems(0).Tag
                .Documento_Id = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLvwDocumentos.Numero).Text
                .Reimpresion = True
            End With


            Mensaje = FacturaEncabezado.ListKey
            VerificaMensaje(Mensaje)

            If FacturaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontro el documento")
            End If

            VerificaMensaje(ImprimeFactura(FacturaEncabezado))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FacturaEncabezado = Nothing
        End Try
    End Sub

    Private Sub CbTipo_CheckedChanged(sender As Object, e As EventArgs) Handles CbTipo.CheckedChanged
        If CbTipo.Checked Then
            CmbTipoDocumento.Enabled = True
        Else
            CmbTipoDocumento.Enabled = False
        End If
    End Sub

    Private Sub CbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles CbCaja.CheckedChanged
        CmbCaja.Enabled = CbCaja.Checked
    End Sub

    Private Sub CbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles CbCliente.CheckedChanged
        If CbCliente.Checked Then
            TxtCliente.Enabled = True
            TxtClienteNombre.Enabled = True
            TxtCliente.Select()
        Else
            TxtCliente.Enabled = False
            TxtClienteNombre.Enabled = False
        End If
    End Sub


    Private Sub FrmReimpresionFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
                TxtClienteNombre.Text = Cliente.Nombre
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCliente.TextChanged
        TxtClienteNombre.Text = ""
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Try

            BtnImprimir.Enabled = False
            BtnEnviar.Enabled = False

            DocumentosRecientes()
            'If LvwDocumentos.Items.Count > 0 Then
            '    BtnImprimir.Enabled = True
            'End If

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


    Private Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles BtnEnviar.Click
        Dim FormaEmail As New FrmSolicitaEmail
        Dim CnnConsulta As String = String.Empty
        Dim Cnn As New SqlClient.SqlConnection
        Dim Cmd As New SqlClient.SqlCommand
        Dim Email As String = String.Empty
        Dim SDWCF As New WsSDWCF.SDWCF
        Try

            If LvwDocumentos.SelectedItems Is Nothing OrElse LvwDocumentos.SelectedItems.Count <= 0 Then
                VerificaMensaje("Debe de seleccionar un documento")
            End If


            If LvwDocumentos.SelectedItems(0).SubItems(ColumnasLvwDocumentos.Email).Text.Trim <> String.Empty OrElse IsValidEmailFormat(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLvwDocumentos.Email).Text.Trim) Then
                FormaEmail.Email = LvwDocumentos.SelectedItems(0).SubItems(ColumnasLvwDocumentos.Email).Text
            End If

            FormaEmail.Execute()

            If Not FormaEmail.Acepto Then
                Exit Sub
            Else
                Email = FormaEmail.Email
            End If


            SDWCF.Url = InfoMaquina.URLSD

            SDWCF.ReenvioDocumentoElectronico(EmpresaParametroInfo.Emisor_Id, CLng(LvwDocumentos.SelectedItems(0).SubItems(ColumnasLvwDocumentos.Doc_Id).Text), Email)


            MensajeError("El documento ha sido enviado")


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            If Cnn.State = ConnectionState.Open Then
                Cnn.Close()
            End If
            FormaEmail = Nothing
            Cnn = Nothing
            Cmd = Nothing
            SDWCF = Nothing
        End Try
    End Sub
End Class