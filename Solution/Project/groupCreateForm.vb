Imports System.DirectoryServices
Public Class groupCreateForm
    Private Sub groupCreateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim Comp = Form1.TextBox1.Text
            TextBox1.Text = Comp
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim Comp = Form1.TextBox1.Text
            Dim groupName = TextBox2.Text
            Dim groupDescription = TextBox3.Text
            Dim objComp = GetObject("WinNT://" & Comp)
            Dim objGroup = objComp.Create("group", groupName)
            objGroup.Description = groupDescription
            objGroup.setInfo()
            'For index = 0 To ListView1.Items.Count - 1
            'objGroup.Add("WinNT://" & Comp & "/" & ListView1.Items(index).SubItems(0).Text)
            'Next
            'Form1.ListView1.Items.Add(New ListViewItem(New String() {groupName, groupDescription}))
            Form1.getGroupsFunc()
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class