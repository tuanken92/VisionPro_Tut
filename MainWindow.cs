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
using Cognex.VisionPro.Blob;

namespace VisionPro_Tut
{
    public partial class MainWindow : Form
    {
        #region declare variable, object 
        MyDefine common = null;
        ObjectManager objectManager = null;
        SaveLoadParameter settingParam = null;
        #endregion

        //Consider code
        public MainWindow()
        {
            InitializeComponent();
            Initial();
            UpdateUI();
        }

        #region funtion process
        void Initial()
        {
            common = new MyDefine();
            settingParam = new SaveLoadParameter();
            bool isLoadSuccess = settingParam.Load_Parameter(ref common);

            objectManager = new ObjectManager();
            objectManager.InitObject(common);
            objectManager.mToolBlock.Changed += MToolBlock_Changed;
            objectManager.mToolBlock.Running += MToolBlock_Running;
            objectManager.mToolBlock.Ran += MToolBlock_Ran;
            objectManager.mToolBlock.Inputs["FilterLowValue"].Value = common.blob_filter.area_low;
            objectManager.mToolBlock.Inputs["FilterHighValue"].Value = common.blob_filter.area_high;



            //gui
            //this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        }



        void UpdateUI()
        {
            lb_Toolblock.Text = common.file_vpp;
            lb_ImgDatabase.Text = common.file_image_database;
            tbAreaHighBlob.Text = common.blob_filter.area_high.ToString();
            tbAreaLowBlob.Text = common.blob_filter.area_low.ToString();
            nPass.Text = common.numOK.ToString();
            nFail.Text = common.numNG.ToString();
        }

        void UpdateParam()
        {
            common.file_image_database = lb_ImgDatabase.Text;
            common.file_vpp = lb_Toolblock.Text;
            common.blob_filter.area_high = Double.Parse(tbAreaHighBlob.Text);
            common.blob_filter.area_low = Double.Parse(tbAreaLowBlob.Text);

            common.Print_Infor();
        }

        void UpdateToolBlock()
        {

            objectManager.mToolBlock.Inputs["FilterLowValue"].Value = common.blob_filter.area_low;
            objectManager.mToolBlock.Inputs["FilterHighValue"].Value = common.blob_filter.area_high;
        }

        public void Display(bool result)
        {
            CogGraphicLabel cglCaption = new CogGraphicLabel();
            Font myFont = new Font("Comic Sans MS", 16, FontStyle.Bold);

            // Set it's text and alignment properties
            cglCaption.Text = result ? "PASS" : "FAIL";
            cglCaption.Color = result ? CogColorConstants.Green : CogColorConstants.Red;

            cglCaption.Alignment = CogGraphicLabelAlignmentConstants.BottomLeft;
            // .NET fonts are read only, so create a new font and then
            // push this font object onto the Font property of the label
            // myFont = new Font("Comic Sans MS", 18, FontStyle.Bold);                        

            cglCaption.Font = myFont;

            // Set its space to be '*' - anchored to the image
            cglCaption.SelectedSpaceName = "*";

            // Position the label over the CogDisplay
            cglCaption.X = 50;
            cglCaption.Y = 50;

            // Add the label to the CogDisplay
            cogRecordDisplay1.InteractiveGraphics.Add(cglCaption, cglCaption.Text, false);
            cglCaption.Dispose();
            myFont.Dispose();
        }

        #endregion

        #region Manager Event

        #region MToolBlock event

        private void MToolBlock_Changed(object sender, CogChangedEventArgs e)
        {
            // To see what has changed, look at the state flags that are contained in 
            // the CogChangedEventArgs object.  The StateFlags property is a bitfield,
            // where each bit represents a single element of the tool that may have changed.  If a bit
            // is asserted, that element in the tool has changed.  Multiple bits may be asserted
            // simultaneously.  To see what has changed, bitwise AND the StateFlags with the static
            // Sf**** members in the tool class.  If it returns a value greater than 0, then that
            // particular element has changed.  

            // In the example below, we are testing to see if the RunStatus property has changed
            // by bitwise AND'ing StateFlags with SfRunStatus.

            // Report error conditions, if any.
            Console.WriteLine("MToolBlock_Changed");
            if ((e.StateFlags & CogBlobTool.SfRunStatus) > 0)
            {
                if (objectManager.mToolBlock.RunStatus.Result == CogToolResultConstants.Error)
                    MessageBox.Show(objectManager.mToolBlock.RunStatus.Message);
            }
        }

        private void MToolBlock_Running(object sender, EventArgs e)
        {
            // Get input image.
            Console.WriteLine("MToolBlock_Running");
            //objectManager.mIFTool.Run();
            //objectManager.mToolBlock.Inputs["Image"].Value = objectManager.mIFTool.OutputImage as CogImage8Grey;
        }

        private void MToolBlock_Ran(object sender, EventArgs e)
        {
            // This method executes each time the TB runs
            bool result = (bool)(objectManager.mToolBlock.Outputs["InspectionPassed"].Value);
            if (result)
                objectManager.numPass++;
            else
                objectManager.numFail++;
            // Update the label with pass and fail
            nPass.Text = objectManager.numPass.ToString();
            nFail.Text = objectManager.numFail.ToString();

            CogBlobTool mBlobTool = objectManager.mToolBlock.Tools["CogBlobTool1"] as CogBlobTool;

            //Assign picture to display
            ICogRecord temp = mBlobTool.CreateLastRunRecord();
            //temp = temp.SubRecords["BlobImage"];
            temp = temp.SubRecords["InputImage"];
            cogRecordDisplay1.Record = temp;
            cogRecordDisplay1.Fit(true);

            Display(result);
            Console.WriteLine("Ran done!, time processing = {0} ms", objectManager.mToolBlock.RunStatus.TotalTime);
        }

        private void btn_Click_Event(object sender, EventArgs e)
        {
            var curButton = sender as Button;
            Console.WriteLine($"btn_Click_Event name = {curButton.Name}");
            switch (curButton.Name)
            {
                case "btnRun":
                    objectManager.RunOnce();
                    break;
                case "btnRunContinue":
                    settingParam.Save_Parameter(common);
                    break;
                case "btnSaveParam":
                    UpdateParam();
                    settingParam.Save_Parameter(common);
                    break;
                case "btnResetJob":
                    UpdateToolBlock();
                    break;
            }
        }
        #endregion


        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var strip_menu = sender as ToolStripMenuItem;
            Console.WriteLine("MenuItem click = {0}", strip_menu.Name);
            switch (strip_menu.Name)
            {
                case "loadToolStripMenuItem":
                    ToolBlockWindow win2 = new ToolBlockWindow(objectManager);
                    win2.Show();
                    break;

                case "saveToolStripMenuItem":
                    break;

                default:
                    break;
            }
        }

