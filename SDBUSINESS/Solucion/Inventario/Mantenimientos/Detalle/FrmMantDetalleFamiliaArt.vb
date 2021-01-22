Imports Business
Public Class FrmMantDetalleFamiliaArt
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private Familia As New TArticuloFamilia(EmpresaInfo.Emp_Id)
    Private _Titulo As String
    Private _GuardoCambios As Boolean
    Private _Nuevo As Boolean
#End Region
#Region "Propiedades"
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public WriteOnly Property Nuevo As Boolean
        Set(value As Boolean)
            _Nuevo = value
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
            ReDim Numerico(3)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaDatos()
        Dim Mensaje As String = ""
        Try
            Familia.Familia_Id = CInt(TxtNumero.Text)
            Mensaje = Familia.ListKey()
            VerificaMensaje(Mensaje)

            With Familia
                TxtNombre.Text = .Nombre
                ChkActivo.Checked = .Activo
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(pCodigo As Integer)
        Me.Text = _Titulo
        _GuardoCambios = False

        If Not _Nuevo Then
            TxtNumero.Text = pCodigo.ToString()
            CargaDatos()
        End If

        TxtNumero.Focus()

        Me.ShowDialog()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantCategoriaDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F1
                If TxtNumero.Text <> "" Then
                    Dim Forma As New FrmBuscaArticuloOnLine
                    Forma.Execute()
                    If ValidarArticulo(Forma.Art_Id.Trim) Then
                        AgregarArt(Forma.Art_Id.Trim)
                        Refrescar()
                    End If
                    Forma = Nothing
                Else
                End If
        End Select
    End Sub
    Private Function ValidaTodo() As Boolean
        Try
            If TxtNombre.Text.Trim = "" Then
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        If ValidaTodo() Then
            Guardar()
        End If
    End Sub
    Private Sub Guardar()
        Dim Mensaje As String = ""
        Try

            If _Nuevo Then
                Mensaje = Familia.Siguiente()
                VerificaMensaje(Mensaje)
            Else
                Familia.Familia_Id = CInt(TxtNumero.Text)
            End If

            With Familia
                .Nombre = TxtNombre.Text
                .Activo = ChkActivo.Checked
            End With

            If _Nuevo Then
                Mensaje = Familia.Insert()
            Else
                Mensaje = Familia.Modify()
            End If

            _GuardoCambios = True

            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub FrmMantBancoDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtNombre.Select()
        If (TxtNumero.Text <> "") Then
            Refrescar()
        End If
    End Sub
    Private Sub BntArticulo_Click(sender As Object, e As EventArgs) Handles BntArticulo.Click
        If TxtNumero.Text <> "" Then
            Dim Forma As New FrmBuscaArticuloOnLine
            Forma.Execute()
            If ValidarArticulo(Forma.Art_Id.Trim) Then
                AgregarArt(Forma.Art_Id.Trim)
                Refrescar()
            End If
            Forma = Nothing
        End If
    End Sub
    Private Sub FrmMantDetalleFamiliaArt_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub
    Private Sub Refrescar()
        Dim FamiliaDetalle As New TArticuloFamiliaDetalle(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            With FamiliaDetalle
                .Familia_Id = TxtNumero.Text
            End With

            DGDetalle.DataSource = Nothing

            Mensaje = FamiliaDetalle.DetalleMantenimiento()
            VerificaMensaje(Mensaje)

            DGDetalle.DataSource = FamiliaDetalle.Data.Tables(0)

            DGDetalle.Columns(0).HeaderText = "Código"
            DGDetalle.Columns(1).HeaderText = "Nombre"
            DGDetalle.Columns(0).Width = 100
            DGDetalle.Columns(1).Width = 345

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FamiliaDetalle = Nothing
        End Try
    End Sub
    Private Sub AgregarArt(pArt_Id As String)
        Dim FamiliaDetalle As New TArticuloFamiliaDetalle(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            With FamiliaDetalle
                .Familia_Id = TxtNumero.Text
                .Art_Id = pArt_Id
            End With
            Mensaje = FamiliaDetalle.Insert()
            VerificaMensaje(Mensaje)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FamiliaDetalle = Nothing
        End Try
    End Sub
    Private Function ValidarArticulo(pArt_Id As String) As Boolean

        Try
            For Each Fila In DGDetalle.Rows.Cast(Of DataGridViewRow)()
                If pArt_Id = Fila.Cells(0).Value.ToString() Then
                    VerificaMensaje("El artículo ya exite dentro de la familia " + TxtNombre.Text)
                End If
            Next
            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub DGDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles DGDetalle.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                Dim msg As String =
                        String.Format("¿Desea eliminar el artiículo '{0}'?", DGDetalle.CurrentRow.Cells(1).Value)

                If (MessageBox.Show(msg, "Eliminar artículo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                    Eliminar(Convert.ToString(DGDetalle.CurrentRow.Cells(0).Value))
                    Refrescar()
                End If
                Refrescar()
        End Select
    End Sub

    Public Sub Eliminar(pArt_id As String)
        Dim FamiliaDetalle As New TArticuloFamiliaDetalle(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            With FamiliaDetalle
                .Familia_Id = TxtNumero.Text
                .Art_Id = pArt_id
            End With
            Mensaje = FamiliaDetalle.Delete()
            VerificaMensaje(Mensaje)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
        End Try
    End Sub
End Class