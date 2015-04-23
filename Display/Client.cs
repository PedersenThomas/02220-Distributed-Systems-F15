using System;
using System.IO;
using System.Net.Sockets;

namespace Display
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
