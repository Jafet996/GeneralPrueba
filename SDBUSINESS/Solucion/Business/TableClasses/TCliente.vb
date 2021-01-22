Public Class TCliente
    Inherits TBaseClassManager
#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Cliente_Id As Integer
    Private _Nombre As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _TipoIdentificacion_Id As Integer
    Private _Cedula As String
    Private _Email As String
    Private _CorreoCotizaciones As String
    Private _Direccion As String
    Private _Apartado As String
    Private _PorcDescContado As Double
    Private _PorcDescCredito As Double
    Private _LimiteCredito As Double
    Private _Saldo As Double
    Private _FacturaCredito As Integer
    Private _DiasCredito As Integer
    Private _PorcMora As Double
    Private _DiasGraciaMora As Integer
    Private _AplicaMora As Integer
    Private _Precio_Id As Integer
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _PrecioNombre As String
    Private _AcumulaPuntos As Integer
    Private _PuntosAcumulados As Integer
    Private _PuntosCanjeados As Integer
    Private _PuntosVencidos As Integer
    Private _FechaUltimaCompra As DateTime
    Private _CxC_Colones As String
    Private _CxC_Dolares As String
    Private _ClienteExterno As String
    Private _Provincia_Id As Integer
    Private _Canton_Id As Integer
    Private _Distrito_Id As Integer
    Private _Barrio_Id As Integer
    Private _Data As DataSet
    Private _Contactos As New List(Of String)
    Private _Referencia As String
    Private _Anotaciones As String
    Private _TipoDoc As String
    Private _NombreComercial As String
    Private _Vendedor_Id As Integer
    Private _Adjunto_Id As Integer
    Private _SDL As New SDFinancial.SDFinancial

