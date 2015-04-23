using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModel;
using SharedModel.Messages;

namespace Display
{
    public class Display
    {
        private const string Host = "127.0.0.1";
        private const int Port = 12345;
        public string Id { get; private set; }

        public Display(string id)
        {
            this.Id = id;
        }

        public void Start()
        {
            Configuration config = FetchConfiguration(Host, Port);
            Console.WriteLine("Listening port:{0} Report to [{1}]", config.ListeningPort, String.Join(", ", config.ReportToNodes));

            Server server = new Server(config.ListeningPort);
            server.Start();
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
