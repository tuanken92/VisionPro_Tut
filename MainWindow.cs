using Basler.Pylon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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
            initCambasler();
        }

        void Initial()
        {
            //this.Shown += MainWindow_Shown;
            common = new MyDefine();
            settingParam = new SaveLoadParameter();
            bool isLoadSuccess = settingParam.Load_Parameter(ref common);

            objectManager = new ObjectManager();
            //objectManager.InitObject(common);
            //objectManager.mToolBlockProcess.Changed += mToolBlockProcess_Changed;
            //objectManager.mToolBlockProcess.Running += mToolBlockProcess_Running;
            //objectManager.mToolBlockProcess.Ran += mToolBlockProcess_Ran;
            //objectManager.mToolBlockProcess.Inputs["FilterLowValue"].Value = common.blob_filter.area_low;
            //objectManager.mToolBlockProcess.Inputs["FilterHighValue"].Value = common.blob_filter.area_high;


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

        private void MainWindow_Load(object sender, EventArgs e)
        {
           try
            {
                cur = Process.GetCurrentProcess();
                curpcp = new PerformanceCounter("Process", "Working Set - Private", cur.ProcessName);
                this.timer_DateTime.Start();
            }
            catch
            {

            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            
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
        private System.Windows.Forms.Timer timer;
        private Process cur = null;
        private PerformanceCounter curpcp = null;
        private const int MB_DIV = 1024 * 1024;

        private void timer_DateTime_Tick(object sender, EventArgs e)
        {
            if (curpcp != null)
            {
                string RamInfo = (curpcp.NextValue() / MB_DIV).ToString("F1") + "MB";
                this.lbDateTime.Text = DateTime.Now.ToString("ddd MM/dd/yyyy\nhh:mm:ss tt") + $"\r\nRam: {RamInfo}" ;
            }

        }



        #endregion

        #region camera begin

        private PixelDataConverter converter = new PixelDataConverter();
        Stopwatch stopWatch = new Stopwatch();

        void initCambasler()
        {
            // Set the default names for the controls.
            testImageControl.DefaultName = "Test Image Selector";
            pixelFormatControl.DefaultName = "Pixel Format";
            widthSliderControl.DefaultName = "Width";
            heightSliderControl.DefaultName = "Height";
            gainSliderControl.DefaultName = "Gain";
            exposureTimeSliderControl.DefaultName = "Exposure Time";

            // Update the list of available common.camera devices in the upper left area.
            UpdateDeviceList();

            // Disable all buttons.
            EnableButtons(false, false);
        }

        // Occurs when the single frame acquisition button is clicked.
        private void toolStripButtonOneShot_Click(object sender, EventArgs e)
        {
            OneShot(); // Start the grabbing of one image.
        }


        // Occurs when the continuous frame acquisition button is clicked.
        private void toolStripButtonContinuousShot_Click(object sender, EventArgs e)
        {
            ContinuousShot(); // Start the grabbing of images until grabbing is stopped.
        }


        // Occurs when the stop frame acquisition button is clicked.
        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            StopGrab(); // Stop the grabbing of images.
        }


        // Occurs when a device with an opened connection is removed.
        private void OnConnectionLost(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnConnectionLost), sender, e);
                return;
            }

            // Close the common.camera object.
            DestroyCamera();
            // Because one device is gone, the list needs to be updated.
            UpdateDeviceList();

            MessageBox.Show("Lost connection to camera");
        }


        // Helps to set the states of all buttons.
        private void EnableButtons(bool canGrab, bool canStop)
        {
            toolStripButtonContinuousShot.Enabled = canGrab;
            toolStripButtonOneShot.Enabled = canGrab && IsSingleShotSupported();
            toolStripButtonStop.Enabled = canStop;
        }

        // Stops the grabbing of images and handles exceptions.
        private void StopGrab()
        {
            // Stop the grabbing.
            try
            {
                common.camera.StreamGrabber.Stop();
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }


        // Checks if single shot is supported by the common.camera.
        public bool IsSingleShotSupported()
        {
            // Camera can be null if not yet opened
            if (common.camera == null)
            {
                return false;
            }

            // Camera can be closed
            if (!common.camera.IsOpen)
            {
                return false;
            }

            bool canSet = common.camera.Parameters[PLCamera.AcquisitionMode].CanSetValue("SingleFrame");
            return canSet;
        }


        // Occurs when the connection to a common.camera device is opened.
        private void OnCameraOpened(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnCameraOpened), sender, e);
                return;
            }

            // The image provider is ready to grab. Enable the grab buttons.
            EnableButtons(true, false);
        }


        // Occurs when the connection to a common.camera device is closed.
        private void OnCameraClosed(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnCameraClosed), sender, e);
                return;
            }

            // The common.camera connection is closed. Disable all buttons.
            EnableButtons(false, false);
        }


        // Occurs when a common.camera starts grabbing.
        private void OnGrabStarted(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnGrabStarted), sender, e);
                return;
            }

            // Reset the stopwatch used to reduce the amount of displayed images. The common.camera may acquire images faster than the images can be displayed.

            stopWatch.Reset();

            // Do not update the device list while grabbing to reduce jitter. Jitter may occur because the GUI thread is blocked for a short time when enumerating.
            updateDeviceListTimer.Stop();

            // The common.camera is grabbing. Disable the grab buttons. Enable the stop button.
            EnableButtons(false, true);
        }

        // Timer callback used to periodically check whether displayed common.camera devices are still attached to the PC.
        private void updateDeviceListTimer_Tick(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }

        // Updates the list of available common.camera devices.
        private void UpdateDeviceList()
        {
            try
            {
                // Ask the common.camera finder for a list of common.camera devices.
                List<ICameraInfo> allCameras = CameraFinder.Enumerate();

                ListView.ListViewItemCollection items = deviceListView.Items;

                // Loop over all cameras found.
                foreach (ICameraInfo cameraInfo in allCameras)
                {
                    // Loop over all cameras in the list of cameras.
                    bool newitem = true;
                    foreach (ListViewItem item in items)
                    {
                        ICameraInfo tag = item.Tag as ICameraInfo;

                        // Is the common.camera found already in the list of cameras?
                        if (tag[CameraInfoKey.FullName] == cameraInfo[CameraInfoKey.FullName])
                        {
                            tag = cameraInfo;
                            newitem = false;
                            break;
                        }
                    }

                    // If the common.camera is not in the list, add it to the list.
                    if (newitem)
                    {
                        // Create the item to display.
                        ListViewItem item = new ListViewItem(cameraInfo[CameraInfoKey.FriendlyName]);

                        // Create the tool tip text.
                        string toolTipText = "";
                        foreach (KeyValuePair<string, string> kvp in cameraInfo)
                        {
                            toolTipText += kvp.Key + ": " + kvp.Value + "\n";
                        }
                        item.ToolTipText = toolTipText;

                        // Store the common.camera info in the displayed item.
                        item.Tag = cameraInfo;

                        // Attach the device data.
                        deviceListView.Items.Add(item);
                    }
                }



                // Remove old common.camera devices that have been disconnected.
                foreach (ListViewItem item in items)
                {
                    bool exists = false;

                    // For each common.camera in the list, check whether it can be found by enumeration.
                    foreach (ICameraInfo cameraInfo in allCameras)
                    {
                        if (((ICameraInfo)item.Tag)[CameraInfoKey.FullName] == cameraInfo[CameraInfoKey.FullName])
                        {
                            exists = true;
                            break;
                        }
                    }
                    // If the common.camera has not been found, remove it from the list view.
                    if (!exists)
                    {
                        deviceListView.Items.Remove(item);
                    }
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }


        // Shows exceptions in a message box.
        private void ShowException(Exception exception)
        {
            MessageBox.Show("Exception caught:\n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Closes the common.camera object and handles exceptions.
        private void DestroyCamera()
        {
            // Disable all parameter controls.
            try
            {
                if (common.camera != null)
                {

                    testImageControl.Parameter = null;
                    pixelFormatControl.Parameter = null;
                    widthSliderControl.Parameter = null;
                    heightSliderControl.Parameter = null;
                    gainSliderControl.Parameter = null;
                    exposureTimeSliderControl.Parameter = null;
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }

            // Destroy the common.camera object.
            try
            {
                if (common.camera != null)
                {
                    common.camera.Close();
                    common.camera.Dispose();
                    common.camera = null;
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        // Starts the grabbing of a single image and handles exceptions.
        private void OneShot()
        {
            try
            {
                // Starts the grabbing of one image.
                Configuration.AcquireSingleFrame(common.camera, null);
                common.camera.StreamGrabber.Start(1, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }


        // Starts the continuous grabbing of images and handles exceptions.
        private void ContinuousShot()
        {
            try
            {
                // Start the grabbing of images until grabbing is stopped.
                Configuration.AcquireContinuous(common.camera, null);
                common.camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }


        // Occurs when a new common.camera has been selected in the list. Destroys the object of the currently opened common.camera device and
        // creates a new object for the selected common.camera device. After that, the connection to the selected common.camera device is opened.
        private void deviceListView_SelectedIndexChanged(object sender, EventArgs ev)
        {
            // Destroy the old common.camera object.
            if (common.camera != null)
            {
                DestroyCamera();
            }


            // Open the connection to the selected common.camera device.
            if (deviceListView.SelectedItems.Count > 0)
            {
                // Get the first selected item.
                ListViewItem item = deviceListView.SelectedItems[0];
                // Get the attached device data.
                ICameraInfo selectedCamera = item.Tag as ICameraInfo;
                try
                {
                    // Create a new common.camera object.
                    common.camera = new Camera(selectedCamera);

                    //common.camera.CameraOpened += Configuration.AcquireContinuous;

                    // Register for the events of the image provider needed for proper operation.
                    common.camera.ConnectionLost += OnConnectionLost;
                    common.camera.CameraOpened += OnCameraOpened;
                    common.camera.CameraClosed += OnCameraClosed;
                    common.camera.StreamGrabber.GrabStarted += OnGrabStarted;
                    common.camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;
                    common.camera.StreamGrabber.GrabStopped += OnGrabStopped;

                    // Open the connection to the common.camera device.
                    common.camera.Open();


                    // Set the parameter for the controls.
                    if (common.camera.Parameters[PLCamera.TestImageSelector].IsWritable)
                    {
                        testImageControl.Parameter = common.camera.Parameters[PLCamera.TestImageSelector];
                    }
                    else
                    {
                        testImageControl.Parameter = common.camera.Parameters[PLCamera.TestPattern];
                    }
                    pixelFormatControl.Parameter = common.camera.Parameters[PLCamera.PixelFormat];
                    widthSliderControl.Parameter = (IFloatParameter)common.camera.Parameters[PLCamera.Width];
                    heightSliderControl.Parameter = (IFloatParameter)common.camera.Parameters[PLCamera.Height];




                    if (common.camera.Parameters.Contains(PLCamera.GainAbs))
                    {
                        gainSliderControl.Parameter = common.camera.Parameters[PLCamera.GainAbs];
                    }
                    else
                    {
                        gainSliderControl.Parameter = common.camera.Parameters[PLCamera.Gain];
                    }
                    if (common.camera.Parameters.Contains(PLCamera.ExposureTimeAbs))
                    {
                        exposureTimeSliderControl.Parameter = common.camera.Parameters[PLCamera.ExposureTimeAbs];
                    }
                    else
                    {
                        exposureTimeSliderControl.Parameter = common.camera.Parameters[PLCamera.ExposureTime];
                    }


                    

                }
                catch (Exception exception)
                {
                    ShowException(exception);
                }
            }
        }

        // Occurs when an image has been acquired and is ready to be processed.
        private void OnImageGrabbed(Object sender, ImageGrabbedEventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper GUI thread.
                // The grab result will be disposed after the event call. Clone the event arguments for marshaling to the GUI thread.
                BeginInvoke(new EventHandler<ImageGrabbedEventArgs>(OnImageGrabbed), sender, e.Clone());
                return;
            }

            try
            {
                // Acquire the image from the common.camera. Only show the latest image. The common.camera may acquire images faster than the images can be displayed.

                // Get the grab result.
                IGrabResult grabResult = e.GrabResult;

                // Check if the image can be displayed.
                if (grabResult.IsValid)
                {
                    //tuanna-todo: care when live camera -> don't push frame to queue

                    

                    // Reduce the number of displayed images to a reasonable amount if the common.camera is acquiring images very fast.
                    if (!stopWatch.IsRunning || stopWatch.ElapsedMilliseconds > 33)
                    {
                        stopWatch.Restart();

                        Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                        // Lock the bits of the bitmap.
                        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                        // Place the pointer to the buffer of the bitmap.
                        converter.OutputPixelFormat = PixelType.BGRA8packed;
                        IntPtr ptrBmp = bmpData.Scan0;
                        converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult);
                        bitmap.UnlockBits(bmpData);

                        // Assign a temporary variable to dispose the bitmap after assigning the new bitmap to the display control.
                        Bitmap bitmapOld = pictureBox.Image as Bitmap;
                        // Provide the display control with the new bitmap. This action automatically updates the display.
                        pictureBox.Image = bitmap;
                        if (bitmapOld != null)
                        {
                            // Dispose the bitmap.
                            bitmapOld.Dispose();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Skip display, time process to long = {0}", stopWatch.ElapsedMilliseconds);
                    }

                    
                }
                else
                {
                    Console.WriteLine("Error: {0} {1}", grabResult.ErrorCode, grabResult.ErrorDescription);
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
            finally
            {
                // Dispose the grab result if needed for returning it to the grab loop.
                e.DisposeGrabResultIfClone();
            }
        }


        // Occurs when a MyParam.camera has stopped grabbing.
        private void OnGrabStopped(Object sender, GrabStopEventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<GrabStopEventArgs>(OnGrabStopped), sender, e);
                return;
            }

            // Reset the stopwatch.
            stopWatch.Reset();

            // Re-enable the updating of the device list.
            updateDeviceListTimer.Start();

            // The MyParam.camera stopped grabbing. Enable the grab buttons. Disable the stop button.
            EnableButtons(true, false);

            // If the grabbed stop due to an error, display the error message.
            if (e.Reason != GrabStopReason.UserRequest)
            {
                MessageBox.Show("A grab error occured:\n" + e.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // If the F5 key has been pressed, update the list of devices.
        private void deviceListView_KeyDown(object sender, KeyEventArgs ev)
        {
            if (ev.KeyCode == Keys.F5)
            {
                ev.Handled = true;
                // Update the list of available common.camera devices.
                UpdateDeviceList();
            }
        }


        /*
         
                        CogImage8Grey cogImage8Grey = new CogImage8Grey(MyParam.mat.ToBitmap());
                        //MyLib.Display(cogImage8Grey, MyParam.cogDisplay, true);


                        //process
                        MyParam.toolBlockProcess.Inputs["Image"].Value = cogImage8Grey;
                        MyParam.toolBlockProcess.Run();
                        cogImage8Grey.Dispose();
                        MyParam.mat.Dispose();

         */

        #endregion camera end
    }
}
