using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Program.Model;
using Program.Model.Messages;

namespace Program
{
    class Sensor
    {
        public string Id { get; set; }
        public Status Status { get; set; }
        public VectorClock Time { get; set; }

        static readonly Random Random = new Random();

        public Sensor(string id)
        {
            this.Id = id;
            this.Time = new VectorClock();
            this.Time[id] = 0;
        }

        public void Start()
        {
            var host = Program.HostAddress;
            var port = Program.HostPort;
            Configuration config = ConfigurationFetcher.FetchConfiguration(host, port, Id);

            Console.WriteLine("Listening port:{0} Report to [{1}]", config.ListeningPort, String.Join(", ", config.ReportToNodes));

            var MulticastGroup = new Multicast();
            foreach (DeviceAddress address in config.ReportToNodes)
            {
                MulticastGroup.AddToGroup(address);
            }

            while (true)
            {
                Thread.Sleep(Random.Next(9000) + 1000);

                Time[Id] += 1; 
                this.Status = OppositeStatus(this.Status);
                var e = new ParkingLotEvent { Time = Time, Message = new SensorMessage { ID = this.Id, Status = this.Status } };
                MulticastGroup.Write(e);
            }
        }

        private Status OppositeStatus(Status status)
        {
            return status == Status.Free ? Status.Occupied : Status.Free;
        }
    }
}
