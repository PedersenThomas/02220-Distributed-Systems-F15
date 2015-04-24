using System;

namespace Program.Model.Messages
{
    public class SensorMessage : IMessage
    {
        public string ID { get; set; }
        public Status Status { get; set; }

        public override string ToString()
        {
            return String.Format("ID:{0} Status:{1}", ID, Status);
        }
    }
}
