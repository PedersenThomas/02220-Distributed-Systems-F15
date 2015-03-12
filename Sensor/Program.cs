using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "127.0.0.1";
            int port = 12345;
            var client = new Client(address, port);

            client.Start();
        }
    }
}
