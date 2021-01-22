Imports Business
Public Class FrmMantClienteLista
    Private coTitulo = "Cliente"
    Private _GuardoCambios As Boolean
    Private _ClienteNuevo As Integer
    Private _SalirAlGuardar As Boolean = False

    Public ReadOnly Property GuardoCambios As Boolean
        Get
            Return _GuardoCambios
        End Get
    End Property
    Public ReadOnly Property ClienteNuevo As Integer
        Get
            Return _ClienteNuevo
        End Get
    End Property
    Public WriteOnly Property SalirAlGuardar As Boolean
        Set(value As Boolean)
            _SalirAlGuardar = value
        End Set
    End Property

    Public Sub Execute()
        Me.Text = coTitulo
        _GuardoCambios = False
        _ClienteNuevo = 0
        LblTitulo.Text = coTitulo
        Refrescar()
        Me.ShowDialog()
    End Sub

    Private Sub BtnRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles BtnRefrescar.Click
        Refrescar()
    End Sub

    Private Sub Refrescar()
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            DGDetalle.DataSource = Nothing

            Mensaje = Cliente.ListaMantenimiento(TxtCriterio.Text.Trim)
            VerificaMensaje(Mensaje)

            DGDetalle.DataSource = Cliente.Data.Tables(0)

            DGDetalle.Columns(0).HeaderText = "Código"
            DGDetalle.Columns(1).HeaderText = "Nombre"
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 760

            BtnModificar.Enabled = (DGDetalle.RowCount > 0)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantClienteLista_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                Refrescar()
            Case Keys.F7
                BtnNuevo.PerformClick()
        End Select
    End Sub

    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs)
        Eliminar()
    End Sub
    Private Sub Eliminar()
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If

            If Not ConfirmaAccion("Desea eliminar el registro?") Then
                Exit Sub
            End If


            Cliente.Cliente_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
            Mensaje = Cliente.Delete()
            VerificaMensaje(Mensaje)

            _GuardoCambios = True

            Refrescar()

        Catch ex As Exception
            MensajeError(ex.Message, "Mantenimiento")
        Finally
            Cliente = Nothing
        End Try
    End Sub


    Private Sub Modificar()
        Dim Forma As New FrmMantClienteDetalle
        Dim Codigo As Integer = -1
        Try

            If DGDetalle.SelectedCells Is Nothing OrElse DGDetalle.SelectedCells.Count = 0 Then
                VerificaMensaje("Debe de seleccionar un registro")
            End If


            Codigo = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            Forma.Titulo = coTitulo
            Forma.Nuevo = False
            Forma.Execute(Codigo)

            _GuardoCambios = Forma.GuardoCambios

            If Forma.GuardoCambios Then
                Refrescar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message, "Mantenimiento")
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Dim Forma As New FrmMantClienteDetalle
        Dim Mensaje As String = ""
        Try

            Forma.Titulo = coTitulo
            Forma.Nuevo = True
            Forma.Execute(-1)

            _GuardoCambios = Forma.GuardoCambios

            If Forma.GuardoCambios Then
                _ClienteNuevo = Forma.ClienteNuevo
                If _SalirAlGuardar Then
                    Me.Close()
                Else
                    Refrescar()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Modificar()
    End Sub

    Private Sub DGDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                Modificar()
            Case Keys.Delete
                Eliminar()
        End Select
    End Sub

    Private Sub TxtCriterio_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCriterio.TextChanged
        If TxtCriterio.Text.Trim <> "" Then
            PicBorrar.Image = Global.PuntoVenta.My.Resources.delete
        Else
            PicBorrar.Image = Nothing
        End If
        Refrescar()
    End Sub


    Private Sub PicBorrar_Click(sender As System.Object, e As System.EventArgs) Handles PicBorrar.Click
        TxtCriterio.Text = ""
    End Sub

    Private Sub FrmMantClienteLista_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtCriterio.Select()
    End Sub
End Class