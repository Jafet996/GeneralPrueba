Public Class FrmSeleccionaTomaFisica
    Private _Suc_Id As Integer
    Private _TomaFisicaEncabezado As TTomaFisicaEncabezado = Nothing

    Public WriteOnly Property Suc_Id As Integer
        Set(value As Integer)
            _Suc_Id = value
        End Set
    End Property

    Public ReadOnly Property TomaFisica As TTomaFisicaEncabezado
        Get
            Return _TomaFisicaEncabezado
        End Get
    End Property


    Private Sub CargaCombos()
        Dim TFE As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Try
            TFE.Suc_Id = _Suc_Id

            VerificaMensaje(TFE.LoadComboBoxBodegaTomaFisica(CmbBodega))

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TFE = Nothing
        End Try
    End Sub

    Public Sub Execute()
        _TomaFisicaEncabezado = Nothing

        CargaCombos()
        Me.ShowDialog()
    End Sub

    Private Function ValidaTodo()
        Try

            If CmbBodega.SelectedValue Is Nothing OrElse CmbBodega.SelectedIndex < 0 Then
                VerificaMensaje("Debe de seleccionar una Bodega")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try

            If ValidaTodo() Then
                Seleccionar()
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Seleccionar()
        Try

            _TomaFisicaEncabezado = New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
            With _TomaFisicaEncabezado
                .Suc_Id = _Suc_Id
                .Bod_Id = CInt(CmbBodega.SelectedValue)
            End With

            VerificaMensaje(_TomaFisicaEncabezado.VerificaTomaFisicaActiva())

            If _TomaFisicaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No existe una Toma Física válida para la bodega seleccionada")
            End If

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        _TomaFisicaEncabezado = Nothing
        Me.Close()
    End Sub
End Class