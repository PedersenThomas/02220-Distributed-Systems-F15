using System.Diagnostics;
using Newtonsoft.Json;

namespace SharedModel
{
    public static class ParkingJsonSerializer
    {
        public static string Serialize(SensorMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public static SensorMessage Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<SensorMessage>(json);
        }

        public static ParkingLotEvent DeserializeEvent(string json)
        {
            return JsonConvert.DeserializeObject<ParkingLotEvent>(json, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects
            });
        }

        public static string SerializeEvent(ParkingLotEvent e)
        {
            return JsonConvert.SerializeObject(e, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects
            });
        }
    }
}
