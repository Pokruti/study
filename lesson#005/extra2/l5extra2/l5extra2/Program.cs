using System;
using System.IO;
using System.Text.Json;
using System.Runtime.Serialization;


namespace l5extra2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strPath = "tasks.json";
            funcWriteConsole(strPath);
        Enter:
            Console.Write("Для добавления задачи нажмите 1\n" +
                              "Для очистки списка задач нажмите 0\n" +
                              "Для отметки о выполнении задачи нажмите 2\n" +
                              "Для просмотра задач нажмите 3\n");

            int numChoice = Convert.ToInt32(Console.ReadLine());
            
            
            
            if (File.Exists(strPath) != true) //Проверка наличия файла. 
            {
                File.Create(strPath);         //Если нет, то создаём
            }
            if (numChoice == 1)
            {
                funcWriteFile(strPath, funcNumString(strPath));
                goto Enter;
            }
            if (numChoice == 2)
            {
                funcMark(strPath);
                goto Enter;
            }
            if (numChoice == 0)
            {
                funcClear(strPath);
                goto Enter;
            }
            if (numChoice == 3)
            {
                funcWriteConsole(strPath);
                goto Enter;
            }

            

        }

        
        static void funcWriteConsole(string strPath) //Вывод на экран
        {

            
            string[] json = File.ReadAllLines(strPath); //Читаем построчно файл
            for (int i = 0; i < json.Length; i++)
            {
                ToDo task = JsonSerializer.Deserialize<ToDo>(json[i]); //Десериализация массива
                if (task.IsDone == 1)                                       // Условие выполнения задачи (значок выполнено)
                {
                    Console.WriteLine($"{i + 1}. {task.Title} [x]");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {task.Title} ");
                }
            }
        }

        static void funcWriteFile(string strPath, int numString) //Запись задач в файл
        {
            Console.WriteLine("Введите задачу:");
            ToDo task = new ToDo(Console.ReadLine(), 0);
            string json = JsonSerializer.Serialize(task);
            if (numString == 0)                             //Условие для заполнения с первой строчки
            {
                File.AppendAllText(strPath, json);
            }
            else
            {
                File.AppendAllText(strPath, Environment.NewLine);
                File.AppendAllText(strPath, json);
                //Console.WriteLine(json);
            }


        }

        static int funcNumString(string strPath) //Функция подсчёта строк в файле
        {
            int numString = 0;
            numString = File.ReadAllLines(strPath).Length;
            return numString;
        }

        static void funcClear(string strPath) //Очистка списка задач
        {
            File.WriteAllText(strPath, null);
        }

        static void funcMark(string strPath)        //Функция пометки задания
        {
            Console.WriteLine("Выберите номер задачи, для отметки выполнено:");
            funcWriteConsole(strPath);
            int numChoose = Convert.ToInt32(Console.ReadLine()); //Выбор задания

            string[] json = File.ReadAllLines(strPath);          //Тут чтение из файла строк
            ToDo task = JsonSerializer.Deserialize<ToDo>(json[numChoose - 1]);
            //task.IsDone = 1;
            //task = new ToDo(task.Title, 1);
            funcClear(strPath);                                 //Очистка перед перезаписью массива
            for (int i = 0; i < json.Length; i++)               //Непосредственно сама перезапись
            {
                //json[i] = JsonSerializer.Serialize(task);
                //string jj = json[i];
                if (i == numChoose - 1)                         //Условие изменения марки
                {
                    task = new ToDo(task.Title,1);
                    string js = JsonSerializer.Serialize(task);
                    File.AppendAllTextAsync(strPath, js);
                    File.AppendAllText(strPath, Environment.NewLine);

                }
                else
                {                                                   //Ну а тут ничего не меняется
                    File.AppendAllTextAsync(strPath, json[i]);
                    File.AppendAllText(strPath, Environment.NewLine);
                }
            }
             
            




        }
    }
}
