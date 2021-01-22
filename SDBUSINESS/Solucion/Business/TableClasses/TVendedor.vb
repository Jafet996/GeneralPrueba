Public Class TVendedor
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Vendedor_Id As Integer
    Private _Nombre As String
    Private _Activo As Integer
    Private _Comision As Double
    Private _UltimaModificacion As Datetime
    Private _Data As DataSet
    Private _SDL As New SDFinancial.SDFinancial()
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
    Public Property Vendedor_Id() As Integer
        Get
            Return _Vendedor_Id
        End Get
        Set(ByVal Value As Integer)
            _Vendedor_Id = Value
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
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
        End Set
    End Property
    Public Property Comision() As Double
        Get
            Return _Comision
        End Get
        Set(ByVal Value As Double)
            _Comision = Value
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
        _Vendedor_Id = 0
        _Nombre = ""
        _Activo = 0
        _Comision = 0.00
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New DataSet
        _SDL.Url = InfoMaquina.URLContabilidad
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Function ListaMantenimiento(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Vendedor_Id as Codigo, Nombre From Vendedor where Emp_Id = " & _Emp_Id.ToString()

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
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(Vendedor_Id),0) + 1 From Vendedor Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Vendedor_Id = Tabla.Rows(0).Item(0)
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Dim SDFResultado As New SDFinancial.TResultado()
        Dim Mensaje As String = String.Empty
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Vendedor( Emp_Id , Vendedor_Id" &
                   " , Nombre , Activo, Comision" &
                   " , UltimaModificacion )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Vendedor_Id.ToString() &
                   ",'" & _Nombre & "'" & "," & _Activo.ToString() & "," & _Comision.ToString() &
                   ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & ")"

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()


            If EmpresaParametroInfo.InterfazCxC Then
                Dim DTVendedor As New SDFinancial.DTVendedor()

                With DTVendedor
                    .Activo = _Activo
                    .Comision = _Comision
                    .Emp_Id = _Emp_Id
                    .Nombre = _Nombre
                    .UltimaModificacion = _UltimaModificacion
                    .Vendedor_Id = Vendedor_Id
                End With


                SDFResultado = _SDL.VendedorMant(DTVendedor, SDFinancial.EnumOperacionMant.Insertar, String.Empty)

                If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" OrElse SDFResultado.RowsAffected = 0 Then
                    If Not SDFResultado Is Nothing Then
                        Mensaje = SDFResultado.ErrorDescription
                    End If

                    VerificaMensaje("Se presentaron errores creando vendedor en CXC : " & Mensaje)
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

            Query = "Delete Vendedor" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Vendedor_Id=" & _Vendedor_Id.ToString()

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

            Query = " Update dbo.Vendedor " &
                      " SET   Nombre='" & _Nombre & "' " & "," &
                      " Activo=" & _Activo & "," &
                      " Comision =" & _Comision.ToString() & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Vendedor_Id=" & _Vendedor_Id.ToString()

            Cn.Ejecutar(Query)

            Cn.CommitTransaction()

            If EmpresaParametroInfo.InterfazCxC Then
                Dim DTVendedor As New SDFinancial.DTVendedor()

                With DTVendedor
                    .Activo = _Activo
                    .Comision = _Comision
                    .Emp_Id = _Emp_Id
                    .Nombre = _Nombre
                    .UltimaModificacion = _UltimaModificacion
                    .Vendedor_Id = Vendedor_Id
                End With



                SDFResultado = _SDL.VendedorMant(DTVendedor, SDFinancial.EnumOperacionMant.Modificar, String.Empty)

                If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" Then
                    If Not SDFResultado Is Nothing Then
                        Mensaje = SDFResultado.ErrorDescription
                    End If

                    VerificaMensaje("Se presentaron errores creando vendedor en CXC : " & Mensaje)
                End If

                If SDFResultado.RowsAffected = 0 Then
                    SDFResultado = _SDL.VendedorMant(DTVendedor, SDFinancial.EnumOperacionMant.Insertar, String.Empty)
                    If SDFResultado Is Nothing OrElse SDFResultado.ErrorDescription.Trim() <> "" OrElse SDFResultado.ErrorCode <> "00" OrElse SDFResultado.RowsAffected = 0 Then
                        If Not SDFResultado Is Nothing Then
                            Mensaje = SDFResultado.ErrorDescription
                        End If

                        VerificaMensaje("Se presentaron errores creando vendedor en CXC : " & Mensaje)
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

            Query = "select * From Vendedor" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Vendedor_Id=" & _Vendedor_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Vendedor_Id = Tabla.Rows(0).Item("Vendedor_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Activo = Tabla.Rows(0).Item("Activo")
                _Comision = Tabla.Rows(0).Item("Comision")
                _UltimaModificacion = Tabla.Rows(0).Item("UltimaModificacion")
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

            Query = "select Vendedor_Id as Codigo, Nombre From Vendedor where Emp_Id = " & _Emp_Id.ToString

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

            Query = "select Vendedor_Id as Numero, Nombre From Vendedor where Emp_Id = " & _Emp_Id.ToString & " order by Nombre asc"

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
#End Region
End Class
