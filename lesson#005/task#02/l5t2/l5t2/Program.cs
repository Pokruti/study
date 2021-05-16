using System;
using System.IO;

namespace l5t2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program writes the time in file.");
            funcWriteTime();
        }
        static void funcWriteTime()
        {
            string strFileName = "startup.txt";                                  //Задаём путь к файлу
            string strDate = Convert.ToString(DateTime.Now.ToString("HH:mm:ss"));//Форматируем время
            File.AppendAllText(strFileName, strDate);                            //Добавляем строку в файл
            File.AppendAllText(strFileName, Environment.NewLine);                //Делаем перенос строки в файле

        }

    }
}
