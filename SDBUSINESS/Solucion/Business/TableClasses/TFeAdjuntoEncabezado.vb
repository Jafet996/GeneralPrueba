Public Class TFeAdjuntoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Adjunto_Id As Integer
    Private _Nombre As String
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
    Private _Valor_Id As Integer
    Private _Etiqueta As String
    Private _Valor As String

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
    Public Property Adjunto_Id() As Integer
        Get
            Return _Adjunto_Id
        End Get
        Set(ByVal Value As Integer)
            _Adjunto_Id = Value
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
    Public Property UltimaModificacion() As DateTime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As DateTime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public Property Valor_Id() As Integer
        Get
            Return _Valor_Id
        End Get
        Set(ByVal Value As Integer)
            _Valor_Id = Value
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
        _Adjunto_Id = 0
        _Nombre = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into FeAdjuntoEncabezado( Emp_Id , Adjunto_Id" &
                   " , Nombre , Activo" &
                   " , UltimaModificacion )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Adjunto_Id.ToString() &
                   ",'" & _Nombre & "'" & "," & _Activo.ToString() &
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

            Query = "Delete FeAdjuntoEncabezado" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Adjunto_Id=" & _Adjunto_Id.ToString()

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

            Query = " Update dbo.FeAdjuntoEncabezado " &
                      " SET   Nombre='" & _Nombre & "' " & "," &
                      " Activo=" & _Activo & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Adjunto_Id=" & _Adjunto_Id.ToString()

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

            Query = "select * From FeAdjuntoEncabezado" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Adjunto_Id=" & _Adjunto_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Adjunto_Id = Tabla.Rows(0).Item("Adjunto_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
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

            Query = "select * From FeAdjuntoEncabezado"

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

            Query = "select Adjunto_Id as Numero, Nombre From FeAdjuntoEncabezado"

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
    Public Function CargaAdjuntos() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From FeAdjuntoDetalle" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Adjunto_Id=" & _Adjunto_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Valor_Id = Tabla.Rows(0).Item("Valor_Id")
                _Etiqueta = Tabla.Rows(0).Item("Etiqueta")
                _Valor = Tabla.Rows(0).Item("Valor")
            End If


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

    Public Function ActulizaAdjuntos(pValor_Id As String, pValor As String) As String
        Dim Query As String
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "update FeAdjuntoDetalle" &
                    " set Valor = '" & pValor.ToString() &
                    "' where Emp_Id = " & Emp_Id.ToString() &
                    " And Adjunto_Id = " & _Adjunto_Id.ToString() &
                    " And Valor_Id = " & pValor_Id.ToString()

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
