Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Public Module FuncionesBotones
    Public Enum Enum_ArticuloTipo
        Simple = 1
        Compuesto = 2
        Escogencia = 3
    End Enum

    Public Sub DestruyeBotones(ByRef pPanel As Panel, ByRef pBotones() As Button, ByVal pPrefijoBoton As String)
        'Dim Ctr As Control

        pPanel.Tag = ""
        pBotones = Nothing
        pPanel.Controls.Clear()
    End Sub
    Public Sub InicializaFlechas(ByVal pPicLeft As PictureBox, ByVal pPicRight As PictureBox)
        With pPicLeft
            .Tag = ""
            .Enabled = False
        End With

        With pPicRight
            .Tag = ""
            .Enabled = False
        End With
    End Sub
    Public Function CuantosCaben(ByVal pAlto As Integer, ByVal pAncho As Integer, _
                             ByVal pAltoContenedor As Integer, ByVal pAnchoContenedor As Integer, _
                             ByVal pEspacio As Integer, ByRef pFilas As Integer, ByRef pColumnas As Integer) As Integer
        Dim Filas As Integer = 0
        Dim Columnas As Integer = 0
        Try
            CuantosCaben = 0

            Columnas = Int((pAnchoContenedor - pEspacio) / (pAncho + pEspacio))
            Filas = Int((pAltoContenedor - pEspacio) / (pAlto + pEspacio))

            CuantosCaben = Filas * Columnas

            pColumnas = Columnas
            pFilas = Filas

        Catch ex As Exception
            CuantosCaben = 0
        End Try

    End Function

    Public Function CreaBotones(ByRef pBotones() As Button, ByVal pPanel As Panel, ByVal pBotonTipo As Integer, _
                           ByRef pFechaIzquierda As PictureBox, ByRef pFlechaDerecha As PictureBox) As String

        Dim Botones As New TBotones(EmpresaInfo.Emp_Id)
        Dim CantidadCaben As Integer = 0
        Dim Mensaje As String = ""
        Dim i As Integer = 0
        Dim Filas As Integer = 0
        Dim Columnas As Integer = 0
        Dim vTop As Integer = 0
        Dim vLeft As Integer = 0
        Dim FilaActual As Integer = 0
        Dim ColumnaActual As Integer = 0

        CreaBotones = ""

        Try
            'Busca las dimensiones del boton
            Botones.BotonTipo = pBotonTipo
            Mensaje = Botones.ListKey
            VerificaMensaje(Mensaje)

            CantidadCaben = CuantosCaben(Botones.Alto, Botones.Ancho, pPanel.Height, pPanel.Width, Botones.Espacio, Filas, Columnas)

            If (CantidadCaben < (UBound(pBotones) + 1)) And CantidadCaben > 0 Then
                pFechaIzquierda.Enabled = True
                pFlechaDerecha.Enabled = True
            End If
            pFechaIzquierda.Tag = CantidadCaben
            pFlechaDerecha.Tag = CantidadCaben

            vTop = 1
            vLeft = 1
            FilaActual = 1
            ColumnaActual = 1

            For i = 0 To UBound(pBotones)
                With pBotones(i)
                    .Parent = pPanel
                    .Height = Botones.Alto
                    .Width = Botones.Ancho

                    '.Font = New Font("Verdana", 8, FontStyle.Bold)
                    '.ForeColor = Color.Navy

                    .Top = vTop
                    .Left = vLeft
                    If i < CantidadCaben Then
                        .Visible = True
                    Else
                        .Visible = False
                    End If
                End With

                If FilaActual >= Filas Then
                    vTop = Botones.Espacio
                    vLeft = (Botones.Ancho + (Botones.Espacio * 2)) * ColumnaActual
                    FilaActual = 1
                    ColumnaActual = ColumnaActual + 1
                Else
                    vTop = (Botones.Alto + (Botones.Espacio * 2)) * FilaActual
                    FilaActual = FilaActual + 1
                End If

                If ColumnaActual > Columnas Then
                    ColumnaActual = 1
                    vLeft = Botones.Espacio
                End If
            Next
        Catch ex As Exception
            CreaBotones = ex.Message
        Finally
            Botones = Nothing
        End Try

    End Function
    Public Sub BuscaRangoVisibleAdelante(ByVal pBotones() As Button, ByVal CantidadVisibles As Integer, _
                             ByRef pIniVisibleNew As Integer, ByRef pFinVisibleNew As Integer)
        Dim i As Integer
        Dim IniVisibleOld As Integer

        For i = 0 To UBound(pBotones)
            If pBotones(i).Visible Then
                IniVisibleOld = i
                Exit For
            End If
        Next

        pIniVisibleNew = IniVisibleOld + CantidadVisibles
        If pIniVisibleNew > UBound(pBotones) Then
            pIniVisibleNew = 0
        End If

        pFinVisibleNew = (pIniVisibleNew + CantidadVisibles) - 1

        If pFinVisibleNew > UBound(pBotones) Then
            pFinVisibleNew = UBound(pBotones)
        End If

    End Sub
    Public Sub BuscaRangoVisibleAtras(ByVal pBotones() As Button, ByVal pCantidadVisibles As Integer, _
                         ByRef pIniVisibleNew As Integer, ByRef pFinVisibleNew As Integer)
        Dim i As Integer
        Dim FinVisibleOld As Integer

        For i = UBound(pBotones) To 0 Step -1
            If pBotones(i).Visible Then
                FinVisibleOld = i
                Exit For
            End If
        Next

        If pCantidadVisibles > 1 Then

            If ((FinVisibleOld + 1) Mod pCantidadVisibles) > 0 Then
                pFinVisibleNew = (pCantidadVisibles * Int((FinVisibleOld + 1) / pCantidadVisibles)) - 1
            Else
                pFinVisibleNew = FinVisibleOld - pCantidadVisibles
            End If


            If pFinVisibleNew <= 0 Then
                pFinVisibleNew = UBound(pBotones)
                If ((UBound(pBotones) + 1) Mod pCantidadVisibles) > 0 Then
                    pCantidadVisibles = (UBound(pBotones) + 1) - (pCantidadVisibles * Int((UBound(pBotones) + 1) / pCantidadVisibles))
                End If
            End If

            pIniVisibleNew = (pFinVisibleNew - pCantidadVisibles) + 1

            If pIniVisibleNew < 0 Then
                pIniVisibleNew = 0
            End If

        Else
            If FinVisibleOld = 0 Then
                pIniVisibleNew = UBound(pBotones)
            Else
                pIniVisibleNew = FinVisibleOld - 1
            End If
            pFinVisibleNew = pIniVisibleNew
        End If

    End Sub
    Public Sub OcultaBotones(ByRef pBotones() As Button)
        Dim i As Integer = 0
        For i = 0 To UBound(pBotones)
            pBotones(i).Visible = False
        Next
    End Sub
    Public Sub MuestraBotones(ByRef pBotones() As Button, ByVal pInicio As Integer, ByVal pFin As Integer)
        Dim i As Integer = 0

        For i = pInicio To pFin
            pBotones(i).Visible = True
        Next

    End Sub
    Public Sub MarcaDesmarcaBotones(ByRef pBotones() As TBoton, ByVal pBoton As TBoton, ByVal pSeleccionMultiple As Boolean)
        Dim i As Integer = 0

        If pBoton.ForeColor = pBoton.ColorSelection Then
            If pSeleccionMultiple Then
                pBoton.ForeColor = pBoton.ColorDefault
            End If
        Else
            For i = 0 To UBound(pBotones)
                If pBotones(i).Name = pBoton.Name Then
                    pBotones(i).ForeColor = pBoton.ColorSelection
                Else
                    If Not pSeleccionMultiple Then
                        pBotones(i).ForeColor = pBoton.ColorDefault
                    End If
                End If
            Next
        End If
    End Sub

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
End Module
