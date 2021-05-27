using System;
using System.IO;

namespace l5t3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите неотрицательные числа через пробел из диапазона от 0 до 255");
            var strNumbers = Console.ReadLine();
            
            funcWriteBin(strNumbers);
        }
        static void funcWriteBin(string strNumbers)
        {
            string strPath = "bytes.bin";                   //Указываем путь сохранения
            string[] arrNumbers = strNumbers.Split(" ");    //Выделяем числа из строки
            int[] numArray = new int[arrNumbers.Length];    //Вводим новый целочисленный массив
            byte[] arrByte = new byte[arrNumbers.Length];   //Вводим массив байтов
            for (int i = 0; i < numArray.Length; i++)       //Конвертация из строки в числа
            {
                numArray[i] = Convert.ToInt32(arrNumbers[i]);
                if (numArray[i] < 0 || numArray[i] > 255)   //Проверка заданного условия (от 0 до 255)
                {
                    Console.WriteLine("Error!");
                }
                else
                {
                    arrByte[i] = Convert.ToByte(numArray[i]); //Конвертируем в байты   
                }                                                          
            }
            File.WriteAllBytes(strPath, arrByte);           //Записываем результ в бинарный файл
        }
    }
}
