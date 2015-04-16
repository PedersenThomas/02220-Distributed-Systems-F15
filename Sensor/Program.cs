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
        static void Main(string[] args)
        {
            Thread.Sleep(100);
            string address = "127.0.0.1";
            int port = 12345;
            var client = new Client(address, port);

            client.Start();

            while (true)
            {
                var id = Console.ReadLine();
                var message = new ParkingLotEvent { Message = new SensorMessage { ID = id, Status = Status.Free } }; 
                var buffer = ParkingJsonSerializer.Serialize(message);
                client.Writeline(buffer); 
            }
        }
    }
}
