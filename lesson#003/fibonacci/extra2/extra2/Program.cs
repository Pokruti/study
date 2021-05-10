using System;

namespace extra2
{
    class Program
    {
        static void Main(string[] args)
        {
            static int Fibfunc(int numFirst, int numSecond, int nFib)
            {
                if (nFib == 0)
                {
                    return numFirst;
                }
                else
                {
                    return Fibfunc(numSecond, numFirst + numSecond, nFib-1);
                }
                //return nFib == 0 ? numFirst : Fibfunc(numSecond, numFirst + numSecond, nFib-1);
                
            }
           
            Console.WriteLine("Введите номер числа из ряда Фибоначчи:");
            int numFib = Convert.ToInt32(Console.ReadLine());
            Console.Write(Fibfunc(0,1,numFib));
            
            Console.ReadKey();
            
            
        }
    }
        
}
