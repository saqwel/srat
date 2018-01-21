
Imports System.DirectoryServices
Public Class userGroupAddForm
    Private Sub userGroupAddForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim Comp = UCase(Form1.TextBox1.Text)
            Dim userName = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
            TextBox1.Text = userName
            TextBox2.Text = Comp
            Dim dirEntry As New DirectoryEntry("WinNT://" & Comp)
            For Each child In dirEntry.Children
                If child.SchemaClassName = "Group" Then
                    ComboBox1.Items.Add(child.Name)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim Comp = TextBox2.Text
            Dim userName = TextBox1.Text
            Dim groupName = ComboBox1.Text
            Dim objUser = GetObject("WinNT://" & Comp & "/" & userName & ",user")
            Dim objGroup = GetObject("WinNT://" & Comp & "/" & groupName & ",group")
            objGroup.Add(objUser.ADsPath)
            userPropertiesForm.ListView1.Items.Add(New ListViewItem(New String() {groupName}))
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class