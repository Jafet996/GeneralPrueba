Imports System.Windows.Forms
Public Class TBodega
    Inherits TBaseClassManager

#Region "Definicion Variables Locales"

    Private _Emp_Id As Integer
    Private _Suc_Id As Integer
    Private _Bod_Id As Integer
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
        _Suc_Id = 0
        _Bod_Id = 0
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

            Query = " Insert into Bodega( Emp_Id , Suc_Id" & _
       " , Bod_Id , Nombre" & _
       " , Activo , UltimaModificacion" & _
       " )" & _
       " Values ( " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & _
       "," & _Bod_Id.ToString() & ",'" & _Nombre & "'" & _
       "," & _Activo.ToString() & ",'" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "')"

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

            Query = "Delete Bodega" & _
               " Where     Emp_Id=" & _Emp_Id.ToString() & _
               " And    Suc_Id=" & _Suc_Id.ToString() & _
               " And    Bod_Id=" & _Bod_Id.ToString()

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

            Query = " Update dbo.Bodega " & _
                      " SET   Nombre='" & _Nombre & "' " & "," & _
                      " Activo=" & _Activo & "," & _
                      " UltimaModificacion='" & Format(_UltimaModificacion, "yyyyMMdd HH:mm:ss") & "'" & _
                      " Where     Emp_Id=" & _Emp_Id.ToString() & _
                      " And    Suc_Id=" & _Suc_Id.ToString() & _
                      " And    Bod_Id=" & _Bod_Id.ToString()

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

            Query = "select * From Bodega" & _
           " Where     Emp_Id=" & _Emp_Id.ToString() & _
           " And    Suc_Id=" & _Suc_Id.ToString() & _
           " And    Bod_Id=" & _Bod_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
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

            Query = "select * From Bodega where Emp_Id = " & _Emp_Id.ToString & IIf(_Suc_Id > 0, " and Suc_Id = " & _Suc_Id.ToString(), "")

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

            Query = "select Bod_Id as Numero, Nombre From Bodega where Emp_Id = " & _Emp_Id.ToString & " and Suc_Id = " & _Suc_Id.ToString

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

    Public Function CreaArbolBodegas(pTreeview As TreeView) As String
        Dim Query As String
        Dim TablaEmpresa As DataTable
        Dim TablaSucursal As DataTable
        Dim TablaBodega As DataTable
        Dim NodoEmpresa As TreeNode
        Dim NodoSucursal As TreeNode
        Dim NodoBodega As TreeNode
        Try
            Cn.Open()

            pTreeview.Nodes.Clear()

            Query = "select Emp_Id, Nombre Nombre From Empresa where Emp_Id = " & _Emp_Id.ToString

            TablaEmpresa = Cn.Seleccionar(Query).Copy

            If Not TablaEmpresa Is Nothing AndAlso TablaEmpresa.Rows.Count > 0 Then
                NodoEmpresa = pTreeview.Nodes.Add(TablaEmpresa.Rows(0).Item("Nombre"))
                NodoEmpresa.Tag = TablaEmpresa.Rows(0).Item("Emp_Id")
                NodoEmpresa.ImageIndex = 0
                NodoEmpresa.SelectedImageIndex = 3

                'Carga las sucursales
                Query = "select Suc_Id, Nombre Nombre From Sucursal where Emp_Id = " & _Emp_Id.ToString & " order by Suc_Id"

                TablaSucursal = Cn.Seleccionar(Query).Copy

                If Not TablaSucursal Is Nothing AndAlso TablaSucursal.Rows.Count > 0 Then

                    For Each FilaSuc As DataRow In TablaSucursal.Rows
                        NodoSucursal = NodoEmpresa.Nodes.Add(FilaSuc.Item("Nombre"))
                        NodoSucursal.Tag = FilaSuc.Item("Suc_Id")
                        NodoSucursal.ImageIndex = 1
                        NodoSucursal.SelectedImageIndex = 3

                        'Carga las Bodegas
                        Query = "select Bod_Id, Nombre Nombre From Bodega where Emp_Id = " & _Emp_Id.ToString & " and Suc_Id = " & FilaSuc.Item("Suc_Id") & "and activo = 1 order by Suc_Id, Bod_Id"

                        TablaBodega = Cn.Seleccionar(Query).Copy

                        If Not TablaBodega Is Nothing AndAlso TablaBodega.Rows.Count > 0 Then
                            For Each FilaBod As DataRow In TablaBodega.Rows
                                NodoBodega = NodoSucursal.Nodes.Add(FilaBod.Item("Nombre"))
                                NodoBodega.Tag = FilaBod.Item("Bod_Id")
                                NodoBodega.ImageIndex = 2
                                NodoBodega.SelectedImageIndex = 3
                            Next
                        End If
                        NodoSucursal.Expand()
                    Next

                    NodoEmpresa.Expand()

                End If 'Sucursales
            End If 'Empresas

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function CreaArbolBodegasConSaldos(pTreeview As TreeView, Art_Id As String) As String
        Dim Query As String
        Dim TablaEmpresa As DataTable
        Dim TablaSucursal As DataTable
        Dim TablaBodega As DataTable
        Dim NodoEmpresa As TreeNode
        Dim NodoSucursal As TreeNode
        Dim NodoBodega As TreeNode
        Try
            Cn.Open()

            pTreeview.Nodes.Clear()

            Query = "select Emp_Id, Nombre Nombre From Empresa where Emp_Id = " & _Emp_Id.ToString

            TablaEmpresa = Cn.Seleccionar(Query).Copy

            If Not TablaEmpresa Is Nothing AndAlso TablaEmpresa.Rows.Count > 0 Then
                NodoEmpresa = pTreeview.Nodes.Add(TablaEmpresa.Rows(0).Item("Nombre"))
                NodoEmpresa.Tag = TablaEmpresa.Rows(0).Item("Emp_Id")
                NodoEmpresa.ImageIndex = 0
                NodoEmpresa.SelectedImageIndex = 3

                'Carga las sucursales
                Query = "select Suc_Id, Nombre Nombre From Sucursal where Emp_Id = " & _Emp_Id.ToString & " order by Suc_Id"

                TablaSucursal = Cn.Seleccionar(Query).Copy

                If Not TablaSucursal Is Nothing AndAlso TablaSucursal.Rows.Count > 0 Then

                    For Each FilaSuc As DataRow In TablaSucursal.Rows
                        NodoSucursal = NodoEmpresa.Nodes.Add(FilaSuc.Item("Nombre"))
                        NodoSucursal.Tag = FilaSuc.Item("Suc_Id")
                        NodoSucursal.ImageIndex = 1
                        NodoSucursal.SelectedImageIndex = 3

                        'Carga las Bodegas
                        Query = "select b.Bod_Id,  concat(b.Nombre, ', SALDO:' , a.Saldo) Nombre
                                from ArticuloBodega a
                                inner join Bodega b on a.Bod_Id = b.Bod_Id
                                where a.Art_Id = '" & Art_Id & "'
                                and b.Activo = 1
                                and a.Emp_Id = " & _Emp_Id.ToString & "
                                and a.Suc_Id = " & FilaSuc.Item("Suc_Id") & "
                                order by a.Suc_Id, a.Bod_Id"


                        TablaBodega = Cn.Seleccionar(Query).Copy

                        If Not TablaBodega Is Nothing AndAlso TablaBodega.Rows.Count > 0 Then
                            For Each FilaBod As DataRow In TablaBodega.Rows
                                NodoBodega = NodoSucursal.Nodes.Add(FilaBod.Item("Nombre"))
                                NodoBodega.Tag = FilaBod.Item("Bod_Id")
                                NodoBodega.ImageIndex = 2
                                NodoBodega.SelectedImageIndex = 3
                            Next
                        End If
                        NodoSucursal.Expand()
                    Next

                    NodoEmpresa.Expand()

                End If 'Sucursales
            End If 'Empresas

            Return ""

        Catch ex As Exception
            Return ex.Message
        Finally
            Cn.Close()
        End Try
    End Function

    Public Function LoadComboBoxConteoFisico(pCombo As System.Windows.Forms.ComboBox) As String
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

    Public Function ActualizaPrecioArticuloProforma(pArt_Id As String, pPrecio_Id As Integer) As String
        Dim Query As String = ""
        Try
            Cn.Open()

            Cn.BeginTransaction()

            Query = "exec ActualizaPrecioArticuloProforma " & _Emp_Id.ToString() & "," & _Suc_Id.ToString() & "," & _Bod_Id.ToString() & ",'" & pArt_Id & "'," & pPrecio_Id.ToString()

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

    Public Function GetBodegaApartados() As String
        Dim Query As String
        Dim Tabla As DataTable
        Try
            Cn.Open()

            Query = "select * From Bodega" &
           " Where     Emp_Id = " & _Emp_Id.ToString() &
           " And    Suc_Id = " & _Suc_Id.ToString() &
           " And    Apartados = " & _Bod_Id.ToString()

            Tabla = Cn.Seleccionar(Query).Copy

            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then
                _Emp_Id = Tabla.Rows(0).Item("Emp_Id")
                _Suc_Id = Tabla.Rows(0).Item("Suc_Id")
                _Bod_Id = Tabla.Rows(0).Item("Bod_Id")
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


#End Region
End Class
