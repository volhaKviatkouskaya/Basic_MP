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
            var infinitySearch = true;
            do
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
                    Console.WriteLine("Exclude item(1), Keep item(2), Abort search(3)?");
                    var userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput == (int)ActionType.AbortSearch)
                        infinitySearch = false;
                    return (ActionType)userInput;
                };

                var array = systemVisitor.Search(@"C:\FileSystem");

                if (infinitySearch) PrintToConsole(array);

            } while (infinitySearch);
        }
    }
}
