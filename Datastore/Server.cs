using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedModel;

namespace Datastore
{
    public class Server
    {
        private TcpListener _listener;
        private List<Connection> _connectionPool = new List<Connection>(); 

        public Server(int port)
        {
            var localAddress = IPAddress.Parse("127.0.0.1");
            _listener = new TcpListener(localAddress, port);
        }

        public void Start()
        {
            _listener.Start();
            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                var conn = new Connection(client);
                _connectionPool.Add(conn);
                ThreadStart starter = new ThreadStart(conn.Start);
                Thread thread = new Thread(starter); //TODO Should this be saved???
                thread.Start();
            }
        }
    }
}
