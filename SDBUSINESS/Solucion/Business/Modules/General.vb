Imports Microsoft.Win32
Imports System.Windows.Forms
Imports System.Net
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Threading
Imports System.Xml

'Imports SMSManagement
Public Module General

    Public Function GetReferenciaCxC(pSuc_Id As Integer, pCaja_Id As Integer, pTipoDoc_Id As Integer, pDocumento_Id As Long)
        Dim DocumentoSTR As String
        DocumentoSTR = pSuc_Id.ToString + pCaja_Id.ToString + pTipoDoc_Id.ToString + StrDup(7 - pDocumento_Id.ToString.Length, "0") + pDocumento_Id.ToString

        Return DocumentoSTR

    End Function

    Public Function ConfirmaAccion(pPregunta As String) As Boolean
        Dim FormaPregunta As New FrmPregunta
        Dim Resultado As Boolean
        Try


            FormaPregunta.Pregunta = pPregunta
            FormaPregunta.Execute()


            Resultado = FormaPregunta.Respuesta

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            FormaPregunta = Nothing
        End Try
        Return Resultado
    End Function

    Public Function CreaRegistroArchivo(pTablaNombre As String, pTabla As DataTable) As String
        Dim Fila As String = String.Empty
        Dim i As Integer = 1

        For Each dr As DataRow In pTabla.Rows
            For Each dc As DataColumn In pTabla.Columns
                If Fila = String.Empty Then
                    Fila = pTablaNombre & coSeparaColumna & dr(dc.ColumnName)
                Else
                    If pTabla.Columns(pTabla.Columns.Count - 1).ColumnName = dc.ColumnName Then
                        Fila += coSeparaColumna & dr(dc.ColumnName) & vbCrLf
                        i += 1
                        If i <= pTabla.Rows.Count Then
                            Fila += pTablaNombre
                        End If
                    Else
                        Fila += coSeparaColumna & dr(dc.ColumnName)
                    End If
                End If
            Next
        Next

        Return Fila
    End Function

    Public Sub VerificaVersionModulo(pModulo As Modulos, version As String)
        Dim Modulo As New TModulo
        Dim ValorVersion() As String
        Dim Proceso As New Process
        Try

            ValorVersion = version.Split(".")

            With Modulo
                .Modulo_Id = pModulo
                .Major = ValorVersion(0)
                .Menor = ValorVersion(1)
                .Bug = ValorVersion(2)
                .Build = ValorVersion(3)
            End With
            VerificaMensaje(Modulo.VerificaVersion())

            If Modulo.Resultado >= Enum_ErrorVersiones.Warning Then
                Select Case Modulo.Resultado
                    Case Enum_ErrorVersiones.Warning
                        MensajeError("Su versión se encuentra desactualizada")
                    Case Enum_ErrorVersiones.ErrorMajor, Enum_ErrorVersiones.ErrorMenor, Enum_ErrorVersiones.ErrorBug, Enum_ErrorVersiones.ErrorBuild
                        Mensaje("Imposible continuar, es necesario actualizar la versión de la aplicación")
                        Proceso.Start(coActualizador)
                        'VerificaMensaje("Imposible continuar, es necesario actualizar la versión de la aplicación")
                    Case Enum_ErrorVersiones.ErrorActive
                        VerificaMensaje("El módulo se encuentra fuera de servicio")
                End Select
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub ListViewCambiaColorFilaTexto(ByVal pItem As ListViewItem, ByVal pColor As System.Drawing.Color)
        For i = 0 To pItem.SubItems.Count - 1
            pItem.SubItems(i).ForeColor = pColor
        Next
    End Sub

    Public Sub ListViewCambiaColorFilaFondo(ByVal pItem As ListViewItem, ByVal pColor As System.Drawing.Color)
        For i = 0 To pItem.SubItems.Count - 1
            pItem.SubItems(i).BackColor = pColor
        Next
    End Sub
    Public Sub ListViewMarcaDesmarca(ByVal pLvwLista As ListView, pMarcar As Boolean)
        For Each item As ListViewItem In pLvwLista.Items
            item.Checked = pMarcar
        Next
    End Sub
    Public Sub ListViewCambiaColorCelda(ByVal pItem As ListViewItem, ByVal pColor As System.Drawing.Color, pColumna As Integer)
        For i = 0 To pItem.SubItems.Count - 1
            If pColumna = i Then
                pItem.SubItems(i).BackColor = pColor
                Exit For
            End If
        Next
    End Sub


    Public Sub ListViewCambiaCeldaBackForeColor(ByVal pItem As ListViewItem, ByVal pBackColor As System.Drawing.Color, ByVal pForeColor As System.Drawing.Color, pColumna As Integer)
        For i = 0 To pItem.SubItems.Count - 1
            If pColumna = i Then
                pItem.SubItems(i).BackColor = pBackColor
                pItem.SubItems(i).ForeColor = pForeColor
                Exit For
            End If
        Next
    End Sub

    Public Sub ListViewCambiaFilaBackForeColor(ByVal pItem As ListViewItem, ByVal pBackColor As System.Drawing.Color, ByVal pForeColor As System.Drawing.Color)
        For i = 0 To pItem.SubItems.Count - 1
            pItem.SubItems(i).BackColor = pBackColor
            pItem.SubItems(i).ForeColor = pForeColor
        Next
    End Sub



    Public Function VerificaArchivoIni() As String
        Try

            If Not File.Exists(Application.StartupPath.ToString + "\ini.xml") Then
                VerificaMensaje("No se encontró el archivo de configuración")
            End If

            Return String.Empty

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


    Public Sub MensajeError(ByVal pMensaje As String, Optional ByVal pTitulo As String = "Error de aplicación")
        Dim Forma As New FrmMensaje

        Try
            Forma.Execute(pMensaje)
            BitacoraErrores(Application.StartupPath, pMensaje, pTitulo)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Public Sub Mensaje(ByVal pMensaje As String)
        Dim Forma As New FrmMensaje

        Try
            Forma.Execute(pMensaje)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Public Sub VerificaMensaje(ByVal pMensaje As String)
        If pMensaje.Trim <> "" Then
            Throw New Exception(pMensaje)
        End If
    End Sub

    Public Sub EnfocarTexto(ByVal pTexto As TextBox)
        pTexto.SelectAll()
        pTexto.Focus()
    End Sub

    Public Function GetRegistryValue(ByVal pRegionKey As String, ByVal pCompanyNameKey As String, ByVal pProductNameKey As String, ByVal pValue As String, Optional ByVal pDefaultValue As String = "") As String
        Dim Rk As RegistryKey = Registry.LocalMachine

        Try
            If Rk.OpenSubKey(coRegRegion64Key) Is Nothing Then
                Rk = Rk.OpenSubKey(pRegionKey)
            Else
                Rk = Rk.OpenSubKey(coRegRegion64Key)
            End If

            Rk = Rk.OpenSubKey(pCompanyNameKey)
            Rk = Rk.OpenSubKey(pProductNameKey)

            Return Rk.GetValue(pValue, pDefaultValue)
        Catch ex As Exception
            Return pDefaultValue
        End Try
    End Function

    Public Function GetRegistryServicioValue(ByVal pRegionKey As String, ByVal pCompanyNameKey As String, ByVal pProductNameKey As String, ByVal pServiceNameKey As String, ByVal pValue As String, Optional ByVal pDefaultValue As String = "") As String
        Dim Rk As RegistryKey = Registry.LocalMachine

        Try
            If Rk.OpenSubKey(coRegRegion64Key) Is Nothing Then
                Rk = Rk.OpenSubKey(pRegionKey)
            Else
                Rk = Rk.OpenSubKey(coRegRegion64Key)
            End If

            Rk = Rk.OpenSubKey(pCompanyNameKey)
            Rk = Rk.OpenSubKey(pProductNameKey)
            Rk = Rk.OpenSubKey(pServiceNameKey)

            Return Rk.GetValue(pValue, pDefaultValue)
        Catch ex As Exception
            Return pDefaultValue
        End Try
    End Function

    Public Sub SetRegistryValue(ByVal pRegionKey As String, ByVal pCompanyNameKey As String, ByVal pProductNameKey As String, ByVal pValue As String, ByVal pDefaultValue As String)
        Dim Rk As RegistryKey = Registry.LocalMachine

        Try
            If Rk.OpenSubKey(coRegRegion64Key) Is Nothing Then
                Rk = Rk.OpenSubKey(pRegionKey, True)
            Else
                Rk = Rk.OpenSubKey(coRegRegion64Key, True)
            End If

            Rk = Rk.CreateSubKey(pCompanyNameKey)
            Rk = Rk.CreateSubKey(pProductNameKey)
            Rk.SetValue(pValue, pDefaultValue)

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Sub SetRegistryServicioValue(ByVal pRegionKey As String, ByVal pCompanyNameKey As String, ByVal pProductNameKey As String, ByVal pServiceNameKey As String, ByVal pValue As String, ByVal pDefaultValue As String)
        Dim Rk As RegistryKey = Registry.LocalMachine

        Try
            If Rk.OpenSubKey(coRegRegion64Key) Is Nothing Then
                Rk = Rk.OpenSubKey(pRegionKey, True)
            Else
                Rk = Rk.OpenSubKey(coRegRegion64Key, True)
            End If

            Rk = Rk.CreateSubKey(pCompanyNameKey)
            Rk = Rk.CreateSubKey(pProductNameKey)
            Rk = Rk.CreateSubKey(pServiceNameKey)

            Rk.SetValue(pValue, pDefaultValue)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Function GetConnectionString() As String
        Dim CnStr As String = ""
        Dim xmlArchivo As New XmlDocument
        Dim xmlNodeList As XmlNodeList
        Dim Server As String = String.Empty
        Dim DataBase As String = String.Empty
        Dim User As String = String.Empty
        Dim Password As String = String.Empty
        Try

            xmlArchivo.Load(Application.StartupPath.ToString + "\ini.xml")
            xmlNodeList = xmlArchivo.SelectNodes("/Configuracion")

            For Each nodo As XmlNode In xmlNodeList
                Server = nodo.ChildNodes.Item(0).InnerText
                DataBase = nodo.ChildNodes.Item(1).InnerText
                User = nodo.ChildNodes.Item(2).InnerText
                Password = nodo.ChildNodes.Item(3).InnerText
            Next

            CnStr = "Data Source=" & UnLockPassword(Server) &
                    ";Initial Catalog=" & UnLockPassword(DataBase) &
                    ";User ID=" & UnLockPassword(User) &
                    ";Password = " & UnLockPassword(Password)

            Return CnStr
        Catch ex As Exception
            Return ex.Message
        Finally
            xmlArchivo = Nothing
            xmlNodeList = Nothing
        End Try
    End Function


    Public Function GetMaquinaId() As String
        Dim xmlArchivo As New XmlDocument
        Dim xmlNodeList As XmlNodeList
        Dim Valor As String = String.Empty
        Try

            xmlArchivo.Load(Application.StartupPath.ToString + "\ini.xml")
            xmlNodeList = xmlArchivo.SelectNodes("/Configuracion")

            For Each nodo As XmlNode In xmlNodeList
                Valor = nodo.ChildNodes.Item(4).InnerText
            Next


            Return UnLockPassword(Valor)

        Catch ex As Exception
            Return ex.Message
        Finally
            xmlArchivo = Nothing
            xmlNodeList = Nothing
        End Try
    End Function

    Public Function GetConnectionStringContabilidad() As String
        Dim CnStr As String = ""

        Try
            CnStr = "Data Source=" & InfoMaquina.ContaServer &
                    ";Initial Catalog=" & InfoMaquina.ContaDataBase &
                    ";User ID=" & UnLockPassword(InfoMaquina.ContaUser) &
                    ";Password = " & UnLockPassword(InfoMaquina.ContaPassword)

            Return CnStr
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function UnLockPassword(ByVal key As String) As String
        Dim sResultado As String = Convert.ToString(Text.Encoding.UTF8.GetChars(Convert.FromBase64String(key)))
        Return sResultado.Substring(0, sResultado.Length)
    End Function

    Public Function LockPassword(ByVal key As String) As String
        Dim ValueAndSalt As String = String.Concat(key)
        Dim byteValue() As Byte = Text.Encoding.UTF8.GetBytes(ValueAndSalt)
        Return (Convert.ToBase64String(byteValue))
    End Function

    Public Function CargaParametrosSistema() As String
        Dim Empresa_Id As Integer = 0
        Dim Sucursal_Id As Integer = 0
        Dim Caja_Id As Integer = 0

        Try
            Empresa_Id = InfoMaquina.Emp_Id
            Sucursal_Id = InfoMaquina.Suc_Id
            Caja_Id = InfoMaquina.Caja_Id

            'Carga la empresa
            EmpresaInfo.Emp_Id = Empresa_Id
            VerificaMensaje(EmpresaInfo.ListKey)

            If EmpresaInfo.RowsAffected = 0 Then
                VerificaMensaje("Debe de definir una empresa válida")
            End If

            'Carga los parametros generales para la empresa
            EmpresaParametroInfo.Emp_Id = Empresa_Id
            VerificaMensaje(EmpresaParametroInfo.ListKey)

            If EmpresaParametroInfo.RowsAffected = 0 Then
                VerificaMensaje("Imposible continuar, no se han definido los parametros para la empresa")
            End If

            'Carga la sucursal
            With SucursalInfo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Suc_Id = Sucursal_Id
            End With
            VerificaMensaje(SucursalInfo.ListKey)

            If SucursalInfo.RowsAffected = 0 Then
                VerificaMensaje("Debe de definir una sucursal válida")
            End If

            'Carga los parametros de la sucursal
            With SucursalParametroInfo
                .Emp_Id = EmpresaInfo.Emp_Id
                .Suc_Id = Sucursal_Id
            End With
            VerificaMensaje(SucursalParametroInfo.ListKey)

            If SucursalParametroInfo.RowsAffected = 0 Then
                VerificaMensaje("Imposible continuar, no se han definido los parametros para la sucursal")
            End If

            'Carga la caja
            With CajaInfo
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
                .Caja_Id = Caja_Id
            End With
            VerificaMensaje(CajaInfo.ListKey())

            If CajaInfo.RowsAffected = 0 Then
                VerificaMensaje("Debe de definir una caja válida")
            End If

            If InfoMaquina.PrintLocation < 0 And InfoMaquina.PrintLocation > 5 Then
                VerificaMensaje("El tipo de impresión no es válido: 0 (Serial), 1 (Paralelo Windows), 2 (Paralelo Directo), 3 (Carta 1), 4 (Perfumes), 5 (Perfumes POS)")
            End If


            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Sub BitacoraErrores(ByVal pPath As String, pError As String, pProceso As String)
        Dim Fecha As String = Format(Now, "yyyyMMdd")
        Dim Hora As String = Format(Now, "HH:mm")
        Dim NombreArchivo As String = "\" & Fecha & ".txt"
        Dim Archivo = Nothing
        Dim info As Byte()

        Try
            pPath += "\Errores\"

            If Not System.IO.Directory.Exists(pPath) Then
                System.IO.Directory.CreateDirectory(pPath)
            End If

            Archivo = New FileStream(pPath & NombreArchivo, FileMode.Append, FileAccess.Write)

            info = New UTF8Encoding(True).GetBytes("[" & Fecha & " " & Hora & "][" & pProceso & "] - " & pError & vbCrLf)

            Archivo.Write(info, 0, info.Length)
            Archivo.Close()
        Catch ex As Exception
            '
        End Try
    End Sub

    Public Function GetCPUId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from Win32_Processor")
        Dim cpu_ids As String = ""

        Try
            For Each cpu As Object In processors
                cpu_ids = cpu_ids & ", " & cpu.ProcessorId
            Next cpu

            If cpu_ids.Length > 0 Then cpu_ids = cpu_ids.Substring(2)

            Return cpu_ids
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetIPAddress() As String
        Dim strHostName As String
        Dim strIPAddress As String

        Try
            strHostName = System.Net.Dns.GetHostName()
            strIPAddress = System.Net.Dns.GetHostEntry(strHostName).AddressList(0).ToString()

            Return strIPAddress
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetHostName() As String
        Dim strHostName As String

        Try
            strHostName = System.Net.Dns.GetHostName()

            Return strHostName
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetIPV4() As String
        Dim myHost As String = Dns.GetHostName
        Dim ipEntry As IPHostEntry = Dns.GetHostEntry(myHost)
        Dim ip As String = ""

        For Each tmpIpAddress As IPAddress In ipEntry.AddressList
            If tmpIpAddress.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                Dim ipAddress As String = tmpIpAddress.ToString
                ip = ipAddress

                Exit For
            End If
        Next

        If ip = "" Then
            Throw New Exception("No 10. IP found!")
        End If

        Return ip
    End Function

    Public Function RedondeaMontoCobro(ByVal pMonto As Double) As Double
        Dim ParteEntera As Long = 0
        Dim Residuo As Double = 0
        Dim MontoaCobrar As Double = 0

        If EmpresaParametroInfo.FactorRedondeo <= 0 Then
            Return pMonto
        ElseIf EmpresaParametroInfo.FactorRedondeo = 1 Then
            Return Math.Round(pMonto)
        Else

            ParteEntera = CLng(pMonto \ EmpresaParametroInfo.FactorRedondeo)
            Residuo = pMonto - (ParteEntera * EmpresaParametroInfo.FactorRedondeo)

            If Math.Abs(Residuo) >= EmpresaParametroInfo.TopeRedondeo Then
                Return (ParteEntera * EmpresaParametroInfo.FactorRedondeo) + EmpresaParametroInfo.FactorRedondeo
            Else
                Return ParteEntera * EmpresaParametroInfo.FactorRedondeo
            End If
        End If
    End Function

    Public Function CentraTexto(ByVal pTexto As String)
        Dim Cantidad As Integer = 0
        Dim Ancho As Integer = 38

        Cantidad = (Ancho - pTexto.Length) / 2

        Return StrDup(Cantidad, " ") & pTexto & StrDup(Cantidad, " ")
    End Function

    Public Function BuscaFraseEntera(ByRef pTexto As String, ByVal pLargo As String) As String
        Dim TextoTmp As String = ""

        If pTexto.Length <= pLargo Then
            TextoTmp = pTexto
            pTexto = ""
        Else
            For i As Integer = pLargo To 1 Step -1
                If Mid(pTexto, i, 1) = " " Then
                    TextoTmp = Mid(pTexto, 1, i)
                    pTexto = Mid(pTexto, i, Len(pTexto) - i + 1)
                    Exit For
                End If
            Next

            If TextoTmp.Trim = "" Then
                TextoTmp = Mid(pTexto, 1, pLargo)
                pTexto = Mid(pTexto, pLargo, Len(pTexto) - pLargo)
            End If
        End If

        Return TextoTmp
    End Function

    Public Function QuitaComillas(ByVal pTexto As String) As String
        Return pTexto.Replace("'", "")
    End Function

    Public Function CopyAndCut(ByRef pTexto As String, ByVal pLargo As Integer) As String
        Dim Valor As String = ""
        Dim Restante As String = ""

        Valor = Mid(pTexto, 1, pLargo)
        pTexto = Mid(pTexto, pLargo + 1, pTexto.Length - pLargo)

        Return Valor
    End Function
    Public Function Form_Abierto(ByVal pNombreForm As String) As Boolean
        Dim bResultado As Boolean = False

        For i As Integer = 0 To Application.OpenForms.Count - 1
            If Application.OpenForms.Item(i).Name = pNombreForm Then
                bResultado = True
                MensajeError("La ventana de detalle se encuentra abierta")
                Exit For
            End If
        Next i

        Return bResultado
    End Function

    Public Sub CierraFormulario(ByVal pNombreForm As String)
        For i As Integer = 0 To Application.OpenForms.Count - 1
            If Application.OpenForms.Item(i).Name = pNombreForm Then
                Application.OpenForms.Item(i).Close()
                Exit For
            End If
        Next i
    End Sub

    Public Function FormatearOpcionesRegionales() As Boolean
        Try
            My.Application.ChangeCulture("en-US")
            Return True
        Catch ex As Exception
            MsgBox("Error cargando la cultura [en-US]: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function BuscaNodo(ByVal pArbol As TreeView, ByVal pKey As String) As TreeNode
        Dim NodoResult As TreeNode = Nothing

        Try
            For Each Nodo As TreeNode In pArbol.Nodes
                If Nodo.Name = pKey Then
                    NodoResult = Nodo
                Else
                    NodoResult = RetornaNodo(Nodo, pKey)
                End If
            Next

            Return NodoResult
        Catch ex As Exception
            MensajeError(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function RetornaNodo(ByVal pNodo As TreeNode, ByVal pKey As String) As TreeNode
        Dim NodoResult As TreeNode = Nothing

        Try
            If pNodo.Name = pKey Then
                NodoResult = pNodo
            Else
                For Each Nodo As TreeNode In pNodo.Nodes
                    NodoResult = RetornaNodo(Nodo, pKey)
                Next
            End If

            Return NodoResult
        Catch ex As Exception
            MensajeError(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub CheckChildNones(ByVal pNono As TreeNode)
        For Each Nodo As TreeNode In pNono.Nodes
            Nodo.Checked = pNono.Checked
        Next
    End Sub

    Public Function GetCheck(ByVal node As TreeNodeCollection) As List(Of TreeNode)
        Dim lN As New List(Of TreeNode)

        For Each n As TreeNode In node
            If n.Checked Then lN.Add(n)
            lN.AddRange(GetCheck(n.Nodes))
        Next

        Return lN
    End Function

    Public Function HabilitaMenuGrupo(ByVal pMenu As MenuStrip, ByVal pGrupo_Id As Integer, ByVal pModulo_Id As Integer) As String
        Dim GrupoMenu As New TGrupoMenu(EmpresaInfo.Emp_Id)

        Try
            VerificaMensaje(GrupoMenu.HabilitaMenuGrupo(pMenu, pGrupo_Id, pModulo_Id))

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            GrupoMenu = Nothing
        End Try
    End Function

    Public Function VerificaPermiso(ByVal pEmp_Id As Integer, pSuc_Id As Integer, ByVal pUsuario_Id As String, ByVal pPermiso_Id As Permisos, ByVal pMuestraMensaje As Boolean) As Boolean
        Dim Permiso As New TPermiso(0)
        Dim UsuarioPermiso As New TUsuarioPermiso(EmpresaInfo.Emp_Id)
        Dim FormaPermiso As New FrmPermiso
        Dim Mensaje As String = ""
        Dim TienePermiso As Boolean = False

        Try
            Permiso.Permiso_Id = pPermiso_Id
            VerificaMensaje(Permiso.ListKey)

            If Permiso.RowsAffected = 0 OrElse Not Permiso.Activo Then
                GuardaPermisoBitacora(pEmp_Id, pSuc_Id, pUsuario_Id, pPermiso_Id, "")
                VerificaMensaje("El permiso no se encuenta definido")
            End If

            With UsuarioPermiso
                .Emp_Id = pEmp_Id
                .Usuario_Id = pUsuario_Id
                .Permiso_Id = pPermiso_Id
            End With
            VerificaMensaje(UsuarioPermiso.ListKey())

            If UsuarioPermiso.RowsAffected > 0 Then
                TienePermiso = True
                GuardaPermisoBitacora(pEmp_Id, pSuc_Id, pUsuario_Id, pPermiso_Id, "")
            Else
                With FormaPermiso
                    .Emp_Id = EmpresaInfo.Emp_Id
                    .Permiso_Id = pPermiso_Id
                    .Execute()
                End With

                If FormaPermiso.Selecciono Then
                    With UsuarioPermiso
                        .Emp_Id = pEmp_Id
                        .Usuario_Id = FormaPermiso.Usuario_Id
                        .Permiso_Id = pPermiso_Id
                    End With
                    VerificaMensaje(UsuarioPermiso.ListKey())

                    If UsuarioPermiso.RowsAffected > 0 Then
                        TienePermiso = True
                        GuardaPermisoBitacora(pEmp_Id, pSuc_Id, FormaPermiso.Usuario_Id, pPermiso_Id, "")
                    End If
                Else
                    TienePermiso = False
                End If
            End If

            If Not TienePermiso And pMuestraMensaje Then
                VerificaMensaje("No tiene permisos para ejecutar esta acción")
            End If

            Return TienePermiso
        Catch ex As Exception
            MensajeError(ex.Message)
            Return False
        Finally
            Permiso = Nothing
            UsuarioPermiso = Nothing
            FormaPermiso = Nothing
        End Try
    End Function

    Public Function GuardaPermisoBitacora(ByVal pEmp_Id As Integer, pSuc_Id As Integer, ByVal pUsuario_Id As String, ByVal pPermiso_Id As Permisos, pObservacion As String) As String
        Dim PermisoBitacora As New TPermisoBitacora(pEmp_Id)

        Try
            With PermisoBitacora
                .Suc_Id = pSuc_Id
                .Permiso_Id = pPermiso_Id
                .Usuario_Id = pUsuario_Id
                .Observacion = pObservacion
            End With
            VerificaMensaje(PermisoBitacora.Insert())

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            PermisoBitacora = Nothing
        End Try
    End Function

    Public Function VerificaUsuarioPermisoOpcion(pModulo_Id As Modulos, ByVal pEmp_Id As Integer, ByVal pUsuario_Id As String, pMenu_Id As String) As String
        Dim Usuario As New TUsuario(EmpresaInfo.Emp_Id)

        Try
            Usuario.Usuario_Id = pUsuario_Id
            VerificaMensaje(Usuario.VerificaUsuarioPermisoOpcion(pModulo_Id, pMenu_Id))

            If Usuario.RowsAffected = 0 Then
                VerificaMensaje("No tiene permiso")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Usuario = Nothing
        End Try
    End Function

    Public Function ImpresoraPredeterminada() As String
        Dim Documento As New PrintDocument

        Try
            Return Documento.PrinterSettings.PrinterName
        Catch ex As Exception
            Return ex.Message
        Finally
            Documento = Nothing
        End Try
    End Function

    Public Function SeleccionaImpresora() As String
        Dim MyPrintDialog As New PrintDialog
        Dim Impresora As String = ""

        Try
            With MyPrintDialog
                .AllowSomePages = False
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Impresora = .PrinterSettings.PrinterName
                Else
                    Impresora = ImpresoraPredeterminada()
                End If
            End With

            Return Impresora
        Catch ex As Exception
            Return ex.Message
        Finally
            MyPrintDialog = Nothing
        End Try
    End Function

    Public Function CantidadEtiquetasPar(pCantidad As Long) As Long
        Try
            If (pCantidad Mod 2) > 0 Then
                pCantidad = pCantidad + 1
            End If

            Return pCantidad
        Catch ex As Exception
            MensajeError(ex.Message)
            Return 0
        End Try
    End Function


    Public Function CantidadEtiquetasHojaTamanoCarta(pCantidad As Long) As Long
        Try
            If pCantidad > 40 Then
                If (pCantidad Mod 40) Then
                    pCantidad = pCantidad + 1
                End If
            Else
                pCantidad = 1
            End If


            Return pCantidad
        Catch ex As Exception
            MensajeError(ex.Message)
            Return 0
        End Try

        Return 0
    End Function

    Public Sub GuardaBitacoraUsuario(pModulo_Id As Modulos, pEmp_Id As Integer, pUsuario_Id As String, pDescripcion As String)
        Dim BitacoraUsuario As New TBitacoraUsuario(pEmp_Id)

        Try
            With BitacoraUsuario
                .Modulo_Id = pModulo_Id
                .Usuario_Id = pUsuario_Id
                .Descripcion = pDescripcion
            End With
            VerificaMensaje(BitacoraUsuario.GuardaBitacoraUsuario())

        Catch ex As Exception
            ''
        Finally
            BitacoraUsuario = Nothing
        End Try
    End Sub

    Public Function TipoCambioCompra() As Double
        Dim TipoCambio As New TTipoCambio

        Try
            VerificaMensaje(TipoCambio.ListKey())

            Return TipoCambio.Compra
        Catch ex As Exception
            MensajeError(ex.Message)
            Return 1
        End Try
    End Function

    Public Function TipoCambioVenta() As Double
        Dim TipoCambio As New TTipoCambio

        Try
            VerificaMensaje(TipoCambio.ListKey())

            Return TipoCambio.Venta
        Catch ex As Exception
            MensajeError(ex.Message)
            Return 1
        End Try
    End Function

    Public Function TipoCambioCierreCaja(pSuc_Id As Integer, pCaja_Id As Integer, pCierre_Id As Long) As Double
        Dim CajaCierreEncabezado As New TCajaCierreEncabezado(EmpresaInfo.Emp_Id)

        With CajaCierreEncabezado
            .Suc_Id = pSuc_Id
            .Caja_Id = pCaja_Id
            .Cierre_Id = pCierre_Id
        End With

        VerificaMensaje(CajaCierreEncabezado.ListKey())

        Return CajaCierreEncabezado.TipoCambio

    End Function

    Public Function ObtieneValorTipoCambioBancoCentral(ByVal pIndicador As String, ByVal pFechaInicio As String, ByVal pFechaFinal As String,
                                                       ByVal pNombre As String, ByVal pSubNiveles As String, pCorreoElectronico As String, pToken As String) As Double
        Dim TipoCambio As New TipoCamboBCCR.wsindicadoreseconomicos
        Dim Ds As New DataSet
        Dim Tabla As DataTable = Nothing
        Dim Fila As DataRow = Nothing
        Dim Valor As Double = -1

        Try
            TipoCambio.Url = InfoMaquina.URLTipoCambio

            Ds = TipoCambio.ObtenerIndicadoresEconomicos(pIndicador, pFechaInicio, pFechaFinal, pNombre, pSubNiveles, pCorreoElectronico, pToken)
            Tabla = Ds.Tables(0)

            If Tabla.Rows.Count = 0 Then
                MensajeError("Tipo de Cambio del Día, aun no se encuentra registrado en el service del Banco Central.")
                Return -1
            End If

            Fila = Tabla.Rows(0)
            Valor = Fila.ItemArray(2)

            Return Valor
        Catch ex As Exception
            MensajeError(ex.Message)
            Return -1
        Finally
            TipoCambio = Nothing
            Ds = Nothing
        End Try
    End Function

    Public Function ActualizaTipoCambio() As String
        Dim TipoCambio As New TTipoCambio()
        Dim Compra As Double = 0
        Dim Venta As Double = 0
        Dim Fecha As Date

        Try
            Fecha = EmpresaInfo.Getdate()
            Compra = ObtieneValorTipoCambioBancoCentral("317", Format(Fecha, "dd/MM/yyyy"), Format(Fecha, "dd/MM/yyyy"), "Jimmy Trejos Valverde", "N", "jtrejos@outlook.com", "M1MRVRO4E2")
            Venta = ObtieneValorTipoCambioBancoCentral("318", Format(Fecha, "dd/MM/yyyy"), Format(Fecha, "dd/MM/yyyy"), "Jimmy Trejos Valverde", "N", "jtrejos@outlook.com", "M1MRVRO4E2")

            If Compra <= 0 Then
                VerificaMensaje("No se pudo obtener el tipo de cambio de compra")
            End If

            If Venta <= 0 Then
                VerificaMensaje("No se pudo obtener el tipo de cambio de venta")
            End If

            With TipoCambio
                .Compra = Compra
                .Venta = Venta
            End With
            VerificaMensaje(TipoCambio.ActualizaTipoCambio())

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ValidaProformaDisponible(pSuc_Id As Integer, pDocumento_Id As Long) As String
        Dim ProformaEncabezado As New TProformaEncabezado(EmpresaInfo.Emp_Id)

        Try
            With ProformaEncabezado
                .Suc_Id = pSuc_Id
                .Documento_Id = pDocumento_Id
            End With
            VerificaMensaje(ProformaEncabezado.ListKey())

            If ProformaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("Imposible facturar, debido a que la Proforma ya no se encuentra disponible")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function BuscaCodigoArticulo(pArt_Id As String) As String
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim ArticuloEquivalente As New TArticuloEquivalente(EmpresaInfo.Emp_Id)
        Dim Codigo As String = ""

        Try
            Articulo.Art_Id = pArt_Id
            VerificaMensaje(Articulo.ListKey())

            If Articulo.RowsAffected > 0 Then
                Codigo = pArt_Id
            Else
                ArticuloEquivalente.ArtEquivalente_Id = pArt_Id
                VerificaMensaje(ArticuloEquivalente.ListKey())

                If ArticuloEquivalente.RowsAffected > 0 Then
                    Codigo = ArticuloEquivalente.Art_Id
                End If
            End If

            Return Codigo
        Catch ex As Exception
            MensajeError(ex.Message)
            Return String.Empty
        End Try
    End Function

    Public Function ArticuloServicio(pArt_Id As String) As Boolean
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)

        Articulo.Art_Id = pArt_Id
        VerificaMensaje(Articulo.ListKey())

        Return Articulo.Servicio
    End Function

    Public Function BancoNombre(pBanco_Id As Integer) As String
        Dim Banco As New TBanco(EmpresaInfo.Emp_Id)

        Try
            Banco.Banco_Id = pBanco_Id
            VerificaMensaje(Banco.ListKey())

            Return Banco.Nombre
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ClienteValido(pCliente_Id) As Boolean
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Resultado As Boolean = False

        Try
            Cliente.Cliente_Id = pCliente_Id
            VerificaMensaje(Cliente.ListKey())

            If Cliente.RowsAffected > 0 Then
                Resultado = True
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try

        Return Resultado
    End Function

    Public Function PuntosAcumulados(pCliente_Id As Integer, pRestaCanjeados As Boolean)
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim Puntos As Integer = 0

        Try
            Cliente.Cliente_Id = pCliente_Id
            VerificaMensaje(Cliente.ListKey())

            Puntos = IIf(pRestaCanjeados, Cliente.PuntosAcumulados - Cliente.PuntosCanjeados, Cliente.PuntosAcumulados)
        Catch ex As Exception
            Puntos = 0
            MensajeError(ex.Message)
        Finally
            Cliente = Nothing
        End Try

        Return Puntos
    End Function

    Public Function BuscaPrefacturaCliente(pCliente_Id As Integer) As Long
        Dim ProformaEncabezado As New TProformaEncabezado(EmpresaInfo.Emp_Id)

        Try
            With ProformaEncabezado
                .Suc_Id = SucursalInfo.Suc_Id
                .Cliente_Id = pCliente_Id
                .Documento_Id = -1
                .Tipo = Enum_TipoFacturacion.PreFactura
            End With

            VerificaMensaje(ProformaEncabezado.ConsultaProformaCliente)

            Return ProformaEncabezado.Documento_Id
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function VerificaVigenciaMayoreo(pCliente_Id As Integer) As Boolean
        Dim Cliente As New TCliente(EmpresaInfo.Emp_Id)
        Dim resultado As Boolean = False
        Try

            If EmpresaParametroInfo.DiasMayoreo = 0 Then
                resultado = True
            Else
                Cliente.Cliente_Id = pCliente_Id
                VerificaMensaje(Cliente.ListKey())

                resultado = (DateDiff(DateInterval.Day, Cliente.FechaUltimaCompra, EmpresaInfo.Getdate()) < EmpresaParametroInfo.DiasMayoreo)
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

        Return resultado
    End Function

    Public Function SaldoClienteCxC(pCliente_Id As Long) As Double
        Dim Cliente As New TCxC_Cliente

        With Cliente
            .Emp_Id = EmpresaParametroInfo.EmpresaExterna
            .Cliente_Id = pCliente_Id
        End With
        VerificaMensaje(Cliente.ListKey())

        Return Cliente.Saldo
    End Function

    Public Function ImageToByte(pPictureBox As PictureBox) As Byte()
        Try
            Dim ms As New MemoryStream()
            pPictureBox.Image.Save(ms, pPictureBox.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()

            Return data
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function EsServicio(pArt_Id As String) As Boolean
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)

        Try
            Articulo.Art_Id = pArt_Id
            Articulo.ListKey()

            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("El código de artículo no es válido")
            End If

            Return Articulo.Servicio
        Catch ex As Exception
            Throw ex
        Finally
            Articulo = Nothing
        End Try
    End Function

    Public Function VerificaEstadoFinancialWCF() As String
        Dim FinancialWCF As New SDFinancial.SDFinancial
        Dim Resultado As New SDFinancial.TResultado

        Try
            FinancialWCF.Url = InfoMaquina.URLContabilidad
            Resultado = FinancialWCF.GetIp(InfoMaquina.IP_Address)

            If Resultado.ErrorCode <> "00" Then
                VerificaMensaje(Resultado.ErrorDescription)
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            FinancialWCF = Nothing
        End Try
    End Function

    Public Function GetMAC() As String
        Dim myMac As String = String.Empty

        Try
            Dim adapters As NetworkInformation.NetworkInterface() = NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
            Dim adapter As NetworkInformation.NetworkInterface

            For Each adapter In adapters
                Select Case adapter.NetworkInterfaceType
                    'Exclude Tunnels, Loopbacks and PPP
                    Case NetworkInformation.NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            myMac = adapter.GetPhysicalAddress.ToString
                            Exit For ' Got a mac so exit for
                        End If
                End Select
            Next adapter

        Catch ex As Exception
            '
        End Try

        Return myMac
    End Function

    Public Function CreaConfiguracionMaquina(ByRef pMaquinaConfiguracion As TMaquinaConfiguracion)
        Dim Forma As New FrmSolicitaNombreMaquina

        Try
            With pMaquinaConfiguracion
                .Nombre = GetHostName()
                .Caja_Id = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegCaja_Id, "1")
                .ClienteDefault = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegClienteDefault, "1")
                .ComPort = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegComPort, "COM33")
                .ConfirmaImpresionFactura = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegConfirmaImpresionFactura, "0")
                .ConfirmaImprimeReciboCxC = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegConfirmaImprimeReciboCxC, "0")
                .ContaDataBase = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegContaDataBase, "SDFINANCIAL")
                .ContaPassword = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegContaPassword, LockPassword(""))
                .ContaServer = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegContaServer, "")
                .ContaUser = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegContaUser, LockPassword(""))
                .Emp_Id = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegEmp_Id, "1")
                .FacturaContadoSolicitaCliente = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegFacturaContadoSolicitaCliente, "1")
                .ImpresoraEtiquetaCliente = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegImpresoraEtiquetaCliente, "")
                .ImprimeCodigoArticulo = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegImprimeCodigoArticulo, "0")
                .ImprimePrefactura = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegImprimePrefactura, "0")
                .ImprimeInformacionCliente = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegImprimeInformacionCliente, "0")
                .Interfaz = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegInterfaz, "1")
                .ParallePort = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegParallelPort, "LPT1")
                .PrefacturaTipoEntrega = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPreFacturaTipoEntrega, "0")
                .PrinterName = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPrinterName, "")
                .PrintLocation = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPrintLocation, "1")
                .SMSBaudRate = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegSMSBaudRate, "9600")
                .SMSDataBits = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegSMSDataBits, "8")
                .SMSNotificacionFacturacion = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegSMSNotificacionFacturacion, "0")
                .SMSNotificacionPuntos = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegSMSNotificacionPuntos, "0")
                .SMSPortName = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegSMSPortName, "COM1")
                .SMSReadTimeOut = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegSMSReadTimeOut, "1000")
                .SMSWriteTimeOut = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegSMSWriteTimeOut, "1000")
                .Suc_Id = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegSuc_Id, "1")
                .URLTipoCambio = "http://indicadoreseconomicos.bccr.fi.cr/indicadoreseconomicos/WebServices/wsIndicadoresEconomicos.asmx"
                .URLContabilidad = ""
                .URLCoreAPI = ""
                .VerificaPreFacturasCliente = 0
                .CPU = GetMAC()
                .HostName = GetHostName()
                .IP_Address = GetIPV4()
            End With

            Forma.NombreActual = InfoMaquina.Nombre
            Forma.Execute()

            If Forma.Selecciono Then
                InfoMaquina.Nombre = Forma.NombreNuevo
            End If

            VerificaMensaje(pMaquinaConfiguracion.Insert)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ValidaCuentaContableSD(pCuenta As String, Optional pMuestraMensaje As Boolean = False) As Boolean
        Dim Cuenta As New TCuenta

        Try
            If pCuenta.Trim = "" Then
                VerificaMensaje("Debe de ingresar una cuenta válida")
            End If

            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = pCuenta
            End With
            VerificaMensaje(Cuenta.ListKey())

            If Cuenta.RowsAffected = 0 Then
                VerificaMensaje("La cuenta no es válida")
            End If

            If Not Cuenta.Activo Then
                VerificaMensaje("La cuenta se encuentra inactiva")
            End If

            If Not Cuenta.AceptaMovimiento Then
                VerificaMensaje("La cuenta no acepta movimientos")
            End If

            Return True
        Catch ex As Exception
            If pMuestraMensaje Then
                MensajeError(ex.Message)
            End If
            Return False
        Finally
            Cuenta = Nothing
        End Try
    End Function

    Public Sub MuestraListaResultados(pLista As List(Of String))
        Dim Forma As New FrmListaResultados

        Try
            Forma.Execute(pLista)

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub

    Public Function GuardaErrorCxC(pEmp_Id As Integer, pSuc_Id As Integer, pCaja_Id As Integer, pTipoDoc_Id As Enum_TipoDocumento, pDoc_Id As Integer, pMensaje As String)
        Dim Movimiento As New TCxCMovimientoTmp(pEmp_Id)

        Try
            With Movimiento
                .Suc_Id = pSuc_Id
                .Caja_Id = pCaja_Id
                .TipoDoc_Id = pTipoDoc_Id
                .Documento_Id = pDoc_Id
                .MensajeError = pMensaje
            End With
            VerificaMensaje(Movimiento.Insert)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Movimiento = Nothing
        End Try
    End Function

    Public Function GuardaErrorCxP(pEmp_Id As Integer, pSuc_Id As Integer, pEntrada_Id As Integer, pFactura_Id As Integer, pMensaje As String)
        Dim Movimiento As New TCxPMovimientoTmp(pEmp_Id)

        Try
            With Movimiento
                .Suc_Id = pSuc_Id
                .Entrada_Id = pEntrada_Id
                .Factura_Id = pFactura_Id
                .MensajeError = pMensaje
            End With
            VerificaMensaje(Movimiento.Insert)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Movimiento = Nothing
        End Try
    End Function

    Public Function GuardaErrorAbonoCxC(pEmp_Id As Integer, pSuc_Id As Integer, pCaja_Id As Integer, pCierre_Id As Integer, pAbono_Id As Integer, pMensaje As String)
        Dim CxCAbonoEncabezadoTmp As New TCxCAbonoEncabezadoTmp(pEmp_Id)

        Try
            With CxCAbonoEncabezadoTmp
                .Suc_Id = pSuc_Id
                .Caja_Id = pCaja_Id
                .Cierre_Id = pCierre_Id
                .Abono_Id = pAbono_Id
                .MensajeError = pMensaje
            End With
            VerificaMensaje(CxCAbonoEncabezadoTmp.Insert)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            CxCAbonoEncabezadoTmp = Nothing
        End Try
    End Function


    Public Sub EnviaCorreoEncagos()
        Dim ThdEncargos As Thread
        Try

            ThdEncargos = New Thread(AddressOf EnviarCorreoEncargos)
            ThdEncargos.Start()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            ThdEncargos = Nothing
        End Try
    End Sub

    Public Sub EnviarCorreoEncargos()
        Dim CorreoEnvio As New TCorreoEnvio(EmpresaInfo.Emp_Id)
        Dim CorreoEnvioAUX As TCorreoEnvio = Nothing

        Try
            'NotificacionCajaAbierta() ' Este proceso genera un correo por cada caja abierta

            VerificaMensaje(CorreoEnvio.CorreosPendientes)

            If CorreoEnvio.Data.Tables(0).Rows.Count > 0 Then
                For Each Fila As DataRow In CorreoEnvio.Data.Tables(0).Rows
                    CorreoEnvioAUX = New TCorreoEnvio(EmpresaInfo.Emp_Id)

                    With CorreoEnvioAUX
                        .Correo_Id = CInt(Fila("Correo_Id"))
                        .Emp_Id = CInt(Fila("Emp_Id"))
                        .Desde = Fila("Desde")
                        .Para = Fila("Para")
                        .Asunto = Fila("Asunto")
                        .Mensaje = Fila("Mensaje")
                        .Fecha = CDate(Fila("Fecha"))
                        .Enviado = CInt(Fila("Enviado"))
                        .FechaEnvio = CDate(Fila("FechaEnvio"))
                        .Modulo_Id = CInt(Fila("Modulo_Id"))
                        .Usuario_Id = Fila("Usuario_Id")
                    End With

                    SendEmail(CorreoEnvioAUX.Desde, CorreoEnvioAUX.Para, CorreoEnvioAUX.Asunto, CorreoEnvioAUX.Mensaje)

                    With CorreoEnvioAUX
                        .Enviado = 1
                        .FechaEnvio = EmpresaInfo.Getdate
                    End With
                    VerificaMensaje(CorreoEnvioAUX.Modify)
                Next
            End If
            VerificaMensaje(CorreoEnvio.EliminacionAutomatica)


        Catch ex As Exception
            BitacoraErrores(Application.StartupPath, ex.Message, "Envio Correo")
        Finally
            CorreoEnvio = Nothing
        End Try
    End Sub

    Public Function SendEmail(pFromAddress As String, pToAdress As String, pSubject As String, pBody As String) As String
        Dim EM As New TEmailManagement

        Try
            With EM
                .FromAddress = pFromAddress
                .ToAddress = pToAdress
                .Subject = pSubject
                .Body = pBody
                .IsHTMLBody = True
                .UserName = EmpresaParametroInfo.MailUser
                .Password = UnLockPassword(EmpresaParametroInfo.MailPassword)
                .MailServer = EmpresaParametroInfo.MailServer
            End With

            EM.CreateAddressListTo(pToAdress)
            VerificaMensaje(EM.SendMail())

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            EM = Nothing
        End Try
    End Function

    Public Function ValidaEmail(pEmail As String) As String

        Try

            Dim a As New System.Net.Mail.MailAddress(pEmail)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function TomaFisicaActivaBodega(pSuc_Id As Integer, pBod_Id As Integer) As Long
        Dim TomaFisicaEncabezado As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim TomaFisica_Id As Long = -1
        Try
            With TomaFisicaEncabezado
                .Suc_Id = pSuc_Id
                .Bod_Id = pBod_Id
            End With
            VerificaMensaje(TomaFisicaEncabezado.VerificaTomaFisicaActiva)

            If TomaFisicaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontró ninguna Toma Física activa para la bodega seleccionada")
            End If

            If TomaFisicaEncabezado.RowsAffected > 1 Then
                VerificaMensaje("No se encontró más de una Toma Física activa para la bodega seleccionada")
            End If

            TomaFisica_Id = TomaFisicaEncabezado.TomaFisica_Id

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
        Return TomaFisica_Id
    End Function

    Public Function SeleccionaTomaFisicaActivaSucursal(pSuc_Id As Integer) As TTomaFisicaEncabezado
        Dim TomaFisicaEncabezado As New TTomaFisicaEncabezado(EmpresaInfo.Emp_Id)
        Dim Forma As New FrmSeleccionaTomaFisica
        Try
            With TomaFisicaEncabezado
                .Suc_Id = pSuc_Id
            End With
            VerificaMensaje(TomaFisicaEncabezado.VerificaTomaFisicaActivaTodas)

            If TomaFisicaEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontró ninguna Toma Física activa para la sucursal seleccionada")
            End If

            If TomaFisicaEncabezado.RowsAffected = 1 Then
                With TomaFisicaEncabezado
                    .Bod_Id = TomaFisicaEncabezado.Data.Tables(0).Rows(0).Item("Bod_Id")
                    .TomaFisica_Id = TomaFisicaEncabezado.Data.Tables(0).Rows(0).Item("TomaFisica_Id")
                End With
                VerificaMensaje(TomaFisicaEncabezado.ListKey)
            Else
                Forma.Suc_Id = pSuc_Id
                Forma.Execute()


                If Forma.TomaFisica Is Nothing Then
                    VerificaMensaje("Debe de seleccionar Toma Física activa para la sucursal seleccionada")
                Else
                    With TomaFisicaEncabezado
                        .Bod_Id = Forma.TomaFisica.Bod_Id
                        .TomaFisica_Id = Forma.TomaFisica.TomaFisica_Id
                    End With
                    VerificaMensaje(TomaFisicaEncabezado.ListKey)
                End If
            End If

            Return TomaFisicaEncabezado
        Catch ex As Exception
            MensajeError(ex.Message)
            Return Nothing
        Finally
            TomaFisicaEncabezado = Nothing
            Forma = Nothing
        End Try
    End Function

    Public Function BusquedaCuentaContable() As String
        Dim Forma As New FrmBusquedaCuentaContable
        Dim Resultado As String = String.Empty
        Try
            Forma.Execute()

            If Forma.Selecciono Then
                Resultado = Forma.Cuenta_Id
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            Forma = Nothing
        End Try
        Return Resultado
    End Function

    Public Function DepuraTexto(pTexto As String) As String

        pTexto = Replace(pTexto, "'", " ")


        Return pTexto
    End Function

    Public Function IsValidEmailFormat(ByVal s As String) As Boolean
        Try
            Dim a As New System.Net.Mail.MailAddress(s)

            Return True
        Catch
            Return False
        End Try
    End Function

    Public Function ValidaFacturacionElectronica() As String
        Try

            If EmpresaParametroInfo.FacturacionElectronica Then
                If EmpresaParametroInfo.Emisor_Id <= 0 Then
                    VerificaMensaje("Debe de indicar el código de emisor de Facturación Electrónica")
                End If

                If EmpresaParametroInfo.FeToken.Trim = String.Empty Then
                    VerificaMensaje("Debe de indicar el token de Facturación Electrónica")
                End If

                If EmpresaParametroInfo.FeLeyenda.Trim = String.Empty Then
                    VerificaMensaje("Debe de indicar la leyenda de Facturación Electrónica")
                End If


                If InfoMaquina.URLCoreAPI.Trim = String.Empty Then
                    VerificaMensaje("Debe de indicar el URL de Facturación Electrónica")
                End If
            End If

            Return String.Empty

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function NombreDocumentoElectronico(pTipoDocumento As String) As String

        Dim Resultado As String = String.Empty

        Select Case pTipoDocumento
            Case coFacturaElectronica
                Resultado = "Factura Electronica"
            Case coNotaDebitoElectronica
                Resultado = "Nota Debito Electronica"
            Case coNotaCreditoElectronica
                Resultado = "Nota Credito Electronica"
            Case coNotaCreditoElectronica
                Resultado = "Nota Credito Electronica"
            Case coTiqueteElectronico
                Resultado = "Tiquete Electrónico"
            Case Else
                Resultado = ""
        End Select

        Return Resultado

    End Function

    Public Function CantidadFacturasPendientesDeEnvio() As Long
        Dim FacturaElectronicaPendiente As New TFacturaElectronicaPendiente(EmpresaInfo.Emp_Id)
        Dim Cantidad As Long = 0
        Try

            VerificaMensaje(FacturaElectronicaPendiente.CargaFacturaPendiente)

            Cantidad = FacturaElectronicaPendiente.RowsAffected

        Catch ex As Exception
            Throw ex
        Finally
            FacturaElectronicaPendiente = Nothing
        End Try

        Return Cantidad
    End Function

    Public Function CantidadFacturasPendientesDeEnvioCxC() As Long
        Dim Movimiento As New TCxCMovimientoTmp(EmpresaInfo.Emp_Id)
        Dim Cantidad As Long = 0
        Try

            With Movimiento
                .Emp_Id = SucursalInfo.Emp_Id
                .Suc_Id = SucursalInfo.Suc_Id
            End With
            VerificaMensaje(Movimiento.List)

            Cantidad = Movimiento.RowsAffected

        Catch ex As Exception
            Throw ex
        Finally
            Movimiento = Nothing
        End Try

        Return Cantidad
    End Function


    'Public Function EnviaFacturasPendientes() As String
    '    Dim FacturaElectronicaPendiente As New TFacturaElectronicaPendiente(EmpresaInfo.Emp_Id)
    '    Dim Mensaje As String = String.Empty
    '    Try


    '        VerificaMensaje(FacturaElectronicaPendiente.EnviaFacturasPendientes())


    '        Return String.Empty
    '    Catch ex As Exception
    '        Return ex.Message
    '    Finally
    '        FacturaElectronicaPendiente = Nothing
    '    End Try
    'End Function

    Public Sub GetScreenResolution()
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height

        Try

            If intX <= 800 Then
                InfoMaquina.InterfazFactura = Enum_InterfazFacturacion.Reducida
            End If

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

    End Sub

    Public Sub AbrirCajon()
        Dim Documento As New PrintDocument
        Dim ImpresoraNombre As String = ""
        Try
            ImpresoraNombre = Documento.PrinterSettings.PrinterName()

            RawPrinterHelper.SendStringToPrinter(ImpresoraNombre, Chr(27) + Chr(112) + Chr(48) + Chr(100) + Chr(100))

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

    Public Sub MensajeEnviaFE(pClave As String, pCantidadStr As String)
        Dim forma As New FrmEnviandoFE
        Try

            forma.Execute(pClave, pCantidadStr)

        Catch ex As Exception
            '
        Finally
            forma = Nothing
        End Try
    End Sub

    Public Function VerificaModulo(pModulo_Id As Modulos) As String
        Dim Modulo As New TModulo()
        Try

            VerificaMensaje(Modulo.VerificaModulo(pModulo_Id))


            If Not Modulo.Caduco Then
                If Modulo.Mensaje <> String.Empty Then
                    Mensaje(Modulo.Mensaje)
                End If
            Else
                VerificaMensaje("Licencia Vencida - " & Modulo.Mensaje)
            End If


            Return String.Empty
        Catch ex As Exception
            Return "Verifica Módulo : " & ex.Message
        Finally
            Modulo = Nothing
        End Try
    End Function


    Public Function VerificaExistenciaArticuloVenta(pDocumento_Id As Long, pArt_Id As String, pCantidad As Double) As String
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)
        Dim Mensaje As String = String.Empty
        Try

            With ArticuloBodega
                .Suc_Id = CajaInfo.Suc_Id
                .Art_Id = pArt_Id
            End With

            VerificaMensaje(ArticuloBodega.VerificaExistenciaArticuloVenta(pDocumento_Id, pArt_Id, pCantidad))

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            ArticuloBodega = Nothing
            Articulo = Nothing
        End Try
    End Function


    Public Function GetDisponibleArticulo(pSuc_Id As Integer, pBod_Id As Integer, pArt_Id As String) As Double
        Dim ArticuloBodega As New TArticuloBodega(EmpresaInfo.Emp_Id)
        Dim Disponible As Double = 0
        Try

            With ArticuloBodega
                .Suc_Id = pSuc_Id
                .Bod_Id = pBod_Id
                .Art_Id = pArt_Id
            End With

            VerificaMensaje(ArticuloBodega.ListKey())

            If ArticuloBodega.RowsAffected = 0 Then
                VerificaMensaje("No se encontro el articulo en la bodega")
            End If

            Disponible = (ArticuloBodega.Saldo - ArticuloBodega.Comprometido)

        Catch ex As Exception
            Throw ex
        Finally
            ArticuloBodega = Nothing
        End Try

        Return Disponible
    End Function


    Public Function GetPreFacturadoArticulo(pSuc_Id As Integer, pDocumento_Id As Long, pArt_Id As String) As Double
        Dim ProformaDetalle As New TProformaDetalle(EmpresaInfo.Emp_Id)
        Dim Disponible As Double = 0
        Try

            With ProformaDetalle
                .Suc_Id = pSuc_Id
                .Documento_Id = pDocumento_Id
                .Art_Id = pArt_Id
            End With

            VerificaMensaje(ProformaDetalle.GetPreFacturadoArticulo())


            Disponible = ProformaDetalle.Cantidad

        Catch ex As Exception
            Throw ex
        Finally
            ProformaDetalle = Nothing
        End Try

        Return Disponible
    End Function

    Public Function GetBodegaApartados(pSuc_Id As Integer) As Integer
        Dim Bodega As New TBodega(EmpresaInfo.Emp_Id)
        Dim Bod_Id As Integer = 0
        Try

            With Bodega
                .Suc_Id = pSuc_Id
            End With

            VerificaMensaje(Bodega.GetBodegaApartados())

            If Bodega.RowsAffected = 0 Then
                VerificaMensaje("No se encotró definida una bodega para apartados")
            End If

            Bod_Id = Bodega.Bod_Id

        Catch ex As Exception
            Throw ex
        Finally
            Bodega = Nothing
        End Try

        Return Bod_Id
    End Function

    Public Function VerificaPuntoVentaAbierto() As String
        Try

            If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
                VerificaMensaje("Ya exite otro Punto de Venta abierto en este mismo equipo, FAVOR VERIFICAR!!!")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function CalculaMontoImpuesto(pMonto As Double, ByRef pArticuloImpuestos As List(Of TInfoArticuloImpuesto)) As Double
        Dim OtrosImpuestos As Double = 0
        Dim TotalImpuesto As Double = 0

        For Each impuesto As TInfoArticuloImpuesto In pArticuloImpuestos
            If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
                impuesto.Monto = (pMonto * (impuesto.Porcentaje / 100))
                OtrosImpuestos += impuesto.Monto
            End If
        Next

        For Each impuesto As TInfoArticuloImpuesto In pArticuloImpuestos
            If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
                impuesto.Monto = ((pMonto + OtrosImpuestos) * (impuesto.Porcentaje / 100))
                TotalImpuesto += impuesto.Monto
            End If
        Next

        Return TotalImpuesto + OtrosImpuestos
    End Function
    Public Function CalculaMontoImpuesto(pMonto As Double, pArticuloImpuestos As DataTable) As Double
        Dim OtrosImpuestos As Double = 0
        Dim TotalImpuesto As Double = 0

        For Each impuesto As DataRow In pArticuloImpuestos.Rows
            If impuesto("Codigo_Id") <> coImpuesto01 And impuesto("Codigo_Id") <> coImpuesto12 Then
                OtrosImpuestos += OtrosImpuestos + (pMonto * (impuesto("Porcentaje") / 100))
            End If
        Next

        For Each impuesto As DataRow In pArticuloImpuestos.Rows
            If impuesto("Codigo_Id") = coImpuesto01 OrElse impuesto("Codigo_Id") = coImpuesto12 Then
                TotalImpuesto += (pMonto + OtrosImpuestos) * (impuesto("Porcentaje") / 100)
            End If
        Next

        Return TotalImpuesto + OtrosImpuestos
    End Function
    Public Function RestaMontoImpuesto(pMonto As Double, pArticuloImpuestos As List(Of TInfoArticuloImpuesto)) As Double
        Dim OtrosImpuestos As Double = 0
        Dim TotalImpuesto As Double = 0
        Dim TotalPorcentaje As Double = 0

        For Each impuesto As TInfoArticuloImpuesto In pArticuloImpuestos
            If impuesto.Codigo_Id = coImpuesto01 OrElse impuesto.Codigo_Id = coImpuesto12 Then
                TotalPorcentaje += impuesto.Porcentaje
            End If
        Next

        TotalImpuesto = pMonto - (pMonto / (1 + (TotalPorcentaje / 100)))

        For Each impuesto As TInfoArticuloImpuesto In pArticuloImpuestos
            If impuesto.Codigo_Id <> coImpuesto01 And impuesto.Codigo_Id <> coImpuesto12 Then
                OtrosImpuestos += impuesto.Porcentaje
            End If
        Next

        Return TotalImpuesto + (pMonto - TotalImpuesto) - ((pMonto - TotalImpuesto) / (1 + (OtrosImpuestos / 100)))

    End Function


    Public Function GetXmlMessageLabelValue(pXml As String, pLabelName As String) As String
        Dim PosIni As Long = 0
        Dim PosFin As Long = 0
        Dim Valor As String = ""

        Try
            PosIni = InStr(pXml, "<" & pLabelName & ">") + Len("<" & pLabelName & ">")

            If PosIni > Len("<" & pLabelName & ">") Then
                PosFin = InStr(pXml, "</" & pLabelName & ">")
                Valor = Mid(pXml, PosIni, PosFin - PosIni)
            End If

            Return Valor
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function GetValorXSeccion(pDocumento As XmlDocument, pSeccion As String, pValor As String) As String
        Dim Resultado As String = String.Empty
        Dim TmpStr As String = String.Empty
        Dim XmlStr As String = String.Empty

        Try
            XmlStr = pDocumento.InnerXml

            If XmlStr.IndexOf("<" & pSeccion & ">", 0) > 0 Then
                TmpStr = XmlStr.Substring(XmlStr.IndexOf("<" & pSeccion & ">", 0) + ("<" & pSeccion & ">").Length, XmlStr.IndexOf("</" & pSeccion & ">") - (XmlStr.IndexOf("<" & pSeccion & ">", 0) + ("<" & pSeccion & ">").Length))

                If TmpStr.Length > 0 Then
                    Resultado = GetXmlMessageLabelValue(TmpStr, pValor)
                End If
            End If
        Catch ex As Exception
            Resultado = "Error:" & pSeccion & "-" & pValor
        End Try

        Return Resultado
    End Function

    Public Function ValidaCodigoArticulo(pProv_Id As Integer, pArt_Id As String, ByRef oTipo As Integer, ByRef oArt_Id As String, ByRef oNombre As String, ByRef oServicio As Boolean) As String
        Dim Articulo As New TArticulo(EmpresaInfo.Emp_Id)

        Try

            Articulo.Art_Id = pArt_Id
            VerificaMensaje(Articulo.ValidaCodigoArticulo(pProv_Id))
            If Articulo.RowsAffected = 0 Then
                VerificaMensaje("No se recibió una respuesta de la validación")
            End If

            oTipo = Articulo.Data.Tables(0).Rows(0).Item("Tipo")
            oArt_Id = Articulo.Data.Tables(0).Rows(0).Item("Art_Id")
            oNombre = Articulo.Data.Tables(0).Rows(0).Item("Nombre")
            oServicio = Articulo.Data.Tables(0).Rows(0).Item("Servicio")

            Return String.Empty

        Catch ex As Exception
            Return ex.Message
        Finally
            Articulo = Nothing
        End Try
    End Function
End Module