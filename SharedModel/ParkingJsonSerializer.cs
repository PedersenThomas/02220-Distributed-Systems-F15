using System.Diagnostics;
using Newtonsoft.Json;

namespace SharedModel
{
    public static class ParkingJsonSerializer
    {
        public static ParkingLotEvent Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<ParkingLotEvent>(json, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects
            });
        }

        public static string Serialize(ParkingLotEvent e)
        {
            return JsonConvert.SerializeObject(e, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects
            });
        }
    }
}
