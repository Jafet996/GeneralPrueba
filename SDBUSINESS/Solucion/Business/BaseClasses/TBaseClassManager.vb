Imports System.Windows.Forms
Public MustInherit Class TBaseClassManager
#Region "Variables"
    Private _Cn As Connection.TConnectionManager
    Private _MsgError As String
#End Region
#Region "Propiedades"
    Public Property Cn() As Connection.TConnectionManager
        Get
            Return _Cn
        End Get
        Set(ByVal value As Connection.TConnectionManager)
            _Cn = value
        End Set
    End Property
    Public Property MsgError() As String
        Get
            Return _MsgError
        End Get
        Set(ByVal value As String)
            _MsgError = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
        _Cn = New Connection.TConnectionManager(GetConnectionString())
        _MsgError = ""
    End Sub
    Public Sub New(ByVal pCnStr As String)
        _Cn = New Connection.TConnectionManager(pCnStr)
        _MsgError = ""
    End Sub
#End Region
#Region "Metodos Publicos"
    Public Sub VerificaMsgError()
        If _MsgError.Trim <> "" Then
            Throw New Exception(_MsgError)
        End If
    End Sub
#End Region

#Region "Metodos Publicos para Sobreescribir"
    'Protected MustOverride Function GetNext_Identity() As Long
    'Protected MustOverride Sub Record_Load()
    Public MustOverride Function Insert() As String
    Public MustOverride Function Delete() As String
    Public MustOverride Function Modify() As String
    Public MustOverride Function ListKey() As String
    Public MustOverride Function List() As String
    Public MustOverride Function LoadComboBox(pCombo As ComboBox) As String
#End Region


End Class
