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
            FileSystemVisitor visitor = new();
            List<string> visList = visitor.GetFileSystemList("C://FileSystem", new List<string>());
            PrintToConsole(visList.ToArray());
        }
    }
}
