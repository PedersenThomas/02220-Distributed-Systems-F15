using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Program.ServerConnection
{
    class SensorServerConnectionFactory : IServerConnectionFactory
    {
        public IServerConnection MakeServerConnection(TcpClient client)
        {
            throw new NotImplementedException();
        }
    }
}
