using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedModel;

namespace Sensor
{
    class Program
    {
        private static List<Thread> ThreadPool = new List<Thread>(); 
        static void Main(string[] args)
        {
            var ids = new List<string> { "sensor_01", "sensor_02", "sensor_03", "sensor_04", "sensor_05", "sensor_06" };
            Thread.Sleep(5000);

            foreach (var id in ids)
            {
                Thread.Sleep(357);
                var sensor = new Sensor(id);
                var thread = new Thread(sensor.Start);
                ThreadPool.Add(thread);

                thread.Start();
            }

            Console.WriteLine("Started {0} sensors.", ThreadPool.Count);
            Console.ReadKey();
        }
    }
}
