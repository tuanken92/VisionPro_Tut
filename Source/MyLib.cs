using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionPro_Tut.Source
{
    public class MyLib
    {
        public static String GenNameImg()
        {
            String date_time = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH''mm''ss");
            return date_time + ".jpg";
        }
    }
}
