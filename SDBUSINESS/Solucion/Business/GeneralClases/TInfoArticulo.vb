Public Class TInfoArticulo
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Bod_Id As Integer
    Private _Art_Id As String
    Private _Nombre As String
    Private _FactorConversion As Integer
    Private _ExentoIV As Integer
    Private _Suelto As Integer
    Private _ArtPadre As String
    Private _Activo As Integer
    Private _Saldo As Double
    Private _Costo As Double
    Private _Margen As Double
    Private _Precio As Double
    Private _FechaIniDescuento As DateTime
    Private _FechaFinDescuento As DateTime
    Private _PorcDescuento As Double
    Private _Conjunto As Integer
    Private _SolicitarCantidad As Integer
    Private _Servicio As Integer
    Private _PermiteFacturar As Integer
    Private _UnidadMedidaNombre As String
    Private _CategoriaNombre As String
    Private _SubCategoriaNombre As String
    Private _DepartamentoNombre As String
    Private _ProveedorNombre As String
    Private _Compuesto As Integer
    Private _SaldoPropio As Integer
    Private _Lote As Integer
    Private _Garantia As Integer
    Private _CalculaCantidadFactura As Integer
    Private _CantidadSinRedondeo As Double
    Private _CodigoCabys As String
    Private _ArticuloImpuestos As New List(Of TInfoArticuloImpuesto)
    Private _Data As DataSet
    Private _ListaConjuntos As New List(Of TInfoArticuloConjunto)
#End Region

