using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rating
{
    public class JsonPolicySerializer
    {
        public static Policy GetPolicyFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonString,
                new StringEnumConverter());
        }
    }
}