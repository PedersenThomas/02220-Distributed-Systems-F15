using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedModel.Messages;

namespace Display
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(10);
            string host = "127.0.0.1";
            int port = 12345;
            Configuration config = FetchConfiguration(host, port);


            Console.ReadKey();
        }

        private static Configuration FetchConfiguration(string host, int port)
        {
            Client client = new Client(host, port);
            var request = new ParkingLotEvent {Message = new RequestConfigurationMessage()};
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
