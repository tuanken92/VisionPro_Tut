using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionPro_Tut.Source;

namespace VisionPro_Tut.Windows
{
    public partial class ToolBlockWindow : Form
    {

        #region declera variable, object
        private Utils.TYPE_OF_TOOLBLOCK type_of_block;
        public ObjectManager objectManager;
        public CogToolBlock toolblock;
        private string path_vpp_file;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        #endregion


        public ToolBlockWindow()
        {
            Console.WriteLine("Tool block window default");
            InitializeComponent();
        }

        public ToolBlockWindow(ObjectManager objectManager, string path_vpp, Utils.TYPE_OF_TOOLBLOCK type_of_block)
        {
            Console.WriteLine("Tool block window create, path vpp_file = {0}, type_of_block = {1}", path_vpp, type_of_block);
            this.type_of_block = type_of_block;
            this.objectManager = objectManager;
            this.toolblock = new CogToolBlock();
            this.path_vpp_file = path_vpp;
            InitializeComponent();
        }

        

        private void MenuClick_Event(object sender, EventArgs e)
        {
            var menu_item = sender as ToolStripMenuItem;
            Console.WriteLine(menu_item.Text);
            switch (menu_item.Text)
            {
                case "Load":
                    break;
                case "Save":
                    Console.WriteLine($"Save file {this.path_vpp_file}");
                    switch (this.type_of_block)
                    {
                        case Utils.TYPE_OF_TOOLBLOCK.AcqFifo:
                            File.WriteAllBytes(this.path_vpp_file, Utils.Serialize(this.objectManager.mToolBlockAcq));
                            break;
                        case Utils.TYPE_OF_TOOLBLOCK.ImageProcess:
                            File.WriteAllBytes(this.path_vpp_file, Utils.Serialize(this.objectManager.mToolBlockProcess));
                            break;
                        case Utils.TYPE_OF_TOOLBLOCK.Other:
                            File.WriteAllBytes(this.path_vpp_file, Utils.Serialize(this.toolblock));
                            Console.WriteLine($"{this.path_vpp_file}-> {this.type_of_block}!");
                            break;
                    }
                    break;
                case "Save As":
                    SaveFileDialog saveToolBlock = new SaveFileDialog();
                    saveToolBlock.Filter = "ToolBlock |*.vpp|All File|*.*";
                    saveToolBlock.Title = "Save a Toolblock file";
                    saveToolBlock.RestoreDirectory = true;
                    saveToolBlock.ShowDialog();
                    if (saveToolBlock.FileName != null)
                    {
                        Console.WriteLine(saveToolBlock.FileName);
                        
                        switch (this.type_of_block)
                        {
                            case Utils.TYPE_OF_TOOLBLOCK.AcqFifo:
                                File.WriteAllBytes(saveToolBlock.FileName, Utils.Serialize(this.objectManager.mToolBlockAcq));
                                break;
                            case Utils.TYPE_OF_TOOLBLOCK.ImageProcess:
                                File.WriteAllBytes(saveToolBlock.FileName, Utils.Serialize(this.objectManager.mToolBlockProcess));
                                break;
                            case Utils.TYPE_OF_TOOLBLOCK.Other:
                                File.WriteAllBytes(saveToolBlock.FileName, Utils.Serialize(this.toolblock));
                                break;
                        }
                    }
                    break;
                case "OK":
                    switch (this.type_of_block)
                    {
                        case Utils.TYPE_OF_TOOLBLOCK.AcqFifo:
                        case Utils.TYPE_OF_TOOLBLOCK.ImageProcess:
                            Close();
                            DialogResult = DialogResult.OK;
                            break;
                        case Utils.TYPE_OF_TOOLBLOCK.Other:
                            Close();
                            break;
                    }
                    break;
                case "Run":
                    switch (this.type_of_block)
                    {
                        case Utils.TYPE_OF_TOOLBLOCK.AcqFifo:
                            this.objectManager.mToolBlockAcq.Run();
                            break;
                        case Utils.TYPE_OF_TOOLBLOCK.ImageProcess:
                            this.objectManager.RunOnce();
                            break;
                        case Utils.TYPE_OF_TOOLBLOCK.Other:
                            this.toolblock.Run();
                            break;
                    }
                    
                    break;
            }
        }

