Imports System.Text
Imports Neodynamic.WinControls.BarcodeProfessional
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class TCodigoBarra
#Region "Variables"
    Private _Impresora As String
    Private _Etiquetas As New List(Of TEtiquetaInfo)
    Private _TipoEtiqueta As EtiquetasEnum
    Private _Etiqueta As TEtiquetaInfo
    Private _CantidadCodigosHojaTamanoCarta As Long


#End Region
#Region "Propiedades"
    Public WriteOnly Property Impresora As String
        Set(value As String)
            _Impresora = value
        End Set
    End Property
    Public WriteOnly Property Etiquetas As List(Of TEtiquetaInfo)
        Set(value As List(Of TEtiquetaInfo))
            _Etiquetas = value
        End Set
    End Property
    Public WriteOnly Property Etiqueta As TEtiquetaInfo
        Set(value As TEtiquetaInfo)
            _Etiqueta = value
        End Set
    End Property

    Public WriteOnly Property TipoEtiqueta As EtiquetasEnum
        Set(value As EtiquetasEnum)
            _TipoEtiqueta = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        _Impresora = ImpresoraPredeterminada()
        _Etiquetas.Clear()
        _TipoEtiqueta = EtiquetasEnum.DosColumna_CincoxDosPuntoDos
        _Etiqueta = Nothing
    End Sub
