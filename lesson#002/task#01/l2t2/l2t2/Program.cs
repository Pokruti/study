using System;
using System.IO;

namespace l2t2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the minimal temperature and then enter the maximum temperature");
            Console.Write("Min: ");
            double parMin = Convert.ToDouble(Console.ReadLine());
            Console.Write("Max: ");
            double parMax = Convert.ToDouble(Console.ReadLine());
            double parAverage = (parMin + parMax) / 2;
            Console.WriteLine($"The average temperature: {Math.Round(parAverage,1)}\u00B0C ");
                       
                StreamWriter parTemp = new StreamWriter(@"..\..\..\..\..\..\Temp.txt"); 
                parTemp.Write(parAverage);                                                  //Записываем температуру в файл для чтения из другого проекта
                parTemp.Close();
                        
            Console.ReadKey();
        }
    }
}
