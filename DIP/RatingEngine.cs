using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace Rating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public ILogger Logger { get; set; } = new ConsoleLogger();
        public IPolicySource PolicySource { get; set; } = new FilePolicySource();
        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();
        public void Rate()
        {
            Logger.Log("Bắt dầu rate.");

            Logger.Log("Tải file policy.");

            // load policy - open file policy.json
            string policyJson = PolicySource.GetPolicyFromSource(); // Persistent

            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson); // Encoding

            var factory = new RaterFactory();

            var rater = factory.Create(policy, this);
            if (rater != null) rater.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}