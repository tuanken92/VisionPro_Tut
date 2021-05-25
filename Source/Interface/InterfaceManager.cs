using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static VisionPro_Tut.Source.Utils;

namespace VisionPro_Tut.Source.Interface
{
    public class InterfaceManager
    {
        //data receive from server
        private string _data_receive = null;
        public string data_receive
        {
            get => _data_receive;
            set
            {
                _data_receive = value;
                OnNameChanged(value);
            }
        }



        //event
        private event EventHandler<ReceivedMessageEventArgs> _ReceiveMessage;
        public event EventHandler<ReceivedMessageEventArgs> ReceiveMessage
        {
            add
            {
                _ReceiveMessage += value;
            }
            remove
            {
                _ReceiveMessage -= value;
            }
        }

        void OnNameChanged(string mess)
        {
            if (_ReceiveMessage != null)
            {
                _ReceiveMessage(this, new ReceivedMessageEventArgs(mess));
            }
        }

        //variable
        MySerialPort serialPort = null;
        TcpChatClient chatClient = null;
        TcpChatServer chatServer = null;

        
        MyDefine param;
        public string data_receiver;

        public InterfaceManager(MyDefine param)
        {
            
            this.param = param;
            
            //mode run
            switch (param.mode_run)
            {
                case MODE_RUN.Manual:
                    break;
                case MODE_RUN.SerialPort:
                    serialPort = new MySerialPort(param.serial_port);
                    serialPort.ReceiveMessage += Event_ReceiveMessage;
                    if (serialPort.is_success)
                    {
                        bool bConnectCOM = serialPort.Connect();
                        Console.WriteLine($"Comport {param.serial_port.com_name} connect ok");
                    }
                    break;
                case MODE_RUN.TCP_Client:
                    chatClient = new TcpChatClient(param.tcp_client);
                    chatClient.ReceiveMessage += Event_ReceiveMessage;
                    bool bClientConnect =  chatClient.Connect();
                    if(bClientConnect)
                    {
                        Console.WriteLine($"Client connected to {param.tcp_client.ip}:{param.tcp_client.port} ok");
                    }
                    break;
                case MODE_RUN.TCP_Server:
                    chatServer = new TcpChatServer(param.tcp_server);
                    chatServer.ReceiveMessage += Event_ReceiveMessage;
                    bool bServerListen = chatServer.Listen();
                    if (bServerListen)
                    {
                        Console.WriteLine($"Server listen in {param.tcp_server.ip}:{param.tcp_server.port} ok");
                    }
                    break;
            }
        }

        private void Event_ReceiveMessage(object sender, ReceivedMessageEventArgs e)
        {
            data_receive = e.Message;
            Console.WriteLine($"Interface data = {data_receive}");
        }

        public bool SendMessage(string mess)
        {
            switch (param.mode_run)
            {
                case MODE_RUN.Manual:
                    break;
                case MODE_RUN.SerialPort:
                    serialPort.SendMessage(mess);
                    break;
                case MODE_RUN.TCP_Client:
                    chatClient.SendMessage(mess);
                    break;
                case MODE_RUN.TCP_Server:
                    chatServer.SendMessage(mess);
                    break;
            }
            return true;
        }
        
        public void CloseInterface()
        {
            switch (param.mode_run)
            {
                case MODE_RUN.Manual:
                    break;
                case MODE_RUN.SerialPort:
                    if(serialPort != null)
                    {
                        bool ComportClose = serialPort.Disconnect();
                        Console.WriteLine($"Serialport close {param.serial_port.baudrate} ok");
                    }
                    break;
                case MODE_RUN.TCP_Client:
                    if (chatClient != null)
                    {

                        bool clientDisconnect = chatClient.DisConnect();
                        Console.WriteLine($"Client disconnect form {param.tcp_client.ip}:{param.tcp_client.port} ok");
                    }
                    break;
                case MODE_RUN.TCP_Server:
                    if (chatServer != null)
                    {
                        bool serverStop = chatServer.Stop();
                        Console.WriteLine($"Server close in {param.tcp_server.ip}:{param.tcp_server.port} ok");
                    }
                    break;
            }
        }
    }
}
