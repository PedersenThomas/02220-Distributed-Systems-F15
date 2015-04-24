using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Model;
using Program.Model.Messages;

namespace Program
{
    static class ConfigurationFetcher
    {
        public static Configuration FetchConfiguration(string host, int port, string id)
        {
            using (var client = new Client(host, port))
            {
                client.Start();
                var request = new ParkingLotEvent { Message = new RequestConfigurationMessage { id = id } };
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
