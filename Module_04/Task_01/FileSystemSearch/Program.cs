namespace FileSystemSearch
{
    public static class Program
    {
        public static void PrintToConsole(IEnumerable<SearchedItem> array)
        {
            Console.WriteLine("Search result:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine();
            var filter = FilterSetting.GetFilter();

            FileSystemVisitor systemVisitor = new(filter);

            systemVisitor.StartEvent += () => Console.WriteLine("Search started!");
            systemVisitor.FinishEvent += () => Console.WriteLine("Search finished!");

            systemVisitor.FoundDir += (x) => Console.WriteLine($"Directory found: {x}");
            systemVisitor.FoundFile += (x) => Console.WriteLine($"File found: {x}");

            systemVisitor.FoundFilteredDir += (x) => Console.WriteLine($"Filtered directory found: {x}");
            systemVisitor.FoundFilteredFile += (x) => Console.WriteLine($"Filtered file found: {x}");

            var array = systemVisitor.Search(@"C:\FileSystem");
            PrintToConsole(array);
        }
    }
}
