Imports System.Windows.Forms
Imports System.Net.NetworkInformation
Imports System.Net
Imports System.Text
Imports System.IO
Imports Microsoft.Win32
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Module General
    Public Function FormatearOpcionesRegionales() As Boolean
        Try
            My.Application.ChangeCulture("en-US")

            Return True
        Catch ex As Exception
            MsgBox("Error cargando la cultura [en-US]: " & ex.Message)
            Return False
        End Try
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
    Public Sub BitacoraErrores(ByVal pPath As String, pError As String, pProceso As String)
        Dim Fecha As String = Format(EmpresaInfo.Getdate(), "yyyyMMdd")
        Dim Hora As String = Format(EmpresaInfo.Getdate(), "HH:mm")
        Dim NombreArchivo As String = "\" & Fecha & ".txt"
        Dim Archivo = Nothing
        Dim info As Byte()

        pPath += "\Errores\"

        Try
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
    Public Sub Mensaje(ByVal pMensaje As String, Optional ByVal pTitulo As String = "")
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
    Public Function UnLockPassword(ByVal key As String) As String
        Dim sResultado As String = Convert.ToString(System.Text.Encoding.UTF8.GetChars(Convert.FromBase64String(key)))
        Return sResultado.Substring(0, sResultado.Length)
    End Function
    Public Function LockPassword(ByVal key As String) As String
        Dim ValueAndSalt As String = String.Concat(key)
        Dim byteValue() As Byte = System.Text.Encoding.UTF8.GetBytes(ValueAndSalt)
        Return (Convert.ToBase64String(byteValue))
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
    Public Function ImageToArray(ByVal img As Bitmap) As Byte()
        Dim result(0) As Byte

        Using tmpImg As New Bitmap(img)
            Dim imgData As BitmapData = tmpImg.LockBits(New Rectangle(0, 0, tmpImg.Width, tmpImg.Height), ImageLockMode.ReadOnly, tmpImg.PixelFormat)

            Array.Resize(result, imgData.Stride * tmpImg.Height)
            Marshal.Copy(imgData.Scan0, result, 0, result.Length)
        End Using

        Return result
    End Function
    Public Function ImageComparator(ByVal imgA As Bitmap, ByVal imgB As Bitmap) As Boolean
        If imgA Is Nothing And imgB Is Nothing Then Return True
        If imgA Is Nothing And imgB IsNot Nothing Then Return False
        If imgA IsNot Nothing And imgB Is Nothing Then Return False

        Using tmpImgA As New Bitmap(imgA), tmpImgB As New Bitmap(imgB)
            If tmpImgA.Size <> tmpImgB.Size Then Return False
            If tmpImgA.Flags <> tmpImgB.Flags Then Return False

            Dim iaArray() As Byte = ImageToArray(tmpImgA)
            Dim ibArray() As Byte = ImageToArray(tmpImgB)

            For ca As Integer = 0 To iaArray.Count - 1
                If iaArray(ca) <> ibArray(ca) Then Return False
            Next
        End Using

        Return True
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
    Public Function QuitaComillas(ByVal pTexto As String) As String
        Return pTexto.Replace("'", "")
    End Function
    Public Function HabilitaMenuGrupo(ByVal pMenu As MenuStrip, ByVal pGrupo_Id As Integer, ByVal pModulo_Id As Integer) As String
        Dim GrupoMenu As New TGrupoMenu()

        Try
            GrupoMenu.Emp_Id = EmpresaInfo.Emp_Id
            VerificaMensaje(GrupoMenu.HabilitaMenuGrupo(pMenu, pGrupo_Id, pModulo_Id))

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            GrupoMenu = Nothing
        End Try
    End Function
    Public Function VerificaUsuarioPermisoOpcion(pModulo_Id As Enum_Modulos, ByVal pEmp_Id As Integer, ByVal pUsuario_Id As String, pMenu_Id As String) As String
        Dim Usuario As New TUsuario()

        Try
            With Usuario
                .Emp_Id = EmpresaInfo.Emp_Id
                .Usuario_Id = pUsuario_Id
            End With

            VerificaMensaje(Usuario.VerificaUsuarioPermisoOpcion(pModulo_Id, pMenu_Id))

            If Usuario.RowsAffected = 0 Then
                VerificaMensaje("No tiene permiso")
            End If

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Usuario = Nothing
        End Try
    End Function
    Public Function GetMAC() As String
        Dim myMac As String = String.Empty
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface

        Try
            For Each adapter In adapters
                Select Case adapter.NetworkInterfaceType
                    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            myMac = adapter.GetPhysicalAddress.ToString
                            Exit For
                        End If
                End Select
            Next adapter

        Catch ex As Exception
            myMac = String.Empty
        End Try

        Return myMac
    End Function
    Public Function GetHostName() As String
        Dim strHostName As String

        Try
            strHostName = System.Net.Dns.GetHostName()

            Return strHostName
        Catch ex As Exception
            Return ""
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
    Public Function CreaConfiguracionMaquina(ByRef pMaquinaConfiguracion As TMaquinaConfiguracion)
        Dim Forma As New FrmSolicitaNombreMaquina

        Try
            With pMaquinaConfiguracion
                .Nombre = GetHostName()
                .Caja_Id = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegCaja_Id, "20")
                .ClienteDefault = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegClienteDefault, "1")
                .ComPort = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegComPort, "COM33")
                .ConfirmaImpresionFactura = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegConfirmaImpresionFactura, "0")
                .Data_Base = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegDataBase, "SDFinancial")
                .Emp_Id = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegEmp_Id, "1")
                .FacturaContadoSolicitaCliente = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegFacturaContadoSolicitaCliente, "1")
                .ImprimeCodigoArticulo = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegImprimeCodigoArticulo, "0")
                .ImprimePrefactura = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegImprimePrefactura, "0")
                .Interfaz = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegInterfaz, "1")
                .ParallePort = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegParallelPort, "LPT1")
                .PrefacturaTipoEntrega = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPreFacturaTipoEntrega, "0")
                .PrinterName = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPrinterName, "Send To OneNote 2013")
                .PrintLocation = GetRegistryValue(coRegRegionKey, coRegCompanyNameKey, coRegProductNameKey, coRegPrintLocation, "0")
                .URLTipoCambio = "http://indicadoreseconomicos.bccr.fi.cr/indicadoreseconomicos/WebServices/wsIndicadoresEconomicos.asmx"
                .CPU = GetMAC()
                .HostName = GetHostName()
                .IP_Address = GetIPV4()
            End With

            Forma.NombreActual = InfoMaquina.Nombre
            Forma.Execute()

            If Forma.Selecciono Then
                If Forma.NombreNuevo.ToString.Trim <> String.Empty Then
                    InfoMaquina.Nombre = Forma.NombreNuevo
                End If
            End If
            VerificaMensaje(pMaquinaConfiguracion.Insert)

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Sub VerificaVersionModulo(pModulo As Enum_Modulos, version As String)
        Dim Modulo As New TModulo()
        Dim ValorVersion() As String

        ValorVersion = version.Split(".")

        With Modulo
            .Modulo_Id = pModulo
            .Major = ValorVersion(0)
            .Menor = ValorVersion(1)
            .Bug = ValorVersion(2)
            .Build = ValorVersion(3)
        End With
        VerificaMensaje(Modulo.VerificaVersion())

        If Modulo.CodigoResultado >= Enum_ErrorVersiones.Warning Then
            Select Case Modulo.CodigoResultado
                Case Enum_ErrorVersiones.Warning
                    MensajeError("Su versión se encuentra desactualizada")
                Case Enum_ErrorVersiones.ErrorMajor, Enum_ErrorVersiones.ErrorMenor, Enum_ErrorVersiones.ErrorBug, Enum_ErrorVersiones.ErrorBuild
                    VerificaMensaje("Imposible continuar, es necesario actualizar la versión de la aplicación")
                Case Enum_ErrorVersiones.ErrorActive
                    VerificaMensaje("El módulo se encuentra fuera de servicio")
                Case Enum_ErrorVersiones.ErrorLicense
                    VerificaMensaje("La licencia de prueba ha finalizado, para continuar utilizando el software contacte a su distribuidor")
            End Select
        End If
    End Sub
    Public Function GuardaPermisoBitacora(ByVal pEmp_Id As Integer, ByVal pUsuario_Id As String, ByVal pPermiso_Id As Permisos, pObservacion As String) As String
        Dim PermisoBitacora As New TPermisoBitacora

        Try
            With PermisoBitacora
                .Emp_Id = pEmp_Id
                .Permiso_Id = pPermiso_Id
                .Usuario_Id = pUsuario_Id
                .Observacion = pObservacion
            End With
            VerificaMensaje(PermisoBitacora.Insert())

            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            PermisoBitacora = Nothing
        End Try
    End Function
    Public Function VerificaPermiso(ByVal pEmp_Id As Integer, ByVal pUsuario_Id As String, ByVal pPermiso_Id As Permisos, ByVal pMuestraMensaje As Boolean) As Boolean
        Dim Permiso As New TPermiso(0)
        Dim UsuarioPermiso As New TUsuarioPermiso
        Dim FormaPermiso As New FrmPermiso
        Dim TienePermiso As Boolean = False

        Try
            Permiso.Permiso_Id = pPermiso_Id
            VerificaMensaje(Permiso.ListKey)

            If Permiso.RowsAffected = 0 OrElse Not Permiso.Activo Then
                Return True
            End If

            With UsuarioPermiso
                .Emp_Id = pEmp_Id
                .Usuario_Id = pUsuario_Id
                .Permiso_Id = pPermiso_Id
            End With
            VerificaMensaje(UsuarioPermiso.ListKey())

            If UsuarioPermiso.RowsAffected > 0 Then
                TienePermiso = True
                GuardaPermisoBitacora(pEmp_Id, pUsuario_Id, pPermiso_Id, "")
            Else
                FormaPermiso.Emp_Id = EmpresaInfo.Emp_Id
                FormaPermiso.Permiso_Id = pPermiso_Id
                FormaPermiso.Execute()

                If FormaPermiso.Selecciono Then

                    With UsuarioPermiso
                        .Emp_Id = pEmp_Id
                        .Usuario_Id = FormaPermiso.Usuario_Id
                        .Permiso_Id = pPermiso_Id
                    End With
                    VerificaMensaje(UsuarioPermiso.ListKey())

                    If UsuarioPermiso.RowsAffected > 0 Then
                        TienePermiso = True
                        GuardaPermisoBitacora(pEmp_Id, FormaPermiso.Usuario_Id, pPermiso_Id, "")
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
    Public Function GeneraCodigosAleatorios(pRaiz As Integer) As String
        Dim obj As Random = New Random(pRaiz)
        Dim posibles As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim longitud As Integer = posibles.Length
        Dim letra As Char
        Dim longitudnuevacadena As Integer = 5
        Dim nuevacadena As String = ""
        Dim AUX As Integer = 0

        Try
            AUX = Now.Millisecond

            For i As Integer = 0 To longitudnuevacadena
                letra = posibles(obj.Next(longitud))
                nuevacadena += letra.ToString()
            Next

        Catch ex As Exception
            '
        End Try

        Return nuevacadena & AUX.ToString
    End Function
    Public Function DiaNombre(pDia As Integer)
        Dim DiaStr As String = ""

        Select Case pDia
            Case 0
                DiaStr = "DOMINGO"
            Case 1
                DiaStr = "LUNES"
            Case 2
                DiaStr = "MARTES"
            Case 3
                DiaStr = "MIERCOLES"
            Case 4
                DiaStr = "JUEVES"
            Case 5
                DiaStr = "VIERNES"
            Case 6
                DiaStr = "SABADO"
        End Select

        Return DiaStr
    End Function
    Public Function MesNombre(pMes As Enum_MesAnnio)
        Return pMes.ToString()
    End Function
    Public Function DiaSemana(pFecha As String) As Integer
        Dim Dia As Integer

        Select Case pFecha
            Case "DOMINGO"
                Dia = 0
            Case "LUNES"
                Dia = 1
            Case "MARTES"
                Dia = 2
            Case "MIERCOLES"
                Dia = 3
            Case "JUEVES"
                Dia = 4
            Case "VIERNES"
                Dia = 5
            Case "SABADO"
                Dia = 6
        End Select

        Return Dia
    End Function
    Public Function BuscaNodoPrimerNivel(pNodo As TreeNode) As TreeNode
        Try
            If pNodo.Parent Is Nothing Then
                Return pNodo
            Else
                Return BuscaNodoPrimerNivel(pNodo.Parent)
            End If
        Catch ex As Exception
            Return Nothing
        End Try
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


            'System.Net.ServicePointManager.Expect100Continue = False
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

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
    Public Sub CargaComboAnnio(pCombo As ComboBox)
        Dim Annio As Integer = Year(EmpresaInfo.Getdate)

        Try
            pCombo.Items.Clear()
            For i = Annio + 10 To Annio - 50 Step -1
                pCombo.Items.Add(i)
            Next

            For i = 1 To pCombo.Items.Count - 1
                If pCombo.Items(i) = Annio Then
                    pCombo.SelectedIndex = i
                End If
            Next

            pCombo.Text = EmpresaParametroInfo.GetProcesoAnnio

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Sub CargaComboMes(pCombo As ComboBox)
        Dim Fecha As Date = EmpresaInfo.Getdate

        Try
            pCombo.Items.Clear()
            pCombo.Items.Add("ENERO")
            pCombo.Items.Add("FEBRERO")
            pCombo.Items.Add("MARZO")
            pCombo.Items.Add("ABRIL")
            pCombo.Items.Add("MAYO")
            pCombo.Items.Add("JUNIO")
            pCombo.Items.Add("JULIO")
            pCombo.Items.Add("AGOSTO")
            pCombo.Items.Add("SETIEMBRE")
            pCombo.Items.Add("OCTUBRE")
            pCombo.Items.Add("NOVIEMBRE")
            pCombo.Items.Add("DICIEMBRE")

            For i = 0 To pCombo.Items.Count - 1
                If pCombo.Items(i) = MesNombre(EmpresaParametroInfo.GetProcesoMes) Then
                    pCombo.SelectedIndex = i
                End If
            Next

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub
    Public Sub PosicionaItemCombo(pCombo As ComboBox, pValor As String)
        For i = 1 To pCombo.Items.Count - 1
            If pCombo.Items(i) = pValor Then
                pCombo.SelectedIndex = i
            End If
        Next
    End Sub
    Public Function MesNumero(pNombreMes As String) As Integer
        Dim Mes As Integer = 0

        Try
            Select Case pNombreMes.ToUpper
                Case "ENERO"
                    Mes = 1
                Case "FEBRERO"
                    Mes = 2
                Case "MARZO"
                    Mes = 3
                Case "ABRIL"
                    Mes = 4
                Case "MAYO"
                    Mes = 5
                Case "JUNIO"
                    Mes = 6
                Case "JULIO"
                    Mes = 7
                Case "AGOSTO"
                    Mes = 8
                Case "SETIEMBRE"
                    Mes = 9
                Case "OCTUBRE"
                    Mes = 10
                Case "NOVIEMBRE"
                    Mes = 11
                Case "DICIEMBRE"
                    Mes = 12
            End Select
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

        Return Mes
    End Function
    Public Function DepuraNumeroCuenta(pCuenta_Id As String) As String
        Dim Niveles() As String
        Dim Resultado As String = String.Empty

        Niveles = pCuenta_Id.Split("-")

        For i = 0 To UBound(Niveles)
            If Niveles(i).Trim.Length <> 0 Then
                If (Niveles(i).Trim.Length Mod 3) <> 0 Then
                    VerificaMensaje("Formato de cuenta incorrecto, cada nivel debe de tener 3 dígitos")
                End If
                Resultado += IIf(Resultado = String.Empty, String.Empty, "-") + Niveles(i)
            Else
                If Resultado = String.Empty Then
                    VerificaMensaje("Debe de digitar una cuenta")
                End If
                Exit For
            End If
        Next

        Return Resultado
    End Function
    Public Function TipoCambioCxP() As Double
        Dim TipoCambio As New TTipoCambio
        Dim Monto As Double

        Try
            VerificaMensaje(TipoCambio.TipoCambioCxP(Monto))

            Return Monto
        Catch ex As Exception
            MensajeError(ex.Message)
            Return 1
        End Try
    End Function
    Public Function TipoCambioCxC() As Double
        Dim TipoCambio As New TTipoCambio
        Dim Monto As Double

        Try
            VerificaMensaje(TipoCambio.TipoCambioCxC(Monto))

            Return Monto
        Catch ex As Exception
            MensajeError(ex.Message)
            Return 1
        End Try
    End Function
    Public Function TipoCambioContabilidad() As Double
        Dim TipoCambio As New TTipoCambio
        Dim Monto As Double

        Try
            VerificaMensaje(TipoCambio.TipoCambioContabilidad(Monto))

            Return Monto
        Catch ex As Exception
            MensajeError(ex.Message)
            Return 1
        End Try
    End Function
    Public Function TipoCambioBancos() As Double
        Dim TipoCambio As New TTipoCambio
        Dim Monto As Double

        Try
            VerificaMensaje(TipoCambio.TipoCambioBancos(Monto))

            Return Monto
        Catch ex As Exception
            MensajeError(ex.Message)
            Return 1
        End Try
    End Function
    Public Function GetAsientoEstado(pAsiento_Id As Long) As Enum_AsientoEstado
        Dim AsientoEncabezado As New TAsientoEncabezado
        Dim Resultado As Enum_AsientoEstado

        Try
            With AsientoEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Asiento_Id = pAsiento_Id
            End With
            VerificaMensaje(AsientoEncabezado.ListKey)

            If AsientoEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontró el asiento")
            End If

            Resultado = AsientoEncabezado.Estado_Id
        Catch ex As Exception
            VerificaMensaje(ex.Message)
        Finally
            AsientoEncabezado = Nothing
        End Try

        Return Resultado
    End Function
    Public Function MaximoDiaMes(pAnnio As Integer, pMes As Integer) As Integer
        Dim Fecha As DateTime
        Dim Dia As Integer = 28

        Try
            While True
                Fecha = New DateTime(pAnnio, pMes, Dia)
                Dia = Dia + 1
            End While

        Catch ex As Exception
            '
        End Try

        Return Fecha.Day
    End Function
    Public Sub ListViewCambiaColorFila(ByVal pItem As ListViewItem, ByVal pColor As System.Drawing.Color)
        For i = 0 To pItem.SubItems.Count - 1
            pItem.SubItems(i).ForeColor = pColor
        Next
    End Sub
    Public Sub ListViewCambiaColorFondoFila(ByVal pItem As ListViewItem, ByVal pColor As System.Drawing.Color)
        pItem.UseItemStyleForSubItems = False
        For i = 0 To pItem.SubItems.Count - 1
            pItem.SubItems(i).BackColor = pColor
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
    Public Function GetTipoCambioCierre(pCierre_Id As Integer) As Double
        Dim CierreEncabezado As New TCajaCierreEncabezado

        Try
            With CierreEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = pCierre_Id
            End With
            VerificaMensaje(CierreEncabezado.ListKey)

            If CierreEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontró el cierre numero (" & pCierre_Id.ToString & ") de la caja actual")
            End If

            If CierreEncabezado.Cerrado Then
                VerificaMensaje("El cierre se encuentra cerrado, no puede realizar más transacciones en este cierre")
            End If

            Return CierreEncabezado.TipoCambio
        Catch ex As Exception
            MensajeError(ex.Message)
            Return 0
        Finally
            CierreEncabezado = Nothing
        End Try
    End Function
    Public Function ValidaCierreCaja() As String
        Dim CierreEncabezado As New TCajaCierreEncabezado

        Try
            With CierreEncabezado
                .Emp_Id = EmpresaInfo.Emp_Id
                .Caja_Id = CajaInfo.Caja_Id
                .Cierre_Id = CajaInfo.Cierre_Id
            End With
            VerificaMensaje(CierreEncabezado.ListKey)

            If CierreEncabezado.RowsAffected = 0 Then
                VerificaMensaje("No se encontró el cierre de la caja actual")
            End If

            If CierreEncabezado.Cerrado Then
                VerificaMensaje("El cierre se encuentra cerrado, no puede realizar más transacciones en este cierre")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            CierreEncabezado = Nothing
        End Try
    End Function
    Public Function CajaEstaAbierta() As String
        Dim Caja As New TCaja

        Try
            With Caja
                .Emp_Id = EmpresaInfo.Emp_Id
                .Caja_Id = InfoMaquina.Caja_Id
            End With
            VerificaMensaje(Caja.ListKey)

            If Caja.RowsAffected = 0 Then
                VerificaMensaje("Caja no existe")
            End If

            If Not Caja.Activo Then
                VerificaMensaje("Caja se encuentra desactivada")
            End If

            If Not Caja.Abierta Then
                VerificaMensaje("No se puede realizar el cierre de caja debido a que esta ya esta cerrada")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Caja = Nothing
        End Try
    End Function
    Public Function CajaEstaCerrada() As String
        Dim Caja As New TCaja

        Try
            With Caja
                .Emp_Id = EmpresaInfo.Emp_Id
                .Caja_Id = InfoMaquina.Caja_Id
            End With
            VerificaMensaje(Caja.ListKey)

            If Caja.RowsAffected = 0 Then
                VerificaMensaje("Caja no existe")
            End If

            If Not Caja.Activo Then
                VerificaMensaje("Caja se encuentra desactivada")
            End If

            If Caja.Abierta Then
                VerificaMensaje("No se puede realizar la apertura de caja debido a que esta ya esta abierta")
            End If

            Return String.Empty
        Catch ex As Exception
            Return ex.Message
        Finally
            Caja = Nothing
        End Try
    End Function
    Public Function BuscaFraseEntera(ByRef pTexto As String, ByVal pLargo As String) As String
        Dim TextoTmp As String = ""

        If pTexto.Length <= pLargo Then
            TextoTmp = pTexto
            pTexto = ""
        Else
            For i As Integer = pLargo To 1 Step -1
                If Mid(pTexto, i, 1) = " " Then
                    TextoTmp = Mid(pTexto, 1, i).Trim
                    pTexto = Mid(pTexto, i, Len(pTexto) - i + 1).Trim
                    Exit For
                End If
            Next

            If TextoTmp.Trim = "" Then
                TextoTmp = Mid(pTexto, 1, pLargo)
                pTexto = Mid(pTexto, pLargo, Len(pTexto) - pLargo).Trim
            End If
        End If

        Return TextoTmp
    End Function
    Public Function ValidaCuentaContable(pCuenta As String, Optional pMuestraMensaje As Boolean = False) As Boolean
        Dim Cuenta As New TCuenta

        Try
            If pCuenta.Trim = "" Then
                VerificaMensaje("Debe de ingresar una cuenta contable")
            End If

            With Cuenta
                .Emp_Id = EmpresaInfo.Emp_Id
                .Cuenta_Id = pCuenta
            End With
            VerificaMensaje(Cuenta.ListKey())

            If Cuenta.RowsAffected = 0 Then
                VerificaMensaje("La cuenta ingresada no es válida")
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
    Public Function FormateaFecha(pFecha As DateTime, pFormat As Enum_FormatDate) As String
        Dim FechaStr As String = ""

        Try
            Select Case pFormat
                Case Enum_FormatDate.Corto
                    FechaStr = Format(pFecha, "dd/MM/yyyy")
                Case Enum_FormatDate.Largo
                    FechaStr = pFecha.Day.ToString & " de "
                    Select Case pFecha.Month
                        Case Enum_MesAnnio.ENERO
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.FEBRERO
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.MARZO
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.ABRIL
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.MAYO
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.JUNIO
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.JULIO
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.AGOSTO
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.SETIEMBRE
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.OCTUBRE
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.NOVIEMBRE
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                        Case Enum_MesAnnio.DICIEMBRE
                            FechaStr += LCase(Enum_MesAnnio.ENERO.ToString)
                    End Select
                    FechaStr += " del " & pFecha.Year.ToString
            End Select

        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

        Return FechaStr
    End Function
    Public Sub Encriptar()
        Dim Forma As New FrmEncriptador
        Try

            Forma.Execute()

        Catch ex As Exception
            MensajeError(ex.Message)
        Finally
            Forma = Nothing
        End Try
    End Sub
End Module