using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionPro_Tut.Source
{
    public class ObjectManager
    {
        //variable
        public CogImageFileTool mIFTool;
        public CogAcqFifoTool mAcqTool;
        public CogToolBlock mToolBlock;
        public ulong numPass;
        public ulong numFail;
        private bool bUseImageDatabase;

        public ObjectManager()
        {
            mToolBlock = new CogToolBlock();
            mIFTool = new CogImageFileTool();
            mAcqTool = new CogAcqFifoTool();
            
            numPass = 0;
            numFail = 0;
            bUseImageDatabase = false;
        }

        
        public void InitObject(MyDefine Common)
        {

            Common.Print_Infor();
            numPass = Common.numOK;
            numFail = Common.numNG;
            bUseImageDatabase = Common.using_image_database;

            
            mToolBlock = CogSerializer.LoadObjectFromFile(Common.file_vpp) as CogToolBlock;
            ToolBlock_PrintInfor();

            
            mIFTool.Operator.Open(Common.file_image_database, CogImageFileModeConstants.Read);
            // If no camera is attached, disable the radio button
            if (mAcqTool.Operator == null)
            {
                bUseImageDatabase = true;
            }
            else
            {
                mAcqTool.Operator.OwnedExposureParams.Exposure = 10;
            }
        }

        public void ToolBlock_PrintInfor()
        {
            int numTools = mToolBlock.Tools.Count;
            Console.WriteLine("-------------Toolblock begin----------------");
            Console.WriteLine("-------------element");
            for(int i =0; i< numTools; i++)
            {
                Console.WriteLine($"{mToolBlock.Tools[i].Name}");

                //cur record
                Cognex.VisionPro.ICogRecord tmpRecord = mToolBlock.Tools[i].CreateCurrentRecord();
                Console.WriteLine($"\ttmpRecord currentRecord = {tmpRecord.Annotation}");
                for (int j = 0; j < tmpRecord.SubRecords.Count; j++)
                {
                    Console.WriteLine($"\t\tj = {j}: {tmpRecord.SubRecords[j].Annotation}");
                }


                //lastest record
                tmpRecord = mToolBlock.Tools[i].CreateLastRunRecord();
                Console.WriteLine($"\ttmpRecord LastRecord = {tmpRecord.Annotation}");
                for (int j = 0; j < tmpRecord.SubRecords.Count; j++)
                {
                    Console.WriteLine($"\t\tj = {j}: {tmpRecord.SubRecords[j].Annotation}");
                }
            }

            Console.WriteLine("-------------input");
            int numInputs = mToolBlock.Inputs.Count;
            for (int i = 0; i < numInputs; i++)
            {
                Console.WriteLine($"{mToolBlock.Inputs[i].Name}");
            }

            Console.WriteLine("-------------output");
            int numOutputs = mToolBlock.Outputs.Count;
            for (int i = 0; i < numOutputs; i++)
            {
                Console.WriteLine($"{mToolBlock.Outputs[i].Name}");
            }

            Console.WriteLine("-------------Toolblock end----------------");
        }
        public void UpdateData(MyDefine Common)
        {
            mToolBlock = CogSerializer.LoadObjectFromFile(Common.file_vpp) as CogToolBlock;
            mIFTool.Operator.Open(Common.file_image_database, CogImageFileModeConstants.Read);
        }
   
        public void RunOnce()
        {
            // Get the next image
            if (bUseImageDatabase)
            {
                mIFTool.Run();
                mToolBlock.Inputs["Image"].Value = mIFTool.OutputImage as CogImage8Grey;
            }
            else
            {
                mAcqTool.Run();
                mToolBlock.Inputs["Image"].Value = mAcqTool.OutputImage as CogImage8Grey;
            }
            // Run the toolblock
            mToolBlock.Run();
        }

        public void RunContinue()
        {
            // Get the next image
            if (bUseImageDatabase)
            {
                mIFTool.Run();
                mToolBlock.Inputs["Image"].Value = mIFTool.OutputImage as CogImage8Grey;
            }
            else
            {
                mAcqTool.Run();
                mToolBlock.Inputs["Image"].Value = mAcqTool.OutputImage as CogImage8Grey;
            }
            // Run the toolblock
            mToolBlock.Run();
        }
        public void ReleaseObject()
        {
            if (mIFTool != null)
                mIFTool.Dispose();
            if (mAcqTool != null)
                mAcqTool.Dispose();
            if (mToolBlock != null)
                mToolBlock.Dispose();
        }

        ~ObjectManager()
        {
            ReleaseObject();
        }
    }
}
