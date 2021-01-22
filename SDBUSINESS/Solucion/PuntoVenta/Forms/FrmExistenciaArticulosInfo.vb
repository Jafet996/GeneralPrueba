Imports Business

Public Class FrmExistenciaArticulosInfo
#Region "Definition of Fields"
    Dim _ArticuloLista As New List(Of TArticuloExistencia)
    Dim _Facturar As Boolean
#End Region
#Region "Definition of Properties"
    Public ReadOnly Property Facturar As Boolean
        Get
            Return _Facturar
        End Get
    End Property
    Public Property ArticuloLista As List(Of TArticuloExistencia)
        Get
            Return _ArticuloLista
        End Get
        Set(value As List(Of TArticuloExistencia))
            _ArticuloLista = value
        End Set
    End Property
#End Region
#Region "Definition of Public Methods"
    Public Sub Execute()
        _Facturar = False
        LlenaLista()
        ShowDialog()
    End Sub
#End Region
#Region "Definition of Private Methods"
    Private Sub LlenaLista()
        Dim Item As ListViewItem
        Dim items(5) As String

        Try
            For Each Art As TArticuloExistencia In _ArticuloLista
                items(0) = Art.Art_Id
                items(1) = Art.Nombre
                items(2) = Format(Art.Saldo, "##0.0000")
                items(3) = Format(Art.Comprometido, "##0.0000")
                items(4) = Format(Art.Facturado, "##0.0000")
                items(5) = Format(Art.Disponible, "##0.0000")

                Item = New ListViewItem(items)
                Item.UseItemStyleForSubItems = False
                ListViewCambiaColorCelda(Item, Color.LightSteelBlue, 4)
                ListViewCambiaColorCelda(Item, Color.LightPink, 5)
                LvwDetalle.Items.Add(Item)
            Next
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Aceptar()
        Try
            If Not VerificaPermiso(EmpresaInfo.Emp_Id, SucursalInfo.Suc_Id, UsuarioInfo.Usuario_Id, Permisos.PVFacturaSinSaldo, False) Then
                VerificaMensaje("No tiene permiso para facturar sin existencia")
            End If

            _Facturar = True
            Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region
#Region "Definition of Events"
    Private Sub FrmExistenciaArticulosInfo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnFacturar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub BtnFacturar_Click(sender As Object, e As EventArgs) Handles BtnFacturar.Click
        Aceptar()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Close()
    End Sub
#End Region
End Class