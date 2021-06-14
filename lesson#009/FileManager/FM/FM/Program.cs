using System;
using System.Collections.Generic;
using System.IO;


namespace FileManager
{
    public delegate void OnKey(ConsoleKeyInfo key);

    class Program
    {
        static void Main(string[] args)
        {
            FileManager manager = new FileManager();
            manager.Start();
        }
    }


    


    
        class FileManager
        {

            
            public event OnKey KeyPress;
            List<FilePanel> panels = new List<FilePanel>();
            private int activePanelIndex;

            static FileManager()
            {
                Console.CursorVisible = false;  //Настройка окна консоли
                Console.SetWindowSize(150, 35);
                Console.SetBufferSize(150, 35);
            }

            public FileManager()
            {
                FilePanel filePanel = new FilePanel(); //расположение первой панелей
                filePanel.Top = 0;
                filePanel.Left = 0;
                this.panels.Add(filePanel);

                filePanel = new FilePanel(); // расположение второй панели
                filePanel.Top = 0;
                filePanel.Left = 80;
                this.panels.Add(filePanel);

                activePanelIndex = 0; //выбор активного окна

                this.panels[this.activePanelIndex].Active = true;
                KeyPress += this.panels[this.activePanelIndex].KeyboardProcessing;

                foreach (FilePanel fp in panels)
                {
                    fp.Show();
                }

                this.ShowKeys();
            }



            public void Start()
            {
                bool exit = false;
                while (!exit)
                {
                    if (Console.KeyAvailable)
                    {
                        this.ClearMessage();

                        ConsoleKeyInfo userKey = Console.ReadKey(true);
                        switch (userKey.Key)
                        {
                            case ConsoleKey.Tab:
                                this.ChangeActivePanel();
                                break;
                            case ConsoleKey.Enter:
                                this.ChangeDirectory();
                                break;
                            case ConsoleKey.F1:
                                this.Copy();
                                break;
                            case ConsoleKey.F2:
                                this.CreateDirectory();
                                break;
                            case ConsoleKey.F3:
                                this.Delete();
                                break;
                            case ConsoleKey.F10:
                                exit = true;
                                Console.ResetColor();
                                Console.Clear();
                                break;
                            case ConsoleKey.DownArrow:
                                goto case ConsoleKey.PageUp;
                            case ConsoleKey.UpArrow:
                                goto case ConsoleKey.PageUp;
                            case ConsoleKey.PageUp:
                                this.KeyPress(userKey);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            private string AksName(string message) //Запрос названия
            {
                string name;
                Console.CursorVisible = true;
                do
                {
                    this.ClearMessage();
                    this.ShowMessage(message);
                    name = Console.ReadLine();
                } while (name.Length == 0);
                Console.CursorVisible = false;
                this.ClearMessage();
                return name;
            }


            //Операции
            private void Copy() //Копирование
            {
                foreach (FilePanel panel in panels)
                {
                    if (panel.isDiscs)
                    {
                        return;
                    }
                }

                if (this.panels[0].Path == this.panels[1].Path)
                {
                    return;
                }

                try
                {
                    string destPath = this.activePanelIndex == 0 ? this.panels[1].Path : this.panels[0].Path;

                    FileSystemInfo fileObject = this.panels[this.activePanelIndex].GetActiveObject();
                    FileInfo currentFile = fileObject as FileInfo;

                    if (currentFile != null) //Копируем файл
                    {
                        string fileName = currentFile.Name;
                        string destName = Path.Combine(destPath, fileName);
                        File.Copy(currentFile.FullName, destName, true);
                    }

                    else
                    {
                        string currentDir = ((DirectoryInfo)fileObject).FullName;
                        string destDir = Path.Combine(destPath, ((DirectoryInfo)fileObject).Name);
                        CopyDirectory(currentDir, destDir);//Если не файл, тогда директорию
                    }

                    this.RefreshPannels();
                }
                catch (Exception e)
                {
                    this.ShowMessage(e.Message);
                    return;
                }
            }

            private void CopyDirectory(string sourceDirName, string destDirName) //Функция копирования каталога
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();

                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, true);
                }

                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    CopyDirectory(subdir.FullName, temppath);
                }
            }

