Public Class TTomaFisicaEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Bod_Id As Integer
    Private _TomaFisica_Id As Integer
    Private _FechaInicio As Datetime
    Private _FechaFinal As Datetime
    Private _Usuario_Id As String
    Private _Activo As Integer
    Private _RebajoAutomaticoAplicado As Boolean
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
    Public Property FechaInicio() As Datetime
        Get
            Return _FechaInicio
        End Get
        Set(ByVal Value As Datetime)
            _FechaInicio = Value
        End Set
    End Property
    Public Property FechaFinal() As Datetime
        Get
            Return _FechaFinal
        End Get
        Set(ByVal Value As Datetime)
            _FechaFinal = Value
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
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal Value As Integer)
            _Activo = Value
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

    Public Property RebajoAutomaticoAplicado() As Boolean
        Get
            Return _RebajoAutomaticoAplicado
        End Get
        Set(ByVal value As Boolean)
            _RebajoAutomaticoAplicado = value
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
        _Suc_Id = 0
        _Bod_Id = 0
        _TomaFisica_Id = 0
        _FechaInicio = CDate("1900/01/01")
        _FechaFinal = CDate("1900/01/01")
        _Usuario_Id = ""
        _Activo = 0
        _Data = New Dataset
    End Sub
#End Region

#Region "Definicion metodos publicos"
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(TomaFisica_Id),0) + 1 From TomaFisicaEncabezado " & _
                    " Where Emp_Id = " & _Emp_Id.ToString() & _
                    " and   Suc_Id = " & _Suc_Id.ToString() & _
                    " and   Bod_Id = " & _Bod_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _TomaFisica_Id = Tabla.Rows(0).Item(0)
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
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into TomaFisicaEncabezado( Emp_Id , Suc_Id" &
                    " , Bod_Id , TomaFisica_Id" &
                    " , FechaInicio , FechaFinal" &
                    " , Usuario_Id , Activo,RebajoAutomaticoAplicado" &
                    " )" &
                    " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() &
                    "," & _Bod_Id.ToString() & "," & _TomaFisica_Id.ToString() &
                    ",'" & Format(_FechaInicio, "yyyyMMdd HH:mm:ss") & "'" & ",'" & Format(_FechaFinal, "yyyyMMdd HH:mm:ss") & "'" &
                    ",'" & _Usuario_Id & "'" & "," & _Activo.ToString() & "," & _RebajoAutomaticoAplicado & ")"

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

            Query = "Delete TomaFisicaEncabezado" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
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
    Public Overrides Function Modify() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Update dbo.TomaFisicaEncabezado " &
                    " SET    FechaInicio='" & Format(_FechaInicio, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " FechaFinal='" & Format(_FechaFinal, "yyyyMMdd HH:mm:ss") & "'" & "," &
                    " Usuario_Id='" & _Usuario_Id & "'" & "," &
                    " Activo=" & _Activo & "," &
                    "RebajoAutomaticoAplicado" & _RebajoAutomaticoAplicado &
                    " Where     Emp_Id=" & _Emp_Id.ToString() &
                    " And    Suc_Id=" & _Suc_Id.ToString() &
                    " And    Bod_Id=" & _Bod_Id.ToString() &
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
    Public Overrides Function ListKey() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From TomaFisicaEncabezado" & _
                    " Where     Emp_Id=" & _Emp_Id.ToString() & _
                    " And    Suc_Id=" & _Suc_Id.ToString() & _
                    " And    Bod_Id=" & _Bod_Id.ToString() & _
                    " And    TomaFisica_Id=" & _TomaFisica_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _TomaFisica_Id = Tabla.Rows(0).Item("TomaFisica_Id")
                _FechaInicio = Tabla.Rows(0).Item("FechaInicio")
                _FechaFinal = Tabla.Rows(0).Item("FechaFinal")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Activo = Tabla.Rows(0).Item("Activo")
                _RebajoAutomaticoAplicado = Tabla.Rows(0).Item("RebajoAutomaticoAplicado")
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

            Query = "select * From TomaFisicaEncabezado"

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

            Query = "Select t.TomaFisica_Id as Numero, (CAST ( FORMAT( t.FechaFinal , 'dd/MM/yyyy', 'en-US' )AS varchar(20) ))  as Nombre
                     From TomaFisicaEncabezado t inner join Bodega b on t.Bod_Id = b.Bod_Id and t.Emp_Id = b.Emp_Id and t.Suc_id = b.Suc_Id
                     Where t.Emp_Id = " & _Emp_Id.ToString() &
                     "And t.Suc_Id = " & _Suc_Id.ToString() &
                     "And t.Activo = 0"

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

    Public Function VerificaTomaFisicaActiva() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "Select * From TomaFisicaEncabezado" &
                    " Where Emp_Id = " & _Emp_Id.ToString() &
                    " And   Suc_Id = " & _Suc_Id.ToString() &
                    " And   Bod_Id = " & _Bod_Id.ToString() &
                    " And   Activo = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _TomaFisica_Id = Tabla.Rows(0).Item("TomaFisica_Id")
                _FechaInicio = Tabla.Rows(0).Item("FechaInicio")
                _FechaFinal = Tabla.Rows(0).Item("FechaFinal")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Activo = Tabla.Rows(0).Item("Activo")
                _RebajoAutomaticoAplicado = Tabla.Rows(0).Item("RebajoAutomaticoAplicado")
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function VerificaRebajoVentasAutomatico() As Boolean
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "Select * From TomaFisicaEncabezado" &
                    " Where Emp_Id = " & _Emp_Id.ToString() &
                    " And   Suc_Id = " & _Suc_Id.ToString() &
                    " And   Bod_Id = " & _Bod_Id.ToString() &
                    " And   Activo = 1"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
                _TomaFisica_Id = Tabla.Rows(0).Item("TomaFisica_Id")
                _FechaInicio = Tabla.Rows(0).Item("FechaInicio")
                _FechaFinal = Tabla.Rows(0).Item("FechaFinal")
                _Usuario_Id = Tabla.Rows(0).Item("Usuario_Id")
                _Activo = Tabla.Rows(0).Item("Activo")
                _RebajoAutomaticoAplicado = Tabla.Rows(0).Item("RebajoAutomaticoAplicado")
            End If

            Return _RebajoAutomaticoAplicado

        Catch ex As Exception
            Throw ex
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function VerificaTomaFisicaActivaTodas() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "Select * From TomaFisicaEncabezado" & _
                    " Where Emp_Id = " & _Emp_Id.ToString() & _
                    " And   Suc_Id = " & _Suc_Id.ToString() & _
                    " And   Activo = 1"

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
    Public Function RptDiferenciasTomaFisica(pMonto As Double, pCantidad As Double) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptDiferenciasTomaFisica " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() & _
                    "," & _TomaFisica_Id.ToString() & "," & pMonto.ToString() & "," & pCantidad.ToString()

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
    Public Function BorraTomaFisica() As String
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

            Query = "Delete TomaFisicaEncabezado" & _
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

    Public Function CreaTomaFisica() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Query = "exec CreaTomaFisica " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() & ",'" & _Usuario_Id & "'"

            Cn.Ejecutar(Query)

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function


    Public Function AplicaTomaFisica() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Query = "exec AplicaTomaFisica " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() & "," & _TomaFisica_Id.ToString() & ",'" & _Usuario_Id & "'"

            Cn.Ejecutar(Query)

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function AplicaRebajoAutomatico() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Query = "exec AjusteVentasComprasTomaFisica " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() & "," & _TomaFisica_Id.ToString()

            Cn.Ejecutar(Query)

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function


    Public Function LoadComboBoxBodegaTomaFisica(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "Select a.Bod_Id as Numero," &
                    " b.Nombre" &
                    " From TomaFisicaEncabezado a" &
                    " ,Bodega b" &
                    " where a.Emp_Id = b.Emp_Id" &
                    " and   a.Suc_Id = b.Suc_Id" &
                    " and   a.Bod_Id = b.Bod_Id" &
                    " and   a.Emp_Id = " & _Emp_Id.ToString &
                    " and   a.Suc_Id = " & _Suc_Id.ToString &
                    " and   a.Activo = 1"

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

    Public Function RptTomaFisicaResultado() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "exec RptTomaFisicaResultado " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() &
                    "," & _TomaFisica_Id.ToString()

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