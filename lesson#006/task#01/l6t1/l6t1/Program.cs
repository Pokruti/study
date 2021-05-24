using System;
using System.IO;
using System.Diagnostics;


namespace l6t1
{
        
    class Program
    {
        

        static void Main(string[] args)
        {

            GetAllProccess();
            Console.WriteLine("Для завершения процесса введите его ID или имя:");
            var NameOrNumber = Console.ReadLine();
            if (int.TryParse(NameOrNumber, out int Nnumber)==true) //Проверка возможности конвертирования строки в число
            {
                
                KillNumber(Nnumber); //Если да - то убиваем по номеру ID
            }
            else
            {
                KillName(NameOrNumber); // Если нет - то убиваем по имени
            }
            
        }

        static void GetAllProccess() //Функция, выводящая список процессов и их ID
        {
            
            var Pr = Process.GetProcesses();
            foreach (Process p in Pr)
            {
                
                Console.Write($"{p.Id.ToString()} \t {p.ProcessName} \n");
            }
           
        }

        static void KillNumber(int Number) //Функция завершения процесса по ID
        {
            
            var Pr = Process.GetProcesses();
            foreach (Process p1 in Pr)
            {
                if (Number == p1.Id)
                {
                    p1.Kill();
                    
                }
                else
                {
                    return;
                }
            }
            

        }
        
        static void KillName(string Name) //Функция завершения процесса по имени
        {
            var Pr  = Process.GetProcesses();
            foreach (Process p2 in Pr)
            {
                if (Name == p2.ProcessName)
                {
                    p2.Kill();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
