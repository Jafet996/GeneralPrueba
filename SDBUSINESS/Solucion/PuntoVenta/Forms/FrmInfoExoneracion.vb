Imports Business
Public Class FrmInfoExoneracion
    Dim Numerico() As TNumericFormat
    Private _Acepto As Boolean
    Private _Exoneracion As New TFacturaExoneracion(EmpresaInfo.Emp_Id)

    Public ReadOnly Property Acepto As Boolean
        Get
            Return _Acepto
        End Get
    End Property
    Public Property Exoneracion As TFacturaExoneracion
        Get
            Return _Exoneracion
        End Get
        Set(value As TFacturaExoneracion)
            _Exoneracion = value
        End Set
    End Property
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(1)

            Numerico(0) = New TNumericFormat(txtPorc, 3, 0, False, "", "##0")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Sub Execute()
        Try

            _Acepto = False

            CargaCombo()
            cmbTipoDoc.SelectedValue = "01"

            FormateaCamposNumericos()

            If _Exoneracion.TipoDocumento.Trim <> String.Empty Then
                cmbTipoDoc.SelectedValue = _Exoneracion.TipoDocumento
            End If

            If _Exoneracion.NumeroDocumento.Trim <> String.Empty Then
                txtNumDoc.Text = _Exoneracion.NumeroDocumento
            End If

            If _Exoneracion.NombreInstitucion.Trim <> String.Empty Then
                txtNombre.Text = _Exoneracion.NombreInstitucion
            End If

            If _Exoneracion.FechaEmision <> #01/01/1900# Then
                dpFecha.Value = DateValue(_Exoneracion.FechaEmision)
            End If


            txtNumDoc.SelectAll()

            Me.ShowDialog()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaCombo()
        Dim TipoDoc As New TTipoExoneracion()
        Dim Mensaje As String

        Try
            Mensaje = TipoDoc.LoadComboBox(cmbTipoDoc)
            VerificaMensaje(Mensaje)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub FrmInfoExoneracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dpFecha.Value = EmpresaInfo.Getdate()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try

            If cmbTipoDoc.SelectedValue = -1 Then
                VerificaMensaje("Debe de seleccionar tipo de documento de exoneración")
            End If

            If txtNumDoc.Text = "" Then
                txtNombre.Select()
                VerificaMensaje("Debe de ingresar el número de documento de exoneración")
            End If

            If txtNombre.Text = "" Then
                txtNombre.Select()
                VerificaMensaje("Debe de ingresar el nombre de la institución")
            End If

            If dpFecha.Value > EmpresaInfo.Getdate() Then
                VerificaMensaje("La fecha de emisión no puede ser mayor a fecha actual")
            End If

            If Not IsNumeric(txtPorc.Text) Then
                VerificaMensaje("Debe de digitar un porcentaje de exoneración")
            End If
            If CDbl(txtPorc.Text) < 0 Then
                VerificaMensaje("El porcentaje de exoneración debe de ser mayor o igual a cero")
            End If

            If CDbl(txtPorc.Text) > 100 Then
                txtPorc.Select()
                VerificaMensaje("El porcentaje de exoneración debe de ser menor a cien")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function
    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Try
            If ValidaTodo() Then

                ' retornar objeto
                _Exoneracion.TipoDocumento = cmbTipoDoc.SelectedValue
                _Exoneracion.NombreInstitucion = txtNombre.Text.Trim()
                _Exoneracion.NumeroDocumento = txtNumDoc.Text.Trim()
                _Exoneracion.FechaEmision = DateValue(dpFecha.Value)
                _Exoneracion.PorcentajeExoneracion = txtPorc.Text.Trim()
                _Acepto = True

                Me.Close()
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        _Acepto = False
        Me.Close()
    End Sub
    Private Sub FrmArticuloPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnAceptar.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
End Class