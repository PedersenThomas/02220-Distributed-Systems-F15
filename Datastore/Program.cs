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

        static Dictionary<string, Configuration> configurationSetup = new Dictionary<string, Configuration>
        {
            {"display01", new Configuration(new List<DeviceAddress>{new DeviceAddress("localhost",12345)},9000)},
            {"display02", new Configuration(new List<DeviceAddress>{new DeviceAddress("localhost",9000)},9001)},
            {"display03", new Configuration(new List<DeviceAddress>{new DeviceAddress("localhost",9000)},9002)},
                                                                                               
            {"sensor_01", new Configuration(new List<DeviceAddress>{new DeviceAddress("localhost",9001)},9100)},
            {"sensor_02", new Configuration(new List<DeviceAddress>{new DeviceAddress("localhost",9001)},9101)},
            {"sensor_03", new Configuration(new List<DeviceAddress>{new DeviceAddress("localhost",9001)},9102)},
                                                                                               
            {"sensor_04", new Configuration(new List<DeviceAddress>{new DeviceAddress("localhost",9002)},9103)},
            {"sensor_05", new Configuration(new List<DeviceAddress>{new DeviceAddress("localhost",9002)},9104)},
            {"sensor_06", new Configuration(new List<DeviceAddress>{new DeviceAddress("localhost",9002)},9105)},
        };
        
        static void Main(string[] args)
        {
            var dataStore = new ConcurrentDictionary<string, Status>();

            int port = 12345;
            var server = new Server(port);
            server.Start(dataStore);
            
        }
    }
}
