using System;

namespace Program.Model.Messages
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
