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

        static readonly Random Random = new Random();

        public Sensor(string id)
        {
            this.Id = id;
        }

        public void Start()
        {
            var host = Program.HostAddress;
            var port = Program.HostPort;
            Configuration config = ConfigurationFetcher.FetchConfiguration(host, port, Id);

            Console.WriteLine("Listening port:{0} Report to [{1}]", config.ListeningPort, String.Join(", ", config.ReportToNodes));


            var dummyNode = config.ReportToNodes.First();
            var client = new Client(dummyNode.IP, dummyNode.Port);
            client.Start();

            while (true)
            {
                this.Status = OppositeStatus(this.Status);
                Thread.Sleep(Random.Next(9000) + 1000);
                var e = new ParkingLotEvent { Time = DateTime.Now, Message = new SensorMessage { ID = this.Id, Status = this.Status } };
                var message = ParkingJsonSerializer.Serialize(e);
                client.Writeline(message);
            }
        }

        private Status OppositeStatus(Status status)
        {
            return status == Status.Free ? Status.Occupied : Status.Free;
        }
    }
}
