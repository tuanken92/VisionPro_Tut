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
        

        void Thread_Run_Continuously()
        {
            try
            {
                while (isRunContinue)
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
        void Thread_Control_By_Interface()
        {
            try
            {
                while (run_thread)
                {
                    Thread.Sleep(100);
                    if (interfaceManager.data_receive != null)
                    {
                        Console.WriteLine(interfaceManager.data_receive);
                        switch (interfaceManager.data_receive)
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
                        interfaceManager.data_receive = null;
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
