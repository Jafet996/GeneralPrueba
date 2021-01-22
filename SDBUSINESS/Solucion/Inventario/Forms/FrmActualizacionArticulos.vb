Imports Business
Imports System.IO
Imports System.Text

Public Class FrmActualizacionArticulos
    Public Sub Execute()
        CargaComboBodega()

        Me.ShowDialog()
    End Sub

    Private Sub CargaComboBodega()
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)

        Try
            Bodega.Suc_Id = SucursalInfo.Suc_Id
            VerificaMensaje(Bodega.LoadComboBox(CmbBodega))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Bodega = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtRuta.Text.Trim = "" Then
                VerificaMensaje("Debe de seleccionar la ruta del archivo.")
                BtnRuta.PerformClick()
            End If

            If CmbBodega.SelectedIndex = -1 Then
                VerificaMensaje("Debe de seleccionar una bodega.")
                CmbBodega.SelectedIndex = 0
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Generar()
        If ValidaTodo() Then
            GenerarArchivo()
        End If
    End Sub

    Private Function CargaCategoria(Valores() As String) As String
        Dim Categoria As New TCategoria(EmpresaInfo.Emp_Id)

        Try
            With Categoria
                .Emp_Id = CInt(Valores(1))
                .Cat_Id = CInt(Valores(2))
                .Nombre = Valores(3)
                .Activo = IIf(Valores(4) = "True", 1, 0)
                .BusquedaRapida = IIf(Valores(5) = "True", 1, 0)
                .UltimaModificacion = Valores(6)
            End With

            VerificaMensaje(Categoria.Modify)

            If Categoria.RowsAffected = 0 Then
                VerificaMensaje(Categoria.Insert)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Private Function CargaSubCategorias(Valores() As String)
        Dim SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)

        Try
            With SubCategoria
                .Emp_Id = CInt(Valores(1))
                .Cat_Id = CInt(Valores(2))
                .SubCat_Id = CInt(Valores(3))
                .Nombre = Valores(4)
                .Activo = IIf(Valores(5) = "True", 1, 0)
                .BusquedaRapida = IIf(Valores(6) = "True", 1, 0)
                .UltimaModificacion = Valores(7)
            End With

            VerificaMensaje(SubCategoria.Modify)

            If SubCategoria.RowsAffected = 0 Then
                VerificaMensaje(SubCategoria.Insert)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function CargaDepartamento(Valores() As String)
        Dim Departamento As New TDepartamento(EmpresaInfo.Emp_Id)

        Try
            With Departamento
                .Emp_Id = CInt(Valores(1))
                .Departamento_Id = CInt(Valores(2))
                .Nombre = Valores(3)
                .Activo = IIf(Valores(4) = "True", 1, 0)
                .UltimaModificacion = Valores(5)
            End With

            VerificaMensaje(Departamento.Modify)

            If Departamento.RowsAffected = 0 Then
                VerificaMensaje(Departamento.Insert)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function CargaTipoAcumulacion(Valores() As String)
        Dim TipoAcumulacion As New TTipoAcumulacion(EmpresaInfo.Emp_Id)

        Try
            With TipoAcumulacion
                .Emp_Id = CInt(Valores(1))
                .TipoAcumulacion_Id = CInt(Valores(2))
                .Nombre = Valores(3)
                .Factor = Valores(4)
                .Activo = IIf(Valores(5) = "True", 1, 0)
            End With

            VerificaMensaje(TipoAcumulacion.Modify)

            If TipoAcumulacion.RowsAffected = 0 Then
                VerificaMensaje(TipoAcumulacion.Insert)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function CargaUnidadMedida(Valores()) As String
        Dim UnidadMedida As New TUnidadMedida(EmpresaInfo.Emp_Id)

        Try
            With UnidadMedida
                .Emp_Id = CInt(Valores(1))
                .UnidadMedida_Id = CInt(Valores(2))
                .Nombre = Valores(3)
                .Activo = IIf(Valores(4) = "True", 1, 0)
                .UltimaModificacion = Valores(5)
            End With

            VerificaMensaje(UnidadMedida.Modify)

            If UnidadMedida.RowsAffected = 0 Then
                VerificaMensaje(UnidadMedida.Insert)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function CargaArticulo(Valores() As String)
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)

        Try
            With Articulo
                .Emp_Id = CInt(Valores(1))
                .Art_Id = Valores(2)
                .Nombre = Valores(3)
                .Cat_Id = CInt(Valores(4))
                .SubCat_Id = CInt(Valores(5))
                .Departamento_Id = CInt(Valores(6))
                .UnidadMedida_Id = CInt(Valores(7))
                .FactorConversion = CInt(Valores(8))
                .ExentoIV = IIf(Valores(9) = "True", 1, 0)
                .Suelto = IIf(Valores(10) = "True", 1, 0)
                .ArtPadre = Valores(11)
                .SolicitarCantidad = IIf(Valores(12) = "True", 1, 0)
                .PermiteFacturar = IIf(Valores(13) = "True", 1, 0)
                .CodigoCantidad = IIf(Valores(14) = "True", 1, 0)
                .CodigoCantidadTipo = CInt(Valores(15))
                .BusquedaRapida = IIf(Valores(16) = "True", 1, 0)
                .Frecuente = IIf(Valores(17) = "True", 1, 0)
                .Servicio = IIf(Valores(18) = "True", 1, 0)
                .TipoAcumulacion_Id = CInt(Valores(19))
                .Activo = IIf(Valores(20) = "True", 1, 0)
                .UltimaModificacion = Valores(21)
            End With

            VerificaMensaje(Articulo.Modifica)

            If Articulo.RowsAffected = 0 Then
                VerificaMensaje(Articulo.Insert)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function CargaArticuloBodega(Valores() As String)
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)

        Try



            With ArticuloBodega
                '.Emp_Id = CInt(Valores(1))
                '.Suc_Id = CInt(Valores(2))
                '.Bod_Id = CInt(Valores(3))
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = 1
                .Art_Id = Valores(4)
                .CostoPromedio = CDbl(Valores(5))
                .Costo = CDbl(Valores(6))
                .Margen = CDbl(Valores(7))
                .MargenMayorista = CDbl(Valores(8))
                .Precio = CDbl(Valores(9))
                .PrecioMayorista = CDbl(Valores(10))
                .FechaIniDescuento = Valores(11)
                .FechaFinDescuento = Valores(12)
                .PorcDescuento = CDbl(Valores(13))
                .Minimo = Valores(14)
                .Maximo = Valores(15)
                .Activo = IIf(Valores(16) = "True", 1, 0)
                .UltimaModificacion = Valores(17)
                .Margen3 = Valores(18)
                .Margen4 = Valores(19)
                .Margen5 = Valores(20)
                .Precio3 = Valores(21)
                .Precio4 = Valores(22)
                .Precio5 = Valores(23)

            End With

            VerificaMensaje(ArticuloBodega.Modifica)

            If ArticuloBodega.RowsAffected = 0 Then
                VerificaMensaje(ArticuloBodega.Insert)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub GenerarArchivo()
        Dim Categoria As New TCategoria(EmpresaInfo.Emp_Id)
        Dim SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)
        Dim Departamento As New TDepartamento(EmpresaInfo.Emp_Id)
        Dim TipoAcumulacion As New TTipoAcumulacion(EmpresaInfo.Emp_Id)
        Dim UnidadMedida As New TUnidadMedida(EmpresaInfo.Emp_Id)
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Archivo = Nothing
        Dim Lista As String = ""
        Dim info As Byte()

        Try
            VerificaMensaje(Categoria.ListaCompleta)
            VerificaMensaje(SubCategoria.ListaCompleta)
            VerificaMensaje(Departamento.ListaCompleta)
            VerificaMensaje(TipoAcumulacion.ListaCompleta)
            VerificaMensaje(UnidadMedida.ListaCompleta)
            VerificaMensaje(Articulo.ListaCompleta)


            With ArticuloBodega
                .Suc_Id = SucursalInfo.Suc_Id
                .Bod_Id = CmbBodega.SelectedValue
            End With
            VerificaMensaje(ArticuloBodega.ListxBodega)

            Archivo = New FileStream(TxtRuta.Text.Trim, FileMode.Append, FileAccess.Write)

            Lista = CreaRegistroArchivo(coCategoria, Categoria.Data.Tables(0)) &
                                                   CreaRegistroArchivo(coSubCategoria, SubCategoria.Data.Tables(0)) &
                                                   CreaRegistroArchivo(coDepartamento, Departamento.Data.Tables(0)) &
                                                   CreaRegistroArchivo(coTipoAcumulacion, TipoAcumulacion.Data.Tables(0)) &
                                                   CreaRegistroArchivo(coUnidadMedida, UnidadMedida.Data.Tables(0)) &
                                                   CreaRegistroArchivo(coArticulo, Articulo.Data.Tables(0)) &
                                                   CreaRegistroArchivo(coArticuloBodega, ArticuloBodega.Data.Tables(0))

            info = New UTF8Encoding(True).GetBytes(Lista)

            Archivo.Write(info, 0, info.Length)
            Archivo.Close()

            MsgBox("El archivo se generó correctamente en la ruta seleccionada.")
            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Categoria = Nothing
            SubCategoria = Nothing
            Departamento = Nothing
            TipoAcumulacion = Nothing
            UnidadMedida = Nothing
            Articulo = Nothing
            ArticuloBodega = Nothing
        End Try
    End Sub

    Private Sub GuardaLog(pTipo As String, pError As String)
        Dim Items(1) As String
        Dim Item As ListViewItem

        Try
            Items(0) = pTipo
            Items(1) = pError

            Item = New ListViewItem(Items)

            LvwLog.Items.Add(Item)
        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub CargarArchivo()
        Dim Item As ListViewItem = Nothing
        Dim Valores() As String
        Dim Resultado As Boolean = True
        Dim Mensaje As String = ""

        OpenF.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        OpenF.FilterIndex = 1
        OpenF.RestoreDirectory = True
        OpenF.FileName = String.Empty

        If OpenF.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If (OpenF.OpenFile() IsNot Nothing) Then

                Panel1.Enabled = False
                Cursor = Cursors.WaitCursor

                Using sr As StreamReader = New StreamReader(OpenF.FileName)
                    Dim line As String

                    line = sr.ReadLine()
                    While (line <> Nothing)

                        Valores = line.Split("|")

                        Select Case Valores(0)

                            Case coCategoria
                                Mensaje = CargaCategoria(Valores)

                            Case coSubCategoria
                                Mensaje = CargaSubCategorias(Valores)

                            Case coDepartamento
                                Mensaje = CargaDepartamento(Valores)

                            Case coTipoAcumulacion
                                Mensaje = CargaTipoAcumulacion(Valores)

                            Case coUnidadMedida
                                Mensaje = CargaUnidadMedida(Valores)

                            Case coArticulo
                                Mensaje = CargaArticulo(Valores)

                            Case coArticuloBodega
                                Mensaje = CargaArticuloBodega(Valores)

                        End Select

                        If Mensaje <> String.Empty Then
                            GuardaLog(Valores(0), Mensaje)
                            Mensaje = String.Empty
                        End If

                        line = sr.ReadLine()
                    End While
                End Using
            End If

            If (OpenF.OpenFile() IsNot Nothing) Then
                OpenF.OpenFile().Close()
            End If

            Panel1.Enabled = True
            Cursor = Cursors.Default

            MsgBox("Se ha cargado y aplicado el archivo seleccionado")
            'Me.Close()

        End If
    End Sub

    Private Sub BtnRuta_Click(sender As Object, e As EventArgs) Handles BtnRuta.Click
        Try

            ' Displays a SaveFileDialog so the user can save the Image
            ' assigned to Button2.
            SaveF.Filter = "Text File|*.txt"
            SaveF.Title = "Save an text File"
            SaveF.ShowDialog()

            ' If the file name is not an empty string open it for saving.
            If SaveF.FileName <> "" Then
                ' Saves the Image via a FileStream created by the OpenFile method.
                Dim fs As System.IO.FileStream = CType(SaveF.OpenFile(), System.IO.FileStream)
                ' Saves the Image in the appropriate ImageFormat based upon the
                ' file type selected in the dialog box.
                ' NOTE that the FilterIndex property is one-based.
                Select Case SaveF.FilterIndex
                    Case 1
                        TxtRuta.Text = SaveF.FileName
                End Select

                fs.Close()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnGenerar_Click(sender As Object, e As EventArgs) Handles BtnGenerar.Click
        Generar()
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        Try
            CargarArchivo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmActualizacionArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                Generar()
            Case Keys.F8
                Try
                    CargarArchivo()
                Catch ex As Exception

                End Try
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class