using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel
{
    public class DeviceAddress
    {
        public string IP;
        public int Port;

        public DeviceAddress(string ip, int port)
        {
            this.IP = ip;
            this.Port = port;
        }
    }
}
