namespace l5extra2
{
    public class ToDo
    {
        public string Title { get; set; }
        public int IsDone { get; set; }

        public ToDo()
        {
            Title = "0";
            IsDone = 0;
        }
        public ToDo(string title, int isdone)
        {
            Title = title;
            IsDone = isdone;
        }


    }
}
