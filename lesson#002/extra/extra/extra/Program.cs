using System;

namespace extra //Задание (**) - переворачивание введенного числа
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the multidigit number:");
            long numMDN = Convert.ToInt32(Console.ReadLine());
            long numStep = 0;
            long numMirror = 0;

            while (numMDN > 0)      // Используем цикл while для проверки оставшихся цифр в введённом числе.
            {
                numStep = numMDN % 10;  //Выделяем последнюю цифру числа 
                numMDN = numMDN / 10;   //Делим введённое число на 10, избавляясь от последней цифры.
                numMirror = (numMirror * 10) + numStep; //Делаем последнюю цифру первой в новом числе.
            }

            Console.WriteLine($"The mirror number is {numMirror}");
            Console.ReadKey();
        }
    }
}
