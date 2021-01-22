Public Class TCliente
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"
    Private _Emp_Id As Integer
    Private _Cliente_Id As Integer
    Private _TipoIdentificacion_Id As Integer
    Private _Identificacion As String
    Private _Nombre As String
    Private _NombreComercial As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _Email As String
    Private _Direccion As String
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Saldo As Double
    Private _DiasCredito As Integer
    Private _PorcMora As Double
    Private _DiasGraciaMora As Integer
    Private _AplicaMora As Integer
    Private _LimiteCredito As Double
    Private _CxC_Colones As String
    Private _CxC_Dolares As String
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _Vendedor_Id As Integer
    Private _EsInterno As Boolean
    Private _Data As DataSet
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
    Public Property Cliente_Id() As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal Value As Integer)
            _Cliente_Id = Value
        End Set
    End Property
    Public Property TipoIdentificacion_Id() As Integer
        Get
            Return _TipoIdentificacion_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoIdentificacion_Id = Value
        End Set
    End Property
    Public Property Identificacion() As String
        Get
            Return _Identificacion
        End Get
        Set(ByVal Value As String)
            _Identificacion = Value
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
    Public Property NombreComercial() As String
        Get
            Return _NombreComercial
        End Get
        Set(ByVal value As String)
            _NombreComercial = value
        End Set
    End Property
    Public Property Telefono1() As String
        Get
            Return _Telefono1
        End Get
        Set(ByVal Value As String)
            _Telefono1 = Value
        End Set
    End Property
    Public Property Telefono2() As String
        Get
            Return _Telefono2
        End Get
        Set(ByVal Value As String)
            _Telefono2 = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal Value As String)
            _Email = Value
        End Set
    End Property
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal Value As String)
            _Direccion = Value
        End Set
    End Property
    Public Property Debitos() As Double
        Get
            Return _Debitos
        End Get
        Set(ByVal Value As Double)
            _Debitos = Value
        End Set
    End Property
    Public Property Creditos() As Double
        Get
            Return _Creditos
        End Get
        Set(ByVal Value As Double)
            _Creditos = Value
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
    Public Property DiasCredito() As Integer
        Get
            Return _DiasCredito
        End Get
        Set(ByVal Value As Integer)
            _DiasCredito = Value
        End Set
    End Property
    Public Property PorcMora() As Double
        Get
            Return _PorcMora
        End Get
        Set(ByVal Value As Double)
            _PorcMora = Value
        End Set
    End Property
    Public Property DiasGraciaMora() As Integer
        Get
            Return _DiasGraciaMora
        End Get
        Set(ByVal Value As Integer)
            _DiasGraciaMora = Value
        End Set
    End Property
    Public Property AplicaMora() As Integer
        Get
            Return _AplicaMora
        End Get
        Set(ByVal Value As Integer)
            _AplicaMora = Value
        End Set
    End Property
    Public Property LimiteCredito() As Double
        Get
            Return _LimiteCredito
        End Get
        Set(ByVal Value As Double)
            _LimiteCredito = Value
        End Set
    End Property
    Public Property CxC_Colones() As String
        Get
            Return _CxC_Colones
        End Get
        Set(ByVal Value As String)
            _CxC_Colones = Value
        End Set
    End Property
    Public Property CxC_Dolares() As String
        Get
            Return _CxC_Dolares
        End Get
        Set(ByVal Value As String)
            _CxC_Dolares = Value
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
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
        End Set
    End Property

    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get

        Set(ByVal value As Integer)
            _Vendedor_Id = value
        End Set
    End Property

    Public Property EsInterno() As Boolean
        Get
            Return _EsInterno
        End Get

        Set(ByVal value As Boolean)
            _EsInterno = value
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
        _Cliente_Id = 0
        _Nombre = ""
        _NombreComercial = ""
        _TipoIdentificacion_Id = 0
        _Identificacion = ""
        _Telefono1 = ""
        _Telefono2 = ""
        _Email = ""
        _Direccion = ""
        _Debitos = 0.0
        _Creditos = 0.0
        _Saldo = 0.0
        _DiasCredito = 0
        _PorcMora = 0.0
        _DiasGraciaMora = 0
        _AplicaMora = 0
        _LimiteCredito = 0.0
        _CxC_Colones = ""
        _CxC_Dolares = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Vendedor_Id = 1
        _EsInterno = False
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Cliente( Emp_Id , Cliente_Id" &
                    " , TipoIdentificacion_Id , Identificacion" &
                    " , Nombre , NombreComercial , Telefono1" &
                    " , Telefono2 , Email" &
                    " , Direccion , Debitos" &
                    " , Creditos , Saldo" &
                    " , DiasCredito , PorcMora" &
                    " , DiasGraciaMora , AplicaMora" &
                    " , LimiteCredito , CxC_Colones" &
                    " , CxC_Dolares , Activo" &
                    " , UltimaModificacion, Vendedor_Id, EsInterno)" &
                    " Values ( " & _Emp_Id.ToString & "," & _Cliente_Id.ToString &
                    "," & _TipoIdentificacion_Id.ToString & ",'" & _Identificacion & "'" &
                    ",'" & _Nombre & "'" & ",'" & _NombreComercial & "'" & ",'" & _Telefono1 & "'" &
                    ",'" & _Telefono2 & "'" & ",'" & _Email & "'" &
                    ",'" & _Direccion & "'" & "," & _Debitos.ToString &
                    "," & _Creditos.ToString & "," & _Saldo.ToString &
                    "," & _DiasCredito.ToString & "," & _PorcMora.ToString &
                    "," & _DiasGraciaMora.ToString & "," & _AplicaMora.ToString &
                    "," & _LimiteCredito.ToString & ",'" & _CxC_Colones & "'" &
                    ",'" & _CxC_Dolares & "'" & "," & _Activo.ToString &
                    ",GETDATE() " & ", " & _Vendedor_Id & "," & If(_EsInterno, 1, 0) & ")"

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

            Query = "Delete Cliente" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Cliente_Id = " & _Cliente_Id.ToString

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

            Query = " Update Cliente " &
                    " SET    TipoIdentificacion_Id = " & _TipoIdentificacion_Id.ToString & "," &
                    " Identificacion = '" & _Identificacion & "'" & "," &
                    " Nombre = '" & _Nombre & "'" & "," &
                    " NombreComercial = '" & _NombreComercial & "'" & "," &
                    " Telefono1 = '" & _Telefono1 & "'" & "," &
                    " Telefono2 = '" & _Telefono2 & "'" & "," &
                    " Email = '" & _Email & "'" & "," &
                    " Direccion = '" & _Direccion & "'" & "," &
                    " DiasCredito = " & _DiasCredito & "," &
                    " PorcMora = " & _PorcMora & "," &
                    " DiasGraciaMora = " & _DiasGraciaMora & "," &
                    " AplicaMora = " & _AplicaMora & "," &
                    " LimiteCredito = " & _LimiteCredito & "," &
                    " CxC_Colones = '" & _CxC_Colones & "'" & "," &
                    " CxC_Dolares = '" & _CxC_Dolares & "'" & "," &
                    " Activo = " & _Activo & "," &
                    " UltimaModificacion = GETDATE() , " &
                    " Vendedor_Id = " & _Vendedor_Id & ", " &
                    " EsInterno = " & If(_EsInterno, 1, 0) &
                    " Where Emp_Id = " & _Emp_Id.ToString &
                    " And   Cliente_Id = " & _Cliente_Id.ToString

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

            Query = "select * From Cliente" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Cliente_Id = " & _Cliente_Id.ToString

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

            Query = "select * From Cliente"

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
    Public Overrides Function LoadComboBox() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select Cliente_Id as Numero, Nombre From Cliente"

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
    Public Overrides Function ListMant(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select Cliente_Id as Codigo, Nombre From Cliente" & _
                    " where Emp_Id = " & _Emp_Id.ToString

            If pNombre.Trim <> "" Then
                Query += " and Nombre Like '%" & pNombre & "%'"
            End If

            Query += " order by Nombre"

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
    Public Overrides Function NextOne() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select IsNull(MAX(Cliente_Id),0) + 1 as Cliente_Id From Cliente" &
                    " Where Emp_Id = " & _Emp_Id.ToString

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

    Public Function FacturasAtrasadas() As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim TablaConsulta As DataTable

        Try
            Cn.Open()

            Query = " select iif(a.FechaVencimiento < GETDATE(), 1, 0)" &
                    " from CxCMovimiento a " &
                    " where Emp_Id = " & Emp_Id &
                    " and Cliente_Id =" & Cliente_Id &
                    " and Saldo > 0"

            TablaConsulta = Cn.Seleccionar(Query).Copy
            Tabla = New DataTable()
            Tabla.Columns.Add("FacturasMorosas")
            Dim row As DataRow = Tabla.NewRow()
            row.Item(0) = 0

            For Each item As DataRow In TablaConsulta.Rows

                If item.ItemArray(0) = 1 Then
                    row.Item(0) = 1
                    Exit For
                End If
            Next

            Tabla.Rows.Add(row)

            _Data.Tables.Clear()
            _Data.Tables.Add(Tabla)

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function Movimientos(ByVal pDesde As Date, ByVal pHasta As Date) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select  a.Emp_Id " &
                           ",1 as Suc_Id " &
                           ",1 as Caja " &
                           ",a.Tipo_Id as TipoDoc_Id " &
                           ",a.Batch_Id as Documento_Id " &
                           ",'' as SucNombre " &
                           ", CASE  " &
                               "WHEN b.Tipo_Id = 1 THEN 'Factura Credito' " &
                               "ELSE b.Nombre " &
                             "END as TipoDocNombre " &
                           ",a.Referencia as Documento " &
                           ",a.Fecha  " &
                           ",a.Monto as TotalCobrado  " &
                           ",'' as Comentario " &
                           ", 1 as Tipo " &
                           ", 0 as Punto " &
                    "from CxCMovimiento a " &
                    "inner join CxCMovimientoTipo b on b.Emp_Id = a.Emp_Id and a.Tipo_Id = b.Tipo_Id " &
                    " Where a.Emp_Id = " & _Emp_Id.ToString &
                    " And   a.Cliente_Id = " & _Cliente_Id.ToString &
                    " And   a.Fecha >= '" & pDesde.ToString("yyyyMMdd") & "'" &
                    " And   a.Fecha < '" & pHasta.ToString("yyyyMMdd") & "'"
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

#End Region
End Class