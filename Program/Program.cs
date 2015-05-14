using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    public class Program
    {
        public const string HostAddress = "127.0.0.1";
        public const int HostPort = 12000;


        public static List<string> displayIds = new List<string> { "display01", "display02", "display03" };
        public static List<string> sensorIds = new List<string> { "sensor_01", "sensor_02", "sensor_03", "sensor_04", "sensor_05", "sensor_06" };
        static void Main(string[] args)
        {
            Thread datastoreThread;
            var displayThreads = new List<Thread>();
            var sensorThreads = new List<Thread>();

            //Start Datastore
            var dataStore = new Datastore();
            datastoreThread = new Thread(dataStore.Start);
            sensorThreads.Add(datastoreThread);
            datastoreThread.Start();
            Console.WriteLine("Started Datastore");

            Thread.Sleep(10);
            //Start Displays
            foreach (var id in displayIds)
            {
                var display = new Display(id);
                var thread = new Thread(display.Start);
                displayThreads.Add(thread);

                thread.Start();
            }
            Console.WriteLine("Started {0} Displays", displayThreads.Count);

            //Start Sensors
            foreach (var id in sensorIds)
            {
                var display = new Sensor(id);
                var thread = new Thread(display.Start);
                sensorThreads.Add(thread);

                thread.Start();
            }
            Console.WriteLine("Started {0} Sensors", sensorThreads.Count);
        }
    }
}
