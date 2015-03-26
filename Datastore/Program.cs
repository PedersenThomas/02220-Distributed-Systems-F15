using SharedModel;
using System;
using System.Collections.Concurrent;
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
			var dataStore = new ConcurrentDictionary<string, Status>();

            int port = 12345;
            var server = new Server(port);
            server.Start(dataStore);
            
        }
    }
}
