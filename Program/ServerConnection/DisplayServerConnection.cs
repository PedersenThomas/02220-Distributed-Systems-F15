using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using Program.Model;
using Program.Model.Messages;

namespace Program.ServerConnection
{
    class DisplayServerConnection :IServerConnection
    {
        private TcpClient client;
        private Display display;
        StreamReader reader;
        StreamWriter writer;
        public DisplayServerConnection(TcpClient client, Display display)
        {
            this.client = client;
            this.display = display;
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());

        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(10);
                OnData();
            }
        }

        private void OnData()
        {
            var line = reader.ReadLine();
            var content = ParkingJsonSerializer.Deserialize(line);
            if (content.Message is SensorMessage)
            {
                var sensorMessage = content.Message as SensorMessage;
                display._state.AddOrUpdate(sensorMessage.ID, sensorMessage.Status, (s, status) => sensorMessage.Status);

                int freeSlots = display._state.Values.Count(status => status == Status.Free);

                Console.WriteLine("[{0}]: Free slots: {1}", display.Id, freeSlots);
            }
        }
    }
}
