Imports System.Windows.Forms

Public Class TArticuloBodega
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Bod_Id As Integer
    Private _Art_Id As String
    Private _Saldo As Double
    Private _Comprometido As Double
    Private _CostoPromedio As Double
    Private _Costo As Double
    Private _Margen As Double
    Private _MargenMayorista As Double
    Private _Margen3 As Double
    Private _Margen4 As Double
    Private _Margen5 As Double
    Private _Precio As Double
    Private _PrecioMayorista As Double
    Private _Precio3 As Double
    Private _Precio4 As Double
    Private _Precio5 As Double
    Private _FechaIniDescuento As DateTime
    Private _FechaFinDescuento As DateTime
    Private _PorcDescuento As Double
    Private _FechaUltimaVenta As DateTime
    Private _PromedioVenta As Double
    Private _Minimo As Double
    Private _Maximo As Double
    Private _Activo As Integer
    Private _Ubicacion As String
    Private _UltimaModificacion As DateTime
    Private _CostoNeto As Double
    Private _Data As DataSet
    Private _PrecioValue As Double

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
    Public Property Art_Id() As String
        Get
            Return _Art_Id
        End Get
        Set(ByVal Value As String)
            _Art_Id = Value
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
    Public ReadOnly Property Comprometido As Double
        Get
            Return _Comprometido
        End Get
    End Property
    Public Property CostoPromedio() As Double
        Get
            Return _CostoPromedio
        End Get
        Set(ByVal Value As Double)
            _CostoPromedio = Value
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
    Public Property MargenMayorista() As Double
        Get
            Return _MargenMayorista
        End Get
        Set(ByVal Value As Double)
            _MargenMayorista = Value
        End Set
    End Property
    Public Property Margen3() As Double
        Get
            Return _Margen3
        End Get
        Set(ByVal Value As Double)
            _Margen3 = Value
        End Set
    End Property
    Public Property Margen4() As Double
        Get
            Return _Margen4
        End Get
        Set(ByVal Value As Double)
            _Margen4 = Value
        End Set
    End Property
    Public Property Margen5() As Double
        Get
            Return _Margen5
        End Get
        Set(ByVal Value As Double)
            _Margen5 = Value
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
    Public Property PrecioValue() As Double
        Get
            Return _PrecioValue
        End Get
        Set(ByVal Value As Double)
            _PrecioValue = Value
        End Set
    End Property
    Public Property PrecioMayorista() As Double
        Get
            Return _PrecioMayorista
        End Get
        Set(ByVal Value As Double)
            _PrecioMayorista = Value
        End Set
    End Property
    Public Property Precio3() As Double
        Get
            Return _Precio3
        End Get
        Set(ByVal Value As Double)
            _Precio3 = Value
        End Set
    End Property
    Public Property Precio4() As Double
        Get
            Return _Precio4
        End Get
        Set(ByVal Value As Double)
            _Precio4 = Value
        End Set
    End Property
    Public Property Precio5() As Double
        Get
            Return _Precio5
        End Get
        Set(ByVal Value As Double)
            _Precio5 = Value
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
    Public Property FechaUltimaVenta() As DateTime
        Get
            Return _FechaUltimaVenta
        End Get
        Set(ByVal Value As DateTime)
            _FechaUltimaVenta = Value
        End Set
    End Property
    Public Property PromedioVenta() As Double
        Get
            Return _PromedioVenta
        End Get
        Set(ByVal Value As Double)
            _PromedioVenta = Value
        End Set
    End Property
    Public Property Minimo() As Double
        Get
            Return _Minimo
        End Get
        Set(ByVal Value As Double)
            _Minimo = Value
        End Set
    End Property
    Public Property Maximo() As Double
        Get
            Return _Maximo
        End Get
        Set(ByVal Value As Double)
            _Maximo = Value
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
    Public Property Ubicacion As String
        Get
            Return _Ubicacion
        End Get
        Set(value As String)
            _Ubicacion = value
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

    Public Property CostoNeto() As String
        Get
            Return _CostoNeto
        End Get
        Set(ByVal value As String)
            _CostoNeto = value
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
        _Saldo = 0.0
        _Comprometido = 0.0
        _CostoPromedio = 0.0
        _Costo = 0.0
        _Margen = 0.0
        _Margen3 = 0.0
        _Margen4 = 0.0
        _Margen5 = 0.0
        _MargenMayorista = 0.0
        _Precio = 0.0
        _PrecioMayorista = 0.0
        _Precio3 = 0.0
        _Precio4 = 0.0
        _Precio5 = 0.0
        _FechaIniDescuento = CDate("1900/01/01")
        _FechaFinDescuento = CDate("1900/01/01")
        _PorcDescuento = 0.0
        _FechaUltimaVenta = CDate("1900/01/01")
        _PromedioVenta = 0.0
        _Minimo = 0.0
        _Maximo = 0.0
        _Activo = 0
        _Ubicacion = ""
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New DataSet
        _CostoNeto = 0.0
        _PrecioValue = 0.0
    End Sub
