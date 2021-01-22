Public Class TProveedor
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Prov_Id As Integer
    Private _Nombre As String
    Private _TipoIdentificacion_Id As Integer
    Private _CedulaJuridica As String
    Private _Direccion As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _Fax As String
    Private _Email As String
    Private _Apartado As String
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _Data As DataSet
    Private _CxP_Colones As String
    Private _CxP_Dolares As String
    Private _DiasCredito As Integer
    Private _SDL As New SDFinancial.SDFinancial

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
    Public Property Prov_Id() As Integer
        Get
            Return _Prov_Id
        End Get
        Set(ByVal Value As Integer)
            _Prov_Id = Value
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
    Public Property TipoIdentificacion_Id() As Integer
        Get
            Return _TipoIdentificacion_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoIdentificacion_Id = Value
        End Set
    End Property
    Public Property CedulaJuridica() As String
        Get
            Return _CedulaJuridica
        End Get
        Set(ByVal Value As String)
            _CedulaJuridica = Value
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
    Public Property Apartado() As String
        Get
            Return _Apartado
        End Get
        Set(ByVal Value As String)
            _Apartado = Value
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
    Public Property CxP_Colones() As String
        Get
            Return _CxP_Colones
        End Get
        Set(ByVal Value As String)
            _CxP_Colones = Value
        End Set
    End Property
    Public Property CxP_Dolares() As String
        Get
            Return _CxP_Dolares
        End Get
        Set(ByVal Value As String)
            _CxP_Dolares = Value
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
        _SDL.Url = InfoMaquina.URLContabilidad
        _Emp_Id = 0
        _Prov_Id = 0
        _Nombre = ""
        _CedulaJuridica = ""
        _TipoIdentificacion_Id = 0
        _Direccion = ""
        _Telefono1 = ""
        _Telefono2 = ""
        _Fax = ""
        _Email = ""
        _Apartado = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _CxP_Colones = ""
        _CxP_Dolares = ""
        _DiasCredito = 0
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Dim SDFResultado As New SDFinancial.TResultado()
        Dim Mensaje As String = String.Empty
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Proveedor( Emp_Id , Prov_Id" &
                   " , Nombre ,TipoIdentificacion_Id ,CedulaJuridica" &
                   " , Direccion , Telefono1" &
                   " , Telefono2 , Fax" &
                   " , Email , Apartado" &
                   " , Activo , UltimaModificacion, CxP_Colones, CxP_Dolares, DiasCredito)" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Prov_Id.ToString() &
                   ",'" & _Nombre & "'," & _TipoIdentificacion_Id & ",'" & _CedulaJuridica &
                   "','" & _Direccion & "'" & ",'" & _Telefono1 & "'" &
                   ",'" & _Telefono2 & "'" & ",'" & _Fax & "'" &
                   ",'" & _Email & "'" & ",'" & _Apartado & "'" &
                   "," & _Activo.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "','" & _CxP_Colones & "','" & CxP_Dolares & "','" & _DiasCredito & "')"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            If EmpresaParametroInfo.InterfazCxC Then
                Dim _DTProveedor As New SDFinancial.DTProveedor()

                With _DTProveedor
                    _DTProveedor.Activo = _Activo
                    _DTProveedor.Creditos = 0
                    _DTProveedor.CxP_Colones = _CxP_Colones
                    _DTProveedor.CxP_Dolares = _CxP_Dolares
                    _DTProveedor.Debitos = 0
                    _DTProveedor.DiasCredito = _DiasCredito
                    _DTProveedor.Direccion = _Direccion
                    _DTProveedor.Email = _Email
                    _DTProveedor.Emp_Id = Emp_Id
                    _DTProveedor.Identificacion = _CedulaJuridica
                    _DTProveedor.Nombre = _Nombre
                    _DTProveedor.Prov_Id = _Prov_Id
                    _DTProveedor.Saldo = 0
                    _DTProveedor.Telefono1 = _Telefono1
                    _DTProveedor.Telefono2 = _Telefono2
                    _DTProveedor.TipoIdentificacion_Id = _TipoIdentificacion_Id
                    _DTProveedor.UltimaModificacion = _UltimaModificacion
                End With

                SDFResultado = _SDL.ProveedorMant(_DTProveedor, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

                If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" OrElse SDFResultado.RowsAffected = 0 Then
                    If Not SDFResultado Is Nothing Then
                        Mensaje = SDFResultado.ErrorDescription
                    End If

                    VerificaMensaje("Se presentaron errores creando cliente en CXP : " & Mensaje)
                End If
            End If


            Return ""
        Catch ex As Exception
            If Cn.ActiveTansaction Then
                Cn.RollBackTransaction()
            End If
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

            Query = "Delete Proveedor" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Prov_Id=" & _Prov_Id.ToString()

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
        Dim SDFResultado As New SDFinancial.TResultado
        Dim Mensaje As String = String.Empty
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.Proveedor " &
                      " SET   Nombre='" & _Nombre & "' " & "," &
                      " TipoIdentificacion_Id =" & _TipoIdentificacion_Id & "," &
                      " CedulaJuridica='" & _CedulaJuridica & "'" & "," &
                      " Direccion='" & _Direccion & "'" & "," &
                      " Telefono1='" & _Telefono1 & "'" & "," &
                      " Telefono2='" & _Telefono2 & "'" & "," &
                      " Fax='" & _Fax & "'" & "," &
                      " Email='" & _Email & "'" & "," &
                      " Apartado='" & _Apartado & "'" & "," &
                      " Activo=" & _Activo & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'," &
                      " CxP_Colones='" & _CxP_Colones & "'" & "," &
                      " CxP_Dolares='" & _CxP_Dolares & "'" & "," &
                      " DiasCredito=" & _DiasCredito &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Prov_Id=" & _Prov_Id.ToString()

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            If EmpresaParametroInfo.InterfazCxC Then
                Dim _DTProveedor As New SDFinancial.DTProveedor()

                With _DTProveedor
                    _DTProveedor.Activo = _Activo
                    _DTProveedor.Creditos = 0
                    _DTProveedor.CxP_Colones = _CxP_Colones
                    _DTProveedor.CxP_Dolares = _CxP_Dolares
                    _DTProveedor.Debitos = 0
                    _DTProveedor.DiasCredito = _DiasCredito
                    _DTProveedor.Direccion = _Direccion
                    _DTProveedor.Email = _Email
                    _DTProveedor.Emp_Id = Emp_Id
                    _DTProveedor.Identificacion = _CedulaJuridica
                    _DTProveedor.Nombre = _Nombre
                    _DTProveedor.Prov_Id = _Prov_Id
                    _DTProveedor.Saldo = 0
                    _DTProveedor.Telefono1 = _Telefono1
                    _DTProveedor.Telefono2 = _Telefono2
                    _DTProveedor.TipoIdentificacion_Id = _TipoIdentificacion_Id
                    _DTProveedor.UltimaModificacion = _UltimaModificacion
                End With

                SDFResultado = _SDL.ProveedorMant(_DTProveedor, SDFinancial.EnumOperacionMant.Modificar, String.Empty)
                VerificaMensaje(SDFResultado.ErrorDescription)

                If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" Then
                    If Not SDFResultado Is Nothing Then
                        Mensaje = SDFResultado.ErrorDescription
                    End If

                    VerificaMensaje("Se presentaron errores creando cliente en CXP : " & Mensaje)
                End If

                If SDFResultado.RowsAffected = 0 Then
                    SDFResultado = _SDL.ProveedorMant(_DTProveedor, SDFinancial.EnumOperacionMant.Insertar, String.Empty)
                    If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" OrElse SDFResultado.RowsAffected = 0 Then
                        If Not SDFResultado Is Nothing Then
                            Mensaje = SDFResultado.ErrorDescription
                        End If

                        VerificaMensaje("Se presentaron errores creando cliente en CXP : " & Mensaje)
                    End If
                End If


            End If

            Return ""
        Catch ex As Exception
            If Cn.ActiveTansaction Then
                Cn.RollBackTransaction()
            End If
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

            Query = "select * From Proveedor" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Prov_Id=" & _Prov_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Prov_Id = Tabla.Rows(0).Item("Prov_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _TipoIdentificacion_Id = Tabla.Rows(0).Item("TipoIdentificacion_Id")
                _CedulaJuridica = Tabla.Rows(0).Item("CedulaJuridica")
                _Direccion = Tabla.Rows(0).Item("Direccion")
                _Telefono1 = Tabla.Rows(0).Item("Telefono1")
                _Telefono2 = Tabla.Rows(0).Item("Telefono2")
                _Fax = Tabla.Rows(0).Item("Fax")
                _Email = Tabla.Rows(0).Item("Email")
                _Apartado = Tabla.Rows(0).Item("Apartado")
                _Activo = Tabla.Rows(0).Item("Activo")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
                _CxP_Colones = Tabla.Rows(0).Item("CxP_Colones")
                _CxP_Dolares = Tabla.Rows(0).Item("CxP_Dolares")
                _DiasCredito = Tabla.Rows(0).Item("DiasCredito")
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

            Query = "select Prov_Id as Codigo, Nombre From Proveedor where Emp_Id = " & _Emp_Id.ToString() & "Order by Nombre asc"

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

            Query = "select Prov_Id as Numero, Nombre From Proveedor where Emp_Id = " & _Emp_Id.ToString() & " order by Prov_Id asc"

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

            Query = "select Prov_Id as Codigo, Nombre From Proveedor " & _
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
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(Prov_Id),0) + 1 From Proveedor Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Prov_Id = Tabla.Rows(0).Item(0)
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

            Query = "select Prov_Id as Codigo, Nombre From Proveedor where Emp_Id = " & _Emp_Id.ToString()

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
    Public Function ProveedorxCedula() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From Proveedor where Emp_Id = " & _Emp_Id.ToString() & " and TipoIdentificacion_Id = " & _TipoIdentificacion_Id & "  and CedulaJuridica = '" & _CedulaJuridica & "'  Order by Nombre asc"

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
