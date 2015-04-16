using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel
{
    public class ParkingLotEvent
    {
        public DateTime? Time { get; set; }
        public IMessage Message { get; set; }
    }
}
