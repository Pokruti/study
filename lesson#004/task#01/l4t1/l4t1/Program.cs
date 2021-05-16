using System;
using System.IO;

namespace l4t1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            

            static string GetFullName(string FirstName, string LastName, string patronymic)
            {
                string parSeparator = " "; //разделитель
               
                string strReturn = string.Join(parSeparator, FirstName,LastName,patronymic); //Объединение строк

                return strReturn;
            }

            int i;
            
            string[,] arrMem = new string[3, 1]; //Объявляем массив для хранения ФИО
            for (i = 0; i < 3; i++)              //По циклу вводим ФИО
            {
                Console.WriteLine("\nВведите фамилию:");
                var FirstName = Console.ReadLine();
                Console.WriteLine("Введите имя:");
                var LastName = Console.ReadLine();
                Console.WriteLine("Введите отчество:");
                var patronymic = Console.ReadLine();
                arrMem[i, 0] = GetFullName(FirstName, LastName, patronymic); //Записываем ФИО
                Console.Clear();
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"\n{arrMem[j, 0]}\n"); 
                }
            }
        }
    }
}
