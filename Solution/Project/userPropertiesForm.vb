Imports System.DirectoryServices
Public Class userPropertiesForm
    Public flag = Nothing
    Public ADS_UF_SCRIPT = Nothing
    Public ADS_UF_ACCOUNTDISABLE = Nothing
    Public ADS_UF_HOMEDIR_REQUIRED = Nothing
    Public ADS_UF_LOCKOUT = Nothing
    Public ADS_UF_PASSWD_NOTREQD = Nothing
    Public ADS_UF_PASSWD_CANT_CHANGE = Nothing
    Public ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = Nothing
    Public ADS_UF_TEMP_DUPLICATE_ACCOUNT = Nothing
    Public ADS_UF_NORMAL_ACCOUNT = Nothing
    Public ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = Nothing
    Public ADS_UF_WORKSTATION_TRUST_ACCOUNT = Nothing
    Public ADS_UF_SERVER_TRUST_ACCOUNT = Nothing
    Public ADS_UF_DONT_EXPIRE_PASSWD = Nothing
    Public ADS_UF_MNS_LOGON_ACCOUNT = Nothing
    Public ADS_UF_SMARTCARD_REQUIRED = Nothing
    Public ADS_UF_TRUSTED_FOR_DELEGATION = Nothing
    Public ADS_UF_NOT_DELEGATED = Nothing
    Public ADS_UF_USE_DES_KEY_ONLY = Nothing
    Public ADS_UF_DONT_REQUIRE_PREAUTH = Nothing
    Public ADS_UF_PASSWORD_EXPIRED = Nothing
    Public ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = Nothing

    Private Sub userPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Comp = UCase(Form1.TextBox1.Text)
        Dim userName = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
        Try
            TextBox3.Text = userName
            TextBox4.Text = Comp
            'Dim AD = New DirectoryEntry("WinNT://" & Comp)
            Dim oUser = GetObject("WinNT://" & Comp & "/" & userName & ",user")
            TextBox1.Text = oUser.FullName
            TextBox2.Text = oUser.Description
            flag = oUser.userflags
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

            ' Get lags which need to us
            ' User must change password at next logon
            If ADS_UF_PASSWORD_EXPIRED Then
                CheckBox1.Checked = True
                CheckBox2.Enabled = False
                CheckBox3.Enabled = False
            End If
            ' User cannot change password
            If ADS_UF_PASSWD_CANT_CHANGE Then
                CheckBox2.Checked = True
                CheckBox1.Enabled = False
            End If
            ' Password never expired
            If ADS_UF_DONT_EXPIRE_PASSWD Then
                CheckBox3.Checked = True
                CheckBox1.Enabled = False
            End If
            ' Account is disabled
            If ADS_UF_ACCOUNTDISABLE Then
                CheckBox4.Checked = True
            End If
            ListView1.Items.Clear()
            ListView1.Columns.Add("GroupName", "Group name", 349)
            For Each group In oUser.Groups
                ListView1.Items.Add(group.Name)
            Next
            TextBox1.Focus()
            'For Each child In oUser
            'If child.SchemaClassName = "User" Then
            'TextBox1.Text = child.Properties("fullanme").Value()
            'TextBox2.Text = child.Properties("description").Value()
            'FileOpen(1, "D:\proprties.txt", OpenMode.Output)
            'For Each prop In child.Properties.PropertyNames
            'FileSystem.WriteLine(1, prop & " = " & child.Properties(prop).value.ToString)
            'Next
            'FileClose(1)
            'End If
            'Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' User must change password at next logon
    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked Then
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            'flag = flag Or &H400000
            ADS_UF_PASSWORD_EXPIRED = True
        Else
            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
            'flag = flag And Not &H400000
            ADS_UF_PASSWORD_EXPIRED = False
        End If
        Button3.Enabled = True
    End Sub

    ' User cannot change password
    Private Sub CheckBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        If CheckBox2.Checked Or CheckBox3.Checked Then
            CheckBox1.Enabled = False
        Else
            CheckBox1.Enabled = True
        End If
        If CheckBox2.Checked Then
            flag = flag Or &H40
        Else
            flag = flag And Not &H40
        End If
        Button3.Enabled = True
    End Sub

    ' Password never expired
    Private Sub CheckBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.Click
        If CheckBox3.Checked Or CheckBox2.Checked Then
            CheckBox1.Enabled = False
        Else
            CheckBox1.Enabled = True
        End If
        If CheckBox3.Checked Then
            flag = flag Or &H10000
        Else
            flag = flag And Not &H10000
        End If
        Button3.Enabled = True
    End Sub

    ' Account is disabled
    Private Sub CheckBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.Click
        If CheckBox4.Checked Then
            flag = flag Or &H2
        Else
            flag = flag And Not &H2
        End If
        Button3.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        saveProperties()
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        saveProperties()
        Button3.Enabled = False
        Button1.Focus()
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        Button3.Enabled = True
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp
        Button3.Enabled = True
    End Sub

    Function saveProperties()
        Dim Comp = TextBox4.Text
        Dim userName = TextBox3.Text
        Try
            Dim oUser = GetObject("WinNT://" & Comp & "/" & userName & ",user")
            oUser.FullName = TextBox1.Text
            oUser.Description = TextBox2.Text
            If ADS_UF_PASSWORD_EXPIRED Then
                oUser.PasswordExpired = 1
            Else
                oUser.PasswordExpired = 0
            End If
            oUser.UserFlags = flag
            oUser.SetInfo()
            For Each item In Form1.ListView1.Items
                If item.text = userName Then
                    item.SubItems(1).Text = TextBox1.Text
                    item.SubItems(2).Text = TextBox2.Text
                End If
            Next
            'Form1.ListView1.SelectedItems.Item(0).SubItems(1).Text = TextBox1.Text
            'Form1.ListView1.SelectedItems.Item(0).SubItems(2).Text = TextBox2.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
        Return 0
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        userGroupAddForm.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        userGroupDeleteFunc()
    End Sub
    Function userGroupDeleteFunc()
        Try
            Dim Comp = TextBox4.Text
            Dim userName = TextBox3.Text
            Dim groupName = ListView1.SelectedItems.Item(0).SubItems(0).Text
            Dim objUser = GetObject("WinNT://" & Comp & "/" & userName & ",user")
            Dim objGroup = GetObject("WinNT://" & Comp & "/" & groupName & ",group")
            objGroup.Remove(objUser.ADsPath)
            ListView1.SelectedItems.Item(0).Remove()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
        Return Nothing
    End Function

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            Dim x = ListView1.SelectedItems.Item(0).Text
            Button5.Enabled = True
        Catch
            Button5.Enabled = False
        End Try
    End Sub
End Class