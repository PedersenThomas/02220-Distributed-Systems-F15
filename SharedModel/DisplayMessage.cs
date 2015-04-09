using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel
{
    public class DisplayMessage : IMessage
    {
        public string ID { get; set; }
        public int NumberOfFreeSpace { get; set; }

        public override string ToString()
        {
            return String.Format("ID:{0} NumberOfFreeSpace:{1}", ID, NumberOfFreeSpace);
        }
    }
}
