
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
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_Auto = new System.Windows.Forms.TabPage();
            this.nFail = new System.Windows.Forms.Label();
            this.nPass = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRunContinue = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tabPage_Manual = new System.Windows.Forms.TabPage();
            this.tabPage_Interface = new System.Windows.Forms.TabPage();
            this.tabPage_Parameter = new System.Windows.Forms.TabPage();
            this.tabPage_Setting = new System.Windows.Forms.TabPage();
            this.tabPage_Log = new System.Windows.Forms.TabPage();
            this.lbLogo = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbDateTime = new System.Windows.Forms.Label();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.menuStrip1.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_Auto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBlockToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(855, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolBlockToolStripMenuItem
            // 
            this.toolBlockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.toolBlockToolStripMenuItem.Name = "toolBlockToolStripMenuItem";
            this.toolBlockToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.toolBlockToolStripMenuItem.Text = "ToolBlock";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Main.Controls.Add(this.tabPage_Auto);
            this.tabControl_Main.Controls.Add(this.tabPage_Manual);
            this.tabControl_Main.Controls.Add(this.tabPage_Interface);
            this.tabControl_Main.Controls.Add(this.tabPage_Parameter);
            this.tabControl_Main.Controls.Add(this.tabPage_Setting);
            this.tabControl_Main.Controls.Add(this.tabPage_Log);
            this.tabControl_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl_Main.ItemSize = new System.Drawing.Size(96, 50);
            this.tabControl_Main.Location = new System.Drawing.Point(0, 75);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(855, 442);
            this.tabControl_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_Main.TabIndex = 1;
            // 
            // tabPage_Auto
            // 
            this.tabPage_Auto.Controls.Add(this.cogRecordDisplay1);
            this.tabPage_Auto.Controls.Add(this.nFail);
            this.tabPage_Auto.Controls.Add(this.nPass);
            this.tabPage_Auto.Controls.Add(this.label6);
            this.tabPage_Auto.Controls.Add(this.label4);
            this.tabPage_Auto.Controls.Add(this.label2);
            this.tabPage_Auto.Controls.Add(this.btnRunContinue);
            this.tabPage_Auto.Controls.Add(this.btnRun);
            this.tabPage_Auto.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Auto.Name = "tabPage_Auto";
            this.tabPage_Auto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Auto.Size = new System.Drawing.Size(847, 384);
            this.tabPage_Auto.TabIndex = 0;
            this.tabPage_Auto.Text = "Auto";
            this.tabPage_Auto.UseVisualStyleBackColor = true;
            // 
            // nFail
            // 
            this.nFail.AutoSize = true;
            this.nFail.Location = new System.Drawing.Point(667, 195);
            this.nFail.Name = "nFail";
            this.nFail.Size = new System.Drawing.Size(16, 17);
            this.nFail.TabIndex = 24;
            this.nFail.Text = "0";
            // 
            // nPass
            // 
            this.nPass.AutoSize = true;
            this.nPass.Location = new System.Drawing.Point(667, 175);
            this.nPass.Name = "nPass";
            this.nPass.Size = new System.Drawing.Size(16, 17);
            this.nPass.TabIndex = 23;
            this.nPass.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(600, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "OutPuts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(605, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Fail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(605, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Pass:";
            // 
            // btnRunContinue
            // 
            this.btnRunContinue.Location = new System.Drawing.Point(603, 324);
            this.btnRunContinue.Name = "btnRunContinue";
            this.btnRunContinue.Size = new System.Drawing.Size(134, 24);
            this.btnRunContinue.TabIndex = 19;
            this.btnRunContinue.Text = "Run Continue";
            this.btnRunContinue.UseVisualStyleBackColor = true;
            this.btnRunContinue.Click += new System.EventHandler(this.btnRunContinue_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(603, 354);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(134, 24);
            this.btnRun.TabIndex = 19;
            this.btnRun.Text = "Run Once";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tabPage_Manual
            // 
            this.tabPage_Manual.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Manual.Name = "tabPage_Manual";
            this.tabPage_Manual.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Manual.Size = new System.Drawing.Size(847, 384);
            this.tabPage_Manual.TabIndex = 1;
            this.tabPage_Manual.Text = "Manual";
            this.tabPage_Manual.UseVisualStyleBackColor = true;
            // 
            // tabPage_Interface
            // 
            this.tabPage_Interface.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Interface.Name = "tabPage_Interface";
            this.tabPage_Interface.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Interface.Size = new System.Drawing.Size(847, 384);
            this.tabPage_Interface.TabIndex = 2;
            this.tabPage_Interface.Text = "Interface";
            this.tabPage_Interface.UseVisualStyleBackColor = true;
            // 
            // tabPage_Parameter
            // 
            this.tabPage_Parameter.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Parameter.Name = "tabPage_Parameter";
            this.tabPage_Parameter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Parameter.Size = new System.Drawing.Size(847, 384);
            this.tabPage_Parameter.TabIndex = 3;
            this.tabPage_Parameter.Text = "Parameter";
            this.tabPage_Parameter.UseVisualStyleBackColor = true;
            // 
            // tabPage_Setting
            // 
            this.tabPage_Setting.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Setting.Name = "tabPage_Setting";
            this.tabPage_Setting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Setting.Size = new System.Drawing.Size(847, 384);
            this.tabPage_Setting.TabIndex = 4;
            this.tabPage_Setting.Text = "Setting";
            this.tabPage_Setting.UseVisualStyleBackColor = true;
            // 
            // tabPage_Log
            // 
            this.tabPage_Log.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Log.Name = "tabPage_Log";
            this.tabPage_Log.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Log.Size = new System.Drawing.Size(847, 384);
            this.tabPage_Log.TabIndex = 5;
            this.tabPage_Log.Text = "Log";
            this.tabPage_Log.UseVisualStyleBackColor = true;
            // 
            // lbLogo
            // 
            this.lbLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbLogo.Location = new System.Drawing.Point(1, 24);
            this.lbLogo.Name = "lbLogo";
            this.lbLogo.Size = new System.Drawing.Size(108, 48);
            this.lbLogo.TabIndex = 2;
            this.lbLogo.Text = "Logo";
            this.lbLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbTitle.Location = new System.Drawing.Point(115, 24);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(626, 48);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "VisionPro Tutorial";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDateTime
            // 
            this.lbDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbDateTime.Location = new System.Drawing.Point(747, 24);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(108, 48);
            this.lbDateTime.TabIndex = 3;
            this.lbDateTime.Text = "Date-Time";
            this.lbDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cogRecordDisplay1.Size = new System.Drawing.Size(582, 375);
            this.cogRecordDisplay1.TabIndex = 25;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 529);
            this.Controls.Add(this.lbDateTime);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbLogo);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "VisionPro Tutotial";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_Auto.ResumeLayout(false);
            this.tabPage_Auto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolBlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_Auto;
        private System.Windows.Forms.TabPage tabPage_Manual;
        private System.Windows.Forms.Label lbLogo;
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
    }
}

