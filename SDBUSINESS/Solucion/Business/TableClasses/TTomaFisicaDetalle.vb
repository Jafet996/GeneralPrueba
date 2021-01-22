Public Class TTomaFisicaDetalle
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Bod_Id As Integer
    Private _TomaFisica_Id As Integer
    Private _Art_Id As String
    Private _Suelto As Integer
    Private _FactorConversion As Integer
    Private _Magnetico As Double
    Private _Fisico As Double
    Private _Nombre As String
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
    Public Property TomaFisica_Id() As Integer
        Get
            Return _TomaFisica_Id
        End Get
        Set(ByVal Value As Integer)
            _TomaFisica_Id = Value
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
    Public Property Suelto() As Integer
        Get
            Return _Suelto
        End Get
        Set(ByVal Value As Integer)
            _Suelto = Value
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
    Public Property Magnetico() As Double
        Get
            Return _Magnetico
        End Get
        Set(ByVal Value As Double)
            _Magnetico = Value
        End Set
    End Property
    Public Property Fisico() As Double
        Get
            Return _Fisico
        End Get
        Set(ByVal Value As Double)
            _Fisico = Value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
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
        _TomaFisica_Id = 0
        _Art_Id = ""
        _Suelto = 0
        _FactorConversion = 0
        _Magnetico = 0.0
        _Fisico = 0.0
        _Nombre = String.Empty
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            query = " Insert into TomaFisicaDetalle( Emp_Id , Suc_Id" & _
                   " , Bod_Id , TomaFisica_Id" & _
                   " , Art_Id , Suelto" & _
                   " , FactorConversion , Magnetico" & _
                   " , Fisico )" & _
                   " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
                   "," & _Bod_Id.ToString() & "," & _TomaFisica_Id.ToString() & _
                   ",'" & _Art_Id & "'" & "," & _Suelto.ToString() & _
                   "," & _FactorConversion.ToString() & "," & _Magnetico.ToString() & _
                   "," & _Fisico.ToString() & ")"

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

            query = "Delete TomaFisicaDetalle" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Bod_Id=" & _Bod_Id.ToString() & _
               " And    TomaFisica_Id=" & _TomaFisica_Id.ToString() & _
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

            query = " Update dbo.TomaFisicaDetalle " & _
                      " SET    Suelto=" & _Suelto.ToString() & "," & _
                      " FactorConversion=" & _FactorConversion & "," & _
                      " Magnetico=" & _Magnetico & "," & _
                      " Fisico=" & _Fisico & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Bod_Id=" & _Bod_Id.ToString() & _
                      " And    TomaFisica_Id=" & _TomaFisica_Id.ToString() & _
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
    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From TomaFisicaDetalle" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    Bod_Id=" & _Bod_Id.ToString() & _
           " And    TomaFisica_Id=" & _TomaFisica_Id.ToString() & _
           " And     Art_Id='" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _TomaFisica_Id = Tabla.Rows(0).Item("TomaFisica_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Suelto = Tabla.Rows(0).Item("Suelto")
                _FactorConversion = Tabla.Rows(0).Item("FactorConversion")
                _Magnetico = Tabla.Rows(0).Item("Magnetico")
                _Fisico = Tabla.Rows(0).Item("Fisico")
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

            Query = "select * From TomaFisicaDetalle"

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

            Query = "select TomaFisicaDetalle_Id as Numero, Nombre From TomaFisicaDetalle"

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

            Query = "Select a.Art_Id," & _
                    " b.Nombre," & _
                    " a.Fisico" & _
                    " From TomaFisicaDetalle a," & _
                    " Articulo b," & _
                    " TomaFisicaEncabezado c" & _
                    " Where a.Emp_Id = b.Emp_Id" & _
                    " and   a.Art_Id = b.Art_Id" & _
                    " and   a.Emp_Id = c.Emp_Id" & _
                    " and   a.Suc_Id = c.Suc_Id" & _
                    " and   a.Bod_Id = c.Bod_Id" & _
                    " and   a.TomaFisica_Id = c.TomaFisica_Id" & _
                    " and   a.Emp_Id = " & _Emp_Id.ToString & _
                    " and   a.Suc_Id = " & _Suc_Id.ToString & _
                    " and   a.Bod_Id = " & _Bod_Id.ToString & _
                    " and   c.TomaFisica_Id = " & _TomaFisica_Id.ToString & _
                    " and   b.Nombre like '%" & pNombre & "%'" & _
                    " order by b.Nombre asc"

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
    Public Function ListaTomaFisicaDetalle(pSuelto As Integer) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select * From TomaFisicaDetalle" & _
                    " Where Emp_Id = " & _Emp_Id.ToString() & _
                    " And   Suc_Id = " & _Suc_Id.ToString() & _
                    " And   Bod_Id = " & _Bod_Id.ToString() & _
                    " And   TomaFisica_Id = " & _TomaFisica_Id.ToString() & _
                    " And   Suelto = " & pSuelto

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
    Public Function BorraTomaFisicaDetalle() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "Delete TomaFisicaDetalle" & _
               " Where  Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Bod_Id=" & _Bod_Id.ToString() & _
               " And    TomaFisica_Id=" & _TomaFisica_Id.ToString()

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
    Public Function ConsultaArticulo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select a.*, b.Nombre From TomaFisicaDetalle a inner join Articulo b on a.Emp_Id = b.Emp_Id and a.Art_Id = b.Art_Id" & _
           " Where  a.Emp_Id=" & _Emp_Id.ToString() & _
           " And    a.Suc_Id=" & _Suc_Id.ToString() & _
           " And    a.Bod_Id=" & _Bod_Id.ToString() & _
           " And    a.TomaFisica_Id=" & _TomaFisica_Id.ToString() & _
           " And    a.Art_Id='" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _TomaFisica_Id = Tabla.Rows(0).Item("TomaFisica_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Suelto = Tabla.Rows(0).Item("Suelto")
                _FactorConversion = Tabla.Rows(0).Item("FactorConversion")
                _Magnetico = Tabla.Rows(0).Item("Magnetico")
                _Fisico = Tabla.Rows(0).Item("Fisico")
                _Nombre = Tabla.Rows(0).Item("Nombre")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function ActualizaConteo() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.TomaFisicaDetalle " & _
                      " SET Fisico=" & _Fisico & _
                      " Where  Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Bod_Id=" & _Bod_Id.ToString() & _
                      " And    TomaFisica_Id=" & _TomaFisica_Id.ToString() & _
                      " And    Art_Id='" & _Art_Id & "'"

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
    Public Function RebajoVentas() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.TomaFisicaDetalle " & _
                      " SET Fisico=" & _Fisico & _
                      " ,Magnetico=" & _Magnetico & _
                      " Where  Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Bod_Id=" & _Bod_Id.ToString() & _
                      " And    TomaFisica_Id=" & _TomaFisica_Id.ToString() & _
                      " And    Art_Id='" & _Art_Id & "'"

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

    Public Function SumaConteo() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.TomaFisicaDetalle " & _
                      " SET Fisico = Fisico + " & _Fisico & _
                      " Where  Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Bod_Id=" & _Bod_Id.ToString() & _
                      " And    TomaFisica_Id=" & _TomaFisica_Id.ToString() & _
                      " And    Art_Id='" & _Art_Id & "'"

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
