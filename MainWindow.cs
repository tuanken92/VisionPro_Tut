using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionPro_Tut.Windows;
using VisionPro_Tut.Source;
using Cognex.VisionPro;

namespace VisionPro_Tut
{
    public partial class MainWindow : Form
    {

        //manager variale, object here
        #region declare variable, object 
        ObjectManager objectManager = null;

        #endregion


        void Initial()
        {
            objectManager = new ObjectManager();
            objectManager.InitObject();
            objectManager.mToolBlock.Ran += MToolBlock_Ran;
            //objectManager.mToolBlock.Inputs["FilterLowValue"].Value = nAreaLow.Value;
            //objectManager.mToolBlock.Inputs["FilterHighValue"].Value = nAreaHigh.Value;

        }




        //Consider code
        public MainWindow()
        {
            InitializeComponent();
            Initial();
        }


        #region manager event here
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("load tool block");
            ToolBlockWindow win2 = new ToolBlockWindow(objectManager);
            win2.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("save tool block");
        }

     

        private void MToolBlock_Ran(object sender, EventArgs e)
        {
            // This method executes each time the TB runs
            if ((bool)(objectManager.mToolBlock.Outputs["InspectionPassed"].Value) == true)
                objectManager.numPass++;
            else
                objectManager.numFail++;
            // Update the label with pass and fail
            nPass.Text = objectManager.numPass.ToString();
            nFail.Text = objectManager.numFail.ToString();
            // Update the CogDisplayRecord with the lastRunRecord

            //CogBlobTool mBlobTool = objectManager.mToolBlock.Tools["CogBlobTool1"] as CogBlobTool;
            //cogRecordDisplay1.Record = mBlobTool.CreateLastRunRecord();

            //// Update the CogDisplayRecord with the image 
            //cogRecordDisplay1.Image = objectManager.mToolBlock.Inputs["Image"].Value as CogImage8Grey;
            //cogRecordDisplay1.Fit(true);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Get the next image
            objectManager.RunOnce();

        }

        private void btnRunContinue_Click(object sender, EventArgs e)
        {
            objectManager.RunOnce();
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            // Disconnect the event handlers before closing the form
            objectManager.mToolBlock.Ran -= new EventHandler(MToolBlock_Ran);

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
