namespace FileSystemSearch
{
    public static class Program
    {
        public static void PrintToConsole(string[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public static void Main(string[] args)
        {
            FileSystemVisitor visitor2 = new();
            var array = visitor2.Search("C://FileSystem");
            PrintToConsole(array.ToArray());
        }
    }
}
