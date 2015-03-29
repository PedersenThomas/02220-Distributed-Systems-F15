using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Datastore
{
	class DisplayClient
	{
		private TcpClient connection;
        private StreamWriter writer;
        public DisplayClient(string address, int port)
        {
            connection = new TcpClient(address, port);
        }

        public void Start()
        {
            var stream = connection.GetStream();
            writer = new StreamWriter(stream);            
        }

        public void Writeline(string message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }
	}
}
