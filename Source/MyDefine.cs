using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionPro_Tut.Source;
using static VisionPro_Tut.Source.Utils;

namespace VisionPro_Tut.Source
{

    public class Utils
    {
        public enum MODE_RUN
        {
            Manual = 0,
            SerialPort,
            TCP
        }
        public const string TRIGGER = "TRIGGER";
        public const string RUNLOOP = "LOOP";

        public static readonly string workingDirectory = Environment.CurrentDirectory;                                      //C:\Users\Admin\Downloads\tuanken92\VisionPro_Tut\bin\Debug
        public static readonly string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;             //C:\Users\Admin\Downloads\tuanken92\VisionPro_Tut
        public static readonly string workspaceDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;     //C:\Users\Admin\Downloads\tuanken92

        public static readonly string file_config = String.Format($"{projectDirectory}\\Data\\config_param.json");
        public static readonly string path_load_img_database = @"C:\Program Files\Cognex\VisionPro\Images";
        public static readonly string path_load_vpp_file = @"C:\Users\Admin\Desktop\Vpp_file";

        public static readonly List<int> list_baudrate = new List<int>{ 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000 };

        public static List<string> Scan_Comport()
        {
            string[] ArrayComPortsNames = null;
            int index = -1;

            ArrayComPortsNames = SerialPort.GetPortNames();
            do
            {
                index += 1;
            }
            while (!(index == ArrayComPortsNames.GetUpperBound(0)));
            Array.Sort(ArrayComPortsNames);

            
            foreach (var com_name in ArrayComPortsNames)
                Console.WriteLine(com_name);

            return (new List<string>(ArrayComPortsNames));
        }
    }

    public class BlobFilter
    {
        public double area_low;
        public double area_high;
        public BlobFilter()
        {
            area_low = 0;
            area_high = 0;
        }

        public void Print_Infor()
        {
            Console.WriteLine($"\tblob filter area low = {area_low}");
            Console.WriteLine($"\tblob filter area high = {area_high}");
        }
    }

    public class SerialPortParam
    {
        public string com_name;
        public int baudrate;

        public SerialPortParam()
        {
            com_name = "COM1";
            baudrate = 115200;
        }

        public void Print_Infor()
        {
            Console.WriteLine($"\tSerialport name = {com_name}");
            Console.WriteLine($"\tSerialport baudrate = {baudrate}");
        }

    }

    public class MyDefine
    {

        public bool using_image_database = true;
        public string file_image_database = Environment.GetEnvironmentVariable("VPRO_ROOT") + @"\images\coins.idb";
        public string file_vpp = Environment.GetEnvironmentVariable("VPRO_ROOT") + @"\samples\programming\toolblock\toolblockload\tb.vpp";
        public ulong numOK = 0;
        public ulong numNG = 0;
        public MODE_RUN mode_run = MODE_RUN.Manual;
        public BlobFilter blob_filter = new BlobFilter();
        public SerialPortParam serial_port = new SerialPortParam();

        public void Print_Infor()
        {
            Console.WriteLine("----MyDefine begin---");
            Console.WriteLine($"\tmode run = {mode_run}");
            Console.WriteLine($"\tusing_image_database = {using_image_database}");
            Console.WriteLine($"\tfile_image_database = {file_image_database}");
            Console.WriteLine($"\tfile_vpp = {file_vpp}");
           
            Console.WriteLine($"\tnumber OK = {numOK}");
            Console.WriteLine($"\tnumber NG = {numNG}");
            blob_filter.Print_Infor();
            serial_port.Print_Infor();
            Console.WriteLine("----MyDefine end---");
        }
    }

    
}
