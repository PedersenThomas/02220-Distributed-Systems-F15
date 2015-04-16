using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SharedModel
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
