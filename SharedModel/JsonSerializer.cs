using Newtonsoft.Json;

namespace SharedModel
{
    public static class JsonSerializer
    {
        public static string Serialize(SensorMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public static SensorMessage Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<SensorMessage>(json);
        }
    }
}
