Public Class vncServerSettingsForm

    Private Sub vncServerSettingsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim HttpPortValue As Int32 = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "HttpPort", 5800)
            Dim RfbPortValue = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "RfbPort", 5900)
            Dim LocalInputPriorityTimeoutValue = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "LocalInputPriorityTimeout", 3)
            If HttpPortValue = 0 Then
                HttpPort.Value = 5800
            End If
            If RfbPortValue = 0 Then
                RfbPort.Value = 5900
            End If
            If LocalInputPriorityTimeoutValue = 0 Then
                LocalInputPriorityTimeout.Value = 3
            End If
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "AcceptHttpConnections", 1) = 1 Then
                AcceptHttpConnections.Checked = True
            Else
                AcceptHttpConnections.Checked = False
            End If
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "AcceptRfbConnections", 1) = 1 Then
                AcceptRfbConnections.Checked = True
            Else
                AcceptRfbConnections.Checked = False
            End If
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "BlockLocalInput", 0) = 1 Then
                BlockLocalInput.Checked = True
            Else
                BlockLocalInput.Checked = False
            End If
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "BlockRemoteInput", 0) = 1 Then
                BlockRemoteInput.Checked = True
            Else
                BlockRemoteInput.Checked = False
            End If
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "EnableFileTransfers", 1) = 1 Then
                EnableFileTransfers.Checked = True
            Else
                EnableFileTransfers.Checked = False
            End If
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "GrabTransparentWindows", 1) = 1 Then
                GrabTransparentWindows.Checked = True
            Else
                GrabTransparentWindows.Checked = False
            End If
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "LocalInputPriority", 0) = 1 Then
                LocalInputPriority.Checked = True
            Else
                LocalInputPriority.Checked = False
            End If
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "RemoveWallpaper", 0) = 1 Then
                RemoveWallpaper.Checked = True
            Else
                RemoveWallpaper.Checked = False
            End If
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "RunControlInterface", 0) = 1 Then
                RunControlInterface.Checked = True
            Else
                RunControlInterface.Checked = False
            End If
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "UseVncAuthentication", 0) = 1 Then
                UseVncAuthentication.Checked = True
            Else
                UseVncAuthentication.Checked = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "RfbPort", RfbPort.Value, Microsoft.Win32.RegistryValueKind.DWord)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "HttpPort", HttpPort.Value, Microsoft.Win32.RegistryValueKind.DWord)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "LocalInputPriorityTimeout", LocalInputPriorityTimeout.Value, Microsoft.Win32.RegistryValueKind.DWord)
            If AcceptHttpConnections.Checked Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "AcceptHttpConnections", 1, Microsoft.Win32.RegistryValueKind.DWord)
            Else
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "AcceptHttpConnections", 0, Microsoft.Win32.RegistryValueKind.DWord)
            End If
            If AcceptRfbConnections.Checked Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "AcceptRfbConnections", 1, Microsoft.Win32.RegistryValueKind.DWord)
            Else
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "AcceptRfbConnections", 0, Microsoft.Win32.RegistryValueKind.DWord)
            End If
            If BlockLocalInput.Checked Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "BlockLocalInput", 1, Microsoft.Win32.RegistryValueKind.DWord)
            Else
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "BlockLocalInput", 0, Microsoft.Win32.RegistryValueKind.DWord)
            End If
            If BlockRemoteInput.Checked Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "BlockRemoteInput", 1, Microsoft.Win32.RegistryValueKind.DWord)
            Else
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "BlockRemoteInput", 0, Microsoft.Win32.RegistryValueKind.DWord)
            End If
            If EnableFileTransfers.Checked Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "EnableFileTransfers", 1, Microsoft.Win32.RegistryValueKind.DWord)
            Else
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "EnableFileTransfers", 0, Microsoft.Win32.RegistryValueKind.DWord)
            End If
            If GrabTransparentWindows.Checked Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "GrabTransparentWindows", 1, Microsoft.Win32.RegistryValueKind.DWord)
            Else
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "GrabTransparentWindows", 0, Microsoft.Win32.RegistryValueKind.DWord)
            End If
            If LocalInputPriority.Checked Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "LocalInputPriority", 1, Microsoft.Win32.RegistryValueKind.DWord)
            Else
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "LocalInputPriority", 0, Microsoft.Win32.RegistryValueKind.DWord)
            End If
            If RemoveWallpaper.Checked Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "RemoveWallpaper", 1, Microsoft.Win32.RegistryValueKind.DWord)
            Else
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "RemoveWallpaper", 0, Microsoft.Win32.RegistryValueKind.DWord)
            End If
            If RunControlInterface.Checked Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "RunControlInterface", 1, Microsoft.Win32.RegistryValueKind.DWord)
            Else
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "RunControlInterface", 0, Microsoft.Win32.RegistryValueKind.DWord)
            End If
            If UseVncAuthentication.Checked Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "UseVncAuthentication", 1, Microsoft.Win32.RegistryValueKind.DWord)
            Else
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Saqwel\RAT\TightVNC\Server", "UseVncAuthentication", 0, Microsoft.Win32.RegistryValueKind.DWord)
            End If
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim vncPasswordForm As New vncPasswordForm(".")
        vncPasswordForm.Show()
    End Sub
End Class