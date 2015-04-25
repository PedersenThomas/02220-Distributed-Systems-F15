using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Model;
using Program.Model.Messages;

namespace Program
{
    public class Multicast
    {
        private List<Client> members = new List<Client>(); 

        public void AddToGroup(DeviceAddress address)
        {
            var client = new Client(address.IP, address.Port);
            members.Add(client);
            client.Start();
        }

        public void Write(ParkingLotEvent msg)
        {
            var json = ParkingJsonSerializer.Serialize(msg);
            foreach (var member in members)
            {
                member.Writeline(json);
            }
        }
    }
}
