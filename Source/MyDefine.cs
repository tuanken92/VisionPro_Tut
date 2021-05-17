using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionPro_Tut.Source
{
    public class Utils
    {
        public static readonly string file_config = @"C:\Users\Admin\Downloads\tuanken92\config_param.json";
        public static readonly string path_load_img_database = @"C:\Program Files\Cognex\VisionPro\Images";
        public static readonly string path_load_vpp_file = @"C:\Users\Admin\Desktop\Vpp_file";

    }
    public class MyDefine
    {

        public bool using_image_database = true;
        public string file_image_database = Environment.GetEnvironmentVariable("VPRO_ROOT") + @"\images\coins.idb";
        public string file_vpp = Environment.GetEnvironmentVariable("VPRO_ROOT") + @"\samples\programming\toolblock\toolblockload\tb.vpp";
        public ulong numOK = 0;
        public ulong numNG = 0;
        

        public void Print_Infor()
        {
            Console.WriteLine("----MyDefine begin---");
            Console.WriteLine($"\tusing_image_database = {using_image_database}");
            Console.WriteLine($"\tfile_image_database = {file_image_database}");
            Console.WriteLine($"\tfile_vpp = {file_vpp}");
           
            Console.WriteLine($"\tnumber OK = {numOK}");
            Console.WriteLine($"\tnumber NG = {numNG}");
            Console.WriteLine("----MyDefine end---");
        }
    }
}
