using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastore
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 12345;
            var server = new Server(port);
            server.Start();
            
        }
    }
}
