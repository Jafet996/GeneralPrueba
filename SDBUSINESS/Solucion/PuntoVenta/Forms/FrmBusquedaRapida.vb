Imports Business
Public Class FrmBusquedaRapida
#Region "Variables de la forma"
    Private _Cantidad As Double
    Private _Art_Id As String
#End Region

#Region "Propiedades"
    Public ReadOnly Property Cantidad As Integer
        Get
            Return _Cantidad
        End Get
    End Property
    Public ReadOnly Property Art_Id As String
        Get
            Return _Art_Id
        End Get
    End Property
#End Region

#Region "Constantes privadas"
    Private Const coCategoriaAltoPanel2 = 214
    Private Const coCategoriaAnchoPanel2 = 103

    Private Const coCategoriaLeftPanel2 = 2
    Private Const coCategoriaTopPanel2 = 2

    Private Const coSubCategoriaAltoPanel2 = 463
    Private Const coSubCategoriaAnchoPanel2 = 103

    Private Const coSubCategoriaLeftPanel2 = 2
    Private Const coSubCategoriaTopPanel2 = 220

    Private Const coArticuloAltoPanel2 = 681
    Private Const coArticuloAnchoPanel2 = 500

    Private Const coFrecuentesAltoPanel2 = 681
    Private Const coFrecuentesAnchoPanel2 = 500

    Private Const coArticuloLeftPanel2 = 150
    Private Const coArticuloTopPanel2 = 2

    Private Const coFrecuentesLeftPanel2 = 695
    Private Const coFrecuentesTopPanel2 = 2

    'Posicion de flechas de toma de orden
    Private Const coCategoriaIzquierda_Left2 = 110
    Private Const coCategoriaIzquierda_Top2 = 22
    Private Const coCategoriaIzquierda_Alto2 = 32
    Private Const coCategoriaIzquierda_Ancho2 = 32

    Private Const coCategoriaDerecha_Left2 = 110
    Private Const coCategoriaDerecha_Top2 = 170
    Private Const coCategoriaDerecha_Alto2 = 32
    Private Const coCategoriaDerecha_Ancho2 = 32

    Private Const coSubCategoriaIzquierda_Left2 = 110
    Private Const coSubCategoriaIzquierda_Top2 = 240
    Private Const coSubCategoriaIzquierda_Alto2 = 32
    Private Const coSubCategoriaIzquierda_Ancho2 = 32

    Private Const coSubCategoriaDerecha_Left2 = 110
    Private Const coSubCategoriaDerecha_Top2 = 575
    Private Const coSubCategoriaDerecha_Alto2 = 32
    Private Const coSubCategoriaDerecha_Ancho2 = 32

    Private Const coArticuloIzquierda_Left2 = 508
    Private Const coArticuloIzquierda_Top2 = 22
    Private Const coArticuloIzquierda_Alto2 = 32
    Private Const coArticuloIzquierda_Ancho2 = 32

    Private Const coArticuloDerecha_Left2 = 508
    Private Const coArticuloDerecha_Top2 = 575
    Private Const coArticuloDerecha_Alto2 = 32
    Private Const coArticuloDerecha_ancho2 = 32

    Private Const coFrecuentesIzquierda_Left2 = 1195
    Private Const coFrecuentesIzquierda_Top2 = 22
    Private Const coFrecuentesIzquierda_Alto2 = 32
    Private Const coFrecuentesIzquierda_Ancho2 = 32

    Private Const coFrecuentesDerecha_Left2 = 1195
    Private Const coFrecuentesDerecha_Top2 = 634
    Private Const coFrecuentesDerecha_Alto2 = 32
    Private Const coFrecuentesDerecha_ancho2 = 32


#End Region

