using System;
using System.IO;
using System.Net.Sockets;

namespace Program
{
    class Client : IDisposable
    {
        private TcpClient connection;
        private StreamWriter writer;
        private StreamReader reader;

        public string Address { get; private set; }
        public int Port { get; private set; }

        public Client(string address, int port)
        {
            Address = address;
            Port = port;
        }

        public void Start()
        {
            connection = new TcpClient(Address, Port);
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
