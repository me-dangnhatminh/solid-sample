namespace Rating
{
    public abstract class Rater
    {
        protected readonly RatingEngine _engine;
        protected readonly ILogger _logger;

        public Rater(RatingEngine engine, ILogger logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public abstract void Rate(Policy policy);
    }
}