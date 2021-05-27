using System;
using System.IO;

namespace Lesson7_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите минимальную температуру, затем максимальную:");
            Console.Write("Мин: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Макс: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
            double num3 = (num1 + num2) / 2.0;
            Console.WriteLine(string.Format("Средняя температура: {0}°C ", (object)Math.Round(num3, 1)));
            StreamWriter streamWriter = new StreamWriter("Temp.txt");
            streamWriter.Write(num3);
            streamWriter.Close();
            Console.ReadKey();
        }
    }
}