        private void label_Click_Event(object sender, EventArgs e)
        {
            var curLabel = sender as Label;
            Console.WriteLine($"label_Click_Event name = {curLabel.Name}");

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            //openFileDialog1.ReadOnlyChecked = true,
            openFileDialog1.ShowReadOnly = true;

            switch (curLabel.Name)
            {
                case "lb_ImgDatabase":
                    openFileDialog1.InitialDirectory = Utils.path_load_img_database;
                    openFileDialog1.Title = "Browse Image Database Files";
                    openFileDialog1.DefaultExt = "idb";
                    openFileDialog1.Filter = "idb files (*.idb)|*.idb|All files (*.*)|*.*";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        lb_ImgDatabase.Text = openFileDialog1.FileName;
                        common.file_image_database = lb_ImgDatabase.Text;
                    }

                    break;
                case "lb_Toolblock":
                    openFileDialog1.InitialDirectory = Utils.path_load_vpp_file;
                    openFileDialog1.Title = "Browse Toolblock Files";
                    openFileDialog1.DefaultExt = "vpp";
                    openFileDialog1.Filter = "vpp files (*.vpp)|*.vpp|All files (*.*)|*.*";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        lb_Toolblock.Text = openFileDialog1.FileName;
                        common.file_vpp = lb_Toolblock.Text;
                    }
                    break;
                default:
                    break;
            }
        }


        protected override void Dispose(bool disposing)
        {
            // Disconnect the event handlers before closing the form
            objectManager.mToolBlock.Ran -= new EventHandler(MToolBlock_Ran);
            objectManager.mToolBlock.Running -= new EventHandler(MToolBlock_Running);
            objectManager.mToolBlock.Changed -= new CogChangedEventHandler(MToolBlock_Changed);

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region timer for date-time display
        private void timer_DateTime_Tick(object sender, EventArgs e)
        {
            this.lbDateTime.Text = DateTime.Now.ToString("ddd MM/dd/yyyy\nhh:mm::ss tt");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.timer_DateTime.Start();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateParam();
            settingParam.Save_Parameter(common);
            this.timer_DateTime.Stop();

        }
        #endregion
    }
}
