using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VisionPro_Tut.Source.Interface
{
    class ChatSession : TcpSession
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



        public ChatSession(TcpServer server) : base(server) { }

        protected override void OnConnected()
        {
            Console.WriteLine($"Chat TCP session with Id {Id} connected!");

            // Send invite message
            string message = "Hello from TCP chat! Please send a message or '!' to disconnect the client!";
            SendAsync(message);
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine($"Chat TCP session with Id {Id} disconnected!");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            Console.WriteLine("Incoming: " + message);

            // Multicast message to all connected sessions
            Server.Multicast(message);

            // If the buffer starts with '!' the disconnect the current session
            if (message == "!")
                Disconnect();

            data_receive = message;

        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP session caught an error with code {error}");
        }
    }

    class ChatServer : TcpServer
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

        public ChatServer(IPAddress address, int port) : base(address, port) 
        {
            
        }

        private void Chatss_ReceiveMessage(object sender, ReceivedMessageEventArgs e)
        {
            Console.WriteLine("%%%%%%%%%%%%%%" + e.Message);
            data_receive = e.Message;
        }

        protected override TcpSession CreateSession() 
        {
            ChatSession chatss =  new ChatSession(this);
            chatss.ReceiveMessage += Chatss_ReceiveMessage;
            return chatss; 
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP server caught an error with code {error}");
        }
    }

    public class TcpChatServer
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

        //tcp chat server
        ChatServer server;


        public TcpChatServer(TCPParam param)
        {
            server = new ChatServer(IPAddress.Parse(param.ip), param.port);
            server.ReceiveMessage += Server_ReceiveMessage;
        }

        private void Server_ReceiveMessage(object sender, ReceivedMessageEventArgs e)
        {
            data_receive = e.Message;
        }

        ~TcpChatServer()
        {

        }


        public bool Listen()
        {
            // Start the server
            Console.Write("Server starting...");
            bool bStart = server.Start();
            Console.WriteLine("Done!");
            return bStart;
        }


        public bool Stop()
        {
            Console.Write("Server Stop...");
            bool bStop = server.Stop();
            Console.WriteLine("Done!");
            return bStop;
        }

        public bool SendMessage(string mess)
        {
            // Multicast admin message to all sessions
            bool bSend = server.Multicast(mess);
            return bSend;
        }


    }
}
