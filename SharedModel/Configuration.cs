using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel
{
    public class Configuration : IMessage
    {
        public List<string> ReportToNodes { get; set; }
        public int ListeningPort { get; set; }
    }
}
