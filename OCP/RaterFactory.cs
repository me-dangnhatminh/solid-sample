namespace Rating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine, engine.Logger);

                case PolicyType.Flood:
                    return new FloodPolicyRater(engine, engine.Logger); 

                case PolicyType.Land:
                    return new LandPolicyRater(engine, engine.Logger);

                case PolicyType.Life:
                    return new LifePolicyRater(engine, engine.Logger);

                default:
                    // currently this can't be reached 
                    return null;
            }
        }
    }
}

// public Rater Create(Policy policy, RatingEngine engine)
// {
//     try
//     {
//         return (Rater)Activator.CreateInstance(
//             Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
//                 new object[] { engine, engine.Logger });
//     }
//     catch
//     {
//         return null;
//     }
// }