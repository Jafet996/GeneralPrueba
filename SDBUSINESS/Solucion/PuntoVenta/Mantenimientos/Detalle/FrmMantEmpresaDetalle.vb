Imports Business
Imports System.IO
Public Class FrmMantEmpresaDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
    Private Empresa As New TEmpresa(EmpresaInfo.Emp_Id)
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
            ReDim Numerico(12)

            Numerico(0) = New TNumericFormat(TxtNumero, 4, 0, False, "", "###")
            Numerico(1) = New TNumericFormat(TxtFactorRedondeo, 2, 0, False, "0", "##0")
            Numerico(2) = New TNumericFormat(TxtTopeRedondeo, 2, 2, False, "0", "#,##0.00")
            Numerico(3) = New TNumericFormat(TxtSaldoMinimoRecarga, 6, 2, False, "0", "#,##0.00")
            Numerico(4) = New TNumericFormat(TxtDiasCredito, 2, 0, False, "0", "###")
            Numerico(5) = New TNumericFormat(TxtPorcMora, 2, 2, False, "", "#,##0.00")
            Numerico(6) = New TNumericFormat(TxtDiasGraciaMora, 2, 0, False, "0", "###")
            Numerico(7) = New TNumericFormat(TxtMinutosPreFactura, 5, 0, False, "0", "##0")
            Numerico(8) = New TNumericFormat(TxtProformaDiasVencimiento, 4, 0, False, "", "###")
            Numerico(9) = New TNumericFormat(TxtPuntosPorCada, 9, 2, False, "0", "#,##0.00")
            Numerico(10) = New TNumericFormat(TxtPuntosAcumula, 5, 0, False, "0", "###")
            Numerico(11) = New TNumericFormat(TxtPorcInteresCredito, 2, 2, False, "", "#,##0.00")
            Numerico(12) = New TNumericFormat(TxtPuntosAcumula, 5, 0, False, "0", "###")


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub CargaDatos()
        Try
            Empresa.Emp_Id = CInt(TxtNumero.Text)
            VerificaMensaje(Empresa.ListKey())

            With Empresa
                TxtNombre.Text = .Nombre
                TxtRazonSocial.Text = .RazonSocial
                CmbTipoIdentificacion.SelectedValue = .TipoIdentificacion_Id
                TxtCedula.Text = .Cedula
                TxtTelefono.Text = .Telefono
                TxtFax.Text = .Fax
                TxtEmail.Text = .Email
                TxtDireccion.Text = .Direccion
                TxtDireccionWeb.Text = .DireccionWeb
                ChkActivo.Checked = .Activo
                ChkDevuelveIV.Checked = .DevuelveIV '08/12/2020 Mike
            End With

            If Not Empresa.Logo Is Nothing Then
                Using ms As New MemoryStream()
                    ms.Write(Empresa.Logo, 0, Empresa.Logo.Length)
                    PicLogo.Image = Image.FromStream(ms, True, True)
                End Using
            Else
                PicLogo.Image = Nothing
            End If

            With Empresa.Parametros
                TxtFactorRedondeo.Text = Format(.FactorRedondeo, "##0")
                TxtTopeRedondeo.Text = Format(.TopeRedondeo, "#,##0.00")
                TxtLeyenda1.Text = .LeyendaFactura1
                TxtLeyenda2.Text = .LeyendaFactura2
                TxtSaldoMinimoRecarga.Text = Format(.SaldoMinimoRecarga, "#,##0.00")
                TxtDiasCredito.Text = Format(.DiasCredito, "##0")
                TxtMinutosPreFactura.Text = Format(.MinutosPrefactura, "##0")
                ChkAcumulaPuntos.Checked = .PuntosActivo
                TxtPuntosPorCada.Text = Format(.PuntosPorCada, "#,##0.00")
                TxtPuntosAcumula.Text = Format(.PuntosAcumula, "##0")
                TxtDiasMayoreo.Text = Format(.DiasMayoreo, "##0")
                TxtDiasGraciaMora.Text = Format(.DiasGraciaMora, "##0")
                TxtPorcMora.Text = Format(.PorcMora, "#,##0.00")
                TxtPorcInteresCredito.Text = Format(.PorcInteresCredito, "#,##0.00")
                TxtPorcRentaPagoTarjeta.Text = Format(.PorcTarjetaRenta, "#,##0.00")
                TxtCuentaEfectivoxDepositar.Text = .CuentaEfectivoxDepositar
                TxtCuentaRentaPagoTarjeta.Text = .CuentaTarjetaRenta
                TxtCuentaGastoComisionTarjeta.Text = .CuentaGastoComisionTarjeta
                TxtCuentaDescuento.Text = .CuentaDescuento
                TxtCuentaDescuentoCompras.Text = .CuentaDescuentoCompras
                TxtCuentaIV.Text = .CuentaIV
                TxtCuentaRedondeo.Text = .CuentaRedondeo
                TxtEmpresaExterna.Text = .EmpresaExterna
                ChkGeneraCuotasCredito.Checked = .GeneraCuotasCredito
                ChkImprimeRecarga.Checked = .ImprimeRecarga
                ChkEliminaProformas.Checked = .ProformaElimina
                ChkPreFacturaCompromete.Checked = .PrefacturaCompromete
                TxtProformaDiasVencimiento.Text = Format(.ProformaDiasVencimiento, "##0")
                ChkProformaGenera.Checked = .ProformaGeneraArchivo
                TxtProformaCarpeta.Text = .ProformaCarpeta
                CmbProformaTipoImpresion.SelectedIndex = .ProformaTipoImpresion
                CkbFacturaGenera.Checked = .FacturaGeneraArchivo
                TxtFacturaCarpeta.Text = .FacturaCarpeta
                CmbFacturaImprime.SelectedIndex = .FacturaImprime - 1

            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub Execute(pCodigo As Integer)
        Me.Text = _Titulo
        _GuardoCambios = False
        CargaCombos()

        If Not _Nuevo Then
            TxtNumero.Text = pCodigo
            CargaDatos()
        Else
            CmbProformaTipoImpresion.SelectedIndex = 0
            CmbFacturaImprime.SelectedIndex = 0
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
        End Select
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtNombre.Text.Trim = "" Then
                TabControl1.SelectedIndex = 0
                TxtNombre.Focus()
                VerificaMensaje("Debe de ingresar un valor")
            End If

            If TxtTelefono.Text.Trim = "" And TxtTelefono.Text.Trim = "" Then
                TabControl1.SelectedIndex = 0
                TxtTelefono.Focus()
                VerificaMensaje("Debe de ingresar al menos un teléfono")
            End If

            If Not IsNumeric(TxtFactorRedondeo.Text) OrElse CInt(TxtFactorRedondeo.Text) < 0 Then
                TabControl1.SelectedIndex = 1
                TxtFactorRedondeo.Focus()
                VerificaMensaje("El valor debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtTopeRedondeo.Text) OrElse CDbl(TxtTopeRedondeo.Text) < 0 Then
                TabControl1.SelectedIndex = 1
                TxtTopeRedondeo.Focus()
                VerificaMensaje("El valor debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtDiasMayoreo.Text) OrElse CDbl(TxtDiasMayoreo.Text) < 0 Then
                TabControl1.SelectedIndex = 1
                TxtDiasMayoreo.Focus()
                VerificaMensaje("El valor debe de ser mayor o igual a cero")
            End If

            If CDbl(TxtTopeRedondeo.Text) > CDbl(TxtFactorRedondeo.Text) Then
                TabControl1.SelectedIndex = 1
                TxtTopeRedondeo.Focus()
                VerificaMensaje("El tope de redondeo no puede ser mayor al factor de redondeo")
            End If

            If Not IsNumeric(TxtMinutosPreFactura.Text) OrElse CInt(TxtMinutosPreFactura.Text) < 0 Then
                TabControl1.SelectedIndex = 1
                TxtMinutosPreFactura.Focus()
                VerificaMensaje("El valor debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtProformaDiasVencimiento.Text) OrElse CInt(TxtProformaDiasVencimiento.Text) < 0 Then
                TabControl1.SelectedIndex = 2
                TxtProformaDiasVencimiento.Focus()
                VerificaMensaje("El valor debe de ser mayor o igual a cero")
            End If

            If ChkProformaGenera.Checked AndAlso TxtProformaCarpeta.Text = String.Empty Then
                TabControl1.SelectedIndex = 2
                BtnProformaCarpeta.Focus()
                VerificaMensaje("Debe de indicar la carpeta donde se almacenan las proformas")
            End If

            If CmbProformaTipoImpresion.SelectedIndex < 0 OrElse CmbProformaTipoImpresion.SelectedItem Is Nothing Then
                TabControl1.SelectedIndex = 2
                CmbProformaTipoImpresion.Focus()
                VerificaMensaje("Debe de indicar el tipo de impresión de la proforma")
            End If

            If Not IsNumeric(TxtDiasCredito.Text) OrElse CInt(TxtDiasCredito.Text) < 0 Then
                TabControl1.SelectedIndex = 1
                TxtDiasCredito.Focus()
                VerificaMensaje("El valor debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtPorcMora.Text) OrElse CDbl(TxtPorcMora.Text) < 0 Then
                TabControl1.SelectedIndex = 1
                TxtPorcMora.Focus()
                VerificaMensaje("El valor debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtPorcInteresCredito.Text) OrElse CDbl(TxtPorcInteresCredito.Text) < 0 Then
                TabControl1.SelectedIndex = 1
                TxtPorcInteresCredito.Focus()
                VerificaMensaje("El valor debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtDiasGraciaMora.Text) OrElse CInt(TxtDiasGraciaMora.Text) < 0 Then
                TabControl1.SelectedIndex = 1
                TxtDiasGraciaMora.Focus()
                VerificaMensaje("El valor debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtSaldoMinimoRecarga.Text) OrElse CDbl(TxtSaldoMinimoRecarga.Text) < 0 Then
                TabControl1.SelectedIndex = 1
                TxtSaldoMinimoRecarga.Focus()
                VerificaMensaje("El valor debe de ser mayor o igual a cero")
            End If

            If Not IsNumeric(TxtPuntosPorCada.Text) Then
                TxtPuntosPorCada.Text = "0.00"
            End If

            If Not IsNumeric(TxtPuntosAcumula.Text) Then
                TxtPuntosAcumula.Text = "0.00"
            End If
            If CmbTipoIdentificacion.Text = "Ced Jurídica" And TxtCedula.TextLength <> 10 Then
                VerificaMensaje("La Cédula Jurídica tiene menos o mas caracteres")
            ElseIf CmbTipoIdentificacion.Text = "Ced Física" And TxtCedula.TextLength <> 9 Then
                VerificaMensaje("La Cédula Física tiene menos o mas caracteres")
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
        Dim data As Byte() = Nothing

        Try
            If Not PicLogo.Image Is Nothing Then
                data = ImageToByte(PicLogo)
            End If

            If _Nuevo Then
                VerificaMensaje(Empresa.Siguiente())
            Else
                Empresa.Emp_Id = CInt(TxtNumero.Text)
            End If

            With Empresa
                .Nombre = TxtNombre.Text
                .RazonSocial = TxtRazonSocial.Text
                .TipoIdentificacion_Id = CmbTipoIdentificacion.SelectedValue
                .Cedula = TxtCedula.Text
                .Telefono = TxtTelefono.Text
                .Fax = TxtFax.Text
                .Email = TxtEmail.Text
                .Direccion = TxtDireccion.Text
                .DireccionWeb = TxtDireccionWeb.Text
                .Activo = ChkActivo.Checked
                .Logo = data
                .DevuelveIV = ChkDevuelveIV.Checked '08/12/2020 Mike
            End With

            With Empresa.Parametros
                .Emp_Id = Empresa.Emp_Id
                .FactorRedondeo = CInt(TxtFactorRedondeo.Text)
                .TopeRedondeo = CDbl(TxtTopeRedondeo.Text)
                .DiasMayoreo = CInt(TxtDiasMayoreo.Text)
                .LeyendaFactura1 = TxtLeyenda1.Text
                .LeyendaFactura2 = TxtLeyenda2.Text
                .SaldoMinimoRecarga = CDbl(TxtSaldoMinimoRecarga.Text)
                .DiasCredito = CInt(TxtDiasCredito.Text)
                .MinutosPrefactura = CInt(TxtMinutosPreFactura.Text)
                .ProformaDiasVencimiento = CInt(TxtProformaDiasVencimiento.Text)
                .ProformaGeneraArchivo = ChkProformaGenera.Checked
                .ProformaCarpeta = TxtProformaCarpeta.Text
                .ProformaTipoImpresion = CmbProformaTipoImpresion.SelectedIndex
                .PuntosActivo = ChkAcumulaPuntos.Checked
                .PuntosPorCada = CDbl(TxtPuntosPorCada.Text)
                .PuntosAcumula = CInt(TxtPuntosAcumula.Text)
                .ProformaElimina = ChkEliminaProformas.Checked
                .PrefacturaCompromete = ChkPreFacturaCompromete.Checked
                .DiasGraciaMora = CInt(TxtDiasGraciaMora.Text)
                .PorcMora = CDbl(TxtPorcMora.Text)
                .PorcInteresCredito = CDbl(TxtPorcInteresCredito.Text)
                .GeneraCuotasCredito = ChkGeneraCuotasCredito.Checked
                .ImprimeRecarga = ChkImprimeRecarga.Checked
                .PorcTarjetaRenta = CDbl(TxtPorcRentaPagoTarjeta.Text)
                .CuentaEfectivoxDepositar = TxtCuentaEfectivoxDepositar.Text
                .CuentaTarjetaRenta = TxtCuentaRentaPagoTarjeta.Text
                .CuentaGastoComisionTarjeta = TxtCuentaGastoComisionTarjeta.Text
                .CuentaDescuento = TxtCuentaDescuento.Text
                .CuentaDescuentoCompras = TxtCuentaDescuentoCompras.Text
                .CuentaIV = TxtCuentaIV.Text
                .CuentaRedondeo = TxtCuentaRedondeo.Text
                .EmpresaExterna = TxtEmpresaExterna.Text.Trim
                .FacturaGeneraArchivo = CkbFacturaGenera.Checked
                .FacturaCarpeta = TxtFacturaCarpeta.Text
                .FacturaImprime = CmbFacturaImprime.SelectedIndex + 1
            End With

            If _Nuevo Then
                VerificaMensaje(Empresa.Insert())
                VerificaMensaje(Empresa.Parametros.Insert())
            Else
                VerificaMensaje(Empresa.Modify())
            End If

            _GuardoCambios = True
            Mensaje("Los cambios se almacenaron correctamente")
            Me.Close()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CargaCombos()
        Dim TipoIdentificacion As New TTipoIdentificacion(EmpresaInfo.Emp_Id)
        Try
            VerificaMensaje(TipoIdentificacion.LoadComboBox(CmbTipoIdentificacion))
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            TipoIdentificacion = Nothing
        End Try
    End Sub

    Private Sub FrmMantEmpresaDetalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateaCamposNumericos()
        TxtNombre.Select()
    End Sub

    Private Sub BtnProformaCarpeta_Click(sender As System.Object, e As System.EventArgs) Handles BtnProformaCarpeta.Click
        Try
            Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog

            ' Descriptive text displayed above the tree view control in the dialog box
            MyFolderBrowser.Description = "Select the Folder"

            ' Sets the root folder where the browsing starts from
            'MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyDocuments

            ' Do not show the button for new folder
            MyFolderBrowser.ShowNewFolderButton = False

            Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

            If dlgResult = Windows.Forms.DialogResult.OK Then
                TxtProformaCarpeta.Text = MyFolderBrowser.SelectedPath
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnLogo_Click(sender As System.Object, e As System.EventArgs) Handles BtnLogo.Click
        OpenFileDialog1.InitialDirectory = Application.StartupPath
        OpenFileDialog1.Filter = "PNG|*.png|Bitmap|*.bmp|JPEG|*.jpg" 'If you like file type filters you can add them here
        OpenFileDialog1.FileName = String.Empty
        'any other modifications to the dialog
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            Dim bmp As New Bitmap(OpenFileDialog1.FileName)
            If Not IsNothing(PicLogo.Image) Then PicLogo.Image.Dispose() 'Optional if you want to destroy the previously loaded image
            PicLogo.Image = bmp
        Catch
            MsgBox("Not a valid image file.")
        End Try
    End Sub

    Private Sub BtnLogoEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLogoEliminar.Click
        PicLogo.Image = Nothing
    End Sub

    Private Sub TxtCuentaEfectivoxDepositar_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuentaEfectivoxDepositar.KeyDown
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCuentaEfectivoxDepositar.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCuentaGastoComisionTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuentaGastoComisionTarjeta.KeyDown
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCuentaGastoComisionTarjeta.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCuentaRentaPagoTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuentaRentaPagoTarjeta.KeyDown
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCuentaRentaPagoTarjeta.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCuentaDescuento_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuentaDescuento.KeyDown
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCuentaDescuento.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCuentaDescuentoCompras_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuentaDescuentoCompras.KeyDown
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCuentaDescuentoCompras.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCuentaIV_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuentaIV.KeyDown
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCuentaIV.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TxtCuentaRedondeo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuentaRedondeo.KeyDown
        Dim Resultado As String = ""
        Try

            Select Case e.KeyCode
                Case Keys.F1
                    Resultado = BusquedaCuentaContable()
                    If Resultado.Trim <> String.Empty Then
                        TxtCuentaRedondeo.Text = Resultado.Trim
                    End If
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog

            ' Descriptive text displayed above the tree view control in the dialog box
            MyFolderBrowser.Description = "Select the Folder"

            ' Sets the root folder where the browsing starts from
            'MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyDocuments

            ' Do not show the button for new folder
            MyFolderBrowser.ShowNewFolderButton = False

            Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

            If dlgResult = Windows.Forms.DialogResult.OK Then
                TxtFacturaCarpeta.Text = MyFolderBrowser.SelectedPath
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CedulaInfo()
        Try
            If CmbTipoIdentificacion.SelectedValue Is Nothing OrElse CmbTipoIdentificacion.SelectedValue.ToString = "System.Data.DataRowView" Then
                Exit Sub
            End If
            TxtCedula.Text = ""
            Select Case CmbTipoIdentificacion.SelectedValue
                Case 1 'CedulaFisica
                    TxtCedula.MaxLength = 9
                    LblCedulaInfo.Text = "La 'Cédula física' debe de contener 9 dígitos, sin cero al inicio y sin guiones"
                Case 2 'Cedula Juridica
                    TxtCedula.MaxLength = 10
                    LblCedulaInfo.Text = "La 'Cédula de personas Jurídicas' debe contener 10 dígitos y sin guiones"
                Case 3 'DIMEX(Pasaporte)
                    TxtCedula.MaxLength = 12
                    LblCedulaInfo.Text = "El 'Documento de Identificación Migratorio para Extranjeros(DIMEX)' debe contener 11 o 12 dígitos, sin ceros al inicio y sin guiones"
                Case 4 'NITE 
                    TxtCedula.MaxLength = 10
                    LblCedulaInfo.Text = "El 'Documento de Identificación de la DGT( NITE)' debe contener 10 dígitos y sin guiones."
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CmbTipoIdentificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoIdentificacion.SelectedIndexChanged
        CedulaInfo()
    End Sub
End Class