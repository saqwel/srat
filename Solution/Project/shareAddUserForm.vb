Imports System.DirectoryServices
Public Class shareAddUserForm

    Private Sub shareAddUserForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim domainName = Form1.ComboBox1.Text
            Dim Comp = sharePropertiesForm.TextBox2.Text
            Dim shareName = sharePropertiesForm.TextBox1.Text
            TextBox1.Text = shareName
            TextBox2.Text = Comp
            ComboBox1.Items.Add(Comp)
            ComboBox1.Items.Add(domainName)
            ComboBox1.SelectedItem = ComboBox1.Items(0)
            ComboBox2.Items.Add("Users")
            ComboBox2.Items.Add("Groups")
            ComboBox2.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            ComboBox2.SelectedIndex = -1
            ComboBox3.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            ComboBox3.SelectedIndex = -1
            ComboBox3.Items.Clear()
            Select Case ComboBox2.SelectedIndex
                Case 0
                    Dim dirEntry As New DirectoryEntry("WinNT://" & ComboBox1.SelectedItem.ToString)
                    For Each child In dirEntry.Children
                        If child.SchemaClassName = "User" Then
                            ComboBox3.Items.Add(child.Name)
                        End If
                    Next
                Case 1
                    Dim dirEntry As New DirectoryEntry("WinNT://" & ComboBox1.SelectedItem.ToString)
                    For Each child In dirEntry.Children
                        If child.SchemaClassName = "Group" Then
                            ComboBox3.Items.Add(child.Name)
                        End If
                    Next
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim objectExist = False
            For Each obj In ComboBox3.Items
                If obj.ToString() = ComboBox3.Text Then
                    objectExist = True
                End If
            Next
            If objectExist Then
                Dim entry
                Dim ace = New objACE
                ace.userName = ComboBox3.Text
                ace.domainName = ComboBox1.Text
                ace.AccessMask = 1179817
                ace.Type = 0
                If ace.domainName.Length > 0 Then
                    entry = ace.domainName & "\" & ace.userName
                Else
                    entry = ace.userName
                End If
                sharePropertiesForm.AceArray.Add(ace, entry)
                sharePropertiesForm.ListView1.Items.Add(New ListViewItem(New String() {entry}))
                Close()
            Else
                MsgBox("Such object does not exist", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class