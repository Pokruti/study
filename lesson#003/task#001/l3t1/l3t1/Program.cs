using System;
using System.IO;

namespace l3t1
{
    class Program
    {
        static void Main(string[] args)
        {
                      
            int dDif = 0;                                          //Переменная для смещения 
            int nLen = 0;                                          //Переменная для выявления длины массива
            string[] nArray = File.ReadAllLines(@"..\nArray.txt"); //Читаем заранее подготовленный массив 5х5
            int[,] nNum = new int[nArray.Length, nArray[0].Split(' ').Length];
            for (int i = 0; i < nArray.Length; i++)
            {
                string[] tTemp = nArray[i].Split(' ');
                for(int j = 0; j < tTemp.Length; j++)
                {
                    nNum[i, j] = Convert.ToInt32(tTemp[j]);
                    nLen = (i+1) * (j+1); // Определяем объём будущего массива
                }
            }
            int[,] sArray = new int[nLen,nLen]; // Объявляем массив для длинной диагонали

            //Выводим на консоль двумерный массив, который получили из файла
            for (int i = 0; i < nNum.GetLength(0); i++)
            {
                for (int j = 0; j < nNum.GetLength(1); j++)
                {
                    Console.Write($"{nNum[i, j]} "); // Вывод исходного массива
                    sArray[dDif, dDif] = nNum[i, j]; // Запись в элементы по диагонали исходного массива
                    dDif++;                          // Смещение по диагонали
                }
                Console.WriteLine();
            }
            //Второй блок - для вывода массива по диагонали
            Console.WriteLine("\nВывод массива по диагонали:\n"); // Перевод на следующую строку для красоты
                    for(int z = 0; z < sArray.GetLength(0); z++)
                    {
                        for(int y = 0; y < sArray.GetLength(1); y++)
                        {
                                                
                        Console.Write($"{sArray[z, y]} ");
                        }
                    Console.WriteLine();
                    }
                                    
               
                    
                
            
            
            
        }
    }
}
