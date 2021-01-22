Imports Business
Public Class FrmClienteTipoPrecio
#Region "Variables"
    Private Numerico() As TNumericFormat
#End Region

#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(TxtMontoIni, 7, 2, False, "", "#,##0.00")
            Numerico(1) = New TNumericFormat(TxtMontoFin, 7, 2, False, "", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaCombos()
        Dim ClientePrecio As New TClientePrecio(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(ClientePrecio.LoadComboBox(CmbPrecio))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ClientePrecio = Nothing
        End Try
    End Sub

    Public Sub Execute()
        Try

            DtpFechaFin.Value = DateValue(EmpresaInfo.Getdate())
            DtpFechaIni.Value = DateAdd(DateInterval.Month, -6, DtpFechaFin.Value)

            TxtMontoIni.Text = "0.00"
            TxtMontoFin.Text = "9999999.00"



            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmClienteTipoPrecio_Load(sender As Object, e As EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        CargaCombos()
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        Try
            If ValidaDatos() Then
                Consultar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaDatos() As Boolean
        Try

            If DtpFechaIni.Value > DtpFechaFin.Value Then
                VerificaMensaje("La fecha final no puede ser menor a la fecha inicial")
                DtpFechaIni.Focus()
            End If

            If Not IsNumeric(TxtMontoIni.Text) OrElse CDbl(TxtMontoIni.Text) < 0 Then
                VerificaMensaje("El monto debe de ser mayor o igual a cero")
                TxtMontoIni.Focus()
            End If

            If Not IsNumeric(TxtMontoFin.Text) OrElse CDbl(TxtMontoFin.Text) < 0 Then
                VerificaMensaje("El monto debe de ser mayor o igual a cero")
                TxtMontoFin.Focus()
            End If

            If CDbl(TxtMontoIni.Text) > CDbl(TxtMontoFin.Text) Then
                VerificaMensaje("El monto final no puede ser menor al monto inicial")
                TxtMontoFin.Focus()
            End If

            Return True

        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Consultar()
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Items(3) As String
        Dim Item As ListViewItem = Nothing
        Try

            LvwClientes.Items.Clear()

            VerificaMensaje(Cliente.ConsultaVentasClientePeriodo(DtpFechaIni.Value, DtpFechaFin.Value, CDbl(TxtMontoIni.Text), CDbl(TxtMontoFin.Text)))

            For Each fila As DataRow In Cliente.Data.Tables(0).Rows
                Items(0) = fila("Cliente_Id")
                Items(1) = fila("Nombre")
                Items(2) = fila("VentaTotal")
                Items(3) = fila("NombrePrecio")

                Item = New ListViewItem(Items)
                Item.Checked = True

                LvwClientes.Items.Add(Item)
            Next


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub BtnInicializa_Click(sender As Object, e As EventArgs) Handles BtnInicializa.Click
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Try

            If ConfirmaAccion("esta opción le asignara todos los clientes el precio de Detalle, Desea Continuar?") Then
                Cliente.Cliente_Id = -1
                VerificaMensaje(Cliente.ActualizaTipoPrecio(Enum_ClientPrecio.Detalle))

                Mensaje("Los precios se asignaron de manera correcta")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Aplicar()
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Try

            Cursor = Cursors.WaitCursor

            If LvwClientes.CheckedItems Is Nothing OrElse LvwClientes.CheckedItems.Count = 0 Then
                VerificaMensaje("No se puede aplicar el cambio porque no hay precios seleccionados")
            End If

            If CmbPrecio.SelectedValue Is Nothing OrElse CmbPrecio.Items.Count = 0 Then
                VerificaMensaje("No se puede aplicar el cambio, primero debe de seleccionar un tipo de precio")
            End If

            If ConfirmaAccion("Desea aplicar el cambio de precio para los clientes seleccionados?") Then
                Exit Sub
            End If

            For Each Item As ListViewItem In LvwClientes.CheckedItems
                Cliente.Cliente_Id = CInt(Item.SubItems(0).Text)
                VerificaMensaje(Cliente.ActualizaTipoPrecio(CmbPrecio.SelectedValue))
            Next


            Mensaje("Los precios se aplicaron correctamente")

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        Try

            Aplicar()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MnuClienteOpciones_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MnuClienteOpciones.Opening
        If LvwClientes.Items Is Nothing OrElse LvwClientes.Items.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub MnuMarcarTodo_Click(sender As Object, e As EventArgs) Handles MnuMarcarTodo.Click
        For Each Item As ListViewItem In LvwClientes.Items
            Item.Checked = True
        Next
    End Sub

    Private Sub MnuDesMarcarTodo_Click(sender As Object, e As EventArgs) Handles MnuDesMarcarTodo.Click
        For Each Item As ListViewItem In LvwClientes.Items
            Item.Checked = False
        Next
    End Sub
End Class
