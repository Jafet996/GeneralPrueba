Public Class TInfoAticuloCompra
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Bod_Id As Integer
    Private _Art_Id As String
    Private _NombreArticulo As String
    Private _FactorConversion As Integer
    Private _ExentoIV As Integer
    Private _Suelto As Integer
    Private _Servicio As Integer
    Private _ArtPadre As String
    Private _Activo As Integer
    Private _Saldo As Double
    Private _Transito As Double
    Private _Costo As Double
    Private _Margen As Double
    Private _Precio As Double
    Private _NombreUnidad As String
    Private _FechaUltimaVenta As Datetime
    Private _PromedioVenta As Double
    Private _Minimo As Double
    Private _Maximo As Double
    Private _Compuesto As Integer
    Private _SaldoPropio As Integer
    Private _Lote As Integer
    Private _SolicitaCantidad As Integer
    Private _ArticuloImpuestos As New List(Of TInfoArticuloImpuesto)
    Private _Data As DataSet

#End Region
#Region "Definicion de propiedades"
    Public Property SolicitaCantidad() As Integer
        Get
            Return _SolicitaCantidad
        End Get
        Set(ByVal value As Integer)
            _SolicitaCantidad = value
        End Set
    End Property
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
    Public Property NombreArticulo() As String
        Get
            Return _NombreArticulo
        End Get
        Set(ByVal Value As String)
            _NombreArticulo = Value
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
    Public Property Lote As Integer
        Get
            Return _Lote
        End Get
        Set(value As Integer)
            _Lote = value
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
    Public Property Transito As Double
        Get
            Return _Transito
        End Get
        Set(value As Double)
            _Transito = value
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
    Public Property NombreUnidad() As String
        Get
            Return _NombreUnidad
        End Get
        Set(ByVal Value As String)
            _NombreUnidad = Value
        End Set
    End Property
    Public Property FechaUltimaVenta() As Datetime
        Get
            Return _FechaUltimaVenta
        End Get
        Set(ByVal Value As Datetime)
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
    Public Property Compuesto() As Integer
        Get
            Return _Compuesto
        End Get
        Set(ByVal value As Integer)
            _Compuesto = value
        End Set
    End Property
    Public Property SaldoPropio As Integer
        Get
            Return _SaldoPropio
        End Get
        Set(value As Integer)
            _SaldoPropio = value
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
    Public Property ArticuloImpuestos As List(Of TInfoArticuloImpuesto)
        Get
            Return _ArticuloImpuestos
        End Get
        Set(value As List(Of TInfoArticuloImpuesto))
            _ArticuloImpuestos = value
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
        _NombreArticulo = ""
        _FactorConversion = 0
        _ExentoIV = 0
        _Suelto = 0
        _Servicio = 0
        _ArtPadre = ""
        _Activo = 0
        _Saldo = 0.0
        _Transito = 0.0
        _Costo = 0.0
        _Margen = 0.0
        _Precio = 0.0
        _NombreUnidad = ""
        _FechaUltimaVenta = CDate("1900/01/01")
        _PromedioVenta = 0.0
        _Minimo = 0.0
        _Maximo = 0.0
        _SolicitaCantidad = 0
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Sub LimpiaArticulo()
        _Art_Id = ""
        _NombreArticulo = ""
        _FactorConversion = 0
        _ExentoIV = 0
        _Suelto = 0
        _Servicio = 0
        _ArtPadre = ""
        _Activo = 0
        _Saldo = 0.0
        _Transito = 0.0
        _Costo = 0.0
        _Margen = 0.0
        _Precio = 0.0
        _NombreUnidad = ""
        _FechaUltimaVenta = CDate("1900/01/01")
        _PromedioVenta = 0.0
        _Minimo = 0.0
        _Maximo = 0.0
        _Compuesto = 0
        _SaldoPropio = 0
        _SolicitaCantidad = 0
        _ArticuloImpuestos.Clear()
    End Sub

    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = ""

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

            Query = ""

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

            Query = """"

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

            Query = "select * From InfoAticuloCompra" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    Bod_Id=" & _Bod_Id.ToString() & _
           " And     Art_Id='" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _NombreArticulo = Tabla.Rows(0).Item("NombreArticulo")
                _FactorConversion = Tabla.Rows(0).Item("FactorConversion")
                _ExentoIV = Tabla.Rows(0).Item("ExentoIV")
                _Suelto = Tabla.Rows(0).Item("Suelto")

                _Servicio = Tabla.Rows(0).Item("Servicio")

                _ArtPadre = Tabla.Rows(0).Item("ArtPadre")
                _Activo = Tabla.Rows(0).Item("Activo")
                _Saldo = Tabla.Rows(0).Item("Saldo")
                _Transito = Tabla.Rows(0).Item("Transito")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Margen = Tabla.Rows(0).Item("Margen")
                _Precio = Tabla.Rows(0).Item("Precio")
                _NombreUnidad = Tabla.Rows(0).Item("NombreUnidad")
                _FechaUltimaVenta = Tabla.Rows(0).Item("FechaUltimaVenta")
                _PromedioVenta = Tabla.Rows(0).Item("PromedioVenta")
                _Minimo = Tabla.Rows(0).Item("Minimo")
                _Maximo = Tabla.Rows(0).Item("Maximo")
                _Compuesto = Tabla.Rows(0).Item("Maximo")
                _SaldoPropio = Tabla.Rows(0).Item("SaldoPropio")
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

            Query = "select * From InfoAticuloCompra"

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

            Query = "select InfoAticuloCompra_Id as Numero, Nombre From InfoAticuloCompra"

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

    Public Function ConsultaArticulo() As String
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

            Query = "exec ConsultaArticuloCompra " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() & ",'" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _NombreArticulo = Tabla.Rows(0).Item("NombreArticulo")
                _FactorConversion = Tabla.Rows(0).Item("FactorConversion")
                _ExentoIV = Tabla.Rows(0).Item("ExentoIV")
                _Suelto = Tabla.Rows(0).Item("Suelto")
                _Lote = Tabla.Rows(0).Item("Lote")
                _Servicio = Tabla.Rows(0).Item("Servicio")

                _ArtPadre = Tabla.Rows(0).Item("ArtPadre")
                _Activo = Tabla.Rows(0).Item("Activo")
                _Saldo = Tabla.Rows(0).Item("Saldo")
                _Transito = Tabla.Rows(0).Item("Transito")
                _Costo = Tabla.Rows(0).Item("Costo")
                _Margen = Tabla.Rows(0).Item("Margen")
                _Precio = Tabla.Rows(0).Item("Precio")
                _NombreUnidad = Tabla.Rows(0).Item("NombreUnidad")
                _FechaUltimaVenta = Tabla.Rows(0).Item("FechaUltimaVenta")
                _PromedioVenta = Tabla.Rows(0).Item("PromedioVenta")
                _Minimo = Tabla.Rows(0).Item("Minimo")
                _Maximo = Tabla.Rows(0).Item("Maximo")
                _SolicitaCantidad = Tabla.Rows(0).Item("SolicitaCantidad")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    'Public Function ConsultaArticuloImpuestosOC() As String
    '    Dim Query As String
    '    Dim TablaImpuesto As DataTable = Nothing
    '    Dim ArticuloImpuesto As TInfoArticuloImpuesto = Nothing
    '    Try
    '        Cn.Open()


    '        _ArticuloImpuestos.Clear()

    '        If _Art_Id.Trim() <> String.Empty Then


    '            Query = "exec ConsultaArticuloImpuesto " & _Emp_Id.ToString & ",'" & _Art_Id & "'"

    '            TablaImpuesto = Cn.Seleccionar(Query).Copy

    '            If Not TablaImpuesto Is Nothing AndAlso TablaImpuesto.Rows.Count > 0 Then
    '                For Each fila As DataRow In TablaImpuesto.Rows
    '                    ArticuloImpuesto = New TInfoArticuloImpuesto()
    '                    With ArticuloImpuesto
    '                        .Codigo_Id = fila("Codigo_Id")
    '                        .Tarifa_Id = fila("Tarifa_Id")
    '                        .Porcentaje = fila("Porcentaje")
    '                    End With
    '                    _ArticuloImpuestos.Add(ArticuloImpuesto)
    '                Next
    '            End If

    '        End If
    '        Return ""

    '    Catch ex As Exception
    '        Return ex.Message
    '    Finally
    '        Cn.Close()
    '    End Try
    'End Function
#End Region

End Class
