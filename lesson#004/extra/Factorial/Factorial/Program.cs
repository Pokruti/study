using System;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое положительное значение больше 1 :  ");
            int numEnter = Convert.ToInt32(Console.ReadLine());
            if(numEnter == 1)                                       //Условия корректности ввода
            {
                Console.WriteLine($"Факториал от {numEnter} равен 1");
            }
            if(numEnter < 1)
            {
                Console.WriteLine("Ошибка. Невозможно вычислить факториал.");
            }
            if(numEnter > 1)
            {
                //Основная часть
                Console.Write(Factorial(numEnter)); //Вызов функции
                Console.ReadKey();
            }
            static int Factorial(int numEnter) //Функция, вычисляющая факториал
            {
                int numFact = 1; //Инициализация переменной
                for (int i = 2; i <= numEnter; i++) //Счет начинаем с двойки, так как единица уже заложена в проверке условий корректности
                {
                    numFact = numFact * i;
                }
                return numFact;
            }
        }
    }
}
