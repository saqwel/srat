<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vncServerSettingsForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RunControlInterface = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LocalInputPriorityTimeout = New System.Windows.Forms.NumericUpDown()
        Me.UseVncAuthentication = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RfbPort = New System.Windows.Forms.NumericUpDown()
        Me.AcceptRfbConnections = New System.Windows.Forms.CheckBox()
        Me.RemoveWallpaper = New System.Windows.Forms.CheckBox()
        Me.LocalInputPriority = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.HttpPort = New System.Windows.Forms.NumericUpDown()
        Me.GrabTransparentWindows = New System.Windows.Forms.CheckBox()
        Me.EnableFileTransfers = New System.Windows.Forms.CheckBox()
        Me.BlockRemoteInput = New System.Windows.Forms.CheckBox()
        Me.BlockLocalInput = New System.Windows.Forms.CheckBox()
        Me.AcceptHttpConnections = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CompTitle = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.LocalInputPriorityTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RfbPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HttpPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.CompTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.RunControlInterface)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LocalInputPriorityTimeout)
        Me.Panel1.Controls.Add(Me.UseVncAuthentication)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.RfbPort)
        Me.Panel1.Controls.Add(Me.AcceptRfbConnections)
        Me.Panel1.Controls.Add(Me.RemoveWallpaper)
        Me.Panel1.Controls.Add(Me.LocalInputPriority)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.HttpPort)
        Me.Panel1.Controls.Add(Me.GrabTransparentWindows)
        Me.Panel1.Controls.Add(Me.EnableFileTransfers)
        Me.Panel1.Controls.Add(Me.BlockRemoteInput)
        Me.Panel1.Controls.Add(Me.BlockLocalInput)
        Me.Panel1.Controls.Add(Me.AcceptHttpConnections)
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(484, 261)
        Me.Panel1.TabIndex = 24
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(29, 146)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(108, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Set password"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(418, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "sec."
        '
        'RunControlInterface
        '
        Me.RunControlInterface.AutoSize = True
        Me.RunControlInterface.Location = New System.Drawing.Point(263, 196)
        Me.RunControlInterface.Name = "RunControlInterface"
        Me.RunControlInterface.Size = New System.Drawing.Size(96, 17)
        Me.RunControlInterface.TabIndex = 12
        Me.RunControlInterface.Text = "Show tray icon"
        Me.RunControlInterface.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(280, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Interval:"
        '
        'LocalInputPriorityTimeout
        '
        Me.LocalInputPriorityTimeout.Location = New System.Drawing.Point(342, 90)
        Me.LocalInputPriorityTimeout.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
        Me.LocalInputPriorityTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.LocalInputPriorityTimeout.Name = "LocalInputPriorityTimeout"
        Me.LocalInputPriorityTimeout.Size = New System.Drawing.Size(70, 20)
        Me.LocalInputPriorityTimeout.TabIndex = 8
        Me.LocalInputPriorityTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LocalInputPriorityTimeout.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'UseVncAuthentication
        '
        Me.UseVncAuthentication.AutoSize = True
        Me.UseVncAuthentication.Location = New System.Drawing.Point(9, 119)
        Me.UseVncAuthentication.Name = "UseVncAuthentication"
        Me.UseVncAuthentication.Size = New System.Drawing.Size(134, 17)
        Me.UseVncAuthentication.TabIndex = 4
        Me.UseVncAuthentication.Text = "Use VNC authetication"
        Me.UseVncAuthentication.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Port:"
        '
        'RfbPort
        '
        Me.RfbPort.Location = New System.Drawing.Point(67, 41)
        Me.RfbPort.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
        Me.RfbPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RfbPort.Name = "RfbPort"
        Me.RfbPort.Size = New System.Drawing.Size(70, 20)
        Me.RfbPort.TabIndex = 1
        Me.RfbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RfbPort.Value = New Decimal(New Integer() {5900, 0, 0, 0})
        '
        'AcceptRfbConnections
        '
        Me.AcceptRfbConnections.AutoSize = True
        Me.AcceptRfbConnections.Location = New System.Drawing.Point(10, 15)
        Me.AcceptRfbConnections.Name = "AcceptRfbConnections"
        Me.AcceptRfbConnections.Size = New System.Drawing.Size(106, 17)
        Me.AcceptRfbConnections.TabIndex = 0
        Me.AcceptRfbConnections.Text = "Allow conections"
        Me.AcceptRfbConnections.UseVisualStyleBackColor = True
        '
        'RemoveWallpaper
        '
        Me.RemoveWallpaper.AutoSize = True
        Me.RemoveWallpaper.Location = New System.Drawing.Point(263, 169)
        Me.RemoveWallpaper.Name = "RemoveWallpaper"
        Me.RemoveWallpaper.Size = New System.Drawing.Size(134, 17)
        Me.RemoveWallpaper.TabIndex = 11
        Me.RemoveWallpaper.Text = "Do not show wallpaper"
        Me.RemoveWallpaper.UseVisualStyleBackColor = True
        '
        'LocalInputPriority
        '
        Me.LocalInputPriority.AutoSize = True
        Me.LocalInputPriority.Location = New System.Drawing.Point(263, 42)
        Me.LocalInputPriority.Name = "LocalInputPriority"
        Me.LocalInputPriority.Size = New System.Drawing.Size(202, 17)
        Me.LocalInputPriority.TabIndex = 7
        Me.LocalInputPriority.Text = "Block remote input while local activity"
        Me.LocalInputPriority.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Port HTTP:"
        '
        'HttpPort
        '
        Me.HttpPort.Location = New System.Drawing.Point(99, 90)
        Me.HttpPort.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
        Me.HttpPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.HttpPort.Name = "HttpPort"
        Me.HttpPort.Size = New System.Drawing.Size(70, 20)
        Me.HttpPort.TabIndex = 3
        Me.HttpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HttpPort.Value = New Decimal(New Integer() {5800, 0, 0, 0})
        '
        'GrabTransparentWindows
        '
        Me.GrabTransparentWindows.AutoSize = True
        Me.GrabTransparentWindows.Location = New System.Drawing.Point(263, 223)
        Me.GrabTransparentWindows.Name = "GrabTransparentWindows"
        Me.GrabTransparentWindows.Size = New System.Drawing.Size(153, 17)
        Me.GrabTransparentWindows.TabIndex = 13
        Me.GrabTransparentWindows.Text = "Show transparent windows"
        Me.GrabTransparentWindows.UseVisualStyleBackColor = True
        '
        'EnableFileTransfers
        '
        Me.EnableFileTransfers.AutoSize = True
        Me.EnableFileTransfers.Location = New System.Drawing.Point(263, 142)
        Me.EnableFileTransfers.Name = "EnableFileTransfers"
        Me.EnableFileTransfers.Size = New System.Drawing.Size(102, 17)
        Me.EnableFileTransfers.TabIndex = 10
        Me.EnableFileTransfers.Text = "Allow ile transfer"
        Me.EnableFileTransfers.UseVisualStyleBackColor = True
        '
        'BlockRemoteInput
        '
        Me.BlockRemoteInput.AutoSize = True
        Me.BlockRemoteInput.Location = New System.Drawing.Point(263, 15)
        Me.BlockRemoteInput.Name = "BlockRemoteInput"
        Me.BlockRemoteInput.Size = New System.Drawing.Size(149, 17)
        Me.BlockRemoteInput.TabIndex = 6
        Me.BlockRemoteInput.Text = "Block remote connections"
        Me.BlockRemoteInput.UseVisualStyleBackColor = True
        '
        'BlockLocalInput
        '
        Me.BlockLocalInput.AutoSize = True
        Me.BlockLocalInput.Location = New System.Drawing.Point(264, 115)
        Me.BlockLocalInput.Name = "BlockLocalInput"
        Me.BlockLocalInput.Size = New System.Drawing.Size(104, 17)
        Me.BlockLocalInput.TabIndex = 9
        Me.BlockLocalInput.Text = "Block local input"
        Me.BlockLocalInput.UseVisualStyleBackColor = True
        '
        'AcceptHttpConnections
        '
        Me.AcceptHttpConnections.AutoSize = True
        Me.AcceptHttpConnections.Location = New System.Drawing.Point(10, 67)
        Me.AcceptHttpConnections.Name = "AcceptHttpConnections"
        Me.AcceptHttpConnections.Size = New System.Drawing.Size(144, 17)
        Me.AcceptHttpConnections.TabIndex = 2
        Me.AcceptHttpConnections.Text = "Allow HTTP connections"
        Me.AcceptHttpConnections.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 326)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(484, 65)
        Me.Panel2.TabIndex = 25
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(309, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(399, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CompTitle
        '
        Me.CompTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CompTitle.Controls.Add(Me.Label1)
        Me.CompTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.CompTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CompTitle.Location = New System.Drawing.Point(0, 0)
        Me.CompTitle.Name = "CompTitle"
        Me.CompTitle.Size = New System.Drawing.Size(484, 65)
        Me.CompTitle.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TightVNC server settings editor"
        '
        'vncServerSettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 391)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CompTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "vncServerSettingsForm"
        Me.ShowIcon = False
        Me.Text = "TightVNC server settings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.LocalInputPriorityTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RfbPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HttpPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.CompTitle.ResumeLayout(False)
        Me.CompTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CompTitle As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AcceptHttpConnections As System.Windows.Forms.CheckBox
    Friend WithEvents BlockLocalInput As System.Windows.Forms.CheckBox
    Friend WithEvents BlockRemoteInput As System.Windows.Forms.CheckBox
    Friend WithEvents EnableFileTransfers As System.Windows.Forms.CheckBox
    Friend WithEvents GrabTransparentWindows As System.Windows.Forms.CheckBox
    Friend WithEvents HttpPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LocalInputPriority As System.Windows.Forms.CheckBox
    Friend WithEvents RemoveWallpaper As System.Windows.Forms.CheckBox
    Friend WithEvents AcceptRfbConnections As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RfbPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents UseVncAuthentication As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LocalInputPriorityTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents RunControlInterface As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
