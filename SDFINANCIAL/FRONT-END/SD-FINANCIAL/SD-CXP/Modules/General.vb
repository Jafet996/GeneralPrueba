Imports BUSINESS
Imports System.IO
Public Module General
#Region "Variables"
    Public Modulo_Id As Enum_Modulos
#End Region

    Public Function ImprimeListaToken(pTokens As List(Of TUsuarioCodigoPermiso))
        Dim Token As List(Of TUsuarioCodigoPermiso)

        Try
            Token = pTokens

            Select Case InfoMaquina.PrintLocation
                Case Else
                    VerificaMensaje(ImprimeToken(Token))
            End Select

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Token = Nothing
        End Try
    End Function

    Public Function ImprimeToken(pTokens As List(Of TUsuarioCodigoPermiso)) As String
        Dim ImprimeTokens As New TImprimeToken(EmpresaInfo, EmpresaParametroInfo, pTokens)
        Dim TipoImpresion As PrintLocation

        Try
            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Serial
                    TipoImpresion = PrintLocation.Serial
                Case PrintLocation.Windows
                    TipoImpresion = PrintLocation.Windows
                Case Else
                    TipoImpresion = PrintLocation.Windows
            End Select

            If Not ImprimeTokens.Print(TipoImpresion, True) Then
                VerificaMensaje("Se presentaron problemas al imprimir el documento")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ImprimeTokens = Nothing
        End Try
    End Function

    Public Sub AsignaLogo(ByRef pPicLogo As PictureBox)
        Dim ToolTip1 As New ToolTip

        Try
            If Not EmpresaInfo.Logo Is Nothing Then
                Using ms As New MemoryStream()
                    ms.Write(EmpresaInfo.Logo, 0, EmpresaInfo.Logo.Length)
                    pPicLogo.Image = Image.FromStream(ms, True, True)
                End Using
            Else
                pPicLogo.Image = Nothing
            End If

            ToolTip1.SetToolTip(pPicLogo, EmpresaInfo.Nombre)
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ToolTip1 = Nothing
        End Try
    End Sub

    Public Function ImprimeCxPMovimiento(pEmpresa As TEmpresa, pTipo_Id As Integer, pMov_Id As Long, pReimpresion As Boolean) As String
        Dim CxPMovimiento As New TCxPMovimiento
        Dim ImprimeMovimiento As TImprimeCxPMovimiento
        Dim TipoImpresion As PrintLocation

        Try
            With CxPMovimiento
                .Emp_Id = pEmpresa.Emp_Id
                .Tipo_Id = pTipo_Id
                .Mov_Id = pMov_Id
            End With
            VerificaMensaje(CxPMovimiento.ListKey)

            ImprimeMovimiento = New TImprimeCxPMovimiento(pEmpresa, CxPMovimiento, pReimpresion)

            Select Case InfoMaquina.PrintLocation
                Case PrintLocation.Serial
                    TipoImpresion = PrintLocation.Serial
                Case PrintLocation.Windows
                    TipoImpresion = PrintLocation.Windows
                Case Else
                    TipoImpresion = PrintLocation.Windows
            End Select

            If Not ImprimeMovimiento.Print(TipoImpresion, True) Then
                VerificaMensaje("Se presentaron problemas al imprimir el documento")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            CxPMovimiento = Nothing
        End Try
    End Function

End Module