using System;

namespace Rating
{
    public class ConsoleLogger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.Clear();
        }
    }
}