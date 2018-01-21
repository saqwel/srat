Imports System.Security.Principal
Imports System.Management

Public Class sharePropertiesForm
    Public AceArray As New Microsoft.VisualBasic.Collection()
    Private shareName = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
    Private Comp = Form1.TextBox1.Text
    Private changedElement = Form1.ListView1.SelectedItems
    Private Sub sharePropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AceArray.Clear()
        TextBox1.Text = shareName
        TextBox2.Text = Comp
        Try
            Dim objWMIService, col
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            col = objWMIService.ExecQuery("SELECT * FROM Win32_Share WHERE Name='" & shareName & "'")
            For Each obj In col
                TextBox3.Text = obj.Path.ToString
                TextBox4.Text = obj.Name.ToString
                TextBox5.Text = obj.Description.ToString
                Try
                    NumericUpDown1.Value = obj.MaximumAllowed
                Catch
                End Try
                getSD(obj.Name.ToString)
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        changeShare()
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        changeShare()
        Button3.Enabled = False
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        Button3.Enabled = True
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Button3.Enabled = True
    End Sub

    ' Show permissions for highlithed user or shadow checkbox
    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim userName = ""
        Try
            Dim entry = ListView1.SelectedItems.Item(0).SubItems(0).Text
            If entry.IndexOf("\") > -1 Then
                userName = Mid(entry, entry.IndexOf("\") + 2)
            Else
                userName = entry
            End If
            CheckBox1.Enabled = True
            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
            CheckBox6.Enabled = True
            CheckBox5.Enabled = True
            CheckBox4.Enabled = True
        Catch
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox6.Enabled = False
            CheckBox5.Enabled = False
            CheckBox4.Enabled = False
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox6.Checked = False
            CheckBox5.Checked = False
            CheckBox4.Checked = False
        End Try
        For Each Ace In AceArray
            If Ace.userName = userName Then
                If Ace.Type = 0 Then
                    Select Case Ace.AccessMask
                        Case 2032127
                            CheckBox1.Checked = True
                            CheckBox2.Checked = True
                            CheckBox3.Checked = True
                        Case 1245631
                            CheckBox1.Checked = False
                            CheckBox2.Checked = True
                            CheckBox3.Checked = True
                        Case 1179817
                            CheckBox1.Checked = False
                            CheckBox2.Checked = False
                            CheckBox3.Checked = True
                    End Select
                End If
                If Ace.Type = 1 Then
                    Select Case Ace.AccessMask
                        Case 2032127
                            CheckBox4.Checked = True
                            CheckBox5.Checked = True
                            CheckBox6.Checked = True
                        Case 1245631
                            CheckBox4.Checked = False
                            CheckBox5.Checked = True
                            CheckBox6.Checked = True
                        Case 1179817
                            CheckBox4.Checked = False
                            CheckBox5.Checked = False
                            CheckBox6.Checked = True
                    End Select
                End If
            End If
        Next
    End Sub

    ' "Delete" button
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim entry = ListView1.SelectedItems.Item(0).SubItems(0).Text
            ListView1.SelectedItems.Item(0).Remove()
            AceArray.Remove(entry)
            Button3.Enabled = True
        Catch
        End Try
    End Sub

    ' "Add" button
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        shareAddUserForm.Show()
        Button3.Enabled = True
    End Sub

    ' Get security descriptor while form load
    Function getSD(ByVal shareName)
        Dim entry
        Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
        Dim col = objWMIService.ExecQuery("Select * from Win32_LogicalShareSecuritySetting where name='" & shareName & "'")
        For Each obj In col
            Dim objSD = Nothing
            obj.GetSecurityDescriptor(objSD)
            For Each objACE In objSD.DACL
                Dim ace = New objACE
                ace.domainName = objACE.Trustee.Domain.ToString
                ace.userName = objACE.Trustee.Name
                ace.AccessMask = objACE.AccessMask
                ace.Type = objACE.AceType
                If ace.domainName = "BUILTIN" Then
                    ace.domainName = TextBox2.Text
                End If
                If ace.domainName.Length > 0 Then
                    entry = ace.domainName & "\" & ace.userName
                Else
                    entry = ace.userName
                End If
                AceArray.Add(ace, entry)
                ListView1.Items.Add(New ListViewItem(New String() {entry}))
            Next
        Next
        Return 0
    End Function

    ' Create access control entry (ACE) for access control list (ACL)
    Function createACE(ByVal userName As String, ByVal domainName As String, ByVal AccessMask As Integer, ByVal Type As Integer)
        Dim Comp = TextBox2.Text
        Dim AccountSID = Nothing
        ' Create scope to determine what computer connect to
        Dim scope As ManagementScope
        scope = New ManagementScope("\\" & Comp & "\root\cimv2")
        scope.Connect()
        If userName = "Everyone" Then
            AccountSID = "S-1-1-0"
        Else
            ' Create query
            Dim query As ObjectQuery
            query = New ObjectQuery("SELECT SID FROM Win32_UserAccount WHERE Domain='" & domainName & "' AND Name='" & userName & "'")
            ' Create sercher, which execute query
            'Dim searcher As ManagementObjectSearcher
            Dim accSearch = New Management.ManagementObjectSearcher(scope, query)
            Dim accCol = accSearch.Get
            ' If it is group:
            If accCol.Count = 0 Then
                query = New ObjectQuery("SELECT SID FROM Win32_Group WHERE Domain='" & domainName & "' AND Name='" & userName & "'")
                ' Create sercher, which execute query
                accSearch = New Management.ManagementObjectSearcher(scope, query)
                accCol = accSearch.Get
            End If
            ' Iterate through the results though it have to be single
            For Each obj In accCol
                AccountSID = obj.Item("SID")
            Next
        End If
        ' Get SID object for getting BinaryRepresentetion of SID string
        Dim pathToSID As ManagementPath = New ManagementPath("\\" & Comp & "\root\cimv2:Win32_SID.SID='" & AccountSID & "'")
        Dim SID = New ManagementObject(pathToSID)
        ' Create Trustee for assigning it to Trustee property of Win32_ACE object
        Dim Trustee = New ManagementClass("Win32_Trustee").CreateInstance()
        Trustee.Item("Domain") = SID.Item("ReferencedDomainName")
        Trustee.Item("Name") = SID.Item("AccountName")
        Trustee.Item("SID") = SID.Item("BinaryRepresentation")
        ' Create Ace for assigning it to DACL() property of Win32_SecurityDescritor object
        Dim ACE = New ManagementClass("Win32_ACE").CreateInstance()
        ACE.Item("AccessMask") = AccessMask '2032127
        ACE.Item("AceType") = Type '0
        ACE.Item("Trustee") = Trustee
        Return ACE
    End Function

    ' Change share settings
    Function changeShare()
        Dim entry
        Dim Comp = TextBox2.Text
        Dim shareName = TextBox1.Text
        Dim share = Nothing
        Dim amount = AceArray.Count
        ' Remove entries if AccessMask 0
        For Each ace In AceArray
            If ace.AccessMask = 0 Then
                If ace.domainName.length > 0 Then
                    entry = ace.domainName & "\" & ace.userName
                Else
                    entry = ace.userName
                End If
                AceArray.Remove(entry)
            End If
        Next
        Dim DACL(amount - 1) As Object
        For i = 1 To amount
            DACL(i - 1) = createACE(AceArray.Item(i).userName, AceArray.Item(i).domainName, AceArray.Item(i).AccessMask, AceArray.Item(i).Type)
        Next
        ' Create security descriptor and add to parameter, which contains (DACL) data from object colection AceArray
        Dim SD = New ManagementClass("Win32_SecurityDescriptor").CreateInstance()
        SD.Item("DACL") = DACL

        Dim scope As ManagementScope
        Dim query As ObjectQuery
        'Dim searcher As ManagementObjectSearcher
        scope = New ManagementScope("\\" & Comp & "\root\cimv2")
        scope.Connect()
        query = New ObjectQuery("SELECT * FROM Win32_Share WHERE Name='" & shareName & "'")
        ' Create sercher, which execute query
        Dim shareSearch = New Management.ManagementObjectSearcher(scope, query)
        Dim shareCol = shareSearch.Get
        For Each obj In shareCol
            share = obj
        Next

        Dim inparams As ManagementBaseObject = share.GetMethodParameters("SetShareInfo")
        inparams.Item("MaximumAllowed") = NumericUpDown1.Value
        inparams.Item("Description") = TextBox5.Text
        inparams.Item("Access") = SD
        '
        Dim options As InvokeMethodOptions = New InvokeMethodOptions
        options.Timeout = New TimeSpan(0, 0, 0, 5)
        '
        Dim result As ManagementBaseObject = share.InvokeMethod("SetShareInfo", inparams, options)
        If result.Item("returnValue") <> 0 Then
            MsgBox("Error " & result.Item("returnValue"))
        End If
        Return 0
    End Function

    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            CheckBox3.Checked = True
            CheckBox2.Checked = True
            CheckBox1.Checked = True
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 2032127
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 0
        Else
            Try
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 1245631
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 0
            Catch
            End Try
        End If
        Button3.Enabled = True
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            CheckBox3.Checked = True
            CheckBox2.Checked = True
            CheckBox1.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 1245631
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 0
        Else
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            Try
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 1179817
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 0
            Catch
            End Try
        End If
        Button3.Enabled = True
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = True
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 1179817
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 0
        Else
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            Try
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 0
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 0
            Catch
            End Try
        End If
        Button3.Enabled = True
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked Then
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox6.Checked = True
            CheckBox5.Checked = True
            CheckBox4.Checked = True
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 2032127
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 1
        Else
            Try
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 1245631
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 1
            Catch
            End Try
        End If
        Button3.Enabled = True
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked Then
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox6.Checked = True
            CheckBox5.Checked = True
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 1245631
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 1
        Else
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            Try
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 1179817
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 1
            Catch
            End Try
        End If
        Button3.Enabled = True
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked Then
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = True
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 1179817
            AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 1
        Else
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            Try
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).AccessMask = 0
                AceArray.Item(ListView1.SelectedItems.Item(0).SubItems(0).Text).Type = 1
            Catch
            End Try
        End If
        Button3.Enabled = True
    End Sub
End Class




