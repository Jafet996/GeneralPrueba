Imports System.IO
Imports System.Net
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Business
Imports System.Web.Script.Serialization

Public Class FrmCabys

    Private _GuardoCambios As Boolean
    Private _SucursalNuevo As Integer
    Private _selecciono As Boolean
    Private _codigo As String
    Private _Descripcion As String
    Private _Tarifa As Double
    Public ReadOnly Property Selecciono As Boolean
        Get
            Return _selecciono
        End Get
    End Property

    Public ReadOnly Property Codigo As String
        Get
            Return _codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion As String
        Get
            Return _Descripcion
        End Get
    End Property
    Public ReadOnly Property Tarifa As Double
        Get
            Return _Tarifa
        End Get
    End Property
    Public Sub Execute()
        _GuardoCambios = False
        _SucursalNuevo = 0
        _selecciono = False
        _codigo = ""
        _Descripcion = ""
        _Tarifa = 0
        Refrescar()
        Categoria1()
        Me.ShowDialog()
    End Sub

    Private Async Sub llenarTabla()

        Dim Http As New HttpClient()
        Dim Serializer As New JavaScriptSerializer()
        Dim Url As String = InfoMaquina.URLCoreAPI & "/api/cabys/codigos"
        Dim pObjeto As New TCabys()
        Dim pObjetoCabys As New TcabysLIst()
        Dim Items(10) As String
        Dim Item As ListViewItem = Nothing

        Dim cat1 As String = DirectCast(Cmbcate1.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim cat2 As String = DirectCast(Cmbcate2.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim cat3 As String = DirectCast(Cmbcate3.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim cat4 As String = DirectCast(Cmbcate4.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim cat5 As String = DirectCast(Cmbcate5.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim cat6 As String = DirectCast(Cmbcate6.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim cat7 As String = DirectCast(Cmbcate7.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim cat8 As String = DirectCast(Cmbcate8.SelectedItem, KeyValuePair(Of String, String)).Key

        Serializer.MaxJsonLength = Int32.MaxValue

        pObjeto.Descripcion = Me.txtcodigo.Text
        pObjeto.Categorias = New List(Of String)
        pObjeto.Id = "SD_Emisor_" & EmpresaParametroInfo.Emisor_Id.ToString

        If cat1 <> "-1" Then
            pObjeto.Categorias.Add(cat1)
        End If


        If cat2 <> "-1" Then
            pObjeto.Categorias.Add(cat2)
        End If

        If cat3 <> "-1" Then
            pObjeto.Categorias.Add(cat3)
        End If

        If cat4 <> "-1" Then
            pObjeto.Categorias.Add(cat4)
        End If

        If cat5 <> "-1" Then
            pObjeto.Categorias.Add(cat5)
        End If

        If cat6 <> "-1" Then
            pObjeto.Categorias.Add(cat6)
        End If

        If cat7 <> "-1" Then
            pObjeto.Categorias.Add(cat7)
        End If

        If cat8 <> "-1" Then
            pObjeto.Categorias.Add(cat8)
        End If


        If pObjeto.Descripcion <> "" Or pObjeto.Categorias.Count <> 0 Then
            Dim Json = Serializer.Serialize(pObjeto)
            Dim Content = New StringContent(Json, Encoding.UTF8, "application/json")
            Dim HttpResponse = Await Http.PostAsync(Url, Content)
            If HttpResponse.IsSuccessStatusCode Then
                Dim Body = Await HttpResponse.Content.ReadAsStringAsync
                pObjetoCabys = Serializer.Deserialize(Of TcabysLIst)(Body)
            End If

            Try
                Productos.Items.Clear()
                For Each Fila In pObjetoCabys.result
                    Items(ColumnasLista.Codigo) = Fila.codigo
                    Items(ColumnasLista.Descripcion) = Fila.descripcion
                    Items(ColumnasLista.Categoria1) = Fila.descripcionCategoria_1
                    Items(ColumnasLista.Categoria2) = Fila.descripcionCategoria_2
                    Items(ColumnasLista.Categoria3) = Fila.descripcionCategoria_3
                    Items(ColumnasLista.Categoria4) = Fila.descripcionCategoria_4
                    Items(ColumnasLista.Categoria5) = Fila.descripcionCategoria_5
                    Items(ColumnasLista.Categoria6) = Fila.descripcionCategoria_6
                    Items(ColumnasLista.Categoria7) = Fila.descripcionCategoria_7
                    Items(ColumnasLista.Categoria8) = Fila.descripcionCategoria_8

                    Item = New ListViewItem(Items)
                    Productos.Items.Add(Item)

                Next
                Productos.Columns(1).Width = 305

            Catch ex As Exception
            Finally

            End Try
        End If



    End Sub

    Private Sub Categoria1()
        Dim Serializer As New JavaScriptSerializer()
        Dim request As WebRequest =
              WebRequest.Create(InfoMaquina.URLCoreAPI & "/api/cabys/categorias?categoria_Id=")
        request.Credentials = CredentialCache.DefaultCredentials
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        Using dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim pObjeto As New TobjectCategoria()
            Dim responseFromServer As String = reader.ReadToEnd()
            pObjeto = Serializer.Deserialize(Of TobjectCategoria)(responseFromServer)
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("-1", "Seleccione una categoria")
            For Each Fila In pObjeto.result
                comboSource.Add(Fila.categoria_id, Fila.descripcion)
            Next
            Cmbcate1.DataSource = New BindingSource(comboSource, Nothing)
            Cmbcate1.DisplayMember = "Value"
            Cmbcate1.ValueMember = "Key"
        End Using
        response.Close()
    End Sub
    Private Sub Categoria2(cate_id As Long)
        Dim Serializer As New JavaScriptSerializer()
        Dim request As WebRequest =
              WebRequest.Create(InfoMaquina.URLCoreAPI & "/api/cabys/categorias?categoria_Id=" & cate_id)
        request.Credentials = CredentialCache.DefaultCredentials
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        Using dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim pObjeto As New TobjectCategoria()
            Dim responseFromServer As String = reader.ReadToEnd()
            pObjeto = Serializer.Deserialize(Of TobjectCategoria)(responseFromServer)
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("-1", "Seleccione una categoria")
            For Each Fila In pObjeto.result
                comboSource.Add(Fila.categoria_id, Fila.descripcion)
            Next
            Cmbcate2.DataSource = New BindingSource(comboSource, Nothing)
            Cmbcate2.DisplayMember = "Value"
            Cmbcate2.ValueMember = "Key"
        End Using
        response.Close()
    End Sub
    Private Sub Categoria3(cate_id As Long)
        Dim Serializer As New JavaScriptSerializer()
        Dim request As WebRequest =
              WebRequest.Create(InfoMaquina.URLCoreAPI & "/api/cabys/categorias?categoria_Id=" & cate_id)
        request.Credentials = CredentialCache.DefaultCredentials
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        Using dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim pObjeto As New TobjectCategoria()
            Dim responseFromServer As String = reader.ReadToEnd()
            pObjeto = Serializer.Deserialize(Of TobjectCategoria)(responseFromServer)
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("-1", "Seleccione una categoria")
            For Each Fila In pObjeto.result
                comboSource.Add(Fila.categoria_id, Fila.descripcion)
            Next
            Cmbcate3.DataSource = New BindingSource(comboSource, Nothing)
            Cmbcate3.DisplayMember = "Value"
            Cmbcate3.ValueMember = "Key"
        End Using
        response.Close()
    End Sub

    Private Sub Categoria4(cate_id As Long)
        Dim Serializer As New JavaScriptSerializer()
        Dim request As WebRequest =
              WebRequest.Create(InfoMaquina.URLCoreAPI & "/api/cabys/categorias?categoria_Id=" & cate_id)
        request.Credentials = CredentialCache.DefaultCredentials
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        Using dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim pObjeto As New TobjectCategoria()
            Dim responseFromServer As String = reader.ReadToEnd()
            pObjeto = Serializer.Deserialize(Of TobjectCategoria)(responseFromServer)
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("-1", "Seleccione una categoria")
            For Each Fila In pObjeto.result
                comboSource.Add(Fila.categoria_id, Fila.descripcion)
            Next
            Cmbcate4.DataSource = New BindingSource(comboSource, Nothing)
            Cmbcate4.DisplayMember = "Value"
            Cmbcate4.ValueMember = "Key"
        End Using
        response.Close()
    End Sub
    Private Sub Categoria5(cate_id As Long)
        Dim Serializer As New JavaScriptSerializer()
        Dim request As WebRequest =
              WebRequest.Create(InfoMaquina.URLCoreAPI & "/api/cabys/categorias?categoria_Id=" & cate_id)
        request.Credentials = CredentialCache.DefaultCredentials
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        Using dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim pObjeto As New TobjectCategoria()
            Dim responseFromServer As String = reader.ReadToEnd()
            pObjeto = Serializer.Deserialize(Of TobjectCategoria)(responseFromServer)
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("-1", "Seleccione una categoria")
            For Each Fila In pObjeto.result
                comboSource.Add(Fila.categoria_id, Fila.descripcion)
            Next
            Cmbcate5.DataSource = New BindingSource(comboSource, Nothing)
            Cmbcate5.DisplayMember = "Value"
            Cmbcate5.ValueMember = "Key"
        End Using
        response.Close()
    End Sub
    Private Sub Categoria6(cate_id As Long)
        Dim Serializer As New JavaScriptSerializer()
        Dim request As WebRequest =
              WebRequest.Create(InfoMaquina.URLCoreAPI & "/api/cabys/categorias?categoria_Id=" & cate_id)
        request.Credentials = CredentialCache.DefaultCredentials
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        Using dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim pObjeto As New TobjectCategoria()
            Dim responseFromServer As String = reader.ReadToEnd()
            pObjeto = Serializer.Deserialize(Of TobjectCategoria)(responseFromServer)
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("-1", "Seleccione una categoria")
            For Each Fila In pObjeto.result
                comboSource.Add(Fila.categoria_id, Fila.descripcion)
            Next
            Cmbcate6.DataSource = New BindingSource(comboSource, Nothing)
            Cmbcate6.DisplayMember = "Value"
            Cmbcate6.ValueMember = "Key"
        End Using
        response.Close()
    End Sub
    Private Sub Categoria7(cate_id As Long)
        Dim Serializer As New JavaScriptSerializer()
        Dim request As WebRequest =
              WebRequest.Create(InfoMaquina.URLCoreAPI & "/api/cabys/categorias?categoria_Id=" & cate_id)
        request.Credentials = CredentialCache.DefaultCredentials
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        Using dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim pObjeto As New TobjectCategoria()
            Dim responseFromServer As String = reader.ReadToEnd()
            pObjeto = Serializer.Deserialize(Of TobjectCategoria)(responseFromServer)
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("-1", "Seleccione una categoria")
            For Each Fila In pObjeto.result
                comboSource.Add(Fila.categoria_id, Fila.descripcion)
            Next
            Cmbcate7.DataSource = New BindingSource(comboSource, Nothing)
            Cmbcate7.DisplayMember = "Value"
            Cmbcate7.ValueMember = "Key"
        End Using
        response.Close()
    End Sub
    Private Sub Categoria8(cate_id As Long)
        Dim Serializer As New JavaScriptSerializer()
        Dim request As WebRequest =
              WebRequest.Create(InfoMaquina.URLCoreAPI & "/api/cabys/categorias?categoria_Id=" & cate_id)
        request.Credentials = CredentialCache.DefaultCredentials
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        Using dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim pObjeto As New TobjectCategoria()
            Dim responseFromServer As String = reader.ReadToEnd()
            pObjeto = Serializer.Deserialize(Of TobjectCategoria)(responseFromServer)
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("-1", "Seleccione una categoria")
            For Each Fila In pObjeto.result
                comboSource.Add(Fila.categoria_id, Fila.descripcion)
            Next
            Cmbcate8.DataSource = New BindingSource(comboSource, Nothing)
            Cmbcate8.DisplayMember = "Value"
            Cmbcate8.ValueMember = "Key"
        End Using
        response.Close()
    End Sub
    Private Sub Refrescar()

    End Sub
    Private Enum ColumnasLista
        Codigo = 0
        Descripcion = 1
        Categoria1 = 2
        Categoria2 = 3
        Categoria3 = 4
        Categoria4 = 5
        Categoria5 = 6
        Categoria6 = 7
        Categoria7 = 8
        Categoria8 = 9
    End Enum

    Private Sub Cmbcate1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmbcate1.SelectedIndexChanged
        Dim key As String = DirectCast(Cmbcate1.SelectedItem, KeyValuePair(Of String, String)).Key
        Categoria2(Long.Parse(key))
        'If key <> "-1" Then
        '    llenarTabla()
        'End If
    End Sub
    Private Sub Cmbcate2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmbcate2.SelectedIndexChanged
        Dim key As String = DirectCast(Cmbcate2.SelectedItem, KeyValuePair(Of String, String)).Key
        Categoria3(Long.Parse(key))
        'If key <> "-1" Then
        '    llenarTabla()
        'End If
    End Sub

    Private Sub Cmbcate3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmbcate3.SelectedIndexChanged
        Dim key As String = DirectCast(Cmbcate3.SelectedItem, KeyValuePair(Of String, String)).Key
        Categoria4(Long.Parse(key))
        'If key <> "-1" Then
        '    llenarTabla()
        'End If
    End Sub

    Private Sub Cmbcate4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmbcate4.SelectedIndexChanged
        Dim key As String = DirectCast(Cmbcate4.SelectedItem, KeyValuePair(Of String, String)).Key
        Categoria5(Long.Parse(key))
        'If key <> "-1" Then
        '    llenarTabla()
        'End If
    End Sub

    Private Sub Cmbcate5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmbcate5.SelectedIndexChanged
        Dim key As String = DirectCast(Cmbcate5.SelectedItem, KeyValuePair(Of String, String)).Key
        Categoria6(Long.Parse(key))
        'If key <> "-1" Then
        '    llenarTabla()
        'End If
    End Sub

    Private Sub Cmbcate6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmbcate6.SelectedIndexChanged
        Dim key As String = DirectCast(Cmbcate6.SelectedItem, KeyValuePair(Of String, String)).Key
        Categoria7(Long.Parse(key))
        'If key <> "-1" Then
        '    llenarTabla()
        'End If
    End Sub

    Private Sub Cmbcate7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmbcate7.SelectedIndexChanged
        Dim key As String = DirectCast(Cmbcate7.SelectedItem, KeyValuePair(Of String, String)).Key
        Categoria8(Long.Parse(key))
        'If key <> "-1" Then
        '    llenarTabla()
        'End If
    End Sub

    Private Sub Cmbcate8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmbcate8.SelectedIndexChanged
        Dim key As String = DirectCast(Cmbcate8.SelectedItem, KeyValuePair(Of String, String)).Key
        'If key <> "-1" Then
        '    llenarTabla()
        'End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Se ha asignado el codigo")
    End Sub

    Private Sub FrmCabys_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Me.Close()

    End Sub

    Private Sub Productos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Productos.DoubleClick
        Seleccionar()
    End Sub
    Private Sub Seleccionar()
        Try
            If Productos.SelectedItems Is Nothing Then
                VerificaMensaje("Debe de seleccionar un valor")
            End If
            _codigo = Productos.SelectedItems.Item(0).SubItems(0).Text
            _Descripcion = Productos.SelectedItems.Item(0).SubItems(1).Text
            _selecciono = True
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub txtcodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcodigo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                llenarTabla()
        End Select
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        llenarTabla()
    End Sub
End Class