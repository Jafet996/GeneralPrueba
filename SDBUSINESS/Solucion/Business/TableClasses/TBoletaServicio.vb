Public Class TBoletaServicio
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Boleta_Id As Integer
    Private _Fecha As DateTime
    Private _FechaVisita As DateTime
    Private _Suc_Id As Integer
    Private _Cliente_Id As Integer
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _Email As String
    Private _Direccion As String
    Private _Asunto As String
    Private _Motivo As String
    Private _Estado_Id As Integer
    Private _Prioridad_Id As Integer
    Private _Usuario_Id As String
    Private _Tecnico_Id As Integer
    Private _UsuarioAsigna_Id As String
    Private _FechaAsignada As DateTime
    Private _UsuarioCierre_Id As String
    Private _FechaCierra As DateTime
    Private _Observacion As String
    Private _Solucion As String
    Private _Data As DataSet
    Private _NombreCliente As String
    Private _Sucursal As String
    Private _Usuario As String
    Private _Contactos As New List(Of String)
    Private _Factura As String
    Private _Comentarios As New List(Of String)
    Private _TraeComentario(50, 2) As String


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
    Public Property Boleta_Id() As Integer
        Get
            Return _Boleta_Id
        End Get
        Set(ByVal Value As Integer)
            _Boleta_Id = Value
        End Set
    End Property
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As DateTime)
            _Fecha = Value
        End Set
    End Property
    Public Property FechaVisita() As DateTime
        Get
            Return _FechaVisita
        End Get
        Set(ByVal Value As DateTime)
            _FechaVisita = Value
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
    Public Property Cliente_Id() As Integer
        Get
            Return _Cliente_Id
        End Get
        Set(ByVal Value As Integer)
            _Cliente_Id = Value
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
    Public Property Asunto() As String
        Get
            Return _Asunto
        End Get
        Set(ByVal Value As String)
            _Asunto = Value
        End Set
    End Property
    Public Property Motivo() As String
        Get
            Return _Motivo
        End Get
        Set(ByVal Value As String)
            _Motivo = Value
        End Set
    End Property
    Public Property Estado_Id() As Integer
        Get
            Return _Estado_Id
        End Get
        Set(ByVal Value As Integer)
            _Estado_Id = Value
        End Set
    End Property
    Public Property Prioridad_Id() As Integer
        Get
            Return _Prioridad_Id
        End Get
        Set(ByVal Value As Integer)
            _Prioridad_Id = Value
        End Set
    End Property
    Public Property Usuario_Id() As String
        Get
            Return _Usuario_Id
        End Get
        Set(ByVal Value As String)
            _Usuario_Id = Value
        End Set
    End Property
    Public Property Tecnico_Id() As Integer
        Get
            Return _Tecnico_Id
        End Get
        Set(ByVal Value As Integer)
            _Tecnico_Id = Value
        End Set
    End Property
    Public Property UsuarioAsigna_Id() As String
        Get
            Return _UsuarioAsigna_Id
        End Get
        Set(ByVal Value As String)
            _UsuarioAsigna_Id = Value
        End Set
    End Property
    Public Property FechaAsignada() As DateTime
        Get
            Return _FechaAsignada
        End Get
        Set(ByVal Value As DateTime)
            _FechaAsignada = Value
        End Set
    End Property
    Public Property UsuarioCierre_Id() As String
        Get
            Return _UsuarioCierre_Id
        End Get
        Set(ByVal Value As String)
            _UsuarioCierre_Id = Value
        End Set
    End Property
    Public Property FechaCierra() As DateTime
        Get
            Return _FechaCierra
        End Get
        Set(ByVal Value As DateTime)
            _FechaCierra = Value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal Value As String)
            _Observacion = Value
        End Set
    End Property
    Public Property Solucion() As String
        Get
            Return _Solucion
        End Get
        Set(ByVal Value As String)
            _Solucion = Value
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
    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal Value As String)
            _NombreCliente = Value
        End Set
    End Property
    Public Property Sucursal() As String
        Get
            Return _Sucursal
        End Get
        Set(ByVal Value As String)
            _Sucursal = Value
        End Set
    End Property
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal Value As String)
            _Usuario = Value
        End Set
    End Property
    Public Property Contactos As List(Of String)
        Get
            Return _Contactos
        End Get
        Set(value As List(Of String))
            _Contactos = value
        End Set
    End Property
    Public Property Factura() As String
        Get
            Return _Factura
        End Get
        Set(ByVal Value As String)
            _Factura = Value
        End Set
    End Property
    Public Property Comentarios As List(Of String)
        Get
            Return _Comentarios
        End Get
        Set(value As List(Of String))
            _Comentarios = value
        End Set
    End Property
    Public Property TraeComentario As Array
        Get
            Return _TraeComentario
        End Get
        Set(value As Array)
            _TraeComentario = value
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
        _Boleta_Id = 0
        _Fecha = CDate("1900/01/01")
        _FechaVisita = CDate("1900/01/01")
        _Suc_Id = 0
        _Cliente_Id = 0
        _Telefono1 = ""
        _Telefono2 = ""
        _Email = ""
        _Direccion = ""
        _Asunto = ""
        _Motivo = ""
        _Estado_Id = 0
        _Prioridad_Id = 0
        _Usuario_Id = ""
        _Tecnico_Id = 0
        _UsuarioAsigna_Id = ""
        _FechaAsignada = CDate("1900/01/01")
        _UsuarioCierre_Id = ""
        _FechaCierra = CDate("1900/01/01")
        _Observacion = ""
        _Solucion = ""
        _Data = New DataSet
        _NombreCliente = ""
        _Sucursal = ""
        _Usuario = ""
        _Factura = ""
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Dim cont As Integer = 1
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into BoletaServicio( Emp_Id , Boleta_Id" &
                   " , Fecha , FechaVisita" &
                   " , Suc_Id , Cliente_Id" &
                   " , Telefono1 , Telefono2" &
                   " , Email " &
                   " , Direccion , Asunto" &
                   " , Motivo , Estado_Id" &
                   " , Prioridad_Id , Usuario_Id" &
                   " , Tecnico_Id , UsuarioAsigna_Id" &
                   " , FechaAsignada , UsuarioCierre_Id" &
                   " , FechaCierra , Observacion" &
                   " , Solucion, Factura )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Boleta_Id.ToString() &
                   ",getdate(),'" & Format(_FechaVisita, "yyyyMMdd HH:mm:ss") & "'" &
                   "," & _Suc_Id.ToString() & "," & _Cliente_Id.ToString() &
                   ",'" & _Telefono1 & "'" & ",'" & _Telefono2 & "'" &
                   ",'" & _Email & "'" &
                   ",'" & _Direccion & "'" & ",'" & _Asunto & "'" &
                   ",'" & _Motivo & "'" & "," & _Estado_Id.ToString() &
                   "," & _Prioridad_Id.ToString() & ",'" & _Usuario_Id & "'" &
                   "," & IIf(_Tecnico_Id = -1, "null", _Tecnico_Id.ToString()) & "," & IIf(_UsuarioAsigna_Id = -1, "null", _UsuarioAsigna_Id) &
                   ",'" & Format(_FechaAsignada, "yyyyMMdd HH:mm:ss") & "'," & IIf(_UsuarioCierre_Id = -1, "null", _UsuarioCierre_Id) &
                   ",'" & Format(_FechaCierra, "yyyyMMdd HH:mm:ss") & "'" & ",'" & _Observacion & "'" &
                   ",'" & _Solucion & "'," & "'" & _Factura & "')"

            Cn.Ejecutar(Query)
            For Each item In Contactos
                Query = "Insert into BoletaServicioContacto(Emp_Id,Boleta_Id ,Cliente_Id, Contacto_Id, Nombre) Values(" &
                        _Emp_Id.ToString() & "," & _Boleta_Id & "," & _Cliente_Id.ToString() & "," & cont.ToString() & ",'" & item.ToString() & "')"
                cont = cont + 1
                Cn.Ejecutar(Query)
            Next
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

            Query = "Delete BoletaServicio" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Boleta_Id=" & _Boleta_Id.ToString()

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
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.BoletaServicio " &
                      " SET FechaVisita='" & Format(_FechaVisita, "yyyyMMdd HH:mm:ss") & "'" & "," &
                      " Cliente_Id=" & _Cliente_Id & "," &
                      " Telefono1='" & _Telefono1 & "'" & "," &
                      " Telefono2='" & _Telefono2 & "'" & "," &
                      " Email='" & _Email & "'" & "," &
                      " Direccion='" & _Direccion & "'" & "," &
                      " Asunto='" & _Asunto & "'" & "," &
                      " Motivo='" & _Motivo & "'" & "," &
                      " Estado_Id=" & _Estado_Id & "," &
                      " Prioridad_Id=" & _Prioridad_Id & "," &
                      " Usuario_Id='" & _Usuario_Id & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Boleta_Id=" & _Boleta_Id.ToString()

            Cn.Ejecutar(Query)
            Query = "Delete BoletaServicioContacto where Emp_Id=" & _Emp_Id.ToString() & " AND Cliente_Id=" & _Cliente_Id.ToString() & " AND Boleta_Id=" & _Boleta_Id.ToString()

            Cn.Ejecutar(Query)

            For Each item In _Contactos
                Query = "Insert into BoletaServicioContacto(Emp_Id,Boleta_Id, Cliente_Id, Contacto_Id, Nombre) Values(" &
                        _Emp_Id.ToString() & "," & _Boleta_Id.ToString() & "," & _Cliente_Id.ToString() & "," & cont.ToString() & ",'" & item.ToString() & "')"
                cont = cont + 1
                Cn.Ejecutar(Query)
            Next

            Cn.CommitTransaction()

            Return ""
        Catch ex As Exception
            Cn.RollBackTransaction()
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function Asigna() As String ' almacena los cambios de asigna boleta
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.BoletaServicio " &
                      " SET" &
                      " Estado_Id=" & _Estado_Id & "," &
                      " Tecnico_Id=" & _Tecnico_Id.ToString() & "," &
                      " UsuarioAsigna_Id='" & _UsuarioAsigna_Id & "'," &
                      " FechaAsignada= getdate()," &
                      " Observacion='" & _Observacion & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Boleta_Id=" & _Boleta_Id.ToString()

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
    Public Function Cierra() As String 'almacena los cambios de cierre de boleta 
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.BoletaServicio " &
                      " SET" &
                      " Estado_Id=" & _Estado_Id & "," &
                      " UsuarioCierre_Id='" & _UsuarioCierre_Id.ToString() & "'," &
                      " FechaCierra= getdate()," &
                      " Solucion='" & _Solucion & "'," &
                      " Factura='" & _Factura & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Boleta_Id=" & _Boleta_Id.ToString()

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
    Public Function Post() As String 'almacena los cambios de cierre de boleta 
        Dim Query As String = ""
        Dim cont As Integer = 1
        Try
            Cn.Open()

            Cn.BeginTransaction()
            Query = "Delete BoletaServicioComentario Where Emp_Id = " & _Emp_Id & " And Boleta_Id = " & Boleta_Id 
            Cn.Ejecutar(Query)
            For Each item In Comentarios
                Query = "Insert into BoletaServicioComentario(Emp_Id, Boleta_Id , Usuario_Id , Comentario_Id, Comentario, FechaRegistro) Values(" &
                        _Emp_Id.ToString() & "," & _Boleta_Id & ",'" & _Usuario_Id & "'," & cont.ToString() & ",'" & item.ToString() & "',GetDate())"
                cont = cont + 1
                Cn.Ejecutar(Query)
            Next
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
        Dim sum As Integer = 0
        Try
            Cn.Open()

            Query = "select a.*, b.Nombre, c.Nombre as Sucursal, d.Nombre as Usuario From BoletaServicio a, Cliente b, Sucursal c, Usuario d" &
           " Where     a.Emp_Id=" & _Emp_Id.ToString() &
           " And    Boleta_Id=" & _Boleta_Id.ToString() &
           " And a.Cliente_Id= b.Cliente_Id And a.Suc_Id = c.Suc_Id" &
           " And a.Usuario_Id= d.Usuario_Id"
            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Boleta_Id = Tabla.Rows(0).Item("Boleta_Id")
                _Fecha = Tabla.Rows(0).Item("Fecha")
                _FechaVisita = Tabla.Rows(0).Item("FechaVisita")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Sucursal = Tabla.Rows(0).Item("Sucursal")
                _Cliente_Id = Tabla.Rows(0).Item("Cliente_Id")
                _NombreCliente = Tabla.Rows(0).Item("Nombre")
                _Telefono1 = Tabla.Rows(0).Item("Telefono1")
                _Telefono2 = Tabla.Rows(0).Item("Telefono2")
                _Email = Tabla.Rows(0).Item("Email")
                _Direccion = Tabla.Rows(0).Item("Direccion")
                _Asunto = Tabla.Rows(0).Item("Asunto")
                _Motivo = Tabla.Rows(0).Item("Motivo")
                _Estado_Id = Tabla.Rows(0).Item("Estado_Id")
                _Prioridad_Id = Tabla.Rows(0).Item("Prioridad_Id")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Usuario = Tabla.Rows(0).Item("Usuario")
                _Tecnico_Id = IIf(IsDBNull(Tabla.Rows(0).Item("Tecnico_Id")), -1, Tabla.Rows(0).Item("Tecnico_Id"))
                _UsuarioAsigna_Id = IIf(IsDBNull(Tabla.Rows(0).Item("UsuarioAsigna_Id")), "", Tabla.Rows(0).Item("UsuarioAsigna_Id"))
                _FechaAsignada = Tabla.Rows(0).Item("FechaAsignada")
                _UsuarioCierre_Id = IIf(IsDBNull(Tabla.Rows(0).Item("UsuarioCierre_Id")), "", Tabla.Rows(0).Item("UsuarioCierre_Id"))
                _FechaCierra = Tabla.Rows(0).Item("FechaCierra")
                _Observacion = Tabla.Rows(0).Item("Observacion")
                _Solucion = Tabla.Rows(0).Item("Solucion")
                _Factura = IIf(IsDBNull(Tabla.Rows(0).Item("Factura")), "", Tabla.Rows(0).Item("Factura"))
            End If
            Query = "select Nombre From BoletaServicioContacto" &
                    " Where Emp_Id = " & _Emp_Id.ToString() &
                    " And   Boleta_Id=" & _Boleta_Id.ToString() &
                    " And   Cliente_Id=" & _Cliente_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy
            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                For Each item In Tabla.Rows
                    _Contactos.Add(item("Nombre"))
                Next
            End If
            Query = "select Comentario, Format(FechaRegistro, 'dd/MM/yyyy', 'en-US') as FechaRegistro, Usuario_Id From BoletaServicioComentario" &
                    " Where Emp_Id = " & _Emp_Id.ToString() &
                    " And   Boleta_Id=" & _Boleta_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy
            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                For Each item In Tabla.Rows
                    _TraeComentario(sum, 0) = Tabla.Rows(sum).Item("Comentario")
                    _TraeComentario(sum, 1) = Tabla.Rows(sum).Item("FechaRegistro")
                    _TraeComentario(sum, 2) = Tabla.Rows(sum).Item("Usuario_Id")
                    sum = sum + 1
                Next
            End If
            sum = 0
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

            Query = "select * From BoletaServicio"

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

            Query = "select BoletaServicio_Id as Numero, Nombre From BoletaServicio"

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
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select isnull(max(Boleta_Id),0) + 1 From BoletaServicio Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Boleta_Id = Tabla.Rows(0).Item(0)
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function ListaMantenimiento(pNombre As String, pEstado As Boolean, pEstado_Id As Integer, pDesde As Date, pHasta As Date, pBoleta As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select a.Boleta_Id as Boleta, b.Nombre as Cliente, a.Asunto as Asunto, FORMAT(a.Fecha, 'dd/MM/yyyy', 'en-US'),c.Nombre as Estado From BoletaServicio a, Cliente b, BoletaServicioEstado c " &
                    " where a.Emp_Id = " & _Emp_Id.ToString() &
                    " And  a.Cliente_Id= b.Cliente_Id And a.Estado_Id = c.Estado_Id" &
                    " And a.Fecha >='" & Format(pDesde, "yyyyMMdd") & "'" &
                    " And a.Fecha <'" & Format(DateAdd(DateInterval.Day, 1, pHasta), "yyyyMMdd") & "'"



            If pNombre.Trim <> "" Then
                Query = Query & " And b.Nombre Like '%" & pNombre & "%'"
            End If
            If pEstado = True Then
                Query = Query & " And a.Estado_Id Like '%" & pEstado_Id & "%'"
            End If
            If pBoleta <> "" Or pBoleta <> "0" Then
                Query = Query & " And a.Boleta_Id Like '%" & pBoleta & "%'"
            End If

            Query = Query & " Order by boleta_id desc"
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
    Public Function ConsultaBoletaContactos() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Nombre from BoletaServicioContacto where Emp_Id = " & _Emp_Id.ToString() & " and Boleta_Id = " & _Boleta_Id & " and Cliente_Id = " & _Cliente_Id.ToString() & " order by Contacto_Id asc"

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

    Public Function RptBoletaServicio()
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptBoletaServicio " & _Emp_Id.ToString() & "," & _Boleta_Id


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
