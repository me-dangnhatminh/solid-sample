using System;

namespace Rating
{
    public class ConsoleLogger
    {
        public static void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}