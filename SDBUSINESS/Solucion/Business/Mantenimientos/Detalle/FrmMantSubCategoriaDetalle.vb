Imports System.Windows.Forms
Imports Business
Public Class FrmMantSubCategoriaDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)
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
    Private Sub CargaCombos()
        Dim Categoria As New TCategoria(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = ""
        Try
            Mensaje = Categoria.LoadComboBox(CmbCategoria)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Categoria = Nothing
        End Try
    End Sub
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaDatos()
        Dim Mensaje As String = ""
        Try
            SubCategoria.Cat_Id = CmbCategoria.SelectedValue
            SubCategoria.SubCat_Id = CInt(TxtNumero.Text)
            Mensaje = SubCategoria.ListKey()
            VerificaMensaje(Mensaje)

            TxtNombre.Text = SubCategoria.Nombre
            ChkActivo.Checked = SubCategoria.Activo
            ChkBusquedaRapida.Checked = SubCategoria.BusquedaRapida


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(pCategoria_Id As Integer, pCodigo As Integer)
        Me.Text = _Titulo
        _GuardoCambios = False

        CargaCombos()

        If Not _Nuevo Then
            CmbCategoria.SelectedValue = pCategoria_Id
            CmbCategoria.Enabled = False
            CmbCategoria.TabStop = False
            TxtNumero.Text = pCodigo
            CargaDatos()
        End If

        TxtNumero.Focus()

        Me.ShowDialog()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantSubCategoriaDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
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


            SubCategoria.Cat_Id = CmbCategoria.SelectedValue
            If _Nuevo Then
                Mensaje = SubCategoria.Siguiente()
                VerificaMensaje(Mensaje)
            Else
                SubCategoria.SubCat_Id = CInt(TxtNumero.Text)
            End If

            With SubCategoria
                .Nombre = TxtNombre.Text
                .Activo = ChkActivo.Checked
                .BusquedaRapida = ChkBusquedaRapida.Checked
            End With

            If _Nuevo Then
                Mensaje = SubCategoria.Insert()
            Else
                Mensaje = SubCategoria.Modify()
            End If

            _GuardoCambios = True

            MsgBox("Los cambios se almacenaron correctamente", MsgBoxStyle.Information, Me.Text)

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
End Class