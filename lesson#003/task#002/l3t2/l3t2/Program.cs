using System;
using System.IO;

namespace l3t2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[,] nNum = new string[5,2];
            //Блок чтения/проверки файла
            
                string[] nArray = File.ReadAllLines(@"..\strContacts.txt"); //Читаем массив построчно
                if (!(nArray.Length > 0))
                { 
                    goto Question;
                }
                else
                {
                    nNum = new string[nArray.Length, nArray[0].Split(' ').Length];
                    for (int i = 0; i < nArray.Length; i++)
                    {
                        string[] tTemp = nArray[i].Split(' ');
                        for (int j = 0; j < tTemp.Length; j++)
                        {
                            nNum[i, j] = tTemp[j];
                        Console.Write($"{nNum[i, j]} ");
                        }
                    Console.WriteLine();
                    }
                Console.WriteLine();
                goto Question;
                }
            
            
            
            //Проверка ненулевого массива для вывода на консоль
               /*  if (!(nNum?.Length > 0))
            
                 {
                    goto Enter;
                 }
                    else
                    {
                        //Вывод массива на консоль
                        //Можно в первый блок включить
                        for (int i = 0; i < nArray.Length; i++)
                        {
                    
                            string[] tTemp = nArray[i].Split(' ');
                            for (int j = 0; j < tTemp.Length; j++)
                            {
                                nNum[i, j] = tTemp[j];                        
                                Console.Write($"{nNum[i,j]} ");
                            }
                            Console.WriteLine();
                            }
                        Console.WriteLine();
                        goto Question;
                    //}*/
            
                        
                //Блок вопроса
                  Question:
                  Console.WriteLine("Для перезаписи введите 1, для выхода 2: ");
                  int nAnswer = Convert.ToInt32(Console.ReadLine());
                  if(nAnswer == 1)
                  {
                    goto Enter;
                  }
                  else
                  {
                    goto Save;
                  }

            //Блок ввода новой информации
                Enter:
                int z = 0;
                
                while (z <= 4)
                {
                    Console.WriteLine("Введите имя:");
                    var nName = Console.ReadLine();
                    int y = 0;
                    nNum[z, y] = nName;
                    y++;
                    Console.WriteLine("Введите номер телефона:");
                    nName = Console.ReadLine();
                    nNum[z, y] = nName;
                    z++;
                
                }

            //Блок сохранения информации
                Save:
                StreamWriter nNumWrite = new StreamWriter(@"..\strContacts.txt");
                
                for (int i = 0; i < nNum.GetLength(0); i++)
                {
                    string[] nNumLine = new string[nNum.GetLength(1)];//Ввод переменной для преобразования строки
                    for (int j = 0; j < nNum.GetLength(1); j++)
                    {
                        nNumLine[j] = nNum[i, j].ToString(); //Преобразование в строку для записи
                    
                    }
                    nNumWrite.WriteLine(String.Join(" ", nNumLine)); // Построчная запись введённого массива
                }
                nNumWrite.Close();

        



             


        }
    }
}
