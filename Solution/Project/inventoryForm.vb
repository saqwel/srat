Imports System.DirectoryServices

Public Class inventoryForm
    Private COMP
    Private APP_PATH

    Private Sub inventoryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            APP_PATH = My.Application.Info.DirectoryPath
        Catch
            APP_PATH = Environment.CurrentDirectory
        End Try
        'My.Computer.FileSystem.CreateDirectory(APP_PATH & "\Inventory")
        Me.OpenFileDialog1.InitialDirectory = APP_PATH
        Me.FolderBrowserDialog1.SelectedPath = APP_PATH

        Me.Label1.Text = ""
        Me.TextBox2.Text = APP_PATH

        CheckBox3.Enabled = False
        CheckBox4.Enabled = False
        CheckBox5.Enabled = False
        CheckBox6.Enabled = False
        CheckBox7.Enabled = False
        CheckBox8.Enabled = False

        CheckBox3.Checked = True
        CheckBox4.Checked = True
        CheckBox5.Checked = True
        CheckBox6.Checked = True
        CheckBox7.Checked = True
        CheckBox8.Checked = True

        Dim parent As New DirectoryEntry("WinNT:")
        Dim child As DirectoryEntry
        Dim domainName = ""
        Dim domainFind = False
        Try
            For Each child In parent.Children
                If child.SchemaClassName = "Domain" Then
                    ComboBox1.Items.Add(child.Name)
                End If
            Next
            For Each item In ComboBox1.Items
                If item.ToString() = Environment.UserDomainName Then
                    ComboBox1.SelectedItem = item
                    domainFind = True
                End If
            Next
            If Not domainFind Then
                For Each item In ComboBox1.Items
                    If item.ToString() = "WORKGROUP" Then
                        ComboBox1.SelectedItem = item
                        domainFind = True
                    End If
                Next
                If Not domainFind Then
                    ComboBox1.SelectedIndex = 0
                    domainFind = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub inventoryForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            ListView1.Items.Clear()
            CheckBox0.Checked = False
            Dim i = 0
            Dim dirEntry As New DirectoryEntry("WinNT://" & ComboBox1.SelectedItem.ToString()) 'Environment.UserDomainName)
            For Each child In dirEntry.Children
                If child.SchemaClassName = "Computer" Then
                    ListView1.Items.Add(New ListViewItem(New String() {child.Name}))
                    i += 1
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Not My.Computer.FileSystem.DirectoryExists(TextBox2.Text) Then
                MsgBox("Необходимо указать существующую папку для сохранения результатов инвентаризации", MsgBoxStyle.Exclamation, "Saqwel Remoe Administration Tool")
                MsgBox("You need to set existing folder to save results", MsgBoxStyle.Exclamation, "Saqwel Remote Administration Tool")
                Exit Sub
            End If
            If CheckBox1.Checked Or CheckBox2.Checked Then
                If My.Computer.FileSystem.FileExists(TextBox2.Text & "\software.txt") Then
                    My.Computer.FileSystem.DeleteFile(TextBox2.Text & "\software.txt")
                End If
                If My.Computer.FileSystem.FileExists(TextBox2.Text & "\hardware.txt") Then
                    My.Computer.FileSystem.DeleteFile(TextBox2.Text & "\hardware.txt")
                End If
                Dim j = 0
                For Each computer In ListView1.Items
                    If computer.checked Then
                        j += 1
                    End If
                Next
                ProgressBar1.Step = 1
                ProgressBar1.Maximum = j
                ProgressBar1.Minimum = 0

                Dim delimiter = setDelimiter()
                Dim newrow = setNewrow()
                Dim objReg, objSoft, pathSoft, objWMIService
                Dim HKLM = &H80000002
                Dim Path = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
                Dim col = Nothing
                Dim soft(500) As String
                Dim colHard
                Dim row(3) As String
                Dim rowHardware(6) As String
                Dim i As Integer = 0
                Dim s As Integer = 0


                If j > 0 Then
                    ' Set columns headers
                    My.Computer.FileSystem.WriteAllText(TextBox2.Text & "\hardware.txt",
                                "Computer name" & delimiter &
                                "Processor" & delimiter &
                                "Processor frequency" & delimiter &
                                "RAM" & delimiter &
                                "RAM frequency" & delimiter &
                                "Storage" & delimiter &
                                "Storage capacity" & delimiter &
                                "Network" & delimiter &
                                "MAC address" & delimiter &
                                "Video device" & delimiter &
                                "Video RAM" & delimiter &
                                "Sound device" & delimiter & vbCrLf, True)
                    ' Iterate through list of computers
                    For Each computer In ListView1.Items
                        ' Whether checkbox checked
                        If computer.checked Then
                            COMP = computer.SubItems(0).Text
                            ' SOFTWARE
                            If CheckBox1.Checked Then
                                Label1.Text = "Collect list of software from " & COMP
                                ' Check that computer is accessible
                                Try
                                    ' If computer is accessible
                                    objReg = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\default:StdRegProv")
                                    objReg.EnumKey(HKLM, Path, col)
                                    For Each objSoft In col
                                        pathSoft = Path & "\" & objSoft.ToString()
                                        Try
                                            objReg.GetStringValue(HKLM, pathSoft, "DisplayName", row(0))
                                        Catch
                                            row(0) = Nothing
                                        End Try
                                        If row(0) IsNot Nothing Then
                                            Try
                                                objReg.GetStringValue(HKLM, pathSoft, "DisplayVersion", row(1))
                                            Catch
                                                row(1) = "-"
                                            End Try
                                            Try
                                                objReg.GetStringValue(HKLM, pathSoft, "InstallDate", row(2))
                                            Catch
                                                row(2) = "-"
                                            End Try
                                            soft(s) = row(0) & delimiter & row(1) & delimiter & row(2)
                                            s += 1
                                            'My.Computer.FileSystem.WriteAllText(TextBox2.Text & "\software.txt", COMP & delimiter & row(0) & delimiter & row(1) & delimiter & row(2) & vbCrLf, True)
                                        End If
                                    Next
                                    s = 0
                                    Array.Sort(soft)
                                    For s = 0 To UBound(soft)
                                        If Len(soft(s)) > 0 Then
                                            My.Computer.FileSystem.WriteAllText(TextBox2.Text & "\software.txt", COMP & delimiter & soft(s) & vbCrLf, True)
                                        End If
                                    Next
                                Catch ex As Exception
                                    ' If computer is not accessible
                                    My.Computer.FileSystem.WriteAllText(TextBox2.Text & "\software.txt", COMP & delimiter & ex.Message & vbCrLf, True)
                                End Try
                            End If

                            ' HARDWARE
                            If CheckBox2.Checked Then
                                ' Date object for next conversion
                                Dim objDatetime = CreateObject("WbemScripting.SWbemDateTime")
                                Dim repeat
                                Label1.Text = "Collect information about computer hardware for " & COMP
                                objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & COMP & "\root\cimv2")

                                ' Processor
                                If CheckBox3.Checked Then
                                    Try
                                        colHard = objWMIService.ExecQuery("Select Name, Caption, MaxClockSpeed from Win32_Processor")
                                        repeat = 0
                                        For Each obj In colHard
                                            ' Processor
                                            Try
                                                If repeat = 0 Then
                                                    rowHardware(0) = obj.Name
                                                Else
                                                    rowHardware(0) &= newrow & obj.Name
                                                End If
                                            Catch ex As Exception
                                                If repeat = 0 Then
                                                    rowHardware(0) = "-"
                                                Else
                                                    rowHardware(0) &= newrow & "-"
                                                End If
                                            End Try
                                            ' Processor
                                            Try
                                                rowHardware(0) &= obj.Caption
                                            Catch ex As Exception
                                            End Try
                                            ' Max frequency
                                            Dim speed
                                            Try
                                                If obj.MaxClockSpeed >= 1000 Then
                                                    speed = Math.Round(obj.MaxClockSpeed / 1000, 1) & " GHz"
                                                Else
                                                    speed = obj.MaxClockSpeed & " MHz"
                                                End If
                                                rowHardware(0) &= delimiter & speed
                                            Catch ex As Exception
                                                rowHardware(0) &= delimiter & "-"
                                            End Try
                                            repeat = 1
                                        Next
                                    Catch
                                    End Try
                                End If

                                ' Memory
                                If CheckBox4.Checked Then
                                    Try
                                        colHard = objWMIService.ExecQuery("Select Capacity, Model, Speed from  Win32_PhysicalMemory")
                                        repeat = 0
                                        For Each obj In colHard
                                            ' Manufacturer
                                            'Try()
                                            'rowHardware(0) = obj.Manufacturer
                                            'Catch ex As Exception
                                            'End Try
                                            ' Capacity
                                            Try
                                                If repeat = 0 Then
                                                    rowHardware(1) = Math.Round(obj.Capacity / 1048576) & " MB"
                                                Else
                                                    rowHardware(1) &= newrow & Math.Round(obj.Capacity / 1048576) & " MB"
                                                End If
                                            Catch ex As Exception
                                                If repeat = 0 Then
                                                    rowHardware(1) = "-"
                                                Else
                                                    rowHardware(1) &= newrow & "-"
                                                End If
                                            End Try
                                            ' Speed
                                            Try
                                                rowHardware(1) &= delimiter & obj.Speed & " MHz"
                                            Catch ex As Exception
                                                rowHardware(1) &= delimiter & "-"
                                            End Try
                                            repeat = 1
                                        Next
                                    Catch
                                    End Try
                                End If

                                ' Storage
                                If CheckBox5.Checked Then
                                    Try
                                        colHard = objWMIService.ExecQuery("Select Caption, Size from Win32_DiskDrive")
                                        repeat = 0
                                        For Each obj In colHard
                                            ' Hard drive
                                            Try
                                                If repeat = 0 Then
                                                    rowHardware(2) = obj.Caption
                                                Else
                                                    rowHardware(2) &= newrow & obj.Caption
                                                End If
                                            Catch ex As Exception
                                                If repeat = 0 Then
                                                    rowHardware(2) = "-"
                                                Else
                                                    rowHardware(2) &= newrow & "-"
                                                End If
                                            End Try
                                            ' Size
                                            Dim size
                                            Try
                                                size = Math.Round(obj.Size / 1073741824) & " Gb"
                                            Catch ex As Exception
                                                size = "-"
                                            End Try
                                            rowHardware(2) &= delimiter & size
                                            repeat = 1
                                        Next
                                    Catch
                                    End Try
                                End If

                                ' Network
                                If CheckBox6.Checked Then
                                    Try
                                        colHard = objWMIService.ExecQuery("Select Description, MACAddress from Win32_NetworkAdapterConfiguration WHERE IPEnabled=true")
                                        repeat = 0
                                        For Each obj In colHard
                                            ' Netowrk card
                                            Try
                                                If repeat = 0 Then
                                                    rowHardware(3) = obj.Description.ToString
                                                Else
                                                    rowHardware(3) &= newrow & obj.Description.ToString
                                                End If
                                            Catch
                                                If repeat = 0 Then
                                                    rowHardware(3) = "-"
                                                Else
                                                    rowHardware(3) &= newrow & "-"
                                                End If
                                            End Try
                                            ' MAC-address
                                            Try
                                                rowHardware(3) &= delimiter & obj.MACAddress.ToString
                                            Catch
                                                rowHardware(3) &= delimiter & "-"
                                            End Try
                                            repeat = 1
                                        Next
                                    Catch
                                    End Try
                                End If

                                ' Video devices
                                If CheckBox7.Checked Then
                                    Try
                                        colHard = objWMIService.ExecQuery("Select Caption, AdapterRAM from Win32_VideoController")
                                        repeat = 0
                                        For Each obj In colHard
                                            ' Device name
                                            Try
                                                If repeat = 0 Then
                                                    rowHardware(4) = obj.Caption
                                                Else
                                                    rowHardware(4) &= newrow & obj.Caption
                                                End If
                                            Catch
                                                If repeat = 0 Then
                                                    rowHardware(4) = "-"
                                                Else
                                                    rowHardware(4) &= newrow & "-"
                                                End If
                                            End Try
                                            ' Video device memory
                                            Try
                                                rowHardware(4) &= delimiter & (obj.AdapterRAM.ToString / 1048576) & " MB"
                                            Catch
                                                rowHardware(4) &= delimiter & "-"
                                            End Try
                                            repeat = 1
                                        Next
                                    Catch
                                    End Try
                                End If

                                ' Sound devices
                                If CheckBox8.Checked Then
                                    Try
                                        colHard = objWMIService.ExecQuery("Select Name from Win32_SoundDevice")
                                        repeat = 0
                                        For Each obj In colHard
                                            Try
                                                If repeat = 0 Then
                                                    rowHardware(5) = obj.Name.ToString
                                                Else
                                                    rowHardware(5) &= newrow & obj.Name.ToString
                                                End If
                                            Catch
                                                If repeat = 0 Then
                                                    rowHardware(5) = "-"
                                                Else
                                                    rowHardware(5) &= newrow & "-"
                                                End If
                                            End Try
                                            Try
                                                rowHardware(5) &= delimiter & ""
                                            Catch
                                                rowHardware(5) &= delimiter & ""
                                            End Try
                                            repeat = 1
                                        Next
                                    Catch
                                    End Try
                                End If
                                ' Write collected information in hardware.txt
                                writeToFile(rowHardware)
                            End If
                            i = i + 1
                            ProgressBar1.Value = i
                        End If
                    Next
                    ProgressBar1.Value = 0
                    MsgBox("Finished collecting", MsgBoxStyle.Information, "Saqwel Remoe Administration Tool")
                    Label1.Text = "Finished collecting"
                    Process.Start(TextBox2.Text)
                Else
                    MsgBox("Need to check at least one computer in the list of computers", MsgBoxStyle.Exclamation, "Saqwel Remoe Administration Tool")
                End If
            Else
                MsgBox("Need to check what information you need to collect", MsgBoxStyle.Exclamation, "Saqwel Remoe Administration Tool")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
            ListView1.Items.Clear()
            While Not sr.EndOfStream
                CheckBox0.Checked = False
                ListView1.Items.Add(UCase(sr.ReadLine))
            End While
            sr.Close()
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked Then
            ComboBox1.Enabled = True
        Else
            ComboBox1.Enabled = False
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox0.CheckedChanged
        If CheckBox0.Checked Then
            For Each computer In ListView1.Items
                computer.checked = True
            Next
        Else
            For Each computer In ListView1.Items
                computer.checked = False
            Next
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        If FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            CheckBox3.Enabled = True
            CheckBox4.Enabled = True
            CheckBox5.Enabled = True
            CheckBox6.Enabled = True
            CheckBox7.Enabled = True
            CheckBox8.Enabled = True
        Else
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
            CheckBox5.Enabled = False
            CheckBox6.Enabled = False
            CheckBox7.Enabled = False
            CheckBox8.Enabled = False
        End If
    End Sub

    Private Sub writeToFile(ByVal array)
        Dim delimiter = setDelimiter()
        Dim newrow = setNewrow()
        Dim newArray(5)()
        ' Divide arrays on smaller arrays
        newArray(0) = array(0).Split(newrow)
        newArray(1) = array(1).Split(newrow)
        newArray(2) = array(2).Split(newrow)
        newArray(3) = array(3).Split(newrow)
        newArray(4) = array(4).Split(newrow)
        newArray(5) = array(5).Split(newrow)
        ' Get the biggest array
        Dim biggest = UBound(newArray(0))
        For Each elem In newArray
            If UBound(elem) > biggest Then
                biggest = UBound(elem)
            End If
        Next
        ' Set one size for all arrays
        'For j = 0 To UBound(newArray)
        'If UBound(newArray(j)) < biggest Then
        'ReDim newArray(j)(biggest + 1)
        'For i = UBound(newArray(j)) + 1 To biggest
        'newArray(j)(i) = delimiter
        'Next
        'End If
        'Next
        ' Write data in file
        For i = 0 To biggest
            My.Computer.FileSystem.WriteAllText(TextBox2.Text & "\hardware.txt", COMP, True)
            For Each device In newArray
                Try
                    My.Computer.FileSystem.WriteAllText(TextBox2.Text & "\hardware.txt", delimiter & device(i), True)
                Catch
                    My.Computer.FileSystem.WriteAllText(TextBox2.Text & "\hardware.txt", delimiter & delimiter, True)
                End Try
            Next
            My.Computer.FileSystem.WriteAllText(TextBox2.Text & "\hardware.txt", vbCrLf, True)
        Next
    End Sub

    Function setDelimiter()
        Dim delimiter = ","
        If RadioButton1.Checked Then
            delimiter = ","
        End If
        If RadioButton2.Checked Then
            delimiter = ";"
        End If
        If RadioButton3.Checked Then
            delimiter = " "
        End If
        If RadioButton4.Checked Then
            delimiter = TextBox1.Text
        End If
        Return delimiter
    End Function

    Function setNewrow()
        Dim newrow = "|"
        If setDelimiter() <> "|" Then
            newrow = "|"
        Else
            newrow = "||"
        End If
        Return newrow
    End Function
End Class
