using Cognex.VisionPro;
using System;
using System.Drawing;
using System.Threading;
using VisionPro_Tut.Source;
using VisionPro_Tut.Source.Interface;

namespace VisionPro_Tut
{
    public partial class MainWindow
    {
        #region funtion process
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

            serialPort = new MySerialPort(common.serial_port);
            Console.WriteLine($"create_serialport = {serialPort.is_success}");

            //mode run
            switch (common.mode_run)
            {
                case Utils.MODE_RUN.Manual:
                    myThread = new Thread(new ThreadStart(Thread_Run_Continuously));
                    myThread.Name = "Thread Control by Manual";
                    myThread.IsBackground = true;
                    run_thread = false;
                    break;
                case Utils.MODE_RUN.SerialPort:

                    if (serialPort.is_success)
                        serialPort.Connect();
                    myThread = new Thread(new ThreadStart(Thread_Control_By_Serial_Port));
                    myThread.Name = "Thread Control by SeriablPort";
                    myThread.IsBackground = true;
                    run_thread = true;
                    myThread.Start();
                    break;
                case Utils.MODE_RUN.TCP:
                    break;
            }

            //care thread ui + thread process
            CheckForIllegalCrossThreadCalls = false;
        }

        void Thread_Run_Continuously()
        {
            try
            {
                while (run_thread)
                {
                    Thread.Sleep(1000);

                    //TODO: care timeout processing
                    objectManager.RunOnce();

                }
                Console.WriteLine(Thread.CurrentThread.Name + "end");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} exception: {e.ToString()}");
            }

        }
        void Thread_Control_By_Serial_Port()
        {
            try
            {
                while (run_thread)
                {
                    Thread.Sleep(100);
                    if (serialPort.DataReceived != null)
                    {
                        switch (serialPort.DataReceived.ToString())
                        {
                            case Utils.TRIGGER:
                                run_continue = false;
                                objectManager.RunOnce();
                                break;
                            case Utils.RUNLOOP:
                                run_continue = true;
                                objectManager.RunOnce();
                                break;
                            default:
                                break;
                        }
                        serialPort.DataReceived.Clear();
                        serialPort.DataReceived = null;
                    }
                }
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} exception: {e.ToString()}");
            }

        }


        void UpdateToolBlock()
        {
            objectManager.mToolBlockProcess.Inputs["FilterLowValue"].Value = common.blob_filter.area_low;
            objectManager.mToolBlockProcess.Inputs["FilterHighValue"].Value = common.blob_filter.area_high;
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
    }
}
