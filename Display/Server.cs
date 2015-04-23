using System.Collections.Generic;
using System.Threading;
using SharedModel;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Display
{
    class Server
    {
        private TcpListener _listener;

        public Server(int port)
        {
            var localAddress = IPAddress.Parse("127.0.0.1");
            _listener = new TcpListener(localAddress, port);
        }

        public void Start()
        {
            var threadPool = new List<Thread>();
            _listener.Start();
            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                var connection = new ServerConnection(client);
                var thread = new Thread(connection.Start);
                connection.Thread = thread;
                threadPool.Add(thread);
                thread.Start();
            }
        }
    }
}
