using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Program.Model;
using Program.ServerConnection;

namespace Program
{
    class Datastore
    {
        private const string Localhost = "127.0.0.1";
        static Dictionary<string, Configuration> configurationSetup = new Dictionary<string, Configuration>
        {
            {Program.displayIds[0], new Configuration(new List<DeviceAddress>{new DeviceAddress(Localhost,12345)}, 9000)},
            {Program.displayIds[1], new Configuration(new List<DeviceAddress>{new DeviceAddress(Localhost,9000)}, 9001)},
            {Program.displayIds[2], new Configuration(new List<DeviceAddress>{new DeviceAddress(Localhost,9000)}, 9002)},
                                                                                               
            {"sensor_01", new Configuration(new List<DeviceAddress>{new DeviceAddress(Localhost,9001), new DeviceAddress(Localhost,9002)}, 9100)},
            {"sensor_02", new Configuration(new List<DeviceAddress>{new DeviceAddress(Localhost,9001)}, 9101)},
            {"sensor_03", new Configuration(new List<DeviceAddress>{new DeviceAddress(Localhost,9001)}, 9102)},
                                                                                               
            {"sensor_04", new Configuration(new List<DeviceAddress>{new DeviceAddress(Localhost,9002)}, 9103)},
            {"sensor_05", new Configuration(new List<DeviceAddress>{new DeviceAddress(Localhost,9002)}, 9104)},
            {"sensor_06", new Configuration(new List<DeviceAddress>{new DeviceAddress(Localhost,9002)}, 9105)},
        };

        public void Start()
        {
            var server = new Server(IPAddress.Any, Program.HostPort, new DatastoreServerFactory(configurationSetup));
            server.Start();
        }
    }
}
