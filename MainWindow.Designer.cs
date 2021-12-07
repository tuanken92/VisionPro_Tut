
namespace VisionPro_Tut
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.load_ImageProcessItem = new System.Windows.Forms.ToolStripMenuItem();
            this.load_AcqFifoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_Auto = new System.Windows.Forms.TabPage();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.nFail = new System.Windows.Forms.Label();
            this.nPass = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRunContinue = new System.Windows.Forms.Button();
            this.btnInitial = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tabPage_Manual = new System.Windows.Forms.TabPage();
            this.display_img = new System.Windows.Forms.PictureBox();
            this.path_img = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.grid_cell = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage_Interface = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_ClientPort = new System.Windows.Forms.TextBox();
            this.tb_ClientIP = new System.Windows.Forms.TextBox();
            this.btn_ClientSend = new System.Windows.Forms.Button();
            this.btn_ClientConnect = new System.Windows.Forms.Button();
            this.tx_ClientData2Send = new System.Windows.Forms.TextBox();
            this.lbx_ClientReceive = new System.Windows.Forms.ListBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbx_Client = new System.Windows.Forms.ListBox();
            this.tb_ServerPort = new System.Windows.Forms.TextBox();
            this.tb_ServerIP = new System.Windows.Forms.TextBox();
            this.btn_ServerSend = new System.Windows.Forms.Button();
            this.btn_ServerListen = new System.Windows.Forms.Button();
            this.tb_ServerData2Send = new System.Windows.Forms.TextBox();
            this.lxb_ClientData = new System.Windows.Forms.ListBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tabPage_Parameter = new System.Windows.Forms.TabPage();
            this.tabPage_Setting = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbAreaLowBlob = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAreaHighBlob = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbb_ModeRun = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_UseCamera = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_Toolblock_AcqFifo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_ImgDatabase = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_Toolblock_Process = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbb_Baudrate = new System.Windows.Forms.ComboBox();
            this.cbb_Comport = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveParam = new System.Windows.Forms.Button();
            this.tabPage_Log = new System.Windows.Forms.TabPage();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbDateTime = new System.Windows.Forms.Label();
            this.timer_DateTime = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_Auto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.tabPage_Manual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.display_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_cell)).BeginInit();
            this.tabPage_Interface.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage_Setting.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBlockToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(4, 562);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(78, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolBlockToolStripMenuItem
            // 
            this.toolBlockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.load_ImageProcessItem,
            this.load_AcqFifoItem});
            this.toolBlockToolStripMenuItem.Name = "toolBlockToolStripMenuItem";
            this.toolBlockToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.toolBlockToolStripMenuItem.Text = "ToolBlock";
            // 
            // load_ImageProcessItem
            // 
            this.load_ImageProcessItem.Name = "load_ImageProcessItem";
            this.load_ImageProcessItem.Size = new System.Drawing.Size(178, 22);
            this.load_ImageProcessItem.Text = "Load_ImageProcess";
            this.load_ImageProcessItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // load_AcqFifoItem
            // 
            this.load_AcqFifoItem.Name = "load_AcqFifoItem";
            this.load_AcqFifoItem.Size = new System.Drawing.Size(178, 22);
            this.load_AcqFifoItem.Text = "Load_AcqFifo";
            this.load_AcqFifoItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl_Main.Controls.Add(this.tabPage_Auto);
            this.tabControl_Main.Controls.Add(this.tabPage_Manual);
            this.tabControl_Main.Controls.Add(this.tabPage_Interface);
            this.tabControl_Main.Controls.Add(this.tabPage_Parameter);
            this.tabControl_Main.Controls.Add(this.tabPage_Setting);
            this.tabControl_Main.Controls.Add(this.tabPage_Log);
            this.tabControl_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl_Main.ItemSize = new System.Drawing.Size(96, 50);
            this.tabControl_Main.Location = new System.Drawing.Point(-2, 52);
            this.tabControl_Main.Multiline = true;
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(855, 510);
            this.tabControl_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_Main.TabIndex = 1;
            // 
            // tabPage_Auto
            // 
            this.tabPage_Auto.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Auto.Controls.Add(this.cogRecordDisplay1);
            this.tabPage_Auto.Controls.Add(this.nFail);
            this.tabPage_Auto.Controls.Add(this.nPass);
            this.tabPage_Auto.Controls.Add(this.label6);
            this.tabPage_Auto.Controls.Add(this.label4);
            this.tabPage_Auto.Controls.Add(this.label2);
            this.tabPage_Auto.Controls.Add(this.btnRunContinue);
            this.tabPage_Auto.Controls.Add(this.btnInitial);
            this.tabPage_Auto.Controls.Add(this.btnRun);
            this.tabPage_Auto.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Auto.Name = "tabPage_Auto";
            this.tabPage_Auto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Auto.Size = new System.Drawing.Size(847, 452);
            this.tabPage_Auto.TabIndex = 0;
            this.tabPage_Auto.Text = "Auto";
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(3, 3);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(694, 436);
            this.cogRecordDisplay1.TabIndex = 25;
            // 
            // nFail
            // 
            this.nFail.AutoSize = true;
            this.nFail.Location = new System.Drawing.Point(765, 290);
            this.nFail.Name = "nFail";
            this.nFail.Size = new System.Drawing.Size(16, 17);
            this.nFail.TabIndex = 24;
            this.nFail.Text = "0";
            // 
            // nPass
            // 
            this.nPass.AutoSize = true;
            this.nPass.Location = new System.Drawing.Point(765, 270);
            this.nPass.Name = "nPass";
            this.nPass.Size = new System.Drawing.Size(16, 17);
            this.nPass.TabIndex = 23;
            this.nPass.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(703, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "OutPuts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(703, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Fail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(703, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Pass:";
            // 
            // btnRunContinue
            // 
            this.btnRunContinue.Location = new System.Drawing.Point(705, 317);
            this.btnRunContinue.Name = "btnRunContinue";
            this.btnRunContinue.Size = new System.Drawing.Size(134, 34);
            this.btnRunContinue.TabIndex = 19;
            this.btnRunContinue.Text = "Run Continue";
            this.btnRunContinue.UseVisualStyleBackColor = true;
            this.btnRunContinue.Click += new System.EventHandler(this.btn_Click_Event);
            // 
            // btnInitial
            // 
            this.btnInitial.Location = new System.Drawing.Point(705, 405);
            this.btnInitial.Name = "btnInitial";
            this.btnInitial.Size = new System.Drawing.Size(134, 34);
            this.btnInitial.TabIndex = 19;
            this.btnInitial.Text = "Initial";
            this.btnInitial.UseVisualStyleBackColor = true;
            this.btnInitial.Click += new System.EventHandler(this.btn_Click_Event);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(705, 361);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(134, 34);
            this.btnRun.TabIndex = 19;
            this.btnRun.Text = "Run Once";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btn_Click_Event);
            // 
            // tabPage_Manual
            // 
            this.tabPage_Manual.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Manual.Controls.Add(this.display_img);
            this.tabPage_Manual.Controls.Add(this.path_img);
            this.tabPage_Manual.Controls.Add(this.btnProcess);
            this.tabPage_Manual.Controls.Add(this.btnReset);
            this.tabPage_Manual.Controls.Add(this.btnLoadImg);
            this.tabPage_Manual.Controls.Add(this.grid_cell);
            this.tabPage_Manual.Controls.Add(this.label14);
            this.tabPage_Manual.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Manual.Name = "tabPage_Manual";
            this.tabPage_Manual.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Manual.Size = new System.Drawing.Size(847, 452);
            this.tabPage_Manual.TabIndex = 1;
            this.tabPage_Manual.Text = "Manual";
            // 
            // display_img
            // 
            this.display_img.Location = new System.Drawing.Point(12, 45);
            this.display_img.Name = "display_img";
            this.display_img.Size = new System.Drawing.Size(605, 396);
            this.display_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.display_img.TabIndex = 5;
            this.display_img.TabStop = false;
            // 
            // path_img
            // 
            this.path_img.Location = new System.Drawing.Point(96, 11);
            this.path_img.Name = "path_img";
            this.path_img.Size = new System.Drawing.Size(603, 25);
            this.path_img.TabIndex = 4;
            this.path_img.Text = "Path of file";
            this.path_img.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(624, 94);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(217, 30);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Location = new System.Drawing.Point(10, 8);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(80, 30);
            this.btnLoadImg.TabIndex = 2;
            this.btnLoadImg.Text = "Load";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // grid_cell
            // 
            this.grid_cell.Location = new System.Drawing.Point(759, 19);
            this.grid_cell.Name = "grid_cell";
            this.grid_cell.Size = new System.Drawing.Size(51, 23);
            this.grid_cell.TabIndex = 1;
            this.grid_cell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.grid_cell.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(705, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Grid";
            // 
            // tabPage_Interface
            // 
            this.tabPage_Interface.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Interface.Controls.Add(this.groupBox3);
            this.tabPage_Interface.Controls.Add(this.groupBox2);
            this.tabPage_Interface.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Interface.Name = "tabPage_Interface";
            this.tabPage_Interface.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Interface.Size = new System.Drawing.Size(847, 452);
            this.tabPage_Interface.TabIndex = 2;
            this.tabPage_Interface.Text = "Interface";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_ClientPort);
            this.groupBox3.Controls.Add(this.tb_ClientIP);
            this.groupBox3.Controls.Add(this.btn_ClientSend);
            this.groupBox3.Controls.Add(this.btn_ClientConnect);
            this.groupBox3.Controls.Add(this.tx_ClientData2Send);
            this.groupBox3.Controls.Add(this.lbx_ClientReceive);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Location = new System.Drawing.Point(307, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 336);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client";
            // 
            // tb_ClientPort
            // 
            this.tb_ClientPort.Location = new System.Drawing.Point(42, 47);
            this.tb_ClientPort.Name = "tb_ClientPort";
            this.tb_ClientPort.Size = new System.Drawing.Size(143, 23);
            this.tb_ClientPort.TabIndex = 7;
            this.tb_ClientPort.Text = "8888";
            // 
            // tb_ClientIP
            // 
            this.tb_ClientIP.Location = new System.Drawing.Point(42, 19);
            this.tb_ClientIP.Name = "tb_ClientIP";
            this.tb_ClientIP.Size = new System.Drawing.Size(143, 23);
            this.tb_ClientIP.TabIndex = 6;
            this.tb_ClientIP.Text = "127.0.0.1";
            // 
            // btn_ClientSend
            // 
            this.btn_ClientSend.Location = new System.Drawing.Point(9, 298);
            this.btn_ClientSend.Name = "btn_ClientSend";
            this.btn_ClientSend.Size = new System.Drawing.Size(278, 28);
            this.btn_ClientSend.TabIndex = 5;
            this.btn_ClientSend.Text = "Send";
            this.btn_ClientSend.UseVisualStyleBackColor = true;
            this.btn_ClientSend.Click += new System.EventHandler(this.btn_Click_Event);
            // 
            // btn_ClientConnect
            // 
            this.btn_ClientConnect.Location = new System.Drawing.Point(191, 19);
            this.btn_ClientConnect.Name = "btn_ClientConnect";
            this.btn_ClientConnect.Size = new System.Drawing.Size(96, 48);
            this.btn_ClientConnect.TabIndex = 4;
            this.btn_ClientConnect.Text = "Connect";
            this.btn_ClientConnect.UseVisualStyleBackColor = true;
            this.btn_ClientConnect.Click += new System.EventHandler(this.btn_Click_Event);
            // 
            // tx_ClientData2Send
            // 
            this.tx_ClientData2Send.Location = new System.Drawing.Point(9, 199);
            this.tx_ClientData2Send.Multiline = true;
            this.tx_ClientData2Send.Name = "tx_ClientData2Send";
            this.tx_ClientData2Send.Size = new System.Drawing.Size(278, 95);
            this.tx_ClientData2Send.TabIndex = 3;
            // 
            // lbx_ClientReceive
            // 
            this.lbx_ClientReceive.FormattingEnabled = true;
            this.lbx_ClientReceive.ItemHeight = 16;
            this.lbx_ClientReceive.Location = new System.Drawing.Point(9, 94);
            this.lbx_ClientReceive.Name = "lbx_ClientReceive";
            this.lbx_ClientReceive.Size = new System.Drawing.Size(278, 84);
            this.lbx_ClientReceive.TabIndex = 2;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 51);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(34, 17);
            this.label33.TabIndex = 1;
            this.label33.Text = "Port";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 23);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(19, 17);
            this.label34.TabIndex = 0;
            this.label34.Text = "Ip";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbx_Client);
            this.groupBox2.Controls.Add(this.tb_ServerPort);
            this.groupBox2.Controls.Add(this.tb_ServerIP);
            this.groupBox2.Controls.Add(this.btn_ServerSend);
            this.groupBox2.Controls.Add(this.btn_ServerListen);
            this.groupBox2.Controls.Add(this.tb_ServerData2Send);
            this.groupBox2.Controls.Add(this.lxb_ClientData);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Location = new System.Drawing.Point(8, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 336);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server";
            // 
            // lbx_Client
            // 
            this.lbx_Client.FormattingEnabled = true;
            this.lbx_Client.ItemHeight = 16;
            this.lbx_Client.Location = new System.Drawing.Point(9, 94);
            this.lbx_Client.Name = "lbx_Client";
            this.lbx_Client.Size = new System.Drawing.Size(82, 164);
            this.lbx_Client.TabIndex = 8;
            // 
            // tb_ServerPort
            // 
            this.tb_ServerPort.Location = new System.Drawing.Point(42, 47);
            this.tb_ServerPort.Name = "tb_ServerPort";
            this.tb_ServerPort.Size = new System.Drawing.Size(143, 23);
            this.tb_ServerPort.TabIndex = 7;
            this.tb_ServerPort.Text = "8888";
            // 
            // tb_ServerIP
            // 
            this.tb_ServerIP.Location = new System.Drawing.Point(42, 19);
            this.tb_ServerIP.Name = "tb_ServerIP";
            this.tb_ServerIP.Size = new System.Drawing.Size(143, 23);
            this.tb_ServerIP.TabIndex = 6;
            this.tb_ServerIP.Text = "127.0.0.1";
            // 
            // btn_ServerSend
            // 
            this.btn_ServerSend.Location = new System.Drawing.Point(9, 298);
            this.btn_ServerSend.Name = "btn_ServerSend";
            this.btn_ServerSend.Size = new System.Drawing.Size(278, 28);
            this.btn_ServerSend.TabIndex = 5;
            this.btn_ServerSend.Text = "Send";
            this.btn_ServerSend.UseVisualStyleBackColor = true;
            this.btn_ServerSend.Click += new System.EventHandler(this.btn_Click_Event);
            // 
            // btn_ServerListen
            // 
            this.btn_ServerListen.Location = new System.Drawing.Point(191, 19);
            this.btn_ServerListen.Name = "btn_ServerListen";
            this.btn_ServerListen.Size = new System.Drawing.Size(96, 48);
            this.btn_ServerListen.TabIndex = 4;
            this.btn_ServerListen.Text = "Listen";
            this.btn_ServerListen.UseVisualStyleBackColor = true;
            this.btn_ServerListen.Click += new System.EventHandler(this.btn_Click_Event);
            // 
            // tb_ServerData2Send
            // 
            this.tb_ServerData2Send.Location = new System.Drawing.Point(9, 270);
            this.tb_ServerData2Send.Multiline = true;
            this.tb_ServerData2Send.Name = "tb_ServerData2Send";
            this.tb_ServerData2Send.Size = new System.Drawing.Size(278, 24);
            this.tb_ServerData2Send.TabIndex = 3;
            // 
            // lxb_ClientData
            // 
            this.lxb_ClientData.FormattingEnabled = true;
            this.lxb_ClientData.ItemHeight = 16;
            this.lxb_ClientData.Location = new System.Drawing.Point(97, 94);
            this.lxb_ClientData.Name = "lxb_ClientData";
            this.lxb_ClientData.Size = new System.Drawing.Size(190, 164);
            this.lxb_ClientData.TabIndex = 2;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 51);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(34, 17);
            this.label31.TabIndex = 1;
            this.label31.Text = "Port";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 23);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(19, 17);
            this.label32.TabIndex = 0;
            this.label32.Text = "Ip";
            // 
            // tabPage_Parameter
            // 
            this.tabPage_Parameter.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Parameter.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Parameter.Name = "tabPage_Parameter";
            this.tabPage_Parameter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Parameter.Size = new System.Drawing.Size(847, 452);
            this.tabPage_Parameter.TabIndex = 3;
            this.tabPage_Parameter.Text = "Parameter";
            // 
            // tabPage_Setting
            // 
            this.tabPage_Setting.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Setting.Controls.Add(this.panel5);
            this.tabPage_Setting.Controls.Add(this.panel4);
            this.tabPage_Setting.Controls.Add(this.panel3);
            this.tabPage_Setting.Controls.Add(this.panel2);
            this.tabPage_Setting.Controls.Add(this.panel1);
            this.tabPage_Setting.Controls.Add(this.btnSaveParam);
            this.tabPage_Setting.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Setting.Name = "tabPage_Setting";
            this.tabPage_Setting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Setting.Size = new System.Drawing.Size(847, 452);
            this.tabPage_Setting.TabIndex = 4;
            this.tabPage_Setting.Text = "Setting";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox2);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Location = new System.Drawing.Point(579, 89);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 77);
            this.panel5.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(114, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 23);
            this.textBox2.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 23);
            this.textBox1.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Port";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Client IP";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbAreaLowBlob);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.tbAreaHighBlob);
            this.panel4.Location = new System.Drawing.Point(11, 193);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(562, 246);
            this.panel4.TabIndex = 11;
            // 
            // tbAreaLowBlob
            // 
            this.tbAreaLowBlob.Location = new System.Drawing.Point(183, 13);
            this.tbAreaLowBlob.Name = "tbAreaLowBlob";
            this.tbAreaLowBlob.Size = new System.Drawing.Size(97, 23);
            this.tbAreaLowBlob.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Area Low Filter Value:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Area High Filter Value:";
            // 
            // tbAreaHighBlob
            // 
            this.tbAreaHighBlob.Location = new System.Drawing.Point(183, 46);
            this.tbAreaHighBlob.Name = "tbAreaHighBlob";
            this.tbAreaHighBlob.Size = new System.Drawing.Size(97, 23);
            this.tbAreaHighBlob.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbb_ModeRun);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(579, 341);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 52);
            this.panel3.TabIndex = 10;
            // 
            // cbb_ModeRun
            // 
            this.cbb_ModeRun.FormattingEnabled = true;
            this.cbb_ModeRun.Location = new System.Drawing.Point(114, 14);
            this.cbb_ModeRun.Name = "cbb_ModeRun";
            this.cbb_ModeRun.Size = new System.Drawing.Size(121, 24);
            this.cbb_ModeRun.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "ModeRun";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cb_UseCamera);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lb_Toolblock_AcqFifo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lb_ImgDatabase);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lb_Toolblock_Process);
            this.panel2.Location = new System.Drawing.Point(11, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 181);
            this.panel2.TabIndex = 9;
            // 
            // cb_UseCamera
            // 
            this.cb_UseCamera.AutoSize = true;
            this.cb_UseCamera.Location = new System.Drawing.Point(15, 101);
            this.cb_UseCamera.Name = "cb_UseCamera";
            this.cb_UseCamera.Size = new System.Drawing.Size(105, 21);
            this.cb_UseCamera.TabIndex = 10;
            this.cb_UseCamera.Text = "Use Camera";
            this.cb_UseCamera.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "ToolBlock AcqFifo";
            // 
            // lb_Toolblock_AcqFifo
            // 
            this.lb_Toolblock_AcqFifo.AutoSize = true;
            this.lb_Toolblock_AcqFifo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Toolblock_AcqFifo.Location = new System.Drawing.Point(180, 41);
            this.lb_Toolblock_AcqFifo.Name = "lb_Toolblock_AcqFifo";
            this.lb_Toolblock_AcqFifo.Size = new System.Drawing.Size(70, 13);
            this.lb_Toolblock_AcqFifo.TabIndex = 9;
            this.lb_Toolblock_AcqFifo.Text = "AcqFifo_path";
            this.lb_Toolblock_AcqFifo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Toolblock_AcqFifo.Click += new System.EventHandler(this.label_Click_Event);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Database";
            // 
            // lb_ImgDatabase
            // 
            this.lb_ImgDatabase.AutoSize = true;
            this.lb_ImgDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ImgDatabase.Location = new System.Drawing.Point(180, 11);
            this.lb_ImgDatabase.Name = "lb_ImgDatabase";
            this.lb_ImgDatabase.Size = new System.Drawing.Size(74, 13);
            this.lb_ImgDatabase.TabIndex = 2;
            this.lb_ImgDatabase.Text = "Img_database";
            this.lb_ImgDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_ImgDatabase.Click += new System.EventHandler(this.label_Click_Event);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "ToolBlock Process";
            // 
            // lb_Toolblock_Process
            // 
            this.lb_Toolblock_Process.AutoSize = true;
            this.lb_Toolblock_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Toolblock_Process.Location = new System.Drawing.Point(180, 71);
            this.lb_Toolblock_Process.Name = "lb_Toolblock_Process";
            this.lb_Toolblock_Process.Size = new System.Drawing.Size(72, 13);
            this.lb_Toolblock_Process.TabIndex = 3;
            this.lb_Toolblock_Process.Text = "Process_path";
            this.lb_Toolblock_Process.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Toolblock_Process.Click += new System.EventHandler(this.label_Click_Event);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbb_Baudrate);
            this.panel1.Controls.Add(this.cbb_Comport);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(579, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 77);
            this.panel1.TabIndex = 8;
            // 
            // cbb_Baudrate
            // 
            this.cbb_Baudrate.FormattingEnabled = true;
            this.cbb_Baudrate.Location = new System.Drawing.Point(115, 44);
            this.cbb_Baudrate.Name = "cbb_Baudrate";
            this.cbb_Baudrate.Size = new System.Drawing.Size(121, 24);
            this.cbb_Baudrate.TabIndex = 2;
            // 
            // cbb_Comport
            // 
            this.cbb_Comport.FormattingEnabled = true;
            this.cbb_Comport.Location = new System.Drawing.Point(115, 11);
            this.cbb_Comport.Name = "cbb_Comport";
            this.cbb_Comport.Size = new System.Drawing.Size(121, 24);
            this.cbb_Comport.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "BaudRate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Comport";
            // 
            // btnSaveParam
            // 
            this.btnSaveParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveParam.Location = new System.Drawing.Point(579, 399);
            this.btnSaveParam.Name = "btnSaveParam";
            this.btnSaveParam.Size = new System.Drawing.Size(260, 40);
            this.btnSaveParam.TabIndex = 4;
            this.btnSaveParam.Text = "Save";
            this.btnSaveParam.UseVisualStyleBackColor = true;
            this.btnSaveParam.Click += new System.EventHandler(this.btn_Click_Event);
            // 
            // tabPage_Log
            // 
            this.tabPage_Log.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Log.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Log.Name = "tabPage_Log";
            this.tabPage_Log.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Log.Size = new System.Drawing.Size(847, 452);
            this.tabPage_Log.TabIndex = 5;
            this.tabPage_Log.Text = "Log";
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbTitle.Location = new System.Drawing.Point(65, 5);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(687, 48);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "VisionPro Tutorial";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDateTime
            // 
            this.lbDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbDateTime.Location = new System.Drawing.Point(674, 5);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(181, 48);
            this.lbDateTime.TabIndex = 3;
            this.lbDateTime.Text = "Date-Time";
            this.lbDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_DateTime
            // 
            this.timer_DateTime.Enabled = true;
            this.timer_DateTime.Interval = 1000;
            this.timer_DateTime.Tick += new System.EventHandler(this.timer_DateTime_Tick);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::VisionPro_Tut.Properties.Resources.Vietnam;
            this.pictureBoxLogo.Location = new System.Drawing.Point(4, 5);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(64, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 4;
            this.pictureBoxLogo.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(623, 45);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 30);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 595);
            this.Controls.Add(this.lbDateTime);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "VisionPro Tutotial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_Auto.ResumeLayout(false);
            this.tabPage_Auto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.tabPage_Manual.ResumeLayout(false);
            this.tabPage_Manual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.display_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_cell)).EndInit();
            this.tabPage_Interface.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage_Setting.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolBlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem load_ImageProcessItem;
        private System.Windows.Forms.ToolStripMenuItem load_AcqFifoItem;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_Auto;
        private System.Windows.Forms.TabPage tabPage_Manual;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.TabPage tabPage_Interface;
        private System.Windows.Forms.TabPage tabPage_Parameter;
        private System.Windows.Forms.TabPage tabPage_Setting;
        private System.Windows.Forms.TabPage tabPage_Log;
        private System.Windows.Forms.Label nFail;
        private System.Windows.Forms.Label nPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRunContinue;
        private System.Windows.Forms.Button btnRun;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
        private System.Windows.Forms.Label lb_Toolblock_Process;
        private System.Windows.Forms.Label lb_ImgDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveParam;
        private System.Windows.Forms.Timer timer_DateTime;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TextBox tbAreaHighBlob;
        private System.Windows.Forms.TextBox tbAreaLowBlob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInitial;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbb_Baudrate;
        private System.Windows.Forms.ComboBox cbb_Comport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbb_ModeRun;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_Toolblock_AcqFifo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox cb_UseCamera;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_ClientPort;
        private System.Windows.Forms.TextBox tb_ClientIP;
        private System.Windows.Forms.Button btn_ClientSend;
        private System.Windows.Forms.Button btn_ClientConnect;
        private System.Windows.Forms.TextBox tx_ClientData2Send;
        private System.Windows.Forms.ListBox lbx_ClientReceive;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbx_Client;
        private System.Windows.Forms.TextBox tb_ServerPort;
        private System.Windows.Forms.TextBox tb_ServerIP;
        private System.Windows.Forms.Button btn_ServerSend;
        private System.Windows.Forms.Button btn_ServerListen;
        private System.Windows.Forms.TextBox tb_ServerData2Send;
        private System.Windows.Forms.ListBox lxb_ClientData;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox display_img;
        private System.Windows.Forms.Label path_img;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.NumericUpDown grid_cell;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnReset;
    }
}

