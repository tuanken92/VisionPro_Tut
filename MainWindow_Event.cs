using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.PMAlign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using VisionPro_Tut.Source;
using VisionPro_Tut.Source.Interface;
using VisionPro_Tut.Windows;

namespace VisionPro_Tut
{
    public partial class MainWindow
    {
        #region CogToolBlock_event
        private void mToolBlockProcess_Changed(object sender, CogChangedEventArgs e)
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
            Console.WriteLine("mToolBlockProcess_Changed");
            if ((e.StateFlags & CogBlobTool.SfRunStatus) > 0)
            {
                if (objectManager.mToolBlockProcess.RunStatus.Result == CogToolResultConstants.Error)
                    Console.WriteLine(objectManager.mToolBlockProcess.RunStatus.Message);
            }
        }

        private void mToolBlockProcess_Running(object sender, EventArgs e)
        {
            // Get input image.
            Console.WriteLine("mToolBlockProcess_Running");
        }


        string Blob_Packet(CogBlobResult blob)
        {
            return String.Format($"{objectManager.mToolBlockProcess.RunStatus.Result},ID={blob.ID},angle={blob.Angle},x={blob.CenterOfMassX},y={blob.CenterOfMassY}\r\n");
        }
        private void mToolBlockProcess_Ran_Old(object sender, EventArgs e)
        {
            // This method executes each time the TB runs
            bool result = (bool)(objectManager.mToolBlockProcess.Outputs["InspectionPassed"].Value);
            if (result)
                objectManager.numPass++;
            else
                objectManager.numFail++;
            // Update the label with pass and fail
            nPass.Text = objectManager.numPass.ToString();
            nFail.Text = objectManager.numFail.ToString();

            CogBlobTool mBlobTool = objectManager.mToolBlockProcess.Tools["CogBlobTool1"] as CogBlobTool;

            //get result
            var blobResult = mBlobTool.Results;
            var all_blob = blobResult.GetBlobs();
            Console.WriteLine($"number blob detected = {all_blob.Count}");
            for (int i = 0; i < all_blob.Count; i++)
                interfaceManager.SendMessage(Blob_Packet(all_blob[i]));

            //var blobRunParam = mBlobTool.RunParams;

            //Assign picture to display
            ICogRecord temp = mBlobTool.CreateLastRunRecord();
            //temp = temp.SubRecords["BlobImage"];
            temp = temp.SubRecords["InputImage"];
            cogRecordDisplay1.Record = temp;
            cogRecordDisplay1.Fit(true);

            Display(result);
            Console.WriteLine("Ran done!, time processing = {0} ms", objectManager.mToolBlockProcess.RunStatus.TotalTime);
        }

        private void mToolBlockProcess_Ran(object sender, EventArgs e)
        {
            // This method executes each time the TB runs
            var output_img = (objectManager.mToolBlockProcess.Outputs["Output"]);
            //if (result)
            //    objectManager.numPass++;
            //else
            //    objectManager.numFail++;
            //// Update the label with pass and fail
            //nPass.Text = objectManager.numPass.ToString();
            //nFail.Text = objectManager.numFail.ToString();

            CogPMAlignTool cogPMAlignTool = objectManager.mToolBlockProcess.Tools["CogPMAlignTool1"] as CogPMAlignTool;
            CogFixtureTool mCogFixtureTool= objectManager.mToolBlockProcess.Tools["CogFixtureTool1"] as CogFixtureTool;

            var input_img = cogPMAlignTool.InputImage;
            CogTransform2DLinear pose = cogPMAlignTool.Results[0].GetPose();
            Console.WriteLine("pose = " + pose.ToString());
            var out_img = mCogFixtureTool.OutputImage;


            ICogTransform2D fromSelectedToPixelTransform = cogPMAlignTool.InputImage.GetTransform("#", ".");
            CogTransform2DLinear fromPatternToPixelLinearTransform = fromSelectedToPixelTransform.ComposeBase(pose).LinearTransform(0, 0);

            ////get result
            //var blobResult = mBlobTool.Results;
            //var all_blob = blobResult.GetBlobs();
            //Console.WriteLine($"number blob detected = {all_blob.Count}");
            //for (int i = 0; i < all_blob.Count; i++)
            //    interfaceManager.SendMessage(Blob_Packet(all_blob[i]));

            ////var blobRunParam = mBlobTool.RunParams;

            ////Assign picture to display
            //ICogRecord temp = mBlobTool.CreateLastRunRecord();
            ////temp = temp.SubRecords["BlobImage"];
            //temp = temp.SubRecords["InputImage"];
            //cogRecordDisplay1.Record = temp;
            //cogRecordDisplay1.Fit(true);


            ICogRecord temp = mCogFixtureTool.CreateLastRunRecord();
            //temp = temp.SubRecords["BlobImage"];
            temp = temp.SubRecords["OutputImage"];
            cogRecordDisplay1.Record = temp;
            cogRecordDisplay1.Fit(true);

            //Display(result);
            Console.WriteLine("Ran done!, time processing = {0} ms", objectManager.mToolBlockProcess.RunStatus.TotalTime);
        }
        #endregion

