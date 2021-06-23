using System;
using System.IO;
using System.Configuration;





namespace L8t1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            string UserName;
            string Age;
            string Job;

            //Копирую код с https://docs.microsoft.com/ru-ru/dotnet/api/system.configuration.configurationmanager?view=net-5.0 
            //и мне выдаёт ошибку по использованию ConfigurationManager. Что не так я делаю?
            // var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //var appSettings = ConfigurationManager.AppSettings;

            Console.Write(L8t1.Properties.Resources.Greetings, L8t1.Properties.Resources.UserName);
            Console.WriteLine();
            Console.WriteLine("Введите имя:");
            UserName = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            Age = Console.ReadLine();
            Console.WriteLine("Введите профессию:");
            Job = Console.ReadLine();

           




        }

        
    }
}
