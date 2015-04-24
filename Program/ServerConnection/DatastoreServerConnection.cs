using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Program.Model;
using Program.Model.Messages;

namespace Program.ServerConnection
{
    class DatastoreServerConnection : IServerConnection
    {
        private TcpClient _client;
        private Dictionary<string, Configuration> _configurationSetup;

        public DatastoreServerConnection(TcpClient client, Dictionary<string, Configuration> configurationSetup)
        {
            _client = client;
            _configurationSetup = configurationSetup;
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

                try
                {
                    while (true)
                    {
                        var line = reader.ReadLine();
                        debug(line);
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
                        else if (e.Message.GetType() == typeof (SensorMessage))
                        {
                            Console.WriteLine(e);
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return;
                }
            }
        }

        private void debug(string line)
        {
            Debug.WriteLine(line);
            if (line == null)
            {
                Debug.WriteLine("The line is null");
            }
            else if (String.IsNullOrWhiteSpace(line))
            {
                Debug.WriteLine("Line is Null or Whitespace");
            }
        }
    }
}
