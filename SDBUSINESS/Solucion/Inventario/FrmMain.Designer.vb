<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.MenuStripPrincipal = New System.Windows.Forms.MenuStrip()
        Me.MnuCatalogos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuArticulos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuUnidadMedida = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDepartamento = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCategoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSubCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuArticulo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFamilia = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuArticuloBodega = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPromociones = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSeguridad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGrupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuLotes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuProcesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAjustesDeInventario = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAjusteDeProduccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAjusteDeCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAjusteCostoMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAjusteMargenesMasivoMnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCambioPrecioMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTrasladoDeInventario = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPonerSaldosEnCero = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGenerarEtiqueta = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGeneraEtiqueta = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGeneraEtiquetaCCSS = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGenerarArchivoArticulos = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignaciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConsultaArtículos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuArticulosInactivosSinSaldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaldosInventario = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaldosInventarioProveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaldosDeInventarioSinCostos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaldosXBodega = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaldosDeInventarioAgrupado = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaldosPorCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaldosPorDepartamento = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuListadoTomaFisica = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuListadoPrecios = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuArticulosInactivosConSaldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrasladoPorArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuKardex = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuKardexResumido = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuKardexDetallado = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosActualizadosMnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPreciosXCategoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTomaFisica = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuIniciarTomaFisica = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConteoFisico = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRebajoVentas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReporteDiferencias = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAplicarTomaFisica = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCancelarTomaFísica = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuResultadoTomaFísica = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConexión = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.TSSCompaniaLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSCompania = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSSucursalLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSSucursal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSUsuarioLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.PnlShortCuts = New System.Windows.Forms.Panel()
        Me.BtnAjusteDeInventario = New System.Windows.Forms.Button()
        Me.BtnTrasladoDeInventario = New System.Windows.Forms.Button()
        Me.BtnArticulo = New System.Windows.Forms.Button()
        Me.BtnConsultaArticulos = New System.Windows.Forms.Button()
        Me.BtnConexion = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblEmpresaNombre = New System.Windows.Forms.Label()
        Me.PicFacturacionElectronica = New System.Windows.Forms.PictureBox()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.SaldoInventarioLOTESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripPrincipal.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.PnlShortCuts.SuspendLayout()
        CType(Me.PicFacturacionElectronica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStripPrincipal
        '
        Me.MenuStripPrincipal.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStripPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCatalogos, Me.MnuProcesos, Me.MnuConsultas, Me.MnuReportes, Me.MnuTomaFisica, Me.MnuSistema})
        Me.MenuStripPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripPrincipal.Name = "MenuStripPrincipal"
        Me.MenuStripPrincipal.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStripPrincipal.Size = New System.Drawing.Size(1444, 28)
        Me.MenuStripPrincipal.TabIndex = 0
        Me.MenuStripPrincipal.Text = "MenuStrip1"
        '
        'MnuCatalogos
        '
        Me.MnuCatalogos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuArticulos, Me.MnuArticuloBodega, Me.MnuPromociones, Me.MnuSeguridad, Me.MnuLotes})
        Me.MnuCatalogos.Name = "MnuCatalogos"
        Me.MnuCatalogos.Size = New System.Drawing.Size(88, 24)
        Me.MnuCatalogos.Text = "Catálogos"
        Me.MnuCatalogos.Visible = False
        '
        'MnuArticulos
        '
        Me.MnuArticulos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuUnidadMedida, Me.MnuDepartamento, Me.MnuCategoria, Me.MnuSubCategoría, Me.MnuArticulo, Me.MnuFamilia})
        Me.MnuArticulos.Name = "MnuArticulos"
        Me.MnuArticulos.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MnuArticulos.Size = New System.Drawing.Size(203, 26)
        Me.MnuArticulos.Text = "Artículos"
        '
        'MnuUnidadMedida
        '
        Me.MnuUnidadMedida.Name = "MnuUnidadMedida"
        Me.MnuUnidadMedida.Size = New System.Drawing.Size(187, 26)
        Me.MnuUnidadMedida.Text = "Unidad Medida"
        '
        'MnuDepartamento
        '
        Me.MnuDepartamento.Name = "MnuDepartamento"
        Me.MnuDepartamento.Size = New System.Drawing.Size(187, 26)
        Me.MnuDepartamento.Text = "Departamento"
        '
        'MnuCategoria
        '
        Me.MnuCategoria.Name = "MnuCategoria"
        Me.MnuCategoria.Size = New System.Drawing.Size(187, 26)
        Me.MnuCategoria.Text = "Categoría"
        '
        'MnuSubCategoría
        '
        Me.MnuSubCategoría.Name = "MnuSubCategoría"
        Me.MnuSubCategoría.Size = New System.Drawing.Size(187, 26)
        Me.MnuSubCategoría.Text = "Sub Categoría"
        '
        'MnuArticulo
        '
        Me.MnuArticulo.Name = "MnuArticulo"
        Me.MnuArticulo.Size = New System.Drawing.Size(187, 26)
        Me.MnuArticulo.Text = "Artículo"
        '
        'MnuFamilia
        '
        Me.MnuFamilia.Name = "MnuFamilia"
        Me.MnuFamilia.Size = New System.Drawing.Size(187, 26)
        Me.MnuFamilia.Text = "Familia"
        '
        'MnuArticuloBodega
        '
        Me.MnuArticuloBodega.Name = "MnuArticuloBodega"
        Me.MnuArticuloBodega.Size = New System.Drawing.Size(203, 26)
        Me.MnuArticuloBodega.Text = "Articulo x Bodega"
        '
        'MnuPromociones
        '
        Me.MnuPromociones.Name = "MnuPromociones"
        Me.MnuPromociones.Size = New System.Drawing.Size(203, 26)
        Me.MnuPromociones.Text = "Promociones"
        '
        'MnuSeguridad
        '
        Me.MnuSeguridad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuUsuario, Me.MnuGrupo})
        Me.MnuSeguridad.Name = "MnuSeguridad"
        Me.MnuSeguridad.Size = New System.Drawing.Size(203, 26)
        Me.MnuSeguridad.Text = "Seguridad"
        '
        'MnuUsuario
        '
        Me.MnuUsuario.Name = "MnuUsuario"
        Me.MnuUsuario.Size = New System.Drawing.Size(134, 26)
        Me.MnuUsuario.Text = "Usuario"
        '
        'MnuGrupo
        '
        Me.MnuGrupo.Name = "MnuGrupo"
        Me.MnuGrupo.Size = New System.Drawing.Size(134, 26)
        Me.MnuGrupo.Text = "Grupo"
        '
        'MnuLotes
        '
        Me.MnuLotes.Name = "MnuLotes"
        Me.MnuLotes.Size = New System.Drawing.Size(203, 26)
        Me.MnuLotes.Text = "Lotes"
        '
        'MnuProcesos
        '
        Me.MnuProcesos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAjustesDeInventario, Me.MnuAjusteDeProduccion, Me.MnuAjusteDeCosto, Me.MnuAjusteCostoMasivo, Me.MnuAjusteMargenesMasivoMnu, Me.MnuCambioPrecioMasivo, Me.MnuTrasladoDeInventario, Me.MnuPonerSaldosEnCero, Me.MnuGenerarEtiqueta, Me.MnuGeneraEtiqueta, Me.MnuGeneraEtiquetaCCSS, Me.MnuGenerarArchivoArticulos, Me.AsignaciToolStripMenuItem})
        Me.MnuProcesos.Name = "MnuProcesos"
        Me.MnuProcesos.Size = New System.Drawing.Size(79, 24)
        Me.MnuProcesos.Text = "Procesos"
        Me.MnuProcesos.Visible = False
        '
        'MnuAjustesDeInventario
        '
        Me.MnuAjustesDeInventario.Name = "MnuAjustesDeInventario"
        Me.MnuAjustesDeInventario.Size = New System.Drawing.Size(306, 26)
        Me.MnuAjustesDeInventario.Text = "Ajustes de Inventario"
        '
        'MnuAjusteDeProduccion
        '
        Me.MnuAjusteDeProduccion.Name = "MnuAjusteDeProduccion"
        Me.MnuAjusteDeProduccion.Size = New System.Drawing.Size(306, 26)
        Me.MnuAjusteDeProduccion.Text = "Ajuste de Producción"
        '
        'MnuAjusteDeCosto
        '
        Me.MnuAjusteDeCosto.Name = "MnuAjusteDeCosto"
        Me.MnuAjusteDeCosto.Size = New System.Drawing.Size(306, 26)
        Me.MnuAjusteDeCosto.Text = "Ajuste de Costo"
        '
        'MnuAjusteCostoMasivo
        '
        Me.MnuAjusteCostoMasivo.Name = "MnuAjusteCostoMasivo"
        Me.MnuAjusteCostoMasivo.Size = New System.Drawing.Size(306, 26)
        Me.MnuAjusteCostoMasivo.Text = "Ajuste Costo Masivo"
        '
        'MnuAjusteMargenesMasivoMnu
        '
        Me.MnuAjusteMargenesMasivoMnu.Name = "MnuAjusteMargenesMasivoMnu"
        Me.MnuAjusteMargenesMasivoMnu.Size = New System.Drawing.Size(306, 26)
        Me.MnuAjusteMargenesMasivoMnu.Text = "Ajuste Margenes Masivo"
        '
        'MnuCambioPrecioMasivo
        '
        Me.MnuCambioPrecioMasivo.Name = "MnuCambioPrecioMasivo"
        Me.MnuCambioPrecioMasivo.Size = New System.Drawing.Size(306, 26)
        Me.MnuCambioPrecioMasivo.Text = "Cambio Precio Masivo"
        '
        'MnuTrasladoDeInventario
        '
        Me.MnuTrasladoDeInventario.Name = "MnuTrasladoDeInventario"
        Me.MnuTrasladoDeInventario.Size = New System.Drawing.Size(306, 26)
        Me.MnuTrasladoDeInventario.Text = "Traslado de Inventario"
        '
        'MnuPonerSaldosEnCero
        '
        Me.MnuPonerSaldosEnCero.Name = "MnuPonerSaldosEnCero"
        Me.MnuPonerSaldosEnCero.Size = New System.Drawing.Size(306, 26)
        Me.MnuPonerSaldosEnCero.Text = "Poner Saldos en Cero"
        '
        'MnuGenerarEtiqueta
        '
        Me.MnuGenerarEtiqueta.Name = "MnuGenerarEtiqueta"
        Me.MnuGenerarEtiqueta.Size = New System.Drawing.Size(306, 26)
        Me.MnuGenerarEtiqueta.Text = "Generar Etiqueta"
        '
        'MnuGeneraEtiqueta
        '
        Me.MnuGeneraEtiqueta.Name = "MnuGeneraEtiqueta"
        Me.MnuGeneraEtiqueta.Size = New System.Drawing.Size(306, 26)
        Me.MnuGeneraEtiqueta.Text = "Genera Etiqueta "
        '
        'MnuGeneraEtiquetaCCSS
        '
        Me.MnuGeneraEtiquetaCCSS.Name = "MnuGeneraEtiquetaCCSS"
        Me.MnuGeneraEtiquetaCCSS.Size = New System.Drawing.Size(306, 26)
        Me.MnuGeneraEtiquetaCCSS.Text = "Genera Etiqueta CCSS"
        '
        'MnuGenerarArchivoArticulos
        '
        Me.MnuGenerarArchivoArticulos.Name = "MnuGenerarArchivoArticulos"
        Me.MnuGenerarArchivoArticulos.Size = New System.Drawing.Size(306, 26)
        Me.MnuGenerarArchivoArticulos.Text = "Generar Archivo Articulos"
        '
        'AsignaciToolStripMenuItem
        '
        Me.AsignaciToolStripMenuItem.Name = "AsignaciToolStripMenuItem"
        Me.AsignaciToolStripMenuItem.Size = New System.Drawing.Size(306, 26)
        Me.AsignaciToolStripMenuItem.Text = "Asignación masiva código CABYS"
        '
        'MnuConsultas
        '
        Me.MnuConsultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuConsultaArtículos, Me.MnuArticulosInactivosSinSaldo})
        Me.MnuConsultas.Name = "MnuConsultas"
        Me.MnuConsultas.Size = New System.Drawing.Size(84, 24)
        Me.MnuConsultas.Text = "Consultas"
        Me.MnuConsultas.Visible = False
        '
        'MnuConsultaArtículos
        '
        Me.MnuConsultaArtículos.Name = "MnuConsultaArtículos"
        Me.MnuConsultaArtículos.Size = New System.Drawing.Size(268, 26)
        Me.MnuConsultaArtículos.Text = "Consulta de Artículos"
        '
        'MnuArticulosInactivosSinSaldo
        '
        Me.MnuArticulosInactivosSinSaldo.Name = "MnuArticulosInactivosSinSaldo"
        Me.MnuArticulosInactivosSinSaldo.Size = New System.Drawing.Size(268, 26)
        Me.MnuArticulosInactivosSinSaldo.Text = "Artículos Inactivos sin Saldo"
        '
        'MnuReportes
        '
        Me.MnuReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSaldosInventario, Me.SaldoInventarioLOTESToolStripMenuItem, Me.MnuSaldosInventarioProveedor, Me.MnuSaldosDeInventarioSinCostos, Me.MnuSaldosXBodega, Me.MnuSaldosDeInventarioAgrupado, Me.MnuSaldosPorCategoría, Me.MnuSaldosPorDepartamento, Me.MnuListadoTomaFisica, Me.MnuListadoPrecios, Me.MnuArticulosInactivosConSaldo, Me.TrasladoPorArtículoToolStripMenuItem, Me.MnuKardex, Me.ProductosActualizadosMnu, Me.MnuPreciosXCategoria})
        Me.MnuReportes.Name = "MnuReportes"
        Me.MnuReportes.Size = New System.Drawing.Size(80, 24)
        Me.MnuReportes.Text = "Reportes"
        Me.MnuReportes.Visible = False
        '
        'MnuSaldosInventario
        '
        Me.MnuSaldosInventario.Name = "MnuSaldosInventario"
        Me.MnuSaldosInventario.Size = New System.Drawing.Size(302, 26)
        Me.MnuSaldosInventario.Text = "Saldos de Inventario"
        '
        'MnuSaldosInventarioProveedor
        '
        Me.MnuSaldosInventarioProveedor.Name = "MnuSaldosInventarioProveedor"
        Me.MnuSaldosInventarioProveedor.Size = New System.Drawing.Size(302, 26)
        Me.MnuSaldosInventarioProveedor.Text = "Saldos de Inventario x Proveedor"
        '
        'MnuSaldosDeInventarioSinCostos
        '
        Me.MnuSaldosDeInventarioSinCostos.Name = "MnuSaldosDeInventarioSinCostos"
        Me.MnuSaldosDeInventarioSinCostos.Size = New System.Drawing.Size(302, 26)
        Me.MnuSaldosDeInventarioSinCostos.Text = "Saldos de Inventario (Sin Costos)"
        '
        'MnuSaldosXBodega
        '
        Me.MnuSaldosXBodega.Name = "MnuSaldosXBodega"
        Me.MnuSaldosXBodega.Size = New System.Drawing.Size(302, 26)
        Me.MnuSaldosXBodega.Text = "Saldos de Inventario x Bodega"
        '
        'MnuSaldosDeInventarioAgrupado
        '
        Me.MnuSaldosDeInventarioAgrupado.Name = "MnuSaldosDeInventarioAgrupado"
        Me.MnuSaldosDeInventarioAgrupado.Size = New System.Drawing.Size(302, 26)
        Me.MnuSaldosDeInventarioAgrupado.Text = "Saldos de Inventario Agrupado"
        '
        'MnuSaldosPorCategoría
        '
        Me.MnuSaldosPorCategoría.Name = "MnuSaldosPorCategoría"
        Me.MnuSaldosPorCategoría.Size = New System.Drawing.Size(302, 26)
        Me.MnuSaldosPorCategoría.Text = "Saldos por Categoría"
        '
        'MnuSaldosPorDepartamento
        '
        Me.MnuSaldosPorDepartamento.Name = "MnuSaldosPorDepartamento"
        Me.MnuSaldosPorDepartamento.Size = New System.Drawing.Size(302, 26)
        Me.MnuSaldosPorDepartamento.Text = "Saldos por Departamento"
        '
        'MnuListadoTomaFisica
        '
        Me.MnuListadoTomaFisica.Name = "MnuListadoTomaFisica"
        Me.MnuListadoTomaFisica.Size = New System.Drawing.Size(302, 26)
        Me.MnuListadoTomaFisica.Text = "Listado Toma Física"
        '
        'MnuListadoPrecios
        '
        Me.MnuListadoPrecios.Name = "MnuListadoPrecios"
        Me.MnuListadoPrecios.Size = New System.Drawing.Size(302, 26)
        Me.MnuListadoPrecios.Text = "Listado Precios"
        '
        'MnuArticulosInactivosConSaldo
        '
        Me.MnuArticulosInactivosConSaldo.Name = "MnuArticulosInactivosConSaldo"
        Me.MnuArticulosInactivosConSaldo.Size = New System.Drawing.Size(302, 26)
        Me.MnuArticulosInactivosConSaldo.Text = "Artículos Inactivos con Saldo"
        '
        'TrasladoPorArtículoToolStripMenuItem
        '
        Me.TrasladoPorArtículoToolStripMenuItem.Name = "TrasladoPorArtículoToolStripMenuItem"
        Me.TrasladoPorArtículoToolStripMenuItem.Size = New System.Drawing.Size(302, 26)
        Me.TrasladoPorArtículoToolStripMenuItem.Text = "Traslado por Artículo"
        '
        'MnuKardex
        '
        Me.MnuKardex.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuKardexResumido, Me.MnuKardexDetallado})
        Me.MnuKardex.Name = "MnuKardex"
        Me.MnuKardex.Size = New System.Drawing.Size(302, 26)
        Me.MnuKardex.Text = "Kardex"
        '
        'MnuKardexResumido
        '
        Me.MnuKardexResumido.Name = "MnuKardexResumido"
        Me.MnuKardexResumido.Size = New System.Drawing.Size(150, 26)
        Me.MnuKardexResumido.Text = "Resumido"
        '
        'MnuKardexDetallado
        '
        Me.MnuKardexDetallado.Name = "MnuKardexDetallado"
        Me.MnuKardexDetallado.Size = New System.Drawing.Size(150, 26)
        Me.MnuKardexDetallado.Text = "Detallado"
        '
        'ProductosActualizadosMnu
        '
        Me.ProductosActualizadosMnu.Name = "ProductosActualizadosMnu"
        Me.ProductosActualizadosMnu.Size = New System.Drawing.Size(302, 26)
        Me.ProductosActualizadosMnu.Text = "Articulos Actualizados"
        '
        'MnuPreciosXCategoria
        '
        Me.MnuPreciosXCategoria.Name = "MnuPreciosXCategoria"
        Me.MnuPreciosXCategoria.Size = New System.Drawing.Size(302, 26)
        Me.MnuPreciosXCategoria.Text = "Precios x Categoría"
        '
        'MnuTomaFisica
        '
        Me.MnuTomaFisica.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuIniciarTomaFisica, Me.MnuConteoFisico, Me.MnuRebajoVentas, Me.MnuReporteDiferencias, Me.MnuAplicarTomaFisica, Me.MnuCancelarTomaFísica, Me.MnuResultadoTomaFísica})
        Me.MnuTomaFisica.Name = "MnuTomaFisica"
        Me.MnuTomaFisica.Size = New System.Drawing.Size(98, 24)
        Me.MnuTomaFisica.Text = "Toma Física"
        Me.MnuTomaFisica.Visible = False
        '
        'MnuIniciarTomaFisica
        '
        Me.MnuIniciarTomaFisica.Name = "MnuIniciarTomaFisica"
        Me.MnuIniciarTomaFisica.Size = New System.Drawing.Size(250, 26)
        Me.MnuIniciarTomaFisica.Text = "1)-Iniciar Toma Física"
        '
        'MnuConteoFisico
        '
        Me.MnuConteoFisico.Name = "MnuConteoFisico"
        Me.MnuConteoFisico.Size = New System.Drawing.Size(250, 26)
        Me.MnuConteoFisico.Text = "2)-Conteo Físico"
        '
        'MnuRebajoVentas
        '
        Me.MnuRebajoVentas.Name = "MnuRebajoVentas"
        Me.MnuRebajoVentas.Size = New System.Drawing.Size(250, 26)
        Me.MnuRebajoVentas.Text = "3)-Rebajo Ventas Manual"
        '
        'MnuReporteDiferencias
        '
        Me.MnuReporteDiferencias.Name = "MnuReporteDiferencias"
        Me.MnuReporteDiferencias.Size = New System.Drawing.Size(250, 26)
        Me.MnuReporteDiferencias.Text = "4)-Reportes Diferencias"
        '
        'MnuAplicarTomaFisica
        '
        Me.MnuAplicarTomaFisica.Name = "MnuAplicarTomaFisica"
        Me.MnuAplicarTomaFisica.Size = New System.Drawing.Size(250, 26)
        Me.MnuAplicarTomaFisica.Text = "5)-Aplicar Toma Física"
        '
        'MnuCancelarTomaFísica
        '
        Me.MnuCancelarTomaFísica.Name = "MnuCancelarTomaFísica"
        Me.MnuCancelarTomaFísica.Size = New System.Drawing.Size(250, 26)
        Me.MnuCancelarTomaFísica.Text = "Cancelar Toma Física"
        '
        'MnuResultadoTomaFísica
        '
        Me.MnuResultadoTomaFísica.Name = "MnuResultadoTomaFísica"
        Me.MnuResultadoTomaFísica.Size = New System.Drawing.Size(250, 26)
        Me.MnuResultadoTomaFísica.Text = "Resultado Toma Física"
        '
        'MnuSistema
        '
        Me.MnuSistema.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAcercaDe, Me.MnuConexión, Me.MnuSalir})
        Me.MnuSistema.Name = "MnuSistema"
        Me.MnuSistema.Size = New System.Drawing.Size(73, 24)
        Me.MnuSistema.Text = "Sistema"
        '
        'MnuAcercaDe
        '
        Me.MnuAcercaDe.Name = "MnuAcercaDe"
        Me.MnuAcercaDe.Size = New System.Drawing.Size(216, 26)
        Me.MnuAcercaDe.Text = "Acerca De"
        '
        'MnuConexión
        '
        Me.MnuConexión.Name = "MnuConexión"
        Me.MnuConexión.Size = New System.Drawing.Size(216, 26)
        Me.MnuConexión.Text = "Conexión"
        '
        'MnuSalir
        '
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Size = New System.Drawing.Size(216, 26)
        Me.MnuSalir.Text = "Salir"
        '
        'StatusBar
        '
        Me.StatusBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSCompaniaLabel, Me.TSSCompania, Me.TSSSucursalLabel, Me.TSSSucursal, Me.TSSUsuarioLabel, Me.TSSUsuario})
        Me.StatusBar.Location = New System.Drawing.Point(0, 688)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusBar.Size = New System.Drawing.Size(1444, 25)
        Me.StatusBar.TabIndex = 1
        Me.StatusBar.Text = "StatusStrip1"
        '
        'TSSCompaniaLabel
        '
        Me.TSSCompaniaLabel.Image = Global.Inventario.My.Resources.Resources.Company_Building
        Me.TSSCompaniaLabel.Name = "TSSCompaniaLabel"
        Me.TSSCompaniaLabel.Size = New System.Drawing.Size(97, 20)
        Me.TSSCompaniaLabel.Text = "Compañía"
        '
        'TSSCompania
        '
        Me.TSSCompania.AutoSize = False
        Me.TSSCompania.Name = "TSSCompania"
        Me.TSSCompania.Size = New System.Drawing.Size(200, 20)
        Me.TSSCompania.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSSSucursalLabel
        '
        Me.TSSSucursalLabel.Image = Global.Inventario.My.Resources.Resources.House__2_
        Me.TSSSucursalLabel.Name = "TSSSucursalLabel"
        Me.TSSSucursalLabel.Size = New System.Drawing.Size(83, 20)
        Me.TSSSucursalLabel.Text = "Sucursal"
        '
        'TSSSucursal
        '
        Me.TSSSucursal.AutoSize = False
        Me.TSSSucursal.Name = "TSSSucursal"
        Me.TSSSucursal.Size = New System.Drawing.Size(200, 20)
        Me.TSSSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSSUsuarioLabel
        '
        Me.TSSUsuarioLabel.Image = Global.Inventario.My.Resources.Resources.user1
        Me.TSSUsuarioLabel.Name = "TSSUsuarioLabel"
        Me.TSSUsuarioLabel.Size = New System.Drawing.Size(79, 20)
        Me.TSSUsuarioLabel.Text = "Usuario"
        '
        'TSSUsuario
        '
        Me.TSSUsuario.AutoSize = False
        Me.TSSUsuario.Name = "TSSUsuario"
        Me.TSSUsuario.Size = New System.Drawing.Size(200, 20)
        Me.TSSUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelMain.Controls.Add(Me.PnlShortCuts)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.LblEmpresaNombre)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMain.Location = New System.Drawing.Point(0, 28)
        Me.PanelMain.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1444, 90)
        Me.PanelMain.TabIndex = 2
        '
        'PnlShortCuts
        '
        Me.PnlShortCuts.Controls.Add(Me.BtnAjusteDeInventario)
        Me.PnlShortCuts.Controls.Add(Me.BtnTrasladoDeInventario)
        Me.PnlShortCuts.Controls.Add(Me.BtnArticulo)
        Me.PnlShortCuts.Controls.Add(Me.BtnConsultaArticulos)
        Me.PnlShortCuts.Controls.Add(Me.BtnConexion)
        Me.PnlShortCuts.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlShortCuts.Location = New System.Drawing.Point(956, 0)
        Me.PnlShortCuts.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlShortCuts.Name = "PnlShortCuts"
        Me.PnlShortCuts.Size = New System.Drawing.Size(484, 86)
        Me.PnlShortCuts.TabIndex = 14
        '
        'BtnAjusteDeInventario
        '
        Me.BtnAjusteDeInventario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAjusteDeInventario.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnAjusteDeInventario.ForeColor = System.Drawing.Color.White
        Me.BtnAjusteDeInventario.Image = Global.Inventario.My.Resources.Resources.box_add
        Me.BtnAjusteDeInventario.Location = New System.Drawing.Point(5, 4)
        Me.BtnAjusteDeInventario.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAjusteDeInventario.Name = "BtnAjusteDeInventario"
        Me.BtnAjusteDeInventario.Size = New System.Drawing.Size(96, 79)
        Me.BtnAjusteDeInventario.TabIndex = 9
        Me.BtnAjusteDeInventario.Text = "Ajuste"
        Me.BtnAjusteDeInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAjusteDeInventario.UseVisualStyleBackColor = False
        '
        'BtnTrasladoDeInventario
        '
        Me.BtnTrasladoDeInventario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTrasladoDeInventario.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnTrasladoDeInventario.ForeColor = System.Drawing.Color.White
        Me.BtnTrasladoDeInventario.Image = Global.Inventario.My.Resources.Resources.box_next1
        Me.BtnTrasladoDeInventario.Location = New System.Drawing.Point(100, 4)
        Me.BtnTrasladoDeInventario.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnTrasladoDeInventario.Name = "BtnTrasladoDeInventario"
        Me.BtnTrasladoDeInventario.Size = New System.Drawing.Size(96, 79)
        Me.BtnTrasladoDeInventario.TabIndex = 8
        Me.BtnTrasladoDeInventario.Text = "Traslado"
        Me.BtnTrasladoDeInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnTrasladoDeInventario.UseVisualStyleBackColor = False
        '
        'BtnArticulo
        '
        Me.BtnArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnArticulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnArticulo.ForeColor = System.Drawing.Color.White
        Me.BtnArticulo.Image = Global.Inventario.My.Resources.Resources.product1
        Me.BtnArticulo.Location = New System.Drawing.Point(194, 4)
        Me.BtnArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnArticulo.Name = "BtnArticulo"
        Me.BtnArticulo.Size = New System.Drawing.Size(96, 79)
        Me.BtnArticulo.TabIndex = 7
        Me.BtnArticulo.Text = "Artículo"
        Me.BtnArticulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnArticulo.UseVisualStyleBackColor = False
        '
        'BtnConsultaArticulos
        '
        Me.BtnConsultaArticulos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultaArticulos.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnConsultaArticulos.ForeColor = System.Drawing.Color.White
        Me.BtnConsultaArticulos.Image = Global.Inventario.My.Resources.Resources.box_view
        Me.BtnConsultaArticulos.Location = New System.Drawing.Point(289, 4)
        Me.BtnConsultaArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnConsultaArticulos.Name = "BtnConsultaArticulos"
        Me.BtnConsultaArticulos.Size = New System.Drawing.Size(96, 79)
        Me.BtnConsultaArticulos.TabIndex = 6
        Me.BtnConsultaArticulos.Text = "Saldos"
        Me.BtnConsultaArticulos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnConsultaArticulos.UseVisualStyleBackColor = False
        '
        'BtnConexion
        '
        Me.BtnConexion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConexion.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.BtnConexion.ForeColor = System.Drawing.Color.White
        Me.BtnConexion.Image = Global.Inventario.My.Resources.Resources.server_client_exchange
        Me.BtnConexion.Location = New System.Drawing.Point(384, 4)
        Me.BtnConexion.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnConexion.Name = "BtnConexion"
        Me.BtnConexion.Size = New System.Drawing.Size(96, 79)
        Me.BtnConexion.TabIndex = 2
        Me.BtnConexion.Text = "Conexión"
        Me.BtnConexion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnConexion.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(321, 42)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "SD-INVENTARIO"
        '
        'LblEmpresaNombre
        '
        Me.LblEmpresaNombre.AutoSize = True
        Me.LblEmpresaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmpresaNombre.ForeColor = System.Drawing.Color.White
        Me.LblEmpresaNombre.Location = New System.Drawing.Point(361, 27)
        Me.LblEmpresaNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEmpresaNombre.Name = "LblEmpresaNombre"
        Me.LblEmpresaNombre.Size = New System.Drawing.Size(313, 36)
        Me.LblEmpresaNombre.TabIndex = 7
        Me.LblEmpresaNombre.Text = "Nombre de la empresa"
        '
        'PicFacturacionElectronica
        '
        Me.PicFacturacionElectronica.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicFacturacionElectronica.Image = Global.Inventario.My.Resources.Resources.FacturaElectronica
        Me.PicFacturacionElectronica.Location = New System.Drawing.Point(1008, 555)
        Me.PicFacturacionElectronica.Margin = New System.Windows.Forms.Padding(4)
        Me.PicFacturacionElectronica.Name = "PicFacturacionElectronica"
        Me.PicFacturacionElectronica.Size = New System.Drawing.Size(420, 103)
        Me.PicFacturacionElectronica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFacturacionElectronica.TabIndex = 11
        Me.PicFacturacionElectronica.TabStop = False
        '
        'PicLogo
        '
        Me.PicLogo.Location = New System.Drawing.Point(16, 128)
        Me.PicLogo.Margin = New System.Windows.Forms.Padding(4)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(685, 530)
        Me.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicLogo.TabIndex = 10
        Me.PicLogo.TabStop = False
        '
        'SaldoInventarioLOTESToolStripMenuItem
        '
        Me.SaldoInventarioLOTESToolStripMenuItem.Name = "SaldoInventarioLOTESToolStripMenuItem"
        Me.SaldoInventarioLOTESToolStripMenuItem.Size = New System.Drawing.Size(302, 26)
        Me.SaldoInventarioLOTESToolStripMenuItem.Text = "Saldo Inventario - LOTES"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1444, 713)
        Me.Controls.Add(Me.PicFacturacionElectronica)
        Me.Controls.Add(Me.PicLogo)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.MenuStripPrincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStripPrincipal
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStripPrincipal.ResumeLayout(False)
        Me.MenuStripPrincipal.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.PnlShortCuts.ResumeLayout(False)
        CType(Me.PicFacturacionElectronica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStripPrincipal As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuProcesos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSistema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuConexión As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents TSSCompaniaLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSCompania As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSSucursalLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSSucursal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents LblEmpresaNombre As System.Windows.Forms.Label
    Friend WithEvents MnuAjustesDeInventario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TSSUsuarioLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MnuCatalogos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuArticulos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCategoria As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuArticulo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDepartamento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUnidadMedida As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSubCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuConsultas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuConsultaArtículos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSeguridad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuArticuloBodega As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAjusteDeCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGrupo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSaldosInventario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSaldosInventarioProveedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuListadoTomaFisica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSaldosDeInventarioSinCostos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PnlShortCuts As System.Windows.Forms.Panel
    Friend WithEvents BtnConsultaArticulos As System.Windows.Forms.Button
    Friend WithEvents BtnConexion As System.Windows.Forms.Button
    Friend WithEvents MnuAjusteCostoMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCambioPrecioMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuListadoPrecios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicLogo As System.Windows.Forms.PictureBox
    Friend WithEvents MnuTomaFisica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuIniciarTomaFisica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuConteoFisico As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRebajoVentas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReporteDiferencias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAplicarTomaFisica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSaldosXBodega As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPromociones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuArticulosInactivosSinSaldo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTrasladoDeInventario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuArticulosInactivosConSaldo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPonerSaldosEnCero As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCancelarTomaFísica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicFacturacionElectronica As PictureBox
    Friend WithEvents MnuKardex As ToolStripMenuItem
    Friend WithEvents MnuKardexResumido As ToolStripMenuItem
    Friend WithEvents MnuKardexDetallado As ToolStripMenuItem
    Friend WithEvents MnuLotes As ToolStripMenuItem
    Friend WithEvents MnuResultadoTomaFísica As ToolStripMenuItem
    Friend WithEvents MnuGenerarEtiqueta As ToolStripMenuItem
    Friend WithEvents MnuFamilia As ToolStripMenuItem
    Friend WithEvents MnuAjusteDeProduccion As ToolStripMenuItem
    Friend WithEvents BtnArticulo As Button
    Friend WithEvents MnuSaldosPorCategoría As ToolStripMenuItem
    Friend WithEvents TrasladoPorArtículoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuSaldosPorDepartamento As ToolStripMenuItem
    Friend WithEvents MnuGeneraEtiqueta As ToolStripMenuItem
    Friend WithEvents BtnTrasladoDeInventario As Button
    Friend WithEvents ProductosActualizadosMnu As ToolStripMenuItem
    Friend WithEvents MnuAjusteMargenesMasivoMnu As ToolStripMenuItem
    Friend WithEvents MnuGeneraEtiquetaCCSS As ToolStripMenuItem
    Friend WithEvents BtnAjusteDeInventario As Button
    Friend WithEvents MnuGenerarArchivoArticulos As ToolStripMenuItem
    Friend WithEvents MnuSaldosDeInventarioAgrupado As ToolStripMenuItem
    Friend WithEvents MnuPreciosXCategoria As ToolStripMenuItem
    Friend WithEvents AsignaciToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaldoInventarioLOTESToolStripMenuItem As ToolStripMenuItem
End Class