            private void Delete() //Удаление
            {
                if (this.panels[this.activePanelIndex].isDiscs)
                {
                    return;
                }

                FileSystemInfo fileObject = this.panels[this.activePanelIndex].GetActiveObject();
                try
                {
                    if (fileObject is DirectoryInfo)
                    {
                        ((DirectoryInfo)fileObject).Delete(true);
                    }
                    else
                    {
                        ((FileInfo)fileObject).Delete();
                    }
                    this.RefreshPannels();
                }
                catch (Exception e)
                {
                    this.ShowMessage(e.Message);
                    return;
                }
            }

            private void CreateDirectory() //Создание каталога
            {
                if (this.panels[this.activePanelIndex].isDiscs)
                {
                    return;
                }

                string destPath = this.panels[this.activePanelIndex].Path;
                string dirName = this.AksName("Введите имя каталога: ");

                try
                {
                    string dirFullName = Path.Combine(destPath, dirName);
                    DirectoryInfo dir = new DirectoryInfo(dirFullName);
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }
                    else
                    {
                        this.ShowMessage("Каталог с таким именем уже существует");
                    }
                    this.RefreshPannels();
                }
                catch (Exception e)
                {
                    this.ShowMessage(e.Message);
                }
            }





            private void RefreshPannels() //Обновление панелей
            {
                if (this.panels == null || this.panels.Count == 0)
                {
                    return;
                }

                foreach (FilePanel panel in panels)
                {
                    if (!panel.isDiscs)
                    {
                        panel.UpdateContent(true);
                    }
                }
            }

            private void ChangeActivePanel() //Смена активной панели
            {
                this.panels[this.activePanelIndex].Active = false;
                KeyPress -= this.panels[this.activePanelIndex].KeyboardProcessing;
                this.panels[this.activePanelIndex].UpdateContent(false);

                this.activePanelIndex++;
                if (this.activePanelIndex >= this.panels.Count)
                {
                    this.activePanelIndex = 0;
                }

                this.panels[this.activePanelIndex].Active = true;
                KeyPress += this.panels[this.activePanelIndex].KeyboardProcessing;
                this.panels[this.activePanelIndex].UpdateContent(false);
            }

            private void ChangeDirectory() //Смена директории
            {
                FileSystemInfo fsInfo = this.panels[this.activePanelIndex].GetActiveObject();
                if (fsInfo != null)
                {
                    if (fsInfo is DirectoryInfo)
                    {
                        try
                        {
                            Directory.GetDirectories(fsInfo.FullName);
                        }
                        catch
                        {
                            return;
                        }

                        this.panels[this.activePanelIndex].Path = fsInfo.FullName;
                        this.panels[this.activePanelIndex].SetLists();
                        this.panels[this.activePanelIndex].UpdatePanel();
                    }

                }
                else
                {
                    string currentPath = this.panels[this.activePanelIndex].Path;
                    DirectoryInfo currentDirectory = new DirectoryInfo(currentPath);
                    DirectoryInfo upLevelDirectory = currentDirectory.Parent;

                    if (upLevelDirectory != null)
                    {
                        this.panels[this.activePanelIndex].Path = upLevelDirectory.FullName;
                        this.panels[this.activePanelIndex].SetLists();
                        this.panels[this.activePanelIndex].UpdatePanel();
                    }

                    else
                    {
                        this.panels[this.activePanelIndex].SetDiscs();
                        this.panels[this.activePanelIndex].UpdatePanel();
                    }
                }
            }



            public static void PrintString(string str, int X, int Y, ConsoleColor text, ConsoleColor background) //Функция рисования для кнопок и сообщения
            {
                Console.ForegroundColor = text;
                Console.BackgroundColor = background;

                Console.SetCursorPosition(X, Y);
                Console.Write(str);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }


            private void ShowKeys() //Полоска с действиями
            {

                string[] menu = { "F1 Копия", "F2 Создать каталог", "F3 Удаление", "F10 Выход" };


                int cellTop = 20;
                int cellWidth = 20;


                for (int i = 0; i < menu.Length; i++)
                {
                    PrintString(menu[i], i * cellWidth, cellTop, ConsoleColor.Green, ConsoleColor.Black); //Вывод подсказок о кнопках управления
                }
            }

            private void ShowMessage(string message) //Сообщение при создании каталога
            {
                PrintString(message, 0, Console.WindowHeight - 10, ConsoleColor.Green, ConsoleColor.Black);
            }

            private void ClearMessage() //Его очистка
            {
                PrintString(new String(' ', Console.WindowWidth), 0, Console.WindowHeight - 10, ConsoleColor.Green, ConsoleColor.Black);
            }

        

    }

}

