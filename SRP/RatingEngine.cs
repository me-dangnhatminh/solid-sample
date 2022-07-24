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
        public void Rate()
        {
            ConsoleLogger.Log("Bắt dầu rate.");

            ConsoleLogger.Log("Tải file policy.");

            // load policy - open file policy.json
            string policyJson = FilePolicySource.GetPolicyFromSource(); // Persistent

            var policy = JsonPolicySerializer.GetPolicyFromJsonString(policyJson); // Encoding

            switch (policy.Type) // Business Rule 
            {
                case PolicyType.Auto:
                    ConsoleLogger.Log("Rating AUTO policy...");
                    ConsoleLogger.Log("Validating policy.");
                    if (String.IsNullOrEmpty(policy.Make)) // Validation
                    {
                        ConsoleLogger.Log("Auto policy must specify Make");
                        return;
                    }
                    if (policy.Make == "BMW")
                    {
                        if (policy.Deductible < 500) Rating = 1000m;
                        Rating = 900m;
                    }
                    break;

                case PolicyType.Land:
                    ConsoleLogger.Log("Rating LAND policy...");
                    ConsoleLogger.Log("Validating policy.");
                    if (policy.BondAmount == 0 || policy.Valuation == 0)
                    {
                        ConsoleLogger.Log("Land policy must specify Bond Amount and Valuation.");
                        return;
                    }
                    if (policy.BondAmount < 0.8m * policy.Valuation)
                    {
                        ConsoleLogger.Log("Insufficient bond amount.");
                        return;
                    }
                    Rating = policy.BondAmount * 0.05m;
                    break;

                case PolicyType.Life:
                    ConsoleLogger.Log("Rating LIFE policy...");
                    ConsoleLogger.Log("Validating policy.");
                    if (policy.DateOfBirth == DateTime.MinValue)
                    {
                        ConsoleLogger.Log("Life policy must include Date of Birth.");
                        return;
                    }
                    if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                    {
                        ConsoleLogger.Log("Centenarians are not eligible for coverage.");
                        return;
                    }
                    if (policy.Amount == 0)
                    {
                        ConsoleLogger.Log("Life policy must include an Amount.");
                        return;
                    }
                    int age = DateTime.Today.Year - policy.DateOfBirth.Year;
                    if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                        DateTime.Today.Day < policy.DateOfBirth.Day ||
                        DateTime.Today.Month < policy.DateOfBirth.Month)
                    {
                        age--;
                    } // Age Calculation
                    decimal baseRate = policy.Amount * age / 200;
                    if (policy.IsSmoker)
                    {
                        Rating = baseRate * 2;
                        break;
                    }
                    Rating = baseRate;
                    break;

                default:
                    ConsoleLogger.Log("Unknown policy type");
                    break;
            }

            ConsoleLogger.Log("Rating completed.");
        }
    }
}