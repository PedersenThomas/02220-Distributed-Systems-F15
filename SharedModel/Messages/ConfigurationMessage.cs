using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Messages
{
    public class RequestConfigurationMessage : IMessage
    {
        public string id { get; set; }
    }

    public class ResponseConfigurationMessage : IMessage
    {
        public Configuration Configuration { get; set; }
    }
}
