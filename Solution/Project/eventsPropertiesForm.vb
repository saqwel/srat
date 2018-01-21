Public Class eventsPropertiesForm

    Private Sub eventsPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Comp = UCase(Form1.TextBox1.Text)
        Dim eventNum As Long = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
        TextBox1.Text = eventNum
        TextBox2.Text = Comp

        Dim col, objWMIService, tz
        Dim objDatetime = CreateObject("WbemScripting.SWbemDateTime")
        objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
        col = objWMIService.ExecQuery("select bias from Win32_Timezone")
        For Each obj In col
            tz = obj.bias
        Next
        col = objWMIService.ExecQuery("select * from Win32_NTLogEvent WHERE LogFile='" & Form1.param & "' AND RecordNumber='" & eventNum & "'", "WQL")
        For Each obj In col
            TextBox3.Text = Form1.PARAM
            TextBox4.Text = obj.SourceName.ToString
            TextBox5.Text = obj.EventCode.ToString
            'TextBox6.Text = Form1.eventTypeToString(obj.EventType)
            TextBox7.Text = obj.User.ToString
            TextBox8.Text = Form1.datetimeFormat(obj.TimeGenerated, objDatetime) 'Form1.FormatDatetime(obj.TimeGenerated.ToString, tz)
            TextBox9.Text = obj.Message.ToString
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub


    Function logFileRu(ByVal value)
        Dim nameRu = ""
        Select Case value
            Case "System"
                nameRu = "Система"
            Case "Application"
                nameRu = "Приложение"
            Case "Security"
                nameRu = "Безопасность"
        End Select
        Return nameRu
    End Function

End Class