        #region GUI_event
        static bool isPressRunContinue = false;
        static bool isPressClientConnect = false;
        static bool isPressServerListen = false;
        static bool isRunContinue = false;
        Thread thread_run_continue = null;
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
                    if(!isPressRunContinue)
                    {
                        
                        try
                        {
                            isRunContinue = true;
                            thread_run_continue = new Thread(new ThreadStart(Thread_Run_Continuously));
                            thread_run_continue.Name = "thread run continue";
                            thread_run_continue.IsBackground = true;
                            thread_run_continue.Start();

                        }
                        catch (ThreadStateException ee)
                        {
                            Console.WriteLine("Caught: {0}", ee.Message);
                        }

                    }
                    else
                    {
                        isRunContinue = false;
                        //thread_run_continue.Abort();
                        
                    }
                    isPressRunContinue = !isPressRunContinue;
                    break;
                case "btnSaveParam":
                    UpdateParam();
                    settingParam.Save_Parameter(common);
                    break;
                case "btnInitial":
                    UpdateToolBlock();
                    break;

                case "btn_ClientConnect":
                    {
                        
                        if (!isPressClientConnect)
                        {
                            if(chatClient.Connect())
                            {
                                isPressClientConnect = true;
                                btn_ClientConnect.Text = "Disconnect";
                            }
                        }
                        else
                        {
                            if(chatClient.DisConnect())
                            {
                                isPressClientConnect = false;
                                btn_ClientConnect.Text = "Connect";
                            }
                        }
                    }
                    
                    break;
                case "btn_ClientSend":
                    chatClient.SendMessage(tx_ClientData2Send.Text);
                    break;
                case "btn_ServerListen":
                    {

                        if (!isPressServerListen)
                        {
                            if (chatServer.Listen())
                            {
                                isPressServerListen = true;
                                btn_ServerListen.Text = "Stop";
                            }
                        }
                        else
                        {
                            if (chatServer.Stop())
                            {
                                isPressServerListen = false;
                                btn_ServerListen.Text = "Listen";
                            }
                        }
                    }
                    break;
                case "btn_ServerSend":
                    chatServer.SendMessage(tb_ServerData2Send.Text);
                    break;
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var strip_menu = sender as ToolStripMenuItem;
            Console.WriteLine("MenuItem click = {0}", strip_menu.Name);
            switch (strip_menu.Name)
            {
                case "load_ImageProcessItem":
                    ToolBlockWindow win2 = new ToolBlockWindow(objectManager, common.file_toolblock_process, Utils.TYPE_OF_TOOLBLOCK.ImageProcess);
                    if (win2.ShowDialog() == DialogResult.OK)
                    {
                        objectManager.mToolBlockProcess = win2.objectManager.mToolBlockProcess;
                        objectManager.ToolBlock_PrintInfor(objectManager.mToolBlockProcess);
                        Console.WriteLine("update done {0}", objectManager.mToolBlockProcess.Name);
                    }
                    win2.Dispose();
                    break;

                case "load_AcqFifoItem":
                    if(!common.use_camera)
                    {
                        System.Windows.Forms.MessageBox.Show("Warning","You not using camera, please recheck!", MessageBoxButtons.OK);
                        break;
                    }
                    ToolBlockWindow win3 = new ToolBlockWindow(objectManager, common.file_toolblock_acq, Utils.TYPE_OF_TOOLBLOCK.AcqFifo);
                    if (win3.ShowDialog() == DialogResult.OK)
                    {
                        objectManager.mToolBlockAcq = win3.objectManager.mToolBlockAcq;
                        objectManager.ToolBlock_PrintInfor(objectManager.mToolBlockAcq);
                        Console.WriteLine("update done {0}", objectManager.mToolBlockAcq.Name);
                    }
                    win3.Dispose();
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
                        lb_Toolblock_Process.Text = openFileDialog1.FileName;
                        common.file_toolblock_process = lb_Toolblock_Process.Text;
                    }
                    break;
                case "lb_Toolblock_Process":
                    openFileDialog1.InitialDirectory = Utils.path_load_vpp_file;
                    openFileDialog1.Title = "Browse Toolblock_ImageProcess Files";
                    openFileDialog1.DefaultExt = "vpp";
                    openFileDialog1.Filter = "vpp files (*.vpp)|*.vpp|All files (*.*)|*.*";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        lb_Toolblock_Process.Text = openFileDialog1.FileName;
                        common.file_toolblock_process = lb_Toolblock_Process.Text;
                    }
                    break;                
                case "lb_Toolblock_AcqFifo":
                    openFileDialog1.InitialDirectory = Utils.path_load_vpp_file;
                    openFileDialog1.Title = "Browse Toolblock_Acq Files";
                    openFileDialog1.DefaultExt = "vpp";
                    openFileDialog1.Filter = "vpp files (*.vpp)|*.vpp|All files (*.*)|*.*";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        lb_Toolblock_AcqFifo.Text = openFileDialog1.FileName;
                        common.file_toolblock_acq = lb_Toolblock_AcqFifo.Text;
                    }
                    break;
                default:
                    break;
            }
        }


        protected override void Dispose(bool disposing)
        {
            // Disconnect the event handlers before closing the form
            objectManager.mToolBlockProcess.Ran -= new EventHandler(mToolBlockProcess_Ran);
            objectManager.mToolBlockProcess.Running -= new EventHandler(mToolBlockProcess_Running);
            objectManager.mToolBlockProcess.Changed -= new CogChangedEventHandler(mToolBlockProcess_Changed);

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
