using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    interface IServerConnectionFactory
    {
        IServerConnection MakeServerConnection(TcpClient client);
    }
}
