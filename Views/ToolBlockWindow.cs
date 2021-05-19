using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        ObjectManager objectManager;
        #endregion


        public ToolBlockWindow()
        {
            Console.WriteLine("Tool block window default");
            InitializeComponent();
        }

        public ToolBlockWindow(ObjectManager objectManager)
        {
            Console.WriteLine("Tool block window create");
            this.objectManager = objectManager;
            InitializeComponent();
        }


        private void ToolBlockWindow_Load(object sender, EventArgs e)
        {
            //Load Toolblock and show on window
            Console.WriteLine("ToolBlockWindow_Load");

            cogToolBlockEditV21.LocalDisplayVisible = false;

            cogToolBlockEditV21.Subject = this.objectManager.mToolBlock;
            
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
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarV21;
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
            this.cogDisplayStatusBarV21 = new Cognex.VisionPro.CogDisplayStatusBarV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogToolBlockEditV21
            // 
            this.cogToolBlockEditV21.AllowDrop = true;
            this.cogToolBlockEditV21.ContextMenuCustomizer = null;
            this.cogToolBlockEditV21.Location = new System.Drawing.Point(-3, 1);
            this.cogToolBlockEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogToolBlockEditV21.Name = "cogToolBlockEditV21";
            this.cogToolBlockEditV21.ShowNodeToolTips = true;
            this.cogToolBlockEditV21.Size = new System.Drawing.Size(808, 410);
            this.cogToolBlockEditV21.SuspendElectricRuns = false;
            this.cogToolBlockEditV21.TabIndex = 0;
            // 
            // lbStatus
            // 
            this.lbStatus.Location = new System.Drawing.Point(3, 425);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(480, 23);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "Status";
            // 
            // cogDisplayStatusBarV21
            // 
            this.cogDisplayStatusBarV21.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarV21.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarV21.Location = new System.Drawing.Point(489, 425);
            this.cogDisplayStatusBarV21.Name = "cogDisplayStatusBarV21";
            this.cogDisplayStatusBarV21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarV21.Size = new System.Drawing.Size(316, 22);
            this.cogDisplayStatusBarV21.TabIndex = 2;
            this.cogDisplayStatusBarV21.Use3DCoordinateSpaceTree = false;
            // 
            // ToolBlockWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 451);
            this.Controls.Add(this.cogDisplayStatusBarV21);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.cogToolBlockEditV21);
            this.Name = "ToolBlockWindow";
            this.Text = "ToolBlockWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolBlockWindow_FormClosing);
            this.Load += new System.EventHandler(this.ToolBlockWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #endregion
    }
}
