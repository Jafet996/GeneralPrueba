Imports System.Windows.Forms

Public Class TNumericFormat

#Region "Declaraciones"
    Dim _Decimales As Integer
    Dim _Default As String
    Dim _Enteros As Integer
    Dim _Miles As Boolean
    Dim _Negativo As Boolean

    '--- Objeto

    Dim WithEvents MiTextBox As TextBox

    '--- Otros

    Dim Formato As String
#End Region

#Region "Procedimientos"
    Public Sub Inicializa(ByRef pText As TextBox, ByVal pEnteros As Integer, ByVal pDecimales As Integer, ByVal pNegativo As Boolean, ByVal pDefault As String, Optional ByVal pFormato As String = "#,##0")
        'pText      : TextBox
        'pEnteros   : Cantidad de enteros
        'pDecimales : Cantidad de decimales
        'pNegativo  : Soporta valores negativos
        'pDefault   : Valor por defecto
        'pFormato   : Formato del número

        Dim Arreglo() As String 'Utilizado para separar el formato de los enteros y decimales
        Dim Calculo As Long
        Dim I As Integer
        Dim J As Integer

        '--- Asigna

        MiTextBox = pText

        _Enteros = pEnteros
        _Decimales = pDecimales
        _Negativo = pNegativo
        _Default = Trim(pDefault)

        '--- Valida

        If pEnteros <= 0 Or pEnteros > 15 Then
            Err.Raise(vbObjectError + 513, , "CLSText [Inicializa : " & MiTextBox.Name & "]" & vbCrLf & "pEnteros debe ser mayor a 0 y menor o igual a 9")
        End If

        If pDecimales < 0 Or pDecimales > 8 Then
            Err.Raise(vbObjectError + 513, , "CLSText [Inicializa : " & MiTextBox.Name & "]" & vbCrLf & "pDecimales debe ser mayor o igual a 0 y menor o igual a 8")
        End If

        If Not IsNumeric(pDefault) Then
            If pDefault <> "" Then
                Err.Raise(vbObjectError + 513, , "CLSText [Inicializa : " & MiTextBox.Name & "]" & vbCrLf & "pDefault debe ser numérico o blanco")
            End If
        Else
            Calculo = CDbl(StrDup(pEnteros, "9"))

            If pDecimales > 0 Then
                Calculo = Calculo + CDbl(StrDup(pDecimales, "9")) / 10 ^ pDecimales
            End If

            If CDbl(pDefault) < IIf(pNegativo, Calculo * -1, 0) Or
               CDbl(pDefault) > Calculo Then
                Err.Raise(vbObjectError + 513, , "CLSText [Inicializa : " & MiTextBox.Name & "]" & vbCrLf & "pDefault esta sobrepasando el rango permitido por pEnteros y pDecimales")
            End If
        End If

        '--- Formato

        pFormato = Trim(pFormato)

        If pFormato <> "" Then
            If Replace(Replace(Replace(Replace(pFormato, "0", ""), "#", ""), ",", ""), ".", "") <> "" Then
                Err.Raise(vbObjectError + 513, , "CLSText [Inicializa : " & MiTextBox.Name & "]" & vbCrLf & "pFormato contiene caractéres inválidos. Solo se permiten ""#"", ""0"" y "",""")
            End If

            Arreglo = Split(pFormato, ".")

            '--- Formato : Enteros

            I = 1
            J = 1

            Do While I <= pEnteros
                Formato = Mid(StrReverse(Arreglo(0)), J, 1) & Formato

                If Left(Formato, 1) <> "," Then
                    I = I + 1
                End If

                J = J + 1
            Loop

            '--- Formato : Decimales

            I = 1

            Do While I <= pDecimales
                If I = 1 Then
                    Formato = Formato & "."
                End If

                If UBound(Arreglo) > 0 Then
                    Formato = Formato & Mid(Arreglo(1), I, 1)
                Else
                    Formato = Formato & "0"
                End If

                I = I + 1
            Loop
        Else
            Formato = pFormato
        End If

        '--- Miles

        _Miles = (InStr(1, Formato, ",") > 0)

        '--- MaxLenght

        Calculo = pEnteros

        If pDecimales > 0 Then
            Calculo = Calculo + pDecimales + 1 '<--- Punto decimal
        End If

        If _Miles Then
            If pEnteros Mod 3 = 0 Then
                Calculo = Calculo + (pEnteros \ 3 - 1)
            Else
                Calculo = Calculo + (pEnteros \ 3)
            End If
        End If

        If pNegativo Then
            Calculo = Calculo + 1
        End If

        MiTextBox.MaxLength = Calculo
    End Sub

    Private Function Monto_Cadena(ByVal pText As TextBox, ByVal pValor As String, ByVal pBackSpace As Boolean) As String
        'pText      : TextBox
        'pCadena    : Chr(Keyascii). Si es "" se interpreta como borrado.
        'pBackSpace : Solo si pCadena es "". True = BackSpace; False = Delete;

        If pText.SelectionLength > 0 Then
            Select Case pValor
                Case ""
                    Monto_Cadena = Mid(pText.Text, 1, pText.SelectionStart) & Mid(pText.Text, pText.SelectionStart + pText.SelectionLength + 1)
                Case Else
                    Monto_Cadena = Mid(pText.Text, 1, pText.SelectionStart) & pValor & Mid(pText.Text, pText.SelectionStart + pText.SelectionLength + 1)
            End Select
        Else
            If pText.SelectionStart > 0 Then
                Select Case pValor
                    Case ""
                        If pBackSpace Then
                            Monto_Cadena = Mid(pText.Text, 1, pText.SelectionStart - 1) & Mid(pText.Text, pText.SelectionStart + pText.SelectionLength + 1)
                        Else
                            Monto_Cadena = Mid(pText.Text, 1, pText.SelectionStart) & Mid(pText.Text, pText.SelectionStart + 2)
                        End If
                    Case Else
                        Monto_Cadena = Mid(pText.Text, 1, pText.SelectionStart) & pValor & Mid(pText.Text, pText.SelectionStart + 1)
                End Select
            Else
                Select Case pValor
                    Case ""
                        If pBackSpace Then
                            Monto_Cadena = pText.Text
                        Else
                            Monto_Cadena = Mid(pText.Text, 2)
                        End If
                    Case Else
                        Monto_Cadena = pValor & pText.Text
                End Select
            End If
        End If
    End Function

    Private Function Monto_KeyAscii(ByVal pText As TextBox, ByVal pKeyAscii As Integer, ByVal pEnteros As Integer, ByVal pDecimales As Integer) As Integer
        Dim Cadena As String

        Try
            '--- Inicializa

            Monto_KeyAscii = pKeyAscii

            '--- Cadena

            If pKeyAscii = 8 Then
                Cadena = Monto_Cadena(pText, "", True)
            Else
                Cadena = Monto_Cadena(pText, Chr(pKeyAscii), True)
            End If

            '--- Valida

            If Not Monto_Verifica(Cadena, pEnteros, pDecimales) Then
                Monto_KeyAscii = 0
            End If
        Catch
            Monto_KeyAscii = 0
            Err.Raise(vbObjectError + 513, , "[Monto_KeyAscii]" & vbCrLf & Err.Number & " : " & Err.Description)
        End Try
    End Function

    Private Function Monto_KeyDelete(ByVal pText As TextBox, ByVal pEnteros As Integer, ByVal pDecimales As Integer) As Integer
        Dim Cadena As String

        Try
            '--- Inicializa

            Monto_KeyDelete = Keys.Delete

            '--- Cadena

            Cadena = Monto_Cadena(pText, "", False)

            '--- Valida

            If Not Monto_Verifica(Cadena, pEnteros, pDecimales) Then
                Monto_KeyDelete = 0
            End If

        Catch
            Monto_KeyDelete = 0
            Err.Raise(vbObjectError + 513, , "[Monto_KeyDelete]" & vbCrLf & Err.Number & " : " & Err.Description)
        End Try
    End Function

    Private Function Monto_Verifica(ByVal pCadena As String, ByVal pEnteros As Integer, ByVal pDecimales As Integer) As Boolean
        Dim Arreglo() As String

        '--- Inicializa

        Monto_Verifica = True

        '--- Valida

        If Trim(pCadena) <> "" And Trim(pCadena) <> "-" And Trim(pCadena) <> "." Then
            If IsNumeric(pCadena) Then
                Arreglo = Split(Replace(pCadena, "-", ""), ".")

                '--- Enteros

                If Len(Arreglo(0)) > pEnteros Then
                    Monto_Verifica = False
                Else
                    If UBound(Arreglo) > 0 Then
                        '--- Decimales

                        If Len(Arreglo(1)) > pDecimales Then
                            Monto_Verifica = False
                        End If
                    End If
                End If
            Else
                Monto_Verifica = False
            End If
        End If
    End Function
