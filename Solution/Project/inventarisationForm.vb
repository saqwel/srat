Public Class inventarisationForm

    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
        End If
    End Sub
End Class