Public Class userPasswordForm
    Private Sub userPasswordForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Comp = UCase(Form1.TextBox1.Text)
        Dim userName = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
        TextBox1.Text = userName
        TextBox2.Text = Comp
        TextBox3.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        passwordChange()
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            passwordChange()
        End If
    End Sub

    Private Sub passwordChange()
        Dim Comp = UCase(Form1.TextBox1.Text)
        Dim userName = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
        Try
            Dim objUser = GetObject("WinNT://" & Comp & "/" & userName & ",user")
            If TextBox3.Text = TextBox4.Text Then
                objUser.setPassword(TextBox3.Text)
            End If
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub
End Class