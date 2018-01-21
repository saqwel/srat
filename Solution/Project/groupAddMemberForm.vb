Imports System.DirectoryServices
Public Class groupAddMemberForm
    Private Sub groupAddMemberForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim domainName = Form1.ComboBox1.Text
            Dim Comp = groupPropertiesForm.TextBox2.Text
            Dim groupName = groupPropertiesForm.TextBox1.Text
            TextBox1.Text = groupName
            TextBox2.Text = Comp
            ComboBox1.Items.Add(Comp)
            ComboBox1.Items.Add(domainName)
            ComboBox1.SelectedItem = ComboBox1.Items(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            ComboBox2.SelectedIndex = -1
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()
            If ComboBox1.SelectedIndex = 1 Then
                ComboBox2.Items.Add("Users")
                ComboBox2.Items.Add("Groups")
                ComboBox2.Items.Add("Computers")
            Else
                ComboBox2.Items.Add("Users")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox3.SelectedIndex = -1
        Try
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
                Case 2
                    Dim dirEntry As New DirectoryEntry("WinNT://" & ComboBox1.SelectedItem.ToString)
                    For Each child In dirEntry.Children
                        If child.SchemaClassName = "Computer" Then
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
            If ComboBox1.SelectedIndex > -1 And ComboBox2.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
                Dim objGroup ', objMember, objectName
                Dim groupName = TextBox1.Text
                Dim Comp = TextBox2.Text
                objGroup = GetObject("WinNT://" & Comp & "/" & groupName & ",group")
                'Select Case ComboBox2.SelectedIndex
                'Case 0
                'objectName = "user"
                'Case 1
                'objectName = "group"
                'Case 2
                'objectName = "computer"
                'End Select
                'objMember = GetObject("WinNT://" & ComboBox1.SelectedItem.ToString & "/" & ComboBox3.SelectedItem.ToString & ", " & objectName)
                objGroup.Add("WinNT://" & ComboBox1.SelectedItem.ToString & "/" & ComboBox3.SelectedItem.ToString)
                groupPropertiesForm.ListView1.Items.Add(ComboBox1.SelectedItem.ToString & "\" & ComboBox3.SelectedItem.ToString)
                Close()
            Else
                MsgBox("Choose object which you want to add", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class