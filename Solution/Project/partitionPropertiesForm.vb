Public Class partitionPropertiesForm
    Public FixErrors As Boolean = False
    Public VigorousIndexCheck As Boolean = True
    Public SkipFolderCycle As Boolean = True
    Public ForceDismount As Boolean = False
    Public RecoverBadSectors As Boolean = False
    Public OKToRunAtBootUp As Boolean = False

    Private Sub partitionPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim Comp = Form1.TextBox1.Text
            Dim partitionCaption = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
            TextBox1.Text = partitionCaption
            TextBox2.Text = Comp
            Dim FileSystem = Nothing
            Dim DriveType = Nothing
            Dim OccupiedSpace = Nothing
            Dim FreeSpace = Nothing
            Dim OccupiedProcent = Nothing
            Dim FullSize = Nothing
            Dim objWMIservice = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            Dim col = objWMIservice.ExecQuery("Select FileSystem, DriveType, Size, FreeSpace from Win32_LogicalDisk WHERE Caption='" & partitionCaption & "'")
            For Each obj In col
                Try
                    FileSystem = obj.FileSystem.ToString
                Catch
                    FileSystem = "-"
                End Try
                Try
                    DriveType = partitionType(obj.DriveType)
                Catch
                    DriveType = "-"
                End Try
                Try
                    FullSize = obj.Size
                    If FullSize.ToString.Length < 1 Then
                        FullSize = 0
                    End If
                Catch
                    FullSize = 0
                End Try
                Try
                    OccupiedSpace = obj.Size - obj.FreeSpace
                Catch
                    OccupiedSpace = 0
                End Try
                Try
                    FreeSpace = Math.Round(obj.FreeSpace / 1073741824, 2)
                Catch
                    FreeSpace = 0
                End Try
            Next
            If FullSize > 0 Then
                OccupiedProcent = (OccupiedSpace / FullSize) * 100
            Else
                OccupiedProcent = 0
            End If
            FullSize = Math.Round(FullSize / 1073741824, 2)
            OccupiedSpace = Math.Round(OccupiedSpace / 1073741824, 2)
            TextBox3.Text = FileSystem
            TextBox4.Text = DriveType
            TextBox5.Text = FullSize & " Гб"
            TextBox6.Text = OccupiedSpace
            TextBox7.Text = FreeSpace
            ProgressBar1.Value = OccupiedProcent
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Function partitionType(ByVal type)
        Dim typeText = ""
        Select Case type
            Case 0
                typeText = "Unknown"
            Case 1
                typeText = "No root directory"
            Case 2
                typeText = "Removable device"
            Case 3
                typeText = "Local drive"
            Case 4
                typeText = "Network drive"
            Case 5
                typeText = "Compact drive"
            Case 6
                typeText = "RAM drive"
        End Select
        Return typeText
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim resultText = Nothing
            Dim result = Nothing
            Dim Comp = Form1.TextBox1.Text
            Dim partitionCaption = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
            Dim objWMIservice = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            Dim col = objWMIservice.ExecQuery("Select * from Win32_LogicalDisk WHERE Caption='" & partitionCaption & "'")
            For Each obj In col
                result = obj.Chkdsk(FixErrors, VigorousIndexCheck, SkipFolderCycle, ForceDismount, RecoverBadSectors, OKToRunAtBootUp)
            Next
            Select Case result
                Case 0
                    resultText = "Check successfully ended"
                Case 1
                    resultText = "Check will start after reboot"
                Case 2
                    resultText = "Unknown ile system"
                Case 3
                    resultText = "Can't make a check"
            End Select
            MsgBox(resultText, MsgBoxStyle.OkOnly, "Check result")
        Catch ex As Exception
            MsgBox("Check cannot be run on computers with " & Chr(13) & " Windows 2000 and older." & Chr(13) & Chr(13) & "Error:" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub CheckBox1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.Checked Then
            FixErrors = True
            CheckBox4.Enabled = True
        Else
            FixErrors = False
            CheckBox4.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckStateChanged
        If CheckBox2.Checked Then
            VigorousIndexCheck = True
        Else
            VigorousIndexCheck = False
        End If
    End Sub

    Private Sub CheckBox3_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckStateChanged
        If CheckBox3.Checked Then
            SkipFolderCycle = True
        Else
            SkipFolderCycle = False
        End If
    End Sub

    Private Sub CheckBox4_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckStateChanged
        If CheckBox4.Checked Then
            ForceDismount = True
        Else
            ForceDismount = False
        End If
    End Sub

    Private Sub CheckBox5_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckStateChanged
        If CheckBox5.Checked Then
            RecoverBadSectors = True
        Else
            RecoverBadSectors = False
        End If
    End Sub

    Private Sub CheckBox6_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckStateChanged
        If CheckBox6.Checked Then
            OKToRunAtBootUp = True
        Else
            OKToRunAtBootUp = False
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            Dim ver As Integer = 0
            Dim FileSystem = ""
            Dim Comp = TextBox2.Text
            Dim objWMIservice = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            Dim col = objWMIservice.ExecQuery("Select BuildNumber,Version from Win32_OperatingSystem")
            For Each obj In col
                ver = obj.BuildNumber
            Next
            For Each item In Form1.ListView1.Items
                If item.text = TextBox1.Text Then
                    FileSystem = item.subitems(1).text
                End If
            Next
            If ver < 2600 And TabControl1.SelectedTab Is TabPage2 Then
                TabControl1.SelectedTab = TabPage1
                MsgBox("Remote check is not possible on that operating system.", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
            End If
            If FileSystem <> "NTFS" And TabControl1.SelectedTab Is TabPage2 Then
                TabControl1.SelectedTab = TabPage1
                MsgBox("Partition check is not possible on that file system.", MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub
End Class