Imports System.Security.Principal
Imports System.Management

'2032127
'1245631
'1179817

Public Class shareCreateForm
    Private AceArray As New Microsoft.VisualBasic.Collection()
    Public Comp

    Private Sub shareCreateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            TextBox1.Text = Form1.COMP
            Comp = TextBox1.Text

            Dim everyone = New objACE
            everyone.domainName = ""
            everyone.userName = "Everyone"
            everyone.AccessMask = 1179817
            everyone.Type = 0
            AceArray.Add(everyone)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim resultText = Nothing
            Const FILE_SHARE = 0
            Dim MAXIMUM_CONNECTIONS As Integer = NumericUpDown1.Value
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            Dim obj = objWMIService.Get("Win32_Share")
            Dim result = obj.Create(TextBox2.Text, TextBox3.Text, FILE_SHARE, MAXIMUM_CONNECTIONS, TextBox4.Text)
            If result = 0 Then
                'Form1.ListView1.Items.Add(New ListViewItem(New String() {TextBox3.Text, "Папка", TextBox4.Text, TextBox2.Text}))
                Form1.getSharesFunc()
                Close()
            Else
                Select Case result
                    Case 2
                        resultText = "No access"
                    Case 8
                        resultText = "Unknown error"
                    Case 9
                        resultText = "Wrong name"
                    Case 10
                        resultText = "Wrong security level"
                    Case 21
                        resultText = "Wrong parameter"
                    Case 22
                        resultText = "Such resource already exists"
                    Case 23
                        resultText = "Redirected path"
                    Case 24
                        resultText = "Unknown directory or device"
                    Case 25
                        resultText = "Network name not found"
                End Select
                MsgBox(resultText, MsgBoxStyle.OkOnly, "Saqwel Remote Administration Tool")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            FolderBrowserDialog1.ShowDialog()
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
    End Sub

    Function createACE(ByVal userName As String, ByVal domainName As String, ByVal AccessMask As Integer, ByVal Type As Integer)
        Try
            Dim Comp = TextBox1.Text
            Dim AccountSID = Nothing
            ' Create scope to detect what computer connect to
            Dim scope As ManagementScope
            scope = New ManagementScope("\\" & Comp & "\root\cimv2")
            scope.Connect()
            If userName = "Everyone" Then
                AccountSID = "S-1-1-0"
            Else
                ' Создать query - запрос, который надо выполнить
                Dim query As ObjectQuery
                query = New ObjectQuery("SELECT SID FROM Win32_UserAccount WHERE Domain='" & domainName & "' AND Name='" & userName & "'")
                ' Create sercher, which execute request
                'Dim searcher As ManagementObjectSearcher
                Dim accSearch = New Management.ManagementObjectSearcher(scope, query)
                Dim accCol = accSearch.Get
                ' If this group:
                If accCol.Count = 0 Then
                    query = New ObjectQuery("SELECT SID FROM Win32_Group WHERE Domain='" & domainName & "' AND Name='" & userName & "'")
                    ' Create sercher, which execute request
                    accSearch = New Management.ManagementObjectSearcher(scope, query)
                    accCol = accSearch.Get
                End If
                ' Iterate results, thought it has to be single
                For Each obj In accCol
                    AccountSID = obj.Item("SID")
                Next
            End If
            ' Get SID object for getting BinaryRepresentetion of SID string
            Dim pathToSID As ManagementPath = New ManagementPath("\\" & Comp & "\root\cimv2:Win32_SID.SID='" & AccountSID & "'")
            Dim SID = New ManagementObject(pathToSID)
            ' Create Trustee for assigning it to Trustee property of Win32_ACE object
            Dim Trustee = New ManagementClass("Win32_Trustee").CreateInstance()
            Trustee.Item("Domain") = SID.Item("ReferencedDomainName")
            Trustee.Item("Name") = SID.Item("AccountName")
            Trustee.Item("SID") = SID.Item("BinaryRepresentation")
            ' Create Ace for assigning it to DACL() property of Win32_SecurityDescritor object
            Dim ACE = New ManagementClass("Win32_ACE").CreateInstance()
            ACE.Item("AccessMask") = AccessMask
            ACE.Item("AceType") = Type
            ACE.Item("Trustee") = Trustee
            Return ACE
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
        Return Nothing
    End Function

    Function createDACLArray()
        Try
            Dim amount = AceArray.Count
            Dim DACL(amount - 1) As Object
            For i = 1 To amount
                DACL(i - 1) = createACE(AceArray.Item(i).userName, AceArray.Item(i).domainName, AceArray.Item(i).AccessMask, AceArray.Item(i).Type)
            Next
            Return DACL
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
        Return Nothing
    End Function

    Function createShare()
        Try
            ' Create Security Descriptor for using it like a parameter for Create method of Win32_Share class
            Dim SD = New ManagementClass("Win32_SecurityDescriptor").CreateInstance()
            SD.Item("DACL") = createDACLArray() 'New Object() {ACE}

            MsgBox(UBound(SD.Item("DACL")))
            Dim p As ManagementPath = New ManagementPath("\\" & Comp & "\root\cimv2:Win32_Share")
            Dim share As ManagementClass = New ManagementClass(p)

            Dim inparams As ManagementBaseObject = share.GetMethodParameters("Create")
            inparams.Item("Access") = SD
            inparams.Item("Description") = TextBox4.Text
            inparams.Item("Name") = TextBox3.Text
            inparams.Item("Path") = TextBox2.Text
            inparams.Item("Type") = 0
            '
            Dim options As InvokeMethodOptions = New InvokeMethodOptions
            options.Timeout = New TimeSpan(0, 0, 0, 5)
            '
            Dim result As ManagementBaseObject = share.InvokeMethod("Create", inparams, options)
            If result.Item("returnValue") <> 0 Then
                MsgBox("Create share failed with returnValue=" & result.Item("returnValue"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Saqwel Remote Administration Tool")
        End Try
        Return Nothing
    End Function

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        createShare()
    End Sub
End Class









Public Class objACE
    Private userNameValue As String
    Private domainNameValue As String
    Private AccessMaskValue As Integer
    Private TypeValue As Integer
    Public Property userName() As String
        Get
            Return userNameValue
        End Get
        Set(ByVal value As String)
            userNameValue = value
        End Set
    End Property

    Public Property domainName() As String
        Get
            Return domainNameValue
        End Get
        Set(ByVal value As String)
            domainNameValue = value
        End Set
    End Property

    Public Property AccessMask() As Integer
        Get
            Return AccessMaskValue
        End Get
        Set(ByVal value As Integer)
            AccessMaskValue = value
        End Set
    End Property

    Public Property Type() As Integer
        Get
            Return TypeValue
        End Get
        Set(ByVal value As Integer)
            TypeValue = value
        End Set
    End Property
End Class