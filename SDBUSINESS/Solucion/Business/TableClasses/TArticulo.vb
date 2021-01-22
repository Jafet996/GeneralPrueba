Imports System.Data.SqlClient
Public Class TArticulo
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Art_Id As String
    Private _Nombre As String
    Private _Cat_Id As Integer
    Private _SubCat_Id As Integer
    Private _Departamento_Id As Integer
    Private _UnidadMedida_Id As Integer
    Private _FactorConversion As Integer
    Private _ExentoIV As Integer
    Private _Suelto As Integer
    Private _ArtPadre As String
    Private _SolicitarCantidad As Integer
    Private _PermiteFacturar As Integer
    Private _Servicio As Integer
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _Existe As Boolean
    Private _CodigoCantidad As Integer
    Private _CodigoCantidadTipo As Integer
    Private _BusquedaRapida As Integer
    Private _TipoAcumulacion_Id As Integer
    Private _Frecuente As Integer
    Private _Compuesto As Integer
    Private _CuentaIngreso As String
    Private _CantidadBotones As Integer
    Private _ListaEquivalentes As New List(Of TArticuloEquivalente)
    Private _ListaConjuntos As New List(Of TArticuloConjunto)
    Private _Anotaciones As String
    Private _CodigoProveedor As String
    Private _CodigoInterno As String
    Private _SaldoPropio As Integer
    Private _CalculaCantidadFactura As Integer
    Private _Precio As New Double
    Private _Costo As New Double
    Private _Margen As Double
    Private _ExentoIC As Integer
    Private _Lote As Integer
    Private _Garantia As Integer
    Private _PorcIC As Double
    Private _Data As DataSet
    Private _ArticuloImpuesto As List(Of TArticuloImpuesto)
    Private _CodigoCabys As String
    Private _CabysDescripcion As String
    Private _CabysTarifa As Double
    Private _Saldo As Integer
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
    Public Property Cat_Id() As Integer
        Get
            Return _Cat_Id
        End Get
        Set(ByVal Value As Integer)
            _Cat_Id = Value
        End Set
    End Property
    Public Property SubCat_Id() As Integer
        Get
            Return _SubCat_Id
        End Get
        Set(ByVal Value As Integer)
            _SubCat_Id = Value
        End Set
    End Property
    Public Property Departamento_Id() As Integer
        Get
            Return _Departamento_Id
        End Get
        Set(ByVal Value As Integer)
            _Departamento_Id = Value
        End Set
    End Property
    Public Property UnidadMedida_Id() As Integer
        Get
            Return _UnidadMedida_Id
        End Get
        Set(ByVal Value As Integer)
            _UnidadMedida_Id = Value
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
    Public Property SolicitarCantidad() As Integer
        Get
            Return _SolicitarCantidad
        End Get
        Set(ByVal Value As Integer)
            _SolicitarCantidad = Value
        End Set
    End Property
    Public Property PermiteFacturar() As Integer
        Get
            Return _PermiteFacturar
        End Get
        Set(ByVal Value As Integer)
            _PermiteFacturar = Value
        End Set
    End Property
    Public Property Servicio() As Integer
        Get
            Return _Servicio
        End Get
        Set(ByVal Value As Integer)
            _Servicio = Value
        End Set
    End Property
    Public Property TipoAcumulacion_Id() As Integer
        Get
            Return _TipoAcumulacion_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoAcumulacion_Id = Value
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
    Public Property CuentaIngreso() As String
        Get
            Return _CuentaIngreso
        End Get
        Set(ByVal Value As String)
            _CuentaIngreso = Value
        End Set
    End Property
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public ReadOnly Property Existe As Boolean
        Get
            Return _Existe
        End Get
    End Property
    Public Property CodigoCantidad As Integer
        Get
            Return _CodigoCantidad
        End Get
        Set(value As Integer)
            _CodigoCantidad = value
        End Set
    End Property
    Public Property CodigoCantidadTipo As Integer
        Get
            Return _CodigoCantidadTipo
        End Get
        Set(value As Integer)
            _CodigoCantidadTipo = value
        End Set
    End Property
    Public Property BusquedaRapida() As Integer
        Get
            Return _BusquedaRapida
        End Get
        Set(ByVal Value As Integer)
            _BusquedaRapida = Value
        End Set
    End Property
    Public Property Frecuente() As Integer
        Get
            Return _Frecuente
        End Get
        Set(ByVal Value As Integer)
            _Frecuente = Value
        End Set
    End Property
    Public Property CantidadBotones() As Long
        Get
            Return _CantidadBotones
        End Get
        Set(ByVal Value As Long)
            _CantidadBotones = Value
        End Set
    End Property
    Public Property ListaEquivalentes As List(Of TArticuloEquivalente)
        Get
            Return _ListaEquivalentes
        End Get
        Set(value As List(Of TArticuloEquivalente))
            _ListaEquivalentes = value
        End Set
    End Property
    Public Property ListaConjuntos As List(Of TArticuloConjunto)
        Get
            Return _ListaConjuntos
        End Get
        Set(value As List(Of TArticuloConjunto))
            _ListaConjuntos = value
        End Set
    End Property
    Public Property Compuesto() As Integer
        Get
            Return _Compuesto
        End Get
        Set(ByVal Value As Integer)
            _Compuesto = Value
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
    Public Property Costo() As Double
        Get
            Return _Costo
        End Get
        Set(ByVal Value As Double)
            _Costo = Value
        End Set
    End Property
    Public Property Garantia() As Integer
        Get
            Return _Garantia
        End Get
        Set(ByVal Value As Integer)
            _Garantia = Value
        End Set
    End Property

    Public Property Margen As Double
        Get
            Return _Margen
        End Get
        Set(value As Double)
            _Margen = value
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
    Public Property Anotaciones() As String
        Get
            Return _Anotaciones
        End Get
        Set(ByVal Value As String)
            _Anotaciones = Value
        End Set
    End Property
    Public Property CodigoProveedor() As String
        Get
            Return _CodigoProveedor
        End Get
        Set(ByVal Value As String)
            _CodigoProveedor = Value
        End Set
    End Property
    Public Property CodigoInterno() As String
        Get
            Return _CodigoInterno
        End Get
        Set(ByVal Value As String)
            _CodigoInterno = Value
        End Set
    End Property
    Public Property SaldoPropio() As Integer
        Get
            Return _SaldoPropio
        End Get
        Set(ByVal Value As Integer)
            _SaldoPropio = Value
        End Set
    End Property
    Public Property Saldo() As Integer
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Integer)
            _Saldo = Value
        End Set
    End Property
    Public Property CalculaCantidadFactura() As Integer
        Get
            Return _CalculaCantidadFactura
        End Get
        Set(ByVal Value As Integer)
            _CalculaCantidadFactura = Value
        End Set
    End Property

    Public Property ExentoIC() As Integer
        Get
            Return _ExentoIC
        End Get
        Set(ByVal Value As Integer)
            _ExentoIC = Value
        End Set
    End Property

    Public Property Lote() As Integer
        Get
            Return _Lote
        End Get
        Set(ByVal Value As Integer)
            _Lote = Value
        End Set
    End Property

    Public Property PorcIC() As Double
        Get
            Return _PorcIC
        End Get

        Set(ByVal Value As Double)
            _PorcIC = Value
        End Set
    End Property
    Public Property ArticuloImpuesto As List(Of TArticuloImpuesto)
        Get
            Return _ArticuloImpuesto
        End Get
        Set(value As List(Of TArticuloImpuesto))
            _ArticuloImpuesto = value
        End Set
    End Property

    Public Property CodigoCabys() As String
        Get
            Return _CodigoCabys
        End Get

        Set(ByVal Value As String)
            _CodigoCabys = Value
        End Set
    End Property

    Public Property CabysDescripcion() As String
        Get
            Return _CabysDescripcion
        End Get

        Set(ByVal Value As String)
            _CabysDescripcion = Value
        End Set
    End Property

    Public Property CabysTarifa() As Double
        Get
            Return _CabysTarifa
        End Get

        Set(ByVal Value As Double)
            _CabysTarifa = Value
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
        _Art_Id = ""
        _Nombre = ""
        _Cat_Id = 0
        _SubCat_Id = 0
        _Departamento_Id = 0
        _UnidadMedida_Id = 0
        _FactorConversion = 0
        _ExentoIV = 0
        _Suelto = 0
        _ArtPadre = ""
        _SolicitarCantidad = 0
        _PermiteFacturar = 0
        _Servicio = 0
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Existe = False
        _CodigoCantidad = 0
        _CodigoCantidadTipo = 0
        _BusquedaRapida = 0
        _Frecuente = 0
        _TipoAcumulacion_Id = 0
        _CuentaIngreso = ""
        _CantidadBotones = 0
        _ListaEquivalentes.Clear()
        _ListaConjuntos.Clear()
        _Compuesto = 0
        _Precio = 0.00
        _Costo = 0.00
        _Margen = 0.00
        _Anotaciones = ""
        _CodigoProveedor = ""
        _CodigoInterno = ""
        _Data = New DataSet
        _SaldoPropio = 0
        _CalculaCantidadFactura = 0
        _ExentoIC = 0
        _PorcIC = 0.0
        _Lote = 0
        _Garantia = 0
        _ArticuloImpuesto = New List(Of TArticuloImpuesto)
    End Sub
