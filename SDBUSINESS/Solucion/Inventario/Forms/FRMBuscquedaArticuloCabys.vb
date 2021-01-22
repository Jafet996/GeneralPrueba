Imports Business
Public Class FRMBuscquedaArticuloCabys
#Region "Enum"
    Dim Codigo As String = ""
    Dim Descripcion As String
    Dim Tarifa As Double
    Dim asignadoCabys As Boolean


    Private Enum Enum_Columnas
        Bodega = 0
        NombreBodega
        Articulo
        NombreArticulo
        Saldo
        Precio
    End Enum
#End Region
#Region "Variables"
    Private _Art_Id As String
    Private _Nombre As String
    Dim tipoBusqueda As Integer = 1
    Private _Articulos As List(Of String)

#End Region
#Region "Propiedades"
    Public ReadOnly Property Articulos() As List(Of String)
        Get
            Return _Articulos
        End Get
    End Property
    Public ReadOnly Property Art_Id As String
        Get
            Return _Art_Id
        End Get
    End Property
    Public ReadOnly Property Nombre As String
        Get
            Return _Nombre
        End Get
    End Property
#End Region

    Public Sub Execute()
        _Art_Id = ""
        _Articulos = New List(Of String)()
        _Nombre = ""
        LblMensaje.Text = ""
        Me.lblCodigo.Text = ""
        Me.ShowDialog()
    End Sub

    'Private Sub TxtCriterio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCriterio.KeyDown
    '    Select Case e.KeyCode
    '        Case Keys.Down
    '            'If DGDetalle.Rows.Count > 0 Then
    '            '    DGDetalle.Rows(0).Selected = True
    '            '    DGDetalle.Focus()
    '            'End If
    '        Case Keys.Enter
    '            If TxtCriterio.Text <> "" Then
    '                Buscar()
    '            End If
    '    End Select
    'End Sub

    Private Sub TxtCriterio_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCriterio.TextChanged
        If TxtCriterio.Text.Trim.Length >= 3 And EmpresaParametroInfo.BusquedaArticuloOnline Then
            Buscar()
        Else
            'DGDetalle.DataSource = Nothing
            'DGDetalle.Rows.Clear()
            'LvwArticuloBodega.Items.Clear()
        End If
    End Sub

    Private Sub Buscar()
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Items(3) As String
        Dim Item As ListViewItem = Nothing
        Try

            With ArticuloBodega
                .Emp_Id = EmpresaInfo.Emp_Id
            End With
            VerificaMensaje(ArticuloBodega.ListBusquedaCABYS(TxtCriterio.Text.Trim, tipoBusqueda, asignadoCabys))

            If ArticuloBodega.RowsAffected = 0 Then
                LblMensaje.Text = "No se encontraron datos relacionados"
            Else
                LblMensaje.Text = ""
            End If
            Me.Articuloslist.CheckBoxes = True

            Me.Articuloslist.Items.Clear()
            For Each Fila In ArticuloBodega.Data.Tables(0).Rows

                Items(1) = Fila(0)
                Items(2) = Fila(2)
                Items(3) = Fila(1)


                Item = New ListViewItem(Items)

                Articuloslist.Items.Add(Item)
            Next

            For i As Integer = 0 To Articuloslist.Items.Count - 1
                Articuloslist.Items(i).Checked = True
            Next
            TotalEncontrados.Text = "( " & Articuloslist.Items.Count & " )"

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ArticuloBodega = Nothing
        End Try
    End Sub


    Private Sub BtnSaldos_Click(sender As Object, e As EventArgs) Handles BtnSaldos.Click
        AsignaCabys()

    End Sub

    Private Sub AsignaCabys()
        Dim Forma As New FrmCabys
        Dim flag As Boolean = False
        Try

            If Articuloslist.Items.Count = 0 Then
                VerificaMensaje("No hay ningun registros para asignar código cabys")
            End If

            For i As Integer = 0 To Articuloslist.Items.Count - 1
                If Articuloslist.Items(i).Checked = True Then
                    flag = True
                End If
            Next



            If flag = False Then
                VerificaMensaje("No hay nungun articulo seleccionado para asignar el código cabys")
            End If


            Forma.Execute()

            If Forma.Selecciono Then
                lblCodigo.Text = Forma.Descripcion
                Codigo = Forma.Codigo
                Descripcion = Forma.Descripcion
                Tarifa = Forma.Tarifa
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try

    End Sub

    Private Sub asignarCodig()
        Try
            Dim Articulos As New List(Of TArticulo)
            Dim artic As TArticulo = New TArticulo(InfoMaquina.Emp_Id)

            For i As Integer = 0 To Articuloslist.CheckedItems.Count - 1
                'If Articuloslist.Items(i).Checked = True Then
                Dim art As TArticulo = New TArticulo(InfoMaquina.Emp_Id)
                art.Art_Id = Articuloslist.CheckedItems(i).SubItems(1).Text
                art.Nombre = Articuloslist.CheckedItems(i).SubItems(3).Text
                'art.SaldoPropio = Articuloslist.CheckedItems(i).SubItems(3).Text
                art.CodigoCabys = Codigo
                art.CabysDescripcion = Descripcion
                art.CabysTarifa = Tarifa
                Articulos.Add(art)
            Next

            'Metodo para asignar cabys a los productos

            artic.AsignarCabys(Articulos)
            Mensaje("Los cambios se almacenaron correctamente")
            Inicializa()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Inicializa()
        _Art_Id = ""
        _Articulos = New List(Of String)()
        _Nombre = ""
        LblMensaje.Text = ""
        Me.lblCodigo.Text = ""
        Me.Articuloslist.Items.Clear()
        Codigo = ""
        Descripcion = ""
        Tarifa = 0
        TxtCriterio.Text = ""
        asignadoCabys = False
        TotalEncontrados.Text = "0"
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub RbtDescripción_CheckedChanged(sender As Object, e As EventArgs) Handles RbtDescripción.CheckedChanged
        Try
            If RbtDescripción.Checked Then
                tipoBusqueda = 1
                RbnCodEquivalente.Checked = False
                TxtCriterio.Focus()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RbnCodEquivalente_CheckedChanged(sender As Object, e As EventArgs) Handles RbnCodEquivalente.CheckedChanged
        Try
            If RbnCodEquivalente.Checked Then
                tipoBusqueda = 2
                RbtDescripción.Checked = False
                TxtCriterio.Focus()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    'Private Sub FRMBuscquedaArticuloCabys_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    '    Select Case e.KeyCode
    '        Case Keys.F10
    '            TxtCriterio.SelectAll()
    '            TxtCriterio.Focus()
    '        Case Keys.F2
    '            AsignaCabys()
    '        Case Keys.Escape
    '            Me.Close()
    '    End Select
    'End Sub

    Private Sub BtnCabys_Click(sender As Object, e As EventArgs)
        If Codigo Is Nothing Or Codigo = "" Then
            VerificaMensaje("No se ha asignado ningun código a los articulos")
        End If
        asignarCodig()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Codigo = "" Then
            Mensaje("No se ha asignado ningun código a los articulos")
            Return
        End If
        asignarCodig()
    End Sub



    Private Sub CheckBoxCabys_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCabys.CheckedChanged
        Try
            If CheckBoxCabys.Checked Then
                asignadoCabys = True

            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


End Class