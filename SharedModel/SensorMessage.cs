using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel
{
    public class SensorMessage
    {
        public string ID { get; set; }
        public Status Status { get; set; }

        public override string ToString()
        {
            return String.Format("ID:{0} Status:{1}", ID, Status);
        }
    }
}