#End Region

    Private Sub MiTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MiTextBox.Enter
        If _Miles Then
            MiTextBox.Text = Replace(MiTextBox.Text, ",", "")
        End If

        MiTextBox.SelectAll()
    End Sub

    Private Sub MiTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MiTextBox.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                e.Handled = (Monto_KeyDelete(MiTextBox, _Enteros, _Decimales) = 0)
        End Select
    End Sub

    Private Sub MiTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MiTextBox.KeyPress
        Dim KeyAscii As Integer

        KeyAscii = Asc(e.KeyChar)

        Select Case KeyAscii
            Case 8, 48 To 57
                e.Handled = (Monto_KeyAscii(MiTextBox, KeyAscii, _Enteros, _Decimales) = 0)
            Case 45
                If _Negativo Then
                    e.Handled = (Monto_KeyAscii(MiTextBox, KeyAscii, _Enteros, _Decimales) = 0)
                Else
                    e.Handled = True
                End If
            Case 46
                If _Decimales > 0 Then
                    e.Handled = (Monto_KeyAscii(MiTextBox, KeyAscii, _Enteros, _Decimales) = 0)
                Else
                    e.Handled = True
                End If
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub MiTextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MiTextBox.Leave
        If MiTextBox.Enabled Then
            If Formato <> "" Then
                If IsNumeric(MiTextBox.Text) Then
                    MiTextBox.Text = Format(CDbl(MiTextBox.Text), Formato)
                Else
                    If IsNumeric(_Default) Then
                        MiTextBox.Text = Format(CDbl(_Default), Formato)
                    Else
                        MiTextBox.Text = _Default
                    End If
                End If
            Else
                If Not IsNumeric(MiTextBox.Text) Then
                    MiTextBox.Text = _Default
                End If
            End If
        End If
    End Sub

    Public Sub New(ByRef pText As TextBox, ByVal pEnteros As Integer, ByVal pDecimales As Integer, ByVal pNegativo As Boolean, ByVal pDefault As String, Optional ByVal pFormato As String = "#,##0")
        Inicializa(pText, pEnteros, pDecimales, pNegativo, pDefault, pFormato)
    End Sub
End Class
