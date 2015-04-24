using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedModel;
using SharedModel.Messages;

namespace Sensor
{
    public class Sensor
    {
        private const string Host = "127.0.0.1";
        private const int Port = 12345;
        public string Id { get; set; }
        public Status Status { get; set; }

        public Sensor(string id)
        {
            this.Id = id;
        }

        public void Start()
        {
            Configuration config = FetchConfiguration(Host, Port);

            Console.WriteLine("Listening port:{0} Report to [{1}]", config.ListeningPort, String.Join(", ", config.ReportToNodes));


            var dummyNode = config.ReportToNodes.First();
            var client = new Client(dummyNode.IP, dummyNode.Port);
            client.Start();

            Random random = new Random();
            while (true)
            {
                this.Status = OppositeStatus(this.Status);
                Thread.Sleep(random.Next(9000) + 1000);
                var e = new ParkingLotEvent{Time = DateTime.Now, Message = new SensorMessage{ID = this.Id,Status = this.Status}};
                var message = ParkingJsonSerializer.Serialize(e);
                client.Writeline(message);
            }
        }

        private Status OppositeStatus(Status status)
        {
            return status == Status.Free ? Status.Occupied : Status.Free;
        }

        private Configuration FetchConfiguration(string host, int port)
        {
            using (Client client = new Client(host, port))
            {
                client.Start();
                var request = new ParkingLotEvent { Message = new RequestConfigurationMessage { id = this.Id } };
                client.Writeline(ParkingJsonSerializer.Serialize(request));
                var response = ParkingJsonSerializer.Deserialize(client.ReadLine());

                var message = response.Message as ResponseConfigurationMessage;
                if (message != null)
                {
                    return message.Configuration;
                }
                return null;
            }
        }
    }
}
