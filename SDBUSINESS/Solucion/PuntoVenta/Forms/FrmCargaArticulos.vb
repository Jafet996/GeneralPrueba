Imports Business
Imports System.IO
Public Class FrmCargaArticulos
#Region "Variables"
    Private _Guardo As Boolean = False
    Private _ValidaSueltos As Boolean
    Private _ListaConteo As New List(Of TArticuloConteo)
    Private _VerificaBodega As Boolean
    Private _Suc_Id As Integer
    Private _Bod_Id As Integer
#End Region
#Region "Propiedades"
    Public Property VerificaBodega As Boolean
        Get
            Return _VerificaBodega
        End Get
        Set(value As Boolean)
            _VerificaBodega = value
        End Set
    End Property
    Public Property Suc_Id As Integer
        Get
            Return _Suc_Id
        End Get
        Set(value As Integer)
            _Suc_Id = value
        End Set
    End Property
    Public Property Bod_Id As Integer
        Get
            Return _Bod_Id
        End Get
        Set(value As Integer)
            _Bod_Id = value
        End Set
    End Property
    Public Property ValidaSueltos As Boolean
        Get
            Return _ValidaSueltos
        End Get
        Set(value As Boolean)
            _ValidaSueltos = value
        End Set
    End Property
    Public ReadOnly Property ListaConteo As List(Of TArticuloConteo)
        Get
            Return _ListaConteo
        End Get
    End Property
    Public ReadOnly Property Guardo As Boolean
        Get
            Return _Guardo
        End Get
    End Property
    Public Sub Execute()
        AsignaLogo(PicLogo)
        _Guardo = False
        Me.ShowDialog()
    End Sub
#End Region

    Private Sub FrmCargaArticulos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnCargar.PerformClick()
            Case Keys.F4
                BtnAplicar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub BtnCargar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCargar.Click
        CargaArchivo()
    End Sub

    Private Sub CargaArchivo()
        Dim Items(2) As String
        Dim Item As ListViewItem = Nothing
        Dim Valores() As String
        Dim Resultado As Boolean = True

        Try
            OpenF.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            OpenF.FilterIndex = 1
            OpenF.RestoreDirectory = True
            OpenF.FileName = String.Empty
            LvwDetalle.BeginUpdate()

            If OpenF.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    Cursor = Cursors.WaitCursor

                    If (OpenF.OpenFile() IsNot Nothing) Then

                        LvwDetalle.Items.Clear()

                        Using sr As StreamReader = New StreamReader(OpenF.FileName)
                            Dim line As String

                            line = sr.ReadLine()
                            While (line <> Nothing)
                                Valores = line.Split(",")



                                Items(0) = Valores(0)
                                Items(1) = String.Empty
                                Items(2) = Valores(1)

                                Item = New ListViewItem(Items)
                                LvwDetalle.Items.Add(Item)
                                LvwDetalle.Refresh()
                                line = sr.ReadLine()
                            End While
                        End Using
                    End If
                Catch Ex As Exception
                    MsgBox("Cannot read file from disk. Original error: " & Ex.Message)
                Finally
                    LvwDetalle.EndUpdate()
                    Cursor = Cursors.Default
                    If (OpenF.OpenFile() IsNot Nothing) Then
                        OpenF.OpenFile().Close()
                    End If
                End Try
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function BuscaCodigo(pArt_Id As String) As String
        Dim ArticuloEquivalente As New TArticuloEquivalente(EmpresaInfo.Emp_Id)
        Dim Codigo As String = ""
        Try
            ArticuloEquivalente.ArtEquivalente_Id = pArt_Id
            VerificaMensaje(ArticuloEquivalente.ListKey())

            If ArticuloEquivalente.RowsAffected > 0 Then
                Codigo = ArticuloEquivalente.Art_Id
            Else
                Codigo = pArt_Id
            End If

            Return Codigo
        Catch ex As Exception
            MensajeError(ex.Message)
            Return String.Empty
        End Try
    End Function


    Private Function ValidaArticulo(ByVal pArt_Id As String, ByRef pResultado As Boolean) As String
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)

        Try
            pArt_Id = BuscaCodigo(pArt_Id)
            Articulo.Art_Id = pArt_Id
            VerificaMensaje(Articulo.ListKey())

            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("El artículo no existe")
            End If

            'If Articulo.Servicio Then
            '    VerificaMensaje("El artículo es un servicio, imposible cargar")
            'End If

            If _ValidaSueltos AndAlso Articulo.Suelto Then
                VerificaMensaje("No se permite cargar articulos sueltos")
            End If

            If _VerificaBodega Then
                If ValidaArticuloBodega(_Suc_Id, _Bod_Id, pArt_Id) <> String.Empty Then
                    VerificaMensaje("El artículo no esta definido en la bodega ")
                End If
            End If

            pResultado = True

            Return Articulo.Nombre
        Catch ex As Exception
            pResultado = False
            Return ex.Message
        Finally
            Articulo = Nothing
        End Try
    End Function



    Private Function ValidaArticuloBodega(pSuc_Id As Integer, pBod_Id As Integer, pArt_Id As String) As String
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Try
            With ArticuloBodega
                .Suc_Id = pSuc_Id
                .Bod_Id = pBod_Id
                .Art_Id = pArt_Id
            End With
            VerificaMensaje(ArticuloBodega.ListKey())

            If ArticuloBodega.RowsAffected = 0 Then
                VerificaMensaje("El artículo no existe en la bodega")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ArticuloBodega = Nothing
        End Try
    End Function

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnAplicar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAplicar.Click
        If ValidaTodo() Then
            Aplicar()
        End If
    End Sub

    Private Sub ValidaArticulos()
        Dim Resultado As Boolean = False
        Try

            Cursor = Cursors.WaitCursor

            With PrgCarga
                .Minimum = 0
                .Maximum = LvwDetalle.Items.Count
                .Value = 0
                .Visible = True
            End With


            For Each item As ListViewItem In LvwDetalle.Items
                PrgCarga.Value = PrgCarga.Value + 1
                PrgCarga.Refresh()
                Try
                    item.SubItems(1).Text = ValidaArticulo(item.SubItems(0).Text, Resultado)
                    item.ImageIndex = IIf(Resultado, 0, 1)
                Catch ex As Exception
                    item.ImageIndex = 1
                    item.SubItems(1).Text = ex.Message
                End Try
                If (PrgCarga.Value Mod 5) = 0 Then
                    LvwDetalle.Refresh()
                    item.EnsureVisible()
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            PrgCarga.Visible = False
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Function ValidaTodo() As Boolean
        Try
            If LvwDetalle.Items.Count = 0 Then
                VerificaMensaje("La lista debe de contener al menos un registro")
            End If

            ValidaArticulos()

            For Each item As ListViewItem In LvwDetalle.Items
                If item.ImageIndex = 1 Then
                    VerificaMensaje("Existen líneas que contienen errores, imposible realizar la carga")
                End If
            Next

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Aplicar()
        Dim Conteo As TArticuloConteo = Nothing
        Try

            For Each item As ListViewItem In LvwDetalle.Items
                Conteo = New TArticuloConteo()

                With Conteo
                    .Art_Id = item.SubItems(0).Text.Trim
                    .Cantidad = CDbl(item.SubItems(2).Text.Trim)
                End With

                ListaConteo.Add(Conteo)
            Next

            _Guardo = True

            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LvwDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                If Not LvwDetalle.SelectedItems Is Nothing AndAlso LvwDetalle.SelectedItems.Count > 0 Then
                    LvwDetalle.Items.Remove(LvwDetalle.SelectedItems(0))
                End If
        End Select
    End Sub

End Class