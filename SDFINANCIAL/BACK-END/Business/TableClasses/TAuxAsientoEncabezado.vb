Public Class TAuxAsientoEncabezado
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Asiento_Id As Long
    Private _Annio As Integer
    Private _Mes As Integer
    Private _Fecha As Datetime
    Private _Tipo_Id As Integer
    Private _Comentario As String
    Private _Debitos As Double
    Private _Creditos As Double
    Private _Usuario_Id As String
    Private _Origen_Id As Integer
    Private _MAC_Address As String
    Private _ListaDetalle As New List(Of TAuxAsientoDetalle)
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
    Public Property Asiento_Id() As Long
        Get
            Return _Asiento_Id
        End Get
        Set(ByVal Value As Long)
            _Asiento_Id = Value
        End Set
    End Property
    Public Property Annio() As Integer
        Get
            Return _Annio
        End Get
        Set(ByVal Value As Integer)
            _Annio = Value
        End Set
    End Property
    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal Value As Integer)
            _Mes = Value
        End Set
    End Property
    Public Property Fecha() As Datetime
        Get
            Return _Fecha
        End Get
        Set(ByVal Value As Datetime)
            _Fecha = Value
        End Set
    End Property
    Public Property Tipo_Id() As Integer
        Get
            Return _Tipo_Id
        End Get
        Set(ByVal Value As Integer)
            _Tipo_Id = Value
        End Set
    End Property
    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(ByVal Value As String)
            _Comentario = Value
        End Set
    End Property
    Public Property Debitos() As Double
        Get
            Return _Debitos
        End Get
        Set(ByVal Value As Double)
            _Debitos = Value
        End Set
    End Property
    Public Property Creditos() As Double
        Get
            Return _Creditos
        End Get
        Set(ByVal Value As Double)
            _Creditos = Value
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
    Public Property Origen_Id() As Integer
        Get
            Return _Origen_Id
        End Get
        Set(ByVal Value As Integer)
            _Origen_Id = Value
        End Set
    End Property
    Public Property MAC_Address() As String
        Get
            Return _MAC_Address
        End Get
        Set(ByVal Value As String)
            _MAC_Address = Value
        End Set
    End Property
    Public Property ListaDetalle As List(Of TAuxAsientoDetalle)
        Get
            Return _ListaDetalle
        End Get
        Set(value As List(Of TAuxAsientoDetalle))
            _ListaDetalle = value
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
        _Asiento_Id = 0
        _Annio = 0
        _Mes = 0
        _Fecha = CDate("1900/01/01")
        _Tipo_Id = 0
        _Comentario = ""
        _Debitos = 0.0
        _Creditos = 0.0
        _Usuario_Id = ""
        _Origen_Id = 0
        _MAC_Address = ""
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Dim Tabla As New DataTable

        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " exec CreaAuxAsientoEncabezado " & _Emp_Id.ToString & "," & _Annio.ToString & _
                    "," & _Mes.ToString & ",'" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'," & _Tipo_Id.ToString & _
                    ",'" & _Comentario & "'" & "," & _Debitos.ToString & "," & _Creditos.ToString & ",'" & _Usuario_Id & "'" & _
                    "," & _Origen_Id.ToString & ",'" & _MAC_Address & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing OrElse Tabla.Rows.Count > 0 Then
                _Asiento_Id = Tabla.Rows(0).Item("Asiento_Id")
            End If

            For Each Item As TAuxAsientoDetalle In _ListaDetalle
                Query = " exec CreaAuxAsientoDetalle " & Item.Emp_Id.ToString & "," & _Asiento_Id.ToString & _
                        "," & Item.Linea_Id.ToString & ",'" & Format(Item.Fecha, "yyyyMMdd HH:mm:ss") & "'" & _
                        ",'" & Item.Moneda.ToString & "'," & Item.CC_Id.ToString & ",'" & Item.Cuenta_Id & "'" & _
                        ",'" & Item.Tipo.ToString & "'," & Item.Monto.ToString & "," & Item.MontoDolares.ToString & _
                        "," & Item.TipoCambio.ToString & ",'" & Item.Referencia & "','" & Item.Descripcion & "'"

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

            Query = "exec BitacoraAuxAsientoEncabezado " & _Emp_Id.ToString & "," & _Asiento_Id.ToString & ",'" & _Usuario_Id & "'"

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

            Query = " Update AuxAsientoEncabezado " & _
                    " SET    Annio = " & _Annio.ToString & "," & _
                    " Mes = " & _Mes & "," & _
                    " Fecha = '" & Format(_Fecha, "yyyyMMdd HH:mm:ss") & "'" & "," & _
                    " Tipo_Id = " & _Tipo_Id & "," & _
                    " Comentario = '" & _Comentario & "'" & "," & _
                    " Debitos = " & _Debitos & "," & _
                    " Creditos = " & _Creditos & "," & _
                    " Usuario_Id = '" & _Usuario_Id & "'" & "," & _
                    " Origen_Id = " & _Origen_Id & "," & _
                    " MAC_Address = '" & _MAC_Address & "'" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Asiento_Id = " & _Asiento_Id.ToString

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

            Query = "select * From AuxAsientoEncabezado" & _
                    " Where Emp_Id = " & _Emp_Id.ToString & _
                    " And   Asiento_Id = " & _Asiento_Id.ToString

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
    Public Overrides Function List() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select * From AuxAsientoEncabezado"

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
    Public Overrides Function LoadComboBox() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select AuxAsientoEncabezado_Id as Numero, Nombre From AuxAsientoEncabezado"

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
    Public Overrides Function ListMant(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select AuxAsientoEncabezado_Id as Codigo, Nombre From AuxAsientoEncabezado" & _
                    " where Emp_Id = " & _Emp_Id.ToString

            If pNombre.Trim <> "" Then
                Query += " and Nombre Like '%" & pNombre & "%'"
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
    Public Overrides Function NextOne() As String
        Dim Query As String
        Dim Tabla As DataTable

        Try
            Cn.Open()

            Query = "select IsNull(MAX(AuxAsientoEncabezado_Id),0) + 1 as AuxAsientoEncabezado_Id From AuxAsientoEncabezado" & _
                    " Where Emp_Id = " & _Emp_Id.ToString

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