#Region "Variables de objetos"
    Dim PnlArticulos As New System.Windows.Forms.Panel
    Dim PnlSubCategorias As New System.Windows.Forms.Panel
    Dim PnlCategorias As New System.Windows.Forms.Panel
    Dim PnlFrecuentes As New System.Windows.Forms.Panel

    Dim BotonesCategoria() As TBoton
    Dim BotonesSubCategoria() As TBoton
    Dim BotonesArticulo() As TBoton
    Dim BotonesFrecuentes() As TBoton
#End Region



    Public Sub Execute()
        _Cantidad = 0
        _Art_Id = ""

        CreaPantalla()
        Me.ShowDialog()
    End Sub

    Private Sub CreaInterfazPantalla()
        Dim FrecuentesAnchoPanel As Integer = 0
        Dim FrecuentesAltoPanel As Integer = 0
        Dim FrecuentesLeftPanel As Integer = 0
        Dim FrecuentesTopPanel As Integer = 0

        Dim ArticuloAnchoPanel As Integer = 0
        Dim ArticuloAltoPanel As Integer = 0
        Dim ArticuloLeftPanel As Integer = 0
        Dim ArticuloTopPanel As Integer = 0

        Dim SubCategoriaAnchoPanel As Integer = 0
        Dim SubCategoriaAltoPanel As Integer = 0
        Dim SubCategoriaLeftPanel As Integer = 0
        Dim SubCategoriaTopPanel As Integer = 0

        Dim CategoriaAnchoPanel As Integer = 0
        Dim CategoriaAltoPanel As Integer = 0
        Dim CategoriaLeftPanel As Integer = 0
        Dim CategoriaTopPanel As Integer = 0

        Dim SubCategoriaIzquierda_Left As Integer = 0
        Dim SubCategoriaIzquierda_Top As Integer = 0
        Dim SubCategoriaDerecha_Left As Integer = 0
        Dim SubCategoriaDerecha_Top As Integer = 0
        Dim SubCategoriaDerecha_Alto As Integer = 0
        Dim SubCategoriaDerecha_Ancho As Integer = 0
        Dim SubCategoriaIzquierda_Alto As Integer = 0
        Dim SubCategoriaIzquierda_Ancho As Integer = 0

        Dim ArticuloIzquierda_Left As Integer = 0
        Dim ArticuloIzquierda_Top As Integer = 0
        Dim ArticuloIzquierda_Alto As Integer = 0
        Dim ArticuloIzquierda_Ancho As Integer = 0
        Dim ArticuloDerecha_Left As Integer = 0
        Dim ArticuloDerecha_Top As Integer = 0
        Dim ArticuloDerecha_Alto As Integer = 0
        Dim ArticuloDerecha_Ancho As Integer = 0

        Dim FrecuentesIzquierda_Left As Integer = 0
        Dim FrecuentesIzquierda_Top As Integer = 0
        Dim FrecuentesIzquierda_Alto As Integer = 0
        Dim FrecuentesIzquierda_Ancho As Integer = 0
        Dim FrecuentesDerecha_Left As Integer = 0
        Dim FrecuentesDerecha_Top As Integer = 0
        Dim FrecuentesDerecha_Alto As Integer = 0
        Dim FrecuentesDerecha_Ancho As Integer = 0

        Dim CategoriaIzquierda_Left As Integer = 0
        Dim CategoriaIzquierda_Top As Integer = 0
        Dim CategoriaDerecha_Left As Integer = 0
        Dim CategoriaDerecha_Top As Integer = 0
        Dim CategoriaDerecha_Alto As Integer = 0
        Dim CategoriaDerecha_Ancho As Integer = 0
        Dim CategoriaIzquierda_Alto As Integer = 0
        Dim CategoriaIzquierda_Ancho As Integer = 0

        'Tamano de los paneles
        ArticuloAnchoPanel = coArticuloAnchoPanel2
        ArticuloAltoPanel = coArticuloAltoPanel2
        SubCategoriaAnchoPanel = coSubCategoriaAnchoPanel2
        SubCategoriaAltoPanel = coSubCategoriaAltoPanel2
        CategoriaAnchoPanel = coCategoriaAnchoPanel2
        CategoriaAltoPanel = coCategoriaAltoPanel2

        FrecuentesAnchoPanel = coFrecuentesAnchoPanel2
        FrecuentesAltoPanel = coFrecuentesAltoPanel2
        'Posicion de los panels
        CategoriaLeftPanel = coCategoriaLeftPanel2
        CategoriaTopPanel = coCategoriaTopPanel2
        SubCategoriaLeftPanel = coSubCategoriaLeftPanel2
        SubCategoriaTopPanel = coSubCategoriaTopPanel2
        ArticuloLeftPanel = coArticuloLeftPanel2
        ArticuloTopPanel = coArticuloTopPanel2
        FrecuentesLeftPanel = coFrecuentesLeftPanel2
        FrecuentesTopPanel = coFrecuentesTopPanel2
        'Posicion de fechas
        CategoriaIzquierda_Left = coCategoriaIzquierda_Left2
        CategoriaIzquierda_Top = coCategoriaIzquierda_Top2
        CategoriaDerecha_Left = coCategoriaDerecha_Left2
        CategoriaDerecha_Top = coCategoriaDerecha_Top2
        SubCategoriaIzquierda_Left = coSubCategoriaIzquierda_Left2
        SubCategoriaIzquierda_Top = coSubCategoriaIzquierda_Top2
        SubCategoriaDerecha_Left = coSubCategoriaDerecha_Left2
        SubCategoriaDerecha_Top = coSubCategoriaDerecha_Top2
        ArticuloIzquierda_Left = coArticuloIzquierda_Left2
        ArticuloIzquierda_Top = coArticuloIzquierda_Top2
        ArticuloDerecha_Left = coArticuloDerecha_Left2
        ArticuloDerecha_Top = coArticuloDerecha_Top2

        FrecuentesIzquierda_Left = coFrecuentesIzquierda_Left2
        FrecuentesIzquierda_Top = coFrecuentesIzquierda_Top2
        FrecuentesDerecha_Left = coFrecuentesDerecha_Left2
        FrecuentesDerecha_Top = coFrecuentesDerecha_Top2

        'Tamano de las flechas
        ArticuloDerecha_Alto = coArticuloDerecha_Alto2
        ArticuloDerecha_Ancho = coArticuloDerecha_ancho2
        ArticuloIzquierda_Alto = coArticuloIzquierda_Alto2
        ArticuloIzquierda_Ancho = coArticuloIzquierda_Ancho2
        FrecuentesDerecha_Alto = coFrecuentesDerecha_Alto2
        FrecuentesDerecha_Ancho = coFrecuentesDerecha_ancho2
        FrecuentesIzquierda_Alto = coFrecuentesIzquierda_Alto2
        FrecuentesIzquierda_Ancho = coFrecuentesIzquierda_Ancho2

        SubCategoriaDerecha_Alto = coSubCategoriaDerecha_Alto2
        SubCategoriaDerecha_Ancho = coSubCategoriaDerecha_Ancho2
        SubCategoriaIzquierda_Alto = coSubCategoriaIzquierda_Alto2
        SubCategoriaIzquierda_Ancho = coSubCategoriaIzquierda_Ancho2
        CategoriaDerecha_Alto = coCategoriaDerecha_Alto2
        CategoriaDerecha_Ancho = coCategoriaDerecha_Ancho2
        CategoriaIzquierda_Alto = coCategoriaIzquierda_Alto2
        CategoriaIzquierda_Ancho = coCategoriaIzquierda_Ancho2


        'Crea paneles

        PnlFrecuentes.Parent = Me
        PnlFrecuentes.AutoScroll = False
        PnlFrecuentes.Location = New System.Drawing.Point(FrecuentesLeftPanel, FrecuentesTopPanel)
        PnlFrecuentes.Name = "PnlFrecuentes"
        PnlFrecuentes.Size = New System.Drawing.Size(FrecuentesAnchoPanel, FrecuentesAltoPanel)
        PnlFrecuentes.BackColor = Color.White
        'PnlFrecuentes.BorderStyle = BorderStyle.Fixed3D

        PnlArticulos.Parent = Me
        PnlArticulos.AutoScroll = False
        PnlArticulos.Location = New System.Drawing.Point(ArticuloLeftPanel, ArticuloTopPanel)
        PnlArticulos.Name = "PnlArticulos"
        PnlArticulos.Size = New System.Drawing.Size(ArticuloAnchoPanel, ArticuloAltoPanel)
        PnlArticulos.BackColor = Color.White

        'PnlArticulos.BorderStyle = BorderStyle.Fixed3D

        PnlSubCategorias.Parent = Me
        PnlSubCategorias.AutoScroll = False
        PnlSubCategorias.Location = New System.Drawing.Point(SubCategoriaLeftPanel, SubCategoriaTopPanel)
        PnlSubCategorias.Name = "PnlSubCategorias"
        PnlSubCategorias.Size = New System.Drawing.Size(SubCategoriaAnchoPanel, SubCategoriaAltoPanel)
        PnlSubCategorias.BackColor = Color.White
        'PnlSubCategorias.BorderStyle = BorderStyle.Fixed3D


        PnlCategorias.Parent = Me
        PnlCategorias.AutoScroll = False
        PnlCategorias.Location = New System.Drawing.Point(CategoriaLeftPanel, CategoriaTopPanel)
        PnlCategorias.Name = "PnlCategorias"
        PnlCategorias.Size = New System.Drawing.Size(CategoriaAnchoPanel, CategoriaAltoPanel)
        PnlCategorias.BackColor = Color.White
        'PnlCategorias.BorderStyle = BorderStyle.Fixed3D

        'Posiciona las flechas
        'Categoria
        With PicCategoriaLeft
            '.Left = CategoriaIzquierda_Left
            '.Top = CategoriaIzquierda_Top
            .Width = CategoriaIzquierda_Ancho
            .Height = CategoriaIzquierda_Alto
        End With

        With PicCategoriaRight
            '.Left = CategoriaDerecha_Left
            '.Top = CategoriaDerecha_Top
            .Width = CategoriaIzquierda_Ancho
            .Height = CategoriaIzquierda_Alto
        End With
        'Sub Categoria
        With PicSubCategoriaLeft
            '.Left = SubCategoriaIzquierda_Left
            '.Top = SubCategoriaIzquierda_Top
            .Width = SubCategoriaIzquierda_Ancho
            .Height = SubCategoriaIzquierda_Alto
        End With

        With PicSubCategoriaRight
            '.Left = SubCategoriaDerecha_Left
            '.Top = SubCategoriaDerecha_Top
            .Width = SubCategoriaDerecha_Ancho
            .Height = SubCategoriaDerecha_Alto
        End With
        'Articulo
        With PicArticuloLeft
            '.Left = ArticuloIzquierda_Left
            '.Top = ArticuloIzquierda_Top
            .Width = ArticuloIzquierda_Ancho
            .Height = ArticuloIzquierda_Alto
        End With

        With PicArticuloRight
            '.Left = ArticuloDerecha_Left
            '.Top = ArticuloDerecha_Top
            .Width = ArticuloDerecha_Ancho
            .Height = ArticuloDerecha_Alto
        End With
        'Frecuentes
        With PicFrecuentesLeft
            '.Left = FrecuentesIzquierda_Left
            '.Top = FrecuentesIzquierda_Top
            .Width = FrecuentesIzquierda_Ancho
            .Height = FrecuentesIzquierda_Alto
        End With

        With PicFrecuentesRight
            '.Left = FrecuentesDerecha_Left
            '.Top = FrecuentesDerecha_Top
            .Width = FrecuentesDerecha_Ancho
            .Height = FrecuentesDerecha_Alto
        End With

    End Sub

    Private Sub DestruyeBotonesCategorias()
        DestruyeBotones(PnlCategorias, BotonesCategoria, coNombreCategoriaPrefijo)

        InicializaFlechas(PicCategoriaLeft, PicCategoriaRight)
    End Sub

    Private Sub DestruyeBotonesSubCategorias()
        DestruyeBotones(PnlSubCategorias, BotonesSubCategoria, coNombreSubCategoriaPrefijo)

        InicializaFlechas(PicSubCategoriaLeft, PicSubCategoriaRight)
    End Sub
    Private Sub DestruyeBotonesArticulos()

        BtnCantidad.Enabled = False

        DestruyeBotones(PnlArticulos, BotonesArticulo, coNombreArticuloPrefijo)
        InicializaFlechas(PicArticuloLeft, PicArticuloRight)
    End Sub

    Private Sub CreacionBotonesCategorias()
        Dim Categoria As New TCategoria(EmpresaInfo.Emp_Id)
        Dim i As Integer = 0
        Dim Mensaje As String = ""
        Try
            'Destruye los botones actuales
            DestruyeBotonesCategorias()

            Mensaje = Categoria.LlenaArreglo(BotonesCategoria)
            VerificaMensaje(Mensaje)

            If Categoria.CantidadBotones > 0 Then
                'Crea las categorias
                Mensaje = CreaBotones(BotonesCategoria, PnlCategorias, coTipoBotonCategoria, PicCategoriaLeft, PicCategoriaRight)
                VerificaMensaje(Mensaje)

                For i = 0 To UBound(BotonesCategoria)
                    AddHandler BotonesCategoria(i).Click, AddressOf BotonCategoriaClick
                Next

            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Categoria = Nothing
        End Try
    End Sub
    Private Sub CreacionBotonesSubCategorias(ByVal pCat_Id As Integer)
        Dim SubCategoria As New TSubCategoria(EmpresaInfo.Emp_Id)
        Dim i As Integer = 0
        Dim Mensaje As String = ""
        Try
            'Destruye los botones actuales
            DestruyeBotonesSubCategorias()

            SubCategoria.Cat_Id = pCat_Id
            Mensaje = SubCategoria.LlenaArreglo(BotonesSubCategoria)
            VerificaMensaje(Mensaje)
            'Crea las subcategorias
            If SubCategoria.CantidadBotones > 0 Then
                Mensaje = CreaBotones(BotonesSubCategoria, PnlSubCategorias, coTipoBotonSubCategoria, PicSubCategoriaLeft, PicSubCategoriaRight)
                VerificaMensaje(Mensaje)

                For i = 0 To UBound(BotonesSubCategoria)
                    AddHandler BotonesSubCategoria(i).Click, AddressOf BotonSubCategoriaClick
                Next
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            SubCategoria = Nothing
        End Try
    End Sub

    Private Sub CreacionBotonesArticulos(ByVal pCat_Id As Integer, ByVal pSubCat_Id As Integer)
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim i As Integer = 0
        Dim Mensaje As String = ""
        Try
            'Destruye los botones actuales
            DestruyeBotonesArticulos()


            Articulo.Cat_Id = pCat_Id
            Articulo.SubCat_Id = pSubCat_Id
            Mensaje = Articulo.LlenaArreglo(BotonesArticulo)
            VerificaMensaje(Mensaje)
            If Articulo.CantidadBotones > 0 Then
                'Crea los articulos
                CreaBotones(BotonesArticulo, PnlArticulos, coTipoBotonArticulo, PicArticuloLeft, PicArticuloRight)

                For i = 0 To UBound(BotonesArticulo)
                    AddHandler BotonesArticulo(i).Click, AddressOf BotonArticuloClick
                Next
                BtnCantidad.Enabled = True
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub

    Private Sub CreaPantalla()
        CreaInterfazPantalla()
        CreacionBotonesCategorias()
        CreacionBotonesFrecuentes()
    End Sub

    Private Sub FrmBusquedaRapida_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        BotonesCategoria = Nothing
        BotonesSubCategoria = Nothing
        BotonesArticulo = Nothing
        BotonesFrecuentes = Nothing
        PnlArticulos = Nothing
        PnlSubCategorias = Nothing
        PnlCategorias = Nothing
    End Sub

    Private Sub PicCategoriaLeft_Click(sender As System.Object, e As System.EventArgs) Handles PicCategoriaLeft.Click
        Dim PosIniVisible As Integer = -1
        Dim PosFinVisible As Integer = -1
        Try
            BuscaRangoVisibleAtras(BotonesCategoria, CInt(PicCategoriaLeft.Tag), PosIniVisible, PosFinVisible)

            OcultaBotones(BotonesCategoria)

            MuestraBotones(BotonesCategoria, PosIniVisible, PosFinVisible)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub PicCategoriaRight_Click(sender As System.Object, e As System.EventArgs) Handles PicCategoriaRight.Click
        Dim PosIniVisible As Integer = -1
        Dim PosFinVisible As Integer = -1
        Try
            BuscaRangoVisibleAdelante(BotonesCategoria, CInt(PicCategoriaRight.Tag), PosIniVisible, PosFinVisible)

            OcultaBotones(BotonesCategoria)

            MuestraBotones(BotonesCategoria, PosIniVisible, PosFinVisible)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


    Private Sub BotonCategoriaClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Btn As TBoton
        Try
            Btn = CType(sender, TBoton)

            PnlCategorias.Tag = Btn.Tag
            MarcaDesmarcaBotones(BotonesCategoria, Btn, False)

            DestruyeBotonesSubCategorias()
            DestruyeBotonesArticulos()
            CreacionBotonesSubCategorias(CInt(Btn.Tag))

            If PnlSubCategorias.Controls.Count > 0 Then
                BotonSubCategoriaClick(PnlSubCategorias.Controls(0), Nothing)
            End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub BotonSubCategoriaClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Btn As TBoton
        Btn = CType(sender, TBoton)

        PnlSubCategorias.Tag = Btn.Tag
        MarcaDesmarcaBotones(BotonesSubCategoria, Btn, False)

        DestruyeBotonesArticulos()
        CreacionBotonesArticulos(CInt(PnlCategorias.Tag), CInt(Btn.Tag))

    End Sub
    Private Sub BotonArticuloClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Btn As TBoton
        'Dim f As New FrmNumeros
        Try
            Btn = CType(sender, TBoton)

            PnlArticulos.Tag = Btn.Tag

            'IngresaArticulo(Btn)

            MarcaDesmarcaBotones(BotonesArticulo, Btn, False)

            _Art_Id = Btn.Tag

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub PicSubCategoriaLeft_Click(sender As System.Object, e As System.EventArgs) Handles PicSubCategoriaLeft.Click
        Dim PosIniVisible As Integer = -1
        Dim PosFinVisible As Integer = -1
        Try
            BuscaRangoVisibleAtras(BotonesSubCategoria, CInt(PicSubCategoriaLeft.Tag), PosIniVisible, PosFinVisible)

            OcultaBotones(BotonesSubCategoria)

            MuestraBotones(BotonesSubCategoria, PosIniVisible, PosFinVisible)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub PicSubCategoriaRight_Click(sender As System.Object, e As System.EventArgs) Handles PicSubCategoriaRight.Click
        Dim PosIniVisible As Integer = -1
        Dim PosFinVisible As Integer = -1
        Try
            BuscaRangoVisibleAdelante(BotonesSubCategoria, CInt(PicSubCategoriaRight.Tag), PosIniVisible, PosFinVisible)

            OcultaBotones(BotonesSubCategoria)

            MuestraBotones(BotonesSubCategoria, PosIniVisible, PosFinVisible)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub PicArticuloLeft_Click(sender As System.Object, e As System.EventArgs) Handles PicArticuloLeft.Click
        Dim PosIniVisible As Integer = -1
        Dim PosFinVisible As Integer = -1
        Try
            BuscaRangoVisibleAtras(BotonesArticulo, CInt(PicArticuloLeft.Tag), PosIniVisible, PosFinVisible)

            OcultaBotones(BotonesArticulo)

            MuestraBotones(BotonesArticulo, PosIniVisible, PosFinVisible)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub PicArticuloRight_Click(sender As System.Object, e As System.EventArgs) Handles PicArticuloRight.Click
        Dim PosIniVisible As Integer = -1
        Dim PosFinVisible As Integer = -1
        Try
            BuscaRangoVisibleAdelante(BotonesArticulo, CInt(PicArticuloRight.Tag), PosIniVisible, PosFinVisible)

            OcultaBotones(BotonesArticulo)

            MuestraBotones(BotonesArticulo, PosIniVisible, PosFinVisible)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CreacionBotonesFrecuentes()
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim i As Integer = 0
        Dim Mensaje As String = ""
        Try
            'Destruye los botones actuales
            DestruyeBotonesFrecuentes()

            Mensaje = Articulo.LlenaArregloFrecuentes(BotonesFrecuentes)
            VerificaMensaje(Mensaje)
            If Articulo.CantidadBotones > 0 Then
                'Crea los articulos
                CreaBotones(BotonesFrecuentes, PnlFrecuentes, coTipoBotonFrecuente, PicFrecuentesLeft, PicFrecuentesRight)

                For i = 0 To UBound(BotonesFrecuentes)
                    AddHandler BotonesFrecuentes(i).Click, AddressOf BotonFrecuenteClick
                Next
                BtnCantidad.Enabled = True
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Articulo = Nothing
        End Try
    End Sub
    Private Sub DestruyeBotonesFrecuentes()

        BtnCantidad.Enabled = False

        DestruyeBotones(PnlFrecuentes, BotonesFrecuentes, coNombreFrecuentePrefijo)
        InicializaFlechas(PicFrecuentesLeft, PicFrecuentesRight)
    End Sub
    Private Sub BotonFrecuenteClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Btn As TBoton
        Try
            Btn = CType(sender, TBoton)

            PnlFrecuentes.Tag = Btn.Tag

            'IngresaArticulo(Btn)

            MarcaDesmarcaBotones(BotonesFrecuentes, Btn, False)

            _Art_Id = Btn.Tag

            Me.Close()

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub PicFrecuentesLeft_Click(sender As System.Object, e As System.EventArgs) Handles PicFrecuentesLeft.Click
        Dim PosIniVisible As Integer = -1
        Dim PosFinVisible As Integer = -1
        Try
            BuscaRangoVisibleAtras(BotonesFrecuentes, CInt(PicFrecuentesLeft.Tag), PosIniVisible, PosFinVisible)

            OcultaBotones(BotonesFrecuentes)

            MuestraBotones(BotonesFrecuentes, PosIniVisible, PosFinVisible)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub PicFrecuentesRight_Click(sender As System.Object, e As System.EventArgs) Handles PicFrecuentesRight.Click
        Dim PosIniVisible As Integer = -1
        Dim PosFinVisible As Integer = -1
        Try
            BuscaRangoVisibleAdelante(BotonesFrecuentes, CInt(PicFrecuentesRight.Tag), PosIniVisible, PosFinVisible)

            OcultaBotones(BotonesFrecuentes)

            MuestraBotones(BotonesFrecuentes, PosIniVisible, PosFinVisible)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub BtnCantidad_Click(sender As System.Object, e As System.EventArgs) Handles BtnCantidad.Click
        'Dim f As New FrmNumeros
        'Try

        '    f.Execute(4, _Cantidad)
        '    _Cantidad = f.Cantidad

        'Catch ex As Exception
        '    Mensaje_Error(ex.Message)
        'Finally
        '    f = Nothing
        'End Try
    End Sub

    Private Sub FrmBusquedaRapida_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class