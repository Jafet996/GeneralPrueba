﻿Public Class TTecnico
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Tecnico_Id As Integer
    Private _Nombre As String
    Private _Activo As Integer
    Private _UltimaModificacion As DateTime
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
    Public Property Tecnico_Id() As Integer
        Get
            Return _Tecnico_Id
        End Get
        Set(ByVal Value As Integer)
            _Tecnico_Id = Value
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
        _Tecnico_Id = 0
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

            Query = " Insert into Tecnico( Emp_Id , Tecnico_Id" &
                   " , Nombre , Activo" &
                   " , UltimaModificacion )" &
                   " Values ( " & _Emp_Id.ToString() & "," & _Tecnico_Id.ToString() &
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

            Query = "Delete Tecnico" &
               " Where     Emp_Id=" & _Emp_Id.ToString() &
               " And    Tecnico_Id=" & _Tecnico_Id.ToString()

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

            Query = " Update dbo.Tecnico " &
                      " SET   Nombre='" & _Nombre & "' " & "," &
                      " Activo=" & _Activo & "," &
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" &
                      " Where     Emp_Id=" & _Emp_Id.ToString() &
                      " And    Tecnico_Id=" & _Tecnico_Id.ToString()

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

            Query = "select * From Tecnico" &
           " Where     Emp_Id=" & _Emp_Id.ToString() &
           " And    Tecnico_Id=" & _Tecnico_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Tecnico_Id = Tabla.Rows(0).Item("Tecnico_Id")
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

            Query = "select * From Tecnico"

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

            Query = "select Tecnico_Id as Numero, Nombre From Tecnico"

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
    Public Function ListaMantenimiento(pNombre As String) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Tecnico_Id as Codigo, Nombre From Tecnico where Emp_Id = " & _Emp_Id.ToString()

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

            Query = "select isnull(max(Tecnico_Id),0) + 1 From Tecnico Where Emp_Id=" & _Emp_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Tecnico_Id = Tabla.Rows(0).Item(0)
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
