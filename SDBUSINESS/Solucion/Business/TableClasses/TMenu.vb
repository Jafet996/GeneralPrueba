﻿Imports System.Windows.Forms
Public Class TMenu
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Modulo_Id As Integer
    Private _Menu_Id As String
    Private _MenuPadre_Id As String
    Private _Nombre As String
    Private _Orden As Integer
    Private _Data As DataSet

#End Region

#Region "Definicion de propiedades"

    Public Property Modulo_Id() As Integer
        Get
            Return _Modulo_Id
        End Get
        Set(ByVal Value As Integer)
            _Modulo_Id = Value
        End Set
    End Property
    Public Property Menu_Id() As String
        Get
            Return _Menu_Id
        End Get
        Set(ByVal Value As String)
            _Menu_Id = Value
        End Set
    End Property
    Public Property MenuPadre_Id() As String
        Get
            Return _MenuPadre_Id
        End Get
        Set(ByVal Value As String)
            _MenuPadre_Id = Value
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
    Public Property Orden() As Integer
        Get
            Return _Orden
        End Get
        Set(ByVal Value As Integer)
            _Orden = Value
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
    Public Sub New(pModulo_Id As Modulos)
        MyBase.New()
        Inicializa()
        _Modulo_Id = pModulo_Id
    End Sub
    Public Sub New(pModulo_Id As Modulos, ByVal pCnStr As String)
        MyBase.New(pCnStr)
        _Modulo_Id = pModulo_Id
        Inicializa()
    End Sub
#End Region
#Region "Metodos Privados"
    Private Sub Inicializa()
        _Modulo_Id = 0
        _Menu_Id = ""
        _MenuPadre_Id = ""
        _Nombre = ""
        _Orden = 0
        _Data = New DataSet
    End Sub
#End Region
#Region "Definicion metodos publicos"
    Public Overrides Function Insert() As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = " Insert into Menu( Modulo_Id , Menu_Id" & _
                   " , MenuPadre_Id , Nombre" & _
                   " , Orden )" & _
                   " Values ( " & _Modulo_Id.ToString() & ",'" & _Menu_Id & "'" & _
                   ",'" & _MenuPadre_Id & "'" & ",'" & _Nombre & "'" & _
                   "," & _Orden.ToString() & ")"

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

            Query = "Delete Menu" & _
               " Where     Modulo_Id=" & _Modulo_Id.ToString()

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

            Query = " Update dbo.Menu " & _
                      " SET   MenuPadre_Id='" & _MenuPadre_Id & "' " & "," & _
                      " Nombre='" & _Nombre & "'" & "," & _
                      " Orden=" & _Orden & _
                      " Where     Modulo_Id=" & _Modulo_Id.ToString() & _
                      " And     Menu_Id='" & _Menu_Id & "'"

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

            Query = "select * From Menu" & _
           " Where     Modulo_Id=" & _Modulo_Id.ToString() & _
           " And     Menu_Id='" & _Menu_Id & "'"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Modulo_Id = Tabla.Rows(0).Item("Modulo_Id")
                _Menu_Id = Tabla.Rows(0).Item("Menu_Id")
                _MenuPadre_Id = Tabla.Rows(0).Item("MenuPadre_Id")
                _Nombre = Tabla.Rows(0).Item("Nombre")
                _Orden = Tabla.Rows(0).Item("Orden")
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

            Query = "select * From Menu"

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

            Query = "select Menu_Id as Numero, Nombre From Menu"

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

    Public Function CreaArbolMenu(pArbol As TreeView) As String
        Dim Query As String
        Dim Tabla As DataTable
        Dim Nodo As TreeNode = Nothing
        Dim NodoPapa As TreeNode() = Nothing
        Try
            Cn.Open()

            Query = "Select * From Menu Where Modulo_Id=" & _Modulo_Id.ToString() & "Order By Orden Asc"

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                For Each Fila As DataRow In Tabla.Rows
                    Nodo = New TreeNode
                    Nodo.Name = Fila("Menu_Id")
                    Nodo.Text = Fila("Nombre")
                    Nodo.SelectedImageIndex = 2

                    If Fila("MenuPadre_Id") = "" Then
                        pArbol.Nodes.Add(Nodo)
                        Nodo.ImageIndex = 0
                    Else
                        NodoPapa = pArbol.Nodes.Find(Fila("MenuPadre_Id"), True)
                        If Not NodoPapa Is Nothing Then
                            NodoPapa(0).Nodes.Add(Nodo)
                            Nodo.ImageIndex = 1
                        End If
                    End If
                Next
                pArbol.ExpandAll()
            End If

            'If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
            '    _Modulo_Id = Tabla.Rows(0).Item("Modulo_Id")
            '    _Menu_Id = Tabla.Rows(0).Item("Menu_Id")
            '    _MenuPadre_Id = Tabla.Rows(0).Item("MenuPadre_Id")
            '    _Nombre = Tabla.Rows(0).Item("Nombre")
            '    _Orden = Tabla.Rows(0).Item("Orden")
            'End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function


#End Region
End Class
