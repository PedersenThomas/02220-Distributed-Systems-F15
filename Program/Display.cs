using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Program.Model;
using Program.Model.Messages;
using Program.ServerConnection;

namespace Program
{
    class Display
    {
        public string Id { get; private set; }

        public Display(string id)
        {
            this.Id = id;
        }

        public void Start()
        {
            string host = Program.HostAddress;
            int port = Program.HostPort;
            Configuration config = ConfigurationFetcher.FetchConfiguration(host, port, Id);
            Console.WriteLine("Listening port:{0} Report to [{1}]", config.ListeningPort, String.Join(", ", config.ReportToNodes));

            var server = new Server(IPAddress.Any, config.ListeningPort, new DisplayServerConnectionFactory());
            server.Start();
        }
    }
}
