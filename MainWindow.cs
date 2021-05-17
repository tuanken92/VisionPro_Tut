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

        //manager variale, object here
        #region declare variable, object 
        MyDefine common = null;
        ObjectManager objectManager = null;
        SaveLoadParameter settingParam = null;
        #endregion


        void Initial()
        {
            common = new MyDefine();
            settingParam = new SaveLoadParameter();
            bool isLoadSuccess = settingParam.Load_Parameter(ref common);

            objectManager = new ObjectManager();
            objectManager.InitObject(common);
            objectManager.mToolBlock.Ran += MToolBlock_Ran;
            //objectManager.mToolBlock.Inputs["FilterLowValue"].Value = nAreaLow.Value;
            //objectManager.mToolBlock.Inputs["FilterHighValue"].Value = nAreaHigh.Value;



            //gui
            //this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        }

        void UpdateUI()
        {
            lb_Toolblock.Text = common.file_vpp;
            lb_ImgDatabase.Text = common.file_image_database;
        }

        void UpdateParam()
        {
            common.file_image_database = lb_ImgDatabase.Text;
            common.file_vpp = lb_Toolblock.Text;
            common.Print_Infor();
        }
        //Consider code
        public MainWindow()
        {
            InitializeComponent();
            Initial();
            UpdateUI();
        }


        #region manager event here
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("load tool block");
            objectManager.UpdateData(common);
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

            CogBlobTool mBlobTool = objectManager.mToolBlock.Tools["CogBlobTool1"] as CogBlobTool;
            cogRecordDisplay1.Record = mBlobTool.CreateLastRunRecord();

            // Update the CogDisplayRecord with the image 
            cogRecordDisplay1.Image = objectManager.mToolBlock.Inputs["Image"].Value as CogImage8Grey;
            cogRecordDisplay1.Fit(true);
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
            }
        }

        private void label_Click_Event(object sender, EventArgs e)
        {
            var curLabel= sender as Label;
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

        #region timer for date-time
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
            this.timer_DateTime.Stop();
        }
        #endregion
    }
}
