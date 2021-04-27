using System;

namespace ConsoleApp001
{
    class Program001
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! What's your name?\n");
            Console.Write("Name: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"\nNice to meet you {userName}! Today's {DateTime.Now}.");
            Console.ReadKey();
        }
    }
}
