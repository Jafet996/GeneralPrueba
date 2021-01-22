Imports Business
Imports System.IO
Public Class FrmGeneraListadoArticulos
    Public Sub Execute()
        Me.ShowDialog()
    End Sub
    Private Sub BtnRuta_Click(sender As System.Object, e As System.EventArgs) Handles BtnRuta.Click
        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()
        Try

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv"
            saveFileDialog1.FilterIndex = 1
            saveFileDialog1.RestoreDirectory = True
            saveFileDialog1.FileName = "CargaArticulos"

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                myStream = saveFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    LblRuta.Text = saveFileDialog1.FileName
                    myStream.Close()
                End If
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            myStream = Nothing
            saveFileDialog1 = Nothing
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGenerar.Click
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Sw As System.IO.StreamWriter = Nothing
        Dim Mensaje As String = ""
        Dim Linea As String = ""
        Try
            If LblRuta.Text = "" Then
                VerificaMensaje("Debe de seleccionar un nombre de archivo")
            End If

            Mensaje = Articulo.List()
            VerificaMensaje(Mensaje)

            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("No se encontraron artículos")
            End If

            Sw = New System.IO.StreamWriter(LblRuta.Text)

            For Each Fila As DataRow In Articulo.Data.Tables(0).Rows
                Linea = Fila("Art_Id").ToString.Replace(",", " ") & "," & Mid(Fila("Nombre").ToString.Replace(",", " "), 1, 28).Trim & "," & Fila("Cantidad").ToString
                Sw.WriteLine(Linea)
            Next

            Sw.Close()

            MsgBox("El archivo se generó de manera correcta en, " & LblRuta.Text, MsgBoxStyle.Information, Me.Text)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing

            Sw = Nothing
        End Try
    End Sub

    Private Sub FrmGeneraListadoArticulos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                BtnSalir.PerformClick()
        End Select
    End Sub
End Class