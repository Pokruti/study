using System;
using System.Collections.Generic;
using System.IO;


namespace FileManager
{
    class FilePanel
    {


        public static int PANEL_HEIGHT = 20; //ограничение высоты панели
        public static int PANEL_WIDTH = 70; //ограничение длины панели


        //Настройка панелек

        private int top;
        public int Top
        {
            get
            {
                return this.top;
            }
            set
            {                
                this.top = 0;
            }
        }

        private int left;
        public int Left
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
            }
        }

        

        private int height = FilePanel.PANEL_HEIGHT;     
        private int width = FilePanel.PANEL_WIDTH;
       


        
        private string path;
        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                DirectoryInfo di = new DirectoryInfo(value);
                if (di.Exists)
                {
                    this.path = value;
                }
                else
                {
                    throw new Exception(String.Format("Путь {0} не существует", value));
                }
            }
        }

        private int activeObjectIndex = 0;
        private int firstObjectIndex = 0;
        private int displayedObjectsAmount = PANEL_HEIGHT - 2; //Длина постраничного списка вывода
        private bool active;
        public bool Active
        {
            get
            {
                return this.active;
            }
            set
            {
                this.active = value;
            }
        }
        private bool discs;
        public bool isDiscs
        {
            get
            {
                return this.discs;
            }
        }

       
        private List<FileSystemInfo> fsObjects = new List<FileSystemInfo>();

        
        public FilePanel()
        {
            this.SetDiscs();
        }

        public FilePanel(string path)
        {
            this.path = path;
            this.SetLists();
        }



        public FileSystemInfo GetActiveObject()
        {
            if (this.fsObjects != null && this.fsObjects.Count != 0)
            {
                return this.fsObjects[this.activeObjectIndex];
            }
            throw new Exception("Список объектов панели пуст");
        }



        //Навигация

        public void KeyboardProcessing(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    this.ScrollUp();
                    break;
                case ConsoleKey.DownArrow:
                    this.ScrollDown();
                    break;
                default:
                    break;
            }
        }

        private void ScrollDown() //Скроллирование
        {
            if (this.activeObjectIndex >= this.firstObjectIndex + this.displayedObjectsAmount - 1)
            {
                this.firstObjectIndex += 1;
                if (this.firstObjectIndex + this.displayedObjectsAmount >= this.fsObjects.Count)
                {
                    this.firstObjectIndex = this.fsObjects.Count - this.displayedObjectsAmount;
                }
                this.activeObjectIndex = this.firstObjectIndex + this.displayedObjectsAmount - 1;
                this.UpdateContent(false);

            }

            else
            {
                if (this.activeObjectIndex >= this.fsObjects.Count - 1)
                {
                    return;
                }
                this.DeactivateObject(this.activeObjectIndex);
                this.activeObjectIndex++;
                this.ActivateObject(this.activeObjectIndex);
            }
        }

        private void ScrollUp() //Скроллирование
        {
            if (this.activeObjectIndex <= this.firstObjectIndex)
            {
                this.firstObjectIndex -= 1;
                if (this.firstObjectIndex < 0)
                {
                    this.firstObjectIndex = 0;
                }
                this.activeObjectIndex = firstObjectIndex;
                this.UpdateContent(false);
            }
            else
            {
                this.DeactivateObject(this.activeObjectIndex);
                this.activeObjectIndex--;
                this.ActivateObject(this.activeObjectIndex);
            }
        }







        public void SetLists() //Получение данных в панели
        {
            if (this.fsObjects.Count != 0)
            {
                this.fsObjects.Clear();
            }

            this.discs = false; //Если не диски, то заполняем директориями и файлами

            DirectoryInfo levelUpDirectory = null;
            this.fsObjects.Add(levelUpDirectory);

            //Директорий

            string[] directories = Directory.GetDirectories(this.path);
            foreach (string directory in directories)
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                this.fsObjects.Add(di);
            }

            //Файлов

            string[] files = Directory.GetFiles(this.path);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                this.fsObjects.Add(fi);
            }
        }

        public void SetDiscs()
        {
            if (this.fsObjects.Count != 0)
            {
                this.fsObjects.Clear();
            }

            this.discs = true; //Если вышли в корень

            DriveInfo[] discs = DriveInfo.GetDrives();
            foreach (DriveInfo disc in discs)
            {
                if (disc.IsReady)
                {
                    DirectoryInfo di = new DirectoryInfo(disc.Name);
                    this.fsObjects.Add(di);
                }
            }
        }




        //Рисовашки
        public void Show()
        {
            this.Clear();

            this.PrintContent();
        }

        public void Clear()
        {
            for (int i = 0; i < this.height; i++)
            {
                string space = new String(' ', this.width);
                Console.SetCursorPosition(this.left, this.top + i);
                Console.Write(space);
            }
        }

        private void PrintContent()
        {
            if (this.fsObjects.Count == 0)
            {
                return;
            }
            int count = 0;

            int lastElement = this.firstObjectIndex + this.displayedObjectsAmount;
            if (lastElement > this.fsObjects.Count)
            {
                lastElement = this.fsObjects.Count;
            }


            if (this.activeObjectIndex >= this.fsObjects.Count)
            {
                activeObjectIndex = 0;
            }

            for (int i = this.firstObjectIndex; i < lastElement; i++)
            {
                Console.SetCursorPosition(this.left + 1, this.top + count + 1);

                if (i == this.activeObjectIndex && this.active == true)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                this.PrintObject(i);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                count++;
            }
        }

        private void ClearContent()
        {
            for (int i = 1; i < this.height - 1; i++)
            {
                string space = new String(' ', this.width - 2);
                Console.SetCursorPosition(this.left + 1, this.top + i);
                Console.Write(space);
            }
        }

        private void PrintObject(int index) // Рисуем в панелях
        {
            if (index < 0 || this.fsObjects.Count <= index)
            {
                throw new Exception(String.Format("Невозможно вывести объект c индексом {0}. Выход индекса за диапазон", index));
            }

            int currentCursorTopPosition = Console.CursorTop;
            int currentCursorLeftPosition = Console.CursorLeft;

            if (!this.discs && index == 0)
            {
                Console.Write("..");
                return;
            }

            Console.Write("{0}", fsObjects[index].Name); //Названия
            Console.SetCursorPosition(currentCursorLeftPosition + this.width / 2, currentCursorTopPosition);
            if (fsObjects[index] is DirectoryInfo)
            {
                Console.Write("{0}", ((DirectoryInfo)fsObjects[index]).LastWriteTime);//Даты
            }
            else
            {
                Console.Write("{0}", ((FileInfo)fsObjects[index]).Length);//Размер
            }
        }

        public void UpdatePanel()
        {
            this.firstObjectIndex = 0;
            this.activeObjectIndex = 0;
            this.Show();
        }

        public void UpdateContent(bool updateList)
        {
            if (updateList)
            {
                this.SetLists();
            }
            this.ClearContent();
            this.PrintContent();
        }

        private void ActivateObject(int index) //При скроллировании
        {
            int offsetY = this.activeObjectIndex - this.firstObjectIndex;
            Console.SetCursorPosition(this.left + 1, this.top + offsetY + 1);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            this.PrintObject(index);
                        
        }

        private void DeactivateObject(int index)
        {
            int offsetY = this.activeObjectIndex - this.firstObjectIndex;
            Console.SetCursorPosition(this.left + 1, this.top + offsetY + 1);

            this.PrintObject(index);
        }


    }
}
