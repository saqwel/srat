Public Class vncPasswordForm
    Private PATH, REG_SECTION
    Private Computer
    Public Sub New(ByVal ComputerName As String)

        ' This call is required by the designer.

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Computer = ComputerName

    End Sub
    Private Sub vncPasswordForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TextBox1.Text = Form1.COMP
            'REG_SECTION = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Saqwel\RAT")
            'PATH = REG_SECTION.GetValue("Path")
            PATH = My.Application.Info.DirectoryPath
            TextBox2.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        passToHex()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            passToHex()
        End If
    End Sub
    Private Sub passToHex()
        Try
            Dim PATH = My.Application.Info.DirectoryPath
            If TextBox2.Text = TextBox3.Text Then

                Dim tightVncExe = PATH & "\TightVNC\vncpwd.exe"
                Dim Result = StartProcess(tightVncExe, TextBox2.Text)

                SetPasswordToRegistry(Result)

                If Computer <> "." Then
                    Dim OS_bit = 32
                    Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Computer & "\root\cimv2")
                    Dim colProcessor = objWMIService.ExecQuery("Select * from Win32_Processor")
                    For Each objProcessor In colProcessor
                        OS_bit = objProcessor.AddressWidth
                    Next

                    Dim regPath
                    If OS_bit = 32 Then
                        regPath = "SOFTWARE\TightVNC"
                    Else
                        regPath = "SOFTWARE\Wow6432Node\TightVNC"
                    End If

                    Dim objReg = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Computer & "\root\default:StdRegProv")
                    Dim HKLM = &H80000002
                    Dim objWMIServiceLocal = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2")
                    Dim objRegLocal = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\default:StdRegProv")
                    Dim binValue
                    objRegLocal.GetBinaryValue(HKLM, "SOFTWARE\Saqwel\RAT\TightVNC\Server", "Password", binValue)
                    objReg.SetBinaryValue(HKLM, regPath & "\Server", "Password", binValue)

                End If

                MsgBox("Пароль сохранен", MsgBoxStyle.Information, "Информация")

                Close()
            Else
                MsgBox("Пароли не совпадают", MsgBoxStyle.OkOnly, "Ошибка")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub
    Private Function StartProcess(ExePath As String, Arg As String)
        Dim sOutput As String
        sOutput = ""
        Try
            Dim oProcess As New Process()
            Dim oStartInfo As New ProcessStartInfo(ExePath, Arg)
            oStartInfo.UseShellExecute = False
            oStartInfo.RedirectStandardOutput = True
            oProcess.StartInfo = oStartInfo
            oProcess.Start()

            Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
                sOutput = oStreamReader.ReadToEnd()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
        Return sOutput
    End Function
    Private Sub SetPasswordToRegistry(Password As String)
        Try

            ' Сохранить пароль VNC в реестре
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2")
            Dim objReg = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\default:StdRegProv")
            Dim HKLM = &H80000002
            Dim SaqwelRegistry = "SOFTWARE\Saqwel\RAT\TightVNC\Server"

            objReg.SetBinaryValue(HKLM, SaqwelRegistry, "Password", vncPasswordHexToDec(Password))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try

    End Sub
    Function vncPasswordHexToDec(Password As String)

        Dim arr1, arr2 As New Dictionary(Of String, Integer)
        'Dim arr1(16), arr2(16) As Integer
        Dim str1 = Nothing
        Dim str2 = Nothing
        Dim Dec(7) As Integer

        arr1.Add("0", 0)
        arr1.Add("1", 16)
        arr1.Add("2", 32)
        arr1.Add("3", 48)
        arr1.Add("4", 64)
        arr1.Add("5", 80)
        arr1.Add("6", 96)
        arr1.Add("7", 112)
        arr1.Add("8", 128)
        arr1.Add("9", 144)
        arr1.Add("A", 160)
        arr1.Add("B", 176)
        arr1.Add("C", 192)
        arr1.Add("D", 208)
        arr1.Add("E", 224)
        arr1.Add("F", 240)

        arr2.Add("0", 0)
        arr2.Add("1", 1)
        arr2.Add("2", 2)
        arr2.Add("3", 3)
        arr2.Add("4", 4)
        arr2.Add("5", 5)
        arr2.Add("6", 6)
        arr2.Add("7", 7)
        arr2.Add("8", 8)
        arr2.Add("9", 9)
        arr2.Add("A", 10)
        arr2.Add("B", 11)
        arr2.Add("C", 12)
        arr2.Add("D", 13)
        arr2.Add("E", 14)
        arr2.Add("F", 15)

        'Dim Hex = My.Computer.FileSystem.ReadAllText(PATH & "\TightVNC\vncpwd")

        Dim Hex = UCase(Trim(Password))
        'ReDim Dec(Math.Floor(Hex.Length / 2) - 1)

        For i = 1 To 16 'Hex.Length
            If i / 2 - Math.Floor(i / 2) <> 0 Then
                str1 = Mid(Hex, i, 1)
            Else
                str2 = Mid(Hex, i, 1)
                Dec(Math.Floor(i / 2) - 1) = arr1(str1) + arr2(str2)
            End If
        Next
        Return Dec
    End Function

End Class