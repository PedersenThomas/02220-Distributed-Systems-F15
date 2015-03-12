using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SharedModel;

namespace Sensor
{
    class Client
    {
        private TcpClient connection;
        public Client(string address, int port)
        {
            connection = new TcpClient(address, port);
        }

        public void Start()
        {
            var stream = connection.GetStream();
            var writer = new StreamWriter(stream);

            while (true)
            {
                var id = Console.ReadLine();
                var message = new SensorMessage{ID = id, Status = Status.Free};
                var buffer = JsonSerializer.Serialize(message);
                writer.WriteLine(buffer);
                writer.Flush();
            }
        }
    }
}
