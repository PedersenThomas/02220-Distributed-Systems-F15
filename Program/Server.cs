using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Program
{
    class Server
    {
        private TcpListener _listener;
        private IServerConnectionFactory _connectionFactory;
        public List<Thread> ThreadPool { get; set; }

        public Server(IPAddress address, int port, IServerConnectionFactory connectionFactory)
        {
            ThreadPool = new List<Thread>();
            _listener = new TcpListener(address, port);

            _connectionFactory = connectionFactory;
        }

        public void Start()
        {
            _listener.Start();
            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                var connection = _connectionFactory.MakeServerConnection(client);
                var thread = new Thread(connection.Start);
                //connection.Thread = thread;
                ThreadPool.Add(thread);
                thread.Start();
            }
        }
    }
}
