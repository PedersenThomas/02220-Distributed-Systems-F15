using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Program.Model;

namespace Program.ServerConnection
{
    class DisplayServerConnectionFactory : IServerConnectionFactory
    {
        private Display display;
        public DisplayServerConnectionFactory(Display display)
        {
            this.display = display;
        }

        public IServerConnection MakeServerConnection(TcpClient client)
        {
            return new DisplayServerConnection(client, display);
        }
    }
}
