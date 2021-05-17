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
            mToolBlock = null;
            mIFTool = null;
            mAcqTool = null;
            
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

            mToolBlock = new CogToolBlock();
            mToolBlock = CogSerializer.LoadObjectFromFile(Common.file_vpp) as CogToolBlock;
            mIFTool = new CogImageFileTool();
            mIFTool.Operator.Open(Common.file_image_database, CogImageFileModeConstants.Read);
            mAcqTool = new CogAcqFifoTool();
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
        }

        ~ObjectManager()
        {

        }
    }
}
