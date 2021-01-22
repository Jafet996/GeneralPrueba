Imports Business
Public Class FrmMantRecetaDetalle

#Region "Variables"
    Private Numerico() As TNumericFormat
    Private Receta As New TArticuloReceta(EmpresaInfo.Emp_Id)
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _CodigoCompuesto As String
#End Region
#Region "Propiedades"
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public ReadOnly Property GuardoCambios As Boolean
        Get
            Return _GuardoCambios
        End Get
    End Property
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(4)

            Numerico(0) = New TNumericFormat(TxtCantidad, 4, 8, False, "", "#,###0.000")
            Numerico(1) = New TNumericFormat(TxtPrecioActual, 8, 2, False, "", "#,##0.00")
            Numerico(2) = New TNumericFormat(TxtCostoCalculado, 8, 2, False, "", "#,##0.00")
            Numerico(3) = New TNumericFormat(TxtCostoMateriaPrima, 8, 2, False, "", "#,##0.00")
            Numerico(4) = New TNumericFormat(TxtPrecioIVIActual, 8, 2, False, "", "#,##0.00")
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region
    Private Sub FrmMantRecetaDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormateaCamposNumericos()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Sub Execute(pCodigo As String)
        Me.Text = _Titulo
        _GuardoCambios = False

        _CodigoCompuesto = pCodigo

        CargaInfoCompuesto()

        CargaDatos()
        LimpiaLinea()
        TxtMateriaPrima.Select()

        Me.ShowDialog()
    End Sub
    Public Sub Guardar(pMestraMensaje As Boolean)
        Dim Receta As New TArticuloReceta(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            _GuardoCambios = False

            If pMestraMensaje Then
                If DGDetalle.Rows.Count = 0 Then
                    If MsgBox("La receta no tiene ingredientes, desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End If
            End If

            Receta.Art_Id = _CodigoCompuesto

            Mensaje = Receta.BorraReceta
            VerificaMensaje(Mensaje)

            For Each row As DataGridViewRow In DGDetalle.Rows
                With Receta
                    .Ingrediente_Id = row.Cells(0).Value.ToString()
                    .Cantidad = CDbl(row.Cells(2).Value.ToString())
                End With
                Mensaje = Receta.Insert()
                VerificaMensaje(Mensaje)
            Next

            If pMestraMensaje Then
                MensajeError("La receta se almaceno de manera correcta")
            End If

            _GuardoCambios = True

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub LimpiaLinea()
        Try

            TxtNombreMateriaPrima.Text = ""
            TxtCantidad.Text = ""
            TxtCostoMateriaPrima.Text = ""


            TxtNombreMateriaPrima.Enabled = False
            TxtCantidad.Enabled = False
            TxtCostoMateriaPrima.Enabled = False

            BtnAgregar.Enabled = False

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Guardar(True)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaDatos()
        Dim Receta As New TArticuloReceta(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            Receta.Data.Clear()
            With Receta
                .Art_Id = _CodigoCompuesto
            End With

            Mensaje = Receta.ListaMateriaPrima
            VerificaMensaje(Mensaje)

            For Each det As DataRow In Receta.Data.Tables(0).Rows
                DGDetalle.Rows.Add(det.Item(2).ToString(), det.Item(5).ToString(), det.Item(3).ToString(), det.Item(6).ToString(), CDbl(det.Item(3).ToString()) * CDbl(det.Item(6).ToString()))
            Next
            calculaTotales()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Receta = Nothing
        End Try
    End Sub

    Private Sub MateriaPrima()
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try

            Articulo.Art_Id = TxtMateriaPrima.Text.Trim
            Mensaje = Articulo.ArticuloReceta()
            VerificaMensaje(Mensaje)

            If Articulo.RowsAffected = 0 Then
                TxtMateriaPrima.SelectAll()
                TxtMateriaPrima.Focus()
                VerificaMensaje("El código de artículo no existe")
            End If

            If Articulo.Activo = False Then
                TxtMateriaPrima.SelectAll()
                TxtMateriaPrima.Focus()
                VerificaMensaje("El artículo se encuentra inactivo")
            End If

            If Articulo.Compuesto Then
                TxtMateriaPrima.SelectAll()
                TxtMateriaPrima.Focus()
                VerificaMensaje("No se permiten agregar articulos compuestos a una receta")
            End If

            If Articulo.Servicio Then
                TxtMateriaPrima.SelectAll()
                TxtMateriaPrima.Focus()
                VerificaMensaje("No se permiten agregar servicios a una receta")
            End If



            TxtMateriaPrima.Enabled = False
            TxtNombreMateriaPrima.Enabled = True
            TxtCantidad.Enabled = True
            TxtCostoMateriaPrima.Enabled = True
            BtnAgregar.Enabled = True


            TxtNombreMateriaPrima.Text = Articulo.Nombre
            TxtCostoMateriaPrima.Text = Format(Articulo.Costo, "#,##0.00")
            TxtCantidad.Text = "0.00"
            TxtCantidad.Select()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub

    Private Sub CancelaIngresoArticulo()
        Try


            LimpiaLinea()
            TxtMateriaPrima.Enabled = True
            TxtMateriaPrima.Text = ""
            TxtMateriaPrima.Select()

        Catch ex As Exception
            MensajeError(EmpresaInfo.Emp_Id)
        End Try
    End Sub


    Private Sub TxtMateriaPrima_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMateriaPrima.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Dim Forma As New FrmBuscaArticuloOnLine
                Forma.Execute()
                If Forma.Art_Id.Trim <> "" Then
                    TxtMateriaPrima.Text = Forma.Art_Id.Trim
                    MateriaPrima()
                End If
                Forma = Nothing
            Case Keys.Enter
                If TxtMateriaPrima.Text.Trim <> "" Then
                    MateriaPrima()
                End If
        End Select
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If DGDetalle.Rows.Count > 0 Then
                For Each row As DataGridViewRow In DGDetalle.Rows
                    If row.Cells(0).Value.ToString() = TxtMateriaPrima.Text Then
                        MensajeError("La materia prima ya existe en la composición de la receta")
                        Return False
                    End If
                Next
            End If

            If TxtMateriaPrima.Text <= 0 Then
                Mensaje("La cantidad debe de ser mayor a cero")
                Return False
            End If

            If TxtCantidad.Text = "" Then
                Mensaje("Ingrese la cantidad")
                Return False
            End If
            If CDbl(TxtCantidad.Text) <= 0 Then
                Mensaje("La cantidad debe de ser mayor a cero")
                Return False
            End If
            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub BntAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Try
            If ValidaTodo() Then

                DGDetalle.Rows.Add(TxtMateriaPrima.Text, TxtNombreMateriaPrima.Text, CDbl(TxtCantidad.Text), CDbl(TxtCostoMateriaPrima.Text), ((CDbl(TxtCantidad.Text) * CDbl(TxtCostoMateriaPrima.Text))))
                TxtMateriaPrima.Text = ""
                TxtNombreMateriaPrima.Text = ""
                TxtCantidad.Text = ""
                TxtCantidad.Enabled = False
                TxtMateriaPrima.Enabled = True
                TxtMateriaPrima.Select()
                TxtCostoMateriaPrima.Text = "0.00"

                calculaTotales()


            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub TxtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCantidad.KeyDown
        Try
            Select Case e.KeyValue
                Case Keys.Enter
                    BtnAgregar.PerformClick()
                Case Keys.Escape
                    If Not TxtMateriaPrima.Enabled Then
                        CancelaIngresoArticulo()
                    End If
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub TxtMateriaPrima_TextChanged(sender As Object, e As EventArgs) Handles TxtMateriaPrima.TextChanged
        Try
            LimpiaLinea()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    'Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
    '    Try
    '        Limpiar()
    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    End Try
    'End Sub

    Private Sub DGDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles DGDetalle.KeyDown

        Try
            Select Case e.KeyValue
                Case Keys.Delete
                    EliminaLinea()
            End Select
        Catch ex As Exception

        End Try
    End Sub


    Private Sub EliminaLinea()
        Dim currentRow As DataGridViewRow = DGDetalle.CurrentRow
        Try

            If currentRow Is Nothing Then
                VerificaMensaje("Debe de seleccionar un ingrediente")
            End If

            DGDetalle.Rows.Remove(currentRow)
            calculaTotales()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    'Private Sub DGDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDetalle.CellDoubleClick
    '    Dim currentRow As DataGridViewRow = DGDetalle.CurrentRow
    '    Try
    '        TxtMateriaPrima.Text = ""
    '        TxtNombreMateriaPrima.Text = ""
    '        TxtCantidad.Text = ""
    '        TxtMateriaPrima.Text = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(0).Value
    '        TxtNombreMateriaPrima.Text = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(1).Value
    '        TxtCantidad.Text = DGDetalle.Rows(DGDetalle.CurrentCell.RowIndex).Cells(2).Value

    '        DGDetalle.Rows.Remove(currentRow)
    '        TxtCantidad.Enabled = True
    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    End Try
    'End Sub

    Private Sub calculaTotales()
        Dim Total As Double = 0.00
        Dim MontoGanancia As Double = 0
        Try
            For Each row As DataGridViewRow In DGDetalle.Rows
                Total = Total + CDbl(row.Cells(4).Value)
            Next
            TxtCostoCalculado.Text = Format(Total, "#,##0.00")

            MontoGanancia = CDbl(TxtPrecioActual.Text) - CDbl(TxtCostoCalculado.Text)

            If CDbl(TxtCostoCalculado.Text) <> 0 Then
                TxtUtilidadCalculada.Text = Format((MontoGanancia * 100) / CDbl(TxtCostoCalculado.Text), "#,##0.00")
            Else
                TxtUtilidadCalculada.Text = Format(100, "#,##0.00")
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmMantRecetaDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnGuardar.PerformClick()
        End Select
    End Sub

    Private Sub TxtNombreMateriaPrima_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNombreMateriaPrima.KeyDown
        Try

            Select Case e.KeyCode
                Case Keys.Escape
                    If Not TxtMateriaPrima.Enabled Then
                        CancelaIngresoArticulo()
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaInfoCompuesto()
        Dim Articulo As New TInfoArticulo(EmpresaInfo.Emp_Id)
        Try


            With Articulo
                .Suc_Id = SucursalParametroInfo.Suc_Id
                .Bod_Id = SucursalParametroInfo.BodCompra_Id
                .Art_Id = _CodigoCompuesto
            End With
            Articulo.ConsultaArticulo(-1)

            If Articulo.RowsAffected = 0 Then
                Mensaje("Articulo invalido")
            End If

            Articulo.CargaRegistroArticulo(Articulo.Data.Tables(0).Rows(0))

            TxtCostoActual.Text = Format(Articulo.Costo, "#,##0.00")
            TxtUtilidadActual.Text = Format(Articulo.Margen, "#,##0.00")
            TxtPrecioActual.Text = Format(Articulo.Precio, "#,##0.00")

            If Articulo.ExentoIV Then
                TxtPrecioIVIActual.Text = Format(Articulo.Precio, "#,##0.00")
            Else
                TxtPrecioIVIActual.Text = Format(CDbl(TxtPrecioActual.Text) * 1.13, "#,##0.00")
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub


    Private Sub TxtCostoMateriaPrima_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCostoMateriaPrima.KeyDown
        Try

            Select Case e.KeyCode
                Case Keys.Escape
                    If Not TxtMateriaPrima.Enabled Then
                        CancelaIngresoArticulo()
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnPrecio_Click(sender As Object, e As EventArgs) Handles BtnPrecio.Click
        ''Dim Forma As New FrmArticuloBodega
        'Try

        '    Guardar(False)

        '    If Not _GuardoCambios Then
        '        Exit Sub
        '    End If


        '    Forma.Art_Id = _CodigoCompuesto
        '    Forma.Execute()

        '    CargaInfoCompuesto()

        'Catch ex As Exception
        '    MensajeError(ex.Message)
        'Finally
        '    Forma = Nothing
        'End Try
    End Sub

    Private Sub BtnCosto_Click(sender As Object, e As EventArgs) Handles BtnCosto.Click
        Dim Forma As New FrmAjusteCosto
        Try

            Guardar(False)

            If Not _GuardoCambios Then
                Exit Sub
            End If

            With Forma
                .Art_Id = _CodigoCompuesto
                .Costo = IIf(IsNumeric(TxtCostoCalculado.Text), CDbl(TxtCostoCalculado.Text), 0)
            End With
            Forma.Execute()

            CargaInfoCompuesto()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
    Private Function CalculaPrecio(pCosto As Double, pMargen As Double) As Double
        Dim Precio As Double = 0

        Try
            If pMargen <= 0 Then
                Precio = pCosto
            Else
                Precio = (pCosto * ((pMargen / 100) + 1))
            End If

            Return Precio
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class