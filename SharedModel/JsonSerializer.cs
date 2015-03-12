using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedModel
{
    public class JsonSerializer
    {
        public static string Serialize(SensorMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public static SensorMessage DeSerialize(string json)
        {
            return JsonConvert.DeserializeObject<SensorMessage>(json);
        }
    }
}
