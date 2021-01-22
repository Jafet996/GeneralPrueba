Public Class TCategoria
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Cat_Id As Integer
    Private _Nombre As String
    Private _Activo As Integer
    Private _CantidadBotones As Integer
    Private _BusquedaRapida As Integer
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
    Public Property Cat_Id() As Integer
        Get
            Return _Cat_Id
        End Get
        Set(ByVal Value As Integer)
            _Cat_Id = Value
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
    Public Property UltimaModificacion() As Datetime
        Get
            Return _UltimaModificacion
        End Get
        Set(ByVal Value As Datetime)
            _UltimaModificacion = Value
        End Set
    End Property
    Public Property BusquedaRapida() As Integer
        Get
            Return _BusquedaRapida
        End Get
        Set(ByVal Value As Integer)
            _BusquedaRapida = Value
        End Set
    End Property
    Public Property CantidadBotones As Integer
        Get
            Return _CantidadBotones
        End Get
        Set(value As Integer)
            _CantidadBotones = value
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
        _Cat_Id = 0
        _Nombre = ""
        _Activo = 0
        _UltimaModificacion = CDate("1900/01/01")
        _BusquedaRapida = 0
        _CantidadBotones = 0
        _Data = New Dataset
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Categoria( Emp_Id , Cat_Id" & _
                " , Nombre , Activo" & _
                " , BusquedaRapida , UltimaModificacion)" & _
                " Values ( " & _Emp_Id.ToString() & "," & _Cat_Id.ToString() & _
                ",'" & _Nombre & "'" & "," & _Activo.ToString() & _
                "," & _BusquedaRapida.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "')"

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

            Query = "Delete Categoria" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Cat_Id=" & _Cat_Id.ToString()

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

            Query = " Update dbo.Categoria " & _
                      " SET   Nombre='" & _Nombre & "' " & "," & _
                      " Activo=" & _Activo & "," & _
                      " BusquedaRapida=" & _BusquedaRapida & "," & _
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Cat_Id=" & _Cat_Id.ToString()

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

            Query = "select * From Categoria" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Cat_Id=" & _Cat_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Cat_Id = Tabla.Rows(0).Item("Cat_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Activo = Tabla.Rows(0).Item("Activo")
                _BusquedaRapida = Tabla.Rows(0).Item("BusquedaRapida")
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

            Query = "select Cat_Id as Codigo, Nombre From Categoria where Emp_Id = " & _Emp_Id.ToString()

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

            Query = "select Cat_Id as Numero, Nombre From Categoria where Emp_Id = " & _Emp_Id.ToString & " order by Nombre asc"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing Then
                If Not Tabla.Rows Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                    _Cat_Id = Tabla.Rows(0).Item("Numero")
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
    Public Function Siguiente() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select isnull(max(Cat_Id),0) + 1 From Categoria Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Cat_Id = Tabla.Rows(0).Item(0)
            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function LlenaArreglo(ByRef BotonesCategoria() As TBoton) As String
        Dim query As String
        Dim BotonId As Long = 0
        Dim Tabla As DataTable
        Try
            _CantidadBotones = 0

            Cn.Open()

            query = " select * from  Categoria where Emp_Id = " & _Emp_Id & " and Activo = 1 and BusquedaRapida = 1"

            Tabla = Cn.Seleccionar(query).Copy

            If Not Tabla Is Nothing Then
                For Each Fila As DataRow In Tabla.Rows
                    ReDim Preserve BotonesCategoria(BotonId)

                    BotonesCategoria(BotonId) = New TBoton
                    With BotonesCategoria(BotonId)
                        .Name = coNombreCategoriaPrefijo & "_" & BotonId.ToString
                        .Tag = Fila("Cat_Id").ToString()
                        .Text = Fila("Nombre")
                        .TipoBoton = coTipoBotonArticulo
                        .BackColor = Drawing.Color.SteelBlue

                    End With
                    _CantidadBotones = CantidadBotones + 1

                    BotonId = BotonId + 1
                Next
            End If




            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function
    Public Function ListaCompleta() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()


            Query = "select Emp_Id,Cat_Id,Nombre,Activo,BusquedaRapida,UltimaModificacion From Categoria where Emp_Id = " & _Emp_Id.ToString() & " and Activo = 1 order by Nombre asc"

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
