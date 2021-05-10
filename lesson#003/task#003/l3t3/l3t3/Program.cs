using System;

namespace l3t3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the message:");
            var strMessage = Console.ReadLine();
            char[] arrReverse = strMessage.ToCharArray();// Копируем символы из строки в массив символов
            Array.Reverse(arrReverse);                   // Разворачиваем символы в обратном порядке
            Console.WriteLine(arrReverse);
            Console.ReadKey();

        }
    }
}
