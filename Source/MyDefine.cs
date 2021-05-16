using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionPro_Tut.Source
{
    public class MyDefine
    {
        public string file_image_database = Environment.GetEnvironmentVariable("VPRO_ROOT") + @"\images\coins.idb";
        public string file_vpp = Environment.GetEnvironmentVariable("VPRO_ROOT") + @"\samples\programming\toolblock\toolblockload\tb.vpp";
        public bool using_image_database = true;
    }
}