#End Region
#Region "Definicion de propiedades"

    Public Property NombreComercial() As String
        Get
            Return _NombreComercial
        End Get
        Set(ByVal value As String)
            _NombreComercial = value
        End Set
    End Property

    Public Property Vendedor_id() As Int16
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal value As Int16)
            _Vendedor_Id = value
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
    Public Property Cliente_Id() As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal Value As Integer)
            _Cliente_Id = Value
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
    Public Property TipoIdentificacion_Id() As Integer
        Get
            Return _TipoIdentificacion_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoIdentificacion_Id = Value
        End Set
    End Property
    Public Property Cedula() As String
        Get
            Return _Cedula
        End Get
        Set(ByVal Value As String)
            _Cedula = Value
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

    Public Property CorreoCotizaciones() As String
        Get
            Return _CorreoCotizaciones
        End Get
        Set(ByVal value As String)
            _CorreoCotizaciones = value
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
    Public Property Apartado() As String
        Get
            Return _Apartado
        End Get
        Set(ByVal Value As String)
            _Apartado = Value
        End Set
    End Property
    Public Property PorcDescContado() As Double
        Get
            Return _PorcDescContado
        End Get
        Set(ByVal Value As Double)
            _PorcDescContado = Value
        End Set
    End Property
    Public Property PorcDescCredito() As Double
        Get
            Return _PorcDescCredito
        End Get
        Set(ByVal Value As Double)
            _PorcDescCredito = Value
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
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property
    Public Property FacturaCredito() As Integer
        Get
            Return _FacturaCredito
        End Get
        Set(ByVal Value As Integer)
            _FacturaCredito = Value
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
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
        End Set
    End Property

    Public Property Precio_Id() As Integer
        Get
            Return _Precio_Id
        End Get
        Set(ByVal Value As Integer)
            _Precio_Id = Value
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

    Public Property AcumulaPuntos() As Integer
        Get
            Return _AcumulaPuntos
        End Get
        Set(ByVal Value As Integer)
            _AcumulaPuntos = Value
        End Set
    End Property
    Public Property PuntosAcumulados() As Integer
        Get
            Return _PuntosAcumulados
        End Get
        Set(ByVal Value As Integer)
            _PuntosAcumulados = Value
        End Set
    End Property
    Public Property PuntosCanjeados() As Integer
        Get
            Return _PuntosCanjeados
        End Get
        Set(ByVal Value As Integer)
            _PuntosCanjeados = Value
        End Set
    End Property
    Public Property PuntosVencidos() As Integer
        Get
            Return _PuntosVencidos
        End Get
        Set(ByVal Value As Integer)
            _PuntosVencidos = Value
        End Set
    End Property

    Public Property PrecioNombre As String
        Get
            Return _PrecioNombre
        End Get
        Set(value As String)
            _PrecioNombre = value
        End Set
    End Property
    Public Property FechaUltimaCompra() As DateTime
        Get
            Return _FechaUltimaCompra
        End Get
        Set(ByVal Value As DateTime)
            _FechaUltimaCompra = Value
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
    Public Property ClienteExterno() As String
        Get
            Return _ClienteExterno
        End Get
        Set(ByVal Value As String)
            _ClienteExterno = Value
        End Set
    End Property
    Public Property Provincia_Id() As Integer
        Get
            Return _Provincia_Id
        End Get
        Set(ByVal Value As Integer)
            _Provincia_Id = Value
        End Set
    End Property
    Public Property Canton_Id() As Integer
        Get
            Return _Canton_Id
        End Get
        Set(ByVal Value As Integer)
            _Canton_Id = Value
        End Set
    End Property
    Public Property Distrito_Id() As Integer
        Get
            Return _Distrito_Id
        End Get
        Set(ByVal Value As Integer)
            _Distrito_Id = Value
        End Set
    End Property
    Public Property Barrio_Id() As Integer
        Get
            Return _Barrio_Id
        End Get
        Set(ByVal Value As Integer)
            _Barrio_Id = Value
        End Set
    End Property
    Public Property TipoDoc() As String
        Get
            Return _TipoDoc
        End Get
        Set(ByVal Value As String)
            _TipoDoc = Value
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
    Public Property Contactos As List(Of String)
        Get
            Return _Contactos
        End Get
        Set(value As List(Of String))
            _Contactos = value
        End Set
    End Property
    Public Property Referencia() As String
        Get
            Return _Referencia
        End Get
        Set(ByVal Value As String)
            _Referencia = Value
        End Set

    End Property
    Public Property Anotaciones() As String
        Get
            Return _Anotaciones
        End Get
        Set(ByVal Value As String)
            _Anotaciones = Value
        End Set
    End Property
    Public Property Adjunto_Id() As Integer
        Get
            Return _Adjunto_Id
        End Get
        Set(ByVal Value As Integer)
            _Adjunto_Id = Value
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
        _SDL.Url = InfoMaquina.URLContabilidad
        _Emp_Id = 0
        _Cliente_Id = 0
        _Nombre = ""
        _Telefono1 = ""
        _Telefono2 = ""
        _TipoIdentificacion_Id = 0
        _Cedula = ""
        _Email = ""
        _CorreoCotizaciones = ""
        _Direccion = ""
        _Apartado = ""
        _PorcDescContado = 0.0
        _PorcDescCredito = 0.0
        _LimiteCredito = 0.0
        _Saldo = 0.0
        _FacturaCredito = 0
        _DiasCredito = 0
        _PorcMora = 0.0
        _DiasGraciaMora = 0
        _AplicaMora = 0
        _Activo = 0
        _Precio_Id = 0
        _UltimaModificacion = CDate("1900/01/01")
        _PrecioNombre = ""
        _AcumulaPuntos = 0
        _PuntosAcumulados = 0
        _PuntosCanjeados = 0
        _PuntosVencidos = 0
        _FechaUltimaCompra = CDate("1900/01/01")
        _CxC_Colones = ""
        _CxC_Dolares = ""
        _ClienteExterno = ""
        _Provincia_Id = 0
        _Canton_Id = 0
        _Distrito_Id = 0
        _Barrio_Id = 0
        _Data = New DataSet
        _Referencia = ""
        _Anotaciones = ""
        _TipoDoc = ""
        _Adjunto_Id = 0
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select isnull(max(Cliente_Id),0) + 1 From Cliente Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Cliente_Id = Tabla.Rows(0).Item(0)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Private Function InsertClienteCxC() As String
        Dim Query As String = String.Empty
        Try

            Query = "Insert into [" & EmpresaParametroInfo.FinancialDB & "]..Cliente( Emp_Id , Cliente_Id" &
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
                    "," & _TipoIdentificacion_Id.ToString & ",'" & _Cedula & "'" &
                    ",'" & _Nombre & "'" & ",'" & _NombreComercial & "'" & ",'" & _Telefono1 & "'" &
                    ",'" & _Telefono2 & "'" & ",'" & _Email & "'" &
                    ",'" & _Direccion & "'" & ",0" &
                    ",0" & "," & _Saldo.ToString &
                    "," & _DiasCredito.ToString & "," & _PorcMora.ToString &
                    "," & _DiasGraciaMora.ToString & "," & _AplicaMora.ToString &
                    "," & _LimiteCredito.ToString & ",'" & _CxC_Colones & "'" &
                    ",'" & _CxC_Dolares & "'" & "," & _Activo.ToString &
                    ",GETDATE() " & ", " & _Vendedor_Id & ",0)"


            Cn.Ejecutar(Query)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Dim cont As Integer = 1
        Dim SDFResultado As New SDFinancial.TResultado()
        Dim Mensaje As String = String.Empty
        Try
            Cn.Open()

            Cn.BeginTransaction()

            'Ini --> Creación de cliene en CxC
            If EmpresaParametroInfo.InterfazCxC Then
                VerificaMensaje(InsertClienteCxC)
            End If
            'Fin --> Creación de cliene en CxC

            _Saldo = 0

            Query = " Insert into Cliente( Emp_Id , Cliente_Id" &
                    " , Nombre , NombreComercial , Telefono1" &
                    " , Telefono2 , TipoIdentificacion_Id, Cedula, Email, CorreoCotizaciones" &
                    " , Direccion , Apartado" &
                    " , PorcDescContado , PorcDescCredito" &
                    " , LimiteCredito , Saldo" &
                    " , FacturaCredito , DiasCredito" &
                    " , PorcMora , DiasGraciaMora" &
                    " , AplicaMora , Activo" &
                    " , Precio_Id , UltimaModificacion , AcumulaPuntos" &
                    " , CxC_Colones , CxC_Dolares, ClienteExterno" &
                    " , Provincia_Id , Canton_Id" &
                    " , Distrito_Id , Barrio_Id, Referencia" &
                    " , Anotaciones, TipoDoc, Vendedor_Id" &
                    " , Adjunto_Id)" &
                    " Values ( " & _Emp_Id.ToString() & "," & _Cliente_Id.ToString() & ",'" & _Nombre &
                    "','" & _NombreComercial.ToString() & "'" & ",'" & _Telefono1 & "'" &
                    ",'" & _Telefono2 & "'" & "," & _TipoIdentificacion_Id.ToString() &
                    ",'" & _Cedula & "'" & ",'" & _Email & "'" & ",'" & _CorreoCotizaciones & "'" &
                    ",'" & _Direccion & "'" & ",'" & _Apartado & "'" &
                    "," & _PorcDescContado.ToString() & "," & _PorcDescCredito.ToString() &
                    "," & _LimiteCredito.ToString() & "," & _Saldo.ToString() &
                    "," & _FacturaCredito.ToString() & "," & _DiasCredito.ToString() &
                    "," & _PorcMora.ToString() & "," & _DiasGraciaMora.ToString() &
                    "," & _AplicaMora.ToString() & "," & _Activo.ToString() &
                    "," & _Precio_Id & ",GETDATE()," & _AcumulaPuntos.ToString() &
                    ",'" & _CxC_Colones & "','" & _CxC_Dolares & "','" & _Cliente_Id.ToString() & "'" &
                    "," & _Provincia_Id.ToString() & "," & _Canton_Id.ToString() &
                    "," & _Distrito_Id.ToString() & "," & _Barrio_Id.ToString() &
                    ",'" & _Referencia & "','" & _Anotaciones & "','" & _TipoDoc &
                    "'," & _Vendedor_Id.ToString() & "," & _Adjunto_Id.ToString() & ")"

            Cn.Ejecutar(Query)

            For Each item In Contactos
                Query = "Insert into ClienteContacto(Emp_Id, Cliente_Id, Contacto_Id, Nombre) Values(" &
                        _Emp_Id.ToString() & "," & _Cliente_Id.ToString() & "," & cont.ToString() & ",'" & item.ToString() & "')"
                cont = cont + 1
                Cn.Ejecutar(Query)
            Next

            Cn.CommitTransaction()

            'Llamada a web service funciona perfctamente, se modifico para meter la creacion de cliente dentro de la misma transaccion
            'If EmpresaParametroInfo.InterfazCxC Then
            '    Dim _DTCliente As New SDFinancial.DTCliente()

            '    With _DTCliente
            '        .Activo = _Activo
            '        .AplicaMora = _AplicaMora
            '        .Cliente_Id = Cliente_Id
            '        .Creditos = 0
            '        .Debitos = 0
            '        .DiasCredito = _DiasCredito
            '        .DiasGraciaMora = _DiasGraciaMora
            '        .Direccion = _Direccion
            '        .Email = _Email
            '        .Emp_Id = _Emp_Id
            '        .Identificacion = _Cedula
            '        .LimiteCredito = _LimiteCredito
            '        .Nombre = _Nombre
            '        .NombreComercial = _NombreComercial
            '        .Saldo = _Saldo
            '        .PorcMora = _PorcMora
            '        .Telefono1 = _Telefono1
            '        .Telefono2 = Telefono2
            '        .TipoIdentificacion_Id = _TipoIdentificacion_Id
            '        .UltimaModificacion = _UltimaModificacion
            '        .Vendedor_Id = _Vendedor_Id
            '    End With

            '    SDFResultado = _SDL.ClienteMant(_DTCliente, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

            '    If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" OrElse SDFResultado.RowsAffected = 0 Then
            '        If Not SDFResultado Is Nothing Then
            '            Mensaje = SDFResultado.ErrorDescription
            '        End If

            '        VerificaMensaje("Se presentaron errores creando cliente en CXC : " & Mensaje)
            '    End If
            'End If


            Return ""
        Catch ex As Exception
            'If Cn.ActiveTansaction Then
            '    Cn.RollBackTransaction()
            'End If
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
            Query = "Delete ClienteContacto" &
                    " Where Emp_Id=" & _Emp_Id.ToString() &
                    " And   Cliente_Id=" & _Cliente_Id.ToString()

            Cn.Ejecutar(Query)

            Query = "Delete Cliente" &
                    " Where Emp_Id=" & _Emp_Id.ToString() &
                    " And   Cliente_Id=" & _Cliente_Id.ToString()

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
        Dim cont As Integer = 1
        Dim SDFResultado As New SDFinancial.TResultado
        Dim Mensaje As String = String.Empty
        Try
            Cn.Open()

            Cn.BeginTransaction()

            If EmpresaParametroInfo.InterfazCxC Then

                Query = " Update [" & EmpresaParametroInfo.FinancialDB & "]..Cliente " &
                        " SET    TipoIdentificacion_Id = " & _TipoIdentificacion_Id.ToString & "," &
                        " Identificacion = '" & _Cedula & "'" & "," &
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
                        " Vendedor_Id = " & _Vendedor_Id &
                        " Where Emp_Id = " & _Emp_Id.ToString &
                        " And   Cliente_Id = " & _Cliente_Id.ToString

                Cn.Ejecutar(Query)

                If Cn.RowsAffected = 0 Then
                    VerificaMensaje(InsertClienteCxC)
                End If

            End If

            Query = " Update dbo.Cliente " &
                    " SET   Nombre='" & _Nombre & "' " & "," &
                    " NombreComercial='" & _NombreComercial.ToString() & "'" & "," &
                    " Telefono1='" & _Telefono1 & "'" & "," &
                    " Telefono2='" & _Telefono2 & "'" & "," &
                    " TipoIdentificacion_Id=" & _TipoIdentificacion_Id & "," &
                    " Cedula='" & _Cedula & "'" & "," &
                    " Email='" & _Email & "'" & "," &
                    " CorreoCotizaciones='" & _CorreoCotizaciones & "'" & "," &
                    " Direccion='" & _Direccion & "'" & "," &
                    " Apartado='" & _Apartado & "'" & "," &
                    " PorcDescContado=" & _PorcDescContado & "," &
                    " PorcDescCredito=" & _PorcDescCredito & "," &
                    " LimiteCredito=" & _LimiteCredito & "," &
                    " FacturaCredito=" & _FacturaCredito & "," &
                    " DiasCredito=" & _DiasCredito & "," &
                    " PorcMora=" & _PorcMora & "," &
                    " DiasGraciaMora=" & _DiasGraciaMora & "," &
                    " AplicaMora=" & _AplicaMora & "," &
                    " Activo=" & _Activo & "," &
                    " Precio_Id=" & _Precio_Id & "," &
                    " UltimaModificacion=GETDATE()," &
                    " AcumulaPuntos=" & _AcumulaPuntos & "," &
                    " CxC_Colones='" & _CxC_Colones & "'" & "," &
                    " CxC_Dolares='" & _CxC_Dolares & "'," &
                    " ClienteExterno='" & _Cliente_Id & "'," &
                    " Provincia_Id=" & _Provincia_Id & "," &
                    " Canton_Id=" & _Canton_Id & "," &
                    " Distrito_Id=" & _Distrito_Id & "," &
                    " Barrio_Id=" & _Barrio_Id & "," &
                    " Referencia = '" & _Referencia & "'," &
                    " Anotaciones='" & _Anotaciones & "'" & "," &
                    " TipoDoc='" & _TipoDoc & "'," &
                    " Vendedor_Id='" & _Vendedor_Id & "'," &
                    " Adjunto_Id='" & _Adjunto_Id & "'" &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Cliente_Id=" & _Cliente_Id.ToString()

            Cn.Ejecutar(Query)
            Query = "Delete ClienteContacto where Emp_Id=" & _Emp_Id.ToString() & " AND Cliente_Id=" & _Cliente_Id.ToString()

            Cn.Ejecutar(Query)

            For Each item In _Contactos
                Query = "Insert into ClienteContacto(Emp_Id, Cliente_Id, Contacto_Id, Nombre) Values(" &
                        _Emp_Id.ToString() & "," & _Cliente_Id.ToString() & "," & cont.ToString() & ",'" & item.ToString() & "')"
                cont = cont + 1
                Cn.Ejecutar(Query)
            Next
            Cn.CommitTransaction()

            'If EmpresaParametroInfo.InterfazCxC Then
            '    Dim _DTCliente As New SDFinancial.DTCliente()

            '    With _DTCliente
            '        .Activo = _Activo
            '        .AplicaMora = _AplicaMora
            '        .Cliente_Id = Cliente_Id
            '        .Creditos = 0
            '        .Debitos = 0
            '        .DiasCredito = _DiasCredito
            '        .DiasGraciaMora = _DiasGraciaMora
            '        .Direccion = _Direccion
            '        .Email = _Email
            '        .Emp_Id = _Emp_Id
            '        .Identificacion = _Cedula
            '        .LimiteCredito = _LimiteCredito
            '        .Nombre = _Nombre
            '        .NombreComercial = _NombreComercial
            '        .PorcMora = _PorcMora
            '        .Saldo = _Saldo
            '        .Telefono1 = _Telefono1
            '        .Telefono2 = Telefono2
            '        .TipoIdentificacion_Id = _TipoIdentificacion_Id
            '        .UltimaModificacion = _UltimaModificacion
            '        .Vendedor_Id = _Vendedor_Id
            '    End With


            '    SDFResultado = _SDL.ClienteMant(_DTCliente, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

            '    If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" Then
            '        If Not SDFResultado Is Nothing Then
            '            Mensaje = SDFResultado.ErrorDescription
            '        End If

            '        VerificaMensaje("Se presentaron errores creando cliente en CXC : " & Mensaje)
            '    End If

            '    If SDFResultado.RowsAffected = 0 Then
            '        SDFResultado = _SDL.ClienteMant(_DTCliente, SDFinancial.EnumOperacionMant.Insertar, String.Empty)
            '        If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" OrElse SDFResultado.RowsAffected = 0 Then
            '            If Not SDFResultado Is Nothing Then
            '                Mensaje = SDFResultado.ErrorDescription
            '            End If

            '            VerificaMensaje("Se presentaron errores creando cliente en CXC : " & Mensaje)
            '        End If
            '    End If

            'End If


            Return ""
        Catch ex As Exception
            'If Cn.ActiveTansaction Then
            '    Cn.RollBackTransaction()
            'End If
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

            Query = "select a.*,b.Nombre as PrecioNombre From Cliente a, ClientePrecio b" &
                    " Where  a.Emp_Id = b.Emp_Id and a.Precio_Id = b.Precio_Id" &
                    " and    a.Emp_Id = " & _Emp_Id.ToString() &
                    " And    a.Cliente_Id=" & _Cliente_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Cliente_Id = Tabla.Rows(0).Item("Cliente_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _NombreComercial = Tabla.Rows(0).Item("NombreComercial")
                _Telefono1 = Tabla.Rows(0).Item("Telefono1")
                _Telefono2 = Tabla.Rows(0).Item("Telefono2")
                _TipoIdentificacion_Id = Tabla.Rows(0).Item("TipoIdentificacion_Id")
                _Cedula = Tabla.Rows(0).Item("Cedula")
                _Email = Tabla.Rows(0).Item("Email")
                _CorreoCotizaciones = Tabla.Rows(0).Item("CorreoCotizaciones")
                _Direccion = Tabla.Rows(0).Item("Direccion")
                _Apartado = Tabla.Rows(0).Item("Apartado")
                _PorcDescContado = Tabla.Rows(0).Item("PorcDescContado")
                _PorcDescCredito = Tabla.Rows(0).Item("PorcDescCredito")
                _LimiteCredito = Tabla.Rows(0).Item("LimiteCredito")
                _Saldo = Tabla.Rows(0).Item("Saldo")
                _FacturaCredito = Tabla.Rows(0).Item("FacturaCredito")
                _DiasCredito = Tabla.Rows(0).Item("DiasCredito")
                _PorcMora = Tabla.Rows(0).Item("PorcMora")
                _DiasGraciaMora = Tabla.Rows(0).Item("DiasGraciaMora")
                _AplicaMora = Tabla.Rows(0).Item("AplicaMora")
                _Activo = Tabla.Rows(0).Item("Activo")
                _Precio_Id = Tabla.Rows(0).Item("Precio_Id")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _PrecioNombre = Tabla.Rows(0).Item("PrecioNombre")
                _AcumulaPuntos = Tabla.Rows(0).Item("AcumulaPuntos")
                _PuntosAcumulados = Tabla.Rows(0).Item("PuntosAcumulados")
                _PuntosCanjeados = Tabla.Rows(0).Item("PuntosCanjeados")
                _PuntosVencidos = Tabla.Rows(0).Item("PuntosVencidos")
                _FechaUltimaCompra = Tabla.Rows(0).Item("FechaUltimaCompra")
                _CxC_Colones = Tabla.Rows(0).Item("CxC_Colones")
                _CxC_Dolares = Tabla.Rows(0).Item("CxC_Dolares")
                _ClienteExterno = Tabla.Rows(0).Item("ClienteExterno")
                _Provincia_Id = Tabla.Rows(0).Item("Provincia_Id")
                _Canton_Id = Tabla.Rows(0).Item("Canton_Id")
                _Distrito_Id = Tabla.Rows(0).Item("Distrito_Id")
                _Barrio_Id = Tabla.Rows(0).Item("Barrio_Id")
                _Referencia = IIf(IsDBNull(Tabla.Rows(0).Item("Referencia")), "", Tabla.Rows(0).Item("Referencia"))
                _Anotaciones = Tabla.Rows(0).Item("Anotaciones")
                _TipoDoc = Tabla.Rows(0).Item("TipoDoc")
                _Adjunto_Id = Tabla.Rows(0).Item("Adjunto_Id")
                _Vendedor_Id = Tabla.Rows(0).Item("Vendedor_Id")
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
    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Cliente_Id as Numero, Nombre From Cliente"

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
    Public Function ListaMantenimiento(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Cliente_Id as Codigo, Nombre From Cliente where Emp_Id = " & _Emp_Id.ToString()

            If pNombre.Trim <> "" Then
                Query = Query & " and Nombre Like '%" & pNombre & "%'"
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
    Public Function ListBusqueda(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = " select a.Cliente_Id as Codigo, a.Nombre, b.Nombre as TipoPrecio, a.Direccion  From Cliente a, ClientePrecio b" &
                " where a.Emp_Id = b.Emp_Id and a.Precio_Id = b.Precio_Id and a.Emp_Id = " & _Emp_Id.ToString & " and a.Nombre like '%" & pNombre & "%' and a.Activo = 1" &
                " order by a.Nombre asc"


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

    Public Function ListBusquedaApartado(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = " SELECT a.cliente_id AS Codigo, " &
                              " a.nombre," &
                              " a.direccion" &
                    " FROM   cliente a" &
                        " INNER JOIN ApartadoEncabezado b on a.Emp_Id = b.Emp_Id" &
                                                       " And a.Cliente_Id = b.Cliente_Id" &
                    " WHERE  a.emp_id = 1 " &
                       " AND a.nombre LIKE '%" & pNombre & "%'" &
                       " AND a.activo = 1" &
                       " AND b.Estado_Id <> " & Enum_ApartadoEstado.Abandonado


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


    Public Function ListBusquedaCliente(pNombre As String, pTipo As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = ""
            If pTipo = 2 Then
                Query = " select a.Cliente_Id as Codigo, a.Nombre, a.Cedula, b.Nombre as TipoPrecio, a.Direccion, a.Vendedor_Id  From Cliente a, ClientePrecio b" &
                " where a.Emp_Id = b.Emp_Id and a.Precio_Id = b.Precio_Id and a.Emp_Id = " & _Emp_Id.ToString & " and a.Cedula like '%" & pNombre & "%' and a.Activo = 1" &
                " order by a.Nombre asc"
            Else

                Query = " select a.Cliente_Id as Codigo, a.Nombre, a.Cedula, b.Nombre as TipoPrecio, a.Direccion, a.Vendedor_Id  From Cliente a, ClientePrecio b" &
                " where a.Emp_Id = b.Emp_Id and a.Precio_Id = b.Precio_Id and a.Emp_Id = " & _Emp_Id.ToString & " and (a.Nombre like '%" & pNombre & "%' or a.NombreComercial like '%" & pNombre & "%') and a.Activo = 1" &
                " order by a.Nombre asc"

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

    Public Function CxCSaldosxCliente(pSaldo As Double) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptCxCSaldosxCliente " & _Emp_Id.ToString & "," & pSaldo.ToString

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
    Public Function CxCBuscaDocumentosMoraCliente(pFecha As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec CxC_BuscaDocumentosMoraCliente " & _Emp_Id.ToString & "," & _Cliente_Id.ToString & ",'" & Format(pFecha, "yyyyMMdd") & "'"

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
    Public Function CxCCalculaMoraCliente(pFecha As DateTime, pUsuario_Id As String) As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec CxC_CalculaMoraCliente " & _Emp_Id.ToString & "," & _Cliente_Id.ToString & ",'" & Format(pFecha, "yyyyMMdd") & "','" & pUsuario_Id & "'"

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

    Public Function ConsultaCedulaPorNommbre() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "Select Cedula from Cliente where Nombre like '%" & _Nombre & "%' "

            Tabla = Cn.Seleccionar(Query).Copy


            Return Tabla.Rows(0).Item(0).ToString()


        Catch ex As Exception
            Return ""
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ConsultaMovimientosCliente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ConsultaMovimientosCliente " & _Emp_Id.ToString() & "," & _Cliente_Id.ToString()

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


    Public Function ConsultaMovimientosContadoCliente(pDesde As Date, pHasta As Date, pTodo As Boolean) As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim _TResultado As SDFinancial.TResultado
        Try
            Cn.Open()

            Query = "exec ConsultaMovimientosContadoCliente " & _Emp_Id.ToString() & "," & _Cliente_Id.ToString() & "," & pTodo & ",'" & pDesde.ToString("yyyyMMdd") & "','" & pHasta.ToString("yyyyMMdd") & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            If EmpresaParametroInfo.InterfazCxC Then
                Dim _DTCliente As New SDFinancial.DTCliente()

                With _DTCliente
                    .Cliente_Id = Cliente_Id
                    .Emp_Id = _Emp_Id
                End With
                _SDL.Url = InfoMaquina.URLContabilidad
                VerificaMensaje(_SDL.VerificaCliente(_Emp_Id, Cliente_Id))

                'Busca Los Movimientos del Cliente en CxC
                If pTodo Then
                    pDesde = New Date(1990, 1, 1)
                    pHasta = DateAdd(DateInterval.Day, 1, Now())
                End If

                _TResultado = _SDL.ClienteMovimientos(_DTCliente, pDesde, pHasta)

                'Agrega los registros de CxC a la tabla que trae 
                'resultados que trae desde SDG-!!!
                If _TResultado.Datos.Rows.Count > 0 Then
                    For Each fila As DataRow In _TResultado.Datos.Rows
                        Dim row As DataRow = Tabla.NewRow()

                        row.ItemArray = fila.ItemArray.Clone()
                        If row.Item(3) = 1 Then
                            row = DividirConsecutivoFE(row)
                        End If
                        Tabla.Rows.Add(row)
                    Next
                End If

            End If

            Tabla.DefaultView.Sort = "Fecha ASC"
            Tabla = Tabla.DefaultView.ToTable()

            _Data.Tables.Add(Tabla)

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ConsultaMovimientosClienteSDC(pDesde As Date, pHasta As Date, pTodo As Boolean) As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim _TResultado As SDFinancial.TResultado
        Try
            Cn.Open()

            Query = "exec ConsultaMovimientosContadoCliente " & _Emp_Id.ToString() & "," & _Cliente_Id.ToString() & "," & pTodo & ",'" & pDesde.ToString("yyyyMMdd") & "','" & pHasta.ToString("yyyyMMdd") & "'"

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

    Private Function DividirConsecutivoFE(row As DataRow) As DataRow
        Try

            Dim consecutivos As String() = row.Item(7).ToString.Split(New Char() {"-"c})
            row.Item(7) = consecutivos(1).ToString()
            Return row

        Catch ex As Exception
            Return row
        End Try
    End Function


    Public Function ConsultaProductoCompradoCliente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ConsultaProductoCompradoCliente " & _Emp_Id.ToString() & "," & _Cliente_Id.ToString()

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

    Public Function ConsultaAnotacionesCliente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * from ClienteAnotacion where Emp_Id = " & _Emp_Id.ToString() & " and Cliente_Id = " & _Cliente_Id.ToString() & " order by Anotacion_Id asc"

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

    Public Function ConsultaEncargosCliente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select a.*, b.Nombre from ClienteEncargo a, Articulo b" &
                " where a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id" &
                " and a.Emp_Id = " & _Emp_Id.ToString() & " and a.Cliente_Id = " & _Cliente_Id.ToString() & " order by a.Fecha Desc"

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

    Public Function RptCliente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptCliente " & _Emp_Id.ToString() & "," & _Precio_Id.ToString()

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
    Public Function RptClienteMasFacturados(pSuc_Id As Integer, pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptClientesMasFacturados " & _Emp_Id.ToString() & "," & pSuc_Id & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'," & Cliente_Id

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
    Public Function RptVentasxCliente(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptVentasxCliente " & _Emp_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'," & _Cliente_Id

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
    Public Function RptEncargosDeMercaderia(pFechaIni As DateTime, pFechaFin As DateTime) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptEncargosDeMercaderia " & _Emp_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'"

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
    Public Function ConsultaVentasClientePeriodo(pFechaIni As DateTime, pFechaFin As DateTime, pMontoIni As Double, pMontoFin As Double) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec ConsultaVentasClientePeriodo " & _Emp_Id.ToString() & ",'" & Format(pFechaIni, "yyyyMMdd") & "','" & Format(pFechaFin, "yyyyMMdd") & "'," & pMontoIni.ToString() & "," & pMontoFin.ToString()

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
    Public Function ActualizaTipoPrecio(pPrecio_Id As Enum_ClientPrecio) As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            If _Cliente_Id = -1 Then
                Query = "update Cliente set Precio_Id = " & pPrecio_Id &
                        " Where Emp_Id=" & _Emp_Id.ToString()
            Else
                Query = "update Cliente set Precio_Id = " & pPrecio_Id &
                        " Where Emp_Id = " & _Emp_Id.ToString() &
                        " and Cliente_Id = " & _Cliente_Id.ToString()
            End If


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
    Public Function ConsultaContactosCliente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Nombre from ClienteContacto where Emp_Id = " & _Emp_Id.ToString() & " and Cliente_Id = " & _Cliente_Id.ToString() & " order by Contacto_Id asc"

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            For Each fila As DataRow In Tabla.Rows
                _Contactos.Add(fila.Item(0).ToString)
            Next

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function GetContactos() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try

            _Contactos.Clear()

            Cn.Open()

            Query = "select Nombre From ClienteContacto" &
                    " Where Emp_Id = " & _Emp_Id.ToString() &
                    " And   Cliente_Id=" & _Cliente_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy


            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                For Each item In Tabla.Rows
                    _Contactos.Add(item("Nombre"))
                Next
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function ConsultaClienteCedula() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Cliente_Id,Nombre,NombreComercial,Telefono1,Cedula,Email,Provincia_Id,Canton_Id,Distrito_Id,Barrio_Id ,Direccion from Cliente where Emp_Id = " & _Emp_Id.ToString() & " and Cedula = '" & _Cedula & "' and Activo = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            Tabla.TableName = "ClientesxCedula"

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
    Public Function ConsultaClienteCedulaTipo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Cliente_Id,Nombre from Cliente where Emp_Id = " & _Emp_Id.ToString() &
                " and Cedula = '" & _Cedula & "'" &
                " and TipoIdentificacion_Id = " & _TipoIdentificacion_Id &
                " and Activo = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            Tabla.TableName = "ClientesxCedula"

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

    Public Function InactivaCliente() As String
        Dim Query As String = ""

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Update Cliente Set Activo = " & _Activo &
                    " Where Emp_Id=" & _Emp_Id.ToString() &
                    " And   Cliente_Id=" & _Cliente_Id.ToString()

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


#End Region
End Class