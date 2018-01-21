
Public Class groupPropertiesForm
    Public type

    Private Sub groupPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim Comp = Form1.TextBox1.Text
            Dim groupName = Form1.ListView1.SelectedItems.Item(0).Text
            Dim objWMIService, col, typeCode
            Dim domain = ""
            Dim row(1) As String
            Dim rows(1000) As ListViewItem
            Dim i As Integer = 0
            Dim objects = -1
            TextBox1.Text = groupName
            TextBox2.Text = Comp
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            ListView1.Columns.Add("groupUser", "Name", 200)
            ListView1.Columns.Add("groupUser", "Type", 100)

            Dim objGroup = GetObject("WinNT://" & Comp & "/" & groupName & ",group")
            TextBox3.Text = objGroup.Description
            Button3.Enabled = False
            ListView1.Sorting = SortOrder.Ascending
            For Each Member In objGroup.Members
                objects = objects + 1
            Next
            ReDim rows(objects)
            For Each Member In objGroup.Members
                ' Determine domain and type of group member through WMI
                col = objWMIService.ExecQuery("Select Domain, SIDType from Win32_Account WHERE Name='" & Member.Name & "'")

                For Each obj In col
                    domain = obj.Domain.ToString
                    'If obj.LocalAccount Then
                    'domain = ""
                    'Else
                    domain = domain + "\"
                    'End If
                    typeCode = obj.SIDType
                    Select Case typeCode
                        Case 1
                            type = "User"
                        Case 2
                            type = "Group"
                        Case 3
                            type = "Domain"
                        Case 4
                            type = "Alias"
                        Case 5
                            type = "WellKnownGroup"
                        Case 6
                            type = "DeletedAccount"
                        Case 7
                            type = "Invalid"
                        Case 8
                            type = "Unknown"
                        Case 9
                            type = "Computer"
                    End Select
                Next
                row(0) = domain & Member.Name
                row(1) = type
                rows(i) = New ListViewItem(row)
                i = i + 1
            Next
            ListView1.Items.AddRange(rows)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        groupAddMemberForm.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        groupDeleteMemberFunc()
    End Sub

    Private Sub groupDeleteMemberFunc()
        Try
            Dim Comp = TextBox2.Text
            Dim groupName = TextBox1.Text
            Dim domain = ""
            Dim Member = ListView1.SelectedItems.Item(0).SubItems(0).Text

            Dim indexof = Member.IndexOf("\")
            If indexof <> -1 Then
                domain = Mid(Member, 1, indexof)
                Member = Mid(Member, indexof + 2)
            End If

            Dim objMember = GetObject("WinNT://" & domain & "/" & Member & "," & type)
            Dim objGroup = GetObject("WinNT://" & Comp & "/" & groupName & ",group")
            objGroup.Remove(objMember.ADsPath)
            ListView1.SelectedItems.Item(0).Remove()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            Dim x = ListView1.SelectedItems.Item(0).Text
            Button5.Enabled = True
        Catch
            Button5.Enabled = False
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim Comp = TextBox2.Text
            Dim groupName = TextBox1.Text
            Dim objGroup = GetObject("WinNT://" & Comp & "/" & groupName & ",group")
            objGroup.Description = TextBox3.Text
            objGroup.setInfo()
            For Each item In Form1.ListView1.Items
                If item.text = groupName Then
                    item.SubItems(1).Text = TextBox3.Text
                End If
            Next
            'Form1.ListView1.SelectedItems.Item(0).SubItems(1).Text = TextBox3.Text
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim Comp = TextBox2.Text
            Dim groupName = TextBox1.Text
            Dim objGroup = GetObject("WinNT://" & Comp & "/" & groupName & ",group")
            objGroup.Description = TextBox3.Text
            objGroup.setInfo()
            For Each item In Form1.ListView1.Items
                If item.text = groupName Then
                    item.SubItems(1).Text = TextBox3.Text
                End If
            Next
            'Form1.ListView1.SelectedItems.Item(0).SubItems(1).Text = TextBox3.Text
            Button3.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Button3.Enabled = True
    End Sub
End Class