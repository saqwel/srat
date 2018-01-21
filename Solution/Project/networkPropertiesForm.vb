Public Class networkPropertiesForm

    Private Sub networkPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim Comp = UCase(Form1.ComboBox2.Text)
            Dim networkName, networkMAC

            networkName = Form1.ListView1.SelectedItems.Item(0).SubItems(0).Text
            networkMAC = Form1.ListView1.SelectedItems.Item(0).SubItems(2).Text


            Dim row(2) As String
            Dim rows(10) As ListViewItem

            TextBox1.Text = networkName
            TextBox2.Text = Comp
            Dim objDatetime = CreateObject("WbemScripting.SWbemDateTime")
            Dim objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & Comp & "\root\cimv2")
            Dim col = objWMIService.ExecQuery("Select * from Win32_NetworkAdapterConfiguration WHERE MACAddress='" & networkMAC & "'")
            For Each obj In col
                Try
                    ReDim rows(11 + UBound(obj.DNSServerSearchOrder) - 1)
                Catch
                End Try
            Next
            For Each obj In col
                Try
                    rows(0) = New ListViewItem(New String() {"Описание", obj.Description})
                Catch
                    rows(0) = New ListViewItem(New String() {"Описание", ""})
                End Try
                Try
                    rows(1) = New ListViewItem(New String() {"Фзичекий адрес", obj.MACAddress})
                Catch
                    rows(1) = New ListViewItem(New String() {"Фзичекий адрес", ""})
                End Try
                If obj.DHCPEnabled Then
                    rows(2) = New ListViewItem(New String() {"DHCP включен", "Да"})
                Else
                    rows(2) = New ListViewItem(New String() {"DHCP включен", "Нет"})
                End If
                Try
                    rows(3) = New ListViewItem(New String() {"Адрес", obj.IPAddress(0)})
                Catch
                    rows(3) = New ListViewItem(New String() {"Адрес", ""})
                End Try
                Try
                    rows(4) = New ListViewItem(New String() {"Маска подсети", obj.IPSubnet(0)})
                Catch
                    rows(4) = New ListViewItem(New String() {"Маска подсети", "xep"})
                End Try
                Try
                    rows(5) = New ListViewItem(New String() {"Основной шлюз", obj.DefaultIPGateway(0)})
                Catch
                    rows(5) = New ListViewItem(New String() {"Основной шлюз", ""})
                End Try
                Try
                    rows(6) = New ListViewItem(New String() {"Аренда получена", Form1.datetimeFormat(obj.DHCPLeaseObtained, objDatetime)})
                Catch
                    rows(6) = New ListViewItem(New String() {"Аренда получена", ""})
                End Try
                Try
                    rows(7) = New ListViewItem(New String() {"Ареда истекает", Form1.datetimeFormat(obj.DHCPLeaseExpires, objDatetime)})
                Catch
                    rows(7) = New ListViewItem(New String() {"Ареда истекает", ""})
                End Try
                Try
                    rows(8) = New ListViewItem(New String() {"DHCP-сервер", obj.DHCPServer})
                Catch
                    rows(8) = New ListViewItem(New String() {"DHCP-сервер", ""})
                End Try
                Try
                    rows(9) = New ListViewItem(New String() {"WINS-сервер", obj.WINSPrimaryServer})
                Catch
                    rows(9) = New ListViewItem(New String() {"WINS-сервер", ""})
                End Try
                Try
                    rows(10) = New ListViewItem(New String() {"DNS-серверы", obj.DNSServerSearchOrder(0)})
                Catch
                    rows(10) = New ListViewItem(New String() {"DNS-серверы", ""})
                End Try
                Try
                    For i = 1 To UBound(obj.DNSServerSearchOrder)
                        rows(10 + i) = New ListViewItem(New String() {"", obj.DNSServerSearchOrder(i)})
                    Next
                Catch ex As Exception
                End Try

            Next
            ListView1.Items.AddRange(rows)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Ошибка")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
