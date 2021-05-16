using System;
using System.IO;
using System.Linq;

namespace l5extra1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь директории в формате C\u003a\u005cDirectory");
            var strPath = Console.ReadLine();
            funcWriteBranch(strPath);
            funcRecBranch(funcWriteBranch(strPath));
        }
        static string[] funcWriteBranch(string strPath) // Функция записи дерева каталогови файлов через цикл
        {
            string strSaveDirName = "FileSystem.txt";   // Указываем путь сохранения
            Console.WriteLine(Directory.Exists(strPath)); //Проверка существования директории
            string[] strBranchDir = Directory.GetFileSystemEntries(strPath, "*", SearchOption.AllDirectories); //Массив со всеми папками и файлами по указанному пути
            for (int i = 0; i < strBranchDir.Length; i++) //Цикл записи в файл
            {
                File.AppendAllText(strSaveDirName, strBranchDir[i]);
                File.AppendAllText(strSaveDirName, Environment.NewLine);
            }

            return strBranchDir; // Возврат массива для рекурсии
        }

        static void funcRecBranch(string[] strBranchDir) // Рекурсия
        {
            string strSaveRec = "FS_Rec.txt";
            if (strBranchDir.Length == 0)  // Условие выхода из рекурсии
            {
                return;
            }
            else
            {
                File.AppendAllText(strSaveRec, strBranchDir[0]);
                File.AppendAllText(strSaveRec, Environment.NewLine);
                funcRecBranch(strBranchDir.Skip(1).ToArray()); //Перебирание элементов путём пропуска предыдущего
            }
        }
    }
}
