using ArdalisRating;

Console.WriteLine("Insurance Rating System Starting..."); // Logging

var engine = new RatingEngine();
engine.Rate();

if (engine.Rating > 0)
{
    Console.WriteLine($"Rating: {engine.Rating}");
}
else
{
    Console.WriteLine("No rating produced.");
}