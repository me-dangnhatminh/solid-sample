using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rating
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policyString);
    }
}
