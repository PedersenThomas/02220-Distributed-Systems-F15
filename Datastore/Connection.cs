using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedModel;

namespace Datastore
{
    public class Connection
    {
        private TcpClient _client;
        public Connection(TcpClient client)
        {
            this._client = client;
        }

        public void Start()
        {
            Thread.CurrentThread.Name = String.Format("{0}", _client.Client.RemoteEndPoint);
            Console.WriteLine("Connected at {0} from {1}", DateTime.Now, Thread.CurrentThread.Name);
            while (true)
            {
                var stream = _client.GetStream();
                var reader = new StreamReader(stream);
                while (true)
                {
                    var line = reader.ReadLine();
                    var message = JsonSerializer.Deserialize(line);
                    Console.WriteLine("{0} - {1}", Thread.CurrentThread.Name, message);
                }
            }
        }
    }
}
