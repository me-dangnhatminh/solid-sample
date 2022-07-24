using System.IO;

namespace Rating
{
    public class FilePolicySource
    {
        public static string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}