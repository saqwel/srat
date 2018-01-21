<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ContextProcess = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ProcessKill = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextService = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ServStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServRestart = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ServStartMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServStartAuto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServStartManual = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServStartDisable = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ServProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextShare = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.shareCreate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.shareOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.shareRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.shareProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.shareRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextComputer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.computerGeneralInformation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.computerVnc = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerReboot = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerShutdown = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.computerPartitions = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerShares = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.computerUsers = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.computerProcesses = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerServices = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerSoftware = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.ComputerDevices = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerMotherboard = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerProcessor = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerMemory = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerStorage = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerNetwork = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerVideo = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerSound = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.computerTerminal = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.buttonMotherboard = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.buttonPane = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.buttonGeneralInformation = New System.Windows.Forms.Button()
        Me.buttonSound = New System.Windows.Forms.Button()
        Me.buttonVideo = New System.Windows.Forms.Button()
        Me.buttonNetwork = New System.Windows.Forms.Button()
        Me.buttonTerminal = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.buttonStorage = New System.Windows.Forms.Button()
        Me.buttonMemory = New System.Windows.Forms.Button()
        Me.buttonProcessor = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.buttonSoftware = New System.Windows.Forms.Button()
        Me.buttonServices = New System.Windows.Forms.Button()
        Me.buttonProcesses = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.buttonGroups = New System.Windows.Forms.Button()
        Me.buttonUsers = New System.Windows.Forms.Button()
        Me.buttonShares = New System.Windows.Forms.Button()
        Me.buttonPartitions = New System.Windows.Forms.Button()
        Me.buttonVnc = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mainMenuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuTightVNC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuVncInstall = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuVncUninstall = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.mainMenuVncServerSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerGeneralInformation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.mainMenuComputerVNC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerReboot = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerShutdown = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.mainMenuComputerPartitions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerShares = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.mainMenuComputerUsers = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.mainMenuComputerProcesses = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerServices = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerSoftware = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.mainMenuComputerDevices = New System.Windows.Forms.ToolStripMenuItem()
        Me.computerMotherboard = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerProcessor = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerMemory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerStorage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerNetwork = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerVideo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuComputerSound = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.mainMenuComputerTerminal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuService = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuServiceInventarization = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuExportComputers = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuHelpReference = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.mainMenuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextUsers = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.userCreate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.userPassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.userRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.userRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.userProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.userRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextGroups = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.groupCreate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.groupAddMember = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.groupRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.groupRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.groupProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.groupRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextPartitions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.partitionProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.partitionRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextGeneral = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.generalDescription = New System.Windows.Forms.ToolStripMenuItem()
        Me.generalRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextTerminalSessions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.terminalLogOff = New System.Windows.Forms.ToolStripMenuItem()
        Me.terminalRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.EventLog1 = New System.Diagnostics.EventLog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ContextProcess.SuspendLayout()
        Me.ContextService.SuspendLayout()
        Me.ContextShare.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextComputer.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextUsers.SuspendLayout()
        Me.ContextGroups.SuspendLayout()
        Me.ContextPartitions.SuspendLayout()
        Me.ContextGeneral.SuspendLayout()
        Me.ContextTerminalSessions.SuspendLayout()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextProcess
        '
        Me.ContextProcess.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcessKill, Me.ProcessRefresh})
        Me.ContextProcess.Name = "ContextMenuStrip1"
        Me.ContextProcess.Size = New System.Drawing.Size(114, 48)
        '
        'ProcessKill
        '
        Me.ProcessKill.Name = "ProcessKill"
        Me.ProcessKill.Size = New System.Drawing.Size(113, 22)
        Me.ProcessKill.Text = "Kill"
        '
        'ProcessRefresh
        '
        Me.ProcessRefresh.Name = "ProcessRefresh"
        Me.ProcessRefresh.Size = New System.Drawing.Size(113, 22)
        Me.ProcessRefresh.Text = "Refresh"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(16, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Computer name"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "0.png")
        Me.ImageList1.Images.SetKeyName(1, "1.png")
        Me.ImageList1.Images.SetKeyName(2, "error.png")
        Me.ImageList1.Images.SetKeyName(3, "warning.png")
        Me.ImageList1.Images.SetKeyName(4, "info.png")
        Me.ImageList1.Images.SetKeyName(5, "key.png")
        '
        'ContextService
        '
        Me.ContextService.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServStart, Me.ServStop, Me.ServRestart, Me.ToolStripSeparator2, Me.ServStartMode, Me.ToolStripSeparator1, Me.ServProperties, Me.ServRefresh})
        Me.ContextService.Name = "ContextMenuStrip2"
        Me.ContextService.Size = New System.Drawing.Size(133, 148)
        '
        'ServStart
        '
        Me.ServStart.Name = "ServStart"
        Me.ServStart.Size = New System.Drawing.Size(132, 22)
        Me.ServStart.Text = "Start"
        '
        'ServStop
        '
        Me.ServStop.Name = "ServStop"
        Me.ServStop.Size = New System.Drawing.Size(132, 22)
        Me.ServStop.Text = "Stop"
        '
        'ServRestart
        '
        Me.ServRestart.Name = "ServRestart"
        Me.ServRestart.Size = New System.Drawing.Size(132, 22)
        Me.ServRestart.Text = "Restart"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(129, 6)
        '
        'ServStartMode
        '
        Me.ServStartMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServStartAuto, Me.ServStartManual, Me.ServStartDisable})
        Me.ServStartMode.Name = "ServStartMode"
        Me.ServStartMode.Size = New System.Drawing.Size(132, 22)
        Me.ServStartMode.Text = "Start mode"
        '
        'ServStartAuto
        '
        Me.ServStartAuto.Name = "ServStartAuto"
        Me.ServStartAuto.Size = New System.Drawing.Size(130, 22)
        Me.ServStartAuto.Text = "Automatic"
        '
        'ServStartManual
        '
        Me.ServStartManual.Name = "ServStartManual"
        Me.ServStartManual.Size = New System.Drawing.Size(130, 22)
        Me.ServStartManual.Text = "Manual"
        '
        'ServStartDisable
        '
        Me.ServStartDisable.Name = "ServStartDisable"
        Me.ServStartDisable.Size = New System.Drawing.Size(130, 22)
        Me.ServStartDisable.Text = "Disable"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(129, 6)
        '
        'ServProperties
        '
        Me.ServProperties.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ServProperties.Name = "ServProperties"
        Me.ServProperties.Size = New System.Drawing.Size(132, 22)
        Me.ServProperties.Text = "Properties"
        '
        'ServRefresh
        '
        Me.ServRefresh.Name = "ServRefresh"
        Me.ServRefresh.Size = New System.Drawing.Size(132, 22)
        Me.ServRefresh.Text = "Refresh"
        '
        'ContextShare
        '
        Me.ContextShare.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ContextShare.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.shareCreate, Me.ToolStripSeparator9, Me.shareOpen, Me.ToolStripSeparator10, Me.shareRemove, Me.ToolStripSeparator11, Me.shareProperties, Me.shareRefresh})
        Me.ContextShare.Name = "ContextMenuStrip3"
        Me.ContextShare.Size = New System.Drawing.Size(141, 132)
        '
        'shareCreate
        '
        Me.shareCreate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.shareCreate.Name = "shareCreate"
        Me.shareCreate.Size = New System.Drawing.Size(140, 22)
        Me.shareCreate.Text = "New share"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(137, 6)
        '
        'shareOpen
        '
        Me.shareOpen.Name = "shareOpen"
        Me.shareOpen.Size = New System.Drawing.Size(140, 22)
        Me.shareOpen.Text = "Open"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(137, 6)
        '
        'shareRemove
        '
        Me.shareRemove.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.shareRemove.Name = "shareRemove"
        Me.shareRemove.Size = New System.Drawing.Size(140, 22)
        Me.shareRemove.Text = "Stop sharing"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(137, 6)
        '
        'shareProperties
        '
        Me.shareProperties.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.shareProperties.Name = "shareProperties"
        Me.shareProperties.Size = New System.Drawing.Size(140, 22)
        Me.shareProperties.Text = "Properties"
        '
        'shareRefresh
        '
        Me.shareRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.shareRefresh.Name = "shareRefresh"
        Me.shareRefresh.Size = New System.Drawing.Size(140, 22)
        Me.shareRefresh.Text = "Refresh"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListView2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListView1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Size = New System.Drawing.Size(784, 366)
        Me.SplitContainer1.SplitterDistance = 399
        Me.SplitContainer1.TabIndex = 1
        '
        'ListView2
        '
        Me.ListView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.FullRowSelect = True
        Me.ListView2.Location = New System.Drawing.Point(0, 0)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(399, 366)
        Me.ListView2.SmallImageList = Me.ImageList2
        Me.ListView2.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView2.TabIndex = 3
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "users.png")
        Me.ImageList2.Images.SetKeyName(1, "groups.png")
        Me.ImageList2.Images.SetKeyName(2, "services.png")
        Me.ImageList2.Images.SetKeyName(3, "partitions.png")
        Me.ImageList2.Images.SetKeyName(4, "eventlog.png")
        Me.ImageList2.Images.SetKeyName(5, "processor.png")
        Me.ImageList2.Images.SetKeyName(6, "memory.png")
        Me.ImageList2.Images.SetKeyName(7, "network.png")
        Me.ImageList2.Images.SetKeyName(8, "video.png")
        Me.ImageList2.Images.SetKeyName(9, "storages.png")
        Me.ImageList2.Images.SetKeyName(10, "sound.png")
        Me.ImageList2.Images.SetKeyName(11, "terminal.png")
        Me.ImageList2.Images.SetKeyName(12, "processes.png")
        Me.ImageList2.Images.SetKeyName(13, "vnc.png")
        Me.ImageList2.Images.SetKeyName(14, "pane_horizontal.png")
        Me.ImageList2.Images.SetKeyName(15, "pane_vertical.png")
        Me.ImageList2.Images.SetKeyName(16, "users_disable.png")
        Me.ImageList2.Images.SetKeyName(17, "computer.png")
        Me.ImageList2.Images.SetKeyName(18, "shares.png")
        Me.ImageList2.Images.SetKeyName(19, "software.png")
        Me.ImageList2.Images.SetKeyName(20, "0.png")
        Me.ImageList2.Images.SetKeyName(21, "1.png")
        Me.ImageList2.Images.SetKeyName(22, "motherboard.png")
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(381, 366)
        Me.ListView1.SmallImageList = Me.ImageList2
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.DimGray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(-1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(971, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Выберите компьютер для управления"
        '
        'ContextComputer
        '
        Me.ContextComputer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.computerGeneralInformation, Me.ToolStripSeparator18, Me.computerVnc, Me.computerReboot, Me.computerShutdown, Me.ToolStripSeparator19, Me.computerPartitions, Me.computerShares, Me.ToolStripSeparator20, Me.computerUsers, Me.computerGroups, Me.ToolStripSeparator21, Me.computerProcesses, Me.computerServices, Me.computerSoftware, Me.ToolStripSeparator22, Me.ComputerDevices, Me.ToolStripSeparator23, Me.computerTerminal})
        Me.ContextComputer.Name = "ContextComputer"
        Me.ContextComputer.Size = New System.Drawing.Size(188, 326)
        '
        'computerGeneralInformation
        '
        Me.computerGeneralInformation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.computerGeneralInformation.Name = "computerGeneralInformation"
        Me.computerGeneralInformation.Size = New System.Drawing.Size(187, 22)
        Me.computerGeneralInformation.Text = "General information"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(184, 6)
        '
        'computerVnc
        '
        Me.computerVnc.Name = "computerVnc"
        Me.computerVnc.Size = New System.Drawing.Size(187, 22)
        Me.computerVnc.Text = "Connect"
        '
        'computerReboot
        '
        Me.computerReboot.Name = "computerReboot"
        Me.computerReboot.Size = New System.Drawing.Size(187, 22)
        Me.computerReboot.Text = "Reboot"
        '
        'computerShutdown
        '
        Me.computerShutdown.Name = "computerShutdown"
        Me.computerShutdown.Size = New System.Drawing.Size(187, 22)
        Me.computerShutdown.Text = "Shutdown"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(184, 6)
        '
        'computerPartitions
        '
        Me.computerPartitions.Name = "computerPartitions"
        Me.computerPartitions.Size = New System.Drawing.Size(187, 22)
        Me.computerPartitions.Text = "Partitions"
        '
        'computerShares
        '
        Me.computerShares.Name = "computerShares"
        Me.computerShares.Size = New System.Drawing.Size(187, 22)
        Me.computerShares.Text = "Shares"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(184, 6)
        '
        'computerUsers
        '
        Me.computerUsers.Name = "computerUsers"
        Me.computerUsers.Size = New System.Drawing.Size(187, 22)
        Me.computerUsers.Text = "Users"
        '
        'computerGroups
        '
        Me.computerGroups.Name = "computerGroups"
        Me.computerGroups.Size = New System.Drawing.Size(187, 22)
        Me.computerGroups.Text = "Groups"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(184, 6)
        '
        'computerProcesses
        '
        Me.computerProcesses.Name = "computerProcesses"
        Me.computerProcesses.Size = New System.Drawing.Size(187, 22)
        Me.computerProcesses.Text = "Processes"
        '
        'computerServices
        '
        Me.computerServices.Name = "computerServices"
        Me.computerServices.Size = New System.Drawing.Size(187, 22)
        Me.computerServices.Text = "Services"
        '
        'computerSoftware
        '
        Me.computerSoftware.Name = "computerSoftware"
        Me.computerSoftware.Size = New System.Drawing.Size(187, 22)
        Me.computerSoftware.Text = "Software"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(184, 6)
        '
        'ComputerDevices
        '
        Me.ComputerDevices.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mainMenuComputerMotherboard, Me.computerProcessor, Me.computerMemory, Me.computerStorage, Me.computerNetwork, Me.computerVideo, Me.computerSound})
        Me.ComputerDevices.Name = "ComputerDevices"
        Me.ComputerDevices.Size = New System.Drawing.Size(187, 22)
        Me.ComputerDevices.Text = "Devices"
        '
        'mainMenuComputerMotherboard
        '
        Me.mainMenuComputerMotherboard.Name = "mainMenuComputerMotherboard"
        Me.mainMenuComputerMotherboard.Size = New System.Drawing.Size(132, 22)
        Me.mainMenuComputerMotherboard.Text = "Base board"
        '
        'computerProcessor
        '
        Me.computerProcessor.Name = "computerProcessor"
        Me.computerProcessor.Size = New System.Drawing.Size(132, 22)
        Me.computerProcessor.Text = "Processor"
        '
        'computerMemory
        '
        Me.computerMemory.Name = "computerMemory"
        Me.computerMemory.Size = New System.Drawing.Size(132, 22)
        Me.computerMemory.Text = "Memory"
        '
        'computerStorage
        '
        Me.computerStorage.Name = "computerStorage"
        Me.computerStorage.Size = New System.Drawing.Size(132, 22)
        Me.computerStorage.Text = "Storage"
        '
        'computerNetwork
        '
        Me.computerNetwork.Name = "computerNetwork"
        Me.computerNetwork.Size = New System.Drawing.Size(132, 22)
        Me.computerNetwork.Text = "Network"
        '
        'computerVideo
        '
        Me.computerVideo.Name = "computerVideo"
        Me.computerVideo.Size = New System.Drawing.Size(132, 22)
        Me.computerVideo.Text = "Video"
        '
        'computerSound
        '
        Me.computerSound.Name = "computerSound"
        Me.computerSound.Size = New System.Drawing.Size(132, 22)
        Me.computerSound.Text = "Sound"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(184, 6)
        '
        'computerTerminal
        '
        Me.computerTerminal.Name = "computerTerminal"
        Me.computerTerminal.Size = New System.Drawing.Size(187, 22)
        Me.computerTerminal.Text = "Terminal sessions"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label10.Location = New System.Drawing.Point(337, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Operating systems"
        Me.Label10.Visible = False
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(332, 83)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(220, 23)
        Me.ComboBox3.Sorted = True
        Me.ComboBox3.TabIndex = 29
        Me.ComboBox3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(177, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Domain or workgroup"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(173, 83)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(153, 23)
        Me.ComboBox1.TabIndex = 28
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonMotherboard)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TextBox1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonPane)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ComboBox3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonGeneralInformation)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonSound)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ComboBox1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonVideo)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonNetwork)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonTerminal)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonStorage)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonMemory)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonProcessor)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonSoftware)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonServices)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonProcesses)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonGroups)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonUsers)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonShares)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonPartitions)
        Me.SplitContainer2.Panel1.Controls.Add(Me.buttonVnc)
        Me.SplitContainer2.Panel1.Controls.Add(Me.MenuStrip1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(784, 482)
        Me.SplitContainer2.SplitterDistance = 115
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 2
        '
        'buttonMotherboard
        '
        Me.buttonMotherboard.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonMotherboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonMotherboard.FlatAppearance.BorderSize = 0
        Me.buttonMotherboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonMotherboard.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonMotherboard.ImageKey = "motherboard.png"
        Me.buttonMotherboard.ImageList = Me.ImageList2
        Me.buttonMotherboard.Location = New System.Drawing.Point(307, 31)
        Me.buttonMotherboard.Name = "buttonMotherboard"
        Me.buttonMotherboard.Size = New System.Drawing.Size(24, 24)
        Me.buttonMotherboard.TabIndex = 31
        Me.buttonMotherboard.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 84)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(155, 21)
        Me.TextBox1.TabIndex = 0
        '
        'buttonPane
        '
        Me.buttonPane.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPane.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonPane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonPane.FlatAppearance.BorderSize = 0
        Me.buttonPane.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonPane.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonPane.ImageKey = "pane_horizontal.png"
        Me.buttonPane.ImageList = Me.ImageList2
        Me.buttonPane.Location = New System.Drawing.Point(747, 31)
        Me.buttonPane.Name = "buttonPane"
        Me.buttonPane.Size = New System.Drawing.Size(25, 24)
        Me.buttonPane.TabIndex = 30
        Me.buttonPane.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DarkGray
        Me.Label9.Location = New System.Drawing.Point(36, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 15)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "|"
        '
        'buttonGeneralInformation
        '
        Me.buttonGeneralInformation.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonGeneralInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonGeneralInformation.FlatAppearance.BorderSize = 0
        Me.buttonGeneralInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonGeneralInformation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonGeneralInformation.ImageKey = "computer.png"
        Me.buttonGeneralInformation.ImageList = Me.ImageList2
        Me.buttonGeneralInformation.Location = New System.Drawing.Point(12, 31)
        Me.buttonGeneralInformation.Name = "buttonGeneralInformation"
        Me.buttonGeneralInformation.Size = New System.Drawing.Size(24, 24)
        Me.buttonGeneralInformation.TabIndex = 1
        Me.buttonGeneralInformation.UseVisualStyleBackColor = False
        '
        'buttonSound
        '
        Me.buttonSound.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonSound.FlatAppearance.BorderSize = 0
        Me.buttonSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonSound.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonSound.ImageKey = "sound.png"
        Me.buttonSound.ImageList = Me.ImageList2
        Me.buttonSound.Location = New System.Drawing.Point(486, 31)
        Me.buttonSound.Name = "buttonSound"
        Me.buttonSound.Size = New System.Drawing.Size(24, 24)
        Me.buttonSound.TabIndex = 15
        Me.buttonSound.UseVisualStyleBackColor = False
        '
        'buttonVideo
        '
        Me.buttonVideo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonVideo.FlatAppearance.BorderSize = 0
        Me.buttonVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonVideo.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonVideo.ImageKey = "video.png"
        Me.buttonVideo.ImageList = Me.ImageList2
        Me.buttonVideo.Location = New System.Drawing.Point(456, 31)
        Me.buttonVideo.Name = "buttonVideo"
        Me.buttonVideo.Size = New System.Drawing.Size(24, 24)
        Me.buttonVideo.TabIndex = 14
        Me.buttonVideo.UseVisualStyleBackColor = False
        '
        'buttonNetwork
        '
        Me.buttonNetwork.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonNetwork.FlatAppearance.BorderSize = 0
        Me.buttonNetwork.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonNetwork.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonNetwork.ImageKey = "network.png"
        Me.buttonNetwork.ImageList = Me.ImageList2
        Me.buttonNetwork.Location = New System.Drawing.Point(426, 31)
        Me.buttonNetwork.Name = "buttonNetwork"
        Me.buttonNetwork.Size = New System.Drawing.Size(24, 24)
        Me.buttonNetwork.TabIndex = 13
        Me.buttonNetwork.UseVisualStyleBackColor = False
        '
        'buttonTerminal
        '
        Me.buttonTerminal.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonTerminal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonTerminal.FlatAppearance.BorderSize = 0
        Me.buttonTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonTerminal.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonTerminal.ImageKey = "terminal.png"
        Me.buttonTerminal.ImageList = Me.ImageList2
        Me.buttonTerminal.Location = New System.Drawing.Point(522, 31)
        Me.buttonTerminal.Name = "buttonTerminal"
        Me.buttonTerminal.Size = New System.Drawing.Size(25, 24)
        Me.buttonTerminal.TabIndex = 16
        Me.buttonTerminal.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DarkGray
        Me.Label8.Location = New System.Drawing.Point(512, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 15)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "|"
        '
        'buttonStorage
        '
        Me.buttonStorage.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonStorage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonStorage.FlatAppearance.BorderSize = 0
        Me.buttonStorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonStorage.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonStorage.ImageKey = "storages.png"
        Me.buttonStorage.ImageList = Me.ImageList2
        Me.buttonStorage.Location = New System.Drawing.Point(396, 31)
        Me.buttonStorage.Name = "buttonStorage"
        Me.buttonStorage.Size = New System.Drawing.Size(24, 24)
        Me.buttonStorage.TabIndex = 12
        Me.buttonStorage.UseVisualStyleBackColor = False
        '
        'buttonMemory
        '
        Me.buttonMemory.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonMemory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonMemory.FlatAppearance.BorderSize = 0
        Me.buttonMemory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonMemory.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonMemory.ImageKey = "memory.png"
        Me.buttonMemory.ImageList = Me.ImageList2
        Me.buttonMemory.Location = New System.Drawing.Point(366, 31)
        Me.buttonMemory.Name = "buttonMemory"
        Me.buttonMemory.Size = New System.Drawing.Size(24, 24)
        Me.buttonMemory.TabIndex = 11
        Me.buttonMemory.UseVisualStyleBackColor = False
        '
        'buttonProcessor
        '
        Me.buttonProcessor.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonProcessor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonProcessor.FlatAppearance.BorderSize = 0
        Me.buttonProcessor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonProcessor.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonProcessor.ImageKey = "processor.png"
        Me.buttonProcessor.ImageList = Me.ImageList2
        Me.buttonProcessor.Location = New System.Drawing.Point(336, 31)
        Me.buttonProcessor.Name = "buttonProcessor"
        Me.buttonProcessor.Size = New System.Drawing.Size(24, 24)
        Me.buttonProcessor.TabIndex = 10
        Me.buttonProcessor.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DarkGray
        Me.Label7.Location = New System.Drawing.Point(297, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 15)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "|"
        '
        'buttonSoftware
        '
        Me.buttonSoftware.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonSoftware.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonSoftware.FlatAppearance.BorderSize = 0
        Me.buttonSoftware.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonSoftware.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonSoftware.ImageKey = "software.png"
        Me.buttonSoftware.ImageList = Me.ImageList2
        Me.buttonSoftware.Location = New System.Drawing.Point(272, 31)
        Me.buttonSoftware.Name = "buttonSoftware"
        Me.buttonSoftware.Size = New System.Drawing.Size(24, 24)
        Me.buttonSoftware.TabIndex = 9
        Me.buttonSoftware.UseVisualStyleBackColor = False
        '
        'buttonServices
        '
        Me.buttonServices.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonServices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonServices.FlatAppearance.BorderSize = 0
        Me.buttonServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonServices.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonServices.ImageKey = "services.png"
        Me.buttonServices.ImageList = Me.ImageList2
        Me.buttonServices.Location = New System.Drawing.Point(242, 31)
        Me.buttonServices.Name = "buttonServices"
        Me.buttonServices.Size = New System.Drawing.Size(24, 24)
        Me.buttonServices.TabIndex = 8
        Me.buttonServices.UseVisualStyleBackColor = False
        '
        'buttonProcesses
        '
        Me.buttonProcesses.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonProcesses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonProcesses.FlatAppearance.BorderSize = 0
        Me.buttonProcesses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonProcesses.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonProcesses.ImageKey = "processes.png"
        Me.buttonProcesses.ImageList = Me.ImageList2
        Me.buttonProcesses.Location = New System.Drawing.Point(212, 31)
        Me.buttonProcesses.Name = "buttonProcesses"
        Me.buttonProcesses.Size = New System.Drawing.Size(24, 24)
        Me.buttonProcesses.TabIndex = 7
        Me.buttonProcesses.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DarkGray
        Me.Label6.Location = New System.Drawing.Point(201, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "|"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DarkGray
        Me.Label5.Location = New System.Drawing.Point(135, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "|"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DarkGray
        Me.Label4.Location = New System.Drawing.Point(70, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "|"
        '
        'buttonGroups
        '
        Me.buttonGroups.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonGroups.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonGroups.FlatAppearance.BorderSize = 0
        Me.buttonGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonGroups.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonGroups.ImageKey = "groups.png"
        Me.buttonGroups.ImageList = Me.ImageList2
        Me.buttonGroups.Location = New System.Drawing.Point(176, 31)
        Me.buttonGroups.Name = "buttonGroups"
        Me.buttonGroups.Size = New System.Drawing.Size(24, 24)
        Me.buttonGroups.TabIndex = 6
        Me.buttonGroups.UseVisualStyleBackColor = False
        '
        'buttonUsers
        '
        Me.buttonUsers.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonUsers.FlatAppearance.BorderSize = 0
        Me.buttonUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonUsers.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonUsers.ImageKey = "users.png"
        Me.buttonUsers.ImageList = Me.ImageList2
        Me.buttonUsers.Location = New System.Drawing.Point(146, 31)
        Me.buttonUsers.Name = "buttonUsers"
        Me.buttonUsers.Size = New System.Drawing.Size(24, 24)
        Me.buttonUsers.TabIndex = 5
        Me.buttonUsers.UseVisualStyleBackColor = False
        '
        'buttonShares
        '
        Me.buttonShares.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonShares.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonShares.FlatAppearance.BorderSize = 0
        Me.buttonShares.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonShares.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonShares.ImageKey = "shares.png"
        Me.buttonShares.ImageList = Me.ImageList2
        Me.buttonShares.Location = New System.Drawing.Point(110, 31)
        Me.buttonShares.Name = "buttonShares"
        Me.buttonShares.Size = New System.Drawing.Size(24, 24)
        Me.buttonShares.TabIndex = 4
        Me.buttonShares.UseVisualStyleBackColor = False
        '
        'buttonPartitions
        '
        Me.buttonPartitions.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonPartitions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonPartitions.FlatAppearance.BorderSize = 0
        Me.buttonPartitions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonPartitions.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonPartitions.ImageKey = "partitions.png"
        Me.buttonPartitions.ImageList = Me.ImageList2
        Me.buttonPartitions.Location = New System.Drawing.Point(80, 31)
        Me.buttonPartitions.Name = "buttonPartitions"
        Me.buttonPartitions.Size = New System.Drawing.Size(24, 24)
        Me.buttonPartitions.TabIndex = 3
        Me.buttonPartitions.UseVisualStyleBackColor = False
        '
        'buttonVnc
        '
        Me.buttonVnc.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.buttonVnc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.buttonVnc.FlatAppearance.BorderSize = 0
        Me.buttonVnc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonVnc.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.buttonVnc.ImageKey = "vnc.png"
        Me.buttonVnc.ImageList = Me.ImageList2
        Me.buttonVnc.Location = New System.Drawing.Point(46, 31)
        Me.buttonVnc.Name = "buttonVnc"
        Me.buttonVnc.Size = New System.Drawing.Size(24, 24)
        Me.buttonVnc.TabIndex = 2
        Me.buttonVnc.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mainMenuFile, Me.mainMenuTightVNC, Me.mainMenuComputer, Me.mainMenuService, Me.mainMenuHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip1.TabIndex = 3
        '
        'mainMenuFile
        '
        Me.mainMenuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mainMenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mainMenuFileExit})
        Me.mainMenuFile.Name = "mainMenuFile"
        Me.mainMenuFile.Size = New System.Drawing.Size(37, 20)
        Me.mainMenuFile.Text = "File"
        '
        'mainMenuFileExit
        '
        Me.mainMenuFileExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mainMenuFileExit.Name = "mainMenuFileExit"
        Me.mainMenuFileExit.Size = New System.Drawing.Size(92, 22)
        Me.mainMenuFileExit.Text = "Exit"
        '
        'mainMenuTightVNC
        '
        Me.mainMenuTightVNC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mainMenuVncInstall, Me.mainMenuVncUninstall, Me.ToolStripSeparator26, Me.mainMenuVncServerSettings})
        Me.mainMenuTightVNC.Name = "mainMenuTightVNC"
        Me.mainMenuTightVNC.Size = New System.Drawing.Size(71, 20)
        Me.mainMenuTightVNC.Text = "TightVNC"
        '
        'mainMenuVncInstall
        '
        Me.mainMenuVncInstall.Name = "mainMenuVncInstall"
        Me.mainMenuVncInstall.Size = New System.Drawing.Size(159, 22)
        Me.mainMenuVncInstall.Text = "Install service"
        '
        'mainMenuVncUninstall
        '
        Me.mainMenuVncUninstall.Name = "mainMenuVncUninstall"
        Me.mainMenuVncUninstall.Size = New System.Drawing.Size(159, 22)
        Me.mainMenuVncUninstall.Text = "Uninstall service"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(156, 6)
        '
        'mainMenuVncServerSettings
        '
        Me.mainMenuVncServerSettings.Name = "mainMenuVncServerSettings"
        Me.mainMenuVncServerSettings.Size = New System.Drawing.Size(159, 22)
        Me.mainMenuVncServerSettings.Text = "Service settings"
        Me.mainMenuVncServerSettings.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'mainMenuComputer
        '
        Me.mainMenuComputer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mainMenuComputerGeneralInformation, Me.ToolStripSeparator12, Me.mainMenuComputerVNC, Me.mainMenuComputerReboot, Me.mainMenuComputerShutdown, Me.ToolStripSeparator13, Me.mainMenuComputerPartitions, Me.mainMenuComputerShares, Me.ToolStripSeparator25, Me.mainMenuComputerUsers, Me.mainMenuComputerGroups, Me.ToolStripSeparator14, Me.mainMenuComputerProcesses, Me.mainMenuComputerServices, Me.mainMenuComputerSoftware, Me.ToolStripSeparator15, Me.mainMenuComputerDevices, Me.ToolStripSeparator16, Me.mainMenuComputerTerminal})
        Me.mainMenuComputer.Name = "mainMenuComputer"
        Me.mainMenuComputer.Size = New System.Drawing.Size(73, 20)
        Me.mainMenuComputer.Text = "Computer"
        '
        'mainMenuComputerGeneralInformation
        '
        Me.mainMenuComputerGeneralInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mainMenuComputerGeneralInformation.Name = "mainMenuComputerGeneralInformation"
        Me.mainMenuComputerGeneralInformation.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerGeneralInformation.Text = "General information"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(177, 6)
        '
        'mainMenuComputerVNC
        '
        Me.mainMenuComputerVNC.Name = "mainMenuComputerVNC"
        Me.mainMenuComputerVNC.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerVNC.Text = "Connect"
        '
        'mainMenuComputerReboot
        '
        Me.mainMenuComputerReboot.Name = "mainMenuComputerReboot"
        Me.mainMenuComputerReboot.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerReboot.Text = "Reboot"
        '
        'mainMenuComputerShutdown
        '
        Me.mainMenuComputerShutdown.Name = "mainMenuComputerShutdown"
        Me.mainMenuComputerShutdown.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerShutdown.Text = "Shutdown"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(177, 6)
        '
        'mainMenuComputerPartitions
        '
        Me.mainMenuComputerPartitions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mainMenuComputerPartitions.Name = "mainMenuComputerPartitions"
        Me.mainMenuComputerPartitions.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerPartitions.Text = "Partitions"
        '
        'mainMenuComputerShares
        '
        Me.mainMenuComputerShares.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mainMenuComputerShares.Name = "mainMenuComputerShares"
        Me.mainMenuComputerShares.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerShares.Text = "Shares"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(177, 6)
        '
        'mainMenuComputerUsers
        '
        Me.mainMenuComputerUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mainMenuComputerUsers.Name = "mainMenuComputerUsers"
        Me.mainMenuComputerUsers.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerUsers.Text = "Users"
        '
        'mainMenuComputerGroups
        '
        Me.mainMenuComputerGroups.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mainMenuComputerGroups.Name = "mainMenuComputerGroups"
        Me.mainMenuComputerGroups.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerGroups.Text = "Groups"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(177, 6)
        '
        'mainMenuComputerProcesses
        '
        Me.mainMenuComputerProcesses.Name = "mainMenuComputerProcesses"
        Me.mainMenuComputerProcesses.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerProcesses.Text = "Processes"
        '
        'mainMenuComputerServices
        '
        Me.mainMenuComputerServices.Name = "mainMenuComputerServices"
        Me.mainMenuComputerServices.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerServices.Text = "Services"
        '
        'mainMenuComputerSoftware
        '
        Me.mainMenuComputerSoftware.Name = "mainMenuComputerSoftware"
        Me.mainMenuComputerSoftware.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerSoftware.Text = "Software"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(177, 6)
        '
        'mainMenuComputerDevices
        '
        Me.mainMenuComputerDevices.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.computerMotherboard, Me.mainMenuComputerProcessor, Me.mainMenuComputerMemory, Me.mainMenuComputerStorage, Me.mainMenuComputerNetwork, Me.mainMenuComputerVideo, Me.mainMenuComputerSound})
        Me.mainMenuComputerDevices.Name = "mainMenuComputerDevices"
        Me.mainMenuComputerDevices.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerDevices.Text = "Devices"
        '
        'computerMotherboard
        '
        Me.computerMotherboard.Name = "computerMotherboard"
        Me.computerMotherboard.Size = New System.Drawing.Size(132, 22)
        Me.computerMotherboard.Text = "Base board"
        '
        'mainMenuComputerProcessor
        '
        Me.mainMenuComputerProcessor.Name = "mainMenuComputerProcessor"
        Me.mainMenuComputerProcessor.Size = New System.Drawing.Size(132, 22)
        Me.mainMenuComputerProcessor.Text = "Processor"
        '
        'mainMenuComputerMemory
        '
        Me.mainMenuComputerMemory.Name = "mainMenuComputerMemory"
        Me.mainMenuComputerMemory.Size = New System.Drawing.Size(132, 22)
        Me.mainMenuComputerMemory.Text = "Memory"
        '
        'mainMenuComputerStorage
        '
        Me.mainMenuComputerStorage.Name = "mainMenuComputerStorage"
        Me.mainMenuComputerStorage.Size = New System.Drawing.Size(132, 22)
        Me.mainMenuComputerStorage.Text = "Storage"
        '
        'mainMenuComputerNetwork
        '
        Me.mainMenuComputerNetwork.Name = "mainMenuComputerNetwork"
        Me.mainMenuComputerNetwork.Size = New System.Drawing.Size(132, 22)
        Me.mainMenuComputerNetwork.Text = "Network"
        '
        'mainMenuComputerVideo
        '
        Me.mainMenuComputerVideo.Name = "mainMenuComputerVideo"
        Me.mainMenuComputerVideo.Size = New System.Drawing.Size(132, 22)
        Me.mainMenuComputerVideo.Text = "Video"
        '
        'mainMenuComputerSound
        '
        Me.mainMenuComputerSound.Name = "mainMenuComputerSound"
        Me.mainMenuComputerSound.Size = New System.Drawing.Size(132, 22)
        Me.mainMenuComputerSound.Text = "Sound"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(177, 6)
        '
        'mainMenuComputerTerminal
        '
        Me.mainMenuComputerTerminal.Name = "mainMenuComputerTerminal"
        Me.mainMenuComputerTerminal.Size = New System.Drawing.Size(180, 22)
        Me.mainMenuComputerTerminal.Text = "Terminal seesions"
        '
        'mainMenuService
        '
        Me.mainMenuService.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mainMenuServiceInventarization, Me.mainMenuExportComputers})
        Me.mainMenuService.Name = "mainMenuService"
        Me.mainMenuService.Size = New System.Drawing.Size(47, 20)
        Me.mainMenuService.Text = "Tools"
        '
        'mainMenuServiceInventarization
        '
        Me.mainMenuServiceInventarization.Name = "mainMenuServiceInventarization"
        Me.mainMenuServiceInventarization.Size = New System.Drawing.Size(199, 22)
        Me.mainMenuServiceInventarization.Text = "Inventory"
        '
        'mainMenuExportComputers
        '
        Me.mainMenuExportComputers.Name = "mainMenuExportComputers"
        Me.mainMenuExportComputers.Size = New System.Drawing.Size(199, 22)
        Me.mainMenuExportComputers.Text = "Export list of computers"
        '
        'mainMenuHelp
        '
        Me.mainMenuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mainMenuHelpReference, Me.ToolStripSeparator17, Me.mainMenuHelpAbout})
        Me.mainMenuHelp.Name = "mainMenuHelp"
        Me.mainMenuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mainMenuHelp.Text = "Help"
        '
        'mainMenuHelpReference
        '
        Me.mainMenuHelpReference.Name = "mainMenuHelpReference"
        Me.mainMenuHelpReference.Size = New System.Drawing.Size(136, 22)
        Me.mainMenuHelpReference.Text = "Instructions"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(133, 6)
        '
        'mainMenuHelpAbout
        '
        Me.mainMenuHelpAbout.Name = "mainMenuHelpAbout"
        Me.mainMenuHelpAbout.Size = New System.Drawing.Size(136, 22)
        Me.mainMenuHelpAbout.Text = "About"
        '
        'ContextUsers
        '
        Me.ContextUsers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.userCreate, Me.ToolStripSeparator28, Me.userPassword, Me.ToolStripSeparator5, Me.userRemove, Me.userRename, Me.ToolStripSeparator4, Me.userProperties, Me.userRefresh})
        Me.ContextUsers.Name = "ContextMenuStrip1"
        Me.ContextUsers.Size = New System.Drawing.Size(144, 154)
        '
        'userCreate
        '
        Me.userCreate.Name = "userCreate"
        Me.userCreate.Size = New System.Drawing.Size(143, 22)
        Me.userCreate.Text = "New user"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(140, 6)
        '
        'userPassword
        '
        Me.userPassword.Name = "userPassword"
        Me.userPassword.Size = New System.Drawing.Size(143, 22)
        Me.userPassword.Text = "Set password"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(140, 6)
        '
        'userRemove
        '
        Me.userRemove.Name = "userRemove"
        Me.userRemove.Size = New System.Drawing.Size(143, 22)
        Me.userRemove.Text = "Delete"
        '
        'userRename
        '
        Me.userRename.Name = "userRename"
        Me.userRename.Size = New System.Drawing.Size(143, 22)
        Me.userRename.Text = "Rename"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(140, 6)
        '
        'userProperties
        '
        Me.userProperties.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.userProperties.Name = "userProperties"
        Me.userProperties.Size = New System.Drawing.Size(143, 22)
        Me.userProperties.Text = "Properties"
        '
        'userRefresh
        '
        Me.userRefresh.Name = "userRefresh"
        Me.userRefresh.Size = New System.Drawing.Size(143, 22)
        Me.userRefresh.Text = "Refresh"
        '
        'ContextGroups
        '
        Me.ContextGroups.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.groupCreate, Me.ToolStripSeparator8, Me.groupAddMember, Me.ToolStripSeparator6, Me.groupRemove, Me.groupRename, Me.ToolStripSeparator7, Me.groupProperties, Me.groupRefresh})
        Me.ContextGroups.Name = "ContextGroups"
        Me.ContextGroups.Size = New System.Drawing.Size(155, 154)
        '
        'groupCreate
        '
        Me.groupCreate.Name = "groupCreate"
        Me.groupCreate.Size = New System.Drawing.Size(154, 22)
        Me.groupCreate.Text = "New group"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(151, 6)
        '
        'groupAddMember
        '
        Me.groupAddMember.Name = "groupAddMember"
        Me.groupAddMember.Size = New System.Drawing.Size(154, 22)
        Me.groupAddMember.Text = "Add to group..."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(151, 6)
        '
        'groupRemove
        '
        Me.groupRemove.Name = "groupRemove"
        Me.groupRemove.Size = New System.Drawing.Size(154, 22)
        Me.groupRemove.Text = "Delete"
        '
        'groupRename
        '
        Me.groupRename.Name = "groupRename"
        Me.groupRename.Size = New System.Drawing.Size(154, 22)
        Me.groupRename.Text = "Rename"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(151, 6)
        '
        'groupProperties
        '
        Me.groupProperties.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.groupProperties.Name = "groupProperties"
        Me.groupProperties.Size = New System.Drawing.Size(154, 22)
        Me.groupProperties.Text = "Properties"
        '
        'groupRefresh
        '
        Me.groupRefresh.Name = "groupRefresh"
        Me.groupRefresh.Size = New System.Drawing.Size(154, 22)
        Me.groupRefresh.Text = "Refresh"
        '
        'ContextPartitions
        '
        Me.ContextPartitions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.partitionProperties, Me.partitionRefresh})
        Me.ContextPartitions.Name = "ContextPartitions"
        Me.ContextPartitions.Size = New System.Drawing.Size(133, 48)
        '
        'partitionProperties
        '
        Me.partitionProperties.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.partitionProperties.Name = "partitionProperties"
        Me.partitionProperties.Size = New System.Drawing.Size(132, 22)
        Me.partitionProperties.Text = "Properties"
        '
        'partitionRefresh
        '
        Me.partitionRefresh.Name = "partitionRefresh"
        Me.partitionRefresh.Size = New System.Drawing.Size(132, 22)
        Me.partitionRefresh.Text = "Refresh"
        '
        'ContextGeneral
        '
        Me.ContextGeneral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.generalDescription, Me.generalRefresh})
        Me.ContextGeneral.Name = "ContextGeneral"
        Me.ContextGeneral.Size = New System.Drawing.Size(178, 48)
        '
        'generalDescription
        '
        Me.generalDescription.Name = "generalDescription"
        Me.generalDescription.Size = New System.Drawing.Size(177, 22)
        Me.generalDescription.Text = "Change description"
        '
        'generalRefresh
        '
        Me.generalRefresh.Name = "generalRefresh"
        Me.generalRefresh.Size = New System.Drawing.Size(177, 22)
        Me.generalRefresh.Text = "Refresh"
        '
        'ContextTerminalSessions
        '
        Me.ContextTerminalSessions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.terminalLogOff, Me.terminalRefresh})
        Me.ContextTerminalSessions.Name = "ContextTerminalSessions"
        Me.ContextTerminalSessions.Size = New System.Drawing.Size(114, 48)
        '
        'terminalLogOff
        '
        Me.terminalLogOff.Name = "terminalLogOff"
        Me.terminalLogOff.Size = New System.Drawing.Size(113, 22)
        Me.terminalLogOff.Text = "Log off"
        '
        'terminalRefresh
        '
        Me.terminalRefresh.Name = "terminalRefresh"
        Me.terminalRefresh.Size = New System.Drawing.Size(113, 22)
        Me.terminalRefresh.Text = "Refresh"
        '
        'EventLog1
        '
        Me.EventLog1.SynchronizingObject = Me
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(784, 482)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(610, 420)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saqwel Remote Administration Tool"
        Me.ContextProcess.ResumeLayout(False)
        Me.ContextService.ResumeLayout(False)
        Me.ContextShare.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextComputer.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextUsers.ResumeLayout(False)
        Me.ContextGroups.ResumeLayout(False)
        Me.ContextPartitions.ResumeLayout(False)
        Me.ContextGeneral.ResumeLayout(False)
        Me.ContextTerminalSessions.ResumeLayout(False)
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ContextProcess As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ProcessKill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextService As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ServStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServRestart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextShare As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents shareOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents buttonVnc As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ServStartMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServStartAuto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServStartManual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServStartDisable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ContextUsers As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ProcessRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents shareRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents userRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents userRename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents userProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents userPassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ContextGroups As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents groupAddMember As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents groupRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents groupRename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents groupProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents groupCreate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents groupRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents shareCreate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents shareRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents shareProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextPartitions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents partitionProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents partitionRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextGeneral As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents generalDescription As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents generalRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mainMenuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ContextTerminalSessions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents terminalLogOff As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents terminalRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuTightVNC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuVncServerSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuVncInstall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuVncUninstall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonPartitions As System.Windows.Forms.Button
    Friend WithEvents buttonGroups As System.Windows.Forms.Button
    Friend WithEvents buttonUsers As System.Windows.Forms.Button
    Friend WithEvents buttonShares As System.Windows.Forms.Button
    Friend WithEvents buttonServices As System.Windows.Forms.Button
    Friend WithEvents buttonProcesses As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents buttonTerminal As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents buttonStorage As System.Windows.Forms.Button
    Friend WithEvents buttonMemory As System.Windows.Forms.Button
    Friend WithEvents buttonProcessor As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents buttonSoftware As System.Windows.Forms.Button
    Friend WithEvents buttonSound As System.Windows.Forms.Button
    Friend WithEvents buttonVideo As System.Windows.Forms.Button
    Friend WithEvents buttonNetwork As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents buttonGeneralInformation As System.Windows.Forms.Button
    Friend WithEvents mainMenuComputer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerGeneralInformation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mainMenuComputerPartitions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerShares As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mainMenuComputerUsers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mainMenuComputerProcesses As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerServices As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerSoftware As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mainMenuComputerTerminal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuHelpReference As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mainMenuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonPane As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents ContextComputer As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents computerGeneralInformation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents computerVnc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents computerPartitions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerShares As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents computerUsers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents computerProcesses As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerServices As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerSoftware As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents computerTerminal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents mainMenuComputerVNC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mainMenuService As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuServiceInventarization As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonMotherboard As System.Windows.Forms.Button
    Friend WithEvents mainMenuComputerReboot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerShutdown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerDevices As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerSound As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerProcessor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerMemory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerStorage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerNetwork As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerVideo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComputerDevices As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerNetwork As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerVideo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerSound As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerProcessor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerMemory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerStorage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerReboot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerShutdown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuComputerMotherboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents computerMotherboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents userCreate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents userRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuExportComputers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
