Imports Business
Imports System.Windows.Forms
Public Class FrmMantArticuloProveedor
    Dim Numerico() As TNumericFormat
    Dim _Cargando As Boolean = False
    Dim _Art_Id As String
    Dim _Activado As Boolean

    Public WriteOnly Property Art_Id As String
        Set(value As String)
            _Art_Id = value
        End Set
    End Property

    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(4)

            'Numerico(0) = New TNumericFormat(TxtMargen, 8, 2, False, "0", "#,##0.00")
            'Numerico(1) = New TNumericFormat(TxtPrecioVenta, 8, 2, False, "0", "#,##0.00")
            'Numerico(2) = New TNumericFormat(TxtPorcDescuento, 3, 2, False, "0", "#,##0.00")
            'Numerico(3) = New TNumericFormat(TxtMinimo, 5, 2, False, "0", "#,##0.00")
            'Numerico(4) = New TNumericFormat(TxtMaximo, 5, 2, False, "0", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub Inicializa()
        TxtCodigo.Enabled = True
        TxtCodigo.Text = ""
        LblNombreArticulo.Text = ""
        LvwProveedores.Items.Clear()
        BtnGuardar.Enabled = False
        BtnLimpiar.Enabled = False
    End Sub

    Public Sub Execute()
        Try
            _Activado = False
            _Cargando = True
            Inicializa()
            _Cargando = False
            Me.Show()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Private Sub TxtCodigo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigo.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Dim Forma As New FrmBuscaArticuloOnLine
                Forma.Execute()
                If Forma.Art_Id.Trim <> "" Then
                    TxtCodigo.Text = Forma.Art_Id.Trim
                    CargaArticulo()
                End If
                Forma = Nothing
            Case Keys.Enter
                If TxtCodigo.Text.Trim <> "" Then
                    CargaArticulo()
                End If
        End Select
    End Sub

    Private Sub TxtCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodigo.TextChanged
        LblNombreArticulo.Text = ""
    End Sub

    Private Sub FrmArticuloBodega_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not _Activado Then
            _Activado = True
            If _Art_Id <> "" Then
                TxtCodigo.Text = _Art_Id
                CargaArticulo()
            End If
        End If
    End Sub

    Private Sub FrmArticuloBodega_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        TxtCodigo.Select()
    End Sub

    Private Sub CargaArticulo()
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Articulo.Art_Id = TxtCodigo.Text.Trim
            Mensaje = Articulo.ListKey()
            VerificaMensaje(Mensaje)

            If Articulo.RowsAffected = 0 Then
                MsgBox("El código de artículo no existe", MsgBoxStyle.Information)
                TxtCodigo.SelectAll()
                TxtCodigo.Focus()
                Exit Sub
            End If

            If Articulo.Suelto Then
                MsgBox("No se puede asignar un proveedor a un código de artículo suelto", MsgBoxStyle.Information)
                TxtCodigo.SelectAll()
                TxtCodigo.Focus()
                Exit Sub
            End If

            TxtCodigo.Enabled = False

            LblNombreArticulo.Text = Articulo.Nombre

            ProveedoresxArticulo()

            BtnGuardar.Enabled = True
            BtnLimpiar.Enabled = True

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub

    Private Sub ProveedoresxArticulo()
        Dim Proveedor As New TProveedor(EmpresaInfo.Emp_Id)
        Dim ArticuloProveedor As New TArticuloProveedor(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Dim Items(2) As String
        Dim Item As ListViewItem = Nothing
        Try
            LvwProveedores.Items.Clear()

            Mensaje = Proveedor.List()
            VerificaMensaje(Mensaje)

            For Each Reg As DataRow In Proveedor.Data.Tables(0).Rows
                Items(0) = Reg("Codigo")
                Items(1) = Reg("Nombre")

                Item = New ListViewItem(Items)
                Item.Tag = Reg("Codigo")
                LvwProveedores.Items.Add(Item)
            Next


            ArticuloProveedor.Art_Id = TxtCodigo.Text()
            Mensaje = ArticuloProveedor.ProveedoresxArticulo()
            VerificaMensaje(Mensaje)

            For Each Reg As DataRow In ArticuloProveedor.Data.Tables(0).Rows
                For Each Litem As ListViewItem In LvwProveedores.Items
                    If Reg("Prov_Id") = Litem.Tag Then
                        Litem.Checked = True

                        Dim TempItem As ListViewItem = Litem.Clone()

                        LvwProveedores.Items.Insert(0, TempItem)

                        Litem.Remove()
                    End If
                Next
            Next


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Proveedor = Nothing
            ArticuloProveedor = Nothing
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Inicializa()
        TxtCodigo.Focus()
    End Sub


    Private Function ValidaTodo() As Boolean
        Try

            If LvwProveedores.Items.Count = 0 Then
                VerificaMensaje("No hay proveedores disponibles")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Try
            If ValidaTodo() Then
                Guardar()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Guardar()
        Dim ArticuloProveedor As New TArticuloProveedor(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try


            ArticuloProveedor.Art_Id = TxtCodigo.Text
            Mensaje = ArticuloProveedor.EliminaProveedoresxArticulo()


            For Each Item As ListViewItem In LvwProveedores.Items()
                If Item.Checked Then
                    ArticuloProveedor.Prov_Id = CInt(Item.Tag)
                    Mensaje = ArticuloProveedor.Insert()
                    VerificaMensaje(Mensaje)
                End If
            Next

            Inicializa()
            TxtCodigo.Focus()

            MsgBox("Los cambios se almacenaron de manera correcta", MsgBoxStyle.Information, Me.Text)

            If _Art_Id <> "" Then
                Me.Close()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloProveedor = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantArticuloProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnGuardar.PerformClick()
            Case Keys.F4
                BtnLimpiar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
End Class