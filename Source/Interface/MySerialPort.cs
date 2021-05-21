using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace VisionPro_Tut.Source.Interface
{
    class MySerialPort
    {
        private string com_name = "";
        private SerialPort serialPort = null;
        private StringBuilder dataReceived = null;
        public List<string> list_comport;
        public bool is_success = false;
        public StringBuilder DataReceived
        {
            get
            {
                return dataReceived;
            }
            set
            {
                if (dataReceived != value)
                    dataReceived = value;
            }
        }


        public MySerialPort(SerialPortParam param)
        {
            Console.WriteLine("MySerialPort create");

            //Check comport is exist?
            list_comport = new List<string>();
            com_name = param.com_name;
            list_comport = Utils.Scan_Comport();
            if (!list_comport.Contains(param.com_name))
            {
                is_success = false;
                Console.WriteLine($"Could not find {param.com_name} in this PC");
                return;
            }
            
            //register event
            serialPort = new SerialPort();
            serialPort.PortName = param.com_name;
            serialPort.BaudRate = param.baudrate;
            serialPort.DataReceived += SerialPort_DataReceived;
            is_success = true;
        }

        ~MySerialPort()
        {
            if(is_success)
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
            Console.WriteLine("SerialPortManager destroy");
        }

        public bool Connect()
        {
            bool is_connect = true;
            if (!this.serialPort.IsOpen)
            {
                this.serialPort.Open();
                if (!this.serialPort.IsOpen)
                {
                    is_connect = false;
                }
            }

            Console.WriteLine($"Connect = {is_connect}");
            return is_connect;
        }

        public bool Disconnect()
        {
            bool is_disconnect = true;
            if (this.serialPort.IsOpen)
            {
                this.serialPort.Close();
                if (this.serialPort.IsOpen)
                {
                    is_disconnect = false;
                }
            }
            Console.WriteLine($"Disconnect = {is_disconnect}");
            return is_disconnect;
        }

        public bool SendMessage(string message)
        {
            if (!this.serialPort.IsOpen)
            {
                Console.WriteLine($"{com_name} is not open, try again");
                return false;
            }

            if (String.IsNullOrEmpty(message))
            {
                Console.WriteLine("data2send is empty/null, retry");
                return false;
            }

            this.serialPort.Write(message);
            return true;
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data_com = this.serialPort.ReadExisting();
            if (data_com != null)
                this.DataReceived = new StringBuilder(data_com);

            Console.WriteLine($"Data {com_name} received: {data_com}");
        }
    }
}
