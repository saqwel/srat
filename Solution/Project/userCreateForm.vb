Imports System.DirectoryServices
Public Class userCreateForm

    Private Sub userCreateForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TextBox9.Text = UCase(Form1.TextBox1.Text)
            TextBox1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim row(3) As String
        Dim itm As ListViewItem
        Try
            If TextBox1.Text.Length < 1 Then
                MsgBox("Need to enter user name", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")

            End If

            'Если пароли совпадают и длина имени больше нуля
            If TextBox4.Text = TextBox5.Text And TextBox1.Text.Length > 0 Then
                Dim Comp = UCase(Form1.TextBox1.Text)
                Dim AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Comp)
                Dim NewUser As DirectoryEntry = AD.Children.Add(TextBox1.Text, "user")
                NewUser.Invoke("Put", New Object() {"FullName", TextBox2.Text})
                NewUser.Invoke("Put", New Object() {"Description", TextBox3.Text})
                NewUser.Invoke("SetPassword", New Object() {TextBox4.Text})
                If CheckBox1.Checked Then
                    NewUser.Invoke("Put", New Object() {"PasswordExpired", 1})
                Else
                    NewUser.Invoke("Put", New Object() {"PasswordExpired", 0})
                End If
                'Запретить смену пароля пользоватем
                If CheckBox2.Checked Then
                    NewUser.Invoke("Put", New Object() {"Userflags", &H40})
                End If
                'Срок действия пароля не ограничен
                If CheckBox3.Checked Then
                    NewUser.Invoke("Put", New Object() {"Userflags", &H10000})
                End If
                'Срок не ограничен и запрещена смена
                If CheckBox2.Checked And CheckBox3.Checked Then
                    NewUser.Invoke("Put", New Object() {"Userflags", &H40 Or &H10000})
                End If
                'Отключить учётную запись
                If CheckBox4.Checked Then
                    NewUser.Invoke("Put", New Object() {"Userflags", &H2})
                End If
                If CheckBox2.Checked And CheckBox4.Checked Then
                    NewUser.Invoke("Put", New Object() {"Userflags", &H40 Or &H2})
                End If
                If CheckBox3.Checked And CheckBox4.Checked Then
                    NewUser.Invoke("Put", New Object() {"Userflags", &H10000 Or &H2})
                End If
                If CheckBox2.Checked And CheckBox3.Checked And CheckBox4.Checked Then
                    NewUser.Invoke("Put", New Object() {"Userflags", &H40 Or &H10000 Or &H2})
                End If
                'NewUser.Invoke("Put", New Object() {"PasswordAge", 0})
                'NewUser.Invoke("ChangePassword", OldSecurelyStoredPassword, NewSecurelyStoredPassword)
                NewUser.CommitChanges()
                Dim listViewItem As New ListViewItem
                row(0) = TextBox1.Text
                row(1) = TextBox2.Text
                row(2) = TextBox3.Text
                itm = New ListViewItem(row)
                'Form1.ListView1.Items.Add(itm)
                Form1.getUsersFunc()
                Close()
            Else
                MsgBox("Passwords are different", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked Then
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
        Else
            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
        End If
    End Sub

    Private Sub CheckBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        If CheckBox2.Checked Then
            CheckBox1.Enabled = False
        Else
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.Click
        If CheckBox3.Checked Then
            CheckBox1.Enabled = False
        Else
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub userCreateForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TextBox1.Focus()
    End Sub
End Class