using Rating;

Console.WriteLine("Hệ thống xếp hạng đang bắt đầu..."); // Logging

var engine = new RatingEngine();
engine.Rate();

if (engine.Rating > 0)
{
    Console.WriteLine($"Xếp hạng: {engine.Rating}");
}
else
{
    Console.WriteLine("Không có sản phẩm xếp hạng.");
}