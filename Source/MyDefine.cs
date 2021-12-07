using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionPro_Tut.Source;
using static VisionPro_Tut.Source.Utils;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp;

namespace VisionPro_Tut.Source
{
    public class ReceivedMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        public ReceivedMessageEventArgs(string name)
        {
            Message = name;
        }
    }

    public class Utils
    {
        public enum TYPE_OF_TOOLBLOCK
        {
            Other = 0,
            AcqFifo,
            ImageProcess
        }
        public enum MODE_RUN
        {
            Manual = 0,
            SerialPort,
            TCP_Client,
            TCP_Server
        }


        public const string TRIGGER = "TRIGGER";
        public const string RUNLOOP = "LOOP";

        public static readonly string workingDirectory = Environment.CurrentDirectory;                                      //C:\Users\Admin\Downloads\tuanken92\VisionPro_Tut\bin\Debug
        public static readonly string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;             //C:\Users\Admin\Downloads\tuanken92\VisionPro_Tut
        public static readonly string workspaceDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;     //C:\Users\Admin\Downloads\tuanken92

        public static readonly string file_config = String.Format($"{projectDirectory}\\Data\\config_param.json");
        public static readonly string path_load_img_database = @"C:\Program Files\Cognex\VisionPro\Images";
        public static readonly string path_load_vpp_file = @"C:\Users\Admin\Desktop\Vpp_file";
        public static readonly string path_save_images = String.Format("{0}\\Images", projectDirectory);

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

        public static byte[] Serialize(Object obj)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFomatter = new BinaryFormatter();
            binaryFomatter.Serialize(memoryStream, obj);
            return memoryStream.ToArray();
        }

        public static Object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            
            return formatter.Deserialize(stream);
        }

        public static bool CreateFolder(string path_folder)
        {
            bool result = Directory.Exists(path_folder);
            if (!result)
            {
                Directory.CreateDirectory(path_folder);
                result = Directory.Exists(path_folder);
            }
            return result;
        }
        public static string GenerateNameImage()
        {
            CreateFolder(path_save_images);
            return String.Format("{0}\\{1}.jpg", path_save_images, DateTime.Now.ToString("yyyyMMdd_hhmmss"));
        }

        public static void Save_BitMap(Bitmap bm)
        {
            string file_name = GenerateNameImage();
            bm.Save(file_name, ImageFormat.Jpeg);
            Console.WriteLine("Saved file {0}", file_name);
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

    public class TCPParam
    {
        public string name;
        public string ip;
        public int port;

        public TCPParam()
        {
            ip = "127.0.0.1";
            port = 8686;
            name = null;
        }

        public TCPParam(string name, string ip, int port)
        {
            this.name = name;
            this.ip = ip;
            this.port = port;
        }

        public void Print_Infor()
        {
            Console.WriteLine($"\tTcp name = {name}");
            Console.WriteLine($"\tTcp address = {ip}:{port}");
        }

    }

    public class MyDefine
    {

        public bool use_camera = true;
        public string file_image_database = Environment.GetEnvironmentVariable("VPRO_ROOT") + @"\images\coins.idb";
        public string file_toolblock_process = Environment.GetEnvironmentVariable("VPRO_ROOT") + @"\samples\programming\toolblock\toolblockload\tb.vpp";
        public string file_toolblock_acq = String.Format($"{projectDirectory}\\Data\\TB_ac3800_10gm.vpp");

        public ulong numOK = 0;
        public ulong numNG = 0;
        public MODE_RUN mode_run = MODE_RUN.Manual;
        public BlobFilter blob_filter = new BlobFilter();
        public SerialPortParam serial_port = new SerialPortParam();
        public TCPParam tcp_client = new TCPParam("Client", "127.0.0.1", 5001);
        public TCPParam tcp_server = new TCPParam("Server", "127.0.0.1", 5002);

        public void Print_Infor()
        {
            Console.WriteLine("----MyDefine begin---");
            Console.WriteLine($"\tmode run = {mode_run}");
            Console.WriteLine($"\tuse_camera = {use_camera}");
            Console.WriteLine($"\tfile_image_database = {file_image_database}");
            Console.WriteLine($"\tfile_toolblock_process = {file_toolblock_process}");
            Console.WriteLine($"\tfile_toolblock_acq = {file_toolblock_acq}");
            Console.WriteLine($"\tnumber OK = {numOK}");
            Console.WriteLine($"\tnumber NG = {numNG}");
            blob_filter.Print_Infor();
            serial_port.Print_Infor();
            tcp_client.Print_Infor();
            tcp_server.Print_Infor();
            Console.WriteLine("----MyDefine end---");
        }
    }


    public class MyParam
    {
        public static String path_img = @"C:\Users\Admin\Desktop\tuan_vision_pro\img_test\1.bmp";
        public static Mat source_img = null;
    }
    
}
