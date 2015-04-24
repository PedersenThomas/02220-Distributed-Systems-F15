using Newtonsoft.Json;
using Program.Model.Messages;

namespace Program.Model
{
    public static class ParkingJsonSerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            //Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Objects
        };

        public static ParkingLotEvent Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<ParkingLotEvent>(json, Settings);
        }

        public static string Serialize(ParkingLotEvent e)
        {
            return JsonConvert.SerializeObject(e, Settings);
        }
    }
}
