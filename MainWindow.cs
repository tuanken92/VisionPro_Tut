using OpenCvSharp;
using OpenCvSharp.Extensions;
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

            if(false)
            {
                objectManager = new ObjectManager();
                objectManager.InitObject(common);
                objectManager.mToolBlockProcess.Changed += mToolBlockProcess_Changed;
                objectManager.mToolBlockProcess.Running += mToolBlockProcess_Running;
                objectManager.mToolBlockProcess.Ran += mToolBlockProcess_Ran;
                //try
                //{
                //    objectManager.mToolBlockProcess.Inputs["FilterLowValue"].Value = common.blob_filter.area_low;
                //    objectManager.mToolBlockProcess.Inputs["FilterHighValue"].Value = common.blob_filter.area_high;
                //}
                //catch(Exception e)
                //{
                //    MessageBox.Show(e.Message);
                //}
            }




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


            tabControl_Main.SelectTab(tabPage_Manual);

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
            if(false)
            {
                common.numOK = objectManager.numPass;
                common.numNG = objectManager.numFail;
            }

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
            if(false)
                objectManager.ReleaseObject();
        }


        #region Datetime_display
        private void timer_DateTime_Tick(object sender, EventArgs e)
        {
            this.lbDateTime.Text = DateTime.Now.ToString("ddd MM/dd/yyyy\nhh:mm::ss tt");
        }




        #endregion

        private void btnLoadImg_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            //openFileDialog1.ReadOnlyChecked = true,
            openFileDialog1.ShowReadOnly = true;

            
            openFileDialog1.InitialDirectory = Utils.path_load_img_database;
            openFileDialog1.Title = "Browse Image Files";
            openFileDialog1.DefaultExt = "bmp";
            openFileDialog1.Filter = "bitmap files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path_img.Text = openFileDialog1.FileName;
                
                try
                {
                    MyParam.source_img = Cv2.ImRead(openFileDialog1.FileName);
                    if(!MyParam.source_img.Empty())
                    {
                        Display_img(MyParam.source_img);
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                
            }

            
        }

        void Display_img(Mat frameMat)
        {
            var frameBitmap = BitmapConverter.ToBitmap(frameMat);
            display_img.Image?.Dispose();
            display_img.Image = frameBitmap;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (MyParam.source_img.Empty())
                return;

            var grid_x = (int)(grid_cell_x.Value);
            var grid_y = (int)(grid_cell_y.Value);

            int width = MyParam.source_img.Width;
            int height = MyParam.source_img.Height;

            int number_rows = (int)(height / grid_x);
            int number_cols = (int)(width / grid_y);

            MyParam.draw_img = MyParam.source_img.Clone();
            //draw cols
            int number_cols_test = 0;
            for (int i = 0; i < width; i+=grid_x)
            {
                
                Cv2.Line(MyParam.draw_img, new Point(i, 0), new Point(i, height), new Scalar(255, 0, 0));
                number_cols_test++;
            }

            //draw rows
            int number_rows_test = 0;
            for (int j = 0; j < height; j += grid_y)
            {
                Cv2.Line(MyParam.draw_img, new Point(0, j), new Point(width, j), new Scalar(0, 255, 255));
                number_rows_test++;
            }

            Display_img(MyParam.draw_img);
            //draw_img.Release();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!MyParam.source_img.Empty())
            {
                Display_img(MyParam.source_img);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MyParam.draw_img.Empty())
                return;

            var file_save = MyLib.GenNameImg();
            bool b = Cv2.ImWrite(file_save, MyParam.draw_img);
            Console.WriteLine($"save Image {file_save} = {b}");
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            if (MyParam.source_img.Empty())
                return;

            if (MyParam.gray_img == null)
                MyParam.gray_img = new Mat(MyParam.source_img.Size(), MatType.CV_8UC1);

            if (MyParam.source_img.Channels() == 3)
            {
                Cv2.CvtColor(MyParam.source_img, MyParam.gray_img, ColorConversionCodes.BGR2GRAY);
            }
            else
            {
                MyParam.gray_img = MyParam.source_img.Clone();
            }

            Display_img(MyParam.gray_img);
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            if (MyParam.gray_img.Empty())
                return;

            if (MyParam.blur_img == null)
                MyParam.blur_img = new Mat(MyParam.source_img.Size(), MatType.CV_8UC1);

            Cv2.Blur(MyParam.gray_img, MyParam.blur_img, new OpenCvSharp.Size(3, 3));

            Display_img(MyParam.blur_img);

        }

        private void btnBinary_Click(object sender, EventArgs e)
        {
            if (MyParam.blur_img.Empty())
                return;

            if (MyParam.bin_img == null)
                MyParam.bin_img = new Mat(MyParam.source_img.Size(), MatType.CV_8UC1);

            Cv2.Threshold(MyParam.blur_img, MyParam.bin_img, VisionParam.thresh_binary, 255, ThresholdTypes.Binary);

            Display_img(MyParam.bin_img);

        }

        private void btnHistogram_Click(object sender, EventArgs e)
        {
            // Histogram view
            const int Width = 260, Height = 200;
            var render = new Mat(new Size(Width, Height), MatType.CV_8UC3, Scalar.All(255));

            // Calculate histogram
            var hist = new Mat();
            int[] hdims = { 256 }; // Histogram size for each dimension
            Rangef[] ranges = { new Rangef(0, 256), }; // min/max 
            Cv2.CalcHist(
                new Mat[] { MyParam.bin_img },
                new int[] { 0 },
                null,
                hist,
                1,
                hdims,
                ranges);

            // Get the max value of histogram
            Cv2.MinMaxLoc(hist, out _, out double maxVal);

            var color = Scalar.All(100);
            // Scales and draws histogram
            hist = hist * (maxVal != 0 ? Height / maxVal : 0.0);
            for (int j = 0; j < hdims[0]; ++j)
            {
                int binW = (int)((double)Width / hdims[0]);
                render.Rectangle(
                    new Point(j * binW, render.Rows - (int)hist.Get<float>(j)),
                    new Point((j + 1) * binW, render.Rows),
                    color,
                    -1);
            }

            Window  histogram_wd = new Window("Histogram", render, WindowFlags.AutoSize | WindowFlags.FreeRatio);
            //histogram_wd.ShowImage()
            Cv2.WaitKey();

            Cv2.DestroyAllWindows();
        }

        private void btnBlob_Click(object sender, EventArgs e)
        {
            
            MyParam.contour_img = MyParam.source_img.Clone();

            Point[][] contours; //vector<vector<Point>> contours;
            HierarchyIndex[] hierarchyIndexes; //vector<Vec4i> hierarchy;

            Cv2.FindContours(
                   MyParam.bin_img,
                   out contours,
                   out hierarchyIndexes,
                   RetrievalModes.List,
                   ContourApproximationModes.ApproxSimple);

            Cv2.DrawContours(
                            MyParam.contour_img,
                            contours,
                            -1,
                            new Scalar(0,255,0),
                            thickness: 2,
                            lineType: LineTypes.Link8,
                            hierarchy: hierarchyIndexes,
                            maxLevel: int.MaxValue);

            Display_img(MyParam.contour_img);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtThreshBinary_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtThreshBinary.Text))
                return;

            VisionParam.thresh_binary = Int32.Parse(txtThreshBinary.Text.Trim());
        }
    }
}
