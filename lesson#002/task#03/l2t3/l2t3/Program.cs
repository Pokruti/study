using System;

namespace l2t3
{
    class Program
    {
        static void Main(string[] args)
        {
            Enter:
            Console.WriteLine("Enter the number please:");
            double parNumber = Convert.ToDouble(Console.ReadLine());
            if (parNumber % 2 == 0)
            {
                Console.WriteLine($"{parNumber} is even");
                goto Enter;
            }
            else
            {
                Console.WriteLine($"{parNumber} is odd");
                goto Enter;
            }
        }
    }
}
