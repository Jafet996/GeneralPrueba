Imports Business
Public Class FrmMantUsuarioCodigoPermisoDetalle
#Region "Variables"
    Private Numerico() As TNumericFormat
#End Region
#Region "Enum"
    Public Enum ColumnaCodigoAcceso
        Codigo_Id = 0
        Codigo = 1
        Fecha = 2
        Vencimiento = 3
    End Enum
#End Region
#Region "Funciones Privadas"
    Private Sub FormateaCamposNumericos()
        Try
            ReDim Numerico(0)

            Numerico(0) = New TNumericFormat(TxtCantidad, 4, 0, False, "0", "#,##0.00")

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub Execute()
        ConfiguraLista()
        CargaDatosUsuario()
        DtpFechaVencimiento.Value = DateAdd(DateInterval.Day, 15, EmpresaInfo.Getdate)
        TxtCantidad.Select()

        Me.ShowDialog()
    End Sub

    Private Sub CargaDatosUsuario()
        LblUsuarioNombre.Text = UsuarioInfo.Nombre
        LblUsuarioNombre.Tag = UsuarioInfo.Usuario_Id

        CargaLista()
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwCodigos
                .Columns(ColumnaCodigoAcceso.Codigo_Id).Text = "Número"
                .Columns(ColumnaCodigoAcceso.Codigo_Id).Width = 0

                .Columns(ColumnaCodigoAcceso.Codigo).Text = "Código"
                .Columns(ColumnaCodigoAcceso.Codigo).Width = 100

                .Columns(ColumnaCodigoAcceso.Fecha).Text = "Fecha"
                .Columns(ColumnaCodigoAcceso.Fecha).Width = 150

                .Columns(ColumnaCodigoAcceso.Vencimiento).Text = "Fecha Vencimiento"
                .Columns(ColumnaCodigoAcceso.Vencimiento).Width = 150
            End With
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaLista()
        Dim UsuarioCodigo As New TUsuarioCodigoPermiso()
        Dim Items(3) As String
        Dim Item As ListViewItem = Nothing

        Try
            LvwCodigos.Items.Clear()

            With UsuarioCodigo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Usuario_Id = LblUsuarioNombre.Tag
            End With
            VerificaMensaje(UsuarioCodigo.ListaxUsuario)

            If UsuarioCodigo.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In UsuarioCodigo.Datos.Tables(0).Rows
                Items(0) = Fila("Codigo_Id")
                Items(1) = Fila("Codigo")
                Items(2) = Format(Fila("Fecha"), "dd/MM/yyyy hh:mm tt")
                Items(3) = Format(Fila("FechaVencimiento"), "dd/MM/yyyy")

                Item = New ListViewItem(Items)
                LvwCodigos.Items.Add(Item)
            Next

            PnlCodigos.Enabled = LvwCodigos.Items.Count > 0

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            UsuarioCodigo = Nothing
        End Try
    End Sub

    Private Function ValidaTodo() As Boolean
        Try
            If TxtCantidad.Text.Trim = "" OrElse Not IsNumeric(TxtCantidad.Text.Trim) Then
                TxtCantidad.Focus()
                VerificaMensaje("Debe de ingresar la cantidad de códigos deseados.")
            End If

            If TxtCantidad.Text.Trim <= 0 Then
                TxtCantidad.Focus()
                VerificaMensaje("La cantidad debe de ser mayor a cero.")
            End If

            If DateValue(DtpFechaVencimiento.Value) < DateValue(EmpresaInfo.Getdate) Then
                DtpFechaVencimiento.Focus()
                VerificaMensaje("La fecha de vencimiento no puede ser del pasado.")
            End If

            Return True
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub GeneraCodigos()
        Dim UsuarioCodigo As TUsuarioCodigoPermiso = Nothing
        Dim AUX As TUsuarioCodigoPermiso = Nothing
        Dim Cantidad As Integer = TxtCantidad.Text.Trim - 1
        Dim Fecha As DateTime = EmpresaInfo.Getdate

        Try
            For i As Integer = 0 To Cantidad
                UsuarioCodigo = New TUsuarioCodigoPermiso()

                With UsuarioCodigo
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Usuario_Id = LblUsuarioNombre.Tag
                    .Codigo = GeneraCodigosAleatorios(i)
                    .Activo = 1
                    .Fecha = Fecha
                    .FechaVencimiento = DateValue(DtpFechaVencimiento.Value)
                End With

                AUX = New TUsuarioCodigoPermiso()

                With AUX
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Codigo = UsuarioCodigo.Codigo
                End With
                VerificaMensaje(AUX.ListKeyXCodigo)

                If AUX.RowsAffected = 0 Then
                    VerificaMensaje(UsuarioCodigo.NextOne)
                    VerificaMensaje(UsuarioCodigo.Insert)
                Else
                    Cantidad += 1
                End If

            Next

            CargaLista()
            TxtCantidad.Text = ""

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            UsuarioCodigo = Nothing
        End Try
    End Sub

    Private Sub ImprimirLista()
        Dim UsuarioCodigo As New TUsuarioCodigoPermiso()
        Dim Token As TUsuarioCodigoPermiso = Nothing
        Dim ListaToken As New List(Of TUsuarioCodigoPermiso)

        Try
            If MsgBox("Desea imprimir la lista de códigos?", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, "Imprimir") <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            If LvwCodigos.Items.Count = 0 Then
                TxtCantidad.Focus()
                VerificaMensaje("No hay códigos disponibles para imprimir, primero debe de generar códigos.")
            End If

            With UsuarioCodigo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Usuario_Id = LblUsuarioNombre.Tag
            End With
            VerificaMensaje(UsuarioCodigo.ListaxUsuario)

            If UsuarioCodigo.RowsAffected = 0 Then
                TxtCantidad.Focus()
                VerificaMensaje("No hay códigos disponibles para imprimir, primero debe de generar códigos.")
            End If

            For Each Fila As DataRow In UsuarioCodigo.Datos.Tables(0).Rows
                Token = New TUsuarioCodigoPermiso()

                With Token
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Usuario_Id = Fila("Usuario_Id")
                    .Codigo_Id = Fila("Codigo_Id")
                    .Codigo = Fila("Codigo")
                    .Activo = Fila("Activo")
                    .Fecha = Fila("Fecha")
                    .FechaVencimiento = Fila("FechaVencimiento")
                End With

                ListaToken.Add(Token)
            Next

            ImprimeListaToken(ListaToken)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            UsuarioCodigo = Nothing
        End Try
    End Sub

    Private Sub BtnGenerar_Click(sender As Object, e As EventArgs) Handles BtnGenerar.Click
        If ValidaTodo() Then
            GeneraCodigos()
        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMantUsuarioCodigoPermisoDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BtnGenerar.PerformClick()
            Case Keys.F4
                BtnImprimir.PerformClick()
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        ImprimirLista()
    End Sub
End Class