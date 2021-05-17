using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionPro_Tut.Source
{
    class SaveLoadParameter
    {
        #region declare variable, object 

        #endregion

        public SaveLoadParameter()
        {
            Console.WriteLine("SaveLoadParameter create ...");

        }

        ~SaveLoadParameter()
        {
            Console.WriteLine("SaveLoadParameter destroy ...");
        }
        public void Inital_Parameter()
        {
            //Create camera basler
            /*CameraPrameter cam_basler = new CameraPrameter();
            cam_basler.Name = "Basler_10MP";
            cam_basler.Format = CameraPrameter.EFormatCamera.MONO;
            cam_basler.Is_support = true;
            cam_basler.Fps = 10;
            cam_basler.Roi = new OpenCvSharp.Rect(0, 0, 1920, 1080);
            cam_basler.Use_calib = false;
            cam_basler.Flip = CameraPrameter.EFlipFrame.Flip_None;


            //Creater COM port
            ComportParameter com_light_control = new ComportParameter();
            com_light_control.Name = "Light Controller";
            com_light_control.Port_name = "COM2";
            com_light_control.Baudrate = 9600;


            //Creater Socket-client
            SocketParameter socket_client = new SocketParameter();
            socket_client.Name = "Client connect to Jump-Sys";
            socket_client.Port = 8888;
            socket_client.Ip = "127.0.0.1";

            //Add to parameter_manager
            parameter_manager.list_cam.Add(cam_basler);
            parameter_manager.list_comport.Add(com_light_control);
            parameter_manager.list_socket_client.Add(socket_client);*/

        }


        public void Get_Parameter()
        {

        }

        public void Update_Parameter()
        {

        }

        
        public void Save_Parameter(MyDefine common)
        {
            // serialize JSON directly to a file
            Console.WriteLine(Utils.file_config);
            using (StreamWriter file = File.CreateText(Utils.file_config))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, common);
            }

            
        }

        public bool Load_Parameter(ref MyDefine common)
        {
            //common = new MyDefine();
            if (!File.Exists(Utils.file_config))
            {
                Console.WriteLine($"file {Utils.file_config} not found...");
                return false;
            }

            using (StreamReader file = File.OpenText(Utils.file_config))
            {
                JsonSerializer serializer = new JsonSerializer();
                common = (MyDefine)serializer.Deserialize(file, typeof(MyDefine));
            }
            //common.Print_Infor();
            Console.WriteLine($"file {Utils.file_config} load ok...");
            return true;
        }
    }
}
