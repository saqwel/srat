Public Class servicePropertiesForm

    ' "Run" button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim Comp, objWMIService, Serv, colServ
            Comp = TextBox2.Text
            Serv = TextBox1.Text
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName = '" & Serv & "'")
            For Each objServ In colServ
                objServ.StartService()
                For Each item In Form1.ListView1.Items
                    If item.text = Serv Then
                        item.SubItems(2).Text = "Running"
                    End If
                Next
                'Form1.ListView1.SelectedItems.Item(0).SubItems(2).Text = "Running"
            Next
            Button1.Enabled = False
            Button2.Enabled = True
            Button2.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Stop" button
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim Comp, objWMIService, Serv, colServ
            Comp = TextBox2.Text
            Serv = TextBox1.Text
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName = '" & Serv & "'")
            For Each objServ In colServ
                objServ.StopService()
                For Each item In Form1.ListView1.Items
                    If item.text = Serv Then
                        item.SubItems(2).Text = ""
                    End If
                Next
                'Form1.ListView1.SelectedItems.Item(0).SubItems(2).Text = ""
            Next
            Button1.Enabled = True
            Button2.Enabled = False
            Button1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Saqwel Remote Administration Tool")
        End Try
    End Sub

    ' "Apply" button
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        saveProperties()
        Button3.Enabled = False
        Button5.Focus()
    End Sub

    ' "OK" button
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        saveProperties()
        Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Button3.Enabled = True
    End Sub
    Function saveProperties()
        Try
            Dim Comp, Serv, objWMIService, colServ, objServ
            Comp = TextBox2.Text
            Serv = TextBox1.Text
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName='" & Serv & "'")
            Select Case ComboBox1.SelectedIndex
                Case 0
                    For Each objServ In colServ
                        objServ.ChangeStartMode("Automatic")
                        For Each item In Form1.ListView1.Items
                            If item.text = Serv Then
                                item.SubItems(3).Text = "Automatic"
                            End If
                        Next
                        'Form1.ListView1.SelectedItems.Item(0).SubItems(3).Text = "Автоматически"
                    Next
                    Button1.Enabled = True
                Case 1
                    For Each objServ In colServ
                        objServ.ChangeStartMode("Manual")
                        For Each item In Form1.ListView1.Items
                            If item.text = Serv Then
                                item.SubItems(3).Text = "Manual"
                            End If
                        Next
                        'Form1.ListView1.SelectedItems.Item(0).SubItems(3).Text = "Вручную"
                    Next
                    Button1.Enabled = True
                Case 2
                    For Each objServ In colServ
                        objServ.ChangeStartMode("Disabled")
                        For Each item In Form1.ListView1.Items
                            If item.text = Serv Then
                                item.SubItems(3).Text = "Disabled"
                            End If
                        Next
                        'Form1.ListView1.SelectedItems.Item(0).SubItems(3).Text = "Отключена"
                    Next
                    Button1.Enabled = False
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
        Return 0
    End Function

    Private Sub servicePropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim Comp = Form1.TextBox1.Text
            Dim ServName = Nothing
            Dim ServPath = Nothing
            Dim ServDesc = Nothing
            Dim ServStrt = Nothing
            Dim ServSost = Nothing
            Dim ServDisp = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            Dim colServ = objWMIService.ExecQuery("SELECT Name, PathName, Description, StartMode, State FROM Win32_Service WHERE DisplayName = '" & ServDisp & "'")
            For Each objServ In colServ
                ServName = objServ.Name.ToString()
                ServPath = objServ.PathName.ToString()
                ServDesc = objServ.Description.ToString()
                ServStrt = objServ.StartMode.ToString()
                ServSost = objServ.State.ToString()
            Next
            'Form2.Text = "Service properties " & ServName
            TextBox1.Text = ServDisp
            TextBox2.Text = Comp
            TextBox3.Text = ServName
            TextBox4.Text = ServDesc
            TextBox5.Text = ServPath
            Select Case ServSost
                Case "Running"
                    Button1.Enabled = False
                    Button2.Enabled = True
                Case "Stopped"
                    Button1.Enabled = True
                    Button2.Enabled = False
                Case "Paused"
                    Button1.Enabled = True
                    Button2.Enabled = False
                Case "Start Pending"
                    Button1.Enabled = False
                    Button2.Enabled = False
                Case "Stop Pending"
                    Button1.Enabled = False
                    Button2.Enabled = False
                Case "Pause Pending"
                    Button1.Enabled = False
                    Button2.Enabled = False
                Case "Unknown"
                    Button1.Enabled = True
                    Button2.Enabled = True
            End Select
            Select Case ServStrt
                Case "Auto"
                    ComboBox1.SelectedItem = ComboBox1.Items(0)
                Case "Manual"
                    ComboBox1.SelectedItem = ComboBox1.Items(1)
                Case "Disabled"
                    ComboBox1.SelectedItem = ComboBox1.Items(2)
                    Button1.Enabled = False
            End Select
            Button3.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

End Class