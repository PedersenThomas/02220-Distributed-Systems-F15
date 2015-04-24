using System;

namespace Program.Model
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

        public override string ToString()
        {
            return String.Format("{0} {1}", IP, Port);
        }
    }
}
