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
using VisionPro_Tut.Source.Interface;
using System.Threading;

namespace VisionPro_Tut
{
    public partial class MainWindow : Form
    {
        #region Declare_variable_object 
        MyDefine common = null;
        ObjectManager objectManager = null;
        SaveLoadParameter settingParam = null;

        MySerialPort serialPort = null;
        Thread myThread = null;
        bool run_thread = false;
        bool run_continue = false;
        #endregion

        //Consider code
        public MainWindow()
        {
            InitializeComponent();
            Initial();
            UpdateUI();
        }

        void UpdateUI()
        {
            lb_Toolblock_Process.Text = common.file_toolblock_process;
            lb_Toolblock_AcqFifo.Text = common.file_toolblock_acq;
            lb_ImgDatabase.Text = common.file_image_database;
            cb_UseCamera.Checked = common.use_camera;
            //result
            nPass.Text = common.numOK.ToString();
            nFail.Text = common.numNG.ToString();

            //param
            tbAreaHighBlob.Text = common.blob_filter.area_high.ToString();
            tbAreaLowBlob.Text = common.blob_filter.area_low.ToString();

            //cb_Comport
            for (int i = 0; i < serialPort.list_comport.Count; i++)
                cbb_Comport.Items.Add(serialPort.list_comport[i]);
            cbb_Comport.Text = common.serial_port.com_name;

            //cb_Baudrate binding with list baudrate
            var bindingBaudrate = new BindingSource();
            bindingBaudrate.DataSource = Utils.list_baudrate;
            cbb_Baudrate.DataSource = bindingBaudrate.DataSource;
            cbb_Baudrate.Text = common.serial_port.baudrate.ToString();

            //cb_Mode_Run
            var bindingModeRun = new BindingSource();
            bindingModeRun.DataSource = Enum.GetValues(typeof(Utils.MODE_RUN));
            cbb_ModeRun.DataSource = bindingModeRun.DataSource;
            cbb_ModeRun.Text = common.mode_run.ToString();

            

        }

        void UpdateParam()
        {
            common.file_image_database = lb_ImgDatabase.Text;
            common.file_toolblock_process = lb_Toolblock_Process.Text;
            common.file_toolblock_acq = lb_Toolblock_AcqFifo.Text;
            common.use_camera = cb_UseCamera.Checked;
            //param
            common.blob_filter.area_high = Double.Parse(tbAreaHighBlob.Text);
            common.blob_filter.area_low = Double.Parse(tbAreaLowBlob.Text);

            //serial port
            common.serial_port.com_name = cbb_Comport.Text;
            common.serial_port.baudrate = int.Parse(cbb_Baudrate.Text);

            //mode run
            Enum.TryParse<Utils.MODE_RUN>(cbb_ModeRun.SelectedValue.ToString(), out common.mode_run);

            //result
            common.numOK = objectManager.numPass;
            common.numNG = objectManager.numFail;

            common.Print_Infor();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.timer_DateTime.Start();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer_DateTime.Stop();
            serialPort.Disconnect();

            //save param before close form
            UpdateParam();
            settingParam.Save_Parameter(common);
            objectManager.ReleaseObject();
        }


        #region Datetime_display
        private void timer_DateTime_Tick(object sender, EventArgs e)
        {
            this.lbDateTime.Text = DateTime.Now.ToString("ddd MM/dd/yyyy\nhh:mm::ss tt");
        }

        #endregion
    }
}
