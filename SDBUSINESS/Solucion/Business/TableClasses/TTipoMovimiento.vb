Public Class TTipoMovimiento
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _TipoMov_Id As Integer
    Private _Nombre As String
    Private _Suma As Integer
    'Private _Traslado As Integer
    Private _EntradaMercaderia As Integer
    Private _Activo As Integer
    Private _UltimaModificacion As Datetime
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
    Public Property TipoMov_Id() As Integer
        Get
            Return _TipoMov_Id
        End Get
        Set(ByVal Value As Integer)
            _TipoMov_Id = Value
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
    Public Property Suma() As Integer
        Get
            Return _Suma
        End Get
        Set(ByVal Value As Integer)
            _Suma = Value
        End Set
    End Property
    'Public Property Traslado() As Integer
    '    Get
    '        Return _Traslado
    '    End Get
    '    Set(ByVal Value As Integer)
    '        _Traslado = Value
    '    End Set
    'End Property
    Public Property EntradaMercaderia() As Integer
        Get
            Return _EntradaMercaderia
        End Get
        Set(ByVal Value As Integer)
            _EntradaMercaderia = Value
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
        _TipoMov_Id = 0
        _Nombre = ""
        _Suma = 0
        '        _Traslado = 0
        _EntradaMercaderia = 0
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()


            query = " Insert into TipoMovimiento( Emp_Id , TipoMov_Id" & _
                               " , Nombre , Suma" & _
                               " , EntradaMercaderia , Activo" & _
                               " , UltimaModificacion )" & _
                               " Values ( " & _Emp_Id.ToString() & "," & _TipoMov_Id.ToString() & _
                               ",'" & _Nombre & "'" & "," & _Suma.ToString() & _
                               "," & _EntradaMercaderia.ToString() & "," & _Activo.ToString() & _
                               ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & ")"
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

            query = "Delete TipoMovimiento" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    TipoMov_Id=" & _TipoMov_Id.ToString()

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


            Query = " Update dbo.TipoMovimiento " & _
                      " SET   Nombre='" & _Nombre & "' " & "," & _
                      " Suma=" & _Suma & "," & _
                      " EntradaMercaderia=" & _EntradaMercaderia & "," & _
                      " Activo=" & _Activo & "," & _
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    TipoMov_Id=" & _TipoMov_Id.ToString()

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

            Query = "select * From TipoMovimiento" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    TipoMov_Id=" & _TipoMov_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _TipoMov_Id = Tabla.Rows(0).Item("TipoMov_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Suma = Tabla.Rows(0).Item("Suma")
                _EntradaMercaderia = Tabla.Rows(0).Item("EntradaMercaderia")
                _Activo = Tabla.Rows(0).Item("Activo")
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

            Query = "select * From TipoMovimiento"

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

            Query = "select TipoMovimiento_Id as Numero, Nombre From TipoMovimiento where Emp_Id = " & _Emp_Id.ToString & " and Activo = 1"

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
    Public Function LoadComboBoxTipo(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select TipoMov_Id as Numero, Nombre From TipoMovimiento where Emp_Id = " & _Emp_Id.ToString & " and Activo = 1"

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
