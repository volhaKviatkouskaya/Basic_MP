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

            systemVisitor.FoundItem += (x) => Console.WriteLine($"Directory found: {x}");

            systemVisitor.FoundFilteredItem += (x) =>
            {

                var itemType = "Deirectory";
                if (!x.IsFolder)
                {
                    itemType = "File";
                }
                Console.WriteLine($"Filtered {itemType} found: {x}");
                return (File.GetAttributes(x.Name) & FileAttributes.Hidden) == 0;
            };

            var array = systemVisitor.Search(@"C:\FileSystem");
            PrintToConsole(array);
        }

    }
}
