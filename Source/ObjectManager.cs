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
        MyDefine Common;
        public CogImageFileTool mIFTool;
        public CogAcqFifoTool mAcqTool;
        public CogToolBlock mToolBlock;
        public ulong numPass;
        public ulong numFail;


        public ObjectManager()
        {
            //cogToolBlockEditV21 = null;
            //cogRecordDisplay1 = null;
            mToolBlock = null;
            mIFTool = null;
            mAcqTool = null;
            Common = null;
            numPass = 0;
            numFail = 0;
        }

        
        public void InitObject()
        {

            Common = new MyDefine();

            //cogToolBlockEditV21.LocalDisplayVisible = false;
            mToolBlock = new CogToolBlock();
            mToolBlock = CogSerializer.LoadObjectFromFile(Common.file_vpp) as CogToolBlock;
            mIFTool = new CogImageFileTool();
            mIFTool.Operator.Open(Common.file_image_database, CogImageFileModeConstants.Read);
            mAcqTool = new CogAcqFifoTool();
            // If no camera is attached, disable the radio button
            if (mAcqTool.Operator == null)
            {
                Common.using_image_database = true;
            }
            else
            {
                mAcqTool.Operator.OwnedExposureParams.Exposure = 10;
            }
        }

   
        public void RunOnce()
        {
            // Get the next image
            if (Common.using_image_database == true)
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
            if (Common.using_image_database == true)
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
