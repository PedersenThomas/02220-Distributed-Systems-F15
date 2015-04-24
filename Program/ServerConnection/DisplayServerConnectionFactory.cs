using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Program.ServerConnection
{
    class DisplayServerConnectionFactory : IServerConnectionFactory
    {
        public IServerConnection MakeServerConnection(TcpClient client)
        {
            return new DisplayServerConnection(client);
        }
    }
}
