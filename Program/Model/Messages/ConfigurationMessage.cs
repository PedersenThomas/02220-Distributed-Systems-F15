namespace Program.Model.Messages
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
