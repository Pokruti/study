using System;
using System.IO;



namespace l4t2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа через пробел:");
            var strNumbers = Console.ReadLine();

            static int funcSum(string strNumbers) //Функция, получающая на вход строку с числами и считающая их сумму
            {

                int numSum = 0;
                string[] arrSum = strNumbers.Split(" "); //Выделяем цифры из строки и запичываем в массив
                int[] numArr = new int[arrSum.Length]; //Вводим новый целочисленный массив
                for (int i = 0; i < arrSum.Length; i++) //По циклу конвертируем из строчного массива в целочисленный
                {
                    numArr[i] = Convert.ToInt32(arrSum[i]);
                    numSum += numArr[i];                //Считаем сумму
                }
                
                return numSum;
                
            }
            Console.Write(funcSum(strNumbers));
            Console.ReadKey();
        }
    }
}
