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
            _listener.Start();
            while (true)
            {
                var client = _listener.AcceptTcpClient();
                var stream = client.GetStream();
                var reader = new StreamReader(stream);
                while (true)
                {
                    var line = reader.ReadLine();
                    var message = ParkingJsonSerializer.Deserialize(line);
                    Console.WriteLine(message);
                }
            }
        }
    }
}
