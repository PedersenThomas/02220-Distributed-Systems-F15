using SharedModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
					var message = JsonSerializer.Deserialize(line);
					Console.WriteLine(message);
				}
			}
		}
	}
}
