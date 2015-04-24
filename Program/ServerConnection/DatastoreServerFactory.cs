using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Program.Model;

namespace Program.ServerConnection
{
    class DatastoreServerFactory : IServerConnectionFactory
    {
        private Dictionary<string, Configuration> configurationSetup;
        public DatastoreServerFactory(Dictionary<string, Configuration> configurationSetup)
        {
            this.configurationSetup = configurationSetup;
        }

        public IServerConnection MakeServerConnection(TcpClient client)
        {
            return new DatastoreServerConnection(client, configurationSetup);
        }
    }
}
