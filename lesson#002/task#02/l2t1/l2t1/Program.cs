using System;
using System.IO;

namespace l2t1
{
    class Program
    {
        //[Flags]
        public enum Months {

            January,
            Februry,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            Oktober,    
            November,
            December
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of months");
           Enter:
            Console.Write("Number: ");
            int parNum = Convert.ToInt32((Console.ReadLine()));
            if (parNum < 1 || parNum > 12)                         //Проверяем корректное значение месяца
            {
                Console.WriteLine("Error");
                goto Enter;
            }
            else
            {
                StreamReader sR = new StreamReader(@"..\..\..\..\..\..\Temp.txt");
                int parTemp = Convert.ToInt32(sR.ReadToEnd());
                if (parTemp > 0 && (parNum==12 || parNum==1 || parNum==2)) //Проверяем условие выполнения пункта "Дождивая зима"
                {
                    Console.WriteLine("The Rainy Winter");
                }
                    else
                {
                    Console.WriteLine($"{(Months)parNum - 1}");
                }
          
                Console.ReadKey(); 
            }
        }
    }
}
