Imports BUSINESS
Public Class FrmAsientoDetalle
#Region "Enum"
    Private Enum Enum_Columna
        Cuenta_Id = 0
        Nombre
        Debe
        Haber
    End Enum
    Public Enum Enum_TipoReporte
        AuxAsiento = 0
        Asiento = 1
    End Enum
#End Region
#Region "Variables"
    Private _Titulo As String
    Private _Asiento_Id As Integer
    Private _TipoReporte As Enum_TipoReporte
#End Region
#Region "Propiedades"
    Public WriteOnly Property Titulo As String
        Set(value As String)
            _Titulo = value
        End Set
    End Property
    Public WriteOnly Property Asiento_Id As Integer
        Set(value As Integer)
            _Asiento_Id = value
        End Set
    End Property
    Public WriteOnly Property TipoReporte As Enum_TipoReporte
        Set(value As Enum_TipoReporte)
            _TipoReporte = value
        End Set
    End Property
#End Region

    Public Sub Execute()
        Me.Text = _Titulo
        ConfiguraLista()
        CargaDetalle()

        Me.ShowDialog()
    End Sub

    Private Sub ConfiguraLista()
        Try
            With LvwDetalle
                .Columns(Enum_Columna.Cuenta_Id).Text = "Cuenta"
                .Columns(Enum_Columna.Cuenta_Id).Width = 130

                .Columns(Enum_Columna.Nombre).Text = "Nombre"
                .Columns(Enum_Columna.Nombre).Width = 200

                .Columns(Enum_Columna.Debe).Text = "Debe"
                .Columns(Enum_Columna.Debe).Width = 120

                .Columns(Enum_Columna.Haber).Text = "Haber"
                .Columns(Enum_Columna.Haber).Width = 120
            End With

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub CargaDetalle()
        If _TipoReporte = Enum_TipoReporte.Asiento Then
            CargaListaAsiento()
        Else
            CargaListaAux()
        End If

        If LvwDetalle.Items.Count > 0 Then
            LvwDetalle.Items(0).Selected = True
            LvwDetalle.Focus()
        End If
    End Sub

    Private Sub CargaListaAux()
        Dim AsientoDetalle As New TAuxAsientoDetalle
        Dim Items(3) As String
        Dim Item As ListViewItem
        Dim Debe As Double = 0.0
        Dim Haber As Double = 0.0

        Try
            LvwDetalle.Items.Clear()

            With AsientoDetalle
                .Emp_Id = EmpresaInfo.Emp_Id
                .Asiento_Id = _Asiento_Id
            End With
            VerificaMensaje(AsientoDetalle.List)

            If AsientoDetalle.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In AsientoDetalle.Datos.Tables(0).Rows
                Debe += IIf(Fila("Tipo") = coDebe, Fila("Monto"), 0)
                Haber += IIf(Fila("Tipo") = coHaber, Fila("Monto"), 0)

                Items(0) = Fila("Cuenta_Id")
                Items(1) = Fila("CuentaNombre")
                Items(2) = IIf(Fila("Tipo") = coDebe, Format(Fila("Monto"), "#,##0.00"), String.Empty)
                Items(3) = IIf(Fila("Tipo") = coHaber, Format(Fila("Monto"), "#,##0.00"), String.Empty)

                Item = New ListViewItem(Items)
                LvwDetalle.Items.Add(Item)
            Next

            Items(0) = String.Empty
            Items(1) = "TOTAL ASIENTO"
            Items(2) = Format(Debe, "#,##0.00")
            Items(3) = Format(Haber, "#,##0.00")

            Item = New ListViewItem(Items)
            Item.BackColor = IIf(Items(2) <> Items(3), Color.LightCoral, Color.PaleTurquoise)
            LvwDetalle.Items.Add(Item)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoDetalle = Nothing
        End Try
    End Sub

    Private Sub CargaListaAsiento()
        Dim AsientoDetalle As New TAsientoDetalle
        Dim Items(3) As String
        Dim Item As ListViewItem
        Dim Debe As Double = 0.0
        Dim Haber As Double = 0.0

        Try
            LvwDetalle.Items.Clear()

            With AsientoDetalle
                .Emp_Id = EmpresaInfo.Emp_Id
                .Asiento_Id = _Asiento_Id
            End With
            VerificaMensaje(AsientoDetalle.List)

            If AsientoDetalle.RowsAffected = 0 Then
                Exit Sub
            End If

            For Each Fila As DataRow In AsientoDetalle.Datos.Tables(0).Rows
                Debe += IIf(Fila("Tipo") = coDebe, Fila("Monto"), 0)
                Haber += IIf(Fila("Tipo") = coHaber, Fila("Monto"), 0)

                Items(0) = Fila("Cuenta_Id")
                Items(1) = Fila("CuentaNombre")
                Items(2) = IIf(Fila("Tipo") = coDebe, Format(Fila("Monto"), "#,##0.00"), String.Empty)
                Items(3) = IIf(Fila("Tipo") = coHaber, Format(Fila("Monto"), "#,##0.00"), String.Empty)

                Item = New ListViewItem(Items)
                LvwDetalle.Items.Add(Item)
            Next

            Items(0) = String.Empty
            Items(1) = "TOTAL ASIENTO"
            Items(2) = Format(Debe, "#,##0.00")
            Items(3) = Format(Haber, "#,##0.00")

            Item = New ListViewItem(Items)
            Item.BackColor = IIf(Items(2) <> Items(3), Color.LightCoral, Color.PaleTurquoise)
            LvwDetalle.Items.Add(Item)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            AsientoDetalle = Nothing
        End Try
    End Sub

    Private Sub FrmAuxAsientoDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class