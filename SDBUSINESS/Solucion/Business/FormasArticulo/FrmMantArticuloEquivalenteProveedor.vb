Imports System.Windows.Forms
Public Class FrmMantArticuloEquivalenteProveedor
    Public Property Prov_Id As Integer = 0
    Public Property Prov_Nombre As String = String.Empty
    Public Property Prov_ArtId As String = String.Empty
    Public Property Prov_ArtNombre As String = String.Empty
    Public Property ArtInterno_Id As String = String.Empty
    Public Property ArtInterno_Nombre As String = String.Empty


    Public Sub Execute()
        Try

            LblProveedor.Tag = Prov_Id
            LblProveedor.Text = Prov_Nombre.Trim.ToUpper
            LblProvArt_Id.Text = Prov_ArtId
            LblProvArt_Nombre.Text = Prov_ArtNombre
            LblArt_Id.Text = String.Empty
            LblArt_Nombre.Text = String.Empty

            CargaArticuloEquivalente()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub CargaArticuloEquivalente()
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Try

            LblArt_Id.Text = String.Empty
            ArtInterno_Id = String.Empty
            LblArt_Nombre.Text = String.Empty
            ArtInterno_Nombre = String.Empty

            VerificaMensaje(Articulo.CargaEquivalenteProveedor(Prov_Id, Prov_ArtId))
            If Articulo.RowsAffected > 0 Then
                LblArt_Id.Text = Articulo.Art_Id
                ArtInterno_Id = Articulo.Art_Id
                LblArt_Nombre.Text = Articulo.Nombre.Trim.ToUpper()
                ArtInterno_Nombre = Articulo.Nombre

            End If

            BtnDel.Visible = (Articulo.RowsAffected > 0)


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub
    Private Sub BuscarArticulo()
        'Dim Forma As New FrmBusquedaArticuloOnLine
        Dim Forma As New FrmBuscaArticuloOnLine
        Try

            Forma.Execute()
            If Forma.Art_Id.Trim <> "" Then
                GuardarArticuloEquivalente(Forma.Art_Id)
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Try

            BuscarArticulo()
            CargaArticuloEquivalente()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub GuardarArticuloEquivalente(pArt_Id As String)
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Try

            Articulo.Art_Id = pArt_Id

            VerificaMensaje(Articulo.GuardaEquivalenteProveedor(Prov_Id, Prov_ArtId))


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub
    Private Sub EliminarArticuloEquivalente(pArt_Id As String)
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Try

            Articulo.Art_Id = pArt_Id

            VerificaMensaje(Articulo.EliminaEquivalenteProveedor(Prov_Id))


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        Try

            If ConfirmaAccion("Desea eliminar el código equivalente?") Then
                EliminarArticuloEquivalente(LblArt_Id.Text)
            End If

            CargaArticuloEquivalente()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMantArticuloEquivalenteProveedor_Click(sender As Object, e As EventArgs) Handles Me.Click

    End Sub
End Class