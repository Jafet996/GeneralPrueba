Imports Business
Public Class FrmClienteSeleccion
    Private _Vendedor_Id As Integer
    Private _Selecciono As Boolean
    Private _Tabla As DataTable
    Private _Registro As DataRow


    Public WriteOnly Property Tabla As DataTable
        Set(value As DataTable)
            _Tabla = value
        End Set
    End Property
    Public ReadOnly Property Registro As DataRow
        Get
            Return _Registro
        End Get
    End Property
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property


    Public Sub Execute()
        _Selecciono = False
        _Registro = Nothing
        Buscar()

        Me.ShowDialog()
    End Sub



    Private Sub Buscar()
        Dim Mensaje As String = ""
        Try


            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()


            DGDetalle.DataSource = _Tabla

            DGDetalle.Columns(0).Width = 0
            DGDetalle.Columns(0).Visible = False

            DGDetalle.Columns(1).Width = 200

            DGDetalle.Columns(2).Width = 200
            'DGDetalle.Columns(2).Visible = False

            DGDetalle.Columns(3).Width = 80

            DGDetalle.Columns(4).Width = 0
            DGDetalle.Columns(4).Visible = False

            DGDetalle.Columns(5).Width = 175

            DGDetalle.Columns(6).Width = 0
            DGDetalle.Columns(6).Visible = False
            DGDetalle.Columns(7).Width = 0
            DGDetalle.Columns(7).Visible = False
            DGDetalle.Columns(8).Width = 0
            DGDetalle.Columns(8).Visible = False
            DGDetalle.Columns(9).Width = 0
            DGDetalle.Columns(9).Visible = False
            DGDetalle.Columns(10).Width = 0
            DGDetalle.Columns(10).Visible = False

            BtnAceptar.Enabled = _Tabla.Rows.Count > 0
            BtnCliente.Enabled = _Tabla.Rows.Count > 0
            BtnInactivar.Enabled = _Tabla.Rows.Count > 0


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Seleccionar()
    End Sub
    'Private Sub DGDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DGDetalle.KeyDown
    '    Select Case e.KeyCode
    '        Case Keys.F2, Keys.Enter
    '            Seleccionar()
    '    End Select
    'End Sub
    Private Sub Seleccionar()
        Try
            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If


            _Selecciono = False
            _Registro = Nothing

            For Each fila As DataRow In _Tabla.Rows
                If fila("Cliente_Id") = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value Then
                    _Registro = fila
                    Exit For
                End If
            Next

            If _Registro Is Nothing Then
                VerificaMensaje("No se localizo el registro en la lista")
                Me.Close()
            End If

            _Selecciono = True
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub




    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Try
            _Selecciono = False
            _Registro = Nothing
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmClienteSeleccion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try

            Select Case e.KeyCode
                Case Keys.F3
                    BtnAceptar.PerformClick()
                Case Keys.F7
                    BtnCliente.PerformClick()
                Case Keys.F8
                    BtnInactivar.PerformClick()
                Case Keys.Escape
                    BtnSalir.PerformClick()
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            Seleccionar()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Dim Forma As New FrmMantClienteDetalle
        Try

            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un cliente")
            End If


            Forma.Titulo = "Mantenimiento Cliente"
            Forma.Nuevo = False
            Forma.Execute(CInt(DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnInactivar_Click(sender As Object, e As EventArgs) Handles BtnInactivar.Click
        Dim ClienteTmp As New TCliente(EmpresaInfo.Emp_Id)
        Try

            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un cliente")
            End If

            If ConfirmaAccion("Desea Inactivar el cliente seleccionado?") Then
                ClienteTmp.Cliente_Id = CInt(DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value)
                ClienteTmp.Activo = False
                VerificaMensaje(ClienteTmp.InactivaCliente())
                Mensaje("El cliente se ha inactivado correctamente")
                BtnSalir.PerformClick()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ClienteTmp = Nothing
        End Try
    End Sub
End Class