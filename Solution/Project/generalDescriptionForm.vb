Public Class generalDescriptionForm
    Private Sub generalDescriptionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim Comp = UCase(Form1.TextBox1.Text)
            TextBox1.Text = Comp
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("SELECT Description FROM Win32_OperatingSystem")
            For Each obj In col
                TextBox2.Text = obj.description
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        desriptionChanging()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            desriptionChanging()
        End If
    End Sub

    Private Sub desriptionChanging()
        Try
            Dim Comp = UCase(Form1.TextBox1.Text)
            TextBox1.Text = Comp
            Dim col = GetObject("winmgmts:\\" & Comp).InstancesOf("Win32_OperatingSystem")
            For Each obj In col
                obj.description = TextBox2.Text
                obj.Put_()
            Next
            Form1.ListView1.Items(3).SubItems(1).Text = TextBox2.Text
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub
End Class