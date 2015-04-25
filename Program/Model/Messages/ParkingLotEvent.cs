using System;

namespace Program.Model.Messages
{
    public class ParkingLotEvent
    {
        public VectorClock Time { get; set; }
        public IMessage Message { get; set; }

        public override string ToString()
        {
            return String.Format("Time: {0} Message: {1}", Time, Message);
        }
    }
}
