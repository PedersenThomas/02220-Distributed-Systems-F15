using System.Collections.Generic;
using Program.Model.Messages;

namespace Program.Model
{
    public class Configuration : IMessage
    {
        public List<DeviceAddress> ReportToNodes { get; set; }
        public int ListeningPort { get; set; }

        public Configuration(List<DeviceAddress> reportToNodes, int listeningPort)
        {
            this.ReportToNodes = reportToNodes;
            this.ListeningPort = listeningPort;
        }
    }
}
