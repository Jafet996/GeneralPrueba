Public Class TArticuloTemporal
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
    Private _Precio As Double
    Private _Suelto As Integer
    Private _CodigoManual As Integer
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
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal Value As Double)
            _Precio = Value
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
    Public Property CodigoManual() As Integer
        Get
            Return _CodigoManual
        End Get
        Set(ByVal Value As Integer)
            _CodigoManual = Value
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
        _Art_Id = ""
        _Nombre = ""
        _Cat_Id = 0
        _SubCat_Id = 0
        _Departamento_Id = 0
        _UnidadMedida_Id = 0
        _FactorConversion = 0
        _ExentoIV = 0
        _Precio = 0.0
        _Suelto = 0
        _CodigoManual = 0
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"

    Public Function ObtenerConsecutivo() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try

            Query = "select ConsecutivoArticulo + 1 as ConsecutivoArticulo From ConsecutivoTemporal"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Art_Id = Tabla.Rows(0).Item("ConsecutivoArticulo").ToString
            Else
                VerificaMensaje("No se encontro el consecutivo del articulo")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()


            If _Art_Id <> "0" Then

                Query = "Delete ArticuloTemporal" & _
                   " Where     Emp_Id=" & _Emp_Id.ToString() & _
                   " And     Art_Id='" & _Art_Id & "'"

                Cn.Ejecutar(Query)
            Else

                VerificaMensaje(ObtenerConsecutivo())

                Query = "update ConsecutivoTemporal set ConsecutivoArticulo = ConsecutivoArticulo + 1"

                Cn.Ejecutar(Query)
            End If



            Query = " Insert into ArticuloTemporal( Emp_Id , Art_Id" &
                   " , Nombre , Cat_Id" &
                   " , SubCat_Id , Departamento_Id" &
                   " , UnidadMedida_Id , FactorConversion" &
                   " , ExentoIV , Precio" &
                   " , Suelto" &
                   " , CodigoManual )" &
                   " Values ( " & _Emp_Id.ToString() & ",'" & _Art_Id & "'" &
                   ",'" & _Nombre & "'" & "," & _Cat_Id.ToString() &
                   "," & _SubCat_Id.ToString() & "," & _Departamento_Id.ToString() &
                   "," & _UnidadMedida_Id.ToString() & "," & _FactorConversion.ToString() &
                   "," & _ExentoIV.ToString() & "," & _Precio.ToString() &
                   "," & _Suelto.ToString() &
                   "," & _CodigoManual.ToString() & ")"

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

            Query = "Delete ArticuloTemporal" &
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
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.ArticuloTemporal " &
                      " SET   Nombre='" & _Nombre & "' " & "," &
                      " Cat_Id=" & _Cat_Id & "," &
                      " SubCat_Id=" & _SubCat_Id & "," &
                      " Departamento_Id=" & _Departamento_Id & "," &
                      " UnidadMedida_Id=" & _UnidadMedida_Id & "," &
                      " FactorConversion=" & _FactorConversion & "," &
                      " ExentoIV=" & _ExentoIV & "," &
                      " Precio=" & _Precio & "," &
                      " Suelto=" & _Suelto & "," &
                      " CodigoManual=" & _CodigoManual &
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
    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From ArticuloTemporal" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And     Art_Id='" & _Art_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Art_Id = Tabla.Rows(0).Item("Art_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Cat_Id = Tabla.Rows(0).Item("Cat_Id")
                _SubCat_Id = Tabla.Rows(0).Item("SubCat_Id")
                _Departamento_Id = Tabla.Rows(0).Item("Departamento_Id")
                _UnidadMedida_Id = Tabla.Rows(0).Item("UnidadMedida_Id")
                _FactorConversion = Tabla.Rows(0).Item("FactorConversion")
                _ExentoIV = Tabla.Rows(0).Item("ExentoIV")
                _Precio = Tabla.Rows(0).Item("Precio")
                _Suelto = Tabla.Rows(0).Item("Suelto")
                _CodigoManual = Tabla.Rows(0).Item("CodigoManual")
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

            Query = "select * From ArticuloTemporal"

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

            Query = "select ArticuloTemporal_Id as Numero, Nombre From ArticuloTemporal"

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