        private void ToolBlockWindow_Load(object sender, EventArgs e)
        {
            //Load Toolblock and show on window
            

            Console.WriteLine("ToolBlockWindow_Load");

            cogToolBlockEditV21.LocalDisplayVisible = false;

            switch (this.type_of_block)
            {
                case Utils.TYPE_OF_TOOLBLOCK.AcqFifo:
                    cogToolBlockEditV21.Subject = this.objectManager.mToolBlockAcq;
                    break;
                case Utils.TYPE_OF_TOOLBLOCK.ImageProcess:
                    cogToolBlockEditV21.Subject = this.objectManager.mToolBlockProcess;
                    break;
                case Utils.TYPE_OF_TOOLBLOCK.Other:
                    cogToolBlockEditV21.Subject = this.toolblock;
                    break;
            }

            cogToolBlockEditV21.SubjectChanged += new EventHandler(cogToolBlockEditV21_SubjectChanged);

        }

        private void ToolBlockWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close and release resource
            Console.WriteLine("ToolBlockWindow_FormClosing");
        }

        void cogToolBlockEditV21_SubjectChanged(object sender, EventArgs e)
        {
            // The application is meant to be used with the TB.vpp so whenever the user changes the TB
            Console.WriteLine("cogToolBlockEditV21_SubjectChanged");
        }




        #region GUI
        private Cognex.VisionPro.ToolBlock.CogToolBlockEditV2 cogToolBlockEditV21;
        private Label lbStatus;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem oKToolStripMenuItem;
        private MenuStrip menuStrip1;
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            Console.WriteLine($"Dispose = {disposing}");

            cogToolBlockEditV21.SubjectChanged -= new EventHandler(cogToolBlockEditV21_SubjectChanged);
            if (disposing && (components != null))
            {
                components.Dispose();
                Console.WriteLine("components.Dispose();");
            }
            base.Dispose(disposing);

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cogToolBlockEditV21 = new Cognex.VisionPro.ToolBlock.CogToolBlockEditV2();
            this.lbStatus = new System.Windows.Forms.Label();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV21)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cogToolBlockEditV21
            // 
            this.cogToolBlockEditV21.AllowDrop = true;
            this.cogToolBlockEditV21.ContextMenuCustomizer = null;
            this.cogToolBlockEditV21.Location = new System.Drawing.Point(-3, 27);
            this.cogToolBlockEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogToolBlockEditV21.Name = "cogToolBlockEditV21";
            this.cogToolBlockEditV21.ShowNodeToolTips = true;
            this.cogToolBlockEditV21.Size = new System.Drawing.Size(808, 410);
            this.cogToolBlockEditV21.SuspendElectricRuns = false;
            this.cogToolBlockEditV21.TabIndex = 0;
            // 
            // lbStatus
            // 
            this.lbStatus.Location = new System.Drawing.Point(3, 445);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(802, 23);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "Status";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.MenuClick_Event);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.MenuClick_Event);
            // 
            // oKToolStripMenuItem
            // 
            this.oKToolStripMenuItem.Name = "oKToolStripMenuItem";
            this.oKToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.oKToolStripMenuItem.Text = "OK";
            this.oKToolStripMenuItem.Click += new System.EventHandler(this.MenuClick_Event);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.runToolStripMenuItem,
            this.oKToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(807, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.MenuClick_Event);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // ToolBlockWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 468);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.cogToolBlockEditV21);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ToolBlockWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolBlockWindow_FormClosing);
            this.Load += new System.EventHandler(this.ToolBlockWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV21)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #endregion


    }
}
