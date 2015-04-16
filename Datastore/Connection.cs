using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedModel;
using SharedModel.Messages;

namespace Datastore
{
    public class Connection
    {
        private TcpClient _client;
        private Dictionary<string, Configuration> _configurationSetup;

        public Connection(TcpClient client, Dictionary<string, Configuration> configurationSetup)
        {
            this._client = client;
            this._configurationSetup = configurationSetup;
        }

        public void Start()
        {
            Thread.CurrentThread.Name = String.Format("{0}", _client.Client.RemoteEndPoint);
            Console.WriteLine("Connected at {0} from {1}", DateTime.Now, Thread.CurrentThread.Name);
            while (true)
            {
                var stream = _client.GetStream();
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);

                while (true)
                {
                    var line = reader.ReadLine();
                    ParkingLotEvent e = ParkingJsonSerializer.Deserialize(line);
                    
                    if (e.Message.GetType() == typeof(RequestConfigurationMessage))
                    {
                        var request = (RequestConfigurationMessage)e.Message;
                        var response = new ResponseConfigurationMessage();
                        var parkingLotEvent = new ParkingLotEvent();
                        response.Configuration = _configurationSetup[request.id];

                        parkingLotEvent.Message = response;
                        writer.WriteLine(ParkingJsonSerializer.Serialize(parkingLotEvent));
                        writer.Flush();
                    }
                }
            }
        }
    }
}
