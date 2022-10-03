namespace FileSystemVisitor
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
            var path = @"C:\FileSystem";
            FileSystem fs = new();

            List<string> some =fs.GetFileSystemList(path,new List<string>());
            PrintToConsole(some.ToArray());
        }
    }
}

