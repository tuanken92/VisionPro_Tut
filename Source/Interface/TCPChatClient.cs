using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VisionPro_Tut.Source.Interface
{
    

    class ChatClient : TcpClient
    {
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

        private string _DataMessage;
        public string DataMessage
        {
            get => _DataMessage;
            set
            {
                _DataMessage = value;
                OnNameChanged(value);
            }
        }

        public ChatClient(string address, int port) : base(address, port) { }

        public void DisconnectAndStop()
        {
            _stop = true;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }

        protected override void OnConnected()
        {
            Console.WriteLine($"Chat TCP client connected a new session with Id {Id}");
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine($"Chat TCP client disconnected a session with Id {Id}");

            // Wait for a while...
            Thread.Sleep(1000);

            // Try to connect again
            if (!_stop)
                ConnectAsync();
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            DataMessage = (Encoding.UTF8.GetString(buffer, (int)offset, (int)size));
            Console.WriteLine(DataMessage);
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP client caught an error with code {error}");
        }

        private bool _stop = true;
    }

    public class TcpChatClient
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

        //tcp chat client
        ChatClient client;
        public TcpChatClient(TCPParam param)
        {

            // Create a new TCP chat client
            client = new ChatClient(param.ip, param.port);
            client.ReceiveMessage += Client_ReceiveMessage;
        }

        private void Client_ReceiveMessage(object sender, ReceivedMessageEventArgs e)
        {
            Console.WriteLine("xxxx: " + e.Message);
            data_receive = e.Message;
        }

        ~TcpChatClient()
        {

        }


        public bool Connect()
        {
            // Connect the client
            Console.Write("Client connecting...");
            bool isConnect = client.ConnectAsync();
            Console.WriteLine("Done!");
            return isConnect;
        }

        public bool DisConnect()
        {
            // Disconnect the client
            Console.Write("Client disconnecting...");
            bool isDisConnect  = client.DisconnectAsync();
            Console.WriteLine("Done!");
            return isDisConnect;
        
        }


        public bool SendMessage(string mess)
        {
            // Send the entered text to the chat server
            bool isSend = client.SendAsync(mess);
            return isSend;
        }

       
    }

}
