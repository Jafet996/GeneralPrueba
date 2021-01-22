Imports System.Windows.Forms
Public Class FrmUcpSeleccion
    Public Property Acepto As Boolean = False
    Public Property Upc_Id As Integer = 0
    Public Property Nombre As String = String.Empty
    Public Property Cantidad As Integer = 1

    Private Sub CargaCombos()
        Dim Upc As New TUpc(EmpresaInfo.Emp_Id)
        Try

            VerificaMensaje(Upc.LoadComboBox(CmbUpc))

            CmbUpc.SelectedIndex = -1

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Upc = Nothing
        End Try
    End Sub
    Public Sub Execute()
        Try

            CargaCombos()

            CmbUpc.Select()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Try

            Acepto = False
            Upc_Id = 0
            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            If CmbUpc.SelectedIndex <= 0 Then
                VerificaMensaje("Debe de selecciona un UPC")
            End If

            If CmbUpc.Tag Is Nothing Then
                VerificaMensaje("Debe de selecciona un UPC")
            End If

            Upc_Id = CInt(CmbUpc.SelectedValue)
            Nombre = CmbUpc.Text
            Cantidad = CInt(CmbUpc.Tag)

            Acepto = True

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CmbUpc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbUpc.SelectedIndexChanged
        Dim Upc As New TUpc(EmpresaInfo.Emp_Id)
        Try

            If CmbUpc.SelectedValue Is Nothing OrElse CmbUpc.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If

            If CmbUpc.Items.Count = 0 Then
                VerificaMensaje("No se han definido UPC")
            End If

            Upc.Upc_Id = CInt(CmbUpc.SelectedValue)
            VerificaMensaje(Upc.ListKey())

            CmbUpc.Tag = Upc.Cantidad


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Upc = Nothing
        End Try
    End Sub




End Class