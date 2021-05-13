using System;
using System.IO;

namespace l4t3
{
    class Program
    {
        /*public enum Months  //Список месяцев
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }*/

        public enum YearTimes //Список времён года
        {
            Winter,
            Spring,
            Summer,
            Autumn
        }
        static void Main(string[] args)
        {
        Enter:                                              //Точка входа
            Console.WriteLine("Введите номер месяца: ");    
            int numMonths = Convert.ToInt32(Console.ReadLine());
            if (numMonths > 12 || numMonths < 1)            //Проверка корректности ввода данных
            {
                Console.WriteLine("Ошибка: введите число от 1 до 12"); 
                goto Enter;
            }
            else
            {
                //Основная часть с вызовом функций
                                
                Console.Write(retYearTime(retMonths(numMonths))); //Вызов функций
                Console.WriteLine();
                goto Enter;
                
            }

        }
        static string retMonths(int numMonths) //Функция, принимающая на вход номер месяца и возвращающая значение из списка времен года
        {
            int numYearTimes = 0;
            string strYearTimes;
            Enum eYearTimes;
            if (numMonths == 12 || numMonths < 3) //Условие "Зима"
            {
               numYearTimes = 0;
            }
            if (numMonths > 2 && numMonths < 6) //Условие "Весна"
            {
               numYearTimes = 1;                
            }
            if (numMonths > 5 && numMonths < 9) //Условие "Лето"
            {
                numYearTimes = 2;
            }
            if (numMonths > 8 && numMonths < 12) //Условие "Осень"
            {
                numYearTimes = 3;
            }
            eYearTimes = (YearTimes)numYearTimes; //Выбираем значение из списка
            strYearTimes = eYearTimes.ToString(); //Конвертируем его в строку
            return strYearTimes;                  //Возвращаем строку с временем года из списка
        }
           
        static string retYearTime(string strYearTimes) //Функция, получающая строку со значением из списка и возвращающая строку с заданным значением
        {
            string strReturnYearTime = "0"; //Инициализация строки
            if (strYearTimes == "Winter")   //Условие "Зима"
            {
                strReturnYearTime = "Зима";
            }
            if (strYearTimes == "Spring") //Условие "Весна"
            {
                strReturnYearTime = "Весна";
            }
            if (strYearTimes == "Summer") //Условие "Лето"
            {
                strReturnYearTime = "Лето";
            }
            if (strYearTimes == "Autumn") //Условие "Осень"
            {
                strReturnYearTime = "Осень";
            }
            return strReturnYearTime;
        }

            
            
            
        
    }
}
