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
    class Client : IDisposable
    {
        private TcpClient connection;
        private StreamWriter writer;
        private StreamReader reader;

        public Client(string address, int port)
        {
            connection = new TcpClient(address, port);
        }

        public void Start()
        {
            var stream = connection.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
        }

        public void Writeline(string message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }

        public string ReadLine()
        {
            return reader.ReadLine();
        }

        public string ReadToEnd()
        {
            return reader.ReadToEnd();
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
