Imports System.Data.SqlClient
Public Class TEmpresa
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Nombre As String
    Private _Cedula As String
    Private _Telefono As String
    Private _Fax As String
    Private _Email As String
    Private _Direccion As String
    Private _DireccionWeb As String
    Private _Activo As Integer
    Private _Parametros As New TEmpresaParametro(0)
    Private _Logo As Byte()
    Private _RazonSocial As String
    Private _TipoIdentificacion_Id As Integer
    Private _UltimaModificacion As DateTime
    Private _Data As DataSet
    Private _DevuelveIV As Integer '08/12/2020 Mike

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
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal Value As String)
            _RazonSocial = Value
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
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal Value As String)
            _Telefono = Value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal Value As String)
            _Fax = Value
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
    Public Property DireccionWeb() As String
        Get
            Return _DireccionWeb
        End Get
        Set(ByVal Value As String)
            _DireccionWeb = Value
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public Property Logo As Byte()
        Get
            Return _Logo
        End Get
        Set(value As Byte())
            _Logo = value
        End Set
    End Property
    Public Property Parametros As TEmpresaParametro
        Get
            Return _Parametros
        End Get
        Set(value As TEmpresaParametro)
            _Parametros = value
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
    Public Property DevuelveIV() As Integer '08/12/2020 Mike
        Get
            Return _DevuelveIV
        End Get
        Set(ByVal Value As Integer)
            _DevuelveIV = Value
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
        _Nombre = ""
        _RazonSocial = ""
        _TipoIdentificacion_Id = 0
        _Cedula = ""
        _Telefono = ""
        _Fax = ""
        _Email = ""
        _Direccion = ""
        _DireccionWeb = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Logo = Nothing
        _DevuelveIV = 0

        With _Parametros
            .Emp_Id = 0
            '.PorcIV = 0.0
            .FactorRedondeo = 0
            .TopeRedondeo = 0.0
            .LeyendaFactura1 = ""
            .LeyendaFactura2 = ""
            .SaldoMinimoRecarga = 0
            .ImprimeRecarga = 0
            .DiasCredito = 0
            .PorcMora = 0.0
            .DiasGraciaMora = 0
            .MinutosPrefactura = 0
            .ProformaDiasVencimiento = 0
            .ProformaGeneraArchivo = 0
            .ProformaCarpeta = ""
            .ProformaTipoImpresion = 0
            .TipoCambioFac = ""
        End With
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function ListaMantenimiento(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Emp_Id as Codigo, Nombre From Empresa"

            If pNombre.Trim <> "" Then
                Query = Query & " where Nombre Like '%" & pNombre & "%'"
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
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(Emp_Id),0) + 1 From Empresa"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item(0)
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Overrides Function Insert() As String
        'Dim Query As String = ""
        'Dim Mensaje As String = ""
        'Try
        '    Cn.Open()

        '    Cn.BeginTransaction()



        '    'Query = " Insert into Empresa( Emp_Id , Nombre" & _
        '    '       " , Cedula , Telefono" & _
        '    '       " , Fax , Email" & _
        '    '       " , Direccion , Activo" & _
        '    '       " , UltimaModificacion )" & _
        '    '       " Values ( " & _Emp_Id.ToString() & ",'" & _Nombre & "'" & _
        '    '       ",'" & _Cedula & "'" & ",'" & _Telefono & "'" & _
        '    '       ",'" & _Fax & "'" & ",'" & _Email & "'" & _
        '    '       ",'" & _Direccion & "'" & "," & _Activo.ToString() & _
        '    '       ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & ")"

        '    Query = " Insert into Empresa( Emp_Id , Nombre" & _
        '        " , Cedula , Telefono" & _
        '        " , Fax , Email" & _
        '        " , Direccion , DireccionWeb" & _
        '        " , Activo , UltimaModificacion" & _
        '        " )" & _
        '        " Values ( " & _Emp_Id.ToString() & ",'" & _Nombre & "'" & _
        '        ",'" & _Cedula & "'" & ",'" & _Telefono & "'" & _
        '        ",'" & _Fax & "'" & ",'" & _Email & "'" & _
        '        ",'" & _Direccion & "'" & ",'" & _DireccionWeb & "'" & _
        '        "," & _Activo.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "')"

        '    Cn.Ejecutar(Query)

        '    'Mensaje = _Parametros.Insert()
        '    'VerificaMensaje(Mensaje)


        '    Cn.CommitTransaction()

        '    Return ""
        'Catch ex As Exception
        '    Cn.RollBackTransaction()
        '    Return ex.Message
        'Finally
        '    Cn.Close()
        'End Try
        Dim Query As String = ""

        Try
            Cn.Open()
            '08/12/2020 Mike
            Query = "INSERT INTO Empresa(Emp_Id,Nombre,Cedula,Telefono,Fax,Email,Direccion,DireccionWeb,Activo,UltimaModificacion,Logo,DevuelveIV) VALUES(@Emp_Id,@Nombre,@RazonSocial,@TipoIdentificacion_Id,@Cedula,@Telefono,@Fax,@Email,@Direccion,@DireccionWeb,@Activo,@UltimaModificacion,@Logo,@DevuelveIV)"

            Dim cmd As New SqlCommand(Query, Cn.ConexionObject)
            cmd.Parameters.AddWithValue("@Emp_Id", _Emp_Id)
            cmd.Parameters.AddWithValue("@Nombre", _Nombre)
            cmd.Parameters.AddWithValue("@RazonSocial", _RazonSocial)
            cmd.Parameters.AddWithValue("@TipoIdentificacion_Id", _TipoIdentificacion_Id)
            cmd.Parameters.AddWithValue("@Cedula", _Cedula)
            cmd.Parameters.AddWithValue("@Telefono", _Telefono)
            cmd.Parameters.AddWithValue("@Fax", _Fax)
            cmd.Parameters.AddWithValue("@Email", _Email)
            cmd.Parameters.AddWithValue("@Direccion", _Direccion)
            cmd.Parameters.AddWithValue("@DireccionWeb", _DireccionWeb)
            cmd.Parameters.AddWithValue("@Activo", _Activo)
            cmd.Parameters.AddWithValue("@UltimaModificacion", Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss"))

            Dim p As New SqlParameter("@Logo", SqlDbType.Image)
            If Not _Logo Is Nothing Then
                p.Value = _Logo
            Else
                p.Value = DBNull.Value
            End If
            cmd.Parameters.AddWithValue("@DevuelveIV", _DevuelveIV)
            '08/12/2020 Mike
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try

    End Function
    Public Overrides Function Delete() As String
        Dim Query As String = ""
        Dim Mensaje As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()


            _Parametros.Emp_Id = _Emp_Id
            Mensaje = _Parametros.Delete
            VerificaMensaje(Mensaje)



            Query = "Delete Empresa" & _
               " Where     Emp_Id=" & _Emp_Id.ToString()

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
        'Dim Query As String = ""
        'Dim Mensaje As String = ""
        'Try
        '    Cn.Open()

        '    Cn.BeginTransaction()


        '    Mensaje = _Parametros.Modify()
        '    VerificaMensaje(Mensaje)


        '    Query = " Update dbo.Empresa " & _
        '              " SET   Nombre='" & _Nombre & "' " & "," & _
        '              " Cedula='" & _Cedula & "'" & "," & _
        '              " Telefono='" & _Telefono & "'" & "," & _
        '              " Fax='" & _Fax & "'" & "," & _
        '              " Email='" & _Email & "'" & "," & _
        '              " Direccion='" & _Direccion & "'" & "," & _
        '              " DireccionWeb='" & _DireccionWeb & "'" & "," & _
        '              " Activo=" & _Activo & "," & _
        '              " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
        '              " Where     Emp_Id=" & _Emp_Id.ToString()

        '    Cn.Ejecutar(Query)

        '    Cn.CommitTransaction()

        '    Return ""
        'Catch ex As Exception
        '    Cn.RollBackTransaction()
        '    Return ex.Message
        'Finally
        '    Cn.Close()
        'End Try

        Dim Query As String = ""
        Dim Mensaje As String = ""
        Try
            Cn.Open()

            Mensaje = _Parametros.Modify()
            VerificaMensaje(Mensaje)

            '08/12/2020 Mike
            Query = "UPDATE Empresa SET Nombre=@Nombre ,RazonSocial = @RazonSocial,TipoIdentificacion_Id = @TipoIdentificacion_Id, Cedula=@Cedula, Telefono=@Telefono, Fax=@Fax, Email=@Email, Direccion=@Direccion, DireccionWeb=@DireccionWeb, Activo=@Activo, UltimaModificacion=@UltimaModificacion, Logo=@Logo, DevuelveIV=@DevuelveIV WHERE Emp_Id = @Emp_Id"


            Dim cmd As New SqlCommand(Query, Cn.ConexionObject)
            cmd.Parameters.AddWithValue("@Emp_Id", _Emp_Id)
            cmd.Parameters.AddWithValue("@Nombre", _Nombre)
            cmd.Parameters.AddWithValue("@RazonSocial", _RazonSocial)
            cmd.Parameters.AddWithValue("@TipoIdentificacion_Id", _TipoIdentificacion_Id)
            cmd.Parameters.AddWithValue("@Cedula", _Cedula)
            cmd.Parameters.AddWithValue("@Telefono", _Telefono)
            cmd.Parameters.AddWithValue("@Fax", _Fax)
            cmd.Parameters.AddWithValue("@Email", _Email)
            cmd.Parameters.AddWithValue("@Direccion", _Direccion)
            cmd.Parameters.AddWithValue("@DireccionWeb", _DireccionWeb)
            cmd.Parameters.AddWithValue("@Activo", _Activo)
            cmd.Parameters.AddWithValue("@UltimaModificacion", Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss"))

            Dim p As New SqlParameter("@Logo", SqlDbType.Image)
            If Not _Logo Is Nothing Then
                p.Value = _Logo
            Else
                p.Value = DBNull.Value
            End If
            cmd.Parameters.AddWithValue("@DevuelveIV", _DevuelveIV)
            '08/12/2020 Mike
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try

    End Function
    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim Mensaje As String = ""
        Try
            Cn.Open()

            Query = "select * From Empresa" &
           " Where     Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _RazonSocial = Tabla.Rows(0).Item("RazonSocial")
                _TipoIdentificacion_Id = Tabla.Rows(0).Item("TipoIdentificacion_Id")
                _Cedula = Tabla.Rows(0).Item("Cedula")
                _Telefono = Tabla.Rows(0).Item("Telefono")
                _Fax = Tabla.Rows(0).Item("Fax")
                _Email = Tabla.Rows(0).Item("Email")
                _Direccion = Tabla.Rows(0).Item("Direccion")
                _DireccionWeb = Tabla.Rows(0).Item("DireccionWeb")
                _Activo = Tabla.Rows(0).Item("Activo")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _DevuelveIV = Tabla.Rows(0).Item("DevuelveIV") '08/12/2020 Mike

                _Parametros.Emp_Id = _Emp_Id
                Mensaje = _Parametros.ListKey()
                VerificaMensaje(Mensaje)


                Query = "select Logo From Empresa" &
                " Where     Emp_Id=" & _Emp_Id.ToString()

                Dim cmd As New SqlCommand(Query, Cn.ConexionObject)

                If Not IsDBNull(Tabla.Rows(0).Item("Logo")) Then
                    _Logo = DirectCast(cmd.ExecuteScalar(), Byte())
                Else
                    _Logo = Nothing
                End If


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

            Query = "select * From Empresa Where Emp_Id=" & _Emp_Id.ToString()

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

            Query = "select Emp_Id as Numero, Nombre From Empresa"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                If Not Tabla.Rows Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                    _Emp_Id = Tabla.Rows(0).Item("Numero")
                End If

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
    Public Function Getdate() As DateTime
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select getdate() as Fecha"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                Return Tabla.Rows(0).Item("Fecha")
            Else
                VerificaMensaje("No se pudo encontrar la fecha de la BD")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function GetLogoEmpresa() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Query = " exec GetLogoEmpresa " & _Emp_Id.ToString

            Tabla = Cn.Seleccionar(Query).Copy

            If _Data.Tables.Contains(Tabla.TableName) Then
                _Data.Tables.Remove(Tabla.TableName)
            End If

            _Data.Tables.Add(Tabla)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region
End Class