using System;
using System.IO;

namespace l5t1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные: ");
            var strData = Console.ReadLine();
            funcWrite(strData);
        }

        static void funcWrite(string strData)
        {
            
            string fileName = "Data.txt";           //Путь к файлу
            File.WriteAllText(fileName, strData);   //Перезапись строки
                                  
            
        }
    }
}
