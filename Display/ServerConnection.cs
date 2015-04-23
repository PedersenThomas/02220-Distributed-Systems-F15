using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedModel;

namespace Display
{
    public class ServerConnection
    {
        public Thread Thread { get; set; }
        private TcpClient client;
        StreamReader reader;
        StreamWriter writer;
        public ServerConnection(TcpClient client)
        {
            this.client = client;
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());

        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(10);
                OnData();
            }
        }

        private void OnData()
        {
            var line = reader.ReadLine();
            var message = ParkingJsonSerializer.Deserialize(line);
            Console.WriteLine("Message: {0}", message);
        }
    }
}
