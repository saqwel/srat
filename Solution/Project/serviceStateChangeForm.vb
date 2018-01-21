Public Class serviceStateChangeForm
    Private COMP
    Private SERV
    Private STATE
    Private COUNTER
    Private ERROR_TEXT

    Private Sub servStartForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SERV = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
            COMP = Form1.TextBox1.Text
            If Form1.SERV_STATE = "Stop" Then
                Label1.Text = "Stop service " & SERV
                ERROR_TEXT = "Can't stop service " & SERV & vbCrLf
            End If
            If Form1.SERV_STATE = "Start" Then
                Label1.Text = "Run service " & SERV
                ERROR_TEXT = "Can't run service " & SERV & vbCrLf
            End If
            If Form1.SERV_STATE = "Restart" Then
                Label1.Text = "Restert service " & SERV
                ERROR_TEXT = "Can't restart service " & SERV & vbCrLf
                STATE = "stopping"
                restartFunc()
            End If
            Timer1.Enabled = True
            Timer1.Start()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If COUNTER < 30 Then
                COUNTER += 1
                If Form1.SERV_STATE = "Restart" Then
                    progressRestart()
                Else
                    servState()
                End If
            Else
                Timer1.Stop()
                Dim answer = MsgBox(ERROR_TEXT & "Wait restart?", MsgBoxStyle.YesNo, "Saqwel Remote Administration Tool")
                If answer = MsgBoxResult.Yes Then
                    COUNTER = 0
                    Timer1.Start()
                Else
                    Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub
   
    Private Sub servState()
        Try
            Dim objWMIService, colServ
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName = '" & SERV & "'")
            For Each objServ In colServ
                If Form1.SERV_STATE = "Start" Then
                    If objServ.State <> "Running" Then
                        Timer1.Start()
                    Else
                        Timer1.Enabled = False

                        Form1.ListView1.SelectedItems.Item(0).SubItems(2).Text = "Running"
                        Form1.ContextService.Items(0).Enabled = False
                        Form1.ContextService.Items(1).Enabled = True
                        Form1.ContextService.Items(2).Enabled = True
                        Close()
                    End If
                End If
                If Form1.SERV_STATE = "Stop" Then
                    If objServ.State <> "Stopped" Then
                        Timer1.Start()
                    Else
                        Timer1.Enabled = False

                        Form1.ListView1.SelectedItems.Item(0).SubItems(2).Text = ""
                        Form1.ContextService.Items(0).Enabled = True
                        Form1.ContextService.Items(1).Enabled = False
                        Form1.ContextService.Items(2).Enabled = False
                        Close()
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub restartFunc()
        Try
            Dim objWMIService, colServ
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName = '" & SERV & "'")
            For Each objServ In colServ
                If STATE = "stopping" Then
                    objServ.stopService()
                    Timer1.Start()
                End If
                If STATE = "starting" Then
                    objServ.startService()
                    Timer1.Start()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub
    Private Sub progressRestart()
        Try
            Dim objWMIService, colServ
            objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")
            colServ = objWMIService.ExecQuery("SELECT * FROM Win32_Service WHERE DisplayName = '" & SERV & "'")
            For Each objServ In colServ
                If STATE = "starting" Then
                    If objServ.State <> "Running" Then
                        Timer1.Start()
                    Else
                        Timer1.Enabled = False

                        Form1.ListView1.SelectedItems.Item(0).SubItems(2).Text = "Running"
                        Form1.ContextService.Items(0).Enabled = False
                        Form1.ContextService.Items(1).Enabled = True
                        Form1.ContextService.Items(2).Enabled = True
                        Close()
                    End If
                End If
                If STATE = "stopping" Then
                    If objServ.State <> "Stopped" Then
                        Timer1.Start()
                    Else
                        Timer1.Enabled = False

                        Form1.ListView1.SelectedItems.Item(0).SubItems(2).Text = ""
                        Form1.ContextService.Items(0).Enabled = True
                        Form1.ContextService.Items(1).Enabled = False
                        Form1.ContextService.Items(2).Enabled = False
                        STATE = "starting"
                        restartFunc()
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub
End Class