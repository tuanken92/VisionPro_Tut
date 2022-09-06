using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using System;
using System.IO;

namespace VisionPro_Tut.Source
{
    public class ObjectManager
    {
        //variable
        public CogImageFileTool mIFTool;
        public CogToolBlock mToolBlockProcess;
        public CogToolBlock mToolBlockAcq;
        public ulong numPass;
        public ulong numFail;
        private bool bUseCamera;

        public ObjectManager()
        {
            mToolBlockProcess = new CogToolBlock();
            mToolBlockAcq = new CogToolBlock();
            mIFTool = new CogImageFileTool();
            

            numPass = 0;
            numFail = 0;
            bUseCamera = false;
        }


        public void InitObject(MyDefine Common)
        {
            Common.Print_Infor();
            numPass = Common.numOK;
            numFail = Common.numNG;
            bUseCamera = Common.use_camera;

            if(!File.Exists(Common.file_toolblock_process))
                Common.file_toolblock_process = String.Format($"{Utils.projectDirectory}\\Data\\TB_process.vpp");
            mToolBlockProcess = CogSerializer.LoadObjectFromFile(Common.file_toolblock_process) as CogToolBlock;
            ToolBlock_PrintInfor(mToolBlockProcess);

            if (bUseCamera)
            {
                try
                {
                    mToolBlockAcq = CogSerializer.LoadObjectFromFile(Common.file_toolblock_acq) as CogToolBlock;
                    mToolBlockAcq.Ran += MToolBlockAcq_Ran;
                    mToolBlockAcq.Changed += MToolBlockAcq_Changed;
                    mToolBlockAcq.Running += MToolBlockAcq_Running;
                    ToolBlock_PrintInfor(mToolBlockAcq);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception {0}", e.ToString());
                }
            }
            else
            {
                //init mIFTool to get Image from database
                mIFTool.Operator.Open(Common.file_image_database, CogImageFileModeConstants.Read);
            }

        }

        private void MToolBlockAcq_Running(object sender, EventArgs e)
        {
            Console.WriteLine("MToolBlockAcq_Running");
        }

        private void MToolBlockAcq_Changed(object sender, CogChangedEventArgs e)
        {
            Console.WriteLine("MToolBlockAcq_Changed");
        }

        private void MToolBlockAcq_Ran(object sender, EventArgs e)
        {
            Console.WriteLine("MToolBlockAcq_Ran");
            Console.WriteLine("Test step process when using camera 0 ....");
            var result = (CogImage8Grey)(mToolBlockAcq.Outputs["Image"].Value);
            Utils.Save_BitMap(result.ToBitmap());

        }

        public void ToolBlock_PrintInfor(CogToolBlock toolblock)
        {
            int numTools = toolblock.Tools.Count;
            Console.WriteLine($"-------------Toolblock {toolblock.Name} begin----------------");
            Console.WriteLine("-------------element");
            for (int i = 0; i < numTools; i++)
            {
                Console.WriteLine($"{toolblock.Tools[i].Name}");

                //cur record
                Cognex.VisionPro.ICogRecord tmpRecord = toolblock.Tools[i].CreateCurrentRecord();
                Console.WriteLine($"\ttmpRecord currentRecord = {tmpRecord.Annotation}");
                for (int j = 0; j < tmpRecord.SubRecords.Count; j++)
                {
                    Console.WriteLine($"\t\tj = {j}: {tmpRecord.SubRecords[j].Annotation}");
                }


                //lastest record
                tmpRecord = toolblock.Tools[i].CreateLastRunRecord();
                Console.WriteLine($"\ttmpRecord LastRecord = {tmpRecord.Annotation}");
                for (int j = 0; j < tmpRecord.SubRecords.Count; j++)
                {
                    Console.WriteLine($"\t\tj = {j}: {tmpRecord.SubRecords[j].Annotation}");
                }
            }

            Console.WriteLine("-------------input");
            int numInputs = toolblock.Inputs.Count;
            for (int i = 0; i < numInputs; i++)
            {
                Console.WriteLine($"{toolblock.Inputs[i].Name}");
            }

            Console.WriteLine("-------------output");
            int numOutputs = toolblock.Outputs.Count;
            for (int i = 0; i < numOutputs; i++)
            {
                Console.WriteLine($"{toolblock.Outputs[i].Name}");
            }

            Console.WriteLine($"-------------Toolblock {toolblock.Name} end----------------");
        }
        public void UpdateData(MyDefine Common)
        {
            mToolBlockProcess = CogSerializer.LoadObjectFromFile(Common.file_toolblock_process) as CogToolBlock;
            mIFTool.Operator.Open(Common.file_image_database, CogImageFileModeConstants.Read);
        }

        public void RunOnce()
        {
            // Get the next image
            if (!bUseCamera)
            {
                mIFTool.Run();
                mToolBlockProcess.Inputs["Image"].Value = mIFTool.OutputImage as CogImage8Grey;
            }
            else
            {
                //FIXME: check output image of mToolBockAcq
                mToolBlockAcq.Run();
                Console.WriteLine("Test step process when using camera 1....");
                mToolBlockProcess.Inputs["Image"].Value = mToolBlockAcq.Outputs["Image"].Value;
            }
            // Run the toolblock
            mToolBlockProcess.Run();
        }

        public void ReleaseObject()
        {
            if (mIFTool != null)
                mIFTool.Dispose();
            //FIXME: check here
            if (mToolBlockAcq != null)
                mToolBlockAcq.Dispose();
            if (mToolBlockProcess != null)
                mToolBlockProcess.Dispose();
        }

        ~ObjectManager()
        {
            //ReleaseObject();
        }
    }
}