#Region "Definicion de propiedades"
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal Value As Integer)
            _Emp_Id = Value
        End Set
    End Property
    Public Property Suc_Id() As Integer
        Get
            Return _Suc_Id
        End Get
        Set(ByVal Value As Integer)
            _Suc_Id = Value
        End Set
    End Property
    Public Property Bod_Id() As Integer
        Get
            Return _Bod_Id
        End Get
        Set(ByVal Value As Integer)
            _Bod_Id = Value
        End Set
    End Property
    Public Property CABYS() As String
        Get
            Return _CodigoCabys
        End Get
        Set(ByVal Value As String)
            _CodigoCabys = Value
        End Set
    End Property
    Public Property Art_Id() As String
        Get
            Return _Art_Id
        End Get
        Set(ByVal Value As String)
            _Art_Id = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    Public Property FactorConversion() As Integer
        Get
            Return _FactorConversion
        End Get
        Set(ByVal Value As Integer)
            _FactorConversion = Value
        End Set
    End Property
    Public Property ExentoIV() As Integer
        Get
            Return _ExentoIV
        End Get
        Set(ByVal Value As Integer)
            _ExentoIV = Value
        End Set
    End Property
    Public Property Suelto() As Integer
        Get
            Return _Suelto
        End Get
        Set(ByVal Value As Integer)
            _Suelto = Value
        End Set
    End Property
    Public Property ArtPadre() As String
        Get
            Return _ArtPadre
        End Get
        Set(ByVal Value As String)
            _ArtPadre = Value
        End Set
    End Property
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
        End Set
    End Property
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property
    Public Property Costo() As Double
        Get
            Return _Costo
        End Get
        Set(ByVal Value As Double)
            _Costo = Value
        End Set
    End Property
    Public Property Margen() As Double
        Get
            Return _Margen
        End Get
        Set(ByVal Value As Double)
            _Margen = Value
        End Set
    End Property
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal Value As Double)
            _Precio = Value
        End Set
    End Property
    Public Property FechaIniDescuento() As DateTime
        Get
            Return _FechaIniDescuento
        End Get
        Set(ByVal Value As DateTime)
            _FechaIniDescuento = Value
        End Set
    End Property
    Public Property FechaFinDescuento() As DateTime
        Get
            Return _FechaFinDescuento
        End Get
        Set(ByVal Value As DateTime)
            _FechaFinDescuento = Value
        End Set
    End Property
    Public Property PorcDescuento() As Double
        Get
            Return _PorcDescuento
        End Get
        Set(ByVal Value As Double)
            _PorcDescuento = Value
        End Set
    End Property
    Public Property Conjunto() As Integer
        Get
            Return _Conjunto
        End Get
        Set(ByVal Value As Integer)
            _Conjunto = Value
        End Set
    End Property
    Public Property SolicitarCantidad As Integer
        Get
            Return _SolicitarCantidad
        End Get
        Set(value As Integer)
            _SolicitarCantidad = value
        End Set
    End Property
    Public Property Servicio As Integer
        Get
            Return _Servicio
        End Get
        Set(ByVal value As Integer)
            _Servicio = value
        End Set
    End Property
    Public Property PermiteFacturar As Integer
        Get
            Return _PermiteFacturar
        End Get
        Set(value As Integer)
            _PermiteFacturar = value
        End Set
    End Property
    Public Property UnidadMedidaNombre As String
        Get
            Return _UnidadMedidaNombre
        End Get
        Set(value As String)
            _UnidadMedidaNombre = value
        End Set
    End Property
    Public Property ProveedorNombre As String
        Get
            Return _ProveedorNombre
        End Get
        Set(value As String)
            _ProveedorNombre = value
        End Set
    End Property
    Public Property Compuesto() As Integer
        Get
            Return _Compuesto
        End Get
        Set(ByVal value As Integer)
            _Compuesto = value
        End Set
    End Property
    Public Property SaldoPropio() As Integer
        Get
            Return _SaldoPropio
        End Get
        Set(ByVal value As Integer)
            _SaldoPropio = value
        End Set
    End Property

    Public Property Lote() As Integer
        Get
            Return _Lote
        End Get
        Set(ByVal value As Integer)
            _Lote = value
        End Set
    End Property
    Public Property Garantia As Integer
        Get
            Return _Garantia
        End Get
        Set(value As Integer)
            _Garantia = value
        End Set
    End Property

    Public Property CalculaCantidadFactura() As Integer
        Get
            Return _CalculaCantidadFactura
        End Get
        Set(ByVal value As Integer)
            _CalculaCantidadFactura = value
        End Set
    End Property
    Public Property CantidadSinRedondeo As Double
        Get
            Return _CantidadSinRedondeo
        End Get
        Set(value As Double)
            _CantidadSinRedondeo = value
        End Set
    End Property
    Public Property ArticuloImpuestos As List(Of TInfoArticuloImpuesto)
        Get
            Return _ArticuloImpuestos
        End Get
        Set(value As List(Of TInfoArticuloImpuesto))
            _ArticuloImpuestos = value
        End Set
    End Property
    Public Property ListaConjuntos As List(Of TInfoArticuloConjunto)
        Get
            Return _ListaConjuntos
        End Get
        Set(value As List(Of TInfoArticuloConjunto))
            _ListaConjuntos = value
        End Set
    End Property
    Public ReadOnly Property Data() As DataSet
        Get
            Return _Data
        End Get
    End Property
    Public ReadOnly Property RowsAffected() As Long
        Get
            Return Cn.RowsAffected
        End Get
    End Property
    Public Property CategoriaNombre As String
        Get
            Return _CategoriaNombre
        End Get
        Set(value As String)
            _CategoriaNombre = value
        End Set
    End Property
    Public Property SubCategoriaNombre As String
        Get
            Return _SubCategoriaNombre
        End Get
        Set(value As String)
            _SubCategoriaNombre = value
        End Set
    End Property
    Public Property DepartamentoNombre As String
        Get
            Return _DepartamentoNombre
        End Get
        Set(value As String)
            _DepartamentoNombre = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(pEmp_Id As Integer)
        MyBase.New()
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
    Public Sub New(pEmp_Id As Integer, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        Inicializa()
        _Emp_Id = pEmp_Id
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Emp_Id = 0
        _Suc_Id = 0
        _Bod_Id = 0
        _Art_Id = ""
        _Nombre = ""
        _FactorConversion = 0
        _ExentoIV = 0
        _Suelto = 0
        _ArtPadre = ""
        _Activo = 0
        _Saldo = 0.0
        _Costo = 0.0
        _Margen = 0.0
        _Precio = 0.0
        _FechaIniDescuento = CDate("1900/01/01")
        _FechaFinDescuento = CDate("1900/01/01")
        _PorcDescuento = 0.0
        _Conjunto = 0
        _SolicitarCantidad = 0
        _Servicio = 0
        _PermiteFacturar = 0
        _UnidadMedidaNombre = ""
        _Compuesto = 0
        _SaldoPropio = 0
        _Lote = 0
        _Garantia = 0
        _CalculaCantidadFactura = 0
        _CantidadSinRedondeo = 0
        _ProveedorNombre = ""
        _ListaConjuntos.Clear()
        _ArticuloImpuestos.Clear()
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Return ""
    End Function
    Public Overrides Function Delete() As String
        Return ""
    End Function
    Public Overrides Function Modify() As String
        Return ""
    End Function
    Public Overrides Function ListKey() As String
        Return ""
    End Function
    Public Overrides Function List() As String
        Return ""
    End Function
    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Return ""
    End Function
    Public Sub LimpiaArticulo()
        _Art_Id = ""
        _Nombre = ""
        _FactorConversion = 0
        _ExentoIV = 0
        _Suelto = 0
        _ArtPadre = ""
        _Activo = 0
        _Saldo = 0.0
        _Costo = 0.0
        _Margen = 0.0
        _Precio = 0.0
        _FechaIniDescuento = CDate("1900/01/01")
        _FechaFinDescuento = CDate("1900/01/01")
        _PorcDescuento = 0.0
        _Conjunto = 0
        _SolicitarCantidad = 0
        _Servicio = 0
        _PermiteFacturar = 0
        _UnidadMedidaNombre = ""
        _Compuesto = 0
        _SaldoPropio = 0
        _CalculaCantidadFactura = 0
        _CantidadSinRedondeo = 0
        _ArticuloImpuestos.Clear()
        _CodigoCabys = ""

    End Sub
    Public Function CargaRegistroArticulo(pFila As DataRow) As String
        Try

            If Not pFila Is Nothing Then
                _Emp_Id = pFila("Emp_Id")
                _Suc_Id = pFila("Suc_Id")
                _Bod_Id = pFila("Bod_Id")
                _Art_Id = pFila("Art_Id")
                _Nombre = pFila("Nombre")
                _FactorConversion = pFila("FactorConversion")
                _ExentoIV = pFila("ExentoIV")
                _Suelto = pFila("Suelto")
                _ArtPadre = pFila("ArtPadre")
                _Activo = pFila("Activo")
                _Saldo = pFila("Saldo")
                _Costo = pFila("Costo")
                _Margen = pFila("Margen")
                _Precio = pFila("Precio")
                _FechaIniDescuento = pFila("FechaIniDescuento")
                _FechaFinDescuento = pFila("FechaFinDescuento")
                _PorcDescuento = pFila("PorcDescuento")
                _Conjunto = pFila("Conjunto")
                _SolicitarCantidad = pFila("SolicitarCantidad")
                _Servicio = pFila("Servicio")
                _PermiteFacturar = pFila("PermiteFacturar")
                _UnidadMedidaNombre = pFila("UnidadMedidaNombre")
                _Compuesto = pFila("Compuesto")
                _SaldoPropio = pFila("SaldoPropio")
                _CalculaCantidadFactura = pFila("CalculaCantidadFactura")
                _Lote = pFila("Lote")
                _Garantia = pFila("Garantia")
                _CodigoCabys = pFila("CodigoCABYS")
            End If




            Return ""

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ConsultaArticulo(pCliente_Id As Long) As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim TablaImpuesto As DataTable = Nothing
        Dim ArticuloImpuesto As TInfoArticuloImpuesto = Nothing
        Try
            Cn.Open()


            _ArticuloImpuestos.Clear()

            If _Art_Id.Trim() <> String.Empty Then


                Query = "exec ConsultaArticuloImpuesto " & _Emp_Id.ToString & ",'" & _Art_Id & "'"

                TablaImpuesto = Cn.Seleccionar(Query).Copy

                If Not TablaImpuesto Is Nothing AndAlso TablaImpuesto.Rows.Count > 0 Then
                    For Each fila As DataRow In TablaImpuesto.Rows
                        ArticuloImpuesto = New TInfoArticuloImpuesto()
                        With ArticuloImpuesto
                            .Codigo_Id = fila("Codigo_Id")
                            .Tarifa_Id = fila("Tarifa_Id")
                            .Porcentaje = fila("Porcentaje")
                        End With
                        _ArticuloImpuestos.Add(ArticuloImpuesto)
                    Next
                End If

            End If


            Query = "exec ConsultaArticulo " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString & ",'" & _Art_Id & "'," & pCliente_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)





            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ConsultaArticuloxTipoPrecio(pPrecio_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ConsultaArticuloxTipoPrecio " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString & ",'" & _Art_Id & "'," & pPrecio_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function CargaListaConjuntos() As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim InfoArticuloConjunto As TInfoArticuloConjunto = Nothing
        Try

            _ListaConjuntos.Clear()

            Cn.Open()

            Query = "select * from ArticuloConjunto where Emp_Id = " & _Emp_Id.ToString & " and Art_Id = '" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                For Each Fila As DataRow In Tabla.Rows
                    InfoArticuloConjunto = New TInfoArticuloConjunto
                    With InfoArticuloConjunto
                        .Emp_Id = Fila("Emp_Id")
                        .Art_Id = Fila("Art_Id")
                        .ArtConjunto_Id = Fila("ArtConjunto_Id")
                        .Cantidad = Fila("Cantidad")
                        .UltimaModificacion = Fila("UltimaModificacion")
                        _ListaConjuntos.Add(InfoArticuloConjunto)
                    End With
                Next
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ConsultaArticuloSinSaldo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ConsultaArticuloSinSaldo " & _Emp_Id.ToString & ",'" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Nombre = Tabla.Rows(0).Item("NombreArticulo")
                _CategoriaNombre = Tabla.Rows(0).Item("CategoriaNombre")
                _SubCategoriaNombre = Tabla.Rows(0).Item("SubCategoriaNombre")
                _DepartamentoNombre = Tabla.Rows(0).Item("DepartamentoNombre")
                _UnidadMedidaNombre = Tabla.Rows(0).Item("UnidadMedidaNombre")
                _ProveedorNombre = Tabla.Rows(0).Item("ProveedorNombre")
                _Suelto = Tabla.Rows(0).Item("Suelto")
                _Activo = Tabla.Rows(0).Item("Activo")
                _ExentoIV = Tabla.Rows(0).Item("ExentoIV")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    'Public Function GetMontoImpuesto(pPrecioSI As Double) As Double
    '    Dim OtrosImpuestos As Double = 0
    '    Dim TotalImpuesto As Double = 0

    '    For Each impuesto As TInfoArticuloImpuesto In _ArticuloImpuestos
    '        If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
    '            OtrosImpuestos += pPrecioSI * (impuesto.Porcentaje / 100)
    '        End If
    '    Next

    '    For Each impuesto As TInfoArticuloImpuesto In _ArticuloImpuestos
    '        If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
    '            TotalImpuesto += (pPrecioSI + OtrosImpuestos) * (impuesto.Porcentaje / 100)
    '        End If
    '    Next

    '    Return TotalImpuesto

    'End Function
    Public Function ConsultaArticuloImpuestos() As String
        Dim Query As String
        Dim TablaImpuesto As DataTable = Nothing
        Dim ArticuloImpuesto As TInfoArticuloImpuesto = Nothing
        Try
            Cn.Open()


            _ArticuloImpuestos.Clear()

            If _Art_Id.Trim() <> String.Empty Then


                Query = "exec ConsultaArticuloImpuesto " & _Emp_Id.ToString & ",'" & _Art_Id & "'"

                TablaImpuesto = Cn.Seleccionar(Query).Copy

                If Not TablaImpuesto Is Nothing AndAlso TablaImpuesto.Rows.Count > 0 Then
                    For Each fila As DataRow In TablaImpuesto.Rows
                        ArticuloImpuesto = New TInfoArticuloImpuesto()
                        With ArticuloImpuesto
                            .Codigo_Id = fila("Codigo_Id")
                            .Tarifa_Id = fila("Tarifa_Id")
                            .Porcentaje = fila("Porcentaje")
                        End With
                        _ArticuloImpuestos.Add(ArticuloImpuesto)
                    Next
                End If

            End If
            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function


#End Region
End Class
