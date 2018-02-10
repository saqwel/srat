Option Strict Off
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.DirectoryServices
Imports System.Runtime.InteropServices.Marshal
Imports System.IO
Imports System.Diagnostics
Imports System.Security.Principal
Imports System.Management
Imports Cassia
Imports System.Net.NetworkInformation

Public Class Form1
    Public PARAM As String, COMP As String, REG_SECTION, PATH
    Public SERV_STATE As String
    Public PANE_POS = "vertical"
    Public lvi As ListViewItem

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'REG_SECTION = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Saqwel\RAT")
        'PATH = REG_SECTION.GetValue("Path")
        PATH = My.Application.Info.DirectoryPath
        'Determine the list of domains on the network - trusted or not
        Dim parent As New DirectoryEntry("WinNT:")
        Dim child As DirectoryEntry
        Dim domainName = ""
        Dim domainFind = False
        Try
            For Each child In parent.Children
                'MsgBox(child.Name)
                If child.SchemaClassName = "Domain" Then
                    ComboBox1.Items.Add(child.Name)
                    'If child.Name = Environment.UserDomainName Then
                    'domainName = child.Name
                    'domainFind = True
                    'ElseIf child.Name = "WORKGROUP" And Not domainFind Then
                    'domainName = child.Name
                    'End If
                End If
            Next
            For Each item In ComboBox1.Items
                If item.ToString() = Environment.UserDomainName Then
                    ComboBox1.SelectedItem = item
                    domainFind = True
                End If
            Next
            If Not domainFind Then
                For Each item In ComboBox1.Items
                    If item.ToString() = "WORKGROUP" Then
                        ComboBox1.SelectedItem = item
                        domainFind = True
                    End If
                Next
                If Not domainFind Then
                    ComboBox1.SelectedIndex = 0
                    domainFind = True
                End If
            End If

            ListView2.Columns.Add("Computer name", 120, HorizontalAlignment.Left)
            ListView2.Columns.Add("Operating system", 200, HorizontalAlignment.Left)
            '*****************
            'If ComboBox1.SelectedText.Length > 0 Then
            'Now list all of the computers in the current domain. Notice we used our
            'own domain name to filter the results, using the 'Environment' class object
            'Dim props = ""
            'Dim dirEntry As New DirectoryEntry("WinNT://" & ComboBox1.SelectedItem.ToString()) 'Environment.UserDomainName)
            'For Each child In dirEntry.Children
            'If the child object is a computername, add it to the second
            'combo box
            'If child.SchemaClassName = "Computer" Then
            'ComboBox2.Items.Add(child.Name)
            'For Each prop In child.Properties.PropertyNames
            'props = props & prop & " = " & child.Properties(prop).Value & Chr(13)
            'Next
            'MsgBox(props)
            'MsgBox(child.Properties("x").Value)
            'End If
            'Next
            'End If
            '*****************
            'Dim dirEntryForSearch As New DirectoryEntry("LDAP://" & ComboBox1.SelectedText.ToString())
            'Dim dirSearch As New DirectorySearcher(dirEntryForSearch)
            'dirSearch.Filter = "(objectClass=Computer)"
            'For Each Obj In dirSearch.FindAll()
            'MsgBox(Obj.GetDirectoryEntry().Properties("cn").Value())
            'MsgBox(Obj.GetDirectoryEntry().Properties("operatingsystem").Value())
            'MsgBox(Obj.name.Value.ToString())
            'ClastLogon = $objItemT.lastlogon.ToString()
            'ClastLogoff = $objItemT.lastlogoff.ToString()
            'CCreated = $objItemT.whencreated.ToString()
            'CDN =$objItemT.distinguishedname
            'MsgBox(objItemT.operatingsystem.ToString())
            'Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub ListView1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        If PARAM = "Users" Then
            userRenameFunc(e)
            ListView1.LabelEdit = False
        End If
        If PARAM = "Groups" Then
            groupRenameFunc(e)
            ListView1.LabelEdit = False
        End If
    End Sub

    '*****************************************************************************************
    ' Script from http://www.vb-helper.com/howto_net_listview_sort_clicked_column.html
    ' The column currently used for sorting.
    Private m_SortingColumn As ColumnHeader
    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick

        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = ListView1.Columns(e.Column)


        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.ImageKey = "1.png" Then 'If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
            m_SortingColumn.ImageKey = Nothing
            m_SortingColumn.TextAlign = HorizontalAlignment.Left
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            'm_SortingColumn.Text = "> " & m_SortingColumn.Text
            m_SortingColumn.ImageKey = "1.png"
        Else
            'm_SortingColumn.Text = "< " & m_SortingColumn.Text
            m_SortingColumn.ImageKey = "0.png"
        End If

        ' Create a comparer.
        ListView1.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView1.Sort()
    End Sub

    ' List double click
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Try
            'Dim p As Point = New Point(e.X, e.Y)
            'Dim hit As DataGridView.HitTestInfo = ListView1.HitTest(e.X, e.Y)
            If PARAM = "Partitions" Then
                partitionPropertiesForm.Show()
            End If
            If PARAM = "Share" Then
                Shell("explorer \\" & COMP & "\" & ListView1.SelectedItems.Item(0).SubItems(0).Text, AppWinStyle.NormalFocus)
            End If
            If PARAM = "Service" Then
                servicePropertiesForm.Show()
            End If
            If PARAM = "System" Or PARAM = "Security" Or PARAM = "Application" Then
                eventsPropertiesForm.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If PARAM = "Partitions" Then
                partitionPropertiesForm.Show()
            End If
            If PARAM = "Share" Then
                Dim Share
                Share = ListView1.SelectedItems.Item(0).SubItems(0).Text
                Shell("explorer \\" & COMP & "\" & Share, AppWinStyle.NormalFocus)
            End If
            If PARAM = "Service" Then
                servicePropertiesForm.Show()
            End If
            If PARAM = "Users" Then
                userPropertiesForm.Show()
            End If
            If PARAM = "Groups" Then
                groupPropertiesForm.Show()
            End If
            If PARAM = "System" Or PARAM = "Security" Or PARAM = "Application" Then
                eventsPropertiesForm.Show()
            End If
        End If
        If e.KeyCode = Keys.Delete Then
            If PARAM = "Users" Then
                userRemoveFunc()
            End If
            If PARAM = "Groups" Then
                groupRemoveFunc()
            End If
            If PARAM = "Process" Then
                Dim ProcessName = ListView1.SelectedItems.Item(0).SubItems(0).Text
                processKillFunc(ProcessName)
            End If
        End If
        If e.KeyCode = Keys.F2 Then
            If PARAM = "Users" Or PARAM = "Groups" Then
                ListView1.LabelEdit = True
                ListView1.SelectedItems.Item(0).BeginEdit()
            End If
        End If
    End Sub

    ' Click by item inside the list
    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        Try
            Dim p As Point = New Point(e.X, e.Y)
            If e.Button = MouseButtons.Right Then
                If PARAM = "General" Then
                    ContextGeneral.Show(ListView1, p)
                End If
                If PARAM = "Partitions" Then
                    ContextPartitions.Show(ListView1, p)
                End If
                If PARAM = "Process" Then
                    ContextProcess.Show(ListView1, p)
                End If
                If PARAM = "Share" Then
                    ContextShare.Show(ListView1, p)
                End If
                If PARAM = "Service" Then
                    ContextService.Show(ListView1, p)
                End If
                If PARAM = "Software" Then
                End If
                If PARAM = "Users" Then
                    ContextUsers.Show(ListView1, p)
                End If
                If PARAM = "Groups" Then
                    ContextGroups.Show(ListView1, p)
                End If
                If PARAM = "System" Or PARAM = "Security" Or PARAM = "Application" Then
                    'ContextEvents.Show(ListView1, p)
                End If
                If PARAM = "TerminalSessions" Then
                    ContextTerminalSessions.Show(ListView1, p)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' TightVNC
    Private Sub getDesktop()
        Try
            ' Ckeck that settings exist in registry
            Dim objRegLocal = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\default:StdRegProv")
            Dim tvnserver = "HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server"
            Dim regKey = My.Computer.Registry.GetValue(tvnserver, "UseVncAuthentication", 0)
            If regKey Is Nothing Then

                Dim answer = MsgBox("You need to tune TightVNC." & vbCrLf &
                        "These settings will apply to compters where you will install TightVNC service and where you will connect." & vbCrLf &
                        "Show TightVNC settings window?", MsgBoxStyle.YesNo, "Saqwel Remote Administration Tool")

                If answer = MsgBoxResult.Yes Then
                    vncServerSettingsForm.Show()
                End If

            Else

                Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")

                ' Check that TightVNC service exists
                Dim colRunningServices = objWMIService.ExecQuery("Select * from Win32_Service Where Name='tvnserver'")
                Dim tvncServiceExist = colRunningServices.Count

                ' Check that TightVNC folder exists
                Dim tvncFolderExist = My.Computer.FileSystem.DirectoryExists("\\" & COMP & "\admin$\TightVNC")
                If tvncServiceExist = 0 Or tvncFolderExist = False Then
                    Dim answer = MsgBox("TightVNC service is not installed on " & COMP & "." & vbCrLf &
                                        "Do you want to install TightVNC service on " & COMP & "?", MsgBoxStyle.YesNo, "Saqwel Remote Administration Tool")
                    If answer = MsgBoxResult.Yes Then
                        vncInstall()

                        colRunningServices = objWMIService.ExecQuery("Select * from Win32_Service Where Name='tvnserver'")
                        tvncServiceExist = colRunningServices.Count

                        If tvncServiceExist = 1 Then
                            MsgBox("TightVNC service is installed." & vbCrLf &
                                   "To connect to " & COMP &
                                   " click TightVNC button one more time", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
                        Else
                            MsgBox("TightVNC service is not installed", MsgBoxStyle.Critical, "Saqwel Remote Administration Tool")
                        End If
                    End If
                End If

                If tvncServiceExist > 0 And tvncFolderExist <> False Then
                    vncInstall()

                    ' Start VNC server service on the remote computer
                    objWMIService.Get("Win32_Service.Name='tvnserver'").StopService()
                    processKillFunc("tvnserver.exe")
                    objWMIService.Get("Win32_Service.Name='tvnserver'").StartService()

                    ' Run TightVNC client
                    Shell(PATH & "\TightVNC\tvncviewer.exe " & COMP, AppWinStyle.NormalFocus)

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub vncInstall()
        'vncServerOptions("HttpPort")
        Dim OS_bit = "32"
        Dim objReg, HKLM, regPath, binValue
        Try
            Dim tvnserver = "HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server"
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            ' Check operating system bit and write TightVNC settings to the correct hive for this type of OS
            Dim colProcessor = objWMIService.ExecQuery("Select * from Win32_Processor")
            For Each objProcessor In colProcessor
                OS_bit = objProcessor.AddressWidth
            Next

            ' Save TightVNC settings in the remote computer registry
            objReg = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\default:StdRegProv")
            HKLM = &H80000002
            If OS_bit = 32 Then
                regPath = "SOFTWARE\TightVNC"
            Else
                regPath = "SOFTWARE\Wow6432Node\TightVNC"
            End If
            objReg.CreateKey(HKLM, regPath)
            objReg.CreateKey(HKLM, regPath & "\Components")
            objReg.CreateKey(HKLM, regPath & "\Server")
            objReg.SetStringValue(HKLM, regPath & "\Components", "TightVNC Server", "1")
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "AcceptHttpConnections", My.Computer.Registry.GetValue(tvnserver, "AcceptHttpConnections", 1)) ' Accept connections HTTP
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "AcceptRfbConnections", My.Computer.Registry.GetValue(tvnserver, "AcceptRfbConnections", 1)) ' Accept regular connections
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "AllowLoopback", My.Computer.Registry.GetValue(tvnserver, "AllowLoopback", 0)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "AlwaysShared", My.Computer.Registry.GetValue(tvnserver, "AlwaysShared", 0)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "BlankScreen", My.Computer.Registry.GetValue(tvnserver, "BlankScreen", 0)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "BlockLocalInput", My.Computer.Registry.GetValue(tvnserver, "BlockLocalInput", 0))
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "BlockRemoteInput", My.Computer.Registry.GetValue(tvnserver, "BlockRemoteInput", 0))
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "DisconnectAction", My.Computer.Registry.GetValue(tvnserver, "DisconnectAction", 0)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "DisconnectClients", My.Computer.Registry.GetValue(tvnserver, "DisconnectClients", 1)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "EnableFileTransfers", My.Computer.Registry.GetValue(tvnserver, "EnableFileTransfers", 1))
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "EnableUrlParams", My.Computer.Registry.GetValue(tvnserver, "EnableUrlParams", 1)) ' Does not changed
            objReg.SetStringValue(HKLM, regPath & "\Server", "ExtraPorts", My.Computer.Registry.GetValue(tvnserver, "ExtraPorts", "")) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "GrabTransparentWindows", My.Computer.Registry.GetValue(tvnserver, "GrabTransparentWindows", 1)) ' Display transparent windows
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "HttpPort", My.Computer.Registry.GetValue(tvnserver, "HttpPort", 5800))
            objReg.SetStringValue(HKLM, regPath & "\Server", "IpAccessControl", My.Computer.Registry.GetValue(tvnserver, "IpAccessControl", "")) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "LocalInputPriority", My.Computer.Registry.GetValue(tvnserver, "LocalInputPriority", 0)) ' Do not allow remote input on local activity
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "LocalInputPriorityTimeout", My.Computer.Registry.GetValue(tvnserver, "LocalInputPriorityTimeout", 3))
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "LogLevel", My.Computer.Registry.GetValue(tvnserver, "LogLevel", 0)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "LoopbackOnly", My.Computer.Registry.GetValue(tvnserver, "LoopbackOnly", 0)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "NeverShared", My.Computer.Registry.GetValue(tvnserver, "NeverShared", 0)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "PollingInterval", My.Computer.Registry.GetValue(tvnserver, "PollingInterval", 1000)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "QueryAcceptOnTimeout", My.Computer.Registry.GetValue(tvnserver, "QueryAcceptOnTimeout", 1)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "QueryTimeout", My.Computer.Registry.GetValue(tvnserver, "QueryTimeout", 30)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "RemoveWallpaper", My.Computer.Registry.GetValue(tvnserver, "RemoveWallpaper", 0)) ' Remove wallpaper of remote computer
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "RfbPort", My.Computer.Registry.GetValue(tvnserver, "RfbPort", 5900))
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "RunControlInterface", My.Computer.Registry.GetValue(tvnserver, "RunControlInterface", 0)) ' Display tray icon
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "SaveLogToAllUsersPath", My.Computer.Registry.GetValue(tvnserver, "SaveLogToAllUsersPath", 0)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "UseControlAuthentication", My.Computer.Registry.GetValue(tvnserver, "UseControlAuthentication", 0)) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "UseVncAuthentication", My.Computer.Registry.GetValue(tvnserver, "UseVncAuthentication", 0))
            objReg.SetStringValue(HKLM, regPath & "\Server", "VideoClasses", My.Computer.Registry.GetValue(tvnserver, "VideoClasses", "")) ' Does not changed
            objReg.SetDWORDValue(HKLM, regPath & "\Server", "VideoRecognitionInterval", My.Computer.Registry.GetValue(tvnserver, "VideoRecognitionInterval", 3000)) ' Does not changed

            Dim AuthTypeCheck
            Dim PasswordCheck
            Dim objRegLocal
            Dim objWMIServiceLocal
            'objWMIServiceLocal = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2")
            'objRegLocal = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\default:StdRegProv")
            'objRegLocal.GetBinaryValue(HKLM, "SOFTWARE\Saqwel\RAT\TightVNC\Server", "UseVncAuthentication", AuthTypeCheck)
            'objRegLocal.GetBinaryValue(HKLM, "SOFTWARE\Saqwel\RAT\TightVNC\Server", "Password", PasswordCheck)

            'If IsDBNull(AuthTypeCheck) Then
            '    AuthTypeCheck = 0
            'Else
            '    AuthTypeCheck = My.Computer.Registry.GetValue(tvnserver, "UseVncAuthentication", 0)
            'End If
            'If IsDBNull(PasswordCheck) Then
            '    PasswordCheck = 0
            'Else
            '    PasswordCheck = My.Computer.Registry.GetValue(tvnserver, "Password", 0)
            'End If
            AuthTypeCheck = My.Computer.Registry.GetValue(tvnserver, "UseVncAuthentication", 0)
            PasswordCheck = My.Computer.Registry.GetValue(tvnserver, "Password", 0)

            ' If set authentication with vnc password and password is empty
            If AuthTypeCheck = 1 And PasswordCheck.GetType().ToString() <> "System.Byte[]" Then
                vncPassword(COMP)
            End If

            ' If set authentication with vnc password and password is not empty
            If AuthTypeCheck = 1 And PasswordCheck.GetType().ToString() = "System.Byte[]" Then

                objWMIServiceLocal = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2")
                objRegLocal = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\default:StdRegProv")
                objRegLocal.GetBinaryValue(HKLM, "SOFTWARE\Saqwel\RAT\TightVNC\Server", "Password", binValue)
                objReg.SetBinaryValue(HKLM, regPath & "\Server", "Password", binValue)

            End If

            ' Copy TightVNC service iles to remote compter
            If My.Computer.FileSystem.DirectoryExists("\\" & COMP & "\admin$\TightVNC") = False Then
                'My.Computer.FileSystem.DeleteDirectory("\\" & Comp & "\admin$\TightVNC", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CopyDirectory(PATH & "\TightVNC\Server", "\\" & COMP & "\admin$\TightVNC", True)
            End If

            ' Create service
            Dim objCreateService = objWMIService.Get("Win32_Service")

            'Create WMI Parameters instance:
            Dim objInParam = objCreateService.Methods_("Create").inParameters.SpawnInstance_()

            ' Add parameters to service
            objInParam.Properties_.Item("DisplayName") = "TightVNC Server"
            objInParam.Properties_.Item("Name") = "tvnserver"
            objInParam.Properties_.Item("PathName") = "%systemroot%\TightVNC\tvnserver.exe -service"
            objInParam.Properties_.Item("StartMode") = "Manual"

            ' Create VNC Server service
            Dim tvncCreate = objWMIService.ExecMethod("Win32_Service", "Create", objInParam)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Temp()
        Throw New NotImplementedException()
    End Sub

    Private Sub vncUninstall()
        Try
            Dim answer = MsgBox("Are you sure that you want to delete TightVNC from " & COMP & "?", MsgBoxStyle.YesNo, "Saqwel Remote Administration Tool")
            If answer = MsgBoxResult.Yes Then
                Dim OS_bit = "32"
                Dim Path
                Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
                ' Delete TightVNC service
                objWMIService.Get("Win32_Service.Name='tvnserver'").StopService()
                processKillFunc("tvnserver.exe")
                objWMIService.Get("Win32_Service.Name='tvnserver'").Delete()
                ' Check bit of operating system and remove correct hive of registry
                Dim colProcessor = objWMIService.ExecQuery("Select * from Win32_Processor")
                For Each objProcessor In colProcessor
                    OS_bit = objProcessor.AddressWidth
                Next

                Dim objReg = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\default:StdRegProv")
                Dim HKLM = &H80000002
                If OS_bit = 32 Then
                    Path = "SOFTWARE\TightVNC"
                Else
                    Path = "SOFTWARE\Wow6432Node\TightVNC"
                End If

                objReg.DeleteKey(HKLM, Path & "\Components")
                objReg.DeleteKey(HKLM, Path & "\Server")
                objReg.DeleteKey(HKLM, Path)

                ' Delete files
                If My.Computer.FileSystem.DirectoryExists("\\" & COMP & "\admin$\TightVNC") = True Then
                    My.Computer.FileSystem.DeleteDirectory("\\" & COMP & "\admin$\TightVNC", FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
                MsgBox("TightVNC is uninstalled", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub vncPassword(ComputerName As String)
        Dim password(7) As Byte
        Dim vncPasswordForm As New vncPasswordForm(ComputerName)
        vncPasswordForm.Show()
    End Sub

    ' Encode password for cerrect writing to the registry
    Function vncPasswordHexToDec(Password As String)

        Dim arr1, arr2 As New Dictionary(Of String, Integer)
        'Dim arr1(16), arr2(16) As Integer
        Dim str1 = Nothing
        Dim str2 = Nothing
        Dim Dec(7) As Integer

        arr1.Add("0", 0)
        arr1.Add("1", 16)
        arr1.Add("2", 32)
        arr1.Add("3", 48)
        arr1.Add("4", 64)
        arr1.Add("5", 80)
        arr1.Add("6", 96)
        arr1.Add("7", 112)
        arr1.Add("8", 128)
        arr1.Add("9", 144)
        arr1.Add("A", 160)
        arr1.Add("B", 176)
        arr1.Add("C", 192)
        arr1.Add("D", 208)
        arr1.Add("E", 224)
        arr1.Add("F", 240)

        arr2.Add("0", 0)
        arr2.Add("1", 1)
        arr2.Add("2", 2)
        arr2.Add("3", 3)
        arr2.Add("4", 4)
        arr2.Add("5", 5)
        arr2.Add("6", 6)
        arr2.Add("7", 7)
        arr2.Add("8", 8)
        arr2.Add("9", 9)
        arr2.Add("A", 10)
        arr2.Add("B", 11)
        arr2.Add("C", 12)
        arr2.Add("D", 13)
        arr2.Add("E", 14)
        arr2.Add("F", 15)

        'Dim Hex = My.Computer.FileSystem.ReadAllText(PATH & "\TightVNC\vncpwd")

        Dim Hex = UCase(Trim(Password))
        'ReDim Dec(Math.Floor(Hex.Length / 2) - 1)

        For i = 1 To 16 'Hex.Length
            If i / 2 - Math.Floor(i / 2) <> 0 Then
                str1 = Mid(Hex, i, 1)
            Else
                str2 = Mid(Hex, i, 1)
                Dec(Math.Floor(i / 2) - 1) = arr1(str1) + arr2(str2)
            End If
        Next
        Return Dec
    End Function

    ' "Kill process" in context menu
    Private Sub ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProcessKill.Click
        Dim ProcessName = ListView1.SelectedItems.Item(0).SubItems(0).Text
        processKillFunc(ProcessName)
    End Sub

    ' "Refresh" in context menu
    Private Sub ProcessRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProcessRefresh.Click
        getProcessesFunc()
    End Sub

    Private Sub processKillFunc(ProcessName As String)
        Try
            Dim objWMIService, colProcess, objProcess
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\CIMV2")
            colProcess = objWMIService.ExecQuery("SELECT * FROM Win32_Process WHERE Name = '" & ProcessName & "'")

            For Each objProcess In colProcess
                objProcess.Terminate()
                If ListView1.SelectedItems.Count > 0 Then
                    If ListView1.SelectedItems.Item(0).SubItems(0).Text = ProcessName Then
                        ListView1.SelectedItems.Item(0).Remove()
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Open" in context menu of shares
    Private Sub ToolStripMenuItem10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles shareOpen.Click
        Try
            Dim Share
            Share = ListView1.SelectedItems.Item(0).SubItems(0).Text
            Shell("explorer \\" & COMP & "\" & Share, AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Refresh" in context menu of shares
    Private Sub ShareRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles shareRefresh.Click
        getSharesFunc()
    End Sub

    ' Translate to russian service starts modes
    Function serviceStartMode(ByVal StartMode)
        Try
            Dim state = ""
            Select Case StartMode
                Case "Auto"
                    state = "Автоматически"
                Case "Manual"
                    state = "Вручную"
                Case "Disabled"
                    state = "Отключена"
                    'Case "Автоматически"
                    'state = "Automatic"
                    'Case "Вручную"
                    'state = "Manual"
                    'Case "Отключена"
                    'state = "Disabled"
            End Select
            Return state
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
        Return 0
    End Function

    ' Translate to russian states of services
    Function serviceState(ByVal servState)
        Try
            Dim state = ""
            Select Case servState
                Case "Running"
                    state = "Работает"
                Case "Stopped"
                    state = ""
                Case "Paused"
                    state = "Приостановлена"
                Case "Start Pending"
                    state = "Запускается"
                Case "Stop Pending"
                    state = "Останавливается"
                Case "Pause Pending"
                    state = "Приостанавливается"
                Case "Unknown"
                    state = "Unknown"
            End Select
            Return state
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
        Return 0
    End Function

    ' "Run" in context menu of services
    Private Sub ServStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ServStart.Click
        servStartFunc()
    End Sub

    Private Sub servStartFunc()
        Try
            Dim objWMIService, Serv, colServ
            Serv = ListView1.SelectedItems.Item(0).SubItems(0).Text
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName = '" & Serv & "'")
            For Each objServ In colServ
                objServ.StartService()
            Next
            SERV_STATE = "Start"
            serviceStateChangeForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Stop" in context menu of services
    Private Sub ServStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ServStop.Click
        servStopFunc()
    End Sub

    Private Sub servStopFunc()
        Try
            Dim objWMIService, Serv, colServ
            Serv = ListView1.SelectedItems.Item(0).SubItems(0).Text
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName = '" & Serv & "'")
            For Each objServ In colServ
                objServ.StopService()
            Next
            SERV_STATE = "Stop"
            serviceStateChangeForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Restart" in context menu of services
    Private Sub ServRestart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ServRestart.Click
        servRestartFunc()
    End Sub
    Private Sub servRestartFunc()
        Try
            SERV_STATE = "Restart"
            serviceStateChangeForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Auto" in context menu of services
    Private Sub ServStartAutoNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ServStartAuto.Click
        Try
            Dim Serv, objWMIService, colServ, objServ

            Serv = ListView1.SelectedItems.Item(0).SubItems(0).Text
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName='" & Serv & "'")
            For Each objServ In colServ
                objServ.ChangeStartMode("Automatic")
                ListView1.SelectedItems.Item(0).SubItems(3).Text = "Automatic"
            Next
            ServStart.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Disable" in context menu of services
    Private Sub ServStartDisableNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ServStartDisable.Click
        Try
            Dim Serv, objWMIService, colServ, objServ

            Serv = ListView1.SelectedItems.Item(0).SubItems(0).Text
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName='" & Serv & "'")
            For Each objServ In colServ
                objServ.ChangeStartMode("Disabled")
                ListView1.SelectedItems.Item(0).SubItems(3).Text = "Disabled"
            Next
            ServStart.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Manual" in context menu of services
    Private Sub ServStartManualNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ServStartManual.Click
        Try
            Dim Serv, objWMIService, colServ, objServ

            Serv = ListView1.SelectedItems.Item(0).SubItems(0).Text
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName='" & Serv & "'")
            For Each objServ In colServ
                objServ.ChangeStartMode("Manual")
                ListView1.SelectedItems.Item(0).SubItems(3).Text = "Manual"
            Next
            ServStart.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Properties" in contet menu of services
    Private Sub ServProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ServProperties.Click
        servicePropertiesForm.Show()
    End Sub

    ' "Refresh" in contet menu of services
    Private Sub ServRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ServRefresh.Click
        getServicesFunc()
    End Sub

    ' Settings of context menu of services
    Private Sub ContextMenuStrip2_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextService.Opening
        Try
            Dim ServStrt = ""
            Dim ServSost = ""
            Dim Serv = ListView1.SelectedItems.Item(0).SubItems(0).Text
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName = '" & Serv & "'")
            For Each objServ In colServ
                ServStrt = objServ.StartMode.ToString()
                ServSost = objServ.State.ToString()
            Next
            Select Case ServSost
                Case "Running"
                    ServStart.Enabled = False
                    ServStop.Enabled = True
                    ServRestart.Enabled = True
                Case "Stopped"
                    ServStart.Enabled = True
                    ServStop.Enabled = False
                    ServRestart.Enabled = False
                Case "Paused"
                    ServStart.Enabled = True
                    ServStop.Enabled = False
                    ServRestart.Enabled = False
                Case "Start Pending"
                    ServStart.Enabled = True
                    ServStop.Enabled = False
                    ServRestart.Enabled = False
                Case "Stop Pending"
                    ServStart.Enabled = True
                    ServStop.Enabled = False
                    ServRestart.Enabled = False
                Case "Pause Pending"
                    ServStart.Enabled = True
                    ServStop.Enabled = False
                    ServRestart.Enabled = False
                Case "Unknown"
                    ServStart.Enabled = True
                    ServStop.Enabled = False
                    ServRestart.Enabled = False
            End Select
            Select Case ServStrt
                Case "Auto"
                    ServStartAuto.Enabled = False
                    ServStartManual.Enabled = True
                    ServStartDisable.Enabled = True
                Case "Manual"
                    ServStartAuto.Enabled = True
                    ServStartManual.Enabled = False
                    ServStartDisable.Enabled = True
                Case "Disabled"
                    ServStartAuto.Enabled = True
                    ServStartManual.Enabled = True
                    ServStartDisable.Enabled = False
                    ServStart.Enabled = False
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub


    ' Text field computer name
    'Private Sub ComboBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    'Dim i As Integer = 0
    'For Each x As String In ListBox1.Items
    'i = i + 1
    'If UCase(Mid(x, 1, ComboBox2.Text.Length)) = UCase(ComboBox2.Text) Then
    'ListBox1.SelectedItem() = ListBox1.Items(i - 1)
    'i = 0
    'Exit For
    'End If
    'Next
    'End Sub
    'Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
    'Try
    'ComboBox2.Text = ListBox1.SelectedItem().ToString()
    'Catch
    'End Try
    'End Sub


    ' Computers list
    'Private Sub ListBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyUp
    'If e.KeyCode = Keys.Enter Then
    'ComboBox2.Text = ListBox1.SelectedItem().ToString()
    'End If
    'End Sub


    'Disks


    ' Change item of list of domains
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox3.Items.Clear()
        ListView2.Items.Clear()
        Try
            Dim OSES = ""
            'Dim OS_ARRAY_1() As String
            Dim OS_ARRAY_2 As New Dictionary(Of String, Integer)
            Dim dirEntryForSearch As New DirectoryEntry("LDAP://" & ComboBox1.SelectedItem.ToString())
            Dim dirSearch As New DirectorySearcher(dirEntryForSearch)
            dirSearch.Filter = "(objectClass=Computer)"
            dirSearch.PageSize = 1000
            Dim i = 0
            For Each Obj In dirSearch.FindAll()
                Dim OS = Obj.GetDirectoryEntry().Properties("operatingsystem").Value()
                Dim NAME = Obj.GetDirectoryEntry().Properties("cn").Value()
                Dim NEW_OS As Boolean = True
                ListView2.Items.Add(New ListViewItem(New String() {NAME, OS}))
                ' Information about operating system
                'If Len(OS) = 0 Then
                OS = "Unknown"
                'End If
                'For Each item In ComboBox3.Items
                'If OS = item Then
                'NEW_OS = False
                'OS_ARRAY_2.Item(OS) += 1
                'End If
                'Next
                'If NEW_OS Then
                'ComboBox3.Items.Add(OS)
                'OS_ARRAY_2.Add(OS, 1)
                'End If
                'i += 1
            Next
            'ComboBox3.Items.Add("Все")

            'ComboBox1.SelectedItem = ComboBox1.SelectedValue & " [" & i & "]"
            'For Each item In ComboBox3.Items
            'OSES = OSES & item & " [" & OS_ARRAY_2(item) & "]" & vbCrLf
            'item = item & " [" & OS_ARRAY_2(item) & "]"
            'Next
            'MsgBox(OSES)
        Catch ex As Exception
            Try
                Dim i = 0
                Dim dirEntry As New DirectoryEntry("WinNT://" & ComboBox1.SelectedItem.ToString()) 'Environment.UserDomainName)
                For Each child In dirEntry.Children
                    If child.SchemaClassName = "Computer" Then
                        ListView2.Items.Add(New ListViewItem(New String() {child.Name}))
                        i += 1
                    End If
                Next
            Catch excep As Exception
                MsgBox(excep.Message, MsgBoxStyle.OkOnly, "Error Saqwel Remote Administration Tool")
            End Try
        End Try
    End Sub

    Private Sub getPartitionsFunc()
        Label1.Text = "Information about disks " & COMP
        Dim objWMIService, col
        Dim row() As String
        Dim rows(1000) As ListViewItem
        Dim i As Integer = 0

        Try
            ListView1.Items.Clear()
            If PARAM <> "Partitions" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("DiskName", "Letter", 80)
                ListView1.Columns.Add("DiskFileSystem", "File system", 100)
                ListView1.Columns.Add("DiskVolume", "Volume", 80)
                ListView1.Columns.Add("DiskBusy", "Used", 80)
                ListView1.Columns.Add("DiskFree", "Free", 80)
            End If
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            col = objWMIService.ExecQuery("Select Caption, Filesystem, FreeSpace, Size from Win32_LogicalDisk")
            ' Number of columns
            Dim columns = ListView1.Columns.Count
            ' Number of objects in collection
            Dim objects = -1
            For Each obj In col
                objects = objects + 1
            Next
            ReDim row(columns)
            ReDim rows(objects)
            For Each objDisk In col
                Try
                    row(0) = objDisk.Caption
                Catch
                    row(0) = "-"
                End Try
                Try
                    row(1) = objDisk.FileSystem
                Catch
                    row(1) = "-"
                End Try
                Try
                    row(2) = Math.Round(objDisk.Size / 1073741824, 2) & " GB"
                Catch
                    row(2) = 0
                End Try
                Try
                    row(3) = Math.Round((objDisk.Size - objDisk.FreeSpace) / 1073741824, 2) & " GB"
                Catch
                    row(3) = 0
                End Try
                Try
                    row(4) = Math.Round(objDisk.FreeSpace / 1073741824, 2) & " GB"
                Catch
                    row(4) = 0
                End Try
                rows(i) = New ListViewItem(row)
                i = i + 1
            Next
            ListView1.Items.AddRange(rows)
            ListView1.Sorting = SortOrder.Ascending

            For Each item In ListView1.Items
                item.ImageKey = "partitions.png"
            Next
            PARAM = "Partitions"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub getGeneralInformationFunc()
        If Mid(COMP, 1, 1) = "A" Or Mid(COMP, 1, 1) = "E" Or Mid(COMP, 1, 1) = "I" Or Mid(COMP, 1, 1) = "O" Or Mid(COMP, 1, 1) = "U" Then
            Label1.Text = "General information about " & COMP
        Else
            Label1.Text = "General information about " & COMP
        End If

        Dim CompSP, CompDescription
        Dim CompUser = ""
        Try
            ListView1.Items.Clear()
            ListView1.Sorting = SortOrder.None
            If PARAM <> "Information" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("Parameter", "Parameter", 200)
                ListView1.Columns.Add("Value", "Value", 300)
            End If

            ' Date object
            Dim objDatetime = CreateObject("WbemScripting.SWbemDateTime")

            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("SELECT CSName, Caption, ServicePackMajorVersion, Description, InstallDate, TotalVisibleMemorySize, LastBootUpTime FROM Win32_OperatingSystem")
            For Each objOs In col
                ' Computer name
                ListView1.Items.Add(New ListViewItem(New String() {"Computer name", objOs.CSName.ToString()}))
                ListView1.Items.Item(ListView1.Items.Count - 1).ImageKey = "computer.png"
                ' Operating system
                ListView1.Items.Add(New ListViewItem(New String() {"Operating system", objOs.Caption.ToString()}))
                If objOs.ServicePackMajorVersion.ToString().Length > 0 Then
                    CompSP = "Service Pack " & objOs.ServicePackMajorVersion.ToString()
                Else
                    CompSP = "-"
                End If
                ListView1.Items.Add(New ListViewItem(New String() {"Service pack", CompSP}))
                If objOs.Description.ToString().Length > 0 Then
                    CompDescription = objOs.Description.ToString()
                Else
                    CompDescription = "-"
                End If
                ListView1.Items.Add(New ListViewItem(New String() {"Description", CompDescription}))
                objDatetime.value = objOs.InstallDate
                ListView1.Items.Add(New ListViewItem(New String() {"Date of installation", objDatetime.GetVarDate(True)}))
                Dim d = "-"
                Try
                    objDatetime.value = objOs.LastBootUpTime
                    d = objDatetime.GetVarDate(True)
                Catch
                End Try
                ListView1.Items.Add(New ListViewItem(New String() {"Date of last run", d}))
            Next
            ' Loaded profile
            Dim colUser = objWMIService.ExecQuery("Select UserName from Win32_ComputerSystem")

            For Each objUser In colUser
                'Dim x As String = objUser.UserName.ToString()
                If objUser.UserName.ToString().Length > 0 Then
                    CompUser = objUser.UserName.ToString()
                Else
                    CompUser = "-"
                End If
                ListView1.Items.Add(New ListViewItem(New String() {"Loaded profile", CompUser}))
            Next
            Dim indexof = CompUser.IndexOf("\")
            If indexof <> -1 Then
                Dim domain = Mid(CompUser, 1, indexof)
                CompUser = Mid(CompUser, indexof + 2)
                If domain <> COMP Then
                    Dim ADEntry As New System.DirectoryServices.DirectoryEntry("WinNT://" & domain) '"LDAP://domainname") '"WinNT://" & a(0) & "/" & a(1))
                    Dim adsUser As DirectoryEntry
                    For Each adsUser In ADEntry.Children
                        If adsUser.SchemaClassName = "User" And adsUser.Name = CompUser Then
                            ListView1.Items.Add(New ListViewItem(New String() {"Profile details", adsUser.Properties("FullName").Value.ToString()}))
                        End If
                    Next
                End If
            End If

            PARAM = "General"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub getProcessesFunc()
        Label1.Text = "Processes of " & COMP
        Dim objWMIService, col
        Dim row() As String
        Dim rows(1000) As ListViewItem
        Dim i As Integer = 0

        Try
            ListView1.Items.Clear()
            If PARAM <> "Process" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("ProcessName", "Process name", 200)
                ListView1.Columns.Add("ProcessID", "Process ID", 80)
                ListView1.Columns.Add("ProcessPath", "Path to file", 300)
            End If
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\CIMV2")
            col = objWMIService.ExecQuery("SELECT ExecutablePath, Name, ProcessID FROM Win32_Process")
            ' Number of columns
            Dim columns = ListView1.Columns.Count
            ' Number of objects in collection
            Dim objects = -1
            For Each obj In col
                objects = objects + 1
            Next
            ReDim row(columns)
            ReDim rows(objects)
            For Each objProcess In col
                row(0) = objProcess.Name.ToString()
                row(1) = objProcess.ProcessID.ToString()
                row(2) = objProcess.ExecutablePath.ToString()

                rows(i) = New ListViewItem(row)
                i = i + 1
            Next
            ListView1.Items.AddRange(rows)
            ListView1.Sorting = SortOrder.Ascending
            ListView1.TopItem.Selected = True

            For Each item In ListView1.Items
                item.ImageKey = "processes.png"
            Next
            PARAM = "Process"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub getServicesFunc()
        Label1.Text = "Services of " & COMP
        Dim objWMIService, col
        Dim row() As String
        Dim rows(1000) As ListViewItem
        Dim i As Integer = 0

        Try
            ListView1.Items.Clear()
            ListView1.Sorting = SortOrder.Ascending
            If PARAM <> "Service" Then
                ListView1.View = View.Details
                ListView1.Columns.Clear()
                ListView1.Columns.Add("Service", 200)
                ListView1.Columns.Add("Description", 200)
                ListView1.Columns.Add("States", 100)
                ListView1.Columns.Add("Start mode", 110)
            End If

            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            col = objWMIService.ExecQuery("SELECT Description, DisplayName, StartMode, State FROM Win32_Service")

            ' Number of columns
            Dim columns = ListView1.Columns.Count
            '
            Dim objects = -1
            For Each obj In col
                objects = objects + 1
            Next
            ReDim row(columns)
            ReDim rows(objects)
            ' Add data to ListView
            For Each obj In col
                row(0) = obj.DisplayName.ToString()
                row(1) = obj.Description.ToString()
                'row(2) = serviceState(obj.State.ToString())
                row(2) = obj.State.ToString()
                'row(3) = serviceStartMode(obj.StartMode.ToString())
                row(3) = obj.StartMode.ToString()
                rows(i) = New ListViewItem(row)
                i = i + 1
            Next
            ListView1.Items.AddRange(rows)
            ListView1.TopItem.Selected = True

            For Each item In ListView1.Items
                item.ImageKey = "services.png"
            Next
            PARAM = "Service"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Public Sub getSharesFunc()
        Label1.Text = "Shares of " & COMP
        Dim objWMIService, col
        Dim row() As String
        Dim rows(1000) As ListViewItem
        Dim i As Integer = 0

        Try
            ListView1.Items.Clear()
            If PARAM <> "Share" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("ShareName", "Name", 150)
                ListView1.Columns.Add("ShareType", "Type", 80)
                ListView1.Columns.Add("ShareDescription", "Description", 150)
                ListView1.Columns.Add("SharePath", "Path", 200)
            End If

            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            col = objWMIService.ExecQuery("Select * from Win32_Share")

            ' Number of columns
            Dim columns = ListView1.Columns.Count
            ' Number of objects in collection
            Dim objects = -1
            For Each obj In col
                objects = objects + 1
            Next
            ReDim row(columns)
            ReDim rows(objects)
            ' Write data to ListView
            For Each obj In col
                row(0) = obj.Name.ToString()
                row(1) = obj.Type.ToString()
                row(2) = obj.Description.ToString()
                row(3) = obj.Path.ToString()
                Select Case row(1)
                    Case "-2147483648"
                        row(1) = ""
                    Case "-2147483645"
                        row(1) = ""
                    Case "-2147483651"
                        row(1) = ""
                    Case "0"
                        row(1) = "Folder"
                    Case "1"
                        row(1) = "Printer"
                    Case "2"
                        row(1) = "Device"
                    Case "3"
                        row(1) = "IPC"
                    Case Else
                        row(1) = ""
                End Select
                rows(i) = New ListViewItem(row)
                i = i + 1
            Next
            ListView1.Items.AddRange(rows)
            ListView1.Sorting = SortOrder.Ascending
            ListView1.TopItem.Selected = True

            For Each item In ListView1.Items
                item.ImageKey = "shares.png"
            Next
            PARAM = "Share"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub getSoftwareFunc()
        Label1.Text = "Software of " & COMP
        Dim objReg, objSoft, HKLM, Path, pathSoft
        Dim col()
        Dim row() As String
        Dim rows(1000) As ListViewItem
        Dim i As Integer = 0

        Try
            ListView1.Items.Clear()
            If PARAM <> "Software" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("SoftDisplayName", "Name", 400)
                ListView1.Columns.Add("SoftDisplayVersion", "Version", 100)
                ListView1.Columns.Add("SoftInstallDate", "Date of installation", 100)
                'ListView1.Columns.Add("ServStartMode", "Start mode")
            End If


            ReDim col(254)
            objReg = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\default:StdRegProv")
            HKLM = &H80000002
            Path = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
            objReg.EnumKey(HKLM, Path, col)

            ' Number of columns
            Dim columns = ListView1.Columns.Count
            ReDim row(columns)
            ' Number of objects in collection
            Dim objects = -1
            For Each obj In col
                pathSoft = Path & "\" & obj.ToString()
                Try
                    objReg.GetStringValue(HKLM, pathSoft, "DisplayName", row(0))
                Catch
                    row(0) = Nothing
                End Try
                If row(0) IsNot Nothing Then
                    objects = objects + 1
                End If
            Next
            ReDim rows(objects)
            For Each objSoft In col
                pathSoft = Path & "\" & objSoft.ToString()
                Try
                    objReg.GetStringValue(HKLM, pathSoft, "DisplayName", row(0))
                Catch
                    row(0) = Nothing
                End Try
                If row(0) IsNot Nothing Then
                    Try
                        objReg.GetStringValue(HKLM, pathSoft, "DisplayVersion", row(1))
                    Catch
                        row(1) = "-"
                    End Try
                    Try
                        objReg.GetStringValue(HKLM, pathSoft, "InstallDate", row(2))
                    Catch
                        row(2) = "-"
                    End Try
                    'objReg.GetExpandedStringValue( $HKLM, $pathSoft, "UninstallString", $softUnin )
                    'softUnin = StringReplace( $softUnin, "MsiExec.exe /I{", "MsiExec.exe /X{" )
                    rows(i) = New ListViewItem(row)
                    i = i + 1
                End If
            Next
            ListView1.Items.AddRange(rows)
            ListView1.Sorting = SortOrder.Ascending
            ListView1.TopItem.Selected = True

            For Each item In ListView1.Items
                item.ImageKey = "software.png"
            Next
            PARAM = "Software"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Public Sub getUsersFunc()
        Try
            Label1.Text = "Users of " & COMP
            Dim row() As String
            Dim rows(1000) As ListViewItem
            Dim i As Integer = 0
            Dim proper = ""
            Dim ADS_UF_SCRIPT = Nothing
            Dim ADS_UF_ACCOUNTDISABLE = Nothing
            Dim ADS_UF_HOMEDIR_REQUIRED = Nothing
            Dim ADS_UF_LOCKOUT = Nothing
            Dim ADS_UF_PASSWD_NOTREQD = Nothing
            Dim ADS_UF_PASSWD_CANT_CHANGE = Nothing
            Dim ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = Nothing
            Dim ADS_UF_TEMP_DUPLICATE_ACCOUNT = Nothing
            Dim ADS_UF_NORMAL_ACCOUNT = Nothing
            Dim ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = Nothing
            Dim ADS_UF_WORKSTATION_TRUST_ACCOUNT = Nothing
            Dim ADS_UF_SERVER_TRUST_ACCOUNT = Nothing
            Dim ADS_UF_DONT_EXPIRE_PASSWD = Nothing
            Dim ADS_UF_MNS_LOGON_ACCOUNT = Nothing
            Dim ADS_UF_SMARTCARD_REQUIRED = Nothing
            Dim ADS_UF_TRUSTED_FOR_DELEGATION = Nothing
            Dim ADS_UF_NOT_DELEGATED = Nothing
            Dim ADS_UF_USE_DES_KEY_ONLY = Nothing
            Dim ADS_UF_DONT_REQUIRE_PREAUTH = Nothing
            Dim ADS_UF_PASSWORD_EXPIRED = Nothing
            Dim ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = Nothing

            ListView1.Items.Clear()
            If PARAM <> "Users" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("UserName", "Name", 150)
                ListView1.Columns.Add("UserState", "State", 100)
                ListView1.Columns.Add("UserFullname", "Full name", 200)
                ListView1.Columns.Add("UserDescription", "Description", 300)
            End If
            ' Number of columns
            ReDim row(ListView1.Columns.Count)
            Dim objects = -1
            Dim dirEntry As New DirectoryEntry("WinNT://" & COMP)
            For Each child In dirEntry.Children
                If child.SchemaClassName = "User" Then
                    objects = objects + 1
                End If
            Next
            ReDim rows(objects)
            For Each child In dirEntry.Children
                If child.SchemaClassName = "User" Then
                    Dim flag = child.Properties("userflags").Value()
                    If flag >= 16777216 Then
                        flag = flag - 16777216
                        ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = True
                    End If
                    If flag >= 8388608 Then
                        flag = flag - 8388608
                        ADS_UF_PASSWORD_EXPIRED = True
                    End If
                    If flag >= 4194304 Then
                        flag = flag - 4194304
                        ADS_UF_DONT_REQUIRE_PREAUTH = True
                    End If
                    If flag >= 2097152 Then
                        flag = flag - 2097152
                        ADS_UF_USE_DES_KEY_ONLY = True
                    End If
                    If flag >= 1048576 Then
                        flag = flag - 1048576
                        ADS_UF_NOT_DELEGATED = True
                    End If
                    If flag >= 524288 Then
                        flag = flag - 524288
                        ADS_UF_TRUSTED_FOR_DELEGATION = True
                    End If
                    If flag >= 262144 Then
                        flag = flag - 262144
                        ADS_UF_SMARTCARD_REQUIRED = True
                    End If
                    If flag >= 131072 Then
                        flag = flag - 131072
                        ADS_UF_MNS_LOGON_ACCOUNT = True
                    End If
                    If flag >= 65536 Then
                        flag = flag - 65536
                        ADS_UF_DONT_EXPIRE_PASSWD = True
                    End If
                    If flag >= 8192 Then
                        flag = flag - 8192
                        ADS_UF_SERVER_TRUST_ACCOUNT = True
                    End If
                    If flag >= 4096 Then
                        flag = flag - 4096
                        ADS_UF_WORKSTATION_TRUST_ACCOUNT = True
                    End If
                    If flag >= 2048 Then
                        flag = flag - 2048
                        ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = True
                    End If
                    If flag >= 512 Then
                        flag = flag - 512
                        ADS_UF_NORMAL_ACCOUNT = True
                    End If
                    If flag >= 256 Then
                        flag = flag - 256
                        ADS_UF_TEMP_DUPLICATE_ACCOUNT = True
                    End If
                    If flag >= 128 Then
                        flag = flag - 128
                        ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = True
                    End If
                    If flag >= 64 Then
                        flag = flag - 64
                        ADS_UF_PASSWD_CANT_CHANGE = True
                    End If
                    If flag >= 32 Then
                        flag = flag - 32
                        ADS_UF_PASSWD_NOTREQD = True
                    End If
                    If flag >= 16 Then
                        flag = flag - 16
                        ADS_UF_LOCKOUT = True
                    End If
                    If flag >= 8 Then
                        flag = flag - 8
                        ADS_UF_HOMEDIR_REQUIRED = True
                    End If
                    If flag >= 2 Then
                        flag = flag - 2
                        ADS_UF_ACCOUNTDISABLE = True
                    End If
                    If flag >= 1 Then
                        flag = flag - 1
                        ADS_UF_SCRIPT = True
                    End If

                    row(0) = child.Name
                    If ADS_UF_ACCOUNTDISABLE Then
                        row(1) = "Disabled"
                    Else
                        row(1) = ""
                    End If
                    row(2) = child.Properties("fullname").Value()
                    row(3) = child.Properties("description").Value()
                    rows(i) = New ListViewItem(row)
                    i = i + 1
                    'For Each prop In child.properties.PropertyNames
                    'proper = proper & prop & Chr(13)
                    'Next
                    ADS_UF_SCRIPT = Nothing
                    ADS_UF_ACCOUNTDISABLE = Nothing
                    ADS_UF_HOMEDIR_REQUIRED = Nothing
                    ADS_UF_LOCKOUT = Nothing
                    ADS_UF_PASSWD_NOTREQD = Nothing
                    ADS_UF_PASSWD_CANT_CHANGE = Nothing
                    ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = Nothing
                    ADS_UF_TEMP_DUPLICATE_ACCOUNT = Nothing
                    ADS_UF_NORMAL_ACCOUNT = Nothing
                    ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = Nothing
                    ADS_UF_WORKSTATION_TRUST_ACCOUNT = Nothing
                    ADS_UF_SERVER_TRUST_ACCOUNT = Nothing
                    ADS_UF_DONT_EXPIRE_PASSWD = Nothing
                    ADS_UF_MNS_LOGON_ACCOUNT = Nothing
                    ADS_UF_SMARTCARD_REQUIRED = Nothing
                    ADS_UF_TRUSTED_FOR_DELEGATION = Nothing
                    ADS_UF_NOT_DELEGATED = Nothing
                    ADS_UF_USE_DES_KEY_ONLY = Nothing
                    ADS_UF_DONT_REQUIRE_PREAUTH = Nothing
                    ADS_UF_PASSWORD_EXPIRED = Nothing
                    ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = Nothing
                End If
            Next
            'MsgBox(proper)
            ListView1.Items.AddRange(rows)
            ListView1.Sorting = SortOrder.Ascending

            For Each item In ListView1.Items
                If item.Subitems(1).Text = "Disabled" Then
                    item.ImageKey = "users_disable.png"
                Else
                    item.ImageKey = "users.png"
                End If
            Next

            PARAM = "Users"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Create user" context menu of users
    Private Sub UserCrete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles userCreate.Click
        userCreateFunc()
    End Sub

    Private Sub userCreateFunc()
        userCreateForm.Show()
    End Sub

    ' "Delete" context menu of users
    Private Sub UserRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles userRemove.Click
        userRemoveFunc()
    End Sub

    Private Sub userRemoveFunc()
        Try
            Dim userName = ListView1.SelectedItems.Item(0).SubItems(0).Text
            Dim answer = MsgBox("Delete user " & userName & "?", MsgBoxStyle.YesNo, "Saqwel Remote Administration Tool")
            If answer = MsgBoxResult.Yes Then
                Dim AD As DirectoryEntry = New DirectoryEntry("WinNT://" & COMP)
                Dim objUser = AD.Children.Find(userName, "user")
                AD.Children.Remove(objUser)
                ListView1.SelectedItems.Item(0).Remove()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Properties" context menu of users
    Private Sub UserProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles userProperties.Click
        userPropertiesForm.Show()
    End Sub

    ' "Change" context menu of users
    Private Sub UserPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles userPassword.Click
        userPasswordForm.Show()
    End Sub

    ' "Refresh" context menu of users
    Private Sub UserRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles userRefresh.Click
        getUsersFunc()
    End Sub

    Public Sub getGroupsFunc()
        Try
            ListView1.Sorting = SortOrder.None
            Label1.Text = "Goups of " & COMP
            Dim row() As String
            Dim rows(1000) As ListViewItem
            Dim i As Integer = 0

            ListView1.Items.Clear()
            If PARAM <> "Groups" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("GroupName", "Name", 200)
                ListView1.Columns.Add("GroupFullname", "Description", 300)
            End If
            ' Number of columns
            ReDim row(ListView1.Columns.Count)
            Dim objects = -1
            Dim dirEntry As New DirectoryEntry("WinNT://" & COMP)
            For Each child In dirEntry.Children
                If child.SchemaClassName = "Group" Then
                    objects = objects + 1
                End If
            Next
            ReDim rows(objects)
            For Each child In dirEntry.Children
                If child.SchemaClassName = "Group" Then
                    row(0) = child.Name
                    row(1) = child.Properties("description").Value()
                    rows(i) = New ListViewItem(row)
                    i = i + 1
                End If
            Next
            ListView1.Items.AddRange(rows)
            ListView1.Sorting = SortOrder.Ascending

            For Each item In ListView1.Items
                item.ImageKey = "groups.png"
            Next
            PARAM = "Groups"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub groupProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles groupProperties.Click
        groupPropertiesForm.Show()
    End Sub

    Private Sub groupAddMember_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles groupAddMember.Click
        groupPropertiesForm.Show()
    End Sub

    Private Sub groupRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles groupRemove.Click
        groupRemoveFunc()
    End Sub

    Private Sub groupRemoveFunc()
        Try
            Dim groupName, objComp
            groupName = ListView1.SelectedItems.Item(0).SubItems(0).Text
            Dim answer = MsgBox("Delete group " & groupName & "?", MsgBoxStyle.YesNo, "Saqwel Remote Administration Tool")
            If answer = MsgBoxResult.Yes Then
                objComp = GetObject("WinNT://" & COMP)
                objComp.Delete("group", groupName)
                ListView1.SelectedItems.Item(0).Remove()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub groupRename_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles groupRename.Click
        ListView1.LabelEdit = True
        ListView1.SelectedItems.Item(0).BeginEdit()
    End Sub

    Private Sub groupRenameFunc(ByVal e As System.Windows.Forms.LabelEditEventArgs)
        Try
            Dim obj, col, objWMIService, echo
            Dim oldGroupName = ListView1.SelectedItems.Item(0).SubItems(0).Text
            Dim newGroupName = e.Label.ToString
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            col = objWMIService.ExecQuery("select Name from Win32_Group where name = '" & oldGroupName & "'")

            For Each obj In col
                echo = obj.Rename(newGroupName)
                If echo = 0 Then
                    ListView1.SelectedItems.Item(0).SubItems(0).Text = newGroupName
                Else
                    MsgBox("Can't rename group", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
                End If
            Next
            ListView1.LabelEdit = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub userRenameFunc(ByVal e As System.Windows.Forms.LabelEditEventArgs)
        Try
            Dim obj, col, objWMIService, echo
            Dim oldUserName = ListView1.SelectedItems.Item(0).SubItems(0).Text
            Dim newUserName = e.Label.ToString
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            col = objWMIService.ExecQuery("select Name from Win32_UserAccount where name = '" & oldUserName & "'")

            For Each obj In col
                echo = obj.Rename(newUserName)
                If echo = 0 Then
                    ListView1.SelectedItems.Item(0).SubItems(0).Text = newUserName
                Else
                    MsgBox("Can't rename user", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
                End If
            Next
            ListView1.LabelEdit = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub UserRename_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles userRename.Click
        ListView1.LabelEdit = True
        ListView1.SelectedItems.Item(0).BeginEdit()
    End Sub

    Private Sub groupCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles groupCreate.Click
        groupCreateForm.Show()
    End Sub

    Private Sub groupRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles groupRefresh.Click
        getGroupsFunc()
    End Sub

    Private Sub shareCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles shareCreate.Click
        shareCreateForm.Show()
    End Sub

    Private Sub shareRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles shareRemove.Click
        Try
            Dim col, objWMIService
            Dim resultText = "Error"
            Dim shareName = ListView1.SelectedItems.Item(0).SubItems(0).Text
            Dim answer = MsgBox("Are you sure that you want to stop sharing " & shareName & "?", MsgBoxStyle.YesNo, "Saqwel Remote Administration Tool")
            If answer = MsgBoxResult.Yes Then
                objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
                col = objWMIService.ExecQuery("select * from Win32_Share where Name = '" & shareName & "'")
                For Each obj In col
                    Dim result = obj.Delete()
                    If result = 0 Then
                        ListView1.SelectedItems.Item(0).Remove()
                    Else
                        Select Case result
                            Case 2
                                resultText = "No access"
                            Case 8
                                resultText = "Unknown error"
                            Case 9
                                resultText = "Wrog name"
                            Case 10
                                resultText = "Wrong security level"
                            Case 21
                                resultText = "Wrong parameter"
                            Case 22
                                resultText = "Such share already exist"
                            Case 23
                                resultText = "Redirected path"
                            Case 24
                                resultText = "Unknown directory or device"
                            Case 25
                                resultText = "Netowrk name not found"
                        End Select
                        MsgBox(resultText, MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Erro Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub shareProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles shareProperties.Click
        sharePropertiesForm.Show()
    End Sub

    Private Sub partitionProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles partitionProperties.Click
        partitionPropertiesForm.Show()
    End Sub

    Function datetimeFormat(ByVal time, ByVal objDatetime)
        Dim datetime, Day, Month, Year, Hours, Minutes, Seconds
        objDatetime.value = time
        If objDatetime.Day < 10 Then
            Day = "0" & objDatetime.Day.ToString
        Else
            Day = objDatetime.Day.ToString
        End If
        If objDatetime.Month < 10 Then
            Month = "0" & objDatetime.Month.ToString
        Else
            Month = objDatetime.Month.ToString
        End If
        If objDatetime.Year < 10 Then
            Year = "0" & objDatetime.Year.ToString
        Else
            Year = objDatetime.Year.ToString
        End If
        If objDatetime.Hours < 10 Then
            Hours = "0" & objDatetime.Hours.ToString
        Else
            Hours = objDatetime.Hours.ToString
        End If
        If objDatetime.Minutes < 10 Then
            Minutes = "0" & objDatetime.Minutes.ToString
        Else
            Minutes = objDatetime.Minutes.ToString
        End If
        If objDatetime.Seconds < 10 Then
            Seconds = "0" & objDatetime.Seconds.ToString
        Else
            Seconds = objDatetime.Seconds.ToString
        End If
        datetime = Day & "." & Month & "." & Year & " " & Hours & ":" & Minutes & ":" & Seconds
        Return datetime
    End Function

    Private Sub partitionRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles partitionRefresh.Click
        getPartitionsFunc()
    End Sub

    Private Sub generalRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles generalRefresh.Click
        getGeneralInformationFunc()
    End Sub

    Private Sub generalDescription_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles generalDescription.Click
        generalDescriptionForm.Show()
    End Sub

    Private Sub mainMenuFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuFileExit.Click
        Close()
    End Sub

    Private Sub getTerminalSessionsFunc()
        Try
            Dim row() As String
            Dim rows() As ListViewItem
            Dim i = 0

            ListView1.Items.Clear()

            If PARAM <> "TerminalSessions" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("sessionName", "Session name", 120)
                ListView1.Columns.Add("sessionID", "Session ID", 70)
                ListView1.Columns.Add("sessionUser", "User name", 130)
                ListView1.Columns.Add("sessionComp", "Computer name", 120)
                ListView1.Columns.Add("sessionState", "State", 100)

            End If
            ReDim row(ListView1.Columns.Count)

            Dim manager As ITerminalServicesManager = New TerminalServicesManager()
            Dim server As ITerminalServer = manager.GetRemoteServer(COMP)
            server.Open()
            ReDim rows(server.GetSessions.Count - 1)
            For Each session In server.GetSessions()
                Try
                    row(0) = session.WindowStationName
                Catch
                End Try
                Try
                    row(1) = session.SessionId.ToString
                Catch
                End Try
                Try
                    row(2) = session.UserName
                Catch
                End Try
                Try
                    row(3) = session.ClientName
                Catch
                End Try
                Try
                    row(4) = terminalStateFunc(session.ConnectionState)
                Catch
                End Try
                rows(i) = New ListViewItem(row)
                i = i + 1
            Next
            ListView1.Items.AddRange(rows)
            PARAM = "TerminalSessions"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Erro Saqwel Remote Administration Tool")
        End Try
    End Sub

    Function terminalStateFunc(ByVal value)
        Dim textCS = ""
        Select Case value
            Case 0
                textCS = "Active"
            Case 1
                textCS = "Connected"
            Case 2
                textCS = "ConnectQuery"
            Case 3
                textCS = "Shadowing"
            Case 4
                textCS = "Disconnected"
            Case 5
                textCS = "Idle"
            Case 6
                textCS = "Listening"
            Case 7
                textCS = "Reset"
            Case 8
                textCS = "Down"
            Case 9
                textCS = "Initializing"
        End Select
        Return textCS
    End Function

    Function getComputer(ByVal computerName)
        Try
            COMP = UCase(computerName)
            TextBox1.Text = COMP
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
        Return COMP
    End Function

    Private Sub getProcessorFunc()
        Try
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("Select * from Win32_Processor")
            ListView1.Items.Clear()
            ListView1.Sorting = SortOrder.None

            If PARAM <> "Processor" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("storageParamName", "Parameter name", 200)
                ListView1.Columns.Add("storageParamValue", "Parameter value", 400)
            End If
            For Each obj In col
                ' Processor
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Processor", obj.Name}))
                    ListView1.Items.Item(ListView1.Items.Count - 1).ImageKey = "processor.png"
                Catch ex As Exception
                End Try
                ' Processor
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"", obj.Caption}))
                Catch ex As Exception
                End Try
                ' Max frequency
                Dim speed
                Try
                    If obj.MaxClockSpeed >= 1000 Then
                        speed = Math.Round(obj.MaxClockSpeed / 1000, 1) & " GHz"
                    Else
                        speed = obj.MaxClockSpeed & " МГц"
                    End If
                    ListView1.Items.Add(New ListViewItem(New String() {"Max frequency", speed}))
                Catch ex As Exception
                End Try
                ' Socket
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Socket", obj.SocketDesignation}))
                Catch ex As Exception
                End Try
                ' Architecture
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Architecture", procArсh(obj.Architecture)}))
                Catch ex As Exception
                End Try
                ' Manufacturer
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Manufacturer", obj.Manufacturer}))
                Catch ex As Exception
                End Try
                ' Family
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Family", procFamily(obj.Family)}))
                Catch ex As Exception
                End Try
                ' Cache size L2
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Cache size L2", obj.L2CacheSize & " Кб"}))
                Catch ex As Exception
                End Try
                ' Cache size L3
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Cache size L3", obj.L3CacheSize & " Кб"}))
                Catch ex As Exception
                End Try
                ' Usage state
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"State", procState(obj.CpuStatus)}))
                Catch ex As Exception
                End Try
                ' 
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"", ""}))
                Catch ex As Exception
                End Try
            Next
            PARAM = "Processor"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Function procArсh(ByVal value)
        Dim archName = "Unknown"
        Select Case value
            Case 0
                archName = "x86"
            Case 1
                archName = "MIPS"
            Case 2
                archName = "Alpha"
            Case 3
                archName = "PowerPC"
            Case 5
                archName = "ARM"
            Case 6
                archName = "Itanium-based systems"
            Case 9
                archName = "x64"
        End Select
        Return archName
    End Function

    Function procState(ByVal value)
        Dim stateName = "Unknown"
        Select Case value
            Case 1
                stateName = "Accessible"
            Case 2
                stateName = "Disabled in BIOS"
            Case 3
                stateName = "Disabled in BIOS (POST errors)"
            Case 4
                stateName = "Idle"
        End Select
        Return stateName
    End Function

    Function procFamily(ByVal value)
        Dim familyName = "Unknown"
        Select Case value
            Case 3
                familyName = "8086"
            Case 4
                familyName = "80286"
            Case 5
                familyName = "Intel386™ Processor"
            Case 6
                familyName = "Intel486™ Processor"
            Case 7
                familyName = "8087"
            Case 8
                familyName = "80287"
            Case 9
                familyName = "80387"
            Case 10
                familyName = "80487"
            Case 11
                familyName = "Pentium Brand"
            Case 12
                familyName = "Pentium Pro"
            Case 13
                familyName = "Pentium II"
            Case 14
                familyName = "Pentium Processor with MMX™ Technology"
            Case 15
                familyName = "Celeron™"
            Case 16
                familyName = "Pentium II Xeon™"
            Case 17
                familyName = "Pentium III"
            Case 18
                familyName = "M1 Family"
            Case 19
                familyName = "M2 Family"
            Case 24
                familyName = "AMD Duron™ Processor Family"
            Case 25
                familyName = "K5 Family"
            Case 26
                familyName = "K6 Family"
            Case 27
                familyName = "K6-2"
            Case 28
                familyName = "K6-3"
            Case 29
                familyName = "AMD Athlon™ Processor Family"
            Case 30
                familyName = "AMD2900 Family"
            Case 31
                familyName = "K6-2+"
            Case 32
                familyName = "Power PC Family"
            Case 33
                familyName = "Power PC 601"
            Case 34
                familyName = "Power PC 603"
            Case 35
                familyName = "Power PC 603+"
            Case 36
                familyName = "Power PC 604"
            Case 37
                familyName = "Power PC 620"
            Case 38
                familyName = "Power PC X704"
            Case 39
                familyName = "Power PC 750"
            Case 48
                familyName = "Alpha Family"
            Case 49
                familyName = "Alpha 21064"
            Case 50
                familyName = "Alpha 21066"
            Case 51
                familyName = "Alpha 21164"
            Case 52
                familyName = "Alpha 21164PC"
            Case 53
                familyName = "Alpha 21164a"
            Case 54
                familyName = "Alpha 21264"
            Case 55
                familyName = "Alpha 21364"
            Case 64
                familyName = "MIPS Family"
            Case 65
                familyName = "MIPS R4000"
            Case 66
                familyName = "MIPS R4200"
            Case 67
                familyName = "MIPS R4400"
            Case 68
                familyName = "MIPS R4600"
            Case 69
                familyName = "MIPS R10000"
            Case 80
                familyName = "SPARC Family"
            Case 81
                familyName = "SuperSPARC"
            Case 82
                familyName = "microSPARC II"
            Case 83
                familyName = "microSPARC IIep"
            Case 84
                familyName = "UltraSPARC"
            Case 85
                familyName = "UltraSPARC II"
            Case 86
                familyName = "UltraSPARC IIi"
            Case 87
                familyName = "UltraSPARC III"
            Case 88
                familyName = "UltraSPARC IIIi"
            Case 96
                familyName = "68040"
            Case 97
                familyName = "68xxx Family"
            Case 98
                familyName = "68000"
            Case 99
                familyName = "68010"
            Case 100
                familyName = "68020"
            Case 101
                familyName = "68030"
            Case 112
                familyName = "Hobbit Family"
            Case 120
                familyName = "Crusoe™ TM5000 Family"
            Case 121
                familyName = "Crusoe™ TM3000 Family"
            Case 122
                familyName = "Efficeon™ TM8000 Family"
            Case 128
                familyName = "Weitek"
            Case 130
                familyName = "Itanium™ Processor"
            Case 131
                familyName = "AMD Athlon™ 64 Processor Family"
            Case 132
                familyName = "AMD Opteron™ Processor Family"
            Case 144
                familyName = "PA-RISC Family"
            Case 145
                familyName = "PA-RISC 8500"
            Case 146
                familyName = "PA-RISC 8000"
            Case 147
                familyName = "PA-RISC 7300LC"
            Case 148
                familyName = "PA-RISC 7200"
            Case 149
                familyName = "PA-RISC 7100LC"
            Case 150
                familyName = "PA-RISC 7100"
            Case 160
                familyName = "V30 Family"
            Case 176
                familyName = "Pentium III Xeon™ Processor"
            Case 177
                familyName = "Pentium III Processor with Intel SpeedStep™ Technology"
            Case 178
                familyName = "Pentium 4"
            Case 179
                familyName = "Intel Xeon™"
            Case 180
                familyName = "AS400 Family"
            Case 181
                familyName = "Intel Xeon™ Processor MP"
            Case 182
                familyName = "AMD Athlon™ XP Family"
            Case 183
                familyName = "AMD Athlon™ MP Family"
            Case 184
                familyName = "Intel Itanium 2"
            Case 185
                familyName = "Intel Pentium M Processor"
            Case 190
                familyName = "K7"
            Case 200
                familyName = "IBM390 Family"
            Case 201
                familyName = "G4"
            Case 202
                familyName = "G5"
            Case 203
                familyName = "G6"
            Case 204
                familyName = "z/Architecture Base"
            Case 250
                familyName = "i860"
            Case 251
                familyName = "i960"
            Case 260
                familyName = "SH-3"
            Case 261
                familyName = "SH-4"
            Case 280
                familyName = "ARM"
            Case 281
                familyName = "StrongARM"
            Case 300
                familyName = "6x86"
            Case 301
                familyName = "MediaGX"
            Case 302
                familyName = "MII"
            Case 320
                familyName = "WinChip"
            Case 350
                familyName = "DSP"
            Case 500
                familyName = "Video Processor"
        End Select
        Return familyName
    End Function

    Private Sub getMemoryFunc()
        Try
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("Select Caption, Capacity, DeviceLocator, Manufacturer, MemoryType, Model, Speed from  Win32_PhysicalMemory")
            ListView1.Items.Clear()
            ListView1.Sorting = SortOrder.None

            If PARAM <> "Memory" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("storageParamName", "Parameter name", 200)
                ListView1.Columns.Add("storageParamValue", "Parameter value", 400)
            End If
            For Each obj In col
                ' Memory
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Memory", obj.Caption}))
                    ListView1.Items.Item(ListView1.Items.Count - 1).ImageKey = "memory.png"
                Catch ex As Exception
                End Try
                ' Capacity
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Capacity", Math.Round(obj.Capacity / 1048576) & " Мб"}))
                Catch ex As Exception
                End Try
                ' Slot
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Slot", obj.DeviceLocator}))
                Catch ex As Exception
                End Try
                ' Manufacturer
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Manufacturer", obj.Manufacturer}))
                Catch ex As Exception
                End Try
                ' Type
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Type", memoryType(obj.MemoryType)}))
                Catch ex As Exception
                End Try
                ' Model
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Model", obj.Model}))
                Catch ex As Exception
                End Try
                ' Speed
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Speed", obj.Speed & " МГц"}))
                Catch ex As Exception
                End Try
                ' 
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"", ""}))
                Catch ex As Exception
                End Try
            Next
            PARAM = "Memory"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Function memoryType(ByVal value)
        Dim typeName = "Unknown"
        Select Case value
            Case 2
                typeName = "DRAM"
            Case 3
                typeName = "Synchronous(DRAM)"
            Case 4
                typeName = "Cache(DRAM)"
            Case 5
                typeName = "EDO"
            Case 6
                typeName = "EDRAM"
            Case 7
                typeName = "VRAM"
            Case 8
                typeName = "SRAM"
            Case 9
                typeName = "RAM"
            Case 10
                typeName = "ROM"
            Case 11
                typeName = "Flash"
            Case 12
                typeName = "EEPROM"
            Case 13
                typeName = "FEPROM"
            Case 14
                typeName = "EPROM"
            Case 15
                typeName = "CDRAM"
            Case 16
                typeName = "3DRAM"
            Case 17
                typeName = "SDRAM"
            Case 18
                typeName = "SGRAM"
            Case 19
                typeName = "RDRAM"
            Case 20
                typeName = "DDR"
            Case 21
                typeName = "DDR-2"
        End Select
        Return typeName
    End Function

    Private Sub getStorageFunc()
        Try
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("Select * from Win32_DiskDrive")
            ListView1.Items.Clear()
            ListView1.Sorting = SortOrder.None

            If PARAM <> "Storage" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("storageParamName", "Prameter name", 200)
                ListView1.Columns.Add("storageParamValue", "Parameter value", 400)
            End If
            For Each obj In col
                ' Hard drive
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Hard drive", obj.Caption}))
                    ListView1.Items.Item(ListView1.Items.Count - 1).ImageKey = "storages.png"
                Catch ex As Exception
                End Try
                ' Size
                Dim size
                Try
                    size = Math.Round(obj.Size / 1073741824) & " GB"
                Catch ex As Exception
                    size = "Unknown"
                End Try
                ListView1.Items.Add(New ListViewItem(New String() {"Size", size}))
                ' Connection interface
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Interface", obj.InterfaceType}))
                Catch ex As Exception
                End Try
                ' Type
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Type", obj.MediaType}))
                Catch ex As Exception
                End Try
                ' Number of partitions
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Partitions", obj.Partitions}))
                Catch ex As Exception
                End Try
                ' Serial number
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Serial number", obj.SerialNumber.ToString}))
                Catch ex As Exception
                End Try
                ' Cylinders
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Cylinders", obj.TotalCylinders.ToString}))
                Catch ex As Exception
                End Try
                ' Heads
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Heads", obj.TotalHeads.ToString}))
                Catch ex As Exception
                End Try
                ' Sectors
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Sectors", obj.TotalSectors.ToString}))
                Catch ex As Exception
                End Try
                ' Tracks
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Tracks", obj.TotalTracks.ToString}))
                Catch ex As Exception
                End Try
                ' Tracks per cylinder
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Tracks per cylinder", obj.TracksPerCylinder.ToString}))
                Catch ex As Exception
                End Try
                ' PnP identity
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"PnP identity", obj.PNPDeviceID}))
                Catch ex As Exception
                End Try
                ' 
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"", ""}))
                Catch ex As Exception
                End Try

            Next
            PARAM = "Storage"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub getNetworkFunc()
        Try
            Dim colAdapter
            Dim objDatetime = CreateObject("WbemScripting.SWbemDateTime")

            ListView1.Items.Clear()
            ListView1.Sorting = SortOrder.None

            If PARAM <> "Network" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("networkParamName", "Prameter name", 200)
                ListView1.Columns.Add("networkParamValue", "Parameter value", 400)
            End If
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("Select Description, MACAddress, DHCPEnabled, IPAddress, IPSubnet, DefaultIPGateway, DHCPLeaseObtained, DHCPLeaseExpires, DHCPServer, WINSPrimaryServer, DNSServerSearchOrder from Win32_NetworkAdapterConfiguration WHERE IPEnabled=true")

            For Each obj In col
                ' Network
                ListView1.Items.Add(New ListViewItem(New String() {"Network", obj.Description.ToString}))
                ListView1.Items.Item(ListView1.Items.Count - 1).ImageKey = "network.png"
                ' Hardware settings
                colAdapter = objWMIService.ExecQuery("Select AdapterType, PNPDeviceID from Win32_NetworkAdapter WHERE MACAddress='" & obj.MACAddress & "'")
                Dim i = 0
                For Each objAdapter In colAdapter
                    If i = 0 Then
                        Try
                            ListView1.Items.Add(New ListViewItem(New String() {"Adapter type", objAdapter.AdapterType.ToString()}))
                        Catch
                        End Try
                        Try
                            ListView1.Items.Add(New ListViewItem(New String() {"PnP identity", objAdapter.PNPDeviceID.ToString()}))
                        Catch
                        End Try
                        i = 1
                    End If
                Next
                ' MAC-address
                ListView1.Items.Add(New ListViewItem(New String() {"MAC-address", obj.MACAddress.ToString}))
                ' DHCP state
                Try
                    If obj.DHCPEnabled Then
                        ListView1.Items.Add(New ListViewItem(New String() {"DHCP enabled", "Yes"}))
                    Else
                        ListView1.Items.Add(New ListViewItem(New String() {"DHCP disabled", "No"}))
                    End If
                Catch ex As Exception
                End Try
                ' IP-address
                Try
                    For i = 0 To UBound(obj.IPAddress)
                        Try
                            ListView1.Items.Add(New ListViewItem(New String() {"IP-address", obj.IPAddress(i).ToString}))
                        Catch ex As Exception
                        End Try
                        Try
                            ListView1.Items.Add(New ListViewItem(New String() {"Mask", obj.IPSubnet(i)}))
                        Catch ex As Exception
                        End Try
                        Try
                            ListView1.Items.Add(New ListViewItem(New String() {"Gateway", obj.DefaultIPGateway(i)}))
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
                ' Lease obtained
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Lease obtained", datetimeFormat(obj.DHCPLeaseObtained, objDatetime)}))
                Catch ex As Exception
                End Try
                ' Lease expires
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Lease expires", datetimeFormat(obj.DHCPLeaseExpires, objDatetime)}))
                Catch ex As Exception
                End Try
                ' DHCP-server
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"DHCP-server", obj.DHCPServer}))
                Catch ex As Exception
                End Try
                ' WINS-server
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"WINS-server", obj.WINSPrimaryServer}))
                Catch ex As Exception
                End Try
                ' DNS-servers
                Try
                    For i = 0 To UBound(obj.DNSServerSearchOrder)
                        If i = 0 Then
                            ListView1.Items.Add(New ListViewItem(New String() {"DNS-servers", obj.DNSServerSearchOrder(i)}))
                        Else
                            ListView1.Items.Add(New ListViewItem(New String() {"", obj.DNSServerSearchOrder(i)}))
                        End If
                    Next
                Catch ex As Exception
                End Try
                ListView1.Items.Add(New ListViewItem(New String() {"", ""}))
            Next
            PARAM = "Network"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub getVideoFunc()
        Try
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("Select Caption, VideoProcessor, AdapterRAM, CurrentHorizontalResolution, CurrentVerticalResolution, VideoModeDescription, CurrentRefreshRate, VideoArchitecture, Status, PNPDeviceID from Win32_VideoController")
            Dim row(2)
            ListView1.Items.Clear()
            ListView1.Sorting = SortOrder.None

            If PARAM <> "Video" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("videoParamName", "Prameter name", 200)
                ListView1.Columns.Add("videoParamValue", "Parameter value", 400)
            End If
            For Each obj In col
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Video controller", obj.Caption}))
                    ListView1.Items.Item(ListView1.Items.Count - 1).ImageKey = "video.png"
                Catch
                End Try
                ' Video processor
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Video processor", obj.VideoProcessor}))
                Catch ex As Exception
                End Try
                ' RAM
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"RAM", Math.Round(obj.AdapterRAM / 1048576) & " Мб"}))
                Catch
                End Try

                'row(0) = "Bits per pixel"
                'row(1) = obj.CurrentBitsPerPixel.ToString
                'ListView1.Items.Add(New ListViewItem(New String() {row(0), row(1)}))
                ' Resolution
                Try
                    If obj.CurrentHorizontalResolution > 0 And obj.CurrentVerticalResolution > 0 Then
                        ListView1.Items.Add(New ListViewItem(New String() {"Resolution", obj.CurrentHorizontalResolution.ToString & " x " & obj.CurrentVerticalResolution.ToString}))
                    End If
                Catch
                End Try
                ' Video mode
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Video mode", obj.VideoModeDescription.ToString}))
                Catch ex As Exception
                End Try

                ' Refresh rate
                Try
                    If obj.CurrentRefreshRate > 0 Then
                        ListView1.Items.Add(New ListViewItem(New String() {"Refresh rate", obj.CurrentRefreshRate.ToString & " Hz"}))
                    End If
                Catch ex As Exception
                End Try

                ' Architecture
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Architecture", videoArch(obj.VideoArchitecture)}))
                Catch ex As Exception
                End Try

                ' Status
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Status", obj.Status.ToString}))
                Catch ex As Exception
                End Try
                ' PnP identity
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"PnP identity", obj.PNPDeviceID}))
                Catch ex As Exception
                End Try
                '
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"", ""}))
                Catch ex As Exception
                End Try
            Next
            PARAM = "Video"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Function videoArch(ByVal value)
        Dim archName = "Unknown"
        If value > 2 Then
            Select Case value
                Case 3
                    archName = "CGA"
                Case 4
                    archName = "EGA"
                Case 5
                    archName = "VGA"
                Case 6
                    archName = "SVGA"
                Case 7
                    archName = "MDA"
                Case 8
                    archName = "HGC"
                Case 9
                    archName = "MCGA"
                Case 10
                    archName = "8514A"
                Case 11
                    archName = "XGA"
                Case 12
                    archName = "Linear Frame Buffer"
                Case 160
                    archName = "PC-98"
            End Select
        End If
        Return archName
    End Function

    Private Sub getSoundFunc()
        Try
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("Select Name, Manufacturer, PNPDeviceID from Win32_SoundDevice")
            ListView1.Items.Clear()

            ListView1.Sorting = SortOrder.None
            If PARAM <> "Sound" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("storageParamName", "Prameter name", 200)
                ListView1.Columns.Add("storageParamValue", "Parameter value", 400)
            End If
            For Each obj In col
                ' Sound device
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Sound device", obj.Name}))
                    ListView1.Items.Item(ListView1.Items.Count - 1).ImageKey = "sound.png"
                Catch ex As Exception
                End Try
                ' Manufacturer
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Manufacturer", obj.Manufacturer}))
                Catch ex As Exception
                End Try
                ' PnP identityt
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"PnP identityt", obj.PNPDeviceID}))
                Catch ex As Exception
                End Try
                ' 
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"", ""}))
                Catch ex As Exception
                End Try
            Next
            PARAM = "Sound"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' Motherboard
    Private Sub getMotherboardFunc()
        Try
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("Select * from Win32_BaseBoard")
            ListView1.Items.Clear()
            ListView1.Sorting = SortOrder.None
            If PARAM <> "MB" Then
                ListView1.Columns.Clear()
                ListView1.Columns.Add("storageParamName", "Prameter name", 200)
                ListView1.Columns.Add("storageParamValue", "Parameter value", 400)
            End If
            For Each obj In col
                ' General info
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Mother board", obj.Caption}))
                    ListView1.Items.Item(ListView1.Items.Count - 1).ImageKey = "motherboard.png"
                Catch ex As Exception
                End Try
                ' Manufacturer
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Manufacturer", obj.Manufacturer}))
                Catch ex As Exception
                End Try
                ' Model
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Model", obj.Model}))
                Catch ex As Exception
                End Try
                ' Serial number
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Serial number", obj.SerialNumber}))
                Catch ex As Exception
                End Try
                ' Name
                'Try
                'ListView1.Items.Add(New ListViewItem(New String() {"Name", obj.Name}))
                'Catch ex As Exception
                'End Try
                ' Identity code
                'Try
                'ListView1.Items.Add(New ListViewItem(New String() {"IdentificationCode", obj.IdentificationCode}))
                'Catch ex As Exception
                'End Try
                ' Description
                'Try
                'ListView1.Items.Add(New ListViewItem(New String() {"Description", obj.Description}))
                'Catch ex As Exception
                'End Try
            Next
            col = objWMIService.ExecQuery("Select * from Win32_BIOS")
            For Each obj In col
                ' Manufacturer БИОС
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"Manufacturer BIOS", obj.Manufacturer}))
                Catch ex As Exception
                End Try
                ' BIOS name
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"BIOS name", obj.Name}))
                Catch ex As Exception
                End Try
                ' BIOS version
                Try
                    ListView1.Items.Add(New ListViewItem(New String() {"BIOS version", obj.Version}))
                Catch ex As Exception
                End Try
                ' BIOS version
                'Try
                'ListView1.Items.Add(New ListViewItem(New String() {"BIOSVersion", obj.BIOSVersion(0)}))
                'Catch ex As Exception
                'End Try
                ' General info
                'Try
                'ListView1.Items.Add(New ListViewItem(New String() {"Caption", obj.Caption}))
                'Catch ex As Exception
                'End Try
                ' Description
                'Try
                'ListView1.Items.Add(New ListViewItem(New String() {"Description", obj.Description}))
                'Catch ex As Exception
                'End Try
            Next
            PARAM = "MB"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonVnc.Click
        getDesktop()
    End Sub

    Private Sub terminalLogOff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles terminalLogOff.Click
        Try
            Dim sessionId = ListView1.SelectedItems.Item(0).SubItems(1).Text
            Dim manager As ITerminalServicesManager = New TerminalServicesManager()
            Dim server As ITerminalServer = manager.GetRemoteServer(COMP)
            server.Open()
            Dim session = server.GetSession(sessionId)
            session.Logoff()
            ListView1.SelectedItems.Item(0).Remove()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub terminalRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles terminalRefresh.Click
        getTerminalSessionsFunc()
    End Sub

    Private Sub reboot()
        Try
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("SELECT * FROM Win32_OperatingSystem")
            For Each objSystem In col
                Dim answer = MsgBox("Are you sure you want to reboot the computer " & COMP, MsgBoxStyle.YesNo, "Saqwel Remote Administration Tool")
                If answer = MsgBoxResult.Yes Then
                    objSystem.Reboot()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub shutdown()
        Try
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("SELECT * FROM Win32_OperatingSystem")
            For Each objSystem In col
                Dim answer = MsgBox("Are you sure you want to shutdown the computer " & COMP, MsgBoxStyle.YesNo, "Saqwel Remote Administration Tool")
                If answer = MsgBoxResult.Yes Then
                    objSystem.Win32Shutdown(1)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub mainMenuVncInstall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuVncInstall.Click

        Dim answer = MsgBox("Are you sure you want to install TightVNC on " & COMP & "?", MsgBoxStyle.YesNo, "Saqwel Remote Administration Tool")
        If answer = MsgBoxResult.Yes Then
            vncInstall()

            ' Check that TightVNC service exists
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            Dim colRunningServices = objWMIService.ExecQuery("Select * from Win32_Service Where Name='tvnserver'")
            Dim tvncServiceExist = colRunningServices.Count

            If tvncServiceExist = 1 Then
                MsgBox("TightVNC service is installed", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
            Else
                MsgBox("TightVNC service is nor installed", MsgBoxStyle.Critical, "Saqwel Remote Administration Tool")
            End If
        End If

    End Sub

    Private Sub mainMenuVncUninstall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuVncUninstall.Click
        vncUninstall()
    End Sub

    Private Sub buttonPartitions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonPartitions.Click
        getPartitionsFunc()
    End Sub

    Private Sub buttonShares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonShares.Click
        getSharesFunc()
    End Sub

    Private Sub buttonUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonUsers.Click
        getUsersFunc()
    End Sub

    Private Sub buttonGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonGroups.Click
        getGroupsFunc()
    End Sub

    Private Sub buttonProcesses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonProcesses.Click
        getProcessesFunc()
    End Sub

    Private Sub buttonServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonServices.Click
        getServicesFunc()
    End Sub

    Private Sub buttonSoftware_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonSoftware.Click
        getSoftwareFunc()
    End Sub

    Private Sub buttonProcessor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonProcessor.Click
        getProcessorFunc()
    End Sub

    Private Sub buttonMemory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonMemory.Click
        getMemoryFunc()
    End Sub

    Private Sub buttonStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStorage.Click
        getStorageFunc()
    End Sub

    Private Sub buttonNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonNetwork.Click
        getNetworkFunc()
    End Sub

    Private Sub buttonVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonVideo.Click
        getVideoFunc()
    End Sub

    Private Sub buttonSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonSound.Click
        getSoundFunc()
    End Sub

    Private Sub buttonTerminal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonTerminal.Click
        getTerminalSessionsFunc()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonGeneralInformation.Click
        getGeneralInformationFunc()
    End Sub

    Private Sub ListView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.Click
        getComputer(ListView2.SelectedItems.Item(0).SubItems(0).Text)
    End Sub

    Private Sub ListView2_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView2.ColumnClick
        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = ListView2.Columns(e.Column)


        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.ImageKey = "1.png" Then 'If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
            m_SortingColumn.ImageKey = Nothing
            m_SortingColumn.TextAlign = HorizontalAlignment.Left
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            'm_SortingColumn.Text = "> " & m_SortingColumn.Text
            m_SortingColumn.ImageKey = "1.png"
        Else
            'm_SortingColumn.Text = "< " & m_SortingColumn.Text
            m_SortingColumn.ImageKey = "0.png"
        End If

        ' Create a comparer.
        ListView2.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView2.Sort()
    End Sub

    Private Sub mainMenuComputerGeneralInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuComputerGeneralInformation.Click
        getGeneralInformationFunc()
    End Sub

    Private Sub mainMenuComputerPartitions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuComputerPartitions.Click
        getPartitionsFunc()
    End Sub

    Private Sub mainMenuComputerShares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuComputerShares.Click
        getSharesFunc()
    End Sub

    Private Sub mainMenuComputerUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuComputerUsers.Click
        getUsersFunc()
    End Sub

    Private Sub mainMenuComputerGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuComputerGroups.Click
        getGroupsFunc()
    End Sub

    Private Sub mainMenuComputerProcesses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuComputerProcesses.Click
        getProcessesFunc()
    End Sub

    Private Sub mainMenuComputerServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuComputerServices.Click
        getServicesFunc()
    End Sub

    Private Sub mainMenuComputerSoftware_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuComputerSoftware.Click
        getSoftwareFunc()
    End Sub

    Private Sub mainMenuComputerTerminal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuComputerTerminal.Click
        getTerminalSessionsFunc()
    End Sub

    Private Sub buttonPane_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonPane.Click
        If PANE_POS = "vertical" Then
            SplitContainer1.Orientation = Orientation.Horizontal
            buttonPane.ImageKey = "pane_vertical.png"
            PANE_POS = "horizontal"
        Else
            SplitContainer1.Orientation = Orientation.Vertical
            buttonPane.ImageKey = "pane_horizontal.png"
            PANE_POS = "vertical"
        End If
    End Sub

    Private Sub mainMenuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuHelpAbout.Click
        aboutForm.ShowDialog()
    End Sub

    Private Sub buttonGroups_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonGroups.MouseHover
        ToolTip1.Show("Groups", buttonGroups)
        buttonGroups.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonMemory_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonMemory.MouseHover
        ToolTip1.Show("Memory", buttonMemory)
        buttonMemory.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonMotherboard_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonMotherboard.MouseHover
        ToolTip1.Show("Mother board", buttonMotherboard)
        buttonMotherboard.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonNetwork_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonNetwork.MouseHover
        ToolTip1.Show("Network interfaces", buttonNetwork)
        buttonNetwork.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonPane_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonPane.MouseHover
        ToolTip1.Show("Change panels location", buttonPane)
        buttonPane.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonPartitions_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonPartitions.MouseHover
        ToolTip1.Show("Partitions of hard drive", buttonPartitions)
        buttonPartitions.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonProcesses_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonProcesses.MouseHover
        ToolTip1.Show("Processes", buttonProcesses)
        buttonProcesses.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonProcessor_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonProcessor.MouseHover
        ToolTip1.Show("Processor", buttonProcessor)
        buttonProcessor.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonServices_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonServices.MouseHover
        ToolTip1.Show("Services", buttonServices)
        buttonServices.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonShares_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonShares.MouseHover
        ToolTip1.Show("Shares", buttonShares)
        buttonShares.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonSoftware_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonSoftware.MouseHover
        ToolTip1.Show("Software", buttonSoftware)
        buttonSoftware.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonSound_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonSound.MouseHover
        ToolTip1.Show("Sound", buttonSound)
        buttonSound.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonStorage_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonStorage.MouseHover
        ToolTip1.Show("Storage", buttonStorage)
        buttonStorage.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonTerminal_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonTerminal.MouseHover
        ToolTip1.Show("Terminal server sessions", buttonTerminal)
        buttonTerminal.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonUsers_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonUsers.MouseHover
        ToolTip1.Show("Users", buttonUsers)
        buttonUsers.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonVideo_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonVideo.MouseHover
        ToolTip1.Show("Video", buttonVideo)
        buttonVideo.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonVnc_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonVnc.MouseHover
        ToolTip1.Show("Connect to remote desktop", buttonVnc)
        buttonVnc.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub buttonGeneralInformation_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonGeneralInformation.MouseHover
        ToolTip1.Show("General information", buttonGeneralInformation)
        buttonGeneralInformation.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        ListView2.Items.Clear()
        Try
            Dim dirEntryForSearch As New DirectoryEntry("LDAP://" & ComboBox1.SelectedItem.ToString())
            Dim dirSearch As New DirectorySearcher(dirEntryForSearch)
            dirSearch.Filter = "(objectClass=Computer)"
            dirSearch.PageSize = 1000
            Dim i = 0
            Dim OS_SELECTED = ComboBox3.SelectedItem

            If OS_SELECTED = "Unknown" Then
                OS_SELECTED = ""
            End If
            For Each Obj In dirSearch.FindAll()
                Dim OS = Obj.GetDirectoryEntry().Properties("operatingsystem").Value()
                Dim NAME = Obj.GetDirectoryEntry().Properties("cn").Value()
                Dim NEW_OS As Boolean = True
                If OS_SELECTED = "Все" Then
                    ListView2.Items.Add(New ListViewItem(New String() {NAME, OS}))
                ElseIf OS_SELECTED = OS Then
                    ListView2.Items.Add(New ListViewItem(New String() {NAME, OS}))
                    i += 1
                End If
            Next
        Catch ex As Exception
            Try
                Dim i = 0
                Dim Winver = ""
                Dim dirEntry As New DirectoryEntry("WinNT://" & ComboBox1.SelectedItem.ToString()) 'Environment.UserDomainName)
                For Each child In dirEntry.Children
                    If child.SchemaClassName = "Computer" Then
                        ListView2.Items.Add(New ListViewItem(New String() {child.Name}))
                        i += 1
                    End If
                Next
            Catch excep As Exception
                MsgBox(excep.Message, MsgBoxStyle.Exclamation, "ErrorSaqwel Remote Administration Tool")
            End Try
        End Try
    End Sub

    Private Sub computerGeneralInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerGeneralInformation.Click
        getGeneralInformationFunc()
    End Sub

    Private Sub computerVnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerVnc.Click
        getDesktop()
    End Sub

    Private Sub computerPartitions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerPartitions.Click
        getPartitionsFunc()
    End Sub

    Private Sub computerShares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerShares.Click
        getSharesFunc()
    End Sub

    Private Sub computerUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerUsers.Click
        getUsersFunc()
    End Sub

    Private Sub computerGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerGroups.Click
        getGroupsFunc()
    End Sub

    Private Sub computerProcesses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerProcesses.Click
        getProcessesFunc()
    End Sub

    Private Sub computerServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerServices.Click
        getServicesFunc()
    End Sub

    Private Sub computerSoftware_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerSoftware.Click
        getSoftwareFunc()
    End Sub

    Private Sub computerProcessor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerProcessor.Click
        getProcessorFunc()
    End Sub

    Private Sub computerMemory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerMemory.Click
        getMemoryFunc()
    End Sub

    Private Sub computerStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerStorage.Click
        getStorageFunc()
    End Sub

    Private Sub computerNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerNetwork.Click
        getNetworkFunc()
    End Sub

    Private Sub computerVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerVideo.Click
        getVideoFunc()
    End Sub

    Private Sub computerSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerSound.Click
        getSoundFunc()
    End Sub

    Private Sub computerTerminal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles computerTerminal.Click
        getTerminalSessionsFunc()
    End Sub

    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick
        getComputer(ListView2.SelectedItems.Item(0).SubItems(0).Text)
        getGeneralInformationFunc()
    End Sub

    Private Sub ListView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            getComputer(ListView2.SelectedItems.Item(0).SubItems(0).Text)
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If ListView2.View = View.Details AndAlso ListView2.Items.Count > 0 Then
                    Dim lvi As ListViewItem = ListView2.FindItemWithText(TextBox1.Text, True, 0)
                    If lvi IsNot Nothing Then
                        ListView2.Focus()
                        lvi.Selected = True
                        lvi.EnsureVisible()
                        lvi.Focused = True
                        TextBox1.Text = ListView2.SelectedItems.Item(0).SubItems(0).Text
                    End If
                End If
                getComputer(TextBox1.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Try
            If Len(TextBox1.Text) > 0 Then
                getComputer(TextBox1.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            If ListView2.View = View.Details AndAlso ListView2.Items.Count > 0 Then
                If Not lvi Is Nothing Then
                    lvi.BackColor = Color.Empty
                End If
                lvi = ListView2.FindItemWithText(TextBox1.Text, True, 0)
                If lvi IsNot Nothing Then
                    lvi.EnsureVisible()
                    lvi.BackColor = Color.LightSteelBlue
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub getComputersAll()
        For Each x In ListView1.Items
            My.Computer.FileSystem.WriteAllText("D:\Documents\computers1.txt", x.subitems(0).text & vbCrLf, True)
        Next
    End Sub

    Private Sub mainMenuComputerVNC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuComputerVNC.Click
        getDesktop()
    End Sub

    Private Sub mainMenuVncServerSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuVncServerSettings.Click
        vncServerSettingsForm.Show()
    End Sub

    Private Sub mainMenuHelpReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuHelpReference.Click
        Try
            Process.Start(System.IO.Path.Combine(PATH, PATH & "\help.html"))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    'Private Sub EventLog1_EntryWritten(ByVal sender As Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles EventLog1.EntryWritten
    'If e.Entry.EntryType = EventLogEntryType.Information Then
    'MsgBox(e.Entry.Message)
    'End If
    'End Sub

    Private Sub getUsersMail()
        Dim dirEntryForSearch As New DirectoryEntry("LDAP://KMZ")
        Dim dirSearch As New DirectorySearcher(dirEntryForSearch)
        dirSearch.Filter = "(objectClass=User)"
        dirSearch.PageSize = 1000
        Dim i = 0
        For Each Obj In dirSearch.FindAll()
            Dim USER = Obj.GetDirectoryEntry().Properties("displayName").Value()
            Dim MAIL = Obj.GetDirectoryEntry().Properties("mail").Value()
            If Len(MAIL) > 0 Then
                My.Computer.FileSystem.WriteAllText("D:\Documents\_\post.txt", USER & ";" & MAIL & vbCrLf, True)
            End If
        Next
    End Sub

    Private Sub buttonGeneralInformation_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonGeneralInformation.MouseLeave
        buttonGeneralInformation.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonGroups_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonGroups.MouseLeave
        buttonGroups.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonMemory_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonMemory.MouseLeave
        buttonMemory.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonNetwork_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonNetwork.MouseLeave
        buttonNetwork.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonPane_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonPane.MouseLeave
        buttonPane.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonPartitions_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonPartitions.MouseLeave
        buttonPartitions.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonProcesses_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonProcesses.MouseLeave
        buttonProcesses.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonProcessor_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonProcessor.MouseLeave
        buttonProcessor.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonServices_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonServices.MouseLeave
        buttonServices.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonShares_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonShares.MouseLeave
        buttonShares.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonSoftware_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonSoftware.MouseLeave
        buttonSoftware.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonMotherboard_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonMotherboard.MouseLeave
        buttonMotherboard.FlatStyle = FlatStyle.Flat
    End Sub
    Private Sub buttonSound_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonSound.MouseLeave
        buttonSound.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonStorage_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonStorage.MouseLeave
        buttonStorage.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonTerminal_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonTerminal.MouseLeave
        buttonTerminal.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonUsers_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonUsers.MouseLeave
        buttonUsers.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonVideo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonVideo.MouseLeave
        buttonVideo.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonVnc_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonVnc.MouseLeave
        buttonVnc.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub buttonMotherboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonMotherboard.Click
        getMotherboardFunc()
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainMenuServiceInventarization.Click
        'Process.Start(PATH & "\si.exe", "")
        ShowInventoryWindow()
    End Sub

    Private Sub ShowInventoryWindow()
        inventoryForm.Show()
    End Sub

    Private Sub mainMenuComputerReboot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuComputerReboot.Click
        reboot()
    End Sub

    Private Sub mainMenuComputerShutdown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuComputerShutdown.Click
        shutdown()
    End Sub

    Private Sub mainMenuComputerProcessor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuComputerProcessor.Click
        getProcessorFunc()
    End Sub

    Private Sub mainMenuComputerMemory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuComputerMemory.Click
        getMemoryFunc()
    End Sub

    Private Sub mainMenuComputerStorage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuComputerStorage.Click
        getStorageFunc()
    End Sub

    Private Sub mainMenuComputerNetwork_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuComputerNetwork.Click
        getNetworkFunc()
    End Sub

    Private Sub mainMenuComputerVideo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuComputerVideo.Click
        getVideoFunc()
    End Sub

    Private Sub mainMenuComputerSound_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuComputerSound.Click
        getSoundFunc()
    End Sub

    Private Sub computerReboot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles computerReboot.Click
        reboot()
    End Sub

    Private Sub computerShutdown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles computerShutdown.Click
        shutdown()
    End Sub

    Private Sub computerMotherboard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles computerMotherboard.Click
        getMotherboardFunc()
    End Sub

    Private Sub mainMenuComputerMotherboard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuComputerMotherboard.Click
        getMotherboardFunc()
    End Sub

    Private Sub ListView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseClick
        Try
            Dim p As Point = New Point(e.X, e.Y)
            If e.Button = MouseButtons.Right Then
                ContextComputer.Show(ListView2, p)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub exportComputers()
        Dim fileName
        SaveFileDialog1.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.RestoreDirectory = True

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            fileName = SaveFileDialog1.FileName
            If My.Computer.FileSystem.FileExists(fileName) Then
                For Each item In ListView2.Items
                    My.Computer.FileSystem.WriteAllText(fileName, item.SubItems(0).Text & vbCrLf, True)
                Next
            End If
        End If
    End Sub

    Private Sub mainMenuExportComputers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuExportComputers.Click
        exportComputers()
    End Sub
End Class








'*****************************************************************************************
' Class for columns sorting
'
' Implements a comparer for ListView columns.
Class ListViewComparer
    Implements IComparer

    Private m_ColumnNumber As Integer
    Private m_SortOrder As SortOrder

    Public Sub New(ByVal column_number As Integer, ByVal sort_order As SortOrder)
        m_ColumnNumber = column_number
        m_SortOrder = sort_order
    End Sub

    ' Compare the items in the appropriate column
    ' for objects x and y.
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim item_x As ListViewItem = DirectCast(x, ListViewItem)
        Dim item_y As ListViewItem = DirectCast(y, ListViewItem)

        ' Get the sub-item values.
        Dim string_x As String
        If item_x.SubItems.Count <= m_ColumnNumber Then
            string_x = ""
        Else
            string_x = item_x.SubItems(m_ColumnNumber).Text
        End If

        Dim string_y As String
        If item_y.SubItems.Count <= m_ColumnNumber Then
            string_y = ""
        Else
            string_y = item_y.SubItems(m_ColumnNumber).Text
        End If

        ' Compare them.
        If m_SortOrder = SortOrder.Ascending Then
            If IsNumeric(string_x) And IsNumeric(string_y) Then
                Return Val(string_x).CompareTo(Val(string_y))
            ElseIf IsDate(string_x) And IsDate(string_y) Then
                Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))
            Else
                Return String.Compare(string_x, string_y)
            End If
        Else
            If IsNumeric(string_x) And IsNumeric(string_y) Then
                Return Val(string_y).CompareTo(Val(string_x))
            ElseIf IsDate(string_x) And IsDate(string_y) Then
                Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))
            Else
                Return String.Compare(string_y, string_x)
            End If
        End If
    End Function

End Class