Imports System.Windows.Forms

Public Class TInfoExoneracion
    Inherits TBaseClassManager
    Private _TipoDocumento As String
    Private _NumeroDocumento As String
    Private _NombreInstitucion As String
    Private _FechaEmision As DateTime
    Private _PorcExoneracion As Integer

    Public Property TipoDocumento As String
        Get
            Return _TipoDocumento
        End Get
        Set(value As String)
            _TipoDocumento = value
        End Set
    End Property
    Public Property NumeroDocumento As String
        Get
            Return _NumeroDocumento
        End Get
        Set(value As String)
            _NumeroDocumento = value
        End Set
    End Property
    Public Property NombreInstitucion As String
        Get
            Return _NombreInstitucion
        End Get
        Set(value As String)
            _NombreInstitucion = value
        End Set
    End Property
    Public Property FechaEmision As DateTime
        Get
            Return _FechaEmision
        End Get
        Set(value As DateTime)
            _FechaEmision = value
        End Set
    End Property
    Public Property PorcExoneracion As Integer
        Get
            Return _PorcExoneracion
        End Get
        Set(value As Integer)
            _PorcExoneracion = value
        End Set
    End Property

    Public Sub New()
        _TipoDocumento = String.Empty
        _NumeroDocumento = String.Empty
        _NombreInstitucion = String.Empty
        _FechaEmision = "1900-01-01"
        _PorcExoneracion = 0
    End Sub

    Public Sub New(pCnStr As String)
        MyBase.New(pCnStr)
    End Sub

    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select Codigo_Id as Numero, Nombre From TipoExoneracion"

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

    Public Overrides Function Insert() As String
        Return ""
    End Function

    Public Overrides Function Delete() As String
        Return ""
    End Function

    Public Overrides Function Modify() As String
        Return ""
    End Function

    Public Overrides Function ListKey() As String
        Return ""
    End Function

    Public Overrides Function List() As String
        Return ""
    End Function


End Class