#End Region

#Region "Definicion metodos publicos"

    Private Function GuardaEquivalentes() As String
        Dim Query As String = ""
        Try


            Query = "Delete ArticuloEquivalente where Emp_Id = " & _Emp_Id.ToString & " and Art_Id = '" & _Art_Id & "'"
            Cn.Ejecutar(Query)


            For Each Item As TArticuloEquivalente In _ListaEquivalentes
                Query = " Insert into ArticuloEquivalente(Emp_Id, Art_Id, ArtEquivalente_Id , UltimaModificacion)" &
                       " Values ( " & _Emp_Id.ToString() & ",'" & _Art_Id & "','" & Item.ArtEquivalente_Id & "',getdate())"
                Cn.Ejecutar(Query)
            Next

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function GuardaConjuntos() As String
        Dim Query As String = ""
        Try


            Query = "Delete ArticuloConjunto where Emp_Id = " & _Emp_Id.ToString & " and Art_Id = '" & _Art_Id & "'"
            Cn.Ejecutar(Query)


            For Each Item As TArticuloConjunto In _ListaConjuntos

                Query = " Insert into ArticuloConjunto(Emp_Id, Art_Id, ArtConjunto_Id, Cantidad, UltimaModificacion)" &
                    " Values ( " & _Emp_Id.ToString() & ",'" & _Art_Id & "','" & Item.ArtConjunto_Id & "'," & Item.Cantidad.ToString() & ",getdate())"
                Cn.Ejecutar(Query)
            Next

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function GuardaImpuestos() As String
        Dim Query As String = ""
        Try


            Query = "Delete ArticuloImpuesto where Emp_Id = " & _Emp_Id.ToString & " and Art_Id = '" & _Art_Id & "'"
            Cn.Ejecutar(Query)


            For Each Item As TArticuloImpuesto In _ArticuloImpuesto

                Query = " Insert into ArticuloImpuesto(Emp_Id, Art_Id, Codigo_Id, Tarifa_Id, Porcentaje)" &
                    " Values ( " & _Emp_Id.ToString() & ",'" & _Art_Id & "','" & Item.Codigo_Id & "','" & Item.Tarifa_Id.ToString() & "'," & Item.Porcentaje.ToString() & ")"
                Cn.Ejecutar(Query)
            Next

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Dim Mensaje As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Articulo( Emp_Id , Art_Id" &
                   " , Nombre , Cat_Id" &
                   " , SubCat_Id , Departamento_Id" &
                   " , UnidadMedida_Id , FactorConversion" &
                   " , ExentoIV , Suelto" &
                   " , ArtPadre , SolicitarCantidad" &
                   " , PermiteFacturar, CodigoCantidad , CodigoCantidadTipo, Servicio, Activo" &
                   " , TipoAcumulacion_Id, BusquedaRapida, Frecuente, UltimaModificacion" &
                   " , CuentaIngreso, Compuesto, Anotaciones, CodigoProveedor, CodigoInterno" &
                   " , SaldoPropio,CalculaCantidadFactura, ExentoIC, PorcIC, Lote,CabysCodigo,CabysDescripcion,CabysTarifa,Garantia)" &
                   " Values ( " & _Emp_Id.ToString() & ",'" & _Art_Id & "'" &
                   ",'" & _Nombre & "'" & "," & _Cat_Id.ToString() &
                   "," & _SubCat_Id.ToString() & "," & _Departamento_Id.ToString() &
                   "," & _UnidadMedida_Id.ToString() & "," & _FactorConversion.ToString() &
                   "," & _ExentoIV.ToString() & "," & _Suelto.ToString() &
                   IIf(_Suelto, ",'" & _ArtPadre & "',", ",null,") & _SolicitarCantidad.ToString() &
                   "," & _PermiteFacturar.ToString() & "," & _CodigoCantidad.ToString() & "," &
                   _CodigoCantidadTipo.ToString() & "," & _Servicio.ToString & "," & _Activo.ToString() &
                   "," & _TipoAcumulacion_Id.ToString() & "," & _BusquedaRapida & "," & _Frecuente & ",'" &
                   Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "','" & _CuentaIngreso.Trim & "'," &
                   _Compuesto & ",'" & _Anotaciones & "','" & _CodigoProveedor & "','" & _CodigoInterno & "'," &
                   _SaldoPropio & "," & _CalculaCantidadFactura.ToString() & "," & _ExentoIC & "," & _PorcIC & "," & _Lote & ",'" & _CodigoCabys &
                    "','" & _CabysDescripcion & "'," & _CabysTarifa & "," & _Garantia & ")"

            Cn.Ejecutar(Query)

            Mensaje = GuardaEquivalentes()
            VerificaMensaje(Mensaje)

            Mensaje = GuardaConjuntos()
            VerificaMensaje(Mensaje)

            Mensaje = GuardaImpuestos()
            VerificaMensaje(Mensaje)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Overrides Function Delete() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Delete Articulo" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And     Art_Id='" & _Art_Id & "'"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Overrides Function Modify() As String
        Dim Query As String = ""
        Dim Mensaje As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.Articulo " &
                      " SET   Nombre='" & _Nombre & "' " & "," &
                      " Cat_Id=" & _Cat_Id & "," &
                      " SubCat_Id=" & _SubCat_Id & "," &
                      " Departamento_Id=" & _Departamento_Id & "," &
                      " UnidadMedida_Id=" & _UnidadMedida_Id & "," &
                      " FactorConversion=" & _FactorConversion & "," &
                      " ExentoIV=" & _ExentoIV & "," &
                      " Suelto=" & _Suelto & "," &
                      " ArtPadre=" & IIf(_Suelto, "'" & _ArtPadre & "'", "null") & "," &
                      " SolicitarCantidad=" & _SolicitarCantidad & "," &
                      " PermiteFacturar=" & _PermiteFacturar & "," &
                      " CodigoCantidad=" & _CodigoCantidad & "," &
                      " CodigoCantidadTipo=" & _CodigoCantidadTipo & "," &
                      " BusquedaRapida=" & _BusquedaRapida & "," &
                      " Frecuente=" & _Frecuente & "," &
                      " Servicio= " & _Servicio & "," &
                      " CuentaIngreso='" & _CuentaIngreso & "'" & "," &
                      " Activo=" & _Activo & "," &
                      " Compuesto=" & _Compuesto & "," &
                      " TipoAcumulacion_Id = " & _TipoAcumulacion_Id.ToString() & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'," &
                      " Anotaciones = '" & _Anotaciones & "'," &
                      " CodigoProveedor = '" & _CodigoProveedor & "'," &
                      " CodigoInterno = '" & CodigoInterno & "'," &
                      " SaldoPropio = " & _SaldoPropio & "," &
                      " CalculaCantidadFactura=" & _CalculaCantidadFactura & ", " &
                      " ExentoIC = " & _ExentoIC & "," &
                      " PorcIC = " & _PorcIC & "," &
                      " Lote = " & _Lote & "," &
                      " Garantia =" & _Garantia &
                      " ,CabysCodigo = '" & _CodigoCabys &
                      "' ,CabysDescripcion = '" & _CabysDescripcion &
                      "' ,CabysTarifa = " & _CabysTarifa &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And     Art_Id='" & _Art_Id & "'"

            Cn.Ejecutar(Query)


            Mensaje = GuardaEquivalentes()
            VerificaMensaje(Mensaje)

            Mensaje = GuardaConjuntos()
            VerificaMensaje(Mensaje)

            Mensaje = GuardaImpuestos()
            VerificaMensaje(Mensaje)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try

            _Existe = False
            Cn.Open()

            Query = "select * From Articulo" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And     Art_Id='" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Existe = True
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Cat_Id = Tabla.Rows(0).Item("Cat_Id")
                _SubCat_Id = Tabla.Rows(0).Item("SubCat_Id")
                _Departamento_Id = Tabla.Rows(0).Item("Departamento_Id")
                _UnidadMedida_Id = Tabla.Rows(0).Item("UnidadMedida_Id")
                _FactorConversion = Tabla.Rows(0).Item("FactorConversion")
                _ExentoIV = Tabla.Rows(0).Item("ExentoIV")
                _Suelto = Tabla.Rows(0).Item("Suelto")
                _ArtPadre = IIf(IsDBNull(Tabla.Rows(0).Item("ArtPadre")), "", Tabla.Rows(0).Item("ArtPadre"))
                _SolicitarCantidad = Tabla.Rows(0).Item("SolicitarCantidad")
                _PermiteFacturar = Tabla.Rows(0).Item("PermiteFacturar")
                _CodigoCantidad = Tabla.Rows(0).Item("CodigoCantidad")
                _CodigoCantidadTipo = Tabla.Rows(0).Item("CodigoCantidadTipo")
                _BusquedaRapida = Tabla.Rows(0).Item("BusquedaRapida")
                _Frecuente = Tabla.Rows(0).Item("Frecuente")
                _Servicio = Tabla.Rows(0).Item("Servicio")
                _Activo = Tabla.Rows(0).Item("Activo")
                _CuentaIngreso = Tabla.Rows(0).Item("CuentaIngreso")
                _TipoAcumulacion_Id = Tabla.Rows(0).Item("TipoAcumulacion_Id")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _Compuesto = Tabla.Rows(0).Item("Compuesto")
                _Anotaciones = Tabla.Rows(0).Item("Anotaciones")
                _CodigoProveedor = Tabla.Rows(0).Item("CodigoProveedor")
                _CodigoInterno = Tabla.Rows(0).Item("CodigoInterno")
                _SaldoPropio = Tabla.Rows(0).Item("SaldoPropio")
                _CalculaCantidadFactura = Tabla.Rows(0).Item("CalculaCantidadFactura")
                _ExentoIC = Tabla.Rows(0).Item("CalculaCantidadFactura")
                _PorcIC = Tabla.Rows(0).Item("PorcIC")
                _Lote = Tabla.Rows(0).Item("Lote")
                _Garantia = Tabla.Rows(0).Item("Garantia")
                _CodigoCabys = IIf(IsDBNull(Tabla.Rows(0).Item("CAbysCodigo")), "", Tabla.Rows(0).Item("CAbysCodigo"))
                _CabysDescripcion = IIf(IsDBNull(Tabla.Rows(0).Item("CabysDescripcion")), "", Tabla.Rows(0).Item("CabysDescripcion"))
            End If
            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function PreciosCambiados(pDesde As Date, pHasta As Date, pBod_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()
            Query = "exec ArticulosCambioPrecio " & Emp_Id.ToString & "," & SucursalInfo.Suc_Id & ",'" & pDesde.ToString("yyyyMMdd") & "','" & pHasta.ToString("yyyyMMdd") & "'"
            'Query = "select a.Art_Id , a.Nombre , iif(a.ExentoIV = 1, b.Precio, b.Precio * 1.13) as Precio" &
            '        " from Articulo a" &
            '        " inner join ArticuloBodega b on b.Emp_Id = a.Emp_Id and b.Art_Id = a.Art_Id" &
            '        " where b.Suc_Id = " & SucursalInfo.Suc_Id & " and b.Bod_Id = " & pBod_Id &
            '        " and a.UltimaModificacion >= '" & pDesde.ToString("yyyyMMdd") & "'" &
            '        " and a.UltimaModificacion < dateadd(day, 1,'" & pHasta.ToString("yyyyMMdd") & "')" &
            '        " and a.Emp_Id = " & Emp_Id
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

    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            'Query = "select * From Articulo where Emp_Id = " & _Emp_Id.ToString
            Query = "select * from ArtiParaConteo"

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

    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Articulo_Id as Numero, Nombre From Articulo"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                pCombo.DataSource = Nothing
                pCombo.DataSource = Tabla
                pCombo.DisplayMember = "Nombre"
                pCombo.ValueMember = "Numero"
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ListBusqueda(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Art_Id as Codigo, Nombre, Suelto, ExentoIV From Articulo " &
                "where Emp_Id = " & _Emp_Id.ToString & " and Nombre like '%" & pNombre & "%' and Activo = 1"

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

    Public Function ArticuloEtiquetado() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            _Existe = False

            Cn.Open()

            Query = "select CodigoCantidadTipo From Articulo" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And       Art_Id='" & _Art_Id & "' and CodigoCantidad = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _CodigoCantidadTipo = Tabla.Rows(0).Item("CodigoCantidadTipo")
                _Existe = True
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function LlenaArreglo(ByRef BotonesArticulo() As TBoton) As String
        Dim query As String = ""
        Dim BotonId As Long = 0
        Dim Tabla As DataTable
        Try

            _CantidadBotones = 0

            Cn.Open()

            query = "select Art_Id, Nombre from Articulo" &
                " where Emp_Id = " & _Emp_Id.ToString &
                " and Cat_Id = " & _Cat_Id.ToString &
                " and SubCat_Id = " & _SubCat_Id.ToString &
                " and Activo = 1 and BusquedaRapida = 1"

            Tabla = Cn.Seleccionar(query).Copy

            If Not Tabla Is Nothing Then
                For Each Fila As DataRow In Tabla.Rows
                    ReDim Preserve BotonesArticulo(BotonId)

                    BotonesArticulo(BotonId) = New TBoton
                    With BotonesArticulo(BotonId)
                        .Name = coNombreArticuloPrefijo & "_" & BotonId.ToString
                        .Tag = Fila("Art_Id").ToString
                        .Text = Fila("Nombre")
                        .TipoBoton = coTipoBotonArticulo
                        '.BackColor = Drawing.Color.LightBlue
                    End With
                    _CantidadBotones = _CantidadBotones + 1
                    BotonId = BotonId + 1
                Next
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function LlenaArregloFrecuentes(ByRef BotonesFrecuentes() As TBoton) As String
        Dim query As String = ""
        Dim BotonId As Long = 0
        Dim Tabla As DataTable
        Try
            _CantidadBotones = 0

            Cn.Open()

            query = "select Art_Id, Nombre from Articulo where Emp_Id = " & _Emp_Id.ToString & " And Activo = 1 and Frecuente = 1"

            Tabla = Cn.Seleccionar(query).Copy

            If Not Tabla Is Nothing Then
                For Each Fila As DataRow In Tabla.Rows
                    ReDim Preserve BotonesFrecuentes(BotonId)

                    BotonesFrecuentes(BotonId) = New TBoton
                    With BotonesFrecuentes(BotonId)
                        .Name = coNombreFrecuentePrefijo & "_" & BotonId.ToString
                        .Tag = Fila("Art_Id").ToString
                        .Text = Fila("Nombre")
                        .TipoBoton = coTipoBotonFrecuente
                        .BackColor = Drawing.Color.LightBlue
                    End With
                    _CantidadBotones = _CantidadBotones + 1
                    BotonId = BotonId + 1
                Next
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try

    End Function

    Public Function CreaArticuloSuelto(pArtHijo_Id As String, pPrecio As Double, pBusquedaRapida As Integer, pFrecuencia As Integer) As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec CreaArticuloSuelto " & _Emp_Id & ",'" & _Art_Id & "','" & pArtHijo_Id & "'," & pPrecio & "," & pBusquedaRapida & "," & pFrecuencia

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function CreaArticulo() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec CreaArticulo " & _Emp_Id & ",'" & _Art_Id & "','" & _Nombre & "'," & _Cat_Id & "," & _SubCat_Id & "," & _Departamento_Id & "," & _UnidadMedida_Id & "," & _ExentoIV & "," & _Servicio & "," & _Costo & "," & _Margen

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ConsultaAnotaciones() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * from ArticuloAnotacion where Emp_Id = " & _Emp_Id.ToString() & " and Art_Id = '" & _Art_Id & "' order by Anotacion_Id asc"

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

    Public Function Modifica() As String
        Dim Query As String = ""
        Dim Mensaje As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.Articulo " &
                      " SET   Nombre='" & _Nombre & "' " & "," &
                      " Cat_Id=" & _Cat_Id & "," &
                      " SubCat_Id=" & _SubCat_Id & "," &
                      " Departamento_Id=" & _Departamento_Id & "," &
                      " UnidadMedida_Id=" & _UnidadMedida_Id & "," &
                      " FactorConversion=" & _FactorConversion & "," &
                      " ExentoIV=" & _ExentoIV & "," &
                      " Suelto=" & _Suelto & "," &
                      " ArtPadre=" & IIf(_Suelto, "'" & _ArtPadre & "'", "null") & "," &
                      " SolicitarCantidad=" & _SolicitarCantidad & "," &
                      " PermiteFacturar=" & _PermiteFacturar & "," &
                      " CodigoCantidad=" & _CodigoCantidad & "," &
                      " CodigoCantidadTipo=" & _CodigoCantidadTipo & "," &
                      " BusquedaRapida=" & _BusquedaRapida & "," &
                      " Frecuente=" & _Frecuente & "," &
                      " Servicio= " & _Servicio & "," &
                      " ExentoIC=" & _ExentoIC & "," &
                      " PorcIC=" & _PorcIC & "," &
                      " Lote=" & _Lote & "," &
                      " Activo=" & _Activo & "," &
                      " TipoAcumulacion_Id = " & _TipoAcumulacion_Id.ToString() & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And     Art_Id='" & _Art_Id & "'"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ListaCompleta() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()


            Query = "select Emp_Id,Art_Id,Nombre,Cat_Id,SubCat_Id,Departamento_Id,UnidadMedida_Id,FactorConversion,ExentoIV,Suelto,ArtPadre,SolicitarCantidad,PermiteFacturar,CodigoCantidad,CodigoCantidadTipo,BusquedaRapida,Frecuente,Servicio,TipoAcumulacion_Id,Activo,UltimaModificacion " &
            "from Articulo where Emp_Id = " & _Emp_Id.ToString

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


    Public Function GeneraEtiqueta() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec GeneraEtiqueta " & _Emp_Id.ToString & ",'" & _Art_Id & "'"

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

    Public Function ArticuloReceta() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try

            _Existe = False
            Cn.Open()

            Query = "select a.*, b.Precio, b.Costo From Articulo a inner join ArticuloBodega b on a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id" &
           " Where     a.Emp_Id=" & _Emp_Id.ToString() &
           " And     a.Art_Id= '" & _Art_Id & "'" &
           " And     b.Suc_Id = " & SucursalParametroInfo.Suc_Id &
           " And     b.Bod_Id = " & SucursalParametroInfo.BodCompra_Id

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Existe = True
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Cat_Id = Tabla.Rows(0).Item("Cat_Id")
                _SubCat_Id = Tabla.Rows(0).Item("SubCat_Id")
                _Departamento_Id = Tabla.Rows(0).Item("Departamento_Id")
                _UnidadMedida_Id = Tabla.Rows(0).Item("UnidadMedida_Id")
                _FactorConversion = Tabla.Rows(0).Item("FactorConversion")
                _ExentoIV = Tabla.Rows(0).Item("ExentoIV")
                _Suelto = Tabla.Rows(0).Item("Suelto")
                _ArtPadre = IIf(IsDBNull(Tabla.Rows(0).Item("ArtPadre")), "", Tabla.Rows(0).Item("ArtPadre"))
                _SolicitarCantidad = Tabla.Rows(0).Item("SolicitarCantidad")
                _PermiteFacturar = Tabla.Rows(0).Item("PermiteFacturar")
                _CodigoCantidad = Tabla.Rows(0).Item("CodigoCantidad")
                _CodigoCantidadTipo = Tabla.Rows(0).Item("CodigoCantidadTipo")
                _BusquedaRapida = Tabla.Rows(0).Item("BusquedaRapida")
                _Frecuente = Tabla.Rows(0).Item("Frecuente")
                _Servicio = Tabla.Rows(0).Item("Servicio")
                _Activo = Tabla.Rows(0).Item("Activo")
                _CuentaIngreso = Tabla.Rows(0).Item("CuentaIngreso")
                _TipoAcumulacion_Id = Tabla.Rows(0).Item("TipoAcumulacion_Id")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _Compuesto = Tabla.Rows(0).Item("Compuesto")
                _Precio = Tabla.Rows(0).Item("Precio")
                _Costo = Tabla.Rows(0).Item("Costo")
                _ExentoIC = Tabla.Rows(0).Item("ExentoIC")
                _PorcIC = Tabla.Rows(0).Item("PorcIC")
                _Lote = Tabla.Rows(0).Item("Lote")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function ValidaCodigoArticulo(pProv_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ValidaCodigoArticulo " & _Emp_Id.ToString() & "," & pProv_Id.ToString() & ",'" & _Art_Id & "'"

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
    Public Function CargaEquivalenteProveedor(pProv_Id As Integer, pArtEquivalente_Id As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try

            _Existe = False
            Cn.Open()

            Query = "select b.* From ArticuloEquivalenteProveedor a (nolock)" &
           " inner join Articulo b (nolock) on a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id" &
           " Where a.Emp_Id=" & _Emp_Id.ToString() &
           " And a.Prov_Id='" & pProv_Id & "'" &
           " And a.ArtEquivalente_Id = '" & pArtEquivalente_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Existe = True
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function GuardaEquivalenteProveedor(pProv_Id As Integer, pArtEquivalente_Id As String) As String
        Dim Query As String = ""
        Dim Mensaje As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "delete ArticuloEquivalenteProveedor" &
                " where Emp_Id = " & _Emp_Id.ToString() &
                " and Prov_Id = " & pProv_Id.ToString() &
                " and Art_Id = '" & _Art_Id & "'"

            Cn.Ejecutar(Query)


            Query = "insert ArticuloEquivalenteProveedor (Emp_Id,Prov_Id,Art_Id,ArtEquivalente_Id)" &
                " values(" & _Emp_Id.ToString() & "," & pProv_Id.ToString & ",'" & _Art_Id & "','" & pArtEquivalente_Id & "')"

            Cn.Ejecutar(Query)


            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function EliminaEquivalenteProveedor(pProv_Id As Integer) As String
        Dim Query As String = ""
        Dim Mensaje As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "delete ArticuloEquivalenteProveedor" &
                " where Emp_Id = " & _Emp_Id.ToString() &
                " and Prov_Id = " & pProv_Id.ToString() &
                " and Art_Id = '" & _Art_Id & "'"

            Cn.Ejecutar(Query)



            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function TableArticulos(articulos As List(Of TArticulo)) As DataTable
        Dim table As DataTable = New DataTable("Articulostmp")
        Try
            table.Columns.Add("Emp_Id", GetType(Integer))
            table.Columns.Add("Codigo", GetType(String))
            table.Columns.Add("CodigoCabys", GetType(String))
            table.Columns.Add("Descripcion", GetType(String))
            table.Columns.Add("Tarifa", GetType(Double))

            For Each item In articulos


                Dim row = table.NewRow()
                row("Emp_Id") = item.Emp_Id
                row("Codigo") = item.Art_Id
                row("CodigoCabys") = item.CodigoCabys
                row("Descripcion") = item.CabysDescripcion
                row("Tarifa") = item.CabysTarifa


                table.Rows.Add(row)
            Next

            Return table

        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Public Function AsignarCabys(articulos As List(Of TArticulo))

        Dim Connection = New SqlConnection(GetConnectionString())

        Try
            Connection.Open()

            Dim Command = Connection.CreateCommand
            Command.CommandText = "AsignaCabys"

            Command.CommandType = CommandType.StoredProcedure

            Command.Parameters.Add("@Articulos", SqlDbType.Structured).TypeName = "Articulostmp"
            Command.Parameters("@Articulos").Value = TableArticulos(articulos)

            Command.ExecuteNonQuery()

        Catch ex As Exception

            Throw ex

        Finally
            Connection.Close()
            Connection.Dispose()
        End Try
    End Function


    Public Function AsignaCAbysArticulo(Art_id As String, CabysCodigo As String, Descripcion As String, Tarifa As Double) As String
        Dim Query As String = ""
        Dim Mensaje As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Update Articulo set CabysCodigo = '" & CabysCodigo & "', CabysDescripcion = '" & Descripcion & "', CabysTarifa =" & Tarifa &
                " where Emp_Id = " & _Emp_Id.ToString() &
                " and Art_Id = '" & Art_id & "'"

            Cn.Ejecutar(Query)



            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    'Public Function BuscaApartados(ByVal pDesde As Date,
    '                                    ByVal pHasta As Date,
    '                                    ByVal IdCliente As Integer) As String
    '    Dim Query As String
    '    Dim orderBy As String = " order by a.Fecha desc"
    '    Dim Tabla As DataTable
    '    Try
    '        Cn.Open()

    '        Query = "select a.Caja_Id as caja
    '                       ,d.Nombre as CajaNombre
    '                       ,b.Nombre as Tipo
    '                       ,a.Documento_Id as Numero
    '                       ,a.Fecha
    '                       ,c.Nombre as Cliente
    '                       ,a.Total as Monto
    '                       ,a.TipoDoc_Id
    '                       ,c.Email
    '                       ,isnull(e.Clave,'') as Clave 
    '                       ,substring(isnull(e.Consecutivo,'00000000000000000000'),9,2) as TipoDoc 
    '                       ,isnull(e.Doc_Id,0) as Doc_Id
    '                       ,isnull(f.Nombre,0) as EstadoNombre
    '                From FacturaEncabezado a (nolock)
    '                    inner join TipoDocumento b (nolock) on a.Emp_Id = b.Emp_Id and a.TipoDoc_Id =  b.TipoDoc_Id 
    '                    inner join Cliente c (nolock) on a.Emp_Id = c.Emp_Id and a.Cliente_Id = c.Cliente_Id
    '                    inner join Caja d (nolock) on a.Emp_Id = d.Emp_Id and a.Suc_Id = d.Suc_Id and a.Caja_Id = d.Caja_Id
    '                    left join FacturaElectronica e (nolock) on a.Emp_Id = e.Emp_Id and a.Suc_Id = e.Suc_Id and a.Caja_Id = e.Caja_Id and a.TipoDoc_Id = e.TipoDoc_Id and a.Documento_Id = e.Documento_Id 
    '                    left join FacturaElectronicaEstado f (nolock) on e.Estado_Id = f.Estado_Id" &
    '                " where a.Emp_Id = " & _Emp_Id.ToString() &
    '                   "and a.Suc_Id = " & _Suc_Id.ToString() &
    '                   "And (a.Fecha >= '" & pDesde.ToString("yyyyMMdd") & "' " &
    '                    "and a.Fecha <  '" & pHasta.ToString("yyyyMMdd") & "')"


    '        If IdCliente <> 0 Then
    '            Query = Query & " And a.Cliente_Id = '" & IdCliente & "'"
    '        End If

    '        Query = Query & orderBy

    '        Tabla = Cn.Seleccionar(Query).Copy

    '        If _Data.Tables.Contains(Tabla.TableName) Then
    '            _Data.Tables.Remove(Tabla.TableName)
    '        End If

    '        _Data.Tables.Add(Tabla)

    '        Return ""

    '    Catch ex As Exception
    '        Return ex.Message
    '    Finally
    '        Cn.Close()
    '    End Try
    'End Function

#End Region
End Class