#End Region
#Region "Definicion metodos publicos"

    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into ArticuloBodega( Emp_Id , Suc_Id" &
                    " , Bod_Id , Art_Id" &
                    " , Saldo , Comprometido" &
                    " , CostoPromedio" &
                    " , Costo , Margen" &
                    " , MargenMayorista , Margen3" &
                    " , Margen4 , Margen5" &
                    " , Precio , PrecioMayorista" &
                    " , Precio3 , Precio4" &
                    " , Precio5 , FechaIniDescuento" &
                    " , FechaFinDescuento , PorcDescuento" &
                    " , FechaUltimaVenta , PromedioVenta" &
                    " , Minimo , Maximo" &
                    " , Activo , Ubicacion" &
                    " , UltimaModificacion , CostoNeto )" &
                    " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                    "," & _Bod_Id.ToString() & ",'" & _Art_Id & "'" &
                    "," & _Saldo.ToString() & "," & _Comprometido.ToString() &
                    "," & _CostoPromedio.ToString() &
                    "," & _Costo.ToString() & "," & _Margen.ToString() &
                    "," & _MargenMayorista.ToString() & "," & _Margen3.ToString() &
                    "," & _Margen4.ToString() & "," & _Margen5.ToString() &
                    "," & _Precio.ToString() & "," & _PrecioMayorista.ToString() &
                    "," & _Precio3.ToString() & "," & _Precio4.ToString() &
                    "," & _Precio5.ToString() & ",'" & Format(_FechaIniDescuento, "yyyyMMdd HH:mm:ss") & "'" &
                    ",'" & Format(_FechaFinDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," & _PorcDescuento.ToString() &
                    ",'" & Format(_FechaUltimaVenta, "yyyyMMdd HH:mm:ss") & "'" & "," & _PromedioVenta.ToString() &
                    "," & _Minimo.ToString() & "," & _Maximo.ToString() &
                    "," & _Activo.ToString() & ",'" & _Ubicacion & "'" &
                    ",GETDATE()" & ", " & CostoNeto & ")"

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

    Public Overrides Function Delete() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Delete ArticuloBodega" &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Bod_Id=" & _Bod_Id.ToString() &
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

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.ArticuloBodega set " &
                    " Margen=" & _Margen & "," &
                    " MargenMayorista=" & _MargenMayorista & "," &
                    " Margen3=" & _Margen3 & "," &
                    " Margen4=" & _Margen4 & "," &
                    " Margen5=" & _Margen5 & "," &
                    " Precio=" & _Precio & "," &
                    " PrecioMayorista=" & _PrecioMayorista & "," &
                    " Precio3=" & _Precio3 & "," &
                    " Precio4=" & _Precio4 & "," &
                    " Precio5=" & _Precio5 & "," &
                    " FechaIniDescuento='" & Format(_FechaIniDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " FechaFinDescuento='" & Format(_FechaFinDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " PorcDescuento=" & _PorcDescuento & "," &
                    " Minimo=" & _Minimo & "," &
                    " Maximo=" & _Maximo & "," &
                    " Activo=" & _Activo & "," &
                    " Ubicacion='" & _Ubicacion & "'," &
                    " UltimaModificacion=GETDATE() ," &
                    " CostoNeto = " & _CostoNeto &
                    " Where Emp_Id=" & _Emp_Id.ToString() &
                    " And   Suc_Id=" & _Suc_Id.ToString() &
                    " And   Bod_Id=" & _Bod_Id.ToString() &
                    " And   Art_Id='" & _Art_Id & "'"

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

    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From ArticuloBodega" &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Bod_Id=" & _Bod_Id.ToString() &
                    " And     Art_Id='" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Saldo = Tabla.Rows(0).Item("Saldo")
                _Comprometido = Tabla.Rows(0).Item("Comprometido")
                _CostoPromedio = Tabla.Rows(0).Item("CostoPromedio")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Margen = Tabla.Rows(0).Item("Margen")
                _MargenMayorista = Tabla.Rows(0).Item("MargenMayorista")
                _Margen3 = Tabla.Rows(0).Item("Margen3")
                _Margen4 = Tabla.Rows(0).Item("Margen4")
                _Margen5 = Tabla.Rows(0).Item("Margen5")
                _Precio = Tabla.Rows(0).Item("Precio")
                _PrecioMayorista = Tabla.Rows(0).Item("PrecioMayorista")
                _Precio3 = Tabla.Rows(0).Item("Precio3")
                _Precio4 = Tabla.Rows(0).Item("Precio4")
                _Precio5 = Tabla.Rows(0).Item("Precio5")
                _FechaIniDescuento = Tabla.Rows(0).Item("FechaIniDescuento")
                _FechaFinDescuento = Tabla.Rows(0).Item("FechaFinDescuento")
                _PorcDescuento = Tabla.Rows(0).Item("PorcDescuento")
                _FechaUltimaVenta = Tabla.Rows(0).Item("FechaUltimaVenta")
                _PromedioVenta = Tabla.Rows(0).Item("PromedioVenta")
                _Minimo = Tabla.Rows(0).Item("Minimo")
                _Maximo = Tabla.Rows(0).Item("Maximo")
                _Activo = Tabla.Rows(0).Item("Activo")
                _Ubicacion = Tabla.Rows(0).Item("Ubicacion")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _CostoNeto = Tabla.Rows(0).Item("CostoNeto")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ListKeySucursal() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From ArticuloBodega" &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And     Art_Id='" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Saldo = Tabla.Rows(0).Item("Saldo")
                _Comprometido = Tabla.Rows(0).Item("Comprometido")
                _CostoPromedio = Tabla.Rows(0).Item("CostoPromedio")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Margen = Tabla.Rows(0).Item("Margen")
                _MargenMayorista = Tabla.Rows(0).Item("MargenMayorista")
                _Margen3 = Tabla.Rows(0).Item("Margen3")
                _Margen4 = Tabla.Rows(0).Item("Margen4")
                _Margen5 = Tabla.Rows(0).Item("Margen5")
                _Precio = Tabla.Rows(0).Item("Precio")
                _PrecioMayorista = Tabla.Rows(0).Item("PrecioMayorista")
                _Precio3 = Tabla.Rows(0).Item("Precio3")
                _Precio4 = Tabla.Rows(0).Item("Precio4")
                _Precio5 = Tabla.Rows(0).Item("Precio5")
                _FechaIniDescuento = Tabla.Rows(0).Item("FechaIniDescuento")
                _FechaFinDescuento = Tabla.Rows(0).Item("FechaFinDescuento")
                _PorcDescuento = Tabla.Rows(0).Item("PorcDescuento")
                _FechaUltimaVenta = Tabla.Rows(0).Item("FechaUltimaVenta")
                _PromedioVenta = Tabla.Rows(0).Item("PromedioVenta")
                _Minimo = Tabla.Rows(0).Item("Minimo")
                _Maximo = Tabla.Rows(0).Item("Maximo")
                _Activo = Tabla.Rows(0).Item("Activo")
                _Ubicacion = Tabla.Rows(0).Item("Ubicacion")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _CostoNeto = Tabla.Rows(0).Item("CostoNeto")
                _PrecioValue = Tabla.Rows(0).Item("Precio")
            End If

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

            Query = "select * From ArticuloBodega"

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

            Query = "select ArticuloBodega_Id as Numero, Nombre From ArticuloBodega"

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

            'Query = "select b.Art_Id as Codigo, b.Nombre, round(a.Saldo,4) as Saldo, round(a.Transito,4) as Transito, round(a.Precio,2) as Precio, b.Suelto From ArticuloBodega a, Articulo b " & _
            '    "where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id and a.Activo = 1 and b.Activo = 1 " & _
            '    "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.Bod_Id = " & _Bod_Id.ToString & _
            '    "and b.Nombre like '%" & pNombre & "%'"

            Query = "select b.Art_Id as Codigo, b.Nombre, round(a.Saldo,4) as Saldo, round(a.Precio,2) as Precio, round(a.PrecioMayorista,2) as Mayorista From ArticuloBodega a, Articulo b " &
            "where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id and a.Activo = 1 and b.Activo = 1 " &
            "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.Bod_Id = " & _Bod_Id.ToString &
            "and b.Nombre like '%" & pNombre & "%' order by Nombre asc"

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

    Public Function ListBusquedaPuntoVenta(pNombre As String, ptipoBusqueda As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            'Query = "select b.Art_Id as Codigo, b.Nombre, round(a.Saldo,4) as Saldo, round(a.Transito,4) as Transito, round(a.Precio,2) as Precio, b.Suelto From ArticuloBodega a, Articulo b " & _
            '    "where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id and a.Activo = 1 and b.Activo = 1 " & _
            '    "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.Bod_Id = " & _Bod_Id.ToString & _
            '    "and b.Nombre like '%" & pNombre & "%'"

            If ptipoBusqueda = 1 Then
                Query = "select b.Art_Id as Codigo, b.Nombre, round(a.Saldo,4) as Saldo, round(a.Precio,2) as Precio, round(a.PrecioMayorista,2) as Mayorista, round(a.Precio3,2) as Precio3, round(a.Precio4,2) as Precio4, round(a.Precio5,2) as Precio5, iif(b.ExentoIV = 1,'Si','No') as Exento From ArticuloBodega a, Articulo b " &
            "where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id and a.Activo = 1 and b.Activo = 1 " &
            "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.Bod_Id = " & _Bod_Id.ToString &
            "and b.Nombre like '%" & pNombre & "%' order by Nombre asc"
            Else
                Query = "select b.Art_Id as Codigo, b.Nombre, round(a.Saldo,4) as Saldo, round(a.Precio,2) as Precio, round(a.PrecioMayorista,2) as Mayorista, round(a.Precio3,2) as Precio3, round(a.Precio4,2) as Precio4, round(a.Precio5,2) as Precio5, iif(b.ExentoIV = 1,'Si','No') as Exento From ArticuloBodega a, Articulo b, ArticuloEquivalente c " &
            "where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id and a.Activo = 1 and b.Activo = 1  and a.Emp_id = c.Emp_Id and a.Art_Id = c.Art_Id " &
            "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.Bod_Id = " & _Bod_Id.ToString &
            "and c.ArtEquivalente_Id like '%" & pNombre & "%' order by Nombre asc"
            End If

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

    Public Function ListBusquedaCABYS(pNombre As String, ptipoBusqueda As Integer, checkcabys As Boolean) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            'Query = "select b.Art_Id as Codigo, b.Nombre, round(a.Saldo,4) as Saldo, round(a.Transito,4) as Transito, round(a.Precio,2) as Precio, b.Suelto From ArticuloBodega a, Articulo b " & _
            '    "where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id and a.Activo = 1 and b.Activo = 1 " & _
            '    "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.Bod_Id = " & _Bod_Id.ToString & _
            '    "and b.Nombre like '%" & pNombre & "%'"

            If ptipoBusqueda = 1 Then

                If checkcabys = True Then
                    Query = "select b.Art_Id as Codigo, b.Nombre , isnull(b.CabysCodigo,'') as CABYS From  Articulo b " &
                            "where b.Activo = 1 " &
                            "and b.Emp_Id = " & _Emp_Id.ToString &
                            "and b.CabysCodigo is null " &
                            "and b.Nombre like '%" & pNombre & "%' order by Nombre asc"

                Else
                    Query = "select b.Art_Id as Codigo, b.Nombre , isnull(b.CabysCodigo,'') as CABYS From  Articulo b " &
                            "where b.Activo = 1 " &
                            "and b.Emp_Id = " & _Emp_Id.ToString &
                            "and b.Nombre like '%" & pNombre & "%' order by Nombre asc"
                End If
            Else

                If checkcabys = True Then
                    Query = "select b.Art_Id as Codigo, b.Nombre, isnull(b.CabysCodigo,'') as CABYS  From  Articulo b, ArticuloEquivalente c " &
                             "where b.Emp_id = c.Emp_Id and b.Art_Id = c.Art_Id " &
                             "and b.Emp_Id = " & _Emp_Id.ToString &
                             "and b.CabysCodigo is null " &
                             "and c.ArtEquivalente_Id like '%" & pNombre & "%' order by Nombre asc"
                Else
                    Query = "select b.Art_Id as Codigo, b.Nombre, isnull(b.CabysCodigo,'') as CABYS  From  Articulo b, ArticuloEquivalente c " &
                             "where b.Emp_id = c.Emp_Id and b.Art_Id = c.Art_Id " &
                             "and b.Emp_Id = " & _Emp_Id.ToString &
                             "and c.ArtEquivalente_Id like '%" & pNombre & "%' order by Nombre asc"
                End If

            End If

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






    Public Function ListBusquedaInventario(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select b.Art_Id as Codigo, b.Nombre, round(a.Saldo,4) as Saldo, round(a.Precio,2) as Precio, round(a.PrecioMayorista,2) as Mayorista, round(a.Precio3,2) as Precio3, round(a.Precio4,2) as Precio4, round(a.Precio5,2) as Precio5, round(a.Costo,2) as Costo From ArticuloBodega a, Articulo b " &
            "where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id and a.Activo = 1 and b.Activo = 1 " &
            "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.Bod_Id = " & _Bod_Id.ToString &
            "and b.Nombre like '%" & pNombre & "%' order by Nombre asc"

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

    Public Function ListBusquedaInventarioOnLine(pValor As String, pTipoCriterio As Integer, pTipoBusqueda As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim CriterioBusqueda As String = String.Empty
        Try
            Cn.Open()

            Query = " select b.Art_Id as Codigo, b.Nombre, round(a.Saldo,4) as Saldo, round(a.Precio,2) as Precio, round(a.PrecioMayorista,2) as Mayorista, round(a.Precio3,2) as Precio3, round(a.Precio4,2) as Precio4, round(a.Precio5,2) as Precio5, round(a.Costo,2) as Costo"


            If pTipoCriterio = 3 Then
                Query = Query & ",c.ArtEquivalente_Id as Equivalente"
            End If
            If pTipoCriterio = 4 Then
                Query = Query & ",b.CodigoProveedor as CodigoProveedor"
            End If
            If pTipoCriterio = 5 Then
                Query = Query & ",b.CodigoInterno as CodigoInterno"
            End If

            If pTipoCriterio = 3 Then
                Query = Query & " From ArticuloBodega a inner join Articulo b on a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id" &
                                " inner join ArticuloEquivalente c on b.Emp_Id = c.Emp_Id and b.Art_Id = c.Art_Id"
            Else
                Query = Query & " From ArticuloBodega a inner join Articulo b on a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id"
            End If
            Query = Query & " where  a.Activo = 1 and b.Activo = 1 " &
            " and a.Emp_Id = " & _Emp_Id.ToString &
            " and a.Suc_Id = " & _Suc_Id.ToString &
            " and a.Bod_Id = " & _Bod_Id.ToString


            If pTipoCriterio = 1 Then 'Descripcion
                CriterioBusqueda = " and b.Nombre like '" & IIf(pTipoBusqueda = 1, "%", "") & pValor & "%' order by b.Nombre asc"
            End If

            If pTipoCriterio = 2 Then 'Codigo
                CriterioBusqueda = " and b.Art_Id like '" & IIf(pTipoBusqueda = 1, "%", "") & pValor & "%' order by b.Art_Id asc"
            End If

            If pTipoCriterio = 3 Then 'Equivalente
                CriterioBusqueda = " and c.ArtEquivalente_Id like '" & IIf(pTipoBusqueda = 1, "%", "") & pValor & "%' order by c.ArtEquivalente_Id asc"
            End If

            If pTipoCriterio = 4 Then 'Codigo Proveedor
                CriterioBusqueda = " and b.CodigoProveedor like '" & IIf(pTipoBusqueda = 1, "%", "") & pValor & "%' order by b.CodigoProveedor asc"
            End If

            If pTipoCriterio = 5 Then 'Codigo Interno
                CriterioBusqueda = " and b.CodigoInterno like '" & IIf(pTipoBusqueda = 1, "%", "") & pValor & "%' order by b.CodigoInterno asc"
            End If

            Query += CriterioBusqueda

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

    Public Function ListaBodegasArticulo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From ArticuloBodega where Emp_Id = " & _Emp_Id.ToString & " and Art_Id = '" & _Art_Id & "' order by Suc_Id, Bod_Id"

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

    Public Function ConsultaExistenciasArticulo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ConsultaExistenciasArticulo " & _Emp_Id.ToString() & ",'" & _Art_Id & "'"

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

    Public Function ConsultaExistencia() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ConsultaExistencia " & _Emp_Id.ToString() & ",'" & _Art_Id & "'"

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

    Public Function CrearAjusteCosto(pAplicarTodas As Boolean, pUsuario_Id As String) As String
        Dim Tabla As DataTable = Nothing
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            If Not pAplicarTodas Then
                Query = "select * From Bodega where Emp_Id = " & _Emp_Id.ToString & " and Suc_Id = " & _Suc_Id.ToString
                Tabla = Cn.Seleccionar(Query).Copy

                If Not Tabla Is Nothing Then
                    For Each Fila As DataRow In Tabla.Rows
                        Query = "CrearAjusteCosto " & _Emp_Id.ToString & "," & _Suc_Id.ToString() & "," & Fila("Bod_Id") & ",'" & _Art_Id & "'," & _Costo.ToString & ",'" & pUsuario_Id & "'"


                        Cn.Ejecutar(Query)
                    Next
                End If
            Else

                Query = "select Suc_Id, Bod_Id" &
                    " From ArticuloBodega" &
                    " where Emp_Id = " & _Emp_Id.ToString &
                    " And Suc_Id = " & _Suc_Id &
                    " And Art_Id = '" & _Art_Id & "'"

                Tabla = Cn.Seleccionar(Query).Copy

                If Not Tabla Is Nothing Then
                    For Each Fila As DataRow In Tabla.Rows
                        Query = "CrearAjusteCosto " & _Emp_Id.ToString & "," & Fila("Suc_Id") & "," & Fila("Bod_Id") & ",'" & _Art_Id & "'," & _Costo.ToString & ",'" & pUsuario_Id & "'"


                        Cn.Ejecutar(Query)
                    Next
                End If
            End If


            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function CalculaPromedioVenta() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec CalculaPromedioVenta " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() & ",30"

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

    Public Function RptSaldosInventario(pTipo As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptSaldosInventario " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString & "," & "'" & pTipo & "'," & _Saldo.ToString

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


    Public Function RptSaldosInventarioLotes(pTipo As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptSaldosInventarioLotes " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString & "," & "'" & pTipo & "'," & _Saldo.ToString

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



    Public Function RptSaldosInventarioCatSubCatDep() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptSaldosInventarioCatSubCatDep " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString

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

    Public Function RptArticulosListado() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()
            Query = "exec RptArticulosListado " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString
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

    Public Function RptListaPrecios(pCategorias As String, pPrecios As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()
            Query = "exec RptListaPrecios " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString & ",'" & pCategorias & "','" & pPrecios & "'"
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

    Public Function RptSaldosInventarioUbicacion(pUbicacionIni As String, pUbicacionFin As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptSaldosInventarioUbicacion " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString() & ",'" & pUbicacionIni & "','" & pUbicacionFin & "'"

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
    Public Function RptSaldosInventario(pProv_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptSaldosInventarioProveedor " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString & "," & pProv_Id.ToString & "," & _Saldo.ToString

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
    Public Function EliminaArticulo() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Delete ArticuloBodega" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And     Art_Id='" & _Art_Id & "'"

            Cn.Ejecutar(Query)


            Query = "Delete ArticuloConjunto" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And     Art_Id='" & _Art_Id & "'"

            Cn.Ejecutar(Query)


            Query = "Delete ArticuloEquivalente" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And       Art_Id='" & _Art_Id & "'"

            Cn.Ejecutar(Query)


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
    Public Function ListxBodega() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()



            Query = "select Emp_Id,Suc_Id,Bod_Id,Art_Id,CostoPromedio,Costo,Margen,MargenMayorista,Precio" &
                    ",PrecioMayorista,FechaIniDescuento,FechaFinDescuento,PorcDescuento,Minimo,Maximo,Activo,UltimaModificacion,Margen3,Margen4,Margen5,Precio3,Precio4,Precio5 From ArticuloBodega" &
                    " where Emp_Id = " & _Emp_Id.ToString &
                    " and   Suc_Id = " & _Suc_Id.ToString &
                    " and   Bod_Id = " & _Bod_Id.ToString

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

        Try
            Cn.Open()

            Cn.BeginTransaction()


            Query = " Update dbo.ArticuloBodega " &
                    " SET CostoPromedio=" & _CostoPromedio & "," &
                    " Costo=" & _Costo & "," &
                    " Margen=" & _Margen & "," &
                    " MargenMayorista=" & _MargenMayorista & "," &
                    " Margen3=" & _Margen3 & "," &
                    " Margen4=" & _Margen4 & "," &
                    " Margen5=" & _Margen5 & "," &
                    " Precio=" & _Precio & "," &
                    " PrecioMayorista=" & _PrecioMayorista & "," &
                    " Precio3=" & _Precio3 & "," &
                    " Precio4=" & _Precio4 & "," &
                    " Precio5=" & _Precio5 & "," &
                    " FechaIniDescuento='" & Format(_FechaIniDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " FechaFinDescuento='" & Format(_FechaFinDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " PorcDescuento=" & _PorcDescuento & "," &
                    " Minimo=" & _Minimo & "," &
                    " Maximo=" & _Maximo & "," &
                    " Activo=" & _Activo & "," &
                    " UltimaModificacion=GETDATE() ," &
                    " CostoNeto = " & _CostoNeto &
                    " Where Emp_Id=" & _Emp_Id.ToString() &
                    " And   Suc_Id=" & _Suc_Id.ToString() &
                    " And   Art_Id='" & _Art_Id & "'"


            'Query = " Update dbo.ArticuloBodega " & _
            '        " SET CostoPromedio=" & _CostoPromedio & "," & _
            '        " Costo=" & _Costo & "," & _
            '        " Margen=" & _Margen & "," & _
            '        " MargenMayorista=" & _MargenMayorista & "," & _
            '        " Margen3=" & _Margen3 & "," & _
            '        " Margen4=" & _Margen4 & "," & _
            '        " Margen5=" & _Margen5 & "," & _
            '        " Precio=" & _Precio & "," & _
            '        " PrecioMayorista=" & _PrecioMayorista & "," & _
            '        " Precio3=" & _Precio3 & "," & _
            '        " Precio4=" & _Precio4 & "," & _
            '        " Precio5=" & _Precio5 & "," & _
            '        " FechaIniDescuento='" & Format(_FechaIniDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," & _
            '        " FechaFinDescuento='" & Format(_FechaFinDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," & _
            '        " PorcDescuento=" & _PorcDescuento & "," & _
            '        " Minimo=" & _Minimo & "," & _
            '        " Maximo=" & _Maximo & "," & _
            '        " Activo=" & _Activo & "," & _
            '        " UltimaModificacion=GETDATE()" & _
            '        " Where Emp_Id=" & _Emp_Id.ToString() & _
            '        " And   Suc_Id=" & _Suc_Id.ToString() & _
            '        " And   Bod_Id=" & _Bod_Id.ToString() & _
            '        " And   Art_Id='" & _Art_Id & "'"

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
    Public Function ArticulosConteo() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select a.* " &
                    " from ArticuloBodega a," &
                    " Articulo b" &
                    " where a.Emp_Id = b.Emp_Id" &
                    " and   a.Art_Id = b.Art_Id" &
                    " and   b.Servicio = 0" &
                    " and   a.Emp_Id = " & _Emp_Id.ToString &
                    " and   a.Suc_Id = " & _Suc_Id.ToString &
                    " and   a.Bod_Id = " & _Bod_Id.ToString

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
    Public Function ListaSaldosXBodega() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select c.Bod_Id," &
                    " c.Nombre as NombreBodega," &
                    " a.Art_Id," &
                    " b.Nombre as NombreArticulo," &
                    " a.Saldo," &
                    " a.Precio" &
                    " from ArticuloBodega a," &
                    " Articulo b," &
                    " Bodega c" &
                    " where a.Emp_Id = b.Emp_Id" &
                    " and   a.Art_Id = b.Art_Id" &
                    " and   a.Emp_Id = c.Emp_Id" &
                    " and   a.Suc_Id = c.Suc_Id" &
                    " and   a.Bod_Id = c.Bod_Id" &
                    " and   a.Emp_Id = " & _Emp_Id.ToString &
                    " and   a.Art_Id = '" & _Art_Id & "'"
            '" and   a.Suc_Id = " & _Suc_Id.ToString & _

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
    Public Function RptSaldosXBodega(pNegativo As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "exec RptSaldosXBodega " & _Emp_Id.ToString & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString & "," & pNegativo

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
    Public Function ModificaBodegasEmpresa() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.ArticuloBodega set " &
                    " Margen=" & _Margen & "," &
                    " MargenMayorista=" & _MargenMayorista & "," &
                    " Margen3=" & _Margen3 & "," &
                    " Margen4=" & _Margen4 & "," &
                    " Margen5=" & _Margen5 & "," &
                    " Precio=" & _Precio & "," &
                    " PrecioMayorista=" & _PrecioMayorista & "," &
                    " Precio3=" & _Precio3 & "," &
                    " Precio4=" & _Precio4 & "," &
                    " Precio5=" & _Precio5 & "," &
                    " FechaIniDescuento='" & Format(_FechaIniDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " FechaFinDescuento='" & Format(_FechaFinDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " PorcDescuento=" & _PorcDescuento & "," &
                    " Minimo=" & _Minimo & "," &
                    " Maximo=" & _Maximo & "," &
                    " Activo=" & _Activo & "," &
                    " Ubicacion='" & _Ubicacion & "'," &
                    " UltimaModificacion=getdate() " &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And       Art_Id='" & _Art_Id & "'"

            Cn.Ejecutar(Query)

            Query = "Update Articulo" &
                    " set UltimaModificacion = '" & Now.ToString("yyyyMMdd") & "'" &
                     " where Emp_Id = " & Emp_Id &
                    " and Art_Id = '" & Art_Id & "'"

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
    Public Function ModificaBodegasSucursal() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.ArticuloBodega set " &
                    " Margen=" & _Margen & "," &
                    " MargenMayorista=" & _MargenMayorista & "," &
                    " Margen3=" & _Margen3 & "," &
                    " Margen4=" & _Margen4 & "," &
                    " Margen5=" & _Margen5 & "," &
                    " Precio=" & _Precio & "," &
                    " PrecioMayorista=" & _PrecioMayorista & "," &
                    " Precio3=" & _Precio3 & "," &
                    " Precio4=" & _Precio4 & "," &
                    " Precio5=" & _Precio5 & "," &
                    " FechaIniDescuento='" & Format(_FechaIniDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " FechaFinDescuento='" & Format(_FechaFinDescuento, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " PorcDescuento=" & _PorcDescuento & "," &
                    " Minimo=" & _Minimo & "," &
                    " Maximo=" & _Maximo & "," &
                    " Activo=" & _Activo & "," &
                    " Ubicacion='" & _Ubicacion & "'," &
                    " UltimaModificacion=getdate() " &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " and       Suc_Id=" & _Suc_Id.ToString() &
                    " and       Art_Id='" & _Art_Id & "'"

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
    Public Function ArticulosInactivos() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select a.Art_Id" &
                    " ,a.Nombre" &
                    " ,b.Precio" &
                    " ,b.PrecioMayorista" &
                    " ,b.Saldo" &
                    " from  Articulo a," &
                    " ArticuloBodega b" &
                    " where a.Emp_Id = b.Emp_Id" &
                    " and   a.Art_Id = b.Art_Id" &
                    " and   b.Emp_Id = " & _Emp_Id.ToString &
                    " and   b.Suc_Id = " & _Suc_Id.ToString &
                    " and   b.Bod_Id = " & _Bod_Id.ToString &
                    " and   b.Saldo != 0" &
                    " and   a.Activo = 0" &
                    " order by a.Nombre asc"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function HabilitaArticulo(pLista As ListView) As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            For Each Item As ListViewItem In pLista.CheckedItems
                Query = " update a" &
                        " set    a.Activo = 1" &
                        " ,a.UltimaModificacion = GETDATE()" &
                        " from ArticuloBodega a" &
                        " Where a.Emp_Id = " & _Emp_Id.ToString &
                        " and   a.Suc_Id = " & _Suc_Id.ToString &
                        " and   a.Bod_Id = " & _Bod_Id.ToString &
                        " and   a.Art_Id = '" & Item.SubItems(0).Text.Trim & "'"

                Cn.Ejecutar(Query)

                Query = " update a" &
                        " set    a.Activo = 1" &
                        " ,a.UltimaModificacion = GETDATE()" &
                        " from Articulo a" &
                        " Where a.Emp_Id = " & _Emp_Id.ToString &
                        " and   a.Art_Id = '" & Item.SubItems(0).Text.Trim & "'"

                Cn.Ejecutar(Query)
            Next

            Cn.CommitTransaction()

            Return String.Empty
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function RptInactivosConSaldo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptInactivosConSaldo " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString

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
    Public Function PonerSaldosEnCero() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "update ArticuloBodega set Saldo = 0, Comprometido = 0, Transito = 0" &
                " where Emp_Id = " & _Emp_Id.ToString() &
                " And Suc_Id = " & _Suc_Id.ToString() &
                " And Bod_Id = " & _Bod_Id.ToString()

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
    Public Function ListKey1() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From ArticuloBodega" &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And     Art_Id='" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Saldo = Tabla.Rows(0).Item("Saldo")
                _Comprometido = Tabla.Rows(0).Item("Comprometido")
                _CostoPromedio = Tabla.Rows(0).Item("CostoPromedio")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Margen = Tabla.Rows(0).Item("Margen")
                _MargenMayorista = Tabla.Rows(0).Item("MargenMayorista")
                _Margen3 = Tabla.Rows(0).Item("Margen3")
                _Margen4 = Tabla.Rows(0).Item("Margen4")
                _Margen5 = Tabla.Rows(0).Item("Margen5")
                _Precio = Tabla.Rows(0).Item("Precio")
                _PrecioMayorista = Tabla.Rows(0).Item("PrecioMayorista")
                _Precio3 = Tabla.Rows(0).Item("Precio3")
                _Precio4 = Tabla.Rows(0).Item("Precio4")
                _Precio5 = Tabla.Rows(0).Item("Precio5")
                _FechaIniDescuento = Tabla.Rows(0).Item("FechaIniDescuento")
                _FechaFinDescuento = Tabla.Rows(0).Item("FechaFinDescuento")
                _PorcDescuento = Tabla.Rows(0).Item("PorcDescuento")
                _FechaUltimaVenta = Tabla.Rows(0).Item("FechaUltimaVenta")
                _PromedioVenta = Tabla.Rows(0).Item("PromedioVenta")
                _Minimo = Tabla.Rows(0).Item("Minimo")
                _Maximo = Tabla.Rows(0).Item("Maximo")
                _Activo = Tabla.Rows(0).Item("Activo")
                _Ubicacion = Tabla.Rows(0).Item("Ubicacion")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function


    Public Function RptInventarioReposicion(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptInventarioReposicion " & _Emp_Id.ToString() & "," & _Suc_Id.ToString & "," & _Bod_Id.ToString & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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

    Public Function ListBusquedaArticuloCompuestoInventario(pNombre As String, pSaldo As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            'Query = "select b.Art_Id as Codigo, b.Nombre, round(a.Saldo,4) as Saldo, round(a.Transito,4) as Transito, round(a.Precio,2) as Precio, b.Suelto From ArticuloBodega a, Articulo b " & _
            '    "where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id and a.Activo = 1 and b.Activo = 1 " & _
            '    "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.Bod_Id = " & _Bod_Id.ToString & _
            '    "and b.Nombre like '%" & pNombre & "%'"

            Query = "select b.Art_Id as Codigo, b.Nombre, round(a.Saldo,4) as Saldo, round(a.Precio,2) as Precio, round(a.PrecioMayorista,2) as Mayorista, round(a.Precio3,2) as Precio3, round(a.Precio4,2) as Precio4, round(a.Precio5,2) as Precio5, round(a.Costo,2) as Costo From ArticuloBodega a, Articulo b " &
            "where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id and a.Activo = 1 and b.Activo = 1 " &
            "and a.Emp_Id = " & _Emp_Id.ToString & " and a.Suc_Id = " & _Suc_Id.ToString & " and a.Bod_Id = " & _Bod_Id.ToString &
            "and b.Nombre like '%" & pNombre & "%' and b.Compuesto = 1"

            If pSaldo = 1 Then
                Query = Query & " and b.SaldoPropio = 1 order by Nombre asc"
            ElseIf pSaldo = 2 Then
                Query = Query & " and b.SaldoPropio = 0 order by Nombre asc"
            Else
                Query = Query & " order by Nombre asc"
            End If


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
    Public Function RptSaldosXCategoria(pCat_Id As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptSaldosxCategoria " & _Emp_Id.ToString() & "," & pCat_Id

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
    Public Function RptSaldosXDepartamento(pDepartamento As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptSaldosxDepartamento " & _Emp_Id.ToString() & "," & pDepartamento

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

    Public Function VerificaArticuloApartado() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "update ArticuloBodega set Saldo = 0, Comprometido = 0, Transito = 0" &
                " where Emp_Id = " & _Emp_Id.ToString() &
                " And Suc_Id = " & _Suc_Id.ToString() &
                " And Bod_Id = " & _Bod_Id.ToString()

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


    Public Function VerificaArticuloApartado(pCantdad) As String
        Dim Query As String = ""
        Try
            Cn.Open()


            Query = "exec VerificaArticuloApartado " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() & ",'" & _Art_Id & "'," & pCantdad

            Cn.Ejecutar(Query)


            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function AddrticuloCambioPrecio(pPrecioAnterior As Double, pPrecioNuevo As Double, Art_Id As String)
        Dim Query As String = ""
        Try
            Cn.Open()
            Query = "exec [AddOrEditArticuloCambioPrecio] " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & ",'" & Art_Id & "'," & pPrecioAnterior & "," & pPrecioNuevo
            Cn.Ejecutar(Query)
            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function



    Public Function VerificaExistenciaArticuloVenta(pDocumento As Long, pArt_Id As String, pCantidad As Double) As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Query = "exec VerificaExistenciaArticuloVenta " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & pDocumento.ToString() & ",'" & _Art_Id & "'," & pCantidad

            Cn.Ejecutar(Query)

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try

    End Function

    Public Function TieneSaldo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ConsultaExistencia " & _Emp_Id.ToString() & ",'" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Cn.RowsAffected = 0 Then
                VerificaMensaje("No se encontró información del artículo")
            End If

            For Each Fila As DataRow In Tabla.Rows
                If Fila("Saldo") <> 0 Then
                    VerificaMensaje("El articulo tiene un saldo distinto de 0 en la bodega " & Fila("NombreBodega").ToString.Trim)
                End If
            Next


            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

#End Region
End Class