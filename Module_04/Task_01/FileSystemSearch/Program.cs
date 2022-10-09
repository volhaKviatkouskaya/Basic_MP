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
            var filter = FilterSetting.GetFilter();

            FileSystemVisitor systemVisitor = new(filter);

            systemVisitor.StartEvent += () => Console.WriteLine("Search started!");
            systemVisitor.FinishEvent += () => Console.WriteLine("Search finished!");

            systemVisitor.FoundItem += (x) =>
            {
                var itemType = x.IsFolder ? "Directory" : "File";
                Console.WriteLine($"{itemType}  found: {x.Name}");
            };

            systemVisitor.FoundFilteredItem += (x) =>
            {
                var itemType = x.IsFolder ? "directory" : "file";
                Console.WriteLine($"Filtered {itemType} found: {x.Name}");
                return ActionType.KeepItem;
            };

            var array = systemVisitor.Search(@"C:\FileSystem");
            PrintToConsole(array);
        }
    }
}
