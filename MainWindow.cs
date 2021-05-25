using System;
using System.Threading;
using System.Windows.Forms;
using VisionPro_Tut.Source;
using VisionPro_Tut.Source.Interface;

namespace VisionPro_Tut
{
    public partial class MainWindow : Form
    {
        #region Declare_variable_object 
        MyDefine common = null;
        ObjectManager objectManager = null;
        SaveLoadParameter settingParam = null;

        MySerialPort serialPort = null;
        TcpChatClient chatClient = null;
        TcpChatServer chatServer = null;

        InterfaceManager interfaceManager = null;

        Thread thread_control_by_interface = null;
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

        void Initial()
        {
            common = new MyDefine();
            settingParam = new SaveLoadParameter();
            bool isLoadSuccess = settingParam.Load_Parameter(ref common);

            objectManager = new ObjectManager();
            objectManager.InitObject(common);
            objectManager.mToolBlockProcess.Changed += mToolBlockProcess_Changed;
            objectManager.mToolBlockProcess.Running += mToolBlockProcess_Running;
            objectManager.mToolBlockProcess.Ran += mToolBlockProcess_Ran;
            objectManager.mToolBlockProcess.Inputs["FilterLowValue"].Value = common.blob_filter.area_low;
            objectManager.mToolBlockProcess.Inputs["FilterHighValue"].Value = common.blob_filter.area_high;


            interfaceManager = new InterfaceManager(common);
            //mode run
            switch (common.mode_run)
            {
                case Utils.MODE_RUN.Manual:
                    break;
                case Utils.MODE_RUN.SerialPort:
                case Utils.MODE_RUN.TCP_Client:
                case Utils.MODE_RUN.TCP_Server:
                    run_thread = true;
                    thread_control_by_interface = new Thread(new ThreadStart(Thread_Control_By_Interface));
                    thread_control_by_interface.Name = "Thread control by interface";
                    thread_control_by_interface.IsBackground = true;
                    thread_control_by_interface.Priority = ThreadPriority.AboveNormal;
                    thread_control_by_interface.Start();
                    break;
            }

            //care thread ui + thread process
            CheckForIllegalCrossThreadCalls = false;
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
            var list_com = Utils.Scan_Comport();
            for (int i = 0; i < list_com.Count; i++)
                cbb_Comport.Items.Add(list_com[i]);
            cbb_Comport.Text = common.serial_port.com_name;

            //tcp server
            tb_ServerIP.Text = common.tcp_server.ip;
            tb_ServerPort.Text = common.tcp_server.port.ToString();

            //tcp client
            tb_ClientIP.Text = common.tcp_client.ip;
            tb_ClientPort.Text = common.tcp_client.port.ToString();

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

            //tcp server
            common.tcp_server.ip = tb_ServerIP.Text;
            common.tcp_server.port = int.Parse(tb_ServerPort.Text);

            //tcp client
            common.tcp_client.ip = tb_ClientIP.Text;
            common.tcp_client.port = int.Parse(tb_ClientPort.Text);

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
            this.interfaceManager.CloseInterface();
            this.run_thread = false;
            //this.thread_control_by_interface.Abort();

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