#End Region
#Region "Metodos Publicos"
    Public Sub ImprimirEstandar(pCopias As Short, pEtiquetas As Long)


        If (pEtiquetas Mod 4) > 0 Then
            Dim EtiquetaTemporal As Integer = (pEtiquetas / 4)
            EtiquetaTemporal = EtiquetaTemporal + 1
            pEtiquetas = ((EtiquetaTemporal) * 4)

        End If

        _CantidadCodigosHojaTamanoCarta = pEtiquetas
        Dim pdBarCode As New PrintDocument()

        Dim pkCustomSize1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 220, 280)

        'Select Case _TipoEtiqueta
        '    Case EtiquetasEnum.CincoColumna_CincoxDosPuntoDos
        '        pkCustomSize1 = pdBarCode.PrinterSettings.PaperSizes(1)
        '    Case Else

        'End Select


        With pdBarCode
            .PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
            .PrinterSettings.PrinterName = _Impresora
            .DefaultPageSettings.Margins.Left = 0
            .DefaultPageSettings.Margins.Right = 0
            .DefaultPageSettings.Margins.Top = 0
            .DefaultPageSettings.Margins.Bottom = 0
            .DefaultPageSettings.PrinterSettings.Copies = pCopias
            AddHandler .PrintPage, AddressOf EnviarParalelo
            .Print()
        End With
    End Sub
    Private Sub EnviarParalelo(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Select Case _TipoEtiqueta
            Case EtiquetasEnum.DosColumna_CincoxDosPuntoDos
                ImprimeEtiqueta1(sender, ev)
            Case EtiquetasEnum.UnaColumna_NuevexDosPuntoCinco
                ImprimeEtiqueta2(sender, ev)
            Case EtiquetasEnum.CincoColumna_CincoxDosPuntoDos
                ImprimeHoja(sender, ev)
        End Select
    End Sub

    Private Sub ImprimeEtiqueta1(ByVal sender As Object, ByVal ev As PrintPageEventArgs)

        Dim PosY As Single = 0.0F
        Dim fnt1 As New Font("Arial", 7.0F, FontStyle.Bold)
        Dim fnt2 As New Font("Arial", 10.5F, FontStyle.Bold)
        Dim bcpBarCode As BarcodeProfessional = Nothing
        'Posiciones

        Dim PosLeftCodigo As Single = 0
        Dim PosLeftDescripcion As Single = 0
        Dim PosLeftPrecio As Single = 0

        bcpBarCode = New BarcodeProfessional

        With bcpBarCode
            .Symbology = Symbology.Code128
            .LicenseOwner = "Logical Data Technology-Standard Edition-Developer License"
            .LicenseKey = "YH4NZRUPCQQLSS2FNQ3M59ZUNCX28SLHRNBDSAMGLLM26MMNYHDQ"
        End With


        PosLeftCodigo = 0.15F
        PosLeftDescripcion = 3.0F
        PosLeftPrecio = 3.0F

        With bcpBarCode
            .BarWidth = 0.01041666666
            .BarHeight = 0.2
            .BarRatio = 2
            .GuardBar = True
            .QuietZoneWidth = 0.01
            .CodeAlignment = Alignment.BelowJustify

            .Code = _Etiqueta.Codigo
            .Left = 300
            .AddChecksum = False
            .DisplayLightMarginIndicator = False
            .DrawOnCanvas(ev.Graphics, New PointF(PosLeftCodigo, 0.55F), 0.875F)
            '.DrawOnCanvas(ev.Graphics, New PointF(PosLeftCodigo, 0.55F), 0.89F)
            ev.Graphics.DrawString(Mid(_Etiqueta.Descripcion, 1, 30), fnt1, Brushes.Black, New PointF(PosLeftDescripcion, 5.0F)) ' si se usa el text este no es necesario
            ev.Graphics.DrawString(_Etiqueta.Precio & " " & _Etiqueta.LeyendaImpuesto, fnt2, Brushes.Black, New PointF(PosLeftPrecio, 25.0F))
        End With


        PosLeftCodigo = 2.26F
        PosLeftDescripcion = 215.0F
        PosLeftPrecio = 212.0F


        With bcpBarCode
            .BarWidth = 0.01041666666
            .BarHeight = 0.2
            .BarRatio = 2
            .GuardBar = True
            .QuietZoneWidth = 0.01
            .CodeAlignment = Alignment.BelowJustify

            .Code = _Etiqueta.Codigo
            .Left = 300
            .AddChecksum = False
            .DisplayLightMarginIndicator = False
            .DrawOnCanvas(ev.Graphics, New PointF(PosLeftCodigo, 0.55F), 0.875F)
            '.DrawOnCanvas(ev.Graphics, New PointF(PosLeftCodigo, 0.55F), 0.89F)
            ev.Graphics.DrawString(Mid(_Etiqueta.Descripcion, 1, 30), fnt1, Brushes.Black, New PointF(PosLeftDescripcion, 5.0F)) ' si se usa el text este no es necesario
            ev.Graphics.DrawString(_Etiqueta.Precio & " " & _Etiqueta.LeyendaImpuesto, fnt2, Brushes.Black, New PointF(PosLeftPrecio, 25.0F))
        End With



    End Sub

    Private Sub ImprimeHoja(ByVal sender As Object, ByVal ev As PrintPageEventArgs)

        Dim PosY As Single = 0.0F
        Dim fnt1 As New Font("Arial", 7.0F, FontStyle.Bold)
        Dim fnt2 As New Font("Arial", 8.5F, FontStyle.Bold)
        Dim bcpBarCode As BarcodeProfessional = Nothing
        'Posiciones

        Dim PosLeftCodigo As Single = 0
        Dim PosLeftDescripcion As Single = 0
        Dim PosLeftPrecio As Single = 0

        Dim PosEjeYCodigo As Single = 0
        Dim PosEjeYDescripcion As Single = 0
        Dim PosEjeYPrecio As Single = 0

        Dim r As Decimal = 0.0



        bcpBarCode = New BarcodeProfessional()

        With bcpBarCode
            .Symbology = Symbology.Code128
            .LicenseOwner = "Logical Data Technology-Standard Edition-Developer License"
            .LicenseKey = "YH4NZRUPCQQLSS2FNQ3M59ZUNCX28SLHRNBDSAMGLLM26MMNYHDQ"
        End With

        For i = 0 To ((_CantidadCodigosHojaTamanoCarta / 4) - 1)

            PosEjeYCodigo = (0.55F + (110 * i))
            PosEjeYDescripcion = (5.0F + (110 * i))
            PosEjeYPrecio = (25.0F + (110 * i))


            For j = 0 To 3

                PosLeftCodigo = (0.15F + (2.09 * j))
                PosLeftDescripcion = (3.0F + (212 * j))
                PosLeftPrecio = (3.0F + (212 * j))

                With bcpBarCode
                    .BarWidth = 0.01041666666
                    .BarHeight = 0.2
                    .BarRatio = 2
                    .GuardBar = True
                    .QuietZoneWidth = 0.01
                    .CodeAlignment = Alignment.BelowJustify
                    .Code = _Etiqueta.Codigo
                    .Left = 300
                    .AddChecksum = False
                    .DisplayLightMarginIndicator = False
                    .DrawOnCanvas(ev.Graphics, New PointF(PosLeftCodigo, 0.55 + r), 0.875F)
                    ev.Graphics.DrawString(Mid(_Etiqueta.Descripcion, 1, 30), fnt1, Brushes.Black, New PointF(PosLeftDescripcion, PosEjeYDescripcion))
                    ev.Graphics.DrawString(_Etiqueta.Precio & " " & _Etiqueta.LeyendaImpuesto, fnt2, Brushes.Black, New PointF(PosLeftPrecio, PosEjeYPrecio))
                End With


            Next
            r = r + 1.1
        Next
        r = 0
        bcpBarCode = Nothing


    End Sub

    Private Sub ImprimeEtiqueta2(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim PosY As Single = 0.0F
        Dim fnt1 As New Font("Arial", 10.0F, FontStyle.Bold)
        Dim fnt2 As New Font("Arial", 9.0F, FontStyle.Bold)
        Dim bcpBarCode As BarcodeProfessional = Nothing

        'Posiciones

        Dim PosLeftPrecio As Single = 0
        Dim PosLeftCodigo As Single = 0
        Dim PosLeftDescripcion As Single = 0
        Dim PosLeftArt_Id As Single = 0
        Dim PosLefEmpresa As Single = 0

        bcpBarCode = New BarcodeProfessional

        With bcpBarCode
            .Symbology = Symbology.Code128
            .LicenseOwner = "Logical Data Technology-Standard Edition-Developer License"
            .LicenseKey = "YH4NZRUPCQQLSS2FNQ3M59ZUNCX28SLHRNBDSAMGLLM26MMNYHDQ"
        End With


        PosLeftCodigo = 0.2F
        PosLeftDescripcion = 6.0F
        PosLeftArt_Id = 12.0F
        PosLefEmpresa = 160

        With bcpBarCode
            .BarWidth = 0.01041666666
            .BarHeight = 0.2
            .BarRatio = 2
            .GuardBar = True
            .QuietZoneWidth = 0.01
            .CodeAlignment = Alignment.BelowJustify

            .Code = _Etiqueta.Codigo
            .Left = 300
            .AddChecksum = False
            .DisplayLightMarginIndicator = False
            '.DrawOnCanvas(ev.Graphics, New PointF(PosLeftCodigo, 0.55F), 0.875F)
            .DrawOnCanvas(ev.Graphics, New PointF(PosLeftCodigo, 0.55F), 0.89F)
            'ev.Graphics.DrawString(Mid(_Etiqueta.Descripcion, 1, 50), fnt1, Brushes.Black, New PointF(PosLeftDescripcion, 1.0F)) ' si se usa el text este no es necesario
            ev.Graphics.DrawString(_Etiqueta.Precio & " " & _Etiqueta.LeyendaImpuesto, fnt2, Brushes.Black, New PointF(PosLeftPrecio, 25.0F))
            ev.Graphics.DrawString(_Etiqueta.Codigo, fnt2, Brushes.Black, New PointF(PosLeftArt_Id, 25.0F))

            ev.Graphics.DrawString(EmpresaInfo.Nombre, fnt2, Brushes.Black, New PointF(PosLefEmpresa, 50.0F))

        End With

    End Sub
#End Region
End Class
