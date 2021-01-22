Imports System.Windows.Forms
Imports Business
Public Class FrmBusquedaProveedor
    Private _Prov_Id As Integer
    Private _Selecciono As Boolean

    Public ReadOnly Property Prov_Id As Integer
        Get
            Return _Prov_Id
        End Get
    End Property
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _Selecciono
        End Get
    End Property


    Public Sub Execute()
        _Prov_Id = -1
        _Selecciono = False
        Me.ShowDialog()
    End Sub

    Private Sub TxtCriterio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCriterio.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                If DGDetalle.Rows.Count > 0 Then
                    DGDetalle.Rows(0).Selected = True
                    DGDetalle.Focus()
                End If
        End Select
    End Sub



    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs)
        Dim Proveedor As New TProveedor(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            _Selecciono = False

            If TxtCriterio.Text.Trim = "" Then
                VerificaMensaje("Debe de digitar una descripción")
            End If

            DGDetalle.DataSource = Nothing
            DGDetalle.Rows.Clear()


            Mensaje = Proveedor.ListBusqueda(TxtCriterio.Text.Trim)
            VerificaMensaje(Mensaje)
            If Proveedor.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron proveedores relacionados con esta descripción")
            End If

            DGDetalle.DataSource = Proveedor.Data.Tables(0)

            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 350

            DGDetalle.Focus()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
        End Try
    End Sub


    Private Sub DGDetalle_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetalle.CellContentDoubleClick
        Seleccionar()
    End Sub
    Private Sub DGDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.F2, Keys.Enter
                Seleccionar()
        End Select
    End Sub
    Private Sub Seleccionar()
        Try
            If DGDetalle.CurrentCell Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If

            _Prov_Id = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value

            _Selecciono = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub FrmBusquedaArticulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                If Me.ActiveControl.Name = "DGDetalle" Then
                    BtnAceptar.PerformClick()
                End If
            Case Keys.F6
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub Limpiar()
        DGDetalle.DataSource = Nothing
        TxtCriterio.Text = ""
        TxtCriterio.Focus()
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Seleccionar()
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtCriterio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCriterio.KeyPress
        Dim Proveedor As New TProveedor(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            _Selecciono = False

            If TxtCriterio.Text.Trim <> "" Then

                DGDetalle.DataSource = Nothing
                DGDetalle.Rows.Clear()


                Mensaje = Proveedor.ListBusqueda(TxtCriterio.Text.Trim)

                DGDetalle.DataSource = Proveedor.Data.Tables(0)

                DGDetalle.Columns(0).Width = 100
                DGDetalle.Columns(1).Width = 350

            End If



        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
        End Try
    End Sub
End Class